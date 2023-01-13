using neptune_hidapi.net;
using neptune_osk;
using NeptuneOskShared;
using SharedMemory;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static System.Windows.Forms.AxHost;

namespace neptune_osk_main
{
    public class OverlayController
    {
        public OverlayController(ref Settings _settings)
        {
            settings = _settings;

            Process[] processes = Process.GetProcessesByName("NeptuneOskOverlay");
            foreach(Process process in processes)
            {
                process.Kill();
            }
        }

        const int refreshRate = 1;
        readonly Settings settings;

        ConcurrentQueue<OskEvent> eventQueue = new ConcurrentQueue<OskEvent>();
        Dictionary<NeptuneControllerButton, bool> prevState = new Dictionary<NeptuneControllerButton, bool>();

        Process overlayProcess = null;
        CancellationTokenSource cts = new CancellationTokenSource();

        public OskRect OskRect = new OskRect();

        public void AddOskEvent(NeptuneControllerInputState state)
        {
            OskEvent oskEvent = new OskEvent();

            int index = 0;
            foreach (var shortcut in settings.ClickShortCut.Keys)
            {
                EventTouch eventTouch = new EventTouch();

                if (state.ButtonState[shortcut])
                {
                    eventTouch.Pos_X = settings.ClickShortCut[shortcut].X;
                    eventTouch.Pos_Y = settings.ClickShortCut[shortcut].Y;
                    eventTouch.IsPressed = true;
                }
                else if (state.ButtonState[shortcut] == false)
                {
                    eventTouch.IsPressed = false;
                }

                switch (index)
                {
                    case 0:
                        oskEvent.Event1 = eventTouch;
                        break;
                    case 1:
                        oskEvent.Event2 = eventTouch;
                        break;
                    case 2:
                        oskEvent.Event3 = eventTouch;
                        break;
                    case 3:
                        oskEvent.Event4 = eventTouch;
                        break;
                    case 4:
                        oskEvent.Event5 = eventTouch;
                        break;
                    default:
                        continue;
                }

                ++index;
                if (index >= 5)
                    break;
            }

            if (state.AxesState[NeptuneControllerAxis.LeftPadX] != 0 && state.AxesState[NeptuneControllerAxis.LeftPadY] != 0)
            {
                oskEvent.Left = new InputTouchPad() { Pos_X = state.AxesState[NeptuneControllerAxis.LeftPadX] , Pos_Y = state.AxesState[NeptuneControllerAxis.LeftPadY] , IsTouched = true, IsPressed = state.ButtonState[NeptuneControllerButton.BtnLPadPress] };                
            }
            else
            {
                oskEvent.Left = new InputTouchPad() { IsPressed = false, IsTouched = false };
            }

            if (state.AxesState[NeptuneControllerAxis.RightPadX] != 0 && state.AxesState[NeptuneControllerAxis.RightPadY] != 0)
            {
                oskEvent.Right = new InputTouchPad() { Pos_X = state.AxesState[NeptuneControllerAxis.RightPadX], Pos_Y = state.AxesState[NeptuneControllerAxis.RightPadY], IsTouched = true, IsPressed = state.ButtonState[NeptuneControllerButton.BtnRPadPress] };
            }
            else
            {
                oskEvent.Right = new InputTouchPad() { IsPressed = false, IsTouched = false };
            }

            foreach (var button in state.ButtonState.Buttons)
            {
                if (prevState.ContainsKey(button) == false)
                    prevState.Add(button, state.ButtonState[button]);
                else
                    prevState[button] = state.ButtonState[button];
            }

            eventQueue.Enqueue(oskEvent);
        }


        public void StartOverlay(int overlab, Color dotColor)
        {
            if(OskRect.Width == 0)
            {
                return;
            }

            
            Stop();
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                Arguments = $"-o {overlab} -a {dotColor.A} -r {dotColor.R} -g {dotColor.G} -b {dotColor.B} -x {OskRect.Pos_X} -y {OskRect.Pos_Y} -w {OskRect.Width} -h {OskRect.Height}",
                FileName = $"NeptuneOskOverlay.exe"
            };
            overlayProcess = Process.Start(processStartInfo);

            cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Run), cts.Token);
        }
        
        public void Stop()
        {
            if (overlayProcess != null && overlayProcess.HasExited == false)
            {
                overlayProcess.Kill();
                overlayProcess = null;
            }
            if(cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
        
        public void Run(object obj)
        {
            CancellationToken token = (CancellationToken)obj;
            OskEvent oskCheckStruct = new OskEvent();
            eventQueue.Clear();
                        
            int bufferSize = Marshal.SizeOf(oskCheckStruct);
            using (CircularBuffer oskServer = new CircularBuffer("OskInput", 2, bufferSize))
            {
                while (true)
                {
                    OskEvent oskEvent;
                    if (eventQueue.TryDequeue(out oskEvent))
                    {
                        oskServer.Write<OskEvent>(ref oskEvent);
                    }
                    else
                    {
                        oskServer.Write<OskEvent>(ref oskEvent);
                    }

                    if (token.IsCancellationRequested)
                        return ;
                }
            }
        }
    }
}

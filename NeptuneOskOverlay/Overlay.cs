
using GameOverlay.Windows;

using NeptuneOskShared;
using System.Drawing;
using System.Text;
using static neptune_osk.Util;
using Font = GameOverlay.Drawing.Font;
using Graphics = GameOverlay.Drawing.Graphics;
using Image = GameOverlay.Drawing.Image;
using SolidBrush = GameOverlay.Drawing.SolidBrush;

namespace neptune_osk
namespace NeptuneOskOverlay
{
    public partial class Overlay
    {
        IntPtr oskHandle = IntPtr.Zero;

        Graphics gfx;
        private GraphicsWindow _window;
        private Dictionary<string, SolidBrush> _brushes;
        private Dictionary<string, Font> _fonts;
        private Dictionary<string, Image> _images;

        public float leftXPos, leftYPos, rightXPos, rightYPos;
        public bool leftTouched = false;
        public bool rightTouched = false;

        public bool[] eventTouchs = new bool[5];
        public bool[] prevEventTouchs = new bool[5];
        PointerTouchInfo[] touchInfos = new PointerTouchInfo[5];

        public bool leftPressed = false;
        PointerTouchInfo leftContact;
        public bool rightPressed = false;
        PointerTouchInfo rightContact;

        public Queue<PointerTouchInfo> EventTouch = new Queue<PointerTouchInfo>();

        public int OverlabPercentage = 50;
        public int OffsetY = 0;

        public Overlay()
        InitOverlay _initParam;

        public Overlay(InitOverlay receivedInitParam)
        {
            Util.SetProcessDPIAware();
            InitializeComponent();

            OverlabPercentage = receivedInitParam.OverlabPercent;
            _initParam = receivedInitParam;

            _brushes = new Dictionary<string, SolidBrush>();
            _fonts = new Dictionary<string, Font>();
            _images = new Dictionary<string, Image>();

            gfx = new Graphics()
            {
                MeasureFPS = false,
                PerPrimitiveAntiAliasing = true,
                TextAntiAliasing = true
            };

            _window = new GraphicsWindow(0, 0, 1280, 600, gfx)
            _window = new GraphicsWindow(_initParam.Target_X, _initParam.Target_Y, _initParam.Target_Width, _initParam.Target_Height, gfx)
            {
                FPS = 60,
                IsTopmost = true,
                IsVisible = true
            };

            _window.DestroyGraphics += _window_DestroyGraphics;
            _window.DrawGraphics += _window_DrawGraphics;
            _window.SetupGraphics += _window_SetupGraphics;

            Init();
        }

        public void Show()
        {
            if (_window.IsInitialized)
                _window.Show();
        }

        public void Hide()
        {
            if(_window.IsInitialized)
                _window.Hide();
        }
             

        private void _window_DestroyGraphics(object sender, DestroyGraphicsEventArgs e)
        {
            foreach (var pair in _brushes) pair.Value.Dispose();
            foreach (var pair in _fonts) pair.Value.Dispose();
            foreach (var pair in _images) pair.Value.Dispose();
        }

        public void SetLeftPadPos(float leftX, float leftY)
        {
            leftXPos = _window.Width * 0.01f * OverlabPercentage * leftX;
            leftYPos = _window.Height * leftY + OffsetY;
            leftTouched = true;
        }
        public void SetRightPadPos(float rightX, float rightY)
        {
            rightXPos = (_window.Width - _window.Width * 0.01f * OverlabPercentage) + _window.Width * 0.01f * OverlabPercentage * rightX;
            rightYPos = _window.Height * rightY + OffsetY;
            rightTouched = true;
        }
        

        private void _window_DrawGraphics(object sender, DrawGraphicsEventArgs e)
        {
            var gfx = e.Graphics;

            var padding = 16;
            var infoText = new StringBuilder()
                .Append("FPS: ").Append(gfx.FPS.ToString().PadRight(padding))
                .Append("FrameTime: ").Append(e.FrameTime.ToString().PadRight(padding))
                .Append("FrameCount: ").Append(e.FrameCount.ToString().PadRight(padding))
                .Append("DeltaTime: ").Append(e.DeltaTime.ToString().PadRight(padding))
                .ToString();

            gfx.ClearScene(_brushes["background"]);

            //gfx.DrawTextWithBackground(_fonts["consolas"], _brushes["green"], _brushes["black"], 58, 20, $"{leftTouched}, {leftXPos}, {leftYPos} | {rightTouched}, {rightXPos} , {rightYPos}");//infoText);

            if(leftTouched)
            {
                gfx.DrawCircle(_brushes["touch"], leftXPos, leftYPos, 10, 5.0f);
            }

            if (rightTouched)
            {
                gfx.DrawCircle(_brushes["touch"], rightXPos, rightYPos, 10, 5.0f);
            }
        }

        private void _window_SetupGraphics(object sender, SetupGraphicsEventArgs e)
        {
            var gfx = e.Graphics;

            if (e.RecreateResources)
            {
                foreach (var pair in _brushes) pair.Value.Dispose();
                foreach (var pair in _images) pair.Value.Dispose();
            }

            _brushes["black"] = gfx.CreateSolidBrush(0, 0, 0);
            _brushes["white"] = gfx.CreateSolidBrush(255, 255, 255);
            _brushes["red"] = gfx.CreateSolidBrush(255, 0, 0);
            _brushes["green"] = gfx.CreateSolidBrush(0, 255, 0);
            _brushes["touch"] = gfx.CreateSolidBrush(255, 0, 0);
            _brushes["background"] = gfx.CreateSolidBrush(255, 255, 255, 0);
            _brushes["grid"] = gfx.CreateSolidBrush(255, 255, 255, 0.2f);
            _brushes["random"] = gfx.CreateSolidBrush(0, 0, 0);
            _brushes["touch"] = gfx.CreateSolidBrush(_initParam.DotColor_R, _initParam.DotColor_G, _initParam.DotColor_B, _initParam.DotColor_A);
            _brushes["background"] = gfx.CreateSolidBrush(255, 255, 255, 50);

            if (e.RecreateResources) return;

            _fonts["arial"] = gfx.CreateFont("Arial", 12);
            _fonts["consolas"] = gfx.CreateFont("Consolas", 14);

            //_fonts["arial"] = gfx.CreateFont("Arial", 12);
            //_fonts["consolas"] = gfx.CreateFont("Consolas", 14);
        }

        public bool Init()
        public void Init()
        {
            _window.Create();
            _window.Show();
            //SetRect(_initParam.Target_X, _initParam.Target_Y, _initParam.Target_Width, _initParam.Target_Height);
        }

        public void OnReceivedOskEvent(OskEvent oskEvent)
        {

            oskHandle = Util.FindWindow("ApplicationFrameWindow", "");
            ProgressEventTouch(0, oskEvent.Event1);
            ProgressEventTouch(1, oskEvent.Event2);
            ProgressEventTouch(2, oskEvent.Event3);
            ProgressEventTouch(3, oskEvent.Event4);
            ProgressEventTouch(3, oskEvent.Event5);

            bool isValidHandle = (IntPtr.Size == 4) ? (oskHandle.ToInt32() > 0) : (oskHandle.ToInt64() > 0);
            if (isValidHandle)
            if (oskEvent.Left.IsTouched)
            {
                return true;
                float leftX = (float)Util.Map(short.MinValue, short.MaxValue, 0, 1, oskEvent.Left.Pos_X);
                float leftY = (float)Util.Map(short.MinValue, short.MaxValue, 0, 1, oskEvent.Left.Pos_Y);
                SetLeftPadPos(leftX, 1 - leftY);
            }
            else
            {
                leftTouched = false;
            }

            return false;
            if (oskEvent.Right.IsTouched)
            {
                float rightX = (float)Util.Map(short.MinValue, short.MaxValue, 0, 1, oskEvent.Right.Pos_X);
                float rightY = (float)Util.Map(short.MinValue, short.MaxValue, 0, 1, oskEvent.Right.Pos_Y);
                SetRightPadPos(rightX, 1 - rightY);
            }
            else
            {
                rightTouched = false;
            }

            ProcessTouch(oskEvent.Left.IsPressed, oskEvent.Right.IsPressed);
        }

        public void AddEventTouch(int xPos, int yPos)
        private void ProgressEventTouch(int index, EventTouch eventTouch)
        {
            Task.Factory.StartNew(() =>
            if (prevEventTouchs[index] == false && eventTouch.IsPressed)
            {
                PointerTouchInfo touchInfo = MakePointerTouchInfo(xPos, yPos, 5, 0);
                touchInfo.PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                TouchInjector.InjectTouchInput(1, new PointerTouchInfo[1] { touchInfo });
                touchInfos[index] = MakePointerTouchInfo(eventTouch.Pos_X, eventTouch.Pos_Y, 5, 0);
                touchInfos[index].PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;

                Thread.Sleep(100);
                touchInfo.PointerInfo.PointerFlags = PointerFlags.UP;
                TouchInjector.InjectTouchInput(1, new PointerTouchInfo[1] { touchInfo });
            });
                EventTouch.Enqueue(touchInfos[index]);
            }
            else if (prevEventTouchs[index] && eventTouch.IsPressed == false)
            {
                touchInfos[index].PointerInfo.PointerFlags = PointerFlags.UP;
                EventTouch.Enqueue(touchInfos[index]);
            }
            else if(eventTouch.IsPressed)
            {
                touchInfos[index].Move(eventTouch.Pos_X - touchInfos[index].PointerInfo.PtPixelLocation.X, eventTouch.Pos_Y - touchInfos[index].PointerInfo.PtPixelLocation.Y);
                PointerFlags oFlags = PointerFlags.INRANGE | PointerFlags.INCONTACT | PointerFlags.UPDATE;
                touchInfos[index].PointerInfo.PointerFlags = oFlags;
                EventTouch.Enqueue(touchInfos[index]);
            }
            
            prevEventTouchs[index] = eventTouch.IsPressed;
        }

        public void ProcessTouch(bool left, bool right)
        private void ProcessTouch(bool left, bool right)
        {
            if (leftPressed == false && left)
            {
                leftPressed = true;
                leftContact = MakePointerTouchInfo((int)(_window.X + leftXPos), (int)(_window.Y + leftYPos), 5, 0);
                PointerFlags oFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                leftContact.PointerInfo.PointerFlags = oFlags;
                EventTouch.Enqueue(leftContact);
            }
            else if (left)
            {
                leftContact.Move((int)(_window.X + leftXPos - leftContact.PointerInfo.PtPixelLocation.X), (int)(_window.Y + leftYPos - leftContact.PointerInfo.PtPixelLocation.Y));
                PointerFlags oFlags = PointerFlags.INRANGE | PointerFlags.INCONTACT | PointerFlags.UPDATE;
                leftContact.PointerInfo.PointerFlags = oFlags;
                EventTouch.Enqueue(leftContact);
            }
            else if (leftPressed && left == false)
            {
                leftContact.PointerInfo.PointerFlags = PointerFlags.UP;
                leftPressed = false;
                EventTouch.Enqueue(leftContact);
            }

            if (rightPressed == false && right)
            {
                rightPressed = true;
                rightContact = MakePointerTouchInfo((int)(_window.X + rightXPos), (int)(_window.Y + rightYPos), 5, 0);
                PointerFlags oFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                rightContact.PointerInfo.PointerFlags = oFlags;
                EventTouch.Enqueue(rightContact);
            }
            else if (right)
            {
                rightContact.Move((int)(_window.X + rightXPos - rightContact.PointerInfo.PtPixelLocation.X), (int)(_window.Y + rightYPos - rightContact.PointerInfo.PtPixelLocation.Y));
                PointerFlags oFlags = PointerFlags.INRANGE | PointerFlags.INCONTACT | PointerFlags.UPDATE;
                rightContact.PointerInfo.PointerFlags = oFlags;
                EventTouch.Enqueue(rightContact);
            }
            else if (rightPressed && right == false)
            {
                rightContact.PointerInfo.PointerFlags = PointerFlags.UP;
                rightPressed = false;
                EventTouch.Enqueue(rightContact);
            }


            TouchInjector.InjectTouchInput(EventTouch.Count, EventTouch.ToArray());
            EventTouch.Clear();
        }

        private PointerTouchInfo MakePointerTouchInfo(int x, int y, int radius,
            uint orientation = 90, uint pressure = 32000)
        {
            PointerTouchInfo contact = new PointerTouchInfo();
            contact.PointerInfo.pointerType = PointerInputType.TOUCH;
            contact.TouchFlags = TouchFlags.NONE;
            contact.Orientation = orientation;
            contact.Pressure = pressure;
            contact.TouchMasks = TouchMask.CONTACTAREA | TouchMask.ORIENTATION | TouchMask.PRESSURE;
            contact.PointerInfo.PtPixelLocation.X = x;
            contact.PointerInfo.PtPixelLocation.Y = y;
            uint unPointerId = IdGenerator.GetUinqueUInt();
            contact.PointerInfo.PointerId = unPointerId;
            contact.ContactArea.left = x - radius;
            contact.ContactArea.right = x + radius;
            contact.ContactArea.top = y - radius;
            contact.ContactArea.bottom = y + radius;
            return contact;
        }

        public void SetRect(int xPos, int yPos, int width, int height)
        {
            if (height <= 0)
                height = 1;
            if (width <= 0)
                width = 1;
            _window.Resize(xPos, yPos, width, height);
        }


        private void InitializeComponent()
        {
        }
    }
}

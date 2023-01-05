
using GameOverlay.Windows;
using System.Diagnostics;
using System.Text;
using static neptune_osk.Util;
using Font = GameOverlay.Drawing.Font;
using Graphics = GameOverlay.Drawing.Graphics;
using Image = GameOverlay.Drawing.Image;
using SolidBrush = GameOverlay.Drawing.SolidBrush;

namespace neptune_osk
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

        public bool leftPressed = false;
        PointerTouchInfo leftContact;
        public bool rightPressed = false;
        PointerTouchInfo rightContact;

        public Queue<PointerTouchInfo> EventTouch = new Queue<PointerTouchInfo>();

        public int OverlabPercentage = 50;
        public int OffsetY = 0;

        Process overlayFakeProc = null;

        public Overlay()
        {
            InitializeComponent();

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
            {
                FPS = 60,
                IsTopmost = true,
                IsVisible = true
            };

            _window.DestroyGraphics += _window_DestroyGraphics;
            _window.DrawGraphics += _window_DrawGraphics;
            _window.SetupGraphics += _window_SetupGraphics;
        }

        public void Show()
        {
            if (_window.IsInitialized)
                _window.Show();

            if(overlayFakeProc == null)
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "NeptuneOskOverlay"
                };
                overlayFakeProc = Process.Start(processStartInfo);
                overlayFakeProc.PriorityClass = ProcessPriorityClass.AboveNormal;
            }
        }

        public void Hide()
        {
            if(_window.IsInitialized)
                _window.Hide();

            if(overlayFakeProc != null)
            {
                overlayFakeProc.Kill();
                overlayFakeProc.Dispose();
                overlayFakeProc = null;
            }
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

            gfx.ClearScene(_brushes["background"]);

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

            _brushes["touch"] = gfx.CreateSolidBrush(255, 0, 0);
            _brushes["background"] = gfx.CreateSolidBrush(255, 255, 255, 0);

            if (e.RecreateResources) return;
        }

        public bool Init()
        {
            _window.Create();


            oskHandle = Util.FindWindow("ApplicationFrameWindow", "");

            bool isValidHandle = (IntPtr.Size == 4) ? (oskHandle.ToInt32() > 0) : (oskHandle.ToInt64() > 0);
            if (isValidHandle)
            {
                return true;
            }

            return false;
        }

        public void AddEventTouch(int xPos, int yPos)
        {
            Task.Factory.StartNew(() =>
            {
                PointerTouchInfo touchInfo = MakePointerTouchInfo(xPos, yPos, 5, 0);
                touchInfo.PointerInfo.PointerFlags = PointerFlags.DOWN | PointerFlags.INRANGE | PointerFlags.INCONTACT;
                TouchInjector.InjectTouchInput(1, new PointerTouchInfo[1] { touchInfo });

                Thread.Sleep(100);
                touchInfo.PointerInfo.PointerFlags = PointerFlags.UP;
                TouchInjector.InjectTouchInput(1, new PointerTouchInfo[1] { touchInfo });
            });
        }

        public void ProcessTouch(bool left, bool right)
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

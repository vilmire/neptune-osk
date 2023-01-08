using System.Drawing;
using System.Runtime.InteropServices;

namespace NeptuneOskOverlay
{
    public static class Util
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();



        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        public enum WMessages : int
        {
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201, //Left mousebutton down
            WM_LBUTTONUP = 0x202,  //Left mousebutton up
            WM_LBUTTONDBLCLK = 0x203, //Left mousebutton doubleclick
            WM_RBUTTONDOWN = 0x204, //Right mousebutton down
            WM_RBUTTONUP = 0x205,   //Right mousebutton up
            WM_RBUTTONDBLCLK = 0x206, //Right mousebutton doubleclick
            WM_KEYDOWN = 0x100,  //Key down
            WM_KEYUP = 0x101,   //Key up
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105,
            WM_CHAR = 0x102,     //char
            WM_COMMAND = 0x111
        }

        [Flags()]
        public enum RedrawWindowFlags : uint
        {
            /// <summary>
            /// Invalidates the rectangle or region that you specify in lprcUpdate or hrgnUpdate.
            /// You can set only one of these parameters to a non-NULL value. If both are NULL, RDW_INVALIDATE invalidates the entire window.
            /// </summary>
            Invalidate = 0x1,

            /// <summary>Causes the OS to post a WM_PAINT message to the window regardless of whether a portion of the window is invalid.</summary>
            InternalPaint = 0x2,

            /// <summary>
            /// Causes the window to receive a WM_ERASEBKGND message when the window is repainted.
            /// Specify this value in combination with the RDW_INVALIDATE value; otherwise, RDW_ERASE has no effect.
            /// </summary>
            Erase = 0x4,

            /// <summary>
            /// Validates the rectangle or region that you specify in lprcUpdate or hrgnUpdate.
            /// You can set only one of these parameters to a non-NULL value. If both are NULL, RDW_VALIDATE validates the entire window.
            /// This value does not affect internal WM_PAINT messages.
            /// </summary>
            Validate = 0x8,

            NoInternalPaint = 0x10,

            /// <summary>Suppresses any pending WM_ERASEBKGND messages.</summary>
            NoErase = 0x20,

            /// <summary>Excludes child windows, if any, from the repainting operation.</summary>
            NoChildren = 0x40,

            /// <summary>Includes child windows, if any, in the repainting operation.</summary>
            AllChildren = 0x80,

            /// <summary>Causes the affected windows, which you specify by setting the RDW_ALLCHILDREN and RDW_NOCHILDREN values, to receive WM_ERASEBKGND and WM_PAINT messages before the RedrawWindow returns, if necessary.</summary>
            UpdateNow = 0x100,

            /// <summary>
            /// Causes the affected windows, which you specify by setting the RDW_ALLCHILDREN and RDW_NOCHILDREN values, to receive WM_ERASEBKGND messages before RedrawWindow returns, if necessary.
            /// The affected windows receive WM_PAINT messages at the ordinary time.
            /// </summary>
            EraseNow = 0x200,

            Frame = 0x400,

            NoFrame = 0x800
        }

        [Flags]
        public enum SetWindowPosFlag : uint
        {
            /// <summary>
            /// SWP_ASYNCWINDOWPOS
            /// </summary>
            SWP_ASYNCWINDOWPOS = 0x4000,

            /// <summary>
            /// SWP_DEFERERASE
            /// </summary>
            SWP_DEFERERASE = 0x2000,

            /// <summary>
            /// SWP_DRAWFRAME
            /// </summary>
            SWP_DRAWFRAME = 0x0020,

            /// <summary>
            /// SWP_FRAMECHANGED
            /// </summary>
            SWP_FRAMECHANGED = 0x0020,

            /// <summary>
            /// SWP_HIDEWINDOW
            /// </summary>
            SWP_HIDEWINDOW = 0x0080,

            /// <summary>
            /// SWP_NOACTIVATE
            /// </summary>
            SWP_NOACTIVATE = 0x0010,

            /// <summary>
            /// SWP_NOCOPYBITS
            /// </summary>
            SWP_NOCOPYBITS = 0x0100,

            /// <summary>
            /// SWP_NOMOVE
            /// </summary>
            SWP_NOMOVE = 0x0002,

            /// <summary>
            /// SWP_NOOWNERZORDER
            /// </summary>
            SWP_NOOWNERZORDER = 0x0200,

            /// <summary>
            /// SWP_NOREDRAW
            /// </summary>
            SWP_NOREDRAW = 0x0008,

            /// <summary>
            /// SWP_NOREPOSITION
            /// </summary>
            SWP_NOREPOSITION = 0x0200,

            /// <summary>
            /// SWP_NOSENDCHANGING
            /// </summary>
            SWP_NOSENDCHANGING = 0x0400,

            /// <summary>
            /// SWP_NOSIZE
            /// </summary>
            SWP_NOSIZE = 0x0001,

            /// <summary>
            /// SWP_NOZORDER
            /// </summary>
            SWP_NOZORDER = 0x0004,

            /// <summary>
            /// SWP_SHOWWINDOW
            /// </summary>
            SWP_SHOWWINDOW = 0x0040,
        }

        public const int WS_EX_TOPMOST = -8;
        public const int GWL_EXSTYLE = -20;
        public const int WS_EX_LAYERED = 0x80000;
        public const int LWA_ALPHA = 0x2;
        public const int LWA_COLORKEY = 0x1;

        public static double Map(double a1, double a2, double b1, double b2, double s) => b1 + (s - a1) * (b2 - b1) / (a2 - a1);

        public static Point GetCursorPosition()
        {
            POINT lpPoint;
            bool success = GetCursorPos(out lpPoint);
            if (!success)
                return new Point(0, 0);

            return lpPoint;
        }


        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowByCaption(IntPtr zeroHandle, string windowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool AllowSetForegroundWindow(uint dwProcessId);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, Int32 nIndex);

        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr windowHandle, IntPtr windowHandleInsertAfter, int x, int y, int width, int height, SetWindowPosFlag flag);

    }
}

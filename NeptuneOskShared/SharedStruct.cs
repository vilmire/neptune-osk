using System.Runtime.InteropServices;

namespace NeptuneOskShared
{
    public struct InitOverlay
    {
        public int OverlabPercent { get; set; }//55
        public byte DotColor_A { get; set; }
        public byte DotColor_R { get; set; }
        public byte DotColor_G { get; set; }
        public byte DotColor_B { get; set; }

        public int Target_X { get; set; }
        public int Target_Y { get; set; }
        public int Target_Width { get; set; }
        public int Target_Height { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventTouch
    {
        public bool IsPressed { get; set; }
        public int Pos_X { get; set; }
        public int Pos_Y { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InputTouchPad
    {
        public bool IsTouched { get; set; }
        public bool IsPressed { get; set; }
        public int Pos_X { get; set; }
        public int Pos_Y { get; set; }
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OskRect
    {
        public int Pos_X { get; set; }
        public int Pos_Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OskEvent
    {
        public InputTouchPad Left;
        public InputTouchPad Right;
        public OskRect OskRect;
        public EventTouch Event1;
        public EventTouch Event2;
        public EventTouch Event3;
        public EventTouch Event4;
        public EventTouch Event5;
    }
}
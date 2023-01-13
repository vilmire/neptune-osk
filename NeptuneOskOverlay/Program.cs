






using NeptuneOskShared;
using SharedMemory;
using System.Drawing;
using System.Diagnostics;
using NDesk.Options;
using GameOverlay.Drawing;

namespace NeptuneOskOverlay
{
    internal class Program
    {
        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: [OPTIONS]+ message");
            p.WriteOptionDescriptions(Console.Out);
        }

        static void Main(string[] args)
        {
#region parseArgs
            bool show_help = false;
            int overlabPercent = 55;
            byte dotColor_A = 255;
            byte dotColor_R = 255;
            byte dotColor_G = 0;
            byte dotColor_B = 0;
            int target_X = 0;
            int target_Y = 0;
            int target_Width = 100;
            int target_Height = 100;

            OptionSet p = new OptionSet() {
            { "o|overlab=", "overlabPercent",
              (int v) => overlabPercent = v },
            { "a|dotColor_A=", "dotColor_A",
              (byte v) => dotColor_A = v },
            { "r|dotColor_R=", "dotColor_R",
              (byte v) => dotColor_R = v },
            { "g|dotColor_G=", "dotColor_G",
              (byte v) => dotColor_G = v },
            { "b|dotColor_B=", "dotColor_B",
              (byte v) => dotColor_B = v },
            { "x|target_X=", "target_X",
              (int v) => target_X = v },
            { "y|target_Y=", "target_Y",
              (int v) => target_Y = v },
            { "w|target_Width=", "target_Width",
              (int v) => target_Width = v },
            { "h|target_Height=", "target_Height",
              (int v) => target_Height = v },
            { "help",  "show this message and exit",
              v => show_help = v != null },
            };
                        
            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("NeptuneOskOverlay: ");
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `NeptuneOskOverlay.exe --help' for more information.");
                return;
            }

            if (show_help)
            {
                ShowHelp(p);
                return;
            }

            string message;
            if (extra.Count > 0)
            {
                message = string.Join(" ", extra.ToArray());
                Console.WriteLine("Using new message: {0}", message);
            }
            else
            {
                message = "";
                Console.WriteLine("Using default", message);
            }

#endregion

            InitOverlay initOverlay = new InitOverlay { OverlabPercent = overlabPercent, DotColor_A = dotColor_A, DotColor_B = dotColor_B, DotColor_G = dotColor_G, DotColor_R = dotColor_R, Target_X = target_X, Target_Y = target_Y, Target_Width = target_Width, Target_Height = target_Height };
            Console.WriteLine($"{initOverlay.Target_X},{initOverlay.Target_Y}, {initOverlay.Target_Width}, {initOverlay.Target_Height}");

            using (CircularBuffer oskClient = new CircularBuffer("OskInput"))
            {
                Overlay overlay = new Overlay(initOverlay);                

                TouchInjector.InitializeTouchInjection();
                while (true)
                {
                    OskEvent oskEvent;
                    int readCount = oskClient.Read<OskEvent>(out oskEvent, timeout:30000);
                    if(readCount == 0)
                    {
                        //TimeOut.
                        //overlay.Set
                        Environment.Exit(0);
                    }

                    overlay.OnReceivedOskEvent(oskEvent);
                }
            }
        }
    }
}
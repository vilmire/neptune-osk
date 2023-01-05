using neptune_hidapi.net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neptune_osk
{
    public class Settings
    {
        public Settings()
        {
            ToggleShortCut = new NeptuneControllerButton[2] { NeptuneControllerButton.BtnSteam, NeptuneControllerButton.BtnX };
            ClickShortCut = new Dictionary<NeptuneControllerButton, Point>();
            OskAlpha = 127;
            OverlabPercentage = 55;
            Offset_Y = 0;
            MinimizeOnStartup = false;
        }

        private const string saveFileName = "setting.json";

        public bool MinimizeOnStartup { get; set; }
        public int OskAlpha { get; set; }
        public int OverlabPercentage { get; set; }
        public int Offset_Y { get; set; }
        public NeptuneControllerButton[] ToggleShortCut { get; set; }
        public Dictionary<NeptuneControllerButton, Point> ClickShortCut { get; set; }


        public void Save()
        {
            string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
            string directoryPath = Path.GetDirectoryName(Application.ExecutablePath);
            string saveFile = Path.Combine(directoryPath, saveFileName);
            File.WriteAllText(saveFile, jsonString);
        }

        public static Settings Load()
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(Application.ExecutablePath);
                string loadFile = Path.Combine(directoryPath, saveFileName);
                if (File.Exists(loadFile) == false)
                {
                    return null;
                }
                string jsonString = File.ReadAllText(loadFile);
                return JsonConvert.DeserializeObject<Settings>(jsonString);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}

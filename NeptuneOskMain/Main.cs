
using Microsoft.Win32;
using neptune_hidapi.net;
using neptune_osk_main;
using NeptuneOskShared;
using Osklib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static neptune_osk.Util;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Application = System.Windows.Forms.Application;
using Point = System.Drawing.Point;

namespace neptune_osk
{
    public partial class Main : Form
    {
        bool Enable = true;
        NeptuneController controller;
        static DateTime lastUpdate = DateTime.Now;
        bool isOskOpend = false;
        Osklib.OnScreenKeyboardWatcher onScreenKeyboardWatcher;
        bool isInitialized = false;
        bool isToggleShortcutSetting = false;
        bool isShortcutSetting = false;
        bool isToggled = false;
        DateTime shortCutSettingStarted;
        OverlayController overlayController;

        Settings settings = new Settings();

        public Main()
        {
            Settings loadedSetting = Settings.Load();
            if (loadedSetting != null)
                settings = loadedSetting;

            overlayController = new OverlayController(ref settings);


            onScreenKeyboardWatcher = new Osklib.OnScreenKeyboardWatcher();
            onScreenKeyboardWatcher.KeyboardOpened += OnScreenKeyboardWatcher_KeyboardOpened;
            onScreenKeyboardWatcher.KeyboardClosed += OnScreenKeyboardWatcher_KeyboardClosed;
            onScreenKeyboardWatcher.ParametersChanged += OnScreenKeyboardWatcher_ParametersChanged;
            InitializeComponent();

            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            showToolStripMenuItem.Click += ShowToolStripMenuItem_Click;
            exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            enableToolStripMenuItem.Click += EnableToolStripMenuItem_Click;
            disableToolStripMenuItem.Click += DisableToolStripMenuItem_Click;
        }

        public void SetOverlayRect(int x, int y, int w, int h)
        {
            overlayController.OskRect.Pos_X = x;
            overlayController.OskRect.Pos_Y = y;
            overlayController.OskRect.Width = w;
            overlayController.OskRect.Height = h;
        }

        private void EnableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enable = true;
            enableCheckBox.Checked = true;
            enableToolStripMenuItem.Checked = true;
            disableToolStripMenuItem.Checked = false;
        }

        private void DisableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enable = false;
            enableCheckBox.Checked = false;
            enableToolStripMenuItem.Checked = false;
            disableToolStripMenuItem.Checked = true;
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            Environment.Exit(0);
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }


        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void OnScreenKeyboardWatcher_ParametersChanged(object sender, EventArgs e)
        {
            if (Enable == false)
                return;


            if (isInitialized && onScreenKeyboardWatcher.Location.Right - onScreenKeyboardWatcher.Location.Left > 0)
            {
                SetOverlayRect(onScreenKeyboardWatcher.Location.Left, onScreenKeyboardWatcher.Location.Top, onScreenKeyboardWatcher.Location.Right - onScreenKeyboardWatcher.Location.Left, onScreenKeyboardWatcher.Location.Bottom - onScreenKeyboardWatcher.Location.Top);
            }
                
        }

        private void OnScreenKeyboardWatcher_KeyboardClosed(object sender, EventArgs e)
        {
            if (Enable == false)
                return;

            controller.LizardMouseEnabled = true;

            isOskOpend = false;

            overlayController.Stop();
        }

        private void OnScreenKeyboardWatcher_KeyboardOpened(object sender, EventArgs e)
        {
            if (Enable == false)
                return;

            isOskOpend = true;

            controller.LizardMouseEnabled = false;

            if (isInitialized == false)
            {
                while(true)
                {
                    if (onScreenKeyboardWatcher.Location.Right - onScreenKeyboardWatcher.Location.Left > 0)
                    {
                        SetOverlayRect(onScreenKeyboardWatcher.Location.Left, onScreenKeyboardWatcher.Location.Top, onScreenKeyboardWatcher.Location.Right - onScreenKeyboardWatcher.Location.Left, onScreenKeyboardWatcher.Location.Bottom - onScreenKeyboardWatcher.Location.Top);
                        break;
                    }
                    Thread.Sleep(1);
                }


                if (oskAlphaTrackBar.InvokeRequired)
                {
                    oskAlphaTrackBar.Invoke(() =>
                    {
                        SetOskTrans((byte)oskAlphaTrackBar.Value);
                    });
                }
                else
                {
                    SetOskTrans((byte)oskAlphaTrackBar.Value);
                }
                isInitialized = true;
            }

            if(overlabTrackBar.InvokeRequired)
            {
                overlabTrackBar.Invoke(() =>
                {
                    overlayController.StartOverlay(overlabTrackBar.Value, Color.Red);
                });
            }
            else
            {
                overlayController.StartOverlay(overlabTrackBar.Value, Color.Red);
            }
        }

        private void SetOskTrans(byte alpha)
        {
            if(alpha < 0)
            {
                alpha = 0;
            }
            else if(alpha > 255)
            {
                alpha = 255;
            }

            IntPtr oskHandle;
            oskHandle = Util.FindWindow("ApplicationFrameWindow", "");

            bool isValidHandle = (IntPtr.Size == 4) ? (oskHandle.ToInt32() > 0):(oskHandle.ToInt64() > 0);
            if(isValidHandle)
            {
                Util.SetWindowLong(oskHandle, Util.GWL_EXSTYLE, Util.GetWindowLong(oskHandle, Util.GWL_EXSTYLE) | Util.WS_EX_LAYERED);
                Util.SetLayeredWindowAttributes(oskHandle, 0, alpha, Util.LWA_ALPHA);
            }
        }

        private void ToggleOSK()
        {
            if (Enable == false)
                return;

            if (Osklib.OnScreenKeyboard.IsOpened())
            {
                controller.LizardMouseEnabled = true;
                Osklib.OnScreenKeyboard.Close();
            }
            else
            {
                controller.LizardMouseEnabled = false;
                Osklib.OnScreenKeyboard.Show();
            }
        }

        private void toggleOskButton_Click(object sender, EventArgs e)
        {
            if(Enable)
                ToggleOSK();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                Process[] fakeoverlays = Process.GetProcessesByName("NeptuneOskOverlay");
                foreach(Process fakeoverlay in fakeoverlays)
                {
                    fakeoverlay.Kill();
                }

                notifyIcon.ContextMenuStrip = contextMenuStrip;
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                object value = rk.GetValue(Application.ProductName);
                if (value != null)
                {
                    addStartupCheckBox.Checked = true;
                }

                hideStartupCheckBox.Checked = settings.MinimizeOnStartup;
                overlabTrackBar.Value = settings.OverlabPercentage;
                offsetYTrackBar.Value = settings.Offset_Y;
                oskAlphaTrackBar.Value = settings.OskAlpha;
                foreach (var clickShortcutKV in settings.ClickShortCut)
                {
                    buttonShortCutListBox.Items.Add($"{clickShortcutKV.Key}|{clickShortcutKV.Value}");
                }
                string shortcutText = "";
                foreach (var buttonName in settings.ToggleShortCut)
                {
                    shortcutText += buttonName.ToString() + "+";
                }
                shortcutText = shortcutText.Remove(shortcutText.Length - 1);
                toggleShortCutTextBox.Text = shortcutText;

                steamButtonComboBox.DataSource = Enum.GetValues(typeof(NeptuneControllerButton));
                overlabPercentageLabel.Text = $"OverlabPercentage : {overlabTrackBar.Value}";
                oskTransparentLabel.Text = $"OSK Transparent : {oskAlphaTrackBar.Value}";

                controller = new NeptuneController();
                controller.OnControllerInputReceived = input => Task.Run(() => Controller_OnControllerInputReceived(input));

                controller.LizardMouseEnabled = true;
                controller.LizardButtonsEnabled = true;

                controller.Open();

                //testTextBox.Text = $"SteamDeck Neptune Connected!";
            }
            catch (Exception ex)
            {
                //testTextBox.Text = ex.Message;
                MessageBox.Show($"Error : {ex.Message}");
            }
        }

        bool IsToggleShortcutPressed(NeptuneControllerInputEventArgs e)
        {
            foreach(var button in settings.ToggleShortCut)
            {
                if (e.State.ButtonState[button] == false)
                {
                    isToggled = false;
                    return false;
                }
            }
            return true;
        }

        private Task Controller_OnControllerInputReceived(NeptuneControllerInputEventArgs e)
        {
            if (Enable == false)
                return Task.CompletedTask;

            if(isToggleShortcutSetting)
            {
                List<NeptuneControllerButton> currentButton = new List<NeptuneControllerButton>();
                string text = "";
                foreach (var buttonName in e.State.ButtonState.Buttons)
                {
                    if (e.State.ButtonState[buttonName])
                    {
                        currentButton.Add(buttonName);
                        text += buttonName.ToString() + "+";
                    }
                }
                text = text.Remove(text.Length - 1);
                if(toggleShortCutTextBox.Text != text)
                {
                    shortCutSettingStarted = DateTime.Now;
                }
                toggleShortCutTextBox.Text = text;

                if(DateTime.Now - shortCutSettingStarted > TimeSpan.FromSeconds(3))
                {
                    isToggleShortcutSetting = false;
                    settings.ToggleShortCut = currentButton.ToArray();
                }
            }

            if (IsToggleShortcutPressed(e) && (DateTime.Now - lastUpdate).TotalMilliseconds > 500 && isToggled == false)
            {
                isToggled = true;
                ToggleOSK();
                lastUpdate = DateTime.Now;
                return Task.CompletedTask;
            }
            else if(isToggled)
            {
                return Task.CompletedTask;
            }

            if(isOskOpend && isShortcutSetting == false)
            {
                overlayController.AddOskEvent(e.State);
            }

            return Task.CompletedTask;
        }

        private void oskAlphaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            oskTransparentLabel.Text = $"OSK Transparent : {oskAlphaTrackBar.Value}";
            SetOskTrans((byte)oskAlphaTrackBar.Value);
        }

        private void overlabTrackBar_ValueChanged(object sender, EventArgs e)
        {
            overlabPercentageLabel.Text = $"OverlabPercentage : {overlabTrackBar.Value}";
        }

        private void offsetYTrackBar_ValueChanged(object sender, EventArgs e)
        {
            offsetYLabel.Text = $"Offset Y : {offsetYTrackBar.Value}";
        }

        private void toggleShortCutTextBox_Enter(object sender, EventArgs e)
        {
            toggleShortCutTextBox.Text = "Press Button(s)";
            isToggleShortcutSetting = true;
        }

        private void toggleShortCutTextBox_Leave(object sender, EventArgs e)
        {
            isToggleShortcutSetting = false;
        }

        private async void addMapButton_Click(object sender, EventArgs e)
        {
            if(steamButtonComboBox.SelectedItem != null && steamButtonComboBox.SelectedItem is NeptuneControllerButton button)
            {
                if(settings.ClickShortCut.ContainsKey(button))
                {
                    MessageBox.Show($"Error. {button} Already Registed!");
                    return;
                }

                MessageBox.Show($"Aim with mouse cursor in 10 seconds");
                
                isShortcutSetting = true;

                await Task.Run(() =>
                {
                    DateTime started = DateTime.Now;
                    Osklib.OnScreenKeyboard.Show();

                    Point point = Util.GetCursorPosition();
                    while (true)
                    {
                        double remainSeconds = (10 - (DateTime.Now - started).TotalSeconds);
                        if (addMapButton.InvokeRequired)
                        {
                            addMapButton.Invoke(() =>
                            {
                                point = Util.GetCursorPosition();
                                addMapButton.Text = $"{button} - x:{point.X} y:{point.Y} ({remainSeconds.ToString("0.##")})";
                            });
                        }
                        if(remainSeconds < 0)
                        {
                            if (addMapButton.InvokeRequired)
                            {
                                addMapButton.Invoke(() =>
                                {
                                    addMapButton.Text = $"Add ShortcutClick";
                                });
                            }

                            controller.LizardMouseEnabled = false;

                            break;
                        }
                        Thread.Sleep(10);

                        controller.LizardMouseEnabled = true;
                    }

                    if(buttonShortCutListBox.InvokeRequired)
                    {
                        buttonShortCutListBox.Invoke(() =>
                        {
                            buttonShortCutListBox.Items.Add($"{button}|{point}");
                            settings.ClickShortCut.Add(button, point);
                        });
                    }
                });

                isShortcutSetting = false;
            }
        }

        private void deleteSelectedShortcutButton_Click(object sender, EventArgs e)
        {
            if(buttonShortCutListBox.SelectedItem != null && buttonShortCutListBox.SelectedItem is string shortcut)
            {
                string enumName = shortcut.Split('|').FirstOrDefault();
                NeptuneControllerButton button;
                bool result = Enum.TryParse<NeptuneControllerButton>(enumName, out button);
                if(result)
                {
                    buttonShortCutListBox.Items.Remove(shortcut);
                    settings.ClickShortCut.Remove(button);                    
                }
            }
        }

        private void addStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (addStartupCheckBox.Checked)
                rk.SetValue(Application.ProductName, Application.ExecutablePath);
            else
                rk.DeleteValue(Application.ProductName, false);

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            settings.OskAlpha = oskAlphaTrackBar.Value;
            settings.Offset_Y = offsetYTrackBar.Value;
            settings.OverlabPercentage = overlabTrackBar.Value;
            settings.MinimizeOnStartup = hideStartupCheckBox.Checked;

            settings.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void hideStartupCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            settings.MinimizeOnStartup = hideStartupCheckBox.Checked;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (settings.MinimizeOnStartup)
                this.Hide();
        }

        private void enableCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(sender != enableCheckBox)
            {
                return;
            }

            if(enableCheckBox.Checked)
            {
                enableToolStripMenuItem.Checked = true;
                disableToolStripMenuItem.Checked = false;
                Enable = true;
            }
            else
            {
                enableToolStripMenuItem.Checked = false;
                disableToolStripMenuItem.Checked = true;
                Enable = false;
            }
        }
    }
}
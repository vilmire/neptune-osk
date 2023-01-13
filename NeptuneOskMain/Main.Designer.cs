namespace neptune_osk
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toggleOskButton = new System.Windows.Forms.Button();
            this.testTextBox = new System.Windows.Forms.TextBox();
            this.oskTransparentLabel = new System.Windows.Forms.Label();
            this.oskAlphaTrackBar = new System.Windows.Forms.TrackBar();
            this.overlabPercentageLabel = new System.Windows.Forms.Label();
            this.overlabTrackBar = new System.Windows.Forms.TrackBar();
            this.offsetYTrackBar = new System.Windows.Forms.TrackBar();
            this.offsetYLabel = new System.Windows.Forms.Label();
            this.ToggleShortCutLabel = new System.Windows.Forms.Label();
            this.toggleShortCutTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.buttonShortCutListBox = new System.Windows.Forms.ListBox();
            this.steamButtonComboBox = new System.Windows.Forms.ComboBox();
            this.addMapButton = new System.Windows.Forms.Button();
            this.deleteSelectedShortcutButton = new System.Windows.Forms.Button();
            this.addStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideStartupCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.oskAlphaTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlabTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYTrackBar)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toggleOskButton
            // 
            this.toggleOskButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toggleOskButton.Location = new System.Drawing.Point(0, 484);
            this.toggleOskButton.Location = new System.Drawing.Point(0, 784);
            this.toggleOskButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toggleOskButton.Name = "toggleOskButton";
            this.toggleOskButton.Size = new System.Drawing.Size(371, 32);
            this.toggleOskButton.Size = new System.Drawing.Size(530, 53);
            this.toggleOskButton.TabIndex = 0;
            this.toggleOskButton.Text = "Toggle OSK";
            this.toggleOskButton.UseVisualStyleBackColor = true;
            this.toggleOskButton.Click += new System.EventHandler(this.toggleOskButton_Click);
            // 
            // testTextBox
            // 
            this.testTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.testTextBox.Location = new System.Drawing.Point(0, 461);
            this.testTextBox.Name = "testTextBox";
            this.testTextBox.Size = new System.Drawing.Size(371, 23);
            this.testTextBox.TabIndex = 1;
            this.testTextBox.Visible = false;
            // 
            // testTextBox
            // 
            this.testTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.testTextBox.Location = new System.Drawing.Point(0, 753);
            this.testTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.testTextBox.Name = "testTextBox";
            this.testTextBox.Size = new System.Drawing.Size(530, 31);
            this.testTextBox.TabIndex = 1;
            this.testTextBox.Visible = false;
            // 
            // oskTransparentLabel
            // 
            this.oskTransparentLabel.AutoSize = true;
            this.oskTransparentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.oskTransparentLabel.Location = new System.Drawing.Point(0, 19);
            this.oskTransparentLabel.Location = new System.Drawing.Point(0, 29);
            this.oskTransparentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.oskTransparentLabel.Name = "oskTransparentLabel";
            this.oskTransparentLabel.Size = new System.Drawing.Size(96, 15);
            this.oskTransparentLabel.Size = new System.Drawing.Size(148, 25);
            this.oskTransparentLabel.TabIndex = 3;
            this.oskTransparentLabel.Text = "OSK Transparent";
            this.oskTransparentLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // oskAlphaTrackBar
            // 
            this.oskAlphaTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.oskAlphaTrackBar.Location = new System.Drawing.Point(0, 34);
            this.oskAlphaTrackBar.Location = new System.Drawing.Point(0, 54);
            this.oskAlphaTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.oskAlphaTrackBar.Maximum = 255;
            this.oskAlphaTrackBar.Name = "oskAlphaTrackBar";
            this.oskAlphaTrackBar.Size = new System.Drawing.Size(371, 45);
            this.oskAlphaTrackBar.Size = new System.Drawing.Size(530, 69);
            this.oskAlphaTrackBar.TabIndex = 4;
            this.oskAlphaTrackBar.TickFrequency = 10;
            this.oskAlphaTrackBar.Value = 127;
            this.oskAlphaTrackBar.ValueChanged += new System.EventHandler(this.oskAlphaTrackBar_ValueChanged);
            // 
            // overlabPercentageLabel
            // 
            this.overlabPercentageLabel.AutoSize = true;
            this.overlabPercentageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.overlabPercentageLabel.Location = new System.Drawing.Point(0, 79);
            this.overlabPercentageLabel.Location = new System.Drawing.Point(0, 123);
            this.overlabPercentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.overlabPercentageLabel.Name = "overlabPercentageLabel";
            this.overlabPercentageLabel.Size = new System.Drawing.Size(107, 15);
            this.overlabPercentageLabel.Size = new System.Drawing.Size(166, 25);
            this.overlabPercentageLabel.TabIndex = 7;
            this.overlabPercentageLabel.Text = "OverlabPercentage";
            this.overlabPercentageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // overlabTrackBar
            // 
            this.overlabTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.overlabTrackBar.Location = new System.Drawing.Point(0, 94);
            this.overlabTrackBar.Location = new System.Drawing.Point(0, 148);
            this.overlabTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.overlabTrackBar.Maximum = 80;
            this.overlabTrackBar.Minimum = 50;
            this.overlabTrackBar.Name = "overlabTrackBar";
            this.overlabTrackBar.Size = new System.Drawing.Size(371, 45);
            this.overlabTrackBar.Size = new System.Drawing.Size(530, 69);
            this.overlabTrackBar.TabIndex = 8;
            this.overlabTrackBar.TickFrequency = 2;
            this.overlabTrackBar.Value = 55;
            this.overlabTrackBar.ValueChanged += new System.EventHandler(this.overlabTrackBar_ValueChanged);
            // 
            // offsetYTrackBar
            // 
            this.offsetYTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.offsetYTrackBar.Location = new System.Drawing.Point(0, 154);
            this.offsetYTrackBar.Location = new System.Drawing.Point(0, 242);
            this.offsetYTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.offsetYTrackBar.Maximum = 300;
            this.offsetYTrackBar.Name = "offsetYTrackBar";
            this.offsetYTrackBar.Size = new System.Drawing.Size(371, 45);
            this.offsetYTrackBar.Size = new System.Drawing.Size(530, 69);
            this.offsetYTrackBar.TabIndex = 10;
            this.offsetYTrackBar.TickFrequency = 30;
            this.offsetYTrackBar.ValueChanged += new System.EventHandler(this.offsetYTrackBar_ValueChanged);
            // 
            // offsetYLabel
            // 
            this.offsetYLabel.AutoSize = true;
            this.offsetYLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.offsetYLabel.Location = new System.Drawing.Point(0, 139);
            this.offsetYLabel.Location = new System.Drawing.Point(0, 217);
            this.offsetYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.offsetYLabel.Name = "offsetYLabel";
            this.offsetYLabel.Size = new System.Drawing.Size(51, 15);
            this.offsetYLabel.Size = new System.Drawing.Size(80, 25);
            this.offsetYLabel.TabIndex = 9;
            this.offsetYLabel.Text = "Offset_Y";
            this.offsetYLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ToggleShortCutLabel
            // 
            this.ToggleShortCutLabel.AutoSize = true;
            this.ToggleShortCutLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToggleShortCutLabel.Location = new System.Drawing.Point(0, 199);
            this.ToggleShortCutLabel.Location = new System.Drawing.Point(0, 311);
            this.ToggleShortCutLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ToggleShortCutLabel.Name = "ToggleShortCutLabel";
            this.ToggleShortCutLabel.Size = new System.Drawing.Size(237, 15);
            this.ToggleShortCutLabel.Size = new System.Drawing.Size(359, 25);
            this.ToggleShortCutLabel.TabIndex = 11;
            this.ToggleShortCutLabel.Text = "Toggle ShortCut(Press Button(s) 3 seconds";
            this.ToggleShortCutLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toggleShortCutTextBox
            // 
            this.toggleShortCutTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toggleShortCutTextBox.Location = new System.Drawing.Point(0, 214);
            this.toggleShortCutTextBox.Location = new System.Drawing.Point(0, 336);
            this.toggleShortCutTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toggleShortCutTextBox.Name = "toggleShortCutTextBox";
            this.toggleShortCutTextBox.Size = new System.Drawing.Size(371, 23);
            this.toggleShortCutTextBox.Size = new System.Drawing.Size(530, 31);
            this.toggleShortCutTextBox.TabIndex = 12;
            this.toggleShortCutTextBox.Text = "Steam+X";
            this.toggleShortCutTextBox.Enter += new System.EventHandler(this.toggleShortCutTextBox_Enter);
            this.toggleShortCutTextBox.Leave += new System.EventHandler(this.toggleShortCutTextBox_Leave);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "NeptuneOnScreenKeyboard";
            this.notifyIcon.Visible = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 237);
            this.label2.Location = new System.Drawing.Point(0, 367);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.Size = new System.Drawing.Size(252, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Button ShortCut(PressToClick)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonShortCutListBox
            // 
            this.buttonShortCutListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonShortCutListBox.FormattingEnabled = true;
            this.buttonShortCutListBox.ItemHeight = 15;
            this.buttonShortCutListBox.Location = new System.Drawing.Point(0, 252);
            this.buttonShortCutListBox.ItemHeight = 25;
            this.buttonShortCutListBox.Location = new System.Drawing.Point(0, 392);
            this.buttonShortCutListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonShortCutListBox.Name = "buttonShortCutListBox";
            this.buttonShortCutListBox.ScrollAlwaysVisible = true;
            this.buttonShortCutListBox.Size = new System.Drawing.Size(371, 34);
            this.buttonShortCutListBox.Size = new System.Drawing.Size(530, 54);
            this.buttonShortCutListBox.TabIndex = 16;
            // 
            // steamButtonComboBox
            // 
            this.steamButtonComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.steamButtonComboBox.FormattingEnabled = true;
            this.steamButtonComboBox.Location = new System.Drawing.Point(0, 286);
            this.steamButtonComboBox.Location = new System.Drawing.Point(0, 446);
            this.steamButtonComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.steamButtonComboBox.Name = "steamButtonComboBox";
            this.steamButtonComboBox.Size = new System.Drawing.Size(371, 23);
            this.steamButtonComboBox.Size = new System.Drawing.Size(530, 33);
            this.steamButtonComboBox.TabIndex = 18;
            // 
            // addMapButton
            // 
            this.addMapButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addMapButton.Location = new System.Drawing.Point(0, 309);
            this.addMapButton.Location = new System.Drawing.Point(0, 479);
            this.addMapButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addMapButton.Name = "addMapButton";
            this.addMapButton.Size = new System.Drawing.Size(371, 21);
            this.addMapButton.Size = new System.Drawing.Size(530, 35);
            this.addMapButton.TabIndex = 19;
            this.addMapButton.Text = "Add ShortcutClick";
            this.addMapButton.UseVisualStyleBackColor = true;
            this.addMapButton.Click += new System.EventHandler(this.addMapButton_Click);
            // 
            // deleteSelectedShortcutButton
            // 
            this.deleteSelectedShortcutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteSelectedShortcutButton.Location = new System.Drawing.Point(0, 330);
            this.deleteSelectedShortcutButton.Location = new System.Drawing.Point(0, 514);
            this.deleteSelectedShortcutButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deleteSelectedShortcutButton.Name = "deleteSelectedShortcutButton";
            this.deleteSelectedShortcutButton.Size = new System.Drawing.Size(371, 21);
            this.deleteSelectedShortcutButton.Size = new System.Drawing.Size(530, 35);
            this.deleteSelectedShortcutButton.TabIndex = 20;
            this.deleteSelectedShortcutButton.Text = "Delete Selected";
            this.deleteSelectedShortcutButton.UseVisualStyleBackColor = true;
            this.deleteSelectedShortcutButton.Click += new System.EventHandler(this.deleteSelectedShortcutButton_Click);
            // 
            // addStartupCheckBox
            // 
            this.addStartupCheckBox.AutoSize = true;
            this.addStartupCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.addStartupCheckBox.Location = new System.Drawing.Point(0, 351);
            this.addStartupCheckBox.Location = new System.Drawing.Point(0, 549);
            this.addStartupCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addStartupCheckBox.Name = "addStartupCheckBox";
            this.addStartupCheckBox.Size = new System.Drawing.Size(371, 19);
            this.addStartupCheckBox.Size = new System.Drawing.Size(530, 29);
            this.addStartupCheckBox.TabIndex = 21;
            this.addStartupCheckBox.Text = "Add StartUp Program";
            this.addStartupCheckBox.UseVisualStyleBackColor = true;
            this.addStartupCheckBox.CheckedChanged += new System.EventHandler(this.addStartupCheckBox_CheckedChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.toolStripSeparator1,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(114, 98);
            this.contextMenuStrip.Size = new System.Drawing.Size(144, 138);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Checked = true;
            this.enableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.enableToolStripMenuItem.Text = "Enable";
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.disableToolStripMenuItem.Text = "Disable";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.showToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 32);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // hideStartupCheckBox
            // 
            this.hideStartupCheckBox.AutoSize = true;
            this.hideStartupCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.hideStartupCheckBox.Location = new System.Drawing.Point(0, 370);
            this.hideStartupCheckBox.Location = new System.Drawing.Point(0, 578);
            this.hideStartupCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hideStartupCheckBox.Name = "hideStartupCheckBox";
            this.hideStartupCheckBox.Size = new System.Drawing.Size(371, 19);
            this.hideStartupCheckBox.Size = new System.Drawing.Size(530, 29);
            this.hideStartupCheckBox.TabIndex = 23;
            this.hideStartupCheckBox.Text = "Minimize on startup";
            this.hideStartupCheckBox.UseVisualStyleBackColor = true;
            this.hideStartupCheckBox.CheckedChanged += new System.EventHandler(this.hideStartupCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveButton.Location = new System.Drawing.Point(0, 389);
            this.saveButton.Location = new System.Drawing.Point(0, 607);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(371, 50);
            this.saveButton.Size = new System.Drawing.Size(530, 83);
            this.saveButton.TabIndex = 24;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Checked = true;
            this.enableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.enableCheckBox.Location = new System.Drawing.Point(0, 0);
            this.enableCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(371, 19);
            this.enableCheckBox.Size = new System.Drawing.Size(530, 29);
            this.enableCheckBox.TabIndex = 25;
            this.enableCheckBox.Text = "Enable";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            this.enableCheckBox.CheckedChanged += new System.EventHandler(this.enableCheckBox_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 516);
            this.ClientSize = new System.Drawing.Size(530, 837);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.hideStartupCheckBox);
            this.Controls.Add(this.addStartupCheckBox);
            this.Controls.Add(this.deleteSelectedShortcutButton);
            this.Controls.Add(this.addMapButton);
            this.Controls.Add(this.steamButtonComboBox);
            this.Controls.Add(this.buttonShortCutListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toggleShortCutTextBox);
            this.Controls.Add(this.ToggleShortCutLabel);
            this.Controls.Add(this.offsetYTrackBar);
            this.Controls.Add(this.offsetYLabel);
            this.Controls.Add(this.overlabTrackBar);
            this.Controls.Add(this.overlabPercentageLabel);
            this.Controls.Add(this.oskAlphaTrackBar);
            this.Controls.Add(this.oskTransparentLabel);
            this.Controls.Add(this.testTextBox);
            this.Controls.Add(this.toggleOskButton);
            this.Controls.Add(this.enableCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "OnScreenKeyboard Setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.oskAlphaTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.overlabTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYTrackBar)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button toggleOskButton;
        private TextBox testTextBox;
        private Label oskTransparentLabel;
        private TrackBar oskAlphaTrackBar;
        private Label overlabPercentageLabel;
        private TrackBar overlabTrackBar;
        private TrackBar offsetYTrackBar;
        private Label offsetYLabel;
        private Label ToggleShortCutLabel;
        private TextBox toggleShortCutTextBox;
        private NotifyIcon notifyIcon;
        private Label label2;
        private ListBox buttonShortCutListBox;
        private ComboBox steamButtonComboBox;
        private Button addMapButton;
        private Button deleteSelectedShortcutButton;
        private CheckBox addStartupCheckBox;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem showToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private CheckBox hideStartupCheckBox;
        private Button saveButton;
        private ToolStripMenuItem enableToolStripMenuItem;
        private ToolStripMenuItem disableToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private CheckBox enableCheckBox;
    }
}
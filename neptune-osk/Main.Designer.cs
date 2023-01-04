﻿namespace neptune_osk
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
            this.LizardEnablecheckBox = new System.Windows.Forms.CheckBox();
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
            this.toggleOskButton.Name = "toggleOskButton";
            this.toggleOskButton.Size = new System.Drawing.Size(371, 32);
            this.toggleOskButton.TabIndex = 0;
            this.toggleOskButton.Text = "Toggle OSK";
            this.toggleOskButton.UseVisualStyleBackColor = true;
            this.toggleOskButton.Click += new System.EventHandler(this.toggleOskButton_Click);
            // 
            // oskTransparentLabel
            // 
            this.oskTransparentLabel.AutoSize = true;
            this.oskTransparentLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.oskTransparentLabel.Location = new System.Drawing.Point(0, 38);
            this.oskTransparentLabel.Name = "oskTransparentLabel";
            this.oskTransparentLabel.Size = new System.Drawing.Size(96, 15);
            this.oskTransparentLabel.TabIndex = 3;
            this.oskTransparentLabel.Text = "OSK Transparent";
            this.oskTransparentLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // oskAlphaTrackBar
            // 
            this.oskAlphaTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.oskAlphaTrackBar.Location = new System.Drawing.Point(0, 53);
            this.oskAlphaTrackBar.Maximum = 255;
            this.oskAlphaTrackBar.Name = "oskAlphaTrackBar";
            this.oskAlphaTrackBar.Size = new System.Drawing.Size(371, 45);
            this.oskAlphaTrackBar.TabIndex = 4;
            this.oskAlphaTrackBar.TickFrequency = 10;
            this.oskAlphaTrackBar.Value = 127;
            this.oskAlphaTrackBar.ValueChanged += new System.EventHandler(this.oskAlphaTrackBar_ValueChanged);
            // 
            // overlabPercentageLabel
            // 
            this.overlabPercentageLabel.AutoSize = true;
            this.overlabPercentageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.overlabPercentageLabel.Location = new System.Drawing.Point(0, 98);
            this.overlabPercentageLabel.Name = "overlabPercentageLabel";
            this.overlabPercentageLabel.Size = new System.Drawing.Size(107, 15);
            this.overlabPercentageLabel.TabIndex = 7;
            this.overlabPercentageLabel.Text = "OverlabPercentage";
            this.overlabPercentageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // overlabTrackBar
            // 
            this.overlabTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.overlabTrackBar.Location = new System.Drawing.Point(0, 113);
            this.overlabTrackBar.Maximum = 80;
            this.overlabTrackBar.Minimum = 50;
            this.overlabTrackBar.Name = "overlabTrackBar";
            this.overlabTrackBar.Size = new System.Drawing.Size(371, 45);
            this.overlabTrackBar.TabIndex = 8;
            this.overlabTrackBar.TickFrequency = 2;
            this.overlabTrackBar.Value = 55;
            this.overlabTrackBar.ValueChanged += new System.EventHandler(this.overlabTrackBar_ValueChanged);
            // 
            // offsetYTrackBar
            // 
            this.offsetYTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.offsetYTrackBar.Location = new System.Drawing.Point(0, 173);
            this.offsetYTrackBar.Maximum = 300;
            this.offsetYTrackBar.Name = "offsetYTrackBar";
            this.offsetYTrackBar.Size = new System.Drawing.Size(371, 45);
            this.offsetYTrackBar.TabIndex = 10;
            this.offsetYTrackBar.TickFrequency = 30;
            this.offsetYTrackBar.ValueChanged += new System.EventHandler(this.offsetYTrackBar_ValueChanged);
            // 
            // offsetYLabel
            // 
            this.offsetYLabel.AutoSize = true;
            this.offsetYLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.offsetYLabel.Location = new System.Drawing.Point(0, 158);
            this.offsetYLabel.Name = "offsetYLabel";
            this.offsetYLabel.Size = new System.Drawing.Size(51, 15);
            this.offsetYLabel.TabIndex = 9;
            this.offsetYLabel.Text = "Offset_Y";
            this.offsetYLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ToggleShortCutLabel
            // 
            this.ToggleShortCutLabel.AutoSize = true;
            this.ToggleShortCutLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToggleShortCutLabel.Location = new System.Drawing.Point(0, 218);
            this.ToggleShortCutLabel.Name = "ToggleShortCutLabel";
            this.ToggleShortCutLabel.Size = new System.Drawing.Size(237, 15);
            this.ToggleShortCutLabel.TabIndex = 11;
            this.ToggleShortCutLabel.Text = "Toggle ShortCut(Press Button(s) 3 seconds";
            this.ToggleShortCutLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toggleShortCutTextBox
            // 
            this.toggleShortCutTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.toggleShortCutTextBox.Location = new System.Drawing.Point(0, 233);
            this.toggleShortCutTextBox.Name = "toggleShortCutTextBox";
            this.toggleShortCutTextBox.Size = new System.Drawing.Size(371, 23);
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
            this.label2.Location = new System.Drawing.Point(0, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Button ShortCut(PressToClick)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonShortCutListBox
            // 
            this.buttonShortCutListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonShortCutListBox.FormattingEnabled = true;
            this.buttonShortCutListBox.ItemHeight = 15;
            this.buttonShortCutListBox.Location = new System.Drawing.Point(0, 271);
            this.buttonShortCutListBox.Name = "buttonShortCutListBox";
            this.buttonShortCutListBox.ScrollAlwaysVisible = true;
            this.buttonShortCutListBox.Size = new System.Drawing.Size(371, 34);
            this.buttonShortCutListBox.TabIndex = 16;
            // 
            // steamButtonComboBox
            // 
            this.steamButtonComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.steamButtonComboBox.FormattingEnabled = true;
            this.steamButtonComboBox.Location = new System.Drawing.Point(0, 305);
            this.steamButtonComboBox.Name = "steamButtonComboBox";
            this.steamButtonComboBox.Size = new System.Drawing.Size(371, 23);
            this.steamButtonComboBox.TabIndex = 18;
            // 
            // addMapButton
            // 
            this.addMapButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addMapButton.Location = new System.Drawing.Point(0, 328);
            this.addMapButton.Name = "addMapButton";
            this.addMapButton.Size = new System.Drawing.Size(371, 21);
            this.addMapButton.TabIndex = 19;
            this.addMapButton.Text = "Add ShortcutClick";
            this.addMapButton.UseVisualStyleBackColor = true;
            this.addMapButton.Click += new System.EventHandler(this.addMapButton_Click);
            // 
            // deleteSelectedShortcutButton
            // 
            this.deleteSelectedShortcutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.deleteSelectedShortcutButton.Location = new System.Drawing.Point(0, 349);
            this.deleteSelectedShortcutButton.Name = "deleteSelectedShortcutButton";
            this.deleteSelectedShortcutButton.Size = new System.Drawing.Size(371, 21);
            this.deleteSelectedShortcutButton.TabIndex = 20;
            this.deleteSelectedShortcutButton.Text = "Delete Selected";
            this.deleteSelectedShortcutButton.UseVisualStyleBackColor = true;
            this.deleteSelectedShortcutButton.Click += new System.EventHandler(this.deleteSelectedShortcutButton_Click);
            // 
            // addStartupCheckBox
            // 
            this.addStartupCheckBox.AutoSize = true;
            this.addStartupCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.addStartupCheckBox.Location = new System.Drawing.Point(0, 370);
            this.addStartupCheckBox.Name = "addStartupCheckBox";
            this.addStartupCheckBox.Size = new System.Drawing.Size(371, 19);
            this.addStartupCheckBox.TabIndex = 21;
            this.addStartupCheckBox.Text = "Add StartUp Program";
            this.addStartupCheckBox.UseVisualStyleBackColor = true;
            this.addStartupCheckBox.CheckedChanged += new System.EventHandler(this.addStartupCheckBox_CheckedChanged);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.toolStripSeparator1,
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(114, 98);
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Checked = true;
            this.enableToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.enableToolStripMenuItem.Text = "Enable";
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.disableToolStripMenuItem.Text = "Disable";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(110, 6);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.showToolStripMenuItem.Text = "Show";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // hideStartupCheckBox
            // 
            this.hideStartupCheckBox.AutoSize = true;
            this.hideStartupCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.hideStartupCheckBox.Location = new System.Drawing.Point(0, 389);
            this.hideStartupCheckBox.Name = "hideStartupCheckBox";
            this.hideStartupCheckBox.Size = new System.Drawing.Size(371, 19);
            this.hideStartupCheckBox.TabIndex = 23;
            this.hideStartupCheckBox.Text = "Minimize on startup";
            this.hideStartupCheckBox.UseVisualStyleBackColor = true;
            this.hideStartupCheckBox.CheckedChanged += new System.EventHandler(this.hideStartupCheckBox_CheckedChanged);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveButton.Location = new System.Drawing.Point(0, 408);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(371, 50);
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
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(371, 19);
            this.enableCheckBox.TabIndex = 25;
            this.enableCheckBox.Text = "Enable";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            this.enableCheckBox.CheckedChanged += new System.EventHandler(this.enableCheckBox_CheckedChanged);
            // 
            // LizardEnablecheckBox
            // 
            this.LizardEnablecheckBox.AutoSize = true;
            this.LizardEnablecheckBox.Checked = true;
            this.LizardEnablecheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LizardEnablecheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.LizardEnablecheckBox.Location = new System.Drawing.Point(0, 19);
            this.LizardEnablecheckBox.Name = "LizardEnablecheckBox";
            this.LizardEnablecheckBox.Size = new System.Drawing.Size(371, 19);
            this.LizardEnablecheckBox.TabIndex = 26;
            this.LizardEnablecheckBox.Text = "Enable Lizard Mouse";
            this.LizardEnablecheckBox.UseVisualStyleBackColor = true;
            this.LizardEnablecheckBox.CheckedChanged += new System.EventHandler(this.LizardEnablecheckBox_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 516);
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
            this.Controls.Add(this.toggleOskButton);
            this.Controls.Add(this.LizardEnablecheckBox);
            this.Controls.Add(this.enableCheckBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private CheckBox LizardEnablecheckBox;
    }
}
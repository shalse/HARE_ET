﻿namespace ET_Project_UI
{
    partial class EyeTrackerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EyeTrackerForm));
            this.VerifyButton = new System.Windows.Forms.Button();
            this.CalibrateButton = new System.Windows.Forms.Button();
            this.SimonSaysButton = new System.Windows.Forms.Button();
            this.KeyBoardControlButton = new System.Windows.Forms.Button();
            this.MouseControlButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EyeTrackingPicture = new System.Windows.Forms.PictureBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.AccuracyButton = new System.Windows.Forms.Button();
            this.AccuracyImage = new System.Windows.Forms.PictureBox();
            this.AccuracyLabel = new System.Windows.Forms.Label();
            this.ShowEyePlacementButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBarLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EyeTrackingPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccuracyImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VerifyButton
            // 
            this.VerifyButton.Enabled = false;
            this.VerifyButton.Location = new System.Drawing.Point(650, 117);
            this.VerifyButton.Name = "VerifyButton";
            this.VerifyButton.Size = new System.Drawing.Size(103, 23);
            this.VerifyButton.TabIndex = 0;
            this.VerifyButton.Text = "Verify";
            this.VerifyButton.UseVisualStyleBackColor = true;
            this.VerifyButton.Click += new System.EventHandler(this.Verify_Click);
            // 
            // CalibrateButton
            // 
            this.CalibrateButton.Enabled = false;
            this.CalibrateButton.Location = new System.Drawing.Point(650, 88);
            this.CalibrateButton.Name = "CalibrateButton";
            this.CalibrateButton.Size = new System.Drawing.Size(103, 23);
            this.CalibrateButton.TabIndex = 1;
            this.CalibrateButton.Text = "Calibrate";
            this.CalibrateButton.UseVisualStyleBackColor = true;
            this.CalibrateButton.Click += new System.EventHandler(this.Callibrate_Click);
            // 
            // SimonSaysButton
            // 
            this.SimonSaysButton.Enabled = false;
            this.SimonSaysButton.Location = new System.Drawing.Point(665, 221);
            this.SimonSaysButton.Name = "SimonSaysButton";
            this.SimonSaysButton.Size = new System.Drawing.Size(103, 23);
            this.SimonSaysButton.TabIndex = 2;
            this.SimonSaysButton.Text = "Simon Says";
            this.SimonSaysButton.UseVisualStyleBackColor = true;
            // 
            // KeyBoardControlButton
            // 
            this.KeyBoardControlButton.Enabled = false;
            this.KeyBoardControlButton.Location = new System.Drawing.Point(665, 250);
            this.KeyBoardControlButton.Name = "KeyBoardControlButton";
            this.KeyBoardControlButton.Size = new System.Drawing.Size(103, 23);
            this.KeyBoardControlButton.TabIndex = 3;
            this.KeyBoardControlButton.Text = "Keyboard Control";
            this.KeyBoardControlButton.UseVisualStyleBackColor = true;
            // 
            // MouseControlButton
            // 
            this.MouseControlButton.Enabled = false;
            this.MouseControlButton.Location = new System.Drawing.Point(665, 279);
            this.MouseControlButton.Name = "MouseControlButton";
            this.MouseControlButton.Size = new System.Drawing.Size(103, 23);
            this.MouseControlButton.TabIndex = 4;
            this.MouseControlButton.Text = "Mouse Control";
            this.MouseControlButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Eyes";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.calibrateToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.Connect_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // calibrateToolStripMenuItem
            // 
            this.calibrateToolStripMenuItem.Name = "calibrateToolStripMenuItem";
            this.calibrateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.calibrateToolStripMenuItem.Text = "Calibrate";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // EyeTrackingPicture
            // 
            this.EyeTrackingPicture.Location = new System.Drawing.Point(12, 40);
            this.EyeTrackingPicture.Name = "EyeTrackingPicture";
            this.EyeTrackingPicture.Size = new System.Drawing.Size(138, 99);
            this.EyeTrackingPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.EyeTrackingPicture.TabIndex = 7;
            this.EyeTrackingPicture.TabStop = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(650, 59);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(103, 23);
            this.ConnectButton.TabIndex = 8;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.Connect_Click);
            // 
            // AccuracyButton
            // 
            this.AccuracyButton.Location = new System.Drawing.Point(650, 147);
            this.AccuracyButton.Name = "AccuracyButton";
            this.AccuracyButton.Size = new System.Drawing.Size(103, 23);
            this.AccuracyButton.TabIndex = 9;
            this.AccuracyButton.Text = "Get Accuracy";
            this.AccuracyButton.UseVisualStyleBackColor = true;
            this.AccuracyButton.Click += new System.EventHandler(this.GetAccuracy_Click);
            // 
            // AccuracyImage
            // 
            this.AccuracyImage.Location = new System.Drawing.Point(153, 40);
            this.AccuracyImage.Name = "AccuracyImage";
            this.AccuracyImage.Size = new System.Drawing.Size(273, 153);
            this.AccuracyImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AccuracyImage.TabIndex = 11;
            this.AccuracyImage.TabStop = false;
            this.AccuracyImage.Click += new System.EventHandler(this.AccuracyImage_Click);
            // 
            // AccuracyLabel
            // 
            this.AccuracyLabel.AutoSize = true;
            this.AccuracyLabel.Location = new System.Drawing.Point(226, 24);
            this.AccuracyLabel.Name = "AccuracyLabel";
            this.AccuracyLabel.Size = new System.Drawing.Size(104, 13);
            this.AccuracyLabel.TabIndex = 12;
            this.AccuracyLabel.Text = "Calibration Accuracy";
            // 
            // ShowEyePlacementButton
            // 
            this.ShowEyePlacementButton.Enabled = false;
            this.ShowEyePlacementButton.Location = new System.Drawing.Point(12, 145);
            this.ShowEyePlacementButton.Name = "ShowEyePlacementButton";
            this.ShowEyePlacementButton.Size = new System.Drawing.Size(135, 23);
            this.ShowEyePlacementButton.TabIndex = 13;
            this.ShowEyePlacementButton.Text = "Show Eye Placement";
            this.ShowEyePlacementButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ShowEyePlacementButton.UseVisualStyleBackColor = true;
            this.ShowEyePlacementButton.Click += new System.EventHandler(this.ShowEyePlacementButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 312);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(780, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBarLabel
            // 
            this.StatusBarLabel.Name = "StatusBarLabel";
            this.StatusBarLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // EyeTrackerSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 334);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ShowEyePlacementButton);
            this.Controls.Add(this.AccuracyLabel);
            this.Controls.Add(this.AccuracyImage);
            this.Controls.Add(this.AccuracyButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.EyeTrackingPicture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MouseControlButton);
            this.Controls.Add(this.KeyBoardControlButton);
            this.Controls.Add(this.SimonSaysButton);
            this.Controls.Add(this.CalibrateButton);
            this.Controls.Add(this.VerifyButton);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EyeTrackerSetupForm";
            this.Text = "Eye Tracker Contol";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EyeTrackingPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccuracyImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button VerifyButton;
        private System.Windows.Forms.Button CalibrateButton;
        private System.Windows.Forms.Button SimonSaysButton;
        private System.Windows.Forms.Button KeyBoardControlButton;
        private System.Windows.Forms.Button MouseControlButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.PictureBox EyeTrackingPicture;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ToolStripMenuItem calibrateToolStripMenuItem;
        private System.Windows.Forms.Button AccuracyButton;
        private System.Windows.Forms.PictureBox AccuracyImage;
        private System.Windows.Forms.Label AccuracyLabel;
        private System.Windows.Forms.Button ShowEyePlacementButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel;
    }
}

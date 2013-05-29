namespace Test_Server
{
    partial class Form1
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
            this.startListeningButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipInputBox = new System.Windows.Forms.TextBox();
            this.portInputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startListeningButton
            // 
            this.startListeningButton.Location = new System.Drawing.Point(206, 332);
            this.startListeningButton.Name = "startListeningButton";
            this.startListeningButton.Size = new System.Drawing.Size(116, 23);
            this.startListeningButton.TabIndex = 0;
            this.startListeningButton.Text = "Start Listening";
            this.startListeningButton.UseVisualStyleBackColor = true;
            this.startListeningButton.Click += new System.EventHandler(this.startListeningButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 9);
            this.statusLabel.MinimumSize = new System.Drawing.Size(200, 100);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(200, 100);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Click += new System.EventHandler(this.statusLabel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port:";
            // 
            // ipInputBox
            // 
            this.ipInputBox.Location = new System.Drawing.Point(81, 105);
            this.ipInputBox.Name = "ipInputBox";
            this.ipInputBox.Size = new System.Drawing.Size(100, 20);
            this.ipInputBox.TabIndex = 4;
            this.ipInputBox.Text = "192.168.1.108";
            // 
            // portInputBox
            // 
            this.portInputBox.Location = new System.Drawing.Point(51, 130);
            this.portInputBox.Name = "portInputBox";
            this.portInputBox.Size = new System.Drawing.Size(100, 20);
            this.portInputBox.TabIndex = 5;
            this.portInputBox.Text = "7777";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 367);
            this.Controls.Add(this.portInputBox);
            this.Controls.Add(this.ipInputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.startListeningButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startListeningButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipInputBox;
        private System.Windows.Forms.TextBox portInputBox;
    }
}


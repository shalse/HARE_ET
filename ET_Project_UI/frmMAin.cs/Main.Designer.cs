namespace TCPClientTester
{
    partial class Main
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
            this.txtBroadcast = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ipInputBox = new System.Windows.Forms.TextBox();
            this.portInputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBroadcast
            // 
            this.txtBroadcast.Location = new System.Drawing.Point(12, 227);
            this.txtBroadcast.Name = "txtBroadcast";
            this.txtBroadcast.Size = new System.Drawing.Size(158, 20);
            this.txtBroadcast.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "SendMessage";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Server Port #:";
            // 
            // ipInputBox
            // 
            this.ipInputBox.Location = new System.Drawing.Point(115, 13);
            this.ipInputBox.Name = "ipInputBox";
            this.ipInputBox.Size = new System.Drawing.Size(100, 20);
            this.ipInputBox.TabIndex = 4;
            this.ipInputBox.Text = "75.102.73.216";
            // 
            // portInputBox
            // 
            this.portInputBox.Location = new System.Drawing.Point(115, 38);
            this.portInputBox.Name = "portInputBox";
            this.portInputBox.Size = new System.Drawing.Size(100, 20);
            this.portInputBox.TabIndex = 5;
            this.portInputBox.Text = "10000";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.portInputBox);
            this.Controls.Add(this.ipInputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBroadcast);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBroadcast;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipInputBox;
        private System.Windows.Forms.TextBox portInputBox;
    }
}


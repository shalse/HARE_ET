namespace ImageRecieverOverSocket
{
    partial class ClientForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.Label();
            this.messageInput = new System.Windows.Forms.TextBox();
            this.SendMessage = new System.Windows.Forms.Button();
            this.updateImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(13, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 50);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(662, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 467);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(749, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "Status";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(0, 475);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(37, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Status";
            // 
            // messageInput
            // 
            this.messageInput.Location = new System.Drawing.Point(3, 444);
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(354, 20);
            this.messageInput.TabIndex = 4;
            this.messageInput.Text = "Type Here to send a message";
            // 
            // SendMessage
            // 
            this.SendMessage.Location = new System.Drawing.Point(364, 440);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(75, 23);
            this.SendMessage.TabIndex = 5;
            this.SendMessage.Text = "Send";
            this.SendMessage.UseVisualStyleBackColor = true;
            this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
            // 
            // updateImage
            // 
            this.updateImage.Location = new System.Drawing.Point(482, 440);
            this.updateImage.Name = "updateImage";
            this.updateImage.Size = new System.Drawing.Size(75, 23);
            this.updateImage.TabIndex = 6;
            this.updateImage.Text = "Get Image";
            this.updateImage.UseVisualStyleBackColor = true;
            this.updateImage.Click += new System.EventHandler(this.updateImage_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 489);
            this.Controls.Add(this.updateImage);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.messageInput);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox);
            this.Name = "ClientForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.TextBox messageInput;
        private System.Windows.Forms.Button SendMessage;
        private System.Windows.Forms.Button updateImage;
    }
}


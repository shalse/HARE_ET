using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageRecieverOverSocket
{
    public partial class ClientForm : Form
    {
        public Client clnt = new Client();
        public ClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            clnt.connectToServer();
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            clnt.sendMessage(messageInput.Text);
        }

        private void updateImage_Click(object sender, EventArgs e)
        {
            Image img = clnt.getImage();
            if (img != null)
            {
                pictureBox.Image = img;
            }
            else
            {
                statusLabel.Text = "Image was null";
            }
        }
    }
}

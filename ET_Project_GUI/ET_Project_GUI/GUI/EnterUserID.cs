using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET_Project_GUI.GUI
{
    public partial class EnterUserID : Form
    {
        public EnterUserID()
        {
            InitializeComponent();
            CustomPanel bgPanel = new CustomPanel();
            bgPanel.BackColor = Color.FromArgb(247, 150, 70);
            bgPanel.Size = new Size(275, 119);
            bgPanel.BorderWidth = 0;
            this.Controls.Add(bgPanel);
            bgPanel.SendToBack();

            
            
        }
    }
}

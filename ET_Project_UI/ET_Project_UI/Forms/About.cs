using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET_Project_UI
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        private void AboutOkButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

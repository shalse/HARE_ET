using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ET_Project_GUI
{
    public partial class CustomPanel : UserControl
    {
        private int borderWidth = 2;
        private Color borderColor = Color.White;
       
        private string panelText = "";

        [Description("This is the width for the border"), Category("Appearance")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }
        
        [Description("This is the color for the border"), Category("Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }


        [Description("Set the text to be displayed on the panel"), Category("Appearance")]
        public string PanelText
        {
            get { return panelText; }
            set { panelText = value; Invalidate(); }
        }

        public CustomPanel()
        {
            
            InitializeComponent();
        }


        private void CustomPanel_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor,
            borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);


            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
       

            e.Graphics.DrawString(panelText, base.Font, new SolidBrush(base.ForeColor), this.ClientRectangle, stringFormat);
        }
    }
}

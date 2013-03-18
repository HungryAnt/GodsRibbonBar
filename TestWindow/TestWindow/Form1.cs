using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestWindow.Ribbon;

namespace TestWindow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ribbonDropDown = new RibbonDropDown(button1);
        }

        RibbonDropDown ribbonDropDown;

        private void button1_Click(object sender, EventArgs e)
        {
            //Point location = this.PointToScreen(new Point(button1.Left, button1.Bottom));
            ribbonDropDown.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //toolStripButton1.Text = "wefwef" + Environment.NewLine + "fwwef";
        }
    }
}

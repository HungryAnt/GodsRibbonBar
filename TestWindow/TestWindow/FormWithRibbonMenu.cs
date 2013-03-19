using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestWindow.Ribbon;
using TestWindow.Properties;

namespace TestWindow
{
    public partial class FormWithRibbonMenu : Form
    {
        public FormWithRibbonMenu()
        {
            InitializeComponent();

            this.Controls.Add(new RibbonBarControl());
        }

        private void FormWithRibbonMenu_Load(object sender, EventArgs e)
        {
            RibbonGroup[] groups = new RibbonGroup[]
            {
                new RibbonGroup(
                    new RibbonItem[]
                    {
                        new RibbonButton()
                        {
                            SizeStyle = RibbonItemSizeStyle.Large,
                            Image = Resources.CustomerExpansion_32,
                            Text = "Gods_巨蚁",
                        },
                        new RibbonButton()
                        {
                            Image = Resources.Toolbar_help_16,
                            SizeStyle = RibbonItemSizeStyle.Small,
                            Text = "Hello Ribbon",
                        },
                        new RibbonButton()
                        {
                            Image = Resources.Toolbar_help_16,
                            SizeStyle = RibbonItemSizeStyle.Small,
                            Text = "Sky is mine",
                        },
                    }
                    ),
                new RibbonGroup(
                    new RibbonItem[]
                    {
                        new RibbonButton(),
                        new RibbonButton(),
                    })
            };

            RibbonBar ribbonBar = new RibbonBar(groups);

            ribbonBarControl.RibbonBar = ribbonBar;
        }
    }
}

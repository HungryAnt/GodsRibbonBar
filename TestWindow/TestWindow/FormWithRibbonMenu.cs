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
                            SizeStyle = RibbonItemSizeType.Large,
                            Image = Resources.CustomerExpansion_32,
                            ImageAlign = ContentAlignment.TopCenter,
                            Text = "Ant TestAnt TestAnt TestAnt Test",
                        },
                        new RibbonItem()
                        {
                            SizeStyle = RibbonItemSizeType.Small
                        },
                        new RibbonItem()
                        {
                            SizeStyle = RibbonItemSizeType.Small
                        },
                    }
                    ),
                new RibbonGroup(
                    new RibbonItem[]
                    {
                        new RibbonItem(),
                        new RibbonItem(),
                    })
            };

            RibbonBar ribbonBar = new RibbonBar(groups);

            ribbonBarControl.RibbonBar = ribbonBar;
        }
    }
}

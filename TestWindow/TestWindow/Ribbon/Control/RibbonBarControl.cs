using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestWindow.Ribbon
{
    public partial class RibbonBarControl : Control
    {
        public RibbonBarControl()
        {
            InitializeComponent();
        }

        public RibbonBar RibbonBar
        {
            get;
            set;
        }

        protected override Padding DefaultPadding
        {
            get
            {
                return new Padding(3, 3, 3, 3);
            }
        }

        public RibbonRenderer Renderer { get; set; }

        #region 绘图

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (RibbonBar != null)
            {
                RibbonBar.Update();

                Graphics g = pe.Graphics;

                int indexGroup = 0;
                foreach (RibbonGroup group in RibbonBar.Groups)
                {
                    Brush groupFillBrush = (indexGroup++ % 2 == 0) ? Brushes.LightGreen : Brushes.LightYellow;
                    g.FillRectangle(groupFillBrush, group.Bounds);

                    int indexItem = 0;
                    foreach (RibbonItem item in group.Items)
                    {
                        Brush itemFillBrush = (indexItem++ % 2 == 0) ? Brushes.Red : Brushes.Blue;
                        g.FillRectangle(itemFillBrush, item.ContentRectangle);
                        DrawImage(g, item);
                    }
                }
            }
        }

        void DrawImage(Graphics g, RibbonItem item)
        {
            if (item.Image != null)
            {
                RibbonItemImageRenderEventArgs e = new RibbonItemImageRenderEventArgs(g, item, item.Image, item.ImageRectangle);
                RibbonRenderer.DrawItemImage(e);
            }
        }

//         void DrawText(Graphics g, RibbonItem item)
//         {
//             if (!string.IsNullOrEmpty(Text))
//             {
//                 RibbonItemTextRenderEventArgs e = new RibbonItemTextRenderEventArgs(g, item, item.Text,
//                     item.TextRectangle, item.ForeColor, item.Font);
//                 RibbonRenderer.DrawItemText(e);
//             }
//         }

        #endregion
        
    }
}

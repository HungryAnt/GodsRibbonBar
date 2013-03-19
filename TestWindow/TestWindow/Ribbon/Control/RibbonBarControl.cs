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

        RibbonRenderer _renderer = new RibbonRenderer();
        public RibbonRenderer Renderer
        {
            get
            {
                return _renderer;
            }
            set
            {
                _renderer = value;
            }
        }

        #region 绘图

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (RibbonBar != null)
            {
                RibbonBar.Renderer = this.Renderer;
                RibbonBar.Update();

                Graphics g = pe.Graphics;

                int indexGroup = 0;
                foreach (RibbonGroup group in RibbonBar.Groups)
                {
                    group.Renderer = this.Renderer;
                    Brush groupFillBrush = (indexGroup++ % 2 == 0) ? Brushes.LightGreen : Brushes.LightYellow;
                    g.FillRectangle(groupFillBrush, group.Bounds);

                    int indexItem = 0;
                    foreach (RibbonItem item in group.Items)
                    {
                        item.Renderer = this.Renderer;
                        Brush itemFillBrush = (indexItem++ % 2 == 0) ? Brushes.Red : Brushes.Blue;
                        g.FillRectangle(itemFillBrush, item.ContentRectangle);
                        item.Draw(pe);
                    }
                }
            }
        }

        #endregion
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TestWindow.Ribbon
{
    class RibbonDropDown : ToolStripDropDown
    {
        Control _sourceControl;

        public RibbonDropDown(Control sourceControl)
        {
            _sourceControl = sourceControl;
            AutoSize = false;
            RenderMode = ToolStripRenderMode.System;
            BackColor = Color.White;
            Items.Add("");  // 我操！必须得加上这句，否则不会有任何弹框显示
            Items.Add(new ToolStripButton("Test"));
        }

//         protected override Padding DefaultPadding
//         {
//             get
//             {
//                 return new Padding(0, 1, 0, 1);
//             }
//         }


        protected override void OnPaint(PaintEventArgs e)
        {
//             Graphics g = e.Graphics;
//             g.FillRectangle(Brushes.LightBlue, this.ClientRectangle);

            base.OnPaint(e);
        }

        public void Open()
        {
            UpdateVisibleItems();
            Show(_sourceControl, new Point(0, _sourceControl.ClientRectangle.Height - 1));
        }

        void UpdateVisibleItems()
        {
            SuspendLayout();
            Size = new Size(200, 80);
            ResumeLayout();
            Invalidate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TestWindow.Ribbon
{
    //ToolStripSystemRenderer

    public class RibbonRenderer
    {
        public static void DrawItemImage(RibbonItemImageRenderEventArgs e)
        {
            e.Graphics.DrawImage(e.Image, e.ImageRectangle);
        }

        public static void DrawItemText(RibbonItemTextRenderEventArgs e)
        {
            using (Brush brush = new SolidBrush(e.TextColor))
            {
                e.Graphics.DrawString(e.Text, e.TextFont, brush, e.TextRectangle);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace TestWindow.Ribbon
{
    

    public class RibbonRenderer
    {
        //ToolStripRenderer

        public void DrawItemImage(RibbonItemImageRenderEventArgs e)
        {
            OnDrawItemImage(e);
        }

        public void DrawItemText(RibbonItemTextRenderEventArgs e)
        {
            OnDrawItemText(e);
        }

        public void DrawItemBackground(RibbonItemRenderEventArgs e)
        {
            OnDrawItemBackground(e);
        }
        
        protected virtual void OnDrawItemImage(RibbonItemImageRenderEventArgs e)
        {
            e.Graphics.DrawImage(e.Image, e.ImageRectangle);
        }

        StringFormat _stringFormat = new StringFormat(StringFormatFlags.NoClip);

        protected virtual void OnDrawItemText(RibbonItemTextRenderEventArgs e)
        {
            using (Brush brush = new SolidBrush(e.TextColor))
            {
//                 e.Graphics.FillRectangle(Brushes.White, e.TextRectangle);
//                 e.Graphics.DrawString(e.Text, e.TextFont, brush, e.TextRectangle, _stringFormat);
                TextRenderer.DrawText(e.Graphics, e.Text, e.TextFont, e.TextRectangle, e.TextColor);
            }
        }

        protected virtual void OnDrawItemBackground(RibbonItemRenderEventArgs e)
        {
//             using (Brush brush = new SolidBrush(ColorTranslator.FromHtml("#D5E0F4")))
//             {
                e.Graphics.FillRectangle(Brushes.White, e.Item.Bounds);
            //}
        }
    }
}

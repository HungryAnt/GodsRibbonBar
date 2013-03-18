using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonItemTextRenderEventArgs : RibbonItemRenderEventArgs
    {
        public RibbonItemTextRenderEventArgs(Graphics g, RibbonItem item, string text, Rectangle textRectangle, Color textColor, Font textFont)
            : base (g, item)
        {
            Text = text;
            TextRectangle = textRectangle;
            TextColor = textColor;
            TextFont = textFont;
        }

        public string Text { get; set; }

        public Rectangle TextRectangle { get; set; }
        
        public Color TextColor { get; set; }
        
        public Font TextFont { get; set; }
    }
}

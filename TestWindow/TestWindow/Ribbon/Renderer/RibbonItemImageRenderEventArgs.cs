using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonItemImageRenderEventArgs : RibbonItemRenderEventArgs
    {
//         public RibbonItemImageRenderEventArgs(Graphics g, RibbonItem item, Rectangle imageRectangle)
//             : base(g, item)
//         {
//             ImageRectangle = imageRectangle;
//         }

        public RibbonItemImageRenderEventArgs(Graphics g, RibbonItem item, Image image, Rectangle imageRectangle)
            : base(g, item)
        {
            Image = image;
            ImageRectangle = imageRectangle;
        }

        public Image Image { get; private set; }

        public Rectangle ImageRectangle { get; private set; }
    }
}

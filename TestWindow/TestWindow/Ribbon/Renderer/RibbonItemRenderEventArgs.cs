using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonItemRenderEventArgs : EventArgs
    {
        public RibbonItemRenderEventArgs(Graphics g, RibbonItem item)
        {
            Graphics = g;
            Item = item;
        }

        public Graphics Graphics { get; private set; }

        public RibbonItem Item { get; private set; }

        //public RibbonBar RibbonBar { get; private set; }
    }
}

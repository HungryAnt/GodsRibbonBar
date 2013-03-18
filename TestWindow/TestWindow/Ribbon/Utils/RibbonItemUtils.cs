using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestWindow.Ribbon
{
    class RibbonItemUtils
    {
        static Font _defaultFont = new Font("宋体", 9f);

        public static Font DefaultFont()
        {
            return _defaultFont;
        }
    }
}

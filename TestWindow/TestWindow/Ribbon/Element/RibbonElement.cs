using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonElement
    {
        public Control ParentControl { get; set; }

        Font _font;
        public virtual Font Font
        {
            get
            {
                if (_font == null)
                {
                    if (ParentControl != null)
                    {
                        return ParentControl.Font;
                    }
                }
                return RibbonItemUtils.DefaultFont();
            }
            set
            {
                _font = value;
            }
        }

        Color _foreColor = Color.Black;
        public virtual Color ForeColor
        {
            get
            {
                return _foreColor;
            }
            set
            {
                _foreColor = value;
            }
        }

        #region Location & Size

        public Point Location { get; set; }

        Size _size;
        public virtual Size Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }
        public int Height
        {
            get
            {
                return _size.Height;
            }
            set
            {
                _size.Height = value;
            }
        }
        public int Width
        {
            get
            {
                return _size.Width;
            }
            set
            {
                _size.Width = value;
            }
        }

        public virtual Rectangle Bounds
        {
            get
            {
                return new Rectangle(Location, Size);
            }
        }

        #endregion

        #region Padding Marging

        Padding _margin = new Padding(3, 0, 3, 0);
        public Padding Margin
        {
            get
            {
                return _margin;
            }
            set
            {
                _margin = value;
            }
        }

        Padding _padding = new Padding(3, 3, 3, 3);
        public virtual Padding Padding
        {
            get
            {
                return _padding;
            }
            set
            {
                _padding = value;
            }
        }

        #endregion
    }
}

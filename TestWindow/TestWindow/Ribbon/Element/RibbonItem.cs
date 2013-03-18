using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public /*abstract*/ class RibbonItem : RibbonElement
    {
        RibbonItemSizeType _sizeStyle = RibbonItemSizeType.Large;
        public RibbonItemSizeType SizeStyle
        {
            get
            {
                return _sizeStyle;
            }
            set
            {
                _sizeStyle = value;
            }
        }

        public virtual Image Image { get; set; }
        public ContentAlignment ImageAlign { get; set; }

        static readonly Size SMALL_IMAGE_SIZE = new Size(16, 16);
        static readonly Size LARGE_IMAGE_SIZE = new Size(32, 32);

        public Size ImageSize
        {
            get
            {
                return _sizeStyle == RibbonItemSizeType.Large ? LARGE_IMAGE_SIZE : SMALL_IMAGE_SIZE;
            }
        }

        public int ImageTextSpacing { get; set; }

        public virtual string Text { get; set; }
        //public virtual ContentAlignment TextAlign { get; set; }
        public TextImageRelation TextImageRelation { get; set; }

        public virtual bool Enabled { get; set; }
        public bool Visible { get; set; }

        
        public Rectangle ContentRectangle
        {
            get
            {
                return new Rectangle(Bounds.Left + Padding.Left, Bounds.Top + Padding.Top,
                    Bounds.Width - Padding.Horizontal, Bounds.Height - Padding.Vertical);
            }
        }

        public Rectangle ImageRectangle
        {
            get
            {
                if (Image != null)
                {
                    if (ImageAlign == ContentAlignment.MiddleLeft)
                    {
                        int prefferedHeight = Math.Max(_cachedPreferredSize.Height, ImageSize.Height);

                        return new Rectangle(
                            new Point(Bounds.Left + Padding.Left,
                                Bounds.Top + Padding.Top + (prefferedHeight - ImageSize.Height) / 2),
                            ImageSize);
                    }
                    else if (ImageAlign == ContentAlignment.TopCenter)
                    {
                        int prefferedWidth = Math.Max(_cachedPreferredSize.Width, ImageSize.Width);

                        return new Rectangle(
                            new Point(Bounds.Left + Padding.Left + (prefferedWidth - ImageSize.Width) / 2,
                                Bounds.Top + Padding.Top),
                            ImageSize);
                    }
                }
                return ContentRectangle;
            }
        }

//         public Rectangle TextRectangle
//         {
//             get
//             {
//                 Size textSize = GetPrefferedTextSize(Text);
// 
//                 if (SizeStyle == RibbonItemSizeType.Large)
//                 {
// 
//                     return new Rectangle(Bounds.Left + Padding.Left, )
//                 }
//             }
//         }

        public event EventHandler Click;
        public event PaintEventHandler Paint;

        protected internal RibbonGroup Parent { get; set; }
        public RibbonGroup GetCurrentParent()
        {
            return Parent;
        }

        const int MIN_WIDTH = 60;
        const int MIN_HEIGHT = 25;

        Size _cachedPreferredSize;

        public virtual Size GetPreferredSize(/*Size constrainingSize*/)
        {
            int width = Padding.Horizontal;
            int height = Padding.Vertical;

            if (Image != null)
            {
                if (ImageAlign == ContentAlignment.MiddleLeft)
                {
                    width += ImageSize.Width + ImageTextSpacing;
                }
                else if (ImageAlign == ContentAlignment.TopCenter)
                {
                    height += ImageSize.Height + ImageTextSpacing;
                }
            }

            if (!string.IsNullOrEmpty(Text))
            {
                Size textSize = GetPrefferedTextSize(Text);

                width += textSize.Width;

                if (Image != null && ImageAlign == ContentAlignment.MiddleLeft)
                {
                    height = Math.Max(height, textSize.Height + Padding.Vertical);
                }
                else
                {
                    height += textSize.Height;
                }
            }

            _cachedPreferredSize = new Size(Math.Max(width, MIN_WIDTH), Math.Max(height, MIN_HEIGHT));

            return _cachedPreferredSize;
        }

        Size GetPrefferedTextSize(string text)
        {
            return TextRenderer.MeasureText(Text, Font);
        }

        public void Invalidate()
        {
            //Parent.Invalidate();
        }
        public void Invalidate(Rectangle r)
        {

        }

        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

//         public void Draw(PaintEventArgs e)
//         {
//             OnPaint(e);
//         }

        protected virtual void OnPaint(PaintEventArgs e)
        {
            if (Paint != null)
            {
                Paint(this, e);
            }
        }
    }
}

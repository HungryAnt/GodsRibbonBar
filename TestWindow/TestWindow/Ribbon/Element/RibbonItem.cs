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
        public virtual Image Image { get; set; }
        public ContentAlignment ImageAlign { get; set; }

        public int ImageTextSpacing { get; set; }

        public virtual string Text { get; set; }
        //public virtual ContentAlignment TextAlign { get; set; }
        public TextImageRelation TextImageRelation { get; set; }

        public virtual bool Enabled { get; set; }
        public bool Visible { get; set; }


        RibbonItemSizeStyle _sizeStyle = RibbonItemSizeStyle.Large;
        public RibbonItemSizeStyle SizeStyle
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
        
        public Rectangle ContentRectangle
        {
            get
            {
                return new Rectangle(Bounds.Left + Padding.Left, Bounds.Top + Padding.Top,
                    Bounds.Width - Padding.Horizontal, Bounds.Height - Padding.Vertical);
            }
        }

        public virtual Rectangle ImageRectangle
        {
            get
            {
                return Rectangle.Empty; 
            }
        }

        public virtual Rectangle TextRectangle
        {
            get
            {
                return Rectangle.Empty;
            }
        }

        public event EventHandler Click;
        public event PaintEventHandler Paint;

        protected internal RibbonGroup Parent { get; set; }
        public RibbonGroup GetCurrentParent()
        {
            return Parent;
        }

        public virtual Size GetPreferredSize()
        {
            return new Size(60, 25);
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

        const int SMALL_MIN_WIDTH = 20;
        const int SMALL_MIN_HEIGHT = 20;

        const int LARGE_MIN_WIDTH = 50;
        const int LARGE_MIN_HEIGHT = 80;

        protected Size PreparePreferedSize(int width, int height)
        {
            int minWidth;
            int minHeight;
            if (SizeStyle == RibbonItemSizeStyle.Small)
            {
                minWidth = SMALL_MIN_WIDTH;
                minHeight = SMALL_MIN_HEIGHT;
            }
            else
            {
                minWidth = LARGE_MIN_WIDTH;
                minHeight = LARGE_MIN_HEIGHT;
            }

            return new Size(Math.Max(width, minWidth), Math.Max(height, minHeight));
        }

        public void Draw(PaintEventArgs e)
        {
            OnPaint(e);
        }

        protected virtual void OnPaint(PaintEventArgs e)
        {
            if (Renderer != null)
            {
                Renderer.DrawItemBackground(new RibbonItemRenderEventArgs(e.Graphics, this));
            }

            if (Paint != null)
            {
                Paint(this, e);
            }
        }
    }
}

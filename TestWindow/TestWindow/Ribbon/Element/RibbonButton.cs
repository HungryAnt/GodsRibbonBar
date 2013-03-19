using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonButton : RibbonItem
    {
        public RibbonButton()
        {

        }

        static readonly Size SMALL_IMAGE_SIZE = new Size(16, 16);
        static readonly Size LARGE_IMAGE_SIZE = new Size(32, 32);

        public Size ImageSize
        {
            get
            {
                return SizeStyle == RibbonItemSizeStyle.Large ? LARGE_IMAGE_SIZE : SMALL_IMAGE_SIZE;
            }
        }

        public Rectangle ImageRectangle
        {
            get
            {
                if (Image != null)
                {
                    if (SizeStyle == RibbonItemSizeStyle.Small)
                    {
                        int prefferedHeight = Math.Max(_preferredSize.Height, ImageSize.Height);

                        return new Rectangle(
                            new Point(Bounds.Left + Padding.Left,
                                Bounds.Top + Padding.Top + (prefferedHeight - ImageSize.Height) / 2),
                            ImageSize);
                    }
                    else if (SizeStyle == RibbonItemSizeStyle.Large)
                    {
                        int prefferedWidth = Math.Max(_preferredSize.Width, ImageSize.Width);

                        return new Rectangle(
                            new Point(Bounds.Left + Padding.Left + (prefferedWidth - ImageSize.Width) / 2,
                                Bounds.Top + Padding.Top),
                            ImageSize);
                    }
                }
                return ContentRectangle;
            }
        }

        public Rectangle TextRectangle
        {
            get
            {
                int offsetX;
                int offsetY;

                Size textSize = GetPrefferedTextSize(Text);

                if (SizeStyle == RibbonItemSizeStyle.Small)
                {
                    offsetX = Bounds.Left + Padding.Left;
                    if (Image != null)
                    {
                        offsetX += ImageSize.Width + ImageTextSpacing;
                    }
                    offsetY = Bounds.Top + (_preferredSize.Height - textSize.Height) / 2;
                }
                else/* if (SizeStyle == RibbonItemSizeStyle.Large)*/
                {
                    offsetY = Bounds.Top + Padding.Top;
                    if (Image != null)
                    {
                        offsetY += ImageSize.Height + ImageTextSpacing;
                    }
                    offsetX = Bounds.Left + (_preferredSize.Width - textSize.Width) / 2;
                }

                return new Rectangle(new Point(offsetX, offsetY), textSize/*new Size(200, 20)*/);
            }
        }

        #region 布局控制
        #endregion

        Size _preferredSize;

        public override Size GetPreferredSize()
        {
            int width = Padding.Horizontal;
            int height = Padding.Vertical;

            if (Image != null)
            {
                if (SizeStyle == RibbonItemSizeStyle.Small)
                {
                    width += ImageSize.Width + ImageTextSpacing;
                }
                else if (SizeStyle == RibbonItemSizeStyle.Large)
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

            _preferredSize = PreparePreferedSize(width, height);

            return _preferredSize;
        }

        Size GetPrefferedTextSize(string text)
        {
            return TextRenderer.MeasureText(Text, Font);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Renderer != null)
            {
                Graphics g = e.Graphics;

                if (Image != null)
                {
                    Renderer.DrawItemImage(new RibbonItemImageRenderEventArgs(g, this, Image, ImageRectangle));
                }
                if (!string.IsNullOrEmpty(Text))
                {
                    Renderer.DrawItemText(new RibbonItemTextRenderEventArgs(g, this, Text, TextRectangle, ForeColor, Font));
                }
            }
        }
    }
}

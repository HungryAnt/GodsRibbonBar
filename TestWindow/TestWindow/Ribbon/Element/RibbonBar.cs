using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonBar : RibbonElement
    {
        public RibbonBar()
        {
            Height = 115;
        }

        public RibbonBar(IEnumerable<RibbonGroup> groups)
            : this()
        {
            _groups.AddRange(groups);
        }

        public RibbonBar(params RibbonGroup[] groups)
            : this()
        {
            _groups.AddRange(groups);
        }

        List<RibbonGroup> _groups = new List<RibbonGroup>();

        public List<RibbonGroup> Groups
        {
            get
            {
                return _groups;
            }
        }

        public void Update()
        {
            CalclateItemsLocation();
        }

        #region 布局

        int _locX;  // 宽度
        int _groupLocY;

        int _smallOverlap;  // 记录叠加的small button数量
        int _smallOverlapMaxWidth;  // 记录叠加的small button 的最大的宽度
        int _smallY;

        void CalclateItemsLocation()
        {
            _locX = Padding.Left;
            _smallOverlap = 0;
            _smallOverlapMaxWidth = 0;
            _smallY = 0;

            int groupHeight = this.Height - Padding.Vertical;

            foreach (RibbonGroup group in Groups)
            {
                _locX += group.Margin.Left;

                int groupLocX = _locX;
                _groupLocY = _smallY = Padding.Top + group.Margin.Top;

                _locX += group.Padding.Left;

                foreach (RibbonItem item in group.Items)
                {
                    switch (item.SizeStyle)
                    {
                        case RibbonItemSizeStyle.Large:
                            TravelLargeItem(item);
                            break;
                        case RibbonItemSizeStyle.Small:
                            TravelSmallItem(item);
                            break;
                    }
                }
                EndTravelSmallBtn();

                _locX += group.Padding.Right;
                int groupWidth = _locX - groupLocX;

                group.Location = new Point(groupLocX, _groupLocY);
                group.Size = new Size(groupWidth, groupHeight);

                _locX += group.Margin.Right;
            }
        }

        void TravelLargeItem(RibbonItem item)
        {
            EndTravelSmallBtn();

            _locX += item.Margin.Left;

            item.Location = new Point(_locX, _groupLocY + item.Margin.Top);

            Size itemSize = item.GetPreferredSize();

            item.Size = itemSize;

            _locX += itemSize.Width + item.Margin.Right;
        }

        void TravelSmallItem(RibbonItem item)
        {
            ++_smallOverlap;

            _smallY += item.Margin.Top;
            item.Location = new Point(_locX + item.Margin.Left, _smallY);

            Size itemSize = item.GetPreferredSize();
            item.Size = itemSize;

            _smallY += itemSize.Height + item.Margin.Bottom;

            _smallOverlapMaxWidth = Math.Max(_smallOverlapMaxWidth, itemSize.Width + item.Margin.Horizontal);

            if (_smallOverlap == 3)
            {
                EndTravelSmallBtn();
            }
        }

        // 结束Small Btn的叠加
        // 1、遍历结束 2、遍历到LargeBtn 3、已经叠加了3个SmallBtn
        void EndTravelSmallBtn()
        {
            if (_smallOverlap > 0)
            {
                _locX += _smallOverlapMaxWidth;

                _smallOverlap = 0;
                _smallOverlapMaxWidth = 0;
                _smallY = Margin.Top;
            }
        }

        #endregion
    }
}

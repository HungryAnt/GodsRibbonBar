using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TestWindow.Ribbon
{
    public class RibbonGroup : RibbonElement
    {
        List<RibbonItem> _items = new List<RibbonItem>();

        public List<RibbonItem> Items
        {
            get
            {
                return _items;
            }
        }

        public RibbonGroup(IEnumerable<RibbonItem> items)
        {
            _items.AddRange(items);
        }


        
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PharmacySystem
{
    static class MinuStripMain
    {
        public static ToolStripMenuItem items { set; get; }
        public static List<string> history = new List<string>();

        public static ToolStripMenuItem instance()
        {
            if (items == null) return null;
            ToolStripMenuItem copy = new ToolStripMenuItem()
            {
                Text = items.Text
            };
            foreach (ToolStripItem subItem in items.DropDownItems)
            {
                if(!history.Any(h => h.Equals(subItem.Text)))
                {
                    ToolStripMenuItem ll = new ToolStripMenuItem(subItem.Text);
                    ll.Click += (a, b) => { subItem.PerformClick(); };
                    copy.DropDownItems.Add(ll);
                }
            }
    
            return copy;
        }
    }
}

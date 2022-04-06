using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasManPC.Forms.UI.Editor
{
    internal class ViewItem
    {
        private string _name;
        private ListViewItem _viewItem;

        public ViewItem(string name) { _name = name; _viewItem = new ListViewItem(Name); }


        public string Name { get { return _name; } set { _name = value; _updateName(); } }


        private void _updateName()
        {
            _viewItem.Text = Name;
        }
    }
}

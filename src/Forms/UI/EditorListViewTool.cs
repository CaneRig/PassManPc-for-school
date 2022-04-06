using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasManPC.Core.Extention;

namespace PasManPC.Forms.UI.Editor
{
    //name login password
    public class ListViewTool
    {
        #region Fileds
        public const int NameId = 1, LoginId = 2, PasswordId = 3;
        private readonly ListView _layout;
        #endregion


        public ListView Layout { get { return _layout; } }
        public ListView.ListViewItemCollection Items => Layout.Items;


        public ListViewTool(ListView listView)
        {
            _layout = listView;

            _layout.Items.Clear();

            if (Layout == null)
                throw new ArgumentNullException("null layout");
        }


        #region ListView
        public ListView.SelectedListViewItemCollection SelectedItems => Layout.SelectedItems;

        #endregion

        #region Container Methods
        public void Add(string name, string login, int password)
        {
            var item = new ListViewItem();

            item.Name = name;
            item.SubItems.Add(name);
            item.SubItems.Add(login);
            item.SubItems.Add('X'.Repeat(password));

            Layout.Items.Add(item);
        }
        public bool Contains(string name) => Layout.Items.ContainsKey(name);

        public void Remove(string name)
        {
            if (Contains(name))
            {
                Layout.Items.RemoveByKey(name);
            }
        }

        public void Rename(string oldName, string newName)
        {
            if (Contains(oldName))
            {
                var val = this[oldName];
                Remove(oldName);

                val.SubItems[NameId].Text = newName;
                Layout.Items.Add(val);
            }
            else
            {
                throw new ArgumentException("trying rename not existing ui element");
            }
        }
        public void SetLogin(string name, string login)
        {
            if (Contains(name))
            {
                var val = this[name];
                val.SubItems[LoginId].Text = login;
            }
            else
            {
                throw new ArgumentException("accesing not existing ui element");
            }
        }
        public void SetPassword(string name, int password)
        {
            if (Contains(name))
            {
                var val = this[name];
                val.SubItems[PasswordId].Text = 'X'.Repeat(password);
            }
            else
            {
                throw new ArgumentException("accesing not existing ui element");
            }
        }

        public ListViewItem this[string name]
        {
            get => Layout.Items[name];
            set
            {
                if (Contains(name)) Remove(name);

                Layout.Items.Add(value);
            }
        }

        public void Clear()
        {
            _layout.Items.Clear();
        }

        public int Count => Items.Count;

        public void Sort() => _layout.Sort();
        #endregion
    }
    class ListViewItemComparer : IComparer
    {
        private int _column;
        private bool _order = true;
        public ListViewItemComparer(int column, IComparer comparable)
        {
            if(comparable is ListViewItemComparer)
            {
                var last = (ListViewItemComparer)comparable;

                if (last._column == column)
                    _order = !last._order;
            }
            _column = column;
        }

        public int Column { get => _column; }

        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[_column].Text, ((ListViewItem)y).SubItems[_column].Text) * (_order?-1:1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasManPC.Core.Session;
using PasManPC.Forms.UI.Editor;

namespace PasManPC.Forms
{
    public partial class Editor : Form
    {
        #region Fields
        private const int MaxFieldLength = 256;
        private const int MaxNameLength = 64;

        private UI.Editor.ListViewTool _layoutTool;
        private Session _session;
        private Dictionary<string, Inspector> _wins;

        private bool showSaveDialogOnExit = true;
        #endregion

        #region Encapsulation
        public ListViewTool LayoutTool { get => _layoutTool; private set => _layoutTool = value; }
        public Session Session { get => _session; private set => _session = value; }
        #endregion


        public Editor(User user)
        {
            InitializeComponent();


            LayoutTool = new ListViewTool(this.layout);
            _session = new Session(user);
            _wins = new Dictionary<string, Inspector>();

            UpdateUI();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (showSaveDialogOnExit && MessageBox.Show("Save before exit?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveToolStripMenuItem_Click();
            }

            base.OnClosing(e);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Exit();
        }

        private void Editor_Load(object sender, EventArgs e) { }


        void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #region UI Actions
        public void UpdateUI()
        {
            UpdateUI((string a) => true);
        }
        public void UpdateUI(Predicate<string> pred)
        {
            LayoutTool.Clear();


            foreach (var item in Session)
            {
                if (pred(item.Key))
                    LayoutTool.Add(item.Key, item.Value.Login, item.Value.Password.Length);
            }
        }

        #endregion

        private void destryWindow(string name)
        {
            if (_wins.ContainsKey(name))
            {
                var win = _wins[name];

                win.Close();

                if (_wins.ContainsKey(name))
                    _wins.Remove(name);
            }
        }
        private void addWindow(string name, ListViewItem item)
        {
            if (_wins.ContainsKey(name))
            {
                var win = _wins[name];

                win.Show();
                win.Activate();
            }
            else
            {
                var win = new Inspector(_session, _session[name], item, () => _wins.Remove(name));

                win.Show();

                _wins.Add(name, win);
            }            
        }

        public string GenerateName()
        {
            string guid = Core.Security.Hash.Sha256(Guid.NewGuid().ToString()).Substring(0, MaxNameLength);


            while (Session.Contains(guid))
                guid = Core.Security.Hash.Sha256(Guid.NewGuid().ToString()).Substring(0, MaxNameLength);
            return guid;
        }

        private void onElementAcivate(object sender, EventArgs e)
        {
            var item = LayoutTool.SelectedItems[0];

            try
            {
                addWindow(item.Name, item);
            }
            catch (Exception ee)
            {
                DialogueBox.Error(ee);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs _e)
        {
            try
            {
                var brick = new Core.Brick(GenerateName());

                Session.Add(brick);
                LayoutTool.Add(brick.Name, brick.Login, brick.Password.Length);
            }
            catch (Exception e)
            {
                DialogueBox.Warning(e);
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LayoutTool.Layout.Items.Count; i++)
                LayoutTool.Layout.Items[i].Checked = true;
        }

        private void deselectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LayoutTool.Layout.Items.Count; i++)
                LayoutTool.Layout.Items[i].Checked = false;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LayoutTool.Layout.Items.Count; i++)
                LayoutTool.Layout.Items[i].Checked = !LayoutTool.Layout.Items[i].Checked;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs et)
        {
            var items = LayoutTool.Layout.CheckedItems;

            while (items.Count > 0)
            {
                items = LayoutTool.Layout.CheckedItems;
                try
                {
                    var item = items[0];

                    destryWindow(item.Name);

                    if (Session.Contains(item.Name))
                        _session.Remove(_session[item.Name]);
                    LayoutTool.Remove(item.Name);

                }
                catch (Exception e)
                {
                    DialogueBox.Error(e);
                }
            }
        }

        private void layout_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            LayoutTool.Layout.ListViewItemSorter = new ListViewItemComparer(e.Column, LayoutTool.Layout.ListViewItemSorter);
        }

        private void saveToolStripMenuItem_Click(object sender = null, EventArgs e = null)
        {
            try
            {
                Session.Save();
            }
            catch (Exception exc)
            {
                DialogueBox.Error(exc);
            }
        }

        private void yesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Delete user?", "Think about it", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    if (MessageBox.Show("Last warning, continue?", "goodbye", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        Core.FileSystem.Delete(Session.UserHash);
                        DialogueBox.Information("User deleted");

                        showSaveDialogOnExit = false;

                        this.Close();
                    }
            }
            catch (Exception er)
            {
                DialogueBox.Error(er);
            }
        }
    }
}

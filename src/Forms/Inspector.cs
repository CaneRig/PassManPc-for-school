using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasManPC.Core;
using PasManPC.Core.Session;
using PasManPC.Core.Extention;

namespace PasManPC.Forms
{
    public partial class Inspector : Form
    {
        private Session _session;

        private Core.Brick _brick;
        private ListViewItem _viewItem;
        private Action _onDelete;

        public string Title { get => ((Form)this).Name; set => ((Form)this).Name = value; }
        public new string Name { get => nameBox.Text; private set => nameBox.Text = value; }
        public string Login { get => loginBox.Text; private set => loginBox.Text = value; }
        public string Password { get => passBox.Text; private set => passBox.Text = value; }
        public Brick Source { get => _brick; private set => _brick = value; }
        private ListViewItem ViewItem { get => _viewItem; set => _viewItem = value; }

        public Inspector(Session ses, Core.Brick brick, ListViewItem viewItem, Action onDelete)
        {
            InitializeComponent();

            Source = brick;
            _session = ses;
            _viewItem = viewItem;
            _onDelete = onDelete;

            Name = Source.Name;
            Login = Source.Login;
            Password = Source.Password;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            // Code
            _onDelete();
        }

        private void NameChecker_Click(object sender, EventArgs e)
        {

            if (_session.Contains(Name) && Name != Source.Name && Name.Length > 2)
                DialogueBox.Warning("This name is already taken");
            else
                DialogueBox.Information("This name is good");
        }

        private void discard_Click(object sender, EventArgs e)
        {
            Name = Source.Name;
            Login = Source.Login;
            Password = Source.Password;
        }

        private void save_Click(object sender = null, EventArgs e = null)
        {
            try
            {
                if (_session.Contains(Name) && Name != Source.Name && Name.Length > 2)
                {
                    DialogueBox.Warning("This name is already taken, aboreted");
                    return;
                }

                _session.Rename(Name, Source.Name);
                Source.Name = Name;
                Source.Login = Login;
                Source.Password = Password;

                ViewItem.Name = Name;
                ViewItem.SubItems[Forms.UI.Editor.ListViewTool.NameId].Text = Name;
                ViewItem.SubItems[Forms.UI.Editor.ListViewTool.LoginId].Text = Login;
                ViewItem.SubItems[Forms.UI.Editor.ListViewTool.PasswordId].Text = 'x'.Repeat(Password.Length);
            }
            catch (Exception ex)
            {
                DialogueBox.Error(ex);
            }
        }

        public bool Edited => !(Name == Source.Name && Login == Source.Login && Password == Source.Password);

        private void closebutt_Click(object sender, EventArgs e)
        {
            if (Edited)
            {
                switch (MessageBox.Show("This element was edited, save or not?", "Save before exit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                {
                    case DialogResult.None:
                        return;
                        break;
                    case DialogResult.Cancel:
                        return;
                        break;
                    case DialogResult.Yes:
                        save_Click();
                        break;
                    default:
                        break;
                }
            }
            this.Close();
        }

        private void hidePassword_Click(object sender, EventArgs e)
        {
            if (passBox.PasswordChar == 'x')
                passBox.PasswordChar = '\0';
            else
                passBox.PasswordChar = 'x';
        }
    }
}
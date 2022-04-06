using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PasManPC
{
    public partial class HomeWindow : Form
    {
        private const int MinInputLength = 2;

        public HomeWindow()
        {
            InitializeComponent();

            this.Text = "Login";
        }

        private void homeWindow_Load(object sender, EventArgs e)
        {
        }

        #region Form Methods
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Forms.UserCreate();

            f.Show();
        }

        private void loginButton_Click(object sender, EventArgs _e)
        {
            
            if(this.loginBox.Text.Length < MinInputLength)
            {
                Forms.DialogueBox.Error("Login too small");
                return;
            }
            if (this.passwordBox.Text.Length < MinInputLength)
            {
                Forms.DialogueBox.Error("Password too small");
                return;
            }
            if(validateLogin(this.loginBox.Text, this.passwordBox.Text, out Core.Session.User user))
            {
                loadEditor(user);
            }
            else
            {
                Forms.DialogueBox.Error("Incorrect login or password!");
            }
        }
        #endregion

        private void loadEditor(Core.Session.User user)
        {
            try
            {
                var editor = new Forms.Editor(user);

                editor.Show();
                this.Hide();
            }
            catch (Exception emsg)
            {
                Forms.DialogueBox.Error("Your file was corrupted or wrong password has used");
            }
        }
        private bool validateLogin(string login, string password, out Core.Session.User use)
        {
            try
            {
                use = new Core.Session.User(loginBox.Text, passwordBox.Text);
                return true;
            }
            catch (Core.Exceptions.NoUserException)
            {
                use = null;
                return false;
            }
        }

    }
}

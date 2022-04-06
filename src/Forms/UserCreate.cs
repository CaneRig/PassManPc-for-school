using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasManPC.Forms
{
    public partial class UserCreate : Form
    {
        public UserCreate()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, EventArgs e)
        {
            string log = loginBox.Text;

            try
            {
                log = Core.Session.User.HashLogin(log);

                if (Core.FileSystem.IsThereUser(log))
                {
                    DialogueBox.Error("Bad login, try another(");

                    return;
                }

                using (var fs = new Core.FileSystem(log))
                {
                    fs.Create();
                }
                DialogueBox.Information("Succsesfully created");

                this.Close();
            }
            catch (Exception ee)
            {
                DialogueBox.Error(ee);
            }
        }
    }
}

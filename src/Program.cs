using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using PasManPC.Core;

namespace PasManPC
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        public static string g(byte[] b) {
            string s = "";
            for (int i = 0; i < b.Length; i++)
            {
                s += b[i].ToString() + " ";
            }

            return s;
        }

        [STAThread]
        static void Main()
        {
            //try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Forms.RepresentorBase("ligma", new string[] { "balls", "boobs", "dick" }));
                // Application.Run(new Forms.Editor( new Core.Session.User()));

                byte[] cryptingData, key, iv;

                Application.Run(new HomeWindow());
            }
           // catch (Exception exp)
            {
               // MessageBox.Show("FATAL ERROR: " + exp.ToString(), "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

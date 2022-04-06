using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasManPC.Forms
{
    public static class DialogueBox
    {
        public static void Information(string message) =>
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        public static void Warning(string message) =>
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public static void Error(string message) =>
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void Warning(Exception message) =>
            MessageBox.Show(ExceptionToString(message), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        public static void Error(Exception message) =>
            MessageBox.Show(ExceptionToString(message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        public static string ExceptionToString(Exception exception)
        {
            return exception.Message;
        }
        
    }
}

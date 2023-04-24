using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS
{
    internal class MessageboxHelper
    {
        public static void Information(string caption, string message)
        {
            XtraMessageBox.Show(message,caption,MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string caption, string message)
        {
            XtraMessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string? classname, string? methodname, string caption, string message)
        {
            try
            {
                LogManager.Write("Failure", classname, methodname, message);
            }
            catch { }   

            XtraMessageBox.Show("오류가 발생하였습니다." + Environment.NewLine + message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Question(string caption, string message)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }
    }
}

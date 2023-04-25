using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS
{
    internal class ValidationUtility
    {
        public static Boolean Empty(string caption, string message, DevExpress.XtraEditors.TextEdit textEdit)
        {
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    MessageboxHelper.Information(caption, message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Empty(string caption, string message, DevExpress.XtraEditors.ButtonEdit buttonEdit)
        {
            if (string.IsNullOrEmpty(buttonEdit.Text))
            {
                if (!string.IsNullOrEmpty(message))
                {
                    MessageboxHelper.Information(caption, message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Empty(string caption, string message, DevExpress.XtraEditors.DateEdit dateEdit)
        {
            if (dateEdit.EditValue == null)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    MessageboxHelper.Information(caption, message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }
        public static Boolean Empty(string caption, string message, DevExpress.XtraEditors.DateEdit dateEdit1, DevExpress.XtraEditors.DateEdit dateEdit2)
        {
            if (dateEdit1.EditValue == null || dateEdit2.EditValue == null)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    MessageboxHelper.Information(caption, message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }


        public static Boolean Empty(string caption, DevExpress.XtraGrid.Views.Grid.GridView gridView, string message)
        {
            if (gridView.SelectedRowsCount <= 0)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    MessageboxHelper.Information(caption, message);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

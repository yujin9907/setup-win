using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolvocarsDMS.Common
{
    internal class FillCombo
    {
        public static void ApiServer(DevExpress.XtraEditors.ComboBoxEdit cbo, int SelectIndex, bool IsDisableTextEditor)
        {
            cbo.Properties.Items.Clear();

            cbo.Properties.Items.Add(new ComboValues("http://vckims.comnarae.com:7777/", "Production Server"));
            cbo.Properties.Items.Add(new ComboValues("http://vckims.comnarae.com:7777/", "Test Server"));
            cbo.Properties.Items.Add(new ComboValues("", "Temporary server"));

            DevExpressUtility.TextEditDisable(cbo, IsDisableTextEditor);

            cbo.SelectedIndex = SelectIndex;
        }

    }
}

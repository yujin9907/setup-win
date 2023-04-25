using DevExpress.Pdf.Native.BouncyCastle.Utilities.Collections;
using DevExpress.XtraEditors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolvocarsDMS.Common;

namespace VolvocarsDMS.Base
{
    public partial class FrmBaseCompany : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaseCompany()
        {
            InitializeComponent();
        }

        #region Event
        private void BtnInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Insert();
        }

        private void BtnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
            }
        }

        private void BtnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }

        private void BtnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        #region Method
        private void Reload()
        {
            try
            {
                #region Validation

                this.Cursor = Cursors.WaitCursor;
                #endregion


                #region Init
                DevExpressUtility.Clear(gridControl1, gridView1);

                #endregion

                #region Parameter
                JObject Parameter1 = new()
                {
                    {"dealership_grant", "DEALER" },
                    {"dlr_cd", "IRGA" },
                    {"comp_fl", "C" }
                };
                #endregion

                #region Execute
                if (!ApiRequester.Get(this.Text, UrlRoutes.MasterCompanies(), Parameter1, out DataTable? dt))
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (dt == null) return;
                #endregion

                #region Grid Fill
                gridControl1.DataSource = dt;

                

                this.Cursor = Cursors.Default;

                #endregion



            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }


        private void Insert()
        {
            FrmBaseCompany_F1 f = new FrmBaseCompany_F1();
            f.ShowDialog();
        }

        #endregion

    }
}
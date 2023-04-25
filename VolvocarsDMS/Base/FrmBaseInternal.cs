using DevExpress.ClipboardSource.SpreadsheetML;
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
    public partial class FrmBaseInternal : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaseInternal()
        {
            InitializeComponent();

            InitGrid();
        }
        
        private void InitGrid()
        {
            try
            {
                //gridView1.Columns.Add(DevExpressUtility.GetGridColumn("No", "No", "No", true));
                //gridView1.Columns.Add(DevExpressUtility.GetGridColumn("Code", "Code", "코드", true));
                //gridView1.Columns.Add(DevExpressUtility.GetGridColumn("Name", "Name", "Internal", true));
                //gridView1.Columns.Add(DevExpressUtility.GetGridColumn("Desc", "Desc", "비고", true));


                //DataTable dt = new DataTable();
                //dt.Columns.Add("No");
                //dt.Columns.Add("Code");
                //dt.Columns.Add("Name");
                //dt.Columns.Add("Desc");

                //DataRow dr = dt.NewRow();
                //dr["No"] = 1;
                //dr["Code"] = "IB";
                //dr["Name"] = "판금/도장 무상서비스";
                //dr["Desc"] = "";
                //dt.Rows.Add(dr);

                //dr = dt.NewRow();
                //dr["No"] = 1;
                //dr["Code"] = "IC";
                //dr["Name"] = "쿠폰(엔진오일)";
                //dr["Desc"] = "";
                //dt.Rows.Add(dr);

                //gridControl1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }   
        }

        private void BtnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                JObject Parameter1 = new();

                #endregion

                #region Execute
                if (!ApiRequester.Get(this.Text, UrlRoutes.MasterInternal(), Parameter1, out DataTable? dt))
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
    }
}
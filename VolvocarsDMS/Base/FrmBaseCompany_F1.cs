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
    public partial class FrmBaseCompany_F1 : DevExpress.XtraEditors.XtraForm
    {
        public FrmBaseCompany_F1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                if (ValidationUtility.Empty(this.Text, "rquest_type를 입력해주세요", textEdit1)) return;
                if (ValidationUtility.Empty(this.Text, "dlr_cde를 입력해주세요", textEdit2)) return;
                if (ValidationUtility.Empty(this.Text, "comp_cd를 입력해주세요", textEdit3)) return;
                if (ValidationUtility.Empty(this.Text, "comp_fl를 입력해주세요", textEdit4)) return;
                if (ValidationUtility.Empty(this.Text, "comp_nm를 입력해주세요", textEdit5)) return;


                this.Cursor = Cursors.WaitCursor;
                #endregion

                #region Init

                #endregion

                #region Parameter
                JArray jArray = new();

                JObject Parameter2 = new()
                {
                    {"request_type", textEdit1.Text.Trim() },
                    {"dlr_cd", textEdit2.Text.Trim() },
                    {"comp_cd", textEdit3.Text.Trim() },
                    {"comp_fl", textEdit4.Text.Trim() },
                    {"comp_nm", textEdit5.Text.Trim() },
                    {"comp_no",textEdit6.Text.Trim() },
                };

                jArray.Add(Parameter2);

                JObject Parameter1 = new()
                {
                    {"dealership_grant", "CENTER" },
                    {"data", jArray },
                    
                };


               

                #endregion

                #region Execute
                if (!ApiRequester.Post(this.Text, UrlRoutes.MasterCompanies(), Parameter1, out DataTable? dt, out DataSet? ds))
                {
                    this.Cursor = Cursors.Default;
                    return;
                }

                MessageboxHelper.Information(this.Text, "저장되었습니다.");
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
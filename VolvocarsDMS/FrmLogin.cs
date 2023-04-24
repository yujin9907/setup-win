using DevExpress.Map.Native;
using DevExpress.Pdf.Native.BouncyCastle.Ocsp;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Export.Pdf.Compression;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace VolvocarsDMS
{
    public partial class FrmLogin : DevExpress.XtraEditors.XtraForm
    {
        private Point _WindowPosition = new (0, 0);

        

        #region Form
        public FrmLogin()
        {
            InitializeComponent();

            Init();
        }
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _WindowPosition = new Point(-e.X, -e.Y);
            }
        }

        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (_WindowPosition.X + e.X), this.Location.Y + (_WindowPosition.Y + e.Y));
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= 0x00020000;
                return createParams;
            }
        }

        #endregion

        #region Event
        private void TxtId_KeyDown(object sender, KeyEventArgs e)
        {
            if (((System.Windows.Forms.Keys)e.KeyCode) == Keys.Enter)
            {
                BtePassword.SelectAll();
                BtePassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (((System.Windows.Forms.Keys)e.KeyCode) == Keys.Enter)
            {
                Login();
            }
        }

        private void BtePassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (((System.Windows.Forms.Keys)e.KeyCode) == Keys.Enter)
            {
                Login();
            }
        }

        private void BtePassword_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BtePasswordButtonPressed();
        }

        private void BtePassword_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            BtePasswordButtonClick();
        }

        private void TxtApiUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (((System.Windows.Forms.Keys)e.KeyCode) == Keys.Enter)
            {
                Login();
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void CboApiUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboApiUrlSelectedIndexChanged();
        }


        #endregion

        #region Method
        private void Init()
        {
            try
            {
                Sessions.AppConfig = JsonHelper.FromJson(Constants.AppConfigFilepath);

                TxtId.Properties.NullValuePrompt = "사용자 아이디를 입력해주세요";
                BtePassword.Properties.PasswordChar = '*';
                BtePassword.Properties.NullValuePrompt = "사용자 비밀번호를 입력해주세요";

                TxtId.Text = "ljh";
                BtePassword.Text = "eogml123";


                FillCombo.ApiServer(CboApiUrl, 0, true);

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }

        private void CboApiUrlSelectedIndexChanged()
        {
            try
            {
                if (DevExpressUtility.GetCode(CboApiUrl).Equals(""))
                {
                    TxtApiUrl.Visible = true;
                }
                else
                {
                    TxtApiUrl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }

        }

        private void BtePasswordButtonPressed()
        {
            try
            {
                BtePassword.Properties.PasswordChar = '\0';
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }

        }

        private void BtePasswordButtonClick()
        {
            try
            {
                BtePassword.Properties.PasswordChar = '*';
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }

        }

        private void Login()
        {
            JObject Parameter1;

            try
            {
                #region Validation
                if (ValidationUtility.Empty(this.Text, "사용자 아이디를 입력해주세요.", TxtId)) return;
                if (ValidationUtility.Empty(this.Text, "사용자 비밀번호를 입력해주세요.", BtePassword)) return;

                this.Cursor = Cursors.WaitCursor;
                #endregion

                #region Init
                if (DevExpressUtility.GetCode(CboApiUrl).Equals(""))
                {
                    Sessions.ApiServer = TxtApiUrl.Text;
                }
                else
                {
                    Sessions.ApiServer = DevExpressUtility.GetCode(CboApiUrl);
                }

                #endregion

                #region Execute - Login
                Parameter1 = new()
                {
                    {"emp_id", TxtId.Text.Trim() },
                    {"emp_pw", BtePassword.Text.Trim() },
                    {"login_dlr_cd", "IRGA" },
                    {"dms_version", "1.0" }
                };

                if (!ApiRequester.Post(this.Text, UrlRoutes.AuthToken(), Parameter1, out DataTable? DtToken, out DataSet? ds))
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                if (DtToken == null) return;

                Sessions.Token = DtToken.Rows[0]["token"].ToString();

                #endregion

                #region Execute - User
                //Parameter1 = new()
                //{
                //    {"empId", TxtId.Text.Trim() }
                //};

                //if (!ApiRequester.Get(this.Text, UrlRoutes.DealerEmployee(), Parameter1, out DataTable? DtUser))
                //{
                //    this.Cursor = Cursors.Default;
                //    return;
                //}
                //if (DtUser == null) return;

                //Sessions.UserId = DtUser.Rows[0]["empId"].ToString();
                //Sessions.UserName = DtUser.Rows[0]["emp_nm"].ToString();
                //Sessions.UserDeptCd = DtUser.Rows[0]["dept_cd"].ToString();
                //Sessions.UserDeptNm = DtUser.Rows[0]["dept_nm"].ToString();
                //Sessions.UserPosCd = DtUser.Rows[0]["pos_cd"].ToString();
                //Sessions.UserPosNm = DtUser.Rows[0]["pos_nm"].ToString();

                #endregion

                #region Execute - Menu
                //Parameter1 = new()
                //{
                //    {"program", "DMS" },
                //    {"userId", TxtId.Text.Trim() }
                //};

                ////if (!ApiRequester.Get(this.Text, UrlRoutes.DealerEmployee(), Parameter1, out DataTable? DtMenu)) 호출했을때 직원 정보가 모두 나옴 ?
                //if (!ApiRequester.Get(this.Text, UrlRoutes.SystemGrantMenu(), Parameter1, out DataTable? DtMenu))
                //{
                //    this.Cursor = Cursors.Default;
                //    return;
                //}
                //if (DtMenu == null) return;


                #endregion


                #region Return
                this.Cursor = Cursors.Default;
                this.DialogResult = DialogResult.OK;

                #endregion
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }

        #endregion

        
    }
}
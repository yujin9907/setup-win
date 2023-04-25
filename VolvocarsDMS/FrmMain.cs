using DevExpress.ChartRangeControlClient.Core;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet.Model.CopyOperation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VolvocarsDMS.Base;
using VolvocarsDMS.Common;

namespace VolvocarsDMS
{
    public delegate void SetLogApiUrlCallback(string Value);
    public delegate void SetLogApiHeaderCallback(string Value);
    public delegate void SetLogApiRequestCallback(string Value);
    public delegate void SetLogApiResponseCallback(string Value);

    public partial class FrmMain : DevExpress.XtraEditors.XtraForm
    {
        #region Form
        public FrmMain()
        {
            InitializeComponent();

            InitSkin();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;

                FrmLogin f = new FrmLogin();

                if (f.ShowDialog(this) != DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    Init();

                    InitSkin();

                    InitGrid();

                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F12)
                {
                    LogShow();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }

        #endregion

        #region Init
        private void Init()
        {
            this.KeyPreview = true;

            Sessions.MainForm = this;

            Assembly? assembly = Assembly.GetExecutingAssembly();
            if (assembly != null)
            {
                Version? version = assembly.GetName().Version;

                if (version != null)
                {
                    this.Text = this.Text + " " + version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString() + "." + version.Revision.ToString();
                }
            }

            BarStatusUser.Caption = Sessions.UserDeptNm + " " + Sessions.UserName;
            BarStatusAs.Caption = "프로그램 문의: 051-329-7777";

            LogHidden();
        }

        private void InitGrid()
        {
            DevExpressUtility.GridInit(GrcSystemLog, GrvSystemLog);
        }

        private void InitSkin()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(CommonUtility.GetAppConfig("Skin"));

            string[] skinsToHide = { };
            //string[] skinsToHide = { "DevExpress Style", "DevExpress Dark Style", "Visual Studio 2013 Blue", "Visual Studio 2013 Dark", "Visual Studio 2013 Light ", "Visual Studio 2010" };
            for (var i = 0; i < BsiToolSkin.ItemLinks.Count; i++)
            {
                //Check regular button items
                if (BsiToolSkin.ItemLinks[i] is BarButtonItemLink)
                {
                    var item = BsiToolSkin.ItemLinks[i];
                    foreach (var skin in skinsToHide)
                    {
                        if (item.Caption.Contains(skin))
                        {
                            item.Visible = false;
                        }

                        //if (item.Caption == "DevExpress Style")
                        //{
                        //    BarButtonItem parentItem = (BarButtonItem)item.Item;
                        //    parentItem.Caption = "Default Skin";
                        //    //parentItem.ImageUri.Uri = "Apply";
                        //}
                    }
                }
            }

            DevExpress.LookAndFeel.UserLookAndFeel.Default.StyleChanged += BsiToolSkin_StyleChanged;
        }
        #endregion

        #region Menu
        private void BsiBaseInternal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowChild(typeof(FrmBaseInternal));
        }
        private void BsiBaseCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            ShowChild(typeof(FrmBaseCompany));
        }


        private void ShowChild(Type formtype)
        {
            try
            {
                Form? form = null;
                foreach (Form child in this.MdiChildren)
                {
                    if (child.GetType().Equals(formtype))
                    {
                        form = child;
                    }
                }

                if (form == null)
                {
                    //targetForm = (Form)Activator.CreateInstance(formType, obj);
                    if (formtype != null)
                    {
                        form = (Form?)Activator.CreateInstance(formtype);
                    }

                    if (form != null)
                    {
                        form.MdiParent = this;
                    }
                }

                if (form != null)
                {
                    if (form.MaximizeBox) form.WindowState = FormWindowState.Maximized;

                    form.Show();
                    form.Activate();
                }

            }
            catch (Exception ex)
            {
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }
        #endregion

        #region Skin
        private void BsiToolSkin_StyleChanged(object? sender, EventArgs e)
        {
            try
            {
                CommonUtility.SetAppConfig("Skin", DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName);

                if (Sessions.AppConfig != null)
                {
                    File.WriteAllText(Constants.AppConfigFilepath, JsonHelper.ToJson(Sessions.AppConfig));
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }

        #endregion

        #region Log
        public void SetLogApiUrl(string Value)
        {
            try
            {
                if (this.TxtApiUrl.InvokeRequired)
                {
                    SetLogApiUrlCallback d = new (SetLogApiUrl);
                    this.Invoke(d, new object[] { Value });
                }
                else
                {
                    TxtApiUrl.Text = Value;
                }
            }
            catch (Exception ex)
            {
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }
        public void SetLogApiHeader(string Value)
        {
            try
            {
                if (this.MemApiHeader.InvokeRequired)
                {
                    SetLogApiHeaderCallback d = new(SetLogApiHeader);
                    this.Invoke(d, new object[] { Value });
                }
                else
                {
                    MemApiHeader.Text = Value;
                }
            }
            catch (Exception ex)
            {
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }
        public void SetLogApiRequest(string Value)
        {
            try
            {
                if (this.MemApiRequest.InvokeRequired)
                {
                    SetLogApiRequestCallback d = new(SetLogApiRequest);
                    this.Invoke(d, new object[] { Value });
                }
                else
                {
                    MemApiRequest.Text = Value;
                }
            }
            catch (Exception ex)
            {
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }
        public void SetLogApiResponse(string Value)
        {
            try
            {
                if (this.MemApiResponse.InvokeRequired)
                {
                    SetLogApiResponseCallback d = new(SetLogApiResponse);
                    this.Invoke(d, new object[] { Value });
                }
                else
                {
                    MemApiResponse.Text = Value;
                }
            }
            catch (Exception ex)
            {
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }

        private void TabLogView_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            try
            {
                if (e.Button.Caption.Equals("나가기"))
                {
                    LogHidden();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
        }

        private void LogHidden()
        {
            Sessions.IsApiLog = false;

            PnlLogView.Visible = false;
            SptLogView.Visible = false;
        }

        private void LogShow()
        {
            Sessions.IsApiLog = true;

            TxtApiUrl.Text = "";
            MemApiHeader.Text = "";
            MemApiRequest.Text = "";
            MemApiResponse.Text = "";

            DteSystemLogDate1.DateTime = DateTime.Now;
            DteSystemLogDate2.DateTime = DateTime.Now;

            DevExpressUtility.Clear(GrcSystemLog, GrvSystemLog);
            MemSystemLogContent.Text = "";

            PnlLogView.Visible = true;
            SptLogView.Visible = true;
        }

        private void BtnSystemLogSearch_Click(object sender, EventArgs e)
        {
            DataTable dt;
            DataRow dr;

            string Folder;
            string FolderLog;

            DateTime Period1;
            DateTime Period2;

            DirectoryInfo directoryInfo;

            string? Line;

            string DatetimeLog;
            string Status;
            string ClassName;
            string MethodName;
            string Content;

            try
            {
                #region Validation
                if (ValidationUtility.Empty(this.Text, "시작일자를 입력해주세요.", DteSystemLogDate1)) return;
                if (ValidationUtility.Empty(this.Text, "종료일자를 입력해주세요.", DteSystemLogDate2)) return;

                this.Cursor = Cursors.WaitCursor;
                #endregion

                #region Init
                DevExpressUtility.Clear(GrcSystemLog, GrvSystemLog);

                dt = new DataTable();
                dt.Columns.Add(new DataColumn("시간", typeof(string)));
                dt.Columns.Add(new DataColumn("상태", typeof(string)));
                dt.Columns.Add(new DataColumn("클래스", typeof(string)));
                dt.Columns.Add(new DataColumn("메소드", typeof(string)));
                dt.Columns.Add(new DataColumn("내용", typeof(string)));

                if (Application.StartupPath.EndsWith("\\"))
                {
                    Folder = Application.StartupPath + "LOG\\";
                }
                else
                {
                    Folder = Application.StartupPath + "\\LOG\\";
                }

                Period1 = Convert.ToDateTime(DteSystemLogDate1.DateTime.ToString("yyyy-MM-01"));
                Period2 = Convert.ToDateTime(DteSystemLogDate2.DateTime.ToString("yyyy-MM-01"));

                #endregion

                #region Execute Query
                while (Period1 <= Period2)
                {
                    FolderLog = Folder + Period1.ToString("yyyy-MM");

                    directoryInfo = new DirectoryInfo(FolderLog);

                    if (directoryInfo.Exists)
                    {
                        FileInfo[] fileInfo = directoryInfo.GetFiles("*.log");

                        foreach (FileInfo f in fileInfo)
                        {
                            if (Convert.ToDateTime(f.Name.Substring(0, 10)) >= Convert.ToDateTime(DteSystemLogDate1.DateTime.ToString("yyyy-MM-dd")) && Convert.ToDateTime(f.Name.Substring(0, 10)) <= Convert.ToDateTime(DteSystemLogDate2.DateTime.ToString("yyyy-MM-dd")))
                            {
                                //System.IO.StreamReader sr = new System.IO.StreamReader(LogFolder + "\\" + f.Name, Encoding.GetEncoding("euc-kr"));
                                StreamReader streamReader = new (FolderLog + "\\" + f.Name);
                                

                                while ((Line = streamReader.ReadLine()) != null)
                                {
                                    DatetimeLog = string.Empty;
                                    Status = string.Empty;
                                    ClassName = string.Empty;
                                    MethodName = string.Empty;
                                    Content = string.Empty;

                                    string[] lines = Line.Split('\t');
                                    if (lines.Length > 0) DatetimeLog = lines[0];
                                    if (lines.Length > 1) Status = lines[1];
                                    if (lines.Length > 2) ClassName = lines[2];
                                    if (lines.Length > 3) MethodName = lines[3];
                                    if (lines.Length > 4) Content = lines[4];

                                    dr = dt.NewRow();
                                    dr["시간"] = DatetimeLog;
                                    dr["상태"] = Status;
                                    dr["클래스"] = ClassName;
                                    dr["메소드"] = MethodName;
                                    dr["내용"] = Content;
                                    dt.Rows.Add(dr);
                                }

                                streamReader.Close();
                            }
                        }
                    }

                    Period1 = Period1.AddMonths(1);
                }
                #endregion

                #region Fill Grid
                GrcSystemLog.DataSource = dt;
                DevExpressUtility.SetGridColumnWidth(GrvSystemLog);

                this.Cursor = Cursors.Default;
                #endregion
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
            finally
            {
            }
        }

        private void GrvSystemLog_Click(object sender, EventArgs e)
        {
            int rowHandle;

            try
            {

                #region Validation
                if (ValidationUtility.Empty(this.Text, GrvSystemLog, "")) return;

                #endregion

                #region init
                MemSystemLogContent.Text = "";

                #endregion

                #region Fill Data
                rowHandle = GrvSystemLog.FocusedRowHandle;
                if (rowHandle == -1) return;

                MemSystemLogContent.Text = GrvSystemLog.GetRowCellValue(rowHandle, "내용").ToString();
                #endregion
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageboxHelper.Error(this.GetType().Name, MethodBase.GetCurrentMethod()?.Name, this.Text, ex.Message);
            }
            finally
            {
            }
        }

        #endregion

    }
}
namespace VolvocarsDMS
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.BtnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.TxtId = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.CboApiUrl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.TxtApiUrl = new DevExpress.XtraEditors.TextEdit();
            this.BtePassword = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboApiUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtApiUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLogin
            // 
            this.BtnLogin.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnLogin.Appearance.Options.UseFont = true;
            this.BtnLogin.Location = new System.Drawing.Point(22, 389);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(103, 39);
            this.BtnLogin.TabIndex = 4;
            this.BtnLogin.Text = "로그인";
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // TxtId
            // 
            this.TxtId.EditValue = "";
            this.TxtId.Location = new System.Drawing.Point(22, 151);
            this.TxtId.Name = "TxtId";
            this.TxtId.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtId.Properties.Appearance.Options.UseFont = true;
            this.TxtId.Properties.AutoHeight = false;
            this.TxtId.Size = new System.Drawing.Size(340, 45);
            this.TxtId.TabIndex = 0;
            this.TxtId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtId_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "VOLVOCARS DMS";
            // 
            // CboApiUrl
            // 
            this.CboApiUrl.Location = new System.Drawing.Point(22, 253);
            this.CboApiUrl.Name = "CboApiUrl";
            this.CboApiUrl.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CboApiUrl.Properties.Appearance.Options.UseFont = true;
            this.CboApiUrl.Properties.AutoHeight = false;
            this.CboApiUrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.CboApiUrl.Size = new System.Drawing.Size(340, 45);
            this.CboApiUrl.TabIndex = 2;
            this.CboApiUrl.SelectedIndexChanged += new System.EventHandler(this.CboApiUrl_SelectedIndexChanged);
            // 
            // TxtApiUrl
            // 
            this.TxtApiUrl.EditValue = "";
            this.TxtApiUrl.Location = new System.Drawing.Point(22, 304);
            this.TxtApiUrl.Name = "TxtApiUrl";
            this.TxtApiUrl.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtApiUrl.Properties.Appearance.Options.UseFont = true;
            this.TxtApiUrl.Properties.AutoHeight = false;
            this.TxtApiUrl.Size = new System.Drawing.Size(340, 45);
            this.TxtApiUrl.TabIndex = 3;
            this.TxtApiUrl.Visible = false;
            this.TxtApiUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtApiUrl_KeyDown);
            // 
            // BtePassword
            // 
            this.BtePassword.Location = new System.Drawing.Point(22, 202);
            this.BtePassword.Name = "BtePassword";
            this.BtePassword.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtePassword.Properties.Appearance.Options.UseFont = true;
            this.BtePassword.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.BtePassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.BtePassword.Size = new System.Drawing.Size(340, 45);
            this.BtePassword.TabIndex = 5;
            this.BtePassword.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BtePassword_ButtonClick);
            this.BtePassword.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.BtePassword_ButtonPressed);
            this.BtePassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtePassword_KeyDown);
            // 
            // FrmLogin
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 505);
            this.Controls.Add(this.BtePassword);
            this.Controls.Add(this.TxtApiUrl);
            this.Controls.Add(this.CboApiUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtId);
            this.Controls.Add(this.BtnLogin);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로그인";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmLogin_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.TxtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CboApiUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtApiUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtePassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnLogin;
        private DevExpress.XtraEditors.TextEdit TxtId;
        private Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit CboApiUrl;
        private DevExpress.XtraEditors.TextEdit TxtApiUrl;
        private DevExpress.XtraEditors.ButtonEdit BtePassword;
    }
}
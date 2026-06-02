namespace HospitalX.GUI.PH2.BacSi
{
    partial class frmPatientHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlBody = new Guna.UI2.WinForms.Guna2Panel();
            this.txtFamilyHistory = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFamilyTitle = new System.Windows.Forms.Label();
            this.txtMedicalHistory = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMedicalTitle = new System.Windows.Forms.Label();
            this.txtAllergy = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAllergyTitle = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = null;
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgDialog.Parent = this;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblCode);
            this.pnlHeader.Controls.Add(this.lblName);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1226, 135);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1177, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 5;
            // 
            // lblCode
            // 
            this.lblCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblCode.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCode.Location = new System.Drawing.Point(1040, 67);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(160, 34);
            this.lblCode.TabIndex = 2;
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(21, 64);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(182, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên bệnh nhân";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(89, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tiền sử bệnh";
            // 
            // pnlBody
            // 
            this.pnlBody.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlBody.BorderRadius = 12;
            this.pnlBody.BorderThickness = 1;
            this.pnlBody.Controls.Add(this.txtFamilyHistory);
            this.pnlBody.Controls.Add(this.lblFamilyTitle);
            this.pnlBody.Controls.Add(this.txtMedicalHistory);
            this.pnlBody.Controls.Add(this.lblMedicalTitle);
            this.pnlBody.Controls.Add(this.txtAllergy);
            this.pnlBody.Controls.Add(this.lblAllergyTitle);
            this.pnlBody.FillColor = System.Drawing.Color.White;
            this.pnlBody.Location = new System.Drawing.Point(28, 174);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1221, 558);
            this.pnlBody.TabIndex = 1;
            // 
            // txtFamilyHistory
            // 
            this.txtFamilyHistory.BackColor = System.Drawing.Color.Transparent;
            this.txtFamilyHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtFamilyHistory.BorderRadius = 8;
            this.txtFamilyHistory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFamilyHistory.DefaultText = "";
            this.txtFamilyHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtFamilyHistory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtFamilyHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFamilyHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtFamilyHistory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtFamilyHistory.Location = new System.Drawing.Point(38, 418);
            this.txtFamilyHistory.Multiline = true;
            this.txtFamilyHistory.Name = "txtFamilyHistory";
            this.txtFamilyHistory.PlaceholderText = "Tiền sử bệnh gia đình";
            this.txtFamilyHistory.SelectedText = "";
            this.txtFamilyHistory.Size = new System.Drawing.Size(1144, 104);
            this.txtFamilyHistory.TabIndex = 5;
            // 
            // lblFamilyTitle
            // 
            this.lblFamilyTitle.AutoSize = true;
            this.lblFamilyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFamilyTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFamilyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblFamilyTitle.Location = new System.Drawing.Point(38, 390);
            this.lblFamilyTitle.Name = "lblFamilyTitle";
            this.lblFamilyTitle.Size = new System.Drawing.Size(145, 15);
            this.lblFamilyTitle.TabIndex = 4;
            this.lblFamilyTitle.Text = "TIỀN SỬ BỆNH GIA ĐÌNH";
            // 
            // txtMedicalHistory
            // 
            this.txtMedicalHistory.BackColor = System.Drawing.Color.Transparent;
            this.txtMedicalHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtMedicalHistory.BorderRadius = 8;
            this.txtMedicalHistory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedicalHistory.DefaultText = "";
            this.txtMedicalHistory.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtMedicalHistory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMedicalHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtMedicalHistory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtMedicalHistory.Location = new System.Drawing.Point(38, 242);
            this.txtMedicalHistory.Multiline = true;
            this.txtMedicalHistory.Name = "txtMedicalHistory";
            this.txtMedicalHistory.PlaceholderText = "Tiền sử bệnh";
            this.txtMedicalHistory.SelectedText = "";
            this.txtMedicalHistory.Size = new System.Drawing.Size(1144, 120);
            this.txtMedicalHistory.TabIndex = 3;
            // 
            // lblMedicalTitle
            // 
            this.lblMedicalTitle.AutoSize = true;
            this.lblMedicalTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicalTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMedicalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblMedicalTitle.Location = new System.Drawing.Point(38, 214);
            this.lblMedicalTitle.Name = "lblMedicalTitle";
            this.lblMedicalTitle.Size = new System.Drawing.Size(87, 15);
            this.lblMedicalTitle.TabIndex = 2;
            this.lblMedicalTitle.Text = "TIỀN SỬ BỆNH";
            // 
            // txtAllergy
            // 
            this.txtAllergy.BackColor = System.Drawing.Color.Transparent;
            this.txtAllergy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtAllergy.BorderRadius = 8;
            this.txtAllergy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAllergy.DefaultText = "";
            this.txtAllergy.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtAllergy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtAllergy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAllergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtAllergy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtAllergy.Location = new System.Drawing.Point(38, 82);
            this.txtAllergy.Multiline = true;
            this.txtAllergy.Name = "txtAllergy";
            this.txtAllergy.PlaceholderText = "Dị ứng";
            this.txtAllergy.SelectedText = "";
            this.txtAllergy.Size = new System.Drawing.Size(1144, 104);
            this.txtAllergy.TabIndex = 1;
            // 
            // lblAllergyTitle
            // 
            this.lblAllergyTitle.AutoSize = true;
            this.lblAllergyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAllergyTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAllergyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblAllergyTitle.Location = new System.Drawing.Point(38, 54);
            this.lblAllergyTitle.Name = "lblAllergyTitle";
            this.lblAllergyTitle.Size = new System.Drawing.Size(50, 15);
            this.lblAllergyTitle.TabIndex = 0;
            this.lblAllergyTitle.Text = "DỊ ỨNG";
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.DefaultAutoSize = true;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnSave.Location = new System.Drawing.Point(1059, 773);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnSave.Size = new System.Drawing.Size(122, 31);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmPatientHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1277, 840);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPatientHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tiền sử bệnh";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBody;
        private Guna.UI2.WinForms.Guna2TextBox txtFamilyHistory;
        private System.Windows.Forms.Label lblFamilyTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMedicalHistory;
        private System.Windows.Forms.Label lblMedicalTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtAllergy;
        private System.Windows.Forms.Label lblAllergyTitle;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
    }
}

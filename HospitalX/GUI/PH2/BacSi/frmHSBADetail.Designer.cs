namespace HospitalX.GUI.PH2.BacSi
{
    partial class frmHSBADetail
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
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.lblPatientMeta = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblHsbaId = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfoTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlClinical = new Guna.UI2.WinForms.Guna2Panel();
            this.lblConclusion = new System.Windows.Forms.Label();
            this.txtConclusion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTreatment = new System.Windows.Forms.Label();
            this.txtTreatment = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblClinicalTitle = new System.Windows.Forms.Label();
            this.pnlLists = new Guna.UI2.WinForms.Guna2Panel();
            this.lstPrescriptions = new System.Windows.Forms.ListBox();
            this.lstServices = new System.Windows.Forms.ListBox();
            this.lblRxTitle = new System.Windows.Forms.Label();
            this.lblServiceTitle = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlClinical.SuspendLayout();
            this.pnlLists.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblPatientMeta);
            this.pnlHeader.Controls.Add(this.lblPatientName);
            this.pnlHeader.Controls.Add(this.lblHsbaId);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.pnlHeader.Location = new System.Drawing.Point(18, 16);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(844, 116);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 8;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.Location = new System.Drawing.Point(790, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(48)))), ((int)(((byte)(36)))));
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblPatientMeta
            // 
            this.lblPatientMeta.AutoSize = true;
            this.lblPatientMeta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPatientMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblPatientMeta.Location = new System.Drawing.Point(26, 84);
            this.lblPatientMeta.Name = "lblPatientMeta";
            this.lblPatientMeta.Size = new System.Drawing.Size(191, 17);
            this.lblPatientMeta.TabIndex = 3;
            this.lblPatientMeta.Text = "BN-00000 · Nam, 00 tuổi · Khoa";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.ForeColor = System.Drawing.Color.White;
            this.lblPatientName.Location = new System.Drawing.Point(24, 51);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(170, 30);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "Tên bệnh nhân";
            // 
            // lblHsbaId
            // 
            this.lblHsbaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblHsbaId.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHsbaId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblHsbaId.Location = new System.Drawing.Point(680, 66);
            this.lblHsbaId.Name = "lblHsbaId";
            this.lblHsbaId.Size = new System.Drawing.Size(124, 28);
            this.lblHsbaId.TabIndex = 1;
            this.lblHsbaId.Text = "HSBA-0000";
            this.lblHsbaId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblTitle.Location = new System.Drawing.Point(26, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết bệnh án";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlInfo.BorderRadius = 10;
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.Controls.Add(this.lblInfo);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(18, 148);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(265, 402);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.AutoSize = true;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(18, 18);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(146, 20);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "Thông tin bệnh nhân";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lblInfo.Location = new System.Drawing.Point(19, 54);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(226, 318);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Thông tin";
            // 
            // pnlClinical
            // 
            this.pnlClinical.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlClinical.BorderRadius = 10;
            this.pnlClinical.BorderThickness = 1;
            this.pnlClinical.Controls.Add(this.lblConclusion);
            this.pnlClinical.Controls.Add(this.txtConclusion);
            this.pnlClinical.Controls.Add(this.lblTreatment);
            this.pnlClinical.Controls.Add(this.txtTreatment);
            this.pnlClinical.Controls.Add(this.lblDiagnosis);
            this.pnlClinical.Controls.Add(this.txtDiagnosis);
            this.pnlClinical.Controls.Add(this.lblClinicalTitle);
            this.pnlClinical.FillColor = System.Drawing.Color.White;
            this.pnlClinical.Location = new System.Drawing.Point(299, 148);
            this.pnlClinical.Name = "pnlClinical";
            this.pnlClinical.Size = new System.Drawing.Size(563, 402);
            this.pnlClinical.TabIndex = 2;
            // 
            // lblConclusion
            // 
            this.lblConclusion.AutoSize = true;
            this.lblConclusion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblConclusion.Location = new System.Drawing.Point(22, 272);
            this.lblConclusion.Name = "lblConclusion";
            this.lblConclusion.Size = new System.Drawing.Size(56, 15);
            this.lblConclusion.TabIndex = 6;
            this.lblConclusion.Text = "KẾT LUẬN";
            // 
            // txtConclusion
            // 
            this.txtConclusion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtConclusion.BorderRadius = 8;
            this.txtConclusion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConclusion.DefaultText = "";
            this.txtConclusion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtConclusion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtConclusion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtConclusion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtConclusion.Location = new System.Drawing.Point(22, 292);
            this.txtConclusion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.PlaceholderText = "Nhập kết luận...";
            this.txtConclusion.SelectedText = "";
            this.txtConclusion.Size = new System.Drawing.Size(518, 82);
            this.txtConclusion.TabIndex = 5;
            // 
            // lblTreatment
            // 
            this.lblTreatment.AutoSize = true;
            this.lblTreatment.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTreatment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTreatment.Location = new System.Drawing.Point(22, 160);
            this.lblTreatment.Name = "lblTreatment";
            this.lblTreatment.Size = new System.Drawing.Size(55, 15);
            this.lblTreatment.TabIndex = 4;
            this.lblTreatment.Text = "ĐIỀU TRỊ";
            // 
            // txtTreatment
            // 
            this.txtTreatment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtTreatment.BorderRadius = 8;
            this.txtTreatment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTreatment.DefaultText = "";
            this.txtTreatment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtTreatment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtTreatment.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTreatment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtTreatment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtTreatment.Location = new System.Drawing.Point(22, 180);
            this.txtTreatment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.PlaceholderText = "Nhập điều trị...";
            this.txtTreatment.SelectedText = "";
            this.txtTreatment.Size = new System.Drawing.Size(518, 82);
            this.txtTreatment.TabIndex = 3;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(22, 49);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(74, 15);
            this.lblDiagnosis.TabIndex = 2;
            this.lblDiagnosis.Text = "CHẨN ĐOÁN";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDiagnosis.BorderRadius = 8;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtDiagnosis.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtDiagnosis.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtDiagnosis.Location = new System.Drawing.Point(22, 69);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PlaceholderText = "Nhập chẩn đoán...";
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.Size = new System.Drawing.Size(518, 82);
            this.txtDiagnosis.TabIndex = 1;
            // 
            // lblClinicalTitle
            // 
            this.lblClinicalTitle.AutoSize = true;
            this.lblClinicalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblClinicalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblClinicalTitle.Location = new System.Drawing.Point(18, 18);
            this.lblClinicalTitle.Name = "lblClinicalTitle";
            this.lblClinicalTitle.Size = new System.Drawing.Size(151, 20);
            this.lblClinicalTitle.TabIndex = 0;
            this.lblClinicalTitle.Text = "Chẩn đoán & điều trị";
            // 
            // pnlLists
            // 
            this.pnlLists.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlLists.BorderRadius = 10;
            this.pnlLists.BorderThickness = 1;
            this.pnlLists.Controls.Add(this.lstPrescriptions);
            this.pnlLists.Controls.Add(this.lstServices);
            this.pnlLists.Controls.Add(this.lblRxTitle);
            this.pnlLists.Controls.Add(this.lblServiceTitle);
            this.pnlLists.FillColor = System.Drawing.Color.White;
            this.pnlLists.Location = new System.Drawing.Point(18, 566);
            this.pnlLists.Name = "pnlLists";
            this.pnlLists.Size = new System.Drawing.Size(704, 146);
            this.pnlLists.TabIndex = 3;
            // 
            // lstPrescriptions
            // 
            this.lstPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPrescriptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstPrescriptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstPrescriptions.FormattingEnabled = true;
            this.lstPrescriptions.ItemHeight = 15;
            this.lstPrescriptions.Location = new System.Drawing.Point(364, 45);
            this.lstPrescriptions.Name = "lstPrescriptions";
            this.lstPrescriptions.Size = new System.Drawing.Size(318, 75);
            this.lstPrescriptions.TabIndex = 3;
            // 
            // lstServices
            // 
            this.lstServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstServices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstServices.FormattingEnabled = true;
            this.lstServices.ItemHeight = 15;
            this.lstServices.Location = new System.Drawing.Point(22, 45);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(318, 75);
            this.lstServices.TabIndex = 2;
            // 
            // lblRxTitle
            // 
            this.lblRxTitle.AutoSize = true;
            this.lblRxTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblRxTitle.Location = new System.Drawing.Point(361, 18);
            this.lblRxTitle.Name = "lblRxTitle";
            this.lblRxTitle.Size = new System.Drawing.Size(98, 19);
            this.lblRxTitle.TabIndex = 1;
            this.lblRxTitle.Text = "Đơn hiện tại";
            // 
            // lblServiceTitle
            // 
            this.lblServiceTitle.AutoSize = true;
            this.lblServiceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblServiceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblServiceTitle.Location = new System.Drawing.Point(19, 18);
            this.lblServiceTitle.Name = "lblServiceTitle";
            this.lblServiceTitle.Size = new System.Drawing.Size(102, 19);
            this.lblServiceTitle.TabIndex = 0;
            this.lblServiceTitle.Text = "Dịch vụ đã làm";
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 8;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(208)))), ((int)(((byte)(203)))));
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnSave.Location = new System.Drawing.Point(739, 606);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnSave.Size = new System.Drawing.Size(123, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmHSBADetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(880, 730);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnlLists);
            this.Controls.Add(this.pnlClinical);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHSBADetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết HSBA";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.pnlClinical.ResumeLayout(false);
            this.pnlClinical.PerformLayout();
            this.pnlLists.ResumeLayout(false);
            this.pnlLists.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHsbaId;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientMeta;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlClinical;
        private System.Windows.Forms.Label lblClinicalTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblDiagnosis;
        private System.Windows.Forms.Label lblTreatment;
        private Guna.UI2.WinForms.Guna2TextBox txtTreatment;
        private System.Windows.Forms.Label lblConclusion;
        private Guna.UI2.WinForms.Guna2TextBox txtConclusion;
        private Guna.UI2.WinForms.Guna2Panel pnlLists;
        private System.Windows.Forms.Label lblServiceTitle;
        private System.Windows.Forms.Label lblRxTitle;
        private System.Windows.Forms.ListBox lstServices;
        private System.Windows.Forms.ListBox lstPrescriptions;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}

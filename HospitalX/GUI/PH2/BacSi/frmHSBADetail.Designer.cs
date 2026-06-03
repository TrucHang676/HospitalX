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
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblPatientMeta = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblHsbaId = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHistoryValue = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.lblAllergyValue = new System.Windows.Forms.Label();
            this.lblAllergyTitle = new System.Windows.Forms.Label();
            this.lblCreatedValue = new System.Windows.Forms.Label();
            this.lblCreatedTitle = new System.Windows.Forms.Label();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblAddressTitle = new System.Windows.Forms.Label();
            this.lblCccdValue = new System.Windows.Forms.Label();
            this.lblCccdTitle = new System.Windows.Forms.Label();
            this.lblBirthValue = new System.Windows.Forms.Label();
            this.lblBirthTitle = new System.Windows.Forms.Label();
            this.lblInfoTitle = new System.Windows.Forms.Label();
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
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = "HospitalX";
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgDialog.Parent = this;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
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
            this.btnClose.Location = new System.Drawing.Point(1172, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 4;
            // 
            // lblPatientMeta
            // 
            this.lblPatientMeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblPatientMeta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPatientMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblPatientMeta.Location = new System.Drawing.Point(32, 88);
            this.lblPatientMeta.Name = "lblPatientMeta";
            this.lblPatientMeta.Size = new System.Drawing.Size(690, 24);
            this.lblPatientMeta.TabIndex = 3;
            this.lblPatientMeta.Text = "BN-00000 · Nam, 00 tuổi · Khoa";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.ForeColor = System.Drawing.Color.White;
            this.lblPatientName.Location = new System.Drawing.Point(30, 44);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(164, 30);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "Tên bệnh nhân";
            // 
            // lblHsbaId
            // 
            this.lblHsbaId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblHsbaId.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHsbaId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblHsbaId.Location = new System.Drawing.Point(1074, 80);
            this.lblHsbaId.Name = "lblHsbaId";
            this.lblHsbaId.Size = new System.Drawing.Size(124, 28);
            this.lblHsbaId.TabIndex = 1;
            this.lblHsbaId.Text = "HSBA-0000";
            this.lblHsbaId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblTitle.Location = new System.Drawing.Point(32, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết bệnh án";
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlInfo.BorderRadius = 10;
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.Controls.Add(this.lblHistoryValue);
            this.pnlInfo.Controls.Add(this.lblHistoryTitle);
            this.pnlInfo.Controls.Add(this.lblAllergyValue);
            this.pnlInfo.Controls.Add(this.lblAllergyTitle);
            this.pnlInfo.Controls.Add(this.lblCreatedValue);
            this.pnlInfo.Controls.Add(this.lblCreatedTitle);
            this.pnlInfo.Controls.Add(this.lblAddressValue);
            this.pnlInfo.Controls.Add(this.lblAddressTitle);
            this.pnlInfo.Controls.Add(this.lblCccdValue);
            this.pnlInfo.Controls.Add(this.lblCccdTitle);
            this.pnlInfo.Controls.Add(this.lblBirthValue);
            this.pnlInfo.Controls.Add(this.lblBirthTitle);
            this.pnlInfo.Controls.Add(this.lblInfoTitle);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(24, 183);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(516, 438);
            this.pnlInfo.TabIndex = 1;
            // 
            // lblHistoryValue
            // 
            this.lblHistoryValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblHistoryValue.Font = new System.Drawing.Font("Segoe UI", 9.3F);
            this.lblHistoryValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lblHistoryValue.Location = new System.Drawing.Point(24, 342);
            this.lblHistoryValue.Name = "lblHistoryValue";
            this.lblHistoryValue.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.lblHistoryValue.Size = new System.Drawing.Size(457, 65);
            this.lblHistoryValue.TabIndex = 12;
            this.lblHistoryValue.Text = "Tăng huyết áp từ năm 2018. Không hút thuốc lá.";
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.BackColor = System.Drawing.Color.White;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(24, 316);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(87, 15);
            this.lblHistoryTitle.TabIndex = 11;
            this.lblHistoryTitle.Text = "TIỀN SỬ BỆNH";
            // 
            // lblAllergyValue
            // 
            this.lblAllergyValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblAllergyValue.Font = new System.Drawing.Font("Segoe UI", 9.3F);
            this.lblAllergyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lblAllergyValue.Location = new System.Drawing.Point(24, 250);
            this.lblAllergyValue.Name = "lblAllergyValue";
            this.lblAllergyValue.Padding = new System.Windows.Forms.Padding(10, 5, 10, 0);
            this.lblAllergyValue.Size = new System.Drawing.Size(457, 50);
            this.lblAllergyValue.TabIndex = 10;
            this.lblAllergyValue.Text = "Không có dị ứng thuốc ghi nhận";
            // 
            // lblAllergyTitle
            // 
            this.lblAllergyTitle.AutoSize = true;
            this.lblAllergyTitle.BackColor = System.Drawing.Color.White;
            this.lblAllergyTitle.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblAllergyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblAllergyTitle.Location = new System.Drawing.Point(24, 220);
            this.lblAllergyTitle.Name = "lblAllergyTitle";
            this.lblAllergyTitle.Size = new System.Drawing.Size(50, 15);
            this.lblAllergyTitle.TabIndex = 9;
            this.lblAllergyTitle.Text = "DỊ ỨNG";
            // 
            // lblCreatedValue
            // 
            this.lblCreatedValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblCreatedValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCreatedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblCreatedValue.Location = new System.Drawing.Point(305, 160);
            this.lblCreatedValue.Name = "lblCreatedValue";
            this.lblCreatedValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCreatedValue.Size = new System.Drawing.Size(176, 32);
            this.lblCreatedValue.TabIndex = 8;
            this.lblCreatedValue.Text = "21/05/2026";
            this.lblCreatedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreatedTitle
            // 
            this.lblCreatedTitle.AutoSize = true;
            this.lblCreatedTitle.BackColor = System.Drawing.Color.White;
            this.lblCreatedTitle.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblCreatedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblCreatedTitle.Location = new System.Drawing.Point(305, 133);
            this.lblCreatedTitle.Name = "lblCreatedTitle";
            this.lblCreatedTitle.Size = new System.Drawing.Size(98, 15);
            this.lblCreatedTitle.TabIndex = 7;
            this.lblCreatedTitle.Text = "NGÀY LẬP HSBA";
            // 
            // lblAddressValue
            // 
            this.lblAddressValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblAddressValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblAddressValue.Location = new System.Drawing.Point(24, 160);
            this.lblAddressValue.Name = "lblAddressValue";
            this.lblAddressValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblAddressValue.Size = new System.Drawing.Size(236, 32);
            this.lblAddressValue.TabIndex = 6;
            this.lblAddressValue.Text = "Q.1, TP.HCM";
            this.lblAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddressTitle
            // 
            this.lblAddressTitle.AutoSize = true;
            this.lblAddressTitle.BackColor = System.Drawing.Color.White;
            this.lblAddressTitle.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblAddressTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblAddressTitle.Location = new System.Drawing.Point(24, 133);
            this.lblAddressTitle.Name = "lblAddressTitle";
            this.lblAddressTitle.Size = new System.Drawing.Size(51, 15);
            this.lblAddressTitle.TabIndex = 5;
            this.lblAddressTitle.Text = "ĐỊA CHỈ";
            // 
            // lblCccdValue
            // 
            this.lblCccdValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblCccdValue.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCccdValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblCccdValue.Location = new System.Drawing.Point(305, 79);
            this.lblCccdValue.Name = "lblCccdValue";
            this.lblCccdValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblCccdValue.Size = new System.Drawing.Size(176, 32);
            this.lblCccdValue.TabIndex = 4;
            this.lblCccdValue.Text = "079074012345";
            this.lblCccdValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCccdTitle
            // 
            this.lblCccdTitle.AutoSize = true;
            this.lblCccdTitle.BackColor = System.Drawing.Color.White;
            this.lblCccdTitle.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblCccdTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblCccdTitle.Location = new System.Drawing.Point(305, 54);
            this.lblCccdTitle.Name = "lblCccdTitle";
            this.lblCccdTitle.Size = new System.Drawing.Size(37, 15);
            this.lblCccdTitle.TabIndex = 3;
            this.lblCccdTitle.Text = "CCCD";
            // 
            // lblBirthValue
            // 
            this.lblBirthValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblBirthValue.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBirthValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblBirthValue.Location = new System.Drawing.Point(24, 79);
            this.lblBirthValue.Name = "lblBirthValue";
            this.lblBirthValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblBirthValue.Size = new System.Drawing.Size(170, 32);
            this.lblBirthValue.TabIndex = 2;
            this.lblBirthValue.Text = "15/03/1974";
            this.lblBirthValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBirthTitle
            // 
            this.lblBirthTitle.AutoSize = true;
            this.lblBirthTitle.BackColor = System.Drawing.Color.White;
            this.lblBirthTitle.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblBirthTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblBirthTitle.Location = new System.Drawing.Point(24, 54);
            this.lblBirthTitle.Name = "lblBirthTitle";
            this.lblBirthTitle.Size = new System.Drawing.Size(71, 15);
            this.lblBirthTitle.TabIndex = 1;
            this.lblBirthTitle.Text = "NGÀY SINH";
            // 
            // lblInfoTitle
            // 
            this.lblInfoTitle.BackColor = System.Drawing.Color.White;
            this.lblInfoTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblInfoTitle.Location = new System.Drawing.Point(22, 20);
            this.lblInfoTitle.Name = "lblInfoTitle";
            this.lblInfoTitle.Size = new System.Drawing.Size(270, 26);
            this.lblInfoTitle.TabIndex = 0;
            this.lblInfoTitle.Text = "Thông tin bệnh nhân";
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
            this.pnlClinical.Location = new System.Drawing.Point(560, 183);
            this.pnlClinical.Name = "pnlClinical";
            this.pnlClinical.Size = new System.Drawing.Size(690, 438);
            this.pnlClinical.TabIndex = 2;
            // 
            // lblConclusion
            // 
            this.lblConclusion.AutoSize = true;
            this.lblConclusion.BackColor = System.Drawing.Color.White;
            this.lblConclusion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblConclusion.Location = new System.Drawing.Point(30, 302);
            this.lblConclusion.Name = "lblConclusion";
            this.lblConclusion.Size = new System.Drawing.Size(63, 15);
            this.lblConclusion.TabIndex = 6;
            this.lblConclusion.Text = "KẾT LUẬN";
            // 
            // txtConclusion
            // 
            this.txtConclusion.BackColor = System.Drawing.Color.Transparent;
            this.txtConclusion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtConclusion.BorderRadius = 8;
            this.txtConclusion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConclusion.DefaultText = "";
            this.txtConclusion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtConclusion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtConclusion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtConclusion.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtConclusion.Location = new System.Drawing.Point(33, 327);
            this.txtConclusion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.PlaceholderText = "Nhập kết luận...";
            this.txtConclusion.SelectedText = "";
            this.txtConclusion.Size = new System.Drawing.Size(629, 76);
            this.txtConclusion.TabIndex = 5;
            // 
            // lblTreatment
            // 
            this.lblTreatment.AutoSize = true;
            this.lblTreatment.BackColor = System.Drawing.Color.White;
            this.lblTreatment.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTreatment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTreatment.Location = new System.Drawing.Point(30, 177);
            this.lblTreatment.Name = "lblTreatment";
            this.lblTreatment.Size = new System.Drawing.Size(57, 15);
            this.lblTreatment.TabIndex = 4;
            this.lblTreatment.Text = "ĐIỀU TRỊ";
            // 
            // txtTreatment
            // 
            this.txtTreatment.BackColor = System.Drawing.Color.Transparent;
            this.txtTreatment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtTreatment.BorderRadius = 8;
            this.txtTreatment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTreatment.DefaultText = "";
            this.txtTreatment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtTreatment.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtTreatment.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTreatment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtTreatment.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtTreatment.Location = new System.Drawing.Point(33, 202);
            this.txtTreatment.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.PlaceholderText = "Nhập điều trị...";
            this.txtTreatment.SelectedText = "";
            this.txtTreatment.Size = new System.Drawing.Size(629, 76);
            this.txtTreatment.TabIndex = 3;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.BackColor = System.Drawing.Color.White;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(30, 54);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(78, 15);
            this.lblDiagnosis.TabIndex = 2;
            this.lblDiagnosis.Text = "CHẨN ĐOÁN";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.BackColor = System.Drawing.Color.Transparent;
            this.txtDiagnosis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDiagnosis.BorderRadius = 8;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtDiagnosis.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtDiagnosis.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtDiagnosis.Location = new System.Drawing.Point(33, 79);
            this.txtDiagnosis.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDiagnosis.Multiline = true;
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PlaceholderText = "Nhập chẩn đoán...";
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.Size = new System.Drawing.Size(629, 76);
            this.txtDiagnosis.TabIndex = 1;
            // 
            // lblClinicalTitle
            // 
            this.lblClinicalTitle.AutoSize = true;
            this.lblClinicalTitle.BackColor = System.Drawing.Color.White;
            this.lblClinicalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblClinicalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblClinicalTitle.Location = new System.Drawing.Point(29, 20);
            this.lblClinicalTitle.Name = "lblClinicalTitle";
            this.lblClinicalTitle.Size = new System.Drawing.Size(141, 20);
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
            this.pnlLists.Location = new System.Drawing.Point(24, 653);
            this.pnlLists.Name = "pnlLists";
            this.pnlLists.Size = new System.Drawing.Size(826, 146);
            this.pnlLists.TabIndex = 3;
            // 
            // lstPrescriptions
            // 
            this.lstPrescriptions.BackColor = System.Drawing.Color.White;
            this.lstPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstPrescriptions.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstPrescriptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstPrescriptions.FormattingEnabled = true;
            this.lstPrescriptions.ItemHeight = 15;
            this.lstPrescriptions.Location = new System.Drawing.Point(430, 48);
            this.lstPrescriptions.Name = "lstPrescriptions";
            this.lstPrescriptions.Size = new System.Drawing.Size(370, 75);
            this.lstPrescriptions.TabIndex = 3;
            // 
            // lstServices
            // 
            this.lstServices.BackColor = System.Drawing.Color.White;
            this.lstServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstServices.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.lstServices.FormattingEnabled = true;
            this.lstServices.ItemHeight = 15;
            this.lstServices.Location = new System.Drawing.Point(24, 48);
            this.lstServices.Name = "lstServices";
            this.lstServices.Size = new System.Drawing.Size(370, 75);
            this.lstServices.TabIndex = 2;
            // 
            // lblRxTitle
            // 
            this.lblRxTitle.AutoSize = true;
            this.lblRxTitle.BackColor = System.Drawing.Color.White;
            this.lblRxTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblRxTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblRxTitle.Location = new System.Drawing.Point(427, 18);
            this.lblRxTitle.Name = "lblRxTitle";
            this.lblRxTitle.Size = new System.Drawing.Size(89, 19);
            this.lblRxTitle.TabIndex = 1;
            this.lblRxTitle.Text = "Đơn hiện tại";
            // 
            // lblServiceTitle
            // 
            this.lblServiceTitle.AutoSize = true;
            this.lblServiceTitle.BackColor = System.Drawing.Color.White;
            this.lblServiceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblServiceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblServiceTitle.Location = new System.Drawing.Point(19, 18);
            this.lblServiceTitle.Name = "lblServiceTitle";
            this.lblServiceTitle.Size = new System.Drawing.Size(108, 19);
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnSave.Location = new System.Drawing.Point(944, 701);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnSave.Size = new System.Drawing.Size(202, 46);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmHSBADetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1277, 840);
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
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHsbaId;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientMeta;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblBirthTitle;
        private System.Windows.Forms.Label lblBirthValue;
        private System.Windows.Forms.Label lblCccdTitle;
        private System.Windows.Forms.Label lblCccdValue;
        private System.Windows.Forms.Label lblAddressTitle;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblCreatedTitle;
        private System.Windows.Forms.Label lblCreatedValue;
        private System.Windows.Forms.Label lblAllergyTitle;
        private System.Windows.Forms.Label lblAllergyValue;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Label lblHistoryValue;
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

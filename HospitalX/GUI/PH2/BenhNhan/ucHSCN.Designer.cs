namespace HospitalX.GUI.PH2.BenhNhan
{
    partial class ucHSCN
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlHistory = new Guna.UI2.WinForms.Guna2Panel();
            this.txtFamilyHistory = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtMedicalHistory = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAllergy = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFamilyHistoryCaption = new System.Windows.Forms.Label();
            this.lblMedicalHistoryCaption = new System.Windows.Forms.Label();
            this.lblAllergyCaption = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlProfile = new Guna.UI2.WinForms.Guna2Panel();
            this.txtAddressField = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCccdField = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtDobField = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtGenderField = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPatientName = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPatientId = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddressCaption = new System.Windows.Forms.Label();
            this.lblCccdCaption = new System.Windows.Forms.Label();
            this.lblDobCaption = new System.Windows.Forms.Label();
            this.lblGenderCaption = new System.Windows.Forms.Label();
            this.lblPatientNameCaption = new System.Windows.Forms.Label();
            this.lblPatientIdCaption = new System.Windows.Forms.Label();
            this.lblProfileTitle = new System.Windows.Forms.Label();
            this.pnlKpiPrescription = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiPrescriptionSub = new System.Windows.Forms.Label();
            this.lblKpiPrescriptionTitle = new System.Windows.Forms.Label();
            this.lblKpiPrescriptionValue = new System.Windows.Forms.Label();
            this.pnlKpiService = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiServiceSub = new System.Windows.Forms.Label();
            this.lblKpiServiceTitle = new System.Windows.Forms.Label();
            this.lblKpiServiceValue = new System.Windows.Forms.Label();
            this.pnlKpiHsba = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiHsbaSub = new System.Windows.Forms.Label();
            this.lblKpiHsbaTitle = new System.Windows.Forms.Label();
            this.lblKpiHsbaValue = new System.Windows.Forms.Label();
            this.pnlKpiAllergy = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiAllergySub = new System.Windows.Forms.Label();
            this.lblKpiAllergyTitle = new System.Windows.Forms.Label();
            this.lblKpiAllergyValue = new System.Windows.Forms.Label();
            this.pnlWelcome = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSaveProfile = new Guna.UI2.WinForms.Guna2Button();
            this.lblWelcomeMeta = new System.Windows.Forms.Label();
            this.lblWelcomeName = new System.Windows.Forms.Label();
            this.lblWelcomeId = new System.Windows.Forms.Label();
            this.pnlRoot.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlKpiPrescription.SuspendLayout();
            this.pnlKpiService.SuspendLayout();
            this.pnlKpiHsba.SuspendLayout();
            this.pnlKpiAllergy.SuspendLayout();
            this.pnlWelcome.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlRoot
            //
            this.pnlRoot.AutoScroll = true;
            this.pnlRoot.Controls.Add(this.btnSaveProfile);
            this.pnlRoot.Controls.Add(this.pnlHistory);
            this.pnlRoot.Controls.Add(this.pnlProfile);
            this.pnlRoot.Controls.Add(this.pnlKpiPrescription);
            this.pnlRoot.Controls.Add(this.pnlKpiService);
            this.pnlRoot.Controls.Add(this.pnlKpiHsba);
            this.pnlRoot.Controls.Add(this.pnlKpiAllergy);
            this.pnlRoot.Controls.Add(this.pnlWelcome);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(24, 20, 24, 24);
            this.pnlRoot.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.TabIndex = 0;
            //
            // pnlHistory
            //
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlHistory.BorderRadius = 8;
            this.pnlHistory.BorderThickness = 1;
            this.pnlHistory.Controls.Add(this.txtFamilyHistory);
            this.pnlHistory.Controls.Add(this.txtMedicalHistory);
            this.pnlHistory.Controls.Add(this.txtAllergy);
            this.pnlHistory.Controls.Add(this.lblFamilyHistoryCaption);
            this.pnlHistory.Controls.Add(this.lblMedicalHistoryCaption);
            this.pnlHistory.Controls.Add(this.lblAllergyCaption);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.FillColor = System.Drawing.Color.White;
            this.pnlHistory.Location = new System.Drawing.Point(520, 288);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(560, 406);
            this.pnlHistory.TabIndex = 6;
            //
            // txtFamilyHistory
            //
            this.txtFamilyHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFamilyHistory.BackColor = System.Drawing.Color.Transparent;
            this.txtFamilyHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtFamilyHistory.BorderRadius = 8;
            this.txtFamilyHistory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFamilyHistory.FillColor = System.Drawing.Color.White;
            this.txtFamilyHistory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtFamilyHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtFamilyHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtFamilyHistory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtFamilyHistory.Location = new System.Drawing.Point(20, 315);
            this.txtFamilyHistory.Multiline = true;
            this.txtFamilyHistory.Name = "txtFamilyHistory";
            this.txtFamilyHistory.PlaceholderText = "";
            this.txtFamilyHistory.ReadOnly = false;
            this.txtFamilyHistory.SelectedText = "";
            this.txtFamilyHistory.Size = new System.Drawing.Size(508, 64);
            this.txtFamilyHistory.TabIndex = 9;
            this.txtFamilyHistory.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // txtMedicalHistory
            //
            this.txtMedicalHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMedicalHistory.BackColor = System.Drawing.Color.Transparent;
            this.txtMedicalHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtMedicalHistory.BorderRadius = 8;
            this.txtMedicalHistory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedicalHistory.FillColor = System.Drawing.Color.White;
            this.txtMedicalHistory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtMedicalHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtMedicalHistory.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMedicalHistory.Location = new System.Drawing.Point(20, 204);
            this.txtMedicalHistory.Multiline = true;
            this.txtMedicalHistory.Name = "txtMedicalHistory";
            this.txtMedicalHistory.PlaceholderText = "";
            this.txtMedicalHistory.ReadOnly = false;
            this.txtMedicalHistory.SelectedText = "";
            this.txtMedicalHistory.Size = new System.Drawing.Size(508, 62);
            this.txtMedicalHistory.TabIndex = 8;
            this.txtMedicalHistory.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // txtAllergy
            //
            this.txtAllergy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAllergy.BackColor = System.Drawing.Color.Transparent;
            this.txtAllergy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtAllergy.BorderRadius = 8;
            this.txtAllergy.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAllergy.FillColor = System.Drawing.Color.White;
            this.txtAllergy.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtAllergy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAllergy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtAllergy.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtAllergy.Location = new System.Drawing.Point(20, 90);
            this.txtAllergy.Multiline = true;
            this.txtAllergy.Name = "txtAllergy";
            this.txtAllergy.PlaceholderText = "";
            this.txtAllergy.ReadOnly = false;
            this.txtAllergy.SelectedText = "";
            this.txtAllergy.Size = new System.Drawing.Size(508, 63);
            this.txtAllergy.TabIndex = 7;
            this.txtAllergy.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblFamilyHistoryCaption
            //
            this.lblFamilyHistoryCaption.AutoSize = true;
            this.lblFamilyHistoryCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblFamilyHistoryCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFamilyHistoryCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblFamilyHistoryCaption.Location = new System.Drawing.Point(22, 288);
            this.lblFamilyHistoryCaption.Name = "lblFamilyHistoryCaption";
            this.lblFamilyHistoryCaption.Size = new System.Drawing.Size(110, 15);
            this.lblFamilyHistoryCaption.TabIndex = 5;
            this.lblFamilyHistoryCaption.Text = "TIỀN SỬ GIA ĐÌNH";
            //
            // lblMedicalHistoryCaption
            //
            this.lblMedicalHistoryCaption.AutoSize = true;
            this.lblMedicalHistoryCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicalHistoryCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMedicalHistoryCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblMedicalHistoryCaption.Location = new System.Drawing.Point(22, 177);
            this.lblMedicalHistoryCaption.Name = "lblMedicalHistoryCaption";
            this.lblMedicalHistoryCaption.Size = new System.Drawing.Size(87, 15);
            this.lblMedicalHistoryCaption.TabIndex = 3;
            this.lblMedicalHistoryCaption.Text = "TIỀN SỬ BỆNH";
            //
            // lblAllergyCaption
            //
            this.lblAllergyCaption.AutoSize = true;
            this.lblAllergyCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblAllergyCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAllergyCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblAllergyCaption.Location = new System.Drawing.Point(22, 63);
            this.lblAllergyCaption.Name = "lblAllergyCaption";
            this.lblAllergyCaption.Size = new System.Drawing.Size(94, 15);
            this.lblAllergyCaption.TabIndex = 1;
            this.lblAllergyCaption.Text = "DỊ ỨNG THUỐC";
            //
            // lblHistoryTitle
            //
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(20, 13);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(81, 28);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "Tiền sử";
            //
            // pnlProfile
            //
            this.pnlProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlProfile.BorderRadius = 8;
            this.pnlProfile.BorderThickness = 1;
            this.pnlProfile.Controls.Add(this.txtAddressField);
            this.pnlProfile.Controls.Add(this.lblAddressCaption);
            this.pnlProfile.Controls.Add(this.txtCccdField);
            this.pnlProfile.Controls.Add(this.lblCccdCaption);
            this.pnlProfile.Controls.Add(this.txtDobField);
            this.pnlProfile.Controls.Add(this.lblDobCaption);
            this.pnlProfile.Controls.Add(this.txtGenderField);
            this.pnlProfile.Controls.Add(this.lblGenderCaption);
            this.pnlProfile.Controls.Add(this.txtPatientName);
            this.pnlProfile.Controls.Add(this.lblPatientNameCaption);
            this.pnlProfile.Controls.Add(this.txtPatientId);
            this.pnlProfile.Controls.Add(this.lblPatientIdCaption);
            this.pnlProfile.Controls.Add(this.lblProfileTitle);
            this.pnlProfile.FillColor = System.Drawing.Color.White;
            this.pnlProfile.Location = new System.Drawing.Point(24, 288);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Size = new System.Drawing.Size(472, 406);
            this.pnlProfile.TabIndex = 5;
            //
            // txtAddressField
            //
            this.txtAddressField.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtAddressField.BorderRadius = 8;
            this.txtAddressField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressField.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtAddressField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtAddressField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtAddressField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtAddressField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtAddressField.Location = new System.Drawing.Point(215, 310);
            this.txtAddressField.Name = "txtAddressField";
            this.txtAddressField.PlaceholderText = "Số nhà, Tên đường, Quận/Huyện, Tỉnh/TP";
            this.txtAddressField.SelectedText = "";
            this.txtAddressField.Size = new System.Drawing.Size(236, 34);
            this.txtAddressField.TabIndex = 12;
            this.txtAddressField.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblAddressCaption
            //
            this.lblAddressCaption.AutoSize = true;
            this.lblAddressCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblAddressCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAddressCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblAddressCaption.Location = new System.Drawing.Point(216, 288);
            this.lblAddressCaption.Name = "lblAddressCaption";
            this.lblAddressCaption.Size = new System.Drawing.Size(51, 15);
            this.lblAddressCaption.TabIndex = 11;
            this.lblAddressCaption.Text = "ĐỊA CHỈ";
            //
            // txtCccdField
            //
            this.txtCccdField.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtCccdField.BorderRadius = 8;
            this.txtCccdField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCccdField.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtCccdField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtCccdField.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtCccdField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.txtCccdField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtCccdField.Location = new System.Drawing.Point(22, 310);
            this.txtCccdField.Name = "txtCccdField";
            this.txtCccdField.PlaceholderText = "";
            this.txtCccdField.SelectedText = "";
            this.txtCccdField.Size = new System.Drawing.Size(172, 34);
            this.txtCccdField.TabIndex = 10;
            this.txtCccdField.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblCccdCaption
            //
            this.lblCccdCaption.AutoSize = true;
            this.lblCccdCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCccdCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCccdCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblCccdCaption.Location = new System.Drawing.Point(22, 288);
            this.lblCccdCaption.Name = "lblCccdCaption";
            this.lblCccdCaption.Size = new System.Drawing.Size(37, 15);
            this.lblCccdCaption.TabIndex = 9;
            this.lblCccdCaption.Text = "CCCD";
            //
            // txtDobField
            //
            this.txtDobField.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtDobField.BorderRadius = 8;
            this.txtDobField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDobField.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtDobField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDobField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDobField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtDobField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDobField.Location = new System.Drawing.Point(215, 197);
            this.txtDobField.Name = "txtDobField";
            this.txtDobField.PlaceholderText = "dd/MM/yyyy";
            this.txtDobField.SelectedText = "";
            this.txtDobField.Size = new System.Drawing.Size(236, 34);
            this.txtDobField.TabIndex = 8;
            this.txtDobField.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblDobCaption
            //
            this.lblDobCaption.AutoSize = true;
            this.lblDobCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblDobCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDobCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDobCaption.Location = new System.Drawing.Point(215, 177);
            this.lblDobCaption.Name = "lblDobCaption";
            this.lblDobCaption.Size = new System.Drawing.Size(71, 15);
            this.lblDobCaption.TabIndex = 7;
            this.lblDobCaption.Text = "NGÀY SINH";
            //
            // txtGenderField
            //
            this.txtGenderField.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtGenderField.BorderRadius = 8;
            this.txtGenderField.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGenderField.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.txtGenderField.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtGenderField.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtGenderField.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.txtGenderField.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtGenderField.Location = new System.Drawing.Point(22, 197);
            this.txtGenderField.Name = "txtGenderField";
            this.txtGenderField.PlaceholderText = "";
            this.txtGenderField.SelectedText = "";
            this.txtGenderField.Size = new System.Drawing.Size(172, 34);
            this.txtGenderField.TabIndex = 6;
            this.txtGenderField.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblGenderCaption
            //
            this.lblGenderCaption.AutoSize = true;
            this.lblGenderCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblGenderCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGenderCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblGenderCaption.Location = new System.Drawing.Point(22, 177);
            this.lblGenderCaption.Name = "lblGenderCaption";
            this.lblGenderCaption.Size = new System.Drawing.Size(65, 15);
            this.lblGenderCaption.TabIndex = 5;
            this.lblGenderCaption.Text = "GIỚI TÍNH";
            //
            // txtPatientName
            //
            this.txtPatientName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtPatientName.BorderRadius = 8;
            this.txtPatientName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatientName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtPatientName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtPatientName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtPatientName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtPatientName.Location = new System.Drawing.Point(215, 84);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.PlaceholderText = "";
            this.txtPatientName.SelectedText = "";
            this.txtPatientName.Size = new System.Drawing.Size(236, 34);
            this.txtPatientName.TabIndex = 4;
            this.txtPatientName.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblPatientNameCaption
            //
            this.lblPatientNameCaption.AutoSize = true;
            this.lblPatientNameCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientNameCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPatientNameCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblPatientNameCaption.Location = new System.Drawing.Point(215, 63);
            this.lblPatientNameCaption.Name = "lblPatientNameCaption";
            this.lblPatientNameCaption.Size = new System.Drawing.Size(102, 15);
            this.lblPatientNameCaption.TabIndex = 3;
            this.lblPatientNameCaption.Text = "TÊN BỆNH NHÂN";
            //
            // txtPatientId
            //
            this.txtPatientId.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.txtPatientId.BorderRadius = 8;
            this.txtPatientId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPatientId.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.txtPatientId.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtPatientId.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtPatientId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.txtPatientId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtPatientId.Location = new System.Drawing.Point(22, 84);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.PlaceholderText = "";
            this.txtPatientId.SelectedText = "";
            this.txtPatientId.Size = new System.Drawing.Size(172, 34);
            this.txtPatientId.TabIndex = 2;
            this.txtPatientId.TextChanged += new System.EventHandler(this.AnyField_TextChanged);
            //
            // lblPatientIdCaption
            //
            this.lblPatientIdCaption.AutoSize = true;
            this.lblPatientIdCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientIdCaption.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPatientIdCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblPatientIdCaption.Location = new System.Drawing.Point(22, 63);
            this.lblPatientIdCaption.Name = "lblPatientIdCaption";
            this.lblPatientIdCaption.Size = new System.Drawing.Size(99, 15);
            this.lblPatientIdCaption.TabIndex = 1;
            this.lblPatientIdCaption.Text = "MÃ BỆNH NHÂN";
            //
            // lblProfileTitle
            //
            this.lblProfileTitle.AutoSize = true;
            this.lblProfileTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblProfileTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblProfileTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblProfileTitle.Location = new System.Drawing.Point(20, 13);
            this.lblProfileTitle.Name = "lblProfileTitle";
            this.lblProfileTitle.Size = new System.Drawing.Size(174, 28);
            this.lblProfileTitle.TabIndex = 0;
            this.lblProfileTitle.Text = "Thông tin cơ bản";
            //
            // pnlKpiPrescription
            //
            this.pnlKpiPrescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlKpiPrescription.BorderRadius = 8;
            this.pnlKpiPrescription.BorderThickness = 1;
            this.pnlKpiPrescription.Controls.Add(this.lblKpiPrescriptionSub);
            this.pnlKpiPrescription.Controls.Add(this.lblKpiPrescriptionTitle);
            this.pnlKpiPrescription.Controls.Add(this.lblKpiPrescriptionValue);
            this.pnlKpiPrescription.FillColor = System.Drawing.Color.White;
            this.pnlKpiPrescription.Location = new System.Drawing.Point(836, 172);
            this.pnlKpiPrescription.Name = "pnlKpiPrescription";
            this.pnlKpiPrescription.Size = new System.Drawing.Size(244, 90);
            this.pnlKpiPrescription.TabIndex = 4;
            //
            // lblKpiPrescriptionSub
            //
            this.lblKpiPrescriptionSub.AutoSize = true;
            this.lblKpiPrescriptionSub.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiPrescriptionSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiPrescriptionSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblKpiPrescriptionSub.Location = new System.Drawing.Point(80, 50);
            this.lblKpiPrescriptionSub.Name = "lblKpiPrescriptionSub";
            this.lblKpiPrescriptionSub.Size = new System.Drawing.Size(83, 15);
            this.lblKpiPrescriptionSub.TabIndex = 2;
            this.lblKpiPrescriptionSub.Text = "thuốc đang kê";
            //
            // lblKpiPrescriptionTitle
            //
            this.lblKpiPrescriptionTitle.AutoSize = true;
            this.lblKpiPrescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiPrescriptionTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiPrescriptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblKpiPrescriptionTitle.Location = new System.Drawing.Point(80, 28);
            this.lblKpiPrescriptionTitle.Name = "lblKpiPrescriptionTitle";
            this.lblKpiPrescriptionTitle.Size = new System.Drawing.Size(77, 19);
            this.lblKpiPrescriptionTitle.TabIndex = 1;
            this.lblKpiPrescriptionTitle.Text = "Đơn thuốc";
            //
            // lblKpiPrescriptionValue
            //
            this.lblKpiPrescriptionValue.AutoSize = true;
            this.lblKpiPrescriptionValue.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiPrescriptionValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiPrescriptionValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblKpiPrescriptionValue.Location = new System.Drawing.Point(24, 20);
            this.lblKpiPrescriptionValue.Name = "lblKpiPrescriptionValue";
            this.lblKpiPrescriptionValue.Size = new System.Drawing.Size(35, 41);
            this.lblKpiPrescriptionValue.TabIndex = 0;
            this.lblKpiPrescriptionValue.Text = "3";
            //
            // pnlKpiService
            //
            this.pnlKpiService.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlKpiService.BorderRadius = 8;
            this.pnlKpiService.BorderThickness = 1;
            this.pnlKpiService.Controls.Add(this.lblKpiServiceSub);
            this.pnlKpiService.Controls.Add(this.lblKpiServiceTitle);
            this.pnlKpiService.Controls.Add(this.lblKpiServiceValue);
            this.pnlKpiService.FillColor = System.Drawing.Color.White;
            this.pnlKpiService.Location = new System.Drawing.Point(565, 172);
            this.pnlKpiService.Name = "pnlKpiService";
            this.pnlKpiService.Size = new System.Drawing.Size(244, 90);
            this.pnlKpiService.TabIndex = 3;
            //
            // lblKpiServiceSub
            //
            this.lblKpiServiceSub.AutoSize = true;
            this.lblKpiServiceSub.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiServiceSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiServiceSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblKpiServiceSub.Location = new System.Drawing.Point(80, 50);
            this.lblKpiServiceSub.Name = "lblKpiServiceSub";
            this.lblKpiServiceSub.Size = new System.Drawing.Size(73, 15);
            this.lblKpiServiceSub.TabIndex = 2;
            this.lblKpiServiceSub.Text = "đã thực hiện";
            //
            // lblKpiServiceTitle
            //
            this.lblKpiServiceTitle.AutoSize = true;
            this.lblKpiServiceTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiServiceTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiServiceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblKpiServiceTitle.Location = new System.Drawing.Point(80, 28);
            this.lblKpiServiceTitle.Name = "lblKpiServiceTitle";
            this.lblKpiServiceTitle.Size = new System.Drawing.Size(58, 19);
            this.lblKpiServiceTitle.TabIndex = 1;
            this.lblKpiServiceTitle.Text = "Dịch vụ";
            //
            // lblKpiServiceValue
            //
            this.lblKpiServiceValue.AutoSize = true;
            this.lblKpiServiceValue.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiServiceValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiServiceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblKpiServiceValue.Location = new System.Drawing.Point(24, 20);
            this.lblKpiServiceValue.Name = "lblKpiServiceValue";
            this.lblKpiServiceValue.Size = new System.Drawing.Size(35, 41);
            this.lblKpiServiceValue.TabIndex = 0;
            this.lblKpiServiceValue.Text = "3";
            //
            // pnlKpiHsba
            //
            this.pnlKpiHsba.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlKpiHsba.BorderRadius = 8;
            this.pnlKpiHsba.BorderThickness = 1;
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaSub);
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaTitle);
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaValue);
            this.pnlKpiHsba.FillColor = System.Drawing.Color.White;
            this.pnlKpiHsba.Location = new System.Drawing.Point(294, 172);
            this.pnlKpiHsba.Name = "pnlKpiHsba";
            this.pnlKpiHsba.Size = new System.Drawing.Size(244, 90);
            this.pnlKpiHsba.TabIndex = 2;
            //
            // lblKpiHsbaSub
            //
            this.lblKpiHsbaSub.AutoSize = true;
            this.lblKpiHsbaSub.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiHsbaSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiHsbaSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblKpiHsbaSub.Location = new System.Drawing.Point(80, 50);
            this.lblKpiHsbaSub.Name = "lblKpiHsbaSub";
            this.lblKpiHsbaSub.Size = new System.Drawing.Size(101, 15);
            this.lblKpiHsbaSub.TabIndex = 2;
            this.lblKpiHsbaSub.Text = "lần khám gần đây";
            //
            // lblKpiHsbaTitle
            //
            this.lblKpiHsbaTitle.AutoSize = true;
            this.lblKpiHsbaTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiHsbaTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiHsbaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblKpiHsbaTitle.Location = new System.Drawing.Point(80, 28);
            this.lblKpiHsbaTitle.Name = "lblKpiHsbaTitle";
            this.lblKpiHsbaTitle.Size = new System.Drawing.Size(105, 19);
            this.lblKpiHsbaTitle.TabIndex = 1;
            this.lblKpiHsbaTitle.Text = "Hồ sơ bệnh án";
            //
            // lblKpiHsbaValue
            //
            this.lblKpiHsbaValue.AutoSize = true;
            this.lblKpiHsbaValue.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiHsbaValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiHsbaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblKpiHsbaValue.Location = new System.Drawing.Point(24, 20);
            this.lblKpiHsbaValue.Name = "lblKpiHsbaValue";
            this.lblKpiHsbaValue.Size = new System.Drawing.Size(35, 41);
            this.lblKpiHsbaValue.TabIndex = 0;
            this.lblKpiHsbaValue.Text = "3";
            //
            // pnlKpiAllergy
            //
            this.pnlKpiAllergy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlKpiAllergy.BorderRadius = 8;
            this.pnlKpiAllergy.BorderThickness = 1;
            this.pnlKpiAllergy.Controls.Add(this.lblKpiAllergySub);
            this.pnlKpiAllergy.Controls.Add(this.lblKpiAllergyTitle);
            this.pnlKpiAllergy.Controls.Add(this.lblKpiAllergyValue);
            this.pnlKpiAllergy.FillColor = System.Drawing.Color.White;
            this.pnlKpiAllergy.Location = new System.Drawing.Point(24, 172);
            this.pnlKpiAllergy.Name = "pnlKpiAllergy";
            this.pnlKpiAllergy.Size = new System.Drawing.Size(244, 90);
            this.pnlKpiAllergy.TabIndex = 1;
            //
            // lblKpiAllergySub
            //
            this.lblKpiAllergySub.AutoSize = true;
            this.lblKpiAllergySub.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiAllergySub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiAllergySub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblKpiAllergySub.Location = new System.Drawing.Point(80, 50);
            this.lblKpiAllergySub.Name = "lblKpiAllergySub";
            this.lblKpiAllergySub.Size = new System.Drawing.Size(108, 15);
            this.lblKpiAllergySub.TabIndex = 2;
            this.lblKpiAllergySub.Text = "trạng thái ghi nhận";
            //
            // lblKpiAllergyTitle
            //
            this.lblKpiAllergyTitle.AutoSize = true;
            this.lblKpiAllergyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiAllergyTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKpiAllergyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblKpiAllergyTitle.Location = new System.Drawing.Point(80, 28);
            this.lblKpiAllergyTitle.Name = "lblKpiAllergyTitle";
            this.lblKpiAllergyTitle.Size = new System.Drawing.Size(94, 19);
            this.lblKpiAllergyTitle.TabIndex = 1;
            this.lblKpiAllergyTitle.Text = "Dị ứng thuốc";
            //
            // lblKpiAllergyValue
            //
            this.lblKpiAllergyValue.AutoSize = true;
            this.lblKpiAllergyValue.BackColor = System.Drawing.Color.Transparent;
            this.lblKpiAllergyValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblKpiAllergyValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblKpiAllergyValue.Location = new System.Drawing.Point(24, 20);
            this.lblKpiAllergyValue.Name = "lblKpiAllergyValue";
            this.lblKpiAllergyValue.Size = new System.Drawing.Size(35, 41);
            this.lblKpiAllergyValue.TabIndex = 0;
            this.lblKpiAllergyValue.Text = "0";
            //
            // pnlWelcome
            //
            this.pnlWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWelcome.BorderRadius = 12;
            this.pnlWelcome.Controls.Add(this.lblWelcomeMeta);
            this.pnlWelcome.Controls.Add(this.lblWelcomeName);
            this.pnlWelcome.Controls.Add(this.lblWelcomeId);
            this.pnlWelcome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(82)))), ((int)(((byte)(66)))));
            this.pnlWelcome.Location = new System.Drawing.Point(24, 20);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(1056, 126);
            this.pnlWelcome.TabIndex = 0;
            // 
            // btnSaveProfile
            // 
            this.btnSaveProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveProfile.BorderRadius = 8;
            this.btnSaveProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveProfile.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSaveProfile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveProfile.ForeColor = System.Drawing.Color.White;
            this.btnSaveProfile.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnSaveProfile.Location = new System.Drawing.Point(960, 710);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.btnSaveProfile.Size = new System.Drawing.Size(120, 35);
            this.btnSaveProfile.TabIndex = 7;
            this.btnSaveProfile.Text = "Cập nhật";
            this.btnSaveProfile.Visible = true;
            this.btnSaveProfile.Enabled = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            //
            // lblWelcomeMeta
            //
            this.lblWelcomeMeta.AutoSize = true;
            this.lblWelcomeMeta.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeMeta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.lblWelcomeMeta.Location = new System.Drawing.Point(34, 84);
            this.lblWelcomeMeta.Name = "lblWelcomeMeta";
            this.lblWelcomeMeta.Size = new System.Drawing.Size(105, 20);
            this.lblWelcomeMeta.TabIndex = 3;
            this.lblWelcomeMeta.Text = "Nam · 52 tuổi";
            //
            // lblWelcomeName
            //
            this.lblWelcomeName.AutoSize = true;
            this.lblWelcomeName.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeName.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeName.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeName.Location = new System.Drawing.Point(30, 19);
            this.lblWelcomeName.Name = "lblWelcomeName";
            this.lblWelcomeName.Size = new System.Drawing.Size(252, 45);
            this.lblWelcomeName.TabIndex = 2;
            this.lblWelcomeName.Text = "Nguyễn Văn An";
            //
            // lblWelcomeId
            //
            this.lblWelcomeId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcomeId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblWelcomeId.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblWelcomeId.Location = new System.Drawing.Point(872, 68);
            this.lblWelcomeId.Name = "lblWelcomeId";
            this.lblWelcomeId.Size = new System.Drawing.Size(152, 36);
            this.lblWelcomeId.TabIndex = 0;
            this.lblWelcomeId.Text = "BN-00341";
            this.lblWelcomeId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // ucHSCN
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlRoot);
            this.Name = "ucHSCN";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.ResumeLayout(false);
            this.pnlRoot.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            this.pnlProfile.ResumeLayout(false);
            this.pnlProfile.PerformLayout();
            this.pnlKpiPrescription.ResumeLayout(false);
            this.pnlKpiPrescription.PerformLayout();
            this.pnlKpiService.ResumeLayout(false);
            this.pnlKpiService.PerformLayout();
            this.pnlKpiHsba.ResumeLayout(false);
            this.pnlKpiHsba.PerformLayout();
            this.pnlKpiAllergy.ResumeLayout(false);
            this.pnlKpiAllergy.PerformLayout();
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlWelcome;
        private Guna.UI2.WinForms.Guna2Button btnSaveProfile;
        private System.Windows.Forms.Label lblWelcomeId;
        private System.Windows.Forms.Label lblWelcomeName;
        private System.Windows.Forms.Label lblWelcomeMeta;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiAllergy;
        private System.Windows.Forms.Label lblKpiAllergyValue;
        private System.Windows.Forms.Label lblKpiAllergyTitle;
        private System.Windows.Forms.Label lblKpiAllergySub;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiHsba;
        private System.Windows.Forms.Label lblKpiHsbaSub;
        private System.Windows.Forms.Label lblKpiHsbaTitle;
        private System.Windows.Forms.Label lblKpiHsbaValue;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiService;
        private System.Windows.Forms.Label lblKpiServiceSub;
        private System.Windows.Forms.Label lblKpiServiceTitle;
        private System.Windows.Forms.Label lblKpiServiceValue;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiPrescription;
        private System.Windows.Forms.Label lblKpiPrescriptionSub;
        private System.Windows.Forms.Label lblKpiPrescriptionTitle;
        private System.Windows.Forms.Label lblKpiPrescriptionValue;
        private Guna.UI2.WinForms.Guna2Panel pnlProfile;
        private System.Windows.Forms.Label lblProfileTitle;
        private System.Windows.Forms.Label lblPatientIdCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtPatientId;
        private System.Windows.Forms.Label lblPatientNameCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtPatientName;
        private System.Windows.Forms.Label lblGenderCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtGenderField;
        private System.Windows.Forms.Label lblDobCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtDobField;
        private System.Windows.Forms.Label lblCccdCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtCccdField;
        private System.Windows.Forms.Label lblAddressCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtAddressField;
        private Guna.UI2.WinForms.Guna2Panel pnlHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Label lblAllergyCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtAllergy;
        private System.Windows.Forms.Label lblMedicalHistoryCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtMedicalHistory;
        private System.Windows.Forms.Label lblFamilyHistoryCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtFamilyHistory;
    }
}

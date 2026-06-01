namespace HospitalX.GUI.PH2.BenhNhan
{
    partial class frmBenhAnDetailBN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBenhAnDetailBN));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblHeaderMeta = new System.Windows.Forms.Label();
            this.lblRecordId = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.pnlDoctor = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDoctorPhoneValue = new System.Windows.Forms.Label();
            this.lblDoctorPhone = new System.Windows.Forms.Label();
            this.lblDoctorDeptValue = new System.Windows.Forms.Label();
            this.lblDoctorDept = new System.Windows.Forms.Label();
            this.lblDoctorRoleValue = new System.Windows.Forms.Label();
            this.lblDoctorRole = new System.Windows.Forms.Label();
            this.lblDoctorNameValue = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblDoctorTitle = new System.Windows.Forms.Label();
            this.pnlRecord = new Guna.UI2.WinForms.Guna2Panel();
            this.txtConclusion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConclusion = new System.Windows.Forms.Label();
            this.txtTreatment = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTreatment = new System.Windows.Forms.Label();
            this.txtDiagnosis = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiagnosis = new System.Windows.Forms.Label();
            this.lblRecordDateValue = new System.Windows.Forms.Label();
            this.lblRecordDate = new System.Windows.Forms.Label();
            this.lblRecordTitle = new System.Windows.Forms.Label();
            this.pnlServices = new Guna.UI2.WinForms.Guna2Panel();
            this.flowServices = new System.Windows.Forms.FlowLayoutPanel();
            this.lblServicesTitle = new System.Windows.Forms.Label();
            this.pnlPrescription = new Guna.UI2.WinForms.Guna2Panel();
            this.flowPrescriptions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblPrescriptionTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlDoctor.SuspendLayout();
            this.pnlRecord.SuspendLayout();
            this.pnlServices.SuspendLayout();
            this.pnlPrescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 14;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 12;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblHeaderMeta);
            this.pnlHeader.Controls.Add(this.lblRecordId);
            this.pnlHeader.Controls.Add(this.lblHeaderTitle);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(82)))), ((int)(((byte)(66)))));
            this.pnlHeader.Location = new System.Drawing.Point(24, 20);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1052, 124);
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
            this.btnClose.Location = new System.Drawing.Point(1001, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.TabIndex = 3;
            // 
            // lblHeaderMeta
            // 
            this.lblHeaderMeta.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderMeta.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblHeaderMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(235)))), ((int)(((byte)(225)))));
            this.lblHeaderMeta.Location = new System.Drawing.Point(32, 78);
            this.lblHeaderMeta.Name = "lblHeaderMeta";
            this.lblHeaderMeta.Size = new System.Drawing.Size(760, 26);
            this.lblHeaderMeta.TabIndex = 2;
            this.lblHeaderMeta.Text = "BN-00341 · Nguyễn Văn An · 21/05/2026";
            // 
            // lblRecordId
            // 
            this.lblRecordId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblRecordId.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.lblRecordId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblRecordId.Location = new System.Drawing.Point(883, 70);
            this.lblRecordId.Name = "lblRecordId";
            this.lblRecordId.Size = new System.Drawing.Size(154, 34);
            this.lblRecordId.TabIndex = 1;
            this.lblRecordId.Text = "HSBA-0000";
            this.lblRecordId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderTitle
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeaderTitle.Location = new System.Drawing.Point(29, 23);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(256, 45);
            this.lblHeaderTitle.TabIndex = 0;
            this.lblHeaderTitle.Text = "Chi tiết bệnh án";
            // 
            // pnlDoctor
            // 
            this.pnlDoctor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlDoctor.BorderRadius = 8;
            this.pnlDoctor.BorderThickness = 1;
            this.pnlDoctor.Controls.Add(this.lblDoctorPhoneValue);
            this.pnlDoctor.Controls.Add(this.lblDoctorPhone);
            this.pnlDoctor.Controls.Add(this.lblDoctorDeptValue);
            this.pnlDoctor.Controls.Add(this.lblDoctorDept);
            this.pnlDoctor.Controls.Add(this.lblDoctorRoleValue);
            this.pnlDoctor.Controls.Add(this.lblDoctorRole);
            this.pnlDoctor.Controls.Add(this.lblDoctorNameValue);
            this.pnlDoctor.Controls.Add(this.lblDoctorName);
            this.pnlDoctor.Controls.Add(this.lblDoctorTitle);
            this.pnlDoctor.FillColor = System.Drawing.Color.White;
            this.pnlDoctor.Location = new System.Drawing.Point(24, 164);
            this.pnlDoctor.Name = "pnlDoctor";
            this.pnlDoctor.Size = new System.Drawing.Size(376, 214);
            this.pnlDoctor.TabIndex = 1;
            // 
            // lblDoctorPhoneValue
            // 
            this.lblDoctorPhoneValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoctorPhoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblDoctorPhoneValue.Location = new System.Drawing.Point(124, 139);
            this.lblDoctorPhoneValue.Name = "lblDoctorPhoneValue";
            this.lblDoctorPhoneValue.Size = new System.Drawing.Size(166, 22);
            this.lblDoctorPhoneValue.TabIndex = 0;
            this.lblDoctorPhoneValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoctorPhone
            // 
            this.lblDoctorPhone.AutoSize = true;
            this.lblDoctorPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorPhone.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDoctorPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDoctorPhone.Location = new System.Drawing.Point(80, 140);
            this.lblDoctorPhone.Name = "lblDoctorPhone";
            this.lblDoctorPhone.Size = new System.Drawing.Size(30, 15);
            this.lblDoctorPhone.TabIndex = 1;
            this.lblDoctorPhone.Text = "SĐT";
            // 
            // lblDoctorDeptValue
            // 
            this.lblDoctorDeptValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblDoctorDeptValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoctorDeptValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblDoctorDeptValue.Location = new System.Drawing.Point(123, 175);
            this.lblDoctorDeptValue.Name = "lblDoctorDeptValue";
            this.lblDoctorDeptValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblDoctorDeptValue.Size = new System.Drawing.Size(150, 30);
            this.lblDoctorDeptValue.TabIndex = 2;
            this.lblDoctorDeptValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoctorDept
            // 
            this.lblDoctorDept.AutoSize = true;
            this.lblDoctorDept.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorDept.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDoctorDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDoctorDept.Location = new System.Drawing.Point(19, 178);
            this.lblDoctorDept.Name = "lblDoctorDept";
            this.lblDoctorDept.Size = new System.Drawing.Size(91, 15);
            this.lblDoctorDept.TabIndex = 3;
            this.lblDoctorDept.Text = "CHUYÊN KHOA";
            // 
            // lblDoctorRoleValue
            // 
            this.lblDoctorRoleValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(245)))), ((int)(((byte)(239)))));
            this.lblDoctorRoleValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoctorRoleValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblDoctorRoleValue.Location = new System.Drawing.Point(123, 94);
            this.lblDoctorRoleValue.Name = "lblDoctorRoleValue";
            this.lblDoctorRoleValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblDoctorRoleValue.Size = new System.Drawing.Size(120, 30);
            this.lblDoctorRoleValue.TabIndex = 4;
            this.lblDoctorRoleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoctorRole
            // 
            this.lblDoctorRole.AutoSize = true;
            this.lblDoctorRole.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorRole.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDoctorRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDoctorRole.Location = new System.Drawing.Point(57, 97);
            this.lblDoctorRole.Name = "lblDoctorRole";
            this.lblDoctorRole.Size = new System.Drawing.Size(53, 15);
            this.lblDoctorRole.TabIndex = 5;
            this.lblDoctorRole.Text = "VAI TRÒ";
            // 
            // lblDoctorNameValue
            // 
            this.lblDoctorNameValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.lblDoctorNameValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDoctorNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblDoctorNameValue.Location = new System.Drawing.Point(121, 54);
            this.lblDoctorNameValue.Name = "lblDoctorNameValue";
            this.lblDoctorNameValue.Padding = new System.Windows.Forms.Padding(10, 4, 8, 4);
            this.lblDoctorNameValue.Size = new System.Drawing.Size(235, 30);
            this.lblDoctorNameValue.TabIndex = 6;
            this.lblDoctorNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDoctorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDoctorName.Location = new System.Drawing.Point(60, 60);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(50, 15);
            this.lblDoctorName.TabIndex = 7;
            this.lblDoctorName.Text = "HỌ TÊN";
            // 
            // lblDoctorTitle
            // 
            this.lblDoctorTitle.AutoSize = true;
            this.lblDoctorTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblDoctorTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblDoctorTitle.Location = new System.Drawing.Point(17, 13);
            this.lblDoctorTitle.Name = "lblDoctorTitle";
            this.lblDoctorTitle.Size = new System.Drawing.Size(121, 28);
            this.lblDoctorTitle.TabIndex = 0;
            this.lblDoctorTitle.Text = "Bác sĩ / Y sĩ";
            // 
            // pnlRecord
            // 
            this.pnlRecord.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlRecord.BorderRadius = 8;
            this.pnlRecord.BorderThickness = 1;
            this.pnlRecord.Controls.Add(this.txtConclusion);
            this.pnlRecord.Controls.Add(this.lblConclusion);
            this.pnlRecord.Controls.Add(this.txtTreatment);
            this.pnlRecord.Controls.Add(this.lblTreatment);
            this.pnlRecord.Controls.Add(this.txtDiagnosis);
            this.pnlRecord.Controls.Add(this.lblDiagnosis);
            this.pnlRecord.Controls.Add(this.lblRecordDateValue);
            this.pnlRecord.Controls.Add(this.lblRecordDate);
            this.pnlRecord.Controls.Add(this.lblRecordTitle);
            this.pnlRecord.FillColor = System.Drawing.Color.White;
            this.pnlRecord.Location = new System.Drawing.Point(422, 164);
            this.pnlRecord.Name = "pnlRecord";
            this.pnlRecord.Size = new System.Drawing.Size(654, 214);
            this.pnlRecord.TabIndex = 2;
            // 
            // txtConclusion
            // 
            this.txtConclusion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.txtConclusion.BorderRadius = 6;
            this.txtConclusion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConclusion.DefaultText = "";
            this.txtConclusion.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtConclusion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtConclusion.Location = new System.Drawing.Point(360, 140);
            this.txtConclusion.Multiline = true;
            this.txtConclusion.Name = "txtConclusion";
            this.txtConclusion.PlaceholderText = "";
            this.txtConclusion.ReadOnly = true;
            this.txtConclusion.SelectedText = "";
            this.txtConclusion.Size = new System.Drawing.Size(272, 56);
            this.txtConclusion.TabIndex = 0;
            // 
            // lblConclusion
            // 
            this.lblConclusion.AutoSize = true;
            this.lblConclusion.BackColor = System.Drawing.Color.Transparent;
            this.lblConclusion.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblConclusion.Location = new System.Drawing.Point(362, 120);
            this.lblConclusion.Name = "lblConclusion";
            this.lblConclusion.Size = new System.Drawing.Size(63, 15);
            this.lblConclusion.TabIndex = 1;
            this.lblConclusion.Text = "KẾT LUẬN";
            // 
            // txtTreatment
            // 
            this.txtTreatment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.txtTreatment.BorderRadius = 6;
            this.txtTreatment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTreatment.DefaultText = "";
            this.txtTreatment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtTreatment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTreatment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtTreatment.Location = new System.Drawing.Point(28, 140);
            this.txtTreatment.Multiline = true;
            this.txtTreatment.Name = "txtTreatment";
            this.txtTreatment.PlaceholderText = "";
            this.txtTreatment.ReadOnly = true;
            this.txtTreatment.SelectedText = "";
            this.txtTreatment.Size = new System.Drawing.Size(303, 56);
            this.txtTreatment.TabIndex = 2;
            // 
            // lblTreatment
            // 
            this.lblTreatment.AutoSize = true;
            this.lblTreatment.BackColor = System.Drawing.Color.Transparent;
            this.lblTreatment.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTreatment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblTreatment.Location = new System.Drawing.Point(25, 120);
            this.lblTreatment.Name = "lblTreatment";
            this.lblTreatment.Size = new System.Drawing.Size(57, 15);
            this.lblTreatment.TabIndex = 3;
            this.lblTreatment.Text = "ĐIỀU TRỊ";
            // 
            // txtDiagnosis
            // 
            this.txtDiagnosis.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(228)))));
            this.txtDiagnosis.BorderRadius = 6;
            this.txtDiagnosis.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiagnosis.DefaultText = "";
            this.txtDiagnosis.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtDiagnosis.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.txtDiagnosis.Location = new System.Drawing.Point(24, 80);
            this.txtDiagnosis.Name = "txtDiagnosis";
            this.txtDiagnosis.PlaceholderText = "";
            this.txtDiagnosis.ReadOnly = true;
            this.txtDiagnosis.SelectedText = "";
            this.txtDiagnosis.Size = new System.Drawing.Size(608, 32);
            this.txtDiagnosis.TabIndex = 4;
            // 
            // lblDiagnosis
            // 
            this.lblDiagnosis.AutoSize = true;
            this.lblDiagnosis.BackColor = System.Drawing.Color.Transparent;
            this.lblDiagnosis.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblDiagnosis.Location = new System.Drawing.Point(25, 60);
            this.lblDiagnosis.Name = "lblDiagnosis";
            this.lblDiagnosis.Size = new System.Drawing.Size(78, 15);
            this.lblDiagnosis.TabIndex = 5;
            this.lblDiagnosis.Text = "CHẨN ĐOÁN";
            // 
            // lblRecordDateValue
            // 
            this.lblRecordDateValue.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblRecordDateValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.lblRecordDateValue.Location = new System.Drawing.Point(557, 24);
            this.lblRecordDateValue.Name = "lblRecordDateValue";
            this.lblRecordDateValue.Size = new System.Drawing.Size(82, 22);
            this.lblRecordDateValue.TabIndex = 6;
            this.lblRecordDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecordDate
            // 
            this.lblRecordDate.AutoSize = true;
            this.lblRecordDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordDate.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRecordDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(138)))), ((int)(((byte)(132)))));
            this.lblRecordDate.Location = new System.Drawing.Point(483, 30);
            this.lblRecordDate.Name = "lblRecordDate";
            this.lblRecordDate.Size = new System.Drawing.Size(63, 15);
            this.lblRecordDate.TabIndex = 7;
            this.lblRecordDate.Text = "NGÀY LẬP";
            // 
            // lblRecordTitle
            // 
            this.lblRecordTitle.AutoSize = true;
            this.lblRecordTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblRecordTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblRecordTitle.Location = new System.Drawing.Point(22, 11);
            this.lblRecordTitle.Name = "lblRecordTitle";
            this.lblRecordTitle.Size = new System.Drawing.Size(162, 28);
            this.lblRecordTitle.TabIndex = 8;
            this.lblRecordTitle.Text = "Thông tin hồ sơ";
            // 
            // pnlServices
            // 
            this.pnlServices.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlServices.BorderRadius = 8;
            this.pnlServices.BorderThickness = 1;
            this.pnlServices.Controls.Add(this.flowServices);
            this.pnlServices.Controls.Add(this.lblServicesTitle);
            this.pnlServices.FillColor = System.Drawing.Color.White;
            this.pnlServices.Location = new System.Drawing.Point(24, 398);
            this.pnlServices.Name = "pnlServices";
            this.pnlServices.Size = new System.Drawing.Size(516, 240);
            this.pnlServices.TabIndex = 3;
            // 
            // flowServices
            // 
            this.flowServices.AutoScroll = true;
            this.flowServices.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowServices.Location = new System.Drawing.Point(22, 58);
            this.flowServices.Name = "flowServices";
            this.flowServices.Size = new System.Drawing.Size(472, 160);
            this.flowServices.TabIndex = 0;
            this.flowServices.WrapContents = false;
            // 
            // lblServicesTitle
            // 
            this.lblServicesTitle.AutoSize = true;
            this.lblServicesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblServicesTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblServicesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblServicesTitle.Location = new System.Drawing.Point(17, 18);
            this.lblServicesTitle.Name = "lblServicesTitle";
            this.lblServicesTitle.Size = new System.Drawing.Size(210, 28);
            this.lblServicesTitle.TabIndex = 1;
            this.lblServicesTitle.Text = "Dịch vụ đã thực hiện";
            // 
            // pnlPrescription
            // 
            this.pnlPrescription.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(224)))), ((int)(((byte)(219)))));
            this.pnlPrescription.BorderRadius = 8;
            this.pnlPrescription.BorderThickness = 1;
            this.pnlPrescription.Controls.Add(this.flowPrescriptions);
            this.pnlPrescription.Controls.Add(this.lblPrescriptionTitle);
            this.pnlPrescription.FillColor = System.Drawing.Color.White;
            this.pnlPrescription.Location = new System.Drawing.Point(560, 398);
            this.pnlPrescription.Name = "pnlPrescription";
            this.pnlPrescription.Size = new System.Drawing.Size(516, 240);
            this.pnlPrescription.TabIndex = 4;
            // 
            // flowPrescriptions
            // 
            this.flowPrescriptions.AutoScroll = true;
            this.flowPrescriptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPrescriptions.Location = new System.Drawing.Point(22, 58);
            this.flowPrescriptions.Name = "flowPrescriptions";
            this.flowPrescriptions.Size = new System.Drawing.Size(472, 160);
            this.flowPrescriptions.TabIndex = 0;
            this.flowPrescriptions.WrapContents = false;
            // 
            // lblPrescriptionTitle
            // 
            this.lblPrescriptionTitle.AutoSize = true;
            this.lblPrescriptionTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPrescriptionTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblPrescriptionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblPrescriptionTitle.Location = new System.Drawing.Point(17, 18);
            this.lblPrescriptionTitle.Name = "lblPrescriptionTitle";
            this.lblPrescriptionTitle.Size = new System.Drawing.Size(112, 28);
            this.lblPrescriptionTitle.TabIndex = 1;
            this.lblPrescriptionTitle.Text = "Đơn thuốc";
            // 
            // frmBenhAnDetailBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(1100, 662);
            this.Controls.Add(this.pnlPrescription);
            this.Controls.Add(this.pnlServices);
            this.Controls.Add(this.pnlRecord);
            this.Controls.Add(this.pnlDoctor);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBenhAnDetailBN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết bệnh án";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlDoctor.ResumeLayout(false);
            this.pnlDoctor.PerformLayout();
            this.pnlRecord.ResumeLayout(false);
            this.pnlRecord.PerformLayout();
            this.pnlServices.ResumeLayout(false);
            this.pnlServices.PerformLayout();
            this.pnlPrescription.ResumeLayout(false);
            this.pnlPrescription.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblHeaderMeta;
        private System.Windows.Forms.Label lblRecordId;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlDoctor;
        private System.Windows.Forms.Label lblDoctorTitle;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblDoctorNameValue;
        private System.Windows.Forms.Label lblDoctorRole;
        private System.Windows.Forms.Label lblDoctorRoleValue;
        private System.Windows.Forms.Label lblDoctorDept;
        private System.Windows.Forms.Label lblDoctorDeptValue;
        private System.Windows.Forms.Label lblDoctorPhone;
        private System.Windows.Forms.Label lblDoctorPhoneValue;
        private Guna.UI2.WinForms.Guna2Panel pnlRecord;
        private System.Windows.Forms.Label lblRecordTitle;
        private System.Windows.Forms.Label lblRecordDate;
        private System.Windows.Forms.Label lblRecordDateValue;
        private System.Windows.Forms.Label lblDiagnosis;
        private Guna.UI2.WinForms.Guna2TextBox txtDiagnosis;
        private System.Windows.Forms.Label lblTreatment;
        private Guna.UI2.WinForms.Guna2TextBox txtTreatment;
        private System.Windows.Forms.Label lblConclusion;
        private Guna.UI2.WinForms.Guna2TextBox txtConclusion;
        private Guna.UI2.WinForms.Guna2Panel pnlServices;
        private System.Windows.Forms.FlowLayoutPanel flowServices;
        private System.Windows.Forms.Label lblServicesTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlPrescription;
        private System.Windows.Forms.FlowLayoutPanel flowPrescriptions;
        private System.Windows.Forms.Label lblPrescriptionTitle;
    }
}

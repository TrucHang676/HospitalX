namespace HospitalX.GUI.PH2.BacSi
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
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlProfile = new Guna.UI2.WinForms.Guna2Panel();
            this.lblProfileStatus = new System.Windows.Forms.Label();
            this.lblPatientStatCaption = new System.Windows.Forms.Label();
            this.lblPatientStat = new System.Windows.Forms.Label();
            this.lblRelatedStatCaption = new System.Windows.Forms.Label();
            this.lblRelatedStat = new System.Windows.Forms.Label();
            this.lblProfileDept = new System.Windows.Forms.Label();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.lblProfileName = new System.Windows.Forms.Label();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.pnlPatientCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRelatedCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlProfileHeader = new System.Windows.Forms.Panel();
            this.pnlProfessional = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSpecFacilityValue = new System.Windows.Forms.Label();
            this.lblSpecFacility = new System.Windows.Forms.Label();
            this.lblSpecDeptValue = new System.Windows.Forms.Label();
            this.lblSpecDept = new System.Windows.Forms.Label();
            this.lblSpecCodeValue = new System.Windows.Forms.Label();
            this.lblSpecCode = new System.Windows.Forms.Label();
            this.lblSpecRoleValue = new System.Windows.Forms.Label();
            this.lblSpecRole = new System.Windows.Forms.Label();
            this.lblSpecNameValue = new System.Windows.Forms.Label();
            this.lblSpecName = new System.Windows.Forms.Label();
            this.lblProfessionalTitle = new System.Windows.Forms.Label();
            this.lblLockTag = new System.Windows.Forms.Label();
            this.pnlContact = new Guna.UI2.WinForms.Guna2Panel();
            this.btnEditContact = new Guna.UI2.WinForms.Guna2Button();
            this.txtAddressValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddressValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtContactPhoneValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContactPhoneValue = new System.Windows.Forms.Label();
            this.lblContactPhone = new System.Windows.Forms.Label();
            this.lblContactTitle = new System.Windows.Forms.Label();
            this.pnlSecurity = new Guna.UI2.WinForms.Guna2Panel();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.lblPassSub = new System.Windows.Forms.Label();
            this.lblPassTitle = new System.Windows.Forms.Label();
            this.lblSecurityTitle = new System.Windows.Forms.Label();
            this.pnlActivity = new Guna.UI2.WinForms.Guna2Panel();
            this.flpRecentActivities = new System.Windows.Forms.FlowLayoutPanel();
            this.lblActivityTitle = new System.Windows.Forms.Label();
            this.pnlProfile.SuspendLayout();
            this.pnlPatientCard.SuspendLayout();
            this.pnlRelatedCard.SuspendLayout();
            this.pnlProfessional.SuspendLayout();
            this.pnlContact.SuspendLayout();
            this.pnlSecurity.SuspendLayout();
            this.pnlActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = "HospitalX";
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.msgDialog.Parent = null;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
            // 
            // pnlProfile
            // 
            this.pnlProfile.BackColor = System.Drawing.Color.Transparent;
            this.pnlProfile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlProfile.BorderRadius = 14;
            this.pnlProfile.BorderThickness = 1;
            this.pnlProfile.Controls.Add(this.lblProfileStatus);
            this.pnlProfile.Controls.Add(this.lblProfileDept);
            this.pnlProfile.Controls.Add(this.lblRoleBadge);
            this.pnlProfile.Controls.Add(this.lblProfileName);
            this.pnlProfile.Controls.Add(this.lblAvatar);
            this.pnlProfile.Controls.Add(this.pnlProfileHeader);
            this.pnlProfile.Controls.Add(this.pnlPatientCard);
            this.pnlProfile.Controls.Add(this.pnlRelatedCard);
            this.pnlProfile.FillColor = System.Drawing.Color.White;
            this.pnlProfile.Location = new System.Drawing.Point(24, 181);
            this.pnlProfile.Name = "pnlProfile";
            this.pnlProfile.Padding = new System.Windows.Forms.Padding(24);
            this.pnlProfile.Size = new System.Drawing.Size(306, 406);
            this.pnlProfile.TabIndex = 0;
            // 
            // lblProfileStatus
            // 
            this.lblProfileStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(168)))), ((int)(((byte)(56)))));
            this.lblProfileStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblProfileStatus.ForeColor = System.Drawing.Color.White;
            this.lblProfileStatus.Location = new System.Drawing.Point(86, 362);
            this.lblProfileStatus.Name = "lblProfileStatus";
            this.lblProfileStatus.Size = new System.Drawing.Size(134, 26);
            this.lblProfileStatus.TabIndex = 8;
            this.lblProfileStatus.Text = "Đang hoạt động";
            this.lblProfileStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientStatCaption
            // 
            this.lblPatientStatCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblPatientStatCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPatientStatCaption.Location = new System.Drawing.Point(7, 60);
            this.lblPatientStatCaption.Name = "lblPatientStatCaption";
            this.lblPatientStatCaption.Size = new System.Drawing.Size(103, 24);
            this.lblPatientStatCaption.TabIndex = 7;
            this.lblPatientStatCaption.Text = "BỆNH NHÂN";
            this.lblPatientStatCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblPatientStat
            // 
            this.lblPatientStat.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPatientStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblPatientStat.Location = new System.Drawing.Point(3, 8);
            this.lblPatientStat.Name = "lblPatientStat";
            this.lblPatientStat.Size = new System.Drawing.Size(110, 42);
            this.lblPatientStat.TabIndex = 6;
            this.lblPatientStat.Text = "9";
            this.lblPatientStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRelatedStatCaption
            // 
            this.lblRelatedStatCaption.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRelatedStatCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblRelatedStatCaption.Location = new System.Drawing.Point(7, 60);
            this.lblRelatedStatCaption.Name = "lblRelatedStatCaption";
            this.lblRelatedStatCaption.Size = new System.Drawing.Size(106, 24);
            this.lblRelatedStatCaption.TabIndex = 5;
            this.lblRelatedStatCaption.Text = "HSBA LIÊN QUAN";
            this.lblRelatedStatCaption.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRelatedStat
            // 
            this.lblRelatedStat.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblRelatedStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblRelatedStat.Location = new System.Drawing.Point(14, 8);
            this.lblRelatedStat.Name = "lblRelatedStat";
            this.lblRelatedStat.Size = new System.Drawing.Size(90, 42);
            this.lblRelatedStat.TabIndex = 4;
            this.lblRelatedStat.Text = "59";
            this.lblRelatedStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfileDept
            // 
            this.lblProfileDept.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblProfileDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblProfileDept.Location = new System.Drawing.Point(28, 214);
            this.lblProfileDept.Name = "lblProfileDept";
            this.lblProfileDept.Size = new System.Drawing.Size(250, 42);
            this.lblProfileDept.TabIndex = 3;
            this.lblProfileDept.Text = "Khoa Thần kinh\r\nBV Đa Khoa Tỉnh\r\n";
            this.lblProfileDept.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblRoleBadge
            // 
            this.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblRoleBadge.Location = new System.Drawing.Point(103, 178);
            this.lblRoleBadge.Name = "lblRoleBadge";
            this.lblRoleBadge.Size = new System.Drawing.Size(100, 26);
            this.lblRoleBadge.TabIndex = 2;
            this.lblRoleBadge.Text = "Bác sĩ";
            this.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProfileName
            // 
            this.lblProfileName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblProfileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblProfileName.Location = new System.Drawing.Point(20, 140);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(266, 34);
            this.lblProfileName.TabIndex = 1;
            this.lblProfileName.Text = "BS. Trúc Hằng";
            this.lblProfileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(111, 50);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(84, 84);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "TH";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPatientCard
            // 
            this.pnlPatientCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlPatientCard.BorderRadius = 10;
            this.pnlPatientCard.BorderThickness = 1;
            this.pnlPatientCard.Controls.Add(this.lblPatientStatCaption);
            this.pnlPatientCard.Controls.Add(this.lblPatientStat);
            this.pnlPatientCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.pnlPatientCard.Location = new System.Drawing.Point(158, 260);
            this.pnlPatientCard.Name = "pnlPatientCard";
            this.pnlPatientCard.Size = new System.Drawing.Size(116, 88);
            this.pnlPatientCard.TabIndex = 9;
            // 
            // pnlRelatedCard
            // 
            this.pnlRelatedCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRelatedCard.BorderRadius = 10;
            this.pnlRelatedCard.BorderThickness = 1;
            this.pnlRelatedCard.Controls.Add(this.lblRelatedStat);
            this.pnlRelatedCard.Controls.Add(this.lblRelatedStatCaption);
            this.pnlRelatedCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlRelatedCard.Location = new System.Drawing.Point(28, 260);
            this.pnlRelatedCard.Name = "pnlRelatedCard";
            this.pnlRelatedCard.Size = new System.Drawing.Size(116, 88);
            this.pnlRelatedCard.TabIndex = 10;
            // 
            // pnlProfileHeader
            // 
            this.pnlProfileHeader.BackColor = System.Drawing.Color.LightSeaGreen;
            this.pnlProfileHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProfileHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProfileHeader.Location = new System.Drawing.Point(24, 24);
            this.pnlProfileHeader.Name = "pnlProfileHeader";
            this.pnlProfileHeader.Size = new System.Drawing.Size(258, 82);
            this.pnlProfileHeader.TabIndex = 11;
            // 
            // pnlProfessional
            // 
            this.pnlProfessional.BackColor = System.Drawing.Color.Transparent;
            this.pnlProfessional.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlProfessional.BorderRadius = 14;
            this.pnlProfessional.BorderThickness = 1;
            this.pnlProfessional.Controls.Add(this.lblSpecFacilityValue);
            this.pnlProfessional.Controls.Add(this.lblSpecFacility);
            this.pnlProfessional.Controls.Add(this.lblSpecDeptValue);
            this.pnlProfessional.Controls.Add(this.lblSpecDept);
            this.pnlProfessional.Controls.Add(this.lblSpecCodeValue);
            this.pnlProfessional.Controls.Add(this.lblSpecCode);
            this.pnlProfessional.Controls.Add(this.lblSpecRoleValue);
            this.pnlProfessional.Controls.Add(this.lblSpecRole);
            this.pnlProfessional.Controls.Add(this.lblSpecNameValue);
            this.pnlProfessional.Controls.Add(this.lblSpecName);
            this.pnlProfessional.Controls.Add(this.lblProfessionalTitle);
            this.pnlProfessional.Controls.Add(this.lblLockTag);
            this.pnlProfessional.FillColor = System.Drawing.Color.White;
            this.pnlProfessional.Location = new System.Drawing.Point(354, 24);
            this.pnlProfessional.Name = "pnlProfessional";
            this.pnlProfessional.Size = new System.Drawing.Size(748, 196);
            this.pnlProfessional.TabIndex = 1;
            // 
            // lblSpecFacilityValue
            // 
            this.lblSpecFacilityValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblSpecFacilityValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecFacilityValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblSpecFacilityValue.Location = new System.Drawing.Point(518, 136);
            this.lblSpecFacilityValue.Name = "lblSpecFacilityValue";
            this.lblSpecFacilityValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSpecFacilityValue.Size = new System.Drawing.Size(196, 34);
            this.lblSpecFacilityValue.TabIndex = 12;
            this.lblSpecFacilityValue.Text = "BV Đa Khoa Tỉnh";
            this.lblSpecFacilityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecFacility
            // 
            this.lblSpecFacility.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblSpecFacility.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSpecFacility.Location = new System.Drawing.Point(518, 114);
            this.lblSpecFacility.Name = "lblSpecFacility";
            this.lblSpecFacility.Size = new System.Drawing.Size(196, 18);
            this.lblSpecFacility.TabIndex = 11;
            this.lblSpecFacility.Text = "CƠ SỞ Y TẾ";
            // 
            // lblSpecDeptValue
            // 
            this.lblSpecDeptValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblSpecDeptValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecDeptValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblSpecDeptValue.Location = new System.Drawing.Point(276, 136);
            this.lblSpecDeptValue.Name = "lblSpecDeptValue";
            this.lblSpecDeptValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSpecDeptValue.Size = new System.Drawing.Size(196, 34);
            this.lblSpecDeptValue.TabIndex = 10;
            this.lblSpecDeptValue.Text = "Thần kinh";
            this.lblSpecDeptValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecDept
            // 
            this.lblSpecDept.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblSpecDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSpecDept.Location = new System.Drawing.Point(276, 114);
            this.lblSpecDept.Name = "lblSpecDept";
            this.lblSpecDept.Size = new System.Drawing.Size(196, 18);
            this.lblSpecDept.TabIndex = 9;
            this.lblSpecDept.Text = "KHOA / PHÒNG";
            // 
            // lblSpecCodeValue
            // 
            this.lblSpecCodeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblSpecCodeValue.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecCodeValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblSpecCodeValue.Location = new System.Drawing.Point(34, 136);
            this.lblSpecCodeValue.Name = "lblSpecCodeValue";
            this.lblSpecCodeValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSpecCodeValue.Size = new System.Drawing.Size(196, 34);
            this.lblSpecCodeValue.TabIndex = 8;
            this.lblSpecCodeValue.Text = "NV-BS-0047";
            this.lblSpecCodeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecCode
            // 
            this.lblSpecCode.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblSpecCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSpecCode.Location = new System.Drawing.Point(34, 114);
            this.lblSpecCode.Name = "lblSpecCode";
            this.lblSpecCode.Size = new System.Drawing.Size(196, 18);
            this.lblSpecCode.TabIndex = 7;
            this.lblSpecCode.Text = "MÃ NHÂN VIÊN";
            // 
            // lblSpecRoleValue
            // 
            this.lblSpecRoleValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblSpecRoleValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecRoleValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblSpecRoleValue.Location = new System.Drawing.Point(518, 70);
            this.lblSpecRoleValue.Name = "lblSpecRoleValue";
            this.lblSpecRoleValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSpecRoleValue.Size = new System.Drawing.Size(196, 34);
            this.lblSpecRoleValue.TabIndex = 6;
            this.lblSpecRoleValue.Text = "Bác sĩ";
            this.lblSpecRoleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecRole
            // 
            this.lblSpecRole.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblSpecRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSpecRole.Location = new System.Drawing.Point(518, 48);
            this.lblSpecRole.Name = "lblSpecRole";
            this.lblSpecRole.Size = new System.Drawing.Size(196, 18);
            this.lblSpecRole.TabIndex = 5;
            this.lblSpecRole.Text = "VAI TRÒ";
            // 
            // lblSpecNameValue
            // 
            this.lblSpecNameValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblSpecNameValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSpecNameValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblSpecNameValue.Location = new System.Drawing.Point(276, 70);
            this.lblSpecNameValue.Name = "lblSpecNameValue";
            this.lblSpecNameValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSpecNameValue.Size = new System.Drawing.Size(196, 34);
            this.lblSpecNameValue.TabIndex = 4;
            this.lblSpecNameValue.Text = "Nguyễn Thị Trúc Hằng";
            this.lblSpecNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpecName
            // 
            this.lblSpecName.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblSpecName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSpecName.Location = new System.Drawing.Point(276, 48);
            this.lblSpecName.Name = "lblSpecName";
            this.lblSpecName.Size = new System.Drawing.Size(196, 18);
            this.lblSpecName.TabIndex = 3;
            this.lblSpecName.Text = "HỌ VÀ TÊN";
            // 
            // lblProfessionalTitle
            // 
            this.lblProfessionalTitle.AutoSize = true;
            this.lblProfessionalTitle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblProfessionalTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfessionalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblProfessionalTitle.Location = new System.Drawing.Point(33, 18);
            this.lblProfessionalTitle.Name = "lblProfessionalTitle";
            this.lblProfessionalTitle.Size = new System.Drawing.Size(183, 21);
            this.lblProfessionalTitle.TabIndex = 1;
            this.lblProfessionalTitle.Text = "Thông tin chuyên môn";
            // 
            // lblLockTag
            // 
            this.lblLockTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lblLockTag.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLockTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblLockTag.Location = new System.Drawing.Point(620, 18);
            this.lblLockTag.Name = "lblLockTag";
            this.lblLockTag.Size = new System.Drawing.Size(94, 26);
            this.lblLockTag.TabIndex = 0;
            this.lblLockTag.Text = "Chỉ xem";
            this.lblLockTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContact
            // 
            this.pnlContact.BackColor = System.Drawing.Color.Transparent;
            this.pnlContact.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlContact.BorderRadius = 14;
            this.pnlContact.BorderThickness = 1;
            this.pnlContact.Controls.Add(this.btnEditContact);
            this.pnlContact.Controls.Add(this.txtAddressValue);
            this.pnlContact.Controls.Add(this.lblAddress);
            this.pnlContact.Controls.Add(this.txtContactPhoneValue);
            this.pnlContact.Controls.Add(this.lblContactPhone);
            this.pnlContact.Controls.Add(this.lblContactTitle);
            this.pnlContact.FillColor = System.Drawing.Color.White;
            this.pnlContact.Location = new System.Drawing.Point(354, 240);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(748, 156);
            this.pnlContact.TabIndex = 2;
            // 
            // btnEditContact
            // 
            this.btnEditContact.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnEditContact.BorderRadius = 9;
            this.btnEditContact.BorderThickness = 1;
            this.btnEditContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditContact.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(208)))), ((int)(((byte)(203)))));
            this.btnEditContact.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnEditContact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnEditContact.FillColor = System.Drawing.Color.White;
            this.btnEditContact.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEditContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnEditContact.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnEditContact.Location = new System.Drawing.Point(588, 28);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnEditContact.Size = new System.Drawing.Size(126, 38);
            this.btnEditContact.TabIndex = 6;
            this.btnEditContact.Text = "Cập nhật";
            this.btnEditContact.Click += new System.EventHandler(this.btnEditContact_Click);
            // 
            // txtAddressValue
            // 
            this.txtAddressValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtAddressValue.BorderRadius = 7;
            this.txtAddressValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressValue.DefaultText = "Q. Bình Thạnh, TP.HCM";
            this.txtAddressValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtAddressValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtAddressValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtAddressValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblAddressValue.Text = "Q. Bình Thạnh, TP.HCM";
            this.lblAddressValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            this.txtAddressValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtAddressValue.Location = new System.Drawing.Point(382, 94);
            this.txtAddressValue.Name = "txtAddressValue";
            this.txtAddressValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.txtAddressValue.PlaceholderText = "";
            this.txtAddressValue.SelectedText = "";
            this.txtAddressValue.Size = new System.Drawing.Size(332, 36);
            this.txtAddressValue.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblAddress.Location = new System.Drawing.Point(382, 70);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(220, 18);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "ĐỊA CHỈ CƯ TRÚ";
            // 
            // lblContactPhoneValue
            // 
            this.lblContactPhoneValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.lblContactPhoneValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblContactPhoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblContactPhoneValue.Location = new System.Drawing.Point(34, 94);
            this.lblContactPhoneValue.Name = "lblContactPhoneValue";
            this.lblContactPhoneValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblContactPhoneValue.Size = new System.Drawing.Size(300, 36);
            this.lblContactPhoneValue.TabIndex = 3;
            this.lblContactPhoneValue.Text = "090 123 4567";
            this.lblContactPhoneValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtContactPhoneValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtContactPhoneValue.BorderRadius = 7;
            this.txtContactPhoneValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContactPhoneValue.DefaultText = "090 123 4567";
            this.txtContactPhoneValue.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtContactPhoneValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtContactPhoneValue.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.txtContactPhoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtContactPhoneValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.txtContactPhoneValue.Location = new System.Drawing.Point(34, 94);
            this.txtContactPhoneValue.Name = "txtContactPhoneValue";
            this.txtContactPhoneValue.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.txtContactPhoneValue.PlaceholderText = "";
            this.txtContactPhoneValue.SelectedText = "";
            this.txtContactPhoneValue.Size = new System.Drawing.Size(300, 36);
            this.txtContactPhoneValue.TabIndex = 3;
            // 
            // lblContactPhone
            // 
            this.lblContactPhone.Font = new System.Drawing.Font("Segoe UI", 8.3F, System.Drawing.FontStyle.Bold);
            this.lblContactPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblContactPhone.Location = new System.Drawing.Point(34, 70);
            this.lblContactPhone.Name = "lblContactPhone";
            this.lblContactPhone.Size = new System.Drawing.Size(220, 18);
            this.lblContactPhone.TabIndex = 2;
            this.lblContactPhone.Text = "SỐ ĐIỆN THOẠI";
            // 
            // lblContactTitle
            // 
            this.lblContactTitle.AutoSize = true;
            this.lblContactTitle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblContactTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblContactTitle.Location = new System.Drawing.Point(32, 17);
            this.lblContactTitle.Name = "lblContactTitle";
            this.lblContactTitle.Size = new System.Drawing.Size(140, 21);
            this.lblContactTitle.TabIndex = 0;
            this.lblContactTitle.Text = "Thông tin liên hệ";
            // 
            // pnlSecurity
            // 
            this.pnlSecurity.BackColor = System.Drawing.Color.Transparent;
            this.pnlSecurity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlSecurity.BorderRadius = 14;
            this.pnlSecurity.BorderThickness = 1;
            this.pnlSecurity.Controls.Add(this.btnChangePassword);
            this.pnlSecurity.Controls.Add(this.lblPassSub);
            this.pnlSecurity.Controls.Add(this.lblPassTitle);
            this.pnlSecurity.Controls.Add(this.lblSecurityTitle);
            this.pnlSecurity.FillColor = System.Drawing.Color.White;
            this.pnlSecurity.Location = new System.Drawing.Point(354, 416);
            this.pnlSecurity.Name = "pnlSecurity";
            this.pnlSecurity.Size = new System.Drawing.Size(748, 113);
            this.pnlSecurity.TabIndex = 3;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BorderRadius = 9;
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(208)))), ((int)(((byte)(203)))));
            this.btnChangePassword.DisabledState.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnChangePassword.Location = new System.Drawing.Point(588, 53);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnChangePassword.Size = new System.Drawing.Size(142, 40);
            this.btnChangePassword.TabIndex = 8;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblPassSub
            // 
            this.lblPassSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPassSub.Location = new System.Drawing.Point(34, 75);
            this.lblPassSub.Name = "lblPassSub";
            this.lblPassSub.Size = new System.Drawing.Size(394, 22);
            this.lblPassSub.TabIndex = 3;
            this.lblPassSub.Text = "Đổi lần cuối: 02/03/2026";
            // 
            // lblPassTitle
            // 
            this.lblPassTitle.AutoSize = true;
            this.lblPassTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPassTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblPassTitle.Location = new System.Drawing.Point(34, 53);
            this.lblPassTitle.Name = "lblPassTitle";
            this.lblPassTitle.Size = new System.Drawing.Size(71, 19);
            this.lblPassTitle.TabIndex = 2;
            this.lblPassTitle.Text = "Mật khẩu";
            // 
            // lblSecurityTitle
            // 
            this.lblSecurityTitle.AutoSize = true;
            this.lblSecurityTitle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblSecurityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurityTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblSecurityTitle.Location = new System.Drawing.Point(32, 18);
            this.lblSecurityTitle.Name = "lblSecurityTitle";
            this.lblSecurityTitle.Size = new System.Drawing.Size(149, 21);
            this.lblSecurityTitle.TabIndex = 0;
            this.lblSecurityTitle.Text = "Bảo mật tài khoản";
            // 
            // pnlActivity
            // 
            this.pnlActivity.BackColor = System.Drawing.Color.Transparent;
            this.pnlActivity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlActivity.BorderRadius = 14;
            this.pnlActivity.BorderThickness = 1;
            this.pnlActivity.Controls.Add(this.flpRecentActivities);
            this.pnlActivity.Controls.Add(this.lblActivityTitle);
            this.pnlActivity.FillColor = System.Drawing.Color.White;
            this.pnlActivity.Location = new System.Drawing.Point(354, 543);
            this.pnlActivity.Name = "pnlActivity";
            this.pnlActivity.Size = new System.Drawing.Size(748, 224);
            this.pnlActivity.TabIndex = 4;
            // 
            // flpRecentActivities
            // 
            this.flpRecentActivities.AutoScroll = true;
            this.flpRecentActivities.BackColor = System.Drawing.Color.Transparent;
            this.flpRecentActivities.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRecentActivities.Location = new System.Drawing.Point(32, 51);
            this.flpRecentActivities.Name = "flpRecentActivities";
            this.flpRecentActivities.Size = new System.Drawing.Size(695, 158);
            this.flpRecentActivities.TabIndex = 11;
            this.flpRecentActivities.WrapContents = false;
            // 
            // lblActivityTitle
            // 
            this.lblActivityTitle.AutoSize = true;
            this.lblActivityTitle.BackColor = System.Drawing.Color.MediumAquamarine;
            this.lblActivityTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActivityTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblActivityTitle.Location = new System.Drawing.Point(32, 15);
            this.lblActivityTitle.Name = "lblActivityTitle";
            this.lblActivityTitle.Size = new System.Drawing.Size(156, 21);
            this.lblActivityTitle.TabIndex = 0;
            this.lblActivityTitle.Text = "Hoạt động gần đây";
            // 
            // ucHSCN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlActivity);
            this.Controls.Add(this.pnlSecurity);
            this.Controls.Add(this.pnlContact);
            this.Controls.Add(this.pnlProfessional);
            this.Controls.Add(this.pnlProfile);
            this.Name = "ucHSCN";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlProfile.ResumeLayout(false);
            this.pnlPatientCard.ResumeLayout(false);
            this.pnlRelatedCard.ResumeLayout(false);
            this.pnlProfessional.ResumeLayout(false);
            this.pnlProfessional.PerformLayout();
            this.pnlContact.ResumeLayout(false);
            this.pnlContact.PerformLayout();
            this.pnlSecurity.ResumeLayout(false);
            this.pnlSecurity.PerformLayout();
            this.pnlActivity.ResumeLayout(false);
            this.pnlActivity.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private Guna.UI2.WinForms.Guna2Panel pnlProfile;
        private System.Windows.Forms.Panel pnlProfileHeader;
        private Guna.UI2.WinForms.Guna2Panel pnlRelatedCard;
        private Guna.UI2.WinForms.Guna2Panel pnlPatientCard;
        private System.Windows.Forms.Label lblProfileStatus;
        private System.Windows.Forms.Label lblPatientStatCaption;
        private System.Windows.Forms.Label lblPatientStat;
        private System.Windows.Forms.Label lblRelatedStatCaption;
        private System.Windows.Forms.Label lblRelatedStat;
        private System.Windows.Forms.Label lblProfileDept;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblAvatar;
        private Guna.UI2.WinForms.Guna2Panel pnlProfessional;
        private System.Windows.Forms.Label lblSpecFacilityValue;
        private System.Windows.Forms.Label lblSpecFacility;
        private System.Windows.Forms.Label lblSpecDeptValue;
        private System.Windows.Forms.Label lblSpecDept;
        private System.Windows.Forms.Label lblSpecCodeValue;
        private System.Windows.Forms.Label lblSpecCode;
        private System.Windows.Forms.Label lblSpecRoleValue;
        private System.Windows.Forms.Label lblSpecRole;
        private System.Windows.Forms.Label lblSpecNameValue;
        private System.Windows.Forms.Label lblSpecName;
        private System.Windows.Forms.Label lblProfessionalTitle;
        private System.Windows.Forms.Label lblLockTag;
        private Guna.UI2.WinForms.Guna2Panel pnlContact;
        private Guna.UI2.WinForms.Guna2Button btnEditContact;
        private Guna.UI2.WinForms.Guna2TextBox txtAddressValue;
        private System.Windows.Forms.Label lblAddressValue;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtContactPhoneValue;
        private System.Windows.Forms.Label lblContactPhoneValue;
        private System.Windows.Forms.Label lblContactPhone;
        private System.Windows.Forms.Label lblContactTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlSecurity;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private System.Windows.Forms.Label lblPassSub;
        private System.Windows.Forms.Label lblPassTitle;
        private System.Windows.Forms.Label lblSecurityTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlActivity;
        private System.Windows.Forms.FlowLayoutPanel flpRecentActivities;
        private System.Windows.Forms.Label lblActivityTitle;
    }
}

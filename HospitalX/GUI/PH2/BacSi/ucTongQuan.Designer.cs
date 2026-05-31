namespace HospitalX.GUI.PH2.BacSi
{
    partial class ucTongQuan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlWelcome = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWelcomeAvatar = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.pnlKpiHsba = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiHsbaIcon = new System.Windows.Forms.Label();
            this.lblKpiHsbaTrend = new System.Windows.Forms.Label();
            this.lblKpiHsbaValue = new System.Windows.Forms.Label();
            this.lblKpiHsbaCaption = new System.Windows.Forms.Label();
            this.pnlKpiPending = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiPendingIcon = new System.Windows.Forms.Label();
            this.lblKpiPendingTrend = new System.Windows.Forms.Label();
            this.lblKpiPendingValue = new System.Windows.Forms.Label();
            this.lblKpiPendingCaption = new System.Windows.Forms.Label();
            this.pnlKpiDone = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiDoneIcon = new System.Windows.Forms.Label();
            this.lblKpiDoneTrend = new System.Windows.Forms.Label();
            this.lblKpiDoneValue = new System.Windows.Forms.Label();
            this.lblKpiDoneCaption = new System.Windows.Forms.Label();
            this.pnlKpiAlert = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKpiAlertIcon = new System.Windows.Forms.Label();
            this.lblKpiAlertTrend = new System.Windows.Forms.Label();
            this.lblKpiAlertValue = new System.Windows.Forms.Label();
            this.lblKpiAlertCaption = new System.Windows.Forms.Label();
            this.pnlRecent = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.lblRecentSub = new System.Windows.Forms.Label();
            this.btnViewAll = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRecentHsba = new System.Windows.Forms.DataGridView();
            this.colHsbaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlWelcome.SuspendLayout();
            this.pnlKpiHsba.SuspendLayout();
            this.pnlKpiPending.SuspendLayout();
            this.pnlKpiDone.SuspendLayout();
            this.pnlKpiAlert.SuspendLayout();
            this.pnlRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentHsba)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWelcome
            // 
            this.pnlWelcome.BackColor = System.Drawing.Color.Transparent;
            this.pnlWelcome.BorderRadius = 14;
            this.pnlWelcome.Controls.Add(this.lblWelcomeAvatar);
            this.pnlWelcome.Controls.Add(this.lblWelcomeTitle);
            this.pnlWelcome.Controls.Add(this.lblWelcomeSubtitle);
            this.pnlWelcome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlWelcome.Location = new System.Drawing.Point(24, 24);
            this.pnlWelcome.Name = "pnlWelcome";
            this.pnlWelcome.Size = new System.Drawing.Size(1080, 128);
            this.pnlWelcome.TabIndex = 0;
            // 
            // lblWelcomeAvatar
            // 
            this.lblWelcomeAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(132)))), ((int)(((byte)(114)))));
            this.lblWelcomeAvatar.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeAvatar.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeAvatar.Location = new System.Drawing.Point(30, 34);
            this.lblWelcomeAvatar.Name = "lblWelcomeAvatar";
            this.lblWelcomeAvatar.Size = new System.Drawing.Size(64, 60);
            this.lblWelcomeAvatar.TabIndex = 0;
            this.lblWelcomeAvatar.Text = "TH";
            this.lblWelcomeAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.White;
            this.lblWelcomeTitle.Location = new System.Drawing.Point(118, 36);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(338, 32);
            this.lblWelcomeTitle.TabIndex = 1;
            this.lblWelcomeTitle.Text = "Chào buổi sáng, Bác sĩ Hằng";
            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.AutoSize = true;
            this.lblWelcomeSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(242)))), ((int)(((byte)(235)))));
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(121, 74);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(426, 19);
            this.lblWelcomeSubtitle.TabIndex = 2;
            this.lblWelcomeSubtitle.Text = "Hôm nay bạn có 5 bệnh nhân cần khám và 3 đơn thuốc cần xem lại.";
            // 
            // pnlKpiHsba
            // 
            this.pnlKpiHsba.BackColor = System.Drawing.Color.Transparent;
            this.pnlKpiHsba.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlKpiHsba.BorderRadius = 12;
            this.pnlKpiHsba.BorderThickness = 1;
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaIcon);
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaTrend);
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaValue);
            this.pnlKpiHsba.Controls.Add(this.lblKpiHsbaCaption);
            this.pnlKpiHsba.FillColor = System.Drawing.Color.White;
            this.pnlKpiHsba.Location = new System.Drawing.Point(24, 178);
            this.pnlKpiHsba.Name = "pnlKpiHsba";
            this.pnlKpiHsba.Size = new System.Drawing.Size(258, 138);
            this.pnlKpiHsba.TabIndex = 1;
            // 
            // lblKpiHsbaIcon
            // 
            this.lblKpiHsbaIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblKpiHsbaIcon.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKpiHsbaIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblKpiHsbaIcon.Location = new System.Drawing.Point(22, 20);
            this.lblKpiHsbaIcon.Name = "lblKpiHsbaIcon";
            this.lblKpiHsbaIcon.Size = new System.Drawing.Size(42, 42);
            this.lblKpiHsbaIcon.TabIndex = 0;
            this.lblKpiHsbaIcon.Text = "HS";
            this.lblKpiHsbaIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiHsbaTrend
            // 
            this.lblKpiHsbaTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblKpiHsbaTrend.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiHsbaTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblKpiHsbaTrend.Location = new System.Drawing.Point(172, 24);
            this.lblKpiHsbaTrend.Name = "lblKpiHsbaTrend";
            this.lblKpiHsbaTrend.Size = new System.Drawing.Size(64, 24);
            this.lblKpiHsbaTrend.TabIndex = 1;
            this.lblKpiHsbaTrend.Text = "▲ 2";
            this.lblKpiHsbaTrend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiHsbaValue
            // 
            this.lblKpiHsbaValue.AutoSize = true;
            this.lblKpiHsbaValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiHsbaValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblKpiHsbaValue.Location = new System.Drawing.Point(24, 68);
            this.lblKpiHsbaValue.Name = "lblKpiHsbaValue";
            this.lblKpiHsbaValue.Size = new System.Drawing.Size(56, 45);
            this.lblKpiHsbaValue.TabIndex = 2;
            this.lblKpiHsbaValue.Text = "12";
            // 
            // lblKpiHsbaCaption
            // 
            this.lblKpiHsbaCaption.AutoSize = true;
            this.lblKpiHsbaCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiHsbaCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKpiHsbaCaption.Location = new System.Drawing.Point(26, 112);
            this.lblKpiHsbaCaption.Name = "lblKpiHsbaCaption";
            this.lblKpiHsbaCaption.Size = new System.Drawing.Size(168, 15);
            this.lblKpiHsbaCaption.TabIndex = 3;
            this.lblKpiHsbaCaption.Text = "Hồ sơ bệnh án đang phụ trách";
            // 
            // pnlKpiPending
            // 
            this.pnlKpiPending.BackColor = System.Drawing.Color.Transparent;
            this.pnlKpiPending.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlKpiPending.BorderRadius = 12;
            this.pnlKpiPending.BorderThickness = 1;
            this.pnlKpiPending.Controls.Add(this.lblKpiPendingIcon);
            this.pnlKpiPending.Controls.Add(this.lblKpiPendingTrend);
            this.pnlKpiPending.Controls.Add(this.lblKpiPendingValue);
            this.pnlKpiPending.Controls.Add(this.lblKpiPendingCaption);
            this.pnlKpiPending.FillColor = System.Drawing.Color.White;
            this.pnlKpiPending.Location = new System.Drawing.Point(298, 178);
            this.pnlKpiPending.Name = "pnlKpiPending";
            this.pnlKpiPending.Size = new System.Drawing.Size(258, 138);
            this.pnlKpiPending.TabIndex = 2;
            // 
            // lblKpiPendingIcon
            // 
            this.lblKpiPendingIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(220)))));
            this.lblKpiPendingIcon.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendingIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(168)))), ((int)(((byte)(56)))));
            this.lblKpiPendingIcon.Location = new System.Drawing.Point(22, 20);
            this.lblKpiPendingIcon.Name = "lblKpiPendingIcon";
            this.lblKpiPendingIcon.Size = new System.Drawing.Size(42, 42);
            this.lblKpiPendingIcon.TabIndex = 0;
            this.lblKpiPendingIcon.Text = "TG";
            this.lblKpiPendingIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiPendingTrend
            // 
            this.lblKpiPendingTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lblKpiPendingTrend.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendingTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKpiPendingTrend.Location = new System.Drawing.Point(162, 24);
            this.lblKpiPendingTrend.Name = "lblKpiPendingTrend";
            this.lblKpiPendingTrend.Size = new System.Drawing.Size(74, 24);
            this.lblKpiPendingTrend.TabIndex = 1;
            this.lblKpiPendingTrend.Text = "Hôm nay";
            this.lblKpiPendingTrend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiPendingValue
            // 
            this.lblKpiPendingValue.AutoSize = true;
            this.lblKpiPendingValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiPendingValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblKpiPendingValue.Location = new System.Drawing.Point(24, 68);
            this.lblKpiPendingValue.Name = "lblKpiPendingValue";
            this.lblKpiPendingValue.Size = new System.Drawing.Size(38, 45);
            this.lblKpiPendingValue.TabIndex = 2;
            this.lblKpiPendingValue.Text = "3";
            // 
            // lblKpiPendingCaption
            // 
            this.lblKpiPendingCaption.AutoSize = true;
            this.lblKpiPendingCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiPendingCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKpiPendingCaption.Location = new System.Drawing.Point(26, 112);
            this.lblKpiPendingCaption.Name = "lblKpiPendingCaption";
            this.lblKpiPendingCaption.Size = new System.Drawing.Size(162, 15);
            this.lblKpiPendingCaption.TabIndex = 3;
            this.lblKpiPendingCaption.Text = "Đang chờ kết quả xét nghiệm";
            // 
            // pnlKpiDone
            // 
            this.pnlKpiDone.BackColor = System.Drawing.Color.Transparent;
            this.pnlKpiDone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlKpiDone.BorderRadius = 12;
            this.pnlKpiDone.BorderThickness = 1;
            this.pnlKpiDone.Controls.Add(this.lblKpiDoneIcon);
            this.pnlKpiDone.Controls.Add(this.lblKpiDoneTrend);
            this.pnlKpiDone.Controls.Add(this.lblKpiDoneValue);
            this.pnlKpiDone.Controls.Add(this.lblKpiDoneCaption);
            this.pnlKpiDone.FillColor = System.Drawing.Color.White;
            this.pnlKpiDone.Location = new System.Drawing.Point(572, 178);
            this.pnlKpiDone.Name = "pnlKpiDone";
            this.pnlKpiDone.Size = new System.Drawing.Size(258, 138);
            this.pnlKpiDone.TabIndex = 3;
            // 
            // lblKpiDoneIcon
            // 
            this.lblKpiDoneIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(248)))), ((int)(((byte)(246)))));
            this.lblKpiDoneIcon.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKpiDoneIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(181)))), ((int)(((byte)(160)))));
            this.lblKpiDoneIcon.Location = new System.Drawing.Point(22, 20);
            this.lblKpiDoneIcon.Name = "lblKpiDoneIcon";
            this.lblKpiDoneIcon.Size = new System.Drawing.Size(42, 42);
            this.lblKpiDoneIcon.TabIndex = 0;
            this.lblKpiDoneIcon.Text = "OK";
            this.lblKpiDoneIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiDoneTrend
            // 
            this.lblKpiDoneTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.lblKpiDoneTrend.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiDoneTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblKpiDoneTrend.Location = new System.Drawing.Point(172, 24);
            this.lblKpiDoneTrend.Name = "lblKpiDoneTrend";
            this.lblKpiDoneTrend.Size = new System.Drawing.Size(64, 24);
            this.lblKpiDoneTrend.TabIndex = 1;
            this.lblKpiDoneTrend.Text = "▲ 5";
            this.lblKpiDoneTrend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiDoneValue
            // 
            this.lblKpiDoneValue.AutoSize = true;
            this.lblKpiDoneValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiDoneValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblKpiDoneValue.Location = new System.Drawing.Point(24, 68);
            this.lblKpiDoneValue.Name = "lblKpiDoneValue";
            this.lblKpiDoneValue.Size = new System.Drawing.Size(56, 45);
            this.lblKpiDoneValue.TabIndex = 2;
            this.lblKpiDoneValue.Text = "47";
            // 
            // lblKpiDoneCaption
            // 
            this.lblKpiDoneCaption.AutoSize = true;
            this.lblKpiDoneCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiDoneCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKpiDoneCaption.Location = new System.Drawing.Point(26, 112);
            this.lblKpiDoneCaption.Name = "lblKpiDoneCaption";
            this.lblKpiDoneCaption.Size = new System.Drawing.Size(182, 15);
            this.lblKpiDoneCaption.TabIndex = 3;
            this.lblKpiDoneCaption.Text = "Hồ sơ đã hoàn thành (tháng này)";
            // 
            // pnlKpiAlert
            // 
            this.pnlKpiAlert.BackColor = System.Drawing.Color.Transparent;
            this.pnlKpiAlert.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlKpiAlert.BorderRadius = 12;
            this.pnlKpiAlert.BorderThickness = 1;
            this.pnlKpiAlert.Controls.Add(this.lblKpiAlertIcon);
            this.pnlKpiAlert.Controls.Add(this.lblKpiAlertTrend);
            this.pnlKpiAlert.Controls.Add(this.lblKpiAlertValue);
            this.pnlKpiAlert.Controls.Add(this.lblKpiAlertCaption);
            this.pnlKpiAlert.FillColor = System.Drawing.Color.White;
            this.pnlKpiAlert.Location = new System.Drawing.Point(846, 178);
            this.pnlKpiAlert.Name = "pnlKpiAlert";
            this.pnlKpiAlert.Size = new System.Drawing.Size(258, 138);
            this.pnlKpiAlert.TabIndex = 4;
            // 
            // lblKpiAlertIcon
            // 
            this.lblKpiAlertIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.lblKpiAlertIcon.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblKpiAlertIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblKpiAlertIcon.Location = new System.Drawing.Point(22, 20);
            this.lblKpiAlertIcon.Name = "lblKpiAlertIcon";
            this.lblKpiAlertIcon.Size = new System.Drawing.Size(42, 42);
            this.lblKpiAlertIcon.TabIndex = 0;
            this.lblKpiAlertIcon.Text = "!";
            this.lblKpiAlertIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiAlertTrend
            // 
            this.lblKpiAlertTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.lblKpiAlertTrend.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblKpiAlertTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.lblKpiAlertTrend.Location = new System.Drawing.Point(160, 24);
            this.lblKpiAlertTrend.Name = "lblKpiAlertTrend";
            this.lblKpiAlertTrend.Size = new System.Drawing.Size(76, 24);
            this.lblKpiAlertTrend.TabIndex = 1;
            this.lblKpiAlertTrend.Text = "Cần xử lý";
            this.lblKpiAlertTrend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKpiAlertValue
            // 
            this.lblKpiAlertValue.AutoSize = true;
            this.lblKpiAlertValue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblKpiAlertValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblKpiAlertValue.Location = new System.Drawing.Point(24, 68);
            this.lblKpiAlertValue.Name = "lblKpiAlertValue";
            this.lblKpiAlertValue.Size = new System.Drawing.Size(38, 45);
            this.lblKpiAlertValue.TabIndex = 2;
            this.lblKpiAlertValue.Text = "2";
            // 
            // lblKpiAlertCaption
            // 
            this.lblKpiAlertCaption.AutoSize = true;
            this.lblKpiAlertCaption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKpiAlertCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKpiAlertCaption.Location = new System.Drawing.Point(26, 112);
            this.lblKpiAlertCaption.Name = "lblKpiAlertCaption";
            this.lblKpiAlertCaption.Size = new System.Drawing.Size(129, 15);
            this.lblKpiAlertCaption.TabIndex = 3;
            this.lblKpiAlertCaption.Text = "Cảnh báo dị ứng thuốc";
            // 
            // pnlRecent
            // 
            this.pnlRecent.BackColor = System.Drawing.Color.Transparent;
            this.pnlRecent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRecent.BorderRadius = 12;
            this.pnlRecent.BorderThickness = 1;
            this.pnlRecent.Controls.Add(this.lblRecentTitle);
            this.pnlRecent.Controls.Add(this.lblRecentSub);
            this.pnlRecent.Controls.Add(this.btnViewAll);
            this.pnlRecent.Controls.Add(this.dgvRecentHsba);
            this.pnlRecent.FillColor = System.Drawing.Color.White;
            this.pnlRecent.Location = new System.Drawing.Point(24, 342);
            this.pnlRecent.Name = "pnlRecent";
            this.pnlRecent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRecent.Size = new System.Drawing.Size(1080, 430);
            this.pnlRecent.TabIndex = 5;
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblRecentTitle.Location = new System.Drawing.Point(28, 20);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(217, 25);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "Hồ sơ bệnh án gần đây";
            // 
            // lblRecentSub
            // 
            this.lblRecentSub.AutoSize = true;
            this.lblRecentSub.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecentSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblRecentSub.Location = new System.Drawing.Point(30, 50);
            this.lblRecentSub.Name = "lblRecentSub";
            this.lblRecentSub.Size = new System.Drawing.Size(187, 15);
            this.lblRecentSub.TabIndex = 1;
            this.lblRecentSub.Text = "Các HSBA mà bạn đang phụ trách";
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.Color.Transparent;
            this.btnViewAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnViewAll.BorderRadius = 8;
            this.btnViewAll.BorderThickness = 1;
            this.btnViewAll.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(208)))), ((int)(((byte)(203)))));
            this.btnViewAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnViewAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnViewAll.FillColor = System.Drawing.Color.White;
            this.btnViewAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnViewAll.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnViewAll.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnViewAll.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnViewAll.Location = new System.Drawing.Point(932, 26);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewAll.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnViewAll.Size = new System.Drawing.Size(112, 34);
            this.btnViewAll.TabIndex = 2;
            this.btnViewAll.Text = "Xem tất cả →";
            // 
            // dgvRecentHsba
            // 
            this.dgvRecentHsba.AllowUserToAddRows = false;
            this.dgvRecentHsba.AllowUserToDeleteRows = false;
            this.dgvRecentHsba.AllowUserToResizeColumns = false;
            this.dgvRecentHsba.AllowUserToResizeRows = false;
            this.dgvRecentHsba.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecentHsba.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecentHsba.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecentHsba.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecentHsba.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecentHsba.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRecentHsba.ColumnHeadersHeight = 44;
            this.dgvRecentHsba.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHsbaId,
            this.colPatient,
            this.colDate,
            this.colStatus,
            this.colAction});
            this.dgvRecentHsba.EnableHeadersVisualStyles = false;
            this.dgvRecentHsba.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvRecentHsba.Location = new System.Drawing.Point(24, 82);
            this.dgvRecentHsba.MultiSelect = false;
            this.dgvRecentHsba.Name = "dgvRecentHsba";
            this.dgvRecentHsba.ReadOnly = true;
            this.dgvRecentHsba.RowHeadersVisible = false;
            this.dgvRecentHsba.RowTemplate.Height = 68;
            this.dgvRecentHsba.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentHsba.Size = new System.Drawing.Size(1032, 326);
            this.dgvRecentHsba.TabIndex = 3;
            this.dgvRecentHsba.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvRecentHsba_CellPainting);
            // 
            // colHsbaId
            // 
            this.colHsbaId.HeaderText = "MÃ HSBA";
            this.colHsbaId.Name = "colHsbaId";
            this.colHsbaId.ReadOnly = true;
            this.colHsbaId.FillWeight = 13F;
            // 
            // colPatient
            // 
            this.colPatient.HeaderText = "BỆNH NHÂN";
            this.colPatient.Name = "colPatient";
            this.colPatient.ReadOnly = true;
            this.colPatient.FillWeight = 34F;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "NGÀY LẬP";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.FillWeight = 16F;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.FillWeight = 26F;
            // 
            // colAction
            // 
            this.colAction.HeaderText = "THAO TÁC";
            this.colAction.Name = "colAction";
            this.colAction.ReadOnly = true;
            this.colAction.FillWeight = 11F;
            // 
            // ucTongQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlRecent);
            this.Controls.Add(this.pnlKpiAlert);
            this.Controls.Add(this.pnlKpiDone);
            this.Controls.Add(this.pnlKpiPending);
            this.Controls.Add(this.pnlKpiHsba);
            this.Controls.Add(this.pnlWelcome);
            this.Name = "ucTongQuan";
            this.Size = new System.Drawing.Size(1128, 782);
            this.Load += new System.EventHandler(this.ucTongQuan_Load);
            this.pnlWelcome.ResumeLayout(false);
            this.pnlWelcome.PerformLayout();
            this.pnlKpiHsba.ResumeLayout(false);
            this.pnlKpiHsba.PerformLayout();
            this.pnlKpiPending.ResumeLayout(false);
            this.pnlKpiPending.PerformLayout();
            this.pnlKpiDone.ResumeLayout(false);
            this.pnlKpiDone.PerformLayout();
            this.pnlKpiAlert.ResumeLayout(false);
            this.pnlKpiAlert.PerformLayout();
            this.pnlRecent.ResumeLayout(false);
            this.pnlRecent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentHsba)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnlWelcome;
        private System.Windows.Forms.Label lblWelcomeAvatar;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblWelcomeSubtitle;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiHsba;
        private System.Windows.Forms.Label lblKpiHsbaIcon;
        private System.Windows.Forms.Label lblKpiHsbaTrend;
        private System.Windows.Forms.Label lblKpiHsbaValue;
        private System.Windows.Forms.Label lblKpiHsbaCaption;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiPending;
        private System.Windows.Forms.Label lblKpiPendingIcon;
        private System.Windows.Forms.Label lblKpiPendingTrend;
        private System.Windows.Forms.Label lblKpiPendingValue;
        private System.Windows.Forms.Label lblKpiPendingCaption;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiDone;
        private System.Windows.Forms.Label lblKpiDoneIcon;
        private System.Windows.Forms.Label lblKpiDoneTrend;
        private System.Windows.Forms.Label lblKpiDoneValue;
        private System.Windows.Forms.Label lblKpiDoneCaption;
        private Guna.UI2.WinForms.Guna2Panel pnlKpiAlert;
        private System.Windows.Forms.Label lblKpiAlertIcon;
        private System.Windows.Forms.Label lblKpiAlertTrend;
        private System.Windows.Forms.Label lblKpiAlertValue;
        private System.Windows.Forms.Label lblKpiAlertCaption;
        private Guna.UI2.WinForms.Guna2Panel pnlRecent;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.Label lblRecentSub;
        private Guna.UI2.WinForms.Guna2Button btnViewAll;
        private System.Windows.Forms.DataGridView dgvRecentHsba;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHsbaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAction;
    }
}

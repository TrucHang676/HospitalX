namespace HospitalX.GUI.PH2.QuanTriVien
{
    partial class ucSaoLuuPhucHoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.pnlHistory = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colBackupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBackupStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHistoryHeader = new System.Windows.Forms.Panel();
            this.lblHistoryTotal = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlBackupLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlBackupProgress = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBackupStatus = new System.Windows.Forms.Label();
            this.lblBackupPercent = new System.Windows.Forms.Label();
            this.progressBackup = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.btnDryRun = new Guna.UI2.WinForms.Guna2Button();
            this.btnStartBackup = new Guna.UI2.WinForms.Guna2Button();
            this.pnlInfoAuto = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfoAutoTitle = new System.Windows.Forms.Label();
            this.lblInfoAutoValue = new System.Windows.Forms.Label();
            this.pnlInfoDir = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfoDirTitle = new System.Windows.Forms.Label();
            this.lblInfoDirValue = new System.Windows.Forms.Label();
            this.pnlInfoStats = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfoStatsTitle = new System.Windows.Forms.Label();
            this.lblInfoStatsValue = new System.Windows.Forms.Label();
            this.lblSeparatorBackup = new System.Windows.Forms.Label();
            this.lblManualTitle = new System.Windows.Forms.Label();
            this.pnlRestore = new System.Windows.Forms.Panel();
            this.pnlRestoreRight = new Guna.UI2.WinForms.Guna2Panel();
            this.txtConsole = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStep5 = new System.Windows.Forms.Label();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblRestoreStatus = new System.Windows.Forms.Label();
            this.lblRestorePercent = new System.Windows.Forms.Label();
            this.progressRestore = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblRestoreProgressTitle = new System.Windows.Forms.Label();
            this.pnlRestoreLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.btnStartRestore = new Guna.UI2.WinForms.Guna2Button();
            this.dtpPointInTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblPointInTime = new System.Windows.Forms.Label();
            this.flowRestoreCards = new System.Windows.Forms.FlowLayoutPanel();
            this.lblRestoreListTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabRestore = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabBackup = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRoot.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlHistoryHeader.SuspendLayout();
            this.pnlBackupLeft.SuspendLayout();
            this.pnlBackupProgress.SuspendLayout();
            this.pnlInfoAuto.SuspendLayout();
            this.pnlInfoDir.SuspendLayout();
            this.pnlInfoStats.SuspendLayout();
            this.pnlRestore.SuspendLayout();
            this.pnlRestoreRight.SuspendLayout();
            this.pnlRestoreLeft.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // msgDialog
            // 
            this.msgDialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.msgDialog.Caption = null;
            this.msgDialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.msgDialog.Parent = null;
            this.msgDialog.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.msgDialog.Text = null;
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.pnlRestore);
            this.pnlRoot.Controls.Add(this.pnlBackup);
            this.pnlRoot.Controls.Add(this.pnlContent);
            this.pnlRoot.Controls.Add(this.pnlTabs);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(22, 18, 22, 18);
            this.pnlRoot.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlBackup
            // 
            this.pnlBackup.Controls.Add(this.pnlHistory);
            this.pnlBackup.Controls.Add(this.pnlBackupLeft);
            this.pnlBackup.Location = new System.Drawing.Point(22, 64);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(1084, 680);
            this.pnlBackup.TabIndex = 0;
            // 
            // pnlHistory
            // 
            this.pnlHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlHistory.BorderRadius = 10;
            this.pnlHistory.BorderThickness = 1;
            this.pnlHistory.Controls.Add(this.dgvHistory);
            this.pnlHistory.Controls.Add(this.pnlHistoryHeader);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.FillColor = System.Drawing.Color.White;
            this.pnlHistory.Location = new System.Drawing.Point(389, 0);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Padding = new System.Windows.Forms.Padding(1);
            this.pnlHistory.Size = new System.Drawing.Size(695, 680);
            this.pnlHistory.TabIndex = 1;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(110)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.ColumnHeadersHeight = 34;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBackupId,
            this.colBackupTime,
            this.colBackupType,
            this.colBackupSource,
            this.colBackupSize,
            this.colBackupDuration,
            this.colBackupStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvHistory.Location = new System.Drawing.Point(2, 54);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 42;
            this.dgvHistory.Size = new System.Drawing.Size(690, 622);
            this.dgvHistory.TabIndex = 0;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHistory.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvHistory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvHistory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHistory.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHistory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.ThemeStyle.HeaderStyle.Height = 34;
            this.dgvHistory.ThemeStyle.ReadOnly = true;
            this.dgvHistory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHistory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHistory.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvHistory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvHistory.ThemeStyle.RowsStyle.Height = 42;
            this.dgvHistory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvHistory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colBackupId
            // 
            this.colBackupId.FillWeight = 130F;
            this.colBackupId.HeaderText = "Backup ID";
            this.colBackupId.Name = "colBackupId";
            this.colBackupId.ReadOnly = true;
            // 
            // colBackupTime
            // 
            this.colBackupTime.FillWeight = 105F;
            this.colBackupTime.HeaderText = "Thời gian";
            this.colBackupTime.Name = "colBackupTime";
            this.colBackupTime.ReadOnly = true;
            // 
            // colBackupType
            // 
            this.colBackupType.HeaderText = "Loại";
            this.colBackupType.Name = "colBackupType";
            this.colBackupType.ReadOnly = true;
            // 
            // colBackupSource
            // 
            this.colBackupSource.HeaderText = "Nguồn";
            this.colBackupSource.Name = "colBackupSource";
            this.colBackupSource.ReadOnly = true;
            // 
            // colBackupSize
            // 
            this.colBackupSize.HeaderText = "Kích thước";
            this.colBackupSize.Name = "colBackupSize";
            this.colBackupSize.ReadOnly = true;
            // 
            // colBackupDuration
            // 
            this.colBackupDuration.HeaderText = "Thời lượng";
            this.colBackupDuration.Name = "colBackupDuration";
            this.colBackupDuration.ReadOnly = true;
            // 
            // colBackupStatus
            // 
            this.colBackupStatus.HeaderText = "Trạng thái";
            this.colBackupStatus.Name = "colBackupStatus";
            this.colBackupStatus.ReadOnly = true;
            // 
            // pnlHistoryHeader
            // 
            this.pnlHistoryHeader.BackColor = System.Drawing.Color.White;
            this.pnlHistoryHeader.Controls.Add(this.lblHistoryTotal);
            this.pnlHistoryHeader.Controls.Add(this.lblHistoryTitle);
            this.pnlHistoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistoryHeader.ForeColor = System.Drawing.Color.White;
            this.pnlHistoryHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlHistoryHeader.Name = "pnlHistoryHeader";
            this.pnlHistoryHeader.Size = new System.Drawing.Size(693, 53);
            this.pnlHistoryHeader.TabIndex = 1;
            // 
            // lblHistoryTotal
            // 
            this.lblHistoryTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistoryTotal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblHistoryTotal.Location = new System.Drawing.Point(463, 18);
            this.lblHistoryTotal.Name = "lblHistoryTotal";
            this.lblHistoryTotal.Size = new System.Drawing.Size(210, 20);
            this.lblHistoryTotal.TabIndex = 0;
            this.lblHistoryTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(18, 16);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(123, 21);
            this.lblHistoryTitle.TabIndex = 1;
            this.lblHistoryTitle.Text = "Lịch sử sao lưu";
            // 
            // pnlBackupLeft
            // 
            this.pnlBackupLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlBackupLeft.BorderRadius = 10;
            this.pnlBackupLeft.BorderThickness = 1;
            this.pnlBackupLeft.Controls.Add(this.pnlBackupProgress);
            this.pnlBackupLeft.Controls.Add(this.btnDryRun);
            this.pnlBackupLeft.Controls.Add(this.btnStartBackup);
            this.pnlBackupLeft.Controls.Add(this.lblSeparatorBackup);
            this.pnlBackupLeft.Controls.Add(this.pnlInfoStats);
            this.pnlBackupLeft.Controls.Add(this.pnlInfoDir);
            this.pnlBackupLeft.Controls.Add(this.pnlInfoAuto);
            this.pnlBackupLeft.Controls.Add(this.lblManualTitle);
            this.pnlBackupLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlBackupLeft.FillColor = System.Drawing.Color.White;
            this.pnlBackupLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlBackupLeft.Name = "pnlBackupLeft";
            this.pnlBackupLeft.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBackupLeft.Size = new System.Drawing.Size(389, 680);
            this.pnlBackupLeft.TabIndex = 0;
            // 
            // pnlBackupProgress
            // 
            this.pnlBackupProgress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlBackupProgress.BorderRadius = 8;
            this.pnlBackupProgress.BorderThickness = 1;
            this.pnlBackupProgress.Controls.Add(this.lblBackupStatus);
            this.pnlBackupProgress.Controls.Add(this.lblBackupPercent);
            this.pnlBackupProgress.Controls.Add(this.progressBackup);
            this.pnlBackupProgress.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(251)))));
            this.pnlBackupProgress.Location = new System.Drawing.Point(26, 430);
            this.pnlBackupProgress.Name = "pnlBackupProgress";
            this.pnlBackupProgress.Size = new System.Drawing.Size(330, 96);
            this.pnlBackupProgress.TabIndex = 0;
            this.pnlBackupProgress.Visible = false;
            // 
            // lblBackupStatus
            // 
            this.lblBackupStatus.AutoEllipsis = true;
            this.lblBackupStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupStatus.Font = new System.Drawing.Font("Segoe UI", 8.8F, System.Drawing.FontStyle.Bold);
            this.lblBackupStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblBackupStatus.Location = new System.Drawing.Point(18, 62);
            this.lblBackupStatus.Name = "lblBackupStatus";
            this.lblBackupStatus.Size = new System.Drawing.Size(290, 22);
            this.lblBackupStatus.TabIndex = 0;
            this.lblBackupStatus.Text = "Đang chuẩn bị...";
            // 
            // lblBackupPercent
            // 
            this.lblBackupPercent.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBackupPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblBackupPercent.Location = new System.Drawing.Point(248, 15);
            this.lblBackupPercent.Name = "lblBackupPercent";
            this.lblBackupPercent.Size = new System.Drawing.Size(60, 20);
            this.lblBackupPercent.TabIndex = 1;
            this.lblBackupPercent.Text = "0%";
            this.lblBackupPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBackup
            // 
            this.progressBackup.BorderRadius = 5;
            this.progressBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.progressBackup.Location = new System.Drawing.Point(18, 44);
            this.progressBackup.Name = "progressBackup";
            this.progressBackup.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.progressBackup.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.progressBackup.Size = new System.Drawing.Size(290, 10);
            this.progressBackup.TabIndex = 2;
            this.progressBackup.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // btnDryRun
            // 
            this.btnDryRun.BackColor = System.Drawing.Color.Transparent;
            this.btnDryRun.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnDryRun.BorderRadius = 8;
            this.btnDryRun.BorderThickness = 1;
            this.btnDryRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDryRun.FillColor = System.Drawing.Color.White;
            this.btnDryRun.Font = this.btnStartBackup.Font;
            this.btnDryRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnDryRun.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnDryRun.Location = new System.Drawing.Point(246, 370);
            this.btnDryRun.Name = "btnDryRun";
            this.btnDryRun.Size = new System.Drawing.Size(110, 40);
            this.btnDryRun.TabIndex = 1;
            this.btnDryRun.Text = "Dry Run";
            // 
            // btnStartBackup
            // 
            this.btnStartBackup.BackColor = System.Drawing.Color.Transparent;
            this.btnStartBackup.BorderRadius = 8;
            this.btnStartBackup.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStartBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartBackup.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStartBackup.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnStartBackup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartBackup.ForeColor = System.Drawing.Color.White;
            this.btnStartBackup.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.btnStartBackup.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStartBackup.Location = new System.Drawing.Point(26, 370);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(210, 40);
            this.btnStartBackup.TabIndex = 2;
            this.btnStartBackup.Text = "▶  Bắt đầu sao lưu";
            // 
            // pnlInfoAuto - Card: Lịch tự động
            // 
            this.pnlInfoAuto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(230)))), ((int)(((byte)(220)))));
            this.pnlInfoAuto.BorderRadius = 10;
            this.pnlInfoAuto.BorderThickness = 1;
            this.pnlInfoAuto.Controls.Add(this.lblInfoAutoTitle);
            this.pnlInfoAuto.Controls.Add(this.lblInfoAutoValue);
            this.pnlInfoAuto.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(252)))), ((int)(((byte)(247)))));
            this.pnlInfoAuto.Location = new System.Drawing.Point(26, 65);
            this.pnlInfoAuto.Name = "pnlInfoAuto";
            this.pnlInfoAuto.Size = new System.Drawing.Size(330, 76);
            this.pnlInfoAuto.TabIndex = 20;
            // 
            // lblInfoAutoTitle
            // 
            this.lblInfoAutoTitle.AutoSize = true;
            this.lblInfoAutoTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoAutoTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoAutoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblInfoAutoTitle.Location = new System.Drawing.Point(14, 12);
            this.lblInfoAutoTitle.Name = "lblInfoAutoTitle";
            this.lblInfoAutoTitle.Size = new System.Drawing.Size(120, 15);
            this.lblInfoAutoTitle.TabIndex = 0;
            this.lblInfoAutoTitle.Text = "🕑  LỊCH TỰ ĐỘNG";
            // 
            // lblInfoAutoValue
            // 
            this.lblInfoAutoValue.AutoSize = false;
            this.lblInfoAutoValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoAutoValue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInfoAutoValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblInfoAutoValue.Location = new System.Drawing.Point(14, 36);
            this.lblInfoAutoValue.Name = "lblInfoAutoValue";
            this.lblInfoAutoValue.Size = new System.Drawing.Size(302, 28);
            this.lblInfoAutoValue.TabIndex = 1;
            this.lblInfoAutoValue.Text = "Mỗi ngày lúc 02:00 AM";
            // 
            // pnlInfoDir - Card: Thư mục lưu trữ
            // 
            this.pnlInfoDir.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            this.pnlInfoDir.BorderRadius = 10;
            this.pnlInfoDir.BorderThickness = 1;
            this.pnlInfoDir.Controls.Add(this.lblInfoDirTitle);
            this.pnlInfoDir.Controls.Add(this.lblInfoDirValue);
            this.pnlInfoDir.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlInfoDir.Location = new System.Drawing.Point(26, 155);
            this.pnlInfoDir.Name = "pnlInfoDir";
            this.pnlInfoDir.Size = new System.Drawing.Size(330, 76);
            this.pnlInfoDir.TabIndex = 21;
            // 
            // lblInfoDirTitle
            // 
            this.lblInfoDirTitle.AutoSize = true;
            this.lblInfoDirTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoDirTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoDirTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(130)))), ((int)(((byte)(170)))));
            this.lblInfoDirTitle.Location = new System.Drawing.Point(14, 12);
            this.lblInfoDirTitle.Name = "lblInfoDirTitle";
            this.lblInfoDirTitle.Size = new System.Drawing.Size(120, 15);
            this.lblInfoDirTitle.TabIndex = 0;
            this.lblInfoDirTitle.Text = "📁  THƯ MỤC LƯU TRỮ";
            // 
            // lblInfoDirValue
            // 
            this.lblInfoDirValue.AutoSize = false;
            this.lblInfoDirValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoDirValue.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoDirValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.lblInfoDirValue.Location = new System.Drawing.Point(14, 36);
            this.lblInfoDirValue.Name = "lblInfoDirValue";
            this.lblInfoDirValue.Size = new System.Drawing.Size(302, 28);
            this.lblInfoDirValue.TabIndex = 1;
            this.lblInfoDirValue.Text = "HOSPITALX_BACKUP_DIR";
            // 
            // pnlInfoStats - Card: Thống kê
            // 
            this.pnlInfoStats.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(210)))), ((int)(((byte)(245)))));
            this.pnlInfoStats.BorderRadius = 10;
            this.pnlInfoStats.BorderThickness = 1;
            this.pnlInfoStats.Controls.Add(this.lblInfoStatsTitle);
            this.pnlInfoStats.Controls.Add(this.lblInfoStatsValue);
            this.pnlInfoStats.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.pnlInfoStats.Location = new System.Drawing.Point(26, 245);
            this.pnlInfoStats.Name = "pnlInfoStats";
            this.pnlInfoStats.Size = new System.Drawing.Size(330, 76);
            this.pnlInfoStats.TabIndex = 22;
            // 
            // lblInfoStatsTitle
            // 
            this.lblInfoStatsTitle.AutoSize = true;
            this.lblInfoStatsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoStatsTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblInfoStatsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(100)))), ((int)(((byte)(170)))));
            this.lblInfoStatsTitle.Location = new System.Drawing.Point(14, 12);
            this.lblInfoStatsTitle.Name = "lblInfoStatsTitle";
            this.lblInfoStatsTitle.Size = new System.Drawing.Size(120, 15);
            this.lblInfoStatsTitle.TabIndex = 0;
            this.lblInfoStatsTitle.Text = "📊  THỐNG KÊ BẢN SAO LƯU";
            // 
            // lblInfoStatsValue
            // 
            this.lblInfoStatsValue.AutoSize = false;
            this.lblInfoStatsValue.BackColor = System.Drawing.Color.Transparent;
            this.lblInfoStatsValue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoStatsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(160)))));
            this.lblInfoStatsValue.Location = new System.Drawing.Point(14, 36);
            this.lblInfoStatsValue.Name = "lblInfoStatsValue";
            this.lblInfoStatsValue.Size = new System.Drawing.Size(302, 28);
            this.lblInfoStatsValue.TabIndex = 1;
            this.lblInfoStatsValue.Text = "Đang tải...";
            // 
            // lblSeparatorBackup
            // 
            this.lblSeparatorBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.lblSeparatorBackup.Location = new System.Drawing.Point(26, 340);
            this.lblSeparatorBackup.Name = "lblSeparatorBackup";
            this.lblSeparatorBackup.Size = new System.Drawing.Size(330, 1);
            this.lblSeparatorBackup.TabIndex = 23;
            //
            // 
            // lblManualTitle
            // 
            this.lblManualTitle.AutoSize = true;
            this.lblManualTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblManualTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblManualTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblManualTitle.Location = new System.Drawing.Point(22, 22);
            this.lblManualTitle.Name = "lblManualTitle";
            this.lblManualTitle.Size = new System.Drawing.Size(144, 21);
            this.lblManualTitle.TabIndex = 12;
            this.lblManualTitle.Text = "Sao lưu chủ động";
            // 
            // pnlRestore
            // 
            this.pnlRestore.Controls.Add(this.pnlRestoreRight);
            this.pnlRestore.Controls.Add(this.pnlRestoreLeft);
            this.pnlRestore.Location = new System.Drawing.Point(22, 64);
            this.pnlRestore.Name = "pnlRestore";
            this.pnlRestore.Size = new System.Drawing.Size(1084, 680);
            this.pnlRestore.TabIndex = 1;
            // 
            // pnlRestoreRight
            // 
            this.pnlRestoreRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRestoreRight.BorderRadius = 10;
            this.pnlRestoreRight.BorderThickness = 1;
            this.pnlRestoreRight.Controls.Add(this.txtConsole);
            this.pnlRestoreRight.Controls.Add(this.lblStep5);
            this.pnlRestoreRight.Controls.Add(this.lblStep4);
            this.pnlRestoreRight.Controls.Add(this.lblStep3);
            this.pnlRestoreRight.Controls.Add(this.lblStep2);
            this.pnlRestoreRight.Controls.Add(this.lblStep1);
            this.pnlRestoreRight.Controls.Add(this.lblRestoreStatus);
            this.pnlRestoreRight.Controls.Add(this.lblRestorePercent);
            this.pnlRestoreRight.Controls.Add(this.progressRestore);
            this.pnlRestoreRight.Controls.Add(this.lblRestoreProgressTitle);
            this.pnlRestoreRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRestoreRight.FillColor = System.Drawing.Color.White;
            this.pnlRestoreRight.Location = new System.Drawing.Point(522, 0);
            this.pnlRestoreRight.Name = "pnlRestoreRight";
            this.pnlRestoreRight.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRestoreRight.Size = new System.Drawing.Size(562, 680);
            this.pnlRestoreRight.TabIndex = 1;
            // 
            // txtConsole
            // 
            this.txtConsole.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.txtConsole.BorderRadius = 8;
            this.txtConsole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConsole.DefaultText = "Chưa có tiến trình phục hồi.\r\nKhi khởi động phục hồi, nhật ký RMAN sẽ hiển thị tạ" +
    "i đây.";
            this.txtConsole.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(222)))));
            this.txtConsole.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtConsole.ForeColor = System.Drawing.Color.Black;
            this.txtConsole.Location = new System.Drawing.Point(24, 330);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtConsole.PlaceholderText = "Nhật ký RMAN sẽ xuất hiện tại đây";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.SelectedText = "";
            this.txtConsole.Size = new System.Drawing.Size(504, 327);
            this.txtConsole.TabIndex = 0;
            // 
            // lblStep5
            // 
            this.lblStep5.BackColor = System.Drawing.Color.Transparent;
            this.lblStep5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStep5.Location = new System.Drawing.Point(26, 274);
            this.lblStep5.Name = "lblStep5";
            this.lblStep5.Size = new System.Drawing.Size(460, 28);
            this.lblStep5.TabIndex = 1;
            this.lblStep5.Text = "5. OPEN RESETLOGS";
            // 
            // lblStep4
            // 
            this.lblStep4.BackColor = System.Drawing.Color.Transparent;
            this.lblStep4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStep4.Location = new System.Drawing.Point(26, 237);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(460, 28);
            this.lblStep4.TabIndex = 2;
            this.lblStep4.Text = "4. Recover archive log";
            // 
            // lblStep3
            // 
            this.lblStep3.BackColor = System.Drawing.Color.Transparent;
            this.lblStep3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStep3.Location = new System.Drawing.Point(26, 200);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(460, 28);
            this.lblStep3.TabIndex = 3;
            this.lblStep3.Text = "3. Restore datafiles";
            // 
            // lblStep2
            // 
            this.lblStep2.BackColor = System.Drawing.Color.Transparent;
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStep2.Location = new System.Drawing.Point(26, 163);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(460, 28);
            this.lblStep2.TabIndex = 4;
            this.lblStep2.Text = "2. Tắt DB / MOUNT mode";
            // 
            // lblStep1
            // 
            this.lblStep1.BackColor = System.Drawing.Color.Transparent;
            this.lblStep1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblStep1.Location = new System.Drawing.Point(26, 126);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(460, 28);
            this.lblStep1.TabIndex = 5;
            this.lblStep1.Text = "1. Xác thực bản backup";
            // 
            // lblRestoreStatus
            // 
            this.lblRestoreStatus.AutoSize = true;
            this.lblRestoreStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblRestoreStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRestoreStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblRestoreStatus.Location = new System.Drawing.Point(24, 86);
            this.lblRestoreStatus.Name = "lblRestoreStatus";
            this.lblRestoreStatus.Size = new System.Drawing.Size(52, 15);
            this.lblRestoreStatus.TabIndex = 6;
            this.lblRestoreStatus.Text = "Standby";
            // 
            // lblRestorePercent
            // 
            this.lblRestorePercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRestorePercent.BackColor = System.Drawing.Color.Transparent;
            this.lblRestorePercent.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRestorePercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblRestorePercent.Location = new System.Drawing.Point(448, 24);
            this.lblRestorePercent.Name = "lblRestorePercent";
            this.lblRestorePercent.Size = new System.Drawing.Size(80, 22);
            this.lblRestorePercent.TabIndex = 7;
            this.lblRestorePercent.Text = "0%";
            this.lblRestorePercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressRestore
            // 
            this.progressRestore.BorderRadius = 5;
            this.progressRestore.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.progressRestore.Location = new System.Drawing.Point(24, 60);
            this.progressRestore.Name = "progressRestore";
            this.progressRestore.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.progressRestore.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(148)))), ((int)(((byte)(112)))));
            this.progressRestore.Size = new System.Drawing.Size(492, 12);
            this.progressRestore.TabIndex = 8;
            this.progressRestore.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // lblRestoreProgressTitle
            // 
            this.lblRestoreProgressTitle.AutoSize = true;
            this.lblRestoreProgressTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRestoreProgressTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRestoreProgressTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblRestoreProgressTitle.Location = new System.Drawing.Point(22, 22);
            this.lblRestoreProgressTitle.Name = "lblRestoreProgressTitle";
            this.lblRestoreProgressTitle.Size = new System.Drawing.Size(155, 21);
            this.lblRestoreProgressTitle.TabIndex = 9;
            this.lblRestoreProgressTitle.Text = "Tiến trình phục hồi";
            // 
            // pnlRestoreLeft
            // 
            this.pnlRestoreLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRestoreLeft.BorderRadius = 10;
            this.pnlRestoreLeft.BorderThickness = 1;
            this.pnlRestoreLeft.Controls.Add(this.btnStartRestore);
            this.pnlRestoreLeft.Controls.Add(this.dtpPointInTime);
            this.pnlRestoreLeft.Controls.Add(this.lblPointInTime);
            this.pnlRestoreLeft.Controls.Add(this.flowRestoreCards);
            this.pnlRestoreLeft.Controls.Add(this.lblRestoreListTitle);
            this.pnlRestoreLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRestoreLeft.FillColor = System.Drawing.Color.White;
            this.pnlRestoreLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlRestoreLeft.Name = "pnlRestoreLeft";
            this.pnlRestoreLeft.Padding = new System.Windows.Forms.Padding(20);
            this.pnlRestoreLeft.Size = new System.Drawing.Size(522, 680);
            this.pnlRestoreLeft.TabIndex = 0;
            // 
            // btnStartRestore
            // 
            this.btnStartRestore.BorderColor = System.Drawing.Color.Maroon;
            this.btnStartRestore.BorderRadius = 8;
            this.btnStartRestore.BorderThickness = 2;
            this.btnStartRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartRestore.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnStartRestore.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(230)))), ((int)(((byte)(228)))));
            this.btnStartRestore.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnStartRestore.FillColor = System.Drawing.Color.Brown;
            this.btnStartRestore.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRestore.ForeColor = System.Drawing.Color.White;
            this.btnStartRestore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnStartRestore.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnStartRestore.Location = new System.Drawing.Point(23, 615);
            this.btnStartRestore.Name = "btnStartRestore";
            this.btnStartRestore.PressedColor = System.Drawing.Color.Maroon;
            this.btnStartRestore.Size = new System.Drawing.Size(474, 42);
            this.btnStartRestore.TabIndex = 0;
            this.btnStartRestore.Text = "Khởi động phục hồi CSDL";
            // 
            // dtpPointInTime
            // 
            this.dtpPointInTime.BackColor = System.Drawing.Color.Transparent;
            this.dtpPointInTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.dtpPointInTime.BorderRadius = 8;
            this.dtpPointInTime.BorderThickness = 1;
            this.dtpPointInTime.Checked = true;
            this.dtpPointInTime.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.dtpPointInTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpPointInTime.FillColor = System.Drawing.Color.White;
            this.dtpPointInTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpPointInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPointInTime.Location = new System.Drawing.Point(23, 554);
            this.dtpPointInTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPointInTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPointInTime.Name = "dtpPointInTime";
            this.dtpPointInTime.Size = new System.Drawing.Size(170, 36);
            this.dtpPointInTime.TabIndex = 1;
            this.dtpPointInTime.Value = new System.DateTime(2026, 6, 1, 15, 52, 2, 335);
            // 
            // lblPointInTime
            // 
            this.lblPointInTime.AutoSize = true;
            this.lblPointInTime.BackColor = System.Drawing.Color.Transparent;
            this.lblPointInTime.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPointInTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPointInTime.Location = new System.Drawing.Point(23, 531);
            this.lblPointInTime.Name = "lblPointInTime";
            this.lblPointInTime.Size = new System.Drawing.Size(156, 15);
            this.lblPointInTime.TabIndex = 2;
            this.lblPointInTime.Text = "POINT-IN-TIME RECOVERY";
            // 
            // flowRestoreCards
            // 
            this.flowRestoreCards.AutoScroll = true;
            this.flowRestoreCards.BackColor = System.Drawing.Color.Transparent;
            this.flowRestoreCards.Location = new System.Drawing.Point(24, 58);
            this.flowRestoreCards.Name = "flowRestoreCards";
            this.flowRestoreCards.Size = new System.Drawing.Size(474, 452);
            this.flowRestoreCards.TabIndex = 3;
            // 
            // lblRestoreListTitle
            // 
            this.lblRestoreListTitle.AutoSize = true;
            this.lblRestoreListTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRestoreListTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRestoreListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblRestoreListTitle.Location = new System.Drawing.Point(22, 22);
            this.lblRestoreListTitle.Name = "lblRestoreListTitle";
            this.lblRestoreListTitle.Size = new System.Drawing.Size(143, 21);
            this.lblRestoreListTitle.TabIndex = 4;
            this.lblRestoreListTitle.Text = "Chọn bản backup";
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(22, 64);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1084, 700);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlTabs
            // 
            this.pnlTabs.Controls.Add(this.btnTabRestore);
            this.pnlTabs.Controls.Add(this.btnTabBackup);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabs.Location = new System.Drawing.Point(22, 18);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(1084, 46);
            this.pnlTabs.TabIndex = 3;
            // 
            // btnTabRestore
            // 
            this.btnTabRestore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabRestore.BorderRadius = 8;
            this.btnTabRestore.BorderThickness = 1;
            this.btnTabRestore.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabRestore.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabRestore.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnTabRestore.FillColor = System.Drawing.Color.White;
            this.btnTabRestore.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabRestore.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnTabRestore.Location = new System.Drawing.Point(140, 6);
            this.btnTabRestore.Name = "btnTabRestore";
            this.btnTabRestore.PressedColor = System.Drawing.Color.Teal;
            this.btnTabRestore.Size = new System.Drawing.Size(130, 34);
            this.btnTabRestore.TabIndex = 0;
            this.btnTabRestore.Text = "Phục hồi";
            // 
            // btnTabBackup
            // 
            this.btnTabBackup.BorderRadius = 8;
            this.btnTabBackup.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabBackup.Checked = true;
            this.btnTabBackup.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabBackup.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnTabBackup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabBackup.DisabledState.FillColor = System.Drawing.Color.White;
            this.btnTabBackup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabBackup.FillColor = System.Drawing.Color.White;
            this.btnTabBackup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabBackup.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnTabBackup.Location = new System.Drawing.Point(0, 6);
            this.btnTabBackup.Name = "btnTabBackup";
            this.btnTabBackup.PressedColor = System.Drawing.Color.Teal;
            this.btnTabBackup.Size = new System.Drawing.Size(130, 34);
            this.btnTabBackup.TabIndex = 1;
            this.btnTabBackup.Text = "Sao lưu";
            // 
            // ucSaoLuuPhucHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlRoot);
            this.Name = "ucSaoLuuPhucHoi";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.ResumeLayout(false);
            this.pnlBackup.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlHistoryHeader.ResumeLayout(false);
            this.pnlHistoryHeader.PerformLayout();
            this.pnlBackupLeft.ResumeLayout(false);
            this.pnlBackupLeft.PerformLayout();
            this.pnlBackupProgress.ResumeLayout(false);
            this.pnlInfoAuto.ResumeLayout(false);
            this.pnlInfoAuto.PerformLayout();
            this.pnlInfoDir.ResumeLayout(false);
            this.pnlInfoDir.PerformLayout();
            this.pnlInfoStats.ResumeLayout(false);
            this.pnlInfoStats.PerformLayout();
            this.pnlRestore.ResumeLayout(false);
            this.pnlRestoreRight.ResumeLayout(false);
            this.pnlRestoreRight.PerformLayout();
            this.pnlRestoreLeft.ResumeLayout(false);
            this.pnlRestoreLeft.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlTabs;
        private Guna.UI2.WinForms.Guna2Button btnTabRestore;
        private Guna.UI2.WinForms.Guna2Button btnTabBackup;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlBackup;
        private Guna.UI2.WinForms.Guna2Panel pnlBackupLeft;
        private System.Windows.Forms.Label lblManualTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlInfoAuto;
        private System.Windows.Forms.Label lblInfoAutoTitle;
        private System.Windows.Forms.Label lblInfoAutoValue;
        private Guna.UI2.WinForms.Guna2Panel pnlInfoDir;
        private System.Windows.Forms.Label lblInfoDirTitle;
        private System.Windows.Forms.Label lblInfoDirValue;
        private Guna.UI2.WinForms.Guna2Panel pnlInfoStats;
        private System.Windows.Forms.Label lblInfoStatsTitle;
        private System.Windows.Forms.Label lblInfoStatsValue;
        private System.Windows.Forms.Label lblSeparatorBackup;
        private Guna.UI2.WinForms.Guna2Button btnStartBackup;
        private Guna.UI2.WinForms.Guna2Button btnDryRun;
        private Guna.UI2.WinForms.Guna2Panel pnlBackupProgress;
        private System.Windows.Forms.Label lblBackupStatus;
        private System.Windows.Forms.Label lblBackupPercent;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBackup;
        private Guna.UI2.WinForms.Guna2Panel pnlHistory;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBackupStatus;
        private System.Windows.Forms.Panel pnlHistoryHeader;
        private System.Windows.Forms.Label lblHistoryTotal;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.Panel pnlRestore;
        private Guna.UI2.WinForms.Guna2Panel pnlRestoreLeft;
        private Guna.UI2.WinForms.Guna2Button btnStartRestore;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpPointInTime;
        private System.Windows.Forms.Label lblPointInTime;
        private System.Windows.Forms.FlowLayoutPanel flowRestoreCards;
        private System.Windows.Forms.Label lblRestoreListTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlRestoreRight;
        private Guna.UI2.WinForms.Guna2TextBox txtConsole;
        private System.Windows.Forms.Label lblStep5;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblRestoreStatus;
        private System.Windows.Forms.Label lblRestorePercent;
        private Guna.UI2.WinForms.Guna2ProgressBar progressRestore;
        private System.Windows.Forms.Label lblRestoreProgressTitle;
    }
}

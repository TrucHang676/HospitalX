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
            this.txtBackupTag = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblBackupTag = new System.Windows.Forms.Label();
            this.lblBackupType = new System.Windows.Forms.Label();
            this.cmbCompression = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbDestination = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCompression = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.chkIncremental = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkFull = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblManualTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnTabRestore = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabBackup = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRoot.SuspendLayout();
            this.pnlRestore.SuspendLayout();
            this.pnlRestoreRight.SuspendLayout();
            this.pnlRestoreLeft.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlHistoryHeader.SuspendLayout();
            this.pnlBackupLeft.SuspendLayout();
            this.pnlBackupProgress.SuspendLayout();
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
            this.btnStartRestore.BorderRadius = 8;
            this.btnStartRestore.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.pnlBackupLeft.Controls.Add(this.txtBackupTag);
            this.pnlBackupLeft.Controls.Add(this.lblBackupTag);
            this.pnlBackupLeft.Controls.Add(this.cmbCompression);
            this.pnlBackupLeft.Controls.Add(this.lblCompression);
            this.pnlBackupLeft.Controls.Add(this.cmbDestination);
            this.pnlBackupLeft.Controls.Add(this.lblDestination);
            this.pnlBackupLeft.Controls.Add(this.chkIncremental);
            this.pnlBackupLeft.Controls.Add(this.chkFull);
            this.pnlBackupLeft.Controls.Add(this.lblBackupType);
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
            this.pnlBackupProgress.Location = new System.Drawing.Point(26, 553);
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
            this.btnDryRun.Location = new System.Drawing.Point(246, 487);
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
            this.btnStartBackup.Location = new System.Drawing.Point(26, 487);
            this.btnStartBackup.Name = "btnStartBackup";
            this.btnStartBackup.Size = new System.Drawing.Size(210, 40);
            this.btnStartBackup.TabIndex = 2;
            this.btnStartBackup.Text = "Bắt đầu sao lưu";
            // 
            // txtBackupTag
            // 
            this.txtBackupTag.BackColor = System.Drawing.Color.Transparent;
            this.txtBackupTag.BorderRadius = 8;
            this.txtBackupTag.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBackupTag.DefaultText = "";
            this.txtBackupTag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBackupTag.Location = new System.Drawing.Point(27, 405);
            this.txtBackupTag.Name = "txtBackupTag";
            this.txtBackupTag.PlaceholderText = "Manual_before_upgrade_v2.1";
            this.txtBackupTag.SelectedText = "";
            this.txtBackupTag.Size = new System.Drawing.Size(330, 59);
            this.txtBackupTag.TabIndex = 3;
            // 
            // lblBackupTag
            // 
            this.lblBackupTag.AutoSize = true;
            this.lblBackupTag.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupTag.Font = this.lblBackupType.Font;
            this.lblBackupTag.ForeColor = this.lblBackupType.ForeColor;
            this.lblBackupTag.Location = new System.Drawing.Point(25, 380);
            this.lblBackupTag.Name = "lblBackupTag";
            this.lblBackupTag.Size = new System.Drawing.Size(91, 15);
            this.lblBackupTag.TabIndex = 4;
            this.lblBackupTag.Text = "GHI CHÚ / TAG";
            // 
            // lblBackupType
            // 
            this.lblBackupType.AutoSize = true;
            this.lblBackupType.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupType.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBackupType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblBackupType.Location = new System.Drawing.Point(25, 68);
            this.lblBackupType.Name = "lblBackupType";
            this.lblBackupType.Size = new System.Drawing.Size(88, 15);
            this.lblBackupType.TabIndex = 11;
            this.lblBackupType.Text = "LOẠI SAO LƯU";
            // 
            // cmbCompression
            // 
            this.cmbCompression.BackColor = System.Drawing.Color.Transparent;
            this.cmbCompression.BorderRadius = 8;
            this.cmbCompression.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompression.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbCompression.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbCompression.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbCompression.ForeColor = this.cmbDestination.ForeColor;
            this.cmbCompression.ItemHeight = 30;
            this.cmbCompression.Items.AddRange(new object[] {
            "MEDIUM",
            "HIGH",
            "LOW",
            "Không nén"});
            this.cmbCompression.Location = new System.Drawing.Point(25, 255);
            this.cmbCompression.Name = "cmbCompression";
            this.cmbCompression.Size = new System.Drawing.Size(330, 36);
            this.cmbCompression.StartIndex = 0;
            this.cmbCompression.TabIndex = 5;
            // 
            // cmbDestination
            // 
            this.cmbDestination.BackColor = System.Drawing.Color.Transparent;
            this.cmbDestination.BorderRadius = 8;
            this.cmbDestination.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestination.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbDestination.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbDestination.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDestination.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.cmbDestination.ItemHeight = 30;
            this.cmbDestination.Items.AddRange(new object[] {
            "/backup/oracle/rman",
            "/nas/backup/tier1",
            "/nas/backup/tier2",
            "TAPE_DRIVE_01"});
            this.cmbDestination.Location = new System.Drawing.Point(26, 183);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(330, 36);
            this.cmbDestination.StartIndex = 0;
            this.cmbDestination.TabIndex = 7;
            // 
            // lblCompression
            // 
            this.lblCompression.AutoSize = true;
            this.lblCompression.BackColor = System.Drawing.Color.Transparent;
            this.lblCompression.Font = this.lblBackupType.Font;
            this.lblCompression.ForeColor = this.lblBackupType.ForeColor;
            this.lblCompression.Location = new System.Drawing.Point(26, 231);
            this.lblCompression.Name = "lblCompression";
            this.lblCompression.Size = new System.Drawing.Size(80, 15);
            this.lblCompression.TabIndex = 6;
            this.lblCompression.Text = "NÉN DỮ LIỆU";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.BackColor = System.Drawing.Color.Transparent;
            this.lblDestination.Font = this.lblBackupType.Font;
            this.lblDestination.ForeColor = this.lblBackupType.ForeColor;
            this.lblDestination.Location = new System.Drawing.Point(27, 162);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(90, 15);
            this.lblDestination.TabIndex = 8;
            this.lblDestination.Text = "ĐÍCH LƯU TRỮ";
            // 
            // chkIncremental
            // 
            this.chkIncremental.AutoSize = true;
            this.chkIncremental.BackColor = System.Drawing.Color.Transparent;
            this.chkIncremental.CheckedState.BorderRadius = 0;
            this.chkIncremental.CheckedState.BorderThickness = 0;
            this.chkIncremental.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkIncremental.Font = this.chkFull.Font;
            this.chkIncremental.ForeColor = this.chkFull.ForeColor;
            this.chkIncremental.Location = new System.Drawing.Point(28, 126);
            this.chkIncremental.Name = "chkIncremental";
            this.chkIncremental.Size = new System.Drawing.Size(243, 23);
            this.chkIncremental.TabIndex = 9;
            this.chkIncremental.Text = "INCREMENTAL - Dữ liệu thay đổi";
            this.chkIncremental.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkIncremental.UncheckedState.BorderRadius = 0;
            this.chkIncremental.UncheckedState.BorderThickness = 1;
            this.chkIncremental.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkIncremental.UseVisualStyleBackColor = false;
            // 
            // chkFull
            // 
            this.chkFull.AutoSize = true;
            this.chkFull.BackColor = System.Drawing.Color.Transparent;
            this.chkFull.Checked = true;
            this.chkFull.CheckedState.BorderRadius = 0;
            this.chkFull.CheckedState.BorderThickness = 0;
            this.chkFull.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkFull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFull.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkFull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkFull.Location = new System.Drawing.Point(28, 97);
            this.chkFull.Name = "chkFull";
            this.chkFull.Size = new System.Drawing.Size(165, 23);
            this.chkFull.TabIndex = 10;
            this.chkFull.Text = "FULL - Toàn bộ CSDL";
            this.chkFull.UncheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkFull.UncheckedState.BorderRadius = 0;
            this.chkFull.UncheckedState.BorderThickness = 1;
            this.chkFull.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkFull.UseVisualStyleBackColor = false;
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
            this.pnlRestore.ResumeLayout(false);
            this.pnlRestoreRight.ResumeLayout(false);
            this.pnlRestoreRight.PerformLayout();
            this.pnlRestoreLeft.ResumeLayout(false);
            this.pnlRestoreLeft.PerformLayout();
            this.pnlBackup.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlHistoryHeader.ResumeLayout(false);
            this.pnlHistoryHeader.PerformLayout();
            this.pnlBackupLeft.ResumeLayout(false);
            this.pnlBackupLeft.PerformLayout();
            this.pnlBackupProgress.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblBackupType;
        private Guna.UI2.WinForms.Guna2CheckBox chkFull;
        private Guna.UI2.WinForms.Guna2CheckBox chkIncremental;
        private System.Windows.Forms.Label lblDestination;
        private Guna.UI2.WinForms.Guna2ComboBox cmbDestination;
        private System.Windows.Forms.Label lblCompression;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCompression;
        private System.Windows.Forms.Label lblBackupTag;
        private Guna.UI2.WinForms.Guna2TextBox txtBackupTag;
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

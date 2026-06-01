namespace HospitalX.GUI.PH2.QuanTriVien
{
    partial class ucTrangChu
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
            this.pnlRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRecent = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRecent = new System.Windows.Forms.DataGridView();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlRecentHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecentSub = new System.Windows.Forms.Label();
            this.lblRecentTitle = new System.Windows.Forms.Label();
            this.pnlRight = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTasks = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTask4 = new System.Windows.Forms.Label();
            this.lblTask3 = new System.Windows.Forms.Label();
            this.lblTask2 = new System.Windows.Forms.Label();
            this.lblTask1 = new System.Windows.Forms.Label();
            this.lblTaskTitle = new System.Windows.Forms.Label();
            this.pnlSystem = new Guna.UI2.WinForms.Guna2Panel();
            this.lblInfo6 = new System.Windows.Forms.Label();
            this.lblInfo5 = new System.Windows.Forms.Label();
            this.lblInfo4 = new System.Windows.Forms.Label();
            this.lblInfo3 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlUsers = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUsersSub = new System.Windows.Forms.Label();
            this.lblUsersValue = new System.Windows.Forms.Label();
            this.lblUsersTitle = new System.Windows.Forms.Label();
            this.pnlAudit = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAuditSub = new System.Windows.Forms.Label();
            this.lblAuditValue = new System.Windows.Forms.Label();
            this.lblAuditTitle = new System.Windows.Forms.Label();
            this.pnlBackup = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBackupSub = new System.Windows.Forms.Label();
            this.lblBackupValue = new System.Windows.Forms.Label();
            this.lblBackupTitle = new System.Windows.Forms.Label();
            this.pnlWarn = new Guna.UI2.WinForms.Guna2Panel();
            this.lblWarnSub = new System.Windows.Forms.Label();
            this.lblWarnValue = new System.Windows.Forms.Label();
            this.lblWarnTitle = new System.Windows.Forms.Label();
            this.pnlAlert = new Guna.UI2.WinForms.Guna2Panel();
            this.lblAlert = new System.Windows.Forms.Label();
            this.pnlRoot.SuspendLayout();
            this.pnlRecent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).BeginInit();
            this.pnlRecentHeader.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlTasks.SuspendLayout();
            this.pnlSystem.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlUsers.SuspendLayout();
            this.pnlAudit.SuspendLayout();
            this.pnlBackup.SuspendLayout();
            this.pnlWarn.SuspendLayout();
            this.pnlAlert.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.pnlRecent);
            this.pnlRoot.Controls.Add(this.pnlRight);
            this.pnlRoot.Controls.Add(this.pnlStats);
            this.pnlRoot.Controls.Add(this.pnlAlert);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.pnlRoot.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlRecent
            // 
            this.pnlRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRecent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRecent.BorderRadius = 8;
            this.pnlRecent.BorderThickness = 1;
            this.pnlRecent.Controls.Add(this.dgvRecent);
            this.pnlRecent.Controls.Add(this.pnlRecentHeader);
            this.pnlRecent.FillColor = System.Drawing.Color.White;
            this.pnlRecent.Location = new System.Drawing.Point(20, 280);
            this.pnlRecent.Name = "pnlRecent";
            this.pnlRecent.Size = new System.Drawing.Size(675, 486);
            this.pnlRecent.TabIndex = 4;
            // 
            // dgvRecent
            // 
            this.dgvRecent.AllowUserToAddRows = false;
            this.dgvRecent.AllowUserToDeleteRows = false;
            this.dgvRecent.AllowUserToResizeRows = false;
            this.dgvRecent.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRecent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.dgvRecent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecent.ColumnHeadersHeight = 36;
            this.dgvRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTime,
            this.colEvent,
            this.colLevel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(48)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(48)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecent.EnableHeadersVisualStyles = false;
            this.dgvRecent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(235)))));
            this.dgvRecent.Location = new System.Drawing.Point(0, 62);
            this.dgvRecent.MultiSelect = false;
            this.dgvRecent.Name = "dgvRecent";
            this.dgvRecent.ReadOnly = true;
            this.dgvRecent.RowHeadersVisible = false;
            this.dgvRecent.RowTemplate.Height = 44;
            this.dgvRecent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecent.Size = new System.Drawing.Size(675, 424);
            this.dgvRecent.TabIndex = 1;
            // 
            // colTime
            // 
            this.colTime.FillWeight = 82F;
            this.colTime.HeaderText = "Thời gian";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 105;
            // 
            // colEvent
            // 
            this.colEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEvent.HeaderText = "Hoạt động";
            this.colEvent.Name = "colEvent";
            this.colEvent.ReadOnly = true;
            // 
            // colLevel
            // 
            this.colLevel.HeaderText = "Mức độ";
            this.colLevel.Name = "colLevel";
            this.colLevel.ReadOnly = true;
            this.colLevel.Width = 110;
            // 
            // pnlRecentHeader
            // 
            this.pnlRecentHeader.Controls.Add(this.lblRecentSub);
            this.pnlRecentHeader.Controls.Add(this.lblRecentTitle);
            this.pnlRecentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRecentHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlRecentHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlRecentHeader.Name = "pnlRecentHeader";
            this.pnlRecentHeader.Size = new System.Drawing.Size(675, 62);
            this.pnlRecentHeader.TabIndex = 0;
            // 
            // lblRecentSub
            // 
            this.lblRecentSub.AutoSize = true;
            this.lblRecentSub.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecentSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblRecentSub.Location = new System.Drawing.Point(22, 36);
            this.lblRecentSub.Name = "lblRecentSub";
            this.lblRecentSub.Size = new System.Drawing.Size(247, 15);
            this.lblRecentSub.TabIndex = 1;
            this.lblRecentSub.Text = "Các thay đổi quan trọng trong phiên làm việc";
            // 
            // lblRecentTitle
            // 
            this.lblRecentTitle.AutoSize = true;
            this.lblRecentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRecentTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblRecentTitle.Location = new System.Drawing.Point(20, 12);
            this.lblRecentTitle.Name = "lblRecentTitle";
            this.lblRecentTitle.Size = new System.Drawing.Size(176, 25);
            this.lblRecentTitle.TabIndex = 0;
            this.lblRecentTitle.Text = "Hoạt động gần đây";
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.Controls.Add(this.pnlTasks);
            this.pnlRight.Controls.Add(this.pnlSystem);
            this.pnlRight.FillColor = System.Drawing.Color.Transparent;
            this.pnlRight.Location = new System.Drawing.Point(711, 280);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(397, 486);
            this.pnlRight.TabIndex = 5;
            // 
            // pnlTasks
            // 
            this.pnlTasks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTasks.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlTasks.BorderRadius = 8;
            this.pnlTasks.BorderThickness = 1;
            this.pnlTasks.Controls.Add(this.lblTask4);
            this.pnlTasks.Controls.Add(this.lblTask3);
            this.pnlTasks.Controls.Add(this.lblTask2);
            this.pnlTasks.Controls.Add(this.lblTask1);
            this.pnlTasks.Controls.Add(this.lblTaskTitle);
            this.pnlTasks.FillColor = System.Drawing.Color.White;
            this.pnlTasks.Location = new System.Drawing.Point(0, 226);
            this.pnlTasks.Name = "pnlTasks";
            this.pnlTasks.Size = new System.Drawing.Size(397, 260);
            this.pnlTasks.TabIndex = 1;
            // 
            // lblTask4
            // 
            this.lblTask4.BackColor = System.Drawing.Color.Transparent;
            this.lblTask4.Font = new System.Drawing.Font("Segoe UI", 9.4F);
            this.lblTask4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTask4.Location = new System.Drawing.Point(22, 190);
            this.lblTask4.Name = "lblTask4";
            this.lblTask4.Size = new System.Drawing.Size(350, 36);
            this.lblTask4.TabIndex = 4;
            this.lblTask4.Text = "Kiểm tra các thông báo OLS nhãn khẩn cấp chưa gửi.";
            // 
            // lblTask3
            // 
            this.lblTask3.BackColor = System.Drawing.Color.Transparent;
            this.lblTask3.Font = new System.Drawing.Font("Segoe UI", 9.4F);
            this.lblTask3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTask3.Location = new System.Drawing.Point(22, 145);
            this.lblTask3.Name = "lblTask3";
            this.lblTask3.Size = new System.Drawing.Size(350, 36);
            this.lblTask3.TabIndex = 3;
            this.lblTask3.Text = "Theo dõi 4 audit log thất bại hoặc trái quyền.";
            // 
            // lblTask2
            // 
            this.lblTask2.BackColor = System.Drawing.Color.Transparent;
            this.lblTask2.Font = new System.Drawing.Font("Segoe UI", 9.4F);
            this.lblTask2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTask2.Location = new System.Drawing.Point(22, 100);
            this.lblTask2.Name = "lblTask2";
            this.lblTask2.Size = new System.Drawing.Size(350, 36);
            this.lblTask2.TabIndex = 2;
            this.lblTask2.Text = "Xác nhận bản backup gần nhất trước khi phục hồi.";
            // 
            // lblTask1
            // 
            this.lblTask1.BackColor = System.Drawing.Color.Transparent;
            this.lblTask1.Font = new System.Drawing.Font("Segoe UI", 9.4F);
            this.lblTask1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTask1.Location = new System.Drawing.Point(22, 55);
            this.lblTask1.Name = "lblTask1";
            this.lblTask1.Size = new System.Drawing.Size(350, 36);
            this.lblTask1.TabIndex = 1;
            this.lblTask1.Text = "Duyệt cấu hình Standard Audit và Fine-grained Audit.";
            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTaskTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblTaskTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(134, 25);
            this.lblTaskTitle.TabIndex = 0;
            this.lblTaskTitle.Text = "Việc cần chú ý";
            // 
            // pnlSystem
            // 
            this.pnlSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSystem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlSystem.BorderRadius = 8;
            this.pnlSystem.BorderThickness = 1;
            this.pnlSystem.Controls.Add(this.lblInfo6);
            this.pnlSystem.Controls.Add(this.lblInfo5);
            this.pnlSystem.Controls.Add(this.lblInfo4);
            this.pnlSystem.Controls.Add(this.lblInfo3);
            this.pnlSystem.Controls.Add(this.lblInfo2);
            this.pnlSystem.Controls.Add(this.lblInfo1);
            this.pnlSystem.Controls.Add(this.lblSystemTitle);
            this.pnlSystem.FillColor = System.Drawing.Color.White;
            this.pnlSystem.Location = new System.Drawing.Point(0, 0);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Size = new System.Drawing.Size(397, 210);
            this.pnlSystem.TabIndex = 0;
            // 
            // lblInfo6
            // 
            this.lblInfo6.AutoSize = true;
            this.lblInfo6.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo6.Font = new System.Drawing.Font("Segoe UI", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblInfo6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblInfo6.Location = new System.Drawing.Point(225, 158);
            this.lblInfo6.Name = "lblInfo6";
            this.lblInfo6.Size = new System.Drawing.Size(70, 17);
            this.lblInfo6.TabIndex = 6;
            this.lblInfo6.Text = "Audit: ON";
            // 
            // lblInfo5
            // 
            this.lblInfo5.AutoSize = true;
            this.lblInfo5.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo5.Font = new System.Drawing.Font("Segoe UI", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblInfo5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblInfo5.Location = new System.Drawing.Point(25, 158);
            this.lblInfo5.Name = "lblInfo5";
            this.lblInfo5.Size = new System.Drawing.Size(85, 17);
            this.lblInfo5.TabIndex = 5;
            this.lblInfo5.Text = "OLS: ACTIVE";
            // 
            // lblInfo4
            // 
            this.lblInfo4.AutoSize = true;
            this.lblInfo4.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo4.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.lblInfo4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblInfo4.Location = new System.Drawing.Point(25, 122);
            this.lblInfo4.Name = "lblInfo4";
            this.lblInfo4.Size = new System.Drawing.Size(117, 17);
            this.lblInfo4.TabIndex = 4;
            this.lblInfo4.Text = "Backup cuối: 24/05";
            // 
            // lblInfo3
            // 
            this.lblInfo3.AutoSize = true;
            this.lblInfo3.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo3.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.lblInfo3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblInfo3.Location = new System.Drawing.Point(25, 95);
            this.lblInfo3.Name = "lblInfo3";
            this.lblInfo3.Size = new System.Drawing.Size(135, 17);
            this.lblInfo3.TabIndex = 3;
            this.lblInfo3.Text = "Instance: BVDKPROD1";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo2.Font = new System.Drawing.Font("Segoe UI", 9.2F);
            this.lblInfo2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblInfo2.Location = new System.Drawing.Point(25, 68);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(133, 17);
            this.lblInfo2.TabIndex = 2;
            this.lblInfo2.Text = "Oracle 19c Enterprise";
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo1.Font = new System.Drawing.Font("Segoe UI", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblInfo1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblInfo1.Location = new System.Drawing.Point(25, 42);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(108, 17);
            this.lblInfo1.TabIndex = 1;
            this.lblInfo1.Text = "Database: OPEN";
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.AutoSize = true;
            this.lblSystemTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblSystemTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblSystemTitle.Location = new System.Drawing.Point(20, 15);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(152, 25);
            this.lblSystemTitle.TabIndex = 0;
            this.lblSystemTitle.Text = "Tổng quan CSDL";
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.Controls.Add(this.pnlUsers);
            this.pnlStats.Controls.Add(this.pnlAudit);
            this.pnlStats.Controls.Add(this.pnlBackup);
            this.pnlStats.Controls.Add(this.pnlWarn);
            this.pnlStats.Location = new System.Drawing.Point(20, 150);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1088, 106);
            this.pnlStats.TabIndex = 3;
            this.pnlStats.WrapContents = false;
            // 
            // pnlUsers
            // 
            this.pnlUsers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlUsers.BorderRadius = 8;
            this.pnlUsers.BorderThickness = 1;
            this.pnlUsers.Controls.Add(this.lblUsersSub);
            this.pnlUsers.Controls.Add(this.lblUsersValue);
            this.pnlUsers.Controls.Add(this.lblUsersTitle);
            this.pnlUsers.FillColor = System.Drawing.Color.White;
            this.pnlUsers.Location = new System.Drawing.Point(0, 0);
            this.pnlUsers.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlUsers.Name = "pnlUsers";
            this.pnlUsers.Size = new System.Drawing.Size(260, 96);
            this.pnlUsers.TabIndex = 0;
            // 
            // lblUsersSub
            // 
            this.lblUsersSub.AutoSize = true;
            this.lblUsersSub.BackColor = System.Drawing.Color.Transparent;
            this.lblUsersSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsersSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblUsersSub.Location = new System.Drawing.Point(20, 68);
            this.lblUsersSub.Name = "lblUsersSub";
            this.lblUsersSub.Size = new System.Drawing.Size(109, 15);
            this.lblUsersSub.TabIndex = 2;
            this.lblUsersSub.Text = "+3 so với hôm qua";
            // 
            // lblUsersValue
            // 
            this.lblUsersValue.AutoSize = true;
            this.lblUsersValue.BackColor = System.Drawing.Color.Transparent;
            this.lblUsersValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblUsersValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblUsersValue.Location = new System.Drawing.Point(18, 28);
            this.lblUsersValue.Name = "lblUsersValue";
            this.lblUsersValue.Size = new System.Drawing.Size(69, 41);
            this.lblUsersValue.TabIndex = 1;
            this.lblUsersValue.Text = "124";
            // 
            // lblUsersTitle
            // 
            this.lblUsersTitle.AutoSize = true;
            this.lblUsersTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUsersTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblUsersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblUsersTitle.Location = new System.Drawing.Point(20, 13);
            this.lblUsersTitle.Name = "lblUsersTitle";
            this.lblUsersTitle.Size = new System.Drawing.Size(146, 15);
            this.lblUsersTitle.TabIndex = 0;
            this.lblUsersTitle.Text = "TÀI KHOẢN HOẠT ĐỘNG";
            // 
            // pnlAudit
            // 
            this.pnlAudit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlAudit.BorderRadius = 8;
            this.pnlAudit.BorderThickness = 1;
            this.pnlAudit.Controls.Add(this.lblAuditSub);
            this.pnlAudit.Controls.Add(this.lblAuditValue);
            this.pnlAudit.Controls.Add(this.lblAuditTitle);
            this.pnlAudit.FillColor = System.Drawing.Color.White;
            this.pnlAudit.Location = new System.Drawing.Point(274, 0);
            this.pnlAudit.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlAudit.Name = "pnlAudit";
            this.pnlAudit.Size = new System.Drawing.Size(260, 96);
            this.pnlAudit.TabIndex = 1;
            // 
            // lblAuditSub
            // 
            this.lblAuditSub.AutoSize = true;
            this.lblAuditSub.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAuditSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblAuditSub.Location = new System.Drawing.Point(20, 68);
            this.lblAuditSub.Name = "lblAuditSub";
            this.lblAuditSub.Size = new System.Drawing.Size(137, 15);
            this.lblAuditSub.TabIndex = 2;
            this.lblAuditSub.Text = "8 thành công, 4 thất bại";
            // 
            // lblAuditValue
            // 
            this.lblAuditValue.AutoSize = true;
            this.lblAuditValue.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblAuditValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblAuditValue.Location = new System.Drawing.Point(18, 28);
            this.lblAuditValue.Name = "lblAuditValue";
            this.lblAuditValue.Size = new System.Drawing.Size(52, 41);
            this.lblAuditValue.TabIndex = 1;
            this.lblAuditValue.Text = "12";
            // 
            // lblAuditTitle
            // 
            this.lblAuditTitle.AutoSize = true;
            this.lblAuditTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAuditTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblAuditTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblAuditTitle.Location = new System.Drawing.Point(20, 13);
            this.lblAuditTitle.Name = "lblAuditTitle";
            this.lblAuditTitle.Size = new System.Drawing.Size(129, 15);
            this.lblAuditTitle.TabIndex = 0;
            this.lblAuditTitle.Text = "AUDIT LOG HÔM NAY";
            // 
            // pnlBackup
            // 
            this.pnlBackup.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlBackup.BorderRadius = 8;
            this.pnlBackup.BorderThickness = 1;
            this.pnlBackup.Controls.Add(this.lblBackupSub);
            this.pnlBackup.Controls.Add(this.lblBackupValue);
            this.pnlBackup.Controls.Add(this.lblBackupTitle);
            this.pnlBackup.FillColor = System.Drawing.Color.White;
            this.pnlBackup.Location = new System.Drawing.Point(548, 0);
            this.pnlBackup.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(260, 96);
            this.pnlBackup.TabIndex = 2;
            // 
            // lblBackupSub
            // 
            this.lblBackupSub.AutoSize = true;
            this.lblBackupSub.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBackupSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblBackupSub.Location = new System.Drawing.Point(20, 68);
            this.lblBackupSub.Name = "lblBackupSub";
            this.lblBackupSub.Size = new System.Drawing.Size(106, 15);
            this.lblBackupSub.TabIndex = 2;
            this.lblBackupSub.Text = "Full backup 8.4GB";
            // 
            // lblBackupValue
            // 
            this.lblBackupValue.AutoSize = true;
            this.lblBackupValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblBackupValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblBackupValue.Location = new System.Drawing.Point(18, 28);
            this.lblBackupValue.Name = "lblBackupValue";
            this.lblBackupValue.Size = new System.Drawing.Size(60, 41);
            this.lblBackupValue.TabIndex = 1;
            this.lblBackupValue.Text = "OK";
            // 
            // lblBackupTitle
            // 
            this.lblBackupTitle.AutoSize = true;
            this.lblBackupTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblBackupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblBackupTitle.Location = new System.Drawing.Point(20, 13);
            this.lblBackupTitle.Name = "lblBackupTitle";
            this.lblBackupTitle.Size = new System.Drawing.Size(123, 15);
            this.lblBackupTitle.TabIndex = 0;
            this.lblBackupTitle.Text = "SAO LƯU GẦN NHẤT";
            // 
            // pnlWarn
            // 
            this.pnlWarn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlWarn.BorderRadius = 8;
            this.pnlWarn.BorderThickness = 1;
            this.pnlWarn.Controls.Add(this.lblWarnSub);
            this.pnlWarn.Controls.Add(this.lblWarnValue);
            this.pnlWarn.Controls.Add(this.lblWarnTitle);
            this.pnlWarn.FillColor = System.Drawing.Color.White;
            this.pnlWarn.Location = new System.Drawing.Point(822, 0);
            this.pnlWarn.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWarn.Name = "pnlWarn";
            this.pnlWarn.Size = new System.Drawing.Size(260, 96);
            this.pnlWarn.TabIndex = 3;
            // 
            // lblWarnSub
            // 
            this.lblWarnSub.AutoSize = true;
            this.lblWarnSub.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnSub.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWarnSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblWarnSub.Location = new System.Drawing.Point(20, 68);
            this.lblWarnSub.Name = "lblWarnSub";
            this.lblWarnSub.Size = new System.Drawing.Size(91, 15);
            this.lblWarnSub.TabIndex = 2;
            this.lblWarnSub.Text = "2 cảnh báo mới";
            // 
            // lblWarnValue
            // 
            this.lblWarnValue.AutoSize = true;
            this.lblWarnValue.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnValue.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblWarnValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblWarnValue.Location = new System.Drawing.Point(18, 28);
            this.lblWarnValue.Name = "lblWarnValue";
            this.lblWarnValue.Size = new System.Drawing.Size(35, 41);
            this.lblWarnValue.TabIndex = 1;
            this.lblWarnValue.Text = "6";
            // 
            // lblWarnTitle
            // 
            this.lblWarnTitle.AutoSize = true;
            this.lblWarnTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnTitle.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblWarnTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblWarnTitle.Location = new System.Drawing.Point(20, 13);
            this.lblWarnTitle.Name = "lblWarnTitle";
            this.lblWarnTitle.Size = new System.Drawing.Size(68, 15);
            this.lblWarnTitle.TabIndex = 0;
            this.lblWarnTitle.Text = "CẢNH BÁO";
            // 
            // pnlAlert
            // 
            this.pnlAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAlert.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(230)))), ((int)(((byte)(138)))));
            this.pnlAlert.BorderRadius = 8;
            this.pnlAlert.BorderThickness = 1;
            this.pnlAlert.Controls.Add(this.lblAlert);
            this.pnlAlert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(235)))));
            this.pnlAlert.Location = new System.Drawing.Point(20, 86);
            this.pnlAlert.Name = "pnlAlert";
            this.pnlAlert.Size = new System.Drawing.Size(1088, 48);
            this.pnlAlert.TabIndex = 2;
            // 
            // lblAlert
            // 
            this.lblAlert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlert.BackColor = System.Drawing.Color.Transparent;
            this.lblAlert.Font = new System.Drawing.Font("Segoe UI", 9.4F, System.Drawing.FontStyle.Bold);
            this.lblAlert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(64)))), ((int)(((byte)(14)))));
            this.lblAlert.Location = new System.Drawing.Point(20, 14);
            this.lblAlert.Name = "lblAlert";
            this.lblAlert.Size = new System.Drawing.Size(1048, 20);
            this.lblAlert.TabIndex = 0;
            this.lblAlert.Text = "Cảnh báo: có 4 audit log thất bại cần kiểm tra và 1 bản backup mới đang chờ xác n" +
    "hận.";
            // 
            // ucTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlRoot);
            this.Name = "ucTrangChu";
            this.Size = new System.Drawing.Size(1128, 782);
            this.Load += new System.EventHandler(this.ucTrangChu_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlRecent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent)).EndInit();
            this.pnlRecentHeader.ResumeLayout(false);
            this.pnlRecentHeader.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlTasks.ResumeLayout(false);
            this.pnlTasks.PerformLayout();
            this.pnlSystem.ResumeLayout(false);
            this.pnlSystem.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlUsers.ResumeLayout(false);
            this.pnlUsers.PerformLayout();
            this.pnlAudit.ResumeLayout(false);
            this.pnlAudit.PerformLayout();
            this.pnlBackup.ResumeLayout(false);
            this.pnlBackup.PerformLayout();
            this.pnlWarn.ResumeLayout(false);
            this.pnlWarn.PerformLayout();
            this.pnlAlert.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlAlert;
        private System.Windows.Forms.Label lblAlert;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private Guna.UI2.WinForms.Guna2Panel pnlUsers;
        private System.Windows.Forms.Label lblUsersSub;
        private System.Windows.Forms.Label lblUsersValue;
        private System.Windows.Forms.Label lblUsersTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlAudit;
        private System.Windows.Forms.Label lblAuditSub;
        private System.Windows.Forms.Label lblAuditValue;
        private System.Windows.Forms.Label lblAuditTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlBackup;
        private System.Windows.Forms.Label lblBackupSub;
        private System.Windows.Forms.Label lblBackupValue;
        private System.Windows.Forms.Label lblBackupTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlWarn;
        private System.Windows.Forms.Label lblWarnSub;
        private System.Windows.Forms.Label lblWarnValue;
        private System.Windows.Forms.Label lblWarnTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlRecent;
        private System.Windows.Forms.DataGridView dgvRecent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLevel;
        private Guna.UI2.WinForms.Guna2Panel pnlRecentHeader;
        private System.Windows.Forms.Label lblRecentSub;
        private System.Windows.Forms.Label lblRecentTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlRight;
        private Guna.UI2.WinForms.Guna2Panel pnlSystem;
        private System.Windows.Forms.Label lblInfo6;
        private System.Windows.Forms.Label lblInfo5;
        private System.Windows.Forms.Label lblInfo4;
        private System.Windows.Forms.Label lblInfo3;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblSystemTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlTasks;
        private System.Windows.Forms.Label lblTask4;
        private System.Windows.Forms.Label lblTask3;
        private System.Windows.Forms.Label lblTask2;
        private System.Windows.Forms.Label lblTask1;
        private System.Windows.Forms.Label lblTaskTitle;
    }
}

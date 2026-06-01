namespace HospitalX.GUI.PH2.QuanTriVien
{
    partial class ucThongBao
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
            this.pnlHistory = new Guna.UI2.WinForms.Guna2Panel();
            this.flowSent = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvSent = new System.Windows.Forms.DataGridView();
            this.pnlHistoryHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHistoryCount = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLabels = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.chkT7 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkT6 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkT5 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkT4 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkT3 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkT2 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkT1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.chkAll = new Guna.UI2.WinForms.Guna2CheckBox();
            this.lblSelectedCount = new System.Windows.Forms.Label();
            this.lblLabelsTitle = new System.Windows.Forms.Label();
            this.pnlCompose = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbPriority = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.txtLocation = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.dtpTime = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtContent = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.lblComposeTitle = new System.Windows.Forms.Label();
            this.msgDialog = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.colSentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentLabels = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSentPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlRoot.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSent)).BeginInit();
            this.pnlHistoryHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLabels.SuspendLayout();
            this.pnlCompose.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.Controls.Add(this.pnlHistory);
            this.pnlRoot.Controls.Add(this.pnlLeft);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.pnlRoot.Size = new System.Drawing.Size(1128, 782);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlHistory
            // 
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlHistory.BorderRadius = 8;
            this.pnlHistory.BorderThickness = 1;
            this.pnlHistory.Controls.Add(this.flowSent);
            this.pnlHistory.Controls.Add(this.dgvSent);
            this.pnlHistory.Controls.Add(this.pnlHistoryHeader);
            this.pnlHistory.FillColor = System.Drawing.Color.White;
            this.pnlHistory.Location = new System.Drawing.Point(477, 35);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(628, 678);
            this.pnlHistory.TabIndex = 2;
            // 
            // flowSent
            // 
            this.flowSent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowSent.AutoScroll = true;
            this.flowSent.BackColor = System.Drawing.Color.White;
            this.flowSent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowSent.Location = new System.Drawing.Point(18, 82);
            this.flowSent.Name = "flowSent";
            this.flowSent.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.flowSent.Size = new System.Drawing.Size(592, 574);
            this.flowSent.TabIndex = 2;
            this.flowSent.WrapContents = false;
            // 
            // dgvSent
            // 
            this.dgvSent.AllowUserToAddRows = false;
            this.dgvSent.AllowUserToDeleteRows = false;
            this.dgvSent.AllowUserToResizeRows = false;
            this.dgvSent.BackgroundColor = System.Drawing.Color.White;
            this.dgvSent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSent.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSent.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.dgvSent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSent.ColumnHeadersHeight = 38;
            this.dgvSent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSentTime,
            this.colSentContent,
            this.colSentLabels,
            this.colSentPriority});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(48)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(48)))), ((int)(((byte)(43)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSent.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSent.EnableHeadersVisualStyles = false;
            this.dgvSent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(238)))), ((int)(((byte)(235)))));
            this.dgvSent.Location = new System.Drawing.Point(3, 62);
            this.dgvSent.MultiSelect = false;
            this.dgvSent.Name = "dgvSent";
            this.dgvSent.ReadOnly = true;
            this.dgvSent.RowHeadersVisible = false;
            this.dgvSent.RowTemplate.Height = 58;
            this.dgvSent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSent.Size = new System.Drawing.Size(622, 613);
            this.dgvSent.TabIndex = 1;
            this.dgvSent.Visible = false;
            // 
            // pnlHistoryHeader
            // 
            this.pnlHistoryHeader.Controls.Add(this.lblHistoryCount);
            this.pnlHistoryHeader.Controls.Add(this.lblHistoryTitle);
            this.pnlHistoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistoryHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlHistoryHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHistoryHeader.Name = "pnlHistoryHeader";
            this.pnlHistoryHeader.Size = new System.Drawing.Size(628, 62);
            this.pnlHistoryHeader.TabIndex = 0;
            // 
            // lblHistoryCount
            // 
            this.lblHistoryCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHistoryCount.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoryCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHistoryCount.ForeColor = System.Drawing.Color.White;
            this.lblHistoryCount.Location = new System.Drawing.Point(442, 22);
            this.lblHistoryCount.Name = "lblHistoryCount";
            this.lblHistoryCount.Size = new System.Drawing.Size(162, 20);
            this.lblHistoryCount.TabIndex = 1;
            this.lblHistoryCount.Text = "0 bản ghi";
            this.lblHistoryCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.White;
            this.lblHistoryTitle.Location = new System.Drawing.Point(3, 17);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(163, 25);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "Thông báo đã gửi";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.Controls.Add(this.pnlLabels);
            this.pnlLeft.Controls.Add(this.pnlCompose);
            this.pnlLeft.FillColor = System.Drawing.Color.Transparent;
            this.pnlLeft.Location = new System.Drawing.Point(23, 35);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(444, 678);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlLabels
            // 
            this.pnlLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLabels.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlLabels.BorderRadius = 8;
            this.pnlLabels.BorderThickness = 1;
            this.pnlLabels.Controls.Add(this.btnSend);
            this.pnlLabels.Controls.Add(this.flowLabels);
            this.pnlLabels.Controls.Add(this.chkT7);
            this.pnlLabels.Controls.Add(this.chkT6);
            this.pnlLabels.Controls.Add(this.chkT5);
            this.pnlLabels.Controls.Add(this.chkT4);
            this.pnlLabels.Controls.Add(this.chkT3);
            this.pnlLabels.Controls.Add(this.chkT2);
            this.pnlLabels.Controls.Add(this.chkT1);
            this.pnlLabels.Controls.Add(this.chkAll);
            this.pnlLabels.Controls.Add(this.lblSelectedCount);
            this.pnlLabels.Controls.Add(this.lblLabelsTitle);
            this.pnlLabels.FillColor = System.Drawing.Color.White;
            this.pnlLabels.Location = new System.Drawing.Point(0, 330);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Size = new System.Drawing.Size(444, 348);
            this.pnlLabels.TabIndex = 1;
            // 
            // flowLabels
            // 
            this.flowLabels.BackColor = System.Drawing.Color.White;
            this.flowLabels.Location = new System.Drawing.Point(20, 62);
            this.flowLabels.Name = "flowLabels";
            this.flowLabels.Size = new System.Drawing.Size(400, 218);
            this.flowLabels.TabIndex = 11;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BorderRadius = 8;
            this.btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(138)))), ((int)(((byte)(108)))));
            this.btnSend.Location = new System.Drawing.Point(24, 288);
            this.btnSend.Name = "btnSend";
            this.btnSend.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(86)))), ((int)(((byte)(67)))));
            this.btnSend.Size = new System.Drawing.Size(396, 40);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Gửi thông báo qua OLS";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // chkT7
            // 
            this.chkT7.BackColor = System.Drawing.Color.Transparent;
            this.chkT7.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT7.CheckedState.BorderRadius = 3;
            this.chkT7.CheckedState.BorderThickness = 1;
            this.chkT7.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT7.Location = new System.Drawing.Point(20, 204);
            this.chkT7.Name = "chkT7";
            this.chkT7.Size = new System.Drawing.Size(194, 32);
            this.chkT7.TabIndex = 9;
            this.chkT7.Text = "t7 - Nhân viên Cơ sở 2";
            this.chkT7.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT7.UncheckedState.BorderRadius = 3;
            this.chkT7.UncheckedState.BorderThickness = 1;
            this.chkT7.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT7.UseVisualStyleBackColor = false;
            this.chkT7.Visible = false;
            this.chkT7.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkT6
            // 
            this.chkT6.BackColor = System.Drawing.Color.Transparent;
            this.chkT6.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT6.CheckedState.BorderRadius = 3;
            this.chkT6.CheckedState.BorderThickness = 1;
            this.chkT6.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT6.Location = new System.Drawing.Point(230, 166);
            this.chkT6.Name = "chkT6";
            this.chkT6.Size = new System.Drawing.Size(190, 32);
            this.chkT6.TabIndex = 8;
            this.chkT6.Text = "t6 - Nhân viên Cơ sở 1";
            this.chkT6.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT6.UncheckedState.BorderRadius = 3;
            this.chkT6.UncheckedState.BorderThickness = 1;
            this.chkT6.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT6.UseVisualStyleBackColor = false;
            this.chkT6.Visible = false;
            this.chkT6.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkT5
            // 
            this.chkT5.BackColor = System.Drawing.Color.Transparent;
            this.chkT5.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT5.CheckedState.BorderRadius = 3;
            this.chkT5.CheckedState.BorderThickness = 1;
            this.chkT5.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT5.Location = new System.Drawing.Point(20, 166);
            this.chkT5.Name = "chkT5";
            this.chkT5.Size = new System.Drawing.Size(194, 32);
            this.chkT5.TabIndex = 7;
            this.chkT5.Text = "t5 - Nhân viên Khoa Nội trú";
            this.chkT5.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT5.UncheckedState.BorderRadius = 3;
            this.chkT5.UncheckedState.BorderThickness = 1;
            this.chkT5.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT5.UseVisualStyleBackColor = false;
            this.chkT5.Visible = false;
            this.chkT5.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkT4
            // 
            this.chkT4.BackColor = System.Drawing.Color.Transparent;
            this.chkT4.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT4.CheckedState.BorderRadius = 3;
            this.chkT4.CheckedState.BorderThickness = 1;
            this.chkT4.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT4.Location = new System.Drawing.Point(230, 128);
            this.chkT4.Name = "chkT4";
            this.chkT4.Size = new System.Drawing.Size(190, 32);
            this.chkT4.TabIndex = 6;
            this.chkT4.Text = "t4 - Nhân viên Khoa Ngoại trú";
            this.chkT4.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT4.UncheckedState.BorderRadius = 3;
            this.chkT4.UncheckedState.BorderThickness = 1;
            this.chkT4.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT4.UseVisualStyleBackColor = false;
            this.chkT4.Visible = false;
            this.chkT4.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkT3
            // 
            this.chkT3.BackColor = System.Drawing.Color.Transparent;
            this.chkT3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT3.CheckedState.BorderRadius = 3;
            this.chkT3.CheckedState.BorderThickness = 1;
            this.chkT3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT3.Location = new System.Drawing.Point(20, 128);
            this.chkT3.Name = "chkT3";
            this.chkT3.Size = new System.Drawing.Size(194, 32);
            this.chkT3.TabIndex = 5;
            this.chkT3.Text = "t3 - Lãnh đạo khoa/phòng";
            this.chkT3.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT3.UncheckedState.BorderRadius = 3;
            this.chkT3.UncheckedState.BorderThickness = 1;
            this.chkT3.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT3.UseVisualStyleBackColor = false;
            this.chkT3.Visible = false;
            this.chkT3.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkT2
            // 
            this.chkT2.BackColor = System.Drawing.Color.Transparent;
            this.chkT2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT2.CheckedState.BorderRadius = 3;
            this.chkT2.CheckedState.BorderThickness = 1;
            this.chkT2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT2.Location = new System.Drawing.Point(230, 90);
            this.chkT2.Name = "chkT2";
            this.chkT2.Size = new System.Drawing.Size(190, 32);
            this.chkT2.TabIndex = 4;
            this.chkT2.Text = "t2 - Ban Giám đốc";
            this.chkT2.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT2.UncheckedState.BorderRadius = 3;
            this.chkT2.UncheckedState.BorderThickness = 1;
            this.chkT2.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT2.UseVisualStyleBackColor = false;
            this.chkT2.Visible = false;
            this.chkT2.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkT1
            // 
            this.chkT1.BackColor = System.Drawing.Color.Transparent;
            this.chkT1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT1.CheckedState.BorderRadius = 3;
            this.chkT1.CheckedState.BorderThickness = 1;
            this.chkT1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkT1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.chkT1.Location = new System.Drawing.Point(20, 90);
            this.chkT1.Name = "chkT1";
            this.chkT1.Size = new System.Drawing.Size(194, 32);
            this.chkT1.TabIndex = 3;
            this.chkT1.Text = "t1 - Toàn bộ nhân viên";
            this.chkT1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkT1.UncheckedState.BorderRadius = 3;
            this.chkT1.UncheckedState.BorderThickness = 1;
            this.chkT1.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkT1.UseVisualStyleBackColor = false;
            this.chkT1.Visible = false;
            this.chkT1.CheckedChanged += new System.EventHandler(this.LabelCheckChanged);
            // 
            // chkAll
            // 
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkAll.CheckedState.BorderRadius = 3;
            this.chkAll.CheckedState.BorderThickness = 1;
            this.chkAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chkAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.chkAll.Location = new System.Drawing.Point(20, 58);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(194, 26);
            this.chkAll.TabIndex = 2;
            this.chkAll.Text = "Chọn tất cả nhóm";
            this.chkAll.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.chkAll.UncheckedState.BorderRadius = 3;
            this.chkAll.UncheckedState.BorderThickness = 1;
            this.chkAll.UncheckedState.FillColor = System.Drawing.Color.White;
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.Visible = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lblSelectedCount
            // 
            this.lblSelectedCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedCount.BackColor = System.Drawing.Color.Transparent;
            this.lblSelectedCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblSelectedCount.Location = new System.Drawing.Point(255, 23);
            this.lblSelectedCount.Name = "lblSelectedCount";
            this.lblSelectedCount.Size = new System.Drawing.Size(165, 18);
            this.lblSelectedCount.TabIndex = 1;
            this.lblSelectedCount.Text = "0 nhóm được chọn";
            this.lblSelectedCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelsTitle
            // 
            this.lblLabelsTitle.AutoSize = true;
            this.lblLabelsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLabelsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLabelsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblLabelsTitle.Location = new System.Drawing.Point(20, 18);
            this.lblLabelsTitle.Name = "lblLabelsTitle";
            this.lblLabelsTitle.Size = new System.Drawing.Size(129, 25);
            this.lblLabelsTitle.TabIndex = 0;
            this.lblLabelsTitle.Text = "Nhãn OLS gửi";
            // 
            // pnlCompose
            // 
            this.pnlCompose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCompose.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlCompose.BorderRadius = 8;
            this.pnlCompose.BorderThickness = 1;
            this.pnlCompose.Controls.Add(this.cmbPriority);
            this.pnlCompose.Controls.Add(this.lblPriority);
            this.pnlCompose.Controls.Add(this.txtLocation);
            this.pnlCompose.Controls.Add(this.lblLocation);
            this.pnlCompose.Controls.Add(this.dtpTime);
            this.pnlCompose.Controls.Add(this.lblTime);
            this.pnlCompose.Controls.Add(this.txtContent);
            this.pnlCompose.Controls.Add(this.lblContent);
            this.pnlCompose.Controls.Add(this.lblComposeTitle);
            this.pnlCompose.FillColor = System.Drawing.Color.White;
            this.pnlCompose.Location = new System.Drawing.Point(0, 0);
            this.pnlCompose.Name = "pnlCompose";
            this.pnlCompose.Size = new System.Drawing.Size(444, 314);
            this.pnlCompose.TabIndex = 0;
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.Transparent;
            this.cmbPriority.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cmbPriority.BorderRadius = 6;
            this.cmbPriority.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbPriority.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cmbPriority.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.cmbPriority.ItemHeight = 30;
            this.cmbPriority.Items.AddRange(new object[] {
            "Thông thường",
            "Quan trọng",
            "Khẩn cấp"});
            this.cmbPriority.Location = new System.Drawing.Point(238, 252);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(182, 36);
            this.cmbPriority.StartIndex = 0;
            this.cmbPriority.TabIndex = 8;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.BackColor = System.Drawing.Color.Transparent;
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblPriority.Location = new System.Drawing.Point(238, 232);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(54, 15);
            this.lblPriority.TabIndex = 7;
            this.lblPriority.Text = "ƯU TIÊN";
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.Transparent;
            this.txtLocation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtLocation.BorderRadius = 6;
            this.txtLocation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLocation.DefaultText = "";
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtLocation.Location = new System.Drawing.Point(24, 252);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.PlaceholderText = "VD: Hội trường A";
            this.txtLocation.SelectedText = "";
            this.txtLocation.Size = new System.Drawing.Size(198, 36);
            this.txtLocation.TabIndex = 6;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblLocation.Location = new System.Drawing.Point(24, 232);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(61, 15);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "ĐỊA ĐIỂM";
            // 
            // dtpTime
            // 
            this.dtpTime.BackColor = System.Drawing.Color.Transparent;
            this.dtpTime.BorderRadius = 6;
            this.dtpTime.Checked = true;
            this.dtpTime.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.dtpTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpTime.FillColor = System.Drawing.Color.White;
            this.dtpTime.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(24, 188);
            this.dtpTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(198, 36);
            this.dtpTime.TabIndex = 4;
            this.dtpTime.Value = new System.DateTime(2026, 6, 1, 15, 30, 0, 0);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblTime.Location = new System.Drawing.Point(24, 168);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(64, 15);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "NGÀY GIỜ";
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.Transparent;
            this.txtContent.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtContent.BorderRadius = 6;
            this.txtContent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContent.DefaultText = "";
            this.txtContent.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtContent.Location = new System.Drawing.Point(24, 72);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.PlaceholderText = "Nhập nội dung thông báo nội bộ...";
            this.txtContent.SelectedText = "";
            this.txtContent.Size = new System.Drawing.Size(396, 86);
            this.txtContent.TabIndex = 2;
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 8.7F, System.Drawing.FontStyle.Bold);
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblContent.Location = new System.Drawing.Point(24, 52);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(68, 15);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "NỘI DUNG";
            // 
            // lblComposeTitle
            // 
            this.lblComposeTitle.AutoSize = true;
            this.lblComposeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblComposeTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblComposeTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblComposeTitle.Location = new System.Drawing.Point(22, 17);
            this.lblComposeTitle.Name = "lblComposeTitle";
            this.lblComposeTitle.Size = new System.Drawing.Size(184, 25);
            this.lblComposeTitle.TabIndex = 0;
            this.lblComposeTitle.Text = "Soạn thông báo mới";
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
            // colSentTime
            // 
            this.colSentTime.HeaderText = "Thời gian";
            this.colSentTime.Name = "colSentTime";
            this.colSentTime.ReadOnly = true;
            this.colSentTime.Width = 150;
            // 
            // colSentContent
            // 
            this.colSentContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colSentContent.HeaderText = "Nội dung";
            this.colSentContent.Name = "colSentContent";
            this.colSentContent.ReadOnly = true;
            // 
            // colSentLabels
            // 
            this.colSentLabels.HeaderText = "Nhãn";
            this.colSentLabels.Name = "colSentLabels";
            this.colSentLabels.ReadOnly = true;
            this.colSentLabels.Width = 90;
            // 
            // colSentPriority
            // 
            this.colSentPriority.HeaderText = "Ưu tiên";
            this.colSentPriority.Name = "colSentPriority";
            this.colSentPriority.ReadOnly = true;
            this.colSentPriority.Width = 120;
            // 
            // ucThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.pnlRoot);
            this.Name = "ucThongBao";
            this.Size = new System.Drawing.Size(1128, 782);
            this.Load += new System.EventHandler(this.ucThongBao_Load);
            this.pnlRoot.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSent)).EndInit();
            this.pnlHistoryHeader.ResumeLayout(false);
            this.pnlHistoryHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLabels.ResumeLayout(false);
            this.pnlLabels.PerformLayout();
            this.pnlCompose.ResumeLayout(false);
            this.pnlCompose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlLeft;
        private Guna.UI2.WinForms.Guna2Panel pnlCompose;
        private Guna.UI2.WinForms.Guna2TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblComposeTitle;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTime;
        private System.Windows.Forms.Label lblTime;
        private Guna.UI2.WinForms.Guna2TextBox txtLocation;
        private System.Windows.Forms.Label lblLocation;
        private Guna.UI2.WinForms.Guna2ComboBox cmbPriority;
        private System.Windows.Forms.Label lblPriority;
        private Guna.UI2.WinForms.Guna2Panel pnlLabels;
        private System.Windows.Forms.FlowLayoutPanel flowLabels;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Guna.UI2.WinForms.Guna2CheckBox chkT7;
        private Guna.UI2.WinForms.Guna2CheckBox chkT6;
        private Guna.UI2.WinForms.Guna2CheckBox chkT5;
        private Guna.UI2.WinForms.Guna2CheckBox chkT4;
        private Guna.UI2.WinForms.Guna2CheckBox chkT3;
        private Guna.UI2.WinForms.Guna2CheckBox chkT2;
        private Guna.UI2.WinForms.Guna2CheckBox chkT1;
        private Guna.UI2.WinForms.Guna2CheckBox chkAll;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label lblLabelsTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlHistory;
        private System.Windows.Forms.FlowLayoutPanel flowSent;
        private System.Windows.Forms.DataGridView dgvSent;
        private Guna.UI2.WinForms.Guna2Panel pnlHistoryHeader;
        private System.Windows.Forms.Label lblHistoryCount;
        private System.Windows.Forms.Label lblHistoryTitle;
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentLabels;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSentPriority;
    }
}

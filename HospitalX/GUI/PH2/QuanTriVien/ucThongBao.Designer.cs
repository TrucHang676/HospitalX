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
            this.pnlRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHistory = new Guna.UI2.WinForms.Guna2Panel();
            this.flowSent = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHistoryHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblHistoryCount = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLabels = new Guna.UI2.WinForms.Guna2Panel();
            this.btnLabelAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnSend = new Guna.UI2.WinForms.Guna2Button();
            this.flowLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLabelT1 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabelT2 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabelT3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabelT4 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabelT5 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabelT6 = new Guna.UI2.WinForms.Guna2Button();
            this.btnLabelT7 = new Guna.UI2.WinForms.Guna2Button();
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
            this.pnlRoot.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.pnlHistoryHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLabels.SuspendLayout();
            this.flowLabels.SuspendLayout();
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
            this.pnlHistory.Controls.Add(this.pnlHistoryHeader);
            this.pnlHistory.FillColor = System.Drawing.Color.White;
            this.pnlHistory.Location = new System.Drawing.Point(477, 35);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(628, 705);
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
            this.flowSent.Size = new System.Drawing.Size(592, 601);
            this.flowSent.TabIndex = 2;
            this.flowSent.WrapContents = false;
            // 
            // pnlHistoryHeader
            // 
            this.pnlHistoryHeader.BorderRadius = 8;
            this.pnlHistoryHeader.BorderThickness = 1;
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
            this.lblHistoryTitle.Location = new System.Drawing.Point(11, 17);
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
            this.pnlLeft.Size = new System.Drawing.Size(444, 708);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlLabels
            // 
            this.pnlLabels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLabels.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlLabels.BorderRadius = 8;
            this.pnlLabels.BorderThickness = 1;
            this.pnlLabels.Controls.Add(this.btnLabelAll);
            this.pnlLabels.Controls.Add(this.btnSend);
            this.pnlLabels.Controls.Add(this.flowLabels);
            this.pnlLabels.Controls.Add(this.lblSelectedCount);
            this.pnlLabels.Controls.Add(this.lblLabelsTitle);
            this.pnlLabels.FillColor = System.Drawing.Color.White;
            this.pnlLabels.Location = new System.Drawing.Point(0, 330);
            this.pnlLabels.Name = "pnlLabels";
            this.pnlLabels.Size = new System.Drawing.Size(444, 375);
            this.pnlLabels.TabIndex = 1;
            // 
            // btnLabelAll
            // 
            this.btnLabelAll.BackColor = System.Drawing.Color.Transparent;
            this.btnLabelAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(216)))), ((int)(((byte)(203)))));
            this.btnLabelAll.BorderRadius = 10;
            this.btnLabelAll.BorderThickness = 1;
            this.btnLabelAll.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelAll.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(243)))), ((int)(((byte)(236)))));
            this.btnLabelAll.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(82)))), ((int)(((byte)(66)))));
            this.btnLabelAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelAll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.btnLabelAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLabelAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelAll.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelAll.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelAll.Location = new System.Drawing.Point(27, 73);
            this.btnLabelAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.btnLabelAll.Name = "btnLabelAll";
            this.btnLabelAll.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(232)))), ((int)(((byte)(222)))));
            this.btnLabelAll.Size = new System.Drawing.Size(179, 34);
            this.btnLabelAll.TabIndex = 12;
            this.btnLabelAll.Tag = "ALL";
            this.btnLabelAll.Text = "Chọn tất cả nhóm nhận";
            this.btnLabelAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelAll.TextOffset = new System.Drawing.Point(14, 0);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.BackColor = System.Drawing.Color.Transparent;
            this.btnSend.BorderColor = System.Drawing.Color.DarkGreen;
            this.btnSend.BorderRadius = 8;
            this.btnSend.BorderThickness = 2;
            this.btnSend.DisabledState.BorderColor = System.Drawing.Color.Silver;
            this.btnSend.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(230)))), ((int)(((byte)(228)))));
            this.btnSend.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnSend.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(138)))), ((int)(((byte)(108)))));
            this.btnSend.Location = new System.Drawing.Point(24, 315);
            this.btnSend.Name = "btnSend";
            this.btnSend.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(86)))), ((int)(((byte)(67)))));
            this.btnSend.Size = new System.Drawing.Size(396, 40);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Gửi thông báo";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // flowLabels
            // 
            this.flowLabels.BackColor = System.Drawing.Color.White;
            this.flowLabels.Controls.Add(this.btnLabelT1);
            this.flowLabels.Controls.Add(this.btnLabelT2);
            this.flowLabels.Controls.Add(this.btnLabelT3);
            this.flowLabels.Controls.Add(this.btnLabelT4);
            this.flowLabels.Controls.Add(this.btnLabelT5);
            this.flowLabels.Controls.Add(this.btnLabelT6);
            this.flowLabels.Controls.Add(this.btnLabelT7);
            this.flowLabels.Location = new System.Drawing.Point(24, 114);
            this.flowLabels.Name = "flowLabels";
            this.flowLabels.Size = new System.Drawing.Size(400, 195);
            this.flowLabels.TabIndex = 11;
            // 
            // btnLabelT1
            // 
            this.btnLabelT1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnLabelT1.BorderRadius = 10;
            this.btnLabelT1.BorderThickness = 1;
            this.btnLabelT1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT1.FillColor = System.Drawing.Color.White;
            this.btnLabelT1.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.btnLabelT1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.btnLabelT1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT1.Location = new System.Drawing.Point(3, 10);
            this.btnLabelT1.Margin = new System.Windows.Forms.Padding(3, 10, 6, 4);
            this.btnLabelT1.Name = "btnLabelT1";
            this.btnLabelT1.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT1.TabIndex = 1;
            this.btnLabelT1.Tag = "t1";
            this.btnLabelT1.Text = "Toàn bộ nhân viên\r";
            this.btnLabelT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT1.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // btnLabelT2
            // 
            this.btnLabelT2.BorderColor = this.btnLabelT1.BorderColor;
            this.btnLabelT2.BorderRadius = 10;
            this.btnLabelT2.BorderThickness = 1;
            this.btnLabelT2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT2.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT2.FillColor = System.Drawing.Color.White;
            this.btnLabelT2.Font = this.btnLabelT1.Font;
            this.btnLabelT2.ForeColor = this.btnLabelT1.ForeColor;
            this.btnLabelT2.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT2.Location = new System.Drawing.Point(213, 10);
            this.btnLabelT2.Margin = new System.Windows.Forms.Padding(25, 10, 3, 4);
            this.btnLabelT2.Name = "btnLabelT2";
            this.btnLabelT2.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT2.TabIndex = 2;
            this.btnLabelT2.Tag = "t2";
            this.btnLabelT2.Text = "Ban Giám đốc\r\n";
            this.btnLabelT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT2.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // btnLabelT3
            // 
            this.btnLabelT3.BorderColor = this.btnLabelT1.BorderColor;
            this.btnLabelT3.BorderRadius = 10;
            this.btnLabelT3.BorderThickness = 1;
            this.btnLabelT3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT3.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT3.FillColor = System.Drawing.Color.White;
            this.btnLabelT3.Font = this.btnLabelT1.Font;
            this.btnLabelT3.ForeColor = this.btnLabelT1.ForeColor;
            this.btnLabelT3.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT3.Location = new System.Drawing.Point(3, 55);
            this.btnLabelT3.Margin = new System.Windows.Forms.Padding(3, 3, 6, 4);
            this.btnLabelT3.Name = "btnLabelT3";
            this.btnLabelT3.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT3.TabIndex = 3;
            this.btnLabelT3.Tag = "t3";
            this.btnLabelT3.Text = "Lãnh đạo khoa/phòng\r\n";
            this.btnLabelT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT3.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // btnLabelT4
            // 
            this.btnLabelT4.BorderColor = this.btnLabelT1.BorderColor;
            this.btnLabelT4.BorderRadius = 10;
            this.btnLabelT4.BorderThickness = 1;
            this.btnLabelT4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT4.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT4.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT4.FillColor = System.Drawing.Color.White;
            this.btnLabelT4.Font = this.btnLabelT1.Font;
            this.btnLabelT4.ForeColor = this.btnLabelT1.ForeColor;
            this.btnLabelT4.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT4.Location = new System.Drawing.Point(213, 55);
            this.btnLabelT4.Margin = new System.Windows.Forms.Padding(25, 3, 3, 4);
            this.btnLabelT4.Name = "btnLabelT4";
            this.btnLabelT4.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT4.TabIndex = 4;
            this.btnLabelT4.Tag = "t4";
            this.btnLabelT4.Text = "Lãnh đạo khoa Tiêu hóa";
            this.btnLabelT4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT4.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // btnLabelT5
            // 
            this.btnLabelT5.BorderColor = this.btnLabelT1.BorderColor;
            this.btnLabelT5.BorderRadius = 10;
            this.btnLabelT5.BorderThickness = 1;
            this.btnLabelT5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT5.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT5.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT5.FillColor = System.Drawing.Color.White;
            this.btnLabelT5.Font = this.btnLabelT1.Font;
            this.btnLabelT5.ForeColor = this.btnLabelT1.ForeColor;
            this.btnLabelT5.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT5.Location = new System.Drawing.Point(3, 100);
            this.btnLabelT5.Margin = new System.Windows.Forms.Padding(3, 3, 6, 4);
            this.btnLabelT5.Name = "btnLabelT5";
            this.btnLabelT5.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT5.TabIndex = 5;
            this.btnLabelT5.Tag = "t5";
            this.btnLabelT5.Text = "Nhân viên khoa Tiêu hóa ở HCM";
            this.btnLabelT5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT5.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // btnLabelT6
            // 
            this.btnLabelT6.BorderColor = this.btnLabelT1.BorderColor;
            this.btnLabelT6.BorderRadius = 10;
            this.btnLabelT6.BorderThickness = 1;
            this.btnLabelT6.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT6.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT6.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT6.FillColor = System.Drawing.Color.White;
            this.btnLabelT6.Font = this.btnLabelT1.Font;
            this.btnLabelT6.ForeColor = this.btnLabelT1.ForeColor;
            this.btnLabelT6.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT6.Location = new System.Drawing.Point(213, 100);
            this.btnLabelT6.Margin = new System.Windows.Forms.Padding(25, 3, 3, 4);
            this.btnLabelT6.Name = "btnLabelT6";
            this.btnLabelT6.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT6.TabIndex = 6;
            this.btnLabelT6.Tag = "t6";
            this.btnLabelT6.Text = "Nhân viên khoa Tiêu hóa ở HN";
            this.btnLabelT6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT6.TextOffset = new System.Drawing.Point(6, 0);
            // 
            // btnLabelT7
            // 
            this.btnLabelT7.BorderColor = this.btnLabelT1.BorderColor;
            this.btnLabelT7.BorderRadius = 10;
            this.btnLabelT7.BorderThickness = 1;
            this.btnLabelT7.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLabelT7.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnLabelT7.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnLabelT7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLabelT7.FillColor = System.Drawing.Color.White;
            this.btnLabelT7.Font = this.btnLabelT1.Font;
            this.btnLabelT7.ForeColor = this.btnLabelT1.ForeColor;
            this.btnLabelT7.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.btnLabelT7.Location = new System.Drawing.Point(3, 145);
            this.btnLabelT7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 4);
            this.btnLabelT7.Name = "btnLabelT7";
            this.btnLabelT7.Size = new System.Drawing.Size(179, 38);
            this.btnLabelT7.TabIndex = 7;
            this.btnLabelT7.Tag = "t7";
            this.btnLabelT7.Text = "Lãnh đạo khoa Tiêu hóa và khoa Thần kinh taị HP";
            this.btnLabelT7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLabelT7.TextOffset = new System.Drawing.Point(6, 0);
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
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.lblPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblPriority.Location = new System.Drawing.Point(238, 232);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(51, 13);
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
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.lblLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblLocation.Location = new System.Drawing.Point(24, 232);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(57, 13);
            this.lblLocation.TabIndex = 5;
            this.lblLocation.Text = "ĐỊA ĐIỂM";
            // 
            // dtpTime
            // 
            this.dtpTime.BackColor = System.Drawing.Color.Transparent;
            this.dtpTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(85)))));
            this.dtpTime.BorderRadius = 6;
            this.dtpTime.BorderThickness = 1;
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
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblTime.Location = new System.Drawing.Point(24, 168);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(61, 13);
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
            this.lblContent.Font = new System.Drawing.Font("Segoe UI", 8.2F, System.Drawing.FontStyle.Bold);
            this.lblContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(128)))), ((int)(((byte)(116)))));
            this.lblContent.Location = new System.Drawing.Point(24, 52);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(63, 13);
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
            this.pnlHistoryHeader.ResumeLayout(false);
            this.pnlHistoryHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLabels.ResumeLayout(false);
            this.pnlLabels.PerformLayout();
            this.flowLabels.ResumeLayout(false);
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
        private Guna.UI2.WinForms.Guna2Button btnLabelT1;
        private Guna.UI2.WinForms.Guna2Button btnLabelT2;
        private Guna.UI2.WinForms.Guna2Button btnLabelT3;
        private Guna.UI2.WinForms.Guna2Button btnLabelT4;
        private Guna.UI2.WinForms.Guna2Button btnLabelT5;
        private Guna.UI2.WinForms.Guna2Button btnLabelT6;
        private Guna.UI2.WinForms.Guna2Button btnLabelT7;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private System.Windows.Forms.Label lblSelectedCount;
        private System.Windows.Forms.Label lblLabelsTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlHistory;
        private System.Windows.Forms.FlowLayoutPanel flowSent;
        private Guna.UI2.WinForms.Guna2Panel pnlHistoryHeader;
        private System.Windows.Forms.Label lblHistoryCount;
        private System.Windows.Forms.Label lblHistoryTitle;
        private Guna.UI2.WinForms.Guna2MessageDialog msgDialog;
        private Guna.UI2.WinForms.Guna2Button btnLabelAll;
    }
}


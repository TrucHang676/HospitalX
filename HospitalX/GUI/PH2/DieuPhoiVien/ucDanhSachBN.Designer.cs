namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class ucDanhSachBN
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
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTableCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTableMeta = new System.Windows.Forms.Label();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.btnSelectAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeleteSelected = new Guna.UI2.WinForms.Guna2Button();
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMaBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBacSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrevPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFilterBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExcel = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnChipUrgent = new Guna.UI2.WinForms.Guna2Button();
            this.btnChipPending = new Guna.UI2.WinForms.Guna2Button();
            this.btnChipActive = new Guna.UI2.WinForms.Guna2Button();
            this.btnChipAll = new Guna.UI2.WinForms.Guna2Button();
            this.pnlModalOverlay = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlModal = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlScroll.SuspendLayout();
            this.pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlFilterBar.SuspendLayout();
            this.pnlModalOverlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Controls.Add(this.pnlTableCard);
            this.pnlScroll.Controls.Add(this.pnlFilterBar);
            this.pnlScroll.Controls.Add(this.btnChipUrgent);
            this.pnlScroll.Controls.Add(this.btnChipPending);
            this.pnlScroll.Controls.Add(this.btnChipActive);
            this.pnlScroll.Controls.Add(this.btnChipAll);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(4);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1453, 958);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlTableCard
            // 
            this.pnlTableCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTableCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlTableCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlTableCard.BorderRadius = 12;
            this.pnlTableCard.BorderThickness = 1;
            this.pnlTableCard.Controls.Add(this.lblTableMeta);
            this.pnlTableCard.Controls.Add(this.lblTableTitle);
            this.pnlTableCard.Controls.Add(this.btnSelectAll);
            this.pnlTableCard.Controls.Add(this.btnDeleteSelected);
            this.pnlTableCard.Controls.Add(this.dgvPatients);
            this.pnlTableCard.Controls.Add(this.lblPageInfo);
            this.pnlTableCard.Controls.Add(this.btnPrevPage);
            this.pnlTableCard.Controls.Add(this.btnNextPage);
            this.pnlTableCard.FillColor = System.Drawing.Color.White;
            this.pnlTableCard.Location = new System.Drawing.Point(27, 200);
            this.pnlTableCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTableCard.Name = "pnlTableCard";
            this.pnlTableCard.Size = new System.Drawing.Size(1387, 650);
            this.pnlTableCard.TabIndex = 5;
            // 
            // lblTableMeta
            // 
            this.lblTableMeta.AutoSize = true;
            this.lblTableMeta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTableMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTableMeta.Location = new System.Drawing.Point(23, 44);
            this.lblTableMeta.Name = "lblTableMeta";
            this.lblTableMeta.Size = new System.Drawing.Size(189, 20);
            this.lblTableMeta.TabIndex = 1;
            this.lblTableMeta.Text = "Hiển thị 10 / 10 bệnh nhân";
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.AutoSize = true;
            this.lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.lblTableTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(222, 25);
            this.lblTableTitle.TabIndex = 0;
            this.lblTableTitle.Text = "Danh sách bệnh nhân";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnSelectAll.BorderRadius = 8;
            this.btnSelectAll.BorderThickness = 1;
            this.btnSelectAll.FillColor = System.Drawing.Color.Transparent;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.btnSelectAll.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.btnSelectAll.Location = new System.Drawing.Point(1070, 15);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(140, 38);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "☑ Chọn tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelected.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.btnDeleteSelected.BorderRadius = 8;
            this.btnDeleteSelected.BorderThickness = 1;
            this.btnDeleteSelected.FillColor = System.Drawing.Color.Transparent;
            this.btnDeleteSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeleteSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnDeleteSelected.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.btnDeleteSelected.Location = new System.Drawing.Point(1225, 15);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(140, 38);
            this.btnDeleteSelected.TabIndex = 3;
            this.btnDeleteSelected.Text = "🗑 Xóa đã chọn";
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.AllowUserToDeleteRows = false;
            this.dgvPatients.AllowUserToResizeRows = false;
            this.dgvPatients.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colMaBN,
            this.colHoTen,
            this.colDob,
            this.colGioiTinh,
            this.colKhoa,
            this.colBacSi,
            this.colDate,
            this.colStatus,
            this.colThaoTac});
            this.dgvPatients.Location = new System.Drawing.Point(21, 75);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.Size = new System.Drawing.Size(1344, 490);
            this.dgvPatients.TabIndex = 4;
            // 
            // colCheck
            // 
            this.colCheck.HeaderText = "";
            this.colCheck.MinimumWidth = 40;
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 40;
            // 
            // colMaBN
            // 
            this.colMaBN.HeaderText = "MÃ BN";
            this.colMaBN.Name = "colMaBN";
            this.colMaBN.ReadOnly = true;
            // 
            // colHoTen
            // 
            this.colHoTen.HeaderText = "HỌ VÀ TÊN";
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colDob
            // 
            this.colDob.HeaderText = "NGÀY SINH";
            this.colDob.Name = "colDob";
            this.colDob.ReadOnly = true;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.HeaderText = "GIỚI TÍNH";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            // 
            // colKhoa
            // 
            this.colKhoa.HeaderText = "KHOA";
            this.colKhoa.Name = "colKhoa";
            this.colKhoa.ReadOnly = true;
            // 
            // colBacSi
            // 
            this.colBacSi.HeaderText = "BÁC SĨ PHỤ TRÁCH";
            this.colBacSi.Name = "colBacSi";
            this.colBacSi.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "NGÀY NHẬP VIỆN";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.HeaderText = "THAO TÁC";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            this.colThaoTac.Width = 175;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblPageInfo.Location = new System.Drawing.Point(1170, 595);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(89, 20);
            this.lblPageInfo.TabIndex = 5;
            this.lblPageInfo.Text = "Trang 1 / 1";
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.BorderRadius = 6;
            this.btnPrevPage.BorderThickness = 1;
            this.btnPrevPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnPrevPage.FillColor = System.Drawing.Color.Transparent;
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.btnPrevPage.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnPrevPage.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnPrevPage.Location = new System.Drawing.Point(1280, 587);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(36, 36);
            this.btnPrevPage.TabIndex = 6;
            this.btnPrevPage.Text = "‹";
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.BorderRadius = 6;
            this.btnNextPage.BorderThickness = 1;
            this.btnNextPage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnNextPage.FillColor = System.Drawing.Color.Transparent;
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.btnNextPage.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnNextPage.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnNextPage.Location = new System.Drawing.Point(1325, 587);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(36, 36);
            this.btnNextPage.TabIndex = 7;
            this.btnNextPage.Text = "›";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // pnlFilterBar
            // 
            this.pnlFilterBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilterBar.BackColor = System.Drawing.Color.Transparent;
            this.pnlFilterBar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFilterBar.BorderRadius = 12;
            this.pnlFilterBar.BorderThickness = 1;
            this.pnlFilterBar.Controls.Add(this.btnExcel);
            this.pnlFilterBar.Controls.Add(this.btnReset);
            this.pnlFilterBar.Controls.Add(this.lblToDate);
            this.pnlFilterBar.Controls.Add(this.dtpTo);
            this.pnlFilterBar.Controls.Add(this.lblFromDate);
            this.pnlFilterBar.Controls.Add(this.dtpFrom);
            this.pnlFilterBar.Controls.Add(this.lblGioiTinh);
            this.pnlFilterBar.Controls.Add(this.cboGioiTinh);
            this.pnlFilterBar.Controls.Add(this.lblKhoa);
            this.pnlFilterBar.Controls.Add(this.cboKhoa);
            this.pnlFilterBar.Controls.Add(this.lblSearch);
            this.pnlFilterBar.Controls.Add(this.txtSearch);
            this.pnlFilterBar.FillColor = System.Drawing.Color.White;
            this.pnlFilterBar.Location = new System.Drawing.Point(27, 76);
            this.pnlFilterBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1387, 108);
            this.pnlFilterBar.TabIndex = 4;
            // 
            // btnExcel
            // 
            this.btnExcel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnExcel.BorderRadius = 8;
            this.btnExcel.BorderThickness = 1;
            this.btnExcel.FillColor = System.Drawing.Color.Transparent;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.btnExcel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.btnExcel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnExcel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnExcel.Location = new System.Drawing.Point(1123, 44);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(120, 36);
            this.btnExcel.TabIndex = 13;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnReset
            // 
            this.btnReset.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnReset.BorderRadius = 8;
            this.btnReset.BorderThickness = 1;
            this.btnReset.FillColor = System.Drawing.Color.Transparent;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnReset.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(242)))));
            this.btnReset.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnReset.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnReset.Location = new System.Drawing.Point(1008, 44);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 36);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblToDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblToDate.Location = new System.Drawing.Point(850, 18);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(73, 17);
            this.lblToDate.TabIndex = 8;
            this.lblToDate.Text = "ĐẾN NGÀY";
            // 
            // dtpTo
            // 
            this.dtpTo.BorderRadius = 8;
            this.dtpTo.BorderThickness = 1;
            this.dtpTo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dtpTo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpTo.HoverState.FillColor = System.Drawing.Color.White;
            this.dtpTo.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpTo.CheckedState.FillColor = System.Drawing.Color.White;
            this.dtpTo.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpTo.Checked = true;
            this.dtpTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.CustomFormat = "MM/dd/yyyy";
            this.dtpTo.Location = new System.Drawing.Point(853, 44);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(140, 36);
            this.dtpTo.TabIndex = 9;
            this.dtpTo.Value = new System.DateTime(2026, 5, 24, 0, 0, 0, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.Filter_Changed);
            this.dtpTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblFromDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblFromDate.Location = new System.Drawing.Point(695, 18);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(65, 17);
            this.lblFromDate.TabIndex = 6;
            this.lblFromDate.Text = "TỪ NGÀY";
            // 
            // dtpFrom
            // 
            this.dtpFrom.BorderRadius = 8;
            this.dtpFrom.BorderThickness = 1;
            this.dtpFrom.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dtpFrom.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpFrom.HoverState.FillColor = System.Drawing.Color.White;
            this.dtpFrom.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpFrom.CheckedState.FillColor = System.Drawing.Color.White;
            this.dtpFrom.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpFrom.Checked = true;
            this.dtpFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.CustomFormat = "MM/dd/yyyy";
            this.dtpFrom.Location = new System.Drawing.Point(698, 44);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(140, 36);
            this.dtpFrom.TabIndex = 7;
            this.dtpFrom.Value = new System.DateTime(2026, 5, 1, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.Filter_Changed);
            this.dtpFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(575, 18);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(68, 17);
            this.lblGioiTinh.TabIndex = 4;
            this.lblGioiTinh.Text = "GIỚI TÍNH";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.BackColor = System.Drawing.Color.Transparent;
            this.cboGioiTinh.BorderRadius = 8;
            this.cboGioiTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.cboGioiTinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboGioiTinh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboGioiTinh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.cboGioiTinh.ItemHeight = 30;
            this.cboGioiTinh.Location = new System.Drawing.Point(578, 44);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(105, 36);
            this.cboGioiTinh.TabIndex = 5;
            this.cboGioiTinh.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKhoa.Location = new System.Drawing.Point(400, 18);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(43, 17);
            this.lblKhoa.TabIndex = 2;
            this.lblKhoa.Text = "KHOA";
            // 
            // cboKhoa
            // 
            this.cboKhoa.BackColor = System.Drawing.Color.Transparent;
            this.cboKhoa.BorderRadius = 8;
            this.cboKhoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.cboKhoa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(73)))));
            this.cboKhoa.ItemHeight = 30;
            this.cboKhoa.Location = new System.Drawing.Point(403, 44);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(160, 36);
            this.cboKhoa.TabIndex = 3;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSearch.Location = new System.Drawing.Point(18, 18);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(65, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "TÌM KIẾM";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Location = new System.Drawing.Point(21, 44);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Họ tên, mã BN, CCCD...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(365, 36);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // btnChipUrgent
            // 
            this.btnChipUrgent.BorderRadius = 18;
            this.btnChipUrgent.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChipUrgent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(236)))), ((int)(((byte)(234)))));
            this.btnChipUrgent.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnChipUrgent.FillColor = System.Drawing.Color.White;
            this.btnChipUrgent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChipUrgent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnChipUrgent.Location = new System.Drawing.Point(543, 20);
            this.btnChipUrgent.Name = "btnChipUrgent";
            this.btnChipUrgent.Size = new System.Drawing.Size(200, 36);
            this.btnChipUrgent.TabIndex = 3;
            this.btnChipUrgent.Text = "Cần điều phối KTV (7)";
            this.btnChipUrgent.Click += new System.EventHandler(this.btnChip_Click);
            // 
            // btnChipPending
            // 
            this.btnChipPending.BorderRadius = 18;
            this.btnChipPending.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChipPending.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(244)))), ((int)(((byte)(220)))));
            this.btnChipPending.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(23)))));
            this.btnChipPending.FillColor = System.Drawing.Color.White;
            this.btnChipPending.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChipPending.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnChipPending.Location = new System.Drawing.Point(367, 20);
            this.btnChipPending.Name = "btnChipPending";
            this.btnChipPending.Size = new System.Drawing.Size(165, 36);
            this.btnChipPending.TabIndex = 2;
            this.btnChipPending.Text = "Chờ xét nghiệm (12)";
            this.btnChipPending.Click += new System.EventHandler(this.btnChip_Click);
            // 
            // btnChipActive
            // 
            this.btnChipActive.BorderRadius = 18;
            this.btnChipActive.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChipActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnChipActive.CheckedState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnChipActive.FillColor = System.Drawing.Color.White;
            this.btnChipActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChipActive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnChipActive.Location = new System.Drawing.Point(177, 20);
            this.btnChipActive.Name = "btnChipActive";
            this.btnChipActive.Size = new System.Drawing.Size(180, 36);
            this.btnChipActive.TabIndex = 1;
            this.btnChipActive.Text = "Đang điều trị (23)";
            this.btnChipActive.Click += new System.EventHandler(this.btnChip_Click);
            // 
            // btnChipAll
            // 
            this.btnChipAll.BorderRadius = 18;
            this.btnChipAll.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnChipAll.Checked = true;
            this.btnChipAll.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnChipAll.CheckedState.ForeColor = System.Drawing.Color.White;
            this.btnChipAll.FillColor = System.Drawing.Color.White;
            this.btnChipAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnChipAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnChipAll.Location = new System.Drawing.Point(27, 20);
            this.btnChipAll.Name = "btnChipAll";
            this.btnChipAll.Size = new System.Drawing.Size(140, 36);
            this.btnChipAll.TabIndex = 0;
            this.btnChipAll.Text = "Tất cả (48)";
            this.btnChipAll.Click += new System.EventHandler(this.btnChip_Click);
            // 
            // pnlModalOverlay
            // 
            this.pnlModalOverlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlModalOverlay.Controls.Add(this.pnlModal);
            this.pnlModalOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModalOverlay.Location = new System.Drawing.Point(0, 0);
            this.pnlModalOverlay.Name = "pnlModalOverlay";
            this.pnlModalOverlay.Size = new System.Drawing.Size(1453, 958);
            this.pnlModalOverlay.TabIndex = 1;
            this.pnlModalOverlay.Visible = false;
            this.pnlModalOverlay.Click += new System.EventHandler(this.pnlModalOverlay_Click);
            // 
            // pnlModal — content is built programmatically in SetupModal()
            // 
            this.pnlModal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlModal.BorderRadius = 16;
            this.pnlModal.BorderThickness = 1;
            this.pnlModal.FillColor = System.Drawing.Color.White;
            this.pnlModal.Location = new System.Drawing.Point(466, 259);
            this.pnlModal.Name = "pnlModal";
            this.pnlModal.Size = new System.Drawing.Size(520, 440);
            this.pnlModal.TabIndex = 0;
            // 

            // 
            // ucDanhSachBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlModalOverlay);
            this.Controls.Add(this.pnlScroll);
            this.Name = "ucDanhSachBN";
            this.Size = new System.Drawing.Size(1453, 958);
            this.Load += new System.EventHandler(this.ucDanhSachBN_Load);
            this.pnlScroll.ResumeLayout(false);
            this.pnlTableCard.ResumeLayout(false);
            this.pnlTableCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.pnlFilterBar.ResumeLayout(false);
            this.pnlFilterBar.PerformLayout();
            this.pnlModalOverlay.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableMeta;
        private System.Windows.Forms.Label lblTableTitle;
        private Guna.UI2.WinForms.Guna2Button btnSelectAll;
        private Guna.UI2.WinForms.Guna2Button btnDeleteSelected;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Label lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnPrevPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2Panel pnlFilterBar;
        private Guna.UI2.WinForms.Guna2Button btnExcel;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private System.Windows.Forms.Label lblToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblFromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblGioiTinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblKhoa;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoa;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnChipUrgent;
        private Guna.UI2.WinForms.Guna2Button btnChipPending;
        private Guna.UI2.WinForms.Guna2Button btnChipActive;
        private Guna.UI2.WinForms.Guna2Button btnChipAll;
        private Guna.UI2.WinForms.Guna2Panel pnlModalOverlay;
        private Guna.UI2.WinForms.Guna2Panel pnlModal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDob;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBacSi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThaoTac;
    }
}

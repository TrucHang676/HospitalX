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
            this.dgvPatients = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMaBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCccd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoNha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuanHuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTinhTP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnPrevPage = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextPage = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFilterBar = new Guna.UI2.WinForms.Guna2Panel();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlScroll.SuspendLayout();
            this.pnlTableCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.pnlFilterBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Controls.Add(this.pnlTableCard);
            this.pnlScroll.Controls.Add(this.pnlFilterBar);
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
            this.pnlTableCard.Controls.Add(this.dgvPatients);
            this.pnlTableCard.Controls.Add(this.lblPageInfo);
            this.pnlTableCard.Controls.Add(this.btnPrevPage);
            this.pnlTableCard.Controls.Add(this.btnNextPage);
            this.pnlTableCard.FillColor = System.Drawing.Color.White;
            this.pnlTableCard.Location = new System.Drawing.Point(27, 120);
            this.pnlTableCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTableCard.Name = "pnlTableCard";
            this.pnlTableCard.Size = new System.Drawing.Size(1387, 845);
            this.pnlTableCard.TabIndex = 5;
            // 
            // lblTableMeta
            // 
            this.lblTableMeta.AutoSize = true;
            this.lblTableMeta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTableMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTableMeta.Location = new System.Drawing.Point(48, 44);
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
            this.lblTableTitle.Location = new System.Drawing.Point(48, 18);
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
            this.btnSelectAll.Size = new System.Drawing.Size(150, 38);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Chọn tất cả";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
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
            this.colCccd,
            this.colSoNha,
            this.colTenDuong,
            this.colQuanHuyen,
            this.colTinhTP,
            this.colThaoTac});
            this.dgvPatients.Location = new System.Drawing.Point(21, 75);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowHeadersVisible = false;
            this.dgvPatients.Size = new System.Drawing.Size(1344, 690);
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
            // colCccd
            // 
            this.colCccd.HeaderText = "CCCD";
            this.colCccd.Name = "colCccd";
            this.colCccd.ReadOnly = true;
            // 
            // colSoNha
            // 
            this.colSoNha.HeaderText = "SỐ NHÀ";
            this.colSoNha.Name = "colSoNha";
            this.colSoNha.ReadOnly = true;
            // 
            // colTenDuong
            // 
            this.colTenDuong.HeaderText = "TÊN ĐƯỜNG";
            this.colTenDuong.Name = "colTenDuong";
            this.colTenDuong.ReadOnly = true;
            // 
            // colQuanHuyen
            // 
            this.colQuanHuyen.HeaderText = "QUẬN/HUYỆN";
            this.colQuanHuyen.Name = "colQuanHuyen";
            this.colQuanHuyen.ReadOnly = true;
            // 
            // colTinhTP
            // 
            this.colTinhTP.HeaderText = "TỈNH/TP";
            this.colTinhTP.Name = "colTinhTP";
            this.colTinhTP.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.HeaderText = "THAO TÁC";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            this.colThaoTac.Width = 180;
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
            this.pnlFilterBar.Controls.Add(this.btnReset);
            this.pnlFilterBar.Controls.Add(this.lblGioiTinh);
            this.pnlFilterBar.Controls.Add(this.cboGioiTinh);
            this.pnlFilterBar.Controls.Add(this.lblSearch);
            this.pnlFilterBar.Controls.Add(this.txtSearch);
            this.pnlFilterBar.FillColor = System.Drawing.Color.White;
            this.pnlFilterBar.Location = new System.Drawing.Point(27, 20);
            this.pnlFilterBar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilterBar.Name = "pnlFilterBar";
            this.pnlFilterBar.Size = new System.Drawing.Size(1387, 85);
            this.pnlFilterBar.TabIndex = 4;
            // 
            // btnExcel
            // 
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
            this.btnReset.Location = new System.Drawing.Point(1008, 25);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 36);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "Đặt lại";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(400, 12);
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
            this.cboGioiTinh.Location = new System.Drawing.Point(403, 34);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(105, 36);
            this.cboGioiTinh.TabIndex = 5;
            this.cboGioiTinh.SelectedIndexChanged += new System.EventHandler(this.Filter_Changed);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSearch.Location = new System.Drawing.Point(18, 12);
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
            this.txtSearch.Location = new System.Drawing.Point(21, 34);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "Nhập mã BN, họ tên hoặc CCCD...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(365, 36);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.Filter_Changed);
            // 

            // 
            // ucDanhSachBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlTableCard;
        private System.Windows.Forms.Label lblTableMeta;
        private System.Windows.Forms.Label lblTableTitle;
        private Guna.UI2.WinForms.Guna2Button btnSelectAll;
        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.Label lblPageInfo;
        private Guna.UI2.WinForms.Guna2Button btnPrevPage;
        private Guna.UI2.WinForms.Guna2Button btnNextPage;
        private Guna.UI2.WinForms.Guna2Panel pnlFilterBar;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private System.Windows.Forms.Label lblGioiTinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDob;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCccd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoNha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuanHuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTinhTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThaoTac;
    }
}

using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class ucCapNhatHSBA
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
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlListCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.lblListSub = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvHsba = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaHSBA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBacSi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDetailCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDetailTitle = new System.Windows.Forms.Label();
            this.lblDetailSub = new System.Windows.Forms.Label();
            this.lblMaHSBALabel = new System.Windows.Forms.Label();
            this.txtMaHSBA = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenBNLabel = new System.Windows.Forms.Label();
            this.txtTenBN = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgayTaoLabel = new System.Windows.Forms.Label();
            this.txtNgayTao = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblChanDoanLabel = new System.Windows.Forms.Label();
            this.txtChanDoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDieuTriLabel = new System.Windows.Forms.Label();
            this.txtDieuTri = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblKetLuanLabel = new System.Windows.Forms.Label();
            this.txtKetLuan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblKhoaLabel = new System.Windows.Forms.Label();
            this.cboKhoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblBacSiLabel = new System.Windows.Forms.Label();
            this.cboBacSi = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnUpdate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.cboFacilityFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.cboDeptFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlScroll.SuspendLayout();
            this.pnlListCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHsba)).BeginInit();
            this.pnlDetailCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Controls.Add(this.pnlListCard);
            this.pnlScroll.Controls.Add(this.pnlDetailCard);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1200, 800);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlListCard
            // 
            this.pnlListCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlListCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlListCard.BorderRadius = 12;
            this.pnlListCard.BorderThickness = 1;
            this.pnlListCard.Controls.Add(this.lblListTitle);
            this.pnlListCard.Controls.Add(this.lblListSub);
            this.pnlListCard.Controls.Add(this.txtSearch);
            this.pnlListCard.Controls.Add(this.dgvHsba);
            this.pnlListCard.Controls.Add(this.cboFacilityFilter);
            this.pnlListCard.Controls.Add(this.cboDeptFilter);
            this.pnlListCard.FillColor = System.Drawing.Color.White;
            this.pnlListCard.Location = new System.Drawing.Point(20, 20);
            this.pnlListCard.Name = "pnlListCard";
            this.pnlListCard.Size = new System.Drawing.Size(730, 750);
            this.pnlListCard.TabIndex = 1;
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblListTitle.Location = new System.Drawing.Point(20, 20);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(325, 28);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "HỒ SƠ BỆNH ÁN ĐÃ TẠO";
            // 
            // lblListSub
            // 
            this.lblListSub.AutoSize = true;
            this.lblListSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblListSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblListSub.Location = new System.Drawing.Point(20, 48);
            this.lblListSub.Name = "lblListSub";
            this.lblListSub.Size = new System.Drawing.Size(180, 20);
            this.lblListSub.TabIndex = 1;
            this.lblListSub.Text = "Hiển thị 0 hồ sơ bệnh án";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Location = new System.Drawing.Point(330, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtSearch.PlaceholderText = "Tìm theo Mã HSBA, Tên bệnh nhân...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(380, 36);
            this.txtSearch.TabIndex = 2;
            // 
            // dgvHsba
            // 
            this.dgvHsba.AllowUserToAddRows = false;
            this.dgvHsba.AllowUserToDeleteRows = false;
            this.dgvHsba.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.dgvHsba.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHsba.BackgroundColor = System.Drawing.Color.White;
            this.dgvHsba.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHsba.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHsba.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHsba.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHsba.ColumnHeadersHeight = 36;
            this.dgvHsba.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHSBA,
            this.colMaBN,
            this.colTenBN,
            this.colNgay,
            this.colKhoa,
            this.colBacSi});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHsba.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHsba.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvHsba.Location = new System.Drawing.Point(20, 80);
            this.dgvHsba.MultiSelect = false;
            this.dgvHsba.Name = "dgvHsba";
            this.dgvHsba.ReadOnly = true;
            this.dgvHsba.RowHeadersVisible = false;
            this.dgvHsba.RowTemplate.Height = 48;
            this.dgvHsba.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHsba.Size = new System.Drawing.Size(690, 650);
            this.dgvHsba.TabIndex = 3;
            this.dgvHsba.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(250)))));
            this.dgvHsba.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvHsba.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvHsba.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvHsba.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvHsba.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvHsba.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvHsba.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.dgvHsba.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvHsba.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvHsba.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.dgvHsba.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHsba.ThemeStyle.HeaderStyle.Height = 36;
            this.dgvHsba.ThemeStyle.ReadOnly = true;
            this.dgvHsba.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvHsba.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHsba.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHsba.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.dgvHsba.ThemeStyle.RowsStyle.Height = 48;
            this.dgvHsba.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.dgvHsba.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            // 
            // colMaHSBA
            // 
            this.colMaHSBA.HeaderText = "MÃ HSBA";
            this.colMaHSBA.Name = "colMaHSBA";
            this.colMaHSBA.ReadOnly = true;
            this.colMaHSBA.Width = 100;
            // 
            // colMaBN
            // 
            this.colMaBN.HeaderText = "MÃ BN";
            this.colMaBN.Name = "colMaBN";
            this.colMaBN.ReadOnly = true;
            this.colMaBN.Width = 90;
            // 
            // colTenBN
            // 
            this.colTenBN.HeaderText = "TÊN BỆNH NHÂN";
            this.colTenBN.Name = "colTenBN";
            this.colTenBN.ReadOnly = true;
            this.colTenBN.Width = 140;
            // 
            // colNgay
            // 
            this.colNgay.HeaderText = "NGÀY TẠO";
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            this.colNgay.Width = 100;
            // 
            // colKhoa
            // 
            this.colKhoa.HeaderText = "KHOA";
            this.colKhoa.Name = "colKhoa";
            this.colKhoa.ReadOnly = true;
            this.colKhoa.Width = 110;
            // 
            // colBacSi
            // 
            this.colBacSi.HeaderText = "BÁC SĨ PHỤ TRÁCH";
            this.colBacSi.Name = "colBacSi";
            this.colBacSi.ReadOnly = true;
            this.colBacSi.Width = 150;
            // 
            // pnlDetailCard
            // 
            this.pnlDetailCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlDetailCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlDetailCard.BorderRadius = 12;
            this.pnlDetailCard.BorderThickness = 1;
            this.pnlDetailCard.Controls.Add(this.lblDetailTitle);
            this.pnlDetailCard.Controls.Add(this.lblDetailSub);
            this.pnlDetailCard.Controls.Add(this.lblMaHSBALabel);
            this.pnlDetailCard.Controls.Add(this.txtMaHSBA);
            this.pnlDetailCard.Controls.Add(this.lblTenBNLabel);
            this.pnlDetailCard.Controls.Add(this.txtTenBN);
            this.pnlDetailCard.Controls.Add(this.lblNgayTaoLabel);
            this.pnlDetailCard.Controls.Add(this.txtNgayTao);
            this.pnlDetailCard.Controls.Add(this.lblChanDoanLabel);
            this.pnlDetailCard.Controls.Add(this.txtChanDoan);
            this.pnlDetailCard.Controls.Add(this.lblDieuTriLabel);
            this.pnlDetailCard.Controls.Add(this.txtDieuTri);
            this.pnlDetailCard.Controls.Add(this.lblKetLuanLabel);
            this.pnlDetailCard.Controls.Add(this.txtKetLuan);
            this.pnlDetailCard.Controls.Add(this.lblKhoaLabel);
            this.pnlDetailCard.Controls.Add(this.cboKhoa);
            this.pnlDetailCard.Controls.Add(this.lblBacSiLabel);
            this.pnlDetailCard.Controls.Add(this.cboBacSi);
            this.pnlDetailCard.Controls.Add(this.btnUpdate);
            this.pnlDetailCard.Controls.Add(this.lblWarning);
            this.pnlDetailCard.FillColor = System.Drawing.Color.White;
            this.pnlDetailCard.Location = new System.Drawing.Point(770, 20);
            this.pnlDetailCard.Name = "pnlDetailCard";
            this.pnlDetailCard.Size = new System.Drawing.Size(410, 750);
            this.pnlDetailCard.TabIndex = 2;
            // 
            // lblDetailTitle
            // 
            this.lblDetailTitle.AutoSize = true;
            this.lblDetailTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.lblDetailTitle.Location = new System.Drawing.Point(20, 20);
            this.lblDetailTitle.Name = "lblDetailTitle";
            this.lblDetailTitle.Size = new System.Drawing.Size(222, 28);
            this.lblDetailTitle.TabIndex = 0;
            this.lblDetailTitle.Text = "CHI TIẾT CẬP NHẬT";
            // 
            // lblDetailSub
            // 
            this.lblDetailSub.AutoSize = true;
            this.lblDetailSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDetailSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDetailSub.Location = new System.Drawing.Point(20, 48);
            this.lblDetailSub.Name = "lblDetailSub";
            this.lblDetailSub.Size = new System.Drawing.Size(239, 20);
            this.lblDetailSub.TabIndex = 1;
            this.lblDetailSub.Text = "Cập nhật Khoa và Bác sĩ phụ trách";
            // 
            // lblMaHSBALabel
            // 
            this.lblMaHSBALabel.AutoSize = true;
            this.lblMaHSBALabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHSBALabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblMaHSBALabel.Location = new System.Drawing.Point(20, 85);
            this.lblMaHSBALabel.Name = "lblMaHSBALabel";
            this.lblMaHSBALabel.Size = new System.Drawing.Size(76, 20);
            this.lblMaHSBALabel.TabIndex = 2;
            this.lblMaHSBALabel.Text = "MÃ HSBA";
            // 
            // txtMaHSBA
            // 
            this.txtMaHSBA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtMaHSBA.BorderRadius = 8;
            this.txtMaHSBA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHSBA.DefaultText = "";
            this.txtMaHSBA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtMaHSBA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtMaHSBA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.txtMaHSBA.Enabled = false;
            this.txtMaHSBA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMaHSBA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtMaHSBA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtMaHSBA.Location = new System.Drawing.Point(20, 108);
            this.txtMaHSBA.Name = "txtMaHSBA";
            this.txtMaHSBA.PasswordChar = '\0';
            this.txtMaHSBA.PlaceholderText = "";
            this.txtMaHSBA.SelectedText = "";
            this.txtMaHSBA.Size = new System.Drawing.Size(170, 36);
            this.txtMaHSBA.TabIndex = 3;
            // 
            // lblTenBNLabel
            // 
            this.lblTenBNLabel.AutoSize = true;
            this.lblTenBNLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTenBNLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTenBNLabel.Location = new System.Drawing.Point(205, 85);
            this.lblTenBNLabel.Name = "lblTenBNLabel";
            this.lblTenBNLabel.Size = new System.Drawing.Size(96, 20);
            this.lblTenBNLabel.TabIndex = 4;
            this.lblTenBNLabel.Text = "BỆNH NHÂN";
            // 
            // txtTenBN
            // 
            this.txtTenBN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtTenBN.BorderRadius = 8;
            this.txtTenBN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenBN.DefaultText = "";
            this.txtTenBN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtTenBN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtTenBN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.txtTenBN.Enabled = false;
            this.txtTenBN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtTenBN.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtTenBN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtTenBN.Location = new System.Drawing.Point(205, 108);
            this.txtTenBN.Name = "txtTenBN";
            this.txtTenBN.PasswordChar = '\0';
            this.txtTenBN.PlaceholderText = "";
            this.txtTenBN.SelectedText = "";
            this.txtTenBN.Size = new System.Drawing.Size(185, 36);
            this.txtTenBN.TabIndex = 5;
            // 
            // lblNgayTaoLabel
            // 
            this.lblNgayTaoLabel.AutoSize = true;
            this.lblNgayTaoLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayTaoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblNgayTaoLabel.Location = new System.Drawing.Point(20, 155);
            this.lblNgayTaoLabel.Name = "lblNgayTaoLabel";
            this.lblNgayTaoLabel.Size = new System.Drawing.Size(89, 20);
            this.lblNgayTaoLabel.TabIndex = 6;
            this.lblNgayTaoLabel.Text = "NGÀY TẠO";
            // 
            // txtNgayTao
            // 
            this.txtNgayTao.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNgayTao.BorderRadius = 8;
            this.txtNgayTao.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNgayTao.DefaultText = "";
            this.txtNgayTao.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNgayTao.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtNgayTao.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.txtNgayTao.Enabled = false;
            this.txtNgayTao.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtNgayTao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtNgayTao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtNgayTao.Location = new System.Drawing.Point(20, 178);
            this.txtNgayTao.Name = "txtNgayTao";
            this.txtNgayTao.PasswordChar = '\0';
            this.txtNgayTao.PlaceholderText = "";
            this.txtNgayTao.SelectedText = "";
            this.txtNgayTao.Size = new System.Drawing.Size(370, 36);
            this.txtNgayTao.TabIndex = 7;
            // 
            // lblChanDoanLabel
            // 
            this.lblChanDoanLabel.AutoSize = true;
            this.lblChanDoanLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChanDoanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblChanDoanLabel.Location = new System.Drawing.Point(20, 225);
            this.lblChanDoanLabel.Name = "lblChanDoanLabel";
            this.lblChanDoanLabel.Size = new System.Drawing.Size(104, 20);
            this.lblChanDoanLabel.TabIndex = 8;
            this.lblChanDoanLabel.Text = "CHẨN ĐOÁN";
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtChanDoan.BorderRadius = 8;
            this.txtChanDoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChanDoan.DefaultText = "";
            this.txtChanDoan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtChanDoan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtChanDoan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.txtChanDoan.Enabled = false;
            this.txtChanDoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtChanDoan.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtChanDoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtChanDoan.Location = new System.Drawing.Point(20, 248);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.PasswordChar = '\0';
            this.txtChanDoan.PlaceholderText = "";
            this.txtChanDoan.SelectedText = "";
            this.txtChanDoan.Size = new System.Drawing.Size(370, 50);
            this.txtChanDoan.TabIndex = 9;
            // 
            // lblDieuTriLabel
            // 
            this.lblDieuTriLabel.AutoSize = true;
            this.lblDieuTriLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDieuTriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDieuTriLabel.Location = new System.Drawing.Point(20, 305);
            this.lblDieuTriLabel.Name = "lblDieuTriLabel";
            this.lblDieuTriLabel.Size = new System.Drawing.Size(76, 20);
            this.lblDieuTriLabel.TabIndex = 10;
            this.lblDieuTriLabel.Text = "ĐIỀU TRỊ";
            // 
            // txtDieuTri
            // 
            this.txtDieuTri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDieuTri.BorderRadius = 8;
            this.txtDieuTri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDieuTri.DefaultText = "";
            this.txtDieuTri.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDieuTri.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtDieuTri.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.txtDieuTri.Enabled = false;
            this.txtDieuTri.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDieuTri.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtDieuTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtDieuTri.Location = new System.Drawing.Point(20, 328);
            this.txtDieuTri.Multiline = true;
            this.txtDieuTri.Name = "txtDieuTri";
            this.txtDieuTri.PasswordChar = '\0';
            this.txtDieuTri.PlaceholderText = "";
            this.txtDieuTri.SelectedText = "";
            this.txtDieuTri.Size = new System.Drawing.Size(370, 50);
            this.txtDieuTri.TabIndex = 11;
            // 
            // lblKetLuanLabel
            // 
            this.lblKetLuanLabel.AutoSize = true;
            this.lblKetLuanLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblKetLuanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKetLuanLabel.Location = new System.Drawing.Point(20, 385);
            this.lblKetLuanLabel.Name = "lblKetLuanLabel";
            this.lblKetLuanLabel.Size = new System.Drawing.Size(81, 20);
            this.lblKetLuanLabel.TabIndex = 12;
            this.lblKetLuanLabel.Text = "KẾT LUÂN";
            // 
            // txtKetLuan
            // 
            this.txtKetLuan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtKetLuan.BorderRadius = 8;
            this.txtKetLuan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKetLuan.DefaultText = "";
            this.txtKetLuan.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtKetLuan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.txtKetLuan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.txtKetLuan.Enabled = false;
            this.txtKetLuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtKetLuan.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.txtKetLuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.txtKetLuan.Location = new System.Drawing.Point(20, 408);
            this.txtKetLuan.Multiline = true;
            this.txtKetLuan.Name = "txtKetLuan";
            this.txtKetLuan.PasswordChar = '\0';
            this.txtKetLuan.PlaceholderText = "";
            this.txtKetLuan.SelectedText = "";
            this.txtKetLuan.Size = new System.Drawing.Size(370, 50);
            this.txtKetLuan.TabIndex = 13;
            // 
            // lblKhoaLabel
            // 
            this.lblKhoaLabel.AutoSize = true;
            this.lblKhoaLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblKhoaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKhoaLabel.Location = new System.Drawing.Point(20, 465);
            this.lblKhoaLabel.Name = "lblKhoaLabel";
            this.lblKhoaLabel.Size = new System.Drawing.Size(126, 20);
            this.lblKhoaLabel.TabIndex = 14;
            this.lblKhoaLabel.Text = "KHOA PHỤ TRÁCH";
            // 
            // cboKhoa
            // 
            this.cboKhoa.BackColor = System.Drawing.Color.Transparent;
            this.cboKhoa.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboKhoa.BorderRadius = 8;
            this.cboKhoa.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoa.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKhoa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboKhoa.ItemHeight = 30;
            this.cboKhoa.Location = new System.Drawing.Point(20, 488);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(370, 36);
            this.cboKhoa.TabIndex = 15;
            // 
            // lblBacSiLabel
            // 
            this.lblBacSiLabel.AutoSize = true;
            this.lblBacSiLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBacSiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblBacSiLabel.Location = new System.Drawing.Point(20, 535);
            this.lblBacSiLabel.Name = "lblBacSiLabel";
            this.lblBacSiLabel.Size = new System.Drawing.Size(142, 20);
            this.lblBacSiLabel.TabIndex = 16;
            this.lblBacSiLabel.Text = "BÁC SĨ PHỤ TRÁCH";
            // 
            // cboBacSi
            // 
            this.cboBacSi.BackColor = System.Drawing.Color.Transparent;
            this.cboBacSi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboBacSi.BorderRadius = 8;
            this.cboBacSi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboBacSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBacSi.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboBacSi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboBacSi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboBacSi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboBacSi.ItemHeight = 30;
            this.cboBacSi.Location = new System.Drawing.Point(20, 558);
            this.cboBacSi.Name = "cboBacSi";
            this.cboBacSi.Size = new System.Drawing.Size(370, 36);
            this.cboBacSi.TabIndex = 17;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BorderRadius = 8;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnUpdate.Location = new System.Drawing.Point(20, 680);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(370, 45);
            this.btnUpdate.TabIndex = 18;
            this.btnUpdate.Text = "CẬP NHẬT HỒ SƠ";
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialog1.Text = null;
            // 
            // cboFacilityFilter
            // 
            this.cboFacilityFilter.BackColor = System.Drawing.Color.Transparent;
            this.cboFacilityFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboFacilityFilter.BorderRadius = 8;
            this.cboFacilityFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboFacilityFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFacilityFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboFacilityFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboFacilityFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboFacilityFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboFacilityFilter.ItemHeight = 30;
            this.cboFacilityFilter.Location = new System.Drawing.Point(150, 16);
            this.cboFacilityFilter.Name = "cboFacilityFilter";
            this.cboFacilityFilter.Size = new System.Drawing.Size(170, 36);
            this.cboFacilityFilter.TabIndex = 4;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblWarning.Location = new System.Drawing.Point(20, 620);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(350, 20);
            this.lblWarning.TabIndex = 19;
            this.lblWarning.Text = "⚠️ Chỉ được chỉnh sửa hồ sơ thuộc cơ sở của mình.";
            this.lblWarning.Visible = false;
            // 
            // cboDeptFilter
            // 
            this.cboDeptFilter.BackColor = System.Drawing.Color.Transparent;
            this.cboDeptFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboDeptFilter.BorderRadius = 8;
            this.cboDeptFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboDeptFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptFilter.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboDeptFilter.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboDeptFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboDeptFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboDeptFilter.ItemHeight = 30;
            this.cboDeptFilter.Location = new System.Drawing.Point(330, 16);
            this.cboDeptFilter.Name = "cboDeptFilter";
            this.cboDeptFilter.Size = new System.Drawing.Size(150, 36);
            this.cboDeptFilter.TabIndex = 5;
            // 
            // ucCapNhatHSBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.pnlScroll);
            this.Name = "ucCapNhatHSBA";
            this.Size = new System.Drawing.Size(1200, 800);
            this.pnlScroll.ResumeLayout(false);
            this.pnlListCard.ResumeLayout(false);
            this.pnlListCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHsba)).EndInit();
            this.pnlDetailCard.ResumeLayout(false);
            this.pnlDetailCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlListCard;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.Label lblListSub;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2DataGridView dgvHsba;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHSBA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBacSi;
        private Guna.UI2.WinForms.Guna2Panel pnlDetailCard;
        private System.Windows.Forms.Label lblDetailTitle;
        private System.Windows.Forms.Label lblDetailSub;
        private System.Windows.Forms.Label lblMaHSBALabel;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHSBA;
        private System.Windows.Forms.Label lblTenBNLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtTenBN;
        private System.Windows.Forms.Label lblNgayTaoLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtNgayTao;
        private System.Windows.Forms.Label lblChanDoanLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtChanDoan;
        private System.Windows.Forms.Label lblDieuTriLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtDieuTri;
        private System.Windows.Forms.Label lblKetLuanLabel;
        private Guna.UI2.WinForms.Guna2TextBox txtKetLuan;
        private System.Windows.Forms.Label lblKhoaLabel;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoa;
        private System.Windows.Forms.Label lblBacSiLabel;
        private Guna.UI2.WinForms.Guna2ComboBox cboBacSi;
        private Guna.UI2.WinForms.Guna2Button btnUpdate;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
        private Guna.UI2.WinForms.Guna2ComboBox cboFacilityFilter;
        private System.Windows.Forms.Label lblWarning;
        private Guna.UI2.WinForms.Guna2ComboBox cboDeptFilter;
    }
}

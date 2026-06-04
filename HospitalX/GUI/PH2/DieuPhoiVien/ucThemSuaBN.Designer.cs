namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class ucThemSuaBN
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThemSuaBN));
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSegment = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTabAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabEdit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSearchCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFormCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBasicTitle = new System.Windows.Forms.Label();
            this.lblHoDem = new System.Windows.Forms.Label();
            this.txtHoDem = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTen = new System.Windows.Forms.Label();
            this.txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMaBN = new System.Windows.Forms.Label();
            this.txtMaBN = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCccd = new System.Windows.Forms.Label();
            this.txtCccd = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSoNha = new System.Windows.Forms.Label();
            this.txtSoNha = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTenDuong = new System.Windows.Forms.Label();
            this.txtTenDuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblQuanHuyen = new System.Windows.Forms.Label();
            this.txtQuanHuyen = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTinhTP = new System.Windows.Forms.Label();
            this.txtTinhTP = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblMedicalTitle = new System.Windows.Forms.Label();
            this.lblTienSuBN = new System.Windows.Forms.Label();
            this.txtTienSuBN = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienSuGD = new System.Windows.Forms.Label();
            this.txtTienSuGD = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiUng = new System.Windows.Forms.Label();
            this.txtDiUng = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlFormFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRequired = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlScroll.SuspendLayout();
            this.pnlSegment.SuspendLayout();
            this.pnlSearchCard.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            this.pnlFormFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMargin = new System.Drawing.Size(0, 40);
            this.pnlScroll.Controls.Add(this.pnlSegment);
            this.pnlScroll.Controls.Add(this.pnlSearchCard);
            this.pnlScroll.Controls.Add(this.pnlFormCard);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1028, 691);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlSegment
            // 
            this.pnlSegment.BackColor = System.Drawing.Color.Transparent;
            this.pnlSegment.Controls.Add(this.btnTabAdd);
            this.pnlSegment.Controls.Add(this.btnTabEdit);
            this.pnlSegment.Location = new System.Drawing.Point(20, 16);
            this.pnlSegment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSegment.Name = "pnlSegment";
            this.pnlSegment.Size = new System.Drawing.Size(987, 49);
            this.pnlSegment.TabIndex = 0;
            // 
            // btnTabAdd
            // 
            this.btnTabAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnTabAdd.BorderRadius = 10;
            this.btnTabAdd.BorderThickness = 1;
            this.btnTabAdd.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabAdd.Checked = true;
            this.btnTabAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabAdd.ForeColor = System.Drawing.Color.White;
            this.btnTabAdd.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnTabAdd.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabAdd.Location = new System.Drawing.Point(0, 8);
            this.btnTabAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTabAdd.Name = "btnTabAdd";
            this.btnTabAdd.Size = new System.Drawing.Size(150, 32);
            this.btnTabAdd.TabIndex = 0;
            this.btnTabAdd.Text = "Thêm bệnh nhân mới";
            this.btnTabAdd.Click += new System.EventHandler(this.btnTabAdd_Click);
            // 
            // btnTabEdit
            // 
            this.btnTabEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnTabEdit.BorderRadius = 10;
            this.btnTabEdit.BorderThickness = 1;
            this.btnTabEdit.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabEdit.ForeColor = System.Drawing.Color.White;
            this.btnTabEdit.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabEdit.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.btnTabEdit.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnTabEdit.Location = new System.Drawing.Point(162, 8);
            this.btnTabEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTabEdit.Name = "btnTabEdit";
            this.btnTabEdit.Size = new System.Drawing.Size(180, 32);
            this.btnTabEdit.TabIndex = 1;
            this.btnTabEdit.Text = "Sửa thông tin bệnh nhân";
            this.btnTabEdit.Click += new System.EventHandler(this.btnTabEdit_Click);
            // 
            // pnlSearchCard
            // 
            this.pnlSearchCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlSearchCard.BorderRadius = 12;
            this.pnlSearchCard.BorderThickness = 1;
            this.pnlSearchCard.Controls.Add(this.lblSearchTitle);
            this.pnlSearchCard.Controls.Add(this.txtSearch);
            this.pnlSearchCard.Controls.Add(this.btnSearch);
            this.pnlSearchCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlSearchCard.Location = new System.Drawing.Point(20, 65);
            this.pnlSearchCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSearchCard.Name = "pnlSearchCard";
            this.pnlSearchCard.Size = new System.Drawing.Size(987, 73);
            this.pnlSearchCard.TabIndex = 2;
            this.pnlSearchCard.Visible = false;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblSearchTitle.Location = new System.Drawing.Point(30, 13);
            this.lblSearchTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(156, 15);
            this.lblSearchTitle.TabIndex = 0;
            this.lblSearchTitle.Text = "TÌM BỆNH NHÂN CẦN SỬA";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearch.Location = new System.Drawing.Point(30, 32);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(251, 29);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BorderRadius = 8;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnSearch.Location = new System.Drawing.Point(882, 32);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 29);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            // 
            // pnlFormCard
            // 
            this.pnlFormCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFormCard.BorderRadius = 16;
            this.pnlFormCard.BorderThickness = 1;
            this.pnlFormCard.Controls.Add(this.lblBasicTitle);
            this.pnlFormCard.Controls.Add(this.lblHoDem);
            this.pnlFormCard.Controls.Add(this.txtHoDem);
            this.pnlFormCard.Controls.Add(this.lblTen);
            this.pnlFormCard.Controls.Add(this.txtTen);
            this.pnlFormCard.Controls.Add(this.lblMaBN);
            this.pnlFormCard.Controls.Add(this.txtMaBN);
            this.pnlFormCard.Controls.Add(this.lblNgaySinh);
            this.pnlFormCard.Controls.Add(this.dtpNgaySinh);
            this.pnlFormCard.Controls.Add(this.lblGioiTinh);
            this.pnlFormCard.Controls.Add(this.cboGioiTinh);
            this.pnlFormCard.Controls.Add(this.lblCccd);
            this.pnlFormCard.Controls.Add(this.txtCccd);
            this.pnlFormCard.Controls.Add(this.lblSoNha);
            this.pnlFormCard.Controls.Add(this.txtSoNha);
            this.pnlFormCard.Controls.Add(this.lblTenDuong);
            this.pnlFormCard.Controls.Add(this.txtTenDuong);
            this.pnlFormCard.Controls.Add(this.lblQuanHuyen);
            this.pnlFormCard.Controls.Add(this.txtQuanHuyen);
            this.pnlFormCard.Controls.Add(this.lblTinhTP);
            this.pnlFormCard.Controls.Add(this.txtTinhTP);
            this.pnlFormCard.Controls.Add(this.lblMedicalTitle);
            this.pnlFormCard.Controls.Add(this.lblTienSuBN);
            this.pnlFormCard.Controls.Add(this.txtTienSuBN);
            this.pnlFormCard.Controls.Add(this.lblTienSuGD);
            this.pnlFormCard.Controls.Add(this.txtTienSuGD);
            this.pnlFormCard.Controls.Add(this.lblDiUng);
            this.pnlFormCard.Controls.Add(this.txtDiUng);
            this.pnlFormCard.Controls.Add(this.pnlFormFooter);
            this.pnlFormCard.FillColor = System.Drawing.Color.White;
            this.pnlFormCard.Location = new System.Drawing.Point(20, 65);
            this.pnlFormCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFormCard.Name = "pnlFormCard";
            this.pnlFormCard.Size = new System.Drawing.Size(987, 715);
            this.pnlFormCard.TabIndex = 1;
            // 
            // lblBasicTitle
            // 
            this.lblBasicTitle.AutoSize = true;
            this.lblBasicTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBasicTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBasicTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblBasicTitle.Location = new System.Drawing.Point(30, 24);
            this.lblBasicTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBasicTitle.Name = "lblBasicTitle";
            this.lblBasicTitle.Size = new System.Drawing.Size(145, 19);
            this.lblBasicTitle.TabIndex = 101;
            this.lblBasicTitle.Text = "THÔNG TIN CƠ BẢN";
            // 
            // lblHoDem
            // 
            this.lblHoDem.Location = new System.Drawing.Point(30, 53);
            this.lblHoDem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHoDem.Name = "lblHoDem";
            this.lblHoDem.Size = new System.Drawing.Size(75, 19);
            this.lblHoDem.TabIndex = 102;
            // 
            // txtHoDem
            // 
            this.txtHoDem.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHoDem.DefaultText = "";
            this.txtHoDem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtHoDem.Location = new System.Drawing.Point(30, 73);
            this.txtHoDem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtHoDem.Name = "txtHoDem";
            this.txtHoDem.PlaceholderText = "";
            this.txtHoDem.SelectedText = "";
            this.txtHoDem.Size = new System.Drawing.Size(297, 31);
            this.txtHoDem.TabIndex = 103;
            // 
            // lblTen
            // 
            this.lblTen.Location = new System.Drawing.Point(345, 53);
            this.lblTen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTen.Name = "lblTen";
            this.lblTen.Size = new System.Drawing.Size(75, 19);
            this.lblTen.TabIndex = 104;
            // 
            // txtTen
            // 
            this.txtTen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTen.DefaultText = "";
            this.txtTen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTen.Location = new System.Drawing.Point(345, 73);
            this.txtTen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTen.Name = "txtTen";
            this.txtTen.PlaceholderText = "";
            this.txtTen.SelectedText = "";
            this.txtTen.Size = new System.Drawing.Size(297, 31);
            this.txtTen.TabIndex = 105;
            // 
            // lblMaBN
            // 
            this.lblMaBN.Location = new System.Drawing.Point(660, 53);
            this.lblMaBN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaBN.Name = "lblMaBN";
            this.lblMaBN.Size = new System.Drawing.Size(75, 19);
            this.lblMaBN.TabIndex = 106;
            // 
            // txtMaBN
            // 
            this.txtMaBN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaBN.DefaultText = "";
            this.txtMaBN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMaBN.Location = new System.Drawing.Point(660, 73);
            this.txtMaBN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaBN.Name = "txtMaBN";
            this.txtMaBN.PlaceholderText = "";
            this.txtMaBN.SelectedText = "";
            this.txtMaBN.Size = new System.Drawing.Size(297, 31);
            this.txtMaBN.TabIndex = 107;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Location = new System.Drawing.Point(30, 122);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(75, 19);
            this.lblNgaySinh.TabIndex = 108;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.BackColor = System.Drawing.Color.Transparent;
            this.dtpNgaySinh.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dtpNgaySinh.BorderRadius = 8;
            this.dtpNgaySinh.BorderThickness = 1;
            this.dtpNgaySinh.Checked = true;
            this.dtpNgaySinh.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpNgaySinh.CheckedState.FillColor = System.Drawing.Color.White;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.dtpNgaySinh.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpNgaySinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpNgaySinh.HoverState.FillColor = System.Drawing.Color.White;
            this.dtpNgaySinh.Location = new System.Drawing.Point(30, 142);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpNgaySinh.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgaySinh.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(297, 31);
            this.dtpNgaySinh.TabIndex = 109;
            this.dtpNgaySinh.TextOffset = new System.Drawing.Point(8, 0);
            this.dtpNgaySinh.Value = new System.DateTime(2026, 6, 4, 2, 36, 54, 466);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Location = new System.Drawing.Point(345, 122);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(75, 19);
            this.lblGioiTinh.TabIndex = 110;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.BackColor = System.Drawing.Color.Transparent;
            this.cboGioiTinh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.FocusedColor = System.Drawing.Color.Empty;
            this.cboGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGioiTinh.ItemHeight = 30;
            this.cboGioiTinh.Location = new System.Drawing.Point(345, 142);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(298, 36);
            this.cboGioiTinh.TabIndex = 111;
            // 
            // lblCccd
            // 
            this.lblCccd.Location = new System.Drawing.Point(660, 122);
            this.lblCccd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCccd.Name = "lblCccd";
            this.lblCccd.Size = new System.Drawing.Size(75, 19);
            this.lblCccd.TabIndex = 112;
            // 
            // txtCccd
            // 
            this.txtCccd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCccd.DefaultText = "";
            this.txtCccd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCccd.Location = new System.Drawing.Point(660, 142);
            this.txtCccd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCccd.Name = "txtCccd";
            this.txtCccd.PlaceholderText = "079xxxxxxxxxx";
            this.txtCccd.SelectedText = "";
            this.txtCccd.Size = new System.Drawing.Size(297, 31);
            this.txtCccd.TabIndex = 113;
            // 
            // lblSoNha
            // 
            this.lblSoNha.Location = new System.Drawing.Point(30, 191);
            this.lblSoNha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoNha.Name = "lblSoNha";
            this.lblSoNha.Size = new System.Drawing.Size(75, 19);
            this.lblSoNha.TabIndex = 114;
            // 
            // txtSoNha
            // 
            this.txtSoNha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSoNha.DefaultText = "";
            this.txtSoNha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSoNha.Location = new System.Drawing.Point(30, 211);
            this.txtSoNha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSoNha.Name = "txtSoNha";
            this.txtSoNha.PlaceholderText = "Ví dụ: 123";
            this.txtSoNha.SelectedText = "";
            this.txtSoNha.Size = new System.Drawing.Size(297, 31);
            this.txtSoNha.TabIndex = 115;
            // 
            // lblTenDuong
            // 
            this.lblTenDuong.Location = new System.Drawing.Point(345, 191);
            this.lblTenDuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTenDuong.Name = "lblTenDuong";
            this.lblTenDuong.Size = new System.Drawing.Size(75, 19);
            this.lblTenDuong.TabIndex = 116;
            // 
            // txtTenDuong
            // 
            this.txtTenDuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTenDuong.DefaultText = "";
            this.txtTenDuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTenDuong.Location = new System.Drawing.Point(345, 211);
            this.txtTenDuong.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenDuong.Name = "txtTenDuong";
            this.txtTenDuong.PlaceholderText = "Ví dụ: Đường Ba Tháng Hai";
            this.txtTenDuong.SelectedText = "";
            this.txtTenDuong.Size = new System.Drawing.Size(612, 31);
            this.txtTenDuong.TabIndex = 117;
            // 
            // lblQuanHuyen
            // 
            this.lblQuanHuyen.Location = new System.Drawing.Point(30, 260);
            this.lblQuanHuyen.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuanHuyen.Name = "lblQuanHuyen";
            this.lblQuanHuyen.Size = new System.Drawing.Size(75, 19);
            this.lblQuanHuyen.TabIndex = 118;
            // 
            // txtQuanHuyen
            // 
            this.txtQuanHuyen.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuanHuyen.DefaultText = "";
            this.txtQuanHuyen.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtQuanHuyen.Location = new System.Drawing.Point(30, 280);
            this.txtQuanHuyen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtQuanHuyen.Name = "txtQuanHuyen";
            this.txtQuanHuyen.PlaceholderText = "Ví dụ: Quận 10";
            this.txtQuanHuyen.SelectedText = "";
            this.txtQuanHuyen.Size = new System.Drawing.Size(462, 31);
            this.txtQuanHuyen.TabIndex = 119;
            // 
            // lblTinhTP
            // 
            this.lblTinhTP.Location = new System.Drawing.Point(510, 260);
            this.lblTinhTP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTinhTP.Name = "lblTinhTP";
            this.lblTinhTP.Size = new System.Drawing.Size(75, 19);
            this.lblTinhTP.TabIndex = 120;
            // 
            // txtTinhTP
            // 
            this.txtTinhTP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTinhTP.DefaultText = "";
            this.txtTinhTP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTinhTP.Location = new System.Drawing.Point(510, 280);
            this.txtTinhTP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTinhTP.Name = "txtTinhTP";
            this.txtTinhTP.PlaceholderText = "Ví dụ: TP. Hồ Chí Minh";
            this.txtTinhTP.SelectedText = "";
            this.txtTinhTP.Size = new System.Drawing.Size(447, 31);
            this.txtTinhTP.TabIndex = 121;
            // 
            // lblMedicalTitle
            // 
            this.lblMedicalTitle.AutoSize = true;
            this.lblMedicalTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicalTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMedicalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblMedicalTitle.Location = new System.Drawing.Point(30, 339);
            this.lblMedicalTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMedicalTitle.Name = "lblMedicalTitle";
            this.lblMedicalTitle.Size = new System.Drawing.Size(120, 19);
            this.lblMedicalTitle.TabIndex = 122;
            this.lblMedicalTitle.Text = "TIỀN SỬ Y KHOA";
            // 
            // lblTienSuBN
            // 
            this.lblTienSuBN.Location = new System.Drawing.Point(30, 367);
            this.lblTienSuBN.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTienSuBN.Name = "lblTienSuBN";
            this.lblTienSuBN.Size = new System.Drawing.Size(75, 19);
            this.lblTienSuBN.TabIndex = 123;
            // 
            // txtTienSuBN
            // 
            this.txtTienSuBN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienSuBN.DefaultText = "";
            this.txtTienSuBN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTienSuBN.Location = new System.Drawing.Point(30, 388);
            this.txtTienSuBN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTienSuBN.Multiline = true;
            this.txtTienSuBN.Name = "txtTienSuBN";
            this.txtTienSuBN.PlaceholderText = "Bệnh nền, phẫu thuật trước đây, các bệnh mãn tính...";
            this.txtTienSuBN.SelectedText = "";
            this.txtTienSuBN.Size = new System.Drawing.Size(927, 57);
            this.txtTienSuBN.TabIndex = 124;
            // 
            // lblTienSuGD
            // 
            this.lblTienSuGD.Location = new System.Drawing.Point(30, 461);
            this.lblTienSuGD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTienSuGD.Name = "lblTienSuGD";
            this.lblTienSuGD.Size = new System.Drawing.Size(75, 19);
            this.lblTienSuGD.TabIndex = 125;
            // 
            // txtTienSuGD
            // 
            this.txtTienSuGD.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTienSuGD.DefaultText = "";
            this.txtTienSuGD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTienSuGD.Location = new System.Drawing.Point(30, 481);
            this.txtTienSuGD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTienSuGD.Multiline = true;
            this.txtTienSuGD.Name = "txtTienSuGD";
            this.txtTienSuGD.PlaceholderText = "Tiểu đường, tim mạch, ung thư trong gia đình...";
            this.txtTienSuGD.SelectedText = "";
            this.txtTienSuGD.Size = new System.Drawing.Size(927, 57);
            this.txtTienSuGD.TabIndex = 126;
            // 
            // lblDiUng
            // 
            this.lblDiUng.Location = new System.Drawing.Point(30, 554);
            this.lblDiUng.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiUng.Name = "lblDiUng";
            this.lblDiUng.Size = new System.Drawing.Size(75, 19);
            this.lblDiUng.TabIndex = 127;
            // 
            // txtDiUng
            // 
            this.txtDiUng.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDiUng.DefaultText = "";
            this.txtDiUng.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDiUng.Location = new System.Drawing.Point(30, 574);
            this.txtDiUng.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiUng.Multiline = true;
            this.txtDiUng.Name = "txtDiUng";
            this.txtDiUng.PlaceholderText = "Tên thuốc gây dị ứng, phản ứng phụ đã gặp...";
            this.txtDiUng.SelectedText = "";
            this.txtDiUng.Size = new System.Drawing.Size(927, 57);
            this.txtDiUng.TabIndex = 128;
            // 
            // pnlFormFooter
            // 
            this.pnlFormFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormFooter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFormFooter.BorderThickness = 1;
            this.pnlFormFooter.Controls.Add(this.lblRequired);
            this.pnlFormFooter.Controls.Add(this.btnCancel);
            this.pnlFormFooter.Controls.Add(this.btnSave);
            this.pnlFormFooter.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlFormFooter.FillColor = System.Drawing.Color.White;
            this.pnlFormFooter.Location = new System.Drawing.Point(0, 650);
            this.pnlFormFooter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlFormFooter.Name = "pnlFormFooter";
            this.pnlFormFooter.Size = new System.Drawing.Size(987, 65);
            this.pnlFormFooter.TabIndex = 10;
            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.BackColor = System.Drawing.Color.Transparent;
            this.lblRequired.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRequired.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(42)))), ((int)(((byte)(20)))));
            this.lblRequired.Location = new System.Drawing.Point(30, 24);
            this.lblRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRequired.Name = "lblRequired";
            this.lblRequired.Size = new System.Drawing.Size(111, 15);
            this.lblRequired.TabIndex = 0;
            this.lblRequired.Text = "(*) Trường bắt buộc";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.btnCancel.Location = new System.Drawing.Point(690, 16);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnSave.Location = new System.Drawing.Point(807, 16);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Thêm bệnh nhân";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = "Thông báo";
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            this.guna2MessageDialog1.Text = null;
            // 
            // ucThemSuaBN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScroll);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucThemSuaBN";
            this.Size = new System.Drawing.Size(1028, 691);
            this.Load += new System.EventHandler(this.ucThemSuaBN_Load);
            this.pnlScroll.ResumeLayout(false);
            this.pnlSegment.ResumeLayout(false);
            this.pnlSearchCard.ResumeLayout(false);
            this.pnlSearchCard.PerformLayout();
            this.pnlFormCard.ResumeLayout(false);
            this.pnlFormCard.PerformLayout();
            this.pnlFormFooter.ResumeLayout(false);
            this.pnlFormFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlSegment;
        private Guna.UI2.WinForms.Guna2Button btnTabAdd;
        private Guna.UI2.WinForms.Guna2Button btnTabEdit;
        private Guna.UI2.WinForms.Guna2Panel pnlFormCard;

        private System.Windows.Forms.Label lblBasicTitle;
        private System.Windows.Forms.Label lblHoDem;
        private Guna.UI2.WinForms.Guna2TextBox txtHoDem;
        private System.Windows.Forms.Label lblTen;
        private Guna.UI2.WinForms.Guna2TextBox txtTen;
        private System.Windows.Forms.Label lblMaBN;
        private Guna.UI2.WinForms.Guna2TextBox txtMaBN;
        private System.Windows.Forms.Label lblNgaySinh;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblGioiTinh;
        private Guna.UI2.WinForms.Guna2ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblCccd;
        private Guna.UI2.WinForms.Guna2TextBox txtCccd;
        private System.Windows.Forms.Label lblSoNha;
        private Guna.UI2.WinForms.Guna2TextBox txtSoNha;
        private System.Windows.Forms.Label lblTenDuong;
        private Guna.UI2.WinForms.Guna2TextBox txtTenDuong;
        private System.Windows.Forms.Label lblQuanHuyen;
        private Guna.UI2.WinForms.Guna2TextBox txtQuanHuyen;
        private System.Windows.Forms.Label lblTinhTP;
        private Guna.UI2.WinForms.Guna2TextBox txtTinhTP;

        private System.Windows.Forms.Label lblMedicalTitle;
        private System.Windows.Forms.Label lblTienSuBN;
        private Guna.UI2.WinForms.Guna2TextBox txtTienSuBN;
        private System.Windows.Forms.Label lblTienSuGD;
        private Guna.UI2.WinForms.Guna2TextBox txtTienSuGD;
        private System.Windows.Forms.Label lblDiUng;
        private Guna.UI2.WinForms.Guna2TextBox txtDiUng;

        private Guna.UI2.WinForms.Guna2Panel pnlSearchCard;
        private System.Windows.Forms.Label lblSearchTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;

        private Guna.UI2.WinForms.Guna2Panel pnlFormFooter;
        private System.Windows.Forms.Label lblRequired;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}

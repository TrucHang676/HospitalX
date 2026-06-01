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
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSegment = new Guna.UI2.WinForms.Guna2Panel();
            this.btnTabAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnTabEdit = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSearchCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.ptbSearchIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFormCard = new Guna.UI2.WinForms.Guna2Panel();
            
            // Avatar
            this.lblAvatarTitle = new System.Windows.Forms.Label();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnUpload = new Guna.UI2.WinForms.Guna2Button();
            this.lblAvatarDesc = new System.Windows.Forms.Label();

            // Basic Info
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
            this.lblNhomMau = new System.Windows.Forms.Label();
            this.cboNhomMau = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblCccd = new System.Windows.Forms.Label();
            this.txtCccd = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblCccdDesc = new System.Windows.Forms.Label();
            this.lblBhyt = new System.Windows.Forms.Label();
            this.txtBhyt = new Guna.UI2.WinForms.Guna2TextBox();

            // Contact Info
            this.lblContactTitle = new System.Windows.Forms.Label();
            this.lblSdt = new System.Windows.Forms.Label();
            this.txtSdt = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNguoiLienHe = new System.Windows.Forms.Label();
            this.txtNguoiLienHe = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new Guna.UI2.WinForms.Guna2TextBox();

            // Treatment Info
            this.lblTreatmentTitle = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.cboKhoa = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblHinhThuc = new System.Windows.Forms.Label();
            this.cboHinhThuc = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.dtpNgayNhap = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienSu = new System.Windows.Forms.Label();
            this.txtTienSu = new Guna.UI2.WinForms.Guna2TextBox();

            // Footer Panel
            this.pnlFormFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRequired = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnDraft = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ptbBasicIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbContactIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbTreatmentIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();

            this.pnlScroll.SuspendLayout();
            this.pnlSegment.SuspendLayout();
            this.pnlSearchCard.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSearchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBasicIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbContactIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTreatmentIcon)).BeginInit();
            this.pnlFormFooter.SuspendLayout();
            this.SuspendLayout();

            // Colors & Styling definitions
            var labelColor = System.Drawing.Color.FromArgb(122, 149, 137);
            var titleColor = System.Drawing.Color.FromArgb(15, 110, 86);
            var inputForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            var cardBorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            var inputBackColor = System.Drawing.Color.FromArgb(247, 249, 248);

            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMargin = new System.Drawing.Size(0, 40);
            this.pnlScroll.Controls.Add(this.pnlSegment);
            this.pnlScroll.Controls.Add(this.pnlSearchCard);
            this.pnlScroll.Controls.Add(this.pnlFormCard);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(244, 247, 246);
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1370, 850);
            this.pnlScroll.TabIndex = 0;

            // 
            // pnlSegment
            // 
            this.pnlSegment.Controls.Add(this.btnTabAdd);
            this.pnlSegment.Controls.Add(this.btnTabEdit);
            this.pnlSegment.Location = new System.Drawing.Point(27, 20);
            this.pnlSegment.Name = "pnlSegment";
            this.pnlSegment.Size = new System.Drawing.Size(1316, 60);
            this.pnlSegment.TabIndex = 0;
            this.pnlSegment.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnTabAdd
            // 
            this.btnTabAdd.BorderRadius = 20;
            this.btnTabAdd.BorderThickness = 1;
            this.btnTabAdd.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabAdd.Checked = true;
            this.btnTabAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabAdd.Location = new System.Drawing.Point(0, 10);
            this.btnTabAdd.Name = "btnTabAdd";
            this.btnTabAdd.Size = new System.Drawing.Size(200, 40);
            this.btnTabAdd.TabIndex = 0;
            this.btnTabAdd.Text = "Thêm bệnh nhân mới";
            this.btnTabAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnTabAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 244, 240);
            this.btnTabAdd.HoverState.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnTabAdd.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnTabAdd.Click += new System.EventHandler(this.btnTabAdd_Click);

            // 
            // btnTabEdit
            // 
            this.btnTabEdit.BorderRadius = 20;
            this.btnTabEdit.BorderThickness = 1;
            this.btnTabEdit.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnTabEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTabEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnTabEdit.Location = new System.Drawing.Point(216, 10);
            this.btnTabEdit.Name = "btnTabEdit";
            this.btnTabEdit.Size = new System.Drawing.Size(240, 40);
            this.btnTabEdit.TabIndex = 1;
            this.btnTabEdit.Text = "Sửa thông tin bệnh nhân";
            this.btnTabEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnTabEdit.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 244, 240);
            this.btnTabEdit.HoverState.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnTabEdit.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnTabEdit.Click += new System.EventHandler(this.btnTabEdit_Click);

            // 
            // pnlSearchCard
            // 
            this.pnlSearchCard.BorderColor = cardBorderColor;
            this.pnlSearchCard.BorderRadius = 12;
            this.pnlSearchCard.BorderThickness = 1;
            this.pnlSearchCard.FillColor = System.Drawing.Color.FromArgb(244, 247, 246); // Matches tab background
            this.pnlSearchCard.Location = new System.Drawing.Point(27, 80);
            this.pnlSearchCard.Name = "pnlSearchCard";
            this.pnlSearchCard.Size = new System.Drawing.Size(1316, 90);
            this.pnlSearchCard.TabIndex = 2;
            this.pnlSearchCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchCard.Visible = false; // Hidden by default in Add mode
            this.pnlSearchCard.Controls.Add(this.lblSearchTitle);
            this.pnlSearchCard.Controls.Add(this.ptbSearchIcon);
            this.pnlSearchCard.Controls.Add(this.txtSearch);
            this.pnlSearchCard.Controls.Add(this.btnSearch);

            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = titleColor;
            this.lblSearchTitle.Location = new System.Drawing.Point(74, 16);
            this.lblSearchTitle.Text = "TÌM BỆNH NHÂN CẦN SỬA";
            this.lblSearchTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // ptbSearchIcon
            // 
            this.ptbSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbSearchIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbSearchIcon.Location = new System.Drawing.Point(40, 46);
            this.ptbSearchIcon.Name = "ptbSearchIcon";
            this.ptbSearchIcon.Size = new System.Drawing.Size(24, 24);
            this.ptbSearchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSearchIcon.TabIndex = 1;
            this.ptbSearchIcon.TabStop = false;

            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.BorderColor = cardBorderColor;
            this.txtSearch.BorderThickness = 1;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.ForeColor = inputForeColor;
            this.txtSearch.FillColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(74, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 36);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.Text = "";
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.HoverState.BorderColor = titleColor;
            this.txtSearch.FocusedState.BorderColor = titleColor;
            this.txtSearch.TextOffset = new System.Drawing.Point(8, 0);

            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 8;
            this.btnSearch.FillColor = titleColor;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.HoverState.FillColor = System.Drawing.Color.FromArgb(10, 79, 61);
            this.btnSearch.Location = new System.Drawing.Point(1196, 40); // Dynamically set in AdjustLayoutSizes
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 36);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;

            // 
            // pnlFormCard
            // 
            this.pnlFormCard.BorderColor = cardBorderColor;
            this.pnlFormCard.BorderRadius = 16;
            this.pnlFormCard.BorderThickness = 1;
            this.pnlFormCard.FillColor = System.Drawing.Color.White;
            this.pnlFormCard.Location = new System.Drawing.Point(27, 80);
            this.pnlFormCard.Name = "pnlFormCard";
            this.pnlFormCard.Size = new System.Drawing.Size(1316, 1220);
            this.pnlFormCard.TabIndex = 1;
            this.pnlFormCard.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblAvatarTitle
            // 
            this.lblAvatarTitle.AutoSize = true;
            this.lblAvatarTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAvatarTitle.ForeColor = labelColor;
            this.lblAvatarTitle.Location = new System.Drawing.Point(40, 24);
            this.lblAvatarTitle.Text = "📷 ẢNH ĐẠI DIỆN";
            this.lblAvatarTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblAvatarTitle);

            // 
            // picAvatar
            // 
            this.picAvatar.FillColor = System.Drawing.Color.FromArgb(230, 244, 240);
            this.picAvatar.Location = new System.Drawing.Point(40, 52);
            this.picAvatar.Size = new System.Drawing.Size(64, 64);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            this.pnlFormCard.Controls.Add(this.picAvatar);

            // 
            // btnUpload
            // 
            this.btnUpload.BorderColor = cardBorderColor;
            this.btnUpload.BorderRadius = 8;
            this.btnUpload.BorderThickness = 1;
            this.btnUpload.FillColor = System.Drawing.Color.Transparent;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = inputForeColor;
            this.btnUpload.HoverState.FillColor = inputBackColor;
            this.btnUpload.Location = new System.Drawing.Point(124, 64);
            this.btnUpload.Size = new System.Drawing.Size(120, 36);
            this.btnUpload.Text = "Tải ảnh lên";
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            this.btnUpload.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.btnUpload);

            // 
            // lblAvatarDesc
            // 
            this.lblAvatarDesc.AutoSize = true;
            this.lblAvatarDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblAvatarDesc.ForeColor = labelColor;
            this.lblAvatarDesc.Location = new System.Drawing.Point(124, 105);
            this.lblAvatarDesc.Text = "JPG, PNG tối đa 2MB";
            this.lblAvatarDesc.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblAvatarDesc);

            // 
            // ptbBasicIcon
            // 
            this.ptbBasicIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbBasicIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbBasicIcon.Location = new System.Drawing.Point(40, 160);
            this.ptbBasicIcon.Name = "ptbBasicIcon";
            this.ptbBasicIcon.Size = new System.Drawing.Size(24, 24);
            this.ptbBasicIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbBasicIcon.TabIndex = 100;
            this.ptbBasicIcon.TabStop = false;
            this.pnlFormCard.Controls.Add(this.ptbBasicIcon);

            // 
            // lblBasicTitle
            // 
            this.lblBasicTitle.AutoSize = true;
            this.lblBasicTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBasicTitle.ForeColor = titleColor;
            this.lblBasicTitle.Location = new System.Drawing.Point(74, 162);
            this.lblBasicTitle.Text = "THÔNG TIN CƠ BẢN";
            this.lblBasicTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblBasicTitle);

            // Row 1 Setup: HoDem, Ten, MaBN
            // Row 1 Setup: HoDem, Ten, MaBN
            lblHoDem.Location = new System.Drawing.Point(40, 195);
            this.pnlFormCard.Controls.Add(lblHoDem);
            txtHoDem.Location = new System.Drawing.Point(40, 220);
            txtHoDem.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(txtHoDem);

            lblTen.Location = new System.Drawing.Point(460, 195);
            this.pnlFormCard.Controls.Add(lblTen);
            txtTen.Location = new System.Drawing.Point(460, 220);
            txtTen.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(txtTen);

            lblMaBN.Location = new System.Drawing.Point(880, 195);
            this.pnlFormCard.Controls.Add(lblMaBN);
            txtMaBN.Location = new System.Drawing.Point(880, 220);
            txtMaBN.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(txtMaBN);

            // Row 2 Setup: NgaySinh, GioiTinh, NhomMau
            lblNgaySinh.Location = new System.Drawing.Point(40, 280);
            this.pnlFormCard.Controls.Add(lblNgaySinh);
            dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dtpNgaySinh.ForeColor = inputForeColor;
            dtpNgaySinh.FillColor = inputBackColor;
            dtpNgaySinh.Location = new System.Drawing.Point(40, 305);
            dtpNgaySinh.Size = new System.Drawing.Size(396, 38);
            dtpNgaySinh.BorderColor = cardBorderColor;
            dtpNgaySinh.BorderThickness = 1;
            dtpNgaySinh.BorderRadius = 8;
            dtpNgaySinh.BackColor = System.Drawing.Color.Transparent;
            dtpNgaySinh.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            dtpNgaySinh.HoverState.FillColor = System.Drawing.Color.White;
            dtpNgaySinh.CheckedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            dtpNgaySinh.CheckedState.FillColor = System.Drawing.Color.White;
            dtpNgaySinh.FocusedColor = System.Drawing.Color.FromArgb(15, 110, 86);
            dtpNgaySinh.TextOffset = new System.Drawing.Point(8, 0);
            this.pnlFormCard.Controls.Add(dtpNgaySinh);

            lblGioiTinh.Location = new System.Drawing.Point(460, 280);
            this.pnlFormCard.Controls.Add(lblGioiTinh);
            cboGioiTinh.Location = new System.Drawing.Point(460, 305);
            cboGioiTinh.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(cboGioiTinh);
            
            lblNhomMau.Location = new System.Drawing.Point(880, 280);
            this.pnlFormCard.Controls.Add(lblNhomMau);
            cboNhomMau.Location = new System.Drawing.Point(880, 305);
            cboNhomMau.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(cboNhomMau);

            // Row 3 Setup: CCCD, BHYT
            lblCccd.Location = new System.Drawing.Point(40, 365);
            this.pnlFormCard.Controls.Add(lblCccd);
            txtCccd.Location = new System.Drawing.Point(40, 390);
            txtCccd.Size = new System.Drawing.Size(816, 38);
            txtCccd.PlaceholderText = "079xxxxxxxxxx";
            this.pnlFormCard.Controls.Add(txtCccd);

            lblCccdDesc.AutoSize = true;
            lblCccdDesc.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblCccdDesc.ForeColor = labelColor;
            lblCccdDesc.Location = new System.Drawing.Point(40, 432);
            lblCccdDesc.Text = "Căn cước công dân hoặc hộ chiếu";
            lblCccdDesc.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(lblCccdDesc);

            lblBhyt.Location = new System.Drawing.Point(880, 365);
            this.pnlFormCard.Controls.Add(lblBhyt);
            txtBhyt.Location = new System.Drawing.Point(880, 390);
            txtBhyt.Size = new System.Drawing.Size(396, 38);
            txtBhyt.PlaceholderText = "GD3-xxxxxxxxx";
            this.pnlFormCard.Controls.Add(txtBhyt);

            // 
            // ptbContactIcon
            // 
            this.ptbContactIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbContactIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbContactIcon.Location = new System.Drawing.Point(40, 475);
            this.ptbContactIcon.Name = "ptbContactIcon";
            this.ptbContactIcon.Size = new System.Drawing.Size(24, 24);
            this.ptbContactIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbContactIcon.TabIndex = 101;
            this.ptbContactIcon.TabStop = false;
            this.pnlFormCard.Controls.Add(this.ptbContactIcon);

            // 
            // lblContactTitle
            // 
            this.lblContactTitle.AutoSize = true;
            this.lblContactTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContactTitle.ForeColor = titleColor;
            this.lblContactTitle.Location = new System.Drawing.Point(74, 477);
            this.lblContactTitle.Text = "THÔNG TIN LIÊN LẠC";
            this.lblContactTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblContactTitle);

            // Row 4: Sdt, Email, NguoiLienHe
            lblSdt.Location = new System.Drawing.Point(40, 510);
            this.pnlFormCard.Controls.Add(lblSdt);
            txtSdt.Location = new System.Drawing.Point(40, 535);
            txtSdt.Size = new System.Drawing.Size(396, 38);
            txtSdt.PlaceholderText = "09x xxx xxxx";
            this.pnlFormCard.Controls.Add(txtSdt);

            lblEmail.Location = new System.Drawing.Point(460, 510);
            this.pnlFormCard.Controls.Add(lblEmail);
            txtEmail.Location = new System.Drawing.Point(460, 535);
            txtEmail.Size = new System.Drawing.Size(396, 38);
            txtEmail.PlaceholderText = "example@email.com";
            this.pnlFormCard.Controls.Add(txtEmail);

            lblNguoiLienHe.Location = new System.Drawing.Point(880, 510);
            this.pnlFormCard.Controls.Add(lblNguoiLienHe);
            txtNguoiLienHe.Location = new System.Drawing.Point(880, 535);
            txtNguoiLienHe.Size = new System.Drawing.Size(396, 38);
            txtNguoiLienHe.PlaceholderText = "Họ tên người thân";
            this.pnlFormCard.Controls.Add(txtNguoiLienHe);

            // Row 5: DiaChi (Full width)
            lblDiaChi.Location = new System.Drawing.Point(40, 595);
            this.pnlFormCard.Controls.Add(lblDiaChi);
            txtDiaChi.Location = new System.Drawing.Point(40, 620);
            txtDiaChi.Size = new System.Drawing.Size(1236, 38);
            txtDiaChi.PlaceholderText = "Số nhà, đường, phường/xã, quận/huyện, tỉnh/thành phố";
            this.pnlFormCard.Controls.Add(txtDiaChi);

            // 
            // ptbTreatmentIcon
            // 
            this.ptbTreatmentIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbTreatmentIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbTreatmentIcon.Location = new System.Drawing.Point(40, 705);
            this.ptbTreatmentIcon.Name = "ptbTreatmentIcon";
            this.ptbTreatmentIcon.Size = new System.Drawing.Size(24, 24);
            this.ptbTreatmentIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbTreatmentIcon.TabIndex = 102;
            this.ptbTreatmentIcon.TabStop = false;
            this.pnlFormCard.Controls.Add(this.ptbTreatmentIcon);

            // 
            // lblTreatmentTitle
            // 
            this.lblTreatmentTitle.AutoSize = true;
            this.lblTreatmentTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTreatmentTitle.ForeColor = titleColor;
            this.lblTreatmentTitle.Location = new System.Drawing.Point(74, 707);
            this.lblTreatmentTitle.Text = "THÔNG TIN ĐIỀU TRỊ";
            this.lblTreatmentTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblTreatmentTitle);

            // Row 6: Khoa, HinhThuc, NgayNhap
            lblKhoa.Location = new System.Drawing.Point(40, 740);
            this.pnlFormCard.Controls.Add(lblKhoa);
            cboKhoa.Location = new System.Drawing.Point(40, 765);
            cboKhoa.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(cboKhoa);

            lblHinhThuc.Location = new System.Drawing.Point(460, 740);
            this.pnlFormCard.Controls.Add(lblHinhThuc);
            cboHinhThuc.Location = new System.Drawing.Point(460, 765);
            cboHinhThuc.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(cboHinhThuc);

            lblNgayNhap.Location = new System.Drawing.Point(880, 740);
            this.pnlFormCard.Controls.Add(lblNgayNhap);
            dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhap.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dtpNgayNhap.ForeColor = inputForeColor;
            dtpNgayNhap.FillColor = inputBackColor;
            dtpNgayNhap.Location = new System.Drawing.Point(880, 765);
            dtpNgayNhap.Size = new System.Drawing.Size(396, 38);
            dtpNgayNhap.BorderColor = cardBorderColor;
            dtpNgayNhap.BorderThickness = 1;
            dtpNgayNhap.BorderRadius = 8;
            dtpNgayNhap.BackColor = System.Drawing.Color.Transparent;
            dtpNgayNhap.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            dtpNgayNhap.HoverState.FillColor = System.Drawing.Color.White;
            dtpNgayNhap.CheckedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            dtpNgayNhap.CheckedState.FillColor = System.Drawing.Color.White;
            dtpNgayNhap.FocusedColor = System.Drawing.Color.FromArgb(15, 110, 86);
            dtpNgayNhap.TextOffset = new System.Drawing.Point(8, 0);
            this.pnlFormCard.Controls.Add(dtpNgayNhap);

            // Row 7: LyDo (Multiline, Height = 70)
            lblLyDo.Location = new System.Drawing.Point(40, 825);
            this.pnlFormCard.Controls.Add(lblLyDo);
            txtLyDo.Multiline = true;
            txtLyDo.Location = new System.Drawing.Point(40, 850);
            txtLyDo.Size = new System.Drawing.Size(1236, 70);
            txtLyDo.PlaceholderText = "Mô tả triệu chứng, lý do đến khám...";
            this.pnlFormCard.Controls.Add(txtLyDo);

            // Row 8: TienSu (Multiline, Height = 70)
            lblTienSu.Location = new System.Drawing.Point(40, 940);
            this.pnlFormCard.Controls.Add(lblTienSu);
            txtTienSu.Multiline = true;
            txtTienSu.Location = new System.Drawing.Point(40, 965);
            txtTienSu.Size = new System.Drawing.Size(1236, 70);
            txtTienSu.PlaceholderText = "Bệnh nền, dị ứng thuốc, phẫu thuật trước...";
            this.pnlFormCard.Controls.Add(txtTienSu);

            // 
            // 
            // pnlFormFooter
            // 
            this.pnlFormFooter.BorderColor = cardBorderColor;
            this.pnlFormFooter.BorderThickness = 1;
            this.pnlFormFooter.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0); // Top divider line
            this.pnlFormFooter.Controls.Add(this.lblRequired);
            this.pnlFormFooter.Controls.Add(this.btnCancel);
            this.pnlFormFooter.Controls.Add(this.btnDraft);
            this.pnlFormFooter.Controls.Add(this.btnSave);
            this.pnlFormFooter.FillColor = System.Drawing.Color.White; // Seamless white integration
            this.pnlFormFooter.Location = new System.Drawing.Point(0, 1100);
            this.pnlFormFooter.Name = "pnlFormFooter";
            this.pnlFormFooter.Size = new System.Drawing.Size(1316, 120);
            this.pnlFormFooter.TabIndex = 10;
            this.pnlFormFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.pnlFormFooter);

            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblRequired.ForeColor = System.Drawing.Color.FromArgb(168, 42, 20); // Dark red
            this.lblRequired.Location = new System.Drawing.Point(40, 52);
            this.lblRequired.Text = "(*) Trường bắt buộc";
            this.lblRequired.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = cardBorderColor;
            this.btnCancel.BorderRadius = 20;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(74, 98, 89);
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(244, 247, 246);
            this.btnCancel.Location = new System.Drawing.Point(784, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnDraft
            // 
            this.btnDraft.BorderColor = titleColor;
            this.btnDraft.BorderRadius = 20;
            this.btnDraft.BorderThickness = 1;
            this.btnDraft.FillColor = System.Drawing.Color.Transparent;
            this.btnDraft.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDraft.ForeColor = titleColor;
            this.btnDraft.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 244, 240);
            this.btnDraft.Location = new System.Drawing.Point(940, 40);
            this.btnDraft.Name = "btnDraft";
            this.btnDraft.Size = new System.Drawing.Size(140, 40);
            this.btnDraft.TabIndex = 1;
            this.btnDraft.Text = "Lưu nháp";
            this.btnDraft.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 20;
            this.btnSave.FillColor = titleColor;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(10, 79, 61);
            this.btnSave.Location = new System.Drawing.Point(1096, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu bệnh nhân";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.BackColor = System.Drawing.Color.Transparent;

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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScroll);
            this.Name = "ucThemSuaBN";
            this.Size = new System.Drawing.Size(1370, 850);
            this.Load += new System.EventHandler(this.ucThemSuaBN_Load);
            this.pnlScroll.ResumeLayout(false);
            this.pnlSegment.ResumeLayout(false);
            this.pnlSearchCard.ResumeLayout(false);
            this.pnlSearchCard.PerformLayout();
            this.pnlFormCard.ResumeLayout(false);
            this.pnlFormCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSearchIcon)).EndInit();
            this.pnlFormFooter.ResumeLayout(false);
            this.pnlFormFooter.PerformLayout();
            this.ResumeLayout(false);
        }



        private Guna.UI2.WinForms.Guna2Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlSegment;
        private Guna.UI2.WinForms.Guna2Button btnTabAdd;
        private Guna.UI2.WinForms.Guna2Button btnTabEdit;
        private Guna.UI2.WinForms.Guna2Panel pnlFormCard;

        private System.Windows.Forms.Label lblAvatarTitle;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2Button btnUpload;
        private System.Windows.Forms.Label lblAvatarDesc;

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
        private System.Windows.Forms.Label lblNhomMau;
        private Guna.UI2.WinForms.Guna2ComboBox cboNhomMau;
        private System.Windows.Forms.Label lblCccd;
        private Guna.UI2.WinForms.Guna2TextBox txtCccd;
        private System.Windows.Forms.Label lblCccdDesc;
        private System.Windows.Forms.Label lblBhyt;
        private Guna.UI2.WinForms.Guna2TextBox txtBhyt;

        private System.Windows.Forms.Label lblContactTitle;
        private System.Windows.Forms.Label lblSdt;
        private Guna.UI2.WinForms.Guna2TextBox txtSdt;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblNguoiLienHe;
        private Guna.UI2.WinForms.Guna2TextBox txtNguoiLienHe;
        private System.Windows.Forms.Label lblDiaChi;
        private Guna.UI2.WinForms.Guna2TextBox txtDiaChi;

        private System.Windows.Forms.Label lblTreatmentTitle;
        private System.Windows.Forms.Label lblKhoa;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoa;
        private System.Windows.Forms.Label lblHinhThuc;
        private Guna.UI2.WinForms.Guna2ComboBox cboHinhThuc;
        private System.Windows.Forms.Label lblNgayNhap;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblLyDo;
        private Guna.UI2.WinForms.Guna2TextBox txtLyDo;
        private System.Windows.Forms.Label lblTienSu;
        private Guna.UI2.WinForms.Guna2TextBox txtTienSu;

        private Guna.UI2.WinForms.Guna2Panel pnlSearchCard;
        private System.Windows.Forms.Label lblSearchTitle;
        private Guna.UI2.WinForms.Guna2PictureBox ptbSearchIcon;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;

        private Guna.UI2.WinForms.Guna2Panel pnlFormFooter;
        private System.Windows.Forms.Label lblRequired;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnDraft;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2PictureBox ptbBasicIcon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbContactIcon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbTreatmentIcon;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}

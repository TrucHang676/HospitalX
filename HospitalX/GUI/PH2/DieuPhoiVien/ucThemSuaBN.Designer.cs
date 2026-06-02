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

            // Section 1: Basic Info
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

            // Section 2: Medical History
            this.lblMedicalTitle = new System.Windows.Forms.Label();
            this.lblTienSuBN = new System.Windows.Forms.Label();
            this.txtTienSuBN = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTienSuGD = new System.Windows.Forms.Label();
            this.txtTienSuGD = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDiUng = new System.Windows.Forms.Label();
            this.txtDiUng = new Guna.UI2.WinForms.Guna2TextBox();

            // Footer Panel
            this.pnlFormFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRequired = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.ptbBasicIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbMedicalIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();

            this.pnlScroll.SuspendLayout();
            this.pnlSegment.SuspendLayout();
            this.pnlSearchCard.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSearchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBasicIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMedicalIcon)).BeginInit();
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
            this.pnlSearchCard.FillColor = System.Drawing.Color.FromArgb(244, 247, 246);
            this.pnlSearchCard.Location = new System.Drawing.Point(27, 80);
            this.pnlSearchCard.Name = "pnlSearchCard";
            this.pnlSearchCard.Size = new System.Drawing.Size(1316, 90);
            this.pnlSearchCard.TabIndex = 2;
            this.pnlSearchCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchCard.Visible = false;
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
            this.btnSearch.Location = new System.Drawing.Point(1176, 40);
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
            this.pnlFormCard.Size = new System.Drawing.Size(1316, 880);
            this.pnlFormCard.TabIndex = 1;
            this.pnlFormCard.BackColor = System.Drawing.Color.Transparent;

            // =============================================
            // SECTION 1: THÔNG TIN CƠ BẢN
            // =============================================

            // 
            // ptbBasicIcon
            // 
            this.ptbBasicIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbBasicIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbBasicIcon.Location = new System.Drawing.Point(40, 28);
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
            this.lblBasicTitle.Location = new System.Drawing.Point(74, 30);
            this.lblBasicTitle.Text = "THÔNG TIN CƠ BẢN";
            this.lblBasicTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblBasicTitle);

            // Row 1: HoDem, Ten, MaBN (Y=65)
            lblHoDem.Location = new System.Drawing.Point(40, 65);
            this.pnlFormCard.Controls.Add(lblHoDem);
            txtHoDem.Location = new System.Drawing.Point(40, 90);
            txtHoDem.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(txtHoDem);

            lblTen.Location = new System.Drawing.Point(460, 65);
            this.pnlFormCard.Controls.Add(lblTen);
            txtTen.Location = new System.Drawing.Point(460, 90);
            txtTen.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(txtTen);

            lblMaBN.Location = new System.Drawing.Point(880, 65);
            this.pnlFormCard.Controls.Add(lblMaBN);
            txtMaBN.Location = new System.Drawing.Point(880, 90);
            txtMaBN.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(txtMaBN);

            // Row 2: NgaySinh, GioiTinh, CCCD (Y=150)
            lblNgaySinh.Location = new System.Drawing.Point(40, 150);
            this.pnlFormCard.Controls.Add(lblNgaySinh);
            dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dtpNgaySinh.ForeColor = inputForeColor;
            dtpNgaySinh.FillColor = inputBackColor;
            dtpNgaySinh.Location = new System.Drawing.Point(40, 175);
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

            lblGioiTinh.Location = new System.Drawing.Point(460, 150);
            this.pnlFormCard.Controls.Add(lblGioiTinh);
            cboGioiTinh.Location = new System.Drawing.Point(460, 175);
            cboGioiTinh.Size = new System.Drawing.Size(396, 38);
            this.pnlFormCard.Controls.Add(cboGioiTinh);

            lblCccd.Location = new System.Drawing.Point(880, 150);
            this.pnlFormCard.Controls.Add(lblCccd);
            txtCccd.Location = new System.Drawing.Point(880, 175);
            txtCccd.Size = new System.Drawing.Size(396, 38);
            txtCccd.PlaceholderText = "079xxxxxxxxxx";
            this.pnlFormCard.Controls.Add(txtCccd);

            // Row 3: SoNha, TenDuong (Y=235)
            lblSoNha.Location = new System.Drawing.Point(40, 235);
            this.pnlFormCard.Controls.Add(lblSoNha);
            txtSoNha.Location = new System.Drawing.Point(40, 260);
            txtSoNha.Size = new System.Drawing.Size(396, 38);
            txtSoNha.PlaceholderText = "Ví dụ: 123";
            this.pnlFormCard.Controls.Add(txtSoNha);

            lblTenDuong.Location = new System.Drawing.Point(460, 235);
            this.pnlFormCard.Controls.Add(lblTenDuong);
            txtTenDuong.Location = new System.Drawing.Point(460, 260);
            txtTenDuong.Size = new System.Drawing.Size(816, 38);
            txtTenDuong.PlaceholderText = "Ví dụ: Đường Ba Tháng Hai";
            this.pnlFormCard.Controls.Add(txtTenDuong);

            // Row 4: QuanHuyen, TinhTP (Y=320)
            lblQuanHuyen.Location = new System.Drawing.Point(40, 320);
            this.pnlFormCard.Controls.Add(lblQuanHuyen);
            txtQuanHuyen.Location = new System.Drawing.Point(40, 345);
            txtQuanHuyen.Size = new System.Drawing.Size(616, 38);
            txtQuanHuyen.PlaceholderText = "Ví dụ: Quận 10";
            this.pnlFormCard.Controls.Add(txtQuanHuyen);

            lblTinhTP.Location = new System.Drawing.Point(680, 320);
            this.pnlFormCard.Controls.Add(lblTinhTP);
            txtTinhTP.Location = new System.Drawing.Point(680, 345);
            txtTinhTP.Size = new System.Drawing.Size(596, 38);
            txtTinhTP.PlaceholderText = "Ví dụ: TP. Hồ Chí Minh";
            this.pnlFormCard.Controls.Add(txtTinhTP);

            // =============================================
            // SECTION 2: TIỀN SỬ Y KHOA
            // =============================================

            // 
            // ptbMedicalIcon
            // 
            this.ptbMedicalIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbMedicalIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbMedicalIcon.Location = new System.Drawing.Point(40, 415);
            this.ptbMedicalIcon.Name = "ptbMedicalIcon";
            this.ptbMedicalIcon.Size = new System.Drawing.Size(24, 24);
            this.ptbMedicalIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbMedicalIcon.TabIndex = 101;
            this.ptbMedicalIcon.TabStop = false;
            this.pnlFormCard.Controls.Add(this.ptbMedicalIcon);

            // 
            // lblMedicalTitle
            // 
            this.lblMedicalTitle.AutoSize = true;
            this.lblMedicalTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMedicalTitle.ForeColor = titleColor;
            this.lblMedicalTitle.Location = new System.Drawing.Point(74, 417);
            this.lblMedicalTitle.Text = "TIỀN SỬ Y KHOA";
            this.lblMedicalTitle.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.lblMedicalTitle);

            // Row 5: TienSuBN (Multiline, Full-width, Y=450)
            lblTienSuBN.Location = new System.Drawing.Point(40, 452);
            this.pnlFormCard.Controls.Add(lblTienSuBN);
            txtTienSuBN.Multiline = true;
            txtTienSuBN.Location = new System.Drawing.Point(40, 477);
            txtTienSuBN.Size = new System.Drawing.Size(1236, 70);
            txtTienSuBN.PlaceholderText = "Bệnh nền, phẫu thuật trước đây, các bệnh mãn tính...";
            this.pnlFormCard.Controls.Add(txtTienSuBN);

            // Row 6: TienSuGD (Multiline, Full-width, Y=567)
            lblTienSuGD.Location = new System.Drawing.Point(40, 567);
            this.pnlFormCard.Controls.Add(lblTienSuGD);
            txtTienSuGD.Multiline = true;
            txtTienSuGD.Location = new System.Drawing.Point(40, 592);
            txtTienSuGD.Size = new System.Drawing.Size(1236, 70);
            txtTienSuGD.PlaceholderText = "Tiểu đường, tim mạch, ung thư trong gia đình...";
            this.pnlFormCard.Controls.Add(txtTienSuGD);

            // Row 7: DiUng (Multiline, Full-width, Y=682)
            lblDiUng.Location = new System.Drawing.Point(40, 682);
            this.pnlFormCard.Controls.Add(lblDiUng);
            txtDiUng.Multiline = true;
            txtDiUng.Location = new System.Drawing.Point(40, 707);
            txtDiUng.Size = new System.Drawing.Size(1236, 70);
            txtDiUng.PlaceholderText = "Tên thuốc gây dị ứng, phản ứng phụ đã gặp...";
            this.pnlFormCard.Controls.Add(txtDiUng);

            // =============================================
            // FOOTER
            // =============================================

            // 
            // pnlFormFooter
            // 
            this.pnlFormFooter.BorderColor = cardBorderColor;
            this.pnlFormFooter.BorderThickness = 1;
            this.pnlFormFooter.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlFormFooter.Controls.Add(this.lblRequired);
            this.pnlFormFooter.Controls.Add(this.btnCancel);
            this.pnlFormFooter.Controls.Add(this.btnSave);
            this.pnlFormFooter.FillColor = System.Drawing.Color.White;
            this.pnlFormFooter.Location = new System.Drawing.Point(0, 800);
            this.pnlFormFooter.Name = "pnlFormFooter";
            this.pnlFormFooter.Size = new System.Drawing.Size(1316, 80);
            this.pnlFormFooter.TabIndex = 10;
            this.pnlFormFooter.BackColor = System.Drawing.Color.Transparent;
            this.pnlFormCard.Controls.Add(this.pnlFormFooter);

            // 
            // lblRequired
            // 
            this.lblRequired.AutoSize = true;
            this.lblRequired.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblRequired.ForeColor = System.Drawing.Color.FromArgb(168, 42, 20);
            this.lblRequired.Location = new System.Drawing.Point(40, 30);
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
            this.btnCancel.Location = new System.Drawing.Point(920, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Hủy bỏ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 20;
            this.btnSave.FillColor = titleColor;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(10, 79, 61);
            this.btnSave.Location = new System.Drawing.Point(1076, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 40);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Thêm bệnh nhân";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.ImageOffset = new System.Drawing.Point(14, 0);
            this.btnSave.TextOffset = new System.Drawing.Point(12, 0);

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
            ((System.ComponentModel.ISupportInitialize)(this.ptbSearchIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbBasicIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMedicalIcon)).EndInit();
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
        private Guna.UI2.WinForms.Guna2PictureBox ptbSearchIcon;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnSearch;

        private Guna.UI2.WinForms.Guna2Panel pnlFormFooter;
        private System.Windows.Forms.Label lblRequired;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2PictureBox ptbBasicIcon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbMedicalIcon;
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;
    }
}

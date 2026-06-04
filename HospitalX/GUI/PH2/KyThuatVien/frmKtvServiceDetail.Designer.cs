namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class frmKtvServiceDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKtvServiceDetail));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnResult = new Guna.UI2.WinForms.Guna2Button();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNote = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoteContent = new System.Windows.Forms.Label();
            this.lblSectionNote = new System.Windows.Forms.Label();
            this.lineTrangThai = new System.Windows.Forms.Panel();
            this.lblTrangThaiVal = new System.Windows.Forms.Label();
            this.lblTrangThaiTitle = new System.Windows.Forms.Label();
            this.lineGioHen = new System.Windows.Forms.Panel();
            this.lblGioHenVal = new System.Windows.Forms.Label();
            this.lblGioHenTitle = new System.Windows.Forms.Label();
            this.lineBSChiDinh = new System.Windows.Forms.Panel();
            this.lblBSChiDinhVal = new System.Windows.Forms.Label();
            this.lblBSChiDinhTitle = new System.Windows.Forms.Label();
            this.lineTenDV = new System.Windows.Forms.Panel();
            this.lblTenDVVal = new System.Windows.Forms.Label();
            this.lblTenDVTitle = new System.Windows.Forms.Label();
            this.lblSectionService = new System.Windows.Forms.Label();
            this.lineGioiTinh = new System.Windows.Forms.Panel();
            this.lblGioiTinhVal = new System.Windows.Forms.Label();
            this.lblGioiTinhTitle = new System.Windows.Forms.Label();
            this.lineNgaySinh = new System.Windows.Forms.Panel();
            this.lblNgaySinhVal = new System.Windows.Forms.Label();
            this.lblNgaySinhTitle = new System.Windows.Forms.Label();
            this.lineMaHSBA = new System.Windows.Forms.Panel();
            this.lblMaHSBAVal = new System.Windows.Forms.Label();
            this.lblMaHSBATitle = new System.Windows.Forms.Label();
            this.lineHoTen = new System.Windows.Forms.Panel();
            this.lblHoTenVal = new System.Windows.Forms.Label();
            this.lblHoTenTitle = new System.Windows.Forms.Label();
            this.lblSectionPatient = new System.Windows.Forms.Label();
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseX = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlRoot.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 16;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlRoot
            // 
            this.pnlRoot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRoot.BorderRadius = 16;
            this.pnlRoot.BorderThickness = 1;
            this.pnlRoot.Controls.Add(this.pnlFooter);
            this.pnlRoot.Controls.Add(this.pnlBody);
            this.pnlRoot.Controls.Add(this.pnlHeader);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(460, 530);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.btnResult);
            this.pnlFooter.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFooter.CustomBorderThickness = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.pnlFooter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlFooter.Location = new System.Drawing.Point(0, 452);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(460, 78);
            this.pnlFooter.TabIndex = 2;
            // 
            // btnResult
            // 
            this.btnResult.BorderRadius = 8;
            this.btnResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnResult.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnResult.ForeColor = System.Drawing.Color.White;
            this.btnResult.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnResult.Location = new System.Drawing.Point(135, 19);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(190, 40);
            this.btnResult.TabIndex = 0;
            this.btnResult.Text = "Nhập kết quả";
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlBody.Controls.Add(this.pnlInfo);
            this.pnlBody.Location = new System.Drawing.Point(0, 56);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(460, 390);
            this.pnlBody.TabIndex = 1;
            // 
            // pnlInfo
            // 
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlInfo.BorderRadius = 8;
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.Controls.Add(this.pnlNote);
            this.pnlInfo.Controls.Add(this.lblNoteContent);
            this.pnlInfo.Controls.Add(this.lblSectionNote);
            this.pnlInfo.Controls.Add(this.lineTrangThai);
            this.pnlInfo.Controls.Add(this.lblTrangThaiVal);
            this.pnlInfo.Controls.Add(this.lblTrangThaiTitle);
            this.pnlInfo.Controls.Add(this.lineGioHen);
            this.pnlInfo.Controls.Add(this.lblGioHenVal);
            this.pnlInfo.Controls.Add(this.lblGioHenTitle);
            this.pnlInfo.Controls.Add(this.lineBSChiDinh);
            this.pnlInfo.Controls.Add(this.lblBSChiDinhVal);
            this.pnlInfo.Controls.Add(this.lblBSChiDinhTitle);
            this.pnlInfo.Controls.Add(this.lineTenDV);
            this.pnlInfo.Controls.Add(this.lblTenDVVal);
            this.pnlInfo.Controls.Add(this.lblTenDVTitle);
            this.pnlInfo.Controls.Add(this.lblSectionService);
            this.pnlInfo.Controls.Add(this.lineGioiTinh);
            this.pnlInfo.Controls.Add(this.lblGioiTinhVal);
            this.pnlInfo.Controls.Add(this.lblGioiTinhTitle);
            this.pnlInfo.Controls.Add(this.lineNgaySinh);
            this.pnlInfo.Controls.Add(this.lblNgaySinhVal);
            this.pnlInfo.Controls.Add(this.lblNgaySinhTitle);
            this.pnlInfo.Controls.Add(this.lineMaHSBA);
            this.pnlInfo.Controls.Add(this.lblMaHSBAVal);
            this.pnlInfo.Controls.Add(this.lblMaHSBATitle);
            this.pnlInfo.Controls.Add(this.lineHoTen);
            this.pnlInfo.Controls.Add(this.lblHoTenVal);
            this.pnlInfo.Controls.Add(this.lblHoTenTitle);
            this.pnlInfo.Controls.Add(this.lblSectionPatient);
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Location = new System.Drawing.Point(20, 20);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(420, 442);
            this.pnlInfo.TabIndex = 0;
            // 
            // pnlNote
            // 
            this.pnlNote.BorderRadius = 8;
            this.pnlNote.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlNote.Location = new System.Drawing.Point(20, 356);
            this.pnlNote.Name = "pnlNote";
            this.pnlNote.Size = new System.Drawing.Size(380, 72);
            this.pnlNote.TabIndex = 27;
            // 
            // lblNoteContent
            // 
            this.lblNoteContent.AutoEllipsis = true;
            this.lblNoteContent.BackColor = System.Drawing.Color.Transparent;
            this.lblNoteContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoteContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNoteContent.Location = new System.Drawing.Point(12, 10);
            this.lblNoteContent.Name = "lblNoteContent";
            this.lblNoteContent.Size = new System.Drawing.Size(356, 52);
            this.lblNoteContent.TabIndex = 0;
            this.lblNoteContent.Text = "Bệnh nhân có tiền sử tiểu đường type 2. Cần lấy mẫu máu tĩnh mạch trong trạng thá" +
    "i nhịn ăn ít nhất 8 giờ. Thực hiện đúng ca trực.";
            // 
            // lblSectionNote
            // 
            this.lblSectionNote.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionNote.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblSectionNote.Location = new System.Drawing.Point(20, 332);
            this.lblSectionNote.Name = "lblSectionNote";
            this.lblSectionNote.Size = new System.Drawing.Size(360, 20);
            this.lblSectionNote.TabIndex = 26;
            this.lblSectionNote.Text = "GHI CHÚ CHỈ ĐỊNH";
            this.lblSectionNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineTrangThai
            // 
            this.lineTrangThai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineTrangThai.Location = new System.Drawing.Point(20, 313);
            this.lineTrangThai.Name = "lineTrangThai";
            this.lineTrangThai.Size = new System.Drawing.Size(380, 1);
            this.lineTrangThai.TabIndex = 25;
            // 
            // lblTrangThaiVal
            // 
            this.lblTrangThaiVal.AutoEllipsis = true;
            this.lblTrangThaiVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThaiVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblTrangThaiVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblTrangThaiVal.Location = new System.Drawing.Point(162, 288);
            this.lblTrangThaiVal.Name = "lblTrangThaiVal";
            this.lblTrangThaiVal.Size = new System.Drawing.Size(238, 20);
            this.lblTrangThaiVal.TabIndex = 24;
            this.lblTrangThaiVal.Text = "(Trạng thái)";
            this.lblTrangThaiVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTrangThaiTitle
            // 
            this.lblTrangThaiTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTrangThaiTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblTrangThaiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblTrangThaiTitle.Location = new System.Drawing.Point(20, 288);
            this.lblTrangThaiTitle.Name = "lblTrangThaiTitle";
            this.lblTrangThaiTitle.Size = new System.Drawing.Size(140, 20);
            this.lblTrangThaiTitle.TabIndex = 23;
            this.lblTrangThaiTitle.Text = "Trạng thái";
            this.lblTrangThaiTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineGioHen
            // 
            this.lineGioHen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineGioHen.Location = new System.Drawing.Point(20, 283);
            this.lineGioHen.Name = "lineGioHen";
            this.lineGioHen.Size = new System.Drawing.Size(380, 1);
            this.lineGioHen.TabIndex = 22;
            // 
            // lblGioHenVal
            // 
            this.lblGioHenVal.AutoEllipsis = true;
            this.lblGioHenVal.BackColor = System.Drawing.Color.Transparent;
            this.lblGioHenVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblGioHenVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblGioHenVal.Location = new System.Drawing.Point(162, 258);
            this.lblGioHenVal.Name = "lblGioHenVal";
            this.lblGioHenVal.Size = new System.Drawing.Size(238, 20);
            this.lblGioHenVal.TabIndex = 21;
            this.lblGioHenVal.Text = "(Giờ hẹn)";
            this.lblGioHenVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGioHenTitle
            // 
            this.lblGioHenTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGioHenTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblGioHenTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblGioHenTitle.Location = new System.Drawing.Point(20, 258);
            this.lblGioHenTitle.Name = "lblGioHenTitle";
            this.lblGioHenTitle.Size = new System.Drawing.Size(140, 20);
            this.lblGioHenTitle.TabIndex = 20;
            this.lblGioHenTitle.Text = "Giờ hẹn";
            this.lblGioHenTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineBSChiDinh
            // 
            this.lineBSChiDinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineBSChiDinh.Location = new System.Drawing.Point(20, 253);
            this.lineBSChiDinh.Name = "lineBSChiDinh";
            this.lineBSChiDinh.Size = new System.Drawing.Size(380, 1);
            this.lineBSChiDinh.TabIndex = 19;
            // 
            // lblBSChiDinhVal
            // 
            this.lblBSChiDinhVal.AutoEllipsis = true;
            this.lblBSChiDinhVal.BackColor = System.Drawing.Color.Transparent;
            this.lblBSChiDinhVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblBSChiDinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblBSChiDinhVal.Location = new System.Drawing.Point(162, 228);
            this.lblBSChiDinhVal.Name = "lblBSChiDinhVal";
            this.lblBSChiDinhVal.Size = new System.Drawing.Size(238, 20);
            this.lblBSChiDinhVal.TabIndex = 18;
            this.lblBSChiDinhVal.Text = "(Bác sĩ chỉ định)";
            this.lblBSChiDinhVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblBSChiDinhTitle
            // 
            this.lblBSChiDinhTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblBSChiDinhTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblBSChiDinhTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblBSChiDinhTitle.Location = new System.Drawing.Point(20, 228);
            this.lblBSChiDinhTitle.Name = "lblBSChiDinhTitle";
            this.lblBSChiDinhTitle.Size = new System.Drawing.Size(140, 20);
            this.lblBSChiDinhTitle.TabIndex = 17;
            this.lblBSChiDinhTitle.Text = "Bác sĩ chỉ định";
            this.lblBSChiDinhTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineTenDV
            // 
            this.lineTenDV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineTenDV.Location = new System.Drawing.Point(20, 223);
            this.lineTenDV.Name = "lineTenDV";
            this.lineTenDV.Size = new System.Drawing.Size(380, 1);
            this.lineTenDV.TabIndex = 16;
            // 
            // lblTenDVVal
            // 
            this.lblTenDVVal.AutoEllipsis = true;
            this.lblTenDVVal.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDVVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblTenDVVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblTenDVVal.Location = new System.Drawing.Point(162, 198);
            this.lblTenDVVal.Name = "lblTenDVVal";
            this.lblTenDVVal.Size = new System.Drawing.Size(238, 20);
            this.lblTenDVVal.TabIndex = 15;
            this.lblTenDVVal.Text = "(Tên dịch vụ)";
            this.lblTenDVVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTenDVTitle
            // 
            this.lblTenDVTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDVTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblTenDVTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblTenDVTitle.Location = new System.Drawing.Point(20, 198);
            this.lblTenDVTitle.Name = "lblTenDVTitle";
            this.lblTenDVTitle.Size = new System.Drawing.Size(140, 20);
            this.lblTenDVTitle.TabIndex = 14;
            this.lblTenDVTitle.Text = "Tên dịch vụ";
            this.lblTenDVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSectionService
            // 
            this.lblSectionService.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionService.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblSectionService.Location = new System.Drawing.Point(20, 174);
            this.lblSectionService.Name = "lblSectionService";
            this.lblSectionService.Size = new System.Drawing.Size(360, 20);
            this.lblSectionService.TabIndex = 13;
            this.lblSectionService.Text = "THÔNG TIN DỊCH VỤ";
            this.lblSectionService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineGioiTinh
            // 
            this.lineGioiTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineGioiTinh.Location = new System.Drawing.Point(20, 155);
            this.lineGioiTinh.Name = "lineGioiTinh";
            this.lineGioiTinh.Size = new System.Drawing.Size(380, 1);
            this.lineGioiTinh.TabIndex = 12;
            // 
            // lblGioiTinhVal
            // 
            this.lblGioiTinhVal.AutoEllipsis = true;
            this.lblGioiTinhVal.BackColor = System.Drawing.Color.Transparent;
            this.lblGioiTinhVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblGioiTinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblGioiTinhVal.Location = new System.Drawing.Point(162, 130);
            this.lblGioiTinhVal.Name = "lblGioiTinhVal";
            this.lblGioiTinhVal.Size = new System.Drawing.Size(238, 20);
            this.lblGioiTinhVal.TabIndex = 11;
            this.lblGioiTinhVal.Text = "Nam";
            this.lblGioiTinhVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGioiTinhTitle
            // 
            this.lblGioiTinhTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblGioiTinhTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblGioiTinhTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblGioiTinhTitle.Location = new System.Drawing.Point(20, 130);
            this.lblGioiTinhTitle.Name = "lblGioiTinhTitle";
            this.lblGioiTinhTitle.Size = new System.Drawing.Size(140, 20);
            this.lblGioiTinhTitle.TabIndex = 10;
            this.lblGioiTinhTitle.Text = "Giới tính";
            this.lblGioiTinhTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineNgaySinh
            // 
            this.lineNgaySinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineNgaySinh.Location = new System.Drawing.Point(20, 125);
            this.lineNgaySinh.Name = "lineNgaySinh";
            this.lineNgaySinh.Size = new System.Drawing.Size(380, 1);
            this.lineNgaySinh.TabIndex = 9;
            // 
            // lblNgaySinhVal
            // 
            this.lblNgaySinhVal.AutoEllipsis = true;
            this.lblNgaySinhVal.BackColor = System.Drawing.Color.Transparent;
            this.lblNgaySinhVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblNgaySinhVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblNgaySinhVal.Location = new System.Drawing.Point(162, 100);
            this.lblNgaySinhVal.Name = "lblNgaySinhVal";
            this.lblNgaySinhVal.Size = new System.Drawing.Size(238, 20);
            this.lblNgaySinhVal.TabIndex = 8;
            this.lblNgaySinhVal.Text = "12/03/1978";
            this.lblNgaySinhVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNgaySinhTitle
            // 
            this.lblNgaySinhTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNgaySinhTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblNgaySinhTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNgaySinhTitle.Location = new System.Drawing.Point(20, 100);
            this.lblNgaySinhTitle.Name = "lblNgaySinhTitle";
            this.lblNgaySinhTitle.Size = new System.Drawing.Size(140, 20);
            this.lblNgaySinhTitle.TabIndex = 7;
            this.lblNgaySinhTitle.Text = "Ngày sinh";
            this.lblNgaySinhTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineMaHSBA
            // 
            this.lineMaHSBA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineMaHSBA.Location = new System.Drawing.Point(20, 95);
            this.lineMaHSBA.Name = "lineMaHSBA";
            this.lineMaHSBA.Size = new System.Drawing.Size(380, 1);
            this.lineMaHSBA.TabIndex = 6;
            // 
            // lblMaHSBAVal
            // 
            this.lblMaHSBAVal.AutoEllipsis = true;
            this.lblMaHSBAVal.BackColor = System.Drawing.Color.Transparent;
            this.lblMaHSBAVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblMaHSBAVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblMaHSBAVal.Location = new System.Drawing.Point(162, 70);
            this.lblMaHSBAVal.Name = "lblMaHSBAVal";
            this.lblMaHSBAVal.Size = new System.Drawing.Size(238, 20);
            this.lblMaHSBAVal.TabIndex = 5;
            this.lblMaHSBAVal.Text = "(Mã HSBA)";
            this.lblMaHSBAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMaHSBATitle
            // 
            this.lblMaHSBATitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMaHSBATitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblMaHSBATitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblMaHSBATitle.Location = new System.Drawing.Point(20, 70);
            this.lblMaHSBATitle.Name = "lblMaHSBATitle";
            this.lblMaHSBATitle.Size = new System.Drawing.Size(140, 20);
            this.lblMaHSBATitle.TabIndex = 4;
            this.lblMaHSBATitle.Text = "Mã HSBA";
            this.lblMaHSBATitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lineHoTen
            // 
            this.lineHoTen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.lineHoTen.Location = new System.Drawing.Point(20, 65);
            this.lineHoTen.Name = "lineHoTen";
            this.lineHoTen.Size = new System.Drawing.Size(380, 1);
            this.lineHoTen.TabIndex = 3;
            // 
            // lblHoTenVal
            // 
            this.lblHoTenVal.AutoEllipsis = true;
            this.lblHoTenVal.BackColor = System.Drawing.Color.Transparent;
            this.lblHoTenVal.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblHoTenVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblHoTenVal.Location = new System.Drawing.Point(162, 40);
            this.lblHoTenVal.Name = "lblHoTenVal";
            this.lblHoTenVal.Size = new System.Drawing.Size(238, 20);
            this.lblHoTenVal.TabIndex = 2;
            this.lblHoTenVal.Text = "(Họ tên bệnh nhân)";
            this.lblHoTenVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoTenTitle
            // 
            this.lblHoTenTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHoTenTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F);
            this.lblHoTenTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblHoTenTitle.Location = new System.Drawing.Point(20, 40);
            this.lblHoTenTitle.Name = "lblHoTenTitle";
            this.lblHoTenTitle.Size = new System.Drawing.Size(140, 20);
            this.lblHoTenTitle.TabIndex = 1;
            this.lblHoTenTitle.Text = "Họ tên";
            this.lblHoTenTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSectionPatient
            // 
            this.lblSectionPatient.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionPatient.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSectionPatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblSectionPatient.Location = new System.Drawing.Point(20, 16);
            this.lblSectionPatient.Name = "lblSectionPatient";
            this.lblSectionPatient.Size = new System.Drawing.Size(360, 20);
            this.lblSectionPatient.TabIndex = 0;
            this.lblSectionPatient.Text = "THÔNG TIN BỆNH NHÂN";
            this.lblSectionPatient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.btnCloseX);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(460, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết phân công";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCloseX
            // 
            this.btnCloseX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseX.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseX.BorderRadius = 8;
            this.btnCloseX.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseX.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnCloseX.IconColor = System.Drawing.Color.White;
            this.btnCloseX.Location = new System.Drawing.Point(412, 12);
            this.btnCloseX.Name = "btnCloseX";
            this.btnCloseX.Size = new System.Drawing.Size(36, 32);
            this.btnCloseX.TabIndex = 4;
            // 
            // frmKtvServiceDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(460, 530);
            this.Controls.Add(this.pnlRoot);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKtvServiceDetail";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết phân công";
            this.pnlRoot.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlInfo.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlBody;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;

        // Section: THÔNG TIN BỆNH NHÂN
        private System.Windows.Forms.Label lblSectionPatient;
        private System.Windows.Forms.Label lblHoTenTitle;
        private System.Windows.Forms.Label lblHoTenVal;
        private System.Windows.Forms.Panel lineHoTen;
        private System.Windows.Forms.Label lblMaHSBATitle;
        private System.Windows.Forms.Label lblMaHSBAVal;
        private System.Windows.Forms.Panel lineMaHSBA;
        private System.Windows.Forms.Label lblNgaySinhTitle;
        private System.Windows.Forms.Label lblNgaySinhVal;
        private System.Windows.Forms.Panel lineNgaySinh;
        private System.Windows.Forms.Label lblGioiTinhTitle;
        private System.Windows.Forms.Label lblGioiTinhVal;
        private System.Windows.Forms.Panel lineGioiTinh;

        // Section: THÔNG TIN DỊCH VỤ
        private System.Windows.Forms.Label lblSectionService;
        private System.Windows.Forms.Label lblTenDVTitle;
        private System.Windows.Forms.Label lblTenDVVal;
        private System.Windows.Forms.Panel lineTenDV;
        private System.Windows.Forms.Label lblBSChiDinhTitle;
        private System.Windows.Forms.Label lblBSChiDinhVal;
        private System.Windows.Forms.Panel lineBSChiDinh;
        private System.Windows.Forms.Label lblGioHenTitle;
        private System.Windows.Forms.Label lblGioHenVal;
        private System.Windows.Forms.Panel lineGioHen;
        private System.Windows.Forms.Label lblTrangThaiTitle;
        private System.Windows.Forms.Label lblTrangThaiVal;
        private System.Windows.Forms.Panel lineTrangThai;

        // Section: GHI CHÚ CHỈ ĐỊNH
        private System.Windows.Forms.Label lblSectionNote;
        private Guna.UI2.WinForms.Guna2Panel pnlNote;
        private System.Windows.Forms.Label lblNoteContent;

        // Footer
        private Guna.UI2.WinForms.Guna2Panel pnlFooter;
        private Guna.UI2.WinForms.Guna2Button btnResult;
        private Guna.UI2.WinForms.Guna2ControlBox btnCloseX;
    }
}

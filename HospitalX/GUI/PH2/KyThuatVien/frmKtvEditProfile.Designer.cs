namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class frmKtvEditProfile
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKtvEditProfile));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseX = new Guna.UI2.WinForms.Guna2Button();
            this.divHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtEditName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEditPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEditEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDob = new System.Windows.Forms.Label();
            this.dtpEditDob = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEditAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboEditGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblShift = new System.Windows.Forms.Label();
            this.cboEditShift = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSkills = new System.Windows.Forms.Label();
            this.txtEditSkills = new Guna.UI2.WinForms.Guna2TextBox();
            this.divFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
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
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnCloseX);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(560, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "✏️ Chỉnh sửa hồ sơ cá nhân";
            // 
            // btnCloseX
            // 
            this.btnCloseX.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseX.BorderColor = System.Drawing.Color.Transparent;
            this.btnCloseX.BorderRadius = 8;
            this.btnCloseX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseX.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCloseX.ForeColor = System.Drawing.Color.White;
            this.btnCloseX.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnCloseX.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnCloseX.Location = new System.Drawing.Point(512, 12);
            this.btnCloseX.Name = "btnCloseX";
            this.btnCloseX.Size = new System.Drawing.Size(36, 32);
            this.btnCloseX.TabIndex = 1;
            this.btnCloseX.Text = "✕";
            this.btnCloseX.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // divHeader
            // 
            this.divHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.divHeader.Location = new System.Drawing.Point(0, 56);
            this.divHeader.Name = "divHeader";
            this.divHeader.Size = new System.Drawing.Size(560, 1);
            this.divHeader.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblName.Location = new System.Drawing.Point(24, 76);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(87, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Họ và tên *";
            // 
            // txtEditName
            // 
            this.txtEditName.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtEditName.BorderRadius = 8;
            this.txtEditName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEditName.DefaultText = "";
            this.txtEditName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEditName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditName.Location = new System.Drawing.Point(24, 96);
            this.txtEditName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.PlaceholderText = "Nhập họ và tên...";
            this.txtEditName.SelectedText = "";
            this.txtEditName.Size = new System.Drawing.Size(244, 36);
            this.txtEditName.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.Transparent;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblPhone.Location = new System.Drawing.Point(284, 76);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(111, 20);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "Số điện thoại *";
            // 
            // txtEditPhone
            // 
            this.txtEditPhone.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtEditPhone.BorderRadius = 8;
            this.txtEditPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEditPhone.DefaultText = "";
            this.txtEditPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEditPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditPhone.Location = new System.Drawing.Point(284, 96);
            this.txtEditPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditPhone.Name = "txtEditPhone";
            this.txtEditPhone.PlaceholderText = "0900 000 000";
            this.txtEditPhone.SelectedText = "";
            this.txtEditPhone.Size = new System.Drawing.Size(252, 36);
            this.txtEditPhone.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblEmail.Location = new System.Drawing.Point(24, 148);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(110, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email liên lạc *";
            // 
            // txtEditEmail
            // 
            this.txtEditEmail.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtEditEmail.BorderRadius = 8;
            this.txtEditEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEditEmail.DefaultText = "";
            this.txtEditEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEditEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditEmail.Location = new System.Drawing.Point(24, 168);
            this.txtEditEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.PlaceholderText = "email@hospitalx.vn";
            this.txtEditEmail.SelectedText = "";
            this.txtEditEmail.Size = new System.Drawing.Size(244, 36);
            this.txtEditEmail.TabIndex = 7;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.BackColor = System.Drawing.Color.Transparent;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDob.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblDob.Location = new System.Drawing.Point(284, 148);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(90, 20);
            this.lblDob.TabIndex = 8;
            this.lblDob.Text = "Ngày sinh *";
            // 
            // dtpEditDob
            // 
            this.dtpEditDob.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dtpEditDob.BorderRadius = 8;
            this.dtpEditDob.BorderThickness = 1;
            this.dtpEditDob.Checked = true;
            this.dtpEditDob.FillColor = System.Drawing.Color.White;
            this.dtpEditDob.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpEditDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditDob.Location = new System.Drawing.Point(284, 168);
            this.dtpEditDob.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEditDob.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEditDob.Name = "dtpEditDob";
            this.dtpEditDob.Size = new System.Drawing.Size(252, 36);
            this.dtpEditDob.TabIndex = 9;
            this.dtpEditDob.Value = new System.DateTime(2026, 6, 2, 14, 28, 21, 238);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblAddress.Location = new System.Drawing.Point(24, 220);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(95, 20);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Địa chỉ nơi ở";
            // 
            // txtEditAddress
            // 
            this.txtEditAddress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtEditAddress.BorderRadius = 8;
            this.txtEditAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEditAddress.DefaultText = "";
            this.txtEditAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEditAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditAddress.Location = new System.Drawing.Point(24, 240);
            this.txtEditAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditAddress.Name = "txtEditAddress";
            this.txtEditAddress.PlaceholderText = "Số nhà, đường, phường, quận...";
            this.txtEditAddress.SelectedText = "";
            this.txtEditAddress.Size = new System.Drawing.Size(244, 36);
            this.txtEditAddress.TabIndex = 11;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.BackColor = System.Drawing.Color.Transparent;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblGender.Location = new System.Drawing.Point(284, 220);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(69, 20);
            this.lblGender.TabIndex = 12;
            this.lblGender.Text = "Giới tính";
            // 
            // cboEditGender
            // 
            this.cboEditGender.BackColor = System.Drawing.Color.Transparent;
            this.cboEditGender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboEditGender.BorderRadius = 8;
            this.cboEditGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEditGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEditGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboEditGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboEditGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboEditGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEditGender.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboEditGender.ItemHeight = 30;
            this.cboEditGender.Items.AddRange(new object[] {
            "Nữ",
            "Nam",
            "Khác"});
            this.cboEditGender.Location = new System.Drawing.Point(284, 240);
            this.cboEditGender.Name = "cboEditGender";
            this.cboEditGender.Size = new System.Drawing.Size(252, 36);
            this.cboEditGender.TabIndex = 13;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.BackColor = System.Drawing.Color.Transparent;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblShift.Location = new System.Drawing.Point(24, 292);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(146, 20);
            this.lblShift.TabIndex = 14;
            this.lblShift.Text = "Ca làm việc đăng ký";
            // 
            // cboEditShift
            // 
            this.cboEditShift.BackColor = System.Drawing.Color.Transparent;
            this.cboEditShift.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboEditShift.BorderRadius = 8;
            this.cboEditShift.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboEditShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEditShift.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboEditShift.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboEditShift.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboEditShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboEditShift.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboEditShift.ItemHeight = 30;
            this.cboEditShift.Items.AddRange(new object[] {
            "Ca sáng: 07:00 – 15:00",
            "Ca chiều: 13:00 – 21:00",
            "Ca tối/đêm: 21:00 – 07:00"});
            this.cboEditShift.Location = new System.Drawing.Point(24, 312);
            this.cboEditShift.Name = "cboEditShift";
            this.cboEditShift.Size = new System.Drawing.Size(512, 36);
            this.cboEditShift.TabIndex = 15;
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.BackColor = System.Drawing.Color.Transparent;
            this.lblSkills.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblSkills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblSkills.Location = new System.Drawing.Point(24, 364);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(256, 20);
            this.lblSkills.TabIndex = 16;
            this.lblSkills.Text = "Mô tả tóm tắt kỹ năng chuyên môn";
            // 
            // txtEditSkills
            // 
            this.txtEditSkills.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtEditSkills.BorderRadius = 8;
            this.txtEditSkills.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEditSkills.DefaultText = "";
            this.txtEditSkills.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditSkills.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEditSkills.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtEditSkills.Location = new System.Drawing.Point(24, 384);
            this.txtEditSkills.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEditSkills.Multiline = true;
            this.txtEditSkills.Name = "txtEditSkills";
            this.txtEditSkills.PlaceholderText = "Nhập mô tả kỹ năng, kinh nghiệm chuyên môn...";
            this.txtEditSkills.SelectedText = "";
            this.txtEditSkills.Size = new System.Drawing.Size(512, 72);
            this.txtEditSkills.TabIndex = 17;
            // 
            // divFooter
            // 
            this.divFooter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.divFooter.Location = new System.Drawing.Point(0, 472);
            this.divFooter.Name = "divFooter";
            this.divFooter.Size = new System.Drawing.Size(560, 1);
            this.divFooter.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnCancel.Location = new System.Drawing.Point(292, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 38);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 8;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSave.Location = new System.Drawing.Point(400, 484);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.btnSave.Size = new System.Drawing.Size(136, 38);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "💾 Lưu thay đổi";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmKtvEditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(560, 538);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.divHeader);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtEditName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEditPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEditEmail);
            this.Controls.Add(this.lblDob);
            this.Controls.Add(this.dtpEditDob);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtEditAddress);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cboEditGender);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cboEditShift);
            this.Controls.Add(this.lblSkills);
            this.Controls.Add(this.txtEditSkills);
            this.Controls.Add(this.divFooter);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKtvEditProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chỉnh sửa hồ sơ";
            this.pnlHeader.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ── Field declarations ────────────────────────────────────
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnCloseX;
        private Guna.UI2.WinForms.Guna2Panel divHeader;

        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2TextBox txtEditName;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtEditPhone;

        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEditEmail;
        private System.Windows.Forms.Label lblDob;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEditDob;

        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtEditAddress;
        private System.Windows.Forms.Label lblGender;
        private Guna.UI2.WinForms.Guna2ComboBox cboEditGender;

        private System.Windows.Forms.Label lblShift;
        private Guna.UI2.WinForms.Guna2ComboBox cboEditShift;

        private System.Windows.Forms.Label lblSkills;
        private Guna.UI2.WinForms.Guna2TextBox txtEditSkills;

        private Guna.UI2.WinForms.Guna2Panel divFooter;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}

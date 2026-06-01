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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnCloseX = new Guna.UI2.WinForms.Guna2Button();
            this.divHeader = new Guna.UI2.WinForms.Guna2Panel();

            // Row 1
            this.lblName = new System.Windows.Forms.Label();
            this.txtEditName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEditPhone = new Guna.UI2.WinForms.Guna2TextBox();

            // Row 2
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEditEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDob = new System.Windows.Forms.Label();
            this.dtpEditDob = new Guna.UI2.WinForms.Guna2DateTimePicker();

            // Row 3
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEditAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.cboEditGender = new Guna.UI2.WinForms.Guna2ComboBox();

            // Row 4
            this.lblShift = new System.Windows.Forms.Label();
            this.cboEditShift = new Guna.UI2.WinForms.Guna2ComboBox();

            // Row 5
            this.lblSkills = new System.Windows.Forms.Label();
            this.txtEditSkills = new Guna.UI2.WinForms.Guna2TextBox();

            // Footer
            this.divFooter = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();

            this.SuspendLayout();

            // ── guna2BorderlessForm1 ──────────────────────────────
            this.guna2BorderlessForm1.BorderRadius = 14;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;

            // ── pnlHeader ────────────────────────────────────────
            this.pnlHeader.FillColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Size = new System.Drawing.Size(560, 56);
            this.pnlHeader.BorderRadius = 0;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnCloseX);

            // ── lblTitle ─────────────────────────────────────────
            this.lblTitle.Text = "✏️ Chỉnh sửa hồ sơ cá nhân";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(26, 39, 51);
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Location = new System.Drawing.Point(24, 14);
            this.lblTitle.Size = new System.Drawing.Size(440, 28);
            this.lblTitle.AutoSize = false;

            // ── btnCloseX ────────────────────────────────────────
            this.btnCloseX.Text = "✕";
            this.btnCloseX.Size = new System.Drawing.Size(28, 28);
            this.btnCloseX.Location = new System.Drawing.Point(508, 14);
            this.btnCloseX.BorderRadius = 14;
            this.btnCloseX.FillColor = System.Drawing.Color.White;
            this.btnCloseX.ForeColor = System.Drawing.Color.FromArgb(138, 152, 170);
            this.btnCloseX.BorderColor = System.Drawing.Color.FromArgb(226, 235, 240);
            this.btnCloseX.BorderThickness = 1;
            this.btnCloseX.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnCloseX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseX.HoverState.FillColor = System.Drawing.Color.FromArgb(254, 235, 235);
            this.btnCloseX.HoverState.ForeColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnCloseX.Click += new System.EventHandler(this.btnCancel_Click);

            // ── divHeader ────────────────────────────────────────
            this.divHeader.FillColor = System.Drawing.Color.FromArgb(226, 235, 240);
            this.divHeader.Location = new System.Drawing.Point(0, 56);
            this.divHeader.Size = new System.Drawing.Size(560, 1);
            this.divHeader.BorderRadius = 0;

            // ── Helpers ──────────────────────────────────────────
            System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            System.Drawing.Color midText = System.Drawing.Color.FromArgb(74, 85, 104);
            System.Drawing.Font labelFont = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font inputFont = new System.Drawing.Font("Segoe UI", 9F);

            // ── Row 1: Họ và tên | Số điện thoại ────────────────
            // lblName
            this.lblName.Text = "Họ và tên *";
            this.lblName.Font = labelFont;
            this.lblName.ForeColor = midText;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(24, 76);
            this.lblName.AutoSize = true;

            // txtEditName
            this.txtEditName.Location = new System.Drawing.Point(24, 96);
            this.txtEditName.Size = new System.Drawing.Size(244, 36);
            this.txtEditName.BorderRadius = 8;
            this.txtEditName.BorderColor = borderColor;
            this.txtEditName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.txtEditName.Font = inputFont;
            this.txtEditName.PlaceholderText = "Nhập họ và tên...";

            // lblPhone
            this.lblPhone.Text = "Số điện thoại *";
            this.lblPhone.Font = labelFont;
            this.lblPhone.ForeColor = midText;
            this.lblPhone.BackColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(284, 76);
            this.lblPhone.AutoSize = true;

            // txtEditPhone
            this.txtEditPhone.Location = new System.Drawing.Point(284, 96);
            this.txtEditPhone.Size = new System.Drawing.Size(252, 36);
            this.txtEditPhone.BorderRadius = 8;
            this.txtEditPhone.BorderColor = borderColor;
            this.txtEditPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.txtEditPhone.Font = inputFont;
            this.txtEditPhone.PlaceholderText = "0900 000 000";

            // ── Row 2: Email | Ngày sinh ─────────────────────────
            // lblEmail
            this.lblEmail.Text = "Email liên lạc *";
            this.lblEmail.Font = labelFont;
            this.lblEmail.ForeColor = midText;
            this.lblEmail.BackColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(24, 148);
            this.lblEmail.AutoSize = true;

            // txtEditEmail
            this.txtEditEmail.Location = new System.Drawing.Point(24, 168);
            this.txtEditEmail.Size = new System.Drawing.Size(244, 36);
            this.txtEditEmail.BorderRadius = 8;
            this.txtEditEmail.BorderColor = borderColor;
            this.txtEditEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.txtEditEmail.Font = inputFont;
            this.txtEditEmail.PlaceholderText = "email@hospitalx.vn";

            // lblDob
            this.lblDob.Text = "Ngày sinh *";
            this.lblDob.Font = labelFont;
            this.lblDob.ForeColor = midText;
            this.lblDob.BackColor = System.Drawing.Color.White;
            this.lblDob.Location = new System.Drawing.Point(284, 148);
            this.lblDob.AutoSize = true;

            // dtpEditDob
            this.dtpEditDob.Location = new System.Drawing.Point(284, 168);
            this.dtpEditDob.Size = new System.Drawing.Size(252, 36);
            this.dtpEditDob.BorderRadius = 8;
            this.dtpEditDob.FillColor = System.Drawing.Color.White;
            this.dtpEditDob.BorderColor = borderColor;
            this.dtpEditDob.BorderThickness = 1;
            this.dtpEditDob.Font = inputFont;
            this.dtpEditDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // ── Row 3: Địa chỉ | Giới tính ──────────────────────
            // lblAddress
            this.lblAddress.Text = "Địa chỉ nơi ở";
            this.lblAddress.Font = labelFont;
            this.lblAddress.ForeColor = midText;
            this.lblAddress.BackColor = System.Drawing.Color.White;
            this.lblAddress.Location = new System.Drawing.Point(24, 220);
            this.lblAddress.AutoSize = true;

            // txtEditAddress
            this.txtEditAddress.Location = new System.Drawing.Point(24, 240);
            this.txtEditAddress.Size = new System.Drawing.Size(244, 36);
            this.txtEditAddress.BorderRadius = 8;
            this.txtEditAddress.BorderColor = borderColor;
            this.txtEditAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.txtEditAddress.Font = inputFont;
            this.txtEditAddress.PlaceholderText = "Số nhà, đường, phường, quận...";

            // lblGender
            this.lblGender.Text = "Giới tính";
            this.lblGender.Font = labelFont;
            this.lblGender.ForeColor = midText;
            this.lblGender.BackColor = System.Drawing.Color.White;
            this.lblGender.Location = new System.Drawing.Point(284, 220);
            this.lblGender.AutoSize = true;

            // cboEditGender
            this.cboEditGender.Location = new System.Drawing.Point(284, 240);
            this.cboEditGender.Size = new System.Drawing.Size(252, 36);
            this.cboEditGender.BorderRadius = 8;
            this.cboEditGender.BorderColor = borderColor;
            this.cboEditGender.Font = inputFont;
            this.cboEditGender.Items.AddRange(new object[] { "Nữ", "Nam", "Khác" });
            this.cboEditGender.SelectedIndex = 0;

            // ── Row 4: Ca làm việc (full width) ─────────────────
            // lblShift
            this.lblShift.Text = "Ca làm việc đăng ký";
            this.lblShift.Font = labelFont;
            this.lblShift.ForeColor = midText;
            this.lblShift.BackColor = System.Drawing.Color.White;
            this.lblShift.Location = new System.Drawing.Point(24, 292);
            this.lblShift.AutoSize = true;

            // cboEditShift
            this.cboEditShift.Location = new System.Drawing.Point(24, 312);
            this.cboEditShift.Size = new System.Drawing.Size(512, 36);
            this.cboEditShift.BorderRadius = 8;
            this.cboEditShift.BorderColor = borderColor;
            this.cboEditShift.Font = inputFont;
            this.cboEditShift.Items.AddRange(new object[]
            {
                "Ca sáng: 07:00 – 15:00",
                "Ca chiều: 13:00 – 21:00",
                "Ca tối/đêm: 21:00 – 07:00"
            });
            this.cboEditShift.SelectedIndex = 0;

            // ── Row 5: Kỹ năng chuyên môn (full width) ───────────
            // lblSkills
            this.lblSkills.Text = "Mô tả tóm tắt kỹ năng chuyên môn";
            this.lblSkills.Font = labelFont;
            this.lblSkills.ForeColor = midText;
            this.lblSkills.BackColor = System.Drawing.Color.White;
            this.lblSkills.Location = new System.Drawing.Point(24, 364);
            this.lblSkills.AutoSize = true;

            // txtEditSkills
            this.txtEditSkills.Location = new System.Drawing.Point(24, 384);
            this.txtEditSkills.Size = new System.Drawing.Size(512, 72);
            this.txtEditSkills.Multiline = true;
            this.txtEditSkills.BorderRadius = 8;
            this.txtEditSkills.BorderColor = borderColor;
            this.txtEditSkills.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.txtEditSkills.Font = inputFont;
            this.txtEditSkills.PlaceholderText = "Nhập mô tả kỹ năng, kinh nghiệm chuyên môn...";

            // ── Footer divider ────────────────────────────────────
            this.divFooter.FillColor = borderColor;
            this.divFooter.Location = new System.Drawing.Point(0, 472);
            this.divFooter.Size = new System.Drawing.Size(560, 1);
            this.divFooter.BorderRadius = 0;

            // ── btnCancel ────────────────────────────────────────
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Size = new System.Drawing.Size(96, 38);
            this.btnCancel.Location = new System.Drawing.Point(328, 484);
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(74, 85, 104);
            this.btnCancel.BorderColor = borderColor;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ── btnSave ──────────────────────────────────────────
            this.btnSave.Text = "💾 Lưu thay đổi";
            this.btnSave.Size = new System.Drawing.Size(136, 38);
            this.btnSave.Location = new System.Drawing.Point(440, 484);
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(15, 110, 86);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(26, 148, 112);
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(10, 79, 61);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // ── Form ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 538);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKtvEditProfile";
            this.Text = "Chỉnh sửa hồ sơ";
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            // Add all controls
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                this.pnlHeader,
                this.divHeader,
                this.lblName,
                this.txtEditName,
                this.lblPhone,
                this.txtEditPhone,
                this.lblEmail,
                this.txtEditEmail,
                this.lblDob,
                this.dtpEditDob,
                this.lblAddress,
                this.txtEditAddress,
                this.lblGender,
                this.cboEditGender,
                this.lblShift,
                this.cboEditShift,
                this.lblSkills,
                this.txtEditSkills,
                this.divFooter,
                this.btnCancel,
                this.btnSave
            });

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

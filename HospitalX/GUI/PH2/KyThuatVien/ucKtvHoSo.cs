using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.DieuPhoiVien;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvHoSo : UserControl
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86); // #0F6E56
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226); // #DAE8E2
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42); // #18302A
        private static readonly Color TextMuted = Color.FromArgb(122, 149, 137); // #7A9589
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);

        private Guna2MessageDialog _messageDialog;

        private static string SavedPhone = "0914 567 890";
        private static string SavedAddress = "45 Đường Lê Lợi, P.3, Biên Hòa, Đồng Nai";

        private string _originalContactPhone;
        private string _originalContactAddress;
        private string _originalMaNV;
        private string _originalHoTen;
        private string _originalVaiTro;
        private string _originalKhoa;
        private string _originalGioiTinh;
        private string _originalNgaySinh;
        private string _originalCccd;
        private string _originalCoSo;
        private bool _isLoadingContact;

        public ucKtvHoSo()
        {
            InitializeComponent();
            DoubleBuffered = true;
            txtContactPhone.TextChanged   += ContactFieldChanged;
            txtContactAddress.TextChanged += ContactFieldChanged;
            txtProfMaNV.TextChanged       += ContactFieldChanged;
            txtProfHoTen.TextChanged      += ContactFieldChanged;
            txtProfVaiTro.TextChanged     += ContactFieldChanged;
            txtKhoa.TextChanged           += ContactFieldChanged;
            txtProfGioiTinh.TextChanged   += ContactFieldChanged;
            txtProfNgaySinh.TextChanged   += ContactFieldChanged;
            txtProfCccd.TextChanged       += ContactFieldChanged;
        }

        private void ucKtvHoSo_Load(object sender, EventArgs e)
        {
            LoadProfileData();
            SetupStyles();
            ucKtvHoSo_Resize(null, null);
        }

        private void SetupStyles()
        {
            // Set styles for Left Card
            pnlLeftCard.BorderColor = BorderGray;
            pnlLeftCard.BorderThickness = 1;
            pnlLeftCard.BorderRadius = 14;
            pnlLeftCard.FillColor = Color.White;

            ptbAvatar.Image = DpvAssets.Load("female_doctor.png");
            ptbAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            lblUserName.ForeColor = TextDark;
            lblUserName.Font = new Font("Segoe UI Semibold", 13.5F, FontStyle.Bold);

            lblUserRole.ForeColor = TextMuted;
            lblUserRole.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);

            lblDeptAndFacility.ForeColor = TextMuted;
            lblDeptAndFacility.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Style stat panels
            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap, "0", "Dịch vụ hôm nay");
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap, "0", "Tổng ca hoàn thành");

            // Status badge
            lblStatusBadge.BackColor = Color.Transparent;
            lblStatusBadge.FillColor = Color.FromArgb(230, 244, 240);
            lblStatusBadge.ForeColor = ThemeGreen;
            lblStatusBadge.Font = new Font("Segoe UI Semibold", 8.5F, FontStyle.Bold);
            lblStatusBadge.Text = "● Đang hoạt động";
            lblStatusBadge.BorderRadius = 15;
            lblStatusBadge.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            lblStatusBadge.PressedColor = Color.FromArgb(230, 244, 240);
            lblStatusBadge.Cursor = Cursors.Default;

            foreach (var panel in new[] { pnlCardProfessional, pnlCardSecurity })
            {
                panel.BorderColor = BorderGray;
                panel.BorderThickness = 1;
                panel.BorderRadius = 14;
                panel.FillColor = Color.White;
            }

            // Titles and labels font styling
            var titleFont = new Font("Segoe UI Semibold", 12.5F, FontStyle.Bold);
            lblTitleProf.Font = titleFont;
            lblTitleContact.Font = titleFont;
            lblTitleSecurity.Font = titleFont;
            lblTitleProf.ForeColor = ThemeGreen;
            lblTitleContact.ForeColor = ThemeGreen;
            lblTitleSecurity.ForeColor = ThemeGreen;

            lblTitleContact.Visible = true;

            var labelFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            foreach (var lbl in new[] { label1, label2, label3, lblKhoa, label4, label5, label6, label8, label9 })
            {
                if (lbl != null)
                {
                    lbl.Font = labelFont;
                    lbl.ForeColor = TextMuted;
                }
            }

            pnlCardProfessional.Margin = new Padding(0, 0, 0, 20);
            pnlCardSecurity.Margin = new Padding(0, 0, 0, 20);
            if (lblSlogan != null)
            {
                lblSlogan.Margin = new Padding(0, 16, 0, 24);
                lblSlogan.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
                lblSlogan.ForeColor = Color.FromArgb(80, 110, 95);
            }

            // Setup Professional text fields as Read-only styling
            SetupReadOnlyField(txtProfMaNV);
            SetupReadOnlyField(txtProfHoTen);
            SetupReadOnlyField(txtProfVaiTro);
            SetupReadOnlyField(txtKhoa);
            SetupReadOnlyField(txtProfGioiTinh);
            SetupReadOnlyField(txtProfNgaySinh);
            SetupReadOnlyField(txtProfCccd);

            // Setup editable contact text fields styling
            txtContactPhone.Font = new Font("Segoe UI", 10.5F);
            txtContactAddress.Font = new Font("Segoe UI", 10.5F);

            // Style buttons
            btnUpdateContact.FillColor = ThemeGreen;
            btnUpdateContact.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnUpdateContact.ForeColor = Color.White;
            btnUpdateContact.HoverState.FillColor = Color.FromArgb(10, 82, 64);
            UpdateContactSaveButton();

            btnChangePassword.BorderColor = ThemeGreen;
            btnChangePassword.BorderThickness = 1;
            btnChangePassword.FillColor = Color.Transparent;
            btnChangePassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnChangePassword.ForeColor = ThemeGreen;
            btnChangePassword.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            btnChangePassword.Cursor = Cursors.Hand;
        }

        private void StyleStatPanel(Guna2Panel panel, Label val, Label cap, string value, string caption)
        {
            panel.BorderColor = Color.FromArgb(230, 238, 235);
            panel.BorderThickness = 1;
            panel.BorderRadius = 10;
            panel.FillColor = Color.FromArgb(247, 249, 248);

            val.Text = value;
            val.ForeColor = ThemeGreen;
            val.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            cap.Text = caption;
            cap.ForeColor = TextMuted;
            cap.Font = new Font("Segoe UI", 8F, FontStyle.Regular);
        }

        private void SetupReadOnlyField(Guna2TextBox box)
        {
            // Cho phép chỉnh sửa — bảo mật được thực thi ở tầng Oracle (SP/Trigger)
            box.ReadOnly = false;
            box.Enabled = true;
            box.FillColor = Color.White;
            box.BorderColor = BorderGray;
            box.ForeColor = TextDark;
            box.Font = new Font("Segoe UI", 10.5F);
        }

        private void LoadProfileData()
        {
            KtvTechnician ktv = KtvData.CurrentTechnician();

            lblUserName.Text = ktv.HoTen;
            lblUserRole.Text = ktv.VaiTro;
            lblDeptAndFacility.Text = $"{ktv.ChuyenKhoa}\r\nBệnh viện Đa khoa HospitalX";

            txtProfMaNV.Text     = ktv.MaNv;
            txtProfHoTen.Text    = ktv.HoTen;
            txtProfVaiTro.Text   = ktv.VaiTro;
            txtProfGioiTinh.Text = ktv.Phai;
            txtProfNgaySinh.Text = ktv.NgaySinh;
            txtProfCccd.Text     = ktv.Cmnd;
            txtKhoa.Text         = ktv.ChuyenKhoa;

            _originalCoSo = ktv.CoSo;

            SavedPhone   = ktv.SoDt;
            SavedAddress = ktv.QueQuan;

            txtContactPhone.Text   = SavedPhone;
            txtContactAddress.Text = SavedAddress;
            AcceptCurrentContactValues();

            // Set gender-appropriate avatar
            if (ktv.Phai.Equals("Nam", StringComparison.OrdinalIgnoreCase))
            {
                ptbAvatar.Image = DpvAssets.Load("male_doctor.png");
            }
            else
            {
                ptbAvatar.Image = DpvAssets.Load("female_doctor.png");
            }

            // Load dynamically calculated stats
            try
            {
                var services = KtvData.Services();
                int todayCount = services.Count(s => s.NgayDv == DateTime.Today.ToString("dd/MM/yyyy"));
                int doneCount = services.Count(s => s.Status == "Hoàn thành");

                lblStat1Val.Text = todayCount.ToString();
                lblStat2Val.Text = doneCount.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi load stats cho KTV profile: " + ex.Message);
                lblStat1Val.Text = "0";
                lblStat2Val.Text = "0";
            }
        }

        private void ucKtvHoSo_Resize(object sender, EventArgs e)
        {
            int totalW = pnlScroll.ClientSize.Width;
            if (totalW <= 0) return;

            // Safeguard against AutoScroll coordinate shift during resize
            Point scrollPos = pnlScroll.AutoScrollPosition;
            pnlScroll.AutoScrollPosition = new Point(0, 0);

            float dpiFactor = (float)this.DeviceDpi / 96f;

            // --- Left Card sizing & positioning (match coordinator: 320x645) ---
            int leftCardW = (int)(320 * dpiFactor);
            int leftCardH = (int)(645 * dpiFactor);

            pnlLeftCard.Location = new Point(24, 24);
            pnlLeftCard.Size = new Size(leftCardW, leftCardH);

            // Center children within left card
            CenterLeftCardChildren(leftCardW, dpiFactor);

            // --- Right Panel positioning (match coordinator: X=368, gap=24) ---
            int rightX = pnlLeftCard.Right + 24;
            int rightW = Math.Max(500, totalW - rightX - 24);

            pnlRight.Location = new Point(rightX, 24);
            pnlRight.Width = rightW;

            // Set card dimensions (matching coordinator exactly)
            pnlCardProfessional.Width = rightW;
            pnlCardProfessional.Height = 570;

            pnlCardSecurity.Width = rightW;
            pnlCardSecurity.Height = 120;

            // Two-column layout (matching coordinator)
            int colPadding = 24;
            int colGap = 24;
            int fieldW = (rightW - (colPadding * 2) - colGap) / 2;
            int col2X = colPadding + fieldW + colGap;

            // Merged Card Y positioning and height of fields
            lblTitleProf.Top = 20;
            btnUpdateContact.Top = 20;
            btnUpdateContact.Height = 40;
            btnUpdateContact.Location = new Point(rightW - btnUpdateContact.Width - 24, btnUpdateContact.Top);

            // Row 1
            label1.Top = 64;
            label1.Left = colPadding;
            txtProfMaNV.Left = colPadding;
            txtProfMaNV.Top = 86;
            txtProfMaNV.Width = fieldW;
            txtProfMaNV.Height = 44;

            label2.Top = 64;
            label2.Left = col2X;
            txtProfHoTen.Left = col2X;
            txtProfHoTen.Top = 86;
            txtProfHoTen.Width = fieldW;
            txtProfHoTen.Height = 44;

            // Row 2
            label3.Top = 154;
            label3.Left = colPadding;
            txtProfVaiTro.Left = colPadding;
            txtProfVaiTro.Top = 176;
            txtProfVaiTro.Width = fieldW;
            txtProfVaiTro.Height = 44;

            lblKhoa.Top = 154;
            lblKhoa.Left = col2X;
            txtKhoa.Left = col2X;
            txtKhoa.Top = 176;
            txtKhoa.Width = fieldW;
            txtKhoa.Height = 44;

            // Subheader: Personal Info
            lblTitleContact.Top = 244;
            lblTitleContact.Left = colPadding;

            // Row 3
            label4.Top = 288;
            label4.Left = colPadding;
            txtProfGioiTinh.Left = colPadding;
            txtProfGioiTinh.Top = 310;
            txtProfGioiTinh.Width = fieldW;
            txtProfGioiTinh.Height = 44;

            label5.Top = 288;
            label5.Left = col2X;
            txtProfNgaySinh.Left = col2X;
            txtProfNgaySinh.Top = 310;
            txtProfNgaySinh.Width = fieldW;
            txtProfNgaySinh.Height = 44;

            // Row 4
            label6.Top = 378;
            label6.Left = colPadding;
            txtProfCccd.Left = colPadding;
            txtProfCccd.Top = 400;
            txtProfCccd.Width = fieldW;
            txtProfCccd.Height = 44;

            label8.Top = 378;
            label8.Left = col2X;
            txtContactPhone.Left = col2X;
            txtContactPhone.Top = 400;
            txtContactPhone.Width = fieldW;
            txtContactPhone.Height = 44;

            // Row 5 (Full-width address field)
            label9.Top = 468;
            label9.Left = colPadding;
            txtContactAddress.Left = colPadding;
            txtContactAddress.Top = 490;
            txtContactAddress.Width = rightW - (colPadding * 2);
            txtContactAddress.Height = 44;

            // Security Card
            lblTitleSecurity.Top = 20;
            btnChangePassword.Top = 20;
            btnChangePassword.Width = 150;
            btnChangePassword.Height = 40;
            btnChangePassword.Location = new Point(rightW - btnChangePassword.Width - 24, btnChangePassword.Top);
            lblPasswordMock.Top = 72;

            // Slogan
            if (lblSlogan != null)
            {
                lblSlogan.Width = rightW;
            }

            // Restore AutoScroll position
            pnlScroll.AutoScrollPosition = new Point(Math.Abs(scrollPos.X), Math.Abs(scrollPos.Y));
        }

        private void CenterLeftCardChildren(int cardW, float dpiFactor)
        {
            // Avatar (matching DPV size of 120)
            int avatarSize = (int)(120 * dpiFactor);
            ptbAvatar.Size = new Size(avatarSize, avatarSize);
            ptbAvatar.Location = new Point((cardW - avatarSize) / 2, (int)(38 * dpiFactor));

            // Username label
            int labelW = cardW - (int)(40 * dpiFactor);
            int labelX = (int)(20 * dpiFactor);
            lblUserName.Location = new Point(labelX, ptbAvatar.Bottom + (int)(16 * dpiFactor));
            lblUserName.Size = new Size(labelW, (int)(30 * dpiFactor));
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;

            // Role label
            lblUserRole.Location = new Point(labelX, lblUserName.Bottom + (int)(4 * dpiFactor));
            lblUserRole.Size = new Size(labelW, (int)(22 * dpiFactor));
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;

            // Department & Facility
            lblDeptAndFacility.Location = new Point(labelX, lblUserRole.Bottom + (int)(8 * dpiFactor));
            lblDeptAndFacility.Size = new Size(labelW, (int)(46 * dpiFactor));
            lblDeptAndFacility.TextAlign = ContentAlignment.TopCenter;

            // Stat panels (matching DPV size of 131x95)
            int statW = (int)(131 * dpiFactor);
            int statH = (int)(95 * dpiFactor);
            int statGap = (int)(12 * dpiFactor);
            int statsTopY = lblDeptAndFacility.Bottom + (int)(16 * dpiFactor);
            int totalStatsW = statW * 2 + statGap;
            int statsStartX = (cardW - totalStatsW) / 2;

            pnlStat1.Location = new Point(statsStartX, statsTopY);
            pnlStat1.Size = new Size(statW, statH);
            pnlStat2.Location = new Point(statsStartX + statW + statGap, statsTopY);
            pnlStat2.Size = new Size(statW, statH);

            // Status badge
            int badgeW = (int)(155 * dpiFactor);
            int badgeH = (int)(28 * dpiFactor);
            lblStatusBadge.Size = new Size(badgeW, badgeH);
            lblStatusBadge.Location = new Point((cardW - badgeW) / 2, pnlStat1.Bottom + (int)(20 * dpiFactor));
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            string phone   = txtContactPhone.Text.Trim();
            string address = txtContactAddress.Text.Trim();
            string manv    = txtProfMaNV.Text.Trim();
            string hoten   = txtProfHoTen.Text.Trim();
            string phai    = txtProfGioiTinh.Text.Trim();
            string cmnd    = txtProfCccd.Text.Trim();
            string vaitro  = txtProfVaiTro.Text.Trim();
            // KTV hiển thị CHUYENKHOA trong txtKhoa; COSO lưu trong _originalCoSo
            string chuyenkhoa = txtKhoa.Text.Trim();

            DateTime? ngaysinh = null;
            if (!string.IsNullOrWhiteSpace(txtProfNgaySinh.Text))
            {
                if (DateTime.TryParseExact(txtProfNgaySinh.Text.Trim(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dob))
                {
                    ngaysinh = dob;
                }
                else
                {
                    ShowInfoMessage("Ngày sinh phải đúng định dạng dd/MM/yyyy.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                    return;
                }
            }

            try
            {
                // Gửi toàn bộ dữ liệu xuống Oracle — bảo mật được thực thi ở tầng SP/Trigger
                bool success = HospitalX.DAO.ProfileDAO.Instance.UpdateProfile(
                    phone, address, 
                    txtProfMaNV.Text.Trim() == _originalMaNV ? _originalMaNV : txtProfMaNV.Text.Trim(),
                    txtProfHoTen.Text.Trim() == _originalHoTen ? _originalHoTen : txtProfHoTen.Text.Trim(),
                    txtProfGioiTinh.Text.Trim() == _originalGioiTinh ? _originalGioiTinh : txtProfGioiTinh.Text.Trim(),
                    ngaysinh, 
                    txtProfCccd.Text.Trim() == _originalCccd ? _originalCccd : txtProfCccd.Text.Trim(),
                    txtProfVaiTro.Text.Trim() == _originalVaiTro ? _originalVaiTro : txtProfVaiTro.Text.Trim(),
                    chuyenkhoa: txtKhoa.Text.Trim() == _originalKhoa ? _originalKhoa : txtKhoa.Text.Trim(),
                    coso: _originalCoSo);

                if (success)
                {
                    SavedPhone   = phone;
                    SavedAddress = address;
                    LoadProfileData();

                    // Refresh main form header info (sidebar name)
                    var mainForm = this.FindForm() as HospitalX.GUI.PH2.Main_KTV;
                    if (mainForm != null)
                    {
                        mainForm.LoadKtvInfo();
                    }

                    ShowInfoMessage("Cập nhật thông tin cá nhân thành công!", "Thông báo", MessageDialogIcon.Information);
                }
                else
                {
                    ShowInfoMessage("Không thể cập nhật thông tin cá nhân. Vui lòng thử lại.", "Lỗi cập nhật", MessageDialogIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi Oracle — chính sách bảo mật từ chối cập nhật trường bị hạn chế
                ShowInfoMessage("Lỗi CSDL: " + ex.Message, "Cập nhật bị từ chối", MessageDialogIcon.Error);
                LoadProfileData(); // Reset về giá trị gốc từ DB
            }
        }

        private void ContactFieldChanged(object sender, EventArgs e)
        {
            if (_isLoadingContact) return;
            UpdateContactSaveButton();
        }

        private void ReloadContactData()
        {
            _isLoadingContact = true;
            txtContactPhone.Text = SavedPhone;
            txtContactAddress.Text = SavedAddress;
            AcceptCurrentContactValues();
            _isLoadingContact = false;
            UpdateContactSaveButton();
        }

        private void AcceptCurrentContactValues()
        {
            _originalContactPhone   = NormalizeContactText(txtContactPhone.Text);
            _originalContactAddress = NormalizeContactText(txtContactAddress.Text);
            _originalMaNV     = NormalizeContactText(txtProfMaNV.Text);
            _originalHoTen    = NormalizeContactText(txtProfHoTen.Text);
            _originalVaiTro   = NormalizeContactText(txtProfVaiTro.Text);
            _originalKhoa     = NormalizeContactText(txtKhoa.Text);
            _originalGioiTinh = NormalizeContactText(txtProfGioiTinh.Text);
            _originalNgaySinh = NormalizeContactText(txtProfNgaySinh.Text);
            _originalCccd     = NormalizeContactText(txtProfCccd.Text);
        }

        private void UpdateContactSaveButton()
        {
            bool changed = NormalizeContactText(txtContactPhone.Text)   != _originalContactPhone
                || NormalizeContactText(txtContactAddress.Text) != _originalContactAddress
                || NormalizeContactText(txtProfMaNV.Text)       != _originalMaNV
                || NormalizeContactText(txtProfHoTen.Text)      != _originalHoTen
                || NormalizeContactText(txtProfVaiTro.Text)     != _originalVaiTro
                || NormalizeContactText(txtKhoa.Text)           != _originalKhoa
                || NormalizeContactText(txtProfGioiTinh.Text)   != _originalGioiTinh
                || NormalizeContactText(txtProfNgaySinh.Text)   != _originalNgaySinh
                || NormalizeContactText(txtProfCccd.Text)       != _originalCccd;
            btnUpdateContact.Visible = true;
            btnUpdateContact.Enabled = changed;
            btnUpdateContact.Cursor = changed ? Cursors.Hand : Cursors.Default;
        }

        private static string NormalizeContactText(string value)
        {
            return (value ?? string.Empty).Trim();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Open mock change password dialog
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }

        private static bool IsPhoneNumber(string value)
        {
            foreach (char c in value)
            {
                if (c != ' ' && (c < '0' || c > '9')) return false;
            }
            return true;
        }

        private void ShowInfoMessage(string message, string title, MessageDialogIcon icon)
        {
            if (_messageDialog == null)
            {
                _messageDialog = new Guna2MessageDialog();
            }

            _messageDialog.Parent = FindForm();
            _messageDialog.Icon = icon;
            _messageDialog.Buttons = MessageDialogButtons.OK;
            _messageDialog.Caption = title;
            _messageDialog.Style = MessageDialogStyle.Light;
            _messageDialog.Show(message);
        }
    }
}

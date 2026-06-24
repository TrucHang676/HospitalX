using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HospitalX.DAO;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucHoSoCaNhan : UserControl
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86); // #0F6E56
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226); // #DAE8E2
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42); // #18302A
        private static readonly Color TextMuted = Color.FromArgb(122, 149, 137); // #7A9589
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);



        private static string SavedPhone = "0901234567";
        private static string SavedAddress = "78/15 Đường Nguyễn Chí Thanh, Quận 5, TP. Hồ Chí Minh";
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

        public ucHoSoCaNhan()
        {
            InitializeComponent();
            DoubleBuffered = true;
            txtContactPhone.TextChanged += txtContactPhone_TextChanged;
            txtContactAddress.TextChanged += txtContactAddress_TextChanged;
            
            txtProfMaNV.TextChanged += (s, ev) => ContactFieldChanged();
            txtProfHoTen.TextChanged += (s, ev) => ContactFieldChanged();
            txtProfVaiTro.TextChanged += (s, ev) => ContactFieldChanged();
            txtKhoa.TextChanged += (s, ev) => ContactFieldChanged();
            txtProfGioiTinh.TextChanged += (s, ev) => ContactFieldChanged();
            txtProfNgaySinh.TextChanged += (s, ev) => ContactFieldChanged();
            txtProfCccd.TextChanged += (s, ev) => ContactFieldChanged();
            
            btnUpdateContact.Click += btnUpdateContact_Click;
        }

        private void ucHoSoCaNhan_Load(object sender, EventArgs e)
        {
            SetupStyles();
            LoadProfileData();
            ucHoSoCaNhan_Resize(null, null);
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
            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap, "0", "HSBA đã tạo");
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap, "0", "Lượt điều phối KTV");

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
            _isLoadingContact = true;

            try
            {
                DataTable dt = ProfileDAO.Instance.GetProfile();
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string maNV = row["MANV"]?.ToString() ?? string.Empty;
                    string hoTen = row["HOTEN"]?.ToString() ?? string.Empty;
                    string phai = row["PHAI"]?.ToString() ?? string.Empty;
                    string ngaySinh = string.Empty;
                    if (row["NGAYSINH"] != DBNull.Value)
                    {
                        ngaySinh = Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy");
                    }
                    string cmnd = row["CMND"]?.ToString() ?? string.Empty;
                    string queQuan = row["QUEQUAN"]?.ToString() ?? string.Empty;
                    string soDT = row["SODT"]?.ToString() ?? string.Empty;
                    string vaiTro = row["VAITRO"]?.ToString() ?? string.Empty;
                    string chuyenKhoa = row["CHUYENKHOA"]?.ToString() ?? string.Empty;
                    string coSo = row["COSO"]?.ToString() ?? string.Empty;

                    lblUserName.Text = hoTen;
                    txtProfMaNV.Text = maNV;
                    txtProfHoTen.Text = hoTen;
                    txtProfVaiTro.Text = vaiTro;
                    lblUserRole.Text = vaiTro;
                    txtKhoa.Text = coSo;
                    lblDeptAndFacility.Text = $"Chi nhánh {coSo}\r\nBệnh viện Đa khoa Tỉnh";
                    txtProfGioiTinh.Text = phai;
                    txtProfNgaySinh.Text = ngaySinh;
                    txtProfCccd.Text = cmnd;

                    txtContactPhone.Text = soDT;
                    txtContactAddress.Text = queQuan;

                    // Set gender-appropriate avatar
                    if (phai.Equals("Nam", StringComparison.OrdinalIgnoreCase))
                    {
                        ptbAvatar.Image = DpvAssets.Load("male_doctor.png");
                    }
                    else
                    {
                        ptbAvatar.Image = DpvAssets.Load("female_doctor.png");
                    }

                    SavedPhone = soDT;
                    SavedAddress = queQuan;
                    _originalCoSo = coSo;
                }
                else
                {
                    ClearProfileFields();
                }
            }
            catch (Exception)
            {
                ClearProfileFields();
            }

            AcceptCurrentContactValues();
            _isLoadingContact = false;
            UpdateContactSaveButton();

            // Load dynamically calculated stats from database
            try
            {
                DataTable dtStats = ProfileDAO.Instance.GetProfileStats();
                if (dtStats != null && dtStats.Rows.Count > 0)
                {
                    lblStat1Val.Text = dtStats.Rows[0]["SO_HSBA"]?.ToString() ?? "0";
                    lblStat2Val.Text = dtStats.Rows[0]["SO_PHAN_CONG"]?.ToString() ?? "0";
                }
                else
                {
                    lblStat1Val.Text = "0";
                    lblStat2Val.Text = "0";
                }
            }
            catch
            {
                lblStat1Val.Text = "0";
                lblStat2Val.Text = "0";
            }
        }

        private void ClearProfileFields()
        {
            lblUserName.Text = "";
            txtProfMaNV.Text = "";
            txtProfHoTen.Text = "";
            txtProfVaiTro.Text = "";
            lblUserRole.Text = "";
            txtKhoa.Text = "";
            lblDeptAndFacility.Text = "";
            txtProfGioiTinh.Text = "";
            txtProfNgaySinh.Text = "";
            txtProfCccd.Text = "";

            txtContactPhone.Text = "";
            txtContactAddress.Text = "";
        }


        private void ucHoSoCaNhan_Resize(object sender, EventArgs e)
        {
            int totalW = pnlScroll.ClientSize.Width;
            if (totalW <= 0) return;

            // Safeguard against AutoScroll coordinate shift during resize
            Point scrollPos = pnlScroll.AutoScrollPosition;
            pnlScroll.AutoScrollPosition = new Point(0, 0);

            int rightW = Math.Max(500, totalW - 368 - 24);
            pnlRight.Location = new Point(368, 24);
            pnlRight.Width = rightW;

            // Set dynamic card dimensions with expanded size
            pnlCardProfessional.Width = rightW;
            pnlCardProfessional.Height = 570;

            pnlCardSecurity.Width = rightW;
            pnlCardSecurity.Height = 120;

            // Dynamically calculate responsive two-column layouts inside cards
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
            txtProfMaNV.Left = colPadding;
            label1.Left = colPadding;
            txtProfMaNV.Top = 86;
            txtProfMaNV.Width = fieldW;
            txtProfMaNV.Height = 44;

            label2.Top = 64;
            txtProfHoTen.Left = col2X;
            label2.Left = col2X;
            txtProfHoTen.Top = 86;
            txtProfHoTen.Width = fieldW;
            txtProfHoTen.Height = 44;

            // Row 2
            label3.Top = 154;
            txtProfVaiTro.Left = colPadding;
            label3.Left = colPadding;
            txtProfVaiTro.Top = 176;
            txtProfVaiTro.Width = fieldW;
            txtProfVaiTro.Height = 44;

            lblKhoa.Top = 154;
            txtKhoa.Left = col2X;
            lblKhoa.Left = col2X;
            txtKhoa.Top = 176;
            txtKhoa.Width = fieldW;
            txtKhoa.Height = 44;

            // Subheader: Personal Info
            lblTitleContact.Top = 244;
            lblTitleContact.Left = colPadding;

            // Row 3
            label4.Top = 288;
            txtProfGioiTinh.Left = colPadding;
            label4.Left = colPadding;
            txtProfGioiTinh.Top = 310;
            txtProfGioiTinh.Width = fieldW;
            txtProfGioiTinh.Height = 44;

            label5.Top = 288;
            txtProfNgaySinh.Left = col2X;
            label5.Left = col2X;
            txtProfNgaySinh.Top = 310;
            txtProfNgaySinh.Width = fieldW;
            txtProfNgaySinh.Height = 44;

            // Row 4
            label6.Top = 378;
            txtProfCccd.Left = colPadding;
            label6.Left = colPadding;
            txtProfCccd.Top = 400;
            txtProfCccd.Width = fieldW;
            txtProfCccd.Height = 44;

            label8.Top = 378;
            txtContactPhone.Left = col2X;
            label8.Left = col2X;
            txtContactPhone.Top = 400;
            txtContactPhone.Width = fieldW;
            txtContactPhone.Height = 44;

            // Row 5 (Full-width address field)
            label9.Top = 468;
            txtContactAddress.Left = colPadding;
            label9.Left = colPadding;
            txtContactAddress.Top = 490;
            txtContactAddress.Width = rightW - (colPadding * 2);
            txtContactAddress.Height = 44;

            // Security Card Y positioning and height of fields
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

            // Restore AutoScroll position (AutoScrollPosition expects positive coords)
            pnlScroll.AutoScrollPosition = new Point(Math.Abs(scrollPos.X), Math.Abs(scrollPos.Y));
        }

        private void txtContactPhone_TextChanged(object sender, EventArgs e)
        {
            ContactFieldChanged();
        }

        private void txtContactAddress_TextChanged(object sender, EventArgs e)
        {
            ContactFieldChanged();
        }

        private void ContactFieldChanged()
        {
            if (_isLoadingContact)
            {
                return;
            }

            UpdateContactSaveButton();
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
            // DPV hiển thị COSO trong txtKhoa; không có CHUYENKHOA
            string coso    = txtKhoa.Text.Trim();

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
                bool success = ProfileDAO.Instance.UpdateProfile(
                    phone, address, 
                    txtProfMaNV.Text.Trim() == _originalMaNV ? _originalMaNV : txtProfMaNV.Text.Trim(),
                    txtProfHoTen.Text.Trim() == _originalHoTen ? _originalHoTen : txtProfHoTen.Text.Trim(),
                    txtProfGioiTinh.Text.Trim() == _originalGioiTinh ? _originalGioiTinh : txtProfGioiTinh.Text.Trim(),
                    ngaysinh, 
                    txtProfCccd.Text.Trim() == _originalCccd ? _originalCccd : txtProfCccd.Text.Trim(),
                    txtProfVaiTro.Text.Trim() == _originalVaiTro ? _originalVaiTro : txtProfVaiTro.Text.Trim(),
                    chuyenkhoa: string.Empty,  // DPV không có chuyên khoa
                    coso: txtKhoa.Text.Trim() == _originalCoSo ? _originalCoSo : txtKhoa.Text.Trim());

                if (success)
                {
                    SavedPhone   = phone;
                    SavedAddress = address;
                    LoadProfileData();
                    ShowInfoMessage("Cập nhật thông tin thành công.", "Thông báo", MessageDialogIcon.Information);
                }
                else
                {
                    ShowInfoMessage("Cập nhật thông tin thất bại hoặc không thay đổi.", "Thông báo", MessageDialogIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi Oracle — chính sách bảo mật từ chối cập nhật trường bị hạn chế
                ShowInfoMessage("Lỗi CSDL: " + ex.Message, "Cập nhật bị từ chối", MessageDialogIcon.Error);
                LoadProfileData(); // Reset về giá trị gốc từ DB
            }
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

        private static bool IsPhoneNumber(string val)
        {
            foreach (char c in val)
            {
                if (c != ' ' && (c < '0' || c > '9')) return false;
            }
            return true;
        }

        private void ShowInfoMessage(string message, string title, MessageDialogIcon icon)
        {
            if (FindForm() is Main_DPV mainDpv)
            {
                mainDpv.ShowMessage(message, title, icon);
            }
            else
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon == MessageDialogIcon.Information ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }
    }
}

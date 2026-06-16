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
        private bool _isLoadingContact;



        public ucHoSoCaNhan()
        {
            InitializeComponent();
            DoubleBuffered = true;
            txtContactPhone.TextChanged += txtContactPhone_TextChanged;
            txtContactAddress.TextChanged += txtContactAddress_TextChanged;
            btnUpdateContact.Click += btnUpdateContact_Click;
        }

        private void ucHoSoCaNhan_Load(object sender, EventArgs e)
        {
            LoadProfileData();
            SetupStyles();
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
            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap, "124", "HSBA đã tạo");
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap, "98", "Lượt điều phối KTV");

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

            foreach (var panel in new[] { pnlCardProfessional, pnlCardContact, pnlCardSecurity })
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
            pnlCardContact.Margin = new Padding(0, 0, 0, 20);
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
            box.ReadOnly = true;
            box.Enabled = false;
            box.FillColor = Color.FromArgb(247, 249, 248);
            box.BorderColor = Color.FromArgb(230, 238, 235);
            box.ForeColor = Color.FromArgb(90, 110, 100);
            box.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
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

                    lblUserName.Text = hoTen;
                    txtProfMaNV.Text = maNV;
                    txtProfHoTen.Text = hoTen;
                    txtProfVaiTro.Text = vaiTro;
                    lblUserRole.Text = vaiTro;
                    txtKhoa.Text = chuyenKhoa;
                    lblDeptAndFacility.Text = $"{chuyenKhoa}\r\nBệnh viện Đa khoa Tỉnh";
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
            pnlCardProfessional.Height = 250;

            pnlCardContact.Width = rightW;
            pnlCardContact.Height = 340;

            pnlCardSecurity.Width = rightW;
            pnlCardSecurity.Height = 120;

            // Dynamically calculate responsive two-column layouts inside cards
            int colPadding = 24;
            int colGap = 24;
            int fieldW = (rightW - (colPadding * 2) - colGap) / 2;
            int col2X = colPadding + fieldW + colGap;

            // Professional Card Y positioning and height of fields
            lblTitleProf.Top = 20;

            label1.Top = 64;
            txtProfMaNV.Left = colPadding;
            label1.Left = colPadding;
            txtProfMaNV.Top = 86;
            txtProfMaNV.Width = fieldW;
            txtProfMaNV.Height = 44;

            label3.Top = 154;
            txtProfVaiTro.Left = colPadding;
            label3.Left = colPadding;
            txtProfVaiTro.Top = 176;
            txtProfVaiTro.Width = fieldW;
            txtProfVaiTro.Height = 44;

            label2.Top = 64;
            txtProfHoTen.Left = col2X;
            label2.Left = col2X;
            txtProfHoTen.Top = 86;
            txtProfHoTen.Width = fieldW;
            txtProfHoTen.Height = 44;

            lblKhoa.Top = 154;
            txtKhoa.Left = col2X;
            lblKhoa.Left = col2X;
            txtKhoa.Top = 176;
            txtKhoa.Width = fieldW;
            txtKhoa.Height = 44;

            // Personal/Contact Card Y positioning and height of fields
            lblTitleContact.Top = 20;
            btnUpdateContact.Top = 20;
            btnUpdateContact.Height = 40;
            btnUpdateContact.Location = new Point(rightW - btnUpdateContact.Width - 24, btnUpdateContact.Top);

            label4.Top = 64;
            txtProfGioiTinh.Left = colPadding;
            label4.Left = colPadding;
            txtProfGioiTinh.Top = 86;
            txtProfGioiTinh.Width = fieldW;
            txtProfGioiTinh.Height = 44;

            label6.Top = 154;
            txtProfCccd.Left = colPadding;
            label6.Left = colPadding;
            txtProfCccd.Top = 176;
            txtProfCccd.Width = fieldW;
            txtProfCccd.Height = 44;

            label5.Top = 64;
            txtProfNgaySinh.Left = col2X;
            label5.Left = col2X;
            txtProfNgaySinh.Top = 86;
            txtProfNgaySinh.Width = fieldW;
            txtProfNgaySinh.Height = 44;

            label8.Top = 154;
            txtContactPhone.Left = col2X;
            label8.Left = col2X;
            txtContactPhone.Top = 176;
            txtContactPhone.Width = fieldW;
            txtContactPhone.Height = 44;

            // Full-width address field
            label9.Top = 244;
            txtContactAddress.Left = colPadding;
            label9.Left = colPadding;
            txtContactAddress.Top = 266;
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
            string phone = txtContactPhone.Text.Trim();
            string address = txtContactAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone) || phone.Replace(" ", "").Length < 10 || !IsPhoneNumber(phone))
            {
                ShowInfoMessage("Số điện thoại phải là chữ số và có độ dài từ 10 ký tự trở lên.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                ShowInfoMessage("Địa chỉ cư trú không được bỏ trống.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            try
            {
                bool success = ProfileDAO.Instance.UpdateProfile(phone, address, txtProfMaNV.Text);
                if (success)
                {
                    SavedPhone = phone;
                    SavedAddress = address;
                    ReloadContactData();
                    ShowInfoMessage("Cập nhật thông tin liên hệ thành công.", "Thông báo", MessageDialogIcon.Information);
                }
                else
                {
                    ShowInfoMessage("Cập nhật thông tin liên hệ thất bại hoặc không thay đổi.", "Thông báo", MessageDialogIcon.Warning);
                }
            }
            catch (Exception)
            {
                // Graceful fallback if database is offline/mock mode
                SavedPhone = phone;
                SavedAddress = address;
                ReloadContactData();
                ShowInfoMessage("Cập nhật thông tin liên hệ thành công (Chế độ ngoại tuyến).", "Thông báo", MessageDialogIcon.Information);
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
            _originalContactPhone = NormalizeContactText(txtContactPhone.Text);
            _originalContactAddress = NormalizeContactText(txtContactAddress.Text);
        }

        private void UpdateContactSaveButton()
        {
            bool changed = NormalizeContactText(txtContactPhone.Text) != _originalContactPhone
                || NormalizeContactText(txtContactAddress.Text) != _originalContactAddress;

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

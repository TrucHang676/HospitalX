using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.DieuPhoiVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using HospitalX.DAO;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucHSCN : UserControl
    {
        private static readonly Color ThemeGreen = Color.FromArgb(15, 110, 86);
        private static readonly Color BorderGray = Color.FromArgb(218, 232, 226);
        private static readonly Color TextDark = Color.FromArgb(24, 48, 42);
        private static readonly Color TextMuted = Color.FromArgb(122, 149, 137);

        private Guna2MessageDialog _messageDialog;
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

        private static string SavedPhone = "090 123 4567";
        private static string SavedAddress = "Q. Bình Thạnh, TP.HCM";

        public ucHSCN()
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

        private void ucHSCN_Load(object sender, EventArgs e)
        {
            SetupStyles();
            LoadProfileData();
            ConfigureScrolling();
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
                    _originalCoSo = coSo;

                    lblUserName.Text = hoTen;
                    txtProfMaNV.Text = maNV;
                    txtProfHoTen.Text = hoTen;
                    txtProfVaiTro.Text = vaiTro;
                    lblUserRole.Text = vaiTro;
                    txtKhoa.Text = chuyenKhoa;
                    lblDeptAndFacility.Text = $"Bệnh viện Đa khoa Tỉnh\r\nChi nhánh {coSo}";
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
                    lblStat2Val.Text = dtStats.Rows[0]["SO_BENH_NHAN"]?.ToString() ?? "0";
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

        private void SetupStyles()
        {
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
            lblDeptAndFacility.Font = new Font("Segoe UI", 9F);

            StyleStatPanel(pnlStat1, lblStat1Val, lblStat1Cap, "0", "HSBA liên quan");
            StyleStatPanel(pnlStat2, lblStat2Val, lblStat2Cap, "0", "Bệnh nhân");

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
                lblSlogan.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
                lblSlogan.ForeColor = Color.FromArgb(80, 110, 95);
                lblSlogan.Margin = new Padding(0, 16, 0, 24);
            }

            SetupReadOnlyField(txtProfMaNV);
            SetupReadOnlyField(txtProfHoTen);
            SetupReadOnlyField(txtProfVaiTro);
            SetupReadOnlyField(txtKhoa);
            SetupReadOnlyField(txtProfGioiTinh);
            SetupReadOnlyField(txtProfNgaySinh);
            SetupReadOnlyField(txtProfCccd);

            lblKhoa.Text = "CHUYÊN KHOA";

            txtContactPhone.Font = new Font("Segoe UI", 10.5F);
            txtContactAddress.Font = new Font("Segoe UI", 10.5F);

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

        private void StyleStatPanel(Guna2Panel panel, Label valueLabel, Label captionLabel, string value, string caption)
        {
            panel.BorderColor = Color.FromArgb(230, 238, 235);
            panel.BorderThickness = 1;
            panel.BorderRadius = 10;
            panel.FillColor = Color.FromArgb(247, 249, 248);

            valueLabel.Text = value;
            valueLabel.ForeColor = ThemeGreen;
            valueLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);

            captionLabel.Text = caption;
            captionLabel.ForeColor = TextMuted;
            captionLabel.Font = new Font("Segoe UI", 8F);
        }

        private void SetupReadOnlyField(Guna2TextBox box)
        {
            box.ReadOnly = false;
            box.Enabled = true;
            box.FillColor = Color.White;
            box.BorderColor = BorderGray;
            box.ForeColor = TextDark;
            box.Font = new Font("Segoe UI", 10.5F);
        }

        private void ucHSCN_Resize(object sender, EventArgs e)
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

            // Restore AutoScroll position
            pnlScroll.AutoScrollPosition = new Point(Math.Abs(scrollPos.X), Math.Abs(scrollPos.Y));
        }

        private void ConfigureScrolling()
        {
            pnlScroll.AutoScroll = true;
            pnlScroll.AutoScrollMargin = new Size(0, 24);
            pnlScroll.AutoScrollMinSize = new Size(0, pnlRight.Bottom + 24);

            pnlScroll.MouseWheel += ScrollRoot_MouseWheel;
            pnlRight.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardProfessional.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardContact.MouseWheel += ScrollRoot_MouseWheel;
            pnlCardSecurity.MouseWheel += ScrollRoot_MouseWheel;
        }

        private void ScrollRoot_MouseWheel(object sender, MouseEventArgs e)
        {
            ScrollContainer(pnlScroll, e.Delta);
        }

        private static void ScrollContainer(ScrollableControl container, int delta)
        {
            int currentY = -container.AutoScrollPosition.Y;
            int nextY = currentY - Math.Sign(delta) * 48;
            if (nextY < 0)
            {
                nextY = 0;
            }

            container.AutoScrollPosition = new Point(0, nextY);
        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            string phone = txtContactPhone.Text.Trim();
            string address = txtContactAddress.Text.Trim();

            if (string.IsNullOrWhiteSpace(phone) || phone.Replace(" ", "").Length < 10 || !IsPhoneNumber(phone))
            {
                ShowMessage("Số điện thoại liên hệ phải là chữ số và có độ dài từ 10 ký tự trở lên.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(address))
            {
                ShowMessage("Địa chỉ cư trú không được bỏ trống.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                return;
            }

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
                    ShowMessage("Ngày sinh phải đúng định dạng dd/MM/yyyy.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                    return;
                }
            }

            try
            {
                bool success = ProfileDAO.Instance.UpdateProfile(
                    phone,
                    address,
                    txtProfMaNV.Text.Trim() == _originalMaNV ? _originalMaNV : txtProfMaNV.Text.Trim(),
                    txtProfHoTen.Text.Trim() == _originalHoTen ? _originalHoTen : txtProfHoTen.Text.Trim(),
                    txtProfGioiTinh.Text.Trim() == _originalGioiTinh ? _originalGioiTinh : txtProfGioiTinh.Text.Trim(),
                    ngaysinh,
                    txtProfCccd.Text.Trim() == _originalCccd ? _originalCccd : txtProfCccd.Text.Trim(),
                    txtProfVaiTro.Text.Trim() == _originalVaiTro ? _originalVaiTro : txtProfVaiTro.Text.Trim(),
                    txtKhoa.Text.Trim() == _originalKhoa ? _originalKhoa : txtKhoa.Text.Trim(),
                    _originalCoSo
                );

                if (success)
                {
                    SavedPhone = phone;
                    SavedAddress = address;
                    ReloadContactData();
                    ShowMessage("Cập nhật thông tin thành công.", "Thông báo", MessageDialogIcon.Information);
                }
                else
                {
                    ShowMessage("Cập nhật thông tin thất bại hoặc không thay đổi.", "Thông báo", MessageDialogIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Lỗi CSDL: " + ex.Message, "Lỗi cập nhật", MessageDialogIcon.Error);
                LoadProfileData(); // Reset to original values from DB
            }
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
            _originalMaNV = NormalizeContactText(txtProfMaNV.Text);
            _originalHoTen = NormalizeContactText(txtProfHoTen.Text);
            _originalVaiTro = NormalizeContactText(txtProfVaiTro.Text);
            _originalKhoa = NormalizeContactText(txtKhoa.Text);
            _originalGioiTinh = NormalizeContactText(txtProfGioiTinh.Text);
            _originalNgaySinh = NormalizeContactText(txtProfNgaySinh.Text);
            _originalCccd = NormalizeContactText(txtProfCccd.Text);
        }

        private void UpdateContactSaveButton()
        {
            bool changed = NormalizeContactText(txtContactPhone.Text) != _originalContactPhone
                || NormalizeContactText(txtContactAddress.Text) != _originalContactAddress
                || NormalizeContactText(txtProfMaNV.Text) != _originalMaNV
                || NormalizeContactText(txtProfHoTen.Text) != _originalHoTen
                || NormalizeContactText(txtProfVaiTro.Text) != _originalVaiTro
                || NormalizeContactText(txtKhoa.Text) != _originalKhoa
                || NormalizeContactText(txtProfGioiTinh.Text) != _originalGioiTinh
                || NormalizeContactText(txtProfNgaySinh.Text) != _originalNgaySinh
                || NormalizeContactText(txtProfCccd.Text) != _originalCccd;

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
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }

        private static bool IsPhoneNumber(string value)
        {
            foreach (char c in value)
            {
                if (c != ' ' && (c < '0' || c > '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private void ShowMessage(string message, string title, MessageDialogIcon icon)
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

using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucThemSuaBN : UserControl
    {
        private bool _isEditMode = false;
        private Image _imgUpload = null;
        private Image _imgDpv3 = null;

        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        public ucThemSuaBN()
        {
            InitializeComponent();
            DoubleBuffered = true;
            ApplyStyles();
        }

        private void ucThemSuaBN_Load(object sender, EventArgs e)
        {
            _imgUpload = DpvAssets.Load("picture.png"); // Upload icon
            _imgDpv3 = DpvAssets.Load("dpv_3.png");     // Pencil icon

            // Default Avatar
            picAvatar.Image = DpvAssets.Load("user.png");

            // Prevent cursor caret from showing on read-only MaBN while keeping focus/glow
            txtMaBN.Enter += (s, ev) => HideCaret(txtMaBN.Handle);
            txtMaBN.GotFocus += (s, ev) => HideCaret(txtMaBN.Handle);

            // Wire Search Panel events
            btnSearch.Click += (s, ev) => ExecuteSearch();
            txtSearch.KeyDown += (s, ev) => {
                if (ev.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    ExecuteSearch();
                    ev.SuppressKeyPress = true; // Prevent Windows beep
                }
            };

            ApplyButtonIcons();
            InitComboBoxes();
            SetMode(false); // Default to Add mode

            // Handle resize
            this.Resize += (s, ev) => AdjustLayoutSizes();
            AdjustLayoutSizes();
        }

        private void InitComboBoxes()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("-- Chọn --");
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = 0;

            cboNhomMau.Items.Clear();
            cboNhomMau.Items.Add("-- Chọn --");
            cboNhomMau.Items.Add("A");
            cboNhomMau.Items.Add("B");
            cboNhomMau.Items.Add("AB");
            cboNhomMau.Items.Add("O");
            cboNhomMau.SelectedIndex = 0;

            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("-- Chọn khoa --");
            cboKhoa.Items.Add("Tim mạch");
            cboKhoa.Items.Add("Nội tổng quát");
            cboKhoa.Items.Add("Chỉnh hình");
            cboKhoa.Items.Add("Sản khoa");
            cboKhoa.Items.Add("Thần kinh");
            cboKhoa.Items.Add("Nhi khoa");
            cboKhoa.SelectedIndex = 0;

            cboHinhThuc.Items.Clear();
            cboHinhThuc.Items.Add("Khám thường");
            cboHinhThuc.Items.Add("Cấp cứu");
            cboHinhThuc.Items.Add("Chuyển viện");
            cboHinhThuc.SelectedIndex = 0;

            dtpNgaySinh.Value = new DateTime(1990, 1, 1);
            dtpNgayNhap.Value = DateTime.Now;
        }

        private void ApplyButtonIcons()
        {
            // Tab Add button (No Icon, Perfectly Centered)
            btnTabAdd.Image = null;
            btnTabAdd.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnTabAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnTabAdd.ImageOffset = new Point(0, 0);
            btnTabAdd.TextOffset = new Point(0, 0);

            // Tab Edit button (No Icon, Perfectly Centered)
            btnTabEdit.Image = null;
            btnTabEdit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnTabEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnTabEdit.ImageOffset = new Point(0, 0);
            btnTabEdit.TextOffset = new Point(0, 0);

            // Upload button
            if (_imgUpload != null)
            {
                btnUpload.Image = _imgUpload;
                btnUpload.ImageSize = new Size(20, 20);
                btnUpload.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
                btnUpload.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                btnUpload.ImageOffset = new Point(4, 0);
                btnUpload.TextOffset = new Point(16, 0);
                btnUpload.Text = "Tải ảnh lên";
            }

            // Section Icons
            ptbBasicIcon.Image = DpvAssets.Load("dpv_7.png");
            ptbContactIcon.Image = DpvAssets.Load("phone.png");
            ptbTreatmentIcon.Image = DpvAssets.Load("medical-report.png");

            // Search button and magnifying glass in the search panel
            Image imgSearch = DpvAssets.Load("magnifying-glass.png");
            if (imgSearch != null)
            {
                ptbSearchIcon.Image = imgSearch;
                btnSearch.Image = imgSearch;
                btnSearch.ImageSize = new Size(16, 16);
                btnSearch.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
                btnSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                btnSearch.ImageOffset = new Point(6, 0);
                btnSearch.TextOffset = new Point(16, 0);
                btnSearch.Text = "Tìm";
            }

            // Save Draft button
            Image imgDraft = DpvAssets.Load("save.png");
            if (imgDraft != null)
            {
                btnDraft.Image = imgDraft;
                btnDraft.ImageSize = new Size(20, 20);
                btnDraft.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
                btnDraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                btnDraft.ImageOffset = new Point(10, 0);
                btnDraft.TextOffset = new Point(22, 0);
            }

            // Save button icon
            Image imgSave = DpvAssets.Load("buttonTick.png");
            if (imgSave != null)
            {
                btnSave.Image = imgSave;
                btnSave.ImageSize = new Size(20, 20);
                btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
                btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                btnSave.ImageOffset = new Point(12, 0);
                btnSave.TextOffset = new Point(24, 0);
            }
        }

        private void SetMode(bool editMode)
        {
            _isEditMode = editMode;

            if (editMode)
            {
                // Active tab Edit
                btnTabAdd.Checked = false;
                btnTabEdit.Checked = true;

                btnTabAdd.FillColor = Color.FromArgb(244, 247, 246);
                btnTabAdd.ForeColor = Color.FromArgb(122, 149, 137);
                btnTabAdd.BorderColor = Color.FromArgb(218, 232, 226);

                btnTabEdit.FillColor = Color.FromArgb(15, 110, 86); // teal
                btnTabEdit.ForeColor = Color.White;
                btnTabEdit.BorderColor = Color.FromArgb(15, 110, 86);

                // Show Search Panel
                pnlSearchCard.Visible = true;
                txtSearch.Text = "";

                // Clear all fields initially in edit mode to wait for search query to be clicked
                txtHoDem.Text = "";
                txtTen.Text = "";
                txtMaBN.Text = "Tự động tạo";
                dtpNgaySinh.Value = new DateTime(1990, 1, 1);
                cboGioiTinh.SelectedIndex = 0;
                cboNhomMau.SelectedIndex = 0;
                txtCccd.Text = "";
                txtBhyt.Text = "";
                txtSdt.Text = "";
                txtEmail.Text = "";
                txtNguoiLienHe.Text = "";
                txtDiaChi.Text = "";
                cboKhoa.SelectedIndex = 0;
                cboHinhThuc.SelectedIndex = 0;
                dtpNgayNhap.Value = DateTime.Now;
                txtLyDo.Text = "";
                txtTienSu.Text = "";
                picAvatar.Image = DpvAssets.Load("user.png");

                btnSave.Text = "Lưu thay đổi";
            }
            else
            {
                // Active tab Add
                btnTabAdd.Checked = true;
                btnTabEdit.Checked = false;

                btnTabAdd.FillColor = Color.FromArgb(15, 110, 86); // teal
                btnTabAdd.ForeColor = Color.White;
                btnTabAdd.BorderColor = Color.FromArgb(15, 110, 86);

                btnTabEdit.FillColor = Color.FromArgb(244, 247, 246);
                btnTabEdit.ForeColor = Color.FromArgb(122, 149, 137);
                btnTabEdit.BorderColor = Color.FromArgb(218, 232, 226);

                // Hide Search Panel
                pnlSearchCard.Visible = false;

                // Clear all fields
                txtHoDem.Text = "";
                txtTen.Text = "";
                txtMaBN.Text = "Tự động tạo";
                dtpNgaySinh.Value = new DateTime(1990, 1, 1);
                cboGioiTinh.SelectedIndex = 0;
                cboNhomMau.SelectedIndex = 0;
                txtCccd.Text = "";
                txtBhyt.Text = "";
                txtSdt.Text = "";
                txtEmail.Text = "";
                txtNguoiLienHe.Text = "";
                txtDiaChi.Text = "";
                cboKhoa.SelectedIndex = 0;
                cboHinhThuc.SelectedIndex = 0;
                dtpNgayNhap.Value = DateTime.Now;
                txtLyDo.Text = "";
                txtTienSu.Text = "";
                picAvatar.Image = DpvAssets.Load("user.png");

                btnSave.Text = "Lưu bệnh nhân";
            }

            // Trigger dynamic co-sizing and positioning updates
            AdjustLayoutSizes();
        }

        private void btnTabAdd_Click(object sender, EventArgs e)
        {
            SetMode(false);
        }

        private void btnTabEdit_Click(object sender, EventArgs e)
        {
            SetMode(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NavigateBack();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            string errorMsg = "Vui lòng điền đầy đủ các thông tin bắt buộc (*):";

            // Validate txtHoDem
            if (string.IsNullOrWhiteSpace(txtHoDem.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtHoDem);
                errorMsg += "\n- Họ và đệm";
            }
            else
            {
                ResetFieldStyle(txtHoDem);
            }

            // Validate txtTen
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtTen);
                errorMsg += "\n- Tên";
            }
            else
            {
                ResetFieldStyle(txtTen);
            }

            // Validate cboGioiTinh
            if (cboGioiTinh.SelectedIndex == 0)
            {
                isValid = false;
                MarkFieldInvalid(cboGioiTinh);
                errorMsg += "\n- Giới tính";
            }
            else
            {
                ResetFieldStyle(cboGioiTinh);
            }

            // Validate txtCccd
            if (string.IsNullOrWhiteSpace(txtCccd.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtCccd);
                errorMsg += "\n- CCCD / Hộ chiếu";
            }
            else
            {
                ResetFieldStyle(txtCccd);
            }

            // Validate txtSdt
            if (string.IsNullOrWhiteSpace(txtSdt.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtSdt);
                errorMsg += "\n- Số điện thoại";
            }
            else
            {
                ResetFieldStyle(txtSdt);
            }

            // Validate txtDiaChi
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtDiaChi);
                errorMsg += "\n- Địa chỉ thường trú";
            }
            else
            {
                ResetFieldStyle(txtDiaChi);
            }

            // Validate cboKhoa
            if (cboKhoa.SelectedIndex == 0)
            {
                isValid = false;
                MarkFieldInvalid(cboKhoa);
                errorMsg += "\n- Khoa tiếp nhận";
            }
            else
            {
                ResetFieldStyle(cboKhoa);
            }

            if (!isValid)
            {
                if (this.guna2MessageDialog1 == null)
                {
                    this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                }
                guna2MessageDialog1.Parent = this.FindForm();
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Caption = "Thiếu thông tin";
                guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
                guna2MessageDialog1.Show(errorMsg);
                return;
            }

            // Successful save
            string msg = _isEditMode 
                ? $"Đã lưu thông tin thay đổi cho bệnh nhân {txtHoDem.Text.Trim()} {txtTen.Text.Trim()} thành công."
                : $"Đã thêm mới bệnh nhân {txtHoDem.Text.Trim()} {txtTen.Text.Trim()} vào hệ thống thành công.";

            if (this.guna2MessageDialog1 == null)
            {
                this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            }
            guna2MessageDialog1.Parent = this.FindForm();
            guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = "Thông báo";
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            guna2MessageDialog1.Show(msg);

            NavigateBack();
        }

        private void MarkFieldInvalid(Control control)
        {
            Color errorColor = Color.FromArgb(253, 114, 114);
            
            if (control is Guna2TextBox txt)
            {
                txt.BorderColor = errorColor;
                txt.HoverState.BorderColor = errorColor;
                txt.FocusedState.BorderColor = errorColor;
                
                txt.TextChanged -= Txt_TextChanged;
                txt.TextChanged += Txt_TextChanged;
            }
            else if (control is Guna2ComboBox cbo)
            {
                cbo.BorderColor = errorColor;
                cbo.HoverState.BorderColor = errorColor;
                cbo.FocusedState.BorderColor = errorColor;
                
                cbo.SelectedIndexChanged -= Cbo_SelectedIndexChanged;
                cbo.SelectedIndexChanged += Cbo_SelectedIndexChanged;
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (sender is Guna2TextBox txt && !string.IsNullOrWhiteSpace(txt.Text))
            {
                ResetFieldStyle(txt);
            }
        }

        private void Cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is Guna2ComboBox cbo && cbo.SelectedIndex > 0)
            {
                ResetFieldStyle(cbo);
            }
        }

        private void ResetFieldStyle(Control control)
        {
            Color normalBorder = Color.FromArgb(218, 232, 226);
            Color tealTheme = Color.FromArgb(15, 110, 86);

            if (control is Guna2TextBox txt)
            {
                txt.BorderColor = normalBorder;
                txt.HoverState.BorderColor = tealTheme;
                txt.FocusedState.BorderColor = tealTheme;
            }
            else if (control is Guna2ComboBox cbo)
            {
                cbo.BorderColor = normalBorder;
                cbo.HoverState.BorderColor = tealTheme;
                cbo.FocusedState.BorderColor = tealTheme;
            }
        }

        private void NavigateBack()
        {
            var main = this.FindForm() as Main_DPV;
            if (main != null)
            {
                main.NavigateToDanhSachBN();
            }
        }

        private void AdjustLayoutSizes()
        {
            int targetWidth = pnlScroll.ClientSize.Width - 54;
            if (targetWidth < 1350) targetWidth = 1350;

            pnlSegment.Width = targetWidth;
            
            // Adjust search card co-size and dynamic position
            pnlSearchCard.Width = targetWidth;
            btnSearch.Left = targetWidth - 100 - 40; // width 100, right margin 40

            // Dynamically position main form card below search card if visible
            if (pnlSearchCard.Visible)
            {
                pnlFormCard.Location = new Point(27, 190);
                pnlFormCard.Size = new Size(targetWidth, 1220);
            }
            else
            {
                pnlFormCard.Location = new Point(27, 80);
                pnlFormCard.Size = new Size(targetWidth, 1220);
            }

            // Dynamically stretch footer and align buttons to the right
            pnlFormFooter.Width = targetWidth;
            btnSave.Left = targetWidth - 180 - 40; // width 180, right margin 40
            btnDraft.Left = btnSave.Left - 140 - 16; // width 140, gap 16
            btnCancel.Left = btnDraft.Left - 140 - 16; // width 140, gap 16

            // Adjust dynamic sizes of footer straightener panels
            var flatTop = pnlFormCard.Controls["pnlFooterFlatTop"];
            if (flatTop != null)
            {
                flatTop.Width = targetWidth;
            }
            var divider = pnlFormCard.Controls["pnlFooterDivider"];
            if (divider != null)
            {
                divider.Width = targetWidth;
            }
        }

        private void ExecuteSearch()
        {
            string query = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                return;
            }

            string queryLower = query.ToLower();
            bool found = false;
            string foundName = "";

            /* 
             * =========================================================================
             * CHÚ THÍCH HƯỚNG DẪN TÍCH HỢP DỮ LIỆU THẬT (REAL DATABASE INTEGRATION HOOK):
             * =========================================================================
             * Để kết nối với Cơ sở dữ liệu thật sau này, lập trình viên có thể thay thế
             * đoạn code bên dưới bằng một truy vấn SQL (ADO.NET, Entity Framework, Dapper, v.v.):
             * 
             * string sql = "SELECT * FROM BenhNhan WHERE MaBN = @Query OR TenFullName LIKE @Query";
             * using (SqlCommand cmd = new SqlCommand(sql, connection)) {
             *     cmd.Parameters.AddWithValue("@Query", "%" + query + "%");
             *     // Đọc dữ liệu đầu ra và gán vào các thuộc tính tương ứng:
             *     // txtHoDem.Text = reader["HoDem"].ToString();
             *     // txtTen.Text = reader["Ten"].ToString();
             *     // ...
             * }
             * =========================================================================
             */

            if (queryLower.Contains("cường") || queryLower.Contains("cuong") || queryLower.Contains("bn240046"))
            {
                // Tải thông tin chi tiết của Trần Thị Cường
                txtHoDem.Text = "Trần Thị";
                txtTen.Text = "Cường";
                txtMaBN.Text = "BN240046";
                dtpNgaySinh.Value = new DateTime(1980, 7, 11);
                cboGioiTinh.SelectedIndex = 2; // Nữ
                cboNhomMau.SelectedIndex = 1;  // A
                txtCccd.Text = "079196657049";
                txtBhyt.Text = "GD3-791966570";
                txtSdt.Text = "0901234567";
                txtEmail.Text = "cuong.tran@gmail.com";
                txtNguoiLienHe.Text = "Nguyễn Văn Hùng (Chồng)";
                txtDiaChi.Text = "123 Đường Ba Tháng Hai, Quận 10, TP. Hồ Chí Minh";
                cboKhoa.SelectedIndex = 6;     // Nhi khoa
                cboHinhThuc.SelectedIndex = 0; // Khám thường
                dtpNgayNhap.Value = new DateTime(2026, 5, 24);
                txtLyDo.Text = "Bé ho sốt kéo dài 3 ngày, muốn khám tổng quát.";
                txtTienSu.Text = "Không có tiền sử dị ứng thuốc, gia đình khỏe mạnh.";
                picAvatar.Image = DpvAssets.Load("female_doctor.png");
                
                found = true;
                foundName = "Trần Thị Cường";
            }
            else if (queryLower.Contains("lan") || queryLower.Contains("bn260195"))
            {
                // Tải thông tin chi tiết của Phạm Thị Lan
                txtHoDem.Text = "Phạm Thị";
                txtTen.Text = "Lan";
                txtMaBN.Text = "BN260195";
                dtpNgaySinh.Value = new DateTime(1992, 10, 15);
                cboGioiTinh.SelectedIndex = 2; // Nữ
                cboNhomMau.SelectedIndex = 2;  // B
                txtCccd.Text = "079192008472";
                txtBhyt.Text = "GD3-791920084";
                txtSdt.Text = "0987654321";
                txtEmail.Text = "lan.pham@gmail.com";
                txtNguoiLienHe.Text = "Phạm Văn Hải (Bố)";
                txtDiaChi.Text = "456 Đường Nguyễn Huệ, Quận 1, TP. Hồ Chí Minh";
                cboKhoa.SelectedIndex = 2;     // Nội tổng quát
                cboHinhThuc.SelectedIndex = 0; // Khám thường
                dtpNgayNhap.Value = new DateTime(2026, 5, 24);
                txtLyDo.Text = "Đau bụng vùng thượng vị kéo dài 2 ngày, kèm buồn nôn.";
                txtTienSu.Text = "Không có tiền sử dị ứng thuốc, dạ dày nhẹ.";
                picAvatar.Image = DpvAssets.Load("female_doctor.png");

                found = true;
                foundName = "Phạm Thị Lan";
            }

            if (found)
            {
                btnSave.Text = "Lưu thay đổi";

                if (this.guna2MessageDialog1 == null)
                {
                    this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                }
                guna2MessageDialog1.Parent = this.FindForm();
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Caption = "Tìm thấy bệnh nhân";
                guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
                guna2MessageDialog1.Show($"Đã tìm thấy và tải thông tin bệnh nhân \"{foundName}\" thành công.");
            }
            else
            {
                if (this.guna2MessageDialog1 == null)
                {
                    this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                }
                guna2MessageDialog1.Parent = this.FindForm();
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Caption = "Không tìm thấy";
                guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
                guna2MessageDialog1.Show($"Không tìm thấy bệnh nhân \"{query}\". Vui lòng thử tìm kiếm lại với 'Phạm Thị Lan' hoặc 'Trần Thị Cường'!");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picAvatar.Image = Image.FromFile(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ApplyStyles()
        {
            Color tealTheme = Color.FromArgb(15, 110, 86);
            Color lightGray = Color.FromArgb(244, 247, 246);
            Color grayGreen = Color.FromArgb(122, 149, 137);
            Color borderGray = Color.FromArgb(218, 232, 226);

            // Highlight Search Panel to stand out cleanly for high usability
            pnlSearchCard.BorderColor = tealTheme; // Green accent border
            pnlSearchCard.BorderThickness = 2; // Thicker border
            pnlSearchCard.FillColor = Color.FromArgb(230, 244, 240); // Soft beautiful warm green-teal tint highlight background
            
            // Highlight Search Textbox
            txtSearch.BorderColor = tealTheme;
            txtSearch.BorderThickness = 1;
            txtSearch.FillColor = Color.White;
            txtSearch.HoverState.BorderColor = Color.FromArgb(10, 79, 61);
            txtSearch.FocusedState.BorderColor = Color.FromArgb(10, 79, 61);
            txtSearch.PlaceholderText = "Nhập mã BN hoặc họ tên";
            txtSearch.PlaceholderForeColor = Color.FromArgb(180, 195, 188);
            
            // Highlight Search Label
            lblSearchTitle.ForeColor = tealTheme;

            // Premium Light Grey Footer Style
            pnlFormFooter.FillColor = Color.FromArgb(244, 247, 246); // Beautiful light grey background matching segment tab
            pnlFormFooter.BorderThickness = 0; // Disable Guna rounded border to prevent curved top borders
            pnlFormFooter.BorderRadius = 12; // Rounds the bottom corners to align with pnlFormCard

            // Create a dynamic flat panel to cover the top rounded corners of the footer
            Guna2Panel pnlFooterFlatTop = new Guna2Panel();
            pnlFooterFlatTop.Name = "pnlFooterFlatTop";
            pnlFooterFlatTop.BorderRadius = 0;
            pnlFooterFlatTop.BorderThickness = 0;
            pnlFooterFlatTop.FillColor = Color.FromArgb(244, 247, 246); // Same grey background
            pnlFooterFlatTop.BackColor = Color.Transparent;
            pnlFooterFlatTop.Location = new Point(0, 1100);
            pnlFooterFlatTop.Size = new Size(pnlFormFooter.Width, 12);
            
            // Create a dynamic straight horizontal divider line
            Panel pnlFooterDivider = new Panel();
            pnlFooterDivider.Name = "pnlFooterDivider";
            pnlFooterDivider.BackColor = borderGray;
            pnlFooterDivider.Location = new Point(0, 1100);
            pnlFooterDivider.Size = new Size(pnlFormFooter.Width, 1);
            
            // Add them to pnlFormCard
            pnlFormCard.Controls.Add(pnlFooterFlatTop);
            pnlFormCard.Controls.Add(pnlFooterDivider);
            
            // Bring them to front so they draw on top of pnlFormFooter
            pnlFooterFlatTop.BringToFront();
            pnlFooterDivider.BringToFront();

            // Configure Tab Buttons (No Icons, Native Radio Checked States)

            btnTabAdd.CheckedState.FillColor = tealTheme;
            btnTabAdd.CheckedState.ForeColor = Color.White;
            btnTabAdd.CheckedState.BorderColor = tealTheme;

            btnTabEdit.CheckedState.FillColor = tealTheme;
            btnTabEdit.CheckedState.ForeColor = Color.White;
            btnTabEdit.CheckedState.BorderColor = tealTheme;

            // Configure labels
            ConfigureLabelStyle(lblHoDem, "HỌ VÀ ĐỆM *");
            ConfigureLabelStyle(lblTen, "TÊN *");
            ConfigureLabelStyle(lblMaBN, "MÃ BỆNH NHÂN");
            ConfigureLabelStyle(lblNgaySinh, "NGÀY SINH *");
            ConfigureLabelStyle(lblGioiTinh, "GIỚI TÍNH *");
            ConfigureLabelStyle(lblNhomMau, "NHÓM MÁU");
            ConfigureLabelStyle(lblCccd, "CCCD / HỘ CHIẾU *");
            ConfigureLabelStyle(lblBhyt, "SỐ BẢO HIỂM Y TẾ");
            ConfigureLabelStyle(lblSdt, "SỐ ĐIỆN THOẠI *");
            ConfigureLabelStyle(lblEmail, "EMAIL");
            ConfigureLabelStyle(lblNguoiLienHe, "NGƯỜI LIÊN LẠC KHẨN CẤP");
            ConfigureLabelStyle(lblDiaChi, "ĐỊA CHỈ THƯỜNG TRÚ *");
            ConfigureLabelStyle(lblKhoa, "KHOA TIẾP NHẬN *");
            ConfigureLabelStyle(lblHinhThuc, "HÌNH THỨC VÀO VIỆN");
            ConfigureLabelStyle(lblNgayNhap, "NGÀY NHẬP VIỆN");
            ConfigureLabelStyle(lblLyDo, "LÝ DO NHẬP VIỆN / TRIỆU CHỨNG BAN ĐẦU");
            ConfigureLabelStyle(lblTienSu, "TIỀN SỬ BỆNH / DỊ ỨNG THUỐC");

            // Configure TextBoxes
            ConfigureTextBoxStyle(txtHoDem, false);
            ConfigureTextBoxStyle(txtTen, false);
            ConfigureTextBoxStyle(txtMaBN, true);
            ConfigureTextBoxStyle(txtCccd, false);
            ConfigureTextBoxStyle(txtBhyt, false);
            ConfigureTextBoxStyle(txtSdt, false);
            ConfigureTextBoxStyle(txtEmail, false);
            ConfigureTextBoxStyle(txtNguoiLienHe, false);
            ConfigureTextBoxStyle(txtDiaChi, false);
            ConfigureTextBoxStyle(txtLyDo, false);
            ConfigureTextBoxStyle(txtTienSu, false);

            // Configure ComboBoxes
            ConfigureComboBoxStyle(cboGioiTinh);
            ConfigureComboBoxStyle(cboNhomMau);
            ConfigureComboBoxStyle(cboKhoa);
            ConfigureComboBoxStyle(cboHinhThuc);

            // Setup Placeholders
            txtHoDem.PlaceholderText = "Ví dụ: Nguyễn Văn";
            txtTen.PlaceholderText = "Ví dụ: An";
        }

        private void ConfigureLabelStyle(System.Windows.Forms.Label label, string text)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(122, 149, 137);
            label.BackColor = System.Drawing.Color.Transparent;

            if (text.EndsWith("*"))
            {
                label.Text = text.Substring(0, text.Length - 1).Trim().ToUpper();
                var starLabel = new System.Windows.Forms.Label();
                starLabel.AutoSize = true;
                starLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
                starLabel.ForeColor = System.Drawing.Color.FromArgb(168, 42, 20); // Red
                starLabel.Text = "*";
                starLabel.BackColor = System.Drawing.Color.Transparent;

                this.Load += (s, e) => {
                    starLabel.Location = new System.Drawing.Point(label.Right - 2, label.Top);
                };
                this.pnlFormCard.Controls.Add(starLabel);
            }
            else
            {
                label.Text = text.ToUpper();
            }
        }

        private void ConfigureTextBoxStyle(Guna.UI2.WinForms.Guna2TextBox textBox, bool readOnly)
        {
            textBox.BorderRadius = 8;
            textBox.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            textBox.BorderThickness = 1;
            textBox.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            textBox.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            textBox.FillColor = readOnly ? System.Drawing.Color.FromArgb(236, 242, 240) : System.Drawing.Color.FromArgb(247, 249, 248);
            textBox.ReadOnly = readOnly;
            textBox.BackColor = System.Drawing.Color.Transparent;
            textBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            textBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            textBox.AutoSize = false;
            textBox.TextOffset = new System.Drawing.Point(8, 0);
            textBox.PlaceholderForeColor = System.Drawing.Color.FromArgb(180, 195, 188); // faint gray-green

            if (readOnly)
            {
                textBox.Enabled = false;
                textBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(236, 242, 240);
                textBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(122, 149, 137); // beautiful muted gray-green text
                textBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            }
        }

        private void ConfigureComboBoxStyle(Guna.UI2.WinForms.Guna2ComboBox cbo)
        {
            cbo.BorderRadius = 8;
            cbo.BorderColor = System.Drawing.Color.FromArgb(218, 232, 226);
            cbo.BorderThickness = 1;
            cbo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            cbo.ForeColor = System.Drawing.Color.FromArgb(24, 48, 42);
            cbo.FillColor = System.Drawing.Color.FromArgb(247, 249, 248);
            cbo.BackColor = System.Drawing.Color.Transparent;
            cbo.HoverState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            cbo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(15, 110, 86);
            cbo.ItemHeight = 32;
            cbo.TextOffset = new System.Drawing.Point(8, 0);
        }
    }
}

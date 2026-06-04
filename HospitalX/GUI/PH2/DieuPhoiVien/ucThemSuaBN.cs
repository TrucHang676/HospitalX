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
        private string _preloadedPatientId = null;

        // Original fields to track patient information changes
        private string _origHoDem = "";
        private string _origTen = "";
        private DateTime _origNgaySinh = new DateTime(1990, 1, 1);
        private int _origGioiTinhIndex = 0;
        private string _origCccd = "";
        private string _origSoNha = "";
        private string _origTenDuong = "";
        private string _origQuanHuyen = "";
        private string _origTinhTP = "";
        private string _origTienSuBN = "";
        private string _origTienSuGD = "";
        private string _origDiUng = "";

        public void PreloadPatient(string patientId)
        {
            _preloadedPatientId = patientId;
        }

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
            // Prevent cursor caret from showing on read-only MaBN while keeping focus/glow
            txtMaBN.Enter += (s, ev) => HideCaret(txtMaBN.Handle);
            txtMaBN.GotFocus += (s, ev) => HideCaret(txtMaBN.Handle);

            // Wire change events for checking edit changes
            WireChangeEvents();

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

            if (!string.IsNullOrEmpty(_preloadedPatientId))
            {
                SetMode(true); // Switch directly to Edit Mode!
                txtSearch.Text = _preloadedPatientId;
                ExecuteSearch(true); // Load silently without showing redundant confirmation dialog
            }
        }

        private void InitComboBoxes()
        {
            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("-- Chọn --");
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = 0;

            dtpNgaySinh.Value = new DateTime(1990, 1, 1);
        }

        private void WireChangeEvents()
        {
            txtHoDem.TextChanged += (s, e) => CheckForChanges();
            txtTen.TextChanged += (s, e) => CheckForChanges();
            dtpNgaySinh.ValueChanged += (s, e) => CheckForChanges();
            cboGioiTinh.SelectedIndexChanged += (s, e) => CheckForChanges();
            txtCccd.TextChanged += (s, e) => CheckForChanges();
            txtSoNha.TextChanged += (s, e) => CheckForChanges();
            txtTenDuong.TextChanged += (s, e) => CheckForChanges();
            txtQuanHuyen.TextChanged += (s, e) => CheckForChanges();
            txtTinhTP.TextChanged += (s, e) => CheckForChanges();
            txtTienSuBN.TextChanged += (s, e) => CheckForChanges();
            txtTienSuGD.TextChanged += (s, e) => CheckForChanges();
            txtDiUng.TextChanged += (s, e) => CheckForChanges();
        }

        private void CheckForChanges()
        {
            if (!_isEditMode)
            {
                bool hasFilledAny =
                    !string.IsNullOrWhiteSpace(txtHoDem.Text) ||
                    !string.IsNullOrWhiteSpace(txtTen.Text) ||
                    cboGioiTinh.SelectedIndex != 0 ||
                    !string.IsNullOrWhiteSpace(txtCccd.Text) ||
                    !string.IsNullOrWhiteSpace(txtSoNha.Text) ||
                    !string.IsNullOrWhiteSpace(txtTenDuong.Text) ||
                    !string.IsNullOrWhiteSpace(txtQuanHuyen.Text) ||
                    !string.IsNullOrWhiteSpace(txtTinhTP.Text) ||
                    !string.IsNullOrWhiteSpace(txtTienSuBN.Text) ||
                    !string.IsNullOrWhiteSpace(txtTienSuGD.Text) ||
                    !string.IsNullOrWhiteSpace(txtDiUng.Text);

                btnSave.Enabled = hasFilledAny;
                return;
            }

            bool hasChanged = 
                txtHoDem.Text != _origHoDem ||
                txtTen.Text != _origTen ||
                dtpNgaySinh.Value != _origNgaySinh ||
                cboGioiTinh.SelectedIndex != _origGioiTinhIndex ||
                txtCccd.Text != _origCccd ||
                txtSoNha.Text != _origSoNha ||
                txtTenDuong.Text != _origTenDuong ||
                txtQuanHuyen.Text != _origQuanHuyen ||
                txtTinhTP.Text != _origTinhTP ||
                txtTienSuBN.Text != _origTienSuBN ||
                txtTienSuGD.Text != _origTienSuGD ||
                txtDiUng.Text != _origDiUng;

            btnSave.Enabled = hasChanged;
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

            // Section Icons
            ptbBasicIcon.Image = DpvAssets.Load("dpv_7.png");
            ptbMedicalIcon.Image = DpvAssets.Load("medical-report.png");

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

            // Save button (No Icon, Perfectly Centered)
            btnSave.Image = null;
            btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnSave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnSave.ImageOffset = new Point(0, 0);
            btnSave.TextOffset = new Point(0, 0);
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

                // Clear all fields initially in edit mode to wait for search query
                ClearAllFields();
                btnSave.Text = "Lưu thay đổi";
                btnSave.ImageOffset = new Point(0, 0);
                btnSave.TextOffset = new Point(0, 0);
                UpdateMainFormHeader("Sửa thông tin bệnh nhân");
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
                ClearAllFields();
                btnSave.Text = "Thêm bệnh nhân";
                btnSave.ImageOffset = new Point(0, 0);
                btnSave.TextOffset = new Point(0, 0);
                UpdateMainFormHeader("Thêm bệnh nhân mới");
            }

            // Trigger dynamic co-sizing and positioning updates
            AdjustLayoutSizes();
            CheckForChanges();
        }

        private void UpdateMainFormHeader(string title)
        {
            var form = this.FindForm();
            if (form == null) return;

            var main = form as Main_DPV;
            if (main != null)
            {
                var controls = main.Controls.Find("lblPageTitle", true);
                if (controls.Length > 0 && controls[0] is Label lbl)
                {
                    lbl.Text = title;
                }
            }
        }

        private void ClearAllFields()
        {
            txtHoDem.Text = "";
            txtTen.Text = "";
            txtMaBN.Text = "Tự động tạo";
            dtpNgaySinh.Value = new DateTime(1990, 1, 1);
            cboGioiTinh.SelectedIndex = 0;
            txtCccd.Text = "";
            txtSoNha.Text = "";
            txtTenDuong.Text = "";
            txtQuanHuyen.Text = "";
            txtTinhTP.Text = "";
            txtTienSuBN.Text = "";
            txtTienSuGD.Text = "";
            txtDiUng.Text = "";

            // Reset original values
            _origHoDem = "";
            _origTen = "";
            _origNgaySinh = new DateTime(1990, 1, 1);
            _origGioiTinhIndex = 0;
            _origCccd = "";
            _origSoNha = "";
            _origTenDuong = "";
            _origQuanHuyen = "";
            _origTinhTP = "";
            _origTienSuBN = "";
            _origTienSuGD = "";
            _origDiUng = "";

            SetFieldsAccessibility(_isEditMode);
            CheckForChanges();
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
                errorMsg += "\n- CCCD";
            }
            else
            {
                ResetFieldStyle(txtCccd);
            }

            // Validate txtTienSuBN
            if (string.IsNullOrWhiteSpace(txtTienSuBN.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtTienSuBN);
                errorMsg += "\n- Tiền sử bệnh";
            }
            else
            {
                ResetFieldStyle(txtTienSuBN);
            }

            // Validate txtTienSuGD
            if (string.IsNullOrWhiteSpace(txtTienSuGD.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtTienSuGD);
                errorMsg += "\n- Tiền sử gia đình";
            }
            else
            {
                ResetFieldStyle(txtTienSuGD);
            }

            // Validate txtDiUng
            if (string.IsNullOrWhiteSpace(txtDiUng.Text))
            {
                isValid = false;
                MarkFieldInvalid(txtDiUng);
                errorMsg += "\n- Dị ứng thuốc";
            }
            else
            {
                ResetFieldStyle(txtDiUng);
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
            string fullName = txtHoDem.Text.Trim() + " " + txtTen.Text.Trim();
            string msg = _isEditMode
                ? $"Đã lưu thông tin thay đổi cho bệnh nhân {fullName} thành công."
                : $"Đã thêm mới bệnh nhân {fullName} vào hệ thống thành công.";

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
                pnlFormCard.Size = new Size(targetWidth, 880);
            }
            else
            {
                pnlFormCard.Location = new Point(27, 80);
                pnlFormCard.Size = new Size(targetWidth, 880);
            }

            // Dynamically stretch footer and align buttons to the right
            pnlFormFooter.Width = targetWidth;
            int btnWidth = _isEditMode ? 180 : 200;
            btnSave.Width = btnWidth;
            btnSave.Left = targetWidth - btnWidth - 40; // right margin 40
            btnCancel.Left = btnSave.Left - 140 - 16; // width 140, gap 16

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

        private void ExecuteSearch(bool silent = false)
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
             * string sql = "SELECT * FROM BenhNhan WHERE MaBN = @Query OR TenBN LIKE @Query";
             * using (SqlCommand cmd = new SqlCommand(sql, connection)) {
             *     cmd.Parameters.AddWithValue("@Query", "%" + query + "%");
             *     // Đọc dữ liệu đầu ra và gán vào các trường tương ứng:
             *     // txtHoDem.Text = reader["HoDem"].ToString();
             *     // txtTen.Text = reader["Ten"].ToString();
             *     // ...
             * }
             * =========================================================================
             */

            // Make sure SharedPatients is initialized
            PatientModel.InitializeSharedPatients();

            PatientModel foundPatient = null;
            foreach (var p in PatientModel.SharedPatients)
            {
                if (p == null) continue;
                string pNameLower = p.Name != null ? p.Name.ToLower() : "";
                string pIdLower = p.Id != null ? p.Id.ToLower() : "";
                string pCccd = p.Cccd != null ? p.Cccd : "";

                if (queryLower == pNameLower || queryLower == pIdLower || queryLower == pCccd)
                {
                    foundPatient = p;
                    break;
                }
            }

            if (foundPatient != null)
            {
                // Split full name into HoDem and Ten
                string fullName = foundPatient.Name.Trim();
                int lastSpaceIndex = fullName.LastIndexOf(' ');
                if (lastSpaceIndex > 0)
                {
                    txtHoDem.Text = fullName.Substring(0, lastSpaceIndex).Trim();
                    txtTen.Text = fullName.Substring(lastSpaceIndex + 1).Trim();
                }
                else
                {
                    txtHoDem.Text = "";
                    txtTen.Text = fullName;
                }

                txtMaBN.Text = foundPatient.Id;

                // Parse Date of Birth
                if (DateTime.TryParseExact(foundPatient.Dob, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dobDate))
                {
                    dtpNgaySinh.Value = dobDate;
                }
                else
                {
                    dtpNgaySinh.Value = new DateTime(1990, 1, 1);
                }

                // Map Gender (1: Nam, 2: Nữ)
                if (foundPatient.Gender == "Nam")
                {
                    cboGioiTinh.SelectedIndex = 1;
                }
                else if (foundPatient.Gender == "Nữ")
                {
                    cboGioiTinh.SelectedIndex = 2;
                }
                else
                {
                    cboGioiTinh.SelectedIndex = 0;
                }

                txtCccd.Text = foundPatient.Cccd;

                // Specific mock details for Trần Thị Cường to maintain consistency
                if (foundPatient.Id == "BN240046")
                {
                    txtSoNha.Text = "123";
                    txtTenDuong.Text = "Đường Ba Tháng Hai";
                    txtQuanHuyen.Text = "Quận 10";
                    txtTinhTP.Text = "TP. Hồ Chí Minh";
                    txtTienSuBN.Text = "Viêm khớp dạng thấp, đã phẫu thuật ruột thừa năm 2015.";
                    txtTienSuGD.Text = "Bố mắc tiểu đường type 2, mẹ có tiền sử cao huyết áp.";
                    txtDiUng.Text = "Dị ứng Penicillin (phát ban da), Aspirin (khó thở).";
                }
                // Specific mock details for Phạm Thị Lan (updated with correct ID BN240002)
                else if (foundPatient.Id == "BN240002")
                {
                    txtSoNha.Text = "456";
                    txtTenDuong.Text = "Đường Nguyễn Huệ";
                    txtQuanHuyen.Text = "Quận 1";
                    txtTinhTP.Text = "TP. Hồ Chí Minh";
                    txtTienSuBN.Text = "Viêm dạ dày mãn tính, đang điều trị từ 2023.";
                    txtTienSuGD.Text = "Không có tiền sử bệnh đáng kể trong gia đình.";
                    txtDiUng.Text = "Không có dị ứng thuốc đã biết.";
                }
                // Intelligent dynamically generated mock data for all other 46 patients on the list
                else
                {
                    int uniqueHash = foundPatient.Id.GetHashCode();
                    txtSoNha.Text = (100 + Math.Abs(uniqueHash % 900)).ToString();
                    txtTenDuong.Text = foundPatient.Gender == "Nữ" ? "Đường Hai Bà Trưng" : "Đường Lê Lợi";
                    txtQuanHuyen.Text = "Quận 1";
                    txtTinhTP.Text = "TP. Hồ Chí Minh";

                    txtTienSuBN.Text = "Theo dõi sức khỏe định kỳ tại chuyên khoa " + foundPatient.Khoa + ".";
                    txtTienSuGD.Text = "Gia đình không có tiền sử bệnh di truyền hoặc cao huyết áp.";
                    txtDiUng.Text = "Không ghi nhận dị ứng đối với các loại thuốc thông thường.";
                }

                found = true;
                foundName = foundPatient.Name;

                // Save original loaded values to track future modifications
                _origHoDem = txtHoDem.Text;
                _origTen = txtTen.Text;
                _origNgaySinh = dtpNgaySinh.Value;
                _origGioiTinhIndex = cboGioiTinh.SelectedIndex;
                _origCccd = txtCccd.Text;
                _origSoNha = txtSoNha.Text;
                _origTenDuong = txtTenDuong.Text;
                _origQuanHuyen = txtQuanHuyen.Text;
                _origTinhTP = txtTinhTP.Text;
                _origTienSuBN = txtTienSuBN.Text;
                _origTienSuGD = txtTienSuGD.Text;
                _origDiUng = txtDiUng.Text;
            }

            if (found)
            {
                btnSave.Text = "Lưu thay đổi";
                btnSave.Enabled = false;
                SetFieldsAccessibility(false); // Enable fields when patient found

                if (!silent)
                {
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
            }
            else
            {
                SetFieldsAccessibility(true); // Keep fields disabled when search fails
                if (this.guna2MessageDialog1 == null)
                {
                    this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
                }
                guna2MessageDialog1.Parent = this.FindForm();
                guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning;
                guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                guna2MessageDialog1.Caption = "Không tìm thấy";
                guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
                guna2MessageDialog1.Show($"Không tìm thấy bệnh nhân \"{query}\". Vui lòng nhập đúng và đầy đủ Họ tên, Mã BN hoặc CCCD (Ví dụ: 'Trần Thị Cường', 'BN240046' hoặc '079196657049') để tìm kiếm!");
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
            txtSearch.PlaceholderText = "Nhập mã BN, họ tên hoặc CCCD";
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
            pnlFooterFlatTop.Location = new Point(0, 800);
            pnlFooterFlatTop.Size = new Size(pnlFormFooter.Width, 12);

            // Create a dynamic straight horizontal divider line
            Panel pnlFooterDivider = new Panel();
            pnlFooterDivider.Name = "pnlFooterDivider";
            pnlFooterDivider.BackColor = borderGray;
            pnlFooterDivider.Location = new Point(0, 800);
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

            // Configure labels - Section 1: Basic Info
            ConfigureLabelStyle(lblHoDem, "HỌ VÀ ĐỆM *");
            ConfigureLabelStyle(lblTen, "TÊN *");
            ConfigureLabelStyle(lblMaBN, "MÃ BỆNH NHÂN");
            ConfigureLabelStyle(lblNgaySinh, "NGÀY SINH *");
            ConfigureLabelStyle(lblGioiTinh, "GIỚI TÍNH *");
            ConfigureLabelStyle(lblCccd, "CCCD *");
            ConfigureLabelStyle(lblSoNha, "SỐ NHÀ");
            ConfigureLabelStyle(lblTenDuong, "TÊN ĐƯỜNG");
            ConfigureLabelStyle(lblQuanHuyen, "QUẬN / HUYỆN");
            ConfigureLabelStyle(lblTinhTP, "TỈNH / THÀNH PHỐ");

            // Configure labels - Section 2: Medical History
            ConfigureLabelStyle(lblTienSuBN, "TIỀN SỬ BỆNH *");
            ConfigureLabelStyle(lblTienSuGD, "TIỀN SỬ BỆNH GIA ĐÌNH *");
            ConfigureLabelStyle(lblDiUng, "DỊ ỨNG THUỐC *");

            // Configure TextBoxes
            ConfigureTextBoxStyle(txtHoDem, false);
            ConfigureTextBoxStyle(txtTen, false);
            ConfigureTextBoxStyle(txtMaBN, true);
            ConfigureTextBoxStyle(txtCccd, false);
            ConfigureTextBoxStyle(txtSoNha, false);
            ConfigureTextBoxStyle(txtTenDuong, false);
            ConfigureTextBoxStyle(txtQuanHuyen, false);
            ConfigureTextBoxStyle(txtTinhTP, false);
            ConfigureTextBoxStyle(txtTienSuBN, false);
            ConfigureTextBoxStyle(txtTienSuGD, false);
            ConfigureTextBoxStyle(txtDiUng, false);

            // Configure ComboBoxes
            ConfigureComboBoxStyle(cboGioiTinh);

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

            textBox.Enabled = !readOnly;
            if (readOnly)
            {
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

        private void SetFieldsAccessibility(bool isReadOnly)
        {
            ConfigureTextBoxStyle(txtHoDem, isReadOnly);
            ConfigureTextBoxStyle(txtTen, isReadOnly);
            ConfigureTextBoxStyle(txtCccd, isReadOnly);
            ConfigureTextBoxStyle(txtSoNha, isReadOnly);
            ConfigureTextBoxStyle(txtTenDuong, isReadOnly);
            ConfigureTextBoxStyle(txtQuanHuyen, isReadOnly);
            ConfigureTextBoxStyle(txtTinhTP, isReadOnly);
            ConfigureTextBoxStyle(txtTienSuBN, isReadOnly);
            ConfigureTextBoxStyle(txtTienSuGD, isReadOnly);
            ConfigureTextBoxStyle(txtDiUng, isReadOnly);

            dtpNgaySinh.Enabled = !isReadOnly;
            cboGioiTinh.Enabled = !isReadOnly;
        }
    }
}

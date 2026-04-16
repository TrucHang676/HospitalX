using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using HospitalX.DAO;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace HospitalX.GUI.PH1
{
    public partial class frmEditUser : Form
    {
        public string Username { get; private set; }

        // Data to return
        public string FullName { get; private set; }
        public string Gender { get; private set; }
        public string BirthDate { get; private set; }
        public string Phone { get; private set; }
        public string Role { get; private set; }
        public string Address { get; private set; }

        // Track original values to detect changes
        private string _originalFullName = "";
        private string _originalGender = "";
        private string _originalBirthDate = "";
        private string _originalPhone = "";
        private string _originalAddress = "";
        private bool _isLoaded = false;

        public frmEditUser(string username)
        {
            InitializeComponent();

            // Fix centering
            this.msgDialog.Parent = this;

            this.Username = username;
            this.lblUsernameDisplay.Text = username;

            // Initialize gender combobox items
            if (this.cmbGender.Items.Count == 0)
            {
                this.cmbGender.Items.Add("Nam");
                this.cmbGender.Items.Add("Nữ");
                this.cmbGender.Items.Add("Khác");
            }

            // Load user data from database
            LoadUserDataFromDb();

            // Wire events
            this.btnCancel.Click += (s, e) => this.Close();
            this.btnSave.Click += BtnSave_Click;

            // Track changes on all input fields
            this.txtFullName.TextChanged += OnDataChanged;
            this.cmbGender.SelectedIndexChanged += OnDataChanged;
            this.txtBirthDate.TextChanged += OnDataChanged;
            this.txtPhone.TextChanged += OnDataChanged;
            this.txtAddress.TextChanged += OnDataChanged;

            // Disable save button initially
            this.btnSave.Enabled = false;
            _isLoaded = true;
        }

        private void LoadUserDataFromDb()
        {
            try
            {
                // Debug: Kiểm tra username có giá trị không
                System.Diagnostics.Debug.WriteLine($"LoadUserDataFromDb - Username: '{this.Username}'");

                var parameters = new OracleParameter[] {
                    new OracleParameter("p_username", OracleDbType.Varchar2) 
                    { 
                        Value = this.Username ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) 
                    { 
                        Direction = ParameterDirection.Output 
                    }
                };

                var dtUser = DataProvider.Instance.ExecuteQuery("USP_GET_USER_INFO", parameters);

                System.Diagnostics.Debug.WriteLine($"USP_GET_USER_INFO returned {dtUser?.Rows.Count ?? 0} rows");

                if (dtUser != null && dtUser.Rows.Count > 0)
                {
                    DataRow row = dtUser.Rows[0];

                    this.txtFullName.Text = row["HOTEN"] != DBNull.Value ? row["HOTEN"].ToString() : "";

                    // Set gender with proper SelectedIndex (not SelectedItem)
                    // Use -1 for empty selection instead of 0
                    string gioiTinh = row["GIOITINH"] != DBNull.Value ? row["GIOITINH"].ToString() : "";
                    int genderIndex = string.IsNullOrEmpty(gioiTinh) ? -1 : this.cmbGender.Items.IndexOf(gioiTinh);
                    this.cmbGender.SelectedIndex = genderIndex >= 0 ? genderIndex : -1;

                    this.txtPhone.Text = row["SDT"] != DBNull.Value ? row["SDT"].ToString() : "";
                    this.txtBirthDate.Text = row["NGAYSINH"] != DBNull.Value ? row["NGAYSINH"].ToString() : "";
                    this.txtAddress.Text = row["DIACHI"] != DBNull.Value ? row["DIACHI"].ToString() : "";
                    this.Role = row["VAITRO"] != DBNull.Value ? row["VAITRO"].ToString() : "";

                    System.Diagnostics.Debug.WriteLine("Dữ liệu user đã được load thành công");
                }
                else
                {
                    // User not found in THONGTIN_NHANVIEN, use defaults (all empty)
                    System.Diagnostics.Debug.WriteLine("User không tìm thấy trong THONGTIN_NHANVIEN, dùng giá trị mặc định");
                    this.cmbGender.SelectedIndex = -1; // Empty selection
                }

                // Save original values to detect changes
                _originalFullName = this.txtFullName.Text;
                _originalGender = this.cmbGender.SelectedIndex >= 0 ? this.cmbGender.SelectedItem.ToString() : "";
                _originalBirthDate = this.txtBirthDate.Text;
                _originalPhone = this.txtPhone.Text;
                _originalAddress = this.txtAddress.Text;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Lỗi tải thông tin user: {ex.Message}\n{ex.StackTrace}");
                this.cmbGender.SelectedIndex = -1; // Empty on error
            }
        }

        // Khi click vào ô -> chữ chuyển sang màu đậm (đang chỉnh sửa)
        private void Txt_Enter(object sender, EventArgs e)
        {
            if (sender is Guna2TextBox txt)
            {
                txt.ForeColor = Color.FromArgb(10, 42, 64);
            }
        }

        // Khi rời khỏi ô -> chữ chuyển lại màu mờ
        private void Txt_Leave(object sender, EventArgs e)
        {
            if (sender is Guna2TextBox txt)
            {
                txt.ForeColor = Color.Gray;
            }
        }

        // ================================================
        // DETECT CHANGES — Khi dữ liệu thay đổi, enable/disable btnSave
        // ================================================
        private void OnDataChanged(object sender, EventArgs e)
        {
            if (!_isLoaded) return; // Ignore changes during initial load

            // Check if any field has changed
            bool hasChanges = 
                this.txtFullName.Text != _originalFullName ||
                (this.cmbGender.SelectedIndex >= 0 ? this.cmbGender.SelectedItem.ToString() : "") != _originalGender ||
                this.txtBirthDate.Text != _originalBirthDate ||
                this.txtPhone.Text != _originalPhone ||
                this.txtAddress.Text != _originalAddress;

            // Enable/disable save button based on changes
            this.btnSave.Enabled = hasChanges;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Họ và tên
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Show("Vui lòng nhập họ và tên!", "Thiếu thông tin");
                txtFullName.Focus();
                return;
            }

            // 2. Kiểm tra định dạng ngày sinh (Gõ tay)
            string birthStr = txtBirthDate.Text.Trim();
            if (!string.IsNullOrEmpty(birthStr))
            {
                // Kiểm tra định dạng DD/MM/YYYY bằng cách thử Parse
                try {
                    DateTime dt = DateTime.ParseExact(birthStr, "dd/MM/yyyy", null);
                } catch {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Ngày sinh không đúng định dạng DD/MM/YYYY!", "Lỗi định dạng");
                    txtBirthDate.Focus();
                    return;
                }
            }

            // 3. Kiểm tra số điện thoại (10 chữ số)
            string phoneStr = txtPhone.Text.Trim();
            if (phoneStr.Length > 0 && phoneStr.Length < 10)
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Show("Số điện thoại không hợp lệ!", "Lỗi định dạng");
                txtPhone.Focus();
                return;
            }

            // Lưu dữ liệu ra các thuộc tính
            this.FullName = txtFullName.Text.Trim();
            this.Gender = cmbGender.SelectedItem.ToString();
            this.BirthDate = birthStr;
            this.Phone = phoneStr;
            this.Address = txtAddress.Text.Trim();

            try
            {
                // Cập nhật thông tin user vào bảng THONGTIN_NHANVIEN (bảng tạo tạm thời cho demo PH1) trong Oracle
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_username", OracleDbType.Varchar2) 
                    { 
                        Value = this.Username ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_hoten", OracleDbType.NVarchar2) 
                    { 
                        Value = this.FullName ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_gioitinh", OracleDbType.NVarchar2) 
                    { 
                        Value = this.Gender ?? "Nam", 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_ngaysinh", OracleDbType.Varchar2) 
                    { 
                        Value = this.BirthDate ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_sdt", OracleDbType.Varchar2) 
                    { 
                        Value = this.Phone ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_diachi", OracleDbType.NVarchar2) 
                    { 
                        Value = this.Address ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    },
                    new OracleParameter("p_vaitro", OracleDbType.NVarchar2) 
                    { 
                        Value = this.Role ?? string.Empty, 
                        Direction = ParameterDirection.Input 
                    }
                };

                DataProvider.Instance.ExecuteNonQuery("sp_UpdateUserInfo", parameters);

                msgDialog.Icon = MessageDialogIcon.Information;
                msgDialog.Show("Đã cập nhật thông tin thành công!", "Thành công");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Show("Lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi");
            }
        }
    }
}

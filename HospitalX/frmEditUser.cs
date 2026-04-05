using System;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HospitalX
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

        public frmEditUser(string username, string currentRole = "", string currentName = "", string currentGender = "Nam", string currentPhone = "", string currentBirth = "", string currentAddress = "")
        {
            InitializeComponent();
            
            // Fix centering
            this.msgDialog.Parent = this;
            
            this.Username = username;
            this.lblUsernameDisplay.Text = username;
            this.Role = currentRole;
            
            // Load current data
            this.txtFullName.Text = currentName;
            this.cmbRole.SelectedItem = currentRole; // Hiển thị Role trong ComboBox
            this.cmbGender.SelectedItem = string.IsNullOrEmpty(currentGender) ? "Nam" : currentGender;
            this.txtPhone.Text = currentPhone;
            this.txtBirthDate.Text = currentBirth;
            this.txtAddress.Text = currentAddress;

            // Wire events
            this.btnCancel.Click += (s, e) => this.Close();
            this.btnSave.Click += BtnSave_Click;
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
            this.Role = cmbRole.SelectedItem?.ToString() ?? "";
            this.BirthDate = birthStr;
            this.Phone = phoneStr;
            this.Address = txtAddress.Text.Trim();

            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Show("Đã cập nhật thông tin thành công!", "Thành công");

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class frmKtvEditProfile : Form
    {
        // Callback data — caller reads these after DialogResult.OK
        public string ResultName     { get; private set; }
        public string ResultPhone    { get; private set; }
        public string ResultEmail    { get; private set; }
        public DateTime ResultDob    { get; private set; }
        public string ResultAddress  { get; private set; }
        public string ResultGender   { get; private set; }
        public string ResultShift    { get; private set; }
        public string ResultSkills   { get; private set; }

        public frmKtvEditProfile(
            string name, string phone, string email,
            DateTime dob, string address, string gender,
            string shift, string skills)
        {
            InitializeComponent();
            if (System.IO.File.Exists(@"d:\HospitalX\image\medical-team.ico"))
            {
                this.Icon = new System.Drawing.Icon(@"d:\HospitalX\image\medical-team.ico");
            }
            LoadData(name, phone, email, dob, address, gender, shift, skills);
        }

        private void LoadData(string name, string phone, string email,
            DateTime dob, string address, string gender,
            string shift, string skills)
        {
            txtEditName.Text    = name;
            txtEditPhone.Text   = phone;
            txtEditEmail.Text   = email;
            dtpEditDob.Value    = dob;
            txtEditAddress.Text = address;

            // Gender combo
            int gIdx = cboEditGender.Items.IndexOf(gender);
            cboEditGender.SelectedIndex = gIdx >= 0 ? gIdx : 0;

            // Shift combo
            int sIdx = cboEditShift.Items.IndexOf(shift);
            cboEditShift.SelectedIndex = sIdx >= 0 ? sIdx : 0;

            txtEditSkills.Text = skills;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEditName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEditPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEditPhone.Focus();
                return;
            }

            ResultName    = txtEditName.Text.Trim();
            ResultPhone   = txtEditPhone.Text.Trim();
            ResultEmail   = txtEditEmail.Text.Trim();
            ResultDob     = dtpEditDob.Value;
            ResultAddress = txtEditAddress.Text.Trim();
            ResultGender  = cboEditGender.SelectedItem?.ToString() ?? "Nữ";
            ResultShift   = cboEditShift.SelectedItem?.ToString() ?? "";
            ResultSkills  = txtEditSkills.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using HospitalX.DAO;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace HospitalX.GUI.PH1
{
    public partial class frmCreateUser : Form
    {
        public frmCreateUser()
        {
            InitializeComponent();
            // Common Label Style
            var labels = new[] { lblUserLabel, lblFullNameLabel, lblPassLabel, lblConfirmPassLabel, lblTablespaceLabel };
            foreach (var l in labels)
            {
                l.Font = new Font("Segoe UI Semibold", 9F);
                l.ForeColor = Color.FromArgb(100, 110, 120);
                l.Margin = new Padding(0, 5, 0, 0);
                l.AutoSize = true;
            }

            // Fix centering
            this.msgDialog.Parent = this;
            this.msgDialog.Caption = "Thông báo";

            // Load tablespaces from database
            try
            {
                LoadTablespacesFromDb();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi tải tablespaces: " + ex.Message);
                cmbTablespace.Items.AddRange(new string[] { "USERS" });
            }

            // Simple close behavior
            btnCancel.Click += (s, e) => this.Close();

            btnCreate.Click += (s, e) =>
            {
                // 1. Kiểm tra Username
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Username!", "Thiếu thông tin");
                    txtUsername.Focus();
                    return;
                }

                // 2. Kiểm tra Họ tên
                if (string.IsNullOrWhiteSpace(txtFullName.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Họ tên nhân viên!", "Thiếu thông tin");
                    txtFullName.Focus();
                    return;
                }

                // 3. Kiểm tra Mật khẩu
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Mật khẩu!", "Thiếu thông tin");
                    txtPassword.Focus();
                    return;
                }

                // 4. Kiểm tra Xác nhận mật khẩu
                if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Show("Vui lòng nhập Xác nhận mật khẩu!", "Thiếu thông tin");
                    txtConfirmPassword.Focus();
                    return;
                }

                // 5. Kiểm tra khớp mật khẩu
                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Show("Mật khẩu xác nhận không khớp!", "Lỗi bảo mật");
                    return;
                }

                try
                {
                    // Tạo user mới với đầy đủ thông tin: username, password, hoten, tablespace
                    var parameters = new OracleParameter[] {
                        new OracleParameter("p_username", OracleDbType.Varchar2, txtUsername.Text.Trim(), ParameterDirection.Input),
                        new OracleParameter("p_password", OracleDbType.Varchar2, txtPassword.Text.Trim(), ParameterDirection.Input),
                        new OracleParameter("p_hoten", OracleDbType.NVarchar2, txtFullName.Text.Trim(), ParameterDirection.Input),
                        new OracleParameter("p_tablespace", OracleDbType.Varchar2, cmbTablespace.SelectedItem?.ToString() ?? "USERS", ParameterDirection.Input)
                    };

                    DataProvider.Instance.ExecuteNonQuery("sp_CreateUser", parameters);

                    msgDialog.Icon = MessageDialogIcon.Information;
                    msgDialog.Show($"Đã tạo thành công người dùng: {txtUsername.Text}\nHọ tên: {txtFullName.Text}\nTablespace: {cmbTablespace.SelectedItem}", "Thành công");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Show("Lỗi khi tạo user: " + ex.Message, "Lỗi");
                }
                catch (Exception ex)
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi");
                }
            };
        }

        private void LoadTablespacesFromDb()
        {
            try
            {
                var parameters = new OracleParameter[] {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                var dtTablespaces = DataProvider.Instance.ExecuteQuery("USP_GET_TABLESPACES", parameters);

                if (dtTablespaces != null && dtTablespaces.Rows.Count > 0)
                {
                    cmbTablespace.Items.Clear();
                    foreach (DataRow row in dtTablespaces.Rows)
                    {
                        cmbTablespace.Items.Add(row["TABLESPACE_NAME"].ToString());
                    }
                    if (cmbTablespace.Items.Count > 0)
                        cmbTablespace.SelectedIndex = 0;
                }
                else
                {
                    cmbTablespace.Items.Add("USERS");
                    cmbTablespace.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Lỗi tải tablespaces: " + ex.Message);
                cmbTablespace.Items.Add("USERS");
                cmbTablespace.SelectedIndex = 0;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message msg = Message.Create(this.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref msg);
            }
        }
    }
}

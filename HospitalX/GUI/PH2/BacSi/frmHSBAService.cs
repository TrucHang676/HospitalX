using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmHSBAService : Form
    {
        private readonly ucHSBA.HsbaRecord _record;

        public frmHSBAService(ucHSBA.HsbaRecord record)
        {
            _record = record;
            InitializeComponent();
            LoadRecord();
            WireInputState();
        }

        private void LoadRecord()
        {
            msgDialog.Parent = this;
            lblTitle.Text = "Thêm dịch vụ";
            lblHsbaId.Text = _record.Id;
            lblPatient.Text = _record.PatientName + " · " + _record.PatientCode;
            RefreshServices();
            ResetInputFields();

            lblNoteTitle.Visible = false;
            txtServiceNote.Visible = false;
        }

        private void RefreshServices()
        {
            lstCurrentServices.Items.Clear();
            _record.Services.Clear();

            try
            {
                System.Data.DataTable dt = HospitalX.DAO.HsbaDAO.GetServicesForHsba(_record.Id);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        string loai = row["LOAIDV"].ToString().Trim();
                        DateTime ngay = Convert.ToDateTime(row["NGAYDV"]);
                        string ktv = row["MAKTV"] != DBNull.Value ? row["MAKTV"].ToString().Trim() : "";
                        string kq = row["KETQUA"] != DBNull.Value ? row["KETQUA"].ToString().Trim() : "";

                        var item = new ServiceItem
                        {
                            LoaiDV = loai,
                            NgayDV = ngay,
                            MaKTV = ktv,
                            KetQua = kq
                        };
                        lstCurrentServices.Items.Add(item);

                        _record.Services.Add(loai + (!string.IsNullOrEmpty(kq) ? " - " + kq : ""));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách dịch vụ: " + ex.Message);
            }

            UpdateDeleteButtonState();
        }

        private void WireInputState()
        {
            txtServiceName.TextChanged += ServiceInputChanged;
            lstCurrentServices.SelectedIndexChanged += lstCurrentServices_SelectedIndexChanged;
        }

        private void lstCurrentServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDeleteButtonState();
        }

        private void UpdateDeleteButtonState()
        {
            if (lstCurrentServices.SelectedItem is ServiceItem selectedItem)
            {
                bool canDelete = string.IsNullOrEmpty(selectedItem.MaKTV);
                btnDelete.Enabled = canDelete;
                btnDelete.Cursor = canDelete ? Cursors.Hand : Cursors.Default;
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.Cursor = Cursors.Default;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCurrentServices.SelectedItem is ServiceItem selectedItem)
            {
                if (!string.IsNullOrEmpty(selectedItem.MaKTV))
                {
                    msgDialog.Icon = MessageDialogIcon.Warning;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Không thể xóa dịch vụ đã được phân công kỹ thuật viên.", "Không được phép");
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa dịch vụ '{selectedItem.LoaiDV}' được chỉ định lúc {selectedItem.NgayDV:dd/MM/yyyy HH:mm} không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        bool success = HospitalX.DAO.HsbaDAO.DeleteHsbaService(_record.Id, selectedItem.LoaiDV, selectedItem.NgayDV);
                        if (success)
                        {
                            msgDialog.Icon = MessageDialogIcon.Information;
                            msgDialog.Buttons = MessageDialogButtons.OK;
                            msgDialog.Show("Đã xóa dịch vụ thành công.", "Thành công");
                            RefreshServices();
                        }
                        else
                        {
                            msgDialog.Icon = MessageDialogIcon.Error;
                            msgDialog.Buttons = MessageDialogButtons.OK;
                            msgDialog.Show("Xóa dịch vụ thất bại. Vui lòng kiểm tra lại trạng thái hoặc quyền hạn.", "Lỗi");
                        }
                    }
                    catch (Exception ex)
                    {
                        msgDialog.Icon = MessageDialogIcon.Error;
                        msgDialog.Buttons = MessageDialogButtons.OK;
                        msgDialog.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi");
                    }
                }
            }
        }

        private void ServiceInputChanged(object sender, EventArgs e)
        {
            UpdateAddButtonState();
        }

        private void UpdateAddButtonState()
        {
            bool canAdd = HasCompleteServiceInput();
            btnAdd.Visible = true;
            btnAdd.Enabled = canAdd;
            btnAdd.Cursor = canAdd ? Cursors.Hand : Cursors.Default;
        }

        private bool HasCompleteServiceInput()
        {
            return !string.IsNullOrWhiteSpace(txtServiceName.Text);
        }

        private void ResetInputFields()
        {
            txtServiceName.Clear();
            txtServiceNote.Clear();
            UpdateAddButtonState();
            txtServiceName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string serviceName = txtServiceName.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                msgDialog.Icon = MessageDialogIcon.Warning;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Vui lòng nhập tên dịch vụ.", "Thiếu thông tin");
                return;
            }

            try
            {
                bool success = HospitalX.DAO.HsbaDAO.InsertHsbaService(_record.Id, serviceName, "Chưa có kết quả");
                if (success)
                {
                    ResetInputFields();
                    RefreshServices();
                    msgDialog.Icon = MessageDialogIcon.Information;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Đã thêm dịch vụ vào HSBA.", "Thành công");
                }
                else
                {
                    msgDialog.Icon = MessageDialogIcon.Error;
                    msgDialog.Buttons = MessageDialogButtons.OK;
                    msgDialog.Show("Thêm dịch vụ vào HSBA thất bại. Vui lòng kiểm tra lại quyền hạn.", "Lỗi");
                }
            }
            catch (Exception ex)
            {
                msgDialog.Icon = MessageDialogIcon.Error;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private class ServiceItem
        {
            public string LoaiDV { get; set; }
            public DateTime NgayDV { get; set; }
            public string MaKTV { get; set; }
            public string KetQua { get; set; }

            public override string ToString()
            {
                string status = string.IsNullOrEmpty(MaKTV) ? "Chưa có KTV" : $"KTV: {MaKTV}";
                return $"{LoaiDV} ({NgayDV:dd/MM/yyyy HH:mm}) - {status}";
            }
        }
    }
}

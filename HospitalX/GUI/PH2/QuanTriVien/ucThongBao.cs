using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.QuanTriVien
{
    public partial class ucThongBao : UserControl
    {
        private bool _loaded;
        private bool _updatingChecks;

        public ucThongBao()
        {
            InitializeComponent();
        }

        private void ucThongBao_Load(object sender, EventArgs e)
        {
            if (_loaded)
            {
                return;
            }

            _loaded = true;
            BindSentNotifications();
            UpdateSelectedCount();
        }

        private void BindSentNotifications()
        {
            dgvSent.Rows.Clear();
            AddNotification("24/05 09:15", "Nhắc nhở cập nhật mật khẩu trước ngày 30/05", "t1", "Quan trọng", true);
            AddNotification("23/05 16:42", "Họp giao ban Ban Giám đốc tại phòng họp số 3", "t2", "Khẩn cấp", true);
            AddNotification("22/05 11:00", "Cập nhật quy trình nhập liệu HSBA tháng 6 theo mẫu mới", "t3, t4", "Thông thường", false);
            AddNotification("21/05 08:30", "Bảo trì hệ thống 22h-02h, lưu dữ liệu trước khi thoát", "t1", "Khẩn cấp", true);
            AddNotification("19/05 14:00", "Kiểm tra phòng khám Cơ sở 2 theo kế hoạch", "t7", "Quan trọng", false);
            AddNotification("16/05 09:00", "Họp lãnh đạo khoa toàn bệnh viện, tổng kết tháng 5", "t2, t3", "Thông thường", false);
            dgvSent.ClearSelection();
            UpdateHistoryCount();
        }

        private void AddNotification(string time, string content, string labels, string priority, bool insertTop)
        {
            int rowIndex;
            if (insertTop)
            {
                dgvSent.Rows.Insert(0, time, content, labels, priority);
                rowIndex = 0;
            }
            else
            {
                rowIndex = dgvSent.Rows.Add(time, content, labels, priority);
            }

            DataGridViewRow row = dgvSent.Rows[rowIndex];

            if (priority == "Khẩn cấp")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 247, 247);
                row.Cells[3].Style.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else if (priority == "Quan trọng")
            {
                row.Cells[3].Style.ForeColor = Color.FromArgb(217, 119, 6);
            }
            else
            {
                row.Cells[3].Style.ForeColor = Color.FromArgb(71, 85, 105);
            }

            row.Cells[2].Style.ForeColor = Color.FromArgb(30, 64, 175);
            row.Cells[2].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            row.Cells[3].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (_updatingChecks)
            {
                return;
            }

            _updatingChecks = true;
            foreach (Guna2CheckBox checkBox in GetLabelChecks())
            {
                checkBox.Checked = chkAll.Checked;
            }
            _updatingChecks = false;
            UpdateSelectedCount();
        }

        private void LabelCheckChanged(object sender, EventArgs e)
        {
            if (_updatingChecks)
            {
                return;
            }

            _updatingChecks = true;
            chkAll.Checked = GetLabelChecks().All(c => c.Checked);
            _updatingChecks = false;
            UpdateSelectedCount();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string content = txtContent.Text.Trim();
            List<string> labels = GetSelectedLabels();

            if (string.IsNullOrWhiteSpace(content))
            {
                ShowMessage("Thiếu nội dung", "Vui lòng nhập nội dung thông báo.", MessageDialogIcon.Warning);
                return;
            }

            if (labels.Count == 0)
            {
                ShowMessage("Thiếu nhãn OLS", "Vui lòng chọn ít nhất một nhóm nhận.", MessageDialogIcon.Warning);
                return;
            }

            string summary = content.Length > 92 ? content.Substring(0, 92) + "..." : content;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                summary += " | " + txtLocation.Text.Trim();
            }

            AddNotification(
                dtpTime.Value.ToString("dd/MM HH:mm"),
                summary,
                string.Join(", ", labels),
                Convert.ToString(cmbPriority.SelectedItem),
                true);

            txtContent.Clear();
            txtLocation.Clear();
            ClearLabelChecks();
            UpdateHistoryCount();
            ShowMessage("Thông báo OLS", "Đã gửi thông báo thành công.", MessageDialogIcon.Information);
        }

        private List<Guna2CheckBox> GetLabelChecks()
        {
            return new List<Guna2CheckBox> { chkT1, chkT2, chkT3, chkT4, chkT5, chkT6, chkT7 };
        }

        private List<string> GetSelectedLabels()
        {
            return GetLabelChecks()
                .Where(c => c.Checked)
                .Select(c => c.Text.Split('-')[0].Trim())
                .ToList();
        }

        private void ClearLabelChecks()
        {
            _updatingChecks = true;
            chkAll.Checked = false;
            foreach (Guna2CheckBox checkBox in GetLabelChecks())
            {
                checkBox.Checked = false;
            }
            _updatingChecks = false;
            UpdateSelectedCount();
        }

        private void UpdateSelectedCount()
        {
            int count = GetLabelChecks().Count(c => c.Checked);
            lblSelectedCount.Text = count + " nhóm được chọn";
        }

        private void UpdateHistoryCount()
        {
            lblHistoryCount.Text = dgvSent.Rows.Count + " bản ghi";
        }

        private void ShowMessage(string caption, string text, MessageDialogIcon icon)
        {
            msgDialog.Parent = FindForm();
            msgDialog.Caption = caption;
            msgDialog.Text = text;
            msgDialog.Icon = icon;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show();
        }
    }
}

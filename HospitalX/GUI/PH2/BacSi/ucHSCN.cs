using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucHSCN : UserControl
    {
        public ucHSCN()
        {
            InitializeComponent();
            LoadRecentActivities();
        }

        // Đổ dữ liệu mẫu vào FlowLayoutPanel đã tạo sẵn trong Designer.
        private void LoadRecentActivities()
        {
            flpRecentActivities.Controls.Clear();
            AddActivityItem("Cập nhật chẩn đoán và điều trị", "HSBA-0821", "Hôm nay, 08:45", Color.FromArgb(15, 110, 86));
            AddActivityItem("Thêm dịch vụ Siêu âm tim", "HSBA-0821", "Hôm nay, 09:16", Color.FromArgb(58, 130, 196));
            AddActivityItem("Kê thêm Aspirin 81mg vào đơn thuốc", "HSBA-0821", "Hôm nay, 10:05", Color.FromArgb(232, 168, 56));
            AddActivityItem("Xem hồ sơ bệnh án", "HSBA-0819", "Hôm qua, 14:20", Color.FromArgb(122, 149, 137));
        }

        private void AddActivityItem(string title, string code, string time, Color dotColor)
        {
            int itemWidth = flpRecentActivities.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
            if (itemWidth < 520)
            {
                itemWidth = 520;
            }

            var item = new Panel
            {
                BackColor = Color.FromArgb(247, 249, 248),
                Margin = new Padding(0, 0, 0, 6),
                Size = new Size(itemWidth, 60)
            };

            var dot = new Label
            {
                BackColor = dotColor,
                Location = new Point(12, 18),
                Size = new Size(8, 8)
            };

            var lblTitle = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9.3F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(30, 5),
                Size = new Size(itemWidth - 210, 25),
                Text = title
            };

            var lblMeta = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Consolas", 8.6F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 110, 86),
                Location = new Point(30, 30),
                Size = new Size(160, 25),
                Text = code
            };

            var lblTime = new Label
            {
                Font = new Font("Segoe UI", 8.6F),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(itemWidth - 150, 13),
                Size = new Size(130, 25),
                Text = time,
                TextAlign = ContentAlignment.MiddleRight
            };

            item.Controls.Add(dot);
            item.Controls.Add(lblTitle);
            item.Controls.Add(lblMeta);
            item.Controls.Add(lblTime);
            flpRecentActivities.Controls.Add(item);
        }

        // Hỏi xác nhận trước khi lưu thông tin liên hệ.
        private void btnEditContact_Click(object sender, System.EventArgs e)
        {
            msgDialog.Parent = FindForm();
            msgDialog.Icon = MessageDialogIcon.Question;
            msgDialog.Buttons = MessageDialogButtons.YesNo;

            DialogResult result = msgDialog.Show(
                "Bạn có muốn cập nhật thông tin liên hệ không?",
                "Xác nhận cập nhật");

            if (result != DialogResult.Yes)
            {
                return;
            }

            string phone = txtContactPhoneValue.Text.Trim();
            string address = txtAddressValue.Text.Trim();

            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show(
                "Đã cập nhật thông tin liên hệ.\nSố điện thoại: " + phone + "\nĐịa chỉ: " + address,
                "HospitalX");
        }

        // Thông báo tạm cho chức năng đổi mật khẩu.
        private void btnChangePassword_Click(object sender, System.EventArgs e)
        {
            msgDialog.Parent = FindForm();
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Show("Chức năng đổi mật khẩu sẽ được kết nối ở bước sau.", "HospitalX");
        }
    }
}

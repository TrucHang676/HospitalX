using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.QuanTriVien
{
    public partial class ucTrangChu : UserControl
    {
        private bool _loaded;

        public ucTrangChu()
        {
            InitializeComponent();
        }

        private void ucTrangChu_Load(object sender, System.EventArgs e)
        {
            if (_loaded)
            {
                return;
            }

            _loaded = true;
            BindRecentActivities();
        }

        private void BindRecentActivities()
        {
            dgvRecent.Rows.Clear();
            AddActivity("14:32", "bs_tim_01 cập nhật đơn thuốc HSBA-0821", "Audit");
            AddActivity("14:25", "ys_noitru_03 cập nhật chẩn đoán hồ sơ bệnh án", "Audit");
            AddActivity("14:18", "nv_khoa_a_07 bị từ chối cập nhật HSBA trái quyền", "Cảnh báo");
            AddActivity("13:58", "dba_admin đọc nhật ký kiểm toán Standard Audit", "Hệ thống");
            AddActivity("13:20", "Kích hoạt policy FGA-03 cho bảng HSBA", "OLS");
            AddActivity("11:20", "backup_job ghi nhận incremental backup hoàn tất", "Backup");
            AddActivity("09:15", "Gửi thông báo OLS đến nhóm t1 - toàn bộ nhân viên", "Thông báo");
            dgvRecent.ClearSelection();
        }

        private void AddActivity(string time, string content, string level)
        {
            int rowIndex = dgvRecent.Rows.Add(time, content, level);
            DataGridViewRow row = dgvRecent.Rows[rowIndex];

            if (level == "Cảnh báo")
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 247, 247);
                row.Cells[2].Style.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else if (level == "Backup")
            {
                row.Cells[2].Style.ForeColor = Color.FromArgb(22, 163, 74);
            }
            else if (level == "OLS")
            {
                row.Cells[2].Style.ForeColor = Color.FromArgb(30, 64, 175);
            }

            row.Cells[2].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
    }
}

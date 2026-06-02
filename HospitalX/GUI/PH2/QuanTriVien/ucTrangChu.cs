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
            LocalizeText();
            StyleRecentGrid();
            BindRecentActivities();
        }

        private void LocalizeText()
        {
            lblRecentTitle.Text = "Hoạt động gần đây";
            colTime.HeaderText = "Thời gian";
            colEvent.HeaderText = "Hoạt động";
            colLevel.HeaderText = "Mức độ";
        }

        private void StyleRecentGrid()
        {
            dgvRecent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecent.BackgroundColor = Color.White;
            dgvRecent.BorderStyle = BorderStyle.None;
            dgvRecent.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRecent.EnableHeadersVisualStyles = false;
            dgvRecent.GridColor = Color.FromArgb(230, 238, 235);
            dgvRecent.RowTemplate.Height = 52;
            dgvRecent.ColumnHeadersHeight = 40;
            dgvRecent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvRecent.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 250);
            dgvRecent.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(86, 112, 104);
            dgvRecent.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.2F, FontStyle.Bold);
            dgvRecent.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 10, 0);

            dgvRecent.DefaultCellStyle.BackColor = Color.White;
            dgvRecent.DefaultCellStyle.ForeColor = Color.FromArgb(20, 42, 56);
            dgvRecent.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRecent.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            dgvRecent.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 244, 240);
            dgvRecent.DefaultCellStyle.SelectionForeColor = Color.FromArgb(10, 42, 64);
            dgvRecent.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 251);

            colTime.FillWeight = 86F;
            colEvent.FillWeight = 330F;
            colLevel.FillWeight = 92F;

            dgvRecent.CellPainting -= dgvRecent_CellPainting;
            dgvRecent.CellPainting += dgvRecent_CellPainting;
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
            }

            row.Cells[2].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        private void dgvRecent_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvRecent.Columns[e.ColumnIndex].Name != "colLevel")
            {
                return;
            }

            e.PaintBackground(e.CellBounds, true);
            string text = System.Convert.ToString(e.Value);
            Color fill = Color.FromArgb(241, 245, 249);
            Color fore = Color.FromArgb(51, 65, 85);

            if (text == "Cảnh báo")
            {
                fill = Color.FromArgb(254, 226, 226);
                fore = Color.FromArgb(185, 28, 28);
            }
            else if (text == "Audit")
            {
                fill = Color.FromArgb(219, 234, 254);
                fore = Color.FromArgb(30, 64, 175);
            }
            else if (text == "Backup")
            {
                fill = Color.FromArgb(220, 252, 231);
                fore = Color.FromArgb(22, 101, 52);
            }
            else if (text == "OLS")
            {
                fill = Color.FromArgb(237, 233, 254);
                fore = Color.FromArgb(91, 33, 182);
            }

            Rectangle badge = new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y + 14, e.CellBounds.Width - 28, e.CellBounds.Height - 28);
            using (System.Drawing.Drawing2D.GraphicsPath path = RoundedPath(badge, 8))
            using (SolidBrush brush = new SolidBrush(fill))
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }

            TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 8.8F, FontStyle.Bold), badge, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private static System.Drawing.Drawing2D.GraphicsPath RoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

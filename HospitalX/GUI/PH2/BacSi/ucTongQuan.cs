using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucTongQuan : UserControl
    {
        public ucTongQuan()
        {
            InitializeComponent();
        }

        private void ucTongQuan_Load(object sender, EventArgs e)
        {
            SetupRecentHsbaGrid();
        }

        // Thiết lập dữ liệu mẫu và style cho bảng HSBA gần đây.
        private void SetupRecentHsbaGrid()
        {
            dgvRecentHsba.EnableHeadersVisualStyles = false;
            dgvRecentHsba.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            dgvRecentHsba.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(122, 149, 137);
            dgvRecentHsba.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvRecentHsba.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRecentHsba.DefaultCellStyle.ForeColor = Color.FromArgb(61, 82, 73);
            dgvRecentHsba.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            dgvRecentHsba.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            dgvRecentHsba.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);

            if (dgvRecentHsba.Rows.Count > 0)
            {
                return;
            }

            dgvRecentHsba.Rows.Add("HSBA-0821", "Nguyễn Văn An\nBN-00341 · Nam, 52 tuổi", "21/05/2026\nHôm nay", "Đang điều trị", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0819", "Lê Thị Bích\nBN-00298 · Nữ, 38 tuổi", "20/05/2026\nHôm qua", "Chờ kết quả", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0815", "Phạm Quốc Hùng\nBN-00215 · Nam, 67 tuổi", "18/05/2026\n3 ngày trước", "Chờ kết quả", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0801", "Trần Thị Mai\nBN-00189 · Nữ, 45 tuổi", "12/05/2026\n9 ngày trước", "Hoàn thành", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0799", "Võ Minh Tuấn\nBN-00174 · Nam, 29 tuổi", "10/05/2026\n11 ngày trước", "Hoàn thành", "Xem");
        }
    }
}

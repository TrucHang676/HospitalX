using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucTongQuan : UserControl
    {
        private int hoveredActionRowIndex = -1;
        public event EventHandler ViewAllHsbaRequested;

        public ucTongQuan()
        {
            InitializeComponent();
            btnViewAll.Click += BtnViewAll_Click;
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
            dgvRecentHsba.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvRecentHsba.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 248);
            dgvRecentHsba.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(122, 149, 137);
            dgvRecentHsba.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgvRecentHsba.DefaultCellStyle.ForeColor = Color.FromArgb(61, 82, 73);
            dgvRecentHsba.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            dgvRecentHsba.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            dgvRecentHsba.DefaultCellStyle.Padding = new Padding(10, 0, 8, 0);
            dgvRecentHsba.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            dgvRecentHsba.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRecentHsba.RowTemplate.Height = 75;

            if (dgvRecentHsba.Rows.Count > 0)
            {
                return;
            }

            dgvRecentHsba.Rows.Add("HSBA-0821", "Trà Văn Sỹ\nBN-00341 · Nam, 21 tuổi", "23/05/2026\nHôm nay", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0819", "Lê Thị Bích\nBN-00298 · Nữ, 38 tuổi", "20/05/2026\nHôm qua", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0815", "Phạm Quốc Hùng\nBN-00215 · Nam, 67 tuổi", "18/05/2026\n3 ngày trước", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0801", "Trần Thị Mai\nBN-00189 · Nữ, 45 tuổi", "12/05/2026\n9 ngày trước", "Xem");
            dgvRecentHsba.Rows.Add("HSBA-0799", "Võ Minh Tuấn\nBN-00174 · Nam, 29 tuổi", "10/05/2026\n11 ngày trước", "Xem");
            dgvRecentHsba.ClearSelection();
            dgvRecentHsba.CurrentCell = null;
            dgvRecentHsba.MouseMove -= dgvRecentHsba_MouseMove;
            dgvRecentHsba.MouseMove += dgvRecentHsba_MouseMove;
            dgvRecentHsba.MouseLeave -= dgvRecentHsba_MouseLeave;
            dgvRecentHsba.MouseLeave += dgvRecentHsba_MouseLeave;
            dgvRecentHsba.CellClick -= dgvRecentHsba_CellClick;
            dgvRecentHsba.CellClick += dgvRecentHsba_CellClick;
        }

        // Vẽ badge, text 2 dòng và nút hành động để bảng mềm hơn.
        private void dgvRecentHsba_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            e.PaintBackground(e.CellBounds, true);

            string value = Convert.ToString(e.Value);
            Rectangle cell = e.CellBounds;

            if (e.ColumnIndex == dgvRecentHsba.Columns["colHsbaId"].Index)
            {
                Rectangle badge = new Rectangle(cell.X + 12, cell.Y + 21, 112, 28);
                FillRound(e.Graphics, badge, 6, Color.FromArgb(230, 244, 240));
                TextRenderer.DrawText(e.Graphics, value, new Font("Consolas", 9.2F, FontStyle.Bold), badge, Color.FromArgb(15, 110, 86), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == dgvRecentHsba.Columns["colPatient"].Index || e.ColumnIndex == dgvRecentHsba.Columns["colDate"].Index)
            {
                string[] lines = value.Split('\n');
                TextRenderer.DrawText(e.Graphics, lines[0], new Font("Segoe UI", 10F, FontStyle.Bold), new Rectangle(cell.X + 14, cell.Y + 3, cell.Width - 20, 40), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                if (lines.Length > 1)
                {
                    TextRenderer.DrawText(e.Graphics, lines[1], new Font("Segoe UI", 8.8F), new Rectangle(cell.X + 14, cell.Y + 40, cell.Width - 20, 30), Color.FromArgb(122, 149, 137), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == dgvRecentHsba.Columns["colAction"].Index)
            {
                bool hovered = e.RowIndex == hoveredActionRowIndex;
                Rectangle button = new Rectangle(cell.X + 24, cell.Y + 19, 70, 32);
                Color fill = hovered ? Color.FromArgb(230, 244, 240) : Color.White;
                Color border = hovered ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
                Color fore = hovered ? Color.FromArgb(10, 79, 61) : Color.FromArgb(15, 110, 86);
                FillRound(e.Graphics, button, 8, fill);
                DrawRound(e.Graphics, button, 8, border);
                TextRenderer.DrawText(e.Graphics, "Xem", new Font("Segoe UI", 9F, FontStyle.Bold), button, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }
        }

        // Hover cho nút Xem trong DataGridView.
        private void dgvRecentHsba_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvRecentHsba.HitTest(e.X, e.Y);
            int actionColumnIndex = dgvRecentHsba.Columns["colAction"].Index;
            int nextHoveredRow = hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == actionColumnIndex ? hit.RowIndex : -1;

            if (hoveredActionRowIndex != nextHoveredRow)
            {
                int oldRow = hoveredActionRowIndex;
                hoveredActionRowIndex = nextHoveredRow;
                dgvRecentHsba.Cursor = hoveredActionRowIndex >= 0 ? Cursors.Hand : Cursors.Default;
                InvalidateActionCell(oldRow);
                InvalidateActionCell(hoveredActionRowIndex);
            }
        }

        private void dgvRecentHsba_MouseLeave(object sender, EventArgs e)
        {
            int oldRow = hoveredActionRowIndex;
            hoveredActionRowIndex = -1;
            dgvRecentHsba.Cursor = Cursors.Default;
            InvalidateActionCell(oldRow);
        }

        private void dgvRecentHsba_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvRecentHsba.Columns["colAction"].Index)
            {
                return;
            }

            ucHSBA.HsbaRecord record = CreateHsbaRecordFromRecentRow(e.RowIndex);
            using (frmHSBADetail form = new frmHSBADetail(record))
            {
                form.ShowDialog(this);
            }
        }

        // Tạo dữ liệu HSBA mẫu cho popup chi tiết khi bấm nút Xem ở bảng Tổng quan.
        private ucHSBA.HsbaRecord CreateHsbaRecordFromRecentRow(int rowIndex)
        {
            DataGridViewRow row = dgvRecentHsba.Rows[rowIndex];
            string hsbaId = Convert.ToString(row.Cells["colHsbaId"].Value);
            string patientText = Convert.ToString(row.Cells["colPatient"].Value);
            string dateText = Convert.ToString(row.Cells["colDate"].Value);

            string[] patientLines = patientText.Split('\n');
            string patientName = patientLines.Length > 0 ? patientLines[0] : "";
            string patientMeta = patientLines.Length > 1 ? patientLines[1] : "";
            string[] metaParts = patientMeta.Split('·');

            string patientCode = metaParts.Length > 0 ? metaParts[0].Trim() : "";
            string gender = metaParts.Length > 1 ? metaParts[1].Trim() : "";
            int age = 0;
            if (metaParts.Length > 2)
            {
                int.TryParse(metaParts[2].Replace("tuổi", "").Trim(), out age);
            }

            DateTime createdDate;
            string createdText = dateText.Split('\n')[0];
            if (!DateTime.TryParseExact(createdText, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out createdDate))
            {
                createdDate = DateTime.Today;
            }

            return new ucHSBA.HsbaRecord
            {
                Id = hsbaId,
                PatientCode = patientCode,
                PatientName = patientName,
                Gender = gender,
                Age = age,
                Department = "Khoa Tim Mạch",
                CreatedDate = createdDate,
                BirthDate = GetBirthDate(hsbaId),
                CitizenId = GetCitizenId(hsbaId),
                Address = GetAddress(hsbaId),
                Allergy = GetAllergy(hsbaId),
                MedicalHistory = GetMedicalHistory(hsbaId),
                Diagnosis = GetDiagnosis(hsbaId),
                Treatment = GetTreatment(hsbaId),
                Conclusion = GetConclusion(hsbaId),
                Services = GetServices(hsbaId),
                Prescriptions = GetPrescriptions(hsbaId)
            };
        }

        private static string GetBirthDate(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0821": return "15/03/1974";
                case "HSBA-0819": return "09/10/1988";
                case "HSBA-0815": return "22/04/1959";
                case "HSBA-0801": return "03/12/1981";
                case "HSBA-0799": return "19/01/1997";
                default: return "";
            }
        }

        private static string GetCitizenId(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0821": return "079074012345";
                case "HSBA-0819": return "079088004512";
                case "HSBA-0815": return "079059002151";
                case "HSBA-0801": return "079081001891";
                case "HSBA-0799": return "079097001741";
                default: return "";
            }
        }

        private static string GetAddress(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0821": return "Q.1, TP.HCM";
                case "HSBA-0819": return "Q.7, TP.HCM";
                case "HSBA-0815": return "TP. Thủ Đức, TP.HCM";
                case "HSBA-0801": return "Q.3, TP.HCM";
                case "HSBA-0799": return "Q. Tân Bình, TP.HCM";
                default: return "";
            }
        }

        private static string GetAllergy(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0815": return "Dị ứng Penicillin";
                default: return "Không ghi nhận";
            }
        }

        private static string GetMedicalHistory(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0821": return "Tăng huyết áp từ năm 2018. Không hút thuốc lá.";
                case "HSBA-0819": return "Đã từng hồi hộp đánh trống ngực khi gắng sức.";
                case "HSBA-0815": return "Đái tháo đường type 2, tăng huyết áp lâu năm.";
                case "HSBA-0801": return "Tăng huyết áp nhẹ.";
                case "HSBA-0799": return "Không có bệnh nền đáng kể.";
                default: return "";
            }
        }

        private static string GetDiagnosis(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0821": return "Tăng huyết áp độ II, rối loạn nhịp tim kèm khó thở khi gắng sức.";
                case "HSBA-0819": return "Rối loạn nhịp tim kịch phát trên thất, cần theo dõi Holter 24h.";
                case "HSBA-0815": return "Suy tim độ II - NYHA, có tiền sử đái tháo đường type 2.";
                case "HSBA-0801": return "Tăng huyết áp kiểm soát tốt.";
                case "HSBA-0799": return "Rối loạn nhịp ngoại tâm thu lành tính.";
                default: return "";
            }
        }

        private static string GetTreatment(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0821": return "Amlodipine 5mg, Bisoprolol 2.5mg. Theo dõi huyết áp tại nhà.";
                case "HSBA-0819": return "Theo dõi nhịp tim, hạn chế caffeine, tái khám khi có kết quả Holter.";
                case "HSBA-0815": return "Điều chỉnh lợi tiểu, kiểm soát đường huyết và theo dõi CT tim.";
                case "HSBA-0801": return "Tiếp tục thuốc duy trì, ăn nhạt, vận động đều.";
                case "HSBA-0799": return "Trấn an, giảm chất kích thích, theo dõi triệu chứng.";
                default: return "";
            }
        }

        private static string GetConclusion(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0801": return "Tăng huyết áp kiểm soát tốt, tái khám sau 1 tháng.";
                case "HSBA-0799": return "Không cần can thiệp thêm.";
                default: return "(Chưa có kết luận - bệnh nhân đang điều trị)";
            }
        }

        private static List<string> GetServices(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0819": return new List<string> { "Holter điện tim 24h - Chờ kết quả" };
                case "HSBA-0815": return new List<string> { "CT tim - Chờ kết quả", "Xét nghiệm HbA1c - Có kết quả" };
                case "HSBA-0801": return new List<string> { "Xét nghiệm máu - Có kết quả" };
                case "HSBA-0799": return new List<string> { "Điện tim - Có kết quả" };
                default: return new List<string> { "Siêu âm tim - Chờ kết quả", "Xét nghiệm máu tổng quát - Có kết quả" };
            }
        }

        private static List<string> GetPrescriptions(string hsbaId)
        {
            switch (hsbaId)
            {
                case "HSBA-0819": return new List<string> { "Magnesium B6 - 2 viên/ngày" };
                case "HSBA-0815": return new List<string> { "Furosemide 40mg - 1 viên buổi sáng", "Metformin 500mg - 2 viên/ngày" };
                case "HSBA-0801": return new List<string> { "Losartan 50mg - 1 viên/ngày" };
                case "HSBA-0799": return new List<string> { "Không kê thuốc" };
                default: return new List<string> { "Amlodipine 5mg - 1 viên/ngày, sáng sau ăn", "Bisoprolol 2.5mg - 1 viên/ngày, sáng trước ăn" };
            }
        }

        private void BtnViewAll_Click(object sender, EventArgs e)
        {
            ViewAllHsbaRequested?.Invoke(this, EventArgs.Empty);
        }

        private void InvalidateActionCell(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvRecentHsba.Rows.Count)
            {
                dgvRecentHsba.InvalidateCell(dgvRecentHsba.Columns["colAction"].Index, rowIndex);
            }
        }

        private static void FillRound(Graphics g, Rectangle rect, int radius, Color color)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = RoundPath(rect, radius))
            using (SolidBrush brush = new SolidBrush(color))
            {
                g.FillPath(brush, path);
            }
        }

        private static void DrawRound(Graphics g, Rectangle rect, int radius, Color color)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath path = RoundPath(rect, radius))
            using (Pen pen = new Pen(color))
            {
                g.DrawPath(pen, path);
            }
        }

        private static GraphicsPath RoundPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

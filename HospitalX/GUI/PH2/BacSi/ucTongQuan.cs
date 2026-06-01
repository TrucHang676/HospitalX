using System;
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

            string maHsba = Convert.ToString(dgvRecentHsba.Rows[e.RowIndex].Cells["colHsbaId"].Value);
            MessageBox.Show("Mở chi tiết " + maHsba, "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

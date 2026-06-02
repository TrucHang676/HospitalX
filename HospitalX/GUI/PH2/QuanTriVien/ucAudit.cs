using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.QuanTriVien
{
    public partial class ucAudit : UserControl
    {
        private readonly List<AuditLogRecord> _logs = new List<AuditLogRecord>();
        private readonly List<AuditScenario> _scenarios = new List<AuditScenario>();
        private bool _isLoaded;
        private int _hoveredDetailRowIndex = -1;

        public ucAudit()
        {
            InitializeComponent();
        }

        private void ucAudit_Load(object sender, EventArgs e)
        {
            if (_isLoaded)
            {
                return;
            }

            _isLoaded = true;
            SeedData();
            SetupAuditGrids();
            WireEvents();
            ApplyFilters();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += FilterChanged;
            cmbObject.SelectedIndexChanged += FilterChanged;
            cmbAction.SelectedIndexChanged += FilterChanged;
            cmbResult.SelectedIndexChanged += FilterChanged;
            cmbSort.SelectedIndexChanged += FilterChanged;
            dtpFrom.ValueChanged += FilterChanged;
            dtpTo.ValueChanged += FilterChanged;
            btnClear.Click += BtnClear_Click;
            dgvLogs.CellContentClick += dgvLogs_CellContentClick;
            dgvLogs.CellPainting += dgvLogs_CellPainting;
            dgvLogs.MouseMove += dgvLogs_MouseMove;
            dgvLogs.MouseLeave += dgvLogs_MouseLeave;
        }

        private void SetupAuditGrids()
        {
            SetupSoftGrid(dgvLogs, 62, 44);
            dgvLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9.4F);
            dgvLogs.Columns["colAuditId"].FillWeight = 104F;
            dgvLogs.Columns["colTime"].FillWeight = 110F;
            dgvLogs.Columns["colUser"].FillWeight = 96F;
            dgvLogs.Columns["colAction"].FillWeight = 82F;
            dgvLogs.Columns["colObject"].FillWeight = 104F;
            dgvLogs.Columns["colDetail"].FillWeight = 238F;
            dgvLogs.Columns["colRows"].FillWeight = 48F;
            dgvLogs.Columns["colIp"].FillWeight = 88F;
            dgvLogs.Columns["colResult"].FillWeight = 112F;
            dgvLogs.Columns["colDetailAction"].FillWeight = 70F;
        }

        private static void SetupSoftGrid(DataGridView grid, int rowHeight, int headerHeight)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.GridColor = Color.White;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.AllowUserToResizeColumns = false;
            grid.ColumnHeadersHeight = headerHeight;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.RowTemplate.Height = rowHeight;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grid.AdvancedCellBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
            grid.AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;

            Guna2DataGridView gunaGrid = grid as Guna2DataGridView;
            if (gunaGrid != null)
            {
                gunaGrid.ThemeStyle.GridColor = Color.White;
                gunaGrid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
                gunaGrid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.None;
            }

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(122, 149, 137);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 248);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(122, 149, 137);

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(24, 48, 42);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            grid.DefaultCellStyle.Padding = new Padding(10, 0, 8, 0);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            grid.RowsDefaultCellStyle.BackColor = Color.White;

            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.DividerWidth = 0;
            }
        }

        private void SeedData()
        {
            if (_logs.Count > 0)
            {
                return;
            }

            _scenarios.Add(new AuditScenario("STD-01", "Standard Audit", "Đăng nhập hệ thống", "CREATE SESSION", "Ghi nhận đăng nhập thành công và thất bại của user cụ thể.", "Đã bật"));
            _scenarios.Add(new AuditScenario("STD-02", "Standard Audit", "Theo dõi đối tượng", "HSBA, HSBA_DV, ĐƠNTHUỐC", "Theo dõi INSERT, UPDATE, DELETE, SELECT trên table/view/procedure/function được chọn.", "Đã bật"));
            _scenarios.Add(new AuditScenario("FGA-01", "Fine-grained Audit", "Cập nhật đơn thuốc", "ĐƠNTHUỐC", "Audit UPDATE trên MAHSBA, NGÀYĐT, TÊNTHUỐC, LIỀUDÙNG sau khi đơn thuốc đã được tạo.", "Đã bật"));
            _scenarios.Add(new AuditScenario("FGA-02", "Fine-grained Audit", "Cập nhật HSBA hợp lệ", "HSBA", "Audit bác sĩ/y sĩ cập nhật CHẨNĐOÁN, ĐIỀUTRỊ, KẾTLUẬN trên HSBA do mình điều trị.", "Đã bật"));
            _scenarios.Add(new AuditScenario("FGA-03", "Fine-grained Audit", "Cập nhật HSBA bất hợp pháp", "HSBA", "Audit cập nhật trái quyền trên CHẨNĐOÁN, ĐIỀUTRỊ, KẾTLUẬN.", "Theo dõi"));
            _scenarios.Add(new AuditScenario("FGA-04", "Fine-grained Audit", "Thao tác bất hợp pháp HSBA_DV", "HSBA_DV", "Audit thêm, xóa, sửa bất hợp pháp trên quan hệ HSBA_DV.", "Theo dõi"));

            _logs.Add(new AuditLogRecord("AUD-08412", new DateTime(2026, 5, 24, 14, 32, 18), "bs_tim_01", "UPDATE", "ĐƠNTHUỐC", "MAHSBA=HSBA-0821; TÊNTHUỐC=Amlodipine 5mg; LIỀUDÙNG=1 viên/ngày", 1, "10.0.2.17", true, "FGA-01"));
            _logs.Add(new AuditLogRecord("AUD-08411", new DateTime(2026, 5, 24, 14, 25, 55), "ys_noitru_03", "UPDATE", "HSBA", "Cập nhật CHẨNĐOÁN, ĐIỀUTRỊ, KẾTLUẬN cho HSBA-0819", 1, "10.0.2.33", true, "FGA-02"));
            _logs.Add(new AuditLogRecord("AUD-08410", new DateTime(2026, 5, 24, 14, 18, 43), "nv_khoa_a_07", "UPDATE", "HSBA", "Bị từ chối cập nhật CHẨNĐOÁN trên HSBA-0815", 0, "10.0.1.18", false, "FGA-03"));
            _logs.Add(new AuditLogRecord("AUD-08409", new DateTime(2026, 5, 24, 14, 12, 06), "nv_khoa_b_03", "DELETE", "HSBA_DV", "Bị từ chối xóa dịch vụ DV-20260524-0099", 0, "10.0.1.31", false, "FGA-04"));
            _logs.Add(new AuditLogRecord("AUD-08408", new DateTime(2026, 5, 24, 13, 58, 20), "dba_admin", "SELECT", "DBA_AUDIT_TRAIL", "Đọc nhật ký kiểm toán môi trường Standard Audit", 500, "10.0.0.1", true, "STD-02"));
            _logs.Add(new AuditLogRecord("AUD-08407", new DateTime(2026, 5, 24, 13, 41, 55), "bs_tim_02", "SELECT", "HSBA", "WHERE NGÀYĐT BETWEEN :d1 AND :d2", 87, "10.0.2.21", true, "STD-02"));
            _logs.Add(new AuditLogRecord("AUD-08406", new DateTime(2026, 5, 24, 13, 20, 18), "dba_admin", "INSERT", "AUDIT_POLICY", "Kích hoạt policy FGA-03 cho bảng HSBA", 1, "10.0.0.1", true, "STD-02"));
            _logs.Add(new AuditLogRecord("AUD-08405", new DateTime(2026, 5, 24, 11, 20, 44), "backup_job", "INSERT", "BACKUP_HISTORY", "Ghi nhận incremental backup hoàn tất", 1, "10.0.0.2", true, "STD-02"));
            _logs.Add(new AuditLogRecord("AUD-08404", new DateTime(2026, 5, 23, 17, 10, 02), "bachmai_user", "LOGIN", "SESSION", "Sai mật khẩu lần 3", 0, "10.0.1.42", false, "STD-01"));
            _logs.Add(new AuditLogRecord("AUD-08403", new DateTime(2026, 5, 23, 16, 55, 22), "bs_tim_01", "LOGIN", "SESSION", "Đăng nhập thành công", 1, "10.0.2.17", true, "STD-01"));
            _logs.Add(new AuditLogRecord("AUD-08402", new DateTime(2026, 5, 22, 10, 15, 09), "ys_noitru_03", "UPDATE", "ĐƠNTHUỐC", "Thay đổi NGÀYĐT cho HSBA-0794", 1, "10.0.2.33", true, "FGA-01"));
            _logs.Add(new AuditLogRecord("AUD-08401", new DateTime(2026, 5, 21, 9, 30, 0), "nv_khoa_a_09", "INSERT", "HSBA_DV", "Bị từ chối thêm dịch vụ vào HSBA không phụ trách", 0, "10.0.1.22", false, "FGA-04"));
        }

        private void ApplyFilters()
        {
            IEnumerable<AuditLogRecord> query = _logs;
            string keyword = RemoveDiacritics(txtSearch.Text.Trim()).ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(log => RemoveDiacritics(
                    log.Id + " " + log.Username + " " + log.Action + " " + log.ObjectName + " " + log.Detail + " " + log.PolicyCode)
                    .ToLowerInvariant()
                    .Contains(keyword));
            }

            string selectedObject = GetSelectedValue(cmbObject);
            if (!string.IsNullOrEmpty(selectedObject))
            {
                query = query.Where(log => log.ObjectName == selectedObject);
            }

            string selectedAction = GetSelectedValue(cmbAction);
            if (!string.IsNullOrEmpty(selectedAction))
            {
                query = query.Where(log => log.Action == selectedAction);
            }

            string selectedResult = GetSelectedValue(cmbResult);
            if (selectedResult == "Thành công")
            {
                query = query.Where(log => log.Success);
            }
            else if (selectedResult == "Thất bại")
            {
                query = query.Where(log => !log.Success);
            }

            DateTime fromDate = dtpFrom.Value.Date <= dtpTo.Value.Date ? dtpFrom.Value.Date : dtpTo.Value.Date;
            DateTime toDate = dtpFrom.Value.Date <= dtpTo.Value.Date ? dtpTo.Value.Date : dtpFrom.Value.Date;
            query = query.Where(log => log.Time.Date >= fromDate && log.Time.Date <= toDate);

            string sort = GetSelectedValue(cmbSort);
            if (sort == "Cũ nhất")
            {
                query = query.OrderBy(log => log.Time);
            }
            else if (sort == "User A-Z")
            {
                query = query.OrderBy(log => log.Username).ThenByDescending(log => log.Time);
            }
            else
            {
                query = query.OrderByDescending(log => log.Time);
            }

            List<AuditLogRecord> filtered = query.ToList();
            RenderStats(filtered);
            RenderLogs(filtered);
        }

        private void RenderStats(List<AuditLogRecord> logs)
        {
            lblResultCount.Text = "Hiển thị " + logs.Count + " bản ghi kiểm toán";
        }

        private void RenderLogs(List<AuditLogRecord> logs)
        {
            dgvLogs.Rows.Clear();
            foreach (AuditLogRecord log in logs)
            {
                int rowIndex = dgvLogs.Rows.Add(
                    log.Id,
                    log.Time.ToString("dd/MM/yyyy") + "\n" + log.Time.ToString("HH:mm:ss"),
                    log.Username,
                    log.Action,
                    log.ObjectName,
                    log.Detail,
                    log.RowsAffected,
                    log.SourceIp,
                    log.Success ? "Thành công" : "Thất bại",
                    "Xem");
                dgvLogs.Rows[rowIndex].Tag = log;
                dgvLogs.Rows[rowIndex].DefaultCellStyle.BackColor = log.Success ? Color.White : Color.FromArgb(255, 247, 247);
                dgvLogs.Rows[rowIndex].DividerHeight = 0;
            }

            dgvLogs.ClearSelection();
        }

        private void dgvLogs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                PaintHeaderCell(e);
                return;
            }

            string columnName = dgvLogs.Columns[e.ColumnIndex].Name;
            PaintLogCellBackground(e);
            string text = Convert.ToString(e.Value);

            if (columnName == "colAuditId")
            {
                Rectangle idBadge = new Rectangle(e.CellBounds.X + 12, e.CellBounds.Y + 17, e.CellBounds.Width - 24, 28);
                PaintBadge(e.Graphics, idBadge, text, Color.FromArgb(230, 244, 240), Color.FromArgb(15, 110, 86), Color.Transparent, 8.8F);
                e.Handled = true;
                return;
            }

            if (columnName == "colTime")
            {
                string[] lines = text.Split('\n');
                TextRenderer.DrawText(e.Graphics, lines[0], new Font("Segoe UI", 9.6F, FontStyle.Bold), new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y + 8, e.CellBounds.Width - 22, 24), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                if (lines.Length > 1)
                {
                    TextRenderer.DrawText(e.Graphics, lines[1], new Font("Segoe UI", 8.8F), new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y + 31, e.CellBounds.Width - 22, 22), Color.FromArgb(122, 149, 137), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
                e.Handled = true;
                return;
            }

            if (columnName == "colDetailAction")
            {
                bool hovered = e.RowIndex == _hoveredDetailRowIndex;
                Rectangle button = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 16, e.CellBounds.Width - 20, 30);
                Color fill = hovered ? Color.FromArgb(230, 244, 240) : Color.White;
                Color border = hovered ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
                Color buttonFore = hovered ? Color.FromArgb(10, 79, 61) : Color.FromArgb(15, 110, 86);
                PaintBadge(e.Graphics, button, "Xem", fill, buttonFore, border, 8.8F);
                e.Handled = true;
                return;
            }

            if (columnName != "colAction" && columnName != "colResult")
            {
                TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                if (columnName == "colRows")
                {
                    flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    new Font("Segoe UI", 9.4F),
                    new Rectangle(e.CellBounds.X + 14, e.CellBounds.Y, e.CellBounds.Width - 22, e.CellBounds.Height),
                    Color.FromArgb(24, 48, 42),
                    flags);
                e.Handled = true;
                return;
            }

            Color back;
            Color fore;
            if (columnName == "colResult")
            {
                AuditLogRecord record = dgvLogs.Rows[e.RowIndex].Tag as AuditLogRecord;
                bool success = record == null || record.Success;
                back = success ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                fore = success ? Color.FromArgb(22, 101, 52) : Color.FromArgb(185, 28, 28);
            }
            else
            {
                GetActionColors(text, out back, out fore);
            }

            Rectangle statusBadge = new Rectangle(e.CellBounds.X + 12, e.CellBounds.Y + 17, e.CellBounds.Width - 24, 28);
            PaintBadge(e.Graphics, statusBadge, text, back, fore, Color.Transparent, 8.5F);
            e.Handled = true;
        }

        private void PaintLogCellBackground(DataGridViewCellPaintingEventArgs e)
        {
            AuditLogRecord record = dgvLogs.Rows[e.RowIndex].Tag as AuditLogRecord;
            Color fill;
            if (record != null && !record.Success)
            {
                fill = Color.FromArgb(255, 248, 248);
            }
            else
            {
                fill = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(248, 251, 250);
            }

            using (SolidBrush brush = new SolidBrush(fill))
            {
                Rectangle cover = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width + 3, e.CellBounds.Height + 3);
                e.Graphics.FillRectangle(brush, cover);
            }

            using (Pen pen = new Pen(Color.FromArgb(236, 243, 240)))
            {
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }
        }

        private static void PaintHeaderCell(DataGridViewCellPaintingEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(247, 249, 248)))
            {
                Rectangle cover = new Rectangle(e.CellBounds.X - 1, e.CellBounds.Y - 1, e.CellBounds.Width + 3, e.CellBounds.Height + 3);
                e.Graphics.FillRectangle(brush, cover);
            }

            TextRenderer.DrawText(
                e.Graphics,
                Convert.ToString(e.Value),
                new Font("Segoe UI", 9F, FontStyle.Bold),
                new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y, e.CellBounds.Width - 16, e.CellBounds.Height),
                Color.FromArgb(122, 149, 137),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        private void dgvLogs_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvLogs.HitTest(e.X, e.Y);
            int actionColumnIndex = dgvLogs.Columns["colDetailAction"].Index;
            int nextHoveredRow = hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == actionColumnIndex ? hit.RowIndex : -1;

            if (_hoveredDetailRowIndex != nextHoveredRow)
            {
                int oldRow = _hoveredDetailRowIndex;
                _hoveredDetailRowIndex = nextHoveredRow;
                dgvLogs.Cursor = _hoveredDetailRowIndex >= 0 ? Cursors.Hand : Cursors.Default;
                InvalidateDetailCell(oldRow);
                InvalidateDetailCell(_hoveredDetailRowIndex);
            }
        }

        private void dgvLogs_MouseLeave(object sender, EventArgs e)
        {
            int oldRow = _hoveredDetailRowIndex;
            _hoveredDetailRowIndex = -1;
            dgvLogs.Cursor = Cursors.Default;
            InvalidateDetailCell(oldRow);
        }

        private void InvalidateDetailCell(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvLogs.Rows.Count)
            {
                dgvLogs.InvalidateCell(dgvLogs.Columns["colDetailAction"].Index, rowIndex);
            }
        }

        private static void GetActionColors(string action, out Color back, out Color fore)
        {
            if (action == "UPDATE")
            {
                back = Color.FromArgb(219, 234, 254);
                fore = Color.FromArgb(30, 64, 175);
            }
            else if (action == "INSERT")
            {
                back = Color.FromArgb(220, 252, 231);
                fore = Color.FromArgb(22, 101, 52);
            }
            else if (action == "DELETE")
            {
                back = Color.FromArgb(254, 226, 226);
                fore = Color.FromArgb(185, 28, 28);
            }
            else if (action == "LOGIN")
            {
                back = Color.FromArgb(237, 233, 254);
                fore = Color.FromArgb(91, 33, 182);
            }
            else
            {
                back = Color.FromArgb(241, 245, 249);
                fore = Color.FromArgb(51, 65, 85);
            }
        }

        private static void PaintBadge(Graphics graphics, Rectangle rect, string text, Color fill, Color fore, Color border, float fontSize)
        {
            using (GraphicsPath path = RoundedPath(rect, 7))
            using (SolidBrush brush = new SolidBrush(fill))
            {
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.FillPath(brush, path);
                if (border != Color.Transparent)
                {
                    using (Pen pen = new Pen(border))
                    {
                        graphics.DrawPath(pen, path);
                    }
                }
            }

            TextRenderer.DrawText(graphics, text, new Font("Segoe UI", fontSize, FontStyle.Bold), rect, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private static GraphicsPath RoundedPath(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbObject.SelectedIndex = 0;
            cmbAction.SelectedIndex = 0;
            cmbResult.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            dtpFrom.Value = new DateTime(2026, 5, 21);
            dtpTo.Value = new DateTime(2026, 5, 24);
            ApplyFilters();
        }

        private void BtnEnableAudit_Click(object sender, EventArgs e)
        {
            msgDialog.Icon = MessageDialogIcon.Information;
            msgDialog.Buttons = MessageDialogButtons.OK;
            msgDialog.Caption = "Kiểm toán hệ thống";
            msgDialog.Text = "Đã kích hoạt các ngữ cảnh Standard Audit và Fine-grained Audit mẫu cho phân hệ 2.";
            msgDialog.Show();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "CSV file (*.csv)|*.csv";
                dialog.FileName = "hospitalx_audit_log.csv";
                if (dialog.ShowDialog(FindForm()) != DialogResult.OK)
                {
                    return;
                }

                List<string> lines = new List<string>();
                lines.Add("AuditId,Time,User,Action,Object,Detail,Rows,Ip,Result,Policy");
                foreach (DataGridViewRow row in dgvLogs.Rows)
                {
                    AuditLogRecord log = row.Tag as AuditLogRecord;
                    if (log == null)
                    {
                        continue;
                    }

                    lines.Add(string.Join(",", new string[]
                    {
                        Csv(log.Id),
                        Csv(log.Time.ToString("yyyy-MM-dd HH:mm:ss")),
                        Csv(log.Username),
                        Csv(log.Action),
                        Csv(log.ObjectName),
                        Csv(log.Detail),
                        Csv(log.RowsAffected.ToString()),
                        Csv(log.SourceIp),
                        Csv(log.Success ? "OK" : "FAIL"),
                        Csv(log.PolicyCode)
                    }));
                }

                System.IO.File.WriteAllLines(dialog.FileName, lines, Encoding.UTF8);
                msgDialog.Icon = MessageDialogIcon.Information;
                msgDialog.Buttons = MessageDialogButtons.OK;
                msgDialog.Caption = "Xuất CSV";
                msgDialog.Text = "Đã xuất " + (lines.Count - 1) + " bản ghi kiểm toán.";
                msgDialog.Show();
            }
        }

        private void dgvLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvLogs.Columns[e.ColumnIndex].Name != "colDetailAction")
            {
                return;
            }

            AuditLogRecord log = dgvLogs.Rows[e.RowIndex].Tag as AuditLogRecord;
            if (log == null)
            {
                return;
            }

            using (var form = new frmAuditLogDetail(log))
            {
                form.ShowDialog(FindForm());
            }
            ApplyFilters();
        }

        private string GetSelectedValue(Guna2ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return string.Empty;
            }

            string value = comboBox.SelectedItem.ToString();
            return value.StartsWith("Tất cả") ? string.Empty : value;
        }

        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder builder = new StringBuilder();
            foreach (char c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }

        private static string Csv(string value)
        {
            return "\"" + (value ?? string.Empty).Replace("\"", "\"\"") + "\"";
        }

        private class AuditScenario
        {
            public AuditScenario(string code, string type, string name, string target, string description, string status)
            {
                Code = code;
                Type = type;
                Name = name;
                Target = target;
                Description = description;
                Status = status;
            }

            public string Code { get; private set; }
            public string Type { get; private set; }
            public string Name { get; private set; }
            public string Target { get; private set; }
            public string Description { get; private set; }
            public string Status { get; private set; }
        }
    }

    public class AuditLogRecord
    {
        public AuditLogRecord(string id, DateTime time, string username, string action, string objectName, string detail, int rowsAffected, string sourceIp, bool success, string policyCode)
        {
            Id = id;
            Time = time;
            Username = username;
            Action = action;
            ObjectName = objectName;
            Detail = detail;
            RowsAffected = rowsAffected;
            SourceIp = sourceIp;
            Success = success;
            PolicyCode = policyCode;
        }

        public string Id { get; private set; }
        public DateTime Time { get; private set; }
        public string Username { get; private set; }
        public string Action { get; private set; }
        public string ObjectName { get; private set; }
        public string Detail { get; private set; }
        public int RowsAffected { get; private set; }
        public string SourceIp { get; private set; }
        public bool Success { get; private set; }
        public string PolicyCode { get; private set; }
    }
}

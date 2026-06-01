using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
            WireEvents();
            BindScenarios();
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
            btnEnableAudit.Click += BtnEnableAudit_Click;
            btnExport.Click += BtnExport_Click;
            dgvLogs.CellContentClick += dgvLogs_CellContentClick;
            dgvLogs.CellPainting += dgvLogs_CellPainting;
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

        private void BindScenarios()
        {
            dgvScenarios.Rows.Clear();
            foreach (AuditScenario scenario in _scenarios)
            {
                int rowIndex = dgvScenarios.Rows.Add(scenario.Code, scenario.Type, scenario.Name, scenario.Target, scenario.Status);
                dgvScenarios.Rows[rowIndex].Tag = scenario;
            }
            dgvScenarios.ClearSelection();
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
            lblTotalValue.Text = logs.Count.ToString();
            lblSuccessValue.Text = logs.Count(log => log.Success).ToString();
            lblFailValue.Text = logs.Count(log => !log.Success).ToString();
            lblUpdateValue.Text = logs.Count(log => log.Action == "UPDATE").ToString();
            lblResultCount.Text = "Hiển thị " + logs.Count + " bản ghi kiểm toán";
        }

        private void RenderLogs(List<AuditLogRecord> logs)
        {
            dgvLogs.Rows.Clear();
            foreach (AuditLogRecord log in logs)
            {
                int rowIndex = dgvLogs.Rows.Add(
                    log.Id,
                    log.Time.ToString("dd/MM/yyyy HH:mm:ss"),
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
            }

            dgvLogs.ClearSelection();
        }

        private void dgvLogs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string columnName = dgvLogs.Columns[e.ColumnIndex].Name;
            if (columnName != "colAction" && columnName != "colResult" && columnName != "colDetailAction")
            {
                return;
            }

            e.PaintBackground(e.CellBounds, true);
            string text = Convert.ToString(e.Value);

            if (columnName == "colDetailAction")
            {
                Rectangle button = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 8, e.CellBounds.Width - 16, e.CellBounds.Height - 16);
                PaintBadge(e.Graphics, button, "Xem", Color.White, Color.FromArgb(15, 110, 86), Color.FromArgb(196, 226, 216));
                e.Handled = true;
                return;
            }

            Color back;
            Color fore;
            if (columnName == "colResult")
            {
                bool success = text.Contains("Thành") || text.Contains("ThÃ");
                back = success ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
                fore = success ? Color.FromArgb(22, 101, 52) : Color.FromArgb(185, 28, 28);
            }
            else
            {
                GetActionColors(text, out back, out fore);
            }

            Rectangle badge = new Rectangle(e.CellBounds.X + 10, e.CellBounds.Y + 10, Math.Min(e.CellBounds.Width - 18, 86), e.CellBounds.Height - 20);
            PaintBadge(e.Graphics, badge, text, back, fore, Color.Transparent);
            e.Handled = true;
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

        private static void PaintBadge(Graphics graphics, Rectangle rect, string text, Color fill, Color fore, Color border)
        {
            using (System.Drawing.Drawing2D.GraphicsPath path = RoundedPath(rect, 7))
            using (SolidBrush brush = new SolidBrush(fill))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.FillPath(brush, path);
                if (border != Color.Transparent)
                {
                    using (Pen pen = new Pen(border))
                    {
                        graphics.DrawPath(pen, path);
                    }
                }
            }

            TextRenderer.DrawText(graphics, text, new Font("Segoe UI", 8.6F, FontStyle.Bold), rect, fore, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
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

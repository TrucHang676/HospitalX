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

        private Guna2ComboBox cmbAuditType;
        private Label lblAuditType;
        private Guna2Button btnRecoverAudit;

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
            InitializeAuditTypeFilter();
            InitializeRecoveryButton();
            SetupAuditGrids();
            InitializeDateFilters();
            LoadLogsFromDatabase();
            WireEvents();
            ApplyFilters();
        }

        private void InitializeAuditTypeFilter()
        {
            lblAuditType = new Label
            {
                Text = "LOẠI AUDIT",
                Location = new Point(cmbSort.Left + cmbSort.Width + 16, lblSort.Top),
                Size = lblSort.Size,
                Font = lblSort.Font,
                ForeColor = lblSort.ForeColor,
                BackColor = Color.Transparent
            };

            cmbAuditType = new Guna2ComboBox
            {
                Location = new Point(cmbSort.Left + cmbSort.Width + 16, cmbSort.Top),
                Size = cmbSort.Size,
                BorderRadius = cmbSort.BorderRadius,
                BorderColor = cmbSort.BorderColor,
                Font = cmbSort.Font,
                ForeColor = cmbSort.ForeColor,
                FocusedColor = cmbSort.FocusedColor
            };
            cmbAuditType.Items.AddRange(new object[] { "Tất cả loại", "STANDARD", "FGA" });
            cmbAuditType.StartIndex = 0;

            cmbAuditType.SelectedIndexChanged += FilterChanged;

            pnlFilter.Controls.Add(lblAuditType);
            pnlFilter.Controls.Add(cmbAuditType);
        }

        // Nút mở hộp thoại khôi phục dữ liệu dựa vào nhật ký kiểm toán (FGA).
        private void InitializeRecoveryButton()
        {
            btnRecoverAudit = new Guna2Button
            {
                Text = "Khôi phục theo nhật ký",
                Location = new Point(240, 15),
                Size = new Size(232, 32),
                BorderRadius = 8,
                FillColor = Color.FromArgb(15, 110, 86),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRecoverAudit.HoverState.FillColor = Color.FromArgb(10, 79, 61);
            btnRecoverAudit.Click += BtnRecoverAudit_Click;

            pnlLogsHeader.Controls.Add(btnRecoverAudit);
            btnRecoverAudit.BringToFront();
        }

        private void BtnRecoverAudit_Click(object sender, EventArgs e)
        {
            using (var dlg = new frmRecoveryAudit())
            {
                dlg.ShowDialog(FindForm());
            }

            // Tải lại nhật ký để phản ánh kết quả khôi phục
            LoadLogsFromDatabase();
            ApplyFilters();
        }

        private void InitializeDateFilters()
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
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

            dgvLogs.Columns["colAuditId"].HeaderText = "Mã audit";
            dgvLogs.Columns["colTime"].HeaderText = "Thời gian";
            dgvLogs.Columns["colUser"].HeaderText = "User";
            dgvLogs.Columns["colAction"].HeaderText = "Hành vi";
            dgvLogs.Columns["colObject"].HeaderText = "Đối tượng";
            dgvLogs.Columns["colDetail"].HeaderText = "Chi tiết";
            dgvLogs.Columns["colRows"].HeaderText = "Mã lỗi";
            dgvLogs.Columns["colIp"].HeaderText = "Loại audit";
            dgvLogs.Columns["colResult"].HeaderText = "Kết quả";
            dgvLogs.Columns["colDetailAction"].HeaderText = "";

            dgvLogs.Columns["colAuditId"].FillWeight = 104F;
            dgvLogs.Columns["colTime"].FillWeight = 110F;
            dgvLogs.Columns["colUser"].FillWeight = 96F;
            dgvLogs.Columns["colAction"].FillWeight = 82F;
            dgvLogs.Columns["colObject"].FillWeight = 104F;
            dgvLogs.Columns["colDetail"].FillWeight = 238F;
            dgvLogs.Columns["colRows"].FillWeight = 68F;
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

        private void LoadLogsFromDatabase()
        {
            _logs.Clear();
            try
            {
                DataTable dt = HospitalX.DAO.AuditLogDAO.GetAuditLogs();
                if (dt != null)
                {
                    int seqId = 1;
                    foreach (DataRow row in dt.Rows)
                    {
                        string loaiAudit = row["LOAI_AUDIT"].ToString().Trim();
                        string username = row["USER_NAME"].ToString().Trim();
                        string objectName = row["DOI_TUONG"] != DBNull.Value ? row["DOI_TUONG"].ToString().Trim() : "-";
                        string action = row["HANH_VI"] != DBNull.Value ? row["HANH_VI"].ToString().Trim() : "-";
                        string policyName = row["POLICY_NAME"] != DBNull.Value ? row["POLICY_NAME"].ToString().Trim() : "-";
                        string errorCode = row["MA_LOI"] != DBNull.Value ? row["MA_LOI"].ToString().Trim() : "0";
                        string result = row["KET_QUA"].ToString().Trim();
                        DateTime time = Convert.ToDateTime(row["THOI_GIAN"]);
                        string sqlText = row["SQL_TEXT"] != DBNull.Value ? row["SQL_TEXT"].ToString().Trim() : "";
                        string detail = row["CHI_TIET"] != DBNull.Value ? row["CHI_TIET"].ToString().Trim() : "";
                        string terminal = row["TERMINAL"] != DBNull.Value ? row["TERMINAL"].ToString().Trim() : "-";

                        string prefix = loaiAudit == "STANDARD" ? "STD" : "FGA";
                        string id = $"{prefix}-{seqId:D5}";

                        var log = new AuditLogRecord(
                            id: id,
                            auditType: loaiAudit,
                            time: time,
                            username: username,
                            action: action,
                            objectName: objectName,
                            policyName: policyName,
                            errorCode: errorCode,
                            result: result,
                            detail: string.IsNullOrEmpty(sqlText) ? detail : $"[Policy: {policyName}] {sqlText}",
                            terminal: terminal
                        );

                        _logs.Add(log);
                        seqId++;
                    }
                }
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex) when (ex.Number == 942 || ex.Number == 1031)
            {
                MessageBox.Show("Quyền truy cập nhật ký kiểm toán bị từ chối.\nVui lòng đảm bảo tài khoản Admin có quyền SELECT trên DBA_AUDIT_TRAIL và DBA_FGA_AUDIT_TRAIL.", "Cảnh báo quyền kiểm toán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải nhật ký kiểm toán từ cơ sở dữ liệu: " + ex.Message, "Lỗi kiểm toán", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _scenarios.Clear();
            _scenarios.Add(new AuditScenario("STD-01", "Standard Audit", "Đăng nhập hệ thống", "CREATE SESSION", "Ghi nhận đăng nhập thành công và thất bại của user cụ thể.", "Đã bật"));
            _scenarios.Add(new AuditScenario("STD-02", "Standard Audit", "Theo dõi đối tượng", "HSBA, HSBA_DV, DONTHUOC", "Theo dõi INSERT, UPDATE, DELETE, SELECT trên table/view/procedure/function được chọn.", "Đã bật"));
            _scenarios.Add(new AuditScenario("FGA-01", "Fine-grained Audit", "Cập nhật đơn thuốc", "DONTHUOC", "Audit UPDATE trên MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG sau khi đơn thuốc đã được tạo.", "Đã bật"));
            _scenarios.Add(new AuditScenario("FGA-02", "Fine-grained Audit", "Cập nhật HSBA hợp lệ", "HSBA", "Audit bác sĩ/y sĩ cập nhật CHANDOAN, DIEUTRI, KETLUAN trên HSBA do mình điều trị.", "Đã bật"));
            _scenarios.Add(new AuditScenario("FGA-03", "Fine-grained Audit", "Cập nhật HSBA bất hợp pháp", "HSBA", "Audit cập nhật trái quyền trên CHANDOAN, DIEUTRI, KETLUAN.", "Theo dõi"));
            _scenarios.Add(new AuditScenario("FGA-04", "Fine-grained Audit", "Thao tác bất hợp pháp HSBA_DV", "HSBA_DV", "Audit thêm, xóa, sửa bất hợp pháp trên quan hệ HSBA_DV.", "Theo dõi"));
        }

        private void ApplyFilters()
        {
            IEnumerable<AuditLogRecord> query = _logs;
            string keyword = RemoveDiacritics(txtSearch.Text.Trim()).ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(log => RemoveDiacritics(
                    log.Id + " " + log.Username + " " + log.Action + " " + log.ObjectName + " " + log.Detail + " " + log.PolicyName)
                    .ToLowerInvariant()
                    .Contains(keyword));
            }

            string selectedAuditType = GetSelectedValue(cmbAuditType);
            if (!string.IsNullOrEmpty(selectedAuditType))
            {
                query = query.Where(log => log.AuditType == selectedAuditType);
            }

            string selectedObject = GetSelectedValue(cmbObject);
            if (!string.IsNullOrEmpty(selectedObject))
            {
                if (selectedObject == "ĐƠNTHUỐC")
                {
                    query = query.Where(log => log.ObjectName == "DONTHUOC" || log.ObjectName == "ĐƠNTHUỐC");
                }
                else
                {
                    query = query.Where(log => log.ObjectName == selectedObject);
                }
            }

            string selectedAction = GetSelectedValue(cmbAction);
            if (!string.IsNullOrEmpty(selectedAction))
            {
                if (selectedAction == "LOGIN")
                {
                    query = query.Where(log => log.Action == "LOGON" || log.Action == "LOGOFF" || log.Action.Contains("LOGON") || log.Action.Contains("SESSION"));
                }
                else
                {
                    query = query.Where(log => log.Action == selectedAction);
                }
            }

            string selectedResult = GetSelectedValue(cmbResult);
            if (!string.IsNullOrEmpty(selectedResult))
            {
                if (selectedResult == "Thành công")
                {
                    query = query.Where(log => log.Result == "Thành công" || log.Result == "Thanh cong" || log.Result == "Ghi nhận FGA" || log.Result == "Ghi nhan FGA");
                }
                else if (selectedResult == "Thất bại")
                {
                    query = query.Where(log => log.Result == "Thất bại" || log.Result == "That bai");
                }
                else if (selectedResult == "Cảnh báo")
                {
                    query = query.Where(log => log.Result == "Cảnh báo" || log.Result == "Canh bao");
                }
                else
                {
                    query = query.Where(log => log.Result == selectedResult);
                }
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
                    log.ErrorCode,
                    log.AuditType,
                    log.Result,
                    "Xem");
                dgvLogs.Rows[rowIndex].Tag = log;
                dgvLogs.Rows[rowIndex].DefaultCellStyle.BackColor = (log.Result == "Thành công" || log.Result == "Ghi nhận FGA" || log.Result == "Thanh cong" || log.Result == "Ghi nhan FGA") ? Color.White : ((log.Result == "Cảnh báo" || log.Result == "Canh bao") ? Color.FromArgb(255, 253, 240) : Color.FromArgb(255, 247, 247));
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
                string res = record != null ? record.Result : "Thành công";
                if (res == "Thành công" || res == "Ghi nhận FGA" || res == "Thanh cong" || res == "Ghi nhan FGA")
                {
                    back = Color.FromArgb(220, 252, 231);
                    fore = Color.FromArgb(22, 101, 52);
                }
                else if (res == "Cảnh báo" || res == "Canh bao")
                {
                    back = Color.FromArgb(254, 243, 199);
                    fore = Color.FromArgb(180, 83, 9);
                }
                else
                {
                    back = Color.FromArgb(254, 226, 226);
                    fore = Color.FromArgb(185, 28, 28);
                }
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
            if (record != null && (record.Result == "Thất bại" || record.Result == "That bai"))
            {
                fill = Color.FromArgb(255, 248, 248);
            }
            else if (record != null && (record.Result == "Cảnh báo" || record.Result == "Canh bao"))
            {
                fill = Color.FromArgb(255, 253, 240);
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
            if (cmbAuditType != null) cmbAuditType.SelectedIndex = 0;
            InitializeDateFilters();
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
                lines.Add("AuditId,Time,User,Action,Object,Detail,ErrorCode,AuditType,Result,Policy,Terminal");
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
                        Csv(log.ErrorCode),
                        Csv(log.AuditType),
                        Csv(log.Result),
                        Csv(log.PolicyName),
                        Csv(log.Terminal)
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
            if (comboBox == null || comboBox.SelectedItem == null)
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
        public AuditLogRecord(string id, string auditType, DateTime time, string username, string action, string objectName, string policyName, string errorCode, string result, string detail, string terminal)
        {
            Id = id;
            AuditType = auditType;
            Time = time;
            Username = username;
            Action = action;
            ObjectName = objectName;
            PolicyName = policyName;
            ErrorCode = errorCode;
            Result = result;
            Detail = detail;
            Terminal = terminal;
        }

        public string Id { get; private set; }
        public string AuditType { get; private set; }
        public DateTime Time { get; private set; }
        public string Username { get; private set; }
        public string Action { get; private set; }
        public string ObjectName { get; private set; }
        public string PolicyName { get; private set; }
        public string ErrorCode { get; private set; }
        public string Result { get; private set; }
        public string Detail { get; private set; }
        public string Terminal { get; private set; }
    }

    // =====================================================================
    // Hộp thoại KHÔI PHỤC DỮ LIỆU DỰA VÀO NHẬT KÝ KIỂM TOÁN (FGA)
    // Xây dựng hoàn toàn bằng code (không Designer/resx) để không phải sửa
    // .csproj. Gọi xuống Oracle qua AuditLogDAO. Chạy đồng bộ + bắt lỗi đầy đủ.
    // =====================================================================
    public class frmRecoveryAudit : Form
    {
        private Guna2DataGridView dgvIncidents;
        private Guna2DataGridView dgvHistory;
        private Guna2Panel pnlStatusAlert;
        private Label lblStatus;
        private Guna2Button btnRecover;
        private Guna2Button btnReload;
        private Guna2Button btnClose;

        public frmRecoveryAudit()
        {
            Text = "Khôi phục dữ liệu theo nhật ký kiểm toán (FGA)";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(940, 630);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 9F);

            BuildUi();
            LoadIncidents();
            LoadHistory();
        }

        private void BuildUi()
        {
            Label lblTitle = new Label
            {
                Text = "Sự cố phát hiện từ nhật ký kiểm toán",
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(16, 14)
            };
            Label lblHint = new Label
            {
                Text = "Hệ thống đọc DBA_FGA_AUDIT_TRAIL, tính SCN ngay trước thời điểm sự cố và Flashback "
                     + "HSBA / HSBA_DV / DONTHUOC về trạng thái nguyên bản (hoàn tác UPDATE/INSERT/DELETE trái phép).",
                AutoSize = false,
                Location = new Point(16, 44),
                Size = new Size(908, 20),
                ForeColor = Color.FromArgb(100, 116, 110)
            };

            // Container cho dgvIncidents để tạo viền bo tròn đẹp
            Guna2Panel pnlIncidentsContainer = new Guna2Panel
            {
                Location = new Point(16, 72),
                Size = new Size(908, 246),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(218, 232, 226),
                FillColor = Color.White
            };

            dgvIncidents = NewGrid();
            dgvIncidents.Location = new Point(2, 2);
            dgvIncidents.Size = new Size(904, 242);
            pnlIncidentsContainer.Controls.Add(dgvIncidents);

            Label lblHist = new Label
            {
                Text = "Lịch sử khôi phục",
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 42, 64),
                Location = new Point(16, 330)
            };

            // Container cho dgvHistory để tạo viền bo tròn đẹp
            Guna2Panel pnlHistoryContainer = new Guna2Panel
            {
                Location = new Point(16, 356),
                Size = new Size(908, 158),
                BorderRadius = 8,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(218, 232, 226),
                FillColor = Color.White
            };

            dgvHistory = NewGrid();
            dgvHistory.Location = new Point(2, 2);
            dgvHistory.Size = new Size(904, 154);
            pnlHistoryContainer.Controls.Add(dgvHistory);

            // Panel trạng thái / Alert box
            pnlStatusAlert = new Guna2Panel
            {
                Location = new Point(16, 520),
                Size = new Size(908, 42),
                BorderRadius = 6,
                FillColor = Color.FromArgb(243, 244, 246)
            };

            lblStatus = new Label
            {
                Text = "Sẵn sàng.",
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.25F, FontStyle.Bold),
                ForeColor = Color.FromArgb(75, 85, 99),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 10, 0),
                BackColor = Color.Transparent
            };
            pnlStatusAlert.Controls.Add(lblStatus);

            btnRecover = new Guna2Button
            {
                Text = "Khôi phục ngay",
                Size = new Size(170, 38),
                Location = new Point(16, 572),
                FillColor = Color.FromArgb(15, 110, 86),
                ForeColor = Color.White,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnRecover.HoverState.FillColor = Color.FromArgb(10, 79, 61);
            btnRecover.Click += BtnRecover_Click;

            btnReload = new Guna2Button
            {
                Text = "Tải lại sự cố",
                Size = new Size(130, 38),
                Location = new Point(198, 572),
                FillColor = Color.White,
                ForeColor = Color.FromArgb(15, 110, 86),
                BorderColor = Color.FromArgb(15, 110, 86),
                BorderThickness = 1,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnReload.HoverState.FillColor = Color.FromArgb(240, 248, 245);
            btnReload.Click += (s, e) => { LoadIncidents(); LoadHistory(); };

            btnClose = new Guna2Button
            {
                Text = "Đóng",
                Size = new Size(100, 38),
                Location = new Point(824, 572),
                FillColor = Color.White,
                ForeColor = Color.FromArgb(80, 90, 85),
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderThickness = 1,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.HoverState.FillColor = Color.FromArgb(245, 247, 246);
            btnClose.Click += (s, e) => Close();

            Controls.Add(lblTitle);
            Controls.Add(lblHint);
            Controls.Add(pnlIncidentsContainer);
            Controls.Add(lblHist);
            Controls.Add(pnlHistoryContainer);
            Controls.Add(pnlStatusAlert);
            Controls.Add(btnRecover);
            Controls.Add(btnReload);
            Controls.Add(btnClose);
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
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 248);
            grid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(122, 149, 137);

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(24, 48, 42);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 250);
        }

        private static Guna2DataGridView NewGrid()
        {
            Guna2DataGridView g = new Guna2DataGridView();
            SetupSoftGrid(g, 36, 36);

            g.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(240, 244, 242);

            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 248);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(122, 149, 137);
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(247, 249, 248);
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(122, 149, 137);

            g.DefaultCellStyle.BackColor = Color.White;
            g.DefaultCellStyle.ForeColor = Color.FromArgb(24, 48, 42);
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);

            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 250);

            g.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 251, 250);
            g.ThemeStyle.BackColor = Color.White;
            g.ThemeStyle.GridColor = Color.FromArgb(240, 244, 242);
            g.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(247, 249, 248);
            g.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(122, 149, 137);
            g.ThemeStyle.RowsStyle.BackColor = Color.White;
            g.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(24, 48, 42);
            g.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(230, 244, 240);
            g.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);

            return g;
        }

        private void LoadIncidents()
        {
            try
            {
                DataTable dt = HospitalX.DAO.AuditLogDAO.GetIncidentsFromAudit();
                dgvIncidents.DataSource = dt;
                int n = dt != null ? dt.Rows.Count : 0;
                btnRecover.Enabled = n > 0;
                if (n > 0)
                {
                    lblStatus.Text = "Phát hiện " + n + " sự cố trong nhật ký kiểm toán. Nhấn 'Khôi phục ngay' để hoàn tác.";
                    lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
                    pnlStatusAlert.FillColor = Color.FromArgb(254, 242, 242);
                }
                else
                {
                    lblStatus.Text = "Không phát hiện sự cố bất hợp pháp trong nhật ký kiểm toán. Không cần khôi phục.";
                    lblStatus.ForeColor = Color.FromArgb(17, 94, 89);
                    pnlStatusAlert.FillColor = Color.FromArgb(240, 253, 250);
                }
            }
            catch (Exception ex)
            {
                btnRecover.Enabled = false;
                lblStatus.Text = "Lỗi tải danh sách sự cố: " + ex.Message;
                lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
                pnlStatusAlert.FillColor = Color.FromArgb(254, 242, 242);
            }
        }

        private void LoadHistory()
        {
            try
            {
                dgvHistory.DataSource = HospitalX.DAO.AuditLogDAO.GetRecoveryHistory();
            }
            catch
            {
                // Lịch sử khôi phục là phụ trợ, lỗi ở đây không chặn chức năng chính.
            }
        }

        private void BtnRecover_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                this,
                "Hệ thống sẽ Flashback HSBA, HSBA_DV, DONTHUOC về trạng thái NGAY TRƯỚC sự cố "
                + "dựa trên mốc thời gian trong nhật ký kiểm toán.\n\nTiếp tục khôi phục?",
                "Xác nhận khôi phục",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            btnRecover.Enabled = false;
            btnReload.Enabled = false;
            Cursor = Cursors.WaitCursor;
            lblStatus.Text = "Đang khôi phục dữ liệu theo nhật ký kiểm toán...";
            lblStatus.ForeColor = Color.FromArgb(30, 64, 175);
            pnlStatusAlert.FillColor = Color.FromArgb(239, 246, 255);
            Application.DoEvents();

            string logId = "";
            string status = "";
            string message = "";
            bool ok = false;

            try
            {
                ok = HospitalX.DAO.AuditLogDAO.RunAutoRecoveryFromAudit(out logId, out status, out message);

                lblStatus.Text = "[" + status + "] " + message;
                lblStatus.ForeColor = ok ? Color.FromArgb(17, 94, 89) : Color.FromArgb(153, 27, 27);
                pnlStatusAlert.FillColor = ok ? Color.FromArgb(240, 253, 250) : Color.FromArgb(254, 242, 242);

                MessageBox.Show(
                    this,
                    message + "\n\nMã khôi phục: " + logId,
                    "Kết quả khôi phục (" + status + ")",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi khôi phục: " + ex.Message;
                lblStatus.ForeColor = Color.FromArgb(153, 27, 27);
                pnlStatusAlert.FillColor = Color.FromArgb(254, 242, 242);
                MessageBox.Show(this, ex.Message, "Lỗi khôi phục", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnReload.Enabled = true;
                LoadIncidents();
                LoadHistory();
            }
        }
    }
}

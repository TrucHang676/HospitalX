using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucBenhNhanCuaToi : UserControl
    {
        private readonly List<PatientRecord> _patients = new List<PatientRecord>();
        private int _hoveredActionRowIndex = -1;
        private int _hoveredActionColumnIndex = -1;
        private int _hoveredRowIndex = -1;

        public ucBenhNhanCuaToi()
        {
            InitializeComponent();
            SetupActionButtons();
            LoadPatientsFromDatabase();
            ApplyFilters();
        }

        private void SetupActionButtons()
        {
            dgvPatients.RowTemplate.Height = 78;
            dgvPatients.DefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
            dgvPatients.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 250);
            dgvPatients.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPatients.Columns["colPatient"].FillWeight = 20F;
            dgvPatients.Columns["colGender"].FillWeight = 10F;
            dgvPatients.Columns["colAge"].FillWeight = 8F;
            dgvPatients.Columns["colHsbaCount"].FillWeight = 9F;
            dgvPatients.Columns["colRxCount"].FillWeight = 11F;
            dgvPatients.Columns["colHometown"].FillWeight = 14F;
            dgvPatients.Columns["colDetail"].FillWeight = 14F;
            dgvPatients.Columns["colHistory"].FillWeight = 14F;
            dgvPatients.Columns["colDetail"].MinimumWidth = 132;
            dgvPatients.Columns["colHistory"].MinimumWidth = 142;

            dgvPatients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPatients.CellPainting += dgvPatients_CellPainting;
            dgvPatients.MouseMove += dgvPatients_MouseMove;
            dgvPatients.MouseLeave += dgvPatients_MouseLeave;
            dgvPatients.CellMouseLeave += dgvPatients_CellMouseLeave;
        }

        private void LoadPatientsFromDatabase()
        {
            _patients.Clear();
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.PatientDAO.GetPatientsForDoctor();
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        var patient = new PatientRecord
                        {
                            Code = row["MABN"].ToString().Trim(),
                            Name = row["TENBN"].ToString().Trim(),
                            Gender = row["PHAI"].ToString().Trim(),
                            Age = row["TUOI"] != DBNull.Value ? Convert.ToInt32(row["TUOI"]) : 0,
                            HsbaCount = row["SO_HSBA"] != DBNull.Value ? Convert.ToInt32(row["SO_HSBA"]) : 0,
                            PrescriptionCount = row["SO_DONTHUOC"] != DBNull.Value ? Convert.ToInt32(row["SO_DONTHUOC"]) : 0,
                            Cccd = row["CCCD"] != DBNull.Value ? row["CCCD"].ToString().Trim() : "",
                            Allergy = row["DIUNGTHUOC"] != DBNull.Value ? row["DIUNGTHUOC"].ToString().Trim() : "",
                            MedicalHistory = row["TIENSUBENH"] != DBNull.Value ? row["TIENSUBENH"].ToString().Trim() : "",
                            FamilyHistory = row["TIENSUBENHGD"] != DBNull.Value ? row["TIENSUBENHGD"].ToString().Trim() : "",
                            TinhTp = row["TINHTP"] != DBNull.Value ? row["TINHTP"].ToString().Trim() : "",
                            HsbaList = new List<string>()
                        };

                        // Build Hometown/Address
                        string address = "";
                        if (row["SONHA"] != DBNull.Value) address += row["SONHA"].ToString().Trim() + " ";
                        if (row["TENDUONG"] != DBNull.Value) address += row["TENDUONG"].ToString().Trim() + ", ";
                        if (row["QUANHUYEN"] != DBNull.Value) address += row["QUANHUYEN"].ToString().Trim() + ", ";
                        if (row["TINHTP"] != DBNull.Value) address += row["TINHTP"].ToString().Trim();
                        address = address.Trim().TrimEnd(',');
                        patient.Hometown = string.IsNullOrEmpty(address) ? "(Chưa cập nhật)" : address;

                        // Fetch medical records lists (HsbaList)
                        System.Data.DataTable dtHsba = HospitalX.DAO.HsbaDAO.GetHsbaForPatient(patient.Code);
                        if (dtHsba != null)
                        {
                            foreach (System.Data.DataRow hRow in dtHsba.Rows)
                            {
                                string hsbaId = hRow["MAHSBA"].ToString().Trim();
                                string dateStr = hRow["NGAY"] != DBNull.Value ? Convert.ToDateTime(hRow["NGAY"]).ToString("dd/MM/yyyy") : "";
                                string chandoan = hRow["CHANDOAN"] != DBNull.Value ? hRow["CHANDOAN"].ToString().Trim() : "";
                                patient.HsbaList.Add($"{hsbaId} | {dateStr} | {chandoan}");
                            }
                        }

                        _patients.Add(patient);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách bệnh nhân từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();
            string gender = cmbGender.SelectedItem == null ? "Tất cả giới tính" : cmbGender.SelectedItem.ToString();

            var filtered = _patients.Where(p =>
                (gender == "Tất cả giới tính" || p.Gender == gender) &&
                (string.IsNullOrWhiteSpace(keyword) ||
                 p.Name.ToLowerInvariant().Contains(keyword) ||
                 p.Code.ToLowerInvariant().Contains(keyword)))
                .ToList();

            dgvPatients.Rows.Clear();
            foreach (PatientRecord patient in filtered)
            {
                int rowIndex = dgvPatients.Rows.Add(
                    patient.Name + Environment.NewLine + patient.Code,
                    patient.Gender,
                    patient.Age,
                    patient.HsbaCount,
                    patient.PrescriptionCount,
                    string.IsNullOrEmpty(patient.TinhTp) ? "(Chưa cập nhật)" : patient.TinhTp,
                    "Xem chi tiết",
                    "Tiền sử bệnh");
                dgvPatients.Rows[rowIndex].Tag = patient;
            }

            lblCount.Text = filtered.Count + " bệnh nhân";
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            PatientRecord patient = dgvPatients.Rows[e.RowIndex].Tag as PatientRecord;
            if (patient == null)
            {
                return;
            }

            if (dgvPatients.Columns[e.ColumnIndex].Name == "colDetail")
            {
                using (var frm = new frmPatientDetail(patient))
                {
                    frm.ShowDialog(FindForm());
                }
                LoadPatientsFromDatabase();
                ApplyFilters();
            }
            else if (dgvPatients.Columns[e.ColumnIndex].Name == "colHistory")
            {
                using (var frm = new frmPatientHistory(patient))
                {
                    frm.ShowDialog(FindForm());
                }
                LoadPatientsFromDatabase();
                ApplyFilters();
            }
        }

        private void dgvPatients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string columnName = dgvPatients.Columns[e.ColumnIndex].Name;
            PaintCellBackground(e);

            if (columnName == "colPatient")
            {
                PaintPatientCell(e);
                e.Handled = true;
                return;
            }



            if (!IsActionColumn(e.ColumnIndex))
            {
                PaintPlainCell(e);
                e.Handled = true;
                return;
            }

            bool hovered = e.RowIndex == _hoveredActionRowIndex && e.ColumnIndex == _hoveredActionColumnIndex;
            bool isDetail = columnName == "colDetail";
            string text = Convert.ToString(e.Value);

            Color fill = isDetail
                ? (hovered ? Color.FromArgb(26, 148, 112) : Color.FromArgb(15, 110, 86))
                : (hovered ? Color.FromArgb(230, 244, 240) : Color.White);
            Color fore = isDetail ? Color.White : Color.FromArgb(15, 110, 86);
            Color border = isDetail
                ? (hovered ? Color.FromArgb(26, 148, 112) : Color.FromArgb(15, 110, 86))
                : (hovered ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226));

            Rectangle button = GetActionButtonBounds(e.CellBounds);
            FillRound(e.Graphics, button, 8, fill);
            DrawRound(e.Graphics, button, 8, border);
            TextRenderer.DrawText(
                e.Graphics,
                text,
                new Font("Segoe UI", 9F, FontStyle.Bold),
                button,
                fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            e.Handled = true;
        }

        private void dgvPatients_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvPatients.HitTest(e.X, e.Y);
            int nextHoveredRow = hit.Type == DataGridViewHitTestType.Cell ? hit.RowIndex : -1;
            int nextRow = -1;
            int nextColumn = -1;

            if (_hoveredRowIndex != nextHoveredRow)
            {
                int oldHoveredRow = _hoveredRowIndex;
                _hoveredRowIndex = nextHoveredRow;
                InvalidateRow(oldHoveredRow);
                InvalidateRow(_hoveredRowIndex);
            }

            if (hit.Type == DataGridViewHitTestType.Cell && IsActionColumn(hit.ColumnIndex))
            {
                Rectangle buttonBounds = GetActionButtonBounds(dgvPatients.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false));
                if (buttonBounds.Contains(e.Location))
                {
                    nextRow = hit.RowIndex;
                    nextColumn = hit.ColumnIndex;
                }
            }

            if (_hoveredActionRowIndex == nextRow && _hoveredActionColumnIndex == nextColumn)
            {
                return;
            }

            int oldRow = _hoveredActionRowIndex;
            int oldColumn = _hoveredActionColumnIndex;
            _hoveredActionRowIndex = nextRow;
            _hoveredActionColumnIndex = nextColumn;
            dgvPatients.Cursor = nextRow >= 0 ? Cursors.Hand : Cursors.Default;
            InvalidateActionCell(oldRow, oldColumn);
            InvalidateActionCell(_hoveredActionRowIndex, _hoveredActionColumnIndex);
        }

        private void dgvPatients_MouseLeave(object sender, EventArgs e)
        {
            int oldHoveredRow = _hoveredRowIndex;
            _hoveredRowIndex = -1;
            InvalidateRow(oldHoveredRow);
            ClearHoveredActionCell();
        }

        private void dgvPatients_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == _hoveredActionRowIndex && e.ColumnIndex == _hoveredActionColumnIndex)
            {
                ClearHoveredActionCell();
            }
        }

        private void ClearHoveredActionCell()
        {
            int oldRow = _hoveredActionRowIndex;
            int oldColumn = _hoveredActionColumnIndex;
            _hoveredActionRowIndex = -1;
            _hoveredActionColumnIndex = -1;
            dgvPatients.Cursor = Cursors.Default;
            InvalidateActionCell(oldRow, oldColumn);
        }

        private bool IsActionColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= dgvPatients.Columns.Count)
            {
                return false;
            }

            string columnName = dgvPatients.Columns[columnIndex].Name;
            return columnName == "colDetail" || columnName == "colHistory";
        }

        private static Rectangle GetActionButtonBounds(Rectangle cell)
        {
            int width = Math.Min(cell.Width - 18, 128);
            int height = 36;
            return new Rectangle(
                cell.X + (cell.Width - width) / 2,
                cell.Y + (cell.Height - height) / 2,
                width,
                height);
        }

        private void PaintCellBackground(DataGridViewCellPaintingEventArgs e)
        {
            bool hovered = e.RowIndex == _hoveredRowIndex;
            bool selected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
            bool alternate = e.RowIndex % 2 == 1;
            Color backColor = hovered || selected
                ? Color.FromArgb(226, 244, 239)
                : (alternate ? Color.FromArgb(248, 251, 250) : Color.White);

            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }

            using (Pen pen = new Pen(Color.FromArgb(238, 242, 240)))
            {
                e.Graphics.DrawLine(pen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }
        }

        private void PaintPatientCell(DataGridViewCellPaintingEventArgs e)
        {
            PatientRecord patient = dgvPatients.Rows[e.RowIndex].Tag as PatientRecord;
            string name = patient == null ? Convert.ToString(e.Value).Split('\n')[0] : patient.Name;
            string code = patient == null ? string.Empty : patient.Code;
            Rectangle cell = e.CellBounds;

            int avatarSize = 38;
            Rectangle avatar = new Rectangle(cell.X + 14, cell.Y + 20, avatarSize, avatarSize);
            FillRound(e.Graphics, avatar, avatarSize / 2, Color.FromArgb(230, 244, 240));
            DrawRound(e.Graphics, avatar, avatarSize / 2, Color.FromArgb(196, 226, 216));
            TextRenderer.DrawText(
                e.Graphics,
                GetAvatarText(name),
                new Font("Segoe UI", 11F, FontStyle.Bold),
                avatar,
                Color.FromArgb(15, 110, 86),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            Rectangle nameRect = new Rectangle(cell.X + 64, cell.Y + 12, cell.Width - 82, 28);
            TextRenderer.DrawText(
                e.Graphics,
                name,
                new Font("Segoe UI", 10.5F, FontStyle.Bold),
                nameRect,
                Color.FromArgb(24, 48, 42),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            Size codeSize = TextRenderer.MeasureText(code, new Font("Consolas", 8.8F, FontStyle.Bold));
            Rectangle badge = new Rectangle(cell.X + 64, cell.Y + 43, Math.Min(codeSize.Width + 22, cell.Width - 86), 24);
            FillRound(e.Graphics, badge, 8, Color.FromArgb(230, 244, 240));
            TextRenderer.DrawText(
                e.Graphics,
                code,
                new Font("Consolas", 8.8F, FontStyle.Bold),
                badge,
                Color.FromArgb(15, 110, 86),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private void PaintGenderCell(DataGridViewCellPaintingEventArgs e)
        {
            string gender = Convert.ToString(e.Value);
            bool male = gender == "Nam";
            Color back = male ? Color.FromArgb(230, 244, 240) : Color.FromArgb(255, 244, 220);
            Color fore = male ? Color.FromArgb(15, 110, 86) : Color.FromArgb(154, 98, 0);
            Color border = male ? Color.FromArgb(196, 226, 216) : Color.FromArgb(238, 213, 156);

            Rectangle pill = new Rectangle(
                e.CellBounds.X + 16,
                e.CellBounds.Y + (e.CellBounds.Height - 30) / 2,
                Math.Min(76, e.CellBounds.Width - 28),
                30);

            FillRound(e.Graphics, pill, 13, back);
            DrawRound(e.Graphics, pill, 13, border);
            TextRenderer.DrawText(
                e.Graphics,
                gender,
                new Font("Segoe UI", 9F, FontStyle.Bold),
                pill,
                fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private void PaintCountCell(DataGridViewCellPaintingEventArgs e, bool isHsba)
        {
            string value = Convert.ToString(e.Value);
            Color back = isHsba ? Color.FromArgb(230, 244, 240) : Color.FromArgb(238, 242, 240);
            Color fore = isHsba ? Color.FromArgb(15, 110, 86) : Color.FromArgb(61, 82, 73);
            Color border = isHsba ? Color.FromArgb(196, 226, 216) : Color.FromArgb(218, 232, 226);

            Rectangle badge = new Rectangle(
                e.CellBounds.X + (e.CellBounds.Width - 70) / 2,
                e.CellBounds.Y + (e.CellBounds.Height - 26) / 2,
                42,
                30);

            FillRound(e.Graphics, badge, 10, back);
            DrawRound(e.Graphics, badge, 10, border);
            TextRenderer.DrawText(
                e.Graphics,
                value,
                new Font("Segoe UI", 9.5F, FontStyle.Bold),
                badge,
                fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void PaintPlainCell(DataGridViewCellPaintingEventArgs e)
        {
            string columnName = dgvPatients.Columns[e.ColumnIndex].Name;
            bool center = true;
            int padding = center ? 0 : 8;
            Rectangle textRect = new Rectangle(e.CellBounds.X + padding, e.CellBounds.Y, e.CellBounds.Width - (padding * 2), e.CellBounds.Height);
            TextFormatFlags flags = TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;
            flags |= center ? TextFormatFlags.HorizontalCenter : TextFormatFlags.Left;

            TextRenderer.DrawText(
                e.Graphics,
                Convert.ToString(e.Value),
                new Font("Segoe UI", 9.8F, FontStyle.Regular),
                textRect,
                Color.FromArgb(24, 48, 42),
                flags);
        }

        private void InvalidateActionCell(int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvPatients.Rows.Count && IsActionColumn(columnIndex))
            {
                dgvPatients.InvalidateCell(columnIndex, rowIndex);
            }
        }

        private void InvalidateRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvPatients.Rows.Count)
            {
                dgvPatients.InvalidateRow(rowIndex);
            }
        }

        private static string GetAvatarText(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "?";
            }

            return name.Trim().Substring(0, 1).ToUpperInvariant();
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

        public class PatientRecord
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int HsbaCount { get; set; }
            public int PrescriptionCount { get; set; }
            public string Hometown { get; set; }
            public string Cccd { get; set; }
            public string Allergy { get; set; }
            public string MedicalHistory { get; set; }
            public string FamilyHistory { get; set; }
            public string TinhTp { get; set; }
            public List<string> HsbaList { get; set; }
        }
    }
}

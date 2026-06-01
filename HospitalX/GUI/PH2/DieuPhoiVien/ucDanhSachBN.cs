using Guna.UI2.WinForms;
using HospitalX.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucDanhSachBN : UserControl
    {
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);
        private static readonly Font StatusFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        private static readonly Font MaBnFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
        private const int StatusPillHorizontalPad = 36;
        private const int PageSize = 10;

        private List<PatientModel> _allPatients = new List<PatientModel>();
        private List<PatientModel> _filteredPatients = new List<PatientModel>();
        private int _currentPage = 1;
        private int _totalPage = 1;
        private string _activeChipStatus = "all";
        private int _hoveredRowIndex = -1;
        private PatientModel _selectedPatient = null;
        private int cboSortSelectedIndex = 0;
        private Image _imgEyeOpen = null;
        private Image _imgDpv3 = null;
        private Image _imgBin = null;
        private int _hoveredButtonIndex = -1;
        private int _hoveredButtonRowIndex = -1;
        private bool _isAllSelectedToggle = false;

        public ucDanhSachBN()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Resize += ucDanhSachBN_Resize;
        }

        private void ucDanhSachBN_Load(object sender, EventArgs e)
        {
            _imgEyeOpen = DpvAssets.Load("eye_open.png");
            _imgDpv3 = DpvAssets.Load("dpv_3.png");
            _imgBin = DpvAssets.Load("bin.png");

            InitMockData();
            SetupPatientGrid();
            // Modal popup is now frmChiTietBN (separate form)

            AdjustLayoutSizes();
            SetupPaginationControls();
            
            InitComboBoxes();

            ApplyFilter();
        }

        private void InitMockData()
        {
            PatientModel.InitializeSharedPatients();
            _allPatients.Clear();
            _allPatients.AddRange(PatientModel.SharedPatients);
            UpdateChipCounts();
        }

        private void UpdateChipCounts()
        {
            int total = _allPatients.Count;
            int active = _allPatients.Count(p => p.Status == "active");
            int pending = _allPatients.Count(p => p.Status == "pending");
            int urgent = _allPatients.Count(p => p.Status == "urgent");

            btnChipAll.Text = $"Tất cả ({total})";
            btnChipActive.Text = $"Đang điều trị ({active})";
            btnChipPending.Text = $"Chờ xử lý ({pending})";
            btnChipUrgent.Text = $"Cần điều phối KTV ({urgent})";

            UpdateChipStyles();
        }

        private void InitComboBoxes()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("Tất cả khoa");
            cboKhoa.Items.Add("Tim mạch");
            cboKhoa.Items.Add("Nội tổng quát");
            cboKhoa.Items.Add("Chỉnh hình");
            cboKhoa.Items.Add("Sản khoa");
            cboKhoa.Items.Add("Thần kinh");
            cboKhoa.Items.Add("Nhi khoa");
            cboKhoa.SelectedIndex = 0;

            cboGioiTinh.Items.Clear();
            cboGioiTinh.Items.Add("Tất cả");
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
            cboGioiTinh.SelectedIndex = 0;

            cboSortSelectedIndex = 0; // Mới nhất

            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "MM/dd/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "MM/dd/yyyy";

            dtpFrom.Value = new DateTime(2026, 5, 1);
            dtpTo.Value = new DateTime(2026, 5, 24);
        }

        private void SetupPatientGrid()
        {
            var headerBack = Color.FromArgb(247, 249, 248);
            var headerFore = Color.FromArgb(122, 149, 137);

            // Enable double buffering for DataGridView to ensure completely smooth rendering
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, dgvPatients, new object[] { true });

            dgvPatients.EnableHeadersVisualStyles = false;
            dgvPatients.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
            dgvPatients.ColumnHeadersDefaultCellStyle.ForeColor = headerFore;
            dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            dgvPatients.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBack;
            dgvPatients.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFore;
            dgvPatients.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 0, 0);
            dgvPatients.ColumnHeadersHeight = 44;
            dgvPatients.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.75F);
            dgvPatients.DefaultCellStyle.ForeColor = Color.FromArgb(61, 82, 73);
            dgvPatients.DefaultCellStyle.BackColor = Color.White;
            dgvPatients.DefaultCellStyle.SelectionBackColor = RowHoverBack;
            dgvPatients.DefaultCellStyle.SelectionForeColor = Color.FromArgb(61, 82, 73);
            dgvPatients.DefaultCellStyle.Padding = new Padding(12, 0, 8, 0);

            dgvPatients.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvPatients.RowsDefaultCellStyle.BackColor = Color.White;
            dgvPatients.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPatients.GridColor = Color.FromArgb(238, 242, 240);
            dgvPatients.RowTemplate.Height = 64;
            dgvPatients.MultiSelect = false;
            dgvPatients.ShowCellToolTips = false;

            colCheck.Width = 40;
            colMaBN.FillWeight = 12F;
            colHoTen.FillWeight = 18F;
            colDob.FillWeight = 12F;
            colGioiTinh.FillWeight = 10F;
            colKhoa.FillWeight = 14F;
            colBacSi.FillWeight = 14F;
            colDate.FillWeight = 14F;
            colStatus.FillWeight = 16F;
            colThaoTac.Width = 180;

            foreach (DataGridViewColumn col in dgvPatients.Columns)
            {
                if (col != colCheck)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            colThaoTac.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvPatients.CellPainting += dgvPatients_CellPainting;
            dgvPatients.MouseMove += dgvPatients_MouseMove;
            dgvPatients.MouseLeave += dgvPatients_MouseLeave;
            dgvPatients.CellClick += dgvPatients_CellClick;
        }

        private void ApplyFilter()
        {
            string query = RemoveDiacritics(txtSearch.Text.Trim());
            string selectedKhoa = cboKhoa.SelectedIndex > 0 ? cboKhoa.SelectedItem.ToString() : null;
            string selectedGender = cboGioiTinh.SelectedIndex > 0 ? cboGioiTinh.SelectedItem.ToString() : null;

            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;

            _filteredPatients = _allPatients.Where(p =>
            {
                // Search condition (accents stripped)
                bool matchesSearch = string.IsNullOrEmpty(query) ||
                                     RemoveDiacritics(p.Name).Contains(query) ||
                                     RemoveDiacritics(p.Id).Contains(query) ||
                                     RemoveDiacritics(p.Cccd).Contains(query);

                // Department condition
                bool matchesKhoa = selectedKhoa == null || p.Khoa == selectedKhoa;

                // Gender condition
                bool matchesGender = selectedGender == null || p.Gender == selectedGender;

                // Date condition
                DateTime pDate;
                bool matchesDate = false;
                if (DateTime.TryParseExact(p.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out pDate))
                {
                    matchesDate = pDate >= fromDate && pDate <= toDate;
                }

                // Tab Status condition
                bool matchesStatus = _activeChipStatus == "all" || p.Status == _activeChipStatus;

                return matchesSearch && matchesKhoa && matchesGender && matchesDate && matchesStatus;
            }).ToList();

            // Sort
            if (cboSortSelectedIndex == 0) // Newest
            {
                _filteredPatients = _filteredPatients.OrderByDescending(p =>
                {
                    DateTime d;
                    return DateTime.TryParseExact(p.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d) ? d : DateTime.MinValue;
                }).ThenByDescending(p => p.Id).ToList();
            }
            else // Oldest
            {
                _filteredPatients = _filteredPatients.OrderBy(p =>
                {
                    DateTime d;
                    return DateTime.TryParseExact(p.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out d) ? d : DateTime.MaxValue;
                }).ThenBy(p => p.Id).ToList();
            }

            _currentPage = 1;
            CalculatePagination();
            RenderGrid();
        }

        private void CalculatePagination()
        {
            _totalPage = (int)Math.Ceiling((double)_filteredPatients.Count / PageSize);
            if (_totalPage < 1) _totalPage = 1;
        }

        private void RenderGrid()
        {
            _isAllSelectedToggle = false;
            dgvPatients.Rows.Clear();

            int startIdx = (_currentPage - 1) * PageSize;
            var pageItems = _filteredPatients.Skip(startIdx).Take(PageSize).ToList();

            foreach (var p in pageItems)
            {
                dgvPatients.Rows.Add(false, p.Id, p.Name, p.Dob, p.Gender, p.Khoa, p.Bs, p.Date, p.StatusLabel, "");
            }

            lblTableMeta.Text = $"Hiển thị {pageItems.Count} / {_filteredPatients.Count} bệnh nhân";
            
            UpdatePaginationUI();

            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                RenderGrid();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPage)
            {
                _currentPage++;
                RenderGrid();
            }
        }

        private void btnChip_Click(object sender, EventArgs e)
        {
            var btn = (Guna2Button)sender;
            btnChipAll.Checked = false;
            btnChipActive.Checked = false;
            btnChipPending.Checked = false;
            btnChipUrgent.Checked = false;
            btn.Checked = true;

            if (btn == btnChipAll) _activeChipStatus = "all";
            else if (btn == btnChipActive) _activeChipStatus = "active";
            else if (btn == btnChipPending) _activeChipStatus = "pending";
            else if (btn == btnChipUrgent) _activeChipStatus = "urgent";

            UpdateChipStyles();
            ApplyFilter();
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboKhoa.SelectedIndex = 0;
            cboGioiTinh.SelectedIndex = 0;
            cboSortSelectedIndex = 0;
            dtpFrom.Value = new DateTime(2026, 5, 1);
            dtpTo.Value = new DateTime(2026, 5, 24);

            btnChipAll.Checked = true;
            btnChipActive.Checked = false;
            btnChipPending.Checked = false;
            btnChipUrgent.Checked = false;
            _activeChipStatus = "all";

            ApplyFilter();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất excel đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            _isAllSelectedToggle = !_isAllSelectedToggle;
            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                row.Cells[colCheck.Index].Value = _isAllSelectedToggle;
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            var selectedIds = new List<string>();
            foreach (DataGridViewRow row in dgvPatients.Rows)
            {
                if (Convert.ToBoolean(row.Cells[colCheck.Index].Value))
                {
                    selectedIds.Add(Convert.ToString(row.Cells[colMaBN.Index].Value));
                }
            }

            if (selectedIds.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bệnh nhân để thực hiện thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Special case: If user selected ALL rows in the current view, uncheck all of them instead of deleting.
            if (selectedIds.Count == dgvPatients.Rows.Count && dgvPatients.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvPatients.Rows)
                {
                    row.Cells[colCheck.Index].Value = false;
                }
                _isAllSelectedToggle = false;
                return;
            }

            // Normal case: Delete selected patients
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa {selectedIds.Count} bệnh nhân đã chọn không?", 
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                foreach (var id in selectedIds)
                {
                    var p = _allPatients.FirstOrDefault(x => x.Id == id);
                    if (p != null) _allPatients.Remove(p);
                }
                UpdateChipCounts();
                ApplyFilter();
                MessageBox.Show($"Đã xóa {selectedIds.Count} bệnh nhân thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPatients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
                return;
            }

            string value = Convert.ToString(e.Value);
            Rectangle cell = e.CellBounds;
            bool hovered = e.RowIndex == _hoveredRowIndex;
            Color bg = hovered ? RowHoverBack : Color.White;

            using (var brush = new SolidBrush(bg))
                e.Graphics.FillRectangle(brush, cell);

            if (e.ColumnIndex == colCheck.Index)
            {
                e.PaintContent(cell);
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == colMaBN.Index)
            {
                using (var monoFont = new Font("Consolas", 10F, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, value, monoFont,
                        new Rectangle(cell.X + 14, cell.Y, cell.Width - 16, cell.Height),
                        Color.FromArgb(15, 110, 86),
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == colHoTen.Index)
            {
                using (var boldFont = new Font(dgvPatients.DefaultCellStyle.Font, FontStyle.Bold))
                {
                    TextRenderer.DrawText(e.Graphics, value, boldFont,
                        new Rectangle(cell.X + 14, cell.Y, cell.Width - 18, cell.Height),
                        Color.FromArgb(24, 48, 42),
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == colStatus.Index)
            {
                GetStatusColors(value, out Color back, out Color fore, out Color dot);
                int maxPillW = cell.Width - 16;
                int pillWidth = MeasureStatusPillWidth(e.Graphics, value, maxPillW);
                Rectangle pill = new Rectangle(cell.X + 12, cell.Y + (cell.Height - 30) / 2, pillWidth, 30);
                
                using (var brush = new SolidBrush(back))
                    e.Graphics.FillRoundedRectangle(brush, pill, 14);

                using (var brush = new SolidBrush(dot))
                    e.Graphics.FillEllipse(brush, pill.X + 12, pill.Y + 11, 7, 7);

                var textFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding;
                if (pillWidth < MeasureStatusPillWidth(e.Graphics, value, int.MaxValue))
                    textFlags |= TextFormatFlags.EndEllipsis;

                TextRenderer.DrawText(e.Graphics, value, StatusFont,
                    new Rectangle(pill.X + 24, pill.Y, pill.Width - 28, pill.Height), fore, textFlags);
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == colThaoTac.Index)
            {
                e.Handled = true;

                // Fill background
                using (var brush = new SolidBrush(bg))
                    e.Graphics.FillRectangle(brush, cell);

                int btnH = 28;
                int btnY = cell.Y + (cell.Height - btnH) / 2;

                // Button 1: Chi tiết (10 to 95)
                bool hover1 = (e.RowIndex == _hoveredButtonRowIndex) && (_hoveredButtonIndex == 1);
                Rectangle rect1 = new Rectangle(cell.X + 10, btnY, 85, btnH);
                Color border1 = hover1 ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
                Color back1 = hover1 ? Color.FromArgb(230, 244, 240) : bg;
                Color fore1 = hover1 ? Color.FromArgb(15, 110, 86) : Color.FromArgb(61, 82, 73);

                using (var bBrush = new SolidBrush(back1))
                    e.Graphics.FillRoundedRectangle(bBrush, rect1, 6);
                using (var pen = new Pen(border1))
                    e.Graphics.DrawRoundedRectangle(pen, rect1, 6);

                if (_imgEyeOpen != null)
                {
                    int iconSize = 16;
                    int iconY = btnY + (btnH - iconSize) / 2;
                    int iconX = rect1.X + 8;
                    e.Graphics.DrawImage(_imgEyeOpen, new Rectangle(iconX, iconY, iconSize, iconSize));
                }
                Rectangle rectText1 = new Rectangle(rect1.X + 28, rect1.Y, rect1.Width - 32, rect1.Height);
                TextRenderer.DrawText(e.Graphics, "Chi tiết", dgvPatients.DefaultCellStyle.Font, rectText1, fore1, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                // Button 2: Sửa (105 to 175)
                bool hover2 = (e.RowIndex == _hoveredButtonRowIndex) && (_hoveredButtonIndex == 2);
                Rectangle rect2 = new Rectangle(cell.X + 105, btnY, 70, btnH);
                Color border2 = hover2 ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
                Color back2 = hover2 ? Color.FromArgb(230, 244, 240) : bg;
                Color fore2 = hover2 ? Color.FromArgb(15, 110, 86) : Color.FromArgb(61, 82, 73);

                using (var bBrush = new SolidBrush(back2))
                    e.Graphics.FillRoundedRectangle(bBrush, rect2, 6);
                using (var pen = new Pen(border2))
                    e.Graphics.DrawRoundedRectangle(pen, rect2, 6);

                if (_imgDpv3 != null)
                {
                    int iconSize = 20; // Increased icon size from 16 to 20 for better visibility
                    int iconY2 = btnY + (btnH - iconSize) / 2;
                    int iconX2 = rect2.X + 5;
                    e.Graphics.DrawImage(_imgDpv3, new Rectangle(iconX2, iconY2, iconSize, iconSize));
                }
                Rectangle rectText2 = new Rectangle(rect2.X + 29, rect2.Y, rect2.Width - 33, rect2.Height);
                TextRenderer.DrawText(e.Graphics, "Sửa", dgvPatients.DefaultCellStyle.Font, rectText2, fore2, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                // Button 3: Xóa (185 to 217)
                bool hover3 = (e.RowIndex == _hoveredButtonRowIndex) && (_hoveredButtonIndex == 3);
                Rectangle rect3 = new Rectangle(cell.X + 185, btnY, 32, btnH);
                Color border3 = hover3 ? Color.FromArgb(224, 92, 58) : Color.FromArgb(218, 232, 226);
                Color back3 = hover3 ? Color.FromArgb(254, 233, 230) : bg;
                Color fore3 = Color.FromArgb(168, 42, 20);

                using (var bBrush = new SolidBrush(back3))
                    e.Graphics.FillRoundedRectangle(bBrush, rect3, 6);
                using (var pen = new Pen(border3))
                    e.Graphics.DrawRoundedRectangle(pen, rect3, 6);

                if (_imgBin != null)
                {
                    int iconSize = 16;
                    int iconY3 = btnY + (btnH - iconSize) / 2;
                    int iconX3 = rect3.X + (rect3.Width - iconSize) / 2;
                    e.Graphics.DrawImage(_imgBin, new Rectangle(iconX3, iconY3, iconSize, iconSize));
                }
                else
                {
                    // Fallback to custom GDI+ drawing if image fails to load
                    int tW = 12;
                    int tH = 14;
                    int tX = rect3.X + (rect3.Width - tW) / 2;
                    int tY = rect3.Y + (rect3.Height - tH) / 2;

                    using (var pen = new Pen(fore3, 1.5F))
                    {
                        // Lid horizontal line
                        e.Graphics.DrawLine(pen, tX - 1, tY + 2, tX + tW + 1, tY + 2);
                        // Lid handle (top loop)
                        e.Graphics.DrawLine(pen, tX + 3, tY + 2, tX + 3, tY);
                        e.Graphics.DrawLine(pen, tX + 3, tY, tX + tW - 3, tY);
                        e.Graphics.DrawLine(pen, tX + tW - 3, tY, tX + tW - 3, tY + 2);

                        // Body outline
                        e.Graphics.DrawLine(pen, tX + 1, tY + 2, tX + 2, tY + tH);
                        e.Graphics.DrawLine(pen, tX + tW - 1, tY + 2, tX + tW - 2, tY + tH);
                        e.Graphics.DrawLine(pen, tX + 2, tY + tH, tX + tW - 2, tY + tH);

                        // Inner vertical lines
                        e.Graphics.DrawLine(pen, tX + 4, tY + 5, tX + 4, tY + tH - 3);
                        e.Graphics.DrawLine(pen, tX + tW - 4, tY + 5, tX + tW - 4, tY + tH - 3);
                    }
                }

                return;
            }

            // Normal columns
            TextRenderer.DrawText(e.Graphics, value, dgvPatients.DefaultCellStyle.Font,
                new Rectangle(cell.X + 14, cell.Y, cell.Width - 18, cell.Height),
                Color.FromArgb(61, 82, 73),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private void dgvPatients_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dgvPatients.HitTest(e.X, e.Y);
            if (hit.RowIndex != _hoveredRowIndex)
            {
                int oldHovered = _hoveredRowIndex;
                _hoveredRowIndex = hit.RowIndex;
                if (oldHovered >= 0 && oldHovered < dgvPatients.Rows.Count)
                    dgvPatients.InvalidateRow(oldHovered);
                if (_hoveredRowIndex >= 0 && _hoveredRowIndex < dgvPatients.Rows.Count)
                    dgvPatients.InvalidateRow(_hoveredRowIndex);
            }

            if (hit.ColumnIndex == colThaoTac.Index && hit.RowIndex >= 0)
            {
                Rectangle cellRect = dgvPatients.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, true);
                int rx = e.X - cellRect.X;
                int ry = e.Y - cellRect.Y;

                int btnH = 28;
                int rY1 = (cellRect.Height - btnH) / 2;
                int rY2 = rY1 + btnH;

                int currentBtnIdx = -1;
                if (ry >= rY1 && ry <= rY2)
                {
                    if (rx >= 10 && rx <= 95) currentBtnIdx = 1;
                    else if (rx >= 105 && rx <= 175) currentBtnIdx = 2;
                    else if (rx >= 185 && rx <= 217) currentBtnIdx = 3;
                }

                if (currentBtnIdx != _hoveredButtonIndex || hit.RowIndex != _hoveredButtonRowIndex)
                {
                    int oldRow = _hoveredButtonRowIndex;
                    int oldCol = colThaoTac.Index;

                    _hoveredButtonIndex = currentBtnIdx;
                    _hoveredButtonRowIndex = hit.RowIndex;

                    if (oldRow >= 0 && oldRow < dgvPatients.Rows.Count)
                        dgvPatients.InvalidateCell(oldCol, oldRow);

                    dgvPatients.InvalidateCell(hit.ColumnIndex, hit.RowIndex);
                }
            }
            else
            {
                if (_hoveredButtonIndex != -1)
                {
                    int oldRow = _hoveredButtonRowIndex;
                    int oldCol = colThaoTac.Index;

                    _hoveredButtonIndex = -1;
                    _hoveredButtonRowIndex = -1;

                    if (oldRow >= 0 && oldRow < dgvPatients.Rows.Count)
                        dgvPatients.InvalidateCell(oldCol, oldRow);
                }
            }
        }

        private void dgvPatients_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex >= 0)
            {
                int oldHovered = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                if (oldHovered < dgvPatients.Rows.Count)
                    dgvPatients.InvalidateRow(oldHovered);
            }

            if (_hoveredButtonIndex != -1)
            {
                int oldRow = _hoveredButtonRowIndex;
                int oldCol = colThaoTac.Index;

                _hoveredButtonIndex = -1;
                _hoveredButtonRowIndex = -1;

                if (oldRow >= 0 && oldRow < dgvPatients.Rows.Count)
                    dgvPatients.InvalidateCell(oldCol, oldRow);
            }
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string maBN = Convert.ToString(dgvPatients.Rows[e.RowIndex].Cells[colMaBN.Index].Value);
            var patient = _allPatients.FirstOrDefault(p => p.Id == maBN);
            if (patient == null) return;

            if (e.ColumnIndex == colThaoTac.Index)
            {
                Point clientPoint = dgvPatients.PointToClient(Cursor.Position);
                Rectangle cellRect = dgvPatients.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                int relativeX = clientPoint.X - cellRect.X;

                // Click first button: Chi tiết (X bounds inside cell: 10 to 95)
                if (relativeX >= 10 && relativeX <= 95)
                {
                    ShowDetail(patient);
                }
                // Click second button: Sửa (X bounds inside cell: 105 to 175)
                else if (relativeX >= 105 && relativeX <= 175)
                {
                    var mainEdit = this.FindForm() as Main_DPV;
                    if (mainEdit != null)
                    {
                        mainEdit.NavigateToThemSuaBN();
                    }
                }
                // Click third button: Xóa (X bounds inside cell: 185 to 217)
                else if (relativeX >= 185 && relativeX <= 217)
                {
                    ShowDeleteConfirm(patient);
                }
            }
        }

        private void ShowDeleteConfirm(PatientModel p)
        {
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa bệnh nhân {p.Name} ({p.Id}) không?", 
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _allPatients.Remove(p);
                UpdateChipCounts();
                ApplyFilter();
                MessageBox.Show($"Đã xóa bệnh nhân {p.Name} thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ═══════════════════════════════════════════════
        // ███  CHI TIẾT POPUP — uses frmChiTietBN    ███
        // ═══════════════════════════════════════════════

        private void ShowDetail(PatientModel p)
        {
            _selectedPatient = p;
            using (var frm = new frmChiTietBN(p))
            {
                frm.ShowDialog(this.FindForm());

                // Handle result: navigate to appropriate tab
                switch (frm.Result)
                {
                    case frmChiTietBN.ActionResult.EditPatient:
                        var mainEdit = this.FindForm() as Main_DPV;
                        if (mainEdit != null)
                            mainEdit.NavigateToThemSuaBN();
                        break;
                    case frmChiTietBN.ActionResult.ViewHSBA:
                        var mainHsba = this.FindForm() as Main_DPV;
                        if (mainHsba != null)
                            mainHsba.NavigateToTaoHSBA();
                        break;
                }
            }
        }



        // Helpers
        private static int MeasureStatusPillWidth(Graphics g, string text, int maxWidth)
        {
            int textW = TextRenderer.MeasureText(g, text, StatusFont, Size.Empty,
                TextFormatFlags.NoPadding | TextFormatFlags.SingleLine).Width;
            int needed = textW + StatusPillHorizontalPad;
            return Math.Min(maxWidth, Math.Max(needed, 80));
        }

        private static void GetStatusColors(string status, out Color back, out Color fore, out Color dot)
        {
            back = Color.FromArgb(238, 242, 240);
            fore = Color.FromArgb(122, 149, 137);
            dot = fore;
            switch (status)
            {
                case "Đang điều trị":
                    back = Color.FromArgb(230, 244, 240);
                    fore = dot = Color.FromArgb(15, 110, 86);
                    break;
                case "Chờ xét nghiệm":
                    back = Color.FromArgb(255, 244, 220);
                    fore = dot = Color.FromArgb(230, 126, 34);
                    break;
                case "Cần điều phối KTV":
                    back = Color.FromArgb(253, 236, 234);
                    fore = dot = Color.FromArgb(229, 57, 53);
                    break;
                case "Chờ xuất viện":
                    back = Color.FromArgb(227, 242, 253);
                    fore = dot = Color.FromArgb(25, 118, 210);
                    break;
            }
        }

        private FlowLayoutPanel pnlPagination;
        private List<Guna2Button> _pageButtons = new List<Guna2Button>();

        private void AdjustLayoutSizes()
        {
            // Adjust height of pnlTableCard to fit 10 rows (690px grid + header & footer padding)
            pnlTableCard.Height = 845;

            // Adjust grid height and disable grid scrollbars (handled by the main scroll panel)
            dgvPatients.Height = 690;
            dgvPatients.ScrollBars = ScrollBars.None;

            // Remove native WinForms right/bottom anchors from primary layout panels
            // to bypass the native WinForms AutoScroll anchor layout bug
            pnlFilterBar.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            pnlTableCard.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Setup filter action buttons to use image assets instead of unicode characters
            btnReset.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnReset.Text = "Đặt lại";
            btnReset.Image = DpvAssets.Load("undo (1).png");
            btnReset.ImageSize = new Size(16, 16);
            btnReset.ImageOffset = new Point(0, 0);

            btnExcel.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnExcel.Text = "Xuất Excel";
            btnExcel.Image = DpvAssets.Load("spreadsheet.png");
            btnExcel.ImageSize = new Size(16, 16);
            btnExcel.ImageOffset = new Point(0, 0);

            // Setup DateTimePickers style (RightToLeft to No, so the calendar icon is on the right)
            dtpFrom.RightToLeft = RightToLeft.No;
            dtpTo.RightToLeft = RightToLeft.No;

            // Setup proper column widths & minimum widths to prevent any value clipping
            colCheck.Width = 40;
            colCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            colMaBN.MinimumWidth = 100;
            colMaBN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colHoTen.MinimumWidth = 160;
            colHoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colDob.MinimumWidth = 110;
            colDob.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colGioiTinh.MinimumWidth = 90;
            colGioiTinh.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colKhoa.MinimumWidth = 130;
            colKhoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colBacSi.MinimumWidth = 140;
            colBacSi.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colDate.MinimumWidth = 130;
            colDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colStatus.MinimumWidth = 170;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            colThaoTac.Width = 220;
            colThaoTac.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            // Set grid default style to clean sans-serif
            dgvPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            dgvPatients.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);

            // Add bottom spacer inside pnlScroll to ensure correct scroll margin at the bottom of the page
            var pnlBottomSpacer = new Panel();
            pnlBottomSpacer.BackColor = Color.Transparent;
            pnlBottomSpacer.Location = new Point(27, pnlTableCard.Bottom + 24);
            pnlBottomSpacer.Size = new Size(10, 24);
            pnlScroll.Controls.Add(pnlBottomSpacer);

            // Setup Search glass icon inside textbox
            txtSearch.IconLeft = DpvAssets.Load("magnifying-glass.png");
            txtSearch.IconLeftSize = new Size(16, 16);
            txtSearch.IconLeftOffset = new Point(10, 0);

            // Setup table header buttons anchor
            btnDeleteSelected.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            btnSelectAll.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Setup Table Title Icon (replacing unicode emoji)
            var ptbTableTitleIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            ptbTableTitleIcon.Image = DpvAssets.Load("dpv_2.png");
            ptbTableTitleIcon.Size = new Size(22, 22);
            ptbTableTitleIcon.Location = new Point(20, 17);
            ptbTableTitleIcon.SizeMode = PictureBoxSizeMode.Zoom;
            pnlTableCard.Controls.Add(ptbTableTitleIcon);

            lblTableTitle.Text = "Danh sách bệnh nhân";
            lblTableTitle.Location = new Point(48, 18);

            // Trigger initial resize calculation
            ucDanhSachBN_Resize(null, null);
        }

        private void SetupPaginationControls()
        {
            // Remove the legacy labels and prev/next buttons from pnlTableCard
            pnlTableCard.Controls.Remove(lblPageInfo);
            pnlTableCard.Controls.Remove(btnPrevPage);
            pnlTableCard.Controls.Remove(btnNextPage);

            // Create right-aligned FlowLayoutPanel for pagination controls
            pnlPagination = new FlowLayoutPanel();
            pnlPagination.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlPagination.Size = new Size(500, 40);
            pnlPagination.Location = new Point(pnlTableCard.Width - 500 - 21, pnlTableCard.Height - 40 - 15);
            pnlPagination.FlowDirection = FlowDirection.LeftToRight;
            pnlPagination.WrapContents = false;
            pnlPagination.BackColor = Color.Transparent;

            // Align page info label vertically — use same height & margin as buttons
            // so they occupy the exact same vertical space in the FlowLayoutPanel
            lblPageInfo.AutoSize = false;
            lblPageInfo.Size = new Size(90, 36);  // Same height as buttons (36px)
            lblPageInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblPageInfo.ForeColor = Color.FromArgb(122, 149, 137);
            lblPageInfo.TextAlign = ContentAlignment.MiddleLeft;
            lblPageInfo.Margin = new Padding(0, 2, 8, 2); // Same top/bottom margin as buttons

            StylePageButton(btnPrevPage, "<");
            StylePageButton(btnNextPage, ">");

            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(btnPrevPage);

            // Generate page numbers 1 through 5 (dynamic clicking logic)
            _pageButtons.Clear();
            for (int i = 0; i < 5; i++)
            {
                var btn = new Guna2Button();
                StylePageButton(btn, "");
                btn.Click += (s, e) => {
                    if (s is Guna2Button clickBtn && int.TryParse(clickBtn.Text, out int pageNum))
                    {
                        ChangePage(pageNum);
                    }
                };
                _pageButtons.Add(btn);
                pnlPagination.Controls.Add(btn);
            }

            pnlPagination.Controls.Add(btnNextPage);
            pnlTableCard.Controls.Add(pnlPagination);
        }

        private void StylePageButton(Guna2Button btn, string text)
        {
            btn.Size = new Size(36, 36);
            btn.Margin = new Padding(3, 2, 3, 2);
            btn.BorderRadius = 6;
            btn.BorderThickness = 1;
            btn.BorderColor = Color.FromArgb(218, 232, 226); // #D8E8E3
            btn.FillColor = Color.Transparent;
            
            // Set slightly larger font for mathematical arrows "<" and ">" to center them perfectly
            if (text == "<" || text == ">")
            {
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }
            else
            {
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            
            btn.ForeColor = Color.FromArgb(74, 98, 89);
            btn.Text = text;
            btn.Cursor = Cursors.Hand;
            btn.TextOffset = new Point(0, 0);

            // Configure Guna2 disabled state colors to keep background transparent instead of gray fill
            btn.DisabledState.FillColor = Color.Transparent;
            btn.DisabledState.BorderColor = Color.FromArgb(218, 232, 226);
            btn.DisabledState.ForeColor = Color.FromArgb(180, 200, 190);

            btn.HoverState.FillColor = Color.FromArgb(15, 110, 86); // teal
            btn.HoverState.ForeColor = Color.White;
            btn.HoverState.BorderColor = Color.FromArgb(15, 110, 86);
        }

        private void ChangePage(int page)
        {
            if (page >= 1 && page <= _totalPage)
            {
                _currentPage = page;
                RenderGrid();
            }
        }

        private void UpdatePaginationUI()
        {
            if (_pageButtons == null || _pageButtons.Count < 5) return;

            lblPageInfo.Text = $"Trang {_currentPage} / {_totalPage}";

            // Calculate start page for sliding window to support arbitrary number of pages
            int startPage = 1;
            if (_totalPage > 5)
            {
                startPage = _currentPage - 2;
                if (startPage < 1) startPage = 1;
                if (startPage + 4 > _totalPage) startPage = _totalPage - 4;
            }

            // Toggle visibility, text, and selection for page buttons
            for (int i = 0; i < 5; i++)
            {
                int pageNum = startPage + i;
                var btn = _pageButtons[i];

                if (pageNum <= _totalPage)
                {
                    btn.Visible = true;
                    btn.Text = pageNum.ToString();
                    if (pageNum == _currentPage)
                    {
                        btn.FillColor = Color.FromArgb(15, 110, 86); // teal
                        btn.ForeColor = Color.White;
                        btn.BorderColor = Color.FromArgb(15, 110, 86);
                    }
                    else
                    {
                        btn.FillColor = Color.Transparent;
                        btn.ForeColor = Color.FromArgb(74, 98, 89);
                        btn.BorderColor = Color.FromArgb(218, 232, 226);
                    }
                }
                else
                {
                    btn.Visible = false;
                }
            }

            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPage;

            btnPrevPage.ForeColor = btnPrevPage.Enabled ? Color.FromArgb(74, 98, 89) : Color.FromArgb(180, 200, 190);
            btnNextPage.ForeColor = btnNextPage.Enabled ? Color.FromArgb(74, 98, 89) : Color.FromArgb(180, 200, 190);
        }

        private void ucDanhSachBN_Resize(object sender, EventArgs e)
        {
            int targetWidth = pnlScroll.ClientSize.Width - 54;
            if (targetWidth < 1350) targetWidth = 1350; // Prevent layouts from shrinking below minimum readable content width

            pnlFilterBar.Width = targetWidth;
            pnlTableCard.Width = targetWidth;
            if (pnlPagination != null)
            {
                pnlPagination.Location = new Point(pnlTableCard.Width - pnlPagination.Width - 21, pnlTableCard.Height - pnlPagination.Height - 15);
            }

            // Position buttons consecutively with a balanced 12px gap from the "Đến ngày" date picker
            btnReset.Width = 110;
            btnReset.Location = new Point(dtpTo.Right + 12, 44);

            btnExcel.Width = 130;
            btnExcel.Location = new Point(btnReset.Right + 12, 44);

            // Dynamically position table card buttons on the top right
            btnDeleteSelected.Width = 165;
            btnDeleteSelected.Location = new Point(pnlTableCard.Width - btnDeleteSelected.Width - 21, 15);

            btnSelectAll.Width = 150;
            btnSelectAll.Location = new Point(btnDeleteSelected.Left - btnSelectAll.Width - 12, 15);
        }

        private void UpdateChipStyles()
        {
            // Reset all to standard outline styles
            btnChipAll.FillColor = Color.White;
            btnChipAll.ForeColor = Color.FromArgb(15, 110, 86);
            btnChipAll.BorderColor = Color.FromArgb(15, 110, 86);
            btnChipAll.BorderThickness = 1;
            btnChipAll.BorderRadius = 18;

            btnChipActive.FillColor = Color.FromArgb(232, 248, 241); // #E8F8F1
            btnChipActive.ForeColor = Color.FromArgb(26, 122, 74); // #1A7A4A
            btnChipActive.BorderColor = Color.FromArgb(26, 122, 74);
            btnChipActive.BorderThickness = 1;
            btnChipActive.BorderRadius = 18;

            btnChipPending.FillColor = Color.FromArgb(255, 247, 230); // #FFF7E6
            btnChipPending.ForeColor = Color.FromArgb(176, 118, 0); // #B07600
            btnChipPending.BorderColor = Color.FromArgb(176, 118, 0);
            btnChipPending.BorderThickness = 1;
            btnChipPending.BorderRadius = 18;

            btnChipUrgent.FillColor = Color.FromArgb(254, 233, 230); // #FEE9E6
            btnChipUrgent.ForeColor = Color.FromArgb(168, 42, 20); // #A82A14
            btnChipUrgent.BorderColor = Color.FromArgb(224, 92, 58); // #E05C3A (var(--accent2))
            btnChipUrgent.BorderThickness = 1;
            btnChipUrgent.BorderRadius = 18;

            // Style the currently active selected chip as solid teal
            Guna2Button activeBtn = null;
            if (_activeChipStatus == "all") activeBtn = btnChipAll;
            else if (_activeChipStatus == "active") activeBtn = btnChipActive;
            else if (_activeChipStatus == "pending") activeBtn = btnChipPending;
            else if (_activeChipStatus == "urgent") activeBtn = btnChipUrgent;

            if (activeBtn != null)
            {
                activeBtn.FillColor = Color.FromArgb(15, 110, 86); // var(--teal)
                activeBtn.ForeColor = Color.White;
                activeBtn.BorderColor = Color.FromArgb(15, 110, 86);
            }
        }

        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalizedString)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC).ToLower();
        }
    }

    public class PatientModel
    {
        public static readonly System.Collections.Generic.List<PatientModel> SharedPatients = new System.Collections.Generic.List<PatientModel>();

        static PatientModel()
        {
            InitializeSharedPatients();
        }

        public static void InitializeSharedPatients()
        {
            if (SharedPatients.Count > 0) return;

            // Initial 10 patients from HTML template
            var seed = new System.Collections.Generic.List<PatientModel>
            {
                new PatientModel { Id = "BN240001", Name = "Nguyễn Văn An", Dob = "15/03/1978", Gender = "Nam", Khoa = "Tim mạch", Bs = "BS. Trần Minh", Date = "24/05/2026", Status = "active", StatusLabel = "Đang điều trị", Cccd = "079204001234" },
                new PatientModel { Id = "BN240002", Name = "Phạm Thị Lan", Dob = "22/07/1985", Gender = "Nữ", Khoa = "Nội tổng quát", Bs = "BS. Lê Hùng", Date = "24/05/2026", Status = "pending", StatusLabel = "Chờ xét nghiệm", Cccd = "079285002345" },
                new PatientModel { Id = "BN240003", Name = "Hoàng Đức Nam", Dob = "09/11/1990", Gender = "Nam", Khoa = "Chỉnh hình", Bs = "BS. Nguyễn Hà", Date = "23/05/2026", Status = "urgent", StatusLabel = "Cần điều phối KTV", Cccd = "079290003456" },
                new PatientModel { Id = "BN240004", Name = "Trần Thị Mai", Dob = "30/01/1996", Gender = "Nữ", Khoa = "Sản khoa", Bs = "BS. Võ Thu", Date = "23/05/2026", Status = "done", StatusLabel = "Chờ xuất viện", Cccd = "079296004567" },
                new PatientModel { Id = "BN240005", Name = "Lê Văn Hải", Dob = "12/06/1972", Gender = "Nam", Khoa = "Thần kinh", Bs = "BS. Phạm Sơn", Date = "22/05/2026", Status = "active", StatusLabel = "Đang điều trị", Cccd = "079272005678" },
                new PatientModel { Id = "BN240006", Name = "Vũ Thị Bích", Dob = "07/09/2000", Gender = "Nữ", Khoa = "Nội tổng quát", Bs = "BS. Lê Hùng", Date = "22/05/2026", Status = "active", StatusLabel = "Đang điều trị", Cccd = "079200006789" },
                new PatientModel { Id = "BN240007", Name = "Đinh Công Sơn", Dob = "14/04/1965", Gender = "Nam", Khoa = "Tim mạch", Bs = "BS. Trần Minh", Date = "21/05/2026", Status = "urgent", StatusLabel = "Cần điều phối KTV", Cccd = "079265007890" },
                new PatientModel { Id = "BN240008", Name = "Ngô Thị Hằng", Dob = "28/12/1982", Gender = "Nữ", Khoa = "Nhi khoa", Bs = "BS. Hồ Linh", Date = "21/05/2026", Status = "pending", StatusLabel = "Chờ xét nghiệm", Cccd = "079282008901" },
                new PatientModel { Id = "BN240009", Name = "Lương Minh Châu", Dob = "05/02/1958", Gender = "Nam", Khoa = "Nội tổng quát", Bs = "BS. Lê Hùng", Date = "20/05/2026", Status = "active", StatusLabel = "Đang điều trị", Cccd = "079258009012" },
                new PatientModel { Id = "BN240010", Name = "Đặng Thị Yến", Dob = "19/08/1993", Gender = "Nữ", Khoa = "Chỉnh hình", Bs = "BS. Nguyễn Hà", Date = "20/05/2026", Status = "done", StatusLabel = "Chờ xuất viện", Cccd = "079293010123" }
            };

            SharedPatients.AddRange(seed);

            // Generate additional records to make it total 48 patients (exactly like the HTML spec "48 patients total")
            string[] firstNames = { "Nguyễn", "Trần", "Lê", "Phạm", "Hoàng", "Huỳnh", "Phan", "Vũ", "Võ", "Đặng" };
            string[] middleNames = { "Văn", "Thị", "Hữu", "Minh", "Đức", "Thành", "Hoài", "Quốc", "Xuân", "Mỹ" };
            string[] lastNames = { "Anh", "Bình", "Cường", "Dương", "Giang", "Hương", "Khánh", "Linh", "Nam", "Phong", "Sơn", "Trang", "Vy", "Yến" };
            string[] departments = { "Tim mạch", "Nội tổng quát", "Chỉnh hình", "Sản khoa", "Thần kinh", "Nhi khoa" };
            string[] doctors = { "BS. Trần Minh", "BS. Lê Hùng", "BS. Nguyễn Hà", "BS. Võ Thu", "BS. Phạm Sơn", "BS. Hồ Linh" };
            string[] statuses = { "active", "pending", "urgent", "done" };
            string[] statusLabels = { "Đang điều trị", "Chờ xét nghiệm", "Cần điều phối KTV", "Chờ xuất viện" };
            System.Random rand = new System.Random(42);

            for (int i = 11; i <= 48; i++)
            {
                string id = $"BN24{i:D4}";
                string gender = rand.Next(2) == 0 ? "Nam" : "Nữ";
                string name = firstNames[rand.Next(firstNames.Length)] + " " +
                              (gender == "Nữ" ? "Thị" : middleNames[rand.Next(middleNames.Length)]) + " " +
                              lastNames[rand.Next(lastNames.Length)];
                int age = rand.Next(18, 80);
                string dob = $"{rand.Next(1, 29):D2}/{rand.Next(1, 13):D2}/{System.DateTime.Now.Year - age}";
                string dept = departments[rand.Next(departments.Length)];
                string doc = doctors[rand.Next(doctors.Length)];
                int statusIdx = rand.Next(statuses.Length);
                string status = statuses[statusIdx];
                string statusLabel = statusLabels[statusIdx];
                string date = $"{rand.Next(1, 25):D2}/05/2026";
                string cccd = $"079{rand.Next(100, 300):D3}{rand.Next(100000, 999999):D6}";

                SharedPatients.Add(new PatientModel
                {
                    Id = id,
                    Name = name,
                    Dob = dob,
                    Gender = gender,
                    Khoa = dept,
                    Bs = doc,
                    Date = date,
                    Status = status,
                    StatusLabel = statusLabel,
                    Cccd = cccd
                });
            }
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Khoa { get; set; }
        public string Bs { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public string StatusLabel { get; set; }
        public string Cccd { get; set; }
    }
}

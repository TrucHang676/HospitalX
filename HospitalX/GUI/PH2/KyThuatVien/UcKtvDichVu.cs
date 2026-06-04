using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class UcKtvDichVu : UserControl
    {
        // 1. Controls bộ lọc (Filter controls)
        // 2. Thống kê nhanh (Status strip cards)
        private readonly Guna2Panel[] stripCards = new Guna2Panel[4];
        private readonly Label[] lblStripVals = new Label[4];
        private readonly Label[] lblStripLabels = new Label[4];
        private readonly Guna2Panel[] stripDots = new Guna2Panel[4];

        private readonly Label[] lblStatTrends = new Label[3];
        private readonly Label[] lblStatTrendsVal = new Label[4];
        private readonly Label[] lblStatTrendsTxt = new Label[4];

        // 3. Bảng dữ liệu chính (Main Grid Card)

        // 4. Phân trang (Pagination)
        private Label lblDrawerTitle;
        private Guna2Button btnCloseDrawer;
        private Timer tmrDrawer;
        private int drawerTargetX = 0;
        private bool isDrawerOpening = true;
        private Label lblDName;
        private Label lblDId;
        private Label lblDSvc;
        private Label lblDTime;
        private Label lblDStatus;
        private string activeRecordId = "";
        private string activeServiceName = "";

        // 5. Drawer thông tin chi tiết trượt bên phải (Right-sliding detail drawer)
        // Dữ liệu nội bộ
        private readonly List<KtvService> allServices = new List<KtvService>();
        private string currentTab = "all";
        private string sortColumnName = "colTime";
        private bool sortAscending = true;
        private bool isDrawerBuilt = false;

        public UcKtvDichVu()
        {
            InitializeComponent();
            Disposed += UcKtvDichVu_Disposed;

            if (IsInDesigner())
            {
                return;
            }

            BackColor = Color.FromArgb(244, 247, 250); // Sleek modern background matching doctor portal #F4F7FA
            DoubleBuffered = true;
            this.AutoScroll = false; // Disable page auto-scroll to fix horizontal scroll-wheel bug

            // Link stripCards to designer-generated cards
            stripCards[0] = this.cardStat1;
            stripCards[1] = this.cardStat2;
            stripCards[2] = this.cardStat3;
            stripCards[3] = this.cardStat4;
            this.cardStat4.Visible = false;

            lblStripVals[0] = this.lblStat1Value;
            lblStripVals[1] = this.lblStat2Value;
            lblStripVals[2] = this.lblStat3Value;
            lblStripVals[3] = this.lblStat4Value;

            lblStripLabels[0] = this.lblStat1Title;
            lblStripLabels[1] = this.lblStat2Title;
            lblStripLabels[2] = this.lblStat3Title;
            lblStripLabels[3] = this.lblStat4Title;

            stripDots[0] = this.dotStat1;
            stripDots[1] = this.dotStat2;
            stripDots[2] = this.dotStat3;
            stripDots[3] = this.dotStat4;

            lblStatTrendsVal[0] = this.lblStat1TrendValue;
            lblStatTrendsVal[1] = this.lblStat2TrendValue;
            lblStatTrendsVal[2] = this.lblStat3TrendValue;
            lblStatTrendsVal[3] = this.lblStat4TrendValue;

            lblStatTrendsTxt[0] = this.lblStat1TrendText;
            lblStatTrendsTxt[1] = this.lblStat2TrendText;
            lblStatTrendsTxt[2] = this.lblStat3TrendText;
            lblStatTrendsTxt[3] = this.lblStat4TrendText;

            BuildControls();
            LoadRows();

            this.Resize += UcKtvDichVu_Resize;
        }

        private void UcKtvDichVu_Disposed(object sender, EventArgs e)
        {
            if (tmrDrawer != null)
            {
                tmrDrawer.Stop();
                tmrDrawer.Tick -= TmrDrawer_Tick;
                tmrDrawer.Dispose();
                tmrDrawer = null;
            }
        }

        private bool IsInDesigner()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime
                || DesignMode
                || processName.Equals("devenv", StringComparison.OrdinalIgnoreCase)
                || processName.Equals("XDesProc", StringComparison.OrdinalIgnoreCase);
        }

        private void UcKtvDichVu_Resize(object sender, EventArgs e)
        {
            if (IsInDesigner()) return;
            LayoutControls();
        }

        private void BuildControls()
        {
            if (IsInDesigner()) return;

            // 2. Setup 3 premium KPI Cards
            string[] statLbls = { "TỔNG DỊCH VỤ", "CHỜ THỰC HIỆN", "HOÀN THÀNH" };
            string[] statEmojis = { "📋", "⏳", "✅" };
            Color[] accents = {
                Color.FromArgb(15, 110, 86),   // Deep Teal
                Color.FromArgb(255, 179, 0),   // Amber
                Color.FromArgb(229, 57, 53)    // Red
            };
            Color[] iconBgs = {
                Color.FromArgb(230, 244, 240),
                Color.FromArgb(255, 248, 225),
                Color.FromArgb(253, 244, 244)
            };
            Color[] trendColors = {
                Color.FromArgb(15, 110, 86),
                Color.FromArgb(160, 112, 0),
                Color.FromArgb(229, 57, 53)
            };
            string[] trends = { "Trong ca trực", "Cần nhập KQ", "Đã hoàn thành" };

            for (int i = 0; i < 3; i++)
            {
                var card = stripCards[i];
                card.ShadowDecoration.Enabled = false;
                card.BorderThickness = 1;
                card.BorderColor = Color.FromArgb(218, 232, 226);
                card.BorderRadius = 14;
                card.FillColor = Color.White;
                card.Padding = new Padding(0, 4, 0, 0);
                card.Tag = accents[i];

                // card.Paint -= KpiCard_Paint;
                // card.Paint += KpiCard_Paint;

                // Setup dynamic icon box only if not present
                string pnlIconName = $"pnlIcon_{i}";
                Guna2Panel pnlIcon = card.Controls.Find(pnlIconName, true).FirstOrDefault() as Guna2Panel;
                if (pnlIcon == null)
                {
                    pnlIcon = new Guna2Panel
                    {
                        Name = pnlIconName,
                        Size = new Size(36, 36),
                        Location = new Point(18, 14),
                        BorderRadius = 10,
                        FillColor = iconBgs[i],
                        BackColor = Color.Transparent
                    };
                    pnlIcon.UseTransparentBackground = true;
                    var lblEmoji = new Label
                    {
                        Text = statEmojis[i],
                        Name = "lblEmoji",
                        Dock = DockStyle.Fill,
                        Font = new Font("Segoe UI", 11F),
                        TextAlign = ContentAlignment.MiddleCenter,
                        BackColor = Color.Transparent
                    };
                    pnlIcon.Controls.Add(lblEmoji);
                    card.Controls.Add(pnlIcon);
                }

                // Configure style of static labels
                if (lblStripLabels[i] != null)
                {
                    lblStripLabels[i].ForeColor = Color.FromArgb(122, 149, 137);
                    lblStripLabels[i].Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
                }
                if (lblStripVals[i] != null)
                {
                    lblStripVals[i].ForeColor = Color.FromArgb(24, 48, 42);
                    lblStripVals[i].Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                }
                if (lblStatTrendsTxt[i] != null)
                {
                    lblStatTrendsTxt[i].ForeColor = trendColors[i];
                    lblStatTrendsTxt[i].Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }
                if (lblStatTrendsVal[i] != null)
                {
                    lblStatTrendsVal[i].ForeColor = trendColors[i];
                    lblStatTrendsVal[i].Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                }

                if (stripDots[i] != null)
                {
                    stripDots[i].Visible = false;
                }

                // ConfigureKpiHover(card);
            }

            // Timer cho slide drawer mượt mà
            tmrDrawer = new Timer { Interval = 15 };
            tmrDrawer.Tick += TmrDrawer_Tick; // Wire up tick handler!

            if (!Controls.Contains(pnlOverlay))
            {
                Controls.Add(pnlOverlay);
            }

            if (!Controls.Contains(pnlDrawer))
            {
                Controls.Add(pnlDrawer);
            }

            pnlOverlay.Paint += PnlOverlay_Paint;

            // Set default selected index to "Tất cả trạng thái" (index 0)
            cboStatus.SelectedIndex = 0;

            // Wire up event handlers to designer-generated controls
            txtSearch.TextChanged += (s, e) => FilterAndLoadGrid();
            cboStatus.SelectedIndexChanged += (s, e) => FilterAndLoadGrid();

            btnReset.Click += (s, e) =>
            {
                txtSearch.Clear();
                cboStatus.SelectedIndex = 0;
                SwitchTab(btnTabAll, "all");
            };

            btnTabAll.Click += (s, e) => SwitchTab((Guna2Button)s, "all");
            btnTabPending.Click += (s, e) => SwitchTab((Guna2Button)s, "pending");
            btnTabDone.Click += (s, e) => SwitchTab((Guna2Button)s, "done");

            // Setup dgv columns (since designer doesn't have them pre-configured)
            dgv.Columns.Clear();
            dgv.Columns.Add("colIndex", "STT");
            dgv.Columns.Add("colPatient", "Bệnh nhân");
            dgv.Columns.Add("colService", "Dịch vụ (LOAIDV)");
            dgv.Columns.Add("colMaHsba", "Mã HSBA");   // MAHSBA từ HSBA_DV
            dgv.Columns.Add("colTime", "Ngày DV");   // NGAYDV
            dgv.Columns.Add("colStatus", "Trạng thái");
            dgv.Columns.Add("colAction", "Thao tác");

            // Columns widths
            dgv.Columns["colIndex"].FillWeight = 8;
            dgv.Columns["colPatient"].FillWeight = 30;
            dgv.Columns["colService"].FillWeight = 30;
            dgv.Columns["colMaHsba"].FillWeight = 18;
            dgv.Columns["colTime"].FillWeight = 18;
            dgv.Columns["colStatus"].FillWeight = 20;
            dgv.Columns["colAction"].FillWeight = 28;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            // Hidden value columns
            dgv.Columns.Add("colPatientVal", "");
            dgv.Columns.Add("colRecordId", "");
            dgv.Columns.Add("colServiceVal", "");
            dgv.Columns.Add("colStatusVal", "");

            dgv.Columns["colPatientVal"].Visible = false;
            dgv.Columns["colRecordId"].Visible = false;
            dgv.Columns["colServiceVal"].Visible = false;
            dgv.Columns["colStatusVal"].Visible = false;

            dgv.CellPainting += Dgv_CellPainting;
            dgv.CellClick += Dgv_CellClick;
            dgv.ColumnHeaderMouseClick += Dgv_ColumnHeaderMouseClick;
            dgv.MouseMove += Dgv_MouseMove;
            dgv.MouseLeave += (s, e) => { dgv.Cursor = Cursors.Default; hoveredRowIndex = -1; dgv.Invalidate(); };

            // Ultra-premium smooth row enter/leave hover tracking
            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex != hoveredRowIndex)
                {
                    int oldIndex = hoveredRowIndex;
                    hoveredRowIndex = e.RowIndex;
                    if (oldIndex >= 0) dgv.InvalidateRow(oldIndex);
                    dgv.InvalidateRow(hoveredRowIndex);
                }
            };
            dgv.CellMouseLeave += (s, e) =>
            {
                if (hoveredRowIndex >= 0)
                {
                    int oldIndex = hoveredRowIndex;
                    hoveredRowIndex = -1;
                    dgv.InvalidateRow(oldIndex);
                }
            };

            // Setup drawer and details components
            BuildDrawerComponents();

            // Setup pagination clicks
            btnPrev.Click += (s, e) => { /* Pagination logic if any */ };
            btnNext.Click += (s, e) => { /* Pagination logic if any */ };
            btnPage1.Click += (s, e) => { /* Pagination logic if any */ };

            // Apply premium style configurations to buttons dynamically (to keep custom CheckedState/HoverState active)
            ConfigureTabButton(btnTabAll);
            ConfigureTabButton(btnTabPending);
            ConfigureTabButton(btnTabDone);

            ConfigurePageButton(btnPrev, false);
            ConfigurePageButton(btnPage1, true);
            ConfigurePageButton(btnNext, false);
        }

        private void LayoutControls()
        {
            if (IsInDesigner()) return;
            int margin = 28;
            int gap = 20;

            int availWidth = this.Width - 2 * margin;
            if (availWidth < 400) return;

            // 1. Layout bộ lọc
            pnlFilter.Location = new Point(margin, margin);
            pnlFilter.Size = new Size(availWidth, 72);

            txtSearch.Location = new Point(18, 18);
            txtSearch.Size = new Size((int)(availWidth * 0.52f), 36);

            cboStatus.Location = new Point(txtSearch.Right + 18, 18);
            cboStatus.Size = new Size((int)(availWidth * 0.22f), 36);

            btnReset.Location = new Point(availWidth - 138, 18);
            btnReset.Size = new Size(120, 36);

            // 2. Layout thống kê
            int stripWidth = (availWidth - 2 * gap) / 3;
            int stripY = pnlFilter.Bottom + gap;

            for (int i = 0; i < 3; i++)
            {
                stripCards[i].Location = new Point(margin + i * (stripWidth + gap), stripY);
                stripCards[i].Size = new Size(stripWidth, 140);
                stripDots[i].Location = new Point(22, 46);

                foreach (Control ctrl in stripCards[i].Controls)
                {
                    if (ctrl is FlowLayoutPanel flp)
                    {
                        flp.Width = stripWidth - 76;
                    }
                }
            }

            // 3. Layout Bảng biểu chính
            int tableY = stripCards[0].Bottom + gap;
            int tableHeight = this.Height - tableY - margin;
            if (tableHeight < 300) tableHeight = 440;

            pnlTableCard.Location = new Point(margin, tableY);
            pnlTableCard.Size = new Size(availWidth, tableHeight);

            pnlTabBar.Width = availWidth - 2;

            dgv.Location = new Point(20, 60);
            dgv.Size = new Size(availWidth - 40, tableHeight - 60 - 44);

            pnlPagination.Location = new Point(1, tableHeight - 45);
            pnlPagination.Width = availWidth - 2;

            btnNext.Location = new Point(availWidth - 48, 8);
            btnPage1.Location = new Point(availWidth - 84, 8);
            btnPrev.Location = new Point(availWidth - 120, 8);

            // Layout Drawer trượt bên phải
            pnlOverlay.Size = new Size(this.Width, this.Height);
            pnlDrawer.Height = this.Height;
            pnlDrawer.Location = new Point(this.Width, 0);
            pnlDrawer.Controls[1].Height = this.Height - 68 - 68; // pnlDrawerBody
            pnlDrawer.Controls[2].Location = new Point(0, this.Height - 68); // pnlDrawerFooter
        }

        private void LoadRows()
        {
            if (IsInDesigner()) return;
            allServices.Clear();
            allServices.AddRange(KtvData.Services());

            FilterAndLoadGrid();
        }

        private void FilterAndLoadGrid()
        {
            if (IsInDesigner()) return;
            var query = allServices.AsEnumerable();

            // Lọc theo Tab hiện tại
            if (currentTab == "pending") query = query.Where(x => x.Status == "Chờ thực hiện");
            else if (currentTab == "done") query = query.Where(x => x.Status == "Hoàn thành");

            // Lọc theo ô tìm kiếm — tìm theo TENBN, MAHSBA, LOAIDV (các trường thực có trong DB)
            string q = txtSearch.Text.Trim().ToLowerInvariant();
            if (q.Length > 0)
            {
                query = query.Where(x => x.Patient.ToLowerInvariant().Contains(q) ||
                                         x.MaHsba.ToLowerInvariant().Contains(q) ||
                                         x.Service.ToLowerInvariant().Contains(q));
            }

            // Lọc theo ComboBox Trạng thái
            if (cboStatus.SelectedIndex > 0)
            {
                query = query.Where(x => x.Status == cboStatus.SelectedItem.ToString());
            }

            query = ApplySort(query);
            var list = query.ToList();

            // Đổ dữ liệu vào bảng DataGridView sạch sẽ
            dgv.Rows.Clear();
            int idx = 1;
            foreach (var item in list)
            {
                dgv.Rows.Add(
                    idx++,
                    item.Patient,          // Bệnh nhân — TENBN
                    item.Service,          // Dịch vụ — LOAIDV
                    item.MaHsba,           // Mã HSBA — MAHSBA (thay cho Doctor)
                    item.NgayDv,           // Ngày DV — NGAYDV
                    item.Status,           // Trạng thái — dẫn xuất từ KETQUA
                    "Chi tiết",
                    item.Patient,          // colPatientVal (hidden)
                    item.MaHsba,           // colRecordId (hidden) — dùng làm RecordId
                    item.Service,          // colServiceVal (hidden)
                    item.Status            // colStatusVal (hidden)
                );
            }

            // Tính toán nhanh số lượng cho Tabs và Stats
            int total = allServices.Count;
            int pending = allServices.Count(x => x.Status == "Chờ thực hiện");
            int done = allServices.Count(x => x.Status == "Hoàn thành");

            lblStripVals[0].Text = total.ToString();
            lblStatTrendsVal[0].Text = "";

            lblStripVals[1].Text = pending.ToString();
            lblStatTrendsVal[1].Text = "";
            lblStatTrendsTxt[1].Text = pending > 0 ? "Cần nhập KQ" : "Đã xong";

            lblStripVals[2].Text = done.ToString();
            lblStatTrendsVal[2].Text = "";

            btnTabAll.Text = $"Tất cả ({total})";
            btnTabPending.Text = $"Chờ thực hiện ({pending})";
            btnTabDone.Text = $"Hoàn thành ({done})";

            lblPageInfo.Text = $"Hiển thị {list.Count} / {list.Count} dịch vụ";
        }

        private IEnumerable<KtvService> ApplySort(IEnumerable<KtvService> query)
        {
            Func<KtvService, object> keySelector;
            switch (sortColumnName)
            {
                case "colIndex":
                case "colTime":
                    keySelector = x => x.NgayDv;
                    break;
                case "colPatient":
                    keySelector = x => x.Patient;
                    break;
                case "colService":
                    keySelector = x => x.Service;
                    break;
                case "colMaHsba":
                    keySelector = x => x.MaHsba;
                    break;
                case "colStatus":
                    keySelector = x => StatusRank(x.Status);
                    break;
                default:
                    keySelector = x => x.NgayDv;
                    break;
            }

            return sortAscending ? query.OrderBy(keySelector) : query.OrderByDescending(keySelector);
        }

        private int StatusRank(string status)
        {
            if (status == "Chá»  thá»±c hiá»‡n" || status == "Chờ thực hiện") return 0;
            return 1;
        }

        private void SwitchTab(Guna2Button activeBtn, string tab)
        {
            btnTabAll.Checked = false;
            btnTabPending.Checked = false;
            btnTabDone.Checked = false;

            activeBtn.Checked = true;
            currentTab = tab;
            FilterAndLoadGrid();
        }

        private int hoveredRowIndex = -1;

        private void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                PaintGridHeader(e);
                return;
            }

            Rectangle cell = e.CellBounds;

            // Draw ultra-premium custom background based on selected / hovered state
            bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
            bool isHovered = e.RowIndex == hoveredRowIndex;

            Color rowBg = Color.White;
            if (isSelected) rowBg = Color.FromArgb(235, 246, 243); // Soft selected teal
            else if (isHovered) rowBg = Color.FromArgb(246, 252, 250); // Soft hovered light-teal

            using (var brush = new SolidBrush(rowBg))
            {
                e.Graphics.FillRectangle(brush, cell);
            }

            // Draw horizontal bottom border
            using (var pen = new Pen(Color.FromArgb(238, 242, 240)))
            {
                e.Graphics.DrawLine(pen, cell.X, cell.Bottom - 1, cell.Right, cell.Bottom - 1);
            }

            string value = e.Value != null ? e.Value.ToString() : "";

            // 1. Vẽ cột Bệnh nhân (Tên in đậm 9.8F, Mã ID in nhạt 8.5F)
            if (e.ColumnIndex == dgv.Columns["colPatient"].Index)
            {
                string name = dgv.Rows[e.RowIndex].Cells["colPatientVal"].Value.ToString();
                string id = dgv.Rows[e.RowIndex].Cells["colRecordId"].Value.ToString();

                TextRenderer.DrawText(e.Graphics, name, new Font("Segoe UI", 9.8F, FontStyle.Bold), new Rectangle(cell.X + 12, cell.Y + 10, cell.Width - 16, 22), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                TextRenderer.DrawText(e.Graphics, id, new Font("Segoe UI", 8.5F), new Rectangle(cell.X + 12, cell.Y + 34, cell.Width - 16, 18), Color.FromArgb(136, 152, 170), TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                e.Handled = true;
                return;
            }

            // 2. Vẽ cột Dịch vụ (Tên dịch vụ 9.8F, căn giữa theo chiều dọc)
            if (e.ColumnIndex == dgv.Columns["colService"].Index)
            {
                string service = dgv.Rows[e.RowIndex].Cells["colServiceVal"].Value.ToString();

                TextRenderer.DrawText(e.Graphics, service, new Font("Segoe UI", 9.8F, FontStyle.Bold), new Rectangle(cell.X + 12, cell.Y, cell.Width - 16, cell.Height), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

                e.Handled = true;
                return;
            }

            // 3. Vẽ cột trạng thái pill badge bo tròn sang xịn
            if (e.ColumnIndex == dgv.Columns["colStatus"].Index)
            {
                string status = dgv.Rows[e.RowIndex].Cells["colStatusVal"].Value.ToString();
                Color bg = Color.FromArgb(230, 246, 241);
                Color fg = Color.FromArgb(12, 100, 78);
                string emoji = "✅ ";

                if (status == "Chờ thực hiện")
                {
                    bg = Color.FromArgb(255, 244, 220);
                    fg = Color.FromArgb(160, 112, 0);
                    emoji = "⏳ ";
                }

                int pillWidth = 116;
                Rectangle pill = new Rectangle(cell.X + 10, cell.Y + 18, Math.Min(pillWidth, cell.Width - 20), 26);
                FillRound(e.Graphics, pill, 13, bg);
                TextRenderer.DrawText(e.Graphics, emoji + status, new Font("Segoe UI", 8.2F, FontStyle.Bold), pill, fg, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
                return;
            }

            // 4. Vẽ hai nút hành động trong cột Thao tác (Chi tiết, Nhập KQ / In KQ)
            if (e.ColumnIndex == dgv.Columns["colAction"].Index)
            {
                string status = dgv.Rows[e.RowIndex].Cells["colStatusVal"].Value.ToString();

                // Button 1: Chi tiết
                Rectangle btn1 = new Rectangle(cell.X + 10, cell.Y + 18, 72, 26);
                FillRound(e.Graphics, btn1, 6, Color.FromArgb(15, 110, 86));
                TextRenderer.DrawText(e.Graphics, "Chi tiết", new Font("Segoe UI", 8.5F, FontStyle.Bold), btn1, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // Button 2: Nhập KQ
                Rectangle btn2 = new Rectangle(cell.X + 90, cell.Y + 18, 72, 26);
                FillRound(e.Graphics, btn2, 6, Color.FromArgb(240, 165, 0));
                TextRenderer.DrawText(e.Graphics, "Nhập KQ", new Font("Segoe UI", 8.5F, FontStyle.Bold), btn2, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
                return;
            }

            TextRenderer.DrawText(
                e.Graphics,
                value,
                new Font("Segoe UI", 8.8F, FontStyle.Regular),
                new Rectangle(cell.X + 4, cell.Y, cell.Width - 8, cell.Height),
                Color.FromArgb(24, 48, 42),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private void PaintGridHeader(DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0)
            {
                e.Handled = true;
                return;
            }

            Rectangle cell = e.CellBounds;
            using (var brush = new SolidBrush(Color.FromArgb(244, 247, 250)))
            {
                e.Graphics.FillRectangle(brush, cell);
            }

            using (var pen = new Pen(Color.FromArgb(218, 232, 226)))
            {
                e.Graphics.DrawLine(pen, cell.Left, cell.Bottom - 1, cell.Right, cell.Bottom - 1);
                e.Graphics.DrawLine(pen, cell.Right - 1, cell.Top + 8, cell.Right - 1, cell.Bottom - 8);
            }

            var column = dgv.Columns[e.ColumnIndex];
            string title = column.HeaderText;
            bool sorted = column.Name == sortColumnName;
            string glyph = sorted ? (sortAscending ? "  ▲" : "  ▼") : "  ⇅";
            Color glyphColor = sorted ? Color.FromArgb(15, 110, 86) : Color.FromArgb(170, 184, 194);

            TextRenderer.DrawText(
                e.Graphics,
                title,
                new Font("Segoe UI", 8.8F, FontStyle.Bold),
                new Rectangle(cell.X + 8, cell.Y, cell.Width - 36, cell.Height),
                Color.FromArgb(122, 149, 137),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            TextRenderer.DrawText(
                e.Graphics,
                glyph,
                new Font("Segoe UI", 8.6F, FontStyle.Bold),
                new Rectangle(cell.Right - 32, cell.Y, 28, cell.Height),
                glyphColor,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter);

            e.Handled = true;
        }

        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["colAction"].Index) return;

            var cellRect = dgv.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
            var mousePos = dgv.PointToClient(Cursor.Position);
            int clickX = mousePos.X - cellRect.X;

            string patientName = dgv.Rows[e.RowIndex].Cells["colPatientVal"].Value.ToString();
            string recordId = dgv.Rows[e.RowIndex].Cells["colRecordId"].Value.ToString();   // MAHSBA
            string serviceName = dgv.Rows[e.RowIndex].Cells["colServiceVal"].Value.ToString();
            string maHsba = dgv.Rows[e.RowIndex].Cells["colMaHsba"].Value.ToString();     // MAHSBA
            string ngayDv = dgv.Rows[e.RowIndex].Cells["colTime"].Value.ToString();       // NGAYDV
            string status = dgv.Rows[e.RowIndex].Cells["colStatusVal"].Value.ToString();

            // Xác định click vào nút nào dựa theo toạ độ ngang X của ô cell
            if (clickX >= 10 && clickX <= 82) // Button 1: Chi tiết
            {
                var item = allServices.FirstOrDefault(x => x.MaHsba == recordId && x.Service == serviceName);
                string gender = item?.BnGender ?? "Nam";
                string dob = item?.BnDob ?? "18/09/1995";
                string doctorName = "BS. Phạm Minh Tuấn";

                using (var frm = new frmKtvServiceDetail(patientName, recordId, serviceName, doctorName, ngayDv, status, gender, dob))
                {
                    frm.ShowDialog(this);
                }
            }
            else if (clickX >= 90 && clickX <= 162) // Button 2: Nhập KQ
            {
                if (Main_KTV.Instance != null)
                {
                    Main_KTV.Instance.SwitchToKetQua(recordId);
                }
                else
                {
                    MessageBox.Show($"Chuyển sang phân hệ Nhập kết quả cho {patientName} (HSBA: {recordId})!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0) return;

            var column = dgv.Columns[e.ColumnIndex];
            if (!column.Visible || column.Name == "colAction") return;

            if (sortColumnName == column.Name)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortColumnName = column.Name;
                sortAscending = true;
            }

            dgv.ClearSelection();
            FilterAndLoadGrid();
            dgv.Invalidate();
        }

        private void Dgv_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dgv.HitTest(e.X, e.Y);
            if (hit.Type == DataGridViewHitTestType.ColumnHeader)
            {
                dgv.Cursor = Cursors.Hand;
                return;
            }
            if (hit.Type == DataGridViewHitTestType.Cell && hit.RowIndex >= 0)
            {
                dgv.Cursor = Cursors.Hand;
            }
            if (hit.Type == DataGridViewHitTestType.Cell && hit.ColumnIndex == dgv.Columns["colAction"].Index)
            {
                var cellRect = dgv.GetCellDisplayRectangle(hit.ColumnIndex, hit.RowIndex, false);
                int hoverX = e.X - cellRect.X;
                if ((hoverX >= 10 && hoverX <= 82) || (hoverX >= 90 && hoverX <= 162))
                {
                    dgv.Cursor = Cursors.Hand;
                    return;
                }
            }
            if (hit.Type != DataGridViewHitTestType.Cell) dgv.Cursor = Cursors.Default;
        }

        // Mở Slide Drawer thông tin chi tiết trượt cực kỳ quyến rũ
        private void OpenDrawer(string name, string id, string svc, string ngayDv, string status)
        {
            activeRecordId = id;
            activeServiceName = svc;

            lblDName.Text = name;
            lblDId.Text = id;
            lblDSvc.Text = svc;
            lblDTime.Text = ngayDv;
            lblDStatus.Text = status;

            // Hiển thị Overlay
            pnlOverlay.Size = new Size(this.Width, this.Height);
            pnlOverlay.Visible = true;
            pnlOverlay.BringToFront();

            pnlDrawer.Height = this.Height;
            pnlDrawer.BringToFront();

            drawerTargetX = this.Width - 420;
            isDrawerOpening = true;
            tmrDrawer.Start();
        }

        // Đóng Slide Drawer
        private void CloseDrawer()
        {
            drawerTargetX = this.Width;
            isDrawerOpening = false;
            tmrDrawer.Start();
        }

        private void TmrDrawer_Tick(object sender, EventArgs e)
        {
            int step = 40;
            if (isDrawerOpening)
            {
                if (pnlDrawer.Left - step > drawerTargetX)
                {
                    pnlDrawer.Left -= step;
                }
                else
                {
                    pnlDrawer.Left = drawerTargetX;
                    tmrDrawer.Stop();
                }
            }
            else
            {
                if (pnlDrawer.Left + step < drawerTargetX)
                {
                    pnlDrawer.Left += step;
                }
                else
                {
                    pnlDrawer.Left = drawerTargetX;
                    pnlOverlay.Visible = false;
                    tmrDrawer.Stop();
                }
            }
        }

        // Helper tạo các dòng nhãn trong slide drawer
        private Label CreateDrawerRow(Panel parent, string labelText, string valText, ref int currentY)
        {
            var pnlRow = new Guna2Panel
            {
                Location = new Point(24, currentY),
                Size = new Size(372, 34),
                CustomBorderColor = Color.FromArgb(238, 242, 240),
                CustomBorderThickness = new Padding(0, 0, 0, 1),
                BackColor = Color.Transparent
            };

            var lblLabel = TextLabel(labelText, 0, 7, 150, 20, 9F, FontStyle.Regular, Color.FromArgb(122, 149, 137));
            var lblValue = TextLabel(valText, 150, 7, 222, 20, 9F, FontStyle.Bold, Color.FromArgb(26, 39, 51), ContentAlignment.MiddleRight);

            pnlRow.Controls.AddRange(new Control[] { lblLabel, lblValue });
            parent.Controls.Add(pnlRow);

            currentY += 34;
            return lblValue;
        }

        // Helper để khởi tạo các control động bên trong Slide Drawer lúc runtime
        private void BuildDrawerComponents()
        {
            if (isDrawerBuilt) return;

            pnlDrawer.Controls.Clear();

            // Drawer Header
            var pnlDrawerHeader = new Guna2Panel
            {
                Size = new Size(420, 68),
                Location = new Point(0, 0),
                FillColor = Color.White,
                CustomBorderColor = Color.FromArgb(218, 232, 226),
                CustomBorderThickness = new Padding(0, 0, 0, 1)
            };
            lblDrawerTitle = TextLabel("📋 Chi tiết phân công", 24, 22, 250, 24, 11F, FontStyle.Bold, Color.FromArgb(26, 39, 51));

            btnCloseDrawer = new Guna2Button
            {
                Text = "✕",
                Size = new Size(32, 32),
                Location = new Point(364, 18),
                BorderRadius = 16,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(122, 149, 137),
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderThickness = 1,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCloseDrawer.HoverState.FillColor = Color.FromArgb(253, 234, 234);
            btnCloseDrawer.HoverState.ForeColor = Color.FromArgb(217, 64, 64);
            btnCloseDrawer.HoverState.BorderColor = Color.FromArgb(217, 64, 64);
            btnCloseDrawer.Click += (s, e) => CloseDrawer();

            pnlDrawerHeader.Controls.AddRange(new Control[] { lblDrawerTitle, btnCloseDrawer });
            pnlDrawer.Controls.Add(pnlDrawerHeader);

            // Drawer Body (Có thanh cuộn)
            var pnlDrawerBody = new Panel
            {
                Location = new Point(0, 68),
                Size = new Size(420, 640),
                AutoScroll = true,
                BackColor = Color.White
            };

            int drawY = 20;
            // Phần 1: Thông tin bệnh nhân (từ BENHNHAN JOIN qua HSBA)
            pnlDrawerBody.Controls.Add(TextLabel("THÔNG TIN BỆNH NHÂN (BENHNHAN)", 24, drawY, 360, 20, 8.5F, FontStyle.Bold, Color.FromArgb(122, 149, 137)));
            drawY += 28;

            lblDName = CreateDrawerRow(pnlDrawerBody, "Họ tên (TENBN)", "—", ref drawY);
            lblDId = CreateDrawerRow(pnlDrawerBody, "Mã bệnh nhân", "—", ref drawY);
            CreateDrawerRow(pnlDrawerBody, "Ngày sinh (NGAYSINH)", "—", ref drawY);
            CreateDrawerRow(pnlDrawerBody, "Giới tính (PHAI)", "—", ref drawY);
            CreateDrawerRow(pnlDrawerBody, "CCCD", "—", ref drawY);

            drawY += 16;
            // Phần 2: Thông tin dịch vụ (từ HSBA_DV)
            pnlDrawerBody.Controls.Add(TextLabel("THÔNG TIN DỊCH VỤ (HSBA_DV)", 24, drawY, 360, 20, 8.5F, FontStyle.Bold, Color.FromArgb(122, 149, 137)));
            drawY += 28;

            lblDSvc = CreateDrawerRow(pnlDrawerBody, "Dịch vụ (LOAIDV)", "—", ref drawY);
            lblDTime = CreateDrawerRow(pnlDrawerBody, "Ngày DV (NGAYDV)", "—", ref drawY);
            lblDStatus = CreateDrawerRow(pnlDrawerBody, "Trạng thái", "—", ref drawY);
            lblDId = CreateDrawerRow(pnlDrawerBody, "Mã HSBA", "—", ref drawY);

            drawY += 20;
            // Phần 3: Ghi chú bác sĩ chỉ định
            pnlDrawerBody.Controls.Add(TextLabel("GHI CHÚ CHỈ ĐỊNH", 24, drawY, 300, 20, 8.5F, FontStyle.Bold, Color.FromArgb(122, 149, 137)));
            drawY += 26;

            var pnlNote = new Guna2Panel
            {
                Location = new Point(24, drawY),
                Size = new Size(372, 82),
                BorderRadius = 8,
                FillColor = Color.FromArgb(244, 247, 250)
            };
            var lblNote = TextLabel("Bệnh nhân có tiền sử tiểu đường type 2. Cần lấy mẫu máu tĩnh mạch trong trạng thái nhịn ăn ít nhất 8 giờ. Thực hiện đúng ca trực.", 12, 10, 348, 62, 9F, FontStyle.Regular, Color.FromArgb(74, 85, 104));
            lblNote.AutoSize = false;
            lblNote.AutoEllipsis = true;
            pnlNote.Controls.Add(lblNote);
            pnlDrawerBody.Controls.Add(pnlNote);

            pnlDrawer.Controls.Add(pnlDrawerBody);

            // Drawer Footer
            var pnlDrawerFooter = new Guna2Panel
            {
                Size = new Size(420, 68),
                FillColor = Color.White,
                CustomBorderColor = Color.FromArgb(218, 232, 226),
                CustomBorderThickness = new Padding(0, 1, 0, 0)
            };

            var btnSubmitKq = KtvTheme.Button("🔬 Nhập kết quả", KtvTheme.Teal, Color.White);
            btnSubmitKq.Location = new Point(24, 15);
            btnSubmitKq.Size = new Size(176, 38);
            btnSubmitKq.Click += (s, e) =>
            {
                CloseDrawer();
                if (Main_KTV.Instance != null)
                {
                    Main_KTV.Instance.SwitchToKetQua(activeRecordId);
                }
                else
                {
                    MessageBox.Show($"Chuyển sang phân hệ Nhập kết quả cho bệnh nhân mã {activeRecordId}!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            var btnCloseFoot = KtvTheme.Button("Đóng", Color.White, Color.FromArgb(74, 85, 104));
            btnCloseFoot.Location = new Point(220, 15);
            btnCloseFoot.Size = new Size(176, 38);
            btnCloseFoot.BorderColor = Color.FromArgb(218, 232, 226);
            btnCloseFoot.BorderThickness = 1;
            btnCloseFoot.Click += (s, e) => CloseDrawer();

            pnlDrawerFooter.Controls.AddRange(new Control[] { btnSubmitKq, btnCloseFoot });
            pnlDrawer.Controls.Add(pnlDrawerFooter);
            pnlDrawer.BringToFront();

            isDrawerBuilt = true;
        }

        private void ConfigureTabButton(Guna2Button btn)
        {
            btn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btn.FillColor = Color.White;
            btn.ForeColor = Color.FromArgb(150, 163, 158);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.CheckedState.FillColor = Color.FromArgb(236, 248, 244);
            btn.CheckedState.ForeColor = Color.FromArgb(15, 110, 86);
            btn.CheckedState.CustomBorderColor = Color.FromArgb(15, 110, 86);
            btn.HoverState.FillColor = Color.FromArgb(246, 252, 250);
            btn.HoverState.ForeColor = Color.FromArgb(60, 120, 100);
            btn.HoverState.CustomBorderColor = Color.FromArgb(160, 210, 195);
            btn.CustomBorderThickness = new Padding(0, 0, 0, 3);
            btn.Cursor = Cursors.Hand;
        }

        private void ConfigurePageButton(Guna2Button btn, bool active)
        {
            btn.BorderRadius = 6;
            btn.BorderThickness = 1;
            btn.BorderColor = active ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
            btn.FillColor = active ? Color.FromArgb(15, 110, 86) : Color.White;
            btn.ForeColor = active ? Color.White : Color.FromArgb(74, 85, 104);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.HoverState.BorderColor = Color.FromArgb(15, 110, 86);
            btn.HoverState.FillColor = active ? Color.FromArgb(15, 110, 86) : Color.FromArgb(230, 244, 240);
            btn.HoverState.ForeColor = active ? Color.White : Color.FromArgb(15, 110, 86);
        }

        private Label TextLabel(string text, int x, int y, int width, int height, float size, FontStyle style, Color color, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, height),
                AutoSize = false,
                AutoEllipsis = true,
                TextAlign = align,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                BackColor = Color.Transparent
            };
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
            if (d <= 0) d = 1;
            GraphicsPath path = new GraphicsPath();
            try
            {
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
            }
            catch { }
            return path;
        }

        private void PnlOverlay_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            var card = (Guna2Panel)sender;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using (var path = GetRoundedRectPath(new RectangleF(0, 0, card.Width, card.Height), 14))
            {
                e.Graphics.SetClip(path);

                // if (card.Tag is Color accentColor)
                // {
                //     using (var brush = new SolidBrush(accentColor))
                //     {
                //         e.Graphics.FillRectangle(brush, 0, 0, card.Width, 4);
                //     }
                // }

                e.Graphics.ResetClip();
            }
        }

        private static System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(RectangleF rect, float radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            float diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ConfigureKpiHover(Guna2Panel card)
        {
            card.Cursor = Cursors.Hand;
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Color = Color.FromArgb(40, 15, 110, 86);
            card.ShadowDecoration.Depth = 5;
            card.ShadowDecoration.Shadow = new Padding(0, 2, 8, 4);

            EventHandler enter = (s, e) => SetKpiHoverState(card, true);
            EventHandler leave = (s, e) => SetKpiHoverState(card, false);

            card.MouseEnter += enter;
            card.MouseLeave += leave;

            foreach (Control child in card.Controls)
            {
                child.Cursor = Cursors.Hand;
                child.MouseEnter += enter;
                child.MouseLeave += leave;
            }
        }

        private void SetKpiHoverState(Guna2Panel card, bool hovered)
        {
            card.FillColor = hovered ? Color.FromArgb(248, 252, 250) : Color.White;
            card.BorderColor = hovered ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226);
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Depth = hovered ? 12 : 5;
            card.ShadowDecoration.Shadow = hovered ? new Padding(0, 4, 14, 8) : new Padding(0, 2, 8, 4);
        }
    }
}

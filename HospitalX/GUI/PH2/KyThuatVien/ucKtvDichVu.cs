using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvDichVu : UserControl
    {
        // 1. Controls bộ lọc (Filter controls)
        private Guna2Panel pnlFilter;
        private Guna2TextBox txtSearch;
        private Guna2ComboBox cboStatus;
        private Guna2ComboBox cboPriority;
        private Guna2Button btnReset;

        // 2. Thống kê nhanh (Status strip cards)
        private Guna2Panel[] stripCards = new Guna2Panel[4];
        private Label[] lblStripVals = new Label[4];
        private Label[] lblStripLabels = new Label[4];
        private Guna2Panel[] stripDots = new Guna2Panel[4];

        // 3. Bảng dữ liệu chính (Main Grid Card)
        private Guna2Panel pnlTableCard;
        private Guna2Panel pnlTabBar;
        private Guna2Button btnTabAll;
        private Guna2Button btnTabPending;
        private Guna2Button btnTabProgress;
        private Guna2Button btnTabDone;
        private DataGridView dgv;

        // 4. Phân trang (Pagination)
        private Guna2Panel pnlPagination;
        private Label lblPageInfo;
        private Guna2Button btnPrev;
        private Guna2Button btnPage1;
        private Guna2Button btnNext;
        private Guna2Panel pnlOverlay;
        private Guna2Panel pnlDrawer;
        private Label lblDrawerTitle;
        private Guna2Button btnCloseDrawer;
        private Timer tmrDrawer;
        private int drawerTargetX = 0;
        private bool isDrawerOpening = true;
        private Label lblDName;
        private Label lblDId;
        private Label lblDSvc;
        private Label lblDRoom;
        private Label lblDDoc;
        private Label lblDTime;
        private Label lblDPrio;
        private Label lblDStatus;
        private string activeRecordId = "";
        private string activeServiceName = "";

        // 5. Drawer thông tin chi tiết trượt bên phải (Right-sliding detail drawer)
        // Dữ liệu nội bộ
        private List<KtvService> allServices = new List<KtvService>();
        private string currentTab = "all";
        private int hoveredButtonIndex = 0;
        private string sortColumnName = "colTime";
        private bool sortAscending = true;

        public ucKtvDichVu()
        {
            InitializeComponent();
            BackColor = Color.FromArgb(244, 247, 250); // Sleek modern background matching doctor portal #F4F7FA
            DoubleBuffered = true;
            this.AutoScroll = false; // Disable page auto-scroll to fix horizontal scroll-wheel bug

            BuildControls();
            LoadRows();

            this.Resize += UcKtvDichVu_Resize;
        }

        private void UcKtvDichVu_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void BuildControls()
        {
            Controls.Clear();

            // Khởi tạo Overlay (Nền tối mờ full màn hình khi trượt Drawer)
            pnlOverlay = new Guna2Panel
            {
                FillColor = Color.FromArgb(80, 0, 0, 0),
                Location = new Point(0, 0),
                Size = new Size(this.Width, this.Height),
                Visible = false
            };
            pnlOverlay.Click += (s, e) => CloseDrawer();
            Controls.Add(pnlOverlay);

            // Timer cho slide drawer mượt mà
            tmrDrawer = new Timer { Interval = 15 };

            // 1. Bộ lọc (Filter Bar Card)
            pnlFilter = KtvTheme.Card(0, 0, 10, 10);
            pnlFilter.BorderColor = Color.FromArgb(218, 232, 226);
            pnlFilter.ShadowDecoration.Enabled = true;
            pnlFilter.ShadowDecoration.Color = Color.FromArgb(15, 110, 86);
            pnlFilter.ShadowDecoration.Depth = 8;
            pnlFilter.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            txtSearch = new Guna2TextBox
            {
                PlaceholderText = "Tìm bệnh nhân, mã HSBA, tên dịch vụ…",
                FillColor = Color.FromArgb(244, 247, 250),
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(24, 48, 42),
                PlaceholderForeColor = Color.FromArgb(136, 152, 170)
            };
            txtSearch.TextChanged += (s, e) => FilterAndLoadGrid();

            cboStatus = new Guna2ComboBox
            {
                BorderRadius = 8,
                BorderColor = Color.FromArgb(218, 232, 226),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(74, 85, 104)
            };
            cboStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ thực hiện", "Đang thực hiện", "Hoàn thành" });
            cboStatus.SelectedIndex = 0;
            cboStatus.SelectedIndexChanged += (s, e) => FilterAndLoadGrid();

            cboPriority = new Guna2ComboBox
            {
                BorderRadius = 8,
                BorderColor = Color.FromArgb(218, 232, 226),
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(74, 85, 104)
            };
            cboPriority.Items.AddRange(new object[] { "Tất cả ưu tiên", "Khẩn cấp", "Cao", "Bình thường" });
            cboPriority.SelectedIndex = 0;
            cboPriority.SelectedIndexChanged += (s, e) => FilterAndLoadGrid();

            btnReset = KtvTheme.Button("Đặt lại", Color.White, Color.FromArgb(74, 85, 104));
            btnReset.BorderColor = Color.FromArgb(218, 232, 226);
            btnReset.BorderThickness = 1;
            btnReset.Click += (s, e) => { txtSearch.Clear(); cboStatus.SelectedIndex = 0; cboPriority.SelectedIndex = 0; switchTab(btnTabAll, "all"); };

            pnlFilter.Controls.AddRange(new Control[] { txtSearch, cboStatus, cboPriority, btnReset });
            Controls.Add(pnlFilter);

            // 2. Thống kê nhanh (Status Strip Cards)
            Color[] stripColors = {
                Color.FromArgb(136, 152, 170), // Xám: Tổng
                Color.FromArgb(240, 165, 0),   // Vàng: Chờ
                Color.FromArgb(35, 119, 196),  // Xanh: Đang TH
                Color.FromArgb(15, 110, 86)    // Teal: Xong
            };
            string[] stripLabels = { "Tổng dịch vụ", "Chờ thực hiện", "Đang thực hiện", "Hoàn thành" };

            for (int i = 0; i < 4; i++)
            {
                stripCards[i] = KtvTheme.Card(0, 0, 10, 10);
                stripCards[i].BorderColor = Color.FromArgb(218, 232, 226);
                stripCards[i].ShadowDecoration.Enabled = true;
                stripCards[i].ShadowDecoration.Color = Color.FromArgb(15, 110, 86);
                stripCards[i].ShadowDecoration.Depth = 8;
                stripCards[i].ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

                stripDots[i] = new Guna2Panel
                {
                    Size = new Size(12, 12),
                    BorderRadius = 6,
                    FillColor = stripColors[i]
                };

                Color valColor = stripColors[i];
                if (i == 0) valColor = Color.FromArgb(26, 39, 51); // Deep slate for total

                lblStripVals[i] = TextLabel("0", 46, 16, 100, 44, 21F, FontStyle.Bold, valColor, ContentAlignment.TopLeft);
                lblStripVals[i].AutoSize = false;
                lblStripLabels[i] = TextLabel(stripLabels[i], 46, 62, 180, 22, 9F, FontStyle.Regular, Color.FromArgb(122, 149, 137), ContentAlignment.TopLeft);
                lblStripLabels[i].AutoSize = false;

                stripCards[i].Controls.AddRange(new Control[] { stripDots[i], lblStripVals[i], lblStripLabels[i] });
                Controls.Add(stripCards[i]);
            }

            // 3. Thẻ bảng biểu chính (Main Card)
            pnlTableCard = KtvTheme.Card(0, 0, 10, 10);
            pnlTableCard.BorderColor = Color.FromArgb(218, 232, 226);
            pnlTableCard.ShadowDecoration.Enabled = true;
            pnlTableCard.ShadowDecoration.Color = Color.FromArgb(15, 110, 86);
            pnlTableCard.ShadowDecoration.Depth = 8;
            pnlTableCard.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            // Tab bar
            pnlTabBar = new Guna2Panel
            {
                Location = new Point(1, 1),
                Height = 46,
                FillColor = Color.White,
                CustomBorderColor = Color.FromArgb(218, 232, 226),
                CustomBorderThickness = new Padding(0, 0, 0, 1)
            };

            btnTabAll = CreateTabButton("Tất cả (0)", true);
            btnTabAll.Location = new Point(20, 1);
            btnTabAll.Size = new Size(120, 44);
            btnTabAll.Click += (s, e) => switchTab((Guna2Button)s, "all");

            btnTabPending = CreateTabButton("Chờ thực hiện (0)", false);
            btnTabPending.Location = new Point(140, 1);
            btnTabPending.Size = new Size(190, 44);
            btnTabPending.Click += (s, e) => switchTab((Guna2Button)s, "pending");

            btnTabProgress = CreateTabButton("Đang thực hiện (0)", false);
            btnTabProgress.Location = new Point(330, 1);
            btnTabProgress.Size = new Size(190, 44);
            btnTabProgress.Click += (s, e) => switchTab((Guna2Button)s, "progress");

            btnTabDone = CreateTabButton("Hoàn thành (0)", false);
            btnTabDone.Location = new Point(520, 1);
            btnTabDone.Size = new Size(160, 44);
            btnTabDone.Click += (s, e) => switchTab((Guna2Button)s, "done");

            pnlTabBar.Controls.AddRange(new Control[] { btnTabAll, btnTabPending, btnTabProgress, btnTabDone });
            pnlTableCard.Controls.Add(pnlTabBar);

            // Khởi tạo DataGridView cao cấp tự vẽ (Custom Painted Grid)
            dgv = new DataGridView
            {
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(238, 242, 240),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            };
            dgv.RowTemplate.Height = 62;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 250);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(122, 149, 137);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8.8F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(244, 247, 250);
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(122, 149, 137);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 246, 243);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(24, 48, 42);
            dgv.ColumnHeadersHeight = 40;

            // Setup columns
            dgv.Columns.Clear();
            dgv.Columns.Add("colIndex", "STT");
            dgv.Columns.Add("colPatient", "Bệnh nhân");
            dgv.Columns.Add("colService", "Dịch vụ");
            dgv.Columns.Add("colDoctor", "Bác sĩ chỉ định");
            dgv.Columns.Add("colTime", "Giờ hẹn");
            dgv.Columns.Add("colPriority", "Ưu tiên");
            dgv.Columns.Add("colStatus", "Trạng thái");
            dgv.Columns.Add("colAction", "Thao tác");

            // Columns widths
            dgv.Columns["colIndex"].FillWeight = 8;
            dgv.Columns["colPatient"].FillWeight = 28;
            dgv.Columns["colService"].FillWeight = 28;
            dgv.Columns["colDoctor"].FillWeight = 20;
            dgv.Columns["colTime"].FillWeight = 14;
            dgv.Columns["colPriority"].FillWeight = 18;
            dgv.Columns["colStatus"].FillWeight = 18;
            dgv.Columns["colAction"].FillWeight = 26;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            }

            // Hidden value columns
            dgv.Columns.Add("colPatientVal", "");
            dgv.Columns.Add("colRecordId", "");
            dgv.Columns.Add("colServiceVal", "");
            dgv.Columns.Add("colPriorityVal", "");
            dgv.Columns.Add("colStatusVal", "");
            dgv.Columns.Add("colRoom", "");

            dgv.Columns["colPatientVal"].Visible = false;
            dgv.Columns["colRecordId"].Visible = false;
            dgv.Columns["colServiceVal"].Visible = false;
            dgv.Columns["colPriorityVal"].Visible = false;
            dgv.Columns["colStatusVal"].Visible = false;
            dgv.Columns["colRoom"].Visible = false;

            dgv.CellPainting += Dgv_CellPainting;
            dgv.CellClick += Dgv_CellClick;
            dgv.ColumnHeaderMouseClick += Dgv_ColumnHeaderMouseClick;
            dgv.MouseMove += Dgv_MouseMove;
            dgv.MouseLeave += (s, e) => { dgv.Cursor = Cursors.Default; hoveredRowIndex = -1; dgv.Invalidate(); };

            // Ultra-premium smooth row enter/leave hover tracking
            dgv.CellMouseEnter += (s, e) => {
                if (e.RowIndex >= 0 && e.RowIndex != hoveredRowIndex)
                {
                    int oldIndex = hoveredRowIndex;
                    hoveredRowIndex = e.RowIndex;
                    if (oldIndex >= 0) dgv.InvalidateRow(oldIndex);
                    dgv.InvalidateRow(hoveredRowIndex);
                }
            };
            dgv.CellMouseLeave += (s, e) => {
                if (hoveredRowIndex >= 0)
                {
                    int oldIndex = hoveredRowIndex;
                    hoveredRowIndex = -1;
                    dgv.InvalidateRow(oldIndex);
                }
            };

            pnlTableCard.Controls.Add(dgv);

            // Phân trang (Pagination)
            pnlPagination = new Guna2Panel
            {
                Height = 44,
                FillColor = Color.White,
                CustomBorderColor = Color.FromArgb(218, 232, 226),
                CustomBorderThickness = new Padding(0, 1, 0, 0)
            };

            lblPageInfo = TextLabel("Hiển thị 7 / 7 dịch vụ", 24, 12, 250, 20, 9F, FontStyle.Regular, Color.FromArgb(122, 149, 137));
            btnPrev = CreatePageButton("‹", false);
            btnPage1 = CreatePageButton("1", true);
            btnNext = CreatePageButton("›", false);

            pnlPagination.Controls.AddRange(new Control[] { lblPageInfo, btnPrev, btnPage1, btnNext });
            pnlTableCard.Controls.Add(pnlPagination);
            Controls.Add(pnlTableCard);

            // 5. Khởi tạo Drawer thông tin chi tiết bệnh nhân trượt cực kỳ sang trọng (Detail Drawer)
            pnlDrawer = new Guna2Panel
            {
                Size = new Size(420, 800),
                FillColor = Color.White,
                CustomBorderColor = Color.FromArgb(218, 232, 226),
                CustomBorderThickness = new Padding(1, 0, 0, 0)
            };
            pnlDrawer.ShadowDecoration.Enabled = true;
            pnlDrawer.ShadowDecoration.Shadow = new Padding(10, 0, 0, 0);
            pnlDrawer.ShadowDecoration.Color = Color.FromArgb(15, 110, 86);
            pnlDrawer.ShadowDecoration.Depth = 15;

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
            // Phần 1: Thông tin bệnh nhân
            pnlDrawerBody.Controls.Add(TextLabel("THÔNG TIN BỆNH NHÂN", 24, drawY, 300, 20, 8.5F, FontStyle.Bold, Color.FromArgb(122, 149, 137)));
            drawY += 28;

            lblDName = CreateDrawerRow(pnlDrawerBody, "Họ tên", "—", ref drawY);
            lblDId = CreateDrawerRow(pnlDrawerBody, "Mã HSBA", "—", ref drawY);
            CreateDrawerRow(pnlDrawerBody, "Ngày sinh", "12/03/1978", ref drawY);
            CreateDrawerRow(pnlDrawerBody, "Giới tính", "Nam", ref drawY);
            CreateDrawerRow(pnlDrawerBody, "Số điện thoại", "0912 345 678", ref drawY);

            drawY += 20;
            // Phần 2: Thông tin dịch vụ
            pnlDrawerBody.Controls.Add(TextLabel("THÔNG TIN DỊCH VỤ", 24, drawY, 300, 20, 8.5F, FontStyle.Bold, Color.FromArgb(122, 149, 137)));
            drawY += 28;

            lblDSvc = CreateDrawerRow(pnlDrawerBody, "Tên dịch vụ", "—", ref drawY);
            lblDRoom = CreateDrawerRow(pnlDrawerBody, "Phòng thực hiện", "—", ref drawY);
            lblDDoc = CreateDrawerRow(pnlDrawerBody, "Bác sĩ chỉ định", "—", ref drawY);
            lblDTime = CreateDrawerRow(pnlDrawerBody, "Giờ hẹn", "—", ref drawY);
            lblDPrio = CreateDrawerRow(pnlDrawerBody, "Ưu tiên", "—", ref drawY);
            lblDStatus = CreateDrawerRow(pnlDrawerBody, "Trạng thái", "—", ref drawY);

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
            var lblNote = TextLabel("Bệnh nhân có tiền sử tiểu đường type 2. Cần lấy mẫu máu tĩnh mạch trong trạng thái nhịn ăn ít nhất 8 giờ. Ưu tiên xử lý nhanh.", 12, 10, 348, 62, 9F, FontStyle.Regular, Color.FromArgb(74, 85, 104));
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
            btnSubmitKq.Click += (s, e) => {
                CloseDrawer();
                MessageBox.Show($"Chuyển sang phân hệ Nhập kết quả cho bệnh nhân mã {activeRecordId}!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            var btnCloseFoot = KtvTheme.Button("Đóng", Color.White, Color.FromArgb(74, 85, 104));
            btnCloseFoot.Location = new Point(220, 15);
            btnCloseFoot.Size = new Size(176, 38);
            btnCloseFoot.BorderColor = Color.FromArgb(218, 232, 226);
            btnCloseFoot.BorderThickness = 1;
            btnCloseFoot.Click += (s, e) => CloseDrawer();

            pnlDrawerFooter.Controls.AddRange(new Control[] { btnSubmitKq, btnCloseFoot });
            pnlDrawer.Controls.Add(pnlDrawerFooter);

            Controls.Add(pnlDrawer);
            pnlDrawer.BringToFront();
        }

        private void LayoutControls()
        {
            int margin = 28;
            int gap = 20;

            int availWidth = this.Width - 2 * margin;
            if (availWidth < 400) return;

            // 1. Layout bộ lọc
            pnlFilter.Location = new Point(margin, margin);
            pnlFilter.Size = new Size(availWidth, 72);

            txtSearch.Location = new Point(18, 18);
            txtSearch.Size = new Size((int)(availWidth * 0.42f), 36);

            cboStatus.Location = new Point(txtSearch.Right + 18, 18);
            cboStatus.Size = new Size((int)(availWidth * 0.18f), 36);

            cboPriority.Location = new Point(cboStatus.Right + 18, 18);
            cboPriority.Size = new Size((int)(availWidth * 0.18f), 36);

            btnReset.Location = new Point(availWidth - 138, 18);
            btnReset.Size = new Size(120, 36);

            // 2. Layout thống kê
            int stripWidth = (availWidth - 3 * gap) / 4;
            int stripY = pnlFilter.Bottom + gap;

            for (int i = 0; i < 4; i++)
            {
                stripCards[i].Location = new Point(margin + i * (stripWidth + gap), stripY);
                stripCards[i].Size = new Size(stripWidth, 104);
                stripDots[i].Location = new Point(22, 46);
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
            allServices = KtvData.Services();

            FilterAndLoadGrid();
        }

        private void FilterAndLoadGrid()
        {
            var query = allServices.AsEnumerable();

            // Lọc theo Tab hiện tại
            if (currentTab == "pending") query = query.Where(x => x.Status == "Chờ thực hiện");
            else if (currentTab == "progress") query = query.Where(x => x.Status == "Đang thực hiện");
            else if (currentTab == "done") query = query.Where(x => x.Status == "Hoàn thành");

            // Lọc theo ô tìm kiếm
            string q = txtSearch.Text.Trim().ToLowerInvariant();
            if (q.Length > 0)
            {
                query = query.Where(x => x.Patient.ToLowerInvariant().Contains(q) || 
                                         x.RecordId.ToLowerInvariant().Contains(q) || 
                                         x.Service.ToLowerInvariant().Contains(q));
            }

            // Lọc theo ComboBox Trạng thái
            if (cboStatus.SelectedIndex > 0)
            {
                query = query.Where(x => x.Status == cboStatus.SelectedItem.ToString());
            }

            // Lọc theo ComboBox Độ ưu tiên
            if (cboPriority.SelectedIndex > 0)
            {
                query = query.Where(x => x.Priority == cboPriority.SelectedItem.ToString());
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
                    item.Patient,
                    item.Service,
                    item.Doctor,
                    item.Time,
                    item.Priority,
                    item.Status,
                    "Chi tiết",
                    item.Patient,
                    item.RecordId,
                    item.Service,
                    item.Priority,
                    item.Status,
                    item.Room
                );
            }

            // Tính toán nhanh số lượng cho Tabs và Stats
            int total = allServices.Count;
            int pending = allServices.Count(x => x.Status == "Chờ thực hiện");
            int progress = allServices.Count(x => x.Status == "Đang thực hiện");
            int done = allServices.Count(x => x.Status == "Hoàn thành");

            lblStripVals[0].Text = total.ToString();
            lblStripVals[1].Text = pending.ToString();
            lblStripVals[2].Text = progress.ToString();
            lblStripVals[3].Text = done.ToString();

            btnTabAll.Text = $"Tất cả ({total})";
            btnTabPending.Text = $"Chờ thực hiện ({pending})";
            btnTabProgress.Text = $"Đang thực hiện ({progress})";
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
                    keySelector = x => x.Time;
                    break;
                case "colPatient":
                    keySelector = x => x.Patient;
                    break;
                case "colService":
                    keySelector = x => x.Service;
                    break;
                case "colDoctor":
                    keySelector = x => x.Doctor;
                    break;
                case "colPriority":
                    keySelector = x => PriorityRank(x.Priority);
                    break;
                case "colStatus":
                    keySelector = x => StatusRank(x.Status);
                    break;
                default:
                    keySelector = x => x.Time;
                    break;
            }

            return sortAscending ? query.OrderBy(keySelector) : query.OrderByDescending(keySelector);
        }

        private int PriorityRank(string priority)
        {
            if (priority == "Kháº©n cáº¥p") return 0;
            if (priority == "Cao") return 1;
            return 2;
        }

        private int StatusRank(string status)
        {
            if (status == "Chá» thá»±c hiá»‡n") return 0;
            if (status == "Äang thá»±c hiá»‡n") return 1;
            return 2;
        }

        private void switchTab(Guna2Button activeBtn, string tab)
        {
            btnTabAll.Checked = false;
            btnTabPending.Checked = false;
            btnTabProgress.Checked = false;
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

            // 2. Vẽ cột Dịch vụ (Tên dịch vụ 9.8F, Phòng ban 8.5F)
            if (e.ColumnIndex == dgv.Columns["colService"].Index)
            {
                string service = dgv.Rows[e.RowIndex].Cells["colServiceVal"].Value.ToString();
                string room = dgv.Rows[e.RowIndex].Cells["colRoom"].Value.ToString();

                TextRenderer.DrawText(e.Graphics, service, new Font("Segoe UI", 9.8F, FontStyle.Bold), new Rectangle(cell.X + 12, cell.Y + 10, cell.Width - 16, 22), Color.FromArgb(24, 48, 42), TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                TextRenderer.DrawText(e.Graphics, room, new Font("Segoe UI", 8.5F), new Rectangle(cell.X + 12, cell.Y + 34, cell.Width - 16, 18), Color.FromArgb(136, 152, 170), TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

                e.Handled = true;
                return;
            }

            // 3. Vẽ cột độ ưu tiên pill badge bo tròn sang xịn
            if (e.ColumnIndex == dgv.Columns["colPriority"].Index)
            {
                string prio = dgv.Rows[e.RowIndex].Cells["colPriorityVal"].Value.ToString();
                Color bg = Color.FromArgb(230, 246, 241);
                Color fg = Color.FromArgb(12, 100, 78);
                string emoji = "🟢 ";

                if (prio == "Khẩn cấp")
                {
                    bg = Color.FromArgb(253, 234, 234);
                    fg = Color.FromArgb(217, 64, 64);
                    emoji = "🔴 ";
                }
                else if (prio == "Cao")
                {
                    bg = Color.FromArgb(255, 244, 220);
                    fg = Color.FromArgb(160, 112, 0);
                    emoji = "🟡 ";
                }

                int pillWidth = prio == "Bình thường" ? 118 : 104;
                Rectangle pill = new Rectangle(cell.X + 10, cell.Y + 18, Math.Min(pillWidth, cell.Width - 20), 26);
                FillRound(e.Graphics, pill, 13, bg);
                TextRenderer.DrawText(e.Graphics, emoji + prio, new Font("Segoe UI", 8.2F, FontStyle.Bold), pill, fg, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
                return;
            }

            // 4. Vẽ cột trạng thái pill badge bo tròn sang xịn
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
                else if (status == "Đang thực hiện")
                {
                    bg = Color.FromArgb(232, 241, 251);
                    fg = Color.FromArgb(35, 119, 196);
                    emoji = "⚙️ ";
                }

                int pillWidth = status == "Đang thực hiện" ? 132 : 116;
                Rectangle pill = new Rectangle(cell.X + 10, cell.Y + 18, Math.Min(pillWidth, cell.Width - 20), 26);
                FillRound(e.Graphics, pill, 13, bg);
                TextRenderer.DrawText(e.Graphics, emoji + status, new Font("Segoe UI", 8.2F, FontStyle.Bold), pill, fg, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                e.Handled = true;
                return;
            }

            // 5. Vẽ hai nút hành động trong cột Thao tác (Chi tiết, Nhập KQ / Bắt đầu / In KQ)
            if (e.ColumnIndex == dgv.Columns["colAction"].Index)
            {
                string status = dgv.Rows[e.RowIndex].Cells["colStatusVal"].Value.ToString();

                // Button 1: Chi tiết
                Rectangle btn1 = new Rectangle(cell.X + 10, cell.Y + 18, 72, 26);
                FillRound(e.Graphics, btn1, 6, Color.FromArgb(15, 110, 86));
                TextRenderer.DrawText(e.Graphics, "Chi tiết", new Font("Segoe UI", 8.5F, FontStyle.Bold), btn1, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

                // Button 2: Action Specific
                Rectangle btn2 = new Rectangle(cell.X + 90, cell.Y + 18, 72, 26);
                if (status == "Chờ thực hiện")
                {
                    FillRound(e.Graphics, btn2, 6, Color.White);
                    DrawRound(e.Graphics, btn2, 6, Color.FromArgb(218, 232, 226));
                    TextRenderer.DrawText(e.Graphics, "Bắt đầu", new Font("Segoe UI", 8.5F, FontStyle.Bold), btn2, Color.FromArgb(74, 85, 104), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else if (status == "Đang thực hiện")
                {
                    FillRound(e.Graphics, btn2, 6, Color.FromArgb(240, 165, 0));
                    TextRenderer.DrawText(e.Graphics, "Nhập KQ", new Font("Segoe UI", 8.5F, FontStyle.Bold), btn2, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }
                else // Hoàn thành
                {
                    FillRound(e.Graphics, btn2, 6, Color.White);
                    DrawRound(e.Graphics, btn2, 6, Color.FromArgb(218, 232, 226));
                    TextRenderer.DrawText(e.Graphics, "In KQ", new Font("Segoe UI", 8.5F, FontStyle.Bold), btn2, Color.FromArgb(74, 85, 104), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                }

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
            string recordId = dgv.Rows[e.RowIndex].Cells["colRecordId"].Value.ToString();
            string serviceName = dgv.Rows[e.RowIndex].Cells["colServiceVal"].Value.ToString();
            string doctorName = dgv.Rows[e.RowIndex].Cells["colDoctor"].Value.ToString();
            string timeStr = dgv.Rows[e.RowIndex].Cells["colTime"].Value.ToString();
            string priority = dgv.Rows[e.RowIndex].Cells["colPriorityVal"].Value.ToString();
            string status = dgv.Rows[e.RowIndex].Cells["colStatusVal"].Value.ToString();
            string room = dgv.Rows[e.RowIndex].Cells["colRoom"].Value.ToString();

            // Xác định click vào nút nào dựa theo toạ độ ngang X của ô cell
            if (clickX >= 10 && clickX <= 82) // Button 1: Chi tiết
            {
                using (var frm = new frmKtvServiceDetail(patientName, recordId, serviceName, doctorName, timeStr, priority, status, room))
                {
                    frm.ShowDialog(this);
                }
            }
            else if (clickX >= 90 && clickX <= 162) // Button 2: Action cụ thể
            {
                if (status == "Chờ thực hiện")
                {
                    UpdateServiceStatus(recordId, serviceName, "Đang thực hiện");
                }
                else if (status == "Đang thực hiện")
                {
                    MessageBox.Show($"Chuyển sang phân hệ Nhập kết quả cho bệnh nhân mã {recordId}!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (status == "Hoàn thành")
                {
                    MessageBox.Show($"Đang in phiếu kết quả dịch vụ {serviceName} cho bệnh nhân {patientName}...", "In kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void UpdateServiceStatus(string recordId, string serviceName, string newStatus)
        {
            var item = allServices.FirstOrDefault(x => x.RecordId == recordId && x.Service == serviceName);
            if (item != null)
            {
                item.Status = newStatus;
                MessageBox.Show($"Bắt đầu thực hiện dịch vụ {serviceName} thành công (Chế độ mô phỏng)!", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FilterAndLoadGrid();
            }
            else
            {
                MessageBox.Show("Không tìm thấy dịch vụ trong dữ liệu mô phỏng.", "HospitalX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Mở Slide Drawer thông tin chi tiết trượt cực kỳ quyến rũ
        private void OpenDrawer(string name, string id, string svc, string doc, string time, string prio, string status, string room)
        {
            activeRecordId = id;
            activeServiceName = svc;

            lblDName.Text = name;
            lblDId.Text = id;
            lblDSvc.Text = svc;
            lblDRoom.Text = room;
            lblDDoc.Text = doc;
            lblDTime.Text = time;
            lblDPrio.Text = prio;
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

        // Helper tạo các nút phân trang
        private Guna2Button CreatePageButton(string text, bool active)
        {
            return new Guna2Button
            {
                Text = text,
                Size = new Size(32, 32),
                BorderRadius = 6,
                BorderThickness = 1,
                BorderColor = active ? Color.FromArgb(15, 110, 86) : Color.FromArgb(218, 232, 226),
                FillColor = active ? Color.FromArgb(15, 110, 86) : Color.White,
                ForeColor = active ? Color.White : Color.FromArgb(74, 85, 104),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                HoverState = { BorderColor = Color.FromArgb(15, 110, 86), FillColor = active ? Color.FromArgb(15, 110, 86) : Color.FromArgb(230, 244, 240), ForeColor = active ? Color.White : Color.FromArgb(15, 110, 86) }
            };
        }

        // Helper tạo nút tab
        private Guna2Button CreateTabButton(string text, bool active)
        {
            var btn = new Guna2Button
            {
                Text = text,
                Height = 44,
                Width = 180,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton,
                Checked = active,
                FillColor = Color.White,
                ForeColor = Color.FromArgb(150, 163, 158),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                // Active state: teal text, soft teal bg, teal bottom border
                CheckedState = {
                    FillColor = Color.FromArgb(236, 248, 244),
                    ForeColor = Color.FromArgb(15, 110, 86),
                    CustomBorderColor = Color.FromArgb(15, 110, 86)
                },
                // Hover state: slightly tinted bg, darker text
                HoverState = {
                    FillColor = Color.FromArgb(246, 252, 250),
                    ForeColor = Color.FromArgb(60, 120, 100),
                    CustomBorderColor = Color.FromArgb(160, 210, 195)
                },
                CustomBorderThickness = new Padding(0, 0, 0, 3),
                Cursor = Cursors.Hand
            };
            return btn;
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
    }
}

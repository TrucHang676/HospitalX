using Guna.UI2.WinForms;
using HospitalX.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucDieuPhoiKTV : UserControl
    {
        // Styling tokens
        private static readonly Color ColorTeal = Color.FromArgb(15, 110, 86);
        private static readonly Color ColorTealDark = Color.FromArgb(10, 82, 64);
        private static readonly Color ColorTealLight = Color.FromArgb(230, 244, 240);
        private static readonly Color ColorBg = Color.FromArgb(244, 247, 246);
        private static readonly Color ColorTextPrimary = Color.FromArgb(26, 46, 39);
        private static readonly Color ColorTextSecondary = Color.FromArgb(74, 98, 89);
        private static readonly Color ColorTextMuted = Color.FromArgb(122, 149, 137);
        private static readonly Color ColorBorder = Color.FromArgb(218, 232, 226);
        
        // Load indicators
        private static readonly Color ColorFree = Color.FromArgb(39, 169, 107);
        private static readonly Color ColorModerate = Color.FromArgb(240, 165, 0);
        private static readonly Color ColorBusy = Color.FromArgb(224, 92, 58);

        // Fonts
        private static readonly Font FontTitle = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        private static readonly Font FontSub = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
        private static readonly Font FontNormal = new Font("Segoe UI", 9F, FontStyle.Regular);
        private static readonly Font FontBold = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
        private static readonly Font FontMono = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

        // Data Models
        public class ServiceRequest
        {
            public string Id { get; set; }
            public string Hsba { get; set; }
            public string PatientCode { get; set; }
            public string PatientName { get; set; }
            public string ServiceType { get; set; }
            public string Priority { get; set; } // high, normal, urgent
            public string AssignedKtv { get; set; }
            public string Status { get; set; } // pending, assigned, inprog, done, urgent
            public string StatusLabel { get; set; }
            public string ServiceDate { get; set; } // NGÀYDV in requirements
            public string Result { get; set; }
        }

        public class Technician
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Skills { get; set; }
            public string Load { get; set; } // free, moderate, busy
            public string LoadLabel { get; set; }
            public Color Color { get; set; }
            public string Initials { get; set; }

            public override string ToString()
            {
                return $"{Name} ({Skills})";
            }
        }

        private readonly List<ServiceRequest> _requests = new List<ServiceRequest>();
        private readonly List<Technician> _ktvs = new List<Technician>();
        
        private int _selectedRequestIndex = 2; // Default to DV-2026-0023

        // Pagination controls & settings
        private FlowLayoutPanel pnlPagination;
        private readonly List<Guna2Button> _pageButtons = new List<Guna2Button>();
        private Guna2Button btnPrevPage;
        private Guna2Button btnNextPage;
        private Label lblPageInfo;
        
        private int _currentPage = 1;
        private int _pageSize = 10; // Page size = 10 as requested
        private int _totalPage = 1;

        // Row hover properties
        private int _hoveredRowIndex = -1;
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);

        public ucDieuPhoiKTV()
        {
            InitializeComponent();
            DoubleBuffered = true;

            // Load data
            LoadMockData();

            // Set up resize handler
            this.Resize += (s, e) => LayoutPanels();
            pnlScroll.Resize += (s, e) => LayoutPanels();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Hide columns that are not defined in requirements
            colMaDV.Visible = false;
            colUuTien.Visible = false;

            // Reset grid anchors to avoid bounds conflicts during custom resize layout
            dgvRequests.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Setup title icon using dpv_5.png (matching ucDanhSachBN alignment structure)
            PictureBox ptbRequestTitleIcon = new PictureBox
            {
                Size = new Size(22, 22),
                Location = new Point(20, 21),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = DpvAssets.Load("dpv_5.png")
            };
            pnlServiceRequests.Controls.Add(ptbRequestTitleIcon);

            // Shift title and sub labels to the right of the icon and remove emoji
            lblRequestTitle.Location = new Point(48, 18);
            lblRequestTitle.Text = "Danh sách yêu cầu dịch vụ hỗ trợ chẩn đoán";
            lblRequestSub.Location = new Point(48, 44);
            SetupPaginationControls();
            ConfigureStyles();
            ApplyFilter();
            SelectRequest(_selectedRequestIndex);

            // Wire event handlers
            dgvRequests.CellClick += DgvRequests_CellClick;
            dgvRequests.CellPainting += DgvRequests_CellPainting;
            dgvRequests.MouseMove += DgvRequests_MouseMove;
            dgvRequests.MouseLeave += DgvRequests_MouseLeave;
            cboServiceType.SelectedIndexChanged += FilterChanged;
            cboStatus.SelectedIndexChanged += FilterChanged;

            // Force initial layout
            LayoutPanels();
        }

        private void SetupPaginationControls()
        {
            // Remove legacy additions
            pnlServiceRequests.Controls.Remove(lblPageInfo);
            pnlServiceRequests.Controls.Remove(btnPrevPage);
            pnlServiceRequests.Controls.Remove(btnNextPage);

            pnlPagination = new FlowLayoutPanel
            {
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                Size = new Size(400, 40),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            lblPageInfo = new Label
            {
                AutoSize = false,
                Size = new Size(90, 36),
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = ColorTextMuted,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0, 2, 8, 2)
            };

            btnPrevPage = new Guna2Button();
            StylePageButton(btnPrevPage, "<");
            btnPrevPage.Click += BtnPrevPage_Click;

            btnNextPage = new Guna2Button();
            StylePageButton(btnNextPage, ">");
            btnNextPage.Click += BtnNextPage_Click;

            pnlPagination.Controls.Add(lblPageInfo);
            pnlPagination.Controls.Add(btnPrevPage);

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
            pnlServiceRequests.Controls.Add(pnlPagination);
        }

        private void StylePageButton(Guna2Button btn, string text)
        {
            btn.Size = new Size(36, 36);
            btn.Margin = new Padding(3, 2, 3, 2);
            btn.BorderRadius = 6;
            btn.BorderThickness = 1;
            btn.BorderColor = ColorBorder;
            btn.FillColor = Color.Transparent;
            
            if (text == "<" || text == ">")
            {
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }
            else
            {
                btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            
            btn.ForeColor = ColorTextSecondary;
            btn.Text = text;
            btn.Cursor = Cursors.Hand;

            btn.DisabledState.FillColor = Color.Transparent;
            btn.DisabledState.BorderColor = ColorBorder;
            btn.DisabledState.ForeColor = Color.FromArgb(180, 200, 190);

            btn.HoverState.FillColor = ColorTeal;
            btn.HoverState.ForeColor = Color.White;
            btn.HoverState.BorderColor = ColorTeal;
        }

        private void ChangePage(int page)
        {
            if (page >= 1 && page <= _totalPage)
            {
                _currentPage = page;
                ApplyFilter();
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
                        btn.FillColor = ColorTeal;
                        btn.ForeColor = Color.White;
                        btn.BorderColor = ColorTeal;
                    }
                    else
                    {
                        btn.FillColor = Color.Transparent;
                        btn.ForeColor = ColorTextSecondary;
                        btn.BorderColor = ColorBorder;
                    }
                }
                else
                {
                    btn.Visible = false;
                }
            }

            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < _totalPage;

            btnPrevPage.ForeColor = btnPrevPage.Enabled ? ColorTextSecondary : Color.FromArgb(180, 200, 190);
            btnNextPage.ForeColor = btnNextPage.Enabled ? ColorTextSecondary : Color.FromArgb(180, 200, 190);
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                ApplyFilter();
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPage)
            {
                _currentPage++;
                ApplyFilter();
            }
        }

        private void DgvRequests_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dgvRequests.HitTest(e.X, e.Y);
            if (hit.RowIndex != _hoveredRowIndex)
            {
                int oldHovered = _hoveredRowIndex;
                _hoveredRowIndex = hit.RowIndex;
                if (oldHovered >= 0 && oldHovered < dgvRequests.Rows.Count)
                    dgvRequests.InvalidateRow(oldHovered);
                if (_hoveredRowIndex >= 0 && _hoveredRowIndex < dgvRequests.Rows.Count)
                    dgvRequests.InvalidateRow(_hoveredRowIndex);
            }
        }

        private void DgvRequests_MouseLeave(object sender, EventArgs e)
        {
            if (_hoveredRowIndex >= 0)
            {
                int oldHovered = _hoveredRowIndex;
                _hoveredRowIndex = -1;
                if (oldHovered < dgvRequests.Rows.Count)
                    dgvRequests.InvalidateRow(oldHovered);
            }
        }

        private void LoadMockData()
        {
            _requests.Add(new ServiceRequest { Id = "DV-2026-0021", Hsba = "HSBA-2026-0155", PatientCode = "BN240001", PatientName = "Nguyễn Văn An", ServiceType = "Điện tâm đồ", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0022", Hsba = "HSBA-2026-0154", PatientCode = "BN240002", PatientName = "Phạm Thị Lan", ServiceType = "Xét nghiệm máu", Priority = "normal", AssignedKtv = "KTV. Lý Hoa", Status = "assigned", StatusLabel = "Đã phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0023", Hsba = "HSBA-2026-0153", PatientCode = "BN240003", PatientName = "Hoàng Đức Nam", ServiceType = "Siêu âm tim", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0024", Hsba = "HSBA-2026-0152", PatientCode = "BN240004", PatientName = "Trần Thị Mai", ServiceType = "Siêu âm thai", Priority = "normal", AssignedKtv = "KTV. Nguyễn Bình", Status = "assigned", StatusLabel = "Đã phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0025", Hsba = "HSBA-2026-0151", PatientCode = "BN240005", PatientName = "Lê Văn Hải", ServiceType = "X-Quang não", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0026", Hsba = "HSBA-2026-0150", PatientCode = "BN240006", PatientName = "Vũ Thị Bích", ServiceType = "Nội soi dạ dày", Priority = "normal", AssignedKtv = "KTV. Trần Đông", Status = "assigned", StatusLabel = "Đã phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0027", Hsba = "HSBA-2026-0149", PatientCode = "BN240007", PatientName = "Đinh Công Sơn", ServiceType = "MRI tim", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "24/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0018", Hsba = "HSBA-2026-0147", PatientCode = "BN240008", PatientName = "Ngô Thị Hằng", ServiceType = "Xét nghiệm máu", Priority = "normal", AssignedKtv = "KTV. Bùi Nghĩa", Status = "done", StatusLabel = "Hoàn thành", ServiceDate = "24/05/2026", Result = "Chỉ số hồng cầu ổn định (4.5 T/L)" });

            // New 20 mock records to test pagination (28 records total)
            _requests.Add(new ServiceRequest { Id = "DV-2026-0028", Hsba = "HSBA-2026-0146", PatientCode = "BN240009", PatientName = "Phan Thanh Bình", ServiceType = "Chụp CT scan", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0029", Hsba = "HSBA-2026-0145", PatientCode = "BN240010", PatientName = "Lý Hoàng Nam", ServiceType = "Điện nano đồ", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0030", Hsba = "HSBA-2026-0144", PatientCode = "BN240011", PatientName = "Trần Văn Cường", ServiceType = "X-Quang phổi", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0031", Hsba = "HSBA-2026-0143", PatientCode = "BN240012", PatientName = "Đỗ Thị Dung", ServiceType = "Nội soi phế quan", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0032", Hsba = "HSBA-2026-0142", PatientCode = "BN240013", PatientName = "Hoàng Minh Tuấn", ServiceType = "Xét nghiệm sinh hoá", Priority = "normal", AssignedKtv = "KTV. Lý Hoa", Status = "assigned", StatusLabel = "Đã phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0033", Hsba = "HSBA-2026-0141", PatientCode = "BN240014", PatientName = "Nguyễn Thị Hạnh", ServiceType = "Siêu âm tim", Priority = "normal", AssignedKtv = "KTV. Nguyễn Bình", Status = "assigned", StatusLabel = "Đã phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0034", Hsba = "HSBA-2026-0140", PatientCode = "BN240015", PatientName = "Bùi Xuân Trường", ServiceType = "MRI cột sống", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "25/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0035", Hsba = "HSBA-2026-0139", PatientCode = "BN240016", PatientName = "Phan Thị Hương", ServiceType = "Xét nghiệm máu", Priority = "normal", AssignedKtv = "KTV. Bùi Nghĩa", Status = "done", StatusLabel = "Hoàn thành", ServiceDate = "25/05/2026", Result = "Số lượng bạch cầu bình thường" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0036", Hsba = "HSBA-2026-0138", PatientCode = "BN240017", PatientName = "Nguyễn Hữu Thắng", ServiceType = "X-Quang khớp gối", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "26/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0037", Hsba = "HSBA-2026-0137", PatientCode = "BN240018", PatientName = "Lê Mỹ Linh", ServiceType = "Nội soi đại tràng", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "26/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0038", Hsba = "HSBA-2026-0136", PatientCode = "BN240019", PatientName = "Trịnh Quốc Bảo", ServiceType = "Điện tâm đồ", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "26/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0039", Hsba = "HSBA-2026-0135", PatientCode = "BN240020", PatientName = "Võ Hoài Nam", ServiceType = "Siêu âm tổng quát", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "26/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0040", Hsba = "HSBA-2026-0134", PatientCode = "BN240021", PatientName = "Phạm Thanh Thảo", ServiceType = "Xét nghiệm nước tiểu", Priority = "normal", AssignedKtv = "KTV. Lý Hoa", Status = "done", StatusLabel = "Hoàn thành", ServiceDate = "26/05/2026", Result = "Không phát hiện vi khuẩn đường tiết niệu" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0041", Hsba = "HSBA-2026-0133", PatientCode = "BN240022", PatientName = "Nguyễn Thị Kim", ServiceType = "Chụp CT scan", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "26/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0042", Hsba = "HSBA-2026-0132", PatientCode = "BN240023", PatientName = "Trần Ngọc Sơn", ServiceType = "Siêu âm tim", Priority = "normal", AssignedKtv = "KTV. Nguyễn Bình", Status = "assigned", StatusLabel = "Đã phân công", ServiceDate = "26/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0043", Hsba = "HSBA-2026-0131", PatientCode = "BN240024", PatientName = "Lương Thế Vinh", ServiceType = "MRI khớp vai", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "27/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0044", Hsba = "HSBA-2026-0130", PatientCode = "BN240025", PatientName = "Đặng Thị Thắm", ServiceType = "Điện tâm đồ", Priority = "high", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "27/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0045", Hsba = "HSBA-2026-0129", PatientCode = "BN240026", PatientName = "Mai Văn Đức", ServiceType = "X-Quang xoang", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "27/05/2026" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0046", Hsba = "HSBA-2026-0128", PatientCode = "BN240027", PatientName = "Hồ Tuấn Anh", ServiceType = "Xét nghiệm máu", Priority = "normal", AssignedKtv = "KTV. Bùi Nghĩa", Status = "done", StatusLabel = "Hoàn thành", ServiceDate = "27/05/2026", Result = "Đường huyết lúc đói đạt 5.4 mmol/L" });
            _requests.Add(new ServiceRequest { Id = "DV-2026-0047", Hsba = "HSBA-2026-0127", PatientCode = "BN240028", PatientName = "Nguyễn Thị Thủy", ServiceType = "Siêu âm tuyến giáp", Priority = "normal", AssignedKtv = "Chưa phân công", Status = "pending", StatusLabel = "Chờ phân công", ServiceDate = "27/05/2026" });

            _ktvs.Add(new Technician { Code = "KTV-001", Name = "Lý Thị Hoa", Skills = "XN Máu, Sinh hoá", Load = "free", LoadLabel = "Rảnh (1 ca)", Color = Color.FromArgb(39, 169, 107), Initials = "LH" });
            _ktvs.Add(new Technician { Code = "KTV-002", Name = "Bùi Trọng Nghĩa", Skills = "Siêu âm, Điện tim", Load = "moderate", LoadLabel = "Trung bình (3 ca)", Color = Color.FromArgb(240, 165, 0), Initials = "BN" });
            _ktvs.Add(new Technician { Code = "KTV-003", Name = "Nguyễn Văn Bình", Skills = "Sản khoa, Siêu âm thai", Load = "free", LoadLabel = "Rảnh (2 ca)", Color = Color.FromArgb(45, 125, 210), Initials = "NB" });
            _ktvs.Add(new Technician { Code = "KTV-004", Name = "Trần Mạnh Đông", Skills = "Nội soi, X-Quang", Load = "moderate", LoadLabel = "Trung bình (4 ca)", Color = Color.FromArgb(142, 68, 173), Initials = "TD" });
            _ktvs.Add(new Technician { Code = "KTV-005", Name = "Phạm Thị Ngọc", Skills = "MRI, CT Scan", Load = "busy", LoadLabel = "Bận (6 ca)", Color = Color.FromArgb(224, 92, 58), Initials = "PN" });
            _ktvs.Add(new Technician { Code = "KTV-006", Name = "Hoàng Anh Dũng", Skills = "X-Quang, Điện tim", Load = "free", LoadLabel = "Rảnh (0 ca)", Color = Color.FromArgb(15, 110, 86), Initials = "HD" });
        }

        private void ConfigureStyles()
        {
            // Set header labels styling
            lblRequestTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRequestTitle.ForeColor = ColorTextPrimary;

            lblRequestSub.Font = FontNormal;
            lblRequestSub.ForeColor = ColorTextMuted;

            // cbo drop downs
            cboServiceType.Font = FontNormal;
            cboStatus.Font = FontNormal;

            // Style DataGridView requests
            var headerBack = Color.FromArgb(247, 249, 248);
            var headerFore = ColorTextMuted;

            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = headerBack;
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = headerFore;
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.25F, FontStyle.Bold);
            dgvRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerBack;
            dgvRequests.ColumnHeadersDefaultCellStyle.SelectionForeColor = headerFore;
            dgvRequests.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
            dgvRequests.ColumnHeadersHeight = 44;
            dgvRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvRequests.DefaultCellStyle.Font = FontNormal;
            dgvRequests.DefaultCellStyle.ForeColor = ColorTextPrimary;
            dgvRequests.DefaultCellStyle.BackColor = Color.White;
            dgvRequests.DefaultCellStyle.SelectionBackColor = ColorTealLight;
            dgvRequests.DefaultCellStyle.SelectionForeColor = ColorTextPrimary;
            dgvRequests.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);

            dgvRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvRequests.RowsDefaultCellStyle.BackColor = Color.White;
            dgvRequests.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvRequests.GridColor = Color.White;
            dgvRequests.RowTemplate.Height = 76; // Increased height to prevent vertical text overlap
            dgvRequests.MultiSelect = false;
            dgvRequests.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configure column widths and headers programmatically
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            colMaHSBA.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMaHSBA.FillWeight = 145;
            colMaHSBA.MinimumWidth = 140;
            colMaHSBA.HeaderText = "MÃ HSBA";

            colBenhNhan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBenhNhan.FillWeight = 180;
            colBenhNhan.MinimumWidth = 160;
            colBenhNhan.HeaderText = "BỆNH NHÂN";

            colLoaiDV.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLoaiDV.FillWeight = 150;
            colLoaiDV.MinimumWidth = 130;
            colLoaiDV.HeaderText = "LOẠI DỊCH VỤ";

            colKTV.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colKTV.FillWeight = 160;
            colKTV.MinimumWidth = 130;
            colKTV.HeaderText = "KTV PHỤ TRÁCH";

            colTrangThai.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTrangThai.FillWeight = 150;
            colTrangThai.MinimumWidth = 140;
            colTrangThai.HeaderText = "TRẠNG THÁI";

            colThaoTac.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colThaoTac.Width = 120;
            colThaoTac.HeaderText = "THAO TÁC";
        }

        private void ApplyFilter()
        {
            string filterType = cboServiceType.SelectedItem?.ToString() ?? "Tất cả loại DV";
            string filterStatus = cboStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            // First, filter the raw list
            var filteredRequests = new List<Tuple<int, ServiceRequest>>();
            
            int pendingCount = 0;
            int assignedCount = 0;

            for (int i = 0; i < _requests.Count; i++)
            {
                var r = _requests[i];

                if (r.Status == "pending" || r.Status == "urgent") pendingCount++;
                if (r.Status == "assigned") assignedCount++;

                // Apply type filter
                if (filterType != "Tất cả loại DV" && !r.ServiceType.Contains(filterType.Replace("Xét nghiệm máu", "Xét nghiệm").Replace("X-Quang", "X-Quang").Replace("Siêu âm", "Siêu âm")))
                {
                    continue;
                }

                // Apply status filter
                if (filterStatus != "Tất cả trạng thái" && r.StatusLabel != filterStatus)
                {
                    continue;
                }

                filteredRequests.Add(new Tuple<int, ServiceRequest>(i, r));
            }

            lblRequestSub.Text = $"{pendingCount} yêu cầu chờ phân công · {assignedCount} đã phân công";

            // Calculate pagination metrics
            int totalRecords = filteredRequests.Count;
            _totalPage = (int)Math.Ceiling((double)totalRecords / _pageSize);
            if (_totalPage < 1) _totalPage = 1;

            if (_currentPage > _totalPage) _currentPage = _totalPage;
            if (_currentPage < 1) _currentPage = 1;

            // Load records for the current page
            dgvRequests.Rows.Clear();
            int startIndex = (_currentPage - 1) * _pageSize;
            int endIndex = Math.Min(startIndex + _pageSize, totalRecords);

            for (int k = startIndex; k < endIndex; k++)
            {
                var item = filteredRequests[k];
                var r = item.Item2;
                int originalIndex = item.Item1;

                int rowIndex = dgvRequests.Rows.Add();
                DataGridViewRow row = dgvRequests.Rows[rowIndex];
                row.Height = 76; // Đảm bảo chiều cao dòng 76px rộng rãi không bị cắt chữ
                row.Tag = originalIndex; // Keep list index reference

                row.Cells[colMaHSBA.Index].Value = r.Hsba;
                row.Cells[colBenhNhan.Index].Value = r.PatientName;
                row.Cells[colLoaiDV.Index].Value = r.ServiceType;
                row.Cells[colKTV.Index].Value = r.AssignedKtv;
                row.Cells[colTrangThai.Index].Value = r.StatusLabel;
                row.Cells[colThaoTac.Index].Value = (r.Status == "pending" || r.Status == "urgent") ? "Phân công" : "Chi tiết";
            }

            // Update pagination UI
            UpdatePaginationUI();

            dgvRequests.ClearSelection();
            dgvRequests.CurrentCell = null;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            _currentPage = 1; // Reset to first page when filter changes
            ApplyFilter();
        }

        private void RenderTimeSlots()
        {
            // Empty method - scheduling time slots are hidden per requirements simplification
        }



        private void DgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvRequests.Rows[e.RowIndex];
            if (row.Tag is int originalIndex)
            {
                SelectRequest(originalIndex);

                if (e.ColumnIndex == colThaoTac.Index)
                {
                    var req = _requests[originalIndex];
                    if (req.Status == "pending" || req.Status == "urgent")
                    {
                        // Open quick assignment dialog
                        using (var frm = new frmPhanCongKTV(req, _ktvs))
                        {
                            if (frm.ShowDialog(this.FindForm()) == DialogResult.OK)
                            {
                                req.AssignedKtv = "KTV. " + frm.SelectedKtv.Name;
                                req.Status = "assigned";
                                req.StatusLabel = "Đã phân công";

                                ApplyFilter();
                                SelectRequest(originalIndex);

                                ShowMessage($"Đã phân công thành công KTV {frm.SelectedKtv.Name} thực hiện dịch vụ {req.ServiceType} cho bệnh nhân {req.PatientName}.", "Bệnh viện X", MessageDialogIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        // Open details dialog
                        using (var frm = new frmChiTietYeuCau(req))
                        {
                            frm.ShowDialog(this.FindForm());
                        }
                    }
                }
            }
        }

        private void SelectRequest(int originalIndex)
        {
            if (originalIndex < 0 || originalIndex >= _requests.Count) return;

            _selectedRequestIndex = originalIndex;
            var r = _requests[originalIndex];



            // Highlight in data grid
            dgvRequests.ClearSelection();
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                if (row.Tag is int idx && idx == originalIndex)
                {
                    row.Selected = true;
                    dgvRequests.CurrentCell = row.Cells[colMaHSBA.Index];
                    break;
                }
            }
        }

        private void DgvRequests_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return; // Header painting handled natively

            var grid = (DataGridView)sender;
            int origIdx = -1;
            if (grid.Rows[e.RowIndex].Tag is int tagVal) origIdx = tagVal;

            if (origIdx == -1) return;
            var r = _requests[origIdx];

            // Resolve row backgrounds dynamically based on selection and hover
            Color rowBgColor = Color.White;
            bool isSelected = grid.Rows[e.RowIndex].Selected;
            bool isHovered = (e.RowIndex == _hoveredRowIndex);

            if (isSelected)
            {
                rowBgColor = ColorTealLight;
            }
            else if (isHovered)
            {
                rowBgColor = RowHoverBack;
            }

            // Fill cell background manually (prevents selected state color conflicts)
            using (var bgBrush = new SolidBrush(rowBgColor))
            {
                e.Graphics.FillRectangle(bgBrush, e.CellBounds);
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Highlight border on left for selected row (ONLY on the first column!)
            if (isSelected && e.ColumnIndex == colMaHSBA.Index)
            {
                using (var tealBrush = new SolidBrush(ColorTeal))
                {
                    e.Graphics.FillRectangle(tealBrush, e.CellBounds.X, e.CellBounds.Y, 4, e.CellBounds.Height - 1);
                }
            }

            // Draw manual bottom border line to divide grid rows
            using (var borderPen = new Pen(Color.FromArgb(238, 242, 240), 1))
            {
                e.Graphics.DrawLine(borderPen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }

            if (e.ColumnIndex == colMaHSBA.Index)
            {
                // Indent HSBA text by 16px to completely clear the green selection indicator bar
                Rectangle textRect = new Rectangle(e.CellBounds.X + 16, e.CellBounds.Y, e.CellBounds.Width - 18, e.CellBounds.Height);
                TextRenderer.DrawText(e.Graphics, r.Hsba, FontMono, textRect, ColorTextSecondary,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else if (e.ColumnIndex == colBenhNhan.Index)
            {
                // Patient column: Name height 24, Code height 20, Gap 6 to fully prevent 'g'/'y' descender clipping
                int topOffset = (e.CellBounds.Height - 24 - 20 - 6) / 2;

                TextRenderer.DrawText(e.Graphics, r.PatientName, FontBold,
                    new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + topOffset, e.CellBounds.Width - 10, 24),
                    ColorTextPrimary, TextFormatFlags.Left | TextFormatFlags.EndEllipsis);

                TextRenderer.DrawText(e.Graphics, r.PatientCode, FontNormal,
                    new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + topOffset + 24 + 6, e.CellBounds.Width - 10, 20),
                    ColorTextMuted, TextFormatFlags.Left);
            }
            else if (e.ColumnIndex == colLoaiDV.Index)
            {
                // Indent content by 8px to align with column headers
                Rectangle textRect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height);
                TextRenderer.DrawText(e.Graphics, r.ServiceType, FontNormal, textRect, ColorTextPrimary,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
            else if (e.ColumnIndex == colKTV.Index)
            {
                // Indent content by 8px to align with column headers
                Rectangle textRect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y, e.CellBounds.Width - 10, e.CellBounds.Height);
                TextRenderer.DrawText(e.Graphics, r.AssignedKtv, FontNormal, textRect, ColorTextPrimary,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
            else if (e.ColumnIndex == colTrangThai.Index)
            {
                // Custom GDI+ Capsule shape Pill Badge for Statuses
                Color badgeBg = Color.FromArgb(244, 247, 246);
                Color badgeFore = ColorTextSecondary;

                if (r.Status == "pending")
                {
                    badgeBg = Color.FromArgb(255, 247, 230);
                    badgeFore = ColorModerate;
                }
                else if (r.Status == "assigned")
                {
                    badgeBg = Color.FromArgb(232, 240, 251);
                    badgeFore = Color.FromArgb(45, 125, 210);
                }
                else if (r.Status == "done")
                {
                    badgeBg = ColorTealLight;
                    badgeFore = ColorTeal;
                }
                else if (r.Status == "urgent")
                {
                    badgeBg = Color.FromArgb(254, 233, 230);
                    badgeFore = ColorBusy;
                }

                int badgeW = r.StatusLabel.Length > 12 ? 135 : 115;
                int badgeH = 24; // Height 24 to comfortably hold status label
                int badgeX = e.CellBounds.X + 8; // Offset by 8px to align badge with column headers
                int badgeY = e.CellBounds.Y + (e.CellBounds.Height - badgeH) / 2;

                using (var path = GetRoundedRectPath(new RectangleF(badgeX, badgeY, badgeW, badgeH), 12)) // Capsule shape
                using (var brush = new SolidBrush(badgeBg))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw dot
                int dotSize = 6;
                int dotX = badgeX + 10;
                int dotY = badgeY + (badgeH - dotSize) / 2;
                using (var dotBrush = new SolidBrush(badgeFore))
                {
                    e.Graphics.FillEllipse(dotBrush, dotX, dotY, dotSize, dotSize);
                }

                // Draw text
                Rectangle textRect = new Rectangle(badgeX + 20, badgeY, badgeW - 24, badgeH);
                TextRenderer.DrawText(e.Graphics, r.StatusLabel, FontSub, textRect, badgeFore,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else if (e.ColumnIndex == colThaoTac.Index)
            {
                // Action Button drawing
                Color btnBg = ColorTeal;
                Color btnFore = Color.White;
                Color btnBorderColor = ColorTeal;
                string btnText = "Phân công";

                bool isPending = (r.Status == "pending" || r.Status == "urgent");
                if (!isPending)
                {
                    btnBg = Color.White;
                    btnFore = ColorTeal;
                    btnBorderColor = ColorTeal;
                    btnText = "Chi tiết";
                }

                int btnW = 86;
                int btnH = 28;
                int btnX = e.CellBounds.X + (e.CellBounds.Width - btnW) / 2;
                int btnY = e.CellBounds.Y + (e.CellBounds.Height - btnH) / 2;

                using (var path = GetRoundedRectPath(new RectangleF(btnX, btnY, btnW, btnH), 6))
                {
                    using (var brush = new SolidBrush(btnBg))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                    using (var pen = new Pen(btnBorderColor, 1.5F))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }

                TextRenderer.DrawText(e.Graphics, btnText, FontSub,
                    new Rectangle(btnX, btnY, btnW, btnH), btnFore,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }

            e.Handled = true;
        }


        private void ShowMessage(string message, string title, MessageDialogIcon icon = MessageDialogIcon.Information)
        {
            var parent = this.FindForm();
            if (parent != null && parent is Main_DPV mainDpv)
            {
                mainDpv.ShowMessage(message, title, icon);
            }
            else
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, icon == MessageDialogIcon.Information ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }

        private void LayoutPanels()
        {
            // Use stable control Width/Height instead of ClientSize to prevent dynamic scrollbar jitter loops
            int scrollW = pnlScroll.Width;
            int scrollH = pnlScroll.Height;
            int totalW = scrollW - 40;
            int totalH = scrollH - 40;
            if (totalW <= 0 || totalH <= 0) return;



            // Width allocation: left card gets full width
            int leftW = totalW;

            pnlServiceRequests.SetBounds(20, 20, leftW, totalH);
            dgvRequests.SetBounds(20, 75, leftW - 40, totalH - 145);

            // Position pagination controls dynamically at the bottom right of the requests panel
            if (pnlPagination != null)
            {
                int bottomY = pnlServiceRequests.Height - 40 - 15;
                pnlPagination.Size = new Size(400, 40);
                pnlPagination.Location = new Point(leftW - 400 - 20, bottomY);
            }

            // Set minimum horizontal scroll limit to preserve visual design integrity (without right panel)
            pnlScroll.AutoScrollMinSize = new Size(20 + leftW + 20, totalH);
        }

        private static GraphicsPath GetRoundedRectPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}

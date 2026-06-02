using Guna.UI2.WinForms;
using HospitalX.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucTrangChu : UserControl
    {
        private const int KpiCardHeight = 172;
        private const int KpiGap = 16;
        private const int KpiIconSize = 48;
        private static readonly Color KpiTrendGreen = Color.FromArgb(34, 197, 94);
        private static readonly Color RowHoverBack = Color.FromArgb(232, 245, 242);
        private static readonly Color QuickTitleColor = Color.FromArgb(24, 48, 42);
        private static readonly Color QuickSubColor = Color.FromArgb(122, 149, 137);
        private static readonly Font QuickTitleFont = new Font("Segoe UI", 9.25F, FontStyle.Bold);
        private static readonly Font QuickSubFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);
        private static readonly Font WorkloadLabelFont = new Font("Segoe UI", 9F, FontStyle.Bold);
        private static readonly Font StatusFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        private static readonly Font MaBnFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
        private static readonly Color WorkloadTrackColor = Color.FromArgb(238, 242, 240);

        private const int MiddleColumnGap = 16;
        private const double RightColumnWidthRatio = 0.38;
        private const int RightColumnMinWidth = 390;
        private const int RightColumnMaxWidth = 420;
        private const int QuickWorkloadGap = 12;
        private const double QuickPanelHeightRatio = 0.47;
        private const int RightSidePad = 16;
        private const int SectionHeaderHeight = 44;
        private const int QuickButtonGap = 10;
        private const int MaxQuickButtonHeight = 95;
        private const int WorkloadBarHeight = 7;
        private const int WorkloadLabelHeight = 18;
        private const int WorkloadRowSpacing = 12;
        private const int StatusPillHorizontalPad = 36;
        private const int StatusColumnMinWidth = 168;

        private int _hoveredPatientRow = -1;

        private readonly Guna2Panel[] _kpiCards;
        private readonly Guna2PictureBox[] _kpiIcons;
        private readonly Label[] _kpiCaps;
        private readonly Label[] _kpiVals;
        private readonly Label[] _kpiSubs;

        public class DashboardPatientRecord
        {
            public string MaHsba { get; set; }
            public string TenBenhNhan { get; set; }
            public string Khoa { get; set; }
            public string DichVuCan { get; set; }
            public string TrangThai { get; set; }
        }

        private List<DashboardPatientRecord> _allPatientsData = new List<DashboardPatientRecord>();

        public ucTrangChu()
        {
            InitializeComponent();
            DoubleBuffered = true;
            _kpiCards = new[] { pnlKpi1, pnlKpi2, pnlKpi3, pnlKpi4 };
            _kpiIcons = new[] { ptbKpi1, ptbKpi2, ptbKpi3, ptbKpi4 };
            _kpiCaps = new[] { lblKpi1Cap, lblKpi2Cap, lblKpi3Cap, lblKpi4Cap };
            _kpiVals = new[] { lblKpi1Val, lblKpi2Val, lblKpi3Val, lblKpi4Val };
            _kpiSubs = new[] { lblKpi1Sub, lblKpi2Sub, lblKpi3Sub, lblKpi4Sub };
        }

        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            ConfigureCardStyles();
            SetupKpiVisuals();
            ApplyIcons();
            SetupSectionHeaders();
            SetupQuickActions();
            SetupPatientGrid();
            LayoutMiddleSection();
            pnlMiddle.Resize += (s, ev) => LayoutMiddleSection();
            pnlScroll.Resize += (s, ev) => LayoutMiddleSection();
            SetupWorkloadBars();
            SetupActivityList();
            RelayoutScrollContent();
        }

        private void ConfigureCardStyles()
        {
            foreach (var panel in new[] { pnlPatients, pnlQuick, pnlWorkload, pnlActivity })
            {
                panel.ShadowDecoration.Enabled = false;
                panel.BorderThickness = 1;
                panel.BorderColor = Color.FromArgb(218, 232, 226);
            }

            foreach (var card in _kpiCards)
            {
                card.ShadowDecoration.Enabled = false;
                card.BorderThickness = 1;
                card.BorderColor = Color.FromArgb(218, 232, 226);
                card.BorderRadius = 14;
                card.FillColor = Color.White;
                card.Padding = new Padding(0, 4, 0, 0);
                card.Paint -= KpiCard_Paint;
                card.Paint += KpiCard_Paint;
            }

            ArrangeKpiRow();
            pnlKpiRow.Resize += (s, ev) =>
            {
                ArrangeKpiRow();
                RelayoutScrollContent();
            };

            pnlMiddle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActivity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnViewAllPatients.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        private void SetupKpiVisuals()
        {
            Color[] accents =
            {
                Color.FromArgb(15, 110, 86),
                Color.FromArgb(255, 179, 0),
                Color.FromArgb(229, 57, 53),
                Color.FromArgb(25, 118, 210)
            };

            Color[] iconBacks =
            {
                Color.FromArgb(255, 249, 196),
                Color.FromArgb(255, 248, 225),
                Color.FromArgb(255, 243, 224),
                Color.FromArgb(227, 242, 253)
            };

            for (int i = 0; i < _kpiCards.Length; i++)
            {
                _kpiCards[i].Tag = accents[i];
                _kpiIcons[i].FillColor = iconBacks[i];
                _kpiIcons[i].BorderRadius = 16;
                _kpiIcons[i].SizeMode = PictureBoxSizeMode.Zoom;
                _kpiCaps[i].Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
                _kpiCaps[i].Padding = Padding.Empty;
                _kpiCaps[i].ForeColor = Color.FromArgb(122, 149, 137);
                _kpiVals[i].Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
                _kpiVals[i].ForeColor = Color.FromArgb(24, 48, 42);
                _kpiSubs[i].Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            }

            lblKpi1Sub.Text = "Cần xử lý ngay";
            lblKpi1Sub.ForeColor = Color.FromArgb(229, 57, 53);
            lblKpi2Sub.ForeColor = KpiTrendGreen;
            lblKpi4Sub.ForeColor = KpiTrendGreen;
            lblKpi3Sub.ForeColor = Color.FromArgb(229, 57, 53);
        }


        private void ArrangeKpiRow()
        {
            int rowW = pnlKpiRow.ClientSize.Width;
            if (rowW <= 0) rowW = 1040;
            int cardW = (rowW - KpiGap * (_kpiCards.Length - 1)) / _kpiCards.Length;

            for (int i = 0; i < _kpiCards.Length; i++)
            {
                _kpiCards[i].Location = new Point(i * (cardW + KpiGap), 0);
                _kpiCards[i].Size = new Size(cardW, KpiCardHeight);
                LayoutKpiCardContents(_kpiCards[i], _kpiIcons[i], _kpiCaps[i], _kpiVals[i], _kpiSubs[i]);
            }

            pnlKpiRow.Height = KpiCardHeight + 8;
        }

        private static void LayoutKpiCardContents(Guna2Panel card, Guna2PictureBox icon, Label cap, Label val, Label sub)
        {
            const int pad = 18;
            const int innerTop = 14;
            int cardW = card.ClientSize.Width > 0 ? card.ClientSize.Width : card.Width;

            if (icon.Name == "ptbKpi4")
            {
                const int targetSize = 32;
                int offset = (KpiIconSize - targetSize) / 2;
                icon.Location = new Point(pad + offset, innerTop + offset);
                icon.Size = new Size(targetSize, targetSize);
            }
            else
            {
                icon.Location = new Point(pad, innerTop);
                icon.Size = new Size(KpiIconSize, KpiIconSize);
            }

            int capW = cardW - pad * 2;
            cap.AutoSize = false;
            cap.Location = new Point(pad, innerTop + KpiIconSize + 8);
            cap.Size = new Size(capW, 20);
            cap.TextAlign = ContentAlignment.TopLeft;

            val.AutoSize = true;
            val.Location = new Point(pad, cap.Bottom + 4);

            sub.AutoSize = true;
            sub.MaximumSize = new Size(cardW - pad * 2, 0);

            // Luôn đặt subtitle bên dưới giá trị (khớp với thiết kế mẫu)
            sub.Location = new Point(pad, val.Bottom + 4);
            icon.BringToFront();
            cap.BringToFront();
        }

        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            var card = (Guna2Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Thiết lập Clipping path theo viền bo tròn của Card để vẽ không bị tràn ra ngoài
            using (var path = GetRoundedRectPath(new RectangleF(0, 0, card.Width, card.Height), 14))
            {
                e.Graphics.SetClip(path);

                // 1. Vẽ thanh màu ngang bo nhẹ theo góc ô
                if (card.Tag is Color accentColor)
                {
                    using (var brush = new SolidBrush(accentColor))
                    {
                        e.Graphics.FillRectangle(brush, 0, 0, card.Width, 4);
                    }
                }

                e.Graphics.ResetClip();
            }
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

        private void RelayoutScrollContent()
        {
            int contentW = Math.Max(960, pnlScroll.ClientSize.Width - 40);
            if (pnlScroll.ClientSize.Width > 0)
            {
                pnlKpiRow.Width = contentW;
                pnlMiddle.Width = contentW;
                pnlActivity.Width = contentW;
                LayoutMiddleSection();
            }

            pnlMiddle.Location = new Point(pnlMiddle.Left, pnlKpiRow.Bottom + 24);
            pnlActivity.Location = new Point(pnlActivity.Left, pnlMiddle.Bottom + 24);
            pnlScroll.AutoScrollMinSize = new Size(0, pnlActivity.Bottom + 32);
        }

        private void ApplyIcons()
        {
            SetKpiIcon(ptbKpi1, 8);
            SetKpiIcon(ptbKpi2, 4);
            SetKpiIcon(ptbKpi3, 9);
            ptbKpi4.Image = DpvAssets.Load("buttonTick.png");
            ptbKpi4.SizeMode = PictureBoxSizeMode.Zoom;
            ptbKpi4.FillColor = Color.Transparent;
        }

        private void SetupSectionHeaders()
        {
            ptbPatientsTitleIcon.Image = DpvAssets.Load(8);
            ptbQuickTitleIcon.Image = DpvAssets.Load(11);
            ptbWorkloadTitleIcon.Image = DpvAssets.Load(14);

            // Cập nhật tiêu đề bảng HSBA cho phù hợp với vai trò điều phối viên
            lblPatientsTitle.Text = "Hồ sơ cần phân công KTV";
            lblActivityTitle.Text = "Hoạt động gần đây";
            lblActivityTitle.Location = new Point(64, 20); // Dịch chuyển sang phải nhường chỗ cho icon

            if (pnlActivity.Controls["ptbActivityTitleIcon"] == null)
            {
                var ptbActivityTitleIcon = new Guna2PictureBox
                {
                    Name = "ptbActivityTitleIcon",
                    Image = DpvAssets.Load("reminder.png"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                    FillColor = Color.Transparent,
                    Size = new Size(29, 27),
                    Location = new Point(27, 18)
                };
                pnlActivity.Controls.Add(ptbActivityTitleIcon);
                ptbActivityTitleIcon.BringToFront();
            }
        }

        private void LayoutMiddleSection()
        {
            int totalW = pnlMiddle.ClientSize.Width;
            int totalH = pnlMiddle.ClientSize.Height;
            if (totalW <= 0 || totalH <= 0) return;

            int rightW = (int)(totalW * RightColumnWidthRatio);
            rightW = Math.Max(RightColumnMinWidth, Math.Min(RightColumnMaxWidth, rightW));
            int patientsW = totalW - rightW - MiddleColumnGap;
            if (patientsW < 480)
            {
                patientsW = Math.Max(480, totalW - rightW - MiddleColumnGap);
                rightW = totalW - patientsW - MiddleColumnGap;
            }

            pnlPatients.SetBounds(0, 0, patientsW, totalH);

            int rightX = patientsW + MiddleColumnGap;
            int quickH = Math.Max(200, (int)(totalH * QuickPanelHeightRatio));
            int workloadH = totalH - quickH - QuickWorkloadGap;
            if (workloadH < 180)
            {
                workloadH = 180;
                quickH = totalH - workloadH - QuickWorkloadGap;
            }

            pnlQuick.SetBounds(rightX, 0, rightW, quickH);
            LayoutQuickPanel(rightW, quickH);

            pnlWorkload.SetBounds(rightX, quickH + QuickWorkloadGap, rightW, workloadH);
            LayoutWorkloadPanel(rightW, workloadH);
        }

        private void LayoutQuickPanel(int panelWidth, int panelHeight)
        {
            int btnW = (panelWidth - RightSidePad * 2 - QuickButtonGap) / 2;

            // Đường kẻ ngang: dưới tiêu đề 8px để có khoảng cách cân đối
            int dividerY = SectionHeaderHeight + 10;
            pnlQuickDivider.Location = new Point(RightSidePad, dividerY);
            pnlQuickDivider.Size = new Size(panelWidth - RightSidePad * 2, 1);

            // Vùng nội dung bắt đầu sau divider + 12px khoảng cách
            int contentTop = dividerY + 13;
            int contentBottom = panelHeight - 12;
            int availableH = Math.Max(120, contentBottom - contentTop);
            int btnH = Math.Min(MaxQuickButtonHeight, (availableH - QuickButtonGap) / 2);
            int row2Top = contentTop + btnH + QuickButtonGap;
            int iconSize = 28;

            PlaceQuickButton(btnQuick1, RightSidePad, contentTop, btnW, btnH, iconSize);
            PlaceQuickButton(btnQuick2, RightSidePad + btnW + QuickButtonGap, contentTop, btnW, btnH, iconSize);
            PlaceQuickButton(btnQuick3, RightSidePad, row2Top, btnW, btnH, iconSize);
            PlaceQuickButton(btnQuick4, RightSidePad + btnW + QuickButtonGap, row2Top, btnW, btnH, iconSize);
        }

        private static void PlaceQuickButton(Guna2Button button, int x, int y, int width, int height, int iconSize)
        {
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            if (button.Image != null)
                button.ImageSize = new Size(iconSize, iconSize);
        }

        private void LayoutWorkloadPanel(int panelWidth, int panelHeight)
        {
            int barW = panelWidth - RightSidePad * 2;
            pnlWorkloadDivider.Size = new Size(barW, 1);

            int y = SectionHeaderHeight + 8;
            y = PlaceWorkloadRow(lblPb1, pbTimMach, "KTV Tim mạch", "6/8", y, barW);
            y = PlaceWorkloadRow(lblPb2, pbNoiTongQuat, "KTV Nội tổng quát", "5/6", y, barW);
            y = PlaceWorkloadRow(lblPb3, pbChinhHinh, "KTV Chỉnh hình", "3/5", y, barW);
            y = PlaceWorkloadRow(lblPb4, pbThanKinh, "KTV Thần kinh", "4/5", y, barW);
            _ = panelHeight;
        }

        private int PlaceWorkloadRow(Label label, Guna2ProgressBar bar, string name, string ratio, int y, int barWidth)
        {
            label.Tag = new[] { name, ratio };
            label.Text = string.Empty;
            label.Font = WorkloadLabelFont;
            label.ForeColor = QuickTitleColor;
            label.BackColor = Color.White;
            label.AutoSize = false;
            label.Location = new Point(RightSidePad, y);
            label.Size = new Size(barWidth, WorkloadLabelHeight);
            label.Paint -= WorkloadLabel_Paint;
            label.Paint += WorkloadLabel_Paint;

            int barY = y + WorkloadLabelHeight + 3;
            bar.Location = new Point(RightSidePad, barY);
            bar.Size = new Size(barWidth, WorkloadBarHeight);
            bar.BorderRadius = 3;

            return barY + WorkloadBarHeight + WorkloadRowSpacing;
        }

        private static void WorkloadLabel_Paint(object sender, PaintEventArgs e)
        {
            var label = (Label)sender;
            if (!(label.Tag is string[] parts) || parts.Length < 2) return;

            using (var brush = new SolidBrush(label.BackColor))
                e.Graphics.FillRectangle(brush, label.ClientRectangle);

            TextRenderer.DrawText(e.Graphics, parts[0], label.Font,
                label.ClientRectangle, label.ForeColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            TextRenderer.DrawText(e.Graphics, parts[1], label.Font,
                label.ClientRectangle, label.ForeColor,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }

        private void SetupQuickActions()
        {
            WireQuickButton(btnQuick1, "Thêm bệnh nhân", "Đăng ký mới", 12);
            WireQuickButton(btnQuick2, "Tạo HSBA", "Hồ sơ bệnh án", 4);
            WireQuickButton(btnQuick3, "Phân công KTV", "Chẩn đoán hỗ trợ", 5);
            WireQuickButton(btnQuick4, "Thông báo", "4 chưa đọc", 6);
        }

        private static void WireQuickButton(Guna2Button button, string title, string subtitle, int iconIndex)
        {
            DpvAssets.ApplyButtonImage(button, iconIndex, 28);
            button.ImageOffset = new Point(12, 0);
            button.Tag = new object[] { title, subtitle, iconIndex };
            button.Text = string.Empty;
            button.HoverState.FillColor = Color.FromArgb(230, 244, 240);
            button.HoverState.BorderColor = Color.FromArgb(15, 110, 86);
            button.Paint -= QuickButton_Paint;
            button.Paint += QuickButton_Paint;
            button.Invalidate();
        }

        private static void QuickButton_Paint(object sender, PaintEventArgs e)
        {
            var button = (Guna2Button)sender;
            if (!(button.Tag is object[] tag) || tag.Length < 2) return;

            string title = tag[0].ToString();
            string subtitle = tag[1].ToString();
            const int textLeft = 54;
            int textAreaW = button.Width - textLeft - 8;

            // Đo chiều cao title có word-wrap
            Size titleSize = TextRenderer.MeasureText(title, QuickTitleFont,
                new Size(textAreaW, 0), TextFormatFlags.Left | TextFormatFlags.WordBreak);
            int subHeight = TextRenderer.MeasureText(subtitle, QuickSubFont).Height;
            int blockHeight = titleSize.Height + subHeight + 1;
            int titleTop = (button.Height - blockHeight) / 2;

            TextRenderer.DrawText(e.Graphics, title, QuickTitleFont,
                new Rectangle(textLeft, titleTop, textAreaW, titleSize.Height),
                QuickTitleColor,
                TextFormatFlags.Left | TextFormatFlags.NoPadding | TextFormatFlags.WordBreak);

            TextRenderer.DrawText(e.Graphics, subtitle, QuickSubFont,
                new Point(textLeft, titleTop + titleSize.Height + 1), QuickSubColor,
                TextFormatFlags.Left | TextFormatFlags.NoPadding);
        }

        private static void SetKpiIcon(Guna2PictureBox box, int index)
        {
            box.Image = DpvAssets.Load(index);
            box.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void SetupPatientGrid()
        {
            var headerBack = Color.FromArgb(247, 249, 248);
            var headerFore = Color.FromArgb(122, 149, 137);

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
            dgvPatients.RowTemplate.Height = 56;
            dgvPatients.MultiSelect = false;

            foreach (DataGridViewColumn col in dgvPatients.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            ApplyPatientColumnWeights();
            UpdateStatusColumnMinWidth();

            dgvPatients.MouseMove -= dgvPatients_MouseMove;
            dgvPatients.MouseMove += dgvPatients_MouseMove;
            dgvPatients.MouseLeave -= dgvPatients_MouseLeave;
            dgvPatients.MouseLeave += dgvPatients_MouseLeave;
            dgvPatients.ColumnHeaderMouseClick -= dgvPatients_ColumnHeaderMouseClick;
            dgvPatients.ColumnHeaderMouseClick += dgvPatients_ColumnHeaderMouseClick;
            dgvPatients.CellClick += dgvPatients_CellClick;

            if (_allPatientsData.Count == 0)
            {
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0156", TenBenhNhan = "Nguyễn Văn An", Khoa = "Tim mạch", DichVuCan = "Siêu âm tim", TrangThai = "Chờ phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0157", TenBenhNhan = "Trần Thị Bích", Khoa = "Nội tổng quát", DichVuCan = "Xét nghiệm máu", TrangThai = "Đã phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0158", TenBenhNhan = "Phạm Quốc Hùng", Khoa = "Chỉnh hình", DichVuCan = "Chụp X-quang", TrangThai = "Chờ phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0159", TenBenhNhan = "Lê Thị Mai", Khoa = "Thần kinh", DichVuCan = "Điện não đồ", TrangThai = "Hoàn thành" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0160", TenBenhNhan = "Võ Minh Tuấn", Khoa = "Tim mạch", DichVuCan = "Holter ECG", TrangThai = "Đã phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0161", TenBenhNhan = "Đinh Công Sơn", Khoa = "Tim mạch", DichVuCan = "MRI tim", TrangThai = "Chờ phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0162", TenBenhNhan = "Ngô Thị Hằng", Khoa = "Nội tổng quát", DichVuCan = "Xét nghiệm máu", TrangThai = "Hoàn thành" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0163", TenBenhNhan = "Phan Thanh Bình", Khoa = "Chỉnh hình", DichVuCan = "Chụp CT scan", TrangThai = "Chờ phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0164", TenBenhNhan = "Lâm Kiến Quốc", Khoa = "Thần kinh", DichVuCan = "Chụp MRI não", TrangThai = "Chờ phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0165", TenBenhNhan = "Hoàng Xuân Hùng", Khoa = "Tim mạch", DichVuCan = "Điện tâm đồ", TrangThai = "Đã phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0166", TenBenhNhan = "Nguyễn Thị Đào", Khoa = "Nội tổng quát", DichVuCan = "Siêu âm bụng", TrangThai = "Hoàn thành" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0167", TenBenhNhan = "Đặng Minh Triết", Khoa = "Chỉnh hình", DichVuCan = "Nội soi khớp", TrangThai = "Chờ phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0168", TenBenhNhan = "Bùi Mỹ Nhân", Khoa = "Thần kinh", DichVuCan = "Điện cơ EMG", TrangThai = "Đã phân công" });
                _allPatientsData.Add(new DashboardPatientRecord { MaHsba = "HSBA-0169", TenBenhNhan = "Lê Hoàng Nam", Khoa = "Tim mạch", DichVuCan = "Siêu âm tim Doppler", TrangThai = "Chờ phân công" });
            }

            dgvPatients.ScrollBars = ScrollBars.Vertical;
            RenderAllData();
        }

        private void RenderAllData()
        {
            dgvPatients.Rows.Clear();
            foreach (var record in _allPatientsData)
            {
                dgvPatients.Rows.Add(record.MaHsba, record.TenBenhNhan, record.Khoa, record.DichVuCan, record.TrangThai);
            }
            
            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
            UpdateStatusColumnMinWidth();
        }

        /// <summary>
        /// Nạp dữ liệu thật từ cơ sở dữ liệu để tự động hiển thị và hỗ trợ cuộn dọc.
        /// </summary>
        public void SetPatientsData(List<DashboardPatientRecord> data)
        {
            _allPatientsData = data ?? new List<DashboardPatientRecord>();
            RenderAllData();
        }

        /// <summary>Gọi sau khi bind dữ liệu thật vào bảng để căn lại cột trạng thái.</summary>
        public void RefreshPatientGridLayout()
        {
            UpdateStatusColumnMinWidth();
            dgvPatients.Invalidate();
        }

        /// <summary>
        /// Cập nhật số liệu hiển thị trên các thẻ KPI đầu trang từ cơ sở dữ liệu.
        /// </summary>
        public void UpdateKpiStats(int todayPatients, int openFiles, int pendingKtv, int completedServices)
        {
            lblKpi1Val.Text = todayPatients.ToString();
            lblKpi2Val.Text = openFiles.ToString();
            lblKpi3Val.Text = pendingKtv.ToString();
            lblKpi4Val.Text = completedServices.ToString();

            // Cập nhật lại layout các nhãn thông số bên trong thẻ
            ArrangeKpiRow();
        }

        /// <summary>
        /// Xóa danh sách hoạt động gần đây hiện tại để chuẩn bị nạp dữ liệu thật.
        /// </summary>
        public void ClearActivities()
        {
            flpActivity.Controls.Clear();
        }

        /// <summary>
        /// Thêm động một hoạt động gần đây từ cơ sở dữ liệu vào danh sách hiển thị.
        /// </summary>
        public void AppendActivity(string imageName, Color iconBack, string formattedText, string metaText)
        {
            AddActivity(imageName, iconBack, formattedText, metaText);
        }

        private void ApplyPatientColumnWeights()
        {
            colMaBN.FillWeight = 15F;
            colHoTen.FillWeight = 20F;
            colKhoa.FillWeight = 17F;
            colBacSi.FillWeight = 18F;
            colStatus.FillWeight = 30F;
            colStatus.MinimumWidth = StatusColumnMinWidth;
        }

        private void UpdateStatusColumnMinWidth()
        {
            int maxPill = StatusColumnMinWidth;
            using (Graphics g = dgvPatients.CreateGraphics())
            {
                foreach (DataGridViewRow row in dgvPatients.Rows)
                {
                    if (row.IsNewRow) continue;
                    string status = Convert.ToString(row.Cells[colStatus.Index].Value);
                    if (string.IsNullOrEmpty(status)) continue;
                    maxPill = Math.Max(maxPill, MeasureStatusPillWidth(g, status, int.MaxValue));
                }
            }

            colStatus.MinimumWidth = maxPill + 12;
        }

        private static int MeasureStatusPillWidth(Graphics g, string text, int maxWidth)
        {
            int textW = TextRenderer.MeasureText(g, text, StatusFont, Size.Empty,
                TextFormatFlags.NoPadding | TextFormatFlags.SingleLine).Width;
            int needed = textW + StatusPillHorizontalPad;
            return Math.Min(maxWidth, Math.Max(needed, 80));
        }

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
        }

        private void dgvPatients_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
        }

        private void dgvPatients_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hit = dgvPatients.HitTest(e.X, e.Y);
            int nextRow = hit.RowIndex >= 0 ? hit.RowIndex : -1;
            if (_hoveredPatientRow == nextRow) return;

            int oldRow = _hoveredPatientRow;
            _hoveredPatientRow = nextRow;
            dgvPatients.Cursor = _hoveredPatientRow >= 0 ? Cursors.Hand : Cursors.Default;
            InvalidatePatientRow(oldRow);
            InvalidatePatientRow(_hoveredPatientRow);
        }

        private void dgvPatients_MouseLeave(object sender, EventArgs e)
        {
            int oldRow = _hoveredPatientRow;
            _hoveredPatientRow = -1;
            dgvPatients.Cursor = Cursors.Default;
            InvalidatePatientRow(oldRow);
        }

        private void InvalidatePatientRow(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < dgvPatients.Rows.Count)
                dgvPatients.InvalidateRow(rowIndex);
        }

        private void SetupWorkloadBars()
        {
            SetWorkload(pbTimMach, 6, 8, Color.FromArgb(255, 167, 38));
            SetWorkload(pbNoiTongQuat, 5, 6, Color.FromArgb(229, 57, 53));
            SetWorkload(pbChinhHinh, 3, 5, Color.FromArgb(15, 110, 86));
            SetWorkload(pbThanKinh, 4, 5, Color.FromArgb(0, 150, 136));
        }

        private static void SetWorkload(Guna2ProgressBar bar, int current, int max, Color color)
        {
            bar.Maximum = max;
            bar.Value = current;
            bar.ProgressColor = color;
            bar.ProgressColor2 = color;
            bar.FillColor = WorkloadTrackColor;
        }

        private void SetupActivityList()
        {
            flpActivity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            flpActivity.FlowDirection = FlowDirection.TopDown;
            flpActivity.WrapContents = false;
            flpActivity.AutoScroll = true;

            flpActivity.Resize -= FlpActivity_Resize;
            flpActivity.Resize += FlpActivity_Resize;

            flpActivity.Controls.Clear();
            AddActivity("buttonTick.png", Color.FromArgb(230, 244, 240),
                "KTV **Bùi Trọng Nghĩa** hoàn thành siêu âm cho bệnh nhân **BN240003**", "08:42 — Tim mạch");
            AddActivity("dpv_4.png", Color.FromArgb(255, 248, 225),
                "Hồ sơ bệnh án **HSBA-2024-0156** đã được tạo cho bệnh nhân Nguyễn Văn An", "08:15 — Điều phối viên");
            AddActivity("dpv_9.png", Color.FromArgb(253, 236, 234),
                "Cảnh báo OLS: Phòng **Nội tổng quát** đang quá tải – 18/20 bệnh nhân", "07:50 — Hệ thống OLS");
            AddActivity("dpv_12.png", Color.FromArgb(237, 231, 246),
                "Bệnh nhân **Trần Thị Mai** được đăng ký vào khoa Sản khoa – BS. Võ Thu phụ trách", "07:30 — Điều phối viên");
            AddActivity("dpv_10.png", Color.FromArgb(230, 248, 246),
                "KTV **Lý Thị Hoa** được phân công xét nghiệm máu cho **BN240002**", "07:05 — Điều phối viên");
        }

        private void FlpActivity_Resize(object sender, EventArgs e)
        {
            int targetW = flpActivity.ClientSize.Width - 8;
            foreach (Control c in flpActivity.Controls)
            {
                if (c is Panel row)
                {
                    row.Width = targetW;
                    foreach (Control child in row.Controls)
                    {
                        if (child.Name == "lblText")
                        {
                            child.Width = targetW - 60;
                        }
                    }
                }
            }
        }

        private static Color GetDotColor(Color iconBack)
        {
            if (iconBack.R == 230 && iconBack.G == 244 && iconBack.B == 240) // light green (success)
                return Color.FromArgb(15, 110, 86);
            if (iconBack.R == 255 && iconBack.G == 248 && iconBack.B == 225) // light orange (warning/info)
                return Color.FromArgb(232, 168, 56);
            if (iconBack.R == 253 && iconBack.G == 236 && iconBack.B == 234) // light red (danger)
                return Color.FromArgb(229, 57, 53);
            if (iconBack.R == 237 && iconBack.G == 231 && iconBack.B == 246) // light purple
                return Color.FromArgb(103, 58, 183);
            if (iconBack.R == 230 && iconBack.G == 248 && iconBack.B == 246) // light teal
                return Color.FromArgb(0, 150, 136);
            return Color.FromArgb(15, 110, 86);
        }

        private void AddActivity(string imageName, Color iconBack, string text, string meta)
        {
            int initialW = flpActivity.ClientSize.Width > 0 ? flpActivity.ClientSize.Width - 8 : 1000;
            var row = new Panel
            {
                Width = initialW,
                Height = 64,
                Margin = new Padding(0, 0, 0, 0),
                BackColor = Color.White
            };

            Color dotColor = GetDotColor(iconBack);

            row.Paint += (s, e) =>
            {
                var pnl = (Panel)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (var pen = new Pen(Color.FromArgb(240, 244, 242), 1))
                {
                    e.Graphics.DrawLine(pen, 0, pnl.Height - 1, pnl.Width, pnl.Height - 1);
                }

                // Draw solid circular dot as status indicator instead of rendering too many icons
                using (var brush = new SolidBrush(dotColor))
                {
                    e.Graphics.FillEllipse(brush, 24, 28, 8, 8);
                }
            };

            var lblText = new Label
            {
                Name = "lblText",
                Tag = text,
                Text = string.Empty,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(48, 6),
                Size = new Size(row.Width - 60, 30),
                AutoSize = false,
                BackColor = Color.Transparent
            };

            lblText.Paint += (s, e) =>
            {
                var lbl = (Label)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string rawText = lbl.Tag != null ? lbl.Tag.ToString() : string.Empty;
                string[] parts = rawText.Split(new string[] { "**" }, StringSplitOptions.None);
                
                int currentX = 0;
                int currentY = (lbl.Height - 22) / 2;
                
                using (var regFont = new Font("Segoe UI", 10.5F, FontStyle.Regular))
                using (var boldFont = new Font("Segoe UI", 10.5F, FontStyle.Bold))
                {
                    for (int i = 0; i < parts.Length; i++)
                    {
                        if (string.IsNullOrEmpty(parts[i])) continue;
                        bool isBold = (i % 2 == 1);
                        Font font = isBold ? boldFont : regFont;
                        Color textCol = isBold ? Color.FromArgb(15, 110, 86) : lbl.ForeColor;

                        Size size = TextRenderer.MeasureText(e.Graphics, parts[i], font, 
                            new Size(lbl.Width - currentX, lbl.Height),
                            TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);

                        TextRenderer.DrawText(e.Graphics, parts[i], font, new Point(currentX, currentY), textCol,
                            TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);

                        currentX += size.Width;
                    }
                }
            };

            var lblMeta = new Label
            {
                Name = "lblMeta",
                Text = meta,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(48, 36),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            row.Controls.Add(lblText);
            row.Controls.Add(lblMeta);
            flpActivity.Controls.Add(row);
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
            bool hovered = e.RowIndex == _hoveredPatientRow;
            Color bg = hovered ? RowHoverBack : Color.White;

            using (var brush = new SolidBrush(bg))
                e.Graphics.FillRectangle(brush, cell);

            if (e.ColumnIndex == colMaBN.Index)
            {
                TextRenderer.DrawText(e.Graphics, value, MaBnFont,
                    new Rectangle(cell.X + 14, cell.Y, cell.Width - 16, cell.Height),
                    Color.FromArgb(15, 110, 86),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                e.Handled = true;
                return;
            }

            if (e.ColumnIndex == colStatus.Index)
            {
                GetStatusColors(value, out Color back, out Color fore, out Color dot);
                int maxPillW = cell.Width - 16;
                int pillWidth = MeasureStatusPillWidth(e.Graphics, value, maxPillW);
                Rectangle pill = new Rectangle(cell.X + 12, cell.Y + (cell.Height - 30) / 2, pillWidth, 30);
                e.Graphics.FillRoundedRectangle(new SolidBrush(back), pill, 14);
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

            TextRenderer.DrawText(e.Graphics, value, dgvPatients.DefaultCellStyle.Font,
                new Rectangle(cell.X + 14, cell.Y, cell.Width - 18, cell.Height),
                Color.FromArgb(61, 82, 73),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
        }

        private static void GetStatusColors(string status, out Color back, out Color fore, out Color dot)
        {
            back = Color.FromArgb(238, 242, 240);
            fore = Color.FromArgb(122, 149, 137);
            dot = fore;
            switch (status)
            {
                case "Chờ phân công":
                    back = Color.FromArgb(253, 236, 234);
                    fore = dot = Color.FromArgb(229, 57, 53);
                    break;
                case "Đã phân công":
                    back = Color.FromArgb(230, 244, 240);
                    fore = dot = Color.FromArgb(15, 110, 86);
                    break;
                case "Hoàn thành":
                    back = Color.FromArgb(227, 242, 253);
                    fore = dot = Color.FromArgb(25, 118, 210);
                    break;
            }
        }

        private void btnViewAllPatients_Click(object sender, EventArgs e)
        {
            if (FindForm() is Main_DPV dlg)
                dlg.NavigateToDieuPhoiKTV();
        }

        private void btnViewAllActivity_Click(object sender, EventArgs e)
        {
            if (FindForm() is Main_DPV dlg)
                dlg.NavigateToHoSoCaNhan();
        }

        private void btnQuick_Click(object sender, EventArgs e)
        {
            if (!(FindForm() is Main_DPV dlg)) return;

            var btn = (Guna2Button)sender;
            string action = btn.Tag is object[] tag && tag.Length > 0 ? tag[0].ToString() : string.Empty;

            switch (action)
            {
                case "Thêm bệnh nhân":
                    dlg.NavigateToThemSuaBN();
                    break;
                case "Tạo HSBA":
                    dlg.NavigateToTaoHSBA();
                    break;
                case "Phân công KTV":
                    dlg.NavigateToDieuPhoiKTV();
                    break;
                case "Thông báo":
                    dlg.NavigateToThongBao();
                    break;
            }
        }

        private static void ShowInfo(Main_DPV form, string message)
        {
            form.ShowMessage(message, "Thông báo");
        }
    }
}

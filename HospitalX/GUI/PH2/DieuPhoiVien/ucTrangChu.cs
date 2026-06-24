using Guna.UI2.WinForms;
using HospitalX.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Data;

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
        private const int StatusColumnMinWidth = 130;

        private int _hoveredPatientRow = -1;
        private bool _isLayoutInProgress = false;

        private Guna2Panel pnlBanner;
        private Guna2Panel pnlBannerAvatar;
        private Label lblBannerAvatarText;
        private Label lblBannerTitle;
        private Label lblBannerSubtitle;

        private readonly Guna2Panel[] _kpiCards;
        private readonly Label[] _kpiIcons;
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
            _kpiIcons = new[] { lblKpi1Icon, lblKpi2Icon, lblKpi3Icon, lblKpi4Icon };
            _kpiCaps = new[] { lblKpi1Cap, lblKpi2Cap, lblKpi3Cap, lblKpi4Cap };
            _kpiVals = new[] { lblKpi1Val, lblKpi2Val, lblKpi3Val, lblKpi4Val };
            _kpiSubs = new[] { lblKpi1Sub, lblKpi2Sub, lblKpi3Sub, lblKpi4Sub };
        }

        private void ucTrangChu_Load(object sender, EventArgs e)
        {
            BuildWelcomeBanner();
            ConfigureCardStyles();
            SetupKpiVisuals();
            SetupSectionHeaders();
            SetupQuickActions();
            SetupPatientGrid();
            LayoutMiddleSection();
            pnlMiddle.Resize += (s, ev) => LayoutMiddleSection();
            pnlScroll.Resize += (s, ev) => LayoutMiddleSection();
            SetupWorkloadBars();
            SetupActivityList();
            RelayoutScrollContent();
            LoadRealDashboardData();
        }

        private void LoadRealDashboardData()
        {
            try
            {
                // 1. Load KPI Stats
                DataTable dtStats = HospitalX.DAO.DashboardDAO.GetDashboardDPV();
                if (dtStats != null && dtStats.Rows.Count > 0)
                {
                    DataRow row = dtStats.Rows[0];
                    int todayNotices = row.Table.Columns.Contains("TODAY_NOTICES") && row["TODAY_NOTICES"] != DBNull.Value ? Convert.ToInt32(row["TODAY_NOTICES"]) : 0;
                    int activeKtvs = row.Table.Columns.Contains("ACTIVE_KTVS") && row["ACTIVE_KTVS"] != DBNull.Value ? Convert.ToInt32(row["ACTIVE_KTVS"]) : 0;
                    int pendingKtv = row.Table.Columns.Contains("PENDING_KTV") && row["PENDING_KTV"] != DBNull.Value ? Convert.ToInt32(row["PENDING_KTV"]) : 0;
                    int completedServices = row.Table.Columns.Contains("COMPLETED_SERVICES") && row["COMPLETED_SERVICES"] != DBNull.Value ? Convert.ToInt32(row["COMPLETED_SERVICES"]) : 0;

                    UpdateKpiStats(todayNotices, activeKtvs, pendingKtv, completedServices);
                    WireQuickButton(btnQuick4, "Thông báo", todayNotices + " hôm nay", 6, Color.FromArgb(229, 57, 53));

                    // Cập nhật thông tin chào mừng và thống kê trên Banner của DPV
                    string dpvName = "Điều phối viên";
                    try
                    {
                        DataTable dtProfile = HospitalX.DAO.ProfileDAO.Instance.GetProfile();
                        if (dtProfile != null && dtProfile.Rows.Count > 0)
                        {
                            dpvName = dtProfile.Rows[0]["HOTEN"]?.ToString() ?? "Điều phối viên";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Warning: Lỗi load profile DPV cho banner: " + ex.Message);
                    }

                    lblBannerTitle.Text = $"Chào buổi sáng, Điều phối viên {dpvName}";
                    if (!string.IsNullOrEmpty(dpvName) && dpvName != "Điều phối viên")
                    {
                        string[] parts = dpvName.Trim().Split(' ');
                        string lastWord = parts[parts.Length - 1];
                        if (!string.IsNullOrEmpty(lastWord))
                        {
                            lblBannerAvatarText.Text = lastWord.Substring(0, 1).ToUpperInvariant();
                        }
                    }

                    lblBannerSubtitle.Text = $"Hôm nay hệ thống có {todayNotices} thông báo mới và {pendingKtv} hồ sơ bệnh án đang chờ điều phối kỹ thuật viên.";
                }

                // 2. Load Patient Grid
                DataTable dtPatients = HospitalX.DAO.DashboardDAO.GetPatientsNeedAssignment();
                _allPatientsData.Clear();
                if (dtPatients != null && dtPatients.Rows.Count > 0)
                {
                    foreach (DataRow row in dtPatients.Rows)
                    {
                        _allPatientsData.Add(new DashboardPatientRecord
                        {
                            MaHsba = row["MAHSBA"] != DBNull.Value ? Convert.ToString(row["MAHSBA"]) : string.Empty,
                            TenBenhNhan = row["TEN_BENH_NHAN"] != DBNull.Value ? Convert.ToString(row["TEN_BENH_NHAN"]) : string.Empty,
                            Khoa = row["KHOA"] != DBNull.Value ? Convert.ToString(row["KHOA"]) : string.Empty,
                            DichVuCan = row["DICH_VU_CAN"] != DBNull.Value ? Convert.ToString(row["DICH_VU_CAN"]) : string.Empty,
                            TrangThai = string.Empty
                        });
                    }
                }
                RenderAllData();

                // 3. Load Workload Bars (Skipped: section hidden on UI)
                // 4. Load Activity List (Skipped: section hidden on UI)
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading real dashboard data, falling back to mock: " + ex.Message);
                MessageBox.Show("Lỗi tải dữ liệu từ database:\n" + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigureCardStyles()
        {
            pnlWorkload.Visible = false;
            pnlActivity.Visible = false;

            foreach (var panel in new[] { pnlPatients, pnlQuick })
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
                card.Padding = Padding.Empty;
            }

            ArrangeKpiRow();
            pnlKpiRow.Resize += (s, ev) =>
            {
                ArrangeKpiRow();
                RelayoutScrollContent();
            };

            pnlMiddle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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

            string[] iconTexts = { "TB", "KT", "CĐ", "OK" };

            Color[] iconBacks =
            {
                Color.FromArgb(230, 244, 240),  // Light teal
                Color.FromArgb(255, 244, 220),  // Light orange/yellow
                Color.FromArgb(227, 242, 253),  // Light blue
                Color.FromArgb(230, 248, 246)   // Light teal/mint
            };

            Color[] iconFores =
            {
                Color.FromArgb(15, 110, 86),    // Dark teal
                Color.FromArgb(232, 168, 56),   // Dark orange/yellow
                Color.FromArgb(30, 136, 229),   // Dark blue
                Color.FromArgb(43, 181, 160)    // Dark teal/mint
            };

            string[] subTexts =
            {
                "Hôm nay",
                "Đang làm việc",
                "Chờ xử lý",
                "Hôm nay"
            };

            Color[] subBacks =
            {
                Color.FromArgb(253, 236, 234),  // Light red
                Color.FromArgb(230, 244, 240),  // Light green
                Color.FromArgb(253, 236, 234),  // Light red
                Color.FromArgb(230, 244, 240)   // Light green
            };

            Color[] subFores =
            {
                Color.FromArgb(217, 79, 61),   // Dark red
                Color.FromArgb(15, 110, 86),    // Dark green
                Color.FromArgb(217, 79, 61),   // Dark red
                Color.FromArgb(15, 110, 86)     // Dark green
            };

            for (int i = 0; i < _kpiCards.Length; i++)
            {
                _kpiCards[i].Tag = accents[i];

                // Configure Icon Badge
                _kpiIcons[i].Text = iconTexts[i];
                _kpiIcons[i].Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                _kpiIcons[i].TextAlign = ContentAlignment.MiddleCenter;
                _kpiIcons[i].BackColor = iconBacks[i];
                _kpiIcons[i].ForeColor = iconFores[i];

                // Configure Caption (bottom description)
                _kpiCaps[i].Font = new Font("Segoe UI Semibold", 8.75F, FontStyle.Bold);
                _kpiCaps[i].Padding = Padding.Empty;
                _kpiCaps[i].ForeColor = Color.FromArgb(122, 149, 137);
                if (i == 0)
                {
                    _kpiCaps[i].Text = "THÔNG BÁO HÔM NAY";
                }

                // Configure Value
                _kpiVals[i].Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
                _kpiVals[i].ForeColor = Color.FromArgb(24, 48, 42);

                // Configure Sub Badge (top-right trend)
                _kpiSubs[i].Text = subTexts[i];
                _kpiSubs[i].Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                _kpiSubs[i].TextAlign = ContentAlignment.MiddleCenter;
                _kpiSubs[i].BackColor = subBacks[i];
                _kpiSubs[i].ForeColor = subFores[i];
                _kpiSubs[i].AutoSize = false;
            }
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

        private static void LayoutKpiCardContents(Guna2Panel card, Label icon, Label cap, Label val, Label sub)
        {
            const int pad = 22;
            const int topMargin = 20;
            int cardW = card.ClientSize.Width > 0 ? card.ClientSize.Width : card.Width;

            // 1. Icon Badge (top-left)
            icon.Location = new Point(pad, topMargin);
            icon.Size = new Size(48, 42);

            // 2. Trend/Status Badge (top-right)
            sub.AutoSize = false;
            sub.Size = new Size(110, 24);
            sub.TextAlign = ContentAlignment.MiddleCenter;
            sub.Location = new Point(cardW - pad - sub.Width, topMargin + 9); // center vertically with 42px icon

            // 3. Value Label (middle-left)
            val.AutoSize = true;
            val.Location = new Point(pad, topMargin + 42 + 8); // 20 + 42 + 8 = 70

            // 4. Caption Label (bottom-left)
            cap.AutoSize = false;
            cap.Size = new Size(cardW - pad * 2, 20);
            cap.TextAlign = ContentAlignment.MiddleLeft;

            // Force dynamic layout update to read val.Bottom correctly
            val.Update();
            cap.Location = new Point(pad, val.Bottom + 4);

            icon.BringToFront();
            sub.BringToFront();
            val.BringToFront();
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
            if (pnlScroll.ClientSize.Width <= 0) return;

            // Save and temporarily reset the scroll position to prevent coordinate shifting during layout calculations
            Point scrollPos = pnlScroll.AutoScrollPosition;
            pnlScroll.AutoScrollPosition = new Point(0, 0);

            int contentW = Math.Max(960, pnlScroll.ClientSize.Width - 40);

            if (pnlBanner != null)
            {
                pnlBanner.Width = contentW;
                lblBannerTitle.Width = contentW - 150;
                lblBannerSubtitle.Width = contentW - 150;
            }
            pnlKpiRow.Width = contentW;
            pnlMiddle.Width = contentW;
            LayoutMiddleSection();

            // Perform positioning in non-scrolled coordinates
            if (pnlBanner != null)
            {
                pnlBanner.Location = new Point(27, 20); // 27 is the standard X coordinate in designer
                pnlKpiRow.Location = new Point(27, pnlBanner.Bottom + 24);
            }
            else
            {
                pnlKpiRow.Location = new Point(27, 20);
            }

            pnlMiddle.Location = new Point(27, pnlKpiRow.Bottom + 24);

            pnlScroll.AutoScrollMinSize = new Size(0, pnlMiddle.Bottom + 32);

            // Restore the scroll position (AutoScrollPosition takes positive values)
            pnlScroll.AutoScrollPosition = new Point(Math.Abs(scrollPos.X), Math.Abs(scrollPos.Y));
        }



        private void SetupSectionHeaders()
        {
            // Reposition titles to start at X=21 for left alignment (matching content padding)
            lblPatientsTitle.Location = new Point(21, 22);
            lblQuickTitle.Location = new Point(21, 20);
            lblWorkloadTitle.Location = new Point(21, 18);

            lblPatientsTitle.Text = "Hồ sơ cần phân công KTV";
            lblActivityTitle.Text = "Hoạt động gần đây";
            lblActivityTitle.Location = new Point(24, 22); // Bell icon is removed, so align label text to the left
        }

        private void LayoutMiddleSection()
        {
            if (_isLayoutInProgress) return;
            _isLayoutInProgress = true;

            try
            {
                int totalW = pnlMiddle.ClientSize.Width;
                if (totalW <= 0) return;

                int patientsH = 500;
                pnlPatients.SetBounds(0, 0, totalW, patientsH);

                // Programmatically position and size controls inside pnlPatients to prevent layout engine clipping
                lblPatientsTitle.Location = new Point(20, 18);
                btnViewAllPatients.Location = new Point(pnlPatients.Width - btnViewAllPatients.Width - 20, 12);
                dgvPatients.Location = new Point(20, 64);
                dgvPatients.Size = new Size(pnlPatients.Width - 40, pnlPatients.Height - 84);

                lblPatientsTitle.BringToFront();
                btnViewAllPatients.BringToFront();
                dgvPatients.BringToFront();

                int quickY = patientsH + 20;
                int quickH = 160;
                pnlQuick.SetBounds(0, quickY, totalW, quickH);
                LayoutQuickPanel(totalW, quickH);

                pnlMiddle.Height = pnlQuick.Bottom + 8;
            }
            finally
            {
                _isLayoutInProgress = false;
            }
        }

        private void LayoutQuickPanel(int panelWidth, int panelHeight)
        {
            int btnW = (panelWidth - RightSidePad * 2 - QuickButtonGap * 3) / 4;

            // Đường kẻ ngang: dưới tiêu đề 8px để có khoảng cách cân đối
            int dividerY = SectionHeaderHeight + 10;
            pnlQuickDivider.Location = new Point(RightSidePad, dividerY);
            pnlQuickDivider.Size = new Size(panelWidth - RightSidePad * 2, 1);

            // Vùng nội dung bắt đầu sau divider + 12px khoảng cách
            int contentTop = dividerY + 13;
            int btnH = 80;
            int iconSize = 28;

            lblQuickTitle.Location = new Point(20, 18);
            lblQuickTitle.BringToFront();
            pnlQuickDivider.BringToFront();

            PlaceQuickButton(btnQuick1, RightSidePad, contentTop, btnW, btnH, iconSize);
            PlaceQuickButton(btnQuick2, RightSidePad + btnW + QuickButtonGap, contentTop, btnW, btnH, iconSize);
            PlaceQuickButton(btnQuick3, RightSidePad + (btnW + QuickButtonGap) * 2, contentTop, btnW, btnH, iconSize);
            PlaceQuickButton(btnQuick4, RightSidePad + (btnW + QuickButtonGap) * 3, contentTop, btnW, btnH, iconSize);

            btnQuick1.BringToFront();
            btnQuick2.BringToFront();
            btnQuick3.BringToFront();
            btnQuick4.BringToFront();
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
            WireQuickButton(btnQuick1, "Thêm bệnh nhân", "Đăng ký mới", 12, Color.FromArgb(15, 110, 86));    // Green
            WireQuickButton(btnQuick2, "Tạo HSBA", "Hồ sơ bệnh án", 4, Color.FromArgb(255, 179, 0));       // Amber
            WireQuickButton(btnQuick3, "Phân công KTV", "Chẩn đoán hỗ trợ", 5, Color.FromArgb(25, 118, 210)); // Blue
            WireQuickButton(btnQuick4, "Thông báo", "Hôm nay", 6, Color.FromArgb(229, 57, 53));        // Red
        }

        private static void WireQuickButton(Guna2Button button, string title, string subtitle, int iconIndex, Color accentColor)
        {
            button.Image = null; // Remove icons from buttons
            button.Tag = new object[] { title, subtitle, iconIndex, accentColor };
            button.Text = string.Empty;

            // Dynamically assign matching light hover background based on accent color
            Color hoverFill;
            if (accentColor == Color.FromArgb(15, 110, 86))      // Green
                hoverFill = Color.FromArgb(230, 244, 240);
            else if (accentColor == Color.FromArgb(255, 179, 0)) // Amber
                hoverFill = Color.FromArgb(255, 248, 225);
            else if (accentColor == Color.FromArgb(25, 118, 210)) // Blue
                hoverFill = Color.FromArgb(227, 242, 253);
            else if (accentColor == Color.FromArgb(229, 57, 53))  // Red
                hoverFill = Color.FromArgb(253, 236, 234);
            else
                hoverFill = Color.FromArgb(230, 244, 240);

            button.HoverState.FillColor = hoverFill;
            button.HoverState.BorderColor = accentColor;
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

            // Draw left accent color bar inside the button's rounded corners (BorderRadius = 10)
            if (tag.Length >= 4 && tag[3] is Color accentColor)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = GetRoundedRectPath(new RectangleF(0, 0, button.Width, button.Height), 10))
                {
                    e.Graphics.SetClip(path);
                    using (var brush = new SolidBrush(accentColor))
                    {
                        e.Graphics.FillRectangle(brush, 0, 0, 4, button.Height);
                    }
                    e.Graphics.ResetClip();
                }
            }

            const int textLeft = 24; // Shift text to X=24 to leave padding after the 4px accent line!
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

            dgvPatients.MouseMove -= dgvPatients_MouseMove;
            dgvPatients.MouseMove += dgvPatients_MouseMove;
            dgvPatients.MouseLeave -= dgvPatients_MouseLeave;
            dgvPatients.MouseLeave += dgvPatients_MouseLeave;
            dgvPatients.ColumnHeaderMouseClick -= dgvPatients_ColumnHeaderMouseClick;
            dgvPatients.ColumnHeaderMouseClick += dgvPatients_ColumnHeaderMouseClick;
            dgvPatients.CellClick += dgvPatients_CellClick;

            dgvPatients.Paint += (s, ev) =>
            {
                if (dgvPatients.Rows.Count == 0)
                {
                    int headerHeight = dgvPatients.ColumnHeadersVisible ? dgvPatients.ColumnHeadersHeight : 0;
                    Rectangle rect = new Rectangle(0, headerHeight, dgvPatients.Width, dgvPatients.Height - headerHeight);
                    using (StringFormat sf = new StringFormat
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    })
                    using (Font font = new Font("Segoe UI", 11.25F, FontStyle.Regular))
                    using (Brush brush = new SolidBrush(Color.FromArgb(122, 149, 137)))
                    {
                        ev.Graphics.DrawString("Không có hồ sơ cần phân công", font, brush, rect, sf);
                    }
                }
            };

            dgvPatients.ScrollBars = ScrollBars.Vertical;
            RenderAllData();
        }

        private void RenderAllData()
        {
            dgvPatients.Rows.Clear();
            foreach (var record in _allPatientsData)
            {
                dgvPatients.Rows.Add(record.MaHsba, record.TenBenhNhan, record.Khoa, record.DichVuCan);
            }

            dgvPatients.ClearSelection();
            dgvPatients.CurrentCell = null;
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
            colHoTen.FillWeight = 40F;
            colKhoa.FillWeight = 20F;
            colBacSi.FillWeight = 25F;
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
            SetWorkload(lblPb1, pbTimMach, "KTV Tim mạch", 6, 8, Color.FromArgb(255, 167, 38));
            SetWorkload(lblPb2, pbNoiTongQuat, "KTV Nội tổng quát", 5, 6, Color.FromArgb(229, 57, 53));
            SetWorkload(lblPb3, pbChinhHinh, "KTV Chỉnh hình", 3, 5, Color.FromArgb(15, 110, 86));
            SetWorkload(lblPb4, pbThanKinh, "KTV Thần kinh", 4, 5, Color.FromArgb(0, 150, 136));
        }

        private static void SetWorkload(Label label, Guna2ProgressBar bar, string name, int current, int max, Color color)
        {
            bar.Maximum = max > 0 ? max : 100;
            bar.Value = current;
            bar.ProgressColor = color;
            bar.ProgressColor2 = color;
            bar.FillColor = WorkloadTrackColor;

            label.Tag = new[] { name, $"{current}/{max}" };
            label.Invalidate();
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



            TextRenderer.DrawText(e.Graphics, value, dgvPatients.DefaultCellStyle.Font,
                new Rectangle(cell.X + 14, cell.Y, cell.Width - 18, cell.Height),
                Color.FromArgb(61, 82, 73),
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            e.Handled = true;
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

        private Label TextLabel(string text, int x, int y, int width, int height, float size, FontStyle style, Color color, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            var lbl = new Label();
            lbl.Text = text;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(width, height);
            lbl.Font = new Font("Segoe UI", size, style);
            lbl.ForeColor = color;
            lbl.TextAlign = align;
            lbl.BackColor = Color.Transparent;
            return lbl;
        }

        private void BuildWelcomeBanner()
        {
            pnlBanner = new Guna2Panel
            {
                BorderRadius = 14,
                FillColor = Color.FromArgb(15, 110, 86),
                Size = new Size(pnlKpiRow.Width, 118),
                BackColor = Color.Transparent,
                Location = new Point(pnlKpiRow.Left, 20)
            };

            pnlBannerAvatar = new Guna2Panel
            {
                Size = new Size(60, 60),
                BorderRadius = 14,
                FillColor = Color.FromArgb(66, 132, 114),
                BackColor = Color.Transparent,
                Location = new Point(30, 29)
            };

            lblBannerAvatarText = new Label
            {
                Text = "DP",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };
            pnlBannerAvatar.Controls.Add(lblBannerAvatarText);
            pnlBanner.Controls.Add(pnlBannerAvatar);

            lblBannerTitle = TextLabel("Chào buổi sáng, Điều phối viên!", 110, 26, 500, 34, 18F, FontStyle.Bold, Color.White);
            lblBannerTitle.AutoSize = true;

            lblBannerSubtitle = TextLabel("Đang tải dữ liệu thống kê hôm nay...", 110, 68, 500, 22, 10F, FontStyle.Regular, Color.FromArgb(218, 242, 235));
            lblBannerSubtitle.AutoSize = true;

            pnlBanner.Controls.Add(lblBannerTitle);
            pnlBanner.Controls.Add(lblBannerSubtitle);

            pnlScroll.Controls.Add(pnlBanner);
            pnlBanner.BringToFront();
        }
    }
}

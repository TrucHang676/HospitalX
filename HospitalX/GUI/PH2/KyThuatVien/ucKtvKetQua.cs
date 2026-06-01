using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    public partial class ucKtvKetQua : UserControl
    {
        // Internal classes for clinical details
        private class TestParam
        {
            public string Name { get; set; }
            public string SubName { get; set; }
            public double MinVal { get; set; }
            public double MaxVal { get; set; }
            public string Unit { get; set; }
            public double DefaultVal { get; set; }
            public string DefaultText { get; set; }
            public bool IsTextParam { get; set; }
        }

        private class ParamRowControls
        {
            public TestParam Param { get; set; }
            public Guna2TextBox TxtInput { get; set; }
            public Guna2Panel PnlFlag { get; set; }
            public Label LblFlag { get; set; }
        }

        // Layout UI controls
        private Guna2Panel pnlQueue;
        private Label lblQueueTitle;
        private Label lblQueueCount;
        private Guna2TextBox txtSearchQueue;
        private FlowLayoutPanel pnlQueueItems;

        private Guna2Panel pnlFormContainer;

        // Form Cards
        private Guna2Panel pnlPatientStrip;
        private Guna2Panel pnlAvatarCircle;
        private Label lblAvatarText;
        private Label lblPatientName;
        private Label lblPatientMeta;
        private Guna2Panel pnlPrioBadge;
        private Label lblPrioText;

        private Guna2Panel cardSvc;
        private Label lblSvcTitle;
        private Label lblSvcMeta;
        private Guna2Panel divSvc1;
        private Guna2Panel divSvc2;
        private Label lblParamsTitle;
        private Guna2Panel pnlTableHeader;

        private Guna2Panel cardConclusion;
        private Label lblConclusionHeader;
        private Label lblRemarksLabel;
        private Guna2TextBox txtRemarks;
        private Label lblConclusionDropdownLabel;
        private Guna2ComboBox cboConclusion;
        private Label lblTimeLabel;
        private Guna2DateTimePicker dtpFinishTime;

        private Guna2Panel cardAttachment;
        private Label lblAttachmentHeader;
        private Guna2Panel pnlUploadZone;
        private Label lblUpload1;
        private Label lblUpload2;
        private FlowLayoutPanel flpUploadedFiles;

        private Guna2Panel cardActions;
        private Label lblActionsKtvInfo;
        private Guna2Button btnSaveDraft;
        private Guna2Button btnSendDoctor;
        private Guna2Button btnComplete;

        // Topbar
        private Guna2Panel pnlTopbar;
        private Label lblTopbarTitle;
        private Label lblTopbarSub;
        private Guna2Panel pnlTopbarBadge;
        private Label lblTopbarBadge;
        private const int TopbarHeight = 64;

        // Custom Toast Notification
        private Guna2Panel pnlToast;
        private Label lblToastText;
        private Timer tmrToast;
        private int toastTicks = 0;
        private bool isToastShowing = false;

        // Local state
        private List<KtvService> allServices = new List<KtvService>();
        private KtvService activeService;
        private List<ParamRowControls> activeParamRows = new List<ParamRowControls>();
        private List<string> mockAttachedFiles = new List<string>();

        public ucKtvKetQua()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = KtvTheme.Bg;
            this.AutoScroll = false;

            allServices = KtvData.Services();
            // Start with the first service that is not completed
            activeService = allServices.FirstOrDefault(x => x.Status != "Hoàn thành") ?? allServices.First();

            BuildControls();

            this.Resize += UcKtvKetQua_Resize;
            this.Load += UcKtvKetQua_Load;
        }

        private void UcKtvKetQua_Load(object sender, EventArgs e)
        {
            LayoutControls();
            SelectPatient(activeService);
        }

        private void UcKtvKetQua_Resize(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void BuildControls()
        {
            Controls.Clear();

            // 0. Build Topbar
            pnlTopbar = new Guna2Panel
            {
                FillColor = Color.White,
                BorderRadius = 0,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1
            };
            // Custom bottom border via CustomBorderColor bottom only — use full border, clip top/left/right via thickness=0 trick
            lblTopbarTitle = new Label
            {
                Text = "Cập nhật kết quả dịch vụ",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = KtvTheme.TextDark,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            lblTopbarSub = new Label
            {
                Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                ForeColor = KtvTheme.TextLight,
                AutoSize = true,
                BackColor = Color.Transparent
            };
            pnlTopbarBadge = new Guna2Panel
            {
                Size = new Size(130, 28),
                BorderRadius = 14,
                FillColor = KtvTheme.TealLight
            };
            lblTopbarBadge = new Label
            {
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = KtvTheme.Teal,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlTopbarBadge.Controls.Add(lblTopbarBadge);
            pnlTopbar.Controls.AddRange(new Control[] { lblTopbarTitle, lblTopbarSub, pnlTopbarBadge });
            pnlTopbar.Visible = false;
            Controls.Add(pnlTopbar);

            // 1. Build Queue Panel (Left)
            pnlQueue = KtvTheme.Card(0, 0, 320, 100);
            pnlQueue.BorderColor = KtvTheme.Border;
            pnlQueue.ShadowDecoration.Enabled = true;
            pnlQueue.ShadowDecoration.Color = KtvTheme.Teal;
            pnlQueue.ShadowDecoration.Depth = 8;
            pnlQueue.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            lblQueueTitle = KtvTheme.Label("🗂 Hàng chờ kết quả", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);

            lblQueueCount = new Label
            {
                Text = "3 chờ",
                Location = new Point(236, 18),
                Size = new Size(64, 24),
                BackColor = KtvTheme.AccentSoft,
                ForeColor = Color.FromArgb(160, 112, 0),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            // Soft rounded badge
            pnlQueue.Controls.Add(lblQueueCount);

            txtSearchQueue = new Guna2TextBox
            {
                PlaceholderText = "Tìm bệnh nhân…",
                FillColor = Color.FromArgb(244, 247, 250),
                BorderColor = KtvTheme.Border,
                BorderRadius = 8,
                Font = new Font("Segoe UI", 9F),
                ForeColor = KtvTheme.TextDark,
                PlaceholderForeColor = KtvTheme.TextLight,
                Size = new Size(280, 36)
            };
            txtSearchQueue.TextChanged += TxtSearchQueue_TextChanged;
            pnlQueue.Controls.Add(txtSearchQueue);

            pnlQueueItems = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.White
            };
            pnlQueue.Controls.Add(pnlQueueItems);
            pnlQueue.Controls.Add(lblQueueTitle);
            Controls.Add(pnlQueue);

            // 2. Build Scrollable Form Container (Right)
            pnlFormContainer = new Guna2Panel
            {
                AutoScroll = true,
                BackColor = Color.Transparent
            };
            Controls.Add(pnlFormContainer);

            // 3. Build Toast Notification
            pnlToast = new Guna2Panel
            {
                Size = new Size(360, 52),
                BorderRadius = 10,
                FillColor = KtvTheme.TealDark,
                Visible = false
            };
            pnlToast.ShadowDecoration.Enabled = true;
            pnlToast.ShadowDecoration.Color = Color.Black;
            pnlToast.ShadowDecoration.Depth = 12;

            lblToastText = new Label
            {
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Location = new Point(16, 16),
                Size = new Size(328, 20),
                TextAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.Transparent
            };
            pnlToast.Controls.Add(lblToastText);
            Controls.Add(pnlToast);

            tmrToast = new Timer { Interval = 20 };
            tmrToast.Tick += TmrToast_Tick;
        }

        private void LayoutControls()
        {
            int margin = 28;
            int gap = 20;
            int topbarH = 0;

            // 0. Topbar (full width, top)
            pnlTopbar.Location = new Point(0, 0);
            pnlTopbar.Size = new Size(this.Width, topbarH);
            pnlTopbar.Visible = false;

            lblTopbarTitle.Location = new Point(margin, 14);
            lblTopbarSub.Location = new Point(margin, 38);

            // Update badge text & subtitle
            int waitCount = allServices != null ? allServices.Count(x => x.Status != "Hoàn thành") : 0;
            lblTopbarSub.Text = $"{waitCount} kết quả đang chờ cập nhật · Hôm nay {DateTime.Now:dd/MM/yyyy}";
            lblTopbarBadge.Text = $"⏳ {waitCount} chờ cập nhật";

            // Badge position (right side of topbar)
            pnlTopbarBadge.Location = new Point(this.Width - margin - pnlTopbarBadge.Width, (topbarH - pnlTopbarBadge.Height) / 2);
            lblTopbarBadge.Size = new Size(pnlTopbarBadge.Width, pnlTopbarBadge.Height);
            lblTopbarBadge.Location = new Point(0, 0);

            int availTop = topbarH + margin;
            int availHeight = this.Height - availTop - margin;
            if (availHeight < 200) availHeight = 500;

            // 1. Layout Queue Panel
            pnlQueue.Location = new Point(margin, availTop);
            pnlQueue.Size = new Size(320, availHeight);

            lblQueueTitle.Location = new Point(20, 18);
            lblQueueCount.Location = new Point(236, 18);
            // Apply simple rounded bounds to badge via Guna if possible, otherwise we set region
            lblQueueCount.Region = GetRoundedRegion(lblQueueCount.ClientRectangle, 8);

            txtSearchQueue.Location = new Point(20, 52);
            txtSearchQueue.Size = new Size(280, 36);

            pnlQueueItems.Location = new Point(1, 100);
            pnlQueueItems.Size = new Size(318, availHeight - 102);

            // 2. Layout Form Container (Right)
            int formX = pnlQueue.Right + gap;
            int formWidth = this.Width - formX - margin;
            if (formWidth < 400) formWidth = 400;

            pnlFormContainer.Location = new Point(formX, availTop);
            pnlFormContainer.Size = new Size(formWidth, availHeight);

            // Render right side components inside pnlFormContainer
            LayoutRightSideForm(formWidth);

            // Adjust Toast location
            pnlToast.Location = new Point(this.Width - pnlToast.Width - margin, this.Height - pnlToast.Height - 16);
            pnlToast.BringToFront();
        }

        private void LayoutRightSideForm(int w)
        {
            if (activeService == null) return;

            // Clear and rebuild panels to make sure it stretches perfectly
            pnlFormContainer.Controls.Clear();

            int y = 0;
            int cardW = w - 24; // Leave room for vertical scrollbar

            // A. Patient Strip
            pnlPatientStrip = new Guna2Panel
            {
                Location = new Point(0, y),
                Size = new Size(cardW, 100),
                BorderRadius = 12,
                FillColor = KtvTheme.TealDark
            };

            pnlAvatarCircle = new Guna2Panel
            {
                Size = new Size(52, 52),
                Location = new Point(22, 24),
                BorderRadius = 26,
                FillColor = Color.FromArgb(50, 255, 255, 255),
                BorderColor = Color.FromArgb(80, 255, 255, 255),
                BorderThickness = 2
            };
            string initials = GetInitials(activeService.Patient);
            lblAvatarText = KtvTheme.Label(initials, 0, 0, 13F, FontStyle.Bold, Color.White);
            lblAvatarText.AutoSize = false;
            lblAvatarText.Location = new Point(0, 0);
            lblAvatarText.Size = new Size(52, 52);
            lblAvatarText.TextAlign = ContentAlignment.MiddleCenter;
            pnlAvatarCircle.Controls.Add(lblAvatarText);
            pnlPatientStrip.Controls.Add(pnlAvatarCircle);

            lblPatientName = KtvTheme.Label(activeService.Patient, 90, 22, 14F, FontStyle.Bold, Color.White);
            lblPatientName.AutoSize = false;
            lblPatientName.Size = new Size(cardW - 260, 24);
            pnlPatientStrip.Controls.Add(lblPatientName);

            string gender = (activeService.Patient.Contains("Mai") || activeService.Patient.Contains("Lan") || activeService.Patient.Contains("Hằng")) ? "Nữ" : "Nam";
            string age = "45 tuổi";
            if (activeService.Patient == "Trần Văn Bình") age = "47 tuổi";
            else if (activeService.Patient == "Nguyễn Thị Mai") age = "52 tuổi";
            else if (activeService.Patient == "Vũ Thị Hằng") age = "38 tuổi";

            lblPatientMeta = KtvTheme.Label($"{activeService.RecordId} · {gender} · {age} · Chỉ định: BS. {activeService.Doctor.Replace("BS. ", "")}", 90, 55, 9F, FontStyle.Regular, Color.FromArgb(200, 230, 222));
            lblPatientMeta.AutoSize = false;
            lblPatientMeta.Size = new Size(cardW - 260, 18);
            pnlPatientStrip.Controls.Add(lblPatientMeta);

            // Priority Badge
            pnlPrioBadge = new Guna2Panel
            {
                Size = new Size(136, 30),
                Location = new Point(cardW - 156, 35),
                BorderRadius = 15
            };
            Color badgeBg = Color.FromArgb(40, 255, 255, 255);
            Color badgeFg = Color.White;
            string prioText = activeService.Priority;

            if (activeService.Priority == "Khẩn cấp")
            {
                badgeBg = KtvTheme.Danger;
                prioText = "⚠ Khẩn cấp";
            }
            else if (activeService.Priority == "Cao")
            {
                badgeBg = KtvTheme.Accent;
                prioText = "🟡 Cao";
            }
            else
            {
                prioText = "🟢 Bình thường";
            }
            pnlPrioBadge.FillColor = badgeBg;
            lblPrioText = KtvTheme.Label(prioText, 0, 0, 8.5F, FontStyle.Bold, badgeFg);
            lblPrioText.AutoSize = false;
            lblPrioText.Location = new Point(0, 0);
            lblPrioText.Size = new Size(136, 30);
            lblPrioText.TextAlign = ContentAlignment.MiddleCenter;
            pnlPrioBadge.Controls.Add(lblPrioText);
            pnlPatientStrip.Controls.Add(pnlPrioBadge);

            pnlFormContainer.Controls.Add(pnlPatientStrip);
            y += 100 + 16;

            // B. Service Info Card (Parameters input inside)
            var testParams = GetParamsForService(activeService.Service);
            int paramsCount = testParams.Count;
            int tableHeight = 292 + paramsCount * 46 + 10;

            cardSvc = KtvTheme.Card(0, y, cardW, tableHeight);
            cardSvc.ShadowDecoration.Enabled = true;
            cardSvc.ShadowDecoration.Color = KtvTheme.Teal;
            cardSvc.ShadowDecoration.Depth = 8;
            cardSvc.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            // Card header with divider line
            lblSvcTitle = KtvTheme.Label($"🔬 {activeService.Service}", 22, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            lblSvcTitle.AutoSize = false;
            lblSvcTitle.Size = new Size(cardW - 260, 22);
            lblSvcTitle.AutoEllipsis = true;
            cardSvc.Controls.Add(lblSvcTitle);

            lblSvcMeta = KtvTheme.Label($"{activeService.Room} · Giờ hẹn: {activeService.Time}", cardW - 230, 20, 8.5F, FontStyle.Regular, KtvTheme.TextLight);
            lblSvcMeta.AutoSize = false;
            lblSvcMeta.Size = new Size(208, 18);
            lblSvcMeta.TextAlign = ContentAlignment.TopRight;
            cardSvc.Controls.Add(lblSvcMeta);

            divSvc1 = new Guna2Panel { Location = new Point(0, 50), Size = new Size(cardW, 1), FillColor = KtvTheme.Border };
            cardSvc.Controls.Add(divSvc1);

            // Info Grid: 2-column × 2-row matching HTML .info-grid
            int colW = (cardW - 66) / 2;
            string[] gridLabels = { "MÃ DỊCH VỤ", "LOẠI MẪU XÉT NGHIỆM", "THỜI GIAN LẤY MẪU", "THIẾT BỊ HỖ TRỢ" };
            string[] gridVals = {
                activeService.RecordId.Replace("BV", "DV"),
                activeService.Service.Contains("máu") ? "Máu tĩnh mạch (EDTA)" : (activeService.Service.Contains("tiểu") ? "Nước tiểu (24h)" : "Không yêu cầu mẫu"),
                "07:35",
                activeService.Service.Contains("máu") ? "Sysmex XN-1000" : (activeService.Service.Contains("Điện tim") ? "Nihon Kohden ECG-2150" : "Thiết bị chụp MedRad")
            };
            for (int i = 0; i < 4; i++)
            {
                int col = i % 2;
                int row = i / 2;
                var cellPnl = new Guna2Panel
                {
                    Location = new Point(22 + col * (colW + 22), 60 + row * 74),
                    Size = new Size(colW, 62),
                    BorderRadius = 8,
                    FillColor = KtvTheme.Bg
                };
                var lblGLabel = KtvTheme.Label(gridLabels[i], 12, 10, 7.5F, FontStyle.Bold, KtvTheme.TextLight);
                var lblGVal = KtvTheme.Label(gridVals[i], 12, 30, 9F, FontStyle.Bold, KtvTheme.TextDark);
                lblGVal.AutoSize = false;
                lblGVal.Size = new Size(colW - 24, 18);
                lblGVal.AutoEllipsis = true;
                cellPnl.Controls.AddRange(new Control[] { lblGLabel, lblGVal });
                cardSvc.Controls.Add(cellPnl);
            }

            divSvc2 = new Guna2Panel { Location = new Point(0, 210), Size = new Size(cardW, 1), FillColor = KtvTheme.Border };
            cardSvc.Controls.Add(divSvc2);

            lblParamsTitle = KtvTheme.Label("NHẬP KẾT QUẢ TỪNG CHỈ SỐ", 22, 224, 8F, FontStyle.Bold, KtvTheme.TextLight);
            cardSvc.Controls.Add(lblParamsTitle);

            // Stable column X anchors for consistent alignment across header + rows
            int tblInnerW = cardW - 44;
            int colX0 = 22;                               // CHỈ SỐ
            int colX1 = 22 + (int)(tblInnerW * 0.29f);   // KẾT QUẢ
            int resultColW = Math.Min(260, Math.Max(230, (int)(tblInnerW * 0.23f)));
            int resultInputW = Math.Min(150, Math.Max(130, resultColW - 100));
            int resultInputX = colX1 + (resultColW - resultInputW) / 2;
            int colX2 = colX1 + resultColW + 18;         // ĐƠN VỊ
            int colX3 = Math.Max(colX2 + 112, 22 + (int)(tblInnerW * 0.77f)); // TRỊ SỐ THAM CHIẾU
            int colX4 = Math.Max(colX3 + 136, 22 + (int)(tblInnerW * 0.92f)); // CỜ

            // Table Header row
            pnlTableHeader = new Guna2Panel
            {
                Location = new Point(0, 244),
                Size = new Size(cardW, 30),
                FillColor = KtvTheme.Bg,
                BorderRadius = 0
            };
            var th0 = KtvTheme.Label("CHỈ SỐ", colX0, 7, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            var th1 = KtvTheme.Label("KẾT QUẢ", resultInputX, 7, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            th1.AutoSize = false;
            th1.Size = new Size(resultInputW, 18);
            th1.TextAlign = ContentAlignment.MiddleCenter;
            var th2 = KtvTheme.Label("ĐƠN VỊ", colX2, 7, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            var th3 = KtvTheme.Label("TRỊ SỐ THAM CHIẾU", colX3, 7, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            var th4 = KtvTheme.Label("CỜ", colX4, 7, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            pnlTableHeader.Controls.AddRange(new Control[] { th0, th1, th2, th3, th4 });
            cardSvc.Controls.Add(pnlTableHeader);

            // Build dynamic param rows
            activeParamRows.Clear();
            int startY = 282;
            for (int i = 0; i < paramsCount; i++)
            {
                var param = testParams[i];

                var lblName = KtvTheme.Label(param.Name, colX0, startY + 4, 9F, FontStyle.Bold, KtvTheme.TextDark);
                lblName.AutoSize = false;
                lblName.Size = new Size(colX1 - colX0 - 8, 18);
                var lblSub = KtvTheme.Label(param.SubName, colX0, startY + 24, 7.5F, FontStyle.Regular, KtvTheme.TextLight);
                lblSub.AutoSize = false;
                lblSub.Size = new Size(colX1 - colX0 - 8, 14);

                var txtValue = new Guna2TextBox
                {
                    Text = param.IsTextParam ? param.DefaultText : param.DefaultVal.ToString("F2").Replace(".00", ""),
                    Location = new Point(resultInputX, startY + 4),
                    Size = new Size(resultInputW, 30),
                    BorderRadius = 6,
                    BorderColor = KtvTheme.Border,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = KtvTheme.TextDark,
                    TextAlign = HorizontalAlignment.Center,
                    Tag = param
                };

                var lblUnit = KtvTheme.Label(param.Unit, colX2, startY + 12, 8.8F, FontStyle.Bold, KtvTheme.TextMid);
                lblUnit.AutoSize = false;
                lblUnit.Size = new Size(colX3 - colX2 - 10, 18);
                lblUnit.TextAlign = ContentAlignment.MiddleLeft;
                var lblRefRange = KtvTheme.Label(
                    param.IsTextParam ? "—" : $"{param.MinVal:F1} – {param.MaxVal:F1}",
                    colX3, startY + 12, 8.5F, FontStyle.Regular, KtvTheme.TextLight);
                lblRefRange.AutoSize = false;
                lblRefRange.Size = new Size(colX4 - colX3 - 10, 18);

                var pnlFlag = new Guna2Panel
                {
                    Size = new Size(36, 22),
                    Location = new Point(colX4, startY + 9),
                    BorderRadius = 11
                };
                var lblFlag = KtvTheme.Label("N", 0, 0, 8F, FontStyle.Bold, Color.White);
                lblFlag.AutoSize = false;
                lblFlag.Location = new Point(0, 0);
                lblFlag.Size = new Size(36, 22);
                lblFlag.TextAlign = ContentAlignment.MiddleCenter;
                pnlFlag.Controls.Add(lblFlag);

                // Wire evaluation logic
                txtValue.TextChanged += (sender, ev) => EvaluateParamRow(txtValue, pnlFlag, lblFlag);
                EvaluateParamRow(txtValue, pnlFlag, lblFlag);

                cardSvc.Controls.AddRange(new Control[] { lblName, lblSub, txtValue, lblUnit, lblRefRange, pnlFlag });

                activeParamRows.Add(new ParamRowControls
                {
                    Param = param,
                    TxtInput = txtValue,
                    PnlFlag = pnlFlag,
                    LblFlag = lblFlag
                });

                // Thin row divider
                if (i < paramsCount - 1)
                {
                    var rowDiv = new Guna2Panel
                    {
                        Location = new Point(22, startY + 42),
                        Size = new Size(cardW - 44, 1),
                        FillColor = Color.FromArgb(235, 240, 238)
                    };
                    cardSvc.Controls.Add(rowDiv);
                }

                startY += 46;
            }

            pnlFormContainer.Controls.Add(cardSvc);
            y += tableHeight + 16;

            // C. Remarks & Conclusion Card
            cardConclusion = KtvTheme.Card(0, y, cardW, 268);
            cardConclusion.ShadowDecoration.Enabled = true;
            cardConclusion.ShadowDecoration.Color = KtvTheme.Teal;
            cardConclusion.ShadowDecoration.Depth = 8;
            cardConclusion.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            lblConclusionHeader = KtvTheme.Label("📝 Nhận xét & kết luận", 22, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);
            cardConclusion.Controls.Add(lblConclusionHeader);

            // Horizontal divider under header
            var concDiv = new Guna2Panel { Location = new Point(0, 50), Size = new Size(cardW, 1), FillColor = KtvTheme.Border };
            cardConclusion.Controls.Add(concDiv);

            lblRemarksLabel = KtvTheme.Label("NHẬN XÉT CỦA KỸ THUẬT VIÊN", 22, 62, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            cardConclusion.Controls.Add(lblRemarksLabel);

            txtRemarks = new Guna2TextBox
            {
                PlaceholderText = "Nhập nhận xét về chất lượng mẫu, các bất thường quan sát được trong phòng thí nghiệm…",
                Location = new Point(22, 82),
                Size = new Size(cardW - 44, 78),
                Multiline = true,
                BorderRadius = 8,
                BorderColor = KtvTheme.Border,
                Font = new Font("Segoe UI", 9F),
                ForeColor = KtvTheme.TextDark
            };
            if (activeService.Patient == "Trần Văn Bình")
                txtRemarks.Text = "Mẫu máu đạt chất lượng. Hồng cầu giảm nhẹ, hemoglobin thấp — nghi ngờ thiếu máu nhược sắc. Đề nghị bác sĩ xem xét chỉ định bổ sung xét nghiệm sắt huyết thanh.";
            else if (activeService.Patient == "Nguyễn Thị Mai")
                txtRemarks.Text = "Mẫu huyết thanh không tán huyết. Chỉ số Glucose và Cholesterol tăng cao hơn ngưỡng tham chiếu. Đề nghị hội chẩn nội tiết.";
            else
                txtRemarks.Text = "Kết quả đo ghi nhận trạng thái bình thường ổn định, không phát hiện dấu hiệu bất thường cấp tính.";
            cardConclusion.Controls.Add(txtRemarks);

            // Two-column row: KẾT LUẬN CHUNG | THỜI GIAN HOÀN THÀNH
            int halfW = (cardW - 66) / 2;
            lblConclusionDropdownLabel = KtvTheme.Label("KẾT LUẬN CHUNG", 22, 172, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            cardConclusion.Controls.Add(lblConclusionDropdownLabel);

            cboConclusion = new Guna2ComboBox
            {
                Location = new Point(22, 192),
                Size = new Size(halfW, 36),
                BorderRadius = 8,
                BorderColor = KtvTheme.Border,
                Font = new Font("Segoe UI", 9F)
            };
            cboConclusion.Items.AddRange(new object[] { "Bình thường", "Bất thường — Cần theo dõi", "Bất thường — Khẩn cấp", "Cần thực hiện lại" });
            cboConclusion.SelectedIndex = (activeService.Patient == "Trần Văn Bình" || activeService.Patient == "Nguyễn Thị Mai") ? 1 : 0;
            cardConclusion.Controls.Add(cboConclusion);

            lblTimeLabel = KtvTheme.Label("THỜI GIAN HOÀN THÀNH", 22 + halfW + 22, 172, 7.8F, FontStyle.Bold, KtvTheme.TextLight);
            cardConclusion.Controls.Add(lblTimeLabel);

            dtpFinishTime = new Guna2DateTimePicker
            {
                Location = new Point(22 + halfW + 22, 192),
                Size = new Size(halfW, 36),
                BorderRadius = 8,
                FillColor = Color.White,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1,
                Font = new Font("Segoe UI", 9F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy HH:mm",
                Value = DateTime.Now
            };
            cardConclusion.Controls.Add(dtpFinishTime);

            pnlFormContainer.Controls.Add(cardConclusion);
            y += 268 + 16;

            // D. File Attachment Card
            if (DateTime.MinValue == DateTime.MaxValue)
            {
            cardAttachment = KtvTheme.Card(0, y, cardW, 212);
            cardAttachment.ShadowDecoration.Enabled = true;
            cardAttachment.ShadowDecoration.Color = KtvTheme.Teal;
            cardAttachment.ShadowDecoration.Depth = 8;
            cardAttachment.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            lblAttachmentHeader = KtvTheme.Label("📎 Đính kèm tệp kết quả", 20, 18, 10F, FontStyle.Bold, KtvTheme.TextDark);
            cardAttachment.Controls.Add(lblAttachmentHeader);

            pnlUploadZone = new Guna2Panel
            {
                Location = new Point(20, 48),
                Size = new Size(cardW - 40, 100),
                BorderRadius = 10,
                BorderColor = Color.Transparent,   // hide Guna border; draw dashed manually
                BorderThickness = 0,
                FillColor = Color.FromArgb(250, 252, 253),
                Cursor = Cursors.Hand
            };
            pnlUploadZone.Paint += (s, pe) =>
            {
                var r = pnlUploadZone.ClientRectangle;
                r.Inflate(-1, -1);
                using (var pen = new Pen(KtvTheme.Border, 1.5f) { DashStyle = DashStyle.Dash })
                using (var gp = new GraphicsPath())
                {
                    int radius = 10;
                    int d = radius * 2;
                    gp.AddArc(r.X, r.Y, d, d, 180, 90);
                    gp.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                    gp.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                    gp.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                    gp.CloseFigure();
                    pe.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    pe.Graphics.DrawPath(pen, gp);
                }
            };
            pnlUploadZone.MouseEnter += (s, e2) => { pnlUploadZone.FillColor = KtvTheme.TealLight; };
            pnlUploadZone.MouseLeave += (s, e2) => { pnlUploadZone.FillColor = Color.FromArgb(250, 252, 253); };
            pnlUploadZone.Click += PnlUploadZone_Click;

            // Icon (large, centered top)
            var lblUploadIcon = KtvTheme.Label("📄", 0, 12, 20F, FontStyle.Regular, KtvTheme.TextMid);
            lblUploadIcon.Size = new Size(cardW - 40, 30);
            lblUploadIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblUploadIcon.Click += PnlUploadZone_Click;
            pnlUploadZone.Controls.Add(lblUploadIcon);

            lblUpload1 = KtvTheme.Label("Nhấp để tải lên hoặc kéo file vào đây", 0, 46, 9F, FontStyle.Bold, KtvTheme.Teal);
            lblUpload1.Size = new Size(cardW - 40, 22);
            lblUpload1.TextAlign = ContentAlignment.MiddleCenter;
            lblUpload1.Click += PnlUploadZone_Click;
            pnlUploadZone.Controls.Add(lblUpload1);

            lblUpload2 = KtvTheme.Label("PDF, JPG, PNG · Tối đa 10MB mỗi file", 0, 70, 8F, FontStyle.Regular, KtvTheme.TextLight);
            lblUpload2.Size = new Size(cardW - 40, 18);
            lblUpload2.TextAlign = ContentAlignment.MiddleCenter;
            lblUpload2.Click += PnlUploadZone_Click;
            pnlUploadZone.Controls.Add(lblUpload2);
            cardAttachment.Controls.Add(pnlUploadZone);

            flpUploadedFiles = new FlowLayoutPanel
            {
                Location = new Point(20, 158),
                Size = new Size(cardW - 40, 44),
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = false,
                BackColor = Color.White
            };
            cardAttachment.Controls.Add(flpUploadedFiles);

            pnlFormContainer.Controls.Add(cardAttachment);
            y += 212 + 16;

            // Render attachment list initially
            RenderAttachmentsList();
            }

            // E. Actions Card
            cardActions = KtvTheme.Card(0, y, cardW, 72);
            cardActions.ShadowDecoration.Enabled = true;
            cardActions.ShadowDecoration.Color = KtvTheme.Teal;
            cardActions.ShadowDecoration.Depth = 8;
            cardActions.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            lblActionsKtvInfo = KtvTheme.Label("Kỹ thuật viên: Nguyễn Thị Thu · Khoa xét nghiệm", 20, 26, 9F, FontStyle.Bold, KtvTheme.TextMid);
            cardActions.Controls.Add(lblActionsKtvInfo);

            btnSaveDraft = KtvTheme.Button("💾 Lưu nháp", Color.White, KtvTheme.TextMid);
            btnSaveDraft.Text = "Lưu";
            btnSaveDraft.BorderColor = KtvTheme.Border;
            btnSaveDraft.BorderThickness = 1;
            btnSaveDraft.Size = new Size(112, 40);
            btnSaveDraft.TextAlign = HorizontalAlignment.Center;
            btnSaveDraft.TextOffset = new Point(0, 0);
            btnSaveDraft.Click += (s, e) => ShowToastNotification("💾 Kết quả đã được lưu nháp thành công!");
            cardActions.Controls.Add(btnSaveDraft);

            btnSendDoctor = KtvTheme.Button("📤 Gửi duyệt", KtvTheme.Accent, Color.White);
            btnSendDoctor.Text = "Gửi";
            btnSendDoctor.Size = new Size(112, 40);
            btnSendDoctor.TextAlign = HorizontalAlignment.Center;
            btnSendDoctor.TextOffset = new Point(0, 0);
            btnSendDoctor.Click += (s, e) => {
                activeService.Status = "Đang thực hiện";
                ShowToastNotification("📤 Đã chuyển kết quả cho bác sĩ chỉ định duyệt!");
                BuildQueueItems();
            };
            cardActions.Controls.Add(btnSendDoctor);

            btnComplete = KtvTheme.Button("✅ Xác nhận & Hoàn thành", KtvTheme.Teal, Color.White);
            btnComplete.Text = "Xác nhận hoàn tất";
            btnComplete.Size = new Size(220, 40);
            btnComplete.TextAlign = HorizontalAlignment.Center;
            btnComplete.TextOffset = new Point(0, 0);
            btnComplete.Click += (s, e) => {
                activeService.Status = "Hoàn thành";
                ShowToastNotification("✅ Đã phê duyệt và đồng bộ hồ sơ bệnh án thành công!");
                BuildQueueItems();
                var next = allServices.FirstOrDefault(x => x.Status != "Hoàn thành");
                if (next != null) SelectPatient(next);
                else SelectPatient(allServices.First());
            };
            cardActions.Controls.Add(btnComplete);

            // Position buttons from right edge
            int btnRight = cardW - 20;
            btnComplete.Location = new Point(btnRight - btnComplete.Width, 16);
            btnSendDoctor.Location = new Point(btnComplete.Left - 10 - btnSendDoctor.Width, 16);
            btnSaveDraft.Location = new Point(btnSendDoctor.Left - 10 - btnSaveDraft.Width, 16);

            pnlFormContainer.Controls.Add(cardActions);
        }

        private void EvaluateParamRow(Guna2TextBox txt, Guna2Panel pnl, Label lbl)
        {
            var param = (TestParam)txt.Tag;
            if (param == null) return;

            if (param.IsTextParam)
            {
                // Simple text comparison
                if (txt.Text.Trim().ToLower().Contains("bất thường") ||
                    txt.Text.Trim().ToLower().Contains("hẹp") ||
                    txt.Text.Trim().ToLower().Contains("dày") ||
                    txt.Text.Trim().ToLower().Contains("sỏi") ||
                    txt.Text.Trim().ToLower().Contains("loãng"))
                {
                    txt.FillColor = KtvTheme.DangerSoft;
                    txt.BorderColor = KtvTheme.Danger;
                    pnl.FillColor = KtvTheme.DangerSoft;
                    lbl.Text = "H";
                    lbl.ForeColor = KtvTheme.Danger;
                }
                else
                {
                    txt.FillColor = Color.White;
                    txt.BorderColor = KtvTheme.Border;
                    pnl.FillColor = KtvTheme.TealLight;
                    lbl.Text = "N";
                    lbl.ForeColor = KtvTheme.Teal;
                }
            }
            else
            {
                double val;
                if (double.TryParse(txt.Text, out val))
                {
                    if (val < param.MinVal)
                    {
                        txt.FillColor = KtvTheme.InfoSoft;
                        txt.BorderColor = KtvTheme.Info;
                        pnl.FillColor = KtvTheme.InfoSoft;
                        lbl.Text = "L";
                        lbl.ForeColor = KtvTheme.Info;
                    }
                    else if (val > param.MaxVal)
                    {
                        txt.FillColor = KtvTheme.DangerSoft;
                        txt.BorderColor = KtvTheme.Danger;
                        pnl.FillColor = KtvTheme.DangerSoft;
                        lbl.Text = "H";
                        lbl.ForeColor = KtvTheme.Danger;
                    }
                    else
                    {
                        txt.FillColor = Color.White;
                        txt.BorderColor = KtvTheme.Border;
                        pnl.FillColor = KtvTheme.TealLight;
                        lbl.Text = "N";
                        lbl.ForeColor = KtvTheme.Teal;
                    }
                }
                else
                {
                    txt.FillColor = Color.White;
                    txt.BorderColor = KtvTheme.Border;
                    pnl.FillColor = KtvTheme.TextLight;
                    lbl.Text = "—";
                    lbl.ForeColor = Color.White;
                }
            }
        }

        private void PnlUploadZone_Click(object sender, EventArgs e)
        {
            // Simulate file attachment upload
            string[] files = { "machine_output_cbc.pdf", "ecg_lead_graph.jpg", "chest_xray_raw.png", "urinalysis_strip.png" };
            Random r = new Random();
            string selected = files[r.Next(files.Length)];

            if (!mockAttachedFiles.Contains(selected))
            {
                mockAttachedFiles.Add(selected);
                RenderAttachmentsList();
                ShowToastNotification($"📎 Đã đính kèm tệp {selected} thành công!");
            }
        }

        private void RenderAttachmentsList()
        {
            if (flpUploadedFiles == null) return;
            flpUploadedFiles.Controls.Clear();

            // Default mock file if empty
            if (mockAttachedFiles.Count == 0 && activeService.Patient == "Trần Văn Bình")
            {
                mockAttachedFiles.Add("CBC_BinhTranVan_240525.pdf");
            }

            foreach (var file in mockAttachedFiles)
            {
                var pnlFile = new Guna2Panel
                {
                    Height = 32,
                    BorderRadius = 6,
                    FillColor = KtvTheme.TealLight,
                    Margin = new Padding(0, 0, 8, 0)
                };

                var lblName = new Label
                {
                    Text = $"📄 {file}",
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    ForeColor = KtvTheme.Teal,
                    Location = new Point(10, 0),
                    Size = new Size(180, 32),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent
                };

                var btnDelete = new Guna2Button
                {
                    Text = "✕",
                    Size = new Size(20, 20),
                    Location = new Point(190, 6),
                    BorderRadius = 10,
                    FillColor = Color.Transparent,
                    ForeColor = KtvTheme.Teal,
                    Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnDelete.Click += (s, e) => {
                    mockAttachedFiles.Remove(file);
                    RenderAttachmentsList();
                };

                pnlFile.Width = 220;
                pnlFile.Controls.AddRange(new Control[] { lblName, btnDelete });
                flpUploadedFiles.Controls.Add(pnlFile);
            }
        }

        private void BuildQueueItems()
        {
            pnlQueueItems.Controls.Clear();

            string searchKey = txtSearchQueue.Text.Trim().ToLowerInvariant();
            var filtered = allServices.Where(x =>
                string.IsNullOrEmpty(searchKey) ||
                x.Patient.ToLowerInvariant().Contains(searchKey) ||
                x.Service.ToLowerInvariant().Contains(searchKey)
            ).ToList();

            // Count waiting patients
            int waitCount = allServices.Count(x => x.Status != "Hoàn thành");
            lblQueueCount.Text = $"{waitCount} chờ";

            // Update topbar badge
            if (lblTopbarBadge != null)
            {
                lblTopbarBadge.Text = $"⏳ {waitCount} chờ cập nhật";
                lblTopbarSub.Text = $"{waitCount} kết quả đang chờ cập nhật · Hôm nay {DateTime.Now:dd/MM/yyyy}";
            }

            foreach (var service in filtered)
            {
                bool isActive = (service == activeService);
                bool isDone = service.Status == "Hoàn thành";

                // Wrapper panel that draws bottom border line
                var pnlWrapper = new Panel
                {
                    Size = new Size(318, 79),
                    BackColor = Color.Transparent,
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    Cursor = Cursors.Hand
                };
                pnlWrapper.Paint += (s, pe) =>
                {
                    using (var pen = new Pen(KtvTheme.Border, 1))
                        pe.Graphics.DrawLine(pen, 0, pnlWrapper.Height - 1, pnlWrapper.Width, pnlWrapper.Height - 1);
                };

                var pnlItem = new Guna2Panel
                {
                    Size = new Size(318, 78),
                    Location = new Point(0, 0),
                    BorderRadius = 0,
                    FillColor = isActive ? KtvTheme.TealLight : Color.White,
                    CustomBorderColor = isActive ? KtvTheme.Teal : Color.Transparent,
                    CustomBorderThickness = new Padding(isActive ? 3 : 0, 0, 0, 0),
                    Cursor = Cursors.Hand
                };

                // Click event
                pnlItem.Click += (s, e) => SelectPatient(service);
                pnlWrapper.Click += (s, e) => SelectPatient(service);

                // Avatar
                var pnlAv = new Guna2Panel
                {
                    Size = new Size(36, 36),
                    Location = new Point(14, 16),
                    BorderRadius = 18,
                    FillColor = isDone ? Color.FromArgb(200, 210, 205) : KtvTheme.TealMid
                };
                var lblAv = KtvTheme.Label(GetInitials(service.Patient), 0, 0, 9F, FontStyle.Bold, isDone ? Color.FromArgb(160, 170, 165) : Color.White);
                lblAv.AutoSize = false;
                lblAv.Location = new Point(0, 0);
                lblAv.Size = new Size(36, 36);
                lblAv.TextAlign = ContentAlignment.MiddleCenter;
                pnlAv.Controls.Add(lblAv);
                pnlItem.Controls.Add(pnlAv);

                lblAv.Click += (s, e) => SelectPatient(service);
                pnlAv.Click += (s, e) => SelectPatient(service);

                // Dimmed colors for completed items
                Color nameColor = isDone ? KtvTheme.TextLight : KtvTheme.TextDark;
                Color svcColor = isDone ? Color.FromArgb(180, 185, 190) : KtvTheme.TextMid;

                // Patient Name
                var lblName = KtvTheme.Label(service.Patient, 62, 12, 9F, FontStyle.Bold, nameColor);
                pnlItem.Controls.Add(lblName);
                lblName.Click += (s, e) => SelectPatient(service);

                // Service Name
                var lblSvc = KtvTheme.Label(service.Service, 62, 32, 7.8F, FontStyle.Regular, svcColor);
                lblSvc.Size = new Size(240, 18);
                lblSvc.AutoEllipsis = true;
                pnlItem.Controls.Add(lblSvc);
                lblSvc.Click += (s, e) => SelectPatient(service);

                // Status Badge — auto-width to prevent text crop
                string stText;
                Color stBg = KtvTheme.AccentSoft;
                Color stFg = Color.FromArgb(160, 112, 0);

                if (service.Status == "Hoàn thành")
                {
                    stText = "✅ Hoàn thành";
                    stBg = KtvTheme.TealLight;
                    stFg = isDone ? Color.FromArgb(150, 165, 160) : KtvTheme.Teal;
                }
                else if (service.Status == "Đang thực hiện")
                {
                    stText = "⚙️ Đang thực hiện";
                    stBg = KtvTheme.InfoSoft;
                    stFg = KtvTheme.Info;
                }
                else
                {
                    stText = "⏳ Chờ cập nhật";
                }

                var lblBadge = KtvTheme.Label(stText, 0, 0, 7.5F, FontStyle.Bold, stFg);
                lblBadge.AutoSize = true;
                var measuredSize = TextRenderer.MeasureText(stText, lblBadge.Font);
                int badgeW = Math.Max(measuredSize.Width + 16, 90);

                var pnlBadge = new Guna2Panel
                {
                    Size = new Size(badgeW, 20),
                    Location = new Point(62, 50),
                    BorderRadius = 10,
                    FillColor = stBg
                };
                lblBadge.AutoSize = false;
                lblBadge.Size = new Size(badgeW, 20);
                lblBadge.TextAlign = ContentAlignment.MiddleCenter;
                lblBadge.Location = new Point(0, 0);
                pnlBadge.Controls.Add(lblBadge);
                pnlItem.Controls.Add(pnlBadge);

                lblBadge.Click += (s, e) => SelectPatient(service);
                pnlBadge.Click += (s, e) => SelectPatient(service);

                pnlWrapper.Controls.Add(pnlItem);
                pnlQueueItems.Controls.Add(pnlWrapper);
            }
        }

        private void SelectPatient(KtvService service)
        {
            activeService = service;
            mockAttachedFiles.Clear();

            BuildQueueItems();

            // Re-render forms panel
            int formX = pnlQueue.Right + 20;
            int formWidth = this.Width - formX - 28;
            if (formWidth < 400) formWidth = 400;
            LayoutRightSideForm(formWidth);
        }

        private void TxtSearchQueue_TextChanged(object sender, EventArgs e)
        {
            BuildQueueItems();
        }

        private void ShowToastNotification(string message)
        {
            lblToastText.Text = message;
            pnlToast.Visible = true;
            isToastShowing = true;
            toastTicks = 0;
            pnlToast.Location = new Point(this.Width - pnlToast.Width - 28, this.Height);
            pnlToast.BringToFront();
            tmrToast.Start();
        }

        private void TmrToast_Tick(object sender, EventArgs e)
        {
            int step = 6;
            int targetY = this.Height - pnlToast.Height - 20;

            if (isToastShowing)
            {
                if (pnlToast.Top - step > targetY)
                {
                    pnlToast.Top -= step;
                }
                else
                {
                    pnlToast.Top = targetY;
                    toastTicks++;
                    if (toastTicks > 120) // Display toast for ~2.4 seconds
                    {
                        isToastShowing = false;
                    }
                }
            }
            else
            {
                int exitY = this.Height + 10;
                if (pnlToast.Top + step < exitY)
                {
                    pnlToast.Top += step;
                }
                else
                {
                    pnlToast.Top = exitY;
                    pnlToast.Visible = false;
                    tmrToast.Stop();
                }
            }
        }

        private List<TestParam> GetParamsForService(string serviceName)
        {
            var list = new List<TestParam>();

            if (serviceName.Contains("máu toàn phần") || serviceName.Contains("CBC"))
            {
                list.Add(new TestParam { Name = "WBC (Bạch cầu)", SubName = "White Blood Cells", MinVal = 4.0, MaxVal = 10.0, Unit = "×10³/μL", DefaultVal = 8.2 });
                list.Add(new TestParam { Name = "RBC (Hồng cầu)", SubName = "Red Blood Cells", MinVal = 4.2, MaxVal = 5.5, Unit = "×10⁶/μL", DefaultVal = 3.8 });
                list.Add(new TestParam { Name = "HGB (Hemoglobin)", SubName = "Huyết sắc tố", MinVal = 13.0, MaxVal = 17.0, Unit = "g/dL", DefaultVal = 11.5 });
                list.Add(new TestParam { Name = "HCT (Hematocrit)", SubName = "Thể tích khối hồng cầu", MinVal = 40.0, MaxVal = 52.0, Unit = "%", DefaultVal = 35.2 });
                list.Add(new TestParam { Name = "PLT (Tiểu cầu)", SubName = "Platelets", MinVal = 150.0, MaxVal = 400.0, Unit = "×10³/μL", DefaultVal = 220.0 });
                list.Add(new TestParam { Name = "MCV", SubName = "Thể tích trung bình hồng cầu", MinVal = 80.0, MaxVal = 100.0, Unit = "fL", DefaultVal = 75.4 });
                list.Add(new TestParam { Name = "Neutrophil", SubName = "Bạch cầu trung tính", MinVal = 50.0, MaxVal = 70.0, Unit = "%", DefaultVal = 65.0 });
            }
            else if (serviceName.Contains("Sinh hóa máu"))
            {
                list.Add(new TestParam { Name = "Glucose", SubName = "Đường huyết", MinVal = 3.9, MaxVal = 6.4, Unit = "mmol/L", DefaultVal = 7.2 });
                list.Add(new TestParam { Name = "Cholesterol toàn phần", SubName = "Total Cholesterol", MinVal = 3.9, MaxVal = 5.2, Unit = "mmol/L", DefaultVal = 5.8 });
                list.Add(new TestParam { Name = "Triglycerides", SubName = "Chất béo trung tính", MinVal = 0.46, MaxVal = 1.88, Unit = "mmol/L", DefaultVal = 1.50 });
                list.Add(new TestParam { Name = "AST (SGOT)", SubName = "Men gan AST", MinVal = 0.0, MaxVal = 37.0, Unit = "U/L", DefaultVal = 24.0 });
                list.Add(new TestParam { Name = "ALT (SGPT)", SubName = "Men gan ALT", MinVal = 0.0, MaxVal = 41.0, Unit = "U/L", DefaultVal = 28.0 });
            }
            else if (serviceName.Contains("nước tiểu") || serviceName.Contains("Urinalysis"))
            {
                list.Add(new TestParam { Name = "pH nước tiểu", SubName = "Urinary pH", MinVal = 5.0, MaxVal = 8.5, Unit = "pH", DefaultVal = 6.0 });
                list.Add(new TestParam { Name = "Glucose nước tiểu", SubName = "U-Glucose", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Âm tính (Negative)", IsTextParam = true });
                list.Add(new TestParam { Name = "Protein nước tiểu", SubName = "U-Protein", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Âm tính (Negative)", IsTextParam = true });
                list.Add(new TestParam { Name = "Ketone nước tiểu", SubName = "U-Ketones", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Âm tính (Negative)", IsTextParam = true });
            }
            else if (serviceName.Contains("Điện tim") || serviceName.Contains("ECG"))
            {
                list.Add(new TestParam { Name = "Nhịp tim (HR)", SubName = "Heart Rate", MinVal = 60.0, MaxVal = 100.0, Unit = "bpm", DefaultVal = 78.0 });
                list.Add(new TestParam { Name = "Nhịp xoang", SubName = "Rhythm", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Nhịp xoang đều", IsTextParam = true });
                list.Add(new TestParam { Name = "Trục điện tim", SubName = "Axis", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Trục trung gian", IsTextParam = true });
            }
            else
            {
                // General/image-based defaults
                list.Add(new TestParam { Name = "Mật độ/Hình ảnh", SubName = "Density/Visuals", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Bình thường ổn định", IsTextParam = true });
                list.Add(new TestParam { Name = "Mô tả tổn thương", SubName = "Lesions/Anomalies", MinVal = 0, MaxVal = 0, Unit = "—", DefaultText = "Không có tổn thương khu trú phát hiện", IsTextParam = true });
            }

            return list;
        }

        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "—";

            // Loại bỏ khoảng trắng thừa
            var parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 2)
            {
                // Lấy chữ cái đầu của từ áp chót và từ cuối cùng (VD: Nguyễn Thị Mai -> TM)
                return (parts[parts.Length - 2].Substring(0, 1) + parts[parts.Length - 1].Substring(0, 1)).ToUpper();
            }
            // Nếu chỉ có 1 tên
            return fullName.Substring(0, Math.Min(2, fullName.Length)).ToUpper();
        }

        private Region GetRoundedRegion(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return new Region(path);
        }
    }
}

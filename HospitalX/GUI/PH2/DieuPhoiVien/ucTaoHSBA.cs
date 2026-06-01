using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class ucTaoHSBA : UserControl
    {
        // Theme colors (synced with ucThemSuaBN)
        private static readonly Color Teal = Color.FromArgb(15, 110, 86);
        private static readonly Color TealDark = Color.FromArgb(10, 82, 64);
        private static readonly Color TealLight = Color.FromArgb(230, 243, 239);
        private static readonly Color BgColor = Color.FromArgb(244, 247, 246);
        private static readonly Color CardBorder = Color.FromArgb(218, 232, 226);
        private static readonly Color LabelColor = Color.FromArgb(122, 149, 137);
        private static readonly Color TextColor = Color.FromArgb(74, 98, 89);

        private string _selectedDoctorCode = "BS-TM-001";
        private string _selectedDoctorName = "BS. Trần Minh Khoa";
        private Guna2Panel _selectedDoctorCard = null;

        // Summary labels (updated dynamically)
        private Label lblSumBN;
        private Label lblSumMaBN;
        private Label lblSumBS;
        private Label lblSumKhoa;
        private Label lblSumIcd;
        private Label lblSumHinhThuc;

        private class IcdRowControls
        {
            public Guna2TextBox CodeBox { get; set; }
            public Guna2TextBox DescBox { get; set; }
            public Guna2Button DelBtn { get; set; }
        }

        private readonly System.Collections.Generic.List<IcdRowControls> _icdRows = new System.Collections.Generic.List<IcdRowControls>();
        private bool _step4Done = false;

        public ucTaoHSBA()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void ucTaoHSBA_Load(object sender, EventArgs e)
        {
            // Load PictureBox icons from images folder
            ptbStep1Icon.Image = DpvAssets.Load("magnifying-glass.png");
            ptbStep2Icon.Image = DpvAssets.Load("dpv_4.png");
            ptbStep3Icon.Image = DpvAssets.Load("dpv_8.png");
            ptbNoteIcon.Image = DpvAssets.Load("taking.png");

            // Load right-side headers icons
            ptbSummaryHeaderIcon.Image = DpvAssets.Load("dpv_4.png");
            ptbPermHeaderIcon.Image = DpvAssets.Load("settings.png");
            ptbLoadHeaderIcon.Image = DpvAssets.Load("dpv_14.png") ?? DpvAssets.Load("dpv_10.png");

            // Style search button with icon
            btnSearchBN.Image = DpvAssets.Load("magnifying-glass.png");
            btnSearchBN.ImageSize = new Size(16, 16);
            btnSearchBN.ImageOffset = new Point(-4, 0);
            btnSearchBN.TextOffset = new Point(2, 0);

            // Style footer buttons with icons
            btnSaveDraft.Image = DpvAssets.Load("save.png");
            btnSaveDraft.ImageSize = new Size(16, 16);
            btnSaveDraft.ImageOffset = new Point(-4, 0);
            btnSaveDraft.TextOffset = new Point(2, 0);

            btnCreateHSBA.Image = DpvAssets.Load("buttonTick.png");
            btnCreateHSBA.ImageSize = new Size(16, 16);
            btnCreateHSBA.ImageOffset = new Point(-4, 0);
            btnCreateHSBA.TextOffset = new Point(2, 0);

            InitComboBoxes();
            BuildStepsIndicator();
            BuildDoctorCards();
            BuildSummaryContent();
            BuildPermContent();
            BuildLoadContent();
            AddDefaultIcdRow();

            // Wire events
            btnSearchBN.Click += (s, ev) => ExecuteSearchBN();
            txtSearchBN.KeyDown += (s, ev) =>
            {
                if (ev.KeyCode == Keys.Enter)
                {
                    ExecuteSearchBN();
                    ev.SuppressKeyPress = true;
                }
            };
            btnChangeBN.Click += (s, ev) => ChangeBN();
            btnAddIcd.Click += (s, ev) => AddIcdRow();
            btnSaveDraft.Click += (s, ev) => SaveDraft();
            btnCreateHSBA.Click += (s, ev) => CreateHSBA();

            // Wire input changes for fully dynamic steps indicator and summary cards
            cboHinhThucDT.SelectedIndexChanged += (s, ev) =>
            {
                if (lblSumHinhThuc != null)
                    lblSumHinhThuc.Text = $"{cboHinhThucDT.Text} · {cboLoaiBH.Text}";
                BuildStepsIndicator();
            };
            cboLoaiBH.SelectedIndexChanged += (s, ev) =>
            {
                if (lblSumHinhThuc != null)
                    lblSumHinhThuc.Text = $"{cboHinhThucDT.Text} · {cboLoaiBH.Text}";
                BuildStepsIndicator();
            };
            cboKhoaDT.SelectedIndexChanged += (s, ev) =>
            {
                if (lblSumKhoa != null)
                    lblSumKhoa.Text = cboKhoaDT.Text;
                BuildStepsIndicator();
            };
            txtChanDoan.TextChanged += (s, ev) =>
            {
                BuildStepsIndicator();
            };

            // Load default patient on initial display
            LoadPatient("Nguyễn Văn An", "BN240001", "Nam", "15/03/1978", "Tim mạch");

            // Handle resize
            this.Resize += (s, ev) => AdjustLayout();
            AdjustLayout();
        }

        private void InitComboBoxes()
        {
            cboHinhThucDT.Items.Clear();
            cboHinhThucDT.Items.Add("Nội trú");
            cboHinhThucDT.Items.Add("Ngoại trú");
            cboHinhThucDT.Items.Add("Cấp cứu");
            cboHinhThucDT.SelectedIndex = 0;

            cboLoaiBH.Items.Clear();
            cboLoaiBH.Items.Add("BHYT toàn phần");
            cboLoaiBH.Items.Add("BHYT một phần");
            cboLoaiBH.Items.Add("Tự chi trả");
            cboLoaiBH.SelectedIndex = 0;

            cboKhoaDT.Items.Clear();
            cboKhoaDT.Items.Add("Tim mạch (TM-001)");
            cboKhoaDT.Items.Add("Nội tổng quát (NTQ-002)");
            cboKhoaDT.Items.Add("Chỉnh hình (CH-003)");
            cboKhoaDT.Items.Add("Sản khoa (SK-004)");
            cboKhoaDT.Items.Add("Thần kinh (TK-005)");
            cboKhoaDT.SelectedIndex = 0;

            cboPhongDT.Items.Clear();
            cboPhongDT.Items.Add("Phòng 201");
            cboPhongDT.Items.Add("Phòng 202");
            cboPhongDT.Items.Add("Phòng 203");
            cboPhongDT.Items.Add("Phòng 204 (VIP)");
            cboPhongDT.SelectedIndex = 0;

            dtpNgayMo.Value = DateTime.Now;

            // Pre-fill diagnosis
            txtChanDoan.Text = "Đau tức ngực, nghi ngờ rối loạn nhịp tim. Cần chuyên khoa Tim mạch đánh giá.";
            txtGhiChu.Text = "Bệnh nhân cao tuổi, cần ưu tiên theo dõi nhịp tim 24h đầu. Đã thông báo người nhà.";
        }

        // =============================================
        // STEP INDICATORS
        // =============================================
        private void BuildStepsIndicator()
        {
            pnlSteps.Controls.Clear();

            bool step1Done = pnlPatientFound.Visible;
            bool step2Done = step1Done && !string.IsNullOrWhiteSpace(txtChanDoan.Text) && _icdRows.Count > 0;
            bool step3Done = step2Done && _selectedDoctorCard != null;
            bool step4Done = step3Done && _step4Done;

            bool[] done = { step1Done, step2Done, step3Done, step4Done };
            bool[] active = {
                !step1Done,
                step1Done && !step2Done,
                step2Done && !step3Done,
                step3Done && !step4Done
            };

            string[] labels = { "1. Chọn bệnh nhân", "2. Thông tin bệnh án", "3. Chỉ định bác sĩ & khoa", "4. Xác nhận & lưu" };
            string[] circleTexts = { "✓", "2", "3", "4" };

            int x = 24;
            for (int i = 0; i < 4; i++)
            {
                // Circle
                var circle = new Label();
                circle.Size = new Size(32, 32);
                circle.Location = new Point(x, 14);
                circle.TextAlign = ContentAlignment.MiddleCenter;
                circle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                circle.Text = done[i] ? "✓" : circleTexts[i];

                if (done[i])
                {
                    circle.BackColor = Teal;
                    circle.ForeColor = Color.White;
                }
                else if (active[i])
                {
                    circle.BackColor = TealLight;
                    circle.ForeColor = Teal;
                }
                else
                {
                    circle.BackColor = BgColor;
                    circle.ForeColor = LabelColor;
                }

                // Round the circle using Region
                var gp = new GraphicsPath();
                gp.AddEllipse(0, 0, 32, 32);
                circle.Region = new Region(gp);

                pnlSteps.Controls.Add(circle);

                // Label
                var lbl = new Label();
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
                lbl.ForeColor = (done[i] || active[i]) ? Teal : LabelColor;
                lbl.Location = new Point(x + 38, 20);
                lbl.Text = labels[i];
                lbl.BackColor = Color.Transparent;
                pnlSteps.Controls.Add(lbl);

                x += 38 + TextRenderer.MeasureText(labels[i], lbl.Font).Width + 10;

                // Line separator (except after last step)
                if (i < 3)
                {
                    var line = new Panel();
                    line.BackColor = done[i] ? Teal : CardBorder;
                    line.Location = new Point(x, 29);
                    line.Size = new Size(60, 2);
                    pnlSteps.Controls.Add(line);
                    x += 70;
                }
            }
        }

        // =============================================
        // DOCTOR CARDS (2x2 grid)
        // =============================================
        private void BuildDoctorCards()
        {
            var doctors = new[]
            {
                new { Code = "BS-TM-001", Name = "BS. Trần Minh Khoa", Spec = "Tim mạch · 18 năm KN", Status = "● Đang rảnh (4 BN hôm nay)", IsFree = true, IsSelected = true },
                new { Code = "BS-TM-002", Name = "BS. Nguyễn Thị Hồng", Spec = "Tim mạch · 12 năm KN", Status = "● Đang bận (8 BN hôm nay)", IsFree = false, IsSelected = false },
                new { Code = "BS-TM-003", Name = "TS. Lê Đình Phước", Spec = "Tim mạch · 25 năm KN", Status = "● Đang rảnh (2 BN hôm nay)", IsFree = true, IsSelected = false },
                new { Code = "BS-TM-004", Name = "BS. Phạm Thu Hà", Spec = "Tim mạch · 8 năm KN", Status = "● Đang bận (9 BN hôm nay)", IsFree = false, IsSelected = false },
            };

            int cardW = 435;
            int cardH = 116;
            int gap = 10;

            for (int i = 0; i < doctors.Length; i++)
            {
                var doc = doctors[i];
                int col = i % 2;
                int row = i / 2;

                var card = new Guna2Panel();
                card.Size = new Size(cardW, cardH);
                card.Location = new Point(col * (cardW + gap), row * (cardH + 14));
                card.BorderRadius = 10;
                card.BorderThickness = 2;
                card.BorderColor = doc.IsSelected ? Teal : CardBorder;
                card.FillColor = doc.IsSelected ? TealLight : Color.White;
                card.Cursor = Cursors.Hand;
                card.BackColor = Color.Transparent;
                card.Tag = doc.Code;

                // Code label
                var lblCode = new Label();
                lblCode.AutoSize = true;
                lblCode.Font = new Font("Consolas", 8.5F, FontStyle.Bold);
                lblCode.ForeColor = Teal;
                lblCode.Location = new Point(12, 12);
                lblCode.Text = doc.Code;
                lblCode.BackColor = Color.Transparent;
                card.Controls.Add(lblCode);

                // Name label
                var lblName = new Label();
                lblName.AutoSize = true;
                lblName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(26, 46, 39);
                lblName.Location = new Point(12, 34);
                lblName.Text = doc.Name;
                lblName.BackColor = Color.Transparent;
                card.Controls.Add(lblName);

                // Spec label
                var lblSpec = new Label();
                lblSpec.AutoSize = true;
                lblSpec.Font = new Font("Segoe UI", 8F);
                lblSpec.ForeColor = LabelColor;
                lblSpec.Location = new Point(12, 58);
                lblSpec.Text = doc.Spec;
                lblSpec.BackColor = Color.Transparent;
                card.Controls.Add(lblSpec);

                // Status label
                var lblStatus = new Label();
                lblStatus.AutoSize = true;
                lblStatus.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                lblStatus.ForeColor = doc.IsFree ? Color.FromArgb(39, 169, 107) : Color.FromArgb(240, 165, 0);
                lblStatus.Location = new Point(12, 82);
                lblStatus.Text = doc.Status;
                lblStatus.BackColor = Color.Transparent;
                card.Controls.Add(lblStatus);

                // Selected checkmark
                if (doc.IsSelected)
                {
                    var lblCheck = new Label();
                    lblCheck.AutoSize = true;
                    lblCheck.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    lblCheck.ForeColor = Teal;
                    lblCheck.Location = new Point(cardW - 30, 10);
                    lblCheck.Text = "✓";
                    lblCheck.BackColor = Color.Transparent;
                    card.Controls.Add(lblCheck);
                    _selectedDoctorCard = card;
                }

                // Click handler — select this doctor
                string code = doc.Code;
                string name = doc.Name;
                card.Click += (s, ev) => SelectDoctor(card, code, name);

                // Also handle clicks on child labels
                foreach (Control c in card.Controls)
                {
                    c.Click += (s, ev) => SelectDoctor(card, code, name);
                }

                pnlDoctorGrid.Controls.Add(card);
            }
        }

        private void SelectDoctor(Guna2Panel card, string code, string name)
        {
            if (_selectedDoctorCard == card)
            {
                // Toggle / Deselect this doctor
                card.BorderColor = CardBorder;
                card.FillColor = Color.White;

                // Remove checkmark
                for (int i = card.Controls.Count - 1; i >= 0; i--)
                {
                    if (card.Controls[i] is Label lbl && lbl.Text == "✓" && lbl.Font.Size > 10)
                        card.Controls.RemoveAt(i);
                }

                _selectedDoctorCode = "";
                _selectedDoctorName = "";
                _selectedDoctorCard = null;

                if (lblSumBS != null)
                    lblSumBS.Text = "—";

                BuildStepsIndicator();
                return;
            }

            // Deselect all
            foreach (Control c in pnlDoctorGrid.Controls)
            {
                if (c is Guna2Panel p)
                {
                    p.BorderColor = CardBorder;
                    p.FillColor = Color.White;

                    // Remove checkmarks
                    for (int i = p.Controls.Count - 1; i >= 0; i--)
                    {
                        if (p.Controls[i] is Label lbl && lbl.Text == "✓" && lbl.Font.Size > 10)
                            p.Controls.RemoveAt(i);
                    }
                }
            }

            // Select this card
            card.BorderColor = Teal;
            card.FillColor = TealLight;
            var checkMark = new Label();
            checkMark.AutoSize = true;
            checkMark.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            checkMark.ForeColor = Teal;
            checkMark.Location = new Point(card.Width - 30, 8);
            checkMark.Text = "✓";
            checkMark.BackColor = Color.Transparent;
            checkMark.Click += (s, ev) => SelectDoctor(card, code, name);
            card.Controls.Add(checkMark);

            _selectedDoctorCode = code;
            _selectedDoctorName = name;
            _selectedDoctorCard = card;

            // Update summary
            if (lblSumBS != null)
                lblSumBS.Text = $"{code} — {name}";

            BuildStepsIndicator();
        }

        // =============================================
        // SUMMARY PANEL
        // =============================================
        private void BuildSummaryContent()
        {
            var rows = new[]
            {
                new { Key = "MÃ HSBA", Val = "HSBA-2026-0157", IsMono = true },
                new { Key = "BỆNH NHÂN", Val = "Nguyễn Văn An", IsMono = false },
                new { Key = "MÃ BN", Val = "BN240001", IsMono = true },
                new { Key = "NGÀY MỞ", Val = DateTime.Now.ToString("dd/MM/yyyy"), IsMono = false },
                new { Key = "BÁC SĨ PHỤ TRÁCH", Val = "BS-TM-001 — BS. Trần Minh Khoa", IsMono = false },
                new { Key = "KHOA", Val = "TM-001 — Tim mạch", IsMono = true },
                new { Key = "CHẨN ĐOÁN ICD-10", Val = "I49.9 — Rối loạn nhịp tim", IsMono = false },
                new { Key = "HÌNH THỨC", Val = "Nội trú · BHYT toàn phần", IsMono = false },
            };

            int y = 16;
            for (int i = 0; i < rows.Length; i++)
            {
                var keyLbl = new Label();
                keyLbl.AutoSize = true;
                keyLbl.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
                keyLbl.ForeColor = LabelColor;
                keyLbl.Text = rows[i].Key;
                keyLbl.Location = new Point(16, y);
                keyLbl.BackColor = Color.Transparent;
                pnlSummaryBody.Controls.Add(keyLbl);

                var valLbl = new Label();
                valLbl.AutoSize = true;
                valLbl.Font = rows[i].IsMono
                    ? new Font("Consolas", 9F, FontStyle.Bold)
                    : new Font("Segoe UI", 9F, FontStyle.Regular);
                valLbl.ForeColor = rows[i].IsMono ? Teal : Color.FromArgb(26, 46, 39);
                valLbl.Text = rows[i].Val;
                valLbl.Location = new Point(16, y + 16);
                valLbl.BackColor = Color.Transparent;
                pnlSummaryBody.Controls.Add(valLbl);

                // Keep references for dynamic updates
                switch (i)
                {
                    case 1: lblSumBN = valLbl; break;
                    case 2: lblSumMaBN = valLbl; break;
                    case 4: lblSumBS = valLbl; break;
                    case 5: lblSumKhoa = valLbl; break;
                    case 6: lblSumIcd = valLbl; break;
                    case 7: lblSumHinhThuc = valLbl; break;
                }

                y += 44;
            }
        }

        // =============================================
        // PERMISSIONS PANEL
        // =============================================
        private void BuildPermContent()
        {
            var perms = new[]
            {
                new { Text = "Tạo & chỉnh sửa HSBA", Allowed = true },
                new { Text = "Chỉ định MÃBS, MÃKHOA", Allowed = true },
                new { Text = "Phân công KTV dịch vụ", Allowed = true },
                new { Text = "Gửi thông báo OLS", Allowed = true },
                new { Text = "Kê đơn thuốc (chỉ BS)", Allowed = false },
                new { Text = "Chẩn đoán cuối (chỉ BS)", Allowed = false },
            };

            int y = 16;
            foreach (var perm in perms)
            {
                // PictureBox icon next to text
                var pic = new Guna2PictureBox();
                pic.Size = new Size(16, 16);
                pic.Location = new Point(16, y + 2);
                pic.Image = perm.Allowed ? DpvAssets.Load("buttonTick.png") : DpvAssets.Load("padlock.png");
                pic.BackColor = Color.Transparent;
                pic.FillColor = Color.Transparent;
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                pnlPermBody.Controls.Add(pic);

                // Clean label next to PictureBox
                var lbl = new Label();
                lbl.AutoSize = true;
                lbl.Font = new Font("Segoe UI", 8.5F);
                lbl.ForeColor = perm.Allowed ? TextColor : Color.FromArgb(224, 92, 58);
                lbl.Text = perm.Text;
                lbl.Location = new Point(38, y);
                lbl.BackColor = Color.Transparent;
                pnlPermBody.Controls.Add(lbl);
                
                y += 32; // Increased spacing for cards to have enough height and not crowd
            }

            // VPD badge (rounded light teal container)
            var badgePanel = new Guna2Panel();
            badgePanel.BorderRadius = 6;
            badgePanel.BorderThickness = 0;
            badgePanel.FillColor = TealLight;
            badgePanel.Location = new Point(16, y + 10);
            badgePanel.Size = new Size(348, 48); // Increased height to 48px to prevent truncation
            badgePanel.BackColor = Color.Transparent;

            // Padlock PictureBox inside badge
            var ptbBadgeIcon = new Guna2PictureBox();
            ptbBadgeIcon.Size = new Size(16, 16);
            ptbBadgeIcon.Location = new Point(10, 16); // Centered vertically in 48px container
            ptbBadgeIcon.Image = DpvAssets.Load("padlock.png");
            ptbBadgeIcon.BackColor = Color.Transparent;
            ptbBadgeIcon.FillColor = Color.Transparent;
            ptbBadgeIcon.SizeMode = PictureBoxSizeMode.Zoom;
            badgePanel.Controls.Add(ptbBadgeIcon);

            // Badge text shifted to the right
            var badgeLbl = new Label();
            badgeLbl.AutoSize = true;
            badgeLbl.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            badgeLbl.ForeColor = Teal;
            badgeLbl.Text = "Cơ chế phân quyền: VPD\r\nKhông thể tự cấp/thu hồi quyền";
            badgeLbl.Location = new Point(32, 8); // Centered vertically, shifted right to make room for icon
            badgeLbl.BackColor = Color.Transparent;
            badgePanel.Controls.Add(badgeLbl);

            pnlPermBody.Controls.Add(badgePanel);
        }

        // =============================================
        // LOAD PANEL (progress bar)
        // =============================================
        private void BuildLoadContent()
        {
            // Stats row
            var lblBnLabel = new Label();
            lblBnLabel.AutoSize = true;
            lblBnLabel.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBnLabel.ForeColor = Color.FromArgb(26, 46, 39);
            lblBnLabel.Text = "Bệnh nhân hiện tại";
            lblBnLabel.Location = new Point(16, 16);
            lblBnLabel.BackColor = Color.Transparent;
            pnlLoadBody.Controls.Add(lblBnLabel);

            var lblBnCount = new Label();
            lblBnCount.AutoSize = true;
            lblBnCount.Font = new Font("Consolas", 9F, FontStyle.Bold);
            lblBnCount.ForeColor = Teal;
            lblBnCount.Text = "14/20";
            lblBnCount.Location = new Point(310, 16);
            lblBnCount.BackColor = Color.Transparent;
            pnlLoadBody.Controls.Add(lblBnCount);

            // Progress bar track
            var pnlTrack = new Panel();
            pnlTrack.Location = new Point(16, 48);
            pnlTrack.Size = new Size(348, 8);
            pnlTrack.BackColor = CardBorder;
            pnlLoadBody.Controls.Add(pnlTrack);

            // Make track rounded
            var trackGp = new GraphicsPath();
            trackGp.AddRoundedRectangle(new Rectangle(0, 0, 348, 8), 4);
            pnlTrack.Region = new Region(trackGp);

            // Progress bar fill
            var pnlFill = new Panel();
            pnlFill.Location = new Point(0, 0);
            pnlFill.Size = new Size((int)(348 * 0.70), 8);
            pnlFill.BackColor = Teal;
            pnlTrack.Controls.Add(pnlFill);

            // Status text
            var lblLoadStatus = new Label();
            lblLoadStatus.AutoSize = true;
            lblLoadStatus.Font = new Font("Segoe UI", 7.5F);
            lblLoadStatus.ForeColor = LabelColor;
            lblLoadStatus.Text = "Tải hiện tại: 70% — Còn 6 chỗ trống";
            lblLoadStatus.Location = new Point(16, 72);
            lblLoadStatus.BackColor = Color.Transparent;
            pnlLoadBody.Controls.Add(lblLoadStatus);
        }

        // =============================================
        // ICD-10 MANAGEMENT
        // =============================================
        private void AddDefaultIcdRow()
        {
            AddIcdRowWithData("I49.9", "Rối loạn nhịp tim, không xác định");
        }

        private void AddIcdRow()
        {
            AddIcdRowWithData("", "");
            RecalcIcdLayout();
            UpdateSummaryIcd();
        }

        private void AddIcdRowWithData(string code, string desc)
        {
            int rowIndex = _icdRows.Count;
            int y = rowIndex * 40;

            var txtCode = new Guna2TextBox();
            txtCode.BorderRadius = 8;
            txtCode.BorderColor = CardBorder;
            txtCode.BorderThickness = 1;
            txtCode.FillColor = Color.FromArgb(247, 249, 248);
            txtCode.ForeColor = Color.FromArgb(24, 48, 42);
            txtCode.Font = new Font("Segoe UI", 9F);
            txtCode.Location = new Point(0, y);
            txtCode.Size = new Size(120, 34);
            txtCode.Text = code;
            txtCode.PlaceholderText = "VD: I49.9";
            txtCode.PlaceholderForeColor = Color.FromArgb(180, 195, 188);
            txtCode.BackColor = Color.Transparent;
            txtCode.AutoSize = false;
            txtCode.TextOffset = new Point(6, 0);
            txtCode.HoverState.BorderColor = Teal;
            txtCode.FocusedState.BorderColor = Teal;
            pnlIcdContainer.Controls.Add(txtCode);

            var txtDesc = new Guna2TextBox();
            txtDesc.BorderRadius = 8;
            txtDesc.BorderColor = CardBorder;
            txtDesc.BorderThickness = 1;
            txtDesc.FillColor = Color.FromArgb(247, 249, 248);
            txtDesc.ForeColor = Color.FromArgb(24, 48, 42);
            txtDesc.Font = new Font("Segoe UI", 9F);
            txtDesc.Location = new Point(130, y);
            txtDesc.Size = new Size(720, 34);
            txtDesc.Text = desc;
            txtDesc.PlaceholderText = "Mô tả bệnh…";
            txtDesc.PlaceholderForeColor = Color.FromArgb(180, 195, 188);
            txtDesc.BackColor = Color.Transparent;
            txtDesc.AutoSize = false;
            txtDesc.TextOffset = new Point(6, 0);
            txtDesc.HoverState.BorderColor = Teal;
            txtDesc.FocusedState.BorderColor = Teal;
            pnlIcdContainer.Controls.Add(txtDesc);

            var btnDel = new Guna2Button();
            btnDel.Size = new Size(34, 34);
            btnDel.Location = new Point(860, y);
            btnDel.BorderRadius = 8;
            btnDel.FillColor = Color.Transparent;
            btnDel.ForeColor = Color.FromArgb(224, 92, 58);
            btnDel.Font = new Font("Segoe UI", 12F);
            btnDel.Text = ""; // Clear emoji text
            btnDel.Image = DpvAssets.Load("bin.png");
            btnDel.ImageSize = new Size(16, 16);
            btnDel.Cursor = Cursors.Hand;
            btnDel.BackColor = Color.Transparent;
            btnDel.HoverState.FillColor = Color.FromArgb(255, 230, 225);

            var row = new IcdRowControls
            {
                CodeBox = txtCode,
                DescBox = txtDesc,
                DelBtn = btnDel
            };
            _icdRows.Add(row);

            btnDel.Click += (s, ev) =>
            {
                pnlIcdContainer.Controls.Remove(txtCode);
                pnlIcdContainer.Controls.Remove(txtDesc);
                pnlIcdContainer.Controls.Remove(btnDel);
                _icdRows.Remove(row);
                RecalcIcdLayout();
                UpdateSummaryIcd();
            };
            pnlIcdContainer.Controls.Add(btnDel);

            // Wire text changes to update summary and step indicator dynamically
            txtCode.TextChanged += (s, ev) =>
            {
                UpdateSummaryIcd();
                BuildStepsIndicator();
            };
            txtDesc.TextChanged += (s, ev) =>
            {
                UpdateSummaryIcd();
                BuildStepsIndicator();
            };
        }

        private void RecalcIcdLayout()
        {
            AdjustLayout();
            BuildStepsIndicator();
        }

        // =============================================
        // PATIENT SEARCH
        // =============================================
        private void ExecuteSearchBN()
        {
            string query = txtSearchBN.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
                return;

            string queryLower = query.ToLower();

            // Ensure shared patients are initialized
            PatientModel.InitializeSharedPatients();

            // Find matching patient in the database (strict exact match on Name or MaBN, case-insensitive)
            PatientModel matchedPatient = null;
            foreach (var p in PatientModel.SharedPatients)
            {
                if (p.Id.ToLower() == queryLower || p.Name.ToLower() == queryLower || RemoveDiacritics(p.Name) == RemoveDiacritics(query))
                {
                    matchedPatient = p;
                    break;
                }
            }

            if (matchedPatient != null)
            {
                LoadPatient(matchedPatient.Name, matchedPatient.Id, matchedPatient.Gender, matchedPatient.Dob, matchedPatient.Khoa);
            }
            else
            {
                ShowDialog("Không tìm thấy", $"Không tìm thấy bệnh nhân \"{query}\". Vui lòng thử lại.",
                    Guna.UI2.WinForms.MessageDialogIcon.Warning);
                return;
            }

            ShowDialog("Tìm thấy bệnh nhân", $"Đã tìm thấy bệnh nhân thành công.",
                Guna.UI2.WinForms.MessageDialogIcon.Information);
        }

        // Helper to remove diacritics for flexible accentless exact name search
        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            string normalizedString = text.Normalize(System.Text.NormalizationForm.FormD);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();

            foreach (char c in normalizedString)
            {
                System.Globalization.UnicodeCategory unicodeCategory = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(System.Text.NormalizationForm.FormC).ToLower().Trim();
        }

        private void LoadPatient(string name, string code, string gender, string dob, string dept)
        {
            lblBNName.Text = name;
            lblBNMeta.Text = $"{code} · {gender} · {dob} · {dept}";

            // Try to load avatar
            Image avatar = DpvAssets.Load("user.png");
            if (avatar != null)
                picBNAvatar.Image = avatar;

            pnlPatientFound.Visible = true;

            // Load patient clinical details based on code (MaBN)
            pnlIcdContainer.Controls.Clear();
            _icdRows.Clear();
            _step4Done = false;
            if (code == "BN240001") // Nguyễn Văn An
            {
                txtMaHSBA.Text = "HSBA-2026-0157";
                cboHinhThucDT.SelectedIndex = 0; // Nội trú
                cboLoaiBH.SelectedIndex = 0; // BHYT toàn phần
                cboKhoaDT.SelectedIndex = 0; // Tim mạch (TM-001)
                cboPhongDT.SelectedIndex = 0; // Phòng 201
                txtChanDoan.Text = "Đau tức ngực, nghi ngờ rối loạn nhịp tim. Cần chuyên khoa Tim mạch đánh giá.";
                txtGhiChu.Text = "Bệnh nhân cao tuổi, cần ưu tiên theo dõi nhịp tim 24h đầu. Đã thông báo người nhà.";
                AddIcdRowWithData("I49.9", "Rối loạn nhịp tim, không xác định");
            }
            else if (code == "BN240046") // Trần Thị Cường
            {
                txtMaHSBA.Text = "HSBA-2026-0248";
                cboHinhThucDT.SelectedIndex = 1; // Ngoại trú
                cboLoaiBH.SelectedIndex = 1; // BHYT một phần
                cboKhoaDT.SelectedIndex = 1; // Nội tổng quát (NTQ-002)
                cboPhongDT.SelectedIndex = 2; // Phòng 203
                txtChanDoan.Text = "Sốt cao co giật nhẹ, ho khan kéo dài 3 ngày. Nghi ngờ viêm phế quản cấp.";
                txtGhiChu.Text = "Trẻ em 6 tuổi, cần dặn dò người nhà uống đúng liều lượng, theo dõi thân nhiệt định kỳ.";
                AddIcdRowWithData("J20.9", "Viêm phế quản cấp, không xác định");
            }
            else if (code == "BN240032") // Lê Thành Anh
            {
                txtMaHSBA.Text = "HSBA-2026-0312";
                cboHinhThucDT.SelectedIndex = 0; // Nội trú
                cboLoaiBH.SelectedIndex = 1; // BHYT một phần
                cboKhoaDT.SelectedIndex = 3; // Sản khoa (SK-004)
                cboPhongDT.SelectedIndex = 2; // Phòng 203
                txtChanDoan.Text = "Theo dõi đau bụng hạ vị kéo dài, nghi ngờ viêm túi thừa hoặc bệnh lý ruột.";
                txtGhiChu.Text = "Bệnh nhân nam lớn tuổi, 73 tuổi, có tiền sử tăng huyết áp nhẹ. Theo dõi sát nhiệt độ và đại tiện.";
                AddIcdRowWithData("K57.9", "Bệnh túi thừa của ruột, không xác định");
            }
            else
            {
                // Dynamic clinical mock data generator based on department (dept)
                string suffix = code.Length >= 4 ? code.Substring(code.Length - 4) : "9999";
                txtMaHSBA.Text = $"HSBA-2026-{suffix}";
                cboHinhThucDT.SelectedIndex = 0; // Nội trú
                cboLoaiBH.SelectedIndex = 0; // BHYT toàn phần

                // Map department string to correct cboKhoaDT items
                // "Tim mạch", "Nội tổng quát", "Chỉnh hình", "Sản khoa", "Thần kinh", "Nhi khoa"
                string deptLower = dept.ToLower();
                if (deptLower.Contains("tim"))
                {
                    cboKhoaDT.SelectedIndex = 0; // Tim mạch (TM-001)
                    cboPhongDT.SelectedIndex = 0; // Phòng 201
                    txtChanDoan.Text = "Đau tức ngực, hồi hộp trống ngực liên tục. Nghi ngờ suy tim sung huyết.";
                    txtGhiChu.Text = "Bệnh nhân cần kiểm tra điện tâm đồ và siêu âm tim khẩn cấp.";
                    AddIcdRowWithData("I50.9", "Suy tim, không xác định");
                }
                else if (deptLower.Contains("nội") || deptLower.Contains("noi"))
                {
                    cboKhoaDT.SelectedIndex = 1; // Nội tổng quát (NTQ-002)
                    cboPhongDT.SelectedIndex = 1; // Phòng 202
                    txtChanDoan.Text = "Đau thượng vị lan ra sau lưng, ăn uống khó tiêu. Nghi ngờ viêm dạ dày cấp.";
                    txtGhiChu.Text = "Kiêng đồ ăn cay nóng, nhiều dầu mỡ. Nội soi dạ dày khi có chỉ định.";
                    AddIcdRowWithData("K29.7", "Viêm dạ dày, không xác định");
                }
                else if (deptLower.Contains("chỉnh") || deptLower.Contains("chinh"))
                {
                    cboKhoaDT.SelectedIndex = 2; // Chỉnh hình (CH-003)
                    cboPhongDT.SelectedIndex = 2; // Phòng 203
                    txtChanDoan.Text = "Chấn thương phần mềm cổ chân phải do té ngã. Theo dõi bong gân.";
                    txtGhiChu.Text = "Hạn chế vận động mạnh cổ chân phải, chườm lạnh giảm sưng.";
                    AddIcdRowWithData("S93.4", "Bong gân và đứt khớp cổ chân");
                }
                else if (deptLower.Contains("sản") || deptLower.Contains("san"))
                {
                    cboKhoaDT.SelectedIndex = 3; // Sản khoa (SK-004)
                    cboPhongDT.SelectedIndex = 1; // Phòng 202
                    txtChanDoan.Text = "Theo dõi đau tức vùng hạ vị kéo dài, rối loạn kinh nguyệt. Nghi ngờ u xơ tử cung.";
                    txtGhiChu.Text = "Siêu âm đầu dò phụ khoa và xét nghiệm các chỉ số viêm.";
                    AddIcdRowWithData("D25.9", "U xơ tử cung, không xác định");
                }
                else if (deptLower.Contains("thần") || deptLower.Contains("than"))
                {
                    cboKhoaDT.SelectedIndex = 4; // Thần kinh (TK-005)
                    cboPhongDT.SelectedIndex = 3; // Phòng 204
                    txtChanDoan.Text = "Đau nửa đầu Migraine cơn kịch phát, chóng mặt kèm buồn nôn.";
                    txtGhiChu.Text = "Nằm nghỉ ngơi nơi yên tĩnh, tránh ánh sáng mạnh và tiếng ồn.";
                    AddIcdRowWithData("G43.9", "Đau nửa đầu, không xác định");
                }
                else // Nhi khoa / default
                {
                    cboKhoaDT.SelectedIndex = 1; // Mặc định Nội tổng quát
                    cboPhongDT.SelectedIndex = 2; // Phòng 203
                    txtChanDoan.Text = "Ho khan kèm sốt nhẹ về chiều. Theo dõi nhiễm trùng đường hô hấp dưới.";
                    txtGhiChu.Text = "Uống nhiều nước ấm, theo dõi thân nhiệt định kỳ mỗi 4 giờ.";
                    AddIcdRowWithData("J06.9", "Nhiễm khuẩn đường hô hấp trên cấp tính");
                }
            }

            RecalcIcdLayout();
            BuildStepsIndicator();

            // Update summary
            if (lblSumBN != null) lblSumBN.Text = name;
            if (lblSumMaBN != null) lblSumMaBN.Text = code;
            if (lblSumHinhThuc != null) lblSumHinhThuc.Text = $"{cboHinhThucDT.Text} · {cboLoaiBH.Text}";
            if (lblSumKhoa != null) lblSumKhoa.Text = cboKhoaDT.Text;
            UpdateSummaryIcd();
        }

        private void ChangeBN()
        {
            txtSearchBN.Text = "";
            txtSearchBN.Focus();
            pnlPatientFound.Visible = false;

            // Clear inputs
            txtMaHSBA.Text = "";
            txtChanDoan.Text = "";
            txtGhiChu.Text = "";
            pnlIcdContainer.Controls.Clear();
            _icdRows.Clear();
            _step4Done = false;
            RecalcIcdLayout();
            BuildStepsIndicator();

            // Clear summary
            if (lblSumBN != null) lblSumBN.Text = "—";
            if (lblSumMaBN != null) lblSumMaBN.Text = "—";
            if (lblSumHinhThuc != null) lblSumHinhThuc.Text = "—";
            if (lblSumKhoa != null) lblSumKhoa.Text = "—";
            if (lblSumIcd != null) lblSumIcd.Text = "—";
        }

        private void UpdateSummaryIcd()
        {
            if (lblSumIcd != null)
            {
                lblSumIcd.Text = GetFirstIcdSummary();
            }
        }

        private string GetFirstIcdSummary()
        {
            if (_icdRows.Count > 0)
            {
                var row = _icdRows[0];
                return $"{row.CodeBox.Text} — {row.DescBox.Text}";
            }
            return "Chưa nhập ICD-10";
        }

        // =============================================
        // CREATE HSBA
        // =============================================
        private void SaveDraft()
        {
            _step4Done = true;
            BuildStepsIndicator();
            ShowDialog("Đã lưu nháp", "Hồ sơ bệnh án đã được lưu nháp thành công. Bạn có thể tiếp tục chỉnh sửa sau.",
                Guna.UI2.WinForms.MessageDialogIcon.Information);
        }

        private void CreateHSBA()
        {
            // Validate required fields
            bool valid = true;
            string errorMsg = "Vui lòng điền đầy đủ thông tin bắt buộc:";

            if (string.IsNullOrWhiteSpace(txtChanDoan.Text))
            {
                valid = false;
                errorMsg += "\n- Chẩn đoán sơ bộ";
                txtChanDoan.BorderColor = Color.FromArgb(253, 114, 114);
            }

            if (!pnlPatientFound.Visible)
            {
                valid = false;
                errorMsg += "\n- Chưa chọn bệnh nhân";
            }

            if (!valid)
            {
                ShowDialog("Thiếu thông tin", errorMsg, Guna.UI2.WinForms.MessageDialogIcon.Warning);
                return;
            }

            // Set Step 4 completed
            _step4Done = true;
            BuildStepsIndicator();

            // Show success
            string successMsg = $"Tạo hồ sơ bệnh án thành công!\n\n"
                + $"Mã HSBA: {txtMaHSBA.Text}\n"
                + $"Bác sĩ: {_selectedDoctorName} ({_selectedDoctorCode})\n"
                + $"Khoa: {cboKhoaDT.Text}\n\n"
                + "Bác sĩ đã được thông báo qua OLS.";

            ShowDialog("Thành công", successMsg, Guna.UI2.WinForms.MessageDialogIcon.Information);
        }

        // =============================================
        // LAYOUT ADJUSTMENT
        // =============================================
        private void AdjustLayout()
        {
            // Save scroll position and temporarily reset to (0, 0) to avoid WinForms AutoScroll layout drift
            Point scrollPos = pnlScroll.AutoScrollPosition;
            pnlScroll.AutoScrollPosition = new Point(0, 0);

            int leftW = pnlScroll.ClientSize.Width - 420;
            if (leftW < 940) leftW = 940;
            int rightX = leftW + 30;
            int rightW = pnlScroll.ClientSize.Width - rightX - 20;
            if (rightW < 380) rightW = 380;

            pnlSteps.Width = pnlScroll.ClientSize.Width - 40;
            pnlStep1Card.Width = leftW;
            pnlStep2Card.Width = leftW;
            pnlStep3Card.Width = leftW;
            pnlActionsCard.Width = leftW;

            // Expand section containers inside cards to prevent clipping
            pnlIcdSection.Width = pnlStep2Card.Width;
            pnlNoteSection.Width = pnlStep3Card.Width;
            txtGhiChu.Width = pnlNoteSection.Width - 40;

            // Expand divider lines inside section panels dynamically
            foreach (Control c in pnlIcdSection.Controls)
            {
                if (c is Panel && !(c is Guna2Panel) && c.Height == 1)
                {
                    c.Width = pnlIcdSection.Width - 40;
                }
            }
            foreach (Control c in pnlNoteSection.Controls)
            {
                if (c is Panel && !(c is Guna2Panel) && c.Height == 1)
                {
                    c.Width = pnlNoteSection.Width - 40;
                }
            }

            // Position and resize ICD rows dynamically first
            pnlIcdContainer.Width = pnlStep2Card.Width - 40;
            btnAddIcd.Width = pnlIcdContainer.Width;

            int icdY = 0;
            foreach (var row in _icdRows)
            {
                row.CodeBox.Location = new Point(0, icdY);
                row.CodeBox.Size = new Size(120, 34);

                row.DescBox.Location = new Point(130, icdY);
                row.DescBox.Size = new Size(pnlIcdContainer.Width - 130 - 34 - 16, 34);

                row.DelBtn.Location = new Point(pnlIcdContainer.Width - 34, icdY);
                row.DelBtn.Size = new Size(34, 34);

                icdY += 40;
            }
            pnlIcdContainer.Height = _icdRows.Count > 0 ? icdY : 0;
            btnAddIcd.Location = new Point(20, pnlIcdContainer.Bottom + 8);
            pnlIcdSection.Height = btnAddIcd.Bottom + 10;
            pnlStep2Card.Height = pnlIcdSection.Bottom;

            // Dynamically stack left cards with 16px gap!
            pnlStep2Card.Top = pnlStep1Card.Bottom + 16;
            pnlStep3Card.Top = pnlStep2Card.Bottom + 16;
            pnlActionsCard.Top = pnlStep3Card.Bottom + 16;

            pnlSummaryCard.Location = new Point(rightX, 91);
            pnlSummaryCard.Width = rightW;
            pnlPermCard.Location = new Point(rightX, 527);
            pnlPermCard.Width = rightW;
            pnlLoadCard.Location = new Point(rightX, 863);
            pnlLoadCard.Width = rightW;

            // Reposition search button
            btnSearchBN.Left = pnlStep1Card.Width - btnSearchBN.Width - 24;
            txtSearchBN.Width = btnSearchBN.Left - 34;
            pnlPatientFound.Width = pnlStep1Card.Width - 44;
            btnChangeBN.Left = pnlPatientFound.Width - btnChangeBN.Width - 10;

            // Reposition footer buttons dynamically
            btnCreateHSBA.Left = pnlActionsCard.Width - btnCreateHSBA.Width - 24;
            btnSaveDraft.Left = btnCreateHSBA.Left - btnSaveDraft.Width - 12;

            // Restore scroll position
            pnlScroll.AutoScrollPosition = new Point(Math.Abs(scrollPos.X), Math.Abs(scrollPos.Y));
        }

        // =============================================
        // NAVIGATION
        // =============================================
        private void NavigateBack()
        {
            var main = this.FindForm() as Main_DPV;
            if (main != null)
            {
                main.NavigateToDanhSachBN();
            }
        }

        // =============================================
        // HELPERS
        // =============================================
        private void ShowDialog(string caption, string message, Guna.UI2.WinForms.MessageDialogIcon icon)
        {
            if (this.guna2MessageDialog1 == null)
                this.guna2MessageDialog1 = new Guna2MessageDialog();

            guna2MessageDialog1.Parent = this.FindForm();
            guna2MessageDialog1.Icon = icon;
            guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            guna2MessageDialog1.Caption = caption;
            guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Light;
            guna2MessageDialog1.Show(message);
        }
    }

    // Extension for rounded rectangle (used in progress bar)
    internal static class GraphicsPathExtensions
    {
        public static void AddRoundedRectangle(this GraphicsPath path, Rectangle rect, int radius)
        {
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
        }
    }
}

using Guna.UI2.WinForms;
using System;
using System.Data;
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

        private string _selectedDoctorCode = "";
        private string _selectedDoctorName = "";
        private Guna2Panel _selectedDoctorCard = null;

        // Summary labels (updated dynamically)
        private Label lblSumMaHSBA;
        private Label lblSumBN;
        private Label lblSumMaBN;
        private Label lblSumNgayMo;
        private Label lblSumBS;
        private Label lblSumKhoa;
        private Label lblSumChanDoan;
        private Label lblSumDieuTri;
        private Label lblSumKetLuan;

        private bool _step4Done = false;
        private FlowLayoutPanel _flpSummary;

        public ucTaoHSBA()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void ucTaoHSBA_Load(object sender, EventArgs e)
        {
            // Style search button without icon
            btnSearchBN.Image = null;
            btnSearchBN.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnSearchBN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnSearchBN.ImageOffset = new Point(0, 0);
            btnSearchBN.TextOffset = new Point(0, 0);

            btnCreateHSBA.Image = null;
            btnCreateHSBA.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnCreateHSBA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnCreateHSBA.ImageOffset = new Point(0, 0);
            btnCreateHSBA.TextOffset = new Point(0, 0);

            pnlDoctorGrid.AutoScroll = true;
            pnlDoctorGrid.Height = 250;

            InitComboBoxes();
            BuildStepsIndicator();
            BuildDoctorCards();
            BuildSummaryContent();
            
            pnlPermCard.Visible = false;
            pnlScroll.Controls.Remove(pnlPermCard);

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
            btnCreateHSBA.Click += (s, ev) => CreateHSBA();

            // Wire input changes for fully dynamic steps indicator and summary cards
            txtMaHSBA.TextChanged += (s, ev) =>
            {
                SetSummaryText(lblSumMaHSBA, string.IsNullOrWhiteSpace(txtMaHSBA.Text) ? "Chưa có" : txtMaHSBA.Text);
            };
            dtpNgayMo.ValueChanged += (s, ev) =>
            {
                SetSummaryText(lblSumNgayMo, !pnlPatientFound.Visible ? "Chưa có" : dtpNgayMo.Value.ToString("dd/MM/yyyy"));
            };
            cboKhoaDT.SelectedIndexChanged += (s, ev) =>
            {
                SetSummaryText(lblSumKhoa, string.IsNullOrEmpty(_selectedDoctorCode) ? "Chưa có" : cboKhoaDT.Text);
                BuildDoctorCards();
            };
            txtChanDoan.TextChanged += (s, ev) =>
            {
                if (!string.IsNullOrWhiteSpace(txtChanDoan.Text))
                    txtChanDoan.BorderColor = CardBorder;
                SetSummaryText(lblSumChanDoan, string.IsNullOrWhiteSpace(txtChanDoan.Text) ? "Chưa có" : txtChanDoan.Text);
                BuildStepsIndicator();
            };
            txtDieuTri.TextChanged += (s, ev) =>
            {
                if (!string.IsNullOrWhiteSpace(txtDieuTri.Text))
                    txtDieuTri.BorderColor = CardBorder;
                SetSummaryText(lblSumDieuTri, string.IsNullOrWhiteSpace(txtDieuTri.Text) ? "Chưa có" : txtDieuTri.Text);
                BuildStepsIndicator();
            };
            txtKetLuan.TextChanged += (s, ev) =>
            {
                if (!string.IsNullOrWhiteSpace(txtKetLuan.Text))
                    txtKetLuan.BorderColor = CardBorder;
                SetSummaryText(lblSumKetLuan, string.IsNullOrWhiteSpace(txtKetLuan.Text) ? "Chưa có" : txtKetLuan.Text);
                BuildStepsIndicator();
            };

            // Start in a clean state with no patient selected and no doctor selected
            ChangeBN();

            // Handle resize
            this.Resize += (s, ev) => AdjustLayout();
            AdjustLayout();
        }

        private void InitComboBoxes()
        {
            cboKhoaDT.Items.Clear();
            try
            {
                DataTable dt = HospitalX.DAO.HsbaDAO.GetDepartments();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["CHUYENKHOA"] != DBNull.Value)
                        {
                            cboKhoaDT.Items.Add(row["CHUYENKHOA"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc danh sach khoa tu view: " + ex.Message);
            }

            // Fallback if empty
            if (cboKhoaDT.Items.Count == 0)
            {
                cboKhoaDT.Items.Add("Khoa tim mạch");
                cboKhoaDT.Items.Add("Khoa tiêu hóa");
                cboKhoaDT.Items.Add("Khoa thần kinh");
            }

            cboKhoaDT.SelectedIndex = 0;

            dtpNgayMo.Value = DateTime.Now;

            // Pre-fill fields
            txtChanDoan.Text = "Đau tức ngực, nghi ngờ rối loạn nhịp tim. Cần chuyên khoa Tim mạch đánh giá.";
            txtDieuTri.Text = "Theo dõi điện tâm đồ liên tục, nghỉ ngơi tại giường, sẵn sàng xử lý loạn nhịp.";
            txtKetLuan.Text = "Rối loạn nhịp tim nghi ngờ do mạch vành, cần nhập viện chuyên khoa Tim mạch.";
        }

        // =============================================
        // STEP INDICATORS
        // =============================================
        private void BuildStepsIndicator()
        {
            pnlSteps.Controls.Clear();

            bool step1Done = pnlPatientFound.Visible;
            bool step2Done = step1Done && !string.IsNullOrWhiteSpace(txtChanDoan.Text) 
                                       && !string.IsNullOrWhiteSpace(txtDieuTri.Text) 
                                       && !string.IsNullOrWhiteSpace(txtKetLuan.Text);
            bool step3Done = step2Done && _selectedDoctorCard != null;
            bool step4Done = step3Done && _step4Done;

            bool[] done = { step1Done, step2Done, step3Done, step4Done };
            bool[] active = {
                !step1Done,
                step1Done && !step2Done,
                step2Done && !step3Done,
                step3Done && !step4Done
            };

            string[] labels = { "Chọn bệnh nhân", "Thông tin bệnh án", "Chỉ định bác sĩ khoa", "Xác nhận lưu" };
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
            pnlDoctorGrid.Controls.Clear();
            _selectedDoctorCard = null;
            _selectedDoctorCode = "";
            _selectedDoctorName = "";
            SetSummaryText(lblSumBS, "Chưa có");

            string currentDept = "Khoa tim mạch";
            if (cboKhoaDT.SelectedItem != null)
            {
                currentDept = cboKhoaDT.SelectedItem.ToString().Trim();
            }

            var doctorsList = new System.Collections.Generic.List<dynamic>();

            try
            {
                DataTable dt = HospitalX.DAO.HsbaDAO.GetDoctorsForTaoHSBA(currentDept);
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        doctorsList.Add(new {
                            Code = row["MANV"].ToString(),
                            Name = row["HOTEN"].ToString(),
                            Spec = row["CHUYENKHOA"].ToString(),
                            Status = "● Đang rảnh",
                            IsFree = true,
                            IsSelected = false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi doc danh sach bac si: " + ex.Message);
            }

            if (doctorsList.Count == 0)
            {
                doctorsList.Add(new { Code = "BS-TM-001", Name = "BS. Trần Minh Khoa", Spec = currentDept, Status = "● Đang rảnh", IsFree = true, IsSelected = false });
                doctorsList.Add(new { Code = "BS-TM-002", Name = "BS. Nguyễn Thị Hồng", Spec = currentDept, Status = "● Đang bận", IsFree = false, IsSelected = false });
                doctorsList.Add(new { Code = "BS-TM-003", Name = "TS. Lê Đình Phước", Spec = currentDept, Status = "● Đang rảnh", IsFree = true, IsSelected = false });
                doctorsList.Add(new { Code = "BS-TM-004", Name = "BS. Phạm Thu Hà", Spec = currentDept, Status = "● Đang bận", IsFree = false, IsSelected = false });
            }

            int cardW = 435;
            int cardH = 116;
            int gap = 10;

            for (int i = 0; i < doctorsList.Count; i++)
            {
                var doc = doctorsList[i];
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

                string code = doc.Code;
                string name = doc.Name;
                card.Click += (s, ev) => SelectDoctor(card, code, name);

                foreach (Control c in card.Controls)
                {
                    c.Click += (s, ev) => SelectDoctor(card, code, name);
                }

                pnlDoctorGrid.Controls.Add(card);
            }
            BuildStepsIndicator();
            AdjustLayout();
        }

        private void SelectDoctor(Guna2Panel card, string code, string name)
        {
            if (_selectedDoctorCard == card)
            {
                SelectDoctorByCode("");
            }
            else
            {
                SelectDoctorByCode(code);
            }
        }

        private void SelectDoctorByCode(string code)
        {
            Guna2Panel targetCard = null;
            string targetName = "";

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

                    if (!string.IsNullOrEmpty(code) && p.Tag as string == code)
                    {
                        targetCard = p;
                        // Find the name label inside the card
                        foreach (Control child in p.Controls)
                        {
                            if (child is Label l && l.Location.Y == 34) // based on name label location
                            {
                                targetName = l.Text;
                            }
                        }
                    }
                }
            }

            if (targetCard != null)
            {
                targetCard.BorderColor = Teal;
                targetCard.FillColor = TealLight;
                var checkMark = new Label();
                checkMark.AutoSize = true;
                checkMark.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                checkMark.ForeColor = Teal;
                checkMark.Location = new Point(targetCard.Width - 30, 8);
                checkMark.Text = "✓";
                checkMark.BackColor = Color.Transparent;
                string localCode = code;
                string localName = targetName;
                checkMark.Click += (s, ev) => SelectDoctor(targetCard, localCode, localName);
                targetCard.Controls.Add(checkMark);

                _selectedDoctorCode = code;
                _selectedDoctorName = targetName;
                _selectedDoctorCard = targetCard;

                SetSummaryText(lblSumBS, $"{code} — {targetName}");
                SetSummaryText(lblSumKhoa, cboKhoaDT.Text);
            }
            else
            {
                _selectedDoctorCode = "";
                _selectedDoctorName = "";
                _selectedDoctorCard = null;

                SetSummaryText(lblSumBS, "Chưa có");
                SetSummaryText(lblSumKhoa, "Chưa có");
            }

            BuildStepsIndicator();
            AdjustLayout();
        }

        private void BuildSummaryContent()
        {
            pnlSummaryBody.Controls.Clear();
            pnlSummaryBody.AutoScroll = false;

            _flpSummary = new FlowLayoutPanel();
            _flpSummary.Dock = DockStyle.Fill;
            _flpSummary.FlowDirection = FlowDirection.TopDown;
            _flpSummary.WrapContents = false;
            _flpSummary.AutoScroll = true; // Bật thanh cuộn dọc thông minh!
            _flpSummary.Padding = new Padding(16, 12, 16, 12);
            _flpSummary.BackColor = Color.Transparent;
            pnlSummaryBody.Controls.Add(_flpSummary);

            // Row 1: MÃ HSBA (Left) & NGÀY MỞ (Right)
            var row1 = CreateSideBySideRow("MÃ HSBA", "NGÀY MỞ", true, false, 175, 125, 195, out lblSumMaHSBA, out lblSumNgayMo);
            _flpSummary.Controls.Add(row1);

            // Row 2: BỆNH NHÂN (Left) & MÃ BN (Right)
            var row2 = CreateSideBySideRow("BỆNH NHÂN", "MÃ BN", false, true, 175, 125, 195, out lblSumBN, out lblSumMaBN);
            _flpSummary.Controls.Add(row2);

            // Row 3: BÁC SĨ PHỤ TRÁCH (Left) & KHOA (Right)
            var row3 = CreateSideBySideRow("BÁC SĨ PHỤ TRÁCH", "KHOA", false, true, 175, 125, 195, out lblSumBS, out lblSumKhoa);
            _flpSummary.Controls.Add(row3);

            // Row 4: CHẨN ĐOÁN (Full width)
            var row4 = CreateFullWidthRow("CHẨN ĐOÁN", false, out lblSumChanDoan);
            _flpSummary.Controls.Add(row4);

            // Row 5: ĐIỀU TRỊ (Full width)
            var row5 = CreateFullWidthRow("ĐIỀU TRỊ", false, out lblSumDieuTri);
            _flpSummary.Controls.Add(row5);

            // Row 6: KẾT LUẬN (Full width)
            var row6 = CreateFullWidthRow("KẾT LUẬN", false, out lblSumKetLuan);
            _flpSummary.Controls.Add(row6);
        }

        private Panel CreateSideBySideRow(string key1Text, string key2Text, bool val1Mono, bool val2Mono, int width1, int width2, int rightX, out Label val1Out, out Label val2Out)
        {
            var p = new Panel();
            p.Width = 320; // Thu gọn chiều rộng xuống 320px để chừa chỗ cho scrollbar dọc, tránh scroll ngang
            p.Height = 36;
            p.Margin = new Padding(0, 0, 0, 14);
            p.BackColor = Color.Transparent;

            // Left Col Key
            var k1 = new Label();
            k1.Text = key1Text;
            k1.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            k1.ForeColor = LabelColor;
            k1.Location = new Point(0, 0);
            k1.AutoSize = true;
            k1.BackColor = Color.Transparent;
            p.Controls.Add(k1);

            // Left Col Val
            var v1 = new Label();
            v1.Text = "Chưa có";
            v1.Font = val1Mono ? new Font("Consolas", 9F, FontStyle.Bold) : new Font("Segoe UI", 9F, FontStyle.Regular);
            v1.ForeColor = val1Mono ? Teal : Color.FromArgb(26, 46, 39);
            v1.Location = new Point(0, 16);
            v1.Width = width1;
            v1.AutoSize = true;
            v1.MaximumSize = new Size(width1, 0);
            v1.Tag = "value";
            v1.BackColor = Color.Transparent;
            p.Controls.Add(v1);
            val1Out = v1;

            // Right Col Key
            var k2 = new Label();
            k2.Text = key2Text;
            k2.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            k2.ForeColor = LabelColor;
            k2.Location = new Point(rightX, 0);
            k2.AutoSize = true;
            k2.BackColor = Color.Transparent;
            p.Controls.Add(k2);

            // Right Col Val
            var v2 = new Label();
            v2.Text = "Chưa có";
            v2.Font = val2Mono ? new Font("Consolas", 9F, FontStyle.Bold) : new Font("Segoe UI", 9F, FontStyle.Regular);
            v2.ForeColor = val2Mono ? Teal : Color.FromArgb(26, 46, 39);
            v2.Location = new Point(rightX, 16);
            v2.Width = width2;
            v2.AutoSize = true;
            v2.MaximumSize = new Size(width2, 0);
            v2.Tag = "value";
            v2.BackColor = Color.Transparent;
            p.Controls.Add(v2);
            val2Out = v2;

            return p;
        }

        private Panel CreateFullWidthRow(string keyText, bool valMono, out Label valOut)
        {
            var p = new Panel();
            p.Width = 320; // Thu gọn chiều rộng xuống 320px
            p.Height = 36;
            p.Margin = new Padding(0, 0, 0, 14);
            p.BackColor = Color.Transparent;

            // Key
            var k = new Label();
            k.Text = keyText;
            k.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            k.ForeColor = LabelColor;
            k.Location = new Point(0, 0);
            k.AutoSize = true;
            k.BackColor = Color.Transparent;
            p.Controls.Add(k);

            // Val
            var v = new Label();
            v.Text = "Chưa có";
            v.Font = valMono ? new Font("Consolas", 9F, FontStyle.Bold) : new Font("Segoe UI", 9F, FontStyle.Regular);
            v.ForeColor = valMono ? Teal : Color.FromArgb(26, 46, 39);
            v.Location = new Point(0, 16);
            v.Width = 320;
            v.AutoSize = true;
            v.MaximumSize = new Size(320, 0);
            v.Tag = "value";
            v.BackColor = Color.Transparent;
            p.Controls.Add(v);
            valOut = v;

            return p;
        }

        private void SetSummaryText(Label val, string text)
        {
            if (val == null) return;
            val.Text = text;
            if (val.Parent is Panel p)
            {
                int maxBottom = 0;
                foreach (Control c in p.Controls)
                {
                    if (c is Label l && l.Tag as string == "value")
                    {
                        l.Height = l.PreferredHeight;
                        if (l.Bottom > maxBottom)
                            maxBottom = l.Bottom;
                    }
                }
                p.Height = maxBottom + 4;
            }
            AdjustLayout();
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
        // PATIENT SEARCH
        // =============================================
        private void ExecuteSearchBN()
        {
            string query = txtSearchBN.Text.Trim();
            if (string.IsNullOrWhiteSpace(query))
                return;

            bool found = false;
            try
            {
                DataTable dt = HospitalX.DAO.PatientDAO.SearchPatient(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string name = row["TENBN"] != DBNull.Value ? row["TENBN"].ToString().Trim() : "";
                    string code = row["MABN"] != DBNull.Value ? row["MABN"].ToString().Trim() : "";
                    string phai = row["PHAI"] != DBNull.Value ? row["PHAI"].ToString().Trim() : "";
                    string dob = row["NGAYSINH"] != DBNull.Value ? Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy") : "";
                    string dept = "Tim mạch";

                    LoadPatient(name, code, phai, dob, dept);
                    found = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi tim kiem benh nhan cho HSBA: " + ex.Message);
            }

            if (!found)
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

            // Mã HSBA sẽ được tự động sinh khi nhấn Tạo hồ sơ bệnh án
            txtMaHSBA.Text = "(Tự động)";

            // Map patient registered department to cboKhoaDT to assist coordinator
            string deptLower = dept.ToLower();
            int selectedIndex = -1;
            for (int i = 0; i < cboKhoaDT.Items.Count; i++)
            {
                string itemText = cboKhoaDT.Items[i].ToString().ToLower();
                if (deptLower.Contains("tim") && itemText.Contains("tim"))
                {
                    selectedIndex = i;
                    break;
                }
                if ((deptLower.Contains("thần") || deptLower.Contains("than")) && (itemText.Contains("thần") || itemText.Contains("than")))
                {
                    selectedIndex = i;
                    break;
                }
                if ((deptLower.Contains("tiêu") || deptLower.Contains("tieu")) && (itemText.Contains("tiêu") || itemText.Contains("tieu")))
                {
                    selectedIndex = i;
                    break;
                }
            }

            if (selectedIndex >= 0)
            {
                cboKhoaDT.SelectedIndex = selectedIndex;
            }
            else if (cboKhoaDT.Items.Count > 0)
            {
                cboKhoaDT.SelectedIndex = 0;
            }

            // Always clear clinical inputs so coordinator enters new record details manually
            txtChanDoan.Text = "";
            txtDieuTri.Text = "";
            txtKetLuan.Text = "";

            txtChanDoan.BorderColor = CardBorder;
            txtDieuTri.BorderColor = CardBorder;
            txtKetLuan.BorderColor = CardBorder;

            _step4Done = false;

            SelectDoctorByCode("");
            BuildStepsIndicator();

            // Update summary
            SetSummaryText(lblSumMaHSBA, txtMaHSBA.Text);
            SetSummaryText(lblSumBN, name);
            SetSummaryText(lblSumMaBN, code);
            SetSummaryText(lblSumNgayMo, dtpNgayMo.Value.ToString("dd/MM/yyyy"));
            SetSummaryText(lblSumKhoa, "Chưa có");
            SetSummaryText(lblSumChanDoan, "Chưa có");
            SetSummaryText(lblSumDieuTri, "Chưa có");
            SetSummaryText(lblSumKetLuan, "Chưa có");

            btnCreateHSBA.Enabled = true;

            AdjustLayout();
        }

        private void ChangeBN()
        {
            txtSearchBN.Text = "";
            txtSearchBN.Focus();
            pnlPatientFound.Visible = false;

            // Clear inputs
            txtMaHSBA.Text = "";
            txtChanDoan.Text = "";
            txtDieuTri.Text = "";
            txtKetLuan.Text = "";
            txtChanDoan.BorderColor = CardBorder;
            txtDieuTri.BorderColor = CardBorder;
            txtKetLuan.BorderColor = CardBorder;
            _step4Done = false;
            BuildStepsIndicator();

            // Clear doctor selection
            SelectDoctorByCode("");

            // Clear summary
            SetSummaryText(lblSumMaHSBA, "Chưa có");
            SetSummaryText(lblSumBN, "Chưa có");
            SetSummaryText(lblSumMaBN, "Chưa có");
            SetSummaryText(lblSumNgayMo, "Chưa có");
            SetSummaryText(lblSumBS, "Chưa có");
            SetSummaryText(lblSumKhoa, "Chưa có");
            SetSummaryText(lblSumChanDoan, "Chưa có");
            SetSummaryText(lblSumDieuTri, "Chưa có");
            SetSummaryText(lblSumKetLuan, "Chưa có");

            btnCreateHSBA.Enabled = false;

            AdjustLayout();
        }

        // =============================================
        // CREATE HSBA
        // =============================================
        private string MapKhoaToCode(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            string lower = text.ToLower();
            if (lower.Contains("tim mạch") || lower.Contains("ktm")) return "KTM";
            if (lower.Contains("thần kinh") || lower.Contains("ktk")) return "KTK";
            if (lower.Contains("tiêu hóa") || lower.Contains("kth")) return "KTH";
            
            int start = text.IndexOf('(');
            int end = text.IndexOf(')');
            if (start >= 0 && end > start)
            {
                return text.Substring(start + 1, end - start - 1);
            }
            return text.Length > 10 ? text.Substring(0, 10) : text;
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
            if (string.IsNullOrWhiteSpace(txtDieuTri.Text))
            {
                valid = false;
                errorMsg += "\n- Hướng điều trị";
                txtDieuTri.BorderColor = Color.FromArgb(253, 114, 114);
            }
            if (string.IsNullOrWhiteSpace(txtKetLuan.Text))
            {
                valid = false;
                errorMsg += "\n- Kết luận";
                txtKetLuan.BorderColor = Color.FromArgb(253, 114, 114);
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

            string maHsba = txtMaHSBA.Text.Trim();
            string maBn = lblSumMaBN.Text.Trim();
            DateTime ngay = dtpNgayMo.Value;
            string chanDoan = txtChanDoan.Text.Trim();
            string dieuTri = txtDieuTri.Text.Trim();
            string maBs = string.IsNullOrEmpty(_selectedDoctorCode) ? null : _selectedDoctorCode.Trim();
            string maKhoa = string.IsNullOrEmpty(_selectedDoctorCode) ? null : MapKhoaToCode(cboKhoaDT.Text);
            string ketLuan = txtKetLuan.Text.Trim();

            bool dbSuccess = false;
            string dbError = "";

            try
            {
                maHsba = HospitalX.DAO.HsbaDAO.GetNextHsbaId();
                txtMaHSBA.Text = maHsba;

                dbSuccess = HospitalX.DAO.HsbaDAO.InsertHsba(
                    maHsba, maBn, ngay, chanDoan, dieuTri, maBs, maKhoa, ketLuan
                );
            }
            catch (Exception ex)
            {
                dbSuccess = false;
                dbError = ex.Message;
            }

            if (!dbSuccess)
            {
                string showMsg = "Không thể tạo hồ sơ bệnh án mới.\nChi tiết lỗi: " + dbError;
                ShowDialog("Lỗi Cơ Sở Dữ Liệu", showMsg, Guna.UI2.WinForms.MessageDialogIcon.Error);
                return;
            }

            // Set Step 4 completed
            _step4Done = true;
            BuildStepsIndicator();

            // Show success
            string successMsg = $"Tạo hồ sơ bệnh án thành công!\n\n"
                + $"Mã HSBA: {maHsba}\n";
            if (!string.IsNullOrEmpty(maBs))
            {
                successMsg += $"Bác sĩ: {_selectedDoctorName} ({maBs})\n"
                    + $"Khoa: {cboKhoaDT.Text}\n\n"
                    + "Bác sĩ đã được thông báo qua OLS.";
            }
            else
            {
                successMsg += "Hồ sơ bệnh án được tạo thành công mà chưa chỉ định Bác sĩ và Khoa điều trị.";
            }

            ShowDialog("Thành công", successMsg, Guna.UI2.WinForms.MessageDialogIcon.Information);
            ChangeBN();
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

            // Dynamically scale columns in Step 2
            int col1X = 20;
            int fieldW = (pnlStep2Card.Width - 60) / 2;
            int col2X = col1X + fieldW + 20;

            txtMaHSBA.Location = new Point(col1X, 80);
            txtMaHSBA.Width = fieldW;
            lblNgayMo.Location = new Point(col2X, 56);
            dtpNgayMo.Location = new Point(col2X, 80);
            dtpNgayMo.Width = fieldW;

            // Dynamically scale multiline fields in Step 2
            txtChanDoan.Width = pnlStep2Card.Width - 40;
            txtDieuTri.Width = pnlStep2Card.Width - 40;
            txtKetLuan.Width = pnlStep2Card.Width - 40;
            pnlStep2Card.Height = txtKetLuan.Bottom + 20;

            // Dynamically scale fields in Step 3
            cboKhoaDT.Width = fieldW;
            lblChonBS.Location = new Point(col1X, 138);
            pnlDoctorGrid.Location = new Point(col1X, 162);
            pnlDoctorGrid.Width = pnlStep3Card.Width - 40;

            // Save doctor scroll position and temporarily reset to (0, 0)
            Point docScrollPos = pnlDoctorGrid.AutoScrollPosition;
            pnlDoctorGrid.AutoScrollPosition = new Point(0, 0);

            // Scale doctor cards inside grid
            int gridWidth = pnlDoctorGrid.Width;
            if (pnlDoctorGrid.Controls.Count > 4)
            {
                gridWidth -= SystemInformation.VerticalScrollBarWidth + 4;
            }
            int docW = (gridWidth - 14) / 2;
            int docH = 116;
            for (int i = 0; i < pnlDoctorGrid.Controls.Count; i++)
            {
                var card = pnlDoctorGrid.Controls[i] as Guna2Panel;
                if (card != null)
                {
                    int col = i % 2;
                    int row = i / 2;
                    card.Location = new Point(col * (docW + 14), row * (docH + 14));
                    card.Width = docW;
                    foreach (Control child in card.Controls)
                    {
                        if (child is Label lbl && lbl.Text == "✓" && lbl.Font.Size > 10)
                        {
                            lbl.Left = docW - 30;
                        }
                    }
                }
            }

            // Restore doctor scroll position
            pnlDoctorGrid.AutoScrollPosition = new Point(Math.Abs(docScrollPos.X), Math.Abs(docScrollPos.Y));

            pnlStep3Card.Height = pnlDoctorGrid.Bottom + 20;

            // Dynamically stack left cards with 16px gap!
            pnlStep2Card.Top = pnlStep1Card.Bottom + 16;
            pnlStep3Card.Top = pnlStep2Card.Bottom + 16;
            pnlActionsCard.Top = pnlStep3Card.Bottom + 16;

            int sumHeight = 420;
            if (_flpSummary != null)
            {
                int contentHeight = _flpSummary.Padding.Top + _flpSummary.Padding.Bottom;
                foreach (Control c in _flpSummary.Controls)
                {
                    if (c.Visible)
                    {
                        contentHeight += c.Height + c.Margin.Top + c.Margin.Bottom;
                    }
                }
                int requiredHeight = contentHeight + 40 + 12;
                sumHeight = Math.Min(Math.Max(requiredHeight, 200), 420);
            }

            pnlSummaryCard.Height = sumHeight;
            pnlSummaryBody.Height = sumHeight - 40 - 12;
            pnlSummaryCard.Location = new Point(rightX, 91);
            pnlSummaryCard.Width = rightW;
            pnlPermCard.Visible = false;

            // Reposition search button
            btnSearchBN.Left = pnlStep1Card.Width - btnSearchBN.Width - 24;
            txtSearchBN.Width = btnSearchBN.Left - 34;
            pnlPatientFound.Width = pnlStep1Card.Width - 44;
            btnChangeBN.Left = pnlPatientFound.Width - btnChangeBN.Width - 10;

            // Reposition footer buttons dynamically
            btnCreateHSBA.Left = pnlActionsCard.Width - btnCreateHSBA.Width - 24;

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

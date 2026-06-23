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

        // Layout UI controls (instantiated inside #if false blocks but referenced in active validation checks)
#pragma warning disable CS0169, CS0649
        private Label lblQueueTitle;
        private Label lblQueueCount;
        private Guna2TextBox txtSearchQueue;
        private FlowLayoutPanel pnlQueueItems;
#pragma warning restore CS0169, CS0649

        // Form Cards
        private Guna2Panel pnlAvatarCircle;
        private Label lblAvatarText;
        private Label lblPatientName;
        private Label lblPatientMeta;
        // pnlPrioBadge removed â€” Priority does not exist in Oracle DB schema
        private Label lblSvcTitle;
        private Label lblSvcMeta;
        private Guna2Panel divSvc1;
        private Guna2Panel divSvc2;
        private Label lblParamsTitle;
        private Guna2Panel pnlTableHeader;
        // pnlPrioBadge and lblPrioText removed â€” Priority does not exist in Oracle DB schema

        private Label lblConclusionHeader;
        private Label lblRemarksLabel;
        private Guna2TextBox txtRemarks;
        private Label lblConclusionDropdownLabel;
        private Guna2ComboBox cboConclusion;
        private Label lblTimeLabel;
        private Guna2DateTimePicker dtpFinishTime;

        private Label lblAttachmentHeader;
        private Guna2Panel pnlUploadZone;
        private Label lblUpload1;
        private Label lblUpload2;
        private FlowLayoutPanel flpUploadedFiles;

        private Label lblActionsKtvInfo;
        private Guna2Button btnSaveDraft;
        // btnSendDoctor removed â€” 'Äang thá»±c hiá»‡n' state does not exist in Oracle DB schema (only KETQUA IS NULL or IS NOT NULL)
        private Guna2Button btnComplete;

        // Topbar
        private Guna2Panel pnlTopbar;
        private Label lblTopbarTitle;
        private Label lblTopbarSub;
        private Guna2Panel pnlTopbarBadge;
        private Label lblTopbarBadge;
        private const int TopbarHeight = 64;
        private FlowLayoutPanel flpServiceRecords;
        private readonly Dictionary<Guna2Panel, KtvService> serviceCardMap = new Dictionary<Guna2Panel, KtvService>();

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
            Disposed += ucKtvKetQua_Disposed;
            DoubleBuffered = true;
            BackColor = KtvTheme.Bg;
            this.AutoScroll = false;

            allServices = KtvData.Services();
            // Start with the first service that is not completed
            activeService = allServices.FirstOrDefault(x => x.Status != "Ho\u00e0n th\u00e0nh") ?? allServices.First();

            BuildControls();

            this.Resize += UcKtvKetQua_Resize;
            this.Load += UcKtvKetQua_Load;
        }

        private void ucKtvKetQua_Disposed(object sender, EventArgs e)
        {
            if (tmrToast != null)
            {
                tmrToast.Stop();
                tmrToast.Tick -= TmrToast_Tick;
                tmrToast.Dispose();
                tmrToast = null;
            }
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
            // 0. Build Topbar
            pnlTopbar = new Guna2Panel
            {
                FillColor = Color.White,
                BorderRadius = 0,
                BorderColor = KtvTheme.Border,
                BorderThickness = 1
            };
            lblTopbarTitle = new Label
            {
                Text = "C\u1eadp nh\u1eadt k\u1ebft qu\u1ea3 d\u1ecbch v\u1ee5",
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

            SetupDesignerNativeForm();

#if false
            // 1. Build Queue Panel (Left)
            pnlQueue.BorderColor = KtvTheme.Border;
            pnlQueue.ShadowDecoration.Enabled = true;
            pnlQueue.ShadowDecoration.Color = KtvTheme.Teal;
            pnlQueue.ShadowDecoration.Depth = 8;
            pnlQueue.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            lblQueueTitle = KtvTheme.Label("ðŸ—‚ HÃ ng chá» káº¿t quáº£", 20, 18, 10.5F, FontStyle.Bold, KtvTheme.TextDark);

            lblQueueCount = new Label
            {
                Text = "3 chá»",
                Location = new Point(236, 18),
                Size = new Size(64, 24),
                BackColor = KtvTheme.AccentSoft,
                ForeColor = Color.FromArgb(160, 112, 0),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlQueue.Controls.Add(lblQueueCount);

            txtSearchQueue = new Guna2TextBox
            {
                PlaceholderText = "TÃ¬m bá»‡nh nhÃ¢nâ€¦",
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

            // 2. Form Container is created statically in InitializeComponent()
#endif

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
            int topbarH = 0;

            // 0. Topbar (full width, top)
            pnlTopbar.Location = new Point(0, 0);
            pnlTopbar.Size = new Size(this.Width, topbarH);
            pnlTopbar.Visible = false;

            lblTopbarTitle.Location = new Point(margin, 14);
            lblTopbarSub.Location = new Point(margin, 38);

            // Update badge text & subtitle
            int waitCount = allServices != null ? allServices.Count(x => x.Status != "Ho\u00e0n th\u00e0nh") : 0;
            lblTopbarSub.Text = $"{waitCount} k\u1ebft qu\u1ea3 \u0111ang ch\u1edd c\u1eadp nh\u1eadt - H\u00f4m nay {DateTime.Now:dd/MM/yyyy}";
            lblTopbarBadge.Text = $"{waitCount} ch\u1edd c\u1eadp nh\u1eadt";

            // Badge position (right side of topbar)
            pnlTopbarBadge.Location = new Point(this.Width - margin - pnlTopbarBadge.Width, (topbarH - pnlTopbarBadge.Height) / 2);
            lblTopbarBadge.Size = new Size(pnlTopbarBadge.Width, pnlTopbarBadge.Height);
            lblTopbarBadge.Location = new Point(0, 0);

            int availTop = topbarH + margin;
            int availHeight = this.Height - availTop - margin;
            if (availHeight < 200) availHeight = 500;

            pnlQueue.Visible = false;

            ResizeDesignerNativeForm();
            BindDesignerNativeForm();

            // Adjust Toast location
            pnlToast.Location = new Point(this.Width - pnlToast.Width - margin, this.Height - pnlToast.Height - 16);
            pnlToast.BringToFront();
        }

        private void LayoutRightSideForm(int w)
        {
            if (activeService == null) return;

            BindDesignerNativeForm();
            return;
        }

        private void SetupDesignerNativeForm()
        {
            pnlQueue.Visible = false;
            EnsureServiceCardsList();
            ApplyVietnameseText();
            pnlFormContainer.AutoScroll = false;
            pnlFormContainer.HorizontalScroll.Enabled = false;
            pnlFormContainer.HorizontalScroll.Visible = false;
            pnlFormContainer.HorizontalScroll.Maximum = 0;

            cboConclusion.Items.Clear();
            cboConclusion.Items.AddRange(new object[] { "B\u00ecnh th\u01b0\u1eddng", "B\u1ea5t th\u01b0\u1eddng - C\u1ea7n theo d\u00f5i", "B\u1ea5t th\u01b0\u1eddng - Kh\u1ea9n c\u1ea5p", "C\u1ea7n th\u1ef1c hi\u1ec7n l\u1ea1i" });
            cboConclusion.SelectedIndex = 1;
            ApplyFormStyling();
        }

        private void ApplyVietnameseText()
        {
            lblSimpleTitle.Text = "Bi\u1ec3u m\u1eabu c\u1eadp nh\u1eadt";
            lblSimplePatient.Text = "B\u1ec7nh nh\u00e2n:";
            lblHeaderIndicator.Text = "Ch\u1ec9 s\u1ed1";
            lblHeaderResult.Text = "K\u1ebft qu\u1ea3";
            lblDensity.Text = "M\u1eadt \u0111\u1ed9/H\u00ecnh \u1ea3nh";
            lblLesion.Text = "M\u00f4 t\u1ea3 t\u1ed5n th\u01b0\u01a1ng";
            lblSimpleConclusion.Text = "K\u1ebft lu\u1eadn chung:";
            lblRemarksLabel.Text = "Ghi ch\u00fa c\u1ee7a K\u1ef9 thu\u1eadt vi\u00ean (L\u01b0u v\u00e0o KETQUA):";
            txtDensity.DefaultText = "B\u00ecnh th\u01b0\u1eddng";
            txtLesion.DefaultText = "Kh\u00f4ng c\u00f3";
            txtRemarks.PlaceholderText = "Nh\u1eadp n\u1ed9i dung chuy\u00ean m\u00f4n...";
            btnComplete.Text = "X\u00e1c nh\u1eadn ho\u00e0n t\u1ea5t";
            lblRecordsTitle.Text = "Danh s\u00e1ch h\u1ed3 s\u01a1 b\u1ec7nh \u00e1n d\u1ecbch v\u1ee5";
        }

        private void ResizeDesignerNativeForm()
        {
            int pad = 28;
            int listPad = 18;
            int listInnerW = pnlRecords.ClientSize.Width - listPad * 2 - SystemInformation.VerticalScrollBarWidth - 4;
            if (listInnerW < 180) listInnerW = 180;
            lblRecordsTitle.Width = listInnerW;
            if (flpServiceRecords != null)
            {
                flpServiceRecords.Location = new Point(listPad, 96);
                flpServiceRecords.Size = new Size(listInnerW, pnlRecords.ClientSize.Height - 124);
            }

            int innerW = pnlFormContainer.ClientSize.Width - pad * 2 - SystemInformation.VerticalScrollBarWidth - 8;
            if (innerW < 320) innerW = 320;

            pnlFormContainer.AutoScrollPosition = Point.Empty;
            lblSimpleTitle.Location = new Point(pad, 34);
            lblSimpleTitle.Width = innerW;
            lblSimpleTitle.Height = 44;
            lblSimplePatient.Location = new Point(pad, 91);
            lblSimplePatient.Width = innerW;
            lblSimplePatient.Height = 32;
            pnlSimpleDivider.Location = new Point(pad, 150);
            pnlSimpleDivider.Width = innerW;
            pnlSimpleDivider.Height = 2;
            pnlResultsCard.Location = new Point(pad, 185);
            pnlResultsCard.Width = innerW;
            pnlResultsCard.Height = 171;
            tblSimpleResults.Location = new Point(1, 1);
            tblSimpleResults.Width = pnlResultsCard.ClientSize.Width - 2;
            tblSimpleResults.Height = pnlResultsCard.ClientSize.Height - 2;
            if (tblSimpleResults.Width > 0 && tblSimpleResults.Height > 0)
            {
                tblSimpleResults.Region = GetRoundedRegion(tblSimpleResults.ClientRectangle, 8);
            }
            lblSimpleConclusion.Location = new Point(pad, 376);
            lblSimpleConclusion.Width = innerW;
            lblSimpleConclusion.Height = 30;
            cboConclusion.Location = new Point(pad, 410);
            cboConclusion.Width = innerW;
            cboConclusion.Height = 40;
            lblRemarksLabel.Location = new Point(pad, 486);
            lblRemarksLabel.Width = innerW;
            lblRemarksLabel.Height = 30;
            txtRemarks.Location = new Point(pad, 522);
            txtRemarks.Width = innerW;
            txtRemarks.Height = 153;
            btnComplete.Location = new Point(pad, 710);

            foreach (Control control in new Control[] { lblSimpleTitle, lblSimplePatient, pnlSimpleDivider, pnlResultsCard, tblSimpleResults, lblSimpleConclusion, cboConclusion, lblRemarksLabel, txtRemarks, btnComplete })
            {
                control.Visible = true;
                control.BringToFront();
            }
        }

        private void BindDesignerNativeForm()
        {
            if (activeService == null) return;


            lblSimplePatient.Text = $"B\u1ec7nh nh\u00e2n: {activeService.Patient} - {activeService.MaBn}";
            txtDensity.Text = "B\u00ecnh th\u01b0\u1eddng";
            txtLesion.Text = "Kh\u00f4ng c\u00f3";
            if (cboConclusion.SelectedIndex < 0) cboConclusion.SelectedIndex = 1;
            txtRemarks.Text = activeService.KetQua ?? string.Empty;
            RenderServiceCards();
        }

        private void dgvServiceRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= allServices.Count) return;
            activeService = allServices[e.RowIndex];
            BindDesignerNativeForm();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (activeService == null) return;

            string details = $"Mật độ/Hình ảnh: {txtDensity.Text}; Mô tả tổn thương: {txtLesion.Text}; Kết luận: {cboConclusion.Text}";
            string note = txtRemarks.Text.Trim();
            string res = string.IsNullOrWhiteSpace(note) ? details : details + ". Ghi chú: " + note;

            bool ok = KtvData.UpdateServiceResult(activeService.MaHsba, activeService.Service, activeService.NgayDv, res);
            if (ok)
            {
                activeService.KetQua = res;
                ShowToastNotification("✅ Đã lưu KETQUA vào HSBA_DV thành công!");
                
                // Tải lại danh sách dịch vụ từ DB và cập nhật UI
                allServices = KtvData.Services();
                RenderServiceCards();

                var next = allServices.FirstOrDefault(x => x.Status != "Hoàn thành");
                if (next != null)
                {
                    SelectPatient(next);
                }
                else
                {
                    BindDesignerNativeForm();
                }
            }
            else
            {
                ShowToastNotification("❌ Không thể lưu kết quả! Vui lòng thử lại.");
            }
        }

        private void EnsureServiceCardsList()
        {
            if (flpServiceRecords != null) return;

            flpServiceRecords = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.White,
                Location = new Point(28, 96),
                Size = new Size(284, 600)
            };
            pnlRecords.Controls.Add(flpServiceRecords);
            flpServiceRecords.BringToFront();
        }

        private void RenderServiceCards()
        {
            if (flpServiceRecords == null || allServices == null) return;

            flpServiceRecords.SuspendLayout();
            flpServiceRecords.Controls.Clear();
            serviceCardMap.Clear();

            int cardW = Math.Max(280, flpServiceRecords.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 2);
            foreach (var service in allServices)
            {
                var card = CreateServiceRecordCard(service, cardW, service == activeService);
                flpServiceRecords.Controls.Add(card);
                serviceCardMap[card] = service;
            }

            flpServiceRecords.ResumeLayout();
        }

        private Guna2Panel CreateServiceRecordCard(KtvService service, int width, bool active)
        {
            var card = new Guna2Panel
            {
                Size = new Size(width, 76),
                Margin = new Padding(0, 0, 0, 8),
                BorderRadius = 10,
                BorderColor = active ? KtvTheme.Teal : KtvTheme.Border,
                BorderThickness = 1,
                FillColor = active ? KtvTheme.TealLight : Color.White,
                Cursor = Cursors.Hand,
                CustomBorderColor = active ? KtvTheme.Teal : Color.Transparent,
                CustomBorderThickness = new Padding(active ? 4 : 0, 0, 0, 0)
            };
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Color = Color.FromArgb(30, 15, 110, 86);
            card.ShadowDecoration.Depth = active ? 8 : 4;
            card.ShadowDecoration.Shadow = active ? new Padding(0, 2, 8, 4) : new Padding(0, 1, 4, 2);

            var lblHsba = KtvTheme.Label(service.MaHsba, 14, 10, 8F, FontStyle.Bold, active ? KtvTheme.Teal : KtvTheme.TextMid);
            lblHsba.AutoSize = false;
            lblHsba.Size = new Size(width - 28, 18);

            var lblPatient = KtvTheme.Label(service.Patient, 14, 30, 9F, FontStyle.Bold, KtvTheme.TextDark);
            lblPatient.AutoSize = false;
            lblPatient.Size = new Size(width - 28, 18);
            lblPatient.AutoEllipsis = true;

            var lblService = KtvTheme.Label(service.Service, 14, 50, 8F, FontStyle.Regular, KtvTheme.TextMid);
            lblService.AutoSize = false;
            lblService.Size = new Size(width - 128, 18);
            lblService.AutoEllipsis = true;

            bool waiting = string.IsNullOrWhiteSpace(service.KetQua);
            var status = new Guna2Panel
            {
                Size = new Size(72, 22),
                Location = new Point(width - 88, 46),
                BorderRadius = 11,
                FillColor = waiting ? KtvTheme.AccentSoft : KtvTheme.TealLight,
                BackColor = active ? KtvTheme.TealLight : Color.White,
                UseTransparentBackground = true
            };
            var lblStatus = new Label
            {
                Text = waiting ? "Ch\u1edd" : "Xong",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 7.5F, FontStyle.Bold),
                ForeColor = waiting ? Color.FromArgb(160, 112, 0) : KtvTheme.Teal,
                BackColor = Color.Transparent
            };
            status.Controls.Add(lblStatus);

            card.Controls.AddRange(new Control[] { lblHsba, lblPatient, lblService, status });
            WireServiceCardEvents(card, service);

            return card;
        }

        private void WireServiceCardEvents(Control control, KtvService service)
        {
            control.Cursor = Cursors.Hand;
            control.Click += (s, e) => SelectPatient(service);
            control.MouseEnter += (s, e) => SetServiceCardHover(control, true);
            control.MouseLeave += (s, e) => SetServiceCardHover(control, false);
            foreach (Control child in control.Controls)
            {
                WireServiceCardEvents(child, service);
            }
        }

        private void SetServiceCardHover(Control source, bool hover)
        {
            Guna2Panel card = source as Guna2Panel;
            while (card != null && !serviceCardMap.ContainsKey(card))
                card = card.Parent as Guna2Panel;

            if (card == null || !serviceCardMap.ContainsKey(card)) return;

            bool active = serviceCardMap[card] == activeService;
            card.FillColor = active ? KtvTheme.TealLight : (hover ? Color.FromArgb(244, 250, 248) : Color.White);
            card.BorderColor = active || hover ? KtvTheme.Teal : KtvTheme.Border;

            // Dynamic shadow depth transitions
            card.ShadowDecoration.Depth = (active || hover) ? 8 : 4;
            card.ShadowDecoration.Shadow = (active || hover) ? new Padding(0, 2, 8, 4) : new Padding(0, 1, 4, 2);

            foreach (Control child in card.Controls)
            {
                if (child is Guna2Panel panel && !serviceCardMap.ContainsKey(panel))
                {
                    panel.BackColor = card.FillColor;
                }
            }
        }

        private void ApplyFormStyling()
        {
            pnlRecords.ShadowDecoration.Color = Color.FromArgb(120, 15, 110, 86);
            pnlRecords.ShadowDecoration.Depth = 6;
            pnlRecords.ShadowDecoration.Shadow = new Padding(0, 2, 6, 2);

            pnlFormContainer.ShadowDecoration.Enabled = true;
            pnlFormContainer.ShadowDecoration.Color = Color.FromArgb(120, 15, 110, 86);
            pnlFormContainer.ShadowDecoration.Depth = 6;
            pnlFormContainer.ShadowDecoration.Shadow = new Padding(0, 2, 6, 2);

            pnlResultsCard.ShadowDecoration.Enabled = true;
            pnlResultsCard.ShadowDecoration.Color = KtvTheme.Teal;
            pnlResultsCard.ShadowDecoration.Depth = 8;
            pnlResultsCard.ShadowDecoration.Shadow = new Padding(0, 2, 8, 2);

            StyleTextBox(txtDensity);
            StyleTextBox(txtLesion);
            StyleTextBox(txtRemarks);

            tblSimpleResults.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            tblSimpleResults.BackColor = Color.White;
            tblSimpleResults.Padding = new Padding(0);
            foreach (Control cell in tblSimpleResults.Controls)
            {
                cell.Margin = new Padding(0);
            }
            lblHeaderIndicator.BackColor = Color.FromArgb(250, 252, 253);
            lblHeaderResult.BackColor = Color.FromArgb(250, 252, 253);
            lblDensity.BackColor = Color.White;
            lblLesion.BackColor = Color.White;
            lblHeaderIndicator.ForeColor = KtvTheme.TextDark;
            lblHeaderResult.ForeColor = KtvTheme.TextDark;
            lblDensity.ForeColor = KtvTheme.TextDark;
            lblLesion.ForeColor = KtvTheme.TextDark;
            txtDensity.BorderRadius = 6;
            txtLesion.BorderRadius = 6;

            cboConclusion.BorderColor = KtvTheme.Border;
            cboConclusion.FocusedState.BorderColor = KtvTheme.Teal;
            cboConclusion.HoverState.BorderColor = KtvTheme.Teal;
            cboConclusion.FillColor = Color.White;
            cboConclusion.ForeColor = KtvTheme.TextDark;
            cboConclusion.ShadowDecoration.Enabled = true;
            cboConclusion.ShadowDecoration.Color = KtvTheme.Teal;
            cboConclusion.ShadowDecoration.Depth = 5;
            cboConclusion.ShadowDecoration.Shadow = new Padding(0, 2, 5, 2);

            txtRemarks.ShadowDecoration.Enabled = true;
            txtRemarks.ShadowDecoration.Color = KtvTheme.Teal;
            txtRemarks.ShadowDecoration.Depth = 5;
            txtRemarks.ShadowDecoration.Shadow = new Padding(0, 2, 5, 2);
            btnComplete.FillColor = KtvTheme.Teal;
            btnComplete.HoverState.FillColor = KtvTheme.TealDark;
        }

        private void StyleTextBox(Guna2TextBox textBox)
        {
            textBox.BorderColor = KtvTheme.Border;
            textBox.FocusedState.BorderColor = KtvTheme.Teal;
            textBox.HoverState.BorderColor = KtvTheme.TealMid;
            textBox.FillColor = Color.White;
        }

        private void BuildSimpleResultForm(int w)
        {
            pnlFormContainer.Controls.Clear();
            pnlFormContainer.AutoScroll = true;
            pnlFormContainer.HorizontalScroll.Enabled = false;
            pnlFormContainer.HorizontalScroll.Visible = false;
            pnlFormContainer.HorizontalScroll.Maximum = 0;
            pnlFormContainer.BorderRadius = 12;
            pnlFormContainer.BorderColor = KtvTheme.Border;
            pnlFormContainer.BorderThickness = 1;
            pnlFormContainer.FillColor = Color.White;

            int pad = 28;
            int scrollBarReserve = SystemInformation.VerticalScrollBarWidth + 8;
            int innerW = pnlFormContainer.ClientSize.Width - pad * 2 - scrollBarReserve;
            if (innerW < 320) innerW = 320;

            int y = 28;

            var lblListTitle = KtvTheme.Label("Danh sách hồ sơ bệnh án dịch vụ", pad, y, 13F, FontStyle.Bold, KtvTheme.TextDark);
            lblListTitle.AutoSize = false;
            lblListTitle.Size = new Size(innerW, 28);
            pnlFormContainer.Controls.Add(lblListTitle);

            var gridRecords = CreateServiceRecordsGrid(innerW);
            gridRecords.Location = new Point(pad, y + 38);
            pnlFormContainer.Controls.Add(gridRecords);

            y += 38 + gridRecords.Height + 30;

            var lblTitle = KtvTheme.Label("Cập nhật kết quả dịch vụ", pad, y, 18F, FontStyle.Bold, KtvTheme.TextDark);
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(innerW, 34);
            pnlFormContainer.Controls.Add(lblTitle);

            var patientLine = $"Bệnh nhân: {activeService.Patient} - {activeService.MaBn}";
            var lblPatient = KtvTheme.Label(patientLine, pad, y + 46, 12F, FontStyle.Regular, KtvTheme.TextDark);
            lblPatient.AutoSize = false;
            lblPatient.Size = new Size(innerW, 26);
            pnlFormContainer.Controls.Add(lblPatient);

            var divider = new Guna2Panel
            {
                Location = new Point(pad, y + 94),
                Size = new Size(innerW, 2),
                FillColor = KtvTheme.Teal
            };
            pnlFormContainer.Controls.Add(divider);

            var table = new TableLayoutPanel
            {
                Location = new Point(pad, y + 122),
                Size = new Size(innerW, 132),
                ColumnCount = 2,
                RowCount = 3,
                BackColor = Color.White,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 57F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));

            table.Controls.Add(CreateTableLabel("Chỉ số", true), 0, 0);
            table.Controls.Add(CreateTableLabel("Kết quả", true), 1, 0);
            table.Controls.Add(CreateTableLabel("Mật độ/Hình ảnh", false), 0, 1);
            table.Controls.Add(CreateTableLabel("Mô tả tổn thương", false), 0, 2);

            var txtDensity = CreateSimpleInput("Bình thường");
            var txtLesion = CreateSimpleInput("Không có");
            table.Controls.Add(txtDensity, 1, 1);
            table.Controls.Add(txtLesion, 1, 2);
            pnlFormContainer.Controls.Add(table);

            var lblConclusion = KtvTheme.Label("Kết luận chung:", pad, y + 274, 11F, FontStyle.Bold, KtvTheme.TextDark);
            pnlFormContainer.Controls.Add(lblConclusion);

            cboConclusion = new Guna2ComboBox
            {
                Location = new Point(pad, y + 300),
                Size = new Size(innerW, 40),
                BorderRadius = 6,
                BorderColor = KtvTheme.Border,
                FillColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                ForeColor = KtvTheme.TextDark,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboConclusion.Items.AddRange(new object[] { "Bình thường", "Bất thường - Cần theo dõi", "Bất thường - Khẩn cấp", "Cần thực hiện lại" });
            cboConclusion.SelectedIndex = 1;
            pnlFormContainer.Controls.Add(cboConclusion);

            lblRemarksLabel = KtvTheme.Label("Ghi chú của Kỹ thuật viên (Lưu vào KETQUA):", pad, y + 360, 11F, FontStyle.Bold, KtvTheme.TextDark);
            pnlFormContainer.Controls.Add(lblRemarksLabel);

            txtRemarks = new Guna2TextBox
            {
                Location = new Point(pad, y + 388),
                Size = new Size(innerW, 124),
                Multiline = true,
                BorderRadius = 6,
                BorderColor = KtvTheme.Border,
                FillColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                ForeColor = KtvTheme.TextDark,
                PlaceholderForeColor = KtvTheme.TextLight,
                PlaceholderText = "Nhập nội dung chuyên môn..."
            };
            if (!string.IsNullOrWhiteSpace(activeService.KetQua))
                txtRemarks.Text = activeService.KetQua;
            pnlFormContainer.Controls.Add(txtRemarks);

            btnComplete = KtvTheme.Button("Xác nhận hoàn tất", KtvTheme.Teal, Color.White);
            btnComplete.Location = new Point(pad, y + 538);
            btnComplete.Size = new Size(170, 45);
            btnComplete.BorderRadius = 6;
            btnComplete.TextAlign = HorizontalAlignment.Center;
            btnComplete.TextOffset = new Point(0, 0);
            btnComplete.Click += (s, e) =>
            {
                if (activeService == null) return;
                string details = $"Mật độ/Hình ảnh: {txtDensity.Text}; Mô tả tổn thương: {txtLesion.Text}; Kết luận: {cboConclusion.Text}";
                string note = txtRemarks.Text.Trim();
                string res = string.IsNullOrWhiteSpace(note) ? details : details + ". Ghi chú: " + note;
                bool ok = KtvData.UpdateServiceResult(activeService.MaHsba, activeService.Service, activeService.NgayDv, res);
                if (ok)
                {
                    activeService.KetQua = res;
                    ShowToastNotification("✅ Đã lưu KETQUA vào HSBA_DV thành công!");
                    
                    // Reload danh sách
                    allServices = KtvData.Services();
                    RenderServiceCards();

                    var next = allServices.FirstOrDefault(x => x.Status != "Hoàn thành");
                    if (next != null)
                    {
                        activeService = next;
                    }
                    BuildSimpleResultForm(pnlFormContainer.Width);
                }
                else
                {
                    ShowToastNotification("❌ Không thể lưu kết quả! Vui lòng thử lại.");
                }
            };
            pnlFormContainer.Controls.Add(btnComplete);

            pnlToast.BringToFront();
        }

        private DataGridView CreateServiceRecordsGrid(int width)
        {
            var grid = new DataGridView
            {
                Width = width,
                Height = 176,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                EnableHeadersVisualStyles = false,
                GridColor = KtvTheme.Border,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ScrollBars = ScrollBars.Vertical
            };

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 253);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = KtvTheme.TextDark;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            grid.DefaultCellStyle.ForeColor = KtvTheme.TextDark;
            grid.DefaultCellStyle.SelectionBackColor = KtvTheme.TealLight;
            grid.DefaultCellStyle.SelectionForeColor = KtvTheme.TextDark;
            grid.DefaultCellStyle.Padding = new Padding(8, 0, 8, 0);
            grid.RowTemplate.Height = 34;
            grid.ColumnHeadersHeight = 34;

            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "HSBA", DataPropertyName = "MaHsba", FillWeight = 16 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bá»‡nh nhÃ¢n", DataPropertyName = "Patient", FillWeight = 28 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Dá»‹ch vá»¥", DataPropertyName = "Service", FillWeight = 32 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "NgÃ y DV", DataPropertyName = "NgayDv", FillWeight = 14 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tráº¡ng thÃ¡i", DataPropertyName = "Status", FillWeight = 16 });

            grid.DataSource = allServices.Select(x => new
            {
                x.MaHsba,
                x.Patient,
                x.Service,
                x.NgayDv,
                Status = (string.IsNullOrWhiteSpace(x.KetQua) || x.KetQua.Trim().StartsWith("Chua", StringComparison.OrdinalIgnoreCase) || x.KetQua.Trim().StartsWith("Chưa", StringComparison.OrdinalIgnoreCase)) ? "Chá»  cáº­p nháº­t" : "HoÃ n thÃ nh"
            }).ToList();

            int activeIndex = allServices.IndexOf(activeService);
            if (activeIndex >= 0 && activeIndex < grid.Rows.Count)
            {
                grid.Rows[activeIndex].Selected = true;
                grid.CurrentCell = grid.Rows[activeIndex].Cells[0];
            }

            grid.CellClick += (s, e) =>
            {
                if (e.RowIndex < 0 || e.RowIndex >= allServices.Count) return;
                activeService = allServices[e.RowIndex];
                BuildSimpleResultForm(pnlFormContainer.Width);
            };

            return grid;
        }

        private Label CreateTableLabel(string text, bool isHeader)
        {
            return new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 0, 8, 0),
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Segoe UI", isHeader ? 10F : 9.8F, isHeader ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = KtvTheme.TextDark,
                BackColor = isHeader ? Color.FromArgb(250, 252, 253) : Color.White
            };
        }

        private Guna2TextBox CreateSimpleInput(string text)
        {
            var input = new Guna2TextBox
            {
                Text = text,
                Anchor = AnchorStyles.Left,
                Size = new Size(230, 30),
                BorderRadius = 4,
                BorderColor = KtvTheme.Border,
                FillColor = Color.White,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = KtvTheme.TextDark,
                Margin = new Padding(12, 6, 0, 0)
            };

            return input;
        }

        private void LayoutDetailedResultForm(int w)
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

            // A. Patient Strip — dùng thông tin từ BENHNHAN (BnGender, BnDob, MaBn, CCCD)
            // Không còn dùng tên bệnh nhân để đoán giới tính
            string bnGender = activeService.BnGender ?? "Nam";
            string bnDob = activeService.BnDob ?? "";
            int bAge = 0;
            if (!string.IsNullOrEmpty(bnDob))
                bAge = KtvData.CalcAge(bnDob);
            string bAgeStr = bAge > 0 ? $"{bAge} tuổi" : bnDob;

            // Metadata: MãBN · Phái · Tuổi — từ BENHNHAN (không hiển thị tên Bác sĩ vì không join trong prototype)
            lblPatientMeta = KtvTheme.Label($"{activeService.MaBn} · {bnGender} · {bAgeStr} · HSBA: {activeService.MaHsba}", 90, 55, 9F, FontStyle.Regular, Color.FromArgb(200, 230, 222));
            lblPatientMeta.AutoSize = false;
            lblPatientMeta.Size = new Size(cardW - 120, 18);
            pnlPatientStrip.Controls.Add(lblPatientMeta);

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

            // lblSvcMeta: hiển thị NGAYDV (từ HSBA_DV) thay vì giờ hẹn mock
            lblSvcMeta = KtvTheme.Label($"Ngày DV: {activeService.NgayDv}", cardW - 230, 20, 8.5F, FontStyle.Regular, KtvTheme.TextLight);
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
                activeService.Service.Contains("máu") ? "Mẫu tĩnh mạch (EDTA)" : (activeService.Service.Contains("tiểu") ? "Nước tiểu (24h)" : "Không yêu cầu mẫu"),
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

            // txtRemarks: placeholder reflects KETQUA field (NVARCHAR2(200))
            txtRemarks = new Guna2TextBox
            {
                PlaceholderText = "Nhập kết quả dịch vụ — sẽ được lưu vào trường KETQUA trong HSBA_DV…",
                Location = new Point(22, 82),
                Size = new Size(cardW - 44, 78),
                Multiline = true,
                BorderRadius = 8,
                BorderColor = KtvTheme.Border,
                Font = new Font("Segoe UI", 9F),
                ForeColor = KtvTheme.TextDark
            };
            // Pre-fill from existing KETQUA if already recorded
            if (!string.IsNullOrEmpty(activeService.KetQua))
                txtRemarks.Text = activeService.KetQua;
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

            btnSaveDraft = KtvTheme.Button("Lưu", Color.White, KtvTheme.TextMid);
            btnSaveDraft.BorderColor = KtvTheme.Border;
            btnSaveDraft.BorderThickness = 1;
            btnSaveDraft.Size = new Size(112, 40);
            btnSaveDraft.TextAlign = HorizontalAlignment.Center;
            btnSaveDraft.TextOffset = new Point(0, 0);
            btnSaveDraft.Click += (s, e) =>
            {
                if (activeService == null) return;
                string currentResult = txtRemarks.Text.Trim();
                bool ok = KtvData.UpdateServiceResult(activeService.MaHsba, activeService.Service, activeService.NgayDv, currentResult);
                if (ok)
                {
                    activeService.KetQua = currentResult;
                    ShowToastNotification("💾 Đã lưu nháp KETQUA thành công!");
                    BuildQueueItems();
                }
                else
                {
                    ShowToastNotification("❌ Lưu nháp thất bại! Vui lòng thử lại.");
                }
            };
            cardActions.Controls.Add(btnSaveDraft);

            btnComplete = KtvTheme.Button("✅ Xác nhận & Hoàn thành", KtvTheme.Teal, Color.White);
            btnComplete.Size = new Size(280, 40);
            btnComplete.TextAlign = HorizontalAlignment.Center;
            btnComplete.TextOffset = new Point(0, 0);
            btnComplete.Click += (s, e) =>
            {
                if (activeService == null) return;
                string res = txtRemarks.Text.Trim().Length > 0
                    ? txtRemarks.Text.Trim()
                    : (activeService.Service + ": kết quả bình thường");
                bool ok = KtvData.UpdateServiceResult(activeService.MaHsba, activeService.Service, activeService.NgayDv, res);
                if (ok)
                {
                    activeService.KetQua = res;
                    ShowToastNotification("✅ Đã lưu KETQUA vào HSBA_DV thành công!");
                    BuildQueueItems();
                    var next = allServices.FirstOrDefault(x => x.Status != "Hoàn thành");
                    if (next != null) SelectPatient(next);
                    else SelectPatient(allServices.First());
                }
                else
                {
                    ShowToastNotification("❌ Không thể lưu kết quả! Vui lòng thử lại.");
                }
            };
            cardActions.Controls.Add(btnComplete);

            // Position buttons from right edge
            int btnRight = cardW - 20;
            btnComplete.Location = new Point(btnRight - btnComplete.Width, 16);
            btnSaveDraft.Location = new Point(btnComplete.Left - 10 - btnSaveDraft.Width, 16);

            pnlFormContainer.Controls.Add(cardActions);
        }

        private void EvaluateParamRow(Guna2TextBox txt, Guna2Panel pnl, Label lbl)
        {
            var param = (TestParam)txt.Tag;
            if (param == null) return;

            if (param.IsTextParam)
            {
                // Simple text comparison
                if (txt.Text.Trim().ToLower().Contains("báº¥t thÆ°á»ng") ||
                    txt.Text.Trim().ToLower().Contains("háº¹p") ||
                    txt.Text.Trim().ToLower().Contains("dÃ y") ||
                    txt.Text.Trim().ToLower().Contains("sá»i") ||
                    txt.Text.Trim().ToLower().Contains("loÃ£ng"))
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
                    lbl.Text = "â€”";
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
                ShowToastNotification($"ðŸ“Ž ÄÃ£ Ä‘Ã­nh kÃ¨m tá»‡p {selected} thÃ nh cÃ´ng!");
            }
        }

        private void RenderAttachmentsList()
        {
            if (flpUploadedFiles == null) return;
            flpUploadedFiles.Controls.Clear();

            // Default mock file if empty
            if (mockAttachedFiles.Count == 0 && activeService.Patient == "Tráº§n VÄƒn BÃ¬nh")
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
                    Text = $"ðŸ“„ {file}",
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    ForeColor = KtvTheme.Teal,
                    Location = new Point(10, 0),
                    Size = new Size(180, 32),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent
                };

                var btnDelete = new Guna2Button
                {
                    Text = "âœ•",
                    Size = new Size(20, 20),
                    Location = new Point(190, 6),
                    BorderRadius = 10,
                    FillColor = Color.Transparent,
                    ForeColor = KtvTheme.Teal,
                    Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnDelete.Click += (s, e) =>
                {
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
            if (pnlQueueItems == null || txtSearchQueue == null || lblQueueCount == null)
            {
                BindDesignerNativeForm();
                return;
            }

            pnlQueueItems.Controls.Clear();

            string searchKey = txtSearchQueue.Text.Trim().ToLowerInvariant();
            var filtered = allServices.Where(x =>
                string.IsNullOrEmpty(searchKey) ||
                x.Patient.ToLowerInvariant().Contains(searchKey) ||
                x.Service.ToLowerInvariant().Contains(searchKey)
            ).ToList();

            // Count waiting patients
            int waitCount = allServices.Count(x => x.Status != "HoÃ n thÃ nh");
            lblQueueCount.Text = $"{waitCount} chá»";

            // Update topbar badge
            if (lblTopbarBadge != null)
            {
                lblTopbarBadge.Text = $"â³ {waitCount} chá» cáº­p nháº­t";
                lblTopbarSub.Text = $"{waitCount} káº¿t quáº£ Ä‘ang chá» cáº­p nháº­t Â· HÃ´m nay {DateTime.Now:dd/MM/yyyy}";
            }

            foreach (var service in filtered)
            {
                bool isActive = (service == activeService);
                bool isDone = service.Status == "HoÃ n thÃ nh";

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

                // Status Badge â€” auto-width to prevent text crop
                string stText;
                Color stBg = KtvTheme.AccentSoft;
                Color stFg = Color.FromArgb(160, 112, 0);

                if (service.Status == "HoÃ n thÃ nh")
                {
                    stText = "âœ… HoÃ n thÃ nh";
                    stBg = KtvTheme.TealLight;
                    stFg = isDone ? Color.FromArgb(150, 165, 160) : KtvTheme.Teal;
                }
                else if (service.Status == "Äang thá»±c hiá»‡n")
                {
                    stText = "âš™ï¸ Äang thá»±c hiá»‡n";
                    stBg = KtvTheme.InfoSoft;
                    stFg = KtvTheme.Info;
                }
                else
                {
                    stText = "â³ Chá» cáº­p nháº­t";
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

            BindDesignerNativeForm();
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

            if (serviceName.Contains("mÃ¡u toÃ n pháº§n") || serviceName.Contains("CBC"))
            {
                list.Add(new TestParam { Name = "WBC (Báº¡ch cáº§u)", SubName = "White Blood Cells", MinVal = 4.0, MaxVal = 10.0, Unit = "Ã—10Â³/Î¼L", DefaultVal = 8.2 });
                list.Add(new TestParam { Name = "RBC (Há»“ng cáº§u)", SubName = "Red Blood Cells", MinVal = 4.2, MaxVal = 5.5, Unit = "Ã—10â¶/Î¼L", DefaultVal = 3.8 });
                list.Add(new TestParam { Name = "HGB (Hemoglobin)", SubName = "Huyáº¿t sáº¯c tá»‘", MinVal = 13.0, MaxVal = 17.0, Unit = "g/dL", DefaultVal = 11.5 });
                list.Add(new TestParam { Name = "HCT (Hematocrit)", SubName = "Thá»ƒ tÃ­ch khá»‘i há»“ng cáº§u", MinVal = 40.0, MaxVal = 52.0, Unit = "%", DefaultVal = 35.2 });
                list.Add(new TestParam { Name = "PLT (Tiá»ƒu cáº§u)", SubName = "Platelets", MinVal = 150.0, MaxVal = 400.0, Unit = "Ã—10Â³/Î¼L", DefaultVal = 220.0 });
                list.Add(new TestParam { Name = "MCV", SubName = "Thá»ƒ tÃ­ch trung bÃ¬nh há»“ng cáº§u", MinVal = 80.0, MaxVal = 100.0, Unit = "fL", DefaultVal = 75.4 });
                list.Add(new TestParam { Name = "Neutrophil", SubName = "Báº¡ch cáº§u trung tÃ­nh", MinVal = 50.0, MaxVal = 70.0, Unit = "%", DefaultVal = 65.0 });
            }
            else if (serviceName.Contains("Sinh hÃ³a mÃ¡u"))
            {
                list.Add(new TestParam { Name = "Glucose", SubName = "ÄÆ°á»ng huyáº¿t", MinVal = 3.9, MaxVal = 6.4, Unit = "mmol/L", DefaultVal = 7.2 });
                list.Add(new TestParam { Name = "Cholesterol toÃ n pháº§n", SubName = "Total Cholesterol", MinVal = 3.9, MaxVal = 5.2, Unit = "mmol/L", DefaultVal = 5.8 });
                list.Add(new TestParam { Name = "Triglycerides", SubName = "Cháº¥t bÃ©o trung tÃ­nh", MinVal = 0.46, MaxVal = 1.88, Unit = "mmol/L", DefaultVal = 1.50 });
                list.Add(new TestParam { Name = "AST (SGOT)", SubName = "Men gan AST", MinVal = 0.0, MaxVal = 37.0, Unit = "U/L", DefaultVal = 24.0 });
                list.Add(new TestParam { Name = "ALT (SGPT)", SubName = "Men gan ALT", MinVal = 0.0, MaxVal = 41.0, Unit = "U/L", DefaultVal = 28.0 });
            }
            else if (serviceName.Contains("nÆ°á»›c tiá»ƒu") || serviceName.Contains("Urinalysis"))
            {
                list.Add(new TestParam { Name = "pH nÆ°á»›c tiá»ƒu", SubName = "Urinary pH", MinVal = 5.0, MaxVal = 8.5, Unit = "pH", DefaultVal = 6.0 });
                list.Add(new TestParam { Name = "Glucose nÆ°á»›c tiá»ƒu", SubName = "U-Glucose", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "Ã‚m tÃ­nh (Negative)", IsTextParam = true });
                list.Add(new TestParam { Name = "Protein nÆ°á»›c tiá»ƒu", SubName = "U-Protein", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "Ã‚m tÃ­nh (Negative)", IsTextParam = true });
                list.Add(new TestParam { Name = "Ketone nÆ°á»›c tiá»ƒu", SubName = "U-Ketones", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "Ã‚m tÃ­nh (Negative)", IsTextParam = true });
            }
            else if (serviceName.Contains("Äiá»‡n tim") || serviceName.Contains("ECG"))
            {
                list.Add(new TestParam { Name = "Nhá»‹p tim (HR)", SubName = "Heart Rate", MinVal = 60.0, MaxVal = 100.0, Unit = "bpm", DefaultVal = 78.0 });
                list.Add(new TestParam { Name = "Nhá»‹p xoang", SubName = "Rhythm", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "Nhá»‹p xoang Ä‘á»u", IsTextParam = true });
                list.Add(new TestParam { Name = "Trá»¥c Ä‘iá»‡n tim", SubName = "Axis", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "Trá»¥c trung gian", IsTextParam = true });
            }
            else
            {
                // General/image-based defaults
                list.Add(new TestParam { Name = "Máº­t Ä‘á»™/HÃ¬nh áº£nh", SubName = "Density/Visuals", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "BÃ¬nh thÆ°á»ng á»•n Ä‘á»‹nh", IsTextParam = true });
                list.Add(new TestParam { Name = "MÃ´ táº£ tá»•n thÆ°Æ¡ng", SubName = "Lesions/Anomalies", MinVal = 0, MaxVal = 0, Unit = "â€”", DefaultText = "KhÃ´ng cÃ³ tá»•n thÆ°Æ¡ng khu trÃº phÃ¡t hiá»‡n", IsTextParam = true });
            }

            return list;
        }

        private string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "â€”";

            // Loáº¡i bá» khoáº£ng tráº¯ng thá»«a
            var parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length >= 2)
            {
                // Láº¥y chá»¯ cÃ¡i Ä‘áº§u cá»§a tá»« Ã¡p chÃ³t vÃ  tá»« cuá»‘i cÃ¹ng (VD: Nguyá»…n Thá»‹ Mai -> TM)
                return (parts[parts.Length - 2].Substring(0, 1) + parts[parts.Length - 1].Substring(0, 1)).ToUpper();
            }
            // Náº¿u chá»‰ cÃ³ 1 tÃªn
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

        private void lblSimpleTitle_Click(object sender, EventArgs e)
        {

        }
    }
}

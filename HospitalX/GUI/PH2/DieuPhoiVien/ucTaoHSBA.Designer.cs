namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class ucTaoHSBA
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // Main scroll container
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();

            // Steps indicator
            this.pnlSteps = new Guna.UI2.WinForms.Guna2Panel();

            // Step 1 — Patient search
            this.pnlStep1Card = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStep1Title = new System.Windows.Forms.Label();
            this.txtSearchBN = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearchBN = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPatientFound = new Guna.UI2.WinForms.Guna2Panel();
            this.picBNAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblBNName = new System.Windows.Forms.Label();
            this.lblBNMeta = new System.Windows.Forms.Label();
            this.btnChangeBN = new Guna.UI2.WinForms.Guna2Button();

            // Step 2 — HSBA info
            this.pnlStep2Card = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStep2Title = new System.Windows.Forms.Label();
            this.lblMaHSBA = new System.Windows.Forms.Label();
            this.txtMaHSBA = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgayMo = new System.Windows.Forms.Label();
            this.dtpNgayMo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblHinhThucDT = new System.Windows.Forms.Label();
            this.cboHinhThucDT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblLoaiBH = new System.Windows.Forms.Label();
            this.cboLoaiBH = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblChanDoan = new System.Windows.Forms.Label();
            this.txtChanDoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlIcdSection = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIcdTitle = new System.Windows.Forms.Label();
            this.pnlIcdContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddIcd = new Guna.UI2.WinForms.Guna2Button();

            // Step 3 — Doctor assignment
            this.pnlStep3Card = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStep3Title = new System.Windows.Forms.Label();
            this.lblKhoaDT = new System.Windows.Forms.Label();
            this.cboKhoaDT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPhongDT = new System.Windows.Forms.Label();
            this.cboPhongDT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblChonBS = new System.Windows.Forms.Label();
            this.pnlDoctorGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlNoteSection = new Guna.UI2.WinForms.Guna2Panel();
            this.lblGhiChuTitle = new System.Windows.Forms.Label();
            this.txtGhiChu = new Guna.UI2.WinForms.Guna2TextBox();

            // Actions footer
            this.pnlActionsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.btnSaveDraft = new Guna.UI2.WinForms.Guna2Button();
            this.btnCreateHSBA = new Guna.UI2.WinForms.Guna2Button();

            // Right side panels
            this.pnlSummaryCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSummaryHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSummaryHeaderText = new System.Windows.Forms.Label();
            this.pnlSummaryBody = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlPermCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPermHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPermHeaderText = new System.Windows.Forms.Label();
            this.pnlPermBody = new Guna.UI2.WinForms.Guna2Panel();

            this.pnlLoadCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlLoadHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLoadHeaderText = new System.Windows.Forms.Label();
            this.pnlLoadBody = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.ptbStep1Icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbStep2Icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbStep3Icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbNoteIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbSummaryHeaderIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbPermHeaderIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ptbLoadHeaderIcon = new Guna.UI2.WinForms.Guna2PictureBox();
 
            this.pnlScroll.SuspendLayout();
            this.pnlSteps.SuspendLayout();
            this.pnlStep1Card.SuspendLayout();
            this.pnlPatientFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBNAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep1Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep2Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep3Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNoteIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSummaryHeaderIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPermHeaderIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLoadHeaderIcon)).BeginInit();
            this.pnlStep2Card.SuspendLayout();
            this.pnlIcdSection.SuspendLayout();
            this.pnlStep3Card.SuspendLayout();
            this.pnlNoteSection.SuspendLayout();
            this.pnlActionsCard.SuspendLayout();
            this.pnlSummaryCard.SuspendLayout();
            this.pnlSummaryHeader.SuspendLayout();
            this.pnlPermCard.SuspendLayout();
            this.pnlPermHeader.SuspendLayout();
            this.pnlLoadCard.SuspendLayout();
            this.pnlLoadHeader.SuspendLayout();
            this.SuspendLayout();

            // Colors
            var teal = System.Drawing.Color.FromArgb(15, 110, 86);
            var bgColor = System.Drawing.Color.FromArgb(244, 247, 246);
            var cardBorder = System.Drawing.Color.FromArgb(218, 232, 226);
            var labelColor = System.Drawing.Color.FromArgb(122, 149, 137);
            var inputFore = System.Drawing.Color.FromArgb(24, 48, 42);
            var inputBg = System.Drawing.Color.FromArgb(247, 249, 248);
            var tealLight = System.Drawing.Color.FromArgb(230, 243, 239);

            // =============================================
            // pnlScroll
            // =============================================
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMargin = new System.Drawing.Size(0, 40);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = bgColor;
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1370, 850);
            this.pnlScroll.TabIndex = 0;
            this.pnlScroll.Controls.Add(this.pnlSteps);
            this.pnlScroll.Controls.Add(this.pnlStep1Card);
            this.pnlScroll.Controls.Add(this.pnlStep2Card);
            this.pnlScroll.Controls.Add(this.pnlStep3Card);
            this.pnlScroll.Controls.Add(this.pnlActionsCard);
            this.pnlScroll.Controls.Add(this.pnlSummaryCard);
            this.pnlScroll.Controls.Add(this.pnlPermCard);
            this.pnlScroll.Controls.Add(this.pnlLoadCard);

            // =============================================
            // pnlSteps — Steps indicator bar
            // =============================================
            this.pnlSteps.BorderColor = cardBorder;
            this.pnlSteps.BorderRadius = 12;
            this.pnlSteps.BorderThickness = 1;
            this.pnlSteps.FillColor = System.Drawing.Color.White;
            this.pnlSteps.Location = new System.Drawing.Point(20, 15);
            this.pnlSteps.Name = "pnlSteps";
            this.pnlSteps.Size = new System.Drawing.Size(1330, 60);
            this.pnlSteps.TabIndex = 0;
            this.pnlSteps.BackColor = System.Drawing.Color.Transparent;

            // =============================================
            // pnlStep1Card — Bước 1: Chọn bệnh nhân
            // =============================================
            this.pnlStep1Card.BorderColor = cardBorder;
            this.pnlStep1Card.BorderRadius = 12;
            this.pnlStep1Card.BorderThickness = 1;
            this.pnlStep1Card.FillColor = System.Drawing.Color.White;
            this.pnlStep1Card.Location = new System.Drawing.Point(20, 91);
            this.pnlStep1Card.Name = "pnlStep1Card";
            this.pnlStep1Card.Size = new System.Drawing.Size(940, 180);
            this.pnlStep1Card.TabIndex = 1;
            this.pnlStep1Card.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep1Card.Controls.Add(this.ptbStep1Icon);
            this.pnlStep1Card.Controls.Add(this.lblStep1Title);
            this.pnlStep1Card.Controls.Add(this.txtSearchBN);
            this.pnlStep1Card.Controls.Add(this.btnSearchBN);
            this.pnlStep1Card.Controls.Add(this.pnlPatientFound);
 
            // ptbStep1Icon
            this.ptbStep1Icon.BackColor = System.Drawing.Color.Transparent;
            this.ptbStep1Icon.FillColor = System.Drawing.Color.Transparent;
            this.ptbStep1Icon.Location = new System.Drawing.Point(20, 14);
            this.ptbStep1Icon.Name = "ptbStep1Icon";
            this.ptbStep1Icon.Size = new System.Drawing.Size(24, 24);
            this.ptbStep1Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbStep1Icon.TabIndex = 100;
            this.ptbStep1Icon.TabStop = false;

            // lblStep1Title
            this.lblStep1Title.AutoSize = true;
            this.lblStep1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep1Title.ForeColor = teal;
            this.lblStep1Title.Location = new System.Drawing.Point(54, 16);
            this.lblStep1Title.Text = "BƯỚC 1 — CHỌN BỆNH NHÂN";
            this.lblStep1Title.BackColor = System.Drawing.Color.Transparent;
 
            // txtSearchBN
            this.txtSearchBN.BorderRadius = 8;
            this.txtSearchBN.BorderColor = cardBorder;
            this.txtSearchBN.BorderThickness = 1;
            this.txtSearchBN.FillColor = inputBg;
            this.txtSearchBN.ForeColor = inputFore;
            this.txtSearchBN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.txtSearchBN.Location = new System.Drawing.Point(20, 52);
            this.txtSearchBN.Name = "txtSearchBN";
            this.txtSearchBN.Size = new System.Drawing.Size(710, 38);
            this.txtSearchBN.TabIndex = 0;
            this.txtSearchBN.PlaceholderText = "Tìm theo mã BN, họ tên, CCCD…";
            this.txtSearchBN.PlaceholderForeColor = System.Drawing.Color.FromArgb(180, 195, 188);
            this.txtSearchBN.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchBN.AutoSize = false;
            this.txtSearchBN.TextOffset = new System.Drawing.Point(8, 0);
            this.txtSearchBN.HoverState.BorderColor = teal;
            this.txtSearchBN.FocusedState.BorderColor = teal;
 
            // btnSearchBN
            this.btnSearchBN.BorderRadius = 8;
            this.btnSearchBN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchBN.FillColor = teal;
            this.btnSearchBN.ForeColor = System.Drawing.Color.White;
            this.btnSearchBN.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearchBN.Location = new System.Drawing.Point(740, 52);
            this.btnSearchBN.Name = "btnSearchBN";
            this.btnSearchBN.Size = new System.Drawing.Size(176, 38);
            this.btnSearchBN.TabIndex = 1;
            this.btnSearchBN.Text = "Tìm kiếm";
            this.btnSearchBN.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchBN.HoverState.FillColor = System.Drawing.Color.FromArgb(10, 82, 64);
 
            // pnlPatientFound
            this.pnlPatientFound.BorderColor = teal;
            this.pnlPatientFound.BorderRadius = 10;
            this.pnlPatientFound.BorderThickness = 2;
            this.pnlPatientFound.FillColor = tealLight;
            this.pnlPatientFound.Location = new System.Drawing.Point(20, 108);
            this.pnlPatientFound.Name = "pnlPatientFound";
            this.pnlPatientFound.Size = new System.Drawing.Size(896, 56);
            this.pnlPatientFound.TabIndex = 2;
            this.pnlPatientFound.BackColor = System.Drawing.Color.Transparent;
            this.pnlPatientFound.Visible = false;
            this.pnlPatientFound.Controls.Add(this.picBNAvatar);
            this.pnlPatientFound.Controls.Add(this.lblBNName);
            this.pnlPatientFound.Controls.Add(this.lblBNMeta);
            this.pnlPatientFound.Controls.Add(this.btnChangeBN);
 
            // picBNAvatar
            this.picBNAvatar.Location = new System.Drawing.Point(12, 10);
            this.picBNAvatar.Name = "picBNAvatar";
            this.picBNAvatar.Size = new System.Drawing.Size(36, 36);
            this.picBNAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBNAvatar.TabIndex = 0;
            this.picBNAvatar.BackColor = System.Drawing.Color.Transparent;
 
            // lblBNName
            this.lblBNName.AutoSize = true;
            this.lblBNName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBNName.ForeColor = teal;
            this.lblBNName.Location = new System.Drawing.Point(58, 8);
            this.lblBNName.Text = "Nguyễn Văn An";
            this.lblBNName.BackColor = System.Drawing.Color.Transparent;
 
            // lblBNMeta
            this.lblBNMeta.AutoSize = true;
            this.lblBNMeta.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblBNMeta.ForeColor = System.Drawing.Color.FromArgb(74, 98, 89);
            this.lblBNMeta.Location = new System.Drawing.Point(58, 32);
            this.lblBNMeta.Text = "BN240001 · Nam · 15/03/1978 · Tim mạch";
            this.lblBNMeta.BackColor = System.Drawing.Color.Transparent;
 
            // btnChangeBN
            this.btnChangeBN.BorderRadius = 8;
            this.btnChangeBN.BorderThickness = 2;
            this.btnChangeBN.BorderColor = teal;
            this.btnChangeBN.FillColor = System.Drawing.Color.Transparent;
            this.btnChangeBN.ForeColor = teal;
            this.btnChangeBN.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnChangeBN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeBN.Location = new System.Drawing.Point(788, 11);
            this.btnChangeBN.Name = "btnChangeBN";
            this.btnChangeBN.Size = new System.Drawing.Size(96, 34);
            this.btnChangeBN.TabIndex = 3;
            this.btnChangeBN.Text = "Đổi BN";
            this.btnChangeBN.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeBN.HoverState.FillColor = tealLight;

            // =============================================
            // pnlStep2Card — Bước 2: Thông tin HSBA
            // =============================================
            this.pnlStep2Card.BorderColor = cardBorder;
            this.pnlStep2Card.BorderRadius = 12;
            this.pnlStep2Card.BorderThickness = 1;
            this.pnlStep2Card.FillColor = System.Drawing.Color.White;
            this.pnlStep2Card.Location = new System.Drawing.Point(20, 287);
            this.pnlStep2Card.Name = "pnlStep2Card";
            this.pnlStep2Card.Size = new System.Drawing.Size(940, 460);
            this.pnlStep2Card.TabIndex = 2;
            this.pnlStep2Card.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep2Card.Controls.Add(this.ptbStep2Icon);
            this.pnlStep2Card.Controls.Add(this.lblStep2Title);
            this.pnlStep2Card.Controls.Add(this.lblMaHSBA);
            this.pnlStep2Card.Controls.Add(this.txtMaHSBA);
            this.pnlStep2Card.Controls.Add(this.lblNgayMo);
            this.pnlStep2Card.Controls.Add(this.dtpNgayMo);
            this.pnlStep2Card.Controls.Add(this.lblHinhThucDT);
            this.pnlStep2Card.Controls.Add(this.cboHinhThucDT);
            this.pnlStep2Card.Controls.Add(this.lblLoaiBH);
            this.pnlStep2Card.Controls.Add(this.cboLoaiBH);
            this.pnlStep2Card.Controls.Add(this.lblChanDoan);
            this.pnlStep2Card.Controls.Add(this.txtChanDoan);
            this.pnlStep2Card.Controls.Add(this.pnlIcdSection);
 
            // ptbStep2Icon
            this.ptbStep2Icon.BackColor = System.Drawing.Color.Transparent;
            this.ptbStep2Icon.FillColor = System.Drawing.Color.Transparent;
            this.ptbStep2Icon.Location = new System.Drawing.Point(20, 14);
            this.ptbStep2Icon.Name = "ptbStep2Icon";
            this.ptbStep2Icon.Size = new System.Drawing.Size(24, 24);
            this.ptbStep2Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbStep2Icon.TabIndex = 101;
            this.ptbStep2Icon.TabStop = false;
 
            // lblStep2Title
            this.lblStep2Title.AutoSize = true;
            this.lblStep2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep2Title.ForeColor = teal;
            this.lblStep2Title.Location = new System.Drawing.Point(54, 16);
            this.lblStep2Title.Text = "BƯỚC 2 — THÔNG TIN HỒ SƠ BỆNH ÁN";
            this.lblStep2Title.BackColor = System.Drawing.Color.Transparent;
 
            int col1X = 20;
            int col2X = 470;
            int fieldW = 430;
 
            // lblMaHSBA
            this.lblMaHSBA.AutoSize = true;
            this.lblMaHSBA.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHSBA.ForeColor = labelColor;
            this.lblMaHSBA.Location = new System.Drawing.Point(col1X, 56);
            this.lblMaHSBA.Text = "MÃ HSBA (TỰ ĐỘNG)";
            this.lblMaHSBA.BackColor = System.Drawing.Color.Transparent;
 
            // txtMaHSBA
            this.txtMaHSBA.BorderRadius = 8;
            this.txtMaHSBA.BorderColor = cardBorder;
            this.txtMaHSBA.BorderThickness = 1;
            this.txtMaHSBA.FillColor = System.Drawing.Color.FromArgb(240, 245, 243);
            this.txtMaHSBA.ForeColor = teal;
            this.txtMaHSBA.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtMaHSBA.Location = new System.Drawing.Point(col1X, 80);
            this.txtMaHSBA.Name = "txtMaHSBA";
            this.txtMaHSBA.Size = new System.Drawing.Size(fieldW, 38);
            this.txtMaHSBA.Text = "HSBA-2026-0157";
            this.txtMaHSBA.ReadOnly = true;
            this.txtMaHSBA.BackColor = System.Drawing.Color.Transparent;
            this.txtMaHSBA.AutoSize = false;
            this.txtMaHSBA.TextOffset = new System.Drawing.Point(8, 0);
 
            // lblNgayMo
            this.lblNgayMo.AutoSize = true;
            this.lblNgayMo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayMo.ForeColor = labelColor;
            this.lblNgayMo.Location = new System.Drawing.Point(col2X, 56);
            this.lblNgayMo.Text = "NGÀY MỞ HỒ SƠ *";
            this.lblNgayMo.BackColor = System.Drawing.Color.Transparent;
 
            // dtpNgayMo
            this.dtpNgayMo.BorderRadius = 8;
            this.dtpNgayMo.BorderColor = cardBorder;
            this.dtpNgayMo.BorderThickness = 1;
            this.dtpNgayMo.FillColor = inputBg;
            this.dtpNgayMo.ForeColor = inputFore;
            this.dtpNgayMo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpNgayMo.Location = new System.Drawing.Point(col2X, 80);
            this.dtpNgayMo.Name = "dtpNgayMo";
            this.dtpNgayMo.Size = new System.Drawing.Size(fieldW, 38);
            this.dtpNgayMo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayMo.BackColor = System.Drawing.Color.Transparent;
            this.dtpNgayMo.TextOffset = new System.Drawing.Point(8, 0);
            this.dtpNgayMo.HoverState.BorderColor = teal;
 
            // lblHinhThucDT
            this.lblHinhThucDT.AutoSize = true;
            this.lblHinhThucDT.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblHinhThucDT.ForeColor = labelColor;
            this.lblHinhThucDT.Location = new System.Drawing.Point(col1X, 138);
            this.lblHinhThucDT.Text = "HÌNH THỨC ĐIỀU TRỊ *";
            this.lblHinhThucDT.BackColor = System.Drawing.Color.Transparent;
 
            // cboHinhThucDT
            this.cboHinhThucDT.BorderRadius = 8;
            this.cboHinhThucDT.BorderColor = cardBorder;
            this.cboHinhThucDT.BorderThickness = 1;
            this.cboHinhThucDT.FillColor = inputBg;
            this.cboHinhThucDT.ForeColor = inputFore;
            this.cboHinhThucDT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboHinhThucDT.Location = new System.Drawing.Point(col1X, 162);
            this.cboHinhThucDT.Name = "cboHinhThucDT";
            this.cboHinhThucDT.Size = new System.Drawing.Size(fieldW, 38);
            this.cboHinhThucDT.BackColor = System.Drawing.Color.Transparent;
            this.cboHinhThucDT.HoverState.BorderColor = teal;
            this.cboHinhThucDT.FocusedState.BorderColor = teal;
            this.cboHinhThucDT.ItemHeight = 32;
            this.cboHinhThucDT.TextOffset = new System.Drawing.Point(8, 0);
 
            // lblLoaiBH
            this.lblLoaiBH.AutoSize = true;
            this.lblLoaiBH.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblLoaiBH.ForeColor = labelColor;
            this.lblLoaiBH.Location = new System.Drawing.Point(col2X, 138);
            this.lblLoaiBH.Text = "LOẠI BẢO HIỂM";
            this.lblLoaiBH.BackColor = System.Drawing.Color.Transparent;
 
            // cboLoaiBH
            this.cboLoaiBH.BorderRadius = 8;
            this.cboLoaiBH.BorderColor = cardBorder;
            this.cboLoaiBH.BorderThickness = 1;
            this.cboLoaiBH.FillColor = inputBg;
            this.cboLoaiBH.ForeColor = inputFore;
            this.cboLoaiBH.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboLoaiBH.Location = new System.Drawing.Point(col2X, 162);
            this.cboLoaiBH.Name = "cboLoaiBH";
            this.cboLoaiBH.Size = new System.Drawing.Size(fieldW, 38);
            this.cboLoaiBH.BackColor = System.Drawing.Color.Transparent;
            this.cboLoaiBH.HoverState.BorderColor = teal;
            this.cboLoaiBH.FocusedState.BorderColor = teal;
            this.cboLoaiBH.ItemHeight = 32;
            this.cboLoaiBH.TextOffset = new System.Drawing.Point(8, 0);
 
            // lblChanDoan
            this.lblChanDoan.AutoSize = true;
            this.lblChanDoan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChanDoan.ForeColor = labelColor;
            this.lblChanDoan.Location = new System.Drawing.Point(col1X, 220);
            this.lblChanDoan.Text = "CHẨN ĐOÁN SƠ BỘ *";
            this.lblChanDoan.BackColor = System.Drawing.Color.Transparent;
 
            // txtChanDoan
            this.txtChanDoan.BorderRadius = 8;
            this.txtChanDoan.BorderColor = cardBorder;
            this.txtChanDoan.BorderThickness = 1;
            this.txtChanDoan.FillColor = inputBg;
            this.txtChanDoan.ForeColor = inputFore;
            this.txtChanDoan.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.txtChanDoan.Location = new System.Drawing.Point(col1X, 244);
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.Size = new System.Drawing.Size(880, 68);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.PlaceholderText = "Nhập chẩn đoán ban đầu của điều dưỡng / điều phối viên…";
            this.txtChanDoan.PlaceholderForeColor = System.Drawing.Color.FromArgb(180, 195, 188);
            this.txtChanDoan.BackColor = System.Drawing.Color.Transparent;
            this.txtChanDoan.AutoSize = false;
            this.txtChanDoan.TextOffset = new System.Drawing.Point(8, 0);
            this.txtChanDoan.HoverState.BorderColor = teal;
            this.txtChanDoan.FocusedState.BorderColor = teal;
 
            // pnlIcdSection — Container for ICD title + rows + add button
            this.pnlIcdSection.BorderColor = System.Drawing.Color.Transparent;
            this.pnlIcdSection.BorderThickness = 0;
            this.pnlIcdSection.FillColor = System.Drawing.Color.White;
            this.pnlIcdSection.Location = new System.Drawing.Point(0, 328);
            this.pnlIcdSection.Name = "pnlIcdSection";
            this.pnlIcdSection.Size = new System.Drawing.Size(940, 130);
            this.pnlIcdSection.BackColor = System.Drawing.Color.Transparent;
            this.pnlIcdSection.Controls.Add(this.lblIcdTitle);
            this.pnlIcdSection.Controls.Add(this.pnlIcdContainer);
            this.pnlIcdSection.Controls.Add(this.btnAddIcd);
 
            // Divider line above ICD
            var icdDivider = new System.Windows.Forms.Panel();
            icdDivider.BackColor = cardBorder;
            icdDivider.Location = new System.Drawing.Point(20, 0);
            icdDivider.Size = new System.Drawing.Size(900, 1);
            this.pnlIcdSection.Controls.Add(icdDivider);
 
            // lblIcdTitle
            this.lblIcdTitle.AutoSize = true;
            this.lblIcdTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblIcdTitle.ForeColor = teal;
            this.lblIcdTitle.Location = new System.Drawing.Point(20, 12);
            this.lblIcdTitle.Text = "🏷   MÃ ICD-10 (CHẨN ĐOÁN SƠ BỘ)";
            this.lblIcdTitle.BackColor = System.Drawing.Color.Transparent;
 
            // pnlIcdContainer
            this.pnlIcdContainer.BorderThickness = 0;
            this.pnlIcdContainer.FillColor = System.Drawing.Color.White;
            this.pnlIcdContainer.Location = new System.Drawing.Point(20, 42);
            this.pnlIcdContainer.Name = "pnlIcdContainer";
            this.pnlIcdContainer.Size = new System.Drawing.Size(900, 36);
            this.pnlIcdContainer.BackColor = System.Drawing.Color.Transparent;
 
            // btnAddIcd
            this.btnAddIcd.BorderRadius = 8;
            this.btnAddIcd.BorderThickness = 2;
            this.btnAddIcd.BorderColor = teal;
            this.btnAddIcd.FillColor = tealLight;
            this.btnAddIcd.ForeColor = teal;
            this.btnAddIcd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddIcd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIcd.Location = new System.Drawing.Point(20, 86);
            this.btnAddIcd.Name = "btnAddIcd";
            this.btnAddIcd.Size = new System.Drawing.Size(900, 30);
            this.btnAddIcd.TabIndex = 5;
            this.btnAddIcd.Text = "+   Thêm mã ICD-10";
            this.btnAddIcd.BackColor = System.Drawing.Color.Transparent;
            this.btnAddIcd.HoverState.FillColor = teal;
            this.btnAddIcd.HoverState.ForeColor = System.Drawing.Color.White;
 
            // =============================================
            // pnlStep3Card — Bước 3: Chỉ định bác sĩ
            // =============================================
            this.pnlStep3Card.BorderColor = cardBorder;
            this.pnlStep3Card.BorderRadius = 12;
            this.pnlStep3Card.BorderThickness = 1;
            this.pnlStep3Card.FillColor = System.Drawing.Color.White;
            this.pnlStep3Card.Location = new System.Drawing.Point(20, 763);
            this.pnlStep3Card.Name = "pnlStep3Card";
            this.pnlStep3Card.Size = new System.Drawing.Size(940, 542);
            this.pnlStep3Card.TabIndex = 3;
            this.pnlStep3Card.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep3Card.Controls.Add(this.ptbStep3Icon);
            this.pnlStep3Card.Controls.Add(this.lblStep3Title);
            this.pnlStep3Card.Controls.Add(this.lblKhoaDT);
            this.pnlStep3Card.Controls.Add(this.cboKhoaDT);
            this.pnlStep3Card.Controls.Add(this.lblPhongDT);
            this.pnlStep3Card.Controls.Add(this.cboPhongDT);
            this.pnlStep3Card.Controls.Add(this.lblChonBS);
            this.pnlStep3Card.Controls.Add(this.pnlDoctorGrid);
            this.pnlStep3Card.Controls.Add(this.pnlNoteSection);
 
            // ptbStep3Icon
            this.ptbStep3Icon.BackColor = System.Drawing.Color.Transparent;
            this.ptbStep3Icon.FillColor = System.Drawing.Color.Transparent;
            this.ptbStep3Icon.Location = new System.Drawing.Point(20, 14);
            this.ptbStep3Icon.Name = "ptbStep3Icon";
            this.ptbStep3Icon.Size = new System.Drawing.Size(24, 24);
            this.ptbStep3Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbStep3Icon.TabIndex = 102;
            this.ptbStep3Icon.TabStop = false;
 
            // lblStep3Title
            this.lblStep3Title.AutoSize = true;
            this.lblStep3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep3Title.ForeColor = teal;
            this.lblStep3Title.Location = new System.Drawing.Point(54, 16);
            this.lblStep3Title.Text = "BƯỚC 3 — CHỈ ĐỊNH BÁC SĨ PHỤ TRÁCH";
            this.lblStep3Title.BackColor = System.Drawing.Color.Transparent;
 
            // lblKhoaDT
            this.lblKhoaDT.AutoSize = true;
            this.lblKhoaDT.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblKhoaDT.ForeColor = labelColor;
            this.lblKhoaDT.Location = new System.Drawing.Point(col1X, 56);
            this.lblKhoaDT.Text = "KHOA ĐIỀU TRỊ *";
            this.lblKhoaDT.BackColor = System.Drawing.Color.Transparent;
 
            // cboKhoaDT
            this.cboKhoaDT.BorderRadius = 8;
            this.cboKhoaDT.BorderColor = cardBorder;
            this.cboKhoaDT.BorderThickness = 1;
            this.cboKhoaDT.FillColor = inputBg;
            this.cboKhoaDT.ForeColor = inputFore;
            this.cboKhoaDT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboKhoaDT.Location = new System.Drawing.Point(col1X, 80);
            this.cboKhoaDT.Name = "cboKhoaDT";
            this.cboKhoaDT.Size = new System.Drawing.Size(fieldW, 38);
            this.cboKhoaDT.BackColor = System.Drawing.Color.Transparent;
            this.cboKhoaDT.HoverState.BorderColor = teal;
            this.cboKhoaDT.FocusedState.BorderColor = teal;
            this.cboKhoaDT.ItemHeight = 32;
            this.cboKhoaDT.TextOffset = new System.Drawing.Point(8, 0);
 
            // lblPhongDT
            this.lblPhongDT.AutoSize = true;
            this.lblPhongDT.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhongDT.ForeColor = labelColor;
            this.lblPhongDT.Location = new System.Drawing.Point(col2X, 56);
            this.lblPhongDT.Text = "PHÒNG ĐIỀU TRỊ";
            this.lblPhongDT.BackColor = System.Drawing.Color.Transparent;
 
            // cboPhongDT
            this.cboPhongDT.BorderRadius = 8;
            this.cboPhongDT.BorderColor = cardBorder;
            this.cboPhongDT.BorderThickness = 1;
            this.cboPhongDT.FillColor = inputBg;
            this.cboPhongDT.ForeColor = inputFore;
            this.cboPhongDT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboPhongDT.Location = new System.Drawing.Point(col2X, 80);
            this.cboPhongDT.Name = "cboPhongDT";
            this.cboPhongDT.Size = new System.Drawing.Size(fieldW, 38);
            this.cboPhongDT.BackColor = System.Drawing.Color.Transparent;
            this.cboPhongDT.HoverState.BorderColor = teal;
            this.cboPhongDT.FocusedState.BorderColor = teal;
            this.cboPhongDT.ItemHeight = 32;
            this.cboPhongDT.TextOffset = new System.Drawing.Point(8, 0);
 
            // lblChonBS
            this.lblChonBS.AutoSize = true;
            this.lblChonBS.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChonBS.ForeColor = labelColor;
            this.lblChonBS.Location = new System.Drawing.Point(col1X, 138);
            this.lblChonBS.Text = "CHỌN BÁC SĨ PHỤ TRÁCH *";
            this.lblChonBS.BackColor = System.Drawing.Color.Transparent;
 
            // pnlDoctorGrid — 2x2 grid for doctor cards (populated in code)
            this.pnlDoctorGrid.BorderThickness = 0;
            this.pnlDoctorGrid.FillColor = System.Drawing.Color.White;
            this.pnlDoctorGrid.Location = new System.Drawing.Point(col1X, 162);
            this.pnlDoctorGrid.Name = "pnlDoctorGrid";
            this.pnlDoctorGrid.Size = new System.Drawing.Size(900, 250);
            this.pnlDoctorGrid.BackColor = System.Drawing.Color.Transparent;
 
            // pnlNoteSection — Notes area
            this.pnlNoteSection.BorderThickness = 0;
            this.pnlNoteSection.FillColor = System.Drawing.Color.White;
            this.pnlNoteSection.Location = new System.Drawing.Point(0, 432);
            this.pnlNoteSection.Name = "pnlNoteSection";
            this.pnlNoteSection.Size = new System.Drawing.Size(940, 110);
            this.pnlNoteSection.BackColor = System.Drawing.Color.Transparent;
            this.pnlNoteSection.Controls.Add(this.ptbNoteIcon);
            this.pnlNoteSection.Controls.Add(this.lblGhiChuTitle);
            this.pnlNoteSection.Controls.Add(this.txtGhiChu);
 
            // ptbNoteIcon
            this.ptbNoteIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbNoteIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbNoteIcon.Location = new System.Drawing.Point(20, 8);
            this.ptbNoteIcon.Name = "ptbNoteIcon";
            this.ptbNoteIcon.Size = new System.Drawing.Size(24, 24);
            this.ptbNoteIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbNoteIcon.TabIndex = 103;
            this.ptbNoteIcon.TabStop = false;
 
            // Divider above notes
            var noteDivider = new System.Windows.Forms.Panel();
            noteDivider.BackColor = cardBorder;
            noteDivider.Location = new System.Drawing.Point(20, 0);
            noteDivider.Size = new System.Drawing.Size(900, 1);
            this.pnlNoteSection.Controls.Add(noteDivider);
 
            // lblGhiChuTitle
            this.lblGhiChuTitle.AutoSize = true;
            this.lblGhiChuTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGhiChuTitle.ForeColor = teal;
            this.lblGhiChuTitle.Location = new System.Drawing.Point(54, 10);
            this.lblGhiChuTitle.Text = "GHI CHÚ ĐIỀU PHỐI";
            this.lblGhiChuTitle.BackColor = System.Drawing.Color.Transparent;
 
            // txtGhiChu
            this.txtGhiChu.BorderRadius = 8;
            this.txtGhiChu.BorderColor = cardBorder;
            this.txtGhiChu.BorderThickness = 1;
            this.txtGhiChu.FillColor = inputBg;
            this.txtGhiChu.ForeColor = inputFore;
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular);
            this.txtGhiChu.Location = new System.Drawing.Point(20, 38);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(900, 60);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.PlaceholderText = "Ghi chú nội bộ cho bác sĩ / điều dưỡng…";
            this.txtGhiChu.PlaceholderForeColor = System.Drawing.Color.FromArgb(180, 195, 188);
            this.txtGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.txtGhiChu.AutoSize = false;
            this.txtGhiChu.TextOffset = new System.Drawing.Point(8, 0);
            this.txtGhiChu.HoverState.BorderColor = teal;
            this.txtGhiChu.FocusedState.BorderColor = teal;
 
            // =============================================
            // pnlActionsCard — Actions footer (bo tròn nền trắng)
            // =============================================
            this.pnlActionsCard.BorderColor = cardBorder;
            this.pnlActionsCard.BorderRadius = 12;
            this.pnlActionsCard.BorderThickness = 1;
            this.pnlActionsCard.FillColor = System.Drawing.Color.White;
            this.pnlActionsCard.Location = new System.Drawing.Point(20, 1321);
            this.pnlActionsCard.Name = "pnlActionsCard";
            this.pnlActionsCard.Size = new System.Drawing.Size(940, 64);
            this.pnlActionsCard.TabIndex = 4;
            this.pnlActionsCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlActionsCard.Controls.Add(this.lblDisclaimer);
            this.pnlActionsCard.Controls.Add(this.btnSaveDraft);
            this.pnlActionsCard.Controls.Add(this.btnCreateHSBA);
 
            // lblDisclaimer
            this.lblDisclaimer.AutoSize = true;
            this.lblDisclaimer.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDisclaimer.ForeColor = labelColor;
            this.lblDisclaimer.Location = new System.Drawing.Point(20, 24);
            this.lblDisclaimer.Text = "Điều phối viên có trách nhiệm xác nhận thông tin trước khi lưu.";
            this.lblDisclaimer.BackColor = System.Drawing.Color.Transparent;
 
            // btnSaveDraft
            this.btnSaveDraft.BorderRadius = 8;
            this.btnSaveDraft.BorderThickness = 1;
            this.btnSaveDraft.BorderColor = cardBorder;
            this.btnSaveDraft.FillColor = System.Drawing.Color.Transparent;
            this.btnSaveDraft.ForeColor = System.Drawing.Color.FromArgb(74, 98, 89);
            this.btnSaveDraft.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveDraft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDraft.Location = new System.Drawing.Point(540, 12);
            this.btnSaveDraft.Name = "btnSaveDraft";
            this.btnSaveDraft.Size = new System.Drawing.Size(150, 40);
            this.btnSaveDraft.TabIndex = 0;
            this.btnSaveDraft.Text = "Lưu nháp";
            this.btnSaveDraft.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveDraft.HoverState.FillColor = tealLight;
            this.btnSaveDraft.HoverState.ForeColor = teal;
            this.btnSaveDraft.HoverState.BorderColor = teal;
 
            // btnCreateHSBA
            this.btnCreateHSBA.BorderRadius = 8;
            this.btnCreateHSBA.FillColor = teal;
            this.btnCreateHSBA.ForeColor = System.Drawing.Color.White;
            this.btnCreateHSBA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateHSBA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateHSBA.Location = new System.Drawing.Point(705, 12);
            this.btnCreateHSBA.Name = "btnCreateHSBA";
            this.btnCreateHSBA.Size = new System.Drawing.Size(210, 40);
            this.btnCreateHSBA.TabIndex = 1;
            this.btnCreateHSBA.Text = "Tạo hồ sơ bệnh án";
            this.btnCreateHSBA.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateHSBA.HoverState.FillColor = System.Drawing.Color.FromArgb(10, 82, 64);
 
            // =============================================
            // pnlSummaryCard — Right: Tóm tắt hồ sơ
            // =============================================
            this.pnlSummaryCard.BorderColor = cardBorder;
            this.pnlSummaryCard.BorderRadius = 12;
            this.pnlSummaryCard.BorderThickness = 1;
            this.pnlSummaryCard.FillColor = System.Drawing.Color.White;
            this.pnlSummaryCard.Location = new System.Drawing.Point(970, 91);
            this.pnlSummaryCard.Name = "pnlSummaryCard";
            this.pnlSummaryCard.Size = new System.Drawing.Size(380, 420);
            this.pnlSummaryCard.TabIndex = 5;
            this.pnlSummaryCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummaryCard.Controls.Add(this.pnlSummaryHeader);
            this.pnlSummaryCard.Controls.Add(this.pnlSummaryBody);
 
            // pnlSummaryHeader
            this.pnlSummaryHeader.BorderRadius = 12;
            this.pnlSummaryHeader.CustomizableEdges.BottomLeft = false;
            this.pnlSummaryHeader.CustomizableEdges.BottomRight = false;
            this.pnlSummaryHeader.BorderThickness = 0;
            this.pnlSummaryHeader.FillColor = teal;
            this.pnlSummaryHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSummaryHeader.Name = "pnlSummaryHeader";
            this.pnlSummaryHeader.Size = new System.Drawing.Size(380, 40);
            this.pnlSummaryHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummaryHeader.Controls.Add(this.ptbSummaryHeaderIcon);
            this.pnlSummaryHeader.Controls.Add(this.lblSummaryHeaderText);
 
            // ptbSummaryHeaderIcon
            this.ptbSummaryHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbSummaryHeaderIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbSummaryHeaderIcon.Location = new System.Drawing.Point(14, 11);
            this.ptbSummaryHeaderIcon.Name = "ptbSummaryHeaderIcon";
            this.ptbSummaryHeaderIcon.Size = new System.Drawing.Size(18, 18);
            this.ptbSummaryHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSummaryHeaderIcon.TabIndex = 104;
            this.ptbSummaryHeaderIcon.TabStop = false;

            // lblSummaryHeaderText
            this.lblSummaryHeaderText.AutoSize = true;
            this.lblSummaryHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSummaryHeaderText.ForeColor = System.Drawing.Color.White;
            this.lblSummaryHeaderText.Location = new System.Drawing.Point(38, 10);
            this.lblSummaryHeaderText.Text = "Tóm tắt hồ sơ";
            this.lblSummaryHeaderText.BackColor = System.Drawing.Color.Transparent;
 
            // pnlSummaryBody
            this.pnlSummaryBody.BorderThickness = 0;
            this.pnlSummaryBody.FillColor = System.Drawing.Color.Transparent;
            this.pnlSummaryBody.Location = new System.Drawing.Point(0, 40);
            this.pnlSummaryBody.Name = "pnlSummaryBody";
            this.pnlSummaryBody.Size = new System.Drawing.Size(380, 380);
            this.pnlSummaryBody.BackColor = System.Drawing.Color.Transparent;
 
            // =============================================
            // pnlPermCard — Right: Quyền VPD
            // =============================================
            this.pnlPermCard.BorderColor = cardBorder;
            this.pnlPermCard.BorderRadius = 12;
            this.pnlPermCard.BorderThickness = 1;
            this.pnlPermCard.FillColor = System.Drawing.Color.White;
            this.pnlPermCard.Location = new System.Drawing.Point(970, 527);
            this.pnlPermCard.Name = "pnlPermCard";
            this.pnlPermCard.Size = new System.Drawing.Size(380, 320);
            this.pnlPermCard.TabIndex = 6;
            this.pnlPermCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlPermCard.Controls.Add(this.pnlPermHeader);
            this.pnlPermCard.Controls.Add(this.pnlPermBody);
 
            // pnlPermHeader
            this.pnlPermHeader.BorderRadius = 12;
            this.pnlPermHeader.CustomizableEdges.BottomLeft = false;
            this.pnlPermHeader.CustomizableEdges.BottomRight = false;
            this.pnlPermHeader.BorderThickness = 0;
            this.pnlPermHeader.FillColor = teal;
            this.pnlPermHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlPermHeader.Name = "pnlPermHeader";
            this.pnlPermHeader.Size = new System.Drawing.Size(380, 40);
            this.pnlPermHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlPermHeader.Controls.Add(this.ptbPermHeaderIcon);
            this.pnlPermHeader.Controls.Add(this.lblPermHeaderText);
 
            // ptbPermHeaderIcon
            this.ptbPermHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbPermHeaderIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbPermHeaderIcon.Location = new System.Drawing.Point(14, 11);
            this.ptbPermHeaderIcon.Name = "ptbPermHeaderIcon";
            this.ptbPermHeaderIcon.Size = new System.Drawing.Size(18, 18);
            this.ptbPermHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbPermHeaderIcon.TabIndex = 105;
            this.ptbPermHeaderIcon.TabStop = false;

            // lblPermHeaderText
            this.lblPermHeaderText.AutoSize = true;
            this.lblPermHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPermHeaderText.ForeColor = System.Drawing.Color.White;
            this.lblPermHeaderText.Location = new System.Drawing.Point(38, 10);
            this.lblPermHeaderText.Text = "Quyền VPD áp dụng";
            this.lblPermHeaderText.BackColor = System.Drawing.Color.Transparent;
 
            // pnlPermBody
            this.pnlPermBody.BorderThickness = 0;
            this.pnlPermBody.FillColor = System.Drawing.Color.Transparent;
            this.pnlPermBody.Location = new System.Drawing.Point(0, 40);
            this.pnlPermBody.Name = "pnlPermBody";
            this.pnlPermBody.Size = new System.Drawing.Size(380, 280);
            this.pnlPermBody.BackColor = System.Drawing.Color.Transparent;
 
            // =============================================
            // pnlLoadCard — Right: Tải của khoa
            // =============================================
            this.pnlLoadCard.BorderColor = cardBorder;
            this.pnlLoadCard.BorderRadius = 12;
            this.pnlLoadCard.BorderThickness = 1;
            this.pnlLoadCard.FillColor = System.Drawing.Color.White;
            this.pnlLoadCard.Location = new System.Drawing.Point(970, 863);
            this.pnlLoadCard.Name = "pnlLoadCard";
            this.pnlLoadCard.Size = new System.Drawing.Size(380, 150);
            this.pnlLoadCard.TabIndex = 7;
            this.pnlLoadCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoadCard.Controls.Add(this.pnlLoadHeader);
            this.pnlLoadCard.Controls.Add(this.pnlLoadBody);
 
            // pnlLoadHeader
            this.pnlLoadHeader.BorderRadius = 12;
            this.pnlLoadHeader.CustomizableEdges.BottomLeft = false;
            this.pnlLoadHeader.CustomizableEdges.BottomRight = false;
            this.pnlLoadHeader.BorderThickness = 0;
            this.pnlLoadHeader.FillColor = teal;
            this.pnlLoadHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlLoadHeader.Name = "pnlLoadHeader";
            this.pnlLoadHeader.Size = new System.Drawing.Size(380, 40);
            this.pnlLoadHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlLoadHeader.Controls.Add(this.ptbLoadHeaderIcon);
            this.pnlLoadHeader.Controls.Add(this.lblLoadHeaderText);
 
            // ptbLoadHeaderIcon
            this.ptbLoadHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbLoadHeaderIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbLoadHeaderIcon.Location = new System.Drawing.Point(14, 11);
            this.ptbLoadHeaderIcon.Name = "ptbLoadHeaderIcon";
            this.ptbLoadHeaderIcon.Size = new System.Drawing.Size(18, 18);
            this.ptbLoadHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbLoadHeaderIcon.TabIndex = 106;
            this.ptbLoadHeaderIcon.TabStop = false;

            // lblLoadHeaderText
            this.lblLoadHeaderText.AutoSize = true;
            this.lblLoadHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLoadHeaderText.ForeColor = System.Drawing.Color.White;
            this.lblLoadHeaderText.Location = new System.Drawing.Point(38, 10);
            this.lblLoadHeaderText.Text = "Tải của khoa Tim mạch";
            this.lblLoadHeaderText.BackColor = System.Drawing.Color.Transparent;
 
            // pnlLoadBody
            this.pnlLoadBody.BorderThickness = 0;
            this.pnlLoadBody.FillColor = System.Drawing.Color.Transparent;
            this.pnlLoadBody.Location = new System.Drawing.Point(0, 40);
            this.pnlLoadBody.Name = "pnlLoadBody";
            this.pnlLoadBody.Size = new System.Drawing.Size(380, 110);
            this.pnlLoadBody.BackColor = System.Drawing.Color.Transparent;
 
            // =============================================
            // ucTaoHSBA
            // =============================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScroll);
            this.Name = "ucTaoHSBA";
            this.Size = new System.Drawing.Size(1370, 850);
            this.Load += new System.EventHandler(this.ucTaoHSBA_Load);

            this.pnlScroll.ResumeLayout(false);
            this.pnlSteps.ResumeLayout(false);
            this.pnlStep1Card.ResumeLayout(false);
            this.pnlStep1Card.PerformLayout();
            this.pnlPatientFound.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBNAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep1Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep2Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep3Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbNoteIcon)).EndInit();
            this.pnlStep2Card.PerformLayout();
            this.pnlIcdSection.ResumeLayout(false);
            this.pnlIcdSection.PerformLayout();
            this.pnlStep3Card.ResumeLayout(false);
            this.pnlStep3Card.PerformLayout();
            this.pnlNoteSection.ResumeLayout(false);
            this.pnlNoteSection.PerformLayout();
            this.pnlActionsCard.ResumeLayout(false);
            this.pnlActionsCard.PerformLayout();
            this.pnlSummaryCard.ResumeLayout(false);
            this.pnlSummaryHeader.ResumeLayout(false);
            this.pnlSummaryHeader.PerformLayout();
            this.pnlPermCard.ResumeLayout(false);
            this.pnlPermHeader.ResumeLayout(false);
            this.pnlPermHeader.PerformLayout();
            this.pnlLoadCard.ResumeLayout(false);
            this.pnlLoadHeader.ResumeLayout(false);
            this.pnlLoadHeader.PerformLayout();
            this.ResumeLayout(false);
        }

        // Main container
        private Guna.UI2.WinForms.Guna2Panel pnlScroll;

        // Steps
        private Guna.UI2.WinForms.Guna2Panel pnlSteps;

        // Step 1
        private Guna.UI2.WinForms.Guna2Panel pnlStep1Card;
        private System.Windows.Forms.Label lblStep1Title;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBN;
        private Guna.UI2.WinForms.Guna2Button btnSearchBN;
        private Guna.UI2.WinForms.Guna2Panel pnlPatientFound;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picBNAvatar;
        private System.Windows.Forms.Label lblBNName;
        private System.Windows.Forms.Label lblBNMeta;
        private Guna.UI2.WinForms.Guna2Button btnChangeBN;

        // Step 2
        private Guna.UI2.WinForms.Guna2Panel pnlStep2Card;
        private System.Windows.Forms.Label lblStep2Title;
        private System.Windows.Forms.Label lblMaHSBA;
        private Guna.UI2.WinForms.Guna2TextBox txtMaHSBA;
        private System.Windows.Forms.Label lblNgayMo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpNgayMo;
        private System.Windows.Forms.Label lblHinhThucDT;
        private Guna.UI2.WinForms.Guna2ComboBox cboHinhThucDT;
        private System.Windows.Forms.Label lblLoaiBH;
        private Guna.UI2.WinForms.Guna2ComboBox cboLoaiBH;
        private System.Windows.Forms.Label lblChanDoan;
        private Guna.UI2.WinForms.Guna2TextBox txtChanDoan;
        private Guna.UI2.WinForms.Guna2Panel pnlIcdSection;
        private System.Windows.Forms.Label lblIcdTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlIcdContainer;
        private Guna.UI2.WinForms.Guna2Button btnAddIcd;

        // Step 3
        private Guna.UI2.WinForms.Guna2Panel pnlStep3Card;
        private System.Windows.Forms.Label lblStep3Title;
        private System.Windows.Forms.Label lblKhoaDT;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoaDT;
        private System.Windows.Forms.Label lblPhongDT;
        private Guna.UI2.WinForms.Guna2ComboBox cboPhongDT;
        private System.Windows.Forms.Label lblChonBS;
        private Guna.UI2.WinForms.Guna2Panel pnlDoctorGrid;
        private Guna.UI2.WinForms.Guna2Panel pnlNoteSection;
        private System.Windows.Forms.Label lblGhiChuTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtGhiChu;

        // Actions
        private Guna.UI2.WinForms.Guna2Panel pnlActionsCard;
        private System.Windows.Forms.Label lblDisclaimer;
        private Guna.UI2.WinForms.Guna2Button btnSaveDraft;
        private Guna.UI2.WinForms.Guna2Button btnCreateHSBA;

        // Right panels
        private Guna.UI2.WinForms.Guna2Panel pnlSummaryCard;
        private Guna.UI2.WinForms.Guna2Panel pnlSummaryHeader;
        private System.Windows.Forms.Label lblSummaryHeaderText;
        private Guna.UI2.WinForms.Guna2Panel pnlSummaryBody;

        private Guna.UI2.WinForms.Guna2Panel pnlPermCard;
        private Guna.UI2.WinForms.Guna2Panel pnlPermHeader;
        private System.Windows.Forms.Label lblPermHeaderText;
        private Guna.UI2.WinForms.Guna2Panel pnlPermBody;

        private Guna.UI2.WinForms.Guna2Panel pnlLoadCard;
        private Guna.UI2.WinForms.Guna2Panel pnlLoadHeader;
        private System.Windows.Forms.Label lblLoadHeaderText;
        private Guna.UI2.WinForms.Guna2Panel pnlLoadBody;

        // Dialog
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;

        // PictureBox icons for section titles
        private Guna.UI2.WinForms.Guna2PictureBox ptbStep1Icon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbStep2Icon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbStep3Icon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbNoteIcon;

        // PictureBox icons for right headers
        private Guna.UI2.WinForms.Guna2PictureBox ptbSummaryHeaderIcon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbPermHeaderIcon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbLoadHeaderIcon;
    }
}

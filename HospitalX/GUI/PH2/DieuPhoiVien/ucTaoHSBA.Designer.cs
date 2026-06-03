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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTaoHSBA));
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSteps = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlStep1Card = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbStep1Icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblStep1Title = new System.Windows.Forms.Label();
            this.txtSearchBN = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSearchBN = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPatientFound = new Guna.UI2.WinForms.Guna2Panel();
            this.picBNAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblBNName = new System.Windows.Forms.Label();
            this.lblBNMeta = new System.Windows.Forms.Label();
            this.btnChangeBN = new Guna.UI2.WinForms.Guna2Button();
            this.pnlStep2Card = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbStep2Icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblStep2Title = new System.Windows.Forms.Label();
            this.lblMaHSBA = new System.Windows.Forms.Label();
            this.txtMaHSBA = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNgayMo = new System.Windows.Forms.Label();
            this.dtpNgayMo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblChanDoan = new System.Windows.Forms.Label();
            this.txtChanDoan = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDieuTri = new System.Windows.Forms.Label();
            this.txtDieuTri = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblKetLuan = new System.Windows.Forms.Label();
            this.txtKetLuan = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnlStep3Card = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbStep3Icon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblStep3Title = new System.Windows.Forms.Label();
            this.lblKhoaDT = new System.Windows.Forms.Label();
            this.cboKhoaDT = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblChonBS = new System.Windows.Forms.Label();
            this.pnlDoctorGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlActionsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDisclaimer = new System.Windows.Forms.Label();
            this.btnCreateHSBA = new Guna.UI2.WinForms.Guna2Button();
            this.pnlSummaryCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSummaryHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbSummaryHeaderIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblSummaryHeaderText = new System.Windows.Forms.Label();
            this.pnlSummaryBody = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPermCard = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPermHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.ptbPermHeaderIcon = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPermHeaderText = new System.Windows.Forms.Label();
            this.pnlPermBody = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2MessageDialog1 = new Guna.UI2.WinForms.Guna2MessageDialog();
            this.pnlScroll.SuspendLayout();
            this.pnlStep1Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep1Icon)).BeginInit();
            this.pnlPatientFound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBNAvatar)).BeginInit();
            this.pnlStep2Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep2Icon)).BeginInit();
            this.pnlStep3Card.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep3Icon)).BeginInit();
            this.pnlActionsCard.SuspendLayout();
            this.pnlSummaryCard.SuspendLayout();
            this.pnlSummaryHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSummaryHeaderIcon)).BeginInit();
            this.pnlPermCard.SuspendLayout();
            this.pnlPermHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPermHeaderIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.AutoScrollMargin = new System.Drawing.Size(0, 40);
            this.pnlScroll.Controls.Add(this.pnlSteps);
            this.pnlScroll.Controls.Add(this.pnlStep1Card);
            this.pnlScroll.Controls.Add(this.pnlStep2Card);
            this.pnlScroll.Controls.Add(this.pnlStep3Card);
            this.pnlScroll.Controls.Add(this.pnlActionsCard);
            this.pnlScroll.Controls.Add(this.pnlSummaryCard);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1028, 691);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlSteps
            // 
            this.pnlSteps.BackColor = System.Drawing.Color.Transparent;
            this.pnlSteps.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlSteps.BorderRadius = 12;
            this.pnlSteps.BorderThickness = 1;
            this.pnlSteps.FillColor = System.Drawing.Color.White;
            this.pnlSteps.Location = new System.Drawing.Point(15, 12);
            this.pnlSteps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSteps.Name = "pnlSteps";
            this.pnlSteps.Size = new System.Drawing.Size(998, 49);
            this.pnlSteps.TabIndex = 0;
            // 
            // pnlStep1Card
            // 
            this.pnlStep1Card.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep1Card.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlStep1Card.BorderRadius = 12;
            this.pnlStep1Card.BorderThickness = 1;
            this.pnlStep1Card.Controls.Add(this.ptbStep1Icon);
            this.pnlStep1Card.Controls.Add(this.lblStep1Title);
            this.pnlStep1Card.Controls.Add(this.txtSearchBN);
            this.pnlStep1Card.Controls.Add(this.btnSearchBN);
            this.pnlStep1Card.Controls.Add(this.pnlPatientFound);
            this.pnlStep1Card.FillColor = System.Drawing.Color.White;
            this.pnlStep1Card.Location = new System.Drawing.Point(15, 74);
            this.pnlStep1Card.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlStep1Card.Name = "pnlStep1Card";
            this.pnlStep1Card.Size = new System.Drawing.Size(705, 146);
            this.pnlStep1Card.TabIndex = 1;
            // 
            // ptbStep1Icon
            // 
            this.ptbStep1Icon.BackColor = System.Drawing.Color.Transparent;
            this.ptbStep1Icon.FillColor = System.Drawing.Color.Transparent;
            this.ptbStep1Icon.ImageRotate = 0F;
            this.ptbStep1Icon.Location = new System.Drawing.Point(15, 11);
            this.ptbStep1Icon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptbStep1Icon.Name = "ptbStep1Icon";
            this.ptbStep1Icon.Size = new System.Drawing.Size(18, 20);
            this.ptbStep1Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbStep1Icon.TabIndex = 100;
            this.ptbStep1Icon.TabStop = false;
            // 
            // lblStep1Title
            // 
            this.lblStep1Title.AutoSize = true;
            this.lblStep1Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStep1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblStep1Title.Location = new System.Drawing.Point(40, 13);
            this.lblStep1Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep1Title.Name = "lblStep1Title";
            this.lblStep1Title.Size = new System.Drawing.Size(175, 15);
            this.lblStep1Title.TabIndex = 101;
            this.lblStep1Title.Text = "BƯỚC 1 — CHỌN BỆNH NHÂN";
            // 
            // txtSearchBN
            // 
            this.txtSearchBN.BackColor = System.Drawing.Color.Transparent;
            this.txtSearchBN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtSearchBN.BorderRadius = 8;
            this.txtSearchBN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBN.DefaultText = "";
            this.txtSearchBN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtSearchBN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearchBN.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSearchBN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtSearchBN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtSearchBN.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtSearchBN.IconLeft")));
            this.txtSearchBN.Location = new System.Drawing.Point(15, 42);
            this.txtSearchBN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearchBN.Name = "txtSearchBN";
            this.txtSearchBN.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(195)))), ((int)(((byte)(188)))));
            this.txtSearchBN.PlaceholderText = "Tìm theo mã BN, họ tên, CCCD…";
            this.txtSearchBN.SelectedText = "";
            this.txtSearchBN.Size = new System.Drawing.Size(532, 31);
            this.txtSearchBN.TabIndex = 0;
            this.txtSearchBN.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // btnSearchBN
            // 
            this.btnSearchBN.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchBN.BorderRadius = 8;
            this.btnSearchBN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchBN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnSearchBN.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearchBN.ForeColor = System.Drawing.Color.White;
            this.btnSearchBN.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnSearchBN.Location = new System.Drawing.Point(555, 42);
            this.btnSearchBN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearchBN.Name = "btnSearchBN";
            this.btnSearchBN.Size = new System.Drawing.Size(132, 31);
            this.btnSearchBN.TabIndex = 1;
            this.btnSearchBN.Text = "Tìm kiếm";
            // 
            // pnlPatientFound
            // 
            this.pnlPatientFound.BackColor = System.Drawing.Color.Transparent;
            this.pnlPatientFound.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlPatientFound.BorderRadius = 10;
            this.pnlPatientFound.BorderThickness = 2;
            this.pnlPatientFound.Controls.Add(this.picBNAvatar);
            this.pnlPatientFound.Controls.Add(this.lblBNName);
            this.pnlPatientFound.Controls.Add(this.lblBNMeta);
            this.pnlPatientFound.Controls.Add(this.btnChangeBN);
            this.pnlPatientFound.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.pnlPatientFound.Location = new System.Drawing.Point(15, 88);
            this.pnlPatientFound.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlPatientFound.Name = "pnlPatientFound";
            this.pnlPatientFound.Size = new System.Drawing.Size(672, 46);
            this.pnlPatientFound.TabIndex = 2;
            this.pnlPatientFound.Visible = false;
            // 
            // picBNAvatar
            // 
            this.picBNAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picBNAvatar.ImageRotate = 0F;
            this.picBNAvatar.Location = new System.Drawing.Point(9, 8);
            this.picBNAvatar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picBNAvatar.Name = "picBNAvatar";
            this.picBNAvatar.Size = new System.Drawing.Size(27, 29);
            this.picBNAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBNAvatar.TabIndex = 0;
            this.picBNAvatar.TabStop = false;
            // 
            // lblBNName
            // 
            this.lblBNName.AutoSize = true;
            this.lblBNName.BackColor = System.Drawing.Color.Transparent;
            this.lblBNName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblBNName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblBNName.Location = new System.Drawing.Point(44, 6);
            this.lblBNName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBNName.Name = "lblBNName";
            this.lblBNName.Size = new System.Drawing.Size(104, 17);
            this.lblBNName.TabIndex = 1;
            this.lblBNName.Text = "Nguyễn Văn An";
            // 
            // lblBNMeta
            // 
            this.lblBNMeta.AutoSize = true;
            this.lblBNMeta.BackColor = System.Drawing.Color.Transparent;
            this.lblBNMeta.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.lblBNMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblBNMeta.Location = new System.Drawing.Point(44, 26);
            this.lblBNMeta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBNMeta.Name = "lblBNMeta";
            this.lblBNMeta.Size = new System.Drawing.Size(273, 14);
            this.lblBNMeta.TabIndex = 2;
            this.lblBNMeta.Text = "BN240001 · Nam · 15/03/1978 · Tim mạch";
            // 
            // btnChangeBN
            // 
            this.btnChangeBN.BackColor = System.Drawing.Color.Transparent;
            this.btnChangeBN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnChangeBN.BorderRadius = 8;
            this.btnChangeBN.BorderThickness = 2;
            this.btnChangeBN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeBN.FillColor = System.Drawing.Color.Transparent;
            this.btnChangeBN.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnChangeBN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnChangeBN.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.btnChangeBN.Location = new System.Drawing.Point(591, 9);
            this.btnChangeBN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnChangeBN.Name = "btnChangeBN";
            this.btnChangeBN.Size = new System.Drawing.Size(72, 28);
            this.btnChangeBN.TabIndex = 3;
            this.btnChangeBN.Text = "Đổi BN";
            // 
            // pnlStep2Card
            // 
            this.pnlStep2Card.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep2Card.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlStep2Card.BorderRadius = 12;
            this.pnlStep2Card.BorderThickness = 1;
            this.pnlStep2Card.Controls.Add(this.ptbStep2Icon);
            this.pnlStep2Card.Controls.Add(this.lblStep2Title);
            this.pnlStep2Card.Controls.Add(this.lblMaHSBA);
            this.pnlStep2Card.Controls.Add(this.txtMaHSBA);
            this.pnlStep2Card.Controls.Add(this.lblNgayMo);
            this.pnlStep2Card.Controls.Add(this.dtpNgayMo);
            this.pnlStep2Card.Controls.Add(this.lblChanDoan);
            this.pnlStep2Card.Controls.Add(this.txtChanDoan);
            this.pnlStep2Card.Controls.Add(this.lblDieuTri);
            this.pnlStep2Card.Controls.Add(this.txtDieuTri);
            this.pnlStep2Card.Controls.Add(this.lblKetLuan);
            this.pnlStep2Card.Controls.Add(this.txtKetLuan);
            this.pnlStep2Card.FillColor = System.Drawing.Color.White;
            this.pnlStep2Card.Location = new System.Drawing.Point(15, 233);
            this.pnlStep2Card.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlStep2Card.Name = "pnlStep2Card";
            this.pnlStep2Card.Size = new System.Drawing.Size(705, 374);
            this.pnlStep2Card.TabIndex = 2;
            // 
            // ptbStep2Icon
            // 
            this.ptbStep2Icon.BackColor = System.Drawing.Color.Transparent;
            this.ptbStep2Icon.FillColor = System.Drawing.Color.Transparent;
            this.ptbStep2Icon.ImageRotate = 0F;
            this.ptbStep2Icon.Location = new System.Drawing.Point(15, 11);
            this.ptbStep2Icon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptbStep2Icon.Name = "ptbStep2Icon";
            this.ptbStep2Icon.Size = new System.Drawing.Size(18, 20);
            this.ptbStep2Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbStep2Icon.TabIndex = 101;
            this.ptbStep2Icon.TabStop = false;
            // 
            // lblStep2Title
            // 
            this.lblStep2Title.AutoSize = true;
            this.lblStep2Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStep2Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep2Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblStep2Title.Location = new System.Drawing.Point(40, 13);
            this.lblStep2Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep2Title.Name = "lblStep2Title";
            this.lblStep2Title.Size = new System.Drawing.Size(229, 15);
            this.lblStep2Title.TabIndex = 102;
            this.lblStep2Title.Text = "BƯỚC 2 — THÔNG TIN HỒ SƠ BỆNH ÁN";
            // 
            // lblMaHSBA
            // 
            this.lblMaHSBA.AutoSize = true;
            this.lblMaHSBA.BackColor = System.Drawing.Color.Transparent;
            this.lblMaHSBA.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHSBA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblMaHSBA.Location = new System.Drawing.Point(15, 46);
            this.lblMaHSBA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaHSBA.Name = "lblMaHSBA";
            this.lblMaHSBA.Size = new System.Drawing.Size(127, 15);
            this.lblMaHSBA.TabIndex = 103;
            this.lblMaHSBA.Text = "MÃ HSBA (TỰ ĐỘNG)";
            // 
            // txtMaHSBA
            // 
            this.txtMaHSBA.BackColor = System.Drawing.Color.Transparent;
            this.txtMaHSBA.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtMaHSBA.BorderRadius = 8;
            this.txtMaHSBA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMaHSBA.DefaultText = "HSBA-2026-0157";
            this.txtMaHSBA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.txtMaHSBA.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.txtMaHSBA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtMaHSBA.Location = new System.Drawing.Point(15, 65);
            this.txtMaHSBA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMaHSBA.Name = "txtMaHSBA";
            this.txtMaHSBA.PlaceholderText = "";
            this.txtMaHSBA.ReadOnly = true;
            this.txtMaHSBA.SelectedText = "";
            this.txtMaHSBA.Size = new System.Drawing.Size(322, 31);
            this.txtMaHSBA.TabIndex = 104;
            this.txtMaHSBA.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // lblNgayMo
            // 
            this.lblNgayMo.AutoSize = true;
            this.lblNgayMo.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayMo.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNgayMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblNgayMo.Location = new System.Drawing.Point(352, 46);
            this.lblNgayMo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNgayMo.Name = "lblNgayMo";
            this.lblNgayMo.Size = new System.Drawing.Size(110, 15);
            this.lblNgayMo.TabIndex = 105;
            this.lblNgayMo.Text = "NGÀY MỞ HỒ SƠ *";
            // 
            // dtpNgayMo
            // 
            this.dtpNgayMo.BackColor = System.Drawing.Color.Transparent;
            this.dtpNgayMo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.dtpNgayMo.BorderRadius = 8;
            this.dtpNgayMo.BorderThickness = 1;
            this.dtpNgayMo.Checked = true;
            this.dtpNgayMo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.dtpNgayMo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpNgayMo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.dtpNgayMo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayMo.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.dtpNgayMo.Location = new System.Drawing.Point(352, 65);
            this.dtpNgayMo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpNgayMo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpNgayMo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpNgayMo.Name = "dtpNgayMo";
            this.dtpNgayMo.Size = new System.Drawing.Size(322, 31);
            this.dtpNgayMo.TabIndex = 106;
            this.dtpNgayMo.TextOffset = new System.Drawing.Point(8, 0);
            this.dtpNgayMo.Value = new System.DateTime(2026, 6, 4, 2, 36, 29, 487);
            // 
            // lblChanDoan
            // 
            this.lblChanDoan.AutoSize = true;
            this.lblChanDoan.BackColor = System.Drawing.Color.Transparent;
            this.lblChanDoan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChanDoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblChanDoan.Location = new System.Drawing.Point(15, 112);
            this.lblChanDoan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChanDoan.Name = "lblChanDoan";
            this.lblChanDoan.Size = new System.Drawing.Size(125, 15);
            this.lblChanDoan.TabIndex = 107;
            this.lblChanDoan.Text = "CHẨN ĐOÁN SƠ BỘ *";
            // 
            // txtChanDoan
            // 
            this.txtChanDoan.BackColor = System.Drawing.Color.Transparent;
            this.txtChanDoan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtChanDoan.BorderRadius = 8;
            this.txtChanDoan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChanDoan.DefaultText = "";
            this.txtChanDoan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtChanDoan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtChanDoan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtChanDoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtChanDoan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtChanDoan.Location = new System.Drawing.Point(15, 132);
            this.txtChanDoan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtChanDoan.Multiline = true;
            this.txtChanDoan.Name = "txtChanDoan";
            this.txtChanDoan.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(195)))), ((int)(((byte)(188)))));
            this.txtChanDoan.PlaceholderText = "Nhập chẩn đoán ban đầu của điều dưỡng / điều phối viên…";
            this.txtChanDoan.SelectedText = "";
            this.txtChanDoan.Size = new System.Drawing.Size(660, 55);
            this.txtChanDoan.TabIndex = 108;
            this.txtChanDoan.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // lblDieuTri
            // 
            this.lblDieuTri.AutoSize = true;
            this.lblDieuTri.BackColor = System.Drawing.Color.Transparent;
            this.lblDieuTri.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDieuTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDieuTri.Location = new System.Drawing.Point(15, 198);
            this.lblDieuTri.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDieuTri.Name = "lblDieuTri";
            this.lblDieuTri.Size = new System.Drawing.Size(65, 15);
            this.lblDieuTri.TabIndex = 109;
            this.lblDieuTri.Text = "ĐIỀU TRỊ *";
            // 
            // txtDieuTri
            // 
            this.txtDieuTri.BackColor = System.Drawing.Color.Transparent;
            this.txtDieuTri.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDieuTri.BorderRadius = 8;
            this.txtDieuTri.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDieuTri.DefaultText = "";
            this.txtDieuTri.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtDieuTri.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDieuTri.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtDieuTri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtDieuTri.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtDieuTri.Location = new System.Drawing.Point(15, 218);
            this.txtDieuTri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDieuTri.Multiline = true;
            this.txtDieuTri.Name = "txtDieuTri";
            this.txtDieuTri.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(195)))), ((int)(((byte)(188)))));
            this.txtDieuTri.PlaceholderText = "Nhập hướng điều trị ban đầu…";
            this.txtDieuTri.SelectedText = "";
            this.txtDieuTri.Size = new System.Drawing.Size(660, 55);
            this.txtDieuTri.TabIndex = 110;
            this.txtDieuTri.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // lblKetLuan
            // 
            this.lblKetLuan.AutoSize = true;
            this.lblKetLuan.BackColor = System.Drawing.Color.Transparent;
            this.lblKetLuan.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblKetLuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKetLuan.Location = new System.Drawing.Point(15, 284);
            this.lblKetLuan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKetLuan.Name = "lblKetLuan";
            this.lblKetLuan.Size = new System.Drawing.Size(71, 15);
            this.lblKetLuan.TabIndex = 111;
            this.lblKetLuan.Text = "KẾT LUẬN *";
            // 
            // txtKetLuan
            // 
            this.txtKetLuan.BackColor = System.Drawing.Color.Transparent;
            this.txtKetLuan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtKetLuan.BorderRadius = 8;
            this.txtKetLuan.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKetLuan.DefaultText = "";
            this.txtKetLuan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.txtKetLuan.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtKetLuan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtKetLuan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.txtKetLuan.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtKetLuan.Location = new System.Drawing.Point(15, 304);
            this.txtKetLuan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtKetLuan.Multiline = true;
            this.txtKetLuan.Name = "txtKetLuan";
            this.txtKetLuan.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(195)))), ((int)(((byte)(188)))));
            this.txtKetLuan.PlaceholderText = "Nhập kết luận ban đầu của y sĩ hoặc bác sĩ…";
            this.txtKetLuan.SelectedText = "";
            this.txtKetLuan.Size = new System.Drawing.Size(660, 55);
            this.txtKetLuan.TabIndex = 112;
            this.txtKetLuan.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // pnlStep3Card
            // 
            this.pnlStep3Card.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep3Card.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlStep3Card.BorderRadius = 12;
            this.pnlStep3Card.BorderThickness = 1;
            this.pnlStep3Card.Controls.Add(this.ptbStep3Icon);
            this.pnlStep3Card.Controls.Add(this.lblStep3Title);
            this.pnlStep3Card.Controls.Add(this.lblKhoaDT);
            this.pnlStep3Card.Controls.Add(this.cboKhoaDT);
            this.pnlStep3Card.Controls.Add(this.lblChonBS);
            this.pnlStep3Card.Controls.Add(this.pnlDoctorGrid);
            this.pnlStep3Card.FillColor = System.Drawing.Color.White;
            this.pnlStep3Card.Location = new System.Drawing.Point(15, 620);
            this.pnlStep3Card.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlStep3Card.Name = "pnlStep3Card";
            this.pnlStep3Card.Size = new System.Drawing.Size(705, 440);
            this.pnlStep3Card.TabIndex = 3;
            // 
            // ptbStep3Icon
            // 
            this.ptbStep3Icon.BackColor = System.Drawing.Color.Transparent;
            this.ptbStep3Icon.FillColor = System.Drawing.Color.Transparent;
            this.ptbStep3Icon.ImageRotate = 0F;
            this.ptbStep3Icon.Location = new System.Drawing.Point(15, 11);
            this.ptbStep3Icon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptbStep3Icon.Name = "ptbStep3Icon";
            this.ptbStep3Icon.Size = new System.Drawing.Size(18, 20);
            this.ptbStep3Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbStep3Icon.TabIndex = 102;
            this.ptbStep3Icon.TabStop = false;
            // 
            // lblStep3Title
            // 
            this.lblStep3Title.AutoSize = true;
            this.lblStep3Title.BackColor = System.Drawing.Color.Transparent;
            this.lblStep3Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStep3Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblStep3Title.Location = new System.Drawing.Point(40, 13);
            this.lblStep3Title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStep3Title.Name = "lblStep3Title";
            this.lblStep3Title.Size = new System.Drawing.Size(232, 15);
            this.lblStep3Title.TabIndex = 103;
            this.lblStep3Title.Text = "BƯỚC 3 — CHỈ ĐỊNH BÁC SĨ PHỤ TRÁCH";
            // 
            // lblKhoaDT
            // 
            this.lblKhoaDT.AutoSize = true;
            this.lblKhoaDT.BackColor = System.Drawing.Color.Transparent;
            this.lblKhoaDT.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblKhoaDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKhoaDT.Location = new System.Drawing.Point(15, 46);
            this.lblKhoaDT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKhoaDT.Name = "lblKhoaDT";
            this.lblKhoaDT.Size = new System.Drawing.Size(102, 15);
            this.lblKhoaDT.TabIndex = 104;
            this.lblKhoaDT.Text = "KHOA ĐIỀU TRỊ *";
            // 
            // cboKhoaDT
            // 
            this.cboKhoaDT.BackColor = System.Drawing.Color.Transparent;
            this.cboKhoaDT.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboKhoaDT.BorderRadius = 8;
            this.cboKhoaDT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboKhoaDT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoaDT.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.cboKhoaDT.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoaDT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoaDT.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.cboKhoaDT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(48)))), ((int)(((byte)(42)))));
            this.cboKhoaDT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKhoaDT.ItemHeight = 32;
            this.cboKhoaDT.Location = new System.Drawing.Point(15, 65);
            this.cboKhoaDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboKhoaDT.Name = "cboKhoaDT";
            this.cboKhoaDT.Size = new System.Drawing.Size(324, 38);
            this.cboKhoaDT.TabIndex = 105;
            this.cboKhoaDT.TextOffset = new System.Drawing.Point(8, 0);
            // 
            // lblChonBS
            // 
            this.lblChonBS.AutoSize = true;
            this.lblChonBS.BackColor = System.Drawing.Color.Transparent;
            this.lblChonBS.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChonBS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblChonBS.Location = new System.Drawing.Point(15, 112);
            this.lblChonBS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChonBS.Name = "lblChonBS";
            this.lblChonBS.Size = new System.Drawing.Size(159, 15);
            this.lblChonBS.TabIndex = 106;
            this.lblChonBS.Text = "CHỌN BÁC SĨ PHỤ TRÁCH *";
            // 
            // pnlDoctorGrid
            // 
            this.pnlDoctorGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlDoctorGrid.FillColor = System.Drawing.Color.White;
            this.pnlDoctorGrid.Location = new System.Drawing.Point(15, 132);
            this.pnlDoctorGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlDoctorGrid.Name = "pnlDoctorGrid";
            this.pnlDoctorGrid.Size = new System.Drawing.Size(675, 203);
            this.pnlDoctorGrid.TabIndex = 107;
            // 
            // pnlActionsCard
            // 
            this.pnlActionsCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlActionsCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlActionsCard.BorderRadius = 12;
            this.pnlActionsCard.BorderThickness = 1;
            this.pnlActionsCard.Controls.Add(this.lblDisclaimer);
            this.pnlActionsCard.Controls.Add(this.btnCreateHSBA);
            this.pnlActionsCard.FillColor = System.Drawing.Color.White;
            this.pnlActionsCard.Location = new System.Drawing.Point(15, 1073);
            this.pnlActionsCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlActionsCard.Name = "pnlActionsCard";
            this.pnlActionsCard.Size = new System.Drawing.Size(705, 52);
            this.pnlActionsCard.TabIndex = 4;
            // 
            // lblDisclaimer
            // 
            this.lblDisclaimer.AutoSize = true;
            this.lblDisclaimer.BackColor = System.Drawing.Color.Transparent;
            this.lblDisclaimer.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblDisclaimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblDisclaimer.Location = new System.Drawing.Point(15, 20);
            this.lblDisclaimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDisclaimer.Name = "lblDisclaimer";
            this.lblDisclaimer.Size = new System.Drawing.Size(334, 13);
            this.lblDisclaimer.TabIndex = 0;
            this.lblDisclaimer.Text = "Điều phối viên có trách nhiệm xác nhận thông tin trước khi lưu.";
            // 
            // btnCreateHSBA
            // 
            this.btnCreateHSBA.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateHSBA.BorderRadius = 8;
            this.btnCreateHSBA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateHSBA.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnCreateHSBA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreateHSBA.ForeColor = System.Drawing.Color.White;
            this.btnCreateHSBA.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnCreateHSBA.Location = new System.Drawing.Point(529, 10);
            this.btnCreateHSBA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateHSBA.Name = "btnCreateHSBA";
            this.btnCreateHSBA.Size = new System.Drawing.Size(158, 32);
            this.btnCreateHSBA.TabIndex = 1;
            this.btnCreateHSBA.Text = "Tạo hồ sơ bệnh án";
            // 
            // pnlSummaryCard
            // 
            this.pnlSummaryCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummaryCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlSummaryCard.BorderRadius = 12;
            this.pnlSummaryCard.BorderThickness = 1;
            this.pnlSummaryCard.Controls.Add(this.pnlSummaryHeader);
            this.pnlSummaryCard.Controls.Add(this.pnlSummaryBody);
            this.pnlSummaryCard.FillColor = System.Drawing.Color.White;
            this.pnlSummaryCard.Location = new System.Drawing.Point(728, 74);
            this.pnlSummaryCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSummaryCard.Name = "pnlSummaryCard";
            this.pnlSummaryCard.Size = new System.Drawing.Size(285, 341);
            this.pnlSummaryCard.TabIndex = 5;
            // 
            // pnlSummaryHeader
            // 
            this.pnlSummaryHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummaryHeader.BorderRadius = 12;
            this.pnlSummaryHeader.Controls.Add(this.ptbSummaryHeaderIcon);
            this.pnlSummaryHeader.Controls.Add(this.lblSummaryHeaderText);
            this.pnlSummaryHeader.CustomizableEdges.BottomLeft = false;
            this.pnlSummaryHeader.CustomizableEdges.BottomRight = false;
            this.pnlSummaryHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlSummaryHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSummaryHeader.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSummaryHeader.Name = "pnlSummaryHeader";
            this.pnlSummaryHeader.Size = new System.Drawing.Size(285, 32);
            this.pnlSummaryHeader.TabIndex = 0;
            // 
            // ptbSummaryHeaderIcon
            // 
            this.ptbSummaryHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbSummaryHeaderIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbSummaryHeaderIcon.ImageRotate = 0F;
            this.ptbSummaryHeaderIcon.Location = new System.Drawing.Point(10, 9);
            this.ptbSummaryHeaderIcon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ptbSummaryHeaderIcon.Name = "ptbSummaryHeaderIcon";
            this.ptbSummaryHeaderIcon.Size = new System.Drawing.Size(14, 15);
            this.ptbSummaryHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbSummaryHeaderIcon.TabIndex = 104;
            this.ptbSummaryHeaderIcon.TabStop = false;
            // 
            // lblSummaryHeaderText
            // 
            this.lblSummaryHeaderText.AutoSize = true;
            this.lblSummaryHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.lblSummaryHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSummaryHeaderText.ForeColor = System.Drawing.Color.White;
            this.lblSummaryHeaderText.Location = new System.Drawing.Point(28, 8);
            this.lblSummaryHeaderText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSummaryHeaderText.Name = "lblSummaryHeaderText";
            this.lblSummaryHeaderText.Size = new System.Drawing.Size(94, 17);
            this.lblSummaryHeaderText.TabIndex = 105;
            this.lblSummaryHeaderText.Text = "Tóm tắt hồ sơ";
            // 
            // pnlSummaryBody
            // 
            this.pnlSummaryBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlSummaryBody.FillColor = System.Drawing.Color.Transparent;
            this.pnlSummaryBody.Location = new System.Drawing.Point(0, 32);
            this.pnlSummaryBody.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSummaryBody.Name = "pnlSummaryBody";
            this.pnlSummaryBody.Size = new System.Drawing.Size(285, 309);
            this.pnlSummaryBody.TabIndex = 1;
            // 
            // pnlPermCard
            // 
            this.pnlPermCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlPermCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlPermCard.BorderRadius = 12;
            this.pnlPermCard.BorderThickness = 1;
            this.pnlPermCard.Controls.Add(this.pnlPermHeader);
            this.pnlPermCard.Controls.Add(this.pnlPermBody);
            this.pnlPermCard.FillColor = System.Drawing.Color.White;
            this.pnlPermCard.Location = new System.Drawing.Point(970, 527);
            this.pnlPermCard.Name = "pnlPermCard";
            this.pnlPermCard.Size = new System.Drawing.Size(380, 320);
            this.pnlPermCard.TabIndex = 6;
            // 
            // pnlPermHeader
            // 
            this.pnlPermHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlPermHeader.BorderRadius = 12;
            this.pnlPermHeader.Controls.Add(this.ptbPermHeaderIcon);
            this.pnlPermHeader.Controls.Add(this.lblPermHeaderText);
            this.pnlPermHeader.CustomizableEdges.BottomLeft = false;
            this.pnlPermHeader.CustomizableEdges.BottomRight = false;
            this.pnlPermHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlPermHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlPermHeader.Name = "pnlPermHeader";
            this.pnlPermHeader.Size = new System.Drawing.Size(380, 40);
            this.pnlPermHeader.TabIndex = 0;
            // 
            // ptbPermHeaderIcon
            // 
            this.ptbPermHeaderIcon.BackColor = System.Drawing.Color.Transparent;
            this.ptbPermHeaderIcon.FillColor = System.Drawing.Color.Transparent;
            this.ptbPermHeaderIcon.ImageRotate = 0F;
            this.ptbPermHeaderIcon.Location = new System.Drawing.Point(14, 11);
            this.ptbPermHeaderIcon.Name = "ptbPermHeaderIcon";
            this.ptbPermHeaderIcon.Size = new System.Drawing.Size(18, 18);
            this.ptbPermHeaderIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbPermHeaderIcon.TabIndex = 105;
            this.ptbPermHeaderIcon.TabStop = false;
            // 
            // lblPermHeaderText
            // 
            this.lblPermHeaderText.AutoSize = true;
            this.lblPermHeaderText.BackColor = System.Drawing.Color.Transparent;
            this.lblPermHeaderText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPermHeaderText.ForeColor = System.Drawing.Color.White;
            this.lblPermHeaderText.Location = new System.Drawing.Point(38, 10);
            this.lblPermHeaderText.Name = "lblPermHeaderText";
            this.lblPermHeaderText.Size = new System.Drawing.Size(134, 17);
            this.lblPermHeaderText.TabIndex = 106;
            this.lblPermHeaderText.Text = "Quyền VPD áp dụng";
            // 
            // pnlPermBody
            // 
            this.pnlPermBody.BackColor = System.Drawing.Color.Transparent;
            this.pnlPermBody.FillColor = System.Drawing.Color.Transparent;
            this.pnlPermBody.Location = new System.Drawing.Point(0, 40);
            this.pnlPermBody.Name = "pnlPermBody";
            this.pnlPermBody.Size = new System.Drawing.Size(380, 280);
            this.pnlPermBody.TabIndex = 1;
            // 
            // guna2MessageDialog1
            // 
            this.guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
            this.guna2MessageDialog1.Caption = null;
            this.guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
            this.guna2MessageDialog1.Parent = null;
            this.guna2MessageDialog1.Style = Guna.UI2.WinForms.MessageDialogStyle.Default;
            this.guna2MessageDialog1.Text = null;
            // 
            // ucTaoHSBA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlScroll);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ucTaoHSBA";
            this.Size = new System.Drawing.Size(1028, 691);
            this.Load += new System.EventHandler(this.ucTaoHSBA_Load);
            this.pnlScroll.ResumeLayout(false);
            this.pnlStep1Card.ResumeLayout(false);
            this.pnlStep1Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep1Icon)).EndInit();
            this.pnlPatientFound.ResumeLayout(false);
            this.pnlPatientFound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBNAvatar)).EndInit();
            this.pnlStep2Card.ResumeLayout(false);
            this.pnlStep2Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep2Icon)).EndInit();
            this.pnlStep3Card.ResumeLayout(false);
            this.pnlStep3Card.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep3Icon)).EndInit();
            this.pnlActionsCard.ResumeLayout(false);
            this.pnlActionsCard.PerformLayout();
            this.pnlSummaryCard.ResumeLayout(false);
            this.pnlSummaryHeader.ResumeLayout(false);
            this.pnlSummaryHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSummaryHeaderIcon)).EndInit();
            this.pnlPermCard.ResumeLayout(false);
            this.pnlPermHeader.ResumeLayout(false);
            this.pnlPermHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPermHeaderIcon)).EndInit();
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
        private System.Windows.Forms.Label lblChanDoan;
        private Guna.UI2.WinForms.Guna2TextBox txtChanDoan;
        private System.Windows.Forms.Label lblDieuTri;
        private Guna.UI2.WinForms.Guna2TextBox txtDieuTri;
        private System.Windows.Forms.Label lblKetLuan;
        private Guna.UI2.WinForms.Guna2TextBox txtKetLuan;

        // Step 3
        private Guna.UI2.WinForms.Guna2Panel pnlStep3Card;
        private System.Windows.Forms.Label lblStep3Title;
        private System.Windows.Forms.Label lblKhoaDT;
        private Guna.UI2.WinForms.Guna2ComboBox cboKhoaDT;
        private System.Windows.Forms.Label lblChonBS;
        private Guna.UI2.WinForms.Guna2Panel pnlDoctorGrid;

        // Actions
        private Guna.UI2.WinForms.Guna2Panel pnlActionsCard;
        private System.Windows.Forms.Label lblDisclaimer;
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

        // Dialog
        private Guna.UI2.WinForms.Guna2MessageDialog guna2MessageDialog1;

        // PictureBox icons for section titles
        private Guna.UI2.WinForms.Guna2PictureBox ptbStep1Icon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbStep2Icon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbStep3Icon;

        // PictureBox icons for right headers
        private Guna.UI2.WinForms.Guna2PictureBox ptbSummaryHeaderIcon;
        private Guna.UI2.WinForms.Guna2PictureBox ptbPermHeaderIcon;
    }
}

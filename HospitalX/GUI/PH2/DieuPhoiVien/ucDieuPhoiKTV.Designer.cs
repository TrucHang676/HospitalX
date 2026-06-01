namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class ucDieuPhoiKTV
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlScroll = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlServiceRequests = new Guna.UI2.WinForms.Guna2Panel();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.colMaDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaHSBA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBenhNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUuTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKTV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThaoTac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cboServiceType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRequestSub = new System.Windows.Forms.Label();
            this.lblRequestTitle = new System.Windows.Forms.Label();
            this.pnlAssignForm = new Guna.UI2.WinForms.Guna2Panel();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();
            this.txtNotes = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblNotesTitle = new System.Windows.Forms.Label();
            this.pnlTimeSlots = new System.Windows.Forms.Panel();
            this.lblTimeSlotsTitle = new System.Windows.Forms.Label();
            this.pnlSelRequest = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSelBN = new System.Windows.Forms.Label();
            this.lblSelDV = new System.Windows.Forms.Label();
            this.lblSelRequestHeader = new System.Windows.Forms.Label();
            this.lblAssignTitle = new System.Windows.Forms.Label();
            this.pnlKtvListCard = new Guna.UI2.WinForms.Guna2Panel();
            this.flpKtvList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKtvHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblKtvMeta = new System.Windows.Forms.Label();
            this.lblKtvTitle = new System.Windows.Forms.Label();
            this.pnlScroll.SuspendLayout();
            this.pnlServiceRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.pnlAssignForm.SuspendLayout();
            this.pnlSelRequest.SuspendLayout();
            this.pnlKtvListCard.SuspendLayout();
            this.pnlKtvHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Controls.Add(this.pnlServiceRequests);
            this.pnlScroll.Controls.Add(this.pnlAssignForm);
            this.pnlScroll.Controls.Add(this.pnlKtvListCard);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(4);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1507, 958);
            this.pnlScroll.TabIndex = 0;
            // 
            // pnlServiceRequests
            // 
            this.pnlServiceRequests.BackColor = System.Drawing.Color.Transparent;
            this.pnlServiceRequests.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlServiceRequests.BorderRadius = 12;
            this.pnlServiceRequests.BorderThickness = 1;
            this.pnlServiceRequests.Controls.Add(this.dgvRequests);
            this.pnlServiceRequests.Controls.Add(this.cboStatus);
            this.pnlServiceRequests.Controls.Add(this.cboServiceType);
            this.pnlServiceRequests.Controls.Add(this.lblRequestSub);
            this.pnlServiceRequests.Controls.Add(this.lblRequestTitle);
            this.pnlServiceRequests.FillColor = System.Drawing.Color.White;
            this.pnlServiceRequests.Location = new System.Drawing.Point(20, 20);
            this.pnlServiceRequests.Margin = new System.Windows.Forms.Padding(4);
            this.pnlServiceRequests.Name = "pnlServiceRequests";
            this.pnlServiceRequests.Size = new System.Drawing.Size(1047, 918);
            this.pnlServiceRequests.TabIndex = 0;
            // 
            // dgvRequests
            // 
            this.dgvRequests.AllowUserToAddRows = false;
            this.dgvRequests.AllowUserToDeleteRows = false;
            this.dgvRequests.AllowUserToResizeRows = false;
            this.dgvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRequests.BackgroundColor = System.Drawing.Color.White;
            this.dgvRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRequests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRequests.ColumnHeadersHeight = 44;
            this.dgvRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaDV,
            this.colMaHSBA,
            this.colBenhNhan,
            this.colLoaiDV,
            this.colUuTien,
            this.colKTV,
            this.colTrangThai,
            this.colThaoTac});
            this.dgvRequests.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.dgvRequests.Location = new System.Drawing.Point(20, 75);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.RowTemplate.Height = 58;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(1007, 820);
            this.dgvRequests.TabIndex = 4;
            // 
            // colMaDV
            // 
            this.colMaDV.HeaderText = "Mã DV";
            this.colMaDV.Name = "colMaDV";
            this.colMaDV.ReadOnly = true;
            this.colMaDV.Width = 110;
            // 
            // colMaHSBA
            // 
            this.colMaHSBA.HeaderText = "Mã HSBA";
            this.colMaHSBA.Name = "colMaHSBA";
            this.colMaHSBA.ReadOnly = true;
            this.colMaHSBA.Width = 110;
            // 
            // colBenhNhan
            // 
            this.colBenhNhan.HeaderText = "Bệnh nhân";
            this.colBenhNhan.Name = "colBenhNhan";
            this.colBenhNhan.ReadOnly = true;
            this.colBenhNhan.Width = 160;
            // 
            // colLoaiDV
            // 
            this.colLoaiDV.HeaderText = "Loại dịch vụ";
            this.colLoaiDV.Name = "colLoaiDV";
            this.colLoaiDV.ReadOnly = true;
            this.colLoaiDV.Width = 130;
            // 
            // colUuTien
            // 
            this.colUuTien.HeaderText = "Ưu tiên";
            this.colUuTien.Name = "colUuTien";
            this.colUuTien.ReadOnly = true;
            this.colUuTien.Width = 100;
            // 
            // colKTV
            // 
            this.colKTV.HeaderText = "KTV phụ trách";
            this.colKTV.Name = "colKTV";
            this.colKTV.ReadOnly = true;
            this.colKTV.Width = 150;
            // 
            // colTrangThai
            // 
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            this.colTrangThai.Width = 130;
            // 
            // colThaoTac
            // 
            this.colThaoTac.HeaderText = "Thao tác";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
            this.colThaoTac.Width = 100;
            // 
            // cboStatus
            // 
            this.cboStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboStatus.BorderRadius = 8;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboStatus.ItemHeight = 30;
            this.cboStatus.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Chờ phân công",
            "Đã phân công",
            "Hoàn thành"});
            this.cboStatus.Location = new System.Drawing.Point(857, 16);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(170, 36);
            this.cboStatus.StartIndex = 0;
            this.cboStatus.TabIndex = 3;
            // 
            // cboServiceType
            // 
            this.cboServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboServiceType.BackColor = System.Drawing.Color.Transparent;
            this.cboServiceType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboServiceType.BorderRadius = 8;
            this.cboServiceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServiceType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboServiceType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboServiceType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboServiceType.ItemHeight = 30;
            this.cboServiceType.Items.AddRange(new object[] {
            "Tất cả loại DV",
            "Siêu âm",
            "Xét nghiệm máu",
            "X-Quang",
            "Nội soi",
            "Điện tâm đồ"});
            this.cboServiceType.Location = new System.Drawing.Point(671, 16);
            this.cboServiceType.Name = "cboServiceType";
            this.cboServiceType.Size = new System.Drawing.Size(170, 36);
            this.cboServiceType.StartIndex = 0;
            this.cboServiceType.TabIndex = 2;
            // 
            // lblRequestSub
            // 
            this.lblRequestSub.AutoSize = true;
            this.lblRequestSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRequestSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblRequestSub.Location = new System.Drawing.Point(20, 44);
            this.lblRequestSub.Name = "lblRequestSub";
            this.lblRequestSub.Size = new System.Drawing.Size(223, 15);
            this.lblRequestSub.TabIndex = 1;
            this.lblRequestSub.Text = "7 yêu cầu chờ phân công · 3 đã phân công";
            // 
            // lblRequestTitle
            // 
            this.lblRequestTitle.AutoSize = true;
            this.lblRequestTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblRequestTitle.Location = new System.Drawing.Point(18, 18);
            this.lblRequestTitle.Name = "lblRequestTitle";
            this.lblRequestTitle.Size = new System.Drawing.Size(325, 20);
            this.lblRequestTitle.TabIndex = 0;
            this.lblRequestTitle.Text = "🔬 Danh sách yêu cầu dịch vụ hỗ trợ chẩn đoán";
            // 
            // pnlAssignForm
            // 
            this.pnlAssignForm.BackColor = System.Drawing.Color.Transparent;
            this.pnlAssignForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlAssignForm.BorderRadius = 12;
            this.pnlAssignForm.BorderThickness = 1;
            this.pnlAssignForm.Controls.Add(this.btnConfirm);
            this.pnlAssignForm.Controls.Add(this.txtNotes);
            this.pnlAssignForm.Controls.Add(this.lblNotesTitle);
            this.pnlAssignForm.Controls.Add(this.pnlTimeSlots);
            this.pnlAssignForm.Controls.Add(this.lblTimeSlotsTitle);
            this.pnlAssignForm.Controls.Add(this.pnlSelRequest);
            this.pnlAssignForm.Controls.Add(this.lblAssignTitle);
            this.pnlAssignForm.FillColor = System.Drawing.Color.White;
            this.pnlAssignForm.Location = new System.Drawing.Point(1087, 20);
            this.pnlAssignForm.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAssignForm.Name = "pnlAssignForm";
            this.pnlAssignForm.Size = new System.Drawing.Size(400, 390);
            this.pnlAssignForm.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BorderRadius = 8;
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnConfirm.Location = new System.Drawing.Point(16, 332);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(368, 42);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "✅ Xác nhận phân công";
            // 
            // txtNotes
            // 
            this.txtNotes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtNotes.BorderRadius = 8;
            this.txtNotes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNotes.DefaultText = "Bệnh nhân cao tuổi, di chuyển khó khăn. Cần hỗ trợ xe lăn.";
            this.txtNotes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNotes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNotes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNotes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.txtNotes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.txtNotes.Location = new System.Drawing.Point(16, 260);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.PasswordChar = '\0';
            this.txtNotes.PlaceholderText = "Lưu ý đặc biệt cho kỹ thuật viên...";
            this.txtNotes.SelectedText = "";
            this.txtNotes.Size = new System.Drawing.Size(368, 58);
            this.txtNotes.TabIndex = 5;
            // 
            // lblNotesTitle
            // 
            this.lblNotesTitle.AutoSize = true;
            this.lblNotesTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblNotesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblNotesTitle.Location = new System.Drawing.Point(16, 242);
            this.lblNotesTitle.Name = "lblNotesTitle";
            this.lblNotesTitle.Size = new System.Drawing.Size(95, 12);
            this.lblNotesTitle.TabIndex = 4;
            this.lblNotesTitle.Text = "GHI CHÚ CHO KTV";
            // 
            // pnlTimeSlots
            // 
            this.pnlTimeSlots.Location = new System.Drawing.Point(16, 142);
            this.pnlTimeSlots.Name = "pnlTimeSlots";
            this.pnlTimeSlots.Size = new System.Drawing.Size(368, 90);
            this.pnlTimeSlots.TabIndex = 3;
            // 
            // lblTimeSlotsTitle
            // 
            this.lblTimeSlotsTitle.AutoSize = true;
            this.lblTimeSlotsTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTimeSlotsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblTimeSlotsTitle.Location = new System.Drawing.Point(16, 124);
            this.lblTimeSlotsTitle.Name = "lblTimeSlotsTitle";
            this.lblTimeSlotsTitle.Size = new System.Drawing.Size(89, 12);
            this.lblTimeSlotsTitle.TabIndex = 2;
            this.lblTimeSlotsTitle.Text = "CHỌN KHUNG GIỜ";
            // 
            // pnlSelRequest
            // 
            this.pnlSelRequest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlSelRequest.BorderRadius = 8;
            this.pnlSelRequest.BorderThickness = 1;
            this.pnlSelRequest.Controls.Add(this.lblSelBN);
            this.pnlSelRequest.Controls.Add(this.lblSelDV);
            this.pnlSelRequest.Controls.Add(this.lblSelRequestHeader);
            this.pnlSelRequest.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(244)))), ((int)(((byte)(240)))));
            this.pnlSelRequest.Location = new System.Drawing.Point(16, 42);
            this.pnlSelRequest.Name = "pnlSelRequest";
            this.pnlSelRequest.Size = new System.Drawing.Size(368, 72);
            this.pnlSelRequest.TabIndex = 1;
            // 
            // lblSelBN
            // 
            this.lblSelBN.AutoSize = true;
            this.lblSelBN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelBN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblSelBN.Location = new System.Drawing.Point(12, 45);
            this.lblSelBN.Name = "lblSelBN";
            this.lblSelBN.Size = new System.Drawing.Size(155, 15);
            this.lblSelBN.TabIndex = 2;
            this.lblSelBN.Text = "BN240003 · Hoàng Đức Nam";
            // 
            // lblSelDV
            // 
            this.lblSelDV.AutoSize = true;
            this.lblSelDV.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSelDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblSelDV.Location = new System.Drawing.Point(12, 24);
            this.lblSelDV.Name = "lblSelDV";
            this.lblSelDV.Size = new System.Drawing.Size(178, 17);
            this.lblSelDV.TabIndex = 1;
            this.lblSelDV.Text = "DV-2026-0023 — Siêu âm tim";
            // 
            // lblSelRequestHeader
            // 
            this.lblSelRequestHeader.AutoSize = true;
            this.lblSelRequestHeader.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblSelRequestHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblSelRequestHeader.Location = new System.Drawing.Point(12, 8);
            this.lblSelRequestHeader.Name = "lblSelRequestHeader";
            this.lblSelRequestHeader.Size = new System.Drawing.Size(96, 12);
            this.lblSelRequestHeader.TabIndex = 0;
            this.lblSelRequestHeader.Text = "YÊU CẦU ĐANG CHỌN";
            // 
            // lblAssignTitle
            // 
            this.lblAssignTitle.AutoSize = true;
            this.lblAssignTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblAssignTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblAssignTitle.Location = new System.Drawing.Point(14, 18);
            this.lblAssignTitle.Name = "lblAssignTitle";
            this.lblAssignTitle.Size = new System.Drawing.Size(130, 17);
            this.lblAssignTitle.TabIndex = 0;
            this.lblAssignTitle.Text = "⚡ PHÂN CÔNG NHANH";
            // 
            // pnlKtvListCard
            // 
            this.pnlKtvListCard.BackColor = System.Drawing.Color.Transparent;
            this.pnlKtvListCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlKtvListCard.BorderRadius = 12;
            this.pnlKtvListCard.BorderThickness = 1;
            this.pnlKtvListCard.Controls.Add(this.flpKtvList);
            this.pnlKtvListCard.Controls.Add(this.pnlKtvHeader);
            this.pnlKtvListCard.FillColor = System.Drawing.Color.White;
            this.pnlKtvListCard.Location = new System.Drawing.Point(1087, 430);
            this.pnlKtvListCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlKtvListCard.Name = "pnlKtvListCard";
            this.pnlKtvListCard.Size = new System.Drawing.Size(400, 508);
            this.pnlKtvListCard.TabIndex = 2;
            // 
            // flpKtvList
            // 
            this.flpKtvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpKtvList.AutoScroll = true;
            this.flpKtvList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpKtvList.Location = new System.Drawing.Point(10, 56);
            this.flpKtvList.Name = "flpKtvList";
            this.flpKtvList.Size = new System.Drawing.Size(380, 442);
            this.flpKtvList.TabIndex = 1;
            this.flpKtvList.WrapContents = false;
            // 
            // pnlKtvHeader
            // 
            this.pnlKtvHeader.BorderRadius = 12;
            this.pnlKtvHeader.Controls.Add(this.lblKtvMeta);
            this.pnlKtvHeader.Controls.Add(this.lblKtvTitle);
            this.pnlKtvHeader.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlKtvHeader.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.pnlKtvHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlKtvHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlKtvHeader.Name = "pnlKtvHeader";
            this.pnlKtvHeader.Size = new System.Drawing.Size(400, 46);
            this.pnlKtvHeader.TabIndex = 0;
            // 
            // lblKtvMeta
            // 
            this.lblKtvMeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKtvMeta.AutoSize = true;
            this.lblKtvMeta.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKtvMeta.ForeColor = System.Drawing.Color.White;
            this.lblKtvMeta.Location = new System.Drawing.Point(269, 16);
            this.lblKtvMeta.Name = "lblKtvMeta";
            this.lblKtvMeta.Size = new System.Drawing.Size(115, 13);
            this.lblKtvMeta.TabIndex = 1;
            this.lblKtvMeta.Text = "Hôm nay, 24/05/2026";
            // 
            // lblKtvTitle
            // 
            this.lblKtvTitle.AutoSize = true;
            this.lblKtvTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblKtvTitle.ForeColor = System.Drawing.Color.White;
            this.lblKtvTitle.Location = new System.Drawing.Point(14, 14);
            this.lblKtvTitle.Name = "lblKtvTitle";
            this.lblKtvTitle.Size = new System.Drawing.Size(183, 17);
            this.lblKtvTitle.TabIndex = 0;
            this.lblKtvTitle.Text = "👨‍🔬 Kỹ thuật viên khả dụng";
            // 
            // ucDieuPhoiKTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.pnlScroll);
            this.Name = "ucDieuPhoiKTV";
            this.Size = new System.Drawing.Size(1507, 958);
            this.pnlScroll.ResumeLayout(false);
            this.pnlServiceRequests.ResumeLayout(false);
            this.pnlServiceRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.pnlAssignForm.ResumeLayout(false);
            this.pnlAssignForm.PerformLayout();
            this.pnlSelRequest.ResumeLayout(false);
            this.pnlSelRequest.PerformLayout();
            this.pnlKtvListCard.ResumeLayout(false);
            this.pnlKtvHeader.ResumeLayout(false);
            this.pnlKtvHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlScroll;
        private Guna.UI2.WinForms.Guna2Panel pnlServiceRequests;
        private System.Windows.Forms.Label lblRequestSub;
        private System.Windows.Forms.Label lblRequestTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cboServiceType;
        private System.Windows.Forms.DataGridView dgvRequests;
        private Guna.UI2.WinForms.Guna2Panel pnlAssignForm;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
        private Guna.UI2.WinForms.Guna2TextBox txtNotes;
        private System.Windows.Forms.Label lblNotesTitle;
        private System.Windows.Forms.Panel pnlTimeSlots;
        private System.Windows.Forms.Label lblTimeSlotsTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlSelRequest;
        private System.Windows.Forms.Label lblSelBN;
        private System.Windows.Forms.Label lblSelDV;
        private System.Windows.Forms.Label lblSelRequestHeader;
        private System.Windows.Forms.Label lblAssignTitle;
        private Guna.UI2.WinForms.Guna2Panel pnlKtvListCard;
        private System.Windows.Forms.FlowLayoutPanel flpKtvList;
        private Guna.UI2.WinForms.Guna2Panel pnlKtvHeader;
        private System.Windows.Forms.Label lblKtvMeta;
        private System.Windows.Forms.Label lblKtvTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHSBA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBenhNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUuTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKTV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThaoTac;
    }
}

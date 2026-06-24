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
            this.pnlScroll.SuspendLayout();
            this.pnlServiceRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Controls.Add(this.pnlServiceRequests);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.pnlScroll.Location = new System.Drawing.Point(0, 0);
            this.pnlScroll.Margin = new System.Windows.Forms.Padding(4);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.Size = new System.Drawing.Size(1453, 958);
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
            this.pnlServiceRequests.Size = new System.Drawing.Size(1413, 918);
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
            this.dgvRequests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
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
            this.dgvRequests.GridColor = System.Drawing.Color.White;
            this.dgvRequests.Location = new System.Drawing.Point(20, 75);
            this.dgvRequests.MultiSelect = false;
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.ReadOnly = true;
            this.dgvRequests.RowHeadersVisible = false;
            this.dgvRequests.RowTemplate.Height = 58;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(1373, 773);
            this.dgvRequests.TabIndex = 4;
            // 
            // colMaDV
            // 
            this.colMaDV.HeaderText = "Mã DV";
            this.colMaDV.Name = "colMaDV";
            this.colMaDV.ReadOnly = true;
            this.colMaDV.Visible = false;
            this.colMaDV.Width = 110;
            // 
            // colMaHSBA
            // 
            this.colMaHSBA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMaHSBA.FillWeight = 145F;
            this.colMaHSBA.MinimumWidth = 140;
            this.colMaHSBA.HeaderText = "MÃ HSBA";
            this.colMaHSBA.Name = "colMaHSBA";
            this.colMaHSBA.ReadOnly = true;
            // 
            // colBenhNhan
            // 
            this.colBenhNhan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colBenhNhan.FillWeight = 180F;
            this.colBenhNhan.MinimumWidth = 160;
            this.colBenhNhan.HeaderText = "BỆNH NHÂN";
            this.colBenhNhan.Name = "colBenhNhan";
            this.colBenhNhan.ReadOnly = true;
            // 
            // colLoaiDV
            // 
            this.colLoaiDV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colLoaiDV.FillWeight = 150F;
            this.colLoaiDV.MinimumWidth = 130;
            this.colLoaiDV.HeaderText = "LOẠI DỊCH VỤ";
            this.colLoaiDV.Name = "colLoaiDV";
            this.colLoaiDV.ReadOnly = true;
            // 
            // colUuTien
            // 
            this.colUuTien.HeaderText = "Ưu tiên";
            this.colUuTien.Name = "colUuTien";
            this.colUuTien.ReadOnly = true;
            this.colUuTien.Visible = false;
            this.colUuTien.Width = 100;
            // 
            // colKTV
            // 
            this.colKTV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colKTV.FillWeight = 160F;
            this.colKTV.MinimumWidth = 130;
            this.colKTV.HeaderText = "KTV PHỤ TRÁCH";
            this.colKTV.Name = "colKTV";
            this.colKTV.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTrangThai.FillWeight = 150F;
            this.colTrangThai.MinimumWidth = 140;
            this.colTrangThai.HeaderText = "TRẠNG THÁI";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colThaoTac
            // 
            this.colThaoTac.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colThaoTac.Width = 140;
            this.colThaoTac.HeaderText = "THAO TÁC";
            this.colThaoTac.Name = "colThaoTac";
            this.colThaoTac.ReadOnly = true;
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
            this.cboStatus.Location = new System.Drawing.Point(1223, 16);
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
            this.cboServiceType.Location = new System.Drawing.Point(1037, 16);
            this.cboServiceType.Name = "cboServiceType";
            this.cboServiceType.Size = new System.Drawing.Size(170, 36);
            this.cboServiceType.StartIndex = 0;
            this.cboServiceType.TabIndex = 2;
            // 
            // 
            // lblRequestSub
            // 
            this.lblRequestSub.AutoSize = true;
            this.lblRequestSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRequestSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblRequestSub.Location = new System.Drawing.Point(48, 44);
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
            this.lblRequestTitle.Location = new System.Drawing.Point(48, 18);
            this.lblRequestTitle.Name = "lblRequestTitle";
            this.lblRequestTitle.Size = new System.Drawing.Size(325, 20);
            this.lblRequestTitle.TabIndex = 0;
            this.lblRequestTitle.Text = "Danh sách yêu cầu dịch vụ hỗ trợ chẩn đoán";
            // 
            // ucDieuPhoiKTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.Controls.Add(this.pnlScroll);
            this.Name = "ucDieuPhoiKTV";
            this.Size = new System.Drawing.Size(1453, 958);
            this.pnlScroll.ResumeLayout(false);
            this.pnlServiceRequests.ResumeLayout(false);
            this.pnlServiceRequests.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
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

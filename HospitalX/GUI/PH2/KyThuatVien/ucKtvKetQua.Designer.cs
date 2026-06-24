namespace HospitalX.GUI.PH2.KyThuatVien
{
    partial class ucKtvKetQua
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlQueue = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlFormContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSimpleTitle = new System.Windows.Forms.Label();
            this.lblSimplePatient = new System.Windows.Forms.Label();
            this.pnlSimpleDivider = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlResultsCard = new Guna.UI2.WinForms.Guna2Panel();
            this.tblSimpleResults = new System.Windows.Forms.TableLayoutPanel();
            this.lblHeaderIndicator = new System.Windows.Forms.Label();
            this.lblHeaderResult = new System.Windows.Forms.Label();
            this.lblDensity = new System.Windows.Forms.Label();
            this.lblLesion = new System.Windows.Forms.Label();
            this.txtDensity = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtLesion = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSimpleConclusion = new System.Windows.Forms.Label();
            this.cboConclusion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblRemarksLabel = new System.Windows.Forms.Label();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnComplete = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRecords = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRecordsTitle = new System.Windows.Forms.Label();
            this.pnlFormContainer.SuspendLayout();
            this.pnlResultsCard.SuspendLayout();
            this.tblSimpleResults.SuspendLayout();
            this.pnlRecords.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlQueue
            // 
            this.pnlQueue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlQueue.BorderRadius = 12;
            this.pnlQueue.BorderThickness = 1;
            this.pnlQueue.FillColor = System.Drawing.Color.White;
            this.pnlQueue.Location = new System.Drawing.Point(28, 28);
            this.pnlQueue.Name = "pnlQueue";
            this.pnlQueue.Size = new System.Drawing.Size(0, 0);
            this.pnlQueue.TabIndex = 0;
            this.pnlQueue.Visible = false;
            // 
            // pnlFormContainer
            // 
            this.pnlFormContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFormContainer.AutoScroll = true;
            this.pnlFormContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlFormContainer.BorderRadius = 12;
            this.pnlFormContainer.BorderThickness = 1;
            this.pnlFormContainer.Controls.Add(this.lblSimpleTitle);
            this.pnlFormContainer.Controls.Add(this.lblSimplePatient);
            this.pnlFormContainer.Controls.Add(this.pnlSimpleDivider);
            this.pnlFormContainer.Controls.Add(this.pnlResultsCard);
            this.pnlFormContainer.Controls.Add(this.lblSimpleConclusion);
            this.pnlFormContainer.Controls.Add(this.cboConclusion);
            this.pnlFormContainer.Controls.Add(this.lblRemarksLabel);
            this.pnlFormContainer.Controls.Add(this.txtRemarks);
            this.pnlFormContainer.Controls.Add(this.btnComplete);
            this.pnlFormContainer.FillColor = System.Drawing.Color.White;
            this.pnlFormContainer.Location = new System.Drawing.Point(363, 28);
            this.pnlFormContainer.Name = "pnlFormContainer";
            this.pnlFormContainer.Size = new System.Drawing.Size(736, 726);
            this.pnlFormContainer.TabIndex = 1;
            // 
            // lblSimpleTitle
            // 
            this.lblSimpleTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimpleTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSimpleTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblSimpleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblSimpleTitle.Location = new System.Drawing.Point(28, 28);
            this.lblSimpleTitle.Name = "lblSimpleTitle";
            this.lblSimpleTitle.Size = new System.Drawing.Size(711, 38);
            this.lblSimpleTitle.TabIndex = 2;
            this.lblSimpleTitle.Text = "Biểu mẫu cập nhật";
            this.lblSimpleTitle.Click += new System.EventHandler(this.lblSimpleTitle_Click);
            // 
            // lblSimplePatient
            // 
            this.lblSimplePatient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSimplePatient.BackColor = System.Drawing.Color.Transparent;
            this.lblSimplePatient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSimplePatient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblSimplePatient.Location = new System.Drawing.Point(28, 74);
            this.lblSimplePatient.Name = "lblSimplePatient";
            this.lblSimplePatient.Size = new System.Drawing.Size(711, 26);
            this.lblSimplePatient.TabIndex = 3;
            this.lblSimplePatient.Text = "Bệnh nhân:";
            // 
            // pnlSimpleDivider
            // 
            this.pnlSimpleDivider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSimpleDivider.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.pnlSimpleDivider.Location = new System.Drawing.Point(28, 122);
            this.pnlSimpleDivider.Name = "pnlSimpleDivider";
            this.pnlSimpleDivider.Size = new System.Drawing.Size(711, 2);
            this.pnlSimpleDivider.TabIndex = 4;
            // 
            // pnlResultsCard
            // 
            this.pnlResultsCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlResultsCard.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlResultsCard.BorderRadius = 10;
            this.pnlResultsCard.BorderThickness = 1;
            this.pnlResultsCard.Controls.Add(this.tblSimpleResults);
            this.pnlResultsCard.FillColor = System.Drawing.Color.White;
            this.pnlResultsCard.Location = new System.Drawing.Point(28, 150);
            this.pnlResultsCard.Name = "pnlResultsCard";
            this.pnlResultsCard.Size = new System.Drawing.Size(711, 139);
            this.pnlResultsCard.TabIndex = 5;
            // 
            // tblSimpleResults
            // 
            this.tblSimpleResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSimpleResults.BackColor = System.Drawing.Color.White;
            this.tblSimpleResults.ColumnCount = 2;
            this.tblSimpleResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43F));
            this.tblSimpleResults.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57F));
            this.tblSimpleResults.Controls.Add(this.lblHeaderIndicator, 0, 0);
            this.tblSimpleResults.Controls.Add(this.lblHeaderResult, 1, 0);
            this.tblSimpleResults.Controls.Add(this.lblDensity, 0, 1);
            this.tblSimpleResults.Controls.Add(this.lblLesion, 0, 2);
            this.tblSimpleResults.Controls.Add(this.txtDensity, 1, 1);
            this.tblSimpleResults.Controls.Add(this.txtLesion, 1, 2);
            this.tblSimpleResults.Location = new System.Drawing.Point(1, 1);
            this.tblSimpleResults.Name = "tblSimpleResults";
            this.tblSimpleResults.RowCount = 3;
            this.tblSimpleResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tblSimpleResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tblSimpleResults.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tblSimpleResults.Size = new System.Drawing.Size(710, 137);
            this.tblSimpleResults.TabIndex = 0;
            // 
            // lblHeaderIndicator
            // 
            this.lblHeaderIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.lblHeaderIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderIndicator.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderIndicator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblHeaderIndicator.Location = new System.Drawing.Point(3, 0);
            this.lblHeaderIndicator.Name = "lblHeaderIndicator";
            this.lblHeaderIndicator.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.lblHeaderIndicator.Size = new System.Drawing.Size(299, 45);
            this.lblHeaderIndicator.TabIndex = 0;
            this.lblHeaderIndicator.Text = "Chỉ số";
            this.lblHeaderIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHeaderResult
            // 
            this.lblHeaderResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(252)))), ((int)(((byte)(253)))));
            this.lblHeaderResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeaderResult.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHeaderResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblHeaderResult.Location = new System.Drawing.Point(308, 0);
            this.lblHeaderResult.Name = "lblHeaderResult";
            this.lblHeaderResult.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.lblHeaderResult.Size = new System.Drawing.Size(399, 45);
            this.lblHeaderResult.TabIndex = 1;
            this.lblHeaderResult.Text = "Kết quả";
            this.lblHeaderResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDensity
            // 
            this.lblDensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDensity.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblDensity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblDensity.Location = new System.Drawing.Point(3, 45);
            this.lblDensity.Name = "lblDensity";
            this.lblDensity.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.lblDensity.Size = new System.Drawing.Size(299, 43);
            this.lblDensity.TabIndex = 2;
            this.lblDensity.Text = "Mật độ/Hình ảnh";
            this.lblDensity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLesion
            // 
            this.lblLesion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLesion.Font = new System.Drawing.Font("Segoe UI", 9.8F);
            this.lblLesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblLesion.Location = new System.Drawing.Point(3, 88);
            this.lblLesion.Name = "lblLesion";
            this.lblLesion.Padding = new System.Windows.Forms.Padding(12, 0, 8, 0);
            this.lblLesion.Size = new System.Drawing.Size(299, 49);
            this.lblLesion.TabIndex = 3;
            this.lblLesion.Text = "Mô tả tổn thương";
            this.lblLesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDensity
            // 
            this.txtDensity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtDensity.BackColor = System.Drawing.Color.Transparent;
            this.txtDensity.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtDensity.BorderRadius = 4;
            this.txtDensity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDensity.DefaultText = "Bình thường";
            this.txtDensity.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDensity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtDensity.Location = new System.Drawing.Point(317, 54);
            this.txtDensity.Margin = new System.Windows.Forms.Padding(12, 6, 0, 0);
            this.txtDensity.Name = "txtDensity";
            this.txtDensity.PlaceholderText = "";
            this.txtDensity.SelectedText = "";
            this.txtDensity.Size = new System.Drawing.Size(230, 30);
            this.txtDensity.TabIndex = 4;
            // 
            // txtLesion
            // 
            this.txtLesion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLesion.BackColor = System.Drawing.Color.Transparent;
            this.txtLesion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtLesion.BorderRadius = 4;
            this.txtLesion.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLesion.DefaultText = "Không có";
            this.txtLesion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtLesion.Location = new System.Drawing.Point(317, 100);
            this.txtLesion.Margin = new System.Windows.Forms.Padding(12, 6, 0, 0);
            this.txtLesion.Name = "txtLesion";
            this.txtLesion.PlaceholderText = "";
            this.txtLesion.SelectedText = "";
            this.txtLesion.Size = new System.Drawing.Size(230, 30);
            this.txtLesion.TabIndex = 5;
            // 
            // lblSimpleConclusion
            // 
            this.lblSimpleConclusion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSimpleConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblSimpleConclusion.Location = new System.Drawing.Point(28, 302);
            this.lblSimpleConclusion.Name = "lblSimpleConclusion";
            this.lblSimpleConclusion.Size = new System.Drawing.Size(656, 24);
            this.lblSimpleConclusion.TabIndex = 6;
            this.lblSimpleConclusion.Text = "Kết luận chung:";
            // 
            // cboConclusion
            // 
            this.cboConclusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboConclusion.BackColor = System.Drawing.Color.Transparent;
            this.cboConclusion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboConclusion.BorderRadius = 6;
            this.cboConclusion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboConclusion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConclusion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboConclusion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboConclusion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboConclusion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.cboConclusion.ItemHeight = 34;
            this.cboConclusion.Location = new System.Drawing.Point(28, 330);
            this.cboConclusion.Name = "cboConclusion";
            this.cboConclusion.Size = new System.Drawing.Size(710, 40);
            this.cboConclusion.TabIndex = 7;
            // 
            // lblRemarksLabel
            // 
            this.lblRemarksLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblRemarksLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblRemarksLabel.Location = new System.Drawing.Point(28, 390);
            this.lblRemarksLabel.Name = "lblRemarksLabel";
            this.lblRemarksLabel.Size = new System.Drawing.Size(656, 24);
            this.lblRemarksLabel.TabIndex = 8;
            this.lblRemarksLabel.Text = "Ghi chú của Kỹ thuật viên (Lưu vào KETQUA):";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BackColor = System.Drawing.Color.Transparent;
            this.txtRemarks.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.txtRemarks.BorderRadius = 6;
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.txtRemarks.Location = new System.Drawing.Point(28, 418);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PlaceholderText = "Nhập nội dung chuyên môn...";
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(711, 124);
            this.txtRemarks.TabIndex = 9;
            // 
            // btnComplete
            // 
            this.btnComplete.BorderRadius = 8;
            this.btnComplete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.Location = new System.Drawing.Point(28, 568);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(170, 45);
            this.btnComplete.TabIndex = 10;
            this.btnComplete.Text = "Xác nhận hoàn tất";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // pnlRecords
            // 
            this.pnlRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlRecords.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlRecords.BorderRadius = 12;
            this.pnlRecords.BorderThickness = 1;
            this.pnlRecords.Controls.Add(this.lblRecordsTitle);
            this.pnlRecords.FillColor = System.Drawing.Color.White;
            this.pnlRecords.Location = new System.Drawing.Point(28, 28);
            this.pnlRecords.Name = "pnlRecords";
            this.pnlRecords.Size = new System.Drawing.Size(318, 726);
            this.pnlRecords.TabIndex = 2;
            // 
            // lblRecordsTitle
            // 
            this.lblRecordsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecordsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblRecordsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblRecordsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(39)))), ((int)(((byte)(51)))));
            this.lblRecordsTitle.Location = new System.Drawing.Point(28, 28);
            this.lblRecordsTitle.Name = "lblRecordsTitle";
            this.lblRecordsTitle.Size = new System.Drawing.Size(274, 72);
            this.lblRecordsTitle.TabIndex = 0;
            this.lblRecordsTitle.Text = "Danh sách hồ sơ bệnh án dịch vụ";
            // 
            // ucKtvKetQua
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(245)))), ((int)(((byte)(243)))));
            this.Controls.Add(this.pnlQueue);
            this.Controls.Add(this.pnlRecords);
            this.Controls.Add(this.pnlFormContainer);
            this.Name = "ucKtvKetQua";
            this.Size = new System.Drawing.Size(1128, 782);
            this.pnlFormContainer.ResumeLayout(false);
            this.pnlResultsCard.ResumeLayout(false);
            this.tblSimpleResults.ResumeLayout(false);
            this.pnlRecords.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Panel pnlQueue;
        private Guna.UI2.WinForms.Guna2Panel pnlFormContainer;
        private Guna.UI2.WinForms.Guna2Panel pnlRecords;
        private System.Windows.Forms.Label lblRecordsTitle;
        private System.Windows.Forms.Label lblSimpleTitle;
        private System.Windows.Forms.Label lblSimplePatient;
        private Guna.UI2.WinForms.Guna2Panel pnlSimpleDivider;
        private Guna.UI2.WinForms.Guna2Panel pnlResultsCard;
        private System.Windows.Forms.TableLayoutPanel tblSimpleResults;
        private System.Windows.Forms.Label lblHeaderIndicator;
        private System.Windows.Forms.Label lblHeaderResult;
        private System.Windows.Forms.Label lblDensity;
        private System.Windows.Forms.Label lblLesion;
        private Guna.UI2.WinForms.Guna2TextBox txtDensity;
        private Guna.UI2.WinForms.Guna2TextBox txtLesion;
        private System.Windows.Forms.Label lblSimpleConclusion;
        private Guna.UI2.WinForms.Guna2Panel pnlPatientStrip;
        private Guna.UI2.WinForms.Guna2Panel cardSvc;
        private Guna.UI2.WinForms.Guna2Panel cardConclusion;
        private Guna.UI2.WinForms.Guna2Panel cardAttachment;
        private Guna.UI2.WinForms.Guna2Panel cardActions;
    }
}

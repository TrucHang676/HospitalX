namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    partial class frmPhanCongKTV
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.borderlessForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlInfo = new Guna.UI2.WinForms.Guna2Panel();
            
            this.lblMaHSBATitle = new System.Windows.Forms.Label();
            this.lblMaHSBAVal = new System.Windows.Forms.Label();
            
            this.lblLoaiDVTitle = new System.Windows.Forms.Label();
            this.lblLoaiDVVal = new System.Windows.Forms.Label();
            
            this.lblNgayDVTitle = new System.Windows.Forms.Label();
            this.lblNgayDVVal = new System.Windows.Forms.Label();

            this.line1 = new System.Windows.Forms.Panel();
            this.line2 = new System.Windows.Forms.Panel();

            this.lblKtvTitle = new System.Windows.Forms.Label();
            this.cboKtv = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnConfirm = new Guna.UI2.WinForms.Guna2Button();

            this.pnlHeader.SuspendLayout();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();

            // 
            // borderlessForm
            // 
            this.borderlessForm.BorderRadius = 16;
            this.borderlessForm.ContainerControl = this;
            this.borderlessForm.TransparentWhileDrag = true;

            // 
            // pnlHeader
            // 
            this.pnlHeader.Size = new System.Drawing.Size(580, 56);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnClose);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "Phân công kỹ thuật viên";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // btnClose
            // 
            this.btnClose.Size = new System.Drawing.Size(36, 32);
            this.btnClose.Location = new System.Drawing.Point(534, 12);
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 8;
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(79)))), ((int)(((byte)(61)))));
            this.btnClose.HoverState.IconColor = System.Drawing.Color.White;

            // 
            // pnlInfo
            // 
            this.pnlInfo.Size = new System.Drawing.Size(540, 140);
            this.pnlInfo.Location = new System.Drawing.Point(20, 76);
            this.pnlInfo.BorderRadius = 8;
            this.pnlInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.pnlInfo.BorderThickness = 1;
            this.pnlInfo.FillColor = System.Drawing.Color.White;
            this.pnlInfo.Controls.Add(this.lblMaHSBATitle);
            this.pnlInfo.Controls.Add(this.lblMaHSBAVal);
            this.pnlInfo.Controls.Add(this.lblLoaiDVTitle);
            this.pnlInfo.Controls.Add(this.lblLoaiDVVal);
            this.pnlInfo.Controls.Add(this.lblNgayDVTitle);
            this.pnlInfo.Controls.Add(this.lblNgayDVVal);
            this.pnlInfo.Controls.Add(this.line1);
            this.pnlInfo.Controls.Add(this.line2);

            // 
            // lblMaHSBATitle
            // 
            this.lblMaHSBATitle.Text = "Mã hồ sơ bệnh án";
            this.lblMaHSBATitle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular);
            this.lblMaHSBATitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblMaHSBATitle.Location = new System.Drawing.Point(20, 16);
            this.lblMaHSBATitle.Size = new System.Drawing.Size(220, 24);
            this.lblMaHSBATitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMaHSBATitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblMaHSBAVal
            // 
            this.lblMaHSBAVal.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHSBAVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.lblMaHSBAVal.Location = new System.Drawing.Point(260, 16);
            this.lblMaHSBAVal.Size = new System.Drawing.Size(260, 24);
            this.lblMaHSBAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMaHSBAVal.BackColor = System.Drawing.Color.Transparent;

            // 
            // line1
            // 
            this.line1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.line1.Location = new System.Drawing.Point(20, 49);
            this.line1.Size = new System.Drawing.Size(500, 1);

            // 
            // lblLoaiDVTitle
            // 
            this.lblLoaiDVTitle.Text = "Dịch vụ hỗ trợ";
            this.lblLoaiDVTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular);
            this.lblLoaiDVTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblLoaiDVTitle.Location = new System.Drawing.Point(20, 58);
            this.lblLoaiDVTitle.Size = new System.Drawing.Size(220, 24);
            this.lblLoaiDVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLoaiDVTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblLoaiDVVal
            // 
            this.lblLoaiDVVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblLoaiDVVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblLoaiDVVal.Location = new System.Drawing.Point(260, 58);
            this.lblLoaiDVVal.Size = new System.Drawing.Size(260, 24);
            this.lblLoaiDVVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLoaiDVVal.BackColor = System.Drawing.Color.Transparent;

            // 
            // line2
            // 
            this.line2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(240)))));
            this.line2.Location = new System.Drawing.Point(20, 91);
            this.line2.Size = new System.Drawing.Size(500, 1);

            // 
            // lblNgayDVTitle
            // 
            this.lblNgayDVTitle.Text = "Ngày thực hiện";
            this.lblNgayDVTitle.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular);
            this.lblNgayDVTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(98)))), ((int)(((byte)(89)))));
            this.lblNgayDVTitle.Location = new System.Drawing.Point(20, 100);
            this.lblNgayDVTitle.Size = new System.Drawing.Size(220, 24);
            this.lblNgayDVTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNgayDVTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblNgayDVVal
            // 
            this.lblNgayDVVal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.25F, System.Drawing.FontStyle.Bold);
            this.lblNgayDVVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(46)))), ((int)(((byte)(39)))));
            this.lblNgayDVVal.Location = new System.Drawing.Point(260, 100);
            this.lblNgayDVVal.Size = new System.Drawing.Size(260, 24);
            this.lblNgayDVVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNgayDVVal.BackColor = System.Drawing.Color.Transparent;

            // 
            // lblKtvTitle
            // 
            this.lblKtvTitle.Text = "CHỌN KỸ THUẬT VIÊN PHỤ TRÁCH";
            this.lblKtvTitle.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKtvTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.lblKtvTitle.Location = new System.Drawing.Point(20, 236);
            this.lblKtvTitle.Size = new System.Drawing.Size(540, 20);
            this.lblKtvTitle.BackColor = System.Drawing.Color.Transparent;

            // 
            // cboKtv
            // 
            this.cboKtv.Size = new System.Drawing.Size(540, 36);
            this.cboKtv.Location = new System.Drawing.Point(20, 256);
            this.cboKtv.BorderRadius = 8;
            this.cboKtv.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(232)))), ((int)(((byte)(226)))));
            this.cboKtv.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKtv.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.cboKtv.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboKtv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.cboKtv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // 
            // 
            // btnConfirm
            // 
            this.btnConfirm.Size = new System.Drawing.Size(260, 42);
            this.btnConfirm.Location = new System.Drawing.Point(160, 330);
            this.btnConfirm.BorderRadius = 8;
            this.btnConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(110)))), ((int)(((byte)(86)))));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Text = "Xác nhận phân công";
            this.btnConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirm.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(82)))), ((int)(((byte)(64)))));
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);



            // 
            // frmPhanCongKTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(580, 400);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cboKtv);
            this.Controls.Add(this.lblKtvTitle);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhanCongKTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Phân công kỹ thuật viên";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderlessForm;
        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2Panel pnlInfo;
        
        private System.Windows.Forms.Label lblMaHSBATitle;
        private System.Windows.Forms.Label lblMaHSBAVal;
        
        private System.Windows.Forms.Label lblLoaiDVTitle;
        private System.Windows.Forms.Label lblLoaiDVVal;
        
        private System.Windows.Forms.Label lblNgayDVTitle;
        private System.Windows.Forms.Label lblNgayDVVal;

        private System.Windows.Forms.Panel line1;
        private System.Windows.Forms.Panel line2;

        private System.Windows.Forms.Label lblKtvTitle;
        private Guna.UI2.WinForms.Guna2ComboBox cboKtv;
        private Guna.UI2.WinForms.Guna2Button btnConfirm;
    }
}

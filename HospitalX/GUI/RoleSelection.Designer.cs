namespace HospitalX.GUI
{
    partial class RoleSelection
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleSelection));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPh2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPh2Patient = new Guna.UI2.WinForms.Guna2Button();
            this.btnPh2Technician = new Guna.UI2.WinForms.Guna2Button();
            this.btnPh2Doctor = new Guna.UI2.WinForms.Guna2Button();
            this.btnPh2Coordinator = new Guna.UI2.WinForms.Guna2Button();
            this.btnPh2Dba = new Guna.UI2.WinForms.Guna2Button();
            this.lblPh2Choose = new System.Windows.Forms.Label();
            this.linePh2 = new System.Windows.Forms.Label();
            this.lblPh2Sub = new System.Windows.Forms.Label();
            this.lblPh2Title = new System.Windows.Forms.Label();
            this.pnlPh2Icon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPh2Icon = new System.Windows.Forms.Label();
            this.pnlPh1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPh1Dba = new Guna.UI2.WinForms.Guna2Button();
            this.lblPh1Choose = new System.Windows.Forms.Label();
            this.linePh1 = new System.Windows.Forms.Label();
            this.lblPh1Sub = new System.Windows.Forms.Label();
            this.lblPh1Title = new System.Windows.Forms.Label();
            this.pnlPh1Icon = new Guna.UI2.WinForms.Guna2Panel();
            this.lblPh1Icon = new System.Windows.Forms.Label();
            this.btnExit = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlRoot.SuspendLayout();
            this.pnlPh2.SuspendLayout();
            this.pnlPh2Icon.SuspendLayout();
            this.pnlPh1.SuspendLayout();
            this.pnlPh1Icon.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 12;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.DarkCyan;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlRoot
            // 
            this.pnlRoot.BackColor = System.Drawing.Color.Transparent;
            this.pnlRoot.BorderRadius = 14;
            this.pnlRoot.Controls.Add(this.pnlPh2);
            this.pnlRoot.Controls.Add(this.pnlPh1);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.FillColor = System.Drawing.Color.White;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(216)))));
            this.pnlRoot.ShadowDecoration.Depth = 8;
            this.pnlRoot.ShadowDecoration.Enabled = true;
            this.pnlRoot.Size = new System.Drawing.Size(1080, 795);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlPh2
            // 
            this.pnlPh2.Controls.Add(this.btnExit);
            this.pnlPh2.Controls.Add(this.btnPh2Patient);
            this.pnlPh2.Controls.Add(this.btnPh2Technician);
            this.pnlPh2.Controls.Add(this.btnPh2Doctor);
            this.pnlPh2.Controls.Add(this.btnPh2Coordinator);
            this.pnlPh2.Controls.Add(this.btnPh2Dba);
            this.pnlPh2.Controls.Add(this.lblPh2Choose);
            this.pnlPh2.Controls.Add(this.linePh2);
            this.pnlPh2.Controls.Add(this.lblPh2Sub);
            this.pnlPh2.Controls.Add(this.lblPh2Title);
            this.pnlPh2.Controls.Add(this.pnlPh2Icon);
            this.pnlPh2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(121)))), ((int)(((byte)(88)))));
            this.pnlPh2.Location = new System.Drawing.Point(520, 0);
            this.pnlPh2.Name = "pnlPh2";
            this.pnlPh2.Size = new System.Drawing.Size(560, 807);
            this.pnlPh2.TabIndex = 1;
            // 
            // btnPh2Patient
            // 
            this.btnPh2Patient.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(167)))), ((int)(((byte)(143)))));
            this.btnPh2Patient.BorderRadius = 10;
            this.btnPh2Patient.BorderThickness = 1;
            this.btnPh2Patient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPh2Patient.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(137)))), ((int)(((byte)(106)))));
            this.btnPh2Patient.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnPh2Patient.ForeColor = System.Drawing.Color.White;
            this.btnPh2Patient.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
            this.btnPh2Patient.Location = new System.Drawing.Point(42, 616);
            this.btnPh2Patient.Name = "btnPh2Patient";
            this.btnPh2Patient.Size = new System.Drawing.Size(432, 84);
            this.btnPh2Patient.TabIndex = 10;
            this.btnPh2Patient.Text = "Bệnh nhân\r\nXem hồ sơ & tiền sử bệnh        →";
            this.btnPh2Patient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPh2Patient.TextOffset = new System.Drawing.Point(22, 0);
            // 
            // btnPh2Technician
            // 
            this.btnPh2Technician.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(167)))), ((int)(((byte)(143)))));
            this.btnPh2Technician.BorderRadius = 10;
            this.btnPh2Technician.BorderThickness = 1;
            this.btnPh2Technician.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPh2Technician.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(137)))), ((int)(((byte)(106)))));
            this.btnPh2Technician.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnPh2Technician.ForeColor = System.Drawing.Color.White;
            this.btnPh2Technician.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
            this.btnPh2Technician.Location = new System.Drawing.Point(42, 518);
            this.btnPh2Technician.Name = "btnPh2Technician";
            this.btnPh2Technician.Size = new System.Drawing.Size(432, 84);
            this.btnPh2Technician.TabIndex = 9;
            this.btnPh2Technician.Text = "Kỹ thuật viên\r\nThực hiện dịch vụ chẩn đoán        →";
            this.btnPh2Technician.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPh2Technician.TextOffset = new System.Drawing.Point(22, 0);
            // 
            // btnPh2Doctor
            // 
            this.btnPh2Doctor.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(167)))), ((int)(((byte)(143)))));
            this.btnPh2Doctor.BorderRadius = 10;
            this.btnPh2Doctor.BorderThickness = 1;
            this.btnPh2Doctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPh2Doctor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(137)))), ((int)(((byte)(106)))));
            this.btnPh2Doctor.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnPh2Doctor.ForeColor = System.Drawing.Color.White;
            this.btnPh2Doctor.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
            this.btnPh2Doctor.Location = new System.Drawing.Point(42, 420);
            this.btnPh2Doctor.Name = "btnPh2Doctor";
            this.btnPh2Doctor.Size = new System.Drawing.Size(432, 84);
            this.btnPh2Doctor.TabIndex = 8;
            this.btnPh2Doctor.Text = "Bác sĩ / Y sĩ\r\nChẩn đoán & điều trị        →";
            this.btnPh2Doctor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPh2Doctor.TextOffset = new System.Drawing.Point(22, 0);
            // 
            // btnPh2Coordinator
            // 
            this.btnPh2Coordinator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(167)))), ((int)(((byte)(143)))));
            this.btnPh2Coordinator.BorderRadius = 10;
            this.btnPh2Coordinator.BorderThickness = 1;
            this.btnPh2Coordinator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPh2Coordinator.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(137)))), ((int)(((byte)(106)))));
            this.btnPh2Coordinator.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnPh2Coordinator.ForeColor = System.Drawing.Color.White;
            this.btnPh2Coordinator.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
            this.btnPh2Coordinator.Location = new System.Drawing.Point(42, 322);
            this.btnPh2Coordinator.Name = "btnPh2Coordinator";
            this.btnPh2Coordinator.Size = new System.Drawing.Size(432, 84);
            this.btnPh2Coordinator.TabIndex = 7;
            this.btnPh2Coordinator.Text = "Điều phối viên\r\nTiếp nhận & điều phối bệnh nhân        →";
            this.btnPh2Coordinator.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPh2Coordinator.TextOffset = new System.Drawing.Point(22, 0);
            // 
            // btnPh2Dba
            // 
            this.btnPh2Dba.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(167)))), ((int)(((byte)(143)))));
            this.btnPh2Dba.BorderRadius = 10;
            this.btnPh2Dba.BorderThickness = 1;
            this.btnPh2Dba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPh2Dba.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(137)))), ((int)(((byte)(106)))));
            this.btnPh2Dba.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnPh2Dba.ForeColor = System.Drawing.Color.White;
            this.btnPh2Dba.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(151)))), ((int)(((byte)(119)))));
            this.btnPh2Dba.Location = new System.Drawing.Point(42, 224);
            this.btnPh2Dba.Name = "btnPh2Dba";
            this.btnPh2Dba.Size = new System.Drawing.Size(432, 84);
            this.btnPh2Dba.TabIndex = 6;
            this.btnPh2Dba.Text = "DBA\r\nQuản trị hệ thống y tế        →";
            this.btnPh2Dba.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPh2Dba.TextOffset = new System.Drawing.Point(22, 0);
            // 
            // lblPh2Choose
            // 
            this.lblPh2Choose.BackColor = System.Drawing.Color.Transparent;
            this.lblPh2Choose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPh2Choose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(211)))), ((int)(((byte)(205)))));
            this.lblPh2Choose.Location = new System.Drawing.Point(42, 172);
            this.lblPh2Choose.Name = "lblPh2Choose";
            this.lblPh2Choose.Size = new System.Drawing.Size(200, 30);
            this.lblPh2Choose.TabIndex = 4;
            this.lblPh2Choose.Text = "CHỌN VAI TRÒ";
            // 
            // linePh2
            // 
            this.linePh2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(167)))), ((int)(((byte)(143)))));
            this.linePh2.Location = new System.Drawing.Point(42, 142);
            this.linePh2.Name = "linePh2";
            this.linePh2.Size = new System.Drawing.Size(60, 3);
            this.linePh2.TabIndex = 3;
            // 
            // lblPh2Sub
            // 
            this.lblPh2Sub.BackColor = System.Drawing.Color.Transparent;
            this.lblPh2Sub.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPh2Sub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(216)))), ((int)(((byte)(210)))));
            this.lblPh2Sub.Location = new System.Drawing.Point(113, 105);
            this.lblPh2Sub.Name = "lblPh2Sub";
            this.lblPh2Sub.Size = new System.Drawing.Size(330, 50);
            this.lblPh2Sub.TabIndex = 2;
            this.lblPh2Sub.Text = "Quản lý dữ liệu y tế";
            // 
            // lblPh2Title
            // 
            this.lblPh2Title.BackColor = System.Drawing.Color.Transparent;
            this.lblPh2Title.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblPh2Title.ForeColor = System.Drawing.Color.White;
            this.lblPh2Title.Location = new System.Drawing.Point(112, 54);
            this.lblPh2Title.Name = "lblPh2Title";
            this.lblPh2Title.Size = new System.Drawing.Size(320, 48);
            this.lblPh2Title.TabIndex = 1;
            this.lblPh2Title.Text = "Phân hệ 2";
            // 
            // pnlPh2Icon
            // 
            this.pnlPh2Icon.BorderRadius = 12;
            this.pnlPh2Icon.Controls.Add(this.lblPh2Icon);
            this.pnlPh2Icon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(145)))), ((int)(((byte)(116)))));
            this.pnlPh2Icon.Location = new System.Drawing.Point(42, 48);
            this.pnlPh2Icon.Name = "pnlPh2Icon";
            this.pnlPh2Icon.Size = new System.Drawing.Size(54, 54);
            this.pnlPh2Icon.TabIndex = 0;
            // 
            // lblPh2Icon
            // 
            this.lblPh2Icon.BackColor = System.Drawing.Color.Transparent;
            this.lblPh2Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPh2Icon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPh2Icon.ForeColor = System.Drawing.Color.White;
            this.lblPh2Icon.Location = new System.Drawing.Point(0, 0);
            this.lblPh2Icon.Name = "lblPh2Icon";
            this.lblPh2Icon.Size = new System.Drawing.Size(54, 54);
            this.lblPh2Icon.TabIndex = 0;
            this.lblPh2Icon.Text = "HX";
            this.lblPh2Icon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlPh1
            // 
            this.pnlPh1.Controls.Add(this.btnPh1Dba);
            this.pnlPh1.Controls.Add(this.lblPh1Choose);
            this.pnlPh1.Controls.Add(this.linePh1);
            this.pnlPh1.Controls.Add(this.lblPh1Sub);
            this.pnlPh1.Controls.Add(this.lblPh1Title);
            this.pnlPh1.Controls.Add(this.pnlPh1Icon);
            this.pnlPh1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(76)))), ((int)(((byte)(132)))));
            this.pnlPh1.Location = new System.Drawing.Point(-10, 0);
            this.pnlPh1.Name = "pnlPh1";
            this.pnlPh1.Size = new System.Drawing.Size(537, 795);
            this.pnlPh1.TabIndex = 0;
            // 
            // btnPh1Dba
            // 
            this.btnPh1Dba.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(135)))), ((int)(((byte)(181)))));
            this.btnPh1Dba.BorderRadius = 10;
            this.btnPh1Dba.BorderThickness = 1;
            this.btnPh1Dba.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPh1Dba.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(100)))), ((int)(((byte)(153)))));
            this.btnPh1Dba.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.btnPh1Dba.ForeColor = System.Drawing.Color.White;
            this.btnPh1Dba.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(114)))), ((int)(((byte)(168)))));
            this.btnPh1Dba.Location = new System.Drawing.Point(42, 224);
            this.btnPh1Dba.Name = "btnPh1Dba";
            this.btnPh1Dba.Size = new System.Drawing.Size(432, 84);
            this.btnPh1Dba.TabIndex = 6;
            this.btnPh1Dba.Text = "DBA\r\nQuản trị viên CSDL        →";
            this.btnPh1Dba.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPh1Dba.TextOffset = new System.Drawing.Point(22, 0);
            // 
            // lblPh1Choose
            // 
            this.lblPh1Choose.BackColor = System.Drawing.Color.Transparent;
            this.lblPh1Choose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPh1Choose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.lblPh1Choose.Location = new System.Drawing.Point(41, 172);
            this.lblPh1Choose.Name = "lblPh1Choose";
            this.lblPh1Choose.Size = new System.Drawing.Size(200, 30);
            this.lblPh1Choose.TabIndex = 4;
            this.lblPh1Choose.Text = "CHỌN VAI TRÒ";
            // 
            // linePh1
            // 
            this.linePh1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(135)))), ((int)(((byte)(181)))));
            this.linePh1.Location = new System.Drawing.Point(42, 142);
            this.linePh1.Name = "linePh1";
            this.linePh1.Size = new System.Drawing.Size(60, 3);
            this.linePh1.TabIndex = 3;
            // 
            // lblPh1Sub
            // 
            this.lblPh1Sub.BackColor = System.Drawing.Color.Transparent;
            this.lblPh1Sub.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPh1Sub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(204)))), ((int)(((byte)(228)))));
            this.lblPh1Sub.Location = new System.Drawing.Point(113, 105);
            this.lblPh1Sub.Name = "lblPh1Sub";
            this.lblPh1Sub.Size = new System.Drawing.Size(330, 40);
            this.lblPh1Sub.TabIndex = 2;
            this.lblPh1Sub.Text = "Quản trị CSDL Oracle";
            // 
            // lblPh1Title
            // 
            this.lblPh1Title.BackColor = System.Drawing.Color.Transparent;
            this.lblPh1Title.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblPh1Title.ForeColor = System.Drawing.Color.White;
            this.lblPh1Title.Location = new System.Drawing.Point(112, 54);
            this.lblPh1Title.Name = "lblPh1Title";
            this.lblPh1Title.Size = new System.Drawing.Size(320, 48);
            this.lblPh1Title.TabIndex = 1;
            this.lblPh1Title.Text = "Phân hệ 1";
            // 
            // pnlPh1Icon
            // 
            this.pnlPh1Icon.BorderRadius = 12;
            this.pnlPh1Icon.Controls.Add(this.lblPh1Icon);
            this.pnlPh1Icon.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(111)))), ((int)(((byte)(164)))));
            this.pnlPh1Icon.Location = new System.Drawing.Point(42, 48);
            this.pnlPh1Icon.Name = "pnlPh1Icon";
            this.pnlPh1Icon.Size = new System.Drawing.Size(54, 54);
            this.pnlPh1Icon.TabIndex = 0;
            // 
            // lblPh1Icon
            // 
            this.lblPh1Icon.BackColor = System.Drawing.Color.Transparent;
            this.lblPh1Icon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPh1Icon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPh1Icon.ForeColor = System.Drawing.Color.White;
            this.lblPh1Icon.Location = new System.Drawing.Point(0, 0);
            this.lblPh1Icon.Name = "lblPh1Icon";
            this.lblPh1Icon.Size = new System.Drawing.Size(54, 54);
            this.lblPh1Icon.TabIndex = 0;
            this.lblPh1Icon.Text = "DB";
            this.lblPh1Icon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderRadius = 15;
            this.btnExit.CustomIconSize = 20F;
            this.btnExit.FillColor = System.Drawing.Color.Transparent;
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.HoverState.FillColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.IconColor = System.Drawing.Color.DarkBlue;
            this.btnExit.Location = new System.Drawing.Point(518, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(33, 32);
            this.btnExit.TabIndex = 15;
            // 
            // RoleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1080, 795);
            this.Controls.Add(this.pnlRoot);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RoleSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HospitalX - Chọn vai trò";
            this.pnlRoot.ResumeLayout(false);
            this.pnlPh2.ResumeLayout(false);
            this.pnlPh2Icon.ResumeLayout(false);
            this.pnlPh1.ResumeLayout(false);
            this.pnlPh1Icon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlRoot;
        private Guna.UI2.WinForms.Guna2Panel pnlPh1;
        private Guna.UI2.WinForms.Guna2Panel pnlPh2;
        private Guna.UI2.WinForms.Guna2Panel pnlPh1Icon;
        private Guna.UI2.WinForms.Guna2Panel pnlPh2Icon;
        private System.Windows.Forms.Label lblPh1Icon;
        private System.Windows.Forms.Label lblPh2Icon;
        private System.Windows.Forms.Label lblPh1Title;
        private System.Windows.Forms.Label lblPh2Title;
        private System.Windows.Forms.Label lblPh1Sub;
        private System.Windows.Forms.Label lblPh2Sub;
        private System.Windows.Forms.Label linePh1;
        private System.Windows.Forms.Label linePh2;
        private System.Windows.Forms.Label lblPh1Choose;
        private System.Windows.Forms.Label lblPh2Choose;
        private Guna.UI2.WinForms.Guna2Button btnPh1Dba;
        private Guna.UI2.WinForms.Guna2Button btnPh2Dba;
        private Guna.UI2.WinForms.Guna2Button btnPh2Coordinator;
        private Guna.UI2.WinForms.Guna2Button btnPh2Doctor;
        private Guna.UI2.WinForms.Guna2Button btnPh2Technician;
        private Guna.UI2.WinForms.Guna2Button btnPh2Patient;
        private Guna.UI2.WinForms.Guna2ControlBox btnExit;
    }
}

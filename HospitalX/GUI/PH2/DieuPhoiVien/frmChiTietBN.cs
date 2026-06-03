using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class frmChiTietBN : Form
    {
        private PatientModel _patient;

        /// <summary>Kết quả hành động khi đóng form.</summary>
        public enum ActionResult { None, EditPatient, ViewHSBA }
        public ActionResult Result { get; private set; } = ActionResult.None;

        public frmChiTietBN()
        {
            InitializeComponent();
        }

        public frmChiTietBN(PatientModel patient) : this()
        {
            _patient = patient;
            LoadPatient();
        }

        private void LoadPatient()
        {
            // Header
            lblName.Text = _patient.Name;
            lblCode.Text = _patient.Id;

            // Info rows — built programmatically using premium Guna2 rounded cards
            int leftX = 28;
            int rightX = 352;
            int colW = 300;

            // Section 1: THÔNG TIN HÀNH CHÍNH & LIÊN LẠC
            AddInfo("Mã bệnh nhân", _patient.Id, leftX, 56, colW, 36, true);
            AddInfo("Số CCCD / Định danh", _patient.Cccd, rightX, 56, colW, 36, true);

            AddInfo("Họ và tên", _patient.Name, leftX, 126, colW, 36, false);
            AddInfo("Ngày sinh", _patient.Dob, rightX, 126, colW, 36, false);

            AddInfo("Giới tính", _patient.Gender, leftX, 196, colW, 36, false);

            string fullAddress = string.IsNullOrEmpty(_patient.SoNha) 
                ? "Chưa cập nhật địa chỉ" 
                : $"{_patient.SoNha}, {_patient.TenDuong}, {_patient.QuanHuyen}, {_patient.TinhTP}";
            AddInfo("Địa chỉ liên lạc", fullAddress, rightX, 196, colW, 72, false, true);

            // Section 2: TIỀN SỬ Y KHOA (Y = 296 - pushed down from 276)
            var lblHistoryHeader = new Label
            {
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(10, 79, 61),
                Location = new Point(28, 296),
                Text = "TIỀN SỬ Y KHOA VÀ DỊ ỨNG",
                BackColor = Color.Transparent,
                AutoSize = true
            };
            pnlInfo.Controls.Add(lblHistoryHeader);

            int fullW = 624;
            AddInfo("Tiền sử bệnh bản thân", string.IsNullOrEmpty(_patient.TienSuBN) ? "Không có ghi nhận tiền sử bệnh lí." : _patient.TienSuBN, leftX, 332, fullW, 64, false, true);
            AddInfo("Tiền sử bệnh gia đình", string.IsNullOrEmpty(_patient.TienSuGD) ? "Không có ghi nhận tiền sử bệnh di truyền." : _patient.TienSuGD, leftX, 432, fullW, 64, false, true);
            AddInfo("Dị ứng thuốc & Hóa chất", string.IsNullOrEmpty(_patient.DiUng) ? "Không có ghi nhận dị ứng thuốc đã biết." : _patient.DiUng, leftX, 532, fullW, 64, false, true);
        }

        private void AddInfo(string label, string value, int x, int y, int w, int h, bool mono, bool multiline = false)
        {
            var lbl = new Label
            {
                Font = new Font("Segoe UI", 8.25F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(x, y),
                Text = label.ToUpper(),
                BackColor = Color.Transparent,
                AutoSize = true
            };

            var card = new Guna.UI2.WinForms.Guna2Panel
            {
                BorderRadius = 8,
                FillColor = Color.FromArgb(244, 247, 246),
                Location = new Point(x, y + 18),
                Size = new Size(w, h),
                BackColor = Color.Transparent
            };

            var lblValue = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font(mono ? "Consolas" : "Segoe UI", 9.75F, mono ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = mono ? Color.FromArgb(15, 110, 86) : Color.FromArgb(24, 48, 42),
                Dock = DockStyle.Fill,
                AutoSize = false,
                Padding = new Padding(12, multiline ? 8 : 0, 12, multiline ? 8 : 0),
                Text = value,
                TextAlign = multiline ? ContentAlignment.TopLeft : ContentAlignment.MiddleLeft
            };

            card.Controls.Add(lblValue);
            pnlInfo.Controls.Add(lbl);
            pnlInfo.Controls.Add(card);
        }


        private static void GetStatusColors(string status, out Color back, out Color fore, out Color dot)
        {
            back = Color.FromArgb(238, 242, 240);
            fore = Color.FromArgb(122, 149, 137);
            dot = fore;
            switch (status)
            {
                case "Đang điều trị":
                    back = Color.FromArgb(230, 244, 240);
                    fore = dot = Color.FromArgb(15, 110, 86);
                    break;
                case "Chờ xét nghiệm":
                    back = Color.FromArgb(255, 243, 224);
                    fore = dot = Color.FromArgb(230, 126, 34);
                    break;
                case "Cần điều phối KTV":
                    back = Color.FromArgb(253, 237, 236);
                    fore = dot = Color.FromArgb(192, 57, 43);
                    break;
                case "Chờ xuất viện":
                    back = Color.FromArgb(235, 245, 251);
                    fore = dot = Color.FromArgb(41, 128, 185);
                    break;
            }
        }

        // ── Button handlers ──
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Result = ActionResult.EditPatient;
            this.Close();
        }



    }
}

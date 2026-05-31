using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class frmPatientDetail : Form
    {
        private ucBenhNhanCuaToi.PatientRecord _patient;

        // Constructor rỗng để Visual Studio Designer render đầy đủ control.
        public frmPatientDetail()
        {
            InitializeComponent();
        }

        public frmPatientDetail(ucBenhNhanCuaToi.PatientRecord patient)
            : this()
        {
            _patient = patient;
            LoadPatient();
        }

        private void LoadPatient()
        {
            lblName.Text = _patient.Name;
            lblCode.Text = _patient.Code;

            AddInfo("Mã bệnh nhân", _patient.Code, 34, 78, true);
            AddInfo("Giới tính", _patient.Gender, 34, 158, false);
            AddInfo("Tuổi", _patient.Age + " tuổi", 238, 158, false);
            AddInfo("Số HSBA", _patient.HsbaCount.ToString(), 34, 238, false);
            AddInfo("Số đơn thuốc", _patient.PrescriptionCount.ToString(), 238, 238, false);
            AddInfo("Quê quán", _patient.Hometown, 34, 318, false);
            AddInfo("CCCD", _patient.Cccd, 34, 398, true);

            flpHsba.Controls.Clear();
            foreach (string hsba in _patient.HsbaList)
            {
                var item = new Guna2Panel
                {
                    BorderColor = Color.FromArgb(218, 232, 226),
                    BorderRadius = 10,
                    BorderThickness = 1,
                    FillColor = Color.FromArgb(247, 249, 248),
                    Margin = new Padding(0, 0, 0, 10),
                    Size = new Size(668, 76)
                };
                var label = new Label
                {
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(24, 48, 42),
                    Location = new Point(18, 15),
                    Size = new Size(620, 44),
                    Text = hsba
                };
                item.Controls.Add(label);
                flpHsba.Controls.Add(item);
            }
        }

        private void AddInfo(string label, string value, int x, int y, bool mono)
        {
            var lbl = new Label
            {
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(x, y),
                Size = new Size(170, 18),
                Text = label.ToUpper()
            };
            var val = new Label
            {
                BackColor = Color.FromArgb(247, 249, 248),
                Font = new Font(mono ? "Consolas" : "Segoe UI", 10F, FontStyle.Bold),
                ForeColor = mono ? Color.FromArgb(15, 110, 86) : Color.FromArgb(24, 48, 42),
                Location = new Point(x, y + 24),
                Padding = new Padding(10, 0, 0, 0),
                Size = new Size(x > 100 ? 150 : 354, 38),
                Text = value,
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlInfo.Controls.Add(lbl);
            pnlInfo.Controls.Add(val);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucBenhNhanCuaToi : UserControl
    {
        private readonly List<PatientRecord> _patients = new List<PatientRecord>();

        public ucBenhNhanCuaToi()
        {
            InitializeComponent();
            SeedPatients();
            ApplyFilters();
        }

        private void SeedPatients()
        {
            _patients.Add(new PatientRecord
            {
                Code = "BN-00341",
                Name = "Nguyễn Văn An",
                Gender = "Nam",
                Age = 52,
                Hometown = "TP.HCM",
                Cccd = "079074012345",
                HsbaCount = 3,
                PrescriptionCount = 2,
                Allergy = "Không có dị ứng thuốc ghi nhận",
                MedicalHistory = "Tăng huyết áp từ năm 2018. Không hút thuốc lá.",
                FamilyHistory = "Cha có tiền sử tăng huyết áp.",
                HsbaList = new List<string>
                {
                    "HSBA-0821 | 21/05/2026 | Tăng huyết áp độ II, rối loạn nhịp tim",
                    "HSBA-0794 | 03/03/2026 | Theo dõi huyết áp định kỳ",
                    "HSBA-0741 | 12/01/2026 | Khám tim mạch tổng quát"
                }
            });
            _patients.Add(new PatientRecord
            {
                Code = "BN-00298",
                Name = "Lê Thị Bích",
                Gender = "Nữ",
                Age = 38,
                Hometown = "Đồng Nai",
                Cccd = "075186002981",
                HsbaCount = 2,
                PrescriptionCount = 1,
                Allergy = "Dị ứng Penicillin",
                MedicalHistory = "Rối loạn nhịp tim kịch phát trên thất, đang theo dõi Holter 24h.",
                FamilyHistory = "Mẹ có tiền sử đái tháo đường type 2.",
                HsbaList = new List<string>
                {
                    "HSBA-0819 | 20/05/2026 | Rối loạn nhịp tim kịch phát",
                    "HSBA-0766 | 18/02/2026 | Đánh giá đau ngực"
                }
            });
            _patients.Add(new PatientRecord
            {
                Code = "BN-00215",
                Name = "Phạm Quốc Hùng",
                Gender = "Nam",
                Age = 67,
                Hometown = "Long An",
                Cccd = "080159002150",
                HsbaCount = 4,
                PrescriptionCount = 3,
                Allergy = "Không ghi nhận",
                MedicalHistory = "Suy tim độ II - NYHA, có tiền sử đái tháo đường type 2.",
                FamilyHistory = "Anh ruột có bệnh mạch vành.",
                HsbaList = new List<string>
                {
                    "HSBA-0815 | 18/05/2026 | Suy tim độ II",
                    "HSBA-0788 | 28/03/2026 | Kiểm tra đường huyết",
                    "HSBA-0730 | 11/01/2026 | Theo dõi suy tim",
                    "HSBA-0699 | 10/11/2025 | Khám nội tim mạch"
                }
            });
            _patients.Add(new PatientRecord
            {
                Code = "BN-00304",
                Name = "Hoàng Thị Xuân",
                Gender = "Nữ",
                Age = 61,
                Hometown = "Bình Dương",
                Cccd = "074161003049",
                HsbaCount = 2,
                PrescriptionCount = 2,
                Allergy = "Dị ứng Aspirin liều cao",
                MedicalHistory = "Nhồi máu cơ tim cũ, đang điều trị ổn định bằng thuốc chống đông.",
                FamilyHistory = "Cha mất do bệnh tim mạch.",
                HsbaList = new List<string>
                {
                    "HSBA-0814 | 17/05/2026 | Nhồi máu cơ tim cũ",
                    "HSBA-0712 | 09/12/2025 | Theo dõi sau can thiệp"
                }
            });
            _patients.Add(new PatientRecord
            {
                Code = "BN-00189",
                Name = "Trần Thị Mai",
                Gender = "Nữ",
                Age = 45,
                Hometown = "Cần Thơ",
                Cccd = "092145001899",
                HsbaCount = 1,
                PrescriptionCount = 1,
                Allergy = "Không ghi nhận",
                MedicalHistory = "Tăng huyết áp kiểm soát tốt.",
                FamilyHistory = "Không ghi nhận bệnh lý di truyền.",
                HsbaList = new List<string>
                {
                    "HSBA-0801 | 12/05/2026 | Tăng huyết áp kiểm soát tốt"
                }
            });
            _patients.Add(new PatientRecord
            {
                Code = "BN-00174",
                Name = "Võ Minh Tuấn",
                Gender = "Nam",
                Age = 29,
                Hometown = "Tây Ninh",
                Cccd = "072199001742",
                HsbaCount = 1,
                PrescriptionCount = 0,
                Allergy = "Không ghi nhận",
                MedicalHistory = "Rối loạn nhịp ngoại tâm thu lành tính.",
                FamilyHistory = "Không ghi nhận.",
                HsbaList = new List<string>
                {
                    "HSBA-0799 | 10/05/2026 | Rối loạn nhịp ngoại tâm thu"
                }
            });
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();
            string gender = cmbGender.SelectedItem == null ? "Tất cả giới tính" : cmbGender.SelectedItem.ToString();

            var filtered = _patients.Where(p =>
                (gender == "Tất cả giới tính" || p.Gender == gender) &&
                (string.IsNullOrWhiteSpace(keyword) ||
                 p.Name.ToLowerInvariant().Contains(keyword) ||
                 p.Code.ToLowerInvariant().Contains(keyword)))
                .ToList();

            dgvPatients.Rows.Clear();
            foreach (PatientRecord patient in filtered)
            {
                int rowIndex = dgvPatients.Rows.Add(
                    patient.Name + Environment.NewLine + patient.Code,
                    patient.Gender,
                    patient.Age,
                    patient.HsbaCount,
                    patient.PrescriptionCount,
                    patient.Hometown,
                    "Xem chi tiết",
                    "Tiền sử bệnh");
                dgvPatients.Rows[rowIndex].Tag = patient;
            }

            lblCount.Text = filtered.Count + " bệnh nhân";
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            PatientRecord patient = dgvPatients.Rows[e.RowIndex].Tag as PatientRecord;
            if (patient == null)
            {
                return;
            }

            if (dgvPatients.Columns[e.ColumnIndex].Name == "colDetail")
            {
                using (var frm = new frmPatientDetail(patient))
                {
                    frm.ShowDialog(FindForm());
                }
            }
            else if (dgvPatients.Columns[e.ColumnIndex].Name == "colHistory")
            {
                using (var frm = new frmPatientHistory(patient))
                {
                    frm.ShowDialog(FindForm());
                }
            }
        }

        public class PatientRecord
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public int HsbaCount { get; set; }
            public int PrescriptionCount { get; set; }
            public string Hometown { get; set; }
            public string Cccd { get; set; }
            public string Allergy { get; set; }
            public string MedicalHistory { get; set; }
            public string FamilyHistory { get; set; }
            public List<string> HsbaList { get; set; }
        }
    }
}

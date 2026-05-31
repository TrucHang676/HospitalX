using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucHSBA : UserControl
    {
        private readonly List<HsbaRecord> _records = new List<HsbaRecord>();
        private bool _isLoaded;

        public ucHSBA()
        {
            InitializeComponent();
        }

        private void ucHSBA_Load(object sender, EventArgs e)
        {
            if (_isLoaded)
            {
                return;
            }

            _isLoaded = true;
            SeedData();
            WireEvents();
            ApplyFilters();
        }

        // Gắn event cho tìm kiếm, lọc thời gian và sắp xếp.
        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbSort.SelectedIndexChanged += (s, e) => ApplyFilters();
            dtpFrom.ValueChanged += (s, e) => ApplyFilters();
            dtpTo.ValueChanged += (s, e) => ApplyFilters();
            cmbDateRange.SelectedIndexChanged += (s, e) =>
            {
                bool custom = cmbDateRange.SelectedItem != null && cmbDateRange.SelectedItem.ToString() == "Tùy chọn";
                dtpFrom.Enabled = custom;
                dtpTo.Enabled = custom;
                ApplyFilters();
            };
            flpHsbaList.Resize += (s, e) => ResizeCards();
        }

        // Dữ liệu demo để giao diện có thể chạy và test chức năng ngay.
        private void SeedData()
        {
            if (_records.Count > 0)
            {
                return;
            }

            _records.Add(new HsbaRecord
            {
                Id = "HSBA-0821",
                PatientCode = "BN-00341",
                PatientName = "Nguyễn Văn An",
                Gender = "Nam",
                Age = 52,
                Department = "Khoa Tim Mạch",
                CreatedDate = new DateTime(2026, 5, 21),
                BirthDate = "15/03/1974",
                CitizenId = "079074012345",
                Address = "Q.1, TP.HCM",
                Allergy = "Không có dị ứng thuốc ghi nhận",
                MedicalHistory = "Tăng huyết áp từ năm 2018. Không hút thuốc lá.",
                Diagnosis = "Tăng huyết áp độ II, rối loạn nhịp tim kèm khó thở khi gắng sức.",
                Treatment = "Amlodipine 5mg, Bisoprolol 2.5mg. Theo dõi huyết áp tại nhà.",
                Conclusion = "(Chưa có kết luận - bệnh nhân đang điều trị)",
                Services = new List<string> { "Siêu âm tim - Chờ kết quả", "Xét nghiệm máu tổng quát - Có kết quả" },
                Prescriptions = new List<string> { "Amlodipine 5mg - 1 viên/ngày, sáng sau ăn", "Bisoprolol 2.5mg - 1 viên/ngày, sáng trước ăn" }
            });
            _records.Add(new HsbaRecord
            {
                Id = "HSBA-0819",
                PatientCode = "BN-00298",
                PatientName = "Lê Thị Bích",
                Gender = "Nữ",
                Age = 38,
                Department = "Khoa Tim Mạch",
                CreatedDate = new DateTime(2026, 5, 20),
                BirthDate = "09/10/1988",
                CitizenId = "079088004512",
                Address = "Q.7, TP.HCM",
                Allergy = "Chưa ghi nhận",
                MedicalHistory = "Đã từng hồi hộp đánh trống ngực khi gắng sức.",
                Diagnosis = "Rối loạn nhịp tim kịch phát trên thất, cần theo dõi Holter 24h.",
                Treatment = "Theo dõi nhịp tim, hạn chế caffeine, tái khám khi có kết quả Holter.",
                Conclusion = "(Chờ kết quả xét nghiệm hỗ trợ)",
                Services = new List<string> { "Holter điện tim 24h - Chờ kết quả" },
                Prescriptions = new List<string> { "Magnesium B6 - 2 viên/ngày" }
            });
            _records.Add(new HsbaRecord
            {
                Id = "HSBA-0815",
                PatientCode = "BN-00215",
                PatientName = "Phạm Quốc Hùng",
                Gender = "Nam",
                Age = 67,
                Department = "Khoa Tim Mạch",
                CreatedDate = new DateTime(2026, 5, 18),
                BirthDate = "22/04/1959",
                CitizenId = "079059002151",
                Address = "TP. Thủ Đức, TP.HCM",
                Allergy = "Dị ứng Penicillin",
                MedicalHistory = "Đái tháo đường type 2, tăng huyết áp lâu năm.",
                Diagnosis = "Suy tim độ II - NYHA, có tiền sử đái tháo đường type 2.",
                Treatment = "Điều chỉnh lợi tiểu, kiểm soát đường huyết và theo dõi CT tim.",
                Conclusion = "(Chờ kết quả CT tim)",
                Services = new List<string> { "CT tim - Chờ kết quả", "Xét nghiệm HbA1c - Có kết quả" },
                Prescriptions = new List<string> { "Furosemide 40mg - 1 viên buổi sáng", "Metformin 500mg - 2 viên/ngày" }
            });
            _records.Add(new HsbaRecord
            {
                Id = "HSBA-0814",
                PatientCode = "BN-00304",
                PatientName = "Hoàng Thị Xuân",
                Gender = "Nữ",
                Age = 61,
                Department = "Khoa Tim Mạch",
                CreatedDate = new DateTime(2026, 5, 17),
                BirthDate = "11/08/1965",
                CitizenId = "079065003041",
                Address = "Q. Bình Thạnh, TP.HCM",
                Allergy = "Không ghi nhận",
                MedicalHistory = "Nhồi máu cơ tim cũ, đang dùng thuốc chống đông.",
                Diagnosis = "Nhồi máu cơ tim cũ, đang điều trị ổn định bằng thuốc chống đông.",
                Treatment = "Duy trì thuốc chống đông, theo dõi INR và lipid máu.",
                Conclusion = "(Đang theo dõi)",
                Services = new List<string> { "Điện tim - Có kết quả" },
                Prescriptions = new List<string> { "Warfarin 2mg - theo chỉ định", "Atorvastatin 20mg - 1 viên buổi tối" }
            });
            _records.Add(new HsbaRecord
            {
                Id = "HSBA-0801",
                PatientCode = "BN-00189",
                PatientName = "Trần Thị Mai",
                Gender = "Nữ",
                Age = 45,
                Department = "Khoa Tim Mạch",
                CreatedDate = new DateTime(2026, 5, 12),
                BirthDate = "03/12/1981",
                CitizenId = "079081001891",
                Address = "Q.3, TP.HCM",
                Allergy = "Không ghi nhận",
                MedicalHistory = "Tăng huyết áp nhẹ.",
                Diagnosis = "Tăng huyết áp kiểm soát tốt.",
                Treatment = "Tiếp tục thuốc duy trì, ăn nhạt, vận động đều.",
                Conclusion = "Tăng huyết áp kiểm soát tốt, tái khám sau 1 tháng.",
                Services = new List<string> { "Xét nghiệm máu - Có kết quả" },
                Prescriptions = new List<string> { "Losartan 50mg - 1 viên/ngày" }
            });
            _records.Add(new HsbaRecord
            {
                Id = "HSBA-0799",
                PatientCode = "BN-00174",
                PatientName = "Võ Minh Tuấn",
                Gender = "Nam",
                Age = 29,
                Department = "Khoa Tim Mạch",
                CreatedDate = new DateTime(2026, 5, 10),
                BirthDate = "19/01/1997",
                CitizenId = "079097001741",
                Address = "Q. Tân Bình, TP.HCM",
                Allergy = "Không ghi nhận",
                MedicalHistory = "Không có bệnh nền đáng kể.",
                Diagnosis = "Rối loạn nhịp ngoại tâm thu lành tính.",
                Treatment = "Trấn an, giảm chất kích thích, theo dõi triệu chứng.",
                Conclusion = "Không cần can thiệp thêm.",
                Services = new List<string> { "Điện tim - Có kết quả" },
                Prescriptions = new List<string> { "Không kê thuốc" }
            });
        }

        private void ApplyFilters()
        {
            IEnumerable<HsbaRecord> query = _records;
            string keyword = RemoveVietnameseTone(txtSearch.Text.Trim()).ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(r =>
                    RemoveVietnameseTone(r.Id).ToLowerInvariant().Contains(keyword) ||
                    RemoveVietnameseTone(r.PatientName).ToLowerInvariant().Contains(keyword) ||
                    RemoveVietnameseTone(r.PatientCode).ToLowerInvariant().Contains(keyword));
            }

            DateTime fromDate;
            DateTime toDate;
            GetDateRange(out fromDate, out toDate);
            query = query.Where(r => r.CreatedDate.Date >= fromDate.Date && r.CreatedDate.Date <= toDate.Date);

            if (cmbSort.SelectedItem != null && cmbSort.SelectedItem.ToString().Contains("Cũ nhất"))
            {
                query = query.OrderBy(r => r.CreatedDate);
            }
            else
            {
                query = query.OrderByDescending(r => r.CreatedDate);
            }

            List<HsbaRecord> filtered = query.ToList();
            lblResultCount.Text = "Tìm thấy " + filtered.Count + " hồ sơ bệnh án";
            RenderCards(filtered);
        }

        private void GetDateRange(out DateTime fromDate, out DateTime toDate)
        {
            DateTime maxDate = _records.Count == 0 ? DateTime.Today : _records.Max(r => r.CreatedDate);
            string mode = cmbDateRange.SelectedItem == null ? "Tháng này" : cmbDateRange.SelectedItem.ToString();

            if (mode == "Tất cả")
            {
                fromDate = DateTime.MinValue;
                toDate = DateTime.MaxValue;
                return;
            }

            if (mode == "7 ngày gần đây")
            {
                fromDate = maxDate.AddDays(-6);
                toDate = maxDate;
                return;
            }

            if (mode == "Tùy chọn")
            {
                fromDate = dtpFrom.Value.Date <= dtpTo.Value.Date ? dtpFrom.Value.Date : dtpTo.Value.Date;
                toDate = dtpFrom.Value.Date <= dtpTo.Value.Date ? dtpTo.Value.Date : dtpFrom.Value.Date;
                return;
            }

            fromDate = new DateTime(maxDate.Year, maxDate.Month, 1);
            toDate = fromDate.AddMonths(1).AddDays(-1);
        }

        private void RenderCards(List<HsbaRecord> records)
        {
            flpHsbaList.SuspendLayout();
            flpHsbaList.Controls.Clear();

            if (records.Count == 0)
            {
                Label empty = new Label
                {
                    AutoSize = false,
                    Width = Math.Max(400, flpHsbaList.ClientSize.Width - 28),
                    Height = 90,
                    Text = "Không tìm thấy hồ sơ bệnh án phù hợp.",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(122, 149, 137),
                    TextAlign = ContentAlignment.MiddleCenter
                };
                flpHsbaList.Controls.Add(empty);
                flpHsbaList.ResumeLayout();
                return;
            }

            foreach (HsbaRecord record in records)
            {
                flpHsbaList.Controls.Add(CreateCard(record));
            }

            flpHsbaList.ResumeLayout();
        }

        private Guna2Panel CreateCard(HsbaRecord record)
        {
            int cardWidth = Math.Max(780, flpHsbaList.ClientSize.Width - 28);
            Guna2Panel card = new Guna2Panel
            {
                Width = cardWidth,
                Height = 154,
                Margin = new Padding(0, 0, 0, 12),
                BorderRadius = 10,
                BorderThickness = 1,
                BorderColor = Color.FromArgb(218, 232, 226),
                FillColor = Color.White,
                Tag = record
            };
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Color = Color.FromArgb(220, 236, 230);
            card.ShadowDecoration.Depth = 8;
            card.MouseEnter += (s, e) => card.BorderColor = Color.FromArgb(26, 148, 112);
            card.MouseLeave += (s, e) => card.BorderColor = Color.FromArgb(218, 232, 226);

            Panel accent = new Panel
            {
                BackColor = Color.FromArgb(15, 110, 86),
                Location = new Point(0, 0),
                Size = new Size(4, card.Height),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom
            };

            Label lblId = new Label
            {
                AutoSize = false,
                Location = new Point(26, 18),
                Size = new Size(120, 28),
                BackColor = Color.FromArgb(230, 244, 240),
                ForeColor = Color.FromArgb(15, 110, 86),
                Font = new Font("Consolas", 9.5F, FontStyle.Bold),
                Text = record.Id,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblDate = new Label
            {
                AutoSize = false,
                Location = new Point(156, 19),
                Size = new Size(110, 24),
                ForeColor = Color.FromArgb(122, 149, 137),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = record.CreatedDate.ToString("dd/MM/yyyy"),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblName = new Label
            {
                AutoSize = false,
                Location = new Point(26, 52),
                Size = new Size(340, 26),
                ForeColor = Color.FromArgb(24, 48, 42),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Text = record.PatientName,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblMeta = new Label
            {
                AutoSize = false,
                Location = new Point(26, 78),
                Size = new Size(650, 22),
                ForeColor = Color.FromArgb(122, 149, 137),
                Font = new Font("Segoe UI", 9F),
                Text = string.Format("{0}  ·  {1}  ·  {2} tuổi  ·  {3}", record.PatientCode, record.Gender, record.Age, record.Department),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblDiagnosis = new Label
            {
                AutoSize = false,
                Location = new Point(26, 106),
                Size = new Size(cardWidth - 405, 32),
                ForeColor = Color.FromArgb(61, 82, 73),
                Font = new Font("Segoe UI", 9.2F),
                Text = "Chẩn đoán: " + record.Diagnosis,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Guna2Button btnDetail = CreateActionButton("Xem chi tiết", Color.FromArgb(15, 110, 86), Color.White);
            btnDetail.Location = new Point(cardWidth - 350, 28);
            btnDetail.Click += (s, e) => OpenDetail(record);

            Guna2Button btnService = CreateActionButton("Thêm dịch vụ", Color.White, Color.FromArgb(15, 110, 86));
            btnService.BorderThickness = 1;
            btnService.BorderColor = Color.FromArgb(15, 110, 86);
            btnService.Location = new Point(cardWidth - 230, 28);
            btnService.Click += (s, e) => OpenService(record);

            Guna2Button btnPrescription = CreateActionButton("Thêm đơn thuốc", Color.White, Color.FromArgb(15, 110, 86));
            btnPrescription.BorderThickness = 1;
            btnPrescription.BorderColor = Color.FromArgb(15, 110, 86);
            btnPrescription.Size = new Size(140, 36);
            btnPrescription.Location = new Point(cardWidth - 150, 80);
            btnPrescription.Click += (s, e) => OpenPrescription(record);

            card.Controls.Add(accent);
            card.Controls.Add(lblId);
            card.Controls.Add(lblDate);
            card.Controls.Add(lblName);
            card.Controls.Add(lblMeta);
            card.Controls.Add(lblDiagnosis);
            card.Controls.Add(btnDetail);
            card.Controls.Add(btnService);
            card.Controls.Add(btnPrescription);
            return card;
        }

        private Guna2Button CreateActionButton(string text, Color fill, Color fore)
        {
            Guna2Button button = new Guna2Button
            {
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                FillColor = fill,
                ForeColor = fore,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Size = new Size(110, 36),
                Text = text
            };
            button.HoverState.FillColor = fill == Color.White ? Color.FromArgb(230, 244, 240) : Color.FromArgb(26, 148, 112);
            button.HoverState.ForeColor = fill == Color.White ? Color.FromArgb(10, 79, 61) : Color.White;
            button.HoverState.BorderColor = Color.FromArgb(26, 148, 112);
            button.PressedColor = Color.FromArgb(10, 79, 61);
            button.DisabledState.FillColor = Color.FromArgb(238, 242, 240);
            button.DisabledState.ForeColor = Color.FromArgb(122, 149, 137);
            button.DisabledState.BorderColor = Color.FromArgb(196, 208, 203);
            button.CheckedState.FillColor = Color.FromArgb(15, 110, 86);
            button.CheckedState.ForeColor = Color.White;
            return button;
        }

        private void ResizeCards()
        {
            int cardWidth = Math.Max(780, flpHsbaList.ClientSize.Width - 28);
            foreach (Control control in flpHsbaList.Controls)
            {
                control.Width = cardWidth;
            }
        }

        private void OpenDetail(HsbaRecord record)
        {
            using (frmHSBADetail form = new frmHSBADetail(record))
            {
                form.ShowDialog(this);
            }
            ApplyFilters();
        }

        private void OpenService(HsbaRecord record)
        {
            using (frmHSBAService form = new frmHSBAService(record))
            {
                form.ShowDialog(this);
            }
            ApplyFilters();
        }

        private void OpenPrescription(HsbaRecord record)
        {
            using (frmHSBAPrescription form = new frmHSBAPrescription(record))
            {
                form.ShowDialog(this);
            }
            ApplyFilters();
        }

        private static string RemoveVietnameseTone(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }

            string[] signs = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                {
                    text = text.Replace(signs[i][j], signs[0][i - 1]);
                }
            }

            return text;
        }

        public class HsbaRecord
        {
            public string Id { get; set; }
            public string PatientCode { get; set; }
            public string PatientName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string Department { get; set; }
            public DateTime CreatedDate { get; set; }
            public string BirthDate { get; set; }
            public string CitizenId { get; set; }
            public string Address { get; set; }
            public string Allergy { get; set; }
            public string MedicalHistory { get; set; }
            public string Diagnosis { get; set; }
            public string Treatment { get; set; }
            public string Conclusion { get; set; }
            public List<string> Services { get; set; }
            public List<string> Prescriptions { get; set; }
        }
    }
}

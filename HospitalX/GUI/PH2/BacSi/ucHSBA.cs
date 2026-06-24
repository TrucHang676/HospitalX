using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HospitalX.DAO;

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

        // Tải dữ liệu bệnh án thực tế từ CSDL.
        private void SeedData()
        {
            _records.Clear();

            try
            {
                DataTable dt = HsbaDAO.GetHsbaForDoctor();
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string maHsba = row["MAHSBA"]?.ToString() ?? string.Empty;
                        string maBn = row["MABN"]?.ToString() ?? string.Empty;
                        string tenBn = row["TEN_BENH_NHAN"]?.ToString() ?? string.Empty;
                        string phai = row["GIOI_TINH"]?.ToString() ?? string.Empty;
                        
                        DateTime ngaySinh = DateTime.Today;
                        if (row["NGAYSINH"] != DBNull.Value)
                        {
                            ngaySinh = Convert.ToDateTime(row["NGAYSINH"]);
                        }
                        int age = DateTime.Today.Year - ngaySinh.Year;
                        string birthDate = ngaySinh.ToString("dd/MM/yyyy");

                        string cccd = row["CCCD"]?.ToString() ?? string.Empty;
                        
                        string sonha = row["SONHA"]?.ToString() ?? string.Empty;
                        string tenduong = row["TENDUONG"]?.ToString() ?? string.Empty;
                        string quanhuyen = row["QUANHUYEN"]?.ToString() ?? string.Empty;
                        string tinhtp = row["TINHTP"]?.ToString() ?? string.Empty;
                        
                        string addressList = "";
                        if (!string.IsNullOrEmpty(sonha)) addressList += sonha + " ";
                        if (!string.IsNullOrEmpty(tenduong)) addressList += tenduong + ", ";
                        if (!string.IsNullOrEmpty(quanhuyen)) addressList += quanhuyen + ", ";
                        if (!string.IsNullOrEmpty(tinhtp)) addressList += tinhtp;
                        string address = addressList.Trim().TrimEnd(',');

                        string diungthuoc = row["DIUNGTHUOC"]?.ToString() ?? "Chưa ghi nhận";
                        string tiensubenh = row["TIENSUBENH"]?.ToString() ?? "Không có";

                        DateTime ngay = DateTime.Today;
                        if (row["NGAY"] != DBNull.Value)
                        {
                            ngay = Convert.ToDateTime(row["NGAY"]);
                        }

                        string chanDoan = row["CHANDOAN"]?.ToString() ?? string.Empty;
                        string dieuTri = row["DIEUTRI"]?.ToString() ?? string.Empty;
                        string ketLuan = row["KETLUAN"]?.ToString() ?? string.Empty;
                        string khoa = row["MAKHOA"]?.ToString() ?? string.Empty;

                        // Fetch services and prescriptions
                        List<string> services = new List<string>();
                        DataTable dtServices = HsbaDAO.GetServicesForHsba(maHsba);
                        if (dtServices != null)
                        {
                            foreach (DataRow sRow in dtServices.Rows)
                            {
                                string loai = sRow["LOAIDV"]?.ToString() ?? string.Empty;
                                string kq = sRow["KETQUA"]?.ToString() ?? string.Empty;
                                services.Add(loai + (!string.IsNullOrEmpty(kq) ? " - " + kq : ""));
                            }
                        }

                        List<string> prescriptions = new List<string>();
                        DataTable dtPrescriptions = HsbaDAO.GetPrescriptionsForHsba(maHsba);
                        if (dtPrescriptions != null)
                        {
                            foreach (DataRow pRow in dtPrescriptions.Rows)
                            {
                                string thuoc = pRow["TENTHUOC"]?.ToString() ?? string.Empty;
                                string lieu = pRow["LIEUDUNG"]?.ToString() ?? string.Empty;
                                prescriptions.Add(thuoc + (!string.IsNullOrEmpty(lieu) ? " - " + lieu : ""));
                            }
                        }

                        _records.Add(new HsbaRecord
                        {
                            Id = maHsba,
                            PatientCode = maBn,
                            PatientName = tenBn,
                            Gender = phai,
                            Age = age,
                            Department = khoa,
                            CreatedDate = ngay,
                            BirthDate = birthDate,
                            CitizenId = cccd,
                            Address = address,
                            Allergy = diungthuoc,
                            MedicalHistory = tiensubenh,
                            Diagnosis = chanDoan,
                            Treatment = dieuTri,
                            Conclusion = ketLuan,
                            Services = services,
                            Prescriptions = prescriptions
                        });
                    }
                }
            }
            catch (Exception)
            {
                // Graceful fallback
            }
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
            BeginInvoke(new Action(ResizeCards));
        }

        private Guna2Panel CreateCard(HsbaRecord record)
        {
            int cardWidth = GetCardWidth();
            Guna2Panel card = new Guna2Panel
            {
                Width = cardWidth,
                Height = 172,
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
                Location = new Point(26, 56),
                Size = new Size(340, 26),
                ForeColor = Color.FromArgb(24, 48, 42),
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Text = record.PatientName,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblMeta = new Label
            {
                AutoSize = false,
                Location = new Point(26, 88),
                Size = new Size(650, 22),
                ForeColor = Color.FromArgb(122, 149, 137),
                Font = new Font("Segoe UI", 9F),
                Text = string.Format("{0}  ·  {1}  ·  {2} tuổi  ·  {3}", record.PatientCode, record.Gender, record.Age, record.Department),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label lblDiagnosis = new Label
            {
                AutoSize = false,
                Location = new Point(26, 120),
                Name = "lblDiagnosis",
                Size = new Size(Math.Max(360, cardWidth - 430), 32),
                ForeColor = Color.FromArgb(61, 82, 73),
                Font = new Font("Segoe UI", 9.2F),
                Text = "Chẩn đoán: " + record.Diagnosis,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Guna2Button btnDetail = CreateActionButton("Xem chi tiết", Color.FromArgb(15, 110, 86), Color.White);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(150, 40);
            btnDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetail.Click += (s, e) => OpenDetail(record);

            Guna2Button btnService = CreateActionButton("Thêm dịch vụ", Color.White, Color.FromArgb(15, 110, 86));
            btnService.Name = "btnService";
            btnService.Size = new Size(150, 40);
            btnService.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnService.BorderThickness = 1;
            btnService.BorderColor = Color.FromArgb(15, 110, 86);
            btnService.Click += (s, e) => OpenService(record);

            Guna2Button btnPrescription = CreateActionButton("Thêm đơn thuốc", Color.White, Color.FromArgb(15, 110, 86));
            btnPrescription.Name = "btnPrescription";
            btnPrescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrescription.BorderThickness = 1;
            btnPrescription.BorderColor = Color.FromArgb(15, 110, 86);
            btnPrescription.Size = new Size(172, 40);
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
            LayoutCard(card);
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
            int cardWidth = GetCardWidth();
            foreach (Control control in flpHsbaList.Controls)
            {
                control.Width = cardWidth;
                Guna2Panel card = control as Guna2Panel;
                if (card != null)
                {
                    LayoutCard(card);
                }
            }
        }

        private int GetCardWidth()
        {
            return Math.Max(780, flpHsbaList.Width - flpHsbaList.Padding.Horizontal - 28);
        }

        private void LayoutCard(Guna2Panel card)
        {
            Control lblDiagnosis = card.Controls["lblDiagnosis"];
            Control btnDetail = card.Controls["btnDetail"];
            Control btnService = card.Controls["btnService"];
            Control btnPrescription = card.Controls["btnPrescription"];

            if (btnDetail == null || btnService == null || btnPrescription == null)
            {
                return;
            }

            const int rightPadding = 24;
            const int gap = 14;
            int right = card.Width - rightPadding;
            int actionsWidth = btnDetail.Width + btnService.Width + btnPrescription.Width + gap * 2;
            int actionsLeft = right - actionsWidth;
            int buttonTop = 58;

            btnDetail.Location = new Point(actionsLeft, buttonTop);
            btnService.Location = new Point(btnDetail.Right + gap, buttonTop);
            btnPrescription.Location = new Point(btnService.Right + gap, buttonTop);

            if (lblDiagnosis != null)
            {
                lblDiagnosis.Width = Math.Max(360, actionsLeft - lblDiagnosis.Left - 24);
            }
        }

        private void OpenDetail(HsbaRecord record)
        {
            using (frmHSBADetail form = new frmHSBADetail(record))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    SeedData();
                }
            }
            ApplyFilters();
        }

        private void OpenService(HsbaRecord record)
        {
            using (frmHSBAService form = new frmHSBAService(record))
            {
                form.ShowDialog(this);
            }
            SeedData();
            ApplyFilters();
        }

        private void OpenPrescription(HsbaRecord record)
        {
            using (frmHSBAPrescription form = new frmHSBAPrescription(record))
            {
                form.ShowDialog(this);
            }
            SeedData();
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

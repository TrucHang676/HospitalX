using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BacSi
{
    public partial class ucDonThuoc : UserControl
    {
        private readonly List<PrescriptionRecord> _prescriptions = new List<PrescriptionRecord>();
        private bool _isLoaded;

        public ucDonThuoc()
        {
            InitializeComponent();
        }

        private void ucDonThuoc_Load(object sender, EventArgs e)
        {
            if (_isLoaded)
            {
                return;
            }

            _isLoaded = true;
            LoadPrescriptionsFromDatabase();
            WireEvents();
            ApplyFilters();
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (s, e) => ApplyFilters();
            cmbDateRange.SelectedIndexChanged += (s, e) =>
            {
                bool custom = cmbDateRange.SelectedItem != null && cmbDateRange.SelectedItem.ToString() == "Tùy chọn";
                dtpFrom.Enabled = custom;
                dtpTo.Enabled = custom;
                ApplyFilters();
            };
            dtpFrom.ValueChanged += (s, e) => ApplyFilters();
            dtpTo.ValueChanged += (s, e) => ApplyFilters();
            cmbSort.SelectedIndexChanged += (s, e) => ApplyFilters();
            flpPrescriptionList.Resize += (s, e) => ResizeCards();
        }

        private void LoadPrescriptionsFromDatabase()
        {
            _prescriptions.Clear();
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.PrescriptionDAO.GetPrescriptionsForDoctor();
                if (dt != null)
                {
                    var dict = new Dictionary<string, PrescriptionRecord>();
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        string hsbaId = row["MAHSBA"].ToString().Trim();
                        DateTime ngayDt = Convert.ToDateTime(row["NGAYDT"]);
                        string key = hsbaId + "_" + ngayDt.ToString("yyyyMMddHHmmss");

                        if (!dict.TryGetValue(key, out var record))
                        {
                            record = new PrescriptionRecord
                            {
                                HsbaId = hsbaId,
                                PatientCode = row["MABN"].ToString().Trim(),
                                PatientName = row["TENBN"].ToString().Trim(),
                                Gender = row["PHAI"].ToString().Trim(),
                                Age = row["TUOI"] != DBNull.Value ? Convert.ToInt32(row["TUOI"]) : 0,
                                CreatedDate = ngayDt,
                                Drugs = new List<DrugRecord>()
                            };
                            dict[key] = record;
                            _prescriptions.Add(record);
                        }

                        if (row["TENTHUOC"] != DBNull.Value)
                        {
                            record.Drugs.Add(new DrugRecord
                            {
                                Name = row["TENTHUOC"].ToString().Trim(),
                                Dose = row["LIEUDUNG"] != DBNull.Value ? row["LIEUDUNG"].ToString().Trim() : ""
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách đơn thuốc từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilters()
        {
            IEnumerable<PrescriptionRecord> query = _prescriptions;
            string keyword = txtSearch.Text.Trim().ToLowerInvariant();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(p =>
                    p.PatientName.ToLowerInvariant().Contains(keyword) ||
                    p.PatientCode.ToLowerInvariant().Contains(keyword) ||
                    p.HsbaId.ToLowerInvariant().Contains(keyword) ||
                    p.Drugs.Any(d => d.Name.ToLowerInvariant().Contains(keyword)));
            }

            DateTime fromDate;
            DateTime toDate;
            GetDateRange(out fromDate, out toDate);
            query = query.Where(p => p.CreatedDate.Date >= fromDate.Date && p.CreatedDate.Date <= toDate.Date);

            string sort = cmbSort.SelectedItem == null ? "Mới nhất" : cmbSort.SelectedItem.ToString();
            if (sort == "Cũ nhất")
            {
                query = query.OrderBy(p => p.CreatedDate);
            }
            else if (sort == "Tên bệnh nhân")
            {
                query = query.OrderBy(p => p.PatientName);
            }
            else if (sort == "Số thuốc")
            {
                query = query.OrderByDescending(p => p.Drugs.Count);
            }
            else
            {
                query = query.OrderByDescending(p => p.CreatedDate);
            }

            List<PrescriptionRecord> filtered = query.ToList();
            RenderCards(filtered);
            lblResultCount.Text = "Hiển thị " + filtered.Count + " đơn thuốc";
        }

        private void GetDateRange(out DateTime fromDate, out DateTime toDate)
        {
            DateTime maxDate = _prescriptions.Count == 0 ? DateTime.Today : _prescriptions.Max(p => p.CreatedDate);
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

        private Guna2Panel CreateStatCard(string number, string title, string caption, Color accent)
        {
            var card = new Guna2Panel
            {
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 12, 0),
                Size = new Size(270, 74)
            };

            var lblNumber = new Label
            {
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(16, 10),
                Size = new Size(58, 42),
                Text = number,
                TextAlign = ContentAlignment.MiddleLeft
            };
            var lblTitle = new Label
            {
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(78, 12),
                Size = new Size(140, 25),
                Text = title
            };
            var lblCaption = new Label
            {
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(78, 40),
                Size = new Size(140, 22),
                Text = caption
            };

            card.Controls.Add(lblNumber);
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblCaption);
            return card;
        }

        private void RenderCards(List<PrescriptionRecord> records)
        {
            flpPrescriptionList.SuspendLayout();
            flpPrescriptionList.Controls.Clear();

            if (records.Count == 0)
            {
                flpPrescriptionList.Controls.Add(new Label
                {
                    AutoSize = false,
                    Width = Math.Max(400, flpPrescriptionList.ClientSize.Width - 28),
                    Height = 90,
                    Text = "Không tìm thấy đơn thuốc phù hợp.",
                    Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(122, 149, 137),
                    TextAlign = ContentAlignment.MiddleCenter
                });
                flpPrescriptionList.ResumeLayout();
                return;
            }

            foreach (PrescriptionRecord record in records)
            {
                flpPrescriptionList.Controls.Add(CreatePrescriptionCard(record));
            }

            flpPrescriptionList.ResumeLayout();
            BeginInvoke(new Action(ResizeCards));
        }

        private Guna2Panel CreatePrescriptionCard(PrescriptionRecord record)
        {
            int cardWidth = GetCardWidth();
            var card = new Guna2Panel
            {
                BorderColor = Color.FromArgb(218, 232, 226),
                BorderRadius = 10,
                BorderThickness = 1,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 0, 12),
                Size = new Size(cardWidth, 138),
                Tag = record
            };
            card.ShadowDecoration.Enabled = true;
            card.ShadowDecoration.Color = Color.FromArgb(226, 239, 234);
            card.ShadowDecoration.Depth = 5;
            card.MouseEnter += (s, e) => card.BorderColor = Color.FromArgb(26, 148, 112);
            card.MouseLeave += (s, e) => card.BorderColor = Color.FromArgb(218, 232, 226);

            var accent = new Panel
            {
                BackColor = Color.FromArgb(15, 110, 86),
                Location = new Point(0, 0),
                Size = new Size(4, card.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };

            var lblHsba = new Label
            {
                BackColor = Color.FromArgb(230, 244, 240),
                Font = new Font("Consolas", 9.3F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 110, 86),
                Location = new Point(24, 18),
                Size = new Size(118, 28),
                Text = record.HsbaId,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblPatient = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 48, 42),
                Location = new Point(154, 17),
                Size = new Size(300, 28),
                Text = record.PatientName
            };

            var lblMeta = new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(154, 47),
                Size = new Size(430, 22),
                Text = string.Format("{0} · {1}, {2} tuổi · {3}", record.PatientCode, record.Gender, record.Age, record.CreatedDate.ToString("dd/MM/yyyy"))
            };

            var chipPanel = new FlowLayoutPanel
            {
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                Location = new Point(24, 86),
                Size = new Size(cardWidth - 210, 34),
                WrapContents = false
            };
            foreach (DrugRecord drug in record.Drugs.Take(4))
            {
                chipPanel.Controls.Add(CreateDrugChip(drug));
            }
            if (record.Drugs.Count > 4)
            {
                chipPanel.Controls.Add(CreateMoreChip(record.Drugs.Count - 4));
            }

            var lblCount = new Label
            {
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 149, 137),
                Location = new Point(cardWidth - 170, 22),
                Size = new Size(130, 24),
                Text = record.Drugs.Count + " thuốc",
                TextAlign = ContentAlignment.MiddleRight,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var btnDetail = CreateActionButton("Xem chi tiết", Color.FromArgb(15, 110, 86), Color.White);
            btnDetail.Location = new Point(cardWidth - 166, 82);
            btnDetail.Size = new Size(134, 36);
            btnDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetail.Click += (s, e) => OpenPrescriptionDetail(record);

            card.Controls.Add(accent);
            card.Controls.Add(lblHsba);
            card.Controls.Add(lblPatient);
            card.Controls.Add(lblMeta);
            card.Controls.Add(chipPanel);
            card.Controls.Add(lblCount);
            card.Controls.Add(btnDetail);
            return card;
        }

        private Label CreateDrugChip(DrugRecord drug)
        {
            string text = drug.Name;
            var chip = new Label
            {
                AutoSize = false,
                BackColor = Color.FromArgb(247, 249, 248),
                Font = new Font("Segoe UI", 8.6F, FontStyle.Bold),
                ForeColor = Color.FromArgb(61, 82, 73),
                Margin = new Padding(0, 0, 8, 0),
                Padding = new Padding(10, 0, 10, 0),
                Size = new Size(Math.Min(190, 80 + text.Length * 6), 28),
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
            return chip;
        }

        private Label CreateMoreChip(int count)
        {
            return new Label
            {
                AutoSize = false,
                BackColor = Color.FromArgb(230, 244, 240),
                Font = new Font("Segoe UI", 8.6F, FontStyle.Bold),
                ForeColor = Color.FromArgb(15, 110, 86),
                Margin = new Padding(0, 0, 8, 0),
                Size = new Size(74, 28),
                Text = "+" + count + " thuốc",
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Guna2Button CreateActionButton(string text, Color fill, Color fore)
        {
            var button = new Guna2Button
            {
                BorderRadius = 8,
                Cursor = Cursors.Hand,
                FillColor = fill,
                ForeColor = fore,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Text = text
            };
            button.HoverState.FillColor = fill == Color.White ? Color.FromArgb(230, 244, 240) : Color.FromArgb(26, 148, 112);
            button.HoverState.ForeColor = fill == Color.White ? Color.FromArgb(10, 79, 61) : Color.White;
            button.PressedColor = Color.FromArgb(10, 79, 61);
            return button;
        }

        private void OpenPrescriptionDetail(PrescriptionRecord record)
        {
            using (var form = new frmPrescriptionDetail(record))
            {
                if (form.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    LoadPrescriptionsFromDatabase();
                    ApplyFilters();
                }
            }
        }

        private int GetCardWidth()
        {
            return Math.Max(780, flpPrescriptionList.Width - flpPrescriptionList.Padding.Horizontal - 28);
        }

        private void ResizeCards()
        {
            int cardWidth = GetCardWidth();
            foreach (Control control in flpPrescriptionList.Controls)
            {
                control.Width = cardWidth;
            }
        }

        public class PrescriptionRecord
        {
            public string HsbaId { get; set; }
            public string PatientCode { get; set; }
            public string PatientName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public DateTime CreatedDate { get; set; }
            public List<DrugRecord> Drugs { get; set; }
        }

        public class DrugRecord
        {
            public DrugRecord()
            {
            }

            public DrugRecord(string name, string dose)
            {
                Name = name;
                Dose = dose;
            }

            public string Name { get; set; }
            public string Dose { get; set; }
        }
    }

}

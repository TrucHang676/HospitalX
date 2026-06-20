using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using HospitalX.DAO;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class ucBenhAnBN : UserControl
    {
        private readonly List<PatientMedicalRecord> records = new List<PatientMedicalRecord>();

        public ucBenhAnBN()
        {
            InitializeComponent();
            LoadMedicalRecordsFromDB();
            WireEvents();
            RenderRecords();
        }

        private void LoadMedicalRecordsFromDB()
        {
            records.Clear();
            try
            {
                // Gọi stored procedure SP_GET_HSBA_FOR_PATIENT để lấy danh sách HSBA của bệnh nhân hiện tại
                string procHsba = "ADMINHOS.SP_GET_HSBA_FOR_PATIENT";
                Oracle.ManagedDataAccess.Client.OracleParameter[] hsbaParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                {
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_mabn", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = DataProvider.Instance.CurrentUser },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dtHsba = DataProvider.Instance.ExecuteQuery(procHsba, hsbaParams, true);
                if (dtHsba != null)
                {
                    foreach (DataRow row in dtHsba.Rows)
                    {
                        var pmr = new PatientMedicalRecord();
                        pmr.Id = row["MAHSBA"]?.ToString() ?? "";
                        pmr.PatientId = row["MABN"]?.ToString() ?? "";
                        pmr.PatientName = row["TENBN"]?.ToString() ?? "";
                        pmr.Date = row["NGAYTAO"] != DBNull.Value ? Convert.ToDateTime(row["NGAYTAO"]) : DateTime.Today;
                        pmr.Diagnosis = row["CHANDOAN"]?.ToString() ?? "";
                        pmr.Treatment = row["DIEUTRI"]?.ToString() ?? "";
                        pmr.Conclusion = row["KETLUAN"]?.ToString() ?? "";
                        pmr.DoctorId = row["MABS"]?.ToString() ?? "";
                        pmr.DoctorName = row["TENBS"]?.ToString() ?? "Bác sĩ điều trị";
                        pmr.DoctorRole = "Bác sĩ";
                        pmr.Department = row["TENKHOA"]?.ToString() ?? "Khoa điều trị";

                        // Load dịch vụ đi kèm với HSBA này
                        string procDv = "ADMINHOS.SP_GET_SERVICES_FOR_HSBA";
                        Oracle.ManagedDataAccess.Client.OracleParameter[] dvParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                        {
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = pmr.Id },
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                        };
                        DataTable dtDv = DataProvider.Instance.ExecuteQuery(procDv, dvParams, true);
                        if (dtDv != null)
                        {
                            foreach (DataRow dRow in dtDv.Rows)
                            {
                                string tendv = dRow["TENDV"]?.ToString() ?? "";
                                DateTime ngayy = dRow["NGAYYEUCAU"] != DBNull.Value ? Convert.ToDateTime(dRow["NGAYYEUCAU"]) : pmr.Date;
                                string maktv = dRow["MAKTV"]?.ToString() ?? "Chưa phân công";
                                string ketqua = dRow["KETQUA"]?.ToString() ?? "Chờ thực hiện";
                                pmr.Services.Add(new RecordService(tendv, ngayy, maktv, ketqua));
                            }
                        }

                        // Load đơn thuốc đi kèm với HSBA này
                        string procDt = "ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA";
                        Oracle.ManagedDataAccess.Client.OracleParameter[] dtParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                        {
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = pmr.Id },
                            new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                        };
                        DataTable dtPres = DataProvider.Instance.ExecuteQuery(procDt, dtParams, true);
                        if (dtPres != null)
                        {
                            foreach (DataRow pRow in dtPres.Rows)
                            {
                                string thuoc = pRow["TENTHUOC"]?.ToString() ?? "";
                                string lieudung = pRow["CACHDUNG"]?.ToString() ?? "";
                                pmr.Prescriptions.Add(new RecordPrescription(pmr.Date, thuoc, lieudung));
                            }
                        }

                        records.Add(pmr);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi load bệnh án từ database: " + ex.Message);
            }
        }

        private void WireEvents()
        {
            txtSearch.TextChanged += (sender, args) => RenderRecords();

            dtpFrom.ValueChanged += (sender, args) => RenderRecords();
            dtpTo.ValueChanged += (sender, args) => RenderRecords();
            cmbSort.SelectedIndexChanged += (sender, args) => RenderRecords();
            Resize += (sender, args) => LayoutRecordCards();
        }

        private void RenderRecords()
        {
            flowRecords.SuspendLayout();
            flowRecords.Controls.Clear();

            foreach (var record in GetFilteredRecords())
            {
                flowRecords.Controls.Add(CreateRecordCard(record));
            }

            lblCount.Text = $"Hiển thị {flowRecords.Controls.Count} hồ sơ";
            LayoutRecordCards();
            flowRecords.ResumeLayout();
        }

        private IEnumerable<PatientMedicalRecord> GetFilteredRecords()
        {
            var query = records.AsEnumerable();
            var keyword = RemoveDiacritics(txtSearch.Text.Trim()).ToLowerInvariant();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(record =>
                    RemoveDiacritics($"{record.Id} {record.PatientName} {record.Diagnosis} {record.Treatment} {record.Conclusion} {record.DoctorName} {record.Department}")
                        .ToLowerInvariant()
                        .Contains(keyword));
            }

            query = query.Where(record => record.Date.Date >= dtpFrom.Value.Date && record.Date.Date <= dtpTo.Value.Date);

            var sort = cmbSort.SelectedItem?.ToString();
            if (sort == "Cũ nhất")
            {
                query = query.OrderBy(record => record.Date);
            }
            else if (sort == "Mã HSBA A-Z")
            {
                query = query.OrderBy(record => record.Id);
            }
            else
            {
                query = query.OrderByDescending(record => record.Date);
            }

            return query.ToList();
        }

        private Control CreateRecordCard(PatientMedicalRecord record)
        {
            var card = new Guna2Panel
            {
                BorderColor = Color.FromArgb(205, 224, 219),
                BorderRadius = 8,
                BorderThickness = 1,
                CustomBorderColor = Color.FromArgb(0, 128, 102),
                CustomBorderThickness = new Padding(4, 0, 0, 0),
                FillColor = Color.White,
                Height = 180,
                Margin = new Padding(0, 0, 0, 12),
                Width = 800
            };

            card.Controls.Add(CreateBadge(record.Id, 24, 18, 130));
            card.Controls.Add(CreateText(record.Date.ToString("dd/MM/yyyy"), 170, 18, 130, 25, 10f, FontStyle.Bold, Color.FromArgb(112, 138, 132)));
            card.Controls.Add(CreateText(record.Diagnosis, 24, 50, 620, 50, 13f, FontStyle.Bold, Color.FromArgb(10, 42, 64)));
            card.Controls.Add(CreateText($"{record.DoctorRole}: {record.DoctorName} · {record.Department}", 24, 95, 620, 40, 10f, FontStyle.Bold, Color.FromArgb(112, 138, 132)));
            card.Controls.Add(CreateText($"Kết luận: {record.Conclusion}", 24, 130, 620, 30, 9.5f, FontStyle.Regular, Color.FromArgb(74, 98, 92)));

            var btnDetail = CreateDetailButton();
            btnDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDetail.Location = new Point(card.Width - 200, 43);
            btnDetail.Click += (sender, args) =>
            {
                using (var form = new frmBenhAnDetailBN(record))
                {
                    form.ShowDialog(this);
                }
            };
            card.Controls.Add(btnDetail);

            card.Resize += (sender, args) => btnDetail.Location = new Point(card.Width - 200, 43);
            return card;
        }

        private Guna2Button CreateDetailButton()
        {
            var button = new Guna2Button
            {
                BorderRadius = 7,
                Cursor = Cursors.Hand,
                FillColor = Color.FromArgb(0, 120, 95),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                ForeColor = Color.White,
                PressedColor = Color.FromArgb(0, 78, 63),
                Size = new Size(155, 42),
                Text = "Xem chi tiết"
            };
            button.HoverState.FillColor = Color.FromArgb(0, 97, 78);
            button.HoverState.ForeColor = Color.White;
            button.DisabledState.FillColor = Color.FromArgb(180, 205, 198);
            button.DisabledState.ForeColor = Color.White;
            return button;
        }

        private Label CreateBadge(string text, int x, int y, int width)
        {
            return new Label
            {
                AutoEllipsis = true,
                BackColor = Color.FromArgb(226, 245, 239),
                Font = new Font("Consolas", 10f, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 105, 85),
                Location = new Point(x, y),
                Padding = new Padding(8, 2, 8, 2),
                Size = new Size(width, 26),
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }

        private Label CreateText(string text, int x, int y, int width, int height, float size, FontStyle style, Color color)
        {
            return new Label
            {
                AutoEllipsis = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                Location = new Point(x, y),
                Size = new Size(width, height),
                Text = text
            };
        }

        private void LayoutRecordCards()
        {
            var cardWidth = Math.Max(720, flowRecords.ClientSize.Width - 24);
            foreach (Control card in flowRecords.Controls)
            {
                card.Width = cardWidth;
            }
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            var normalized = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();
            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC).Replace("đ", "d").Replace("Đ", "D");
        }
    }
}

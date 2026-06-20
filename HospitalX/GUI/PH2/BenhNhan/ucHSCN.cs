using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using HospitalX.DAO;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class ucHSCN : UserControl
    {
        private readonly PatientSummary currentPatient = new PatientSummary
        {
            Id = "BN-00341",
            Name = "Nguyễn Văn An",
            Gender = "Nam",
            BirthDate = new DateTime(1974, 4, 12),
            Cccd = "079074012345",
            Address = "12 Nguyễn Trãi, Quận 1, TP.HCM",
            MedicalHistory = "Tăng huyết áp từ năm 2018",
            FamilyHistory = "Cha có tiền sử tăng huyết áp",
            Allergy = "Không ghi nhận"
        };

        private readonly List<MedicalRecordSummary> medicalRecords = new List<MedicalRecordSummary>
        {
            new MedicalRecordSummary("HSBA-0821", new DateTime(2026, 5, 21), "Tăng huyết áp độ II, rối loạn nhịp tim", "Amlodipine, Bisoprolol", "Theo dõi huyết áp định kỳ"),
            new MedicalRecordSummary("HSBA-0794", new DateTime(2026, 3, 3), "Theo dõi huyết áp định kỳ", "Điều chỉnh liều dùng", "Tái khám sau 4 tuần"),
            new MedicalRecordSummary("HSBA-0741", new DateTime(2026, 1, 12), "Khám tim mạch tổng quát", "Xét nghiệm và điện tim", "Tình trạng ổn định")
        };

        private readonly List<ServiceSummary> services = new List<ServiceSummary>
        {
            new ServiceSummary("Xét nghiệm máu", new DateTime(2026, 5, 21), "Trong giới hạn cho phép"),
            new ServiceSummary("Điện tim", new DateTime(2026, 5, 21), "Rối loạn nhịp nhẹ"),
            new ServiceSummary("Siêu âm tim", new DateTime(2026, 5, 20), "Chức năng thất trái bảo tồn")
        };

        private readonly List<PrescriptionSummary> prescriptions = new List<PrescriptionSummary>
        {
            new PrescriptionSummary("Amlodipine 5mg", "1 viên/ngày", new DateTime(2026, 5, 21)),
            new PrescriptionSummary("Bisoprolol 2.5mg", "1 viên/ngày", new DateTime(2026, 5, 21)),
            new PrescriptionSummary("Aspirin 81mg", "1 viên/ngày", new DateTime(2026, 5, 21))
        };

        private string originalAllergy;
        private string originalMedicalHistory;
        private string originalFamilyHistory;

        public ucHSCN()
        {
            InitializeComponent();
            BringEditableControlsToFront();
            LoadPatientDataFromDB();
            RenderDashboard();
            SetHistoryEditing(false);
            btnSaveProfile.Visible = false;
        }

        private void LoadPatientDataFromDB()
        {
            try
            {
                // Load thông tin cá nhân từ VW_BENHNHAN_SELF
                string sql = "SELECT MABN, TENBN, PHAI, NGAYSINH, CCCD, SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC FROM ADMINHOS.VW_BENHNHAN_SELF";
                DataTable dt = DataProvider.Instance.ExecuteQuery(sql, null, false);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    currentPatient.Id = row["MABN"]?.ToString() ?? "";
                    currentPatient.Name = row["TENBN"]?.ToString() ?? "";
                    currentPatient.Gender = row["PHAI"]?.ToString() ?? "";
                    currentPatient.BirthDate = row["NGAYSINH"] != DBNull.Value ? Convert.ToDateTime(row["NGAYSINH"]) : DateTime.Today;
                    currentPatient.Cccd = row["CCCD"]?.ToString() ?? "";
                    
                    string sonha = row["SONHA"]?.ToString() ?? "";
                    string tenduong = row["TENDUONG"]?.ToString() ?? "";
                    string quanhuyen = row["QUANHUYEN"]?.ToString() ?? "";
                    string tinhtp = row["TINHTP"]?.ToString() ?? "";
                    
                    List<string> addrParts = new List<string>();
                    if (!string.IsNullOrEmpty(sonha)) addrParts.Add(sonha.Trim());
                    if (!string.IsNullOrEmpty(tenduong)) addrParts.Add(tenduong.Trim());
                    if (!string.IsNullOrEmpty(quanhuyen)) addrParts.Add(quanhuyen.Trim());
                    if (!string.IsNullOrEmpty(tinhtp)) addrParts.Add(tinhtp.Trim());
                    currentPatient.Address = string.Join(", ", addrParts);

                    currentPatient.MedicalHistory = row["TIENSUBENH"]?.ToString() ?? "";
                    currentPatient.FamilyHistory = row["TIENSUBENHGD"]?.ToString() ?? "";
                    currentPatient.Allergy = row["DIUNGTHUOC"]?.ToString() ?? "";
                }

                // Load danh sách bệnh án tóm tắt từ stored procedure
                medicalRecords.Clear();
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
                        string id = row["MAHSBA"]?.ToString() ?? "";
                        DateTime ngay = row["NGAYTAO"] != DBNull.Value ? Convert.ToDateTime(row["NGAYTAO"]) : DateTime.Today;
                        string chandoan = row["CHANDOAN"]?.ToString() ?? "";
                        string dieutri = row["DIEUTRI"]?.ToString() ?? "";
                        string ketluan = row["KETLUAN"]?.ToString() ?? "";
                        medicalRecords.Add(new MedicalRecordSummary(id, ngay, chandoan, dieutri, ketluan));
                    }
                }

                // Load tóm tắt đơn thuốc từ stored procedure (lấy từ các HSBA của bệnh nhân)
                prescriptions.Clear();
                foreach (var mr in medicalRecords)
                {
                    string procDt = "ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA";
                    Oracle.ManagedDataAccess.Client.OracleParameter[] dtParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                    {
                        new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = mr.Id },
                        new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                    };
                    DataTable dtPres = DataProvider.Instance.ExecuteQuery(procDt, dtParams, true);
                    if (dtPres != null)
                    {
                        foreach (DataRow row in dtPres.Rows)
                        {
                            string thuoc = row["TENTHUOC"]?.ToString() ?? "";
                            string lieudung = row["CACHDUNG"]?.ToString() ?? "";
                            prescriptions.Add(new PrescriptionSummary(thuoc, lieudung, mr.Date));
                        }
                    }
                }

                // Load tóm tắt dịch vụ từ stored procedure
                services.Clear();
                foreach (var mr in medicalRecords)
                {
                    string procDv = "ADMINHOS.SP_GET_SERVICES_FOR_HSBA";
                    Oracle.ManagedDataAccess.Client.OracleParameter[] dvParams = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                    {
                        new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = mr.Id },
                        new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                    };
                    DataTable dtDv = DataProvider.Instance.ExecuteQuery(procDv, dvParams, true);
                    if (dtDv != null)
                    {
                        foreach (DataRow row in dtDv.Rows)
                        {
                            string tendv = row["TENDV"]?.ToString() ?? "";
                            DateTime ngay = row["NGAYYEUCAU"] != DBNull.Value ? Convert.ToDateTime(row["NGAYYEUCAU"]) : mr.Date;
                            string ketqua = row["KETQUA"]?.ToString() ?? "Chờ thực hiện";
                            services.Add(new ServiceSummary(tendv, ngay, ketqua));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi tải dữ liệu bệnh nhân từ DB: " + ex.Message);
            }
        }

        private void BringEditableControlsToFront()
        {
            txtAllergy.BringToFront();
            txtMedicalHistory.BringToFront();
            txtFamilyHistory.BringToFront();
            btnEditHistory.BringToFront();
            btnEditAddress.BringToFront();
            btnSaveProfile.BringToFront();
        }

        private void RenderDashboard()
        {
            lblWelcomeName.Text = currentPatient.Name;
            lblWelcomeId.Text = currentPatient.Id;
            lblWelcomeMeta.Text = $"{currentPatient.Gender} · {CalculateAge(currentPatient.BirthDate)} tuổi";

            lblPatientIdValue.Text = currentPatient.Id;
            lblPatientNameValue.Text = currentPatient.Name;
            lblGenderValue.Text = currentPatient.Gender;
            lblDobValue.Text = currentPatient.BirthDate.ToString("dd/MM/yyyy");
            lblCccdValue.Text = currentPatient.Cccd;
            lblAddressValue.Text = currentPatient.Address;

            txtAllergy.Text = currentPatient.Allergy;
            txtMedicalHistory.Text = currentPatient.MedicalHistory;
            txtFamilyHistory.Text = currentPatient.FamilyHistory;
            lblAllergyValue.Text = currentPatient.Allergy;
            lblMedicalHistoryValue.Text = currentPatient.MedicalHistory;
            lblFamilyHistoryValue.Text = currentPatient.FamilyHistory;
            CaptureHistoryOriginals();

            lblKpiAllergyValue.Text = HasRecordedAllergy(currentPatient.Allergy) ? "1" : "0";
            lblKpiHsbaValue.Text = medicalRecords.Count.ToString();
            lblKpiServiceValue.Text = services.Count.ToString();
            lblKpiPrescriptionValue.Text = prescriptions.Count.ToString();
        }

        private void CaptureHistoryOriginals()
        {
            originalAllergy = txtAllergy.Text.Trim();
            originalMedicalHistory = txtMedicalHistory.Text.Trim();
            originalFamilyHistory = txtFamilyHistory.Text.Trim();
        }

        private void SetHistoryEditing(bool enabled)
        {
            txtAllergy.ReadOnly = !enabled;
            txtMedicalHistory.ReadOnly = !enabled;
            txtFamilyHistory.ReadOnly = !enabled;

            Color fill = enabled ? Color.White : Color.FromArgb(247, 250, 249);
            txtAllergy.FillColor = fill;
            txtMedicalHistory.FillColor = fill;
            txtFamilyHistory.FillColor = fill;

            if (enabled)
            {
                txtAllergy.Focus();
            }
        }

        private void btnEditHistory_Click(object sender, EventArgs e)
        {
            SetHistoryEditing(true);
        }

        private void HistoryField_TextChanged(object sender, EventArgs e)
        {
            btnSaveProfile.Visible = HasHistoryChanges();
        }

        private bool HasHistoryChanges()
        {
            return !string.Equals(txtAllergy.Text.Trim(), originalAllergy, StringComparison.Ordinal)
                || !string.Equals(txtMedicalHistory.Text.Trim(), originalMedicalHistory, StringComparison.Ordinal)
                || !string.Equals(txtFamilyHistory.Text.Trim(), originalFamilyHistory, StringComparison.Ordinal);
        }

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            string allergy = txtAllergy.Text.Trim();
            string medHist = txtMedicalHistory.Text.Trim();
            string famHist = txtFamilyHistory.Text.Trim();

            try
            {
                string sql = "UPDATE ADMINHOS.VW_BENHNHAN_SELF SET TIENSUBENH = :medHist, TIENSUBENHGD = :famHist, DIUNGTHUOC = :allergy";
                Oracle.ManagedDataAccess.Client.OracleParameter[] parameters = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                {
                    new Oracle.ManagedDataAccess.Client.OracleParameter("medHist", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = medHist },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("famHist", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = famHist },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("allergy", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = allergy }
                };
                DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);

                currentPatient.Allergy = allergy;
                currentPatient.MedicalHistory = medHist;
                currentPatient.FamilyHistory = famHist;

                lblAllergyValue.Text = currentPatient.Allergy;
                lblMedicalHistoryValue.Text = currentPatient.MedicalHistory;
                lblFamilyHistoryValue.Text = currentPatient.FamilyHistory;
                lblKpiAllergyValue.Text = HasRecordedAllergy(currentPatient.Allergy) ? "1" : "0";

                CaptureHistoryOriginals();
                SetHistoryEditing(false);
                btnSaveProfile.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu tiền sử bệnh vào CSDL: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditAddress_Click(object sender, EventArgs e)
        {
            AddressParts parts = AddressParts.Parse(currentPatient.Address);
            using (var dialog = new frmPatientAddressEdit(parts.HouseNumber, parts.StreetName, parts.District, parts.City))
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    string sql = "UPDATE ADMINHOS.VW_BENHNHAN_SELF SET SONHA = :sonha, TENDUONG = :tenduong, QUANHUYEN = :quanhuyen, TINHTP = :tinhtp";
                    Oracle.ManagedDataAccess.Client.OracleParameter[] parameters = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                    {
                        new Oracle.ManagedDataAccess.Client.OracleParameter("sonha", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = dialog.HouseNumber.Trim() },
                        new Oracle.ManagedDataAccess.Client.OracleParameter("tenduong", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = dialog.StreetName.Trim() },
                        new Oracle.ManagedDataAccess.Client.OracleParameter("quanhuyen", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = dialog.District.Trim() },
                        new Oracle.ManagedDataAccess.Client.OracleParameter("tinhtp", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = dialog.City.Trim() }
                    };
                    DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);

                    currentPatient.Address = dialog.FullAddress;
                    lblAddressValue.Text = currentPatient.Address;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi lưu địa chỉ vào CSDL: " + ex.Message, "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Control CreateMedicalRecordCard(MedicalRecordSummary record)
        {
            var card = CreateBaseCard(102, Color.FromArgb(0, 128, 102));

            var code = CreateBadge(record.Id, 18, 14, 110);
            var date = CreateText(record.Date.ToString("dd/MM/yyyy"), 140, 15, 100, 18, 9.5f, FontStyle.Bold, Color.FromArgb(112, 138, 132));
            var diagnosis = CreateText(record.Diagnosis, 18, 42, 520, 24, 11f, FontStyle.Bold, Color.FromArgb(10, 42, 64));
            var detail = CreateText($"Điều trị: {record.Treatment} · Kết luận: {record.Conclusion}", 18, 69, 560, 20, 9.5f, FontStyle.Regular, Color.FromArgb(74, 98, 92));

            card.Controls.Add(code);
            card.Controls.Add(date);
            card.Controls.Add(diagnosis);
            card.Controls.Add(detail);
            return card;
        }

        private Control CreateSimpleListCard(string title, string date, string subtitle)
        {
            var card = CreateBaseCard(74, Color.FromArgb(205, 224, 219));
            var titleLabel = CreateText(title, 18, 12, 260, 22, 10.5f, FontStyle.Bold, Color.FromArgb(10, 42, 64));
            var dateLabel = CreateText(date, 18, 39, 92, 18, 9f, FontStyle.Bold, Color.FromArgb(0, 105, 85));
            var subtitleLabel = CreateText(subtitle, 116, 39, 220, 18, 9f, FontStyle.Regular, Color.FromArgb(74, 98, 92));

            card.Controls.Add(titleLabel);
            card.Controls.Add(dateLabel);
            card.Controls.Add(subtitleLabel);
            return card;
        }

        private Guna2Panel CreateBaseCard(int height, Color accentColor)
        {
            return new Guna2Panel
            {
                BorderColor = Color.FromArgb(205, 224, 219),
                BorderRadius = 8,
                BorderThickness = 1,
                CustomBorderColor = accentColor,
                CustomBorderThickness = new Padding(4, 0, 0, 0),
                FillColor = Color.FromArgb(250, 252, 251),
                Height = height,
                Margin = new Padding(0, 0, 0, 10),
                Width = 300
            };
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

        private void LayoutFlowCards(FlowLayoutPanel flow)
        {
            var cardWidth = Math.Max(260, flow.ClientSize.Width - 24);
            foreach (Control card in flow.Controls)
            {
                card.Width = cardWidth;
            }
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private bool HasRecordedAllergy(string allergy)
        {
            return !string.IsNullOrWhiteSpace(allergy)
                && !allergy.Trim().Equals("Không ghi nhận", StringComparison.OrdinalIgnoreCase);
        }

        private class PatientSummary
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public DateTime BirthDate { get; set; }
            public string Cccd { get; set; }
            public string Address { get; set; }
            public string MedicalHistory { get; set; }
            public string FamilyHistory { get; set; }
            public string Allergy { get; set; }
        }

        private class AddressParts
        {
            public string HouseNumber { get; set; }
            public string StreetName { get; set; }
            public string District { get; set; }
            public string City { get; set; }

            public static AddressParts Parse(string address)
            {
                string[] parts = (address ?? string.Empty).Split(',');
                string[] streetParts = parts.Length > 0 ? parts[0].Trim().Split(new[] { ' ' }, 2) : new string[0];

                return new AddressParts
                {
                    HouseNumber = streetParts.Length > 0 ? streetParts[0].Trim() : string.Empty,
                    StreetName = streetParts.Length > 1 ? streetParts[1].Trim() : string.Empty,
                    District = parts.Length > 1 ? parts[1].Trim() : string.Empty,
                    City = parts.Length > 2 ? parts[2].Trim() : string.Empty
                };
            }
        }

        private class MedicalRecordSummary
        {
            public MedicalRecordSummary(string id, DateTime date, string diagnosis, string treatment, string conclusion)
            {
                Id = id;
                Date = date;
                Diagnosis = diagnosis;
                Treatment = treatment;
                Conclusion = conclusion;
            }

            public string Id { get; }
            public DateTime Date { get; }
            public string Diagnosis { get; }
            public string Treatment { get; }
            public string Conclusion { get; }
        }

        private class ServiceSummary
        {
            public ServiceSummary(string name, DateTime date, string result)
            {
                Name = name;
                Date = date;
                Result = result;
            }

            public string Name { get; }
            public DateTime Date { get; }
            public string Result { get; }
        }

        private class PrescriptionSummary
        {
            public PrescriptionSummary(string medicineName, string dose, DateTime date)
            {
                MedicineName = medicineName;
                Dose = dose;
                Date = date;
            }

            public string MedicineName { get; }
            public string Dose { get; }
            public DateTime Date { get; }
        }
    }
}

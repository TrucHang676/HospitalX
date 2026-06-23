using Guna.UI2.WinForms;
using HospitalX.GUI.PH2.DieuPhoiVien;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using HospitalX.DAO;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class ucHSCN : UserControl
    {
        // ----- current patient data -----
        private readonly PatientSummary currentPatient = new PatientSummary
        {
            Id = "", Name = "", Gender = "", BirthDate = DateTime.Today,
            Cccd = "", Address = "", MedicalHistory = "", FamilyHistory = "", Allergy = ""
        };

        // raw address parts from DB (for SP params on save)
        private string _dbSonha;
        private string _dbTenduong;
        private string _dbQuanhuyen;
        private string _dbTinhtp;

        // ----- original values for change detection -----
        private string _origMaBN;
        private string _origTenBN;
        private string _origPhai;
        private string _origNgaySinhStr;
        private string _origCccd;
        private string _origAddress;
        private string _origAllergy;
        private string _origMedHist;
        private string _origFamHist;

        private bool _isLoading;
        private Guna2MessageDialog _messageDialog;

        private readonly List<MedicalRecordSummary> medicalRecords = new List<MedicalRecordSummary>();
        private readonly List<ServiceSummary> services = new List<ServiceSummary>();
        private readonly List<PrescriptionSummary> prescriptions = new List<PrescriptionSummary>();

        public ucHSCN()
        {
            InitializeComponent();
            LoadAll();
        }

        private void LoadAll()
        {
            LoadPatientDataFromDB();
            _isLoading = true;
            PopulateTextboxes();
            _isLoading = false;
            CaptureAllOriginals();
            RenderDashboard();
            btnSaveProfile.Enabled = false;
        }

        // ──────────────────────────────────────────────────────────────────
        // Data loading
        // ──────────────────────────────────────────────────────────────────

        private void LoadPatientDataFromDB()
        {
            try
            {
                OracleParameter[] selfParams = new OracleParameter[]
                {
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dt = DataProvider.Instance.ExecuteQuery("ADMINHOS.SP_GET_PATIENT_SELF", selfParams, true);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    currentPatient.Id     = row["MABN"]?.ToString() ?? "";
                    currentPatient.Name   = row["TENBN"]?.ToString() ?? "";
                    currentPatient.Gender = row["PHAI"]?.ToString() ?? "";
                    currentPatient.BirthDate = row["NGAYSINH"] != DBNull.Value
                        ? Convert.ToDateTime(row["NGAYSINH"]) : DateTime.Today;
                    currentPatient.Cccd   = row["CCCD"]?.ToString() ?? "";

                    _dbSonha     = row["SONHA"]?.ToString() ?? "";
                    _dbTenduong  = row["TENDUONG"]?.ToString() ?? "";
                    _dbQuanhuyen = row["QUANHUYEN"]?.ToString() ?? "";
                    _dbTinhtp    = row["TINHTP"]?.ToString() ?? "";

                    var addrParts = new List<string>();
                    if (!string.IsNullOrEmpty(_dbSonha))     addrParts.Add(_dbSonha.Trim());
                    if (!string.IsNullOrEmpty(_dbTenduong))  addrParts.Add(_dbTenduong.Trim());
                    if (!string.IsNullOrEmpty(_dbQuanhuyen)) addrParts.Add(_dbQuanhuyen.Trim());
                    if (!string.IsNullOrEmpty(_dbTinhtp))    addrParts.Add(_dbTinhtp.Trim());
                    currentPatient.Address = string.Join(", ", addrParts);

                    currentPatient.MedicalHistory = row["TIENSUBENH"]?.ToString() ?? "";
                    currentPatient.FamilyHistory  = row["TIENSUBENHGD"]?.ToString() ?? "";
                    currentPatient.Allergy        = row["DIUNGTHUOC"]?.ToString() ?? "";
                }

                // Load HSBA
                medicalRecords.Clear();
                OracleParameter[] hsbaParams = new OracleParameter[]
                {
                    new OracleParameter("p_mabn",   OracleDbType.Varchar2) { Value = DataProvider.Instance.CurrentUser },
                    new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                };
                DataTable dtHsba = DataProvider.Instance.ExecuteQuery("ADMINHOS.SP_GET_HSBA_FOR_PATIENT", hsbaParams, true);
                if (dtHsba != null)
                {
                    foreach (DataRow row in dtHsba.Rows)
                    {
                        DateTime ngay = row["NGAYTAO"] != DBNull.Value ? Convert.ToDateTime(row["NGAYTAO"]) : DateTime.Today;
                        medicalRecords.Add(new MedicalRecordSummary(
                            row["MAHSBA"]?.ToString() ?? "", ngay,
                            row["CHANDOAN"]?.ToString() ?? "",
                            row["DIEUTRI"]?.ToString() ?? "",
                            row["KETLUAN"]?.ToString() ?? ""));
                    }
                }

                // Load prescriptions & services per HSBA
                prescriptions.Clear();
                services.Clear();
                foreach (var mr in medicalRecords)
                {
                    OracleParameter[] dtParams = new OracleParameter[]
                    {
                        new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = mr.Id },
                        new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                    };
                    DataTable dtPres = DataProvider.Instance.ExecuteQuery("ADMINHOS.SP_GET_PRESCRIPTIONS_FOR_HSBA", dtParams, true);
                    if (dtPres != null)
                        foreach (DataRow row in dtPres.Rows)
                            prescriptions.Add(new PrescriptionSummary(
                                row["TENTHUOC"]?.ToString() ?? "", row["CACHDUNG"]?.ToString() ?? "", mr.Date));

                    OracleParameter[] dvParams = new OracleParameter[]
                    {
                        new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = mr.Id },
                        new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output }
                    };
                    DataTable dtDv = DataProvider.Instance.ExecuteQuery("ADMINHOS.SP_GET_SERVICES_FOR_HSBA", dvParams, true);
                    if (dtDv != null)
                        foreach (DataRow row in dtDv.Rows)
                        {
                            DateTime ngay = row["NGAYYEUCAU"] != DBNull.Value ? Convert.ToDateTime(row["NGAYYEUCAU"]) : mr.Date;
                            services.Add(new ServiceSummary(
                                row["TENDV"]?.ToString() ?? "", ngay,
                                row["KETQUA"]?.ToString() ?? "Chờ thực hiện"));
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi tải dữ liệu bệnh nhân: " + ex.Message);
            }
        }

        // ──────────────────────────────────────────────────────────────────
        // UI helpers
        // ──────────────────────────────────────────────────────────────────

        private void PopulateTextboxes()
        {
            txtPatientId.Text    = currentPatient.Id;
            txtPatientName.Text  = currentPatient.Name;
            txtGenderField.Text  = currentPatient.Gender;
            txtDobField.Text     = currentPatient.BirthDate.ToString("dd/MM/yyyy");
            txtCccdField.Text    = currentPatient.Cccd;
            txtAddressField.Text = currentPatient.Address;
            txtAllergy.Text      = currentPatient.Allergy;
            txtMedicalHistory.Text  = currentPatient.MedicalHistory;
            txtFamilyHistory.Text   = currentPatient.FamilyHistory;
        }

        private void CaptureAllOriginals()
        {
            _origMaBN        = txtPatientId.Text.Trim();
            _origTenBN       = txtPatientName.Text.Trim();
            _origPhai        = txtGenderField.Text.Trim();
            _origNgaySinhStr = txtDobField.Text.Trim();
            _origCccd        = txtCccdField.Text.Trim();
            _origAddress     = txtAddressField.Text.Trim();
            _origAllergy     = txtAllergy.Text.Trim();
            _origMedHist     = txtMedicalHistory.Text.Trim();
            _origFamHist     = txtFamilyHistory.Text.Trim();
        }

        private void RenderDashboard()
        {
            lblWelcomeName.Text  = currentPatient.Name;
            lblWelcomeId.Text    = currentPatient.Id;
            lblWelcomeMeta.Text  = $"{currentPatient.Gender} · {CalculateAge(currentPatient.BirthDate)} tuổi";

            lblKpiAllergyValue.Text      = HasRecordedAllergy(currentPatient.Allergy) ? "1" : "0";
            lblKpiHsbaValue.Text         = medicalRecords.Count.ToString();
            lblKpiServiceValue.Text      = services.Count.ToString();
            lblKpiPrescriptionValue.Text = prescriptions.Count.ToString();
        }

        // ──────────────────────────────────────────────────────────────────
        // Change detection
        // ──────────────────────────────────────────────────────────────────

        private void AnyField_TextChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;
            btnSaveProfile.Enabled = HasAnyChanges();
        }

        private bool HasAnyChanges()
        {
            return !string.Equals(txtPatientId.Text.Trim(),    _origMaBN,        StringComparison.Ordinal)
                || !string.Equals(txtPatientName.Text.Trim(),  _origTenBN,       StringComparison.Ordinal)
                || !string.Equals(txtGenderField.Text.Trim(),  _origPhai,        StringComparison.Ordinal)
                || !string.Equals(txtDobField.Text.Trim(),     _origNgaySinhStr, StringComparison.Ordinal)
                || !string.Equals(txtCccdField.Text.Trim(),    _origCccd,        StringComparison.Ordinal)
                || !string.Equals(txtAddressField.Text.Trim(), _origAddress,     StringComparison.Ordinal)
                || !string.Equals(txtAllergy.Text.Trim(),      _origAllergy,     StringComparison.Ordinal)
                || !string.Equals(txtMedicalHistory.Text.Trim(), _origMedHist,   StringComparison.Ordinal)
                || !string.Equals(txtFamilyHistory.Text.Trim(),  _origFamHist,   StringComparison.Ordinal);
        }

        // ──────────────────────────────────────────────────────────────────
        // Save — gửi toàn bộ xuống Oracle, bảo mật thực thi tại SP
        // ──────────────────────────────────────────────────────────────────

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            // Validate date format
            DateTime? ngaySinh = null;
            if (!string.IsNullOrWhiteSpace(txtDobField.Text))
            {
                if (!DateTime.TryParseExact(txtDobField.Text.Trim(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dob))
                {
                    ShowMessage("Ngày sinh phải đúng định dạng dd/MM/yyyy.", "Lỗi nhập liệu", MessageDialogIcon.Warning);
                    return;
                }
                ngaySinh = dob;
            }

            string maBN   = txtPatientId.Text.Trim();
            string tenBN  = txtPatientName.Text.Trim();
            string phai   = txtGenderField.Text.Trim();
            string cccd   = txtCccdField.Text.Trim();
            string allergy  = txtAllergy.Text.Trim();
            string medHist  = txtMedicalHistory.Text.Trim();
            string famHist  = txtFamilyHistory.Text.Trim();

            // Parse combined address string → 4 DB fields
            AddressParts addr = AddressParts.Parse(txtAddressField.Text.Trim());

            try
            {
                OracleParameter[] parameters = new OracleParameter[]
                {
                    new OracleParameter("p_mabn",          OracleDbType.Varchar2)  { Value = maBN },
                    new OracleParameter("p_tenbn",         OracleDbType.NVarchar2) { Value = tenBN },
                    new OracleParameter("p_phai",          OracleDbType.NVarchar2) { Value = phai },
                    new OracleParameter("p_ngaysinh",      OracleDbType.Date)      { Value = (object)ngaySinh ?? DBNull.Value },
                    new OracleParameter("p_cccd",          OracleDbType.Varchar2)  { Value = cccd },
                    new OracleParameter("p_sonha",         OracleDbType.NVarchar2) { Value = addr.HouseNumber },
                    new OracleParameter("p_tenduong",      OracleDbType.NVarchar2) { Value = addr.StreetName },
                    new OracleParameter("p_quanhuyen",     OracleDbType.NVarchar2) { Value = addr.District },
                    new OracleParameter("p_tinhtp",        OracleDbType.NVarchar2) { Value = addr.City },
                    new OracleParameter("p_tiensubenh",    OracleDbType.NVarchar2) { Value = medHist },
                    new OracleParameter("p_tiensubenhgd",  OracleDbType.NVarchar2) { Value = famHist },
                    new OracleParameter("p_diungthuoc",    OracleDbType.NVarchar2) { Value = allergy }
                };
                DataProvider.Instance.ExecuteNonQuery("ADMINHOS.SP_UPDATE_PATIENT_SELF", parameters, true);

                // Update in-memory state
                currentPatient.Allergy        = allergy;
                currentPatient.MedicalHistory = medHist;
                currentPatient.FamilyHistory  = famHist;
                currentPatient.Address        = txtAddressField.Text.Trim();
                _dbSonha     = addr.HouseNumber;
                _dbTenduong  = addr.StreetName;
                _dbQuanhuyen = addr.District;
                _dbTinhtp    = addr.City;

                CaptureAllOriginals();
                RenderDashboard();
                btnSaveProfile.Enabled = false;

                // Notify Main_BN to update its header details (top left name/age)
                var mainForm = this.FindForm() as HospitalX.GUI.PH2.Main_BN;
                if (mainForm != null)
                {
                    mainForm.LoadPatientInfo();
                }

                ShowMessage("Cập nhật thành công.", "Thông báo", MessageDialogIcon.Information);
            }
            catch (Exception ex)
            {
                // Hiển thị lỗi Oracle — chính sách bảo mật từ chối trường bị hạn chế
                ShowMessage("Lỗi CSDL: " + ex.Message, "Cập nhật bị từ chối", MessageDialogIcon.Error);
                // Reset về giá trị gốc
                _isLoading = true;
                PopulateTextboxes();
                _isLoading = false;
                btnSaveProfile.Enabled = false;
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var frm = new frmDoiMatKhau())
            {
                frm.ShowDialog(this);
            }
        }

        // ──────────────────────────────────────────────────────────────────
        // Utility
        // ──────────────────────────────────────────────────────────────────

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }

        private bool HasRecordedAllergy(string allergy)
        {
            return !string.IsNullOrWhiteSpace(allergy)
                && !allergy.Trim().Equals("Không ghi nhận", StringComparison.OrdinalIgnoreCase);
        }

        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            if (_messageDialog == null)
            {
                _messageDialog = new Guna2MessageDialog();
            }

            _messageDialog.Parent = FindForm();
            _messageDialog.Icon = icon;
            _messageDialog.Buttons = MessageDialogButtons.OK;
            _messageDialog.Caption = title;
            _messageDialog.Style = MessageDialogStyle.Light;
            _messageDialog.Show(message);
        }

        // ──────────────────────────────────────────────────────────────────
        // Inner types
        // ──────────────────────────────────────────────────────────────────

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
                // DB format: "SONHA, TENDUONG, QUANHUYEN, TINHTP"
                string[] parts = (address ?? string.Empty).Split(',');
                return new AddressParts
                {
                    HouseNumber = parts.Length > 0 ? parts[0].Trim() : string.Empty,
                    StreetName  = parts.Length > 1 ? parts[1].Trim() : string.Empty,
                    District    = parts.Length > 2 ? parts[2].Trim() : string.Empty,
                    City        = parts.Length > 3 ? parts[3].Trim() : string.Empty
                };
            }
        }

        private class MedicalRecordSummary
        {
            public MedicalRecordSummary(string id, DateTime date, string diagnosis, string treatment, string conclusion)
            { Id = id; Date = date; Diagnosis = diagnosis; Treatment = treatment; Conclusion = conclusion; }
            public string Id { get; }
            public DateTime Date { get; }
            public string Diagnosis { get; }
            public string Treatment { get; }
            public string Conclusion { get; }
        }

        private class ServiceSummary
        {
            public ServiceSummary(string name, DateTime date, string result)
            { Name = name; Date = date; Result = result; }
            public string Name { get; }
            public DateTime Date { get; }
            public string Result { get; }
        }

        private class PrescriptionSummary
        {
            public PrescriptionSummary(string medicineName, string dose, DateTime date)
            { MedicineName = medicineName; Dose = dose; Date = date; }
            public string MedicineName { get; }
            public string Dose { get; }
            public DateTime Date { get; }
        }
    }
}

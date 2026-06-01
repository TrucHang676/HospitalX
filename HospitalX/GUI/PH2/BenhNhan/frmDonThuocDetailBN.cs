using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class frmDonThuocDetailBN : Form
    {
        public frmDonThuocDetailBN(PatientMedicalRecord record, RecordPrescription prescription)
        {
            InitializeComponent();
            lblCode.Text = record.Id;
            lblMeta.Text = $"{record.PatientId} · {record.PatientName} · {record.Date:dd/MM/yyyy}";
            lblHsbaValue.Text = record.Id;
            lblMedicineValue.Text = prescription.MedicineName;
            lblDateValue.Text = prescription.Date.ToString("dd/MM/yyyy");
            lblDoseValue.Text = prescription.Dose;
            txtDiagnosis.Text = record.Diagnosis;
        }
    }
}

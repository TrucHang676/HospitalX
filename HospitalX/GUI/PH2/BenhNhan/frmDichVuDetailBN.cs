using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class frmDichVuDetailBN : Form
    {
        public frmDichVuDetailBN(PatientMedicalRecord record, RecordService service)
        {
            InitializeComponent();
            lblCode.Text = record.Id;
            lblMeta.Text = $"{record.PatientId} · {record.PatientName} · {record.Diagnosis}";
            lblHsbaValue.Text = record.Id;
            lblServiceValue.Text = service.Type;
            lblDateValue.Text = service.Date.ToString("dd/MM/yyyy");
            lblTechnicianValue.Text = service.TechnicianId;
            txtResult.Text = service.Result;
        }
    }
}

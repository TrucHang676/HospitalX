using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class frmChiTietYeuCau : Form
    {
        public frmChiTietYeuCau()
        {
            InitializeComponent();
        }

        public frmChiTietYeuCau(ucDieuPhoiKTV.ServiceRequest req) : this()
        {
            lblMaHSBAVal.Text = req.Hsba;
            lblBenhNhanVal.Text = $"{req.PatientCode} · {req.PatientName}";
            lblLoaiDVVal.Text = req.ServiceType;
            lblNgayDVVal.Text = req.ServiceDate;
            lblKtvVal.Text = req.AssignedKtv;
            lblTrangThaiVal.Text = req.StatusLabel;
            lblKetQuaVal.Text = string.IsNullOrEmpty(req.Result) ? "chưa có" : req.Result;
        }


    }
}

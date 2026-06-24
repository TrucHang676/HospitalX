using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    public partial class frmPhanCongKTV : Form
    {
        public ucDieuPhoiKTV.Technician SelectedKtv { get; private set; }

        public frmPhanCongKTV()
        {
            InitializeComponent();
        }

        public frmPhanCongKTV(ucDieuPhoiKTV.ServiceRequest req, List<ucDieuPhoiKTV.Technician> ktvs) : this()
        {
            lblMaHSBAVal.Text = req.Hsba;
            lblLoaiDVVal.Text = req.ServiceType;
            lblNgayDVVal.Text = req.ServiceDate;

            foreach (var ktv in ktvs)
            {
                cboKtv.Items.Add(ktv);
            }

            if (cboKtv.Items.Count > 0) cboKtv.SelectedIndex = 0;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cboKtv.SelectedItem is ucDieuPhoiKTV.Technician selected)
            {
                SelectedKtv = selected;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn kỹ thuật viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}

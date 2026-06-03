using System;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class frmPatientAddressEdit : Form
    {
        private readonly string originalHouseNumber;
        private readonly string originalStreetName;
        private readonly string originalDistrict;
        private readonly string originalCity;

        public frmPatientAddressEdit(string houseNumber, string streetName, string district, string city)
        {
            InitializeComponent();

            originalHouseNumber = houseNumber ?? string.Empty;
            originalStreetName = streetName ?? string.Empty;
            originalDistrict = district ?? string.Empty;
            originalCity = city ?? string.Empty;

            txtHouseNumber.Text = originalHouseNumber;
            txtStreetName.Text = originalStreetName;
            txtDistrict.Text = originalDistrict;
            txtCity.Text = originalCity;
            btnSave.Visible = false;
        }

        public string FullAddress
        {
            get
            {
                return string.Format("{0} {1}, {2}, {3}",
                    txtHouseNumber.Text.Trim(),
                    txtStreetName.Text.Trim(),
                    txtDistrict.Text.Trim(),
                    txtCity.Text.Trim());
            }
        }

        private void AddressField_TextChanged(object sender, EventArgs e)
        {
            btnSave.Visible = HasCompleteInput() && HasChanges();
        }

        private bool HasCompleteInput()
        {
            return !string.IsNullOrWhiteSpace(txtHouseNumber.Text)
                && !string.IsNullOrWhiteSpace(txtStreetName.Text)
                && !string.IsNullOrWhiteSpace(txtDistrict.Text)
                && !string.IsNullOrWhiteSpace(txtCity.Text);
        }

        private bool HasChanges()
        {
            return !string.Equals(txtHouseNumber.Text.Trim(), originalHouseNumber, StringComparison.Ordinal)
                || !string.Equals(txtStreetName.Text.Trim(), originalStreetName, StringComparison.Ordinal)
                || !string.Equals(txtDistrict.Text.Trim(), originalDistrict, StringComparison.Ordinal)
                || !string.Equals(txtCity.Text.Trim(), originalCity, StringComparison.Ordinal);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}

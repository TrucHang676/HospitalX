using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace HospitalX.GUI.PH2.BenhNhan
{
    public partial class frmPatientAddressEdit : Form
    {
        private readonly string originalHouseNumber;
        private readonly string originalStreetName;
        private readonly string originalDistrict;
        private readonly string originalCity;
        private Guna2MessageDialog _messageDialog;

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
            UpdateSaveButtonState();
        }

        public string HouseNumber => txtHouseNumber.Text.Trim();
        public string StreetName => txtStreetName.Text.Trim();
        public string District => txtDistrict.Text.Trim();
        public string City => txtCity.Text.Trim();

        public string FullAddress
        {
            get
            {
                // Consistent with DB storage: SONHA, TENDUONG, QUANHUYEN, TINHTP
                return string.Join(", ",
                    txtHouseNumber.Text.Trim(),
                    txtStreetName.Text.Trim(),
                    txtDistrict.Text.Trim(),
                    txtCity.Text.Trim());
            }
        }

        private void AddressField_TextChanged(object sender, EventArgs e)
        {
            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            bool canSave = HasCompleteInput() && HasChanges();
            btnSave.Visible = true;
            btnSave.Enabled = canSave;
            btnSave.Cursor = canSave ? Cursors.Hand : Cursors.Default;
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
            if (!HasCompleteInput())
            {
                ShowMessage("Vui lòng nhập đầy đủ số nhà, tên đường, quận/huyện và tỉnh/thành phố.",
                    "Thiếu dữ liệu", MessageDialogIcon.Warning);
                UpdateSaveButtonState();
                return;
            }

            if (!HasChanges())
            {
                UpdateSaveButtonState();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        private void ShowMessage(string message, string title, MessageDialogIcon icon)
        {
            if (_messageDialog == null)
            {
                _messageDialog = new Guna2MessageDialog();
            }

            _messageDialog.Parent = this;
            _messageDialog.Icon = icon;
            _messageDialog.Buttons = MessageDialogButtons.OK;
            _messageDialog.Caption = title;
            _messageDialog.Style = MessageDialogStyle.Light;
            _messageDialog.Show(message);
        }
    }
}

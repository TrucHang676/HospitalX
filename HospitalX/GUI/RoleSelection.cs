using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI
{
    public partial class RoleSelection : Form
    {
        public RoleSelection()
        {
            InitializeComponent();
            WireRoleButtons();
        }

        private void WireRoleButtons()
        {
            btnPh1Dba.Click += (s, e) => OpenRoleLogin(CreateRole("PH1_DBA", "Phân hệ 1", "DBA", "Quản trị viên CSDL", LoginModule.Ph1, Ph1Color));

            btnPh2Dba.Click += (s, e) => OpenRoleLogin(CreateRole("PH2_DBA", "Phân hệ 2", "DBA", "Quản trị hệ thống y tế", LoginModule.Ph2, Ph2Color));
            btnPh2Coordinator.Click += (s, e) => OpenRoleLogin(CreateRole("PH2_COORDINATOR", "Phân hệ 2", "Điều phối viên", "Tiếp nhận & điều phối bệnh nhân", LoginModule.Ph2, Ph2Color));
            btnPh2Doctor.Click += (s, e) => OpenRoleLogin(CreateRole("PH2_DOCTOR", "Phân hệ 2", "Bác sĩ / Y sĩ", "Chẩn đoán & điều trị", LoginModule.Ph2, Ph2Color));
            btnPh2Technician.Click += (s, e) => OpenRoleLogin(CreateRole("PH2_TECHNICIAN", "Phân hệ 2", "Kỹ thuật viên", "Thực hiện dịch vụ chẩn đoán", LoginModule.Ph2, Ph2Color));
            btnPh2Patient.Click += (s, e) => OpenRoleLogin(CreateRole("PH2_PATIENT", "Phân hệ 2", "Bệnh nhân", "Xem hồ sơ & tiền sử bệnh", LoginModule.Ph2, Ph2Color));
        }

        private static Color Ph1Color
        {
            get { return Color.FromArgb(43, 76, 132); }
        }

        private static Color Ph2Color
        {
            get { return Color.FromArgb(48, 121, 88); }
        }

        private LoginRoleOption CreateRole(string key, string moduleName, string title, string description, LoginModule module, Color themeColor)
        {
            return new LoginRoleOption(key, moduleName, title, description, module, themeColor);
        }

        private void OpenRoleLogin(LoginRoleOption role)
        {
            Hide();
            using (var login = new RoleLogin(role))
            {
                login.ShowDialog(this);
            }

            if (!IsDisposed)
            {
                Show();
            }
        }
    }

    public enum LoginModule
    {
        Ph1,
        Ph2
    }

    public sealed class LoginRoleOption
    {
        public LoginRoleOption(string key, string moduleName, string title, string description, LoginModule module, Color themeColor)
        {
            Key = key;
            ModuleName = moduleName;
            Title = title;
            Description = description;
            Module = module;
            ThemeColor = themeColor;
        }

        public string Key { get; private set; }
        public string ModuleName { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public LoginModule Module { get; private set; }
        public Color ThemeColor { get; private set; }
    }
}

using System;
using System.Windows.Forms;

namespace HospitalX
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new GUI.RoleSelection());
            Application.Run(new GUI.PH2.Main_DPV());
            //Application.Run(new GUI.PH2.Main_KTV());
            //Application.Run(new GUI.PH2.Main_BS());
            //Application.Run(new GUI.PH2.Main_BN());
            //Application.Run(new GUI.PH2.Main_QTV());
            //Application.Run(new GUI.PH1.Main_PhanHe1());
        }

        // Khai báo hàm API của Windows 
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}

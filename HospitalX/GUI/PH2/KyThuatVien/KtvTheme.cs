using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    internal static class KtvTheme
    {
        public static readonly Color Teal = Color.FromArgb(15, 110, 86);
        public static readonly Color TealDark = Color.FromArgb(10, 79, 61);
        public static readonly Color TealMid = Color.FromArgb(26, 138, 106);
        public static readonly Color TealLight = Color.FromArgb(232, 245, 240);
        public static readonly Color Accent = Color.FromArgb(240, 165, 0);
        public static readonly Color AccentSoft = Color.FromArgb(255, 243, 205);
        public static readonly Color Danger = Color.FromArgb(217, 64, 64);
        public static readonly Color DangerSoft = Color.FromArgb(253, 234, 234);
        public static readonly Color Info = Color.FromArgb(35, 119, 196);
        public static readonly Color InfoSoft = Color.FromArgb(232, 241, 251);
        public static readonly Color Bg = Color.FromArgb(244, 247, 250);
        public static readonly Color Border = Color.FromArgb(226, 235, 240);
        public static readonly Color TextDark = Color.FromArgb(26, 39, 51);
        public static readonly Color TextMid = Color.FromArgb(74, 85, 104);
        public static readonly Color TextLight = Color.FromArgb(136, 152, 170);

        public static Guna2Panel Card(int x, int y, int w, int h)
        {
            return new Guna2Panel
            {
                Location = new Point(x, y),
                Size = new Size(w, h),
                BorderRadius = 12,
                FillColor = Color.White,
                BorderColor = Border,
                BorderThickness = 1
            };
        }

        public static Label Label(string text, int x, int y, float size, FontStyle style, Color color)
        {
            return new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                BackColor = Color.Transparent
            };
        }

        public static Guna2Button Button(string text, Color fill, Color fore)
        {
            return new Guna2Button
            {
                Text = text,
                Size = new Size(120, 34),
                BorderRadius = 8,
                FillColor = fill,
                ForeColor = fore,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand,
                HoverState = { FillColor = fill == Color.White ? TealLight : TealDark, ForeColor = fill == Color.White ? Teal : Color.White }
            };
        }
    }
}

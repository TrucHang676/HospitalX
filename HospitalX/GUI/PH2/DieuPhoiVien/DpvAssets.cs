using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HospitalX.GUI.PH2.DieuPhoiVien
{
    /// <summary>Load icon PNG từ thư mục image (dpv_1.png …).</summary>
    internal static class DpvAssets
    {
        private static string _folder;
        private static readonly object _lock = new object();

        public static string ImageFolder
        {
            get
            {
                if (_folder != null) return _folder;
                lock (_lock)
                {
                    if (_folder != null) return _folder;
                    string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                    string[] candidates =
                    {
                        Path.GetFullPath(Path.Combine(baseDir, @"..\..\..\image\")),
                        Path.GetFullPath(Path.Combine(baseDir, @"..\..\image\")),
                        Path.GetFullPath(Path.Combine(baseDir, @"image\"))
                    };
                    foreach (string path in candidates)
                    {
                        if (Directory.Exists(path))
                        {
                            _folder = path;
                            return _folder;
                        }
                    }
                    _folder = candidates[0];
                    return _folder;
                }
            }
        }

        public static Image Load(int index)
        {
            return Load($"dpv_{index}.png");
        }

        public static Image Load(string fileName)
        {
            try
            {
                string path = Path.Combine(ImageFolder, fileName);
                if (!File.Exists(path)) return null;
                using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
        }

        public static void ApplyButtonImage(Guna.UI2.WinForms.Guna2Button button, int index, int imageSize = 24)
        {
            Image img = Load(index);
            if (img == null) return;
            button.Image = img;
            button.ImageSize = new Size(imageSize, imageSize);
            button.ImageOffset = new Point(10, 0);
            button.TextOffset = new Point(8, 0);
        }
    }
}

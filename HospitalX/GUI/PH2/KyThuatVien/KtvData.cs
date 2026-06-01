using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    /// <summary>
    /// Model ánh xạ một bản ghi dịch vụ từ HSBA_DV JOIN HSBA JOIN BENHNHAN.
    /// Chỉ chứa các trường thực sự tồn tại trong Oracle schema.
    /// </summary>
    internal class KtvService
    {
        // Từ HSBA_DV
        public string MaHsba   { get; set; }  // MAHSBA (PK part)
        public string Service  { get; set; }  // LOAIDV
        public string NgayDv   { get; set; }  // NGAYDV (dd/MM/yyyy)
        public string Time     { get; set; }  // Giờ ngắn gọn từ NGAYDV (HH:mm) — giả lập vì DB lưu DATE
        public string KetQua   { get; set; }  // KETQUA — null → Chờ thực hiện

        // Từ BENHNHAN (JOIN qua HSBA.MABN)
        public string MaBn     { get; set; }  // MABN
        public string Patient  { get; set; }  // TENBN
        public string BnGender { get; set; }  // PHAI
        public string BnDob    { get; set; }  // NGAYSINH (dd/MM/yyyy)
        public string BnCccd   { get; set; }  // CCCD
        public string BnDiaChi { get; set; }  // SONHA + TENDUONG + QUANHUYEN + TINHTP

        // Từ HSBA (trung gian)
        public string RecordId { get; set; }  // MAHSBA — alias để tương thích UI

        // Trạng thái dẫn xuất — KHÔNG lưu trong DB, tính từ KETQUA
        public string Status => string.IsNullOrEmpty(KetQua) ? "Chờ thực hiện" : "Hoàn thành";
    }

    /// <summary>
    /// Thông tin kỹ thuật viên từ bảng NHANVIEN.
    /// Chỉ chứa các cột thực sự tồn tại trong Oracle schema.
    /// </summary>
    internal class KtvTechnician
    {
        public string MaNv       { get; set; }  // MANV
        public string HoTen      { get; set; }  // HOTEN
        public string Phai       { get; set; }  // PHAI
        public string NgaySinh   { get; set; }  // NGAYSINH (dd/MM/yyyy)
        public string Cmnd       { get; set; }  // CMND
        public string QueQuan    { get; set; }  // QUEQUAN
        public string SoDt       { get; set; }  // SODT
        public string VaiTro     { get; set; }  // VAITRO
        public string ChuyenKhoa { get; set; }  // CHUYENKHOA
    }

    internal static class KtvData
    {
        /// <summary>
        /// Trả về thông tin kỹ thuật viên đang đăng nhập (mock — sẽ lấy từ Oracle session sau).
        /// Các trường khớp 1-1 với cột trong NHANVIEN.
        /// </summary>
        public static KtvTechnician CurrentTechnician()
        {
            return new KtvTechnician
            {
                MaNv       = "KTV042",
                HoTen      = "Nguyễn Thị Thu",
                Phai       = "Nữ",
                NgaySinh   = "15/08/1992",
                Cmnd       = "079292013456",
                QueQuan    = "45 Đường Lê Lợi, P.3, TP. Biên Hòa, Đồng Nai",
                SoDt       = "0914 567 890",
                VaiTro     = "Kỹ thuật viên",
                ChuyenKhoa = "Khoa Xét nghiệm"
            };
        }

        /// <summary>
        /// Alias ngắn gọn — dùng bởi Dashboard.
        /// </summary>
        public static string TechnicianName() => CurrentTechnician().HoTen;

        /// <summary>
        /// Danh sách dịch vụ phân công cho KTV này (mock ánh xạ từ HSBA_DV JOIN HSBA JOIN BENHNHAN).
        /// KETQUA = null → Chờ thực hiện; KETQUA != null → Hoàn thành.
        /// </summary>
        public static List<KtvService> Services()
        {
            return new List<KtvService>
            {
                new KtvService
                {
                    MaHsba   = "HSBA00001", RecordId = "HSBA00001",
                    MaBn     = "BN000001",  Patient  = "Trần Văn Bình",
                    BnGender = "Nam",       BnDob    = "12/03/1985",
                    BnCccd   = "079000000001",
                    BnDiaChi = "12 Đường số 1, Quận 1, Hồ Chí Minh",
                    Service  = "Xét nghiệm máu",
                    NgayDv   = "01/06/2026", Time = "07:30",
                    KetQua   = null   // Chờ thực hiện
                },
                new KtvService
                {
                    MaHsba   = "HSBA00002", RecordId = "HSBA00002",
                    MaBn     = "BN000002",  Patient  = "Nguyễn Thị Mai",
                    BnGender = "Nữ",        BnDob    = "07/11/1990",
                    BnCccd   = "079000000002",
                    BnDiaChi = "23 Đường số 2, Quận 3, Hồ Chí Minh",
                    Service  = "Chụp X-Quang",
                    NgayDv   = "01/06/2026", Time = "08:00",
                    KetQua   = null   // Chờ thực hiện
                },
                new KtvService
                {
                    MaHsba   = "HSBA00003", RecordId = "HSBA00003",
                    MaBn     = "BN000003",  Patient  = "Lê Văn Dũng",
                    BnGender = "Nam",       BnDob    = "22/05/1978",
                    BnCccd   = "079000000003",
                    BnDiaChi = "56 Đường số 3, Quận 5, Hồ Chí Minh",
                    Service  = "Siêu âm",
                    NgayDv   = "01/06/2026", Time = "08:30",
                    KetQua   = null   // Chờ thực hiện
                },
                new KtvService
                {
                    MaHsba   = "HSBA00004", RecordId = "HSBA00004",
                    MaBn     = "BN000004",  Patient  = "Phạm Thị Lan",
                    BnGender = "Nữ",        BnDob    = "30/09/1965",
                    BnCccd   = "079000000004",
                    BnDiaChi = "8 Đường số 4, Quận 1, Hồ Chí Minh",
                    Service  = "Xét nghiệm máu",
                    NgayDv   = "01/06/2026", Time = "09:00",
                    KetQua   = "Hồng cầu: 4.5, Bạch cầu: 7.2, Tiểu cầu: 220"
                },
                new KtvService
                {
                    MaHsba   = "HSBA00005", RecordId = "HSBA00005",
                    MaBn     = "BN000005",  Patient  = "Hoàng Văn Tuấn",
                    BnGender = "Nam",       BnDob    = "14/02/1970",
                    BnCccd   = "079000000005",
                    BnDiaChi = "101 Đường số 5, Quận 3, Hồ Chí Minh",
                    Service  = "Siêu âm",
                    NgayDv   = "01/06/2026", Time = "10:00",
                    KetQua   = "Siêu âm ổ bụng: Gan, lách, thận bình thường. Không có dịch tự do."
                },
                new KtvService
                {
                    MaHsba   = "HSBA00006", RecordId = "HSBA00006",
                    MaBn     = "BN000006",  Patient  = "Vũ Thị Hằng",
                    BnGender = "Nữ",        BnDob    = "01/07/1988",
                    BnCccd   = "079000000006",
                    BnDiaChi = "77 Đường số 6, Quận 5, Hồ Chí Minh",
                    Service  = "Chụp X-Quang",
                    NgayDv   = "01/06/2026", Time = "10:30",
                    KetQua   = null   // Chờ thực hiện
                },
                new KtvService
                {
                    MaHsba   = "HSBA00007", RecordId = "HSBA00007",
                    MaBn     = "BN000007",  Patient  = "Phạm Văn Sơn",
                    BnGender = "Nam",       BnDob    = "19/12/1955",
                    BnCccd   = "079000000007",
                    BnDiaChi = "34 Đường số 7, Quận 1, Hồ Chí Minh",
                    Service  = "Xét nghiệm máu",
                    NgayDv   = "01/06/2026", Time = "11:00",
                    KetQua   = "Glucose: 6.2 mmol/L (↑), Cholesterol: 5.8 mmol/L (bình thường)"
                },
            };
        }

        /// <summary>
        /// Tính tuổi từ chuỗi ngày sinh (dd/MM/yyyy).
        /// </summary>
        public static int CalcAge(string dobStr)
        {
            if (DateTime.TryParseExact(dobStr, "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime dob))
            {
                int age = DateTime.Today.Year - dob.Year;
                if (DateTime.Today < dob.AddYears(age)) age--;
                return age;
            }
            return 0;
        }

        /// <summary>
        /// Lấy initials từ họ tên đầy đủ (ký tự đầu họ + ký tự đầu tên).
        /// </summary>
        public static string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "KT";
            var parts = fullName.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 2)
                return (parts[0][0].ToString() + parts[parts.Length - 1][0].ToString()).ToUpper();
            return parts[0].Length > 0 ? parts[0][0].ToString().ToUpper() : "KT";
        }
    }
}

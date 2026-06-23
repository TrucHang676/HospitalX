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
        public string Status
        {
            get
            {
                if (string.IsNullOrEmpty(KetQua))
                    return "Chờ thực hiện";
                string kq = KetQua.Trim();
                if (kq.Equals("Chưa có kết quả", StringComparison.OrdinalIgnoreCase) ||
                    kq.Equals("Chua co ket qua", StringComparison.OrdinalIgnoreCase) ||
                    kq.Equals("Chua c k t qu", StringComparison.OrdinalIgnoreCase) ||
                    kq.StartsWith("Chưa", StringComparison.OrdinalIgnoreCase) ||
                    kq.StartsWith("Chua", StringComparison.OrdinalIgnoreCase))
                {
                    return "Chờ thực hiện";
                }
                return "Hoàn thành";
            }
        }
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
        public string CoSo       { get; set; }  // COSO
    }

    internal static class KtvData
    {
        /// <summary>
        /// Trả về thông tin kỹ thuật viên đang đăng nhập.
        /// </summary>
        public static KtvTechnician CurrentTechnician()
        {
            try
            {
                System.Data.DataTable dt = HospitalX.DAO.ProfileDAO.Instance.GetProfile();
                if (dt != null && dt.Rows.Count > 0)
                {
                    System.Data.DataRow row = dt.Rows[0];
                    var ktv = new KtvTechnician();
                    ktv.MaNv = row["MANV"]?.ToString() ?? HospitalX.DAO.DataProvider.Instance.CurrentUser;
                    ktv.HoTen = row["HOTEN"]?.ToString() ?? "Kỹ thuật viên";
                    ktv.Phai = row["PHAI"]?.ToString() ?? "Nữ";
                    ktv.NgaySinh = row["NGAYSINH"] != DBNull.Value ? Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy") : "01/01/1990";
                    ktv.Cmnd = row["CMND"]?.ToString() ?? "";
                    ktv.QueQuan = row["QUEQUAN"]?.ToString() ?? "";
                    ktv.SoDt = row["SODT"]?.ToString() ?? "";
                    ktv.ChuyenKhoa = row["CHUYENKHOA"]?.ToString() ?? "";
                    ktv.VaiTro = row["VAITRO"]?.ToString() ?? "Kỹ thuật viên";
                    ktv.CoSo = row["COSO"]?.ToString() ?? "";
                    return ktv;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi load profile KTV từ database: " + ex.Message);
            }

            // Fallback
            return new KtvTechnician
            {
                MaNv       = HospitalX.DAO.DataProvider.Instance.CurrentUser ?? "KTV001",
                HoTen      = "Kỹ thuật viên",
                Phai       = "Nữ",
                NgaySinh   = "15/08/1992",
                Cmnd       = "079292013456",
                QueQuan    = "45 Đường Lê Lợi, P.3, Biên Hòa, Đồng Nai",
                SoDt       = "0914 567 890",
                VaiTro     = "Kỹ thuật viên",
                ChuyenKhoa = "Khoa Xét nghiệm",
                CoSo       = "Hồ Chí Minh"
            };
        }

        /// <summary>
        /// Alias ngắn gọn — dùng bởi Dashboard.
        /// </summary>
        public static string TechnicianName() => CurrentTechnician().HoTen;

        /// <summary>
        /// Danh sách dịch vụ phân công cho KTV này (mức dòng/cột từ view VW_HSBA_DV_KTV).
        /// KETQUA = null → Chờ thực hiện; KETQUA != null → Hoàn thành.
        /// </summary>
        public static List<KtvService> Services()
        {
            var list = new List<KtvService>();
            try
            {
                // Gọi stored procedure thay vì raw SQL JOIN 3 bảng (đẩy nghiệp vụ xuống Oracle)
                Oracle.ManagedDataAccess.Client.OracleParameter[] parameters = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                {
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_cursor", Oracle.ManagedDataAccess.Client.OracleDbType.RefCursor) { Direction = System.Data.ParameterDirection.Output }
                };
                System.Data.DataTable dt = HospitalX.DAO.DataProvider.Instance.ExecuteQuery("ADMINHOS.SP_GET_SERVICES_FOR_KTV", parameters, true);
                if (dt != null)
                {
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        var svc = new KtvService();
                        svc.MaHsba = row["MAHSBA"]?.ToString() ?? "";
                        svc.RecordId = svc.MaHsba;
                        svc.Service = row["LOAIDV"]?.ToString() ?? "";
                        
                        DateTime ngayDv = row["NGAYDV"] != DBNull.Value ? Convert.ToDateTime(row["NGAYDV"]) : DateTime.Now;
                        svc.NgayDv = ngayDv.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                        svc.Time = ngayDv.ToString("HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                        
                        svc.KetQua = row["KETQUA"]?.ToString();
                        if (row["KETQUA"] == DBNull.Value) svc.KetQua = null;
                        
                        svc.MaBn = row["MABN"]?.ToString() ?? "";
                        svc.Patient = row["TENBN"]?.ToString() ?? "";
                        svc.BnGender = row["PHAI"]?.ToString() ?? "";
                        
                        if (row["NGAYSINH"] != DBNull.Value)
                            svc.BnDob = Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy");
                        else
                            svc.BnDob = "";
                        
                        svc.BnCccd = row["CCCD"]?.ToString() ?? "";
                        
                        string sonha = row["SONHA"]?.ToString() ?? "";
                        string tenduong = row["TENDUONG"]?.ToString() ?? "";
                        string quanhuyen = row["QUANHUYEN"]?.ToString() ?? "";
                        string tinhtp = row["TINHTP"]?.ToString() ?? "";
                        
                        List<string> addrParts = new List<string>();
                        if (!string.IsNullOrEmpty(sonha)) addrParts.Add(sonha.Trim());
                        if (!string.IsNullOrEmpty(tenduong)) addrParts.Add(tenduong.Trim());
                        if (!string.IsNullOrEmpty(quanhuyen)) addrParts.Add(quanhuyen.Trim());
                        if (!string.IsNullOrEmpty(tinhtp)) addrParts.Add(tinhtp.Trim());
                        svc.BnDiaChi = string.Join(", ", addrParts);
                        
                        list.Add(svc);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi load services KTV từ database: " + ex.Message);
            }
            return list;
        }


        public static bool UpdateServiceResult(string mahsba, string loaidv, string ngaydv, string ketqua)
        {
            try
            {
                // Gọi stored procedure thay vì raw SQL UPDATE (đẩy nghiệp vụ xuống Oracle)
                Oracle.ManagedDataAccess.Client.OracleParameter[] parameters = new Oracle.ManagedDataAccess.Client.OracleParameter[]
                {
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_mahsba", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = mahsba.Trim() },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_loaidv", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = loaidv.Trim() },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_ngaydv", Oracle.ManagedDataAccess.Client.OracleDbType.Varchar2) { Value = ngaydv.Trim() },
                    new Oracle.ManagedDataAccess.Client.OracleParameter("p_ketqua", Oracle.ManagedDataAccess.Client.OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(ketqua) ? (object)DBNull.Value : ketqua.Trim() }
                };
                int rows = HospitalX.DAO.DataProvider.Instance.ExecuteNonQuery("ADMINHOS.SP_UPDATE_SERVICE_RESULT", parameters, true);
                return rows >= 0; // stored proc raises exception on failure, so any non-exception = success
            }
            catch (Exception ex)
            {
                Console.WriteLine("Warning: Lỗi update service result: " + ex.Message);
                return false;
            }
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

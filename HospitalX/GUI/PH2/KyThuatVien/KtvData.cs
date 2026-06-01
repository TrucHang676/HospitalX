using System.Collections.Generic;

namespace HospitalX.GUI.PH2.KyThuatVien
{
    internal class KtvService
    {
        public string Patient { get; set; }
        public string RecordId { get; set; }
        public string Service { get; set; }
        public string Doctor { get; set; }
        public string Time { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Room { get; set; }
    }

    internal static class KtvData
    {
        public static string TechnicianName()
        {
            return "Nguyễn Thị Thu";
        }

        public static List<KtvService> Services()
        {
            return new List<KtvService>
            {
                new KtvService { Patient = "Trần Văn Bình", RecordId = "BV-2025-00412", Service = "Xét nghiệm máu toàn phần (CBC)", Doctor = "BS. Lê Minh Đức", Time = "07:30", Priority = "Khẩn cấp", Status = "Đang thực hiện", Room = "Phòng XN A1" },
                new KtvService { Patient = "Nguyễn Thị Mai", RecordId = "BV-2025-00415", Service = "Sinh hóa máu (Glucose, Cholesterol)", Doctor = "BS. Phạm Anh Tuấn", Time = "08:00", Priority = "Khẩn cấp", Status = "Chờ thực hiện", Room = "Phòng XN A1" },
                new KtvService { Patient = "Lê Văn Dũng", RecordId = "BV-2025-00421", Service = "Phân tích nước tiểu (Urinalysis)", Doctor = "BS. Nguyễn Thị Hoa", Time = "08:30", Priority = "Cao", Status = "Chờ thực hiện", Room = "Phòng XN B2" },
                new KtvService { Patient = "Phạm Thị Lan", RecordId = "BV-2025-00403", Service = "Chụp X-quang ngực thẳng", Doctor = "BS. Trần Quốc Hùng", Time = "09:00", Priority = "Bình thường", Status = "Hoàn thành", Room = "Phòng CĐHA" },
                new KtvService { Patient = "Hoàng Văn Tuấn", RecordId = "BV-2025-00388", Service = "Siêu âm ổ bụng tổng quát", Doctor = "BS. Lê Minh Đức", Time = "10:00", Priority = "Bình thường", Status = "Hoàn thành", Room = "Phòng Siêu âm" },
                new KtvService { Patient = "Vũ Thị Hằng", RecordId = "BV-2025-00435", Service = "Điện tim (ECG 12 chuyển đạo)", Doctor = "BS. Phạm Anh Tuấn", Time = "10:30", Priority = "Cao", Status = "Chờ thực hiện", Room = "Phòng Tim mạch" },
                new KtvService { Patient = "Phạm Văn Sơn", RecordId = "BV-2025-00371", Service = "Đo loãng xương (DEXA Scan)", Doctor = "BS. Nguyễn Thị Hoa", Time = "11:00", Priority = "Bình thường", Status = "Hoàn thành", Room = "Phòng CĐHA" }
            };
        }
    }
}

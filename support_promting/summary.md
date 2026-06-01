# 🏥 HospitalX - Hệ thống Quản trị Bệnh viện X
Dự án phát triển ứng dụng quản lý bệnh viện với trọng tâm là bảo mật dữ liệu và phân quyền người dùng trên nền tảng Oracle Database và C# WinForms.

## 📝 Mô tả đề tài
Dự án được chia thành 2 phân hệ chính với các mục tiêu cụ thể:

### Phân hệ 1: Quản trị Người dùng & Bảo mật dữ liệu
- Tập trung vào vai trò của Database Administrator (DBA). Xây dựng giao diện cho phép quản lý toàn bộ hạ tầng bảo mật của hệ thống Oracle mà không cần dùng dòng lệnh.

- Quản lý danh tính: Tạo, sửa, xóa, khóa/mở khóa tài khoản người dùng và vai trò (Role).

- Kiểm soát truy cập: Cấp và thu hồi quyền hạn (SELECT, INSERT, UPDATE, DELETE, EXECUTE) trên các đối tượng cơ sở dữ liệu.

- Bảo mật mức độ hạt (Granular Security): Triển khai phân quyền đến mức cột cho hành động SELECT (sử dụng VPD cho Table và View-wrapping cho View).

### Phân hệ 2: Quản lý Nghiệp vụ Bệnh viện
- Xây dựng các tiến trình nghiệp vụ thực tế dựa trên dữ liệu nhân viên, bệnh nhân và các hoạt động y tế.

- Quản lý nhân sự: Lưu trữ thông tin chi tiết nhân viên, vị trí công tác và lương bổng.

- Quản lý lương: Tính toán thu nhập, phụ cấp và thuế TNCN.

- Thực thi chính sách: Áp dụng các chính sách bảo mật đã thiết lập ở Phân hệ 1 vào các màn hình chức năng của từng bộ phận (Bác sĩ, Y tá, Kế toán...).

## 🏗️ Kiến trúc
### Mục đích
Cung cấp cái nhìn tổng quan về kiến trúc để dễ dàng tiếp cận và gỡ lỗi. Giải thích các thành phần chính, luồng thực thi và nơi tìm các mã và tài liệu DB quan trọng.

### Các thành phần chính
- **UI**: WinForms với Guna2 (thư mục `GUI/`). Điểm vào chính: `Program.cs` → `Splash` → `Login` → `Main_PhanHe1`.
- **Data Access**: `HospitalX.DAO.DataProvider` — truy cập Oracle tập trung sử dụng `Oracle.ManagedDataAccess`.
- **Logic nghiệp vụ / màn hình**: `GUI/PH1/` chứa `ucDashboard`, `ucUser`, `ucGrantRevoke`, `ucRevoke`.
- **Cơ sở dữ liệu**: PDB `PDBHOSX` với các script PL/SQL trong `SQL/HospitalX_PH1.sql` (các stored procedures, functions, bảng theo dõi VPD).

### Các tài liệu DB quan trọng (trong `HospitalX_PH1.sql`)
- `VPD_COL_TRACKING` — bảng theo dõi các cột ẩn cho SELECT mức cột.
- `SP_GRANT_PRIVILEGE` — SP trung tâm để cấp quyền (xử lý SELECT mức cột qua VPD hoặc view-wrapping).
- `SP_REVOKE_PRIVILEGE` — SP trung tâm để thu hồi quyền (xử lý logic mức bảng, view, cột).
- `USP_LIST_USERS`, `USP_LIST_ROLES`, `USP_GET_OBJ_PRIVS`, `USP_GET_USER_ROLE`, `USP_DASHBOARD_*` — SP trả về REF CURSOR được UI tiêu thụ.
- Các đối tượng demo: `THONGTIN_NHANVIEN`, `LUONG_NHANVIEN`, các view và procs mẫu để kiểm tra.

### Luồng thực thi (đăng nhập → màn hình chính)
1. Ứng dụng khởi động trong `Program.Main` (hiện `Splash`).
2. `Splash` -> hiển thị tiến trình rồi mở `Login`.
3. `Login` xây dựng chuỗi EZConnect và xác thực kết nối + vai trò DBA; nếu thành công, thiết lập chuỗi kết nối `DataProvider.Instance` và mở `Main_PhanHe1`.
4. `Main_PhanHe1` tải các điều khiển người dùng vào `pnlContent` (Dashboard, User, Role, Grant/Revoke). Mỗi UC gọi các thủ tục qua `DataProvider`.

### Cách UI gọi DB
- UI sử dụng `DataProvider.ExecuteQuery` cho các stored procedures trả về `REF CURSOR` và `ExecuteNonQuery` cho các hành động.
- Tên tham số phải khớp với tên tham số PL/SQL (ví dụ: `p_columns` trong `SP_REVOKE_PRIVILEGE`)

### Các điểm gỡ lỗi thường gặp
- **Kết nối**: kiểm tra chuỗi kết nối `DataProvider` hoặc sử dụng các trường Login (host, port, service). Đảm bảo PDB `PDBHOSX` đang mở và `adminHos` tồn tại và có vai trò `DBA`.
- **NuGet**: đảm bảo đã cài đặt `Oracle.ManagedDataAccess` và `Guna.UI2.WinForms`.
- **Lỗi Revoke/Grant**: xác minh tên tham số và logic stored procedure. Đối với SELECT mức cột, ứng dụng sử dụng các view trung gian có tên `V_<OBJ>_...` — proc DB phải xử lý cả việc cấp và thu hồi quyền cho view-wrapped và cập nhật `VPD_COL_TRACKING` chính xác.

### Các tệp quan trọng để kiểm tra khi gỡ lỗi
- `HospitalX\\DAO\DataProvider.cs` — kết nối & wrappers gọi.
- `HospitalX\GUI\Login.cs` — xây dựng chuỗi kết nối và kiểm tra vai trò DBA.
- `HospitalX\GUI\PH1\ucRevoke.cs` và `ucGrantRevoke.cs` — logic UI grant/revoke.
- `HospitalX\Program.cs`, `HospitalX\GUI\Splash.cs`, `HospitalX\GUI\PH1\Main_PhanHe1.cs` — khởi động và điều hướng.
- `SQL\HospitalX_PH1.sql` — tất cả các thủ tục DB, bảng theo dõi VPD, dữ liệu demo.

### Các bước kiểm tra nhanh cho grant/revoke
1. Đảm bảo script DB `HospitalX_PH1.sql` đã được thực thi trong `PDBHOSX`.
2. Đăng nhập với `adminHos`/`123` (hoặc một tài khoản DBA).
3. Sử dụng UI Grant để thiết lập SELECT mức cột (tạo view `V_*`). Xác minh qua `DBA_TAB_PRIVS` / `DBA_COL_PRIVS`.
4. Sử dụng UI Revoke để thu hồi SELECT; sau đó xác minh qua các view DBA tương tự rằng quyền đã bị xóa và `VPD_COL_TRACKING`/các view trung gian đã được cập nhật.

### Ghi chú cho các cộng tác viên
- Tuân theo quy tắc đặt tên và phong cách hiện có. Giữ cho tên tham số PL/SQL và tên tham số C# đồng bộ.
- Nếu thay đổi chữ ký SP DB, cập nhật tất cả các caller trong `GUI/PH1/*.cs`.

---

## 🛠️ Hướng dẫn Cài đặt & Cấu hình
#### 1. Tạo Pluggable Database (PDB)
Dự án sử dụng PDB riêng biệt có tên là PDBHOSX để cô lập dữ liệu bệnh viện.

Kết nối với quyền sysdba và chạy lệnh sau để tạo/mở PDB:

SQL
-- Tạo PDB mới (Nếu chưa có)
CREATE PLUGGABLE DATABASE PDBHOSX ADMIN USER pdbadmin IDENTIFIED BY 123;

-- Mở PDB và lưu trạng thái
ALTER PLUGGABLE DATABASE PDBHOSX OPEN;
ALTER PLUGGABLE DATABASE PDBHOSX SAVE STATE;
#### 2. Chạy Script Database
Mở SQL Developer hoặc công cụ tương đương, kết nối vào PDB PDBHOSX bằng quyền sysdba và thực hiện:

Chạy file `HospitalX_PH1.sql` để thiết lập User quản trị `adminHos`, các Stored Procedure, Function và bảng tracking VPD. Script sẽ tự động tạo bảng `VPD_COL_TRACKING` để quản lý việc ẩn/hiện cột.

#### 3. Khởi động dự án C#
Mở file solution dự án bằng Visual Studio.

Kiểm tra chuỗi kết nối trong `App.config` hoặc lớp `DataProvider.cs` để đảm bảo khớp với User `adminHos` và mật khẩu `123`.

Build và Run dự án.

## 🚀 Các chức năng đã hoàn thành (Phân hệ 1)
#### 👥 Quản lý Người dùng & Vai trò
- CRUD User/Role: Tạo mới, xóa và đổi mật khẩu thông qua Stored Procedure chuyên biệt.

- Account Locking: Khóa tài khoản ngay lập tức khi phát hiện vi phạm hoặc nhân viên nghỉ việc.

- Smart Filter: Tìm kiếm User/Role thời gian thực, lọc theo trạng thái (Open/Locked) và loại vai trò.

#### 🔐 Cơ chế Phân quyền Nâng cao
- Phân quyền cơ bản trên các đối tượng: SELECT/INSERT/UPDATE, DELETE cho TABLE/VIEW, EXECUTE cho PROCEDURE/FUNCTION, GRANT ROLE FOR USER,...

- SELECT mức cột (Table): Sử dụng Oracle VPD để che giấu các cột nhạy cảm. Người dùng vẫn truy vấn trên bảng gốc nhưng các cột không được phép sẽ trả về giá trị NULL.

- SELECT mức cột (View): Sử dụng cơ chế tạo View trung gian động dựa trên tổ hợp cột được cấp, đảm bảo tính tái sử dụng cao giữa các người dùng cùng quyền hạn.

- UPDATE mức cột: Tận dụng tính năng Native của Oracle để giới hạn các trường dữ liệu được phép cập nhật.

#### 📊 Giám sát & Thống kê
- Kiểm tra quyền hạn: Giao diện chi tiết cho phép xem mọi quyền của một User/Role dưới dạng danh sách tách bạch (mỗi cột một dòng).

- Dashboard DBA: Biểu đồ trực quan thống kê tổng số User, Role, Object và số lượng quyền hạn đang được lưu hành trong hệ thống.

## 💻 Công nghệ sử dụng
Database: Oracle 21c/19c (PDB, VPD, DBMS_RLS).

Backend: C# .NET Framework.

UI Library: Guna UI2 (WinForms).

Data Access: Oracle.ManagedDataAccess.

---

## Nhóm thực hiện: NHÓM 12 - CQ2023/1 - FIT HCMUS - INFORMATION SYSTEM SECURITY PROJECT

Danh sách thành viên:

    1. Hoàng Quốc Việt - 23120189
    
    2. Trần Kim Yến - 23120193
    
    3. Nguyễn Thị Trúc Hằng - 23120201
    
    4. Lê Hoàng Nhật Anh - 23120209
    
    5. Lê Lâm Trí Đức - 23120237

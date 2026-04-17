🏥 HospitalX - Hệ thống Quản trị Bệnh viện X
Dự án phát triển ứng dụng quản lý bệnh viện với trọng tâm là bảo mật dữ liệu và phân quyền người dùng trên nền tảng Oracle Database và C# WinForms.

📝 Mô tả đề tài
Dự án được chia thành 2 phân hệ chính với các mục tiêu cụ thể:

Phân hệ 1: Quản trị Người dùng & Bảo mật dữ liệu
Tập trung vào vai trò của Database Administrator (DBA). Xây dựng giao diện cho phép quản lý toàn bộ hạ tầng bảo mật của hệ thống Oracle mà không cần dùng dòng lệnh.

Quản lý danh tính: Tạo, sửa, xóa, khóa/mở khóa tài khoản người dùng và vai trò (Role).

Kiểm soát truy cập: Cấp và thu hồi quyền hạn (SELECT, INSERT, UPDATE, DELETE, EXECUTE) trên các đối tượng cơ sở dữ liệu.

Bảo mật mức độ hạt (Granular Security): Triển khai phân quyền đến mức cột cho hành động SELECT (sử dụng VPD cho Table và View-wrapping cho View).

Phân hệ 2: Quản lý Nghiệp vụ Bệnh viện
Xây dựng các tiến trình nghiệp vụ thực tế dựa trên dữ liệu nhân viên, bệnh nhân và các hoạt động y tế.

Quản lý nhân sự: Lưu trữ thông tin chi tiết nhân viên, vị trí công tác và lương bổng.

Quản lý lương: Tính toán thu nhập, phụ cấp và thuế TNCN.

Thực thi chính sách: Áp dụng các chính sách bảo mật đã thiết lập ở Phân hệ 1 vào các màn hình chức năng của từng bộ phận (Bác sĩ, Y tá, Kế toán...).

🛠️ Hướng dẫn Cài đặt & Cấu hình
1. Tạo Pluggable Database (PDB)
Dự án sử dụng PDB riêng biệt có tên là PDBHOSX để cô lập dữ liệu bệnh viện.

Kết nối với quyền sysdba và chạy lệnh sau để tạo/mở PDB:

SQL
-- Tạo PDB mới (Nếu chưa có)
CREATE PLUGGABLE DATABASE PDBHOSX ADMIN USER pdbadmin IDENTIFIED BY 123;

-- Mở PDB và lưu trạng thái
ALTER PLUGGABLE DATABASE PDBHOSX OPEN;
ALTER PLUGGABLE DATABASE PDBHOSX SAVE STATE;
2. Chạy Script Database
Mở SQL Developer hoặc công cụ tương đương, kết nối vào PDB PDBHOSX bằng quyền sysdba và thực hiện:

Chạy file HospitalX_PH1.sql để thiết lập User quản trị adminHos, các Stored Procedure, Function và bảng tracking VPD.

Script sẽ tự động tạo bảng VPD_COL_TRACKING để quản lý việc ẩn/hiện cột.

3. Khởi động dự án C#
Mở file solution dự án bằng Visual Studio.

Kiểm tra chuỗi kết nối trong App.config hoặc lớp DataProvider.cs để đảm bảo khớp với User adminHos và mật khẩu 123.

Build và Run dự án.

🚀 Các chức năng đã hoàn thành (Phân hệ 1)
👥 Quản lý Người dùng & Vai trò
CRUD User/Role: Tạo mới, xóa và đổi mật khẩu thông qua Stored Procedure chuyên biệt.

Account Locking: Khóa tài khoản ngay lập tức khi phát hiện vi phạm hoặc nhân viên nghỉ việc.

Smart Filter: Tìm kiếm User/Role thời gian thực, lọc theo trạng thái (Open/Locked) và loại vai trò.

🔐 Cơ chế Phân quyền Nâng cao
SELECT mức cột (Table): Sử dụng Oracle VPD để che giấu các cột nhạy cảm. Người dùng vẫn truy vấn trên bảng gốc nhưng các cột không được phép sẽ trả về giá trị NULL.

SELECT mức cột (View): Sử dụng cơ chế tạo View trung gian động dựa trên tổ hợp cột được cấp, đảm bảo tính tái sử dụng cao giữa các người dùng cùng quyền hạn.

UPDATE mức cột: Tận dụng tính năng Native của Oracle để giới hạn các trường dữ liệu được phép cập nhật.

📊 Giám sát & Thống kê
Kiểm tra quyền hạn: Giao diện chi tiết cho phép xem mọi quyền của một User/Role dưới dạng danh sách tách bạch (mỗi cột một dòng).

Dashboard DBA: Biểu đồ trực quan thống kê tổng số User, Role, Object và số lượng quyền hạn đang được lưu hành trong hệ thống.

💻 Công nghệ sử dụng
Database: Oracle 21c/19c (PDB, VPD, DBMS_RLS).

Backend: C# .NET Framework.

UI Library: Guna UI2 (WinForms).

Data Access: Oracle.ManagedDataAccess.

Nhóm thực hiện: NHÓM 12 - CQ2023/1 - FIT HCMUS

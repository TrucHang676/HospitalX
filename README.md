# 🏥 HospitalX - Hệ thống Quản trị Bệnh viện (Oracle DBA)

Dự án môn An toàn và bảo mật dữ liệu trong HTTT - Xây dựng ứng dụng quản lý người dùng và phân quyền trên Oracle Database.

## ✨ Chức năng chính phân hệ 1
- **Hệ thống Đăng nhập:** Xác thực trực tiếp với tài khoản người dùng Oracle.
- **Dashboard tổng quan:** Thống kê số lượng User, Role và các đối tượng DB (Table, View...).
- **Quản lý User/Role:** Tạo mới, chỉnh sửa thông tin và theo dõi trạng thái tài khoản.
- **Phân quyền chi tiết:** - Cấp/Thu hồi quyền trên Object (Select, Insert, Update, Delete).
  - Hỗ trợ cấp quyền mức cột (Column-level privileges).
  - Cấp quyền kèm `WITH GRANT OPTION`.
- **Tra cứu quyền hạn:** Xem danh sách quyền hệ thống và quyền đối tượng của từng User/Role.

## 🛠 Công nghệ sử dụng
- **Ngôn ngữ:** C# (.NET Framework)
- **Giao diện:** WinForms & Guna2 UI Framework
- **Cơ sở dữ liệu:** Oracle Database 19c/21c
- **Thư viện:** Oracle.ManagedDataAccess

## 🚀 Cách chạy dự án
1. Clone dự án: `git clone https://github.com/TrucHang676/HospitalX.git`
2. Mở file `.sln` bằng Visual Studio 2022.
3. Restore các NuGet Package (Guna2, Oracle Managed Data Access).
4. Build và Run (F5).

---
*Thực hiện bởi nhóm 12*
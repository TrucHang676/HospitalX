using System;
using System.Data;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using HospitalX.GUI.PH2.BacSi;

namespace HospitalX.DAO
{
    public class HsbaDAO
    {
        public static string GetNextHsbaId()
        {
            string sql = "SELECT ADMINHOS.PKG_VPD_YC1C3.FN_GET_NEXT_HSBA_ID() FROM DUAL";
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, null, false);
            return dt.Rows[0][0].ToString().Trim();
        }

        public static bool InsertHsba(
            string maHsba, string maBn, DateTime ngay, string chanDoan,
            string dieuTri, string maBs, string maKhoa, string ketLuan)
        {
            string sql = @"
                INSERT INTO ADMINHOS.HSBA (
                    MAHSBA, MABN, NGAY, CHANDOAN, DIEUTRI, MABS, MAKHOA, KETLUAN
                ) VALUES (
                    :maHsba, :maBn, :ngay, :chanDoan, :dieuTri, :maBs, :maKhoa, :ketLuan
                )
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":maBn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter(":ngay", OracleDbType.Date) { Value = ngay },
                new OracleParameter(":chanDoan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(chanDoan) ? (object)DBNull.Value : chanDoan.Trim() },
                new OracleParameter(":dieuTri", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(dieuTri) ? (object)DBNull.Value : dieuTri.Trim() },
                new OracleParameter(":maBs", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(maBs) ? (object)DBNull.Value : maBs.Trim() },
                new OracleParameter(":maKhoa", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(maKhoa) ? (object)DBNull.Value : maKhoa.Trim() },
                new OracleParameter(":ketLuan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(ketLuan) ? (object)DBNull.Value : ketLuan.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static DataTable GetDoctorsForTaoHSBA(string specialty)
        {
            string sql = @"
                SELECT MANV, HOTEN, CHUYENKHOA
                FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI
                WHERE VAITRO = N'Bác sĩ/Y sĩ'
                  AND CHUYENKHOA = :specialty
                ORDER BY MANV ASC
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":specialty", OracleDbType.NVarchar2) { Value = specialty.Trim() }
            };
            return DataProvider.Instance.ExecuteQuery(sql, parameters, false);
        }

        public static DataTable GetDepartments()
        {
            string sql = @"
                SELECT DISTINCT CHUYENKHOA 
                FROM ADMINHOS.VW_NHANVIEN_DIEUPHOI 
                WHERE CHUYENKHOA IS NOT NULL 
                  AND VAITRO = N'Bác sĩ/Y sĩ'
                ORDER BY CHUYENKHOA ASC
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static DataTable GetHsbaForDieuPhoi()
        {
            string sql = @"
                SELECT 
                    HS.MAHSBA,
                    HS.MABN,
                    BN.TENBN AS TEN_BENH_NHAN,
                    HS.NGAY,
                    HS.CHANDOAN,
                    HS.DIEUTRI,
                    HS.MABS,
                    HS.MAKHOA,
                    BS.HOTEN AS TEN_BACSI,
                    BS.CHUYENKHOA AS CHUYENKHOA_BACSI,
                    HS.KETLUAN,
                    CASE WHEN HS.MABS IS NULL OR BS.MANV IS NOT NULL THEN 1 ELSE 0 END AS CUNG_CO_SO
                FROM ADMINHOS.HSBA HS
                LEFT JOIN ADMINHOS.BENHNHAN BN
                    ON HS.MABN = BN.MABN
                LEFT JOIN ADMINHOS.VW_NHANVIEN_DIEUPHOI BS
                    ON HS.MABS = BS.MANV
                   AND TRIM(BS.VAITRO) = N'Bác sĩ/Y sĩ'
                ORDER BY HS.MAHSBA
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static bool UpdateHsbaDepartmentAndDoctor(string maHsba, string maKhoa, string maBs)
        {
            string sql = @"
                UPDATE ADMINHOS.HSBA
                SET MAKHOA = :maKhoa,
                    MABS = :maBs
                WHERE MAHSBA = :maHsba
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maKhoa", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maKhoa) ? (object)DBNull.Value : maKhoa.Trim() },
                new OracleParameter(":maBs", OracleDbType.Varchar2) { Value = string.IsNullOrEmpty(maBs) ? (object)DBNull.Value : maBs.Trim() },
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static DataTable GetHsbaForDoctor()
        {
            string sql = @"
                SELECT 
                    HS.MAHSBA,
                    HS.MABN,
                    BN.TENBN AS TEN_BENH_NHAN,
                    BN.PHAI AS GIOI_TINH,
                    BN.NGAYSINH,
                    BN.CCCD,
                    BN.SONHA,
                    BN.TENDUONG,
                    BN.QUANHUYEN,
                    BN.TINHTP,
                    BN.DIUNGTHUOC,
                    BN.TIENSUBENH,
                    HS.NGAY,
                    HS.CHANDOAN,
                    HS.DIEUTRI,
                    HS.MAKHOA,
                    HS.KETLUAN
                FROM ADMINHOS.HSBA HS
                LEFT JOIN ADMINHOS.BENHNHAN BN
                    ON HS.MABN = BN.MABN
                ORDER BY HS.NGAY DESC
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static DataTable GetServicesForHsba(string maHsba)
        {
            string sql = @"
                SELECT LOAIDV, NGAYDV, MAKTV, KETQUA
                FROM ADMINHOS.HSBA_DV
                WHERE MAHSBA = :maHsba
                ORDER BY NGAYDV ASC
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };
            return DataProvider.Instance.ExecuteQuery(sql, parameters, false);
        }

        public static bool DeleteHsbaService(string maHsba, string loaiDv, DateTime ngayDv)
        {
            string sql = @"
                DELETE FROM ADMINHOS.HSBA_DV
                WHERE MAHSBA = :maHsba
                  AND LOAIDV = :loaiDv
                  AND NGAYDV = :ngayDv
                  AND MAKTV IS NULL
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":loaiDv", OracleDbType.NVarchar2) { Value = loaiDv.Trim() },
                new OracleParameter(":ngayDv", OracleDbType.Date) { Value = ngayDv }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static DataTable GetPrescriptionsForHsba(string maHsba)
        {
            string sql = @"
                SELECT TENTHUOC, LIEUDUNG
                FROM ADMINHOS.DONTHUOC
                WHERE MAHSBA = :maHsba
                ORDER BY NGAYDT ASC
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };
            return DataProvider.Instance.ExecuteQuery(sql, parameters, false);
        }

        public static bool UpdateHsbaDetails(string maHsba, string chanDoan, string dieuTri, string ketLuan)
        {
            string sql = @"
                UPDATE ADMINHOS.HSBA
                SET CHANDOAN = :chanDoan,
                    DIEUTRI = :dieuTri
                WHERE MAHSBA = :maHsba
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":chanDoan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(chanDoan) ? (object)DBNull.Value : chanDoan.Trim() },
                new OracleParameter(":dieuTri", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(dieuTri) ? (object)DBNull.Value : dieuTri.Trim() },
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);

            string spSql = "ADMINHOS.SP_CAPNHAT_KETLUAN_HSBA";
            OracleParameter[] spParams = new OracleParameter[]
            {
                new OracleParameter("p_mahsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter("p_ketluan", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(ketLuan) ? (object)DBNull.Value : ketLuan.Trim() }
            };
            int spResult = DataProvider.Instance.ExecuteNonQuery(spSql, spParams, true);

            return result > 0 || spResult > 0;
        }

        public static bool InsertHsbaService(string maHsba, string loaiDv, string ketQua)
        {
            string sql = @"
                INSERT INTO ADMINHOS.HSBA_DV (
                    MAHSBA, LOAIDV, NGAYDV, MAKTV, KETQUA
                ) VALUES (
                    :maHsba, :loaiDv, SYSDATE, NULL, N'Chưa có kết quả'
                )
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":loaiDv", OracleDbType.NVarchar2) { Value = loaiDv.Trim() }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static bool InsertDonThuoc(string maHsba, string tenThuoc, string lieuDung)
        {
            string sql = @"
                INSERT INTO ADMINHOS.DONTHUOC (
                    MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG
                ) VALUES (
                    :maHsba, SYSDATE, :tenThuoc, :lieuDung
                )
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":tenThuoc", OracleDbType.NVarchar2) { Value = tenThuoc.Trim() },
                new OracleParameter(":lieuDung", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(lieuDung) ? (object)DBNull.Value : lieuDung.Trim() }
            };
            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static DataTable GetHsbaForPatient(string maBn)
        {
            string sql = @"
                SELECT 
                    HS.MAHSBA,
                    HS.MABN,
                    BN.TENBN AS TEN_BENH_NHAN,
                    BN.PHAI AS GIOI_TINH,
                    BN.NGAYSINH,
                    BN.CCCD,
                    BN.SONHA,
                    BN.TENDUONG,
                    BN.QUANHUYEN,
                    BN.TINHTP,
                    BN.DIUNGTHUOC,
                    BN.TIENSUBENH,
                    HS.NGAY,
                    HS.CHANDOAN,
                    HS.DIEUTRI,
                    HS.MAKHOA,
                    HS.KETLUAN
                FROM ADMINHOS.HSBA HS
                LEFT JOIN ADMINHOS.BENHNHAN BN
                    ON HS.MABN = BN.MABN
                WHERE HS.MABN = :maBn
                ORDER BY HS.NGAY DESC
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maBn", OracleDbType.Varchar2) { Value = maBn.Trim() }
            };
            return DataProvider.Instance.ExecuteQuery(sql, parameters, false);
        }

        public static ucHSBA.HsbaRecord GetHsbaDetailsById(string maHsba)
        {
            string sql = @"
                SELECT 
                    HS.MAHSBA,
                    HS.MABN,
                    BN.TENBN AS TEN_BENH_NHAN,
                    BN.PHAI AS GIOI_TINH,
                    BN.NGAYSINH,
                    BN.CCCD,
                    BN.SONHA,
                    BN.TENDUONG,
                    BN.QUANHUYEN,
                    BN.TINHTP,
                    BN.DIUNGTHUOC,
                    BN.TIENSUBENH,
                    HS.NGAY,
                    HS.CHANDOAN,
                    HS.DIEUTRI,
                    HS.MAKHOA,
                    HS.KETLUAN
                FROM ADMINHOS.HSBA HS
                LEFT JOIN ADMINHOS.BENHNHAN BN
                    ON HS.MABN = BN.MABN
                WHERE HS.MAHSBA = :maHsba
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() }
            };
            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, parameters, false);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var rec = new ucHSBA.HsbaRecord
                {
                    Id = row["MAHSBA"].ToString().Trim(),
                    PatientCode = row["MABN"].ToString().Trim(),
                    PatientName = row["TEN_BENH_NHAN"].ToString().Trim(),
                    Gender = row["GIOI_TINH"].ToString().Trim(),
                    BirthDate = row["NGAYSINH"] != DBNull.Value ? Convert.ToDateTime(row["NGAYSINH"]).ToString("dd/MM/yyyy") : "",
                    CreatedDate = row["NGAY"] != DBNull.Value ? Convert.ToDateTime(row["NGAY"]) : DateTime.Today,
                    CitizenId = row["CCCD"] != DBNull.Value ? row["CCCD"].ToString().Trim() : "",
                    Address = (row["SONHA"] != DBNull.Value ? row["SONHA"].ToString().Trim() + " " : "") +
                              (row["TENDUONG"] != DBNull.Value ? row["TENDUONG"].ToString().Trim() + ", " : "") +
                              (row["QUANHUYEN"] != DBNull.Value ? row["QUANHUYEN"].ToString().Trim() + ", " : "") +
                              (row["TINHTP"] != DBNull.Value ? row["TINHTP"].ToString().Trim() : ""),
                    Allergy = row["DIUNGTHUOC"] != DBNull.Value ? row["DIUNGTHUOC"].ToString().Trim() : "",
                    MedicalHistory = row["TIENSUBENH"] != DBNull.Value ? row["TIENSUBENH"].ToString().Trim() : "",
                    Diagnosis = row["CHANDOAN"] != DBNull.Value ? row["CHANDOAN"].ToString().Trim() : "",
                    Treatment = row["DIEUTRI"] != DBNull.Value ? row["DIEUTRI"].ToString().Trim() : "",
                    Conclusion = row["KETLUAN"] != DBNull.Value ? row["KETLUAN"].ToString().Trim() : "",
                    Department = row["MAKHOA"] != DBNull.Value ? row["MAKHOA"].ToString().Trim() : "",
                    Services = new List<string>(),
                    Prescriptions = new List<string>()
                };

                if (row["NGAYSINH"] != DBNull.Value)
                {
                    DateTime dob = Convert.ToDateTime(row["NGAYSINH"]);
                    rec.Age = DateTime.Today.Year - dob.Year;
                }

                DataTable dtServices = GetServicesForHsba(rec.Id);
                if (dtServices != null)
                {
                    foreach (DataRow sRow in dtServices.Rows)
                    {
                        string loai = sRow["LOAIDV"].ToString().Trim();
                        string kq = sRow["KETQUA"] != DBNull.Value ? sRow["KETQUA"].ToString().Trim() : "";
                        rec.Services.Add(loai + (!string.IsNullOrEmpty(kq) ? " - " + kq : ""));
                    }
                }

                DataTable dtRx = GetPrescriptionsForHsba(rec.Id);
                if (dtRx != null)
                {
                    foreach (DataRow rRow in dtRx.Rows)
                    {
                        string thuoc = rRow["TENTHUOC"].ToString().Trim();
                        string lieu = rRow["LIEUDUNG"] != DBNull.Value ? rRow["LIEUDUNG"].ToString().Trim() : "";
                        rec.Prescriptions.Add(thuoc + (!string.IsNullOrEmpty(lieu) ? " - " + lieu : ""));
                    }
                }

                return rec;
            }
            return null;
        }
    }
}

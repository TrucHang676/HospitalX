using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class PatientDAO
    {
        public static DataTable GetAllPatients()
        {
            string sql = @"
                SELECT 
                    MABN, TENBN, PHAI, NGAYSINH, CCCD, SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC 
                FROM ADMINHOS.BENHNHAN
                ORDER BY MABN
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static DataTable SearchPatient(string query)
        {
            string sql = @"
                SELECT 
                    MABN, TENBN, PHAI, NGAYSINH, CCCD, SONHA, TENDUONG, QUANHUYEN, TINHTP, TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC 
                FROM ADMINHOS.BENHNHAN
                WHERE LOWER(MABN) = :query1 
                   OR LOWER(TENBN) = :query2 
                   OR CCCD = :cccd
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":query1", OracleDbType.Varchar2) { Value = query.Trim().ToLower() },
                new OracleParameter(":query2", OracleDbType.NVarchar2) { Value = query.Trim().ToLower() },
                new OracleParameter(":cccd", OracleDbType.Varchar2) { Value = query.Trim() }
            };

            return DataProvider.Instance.ExecuteQuery(sql, parameters, false);
        }

        public static string GetNextPatientId()
        {
            string sql = @"
                SELECT NVL(MAX(TO_NUMBER(SUBSTR(MABN, 3))), 0) + 1
                FROM ADMINHOS.BENHNHAN
                WHERE MABN LIKE 'BN%'
            ";

            DataTable dt = DataProvider.Instance.ExecuteQuery(sql, null, false);

            long nextNum = Convert.ToInt64(dt.Rows[0][0]);

            return "BN" + nextNum.ToString("D6");
        }

        public static bool InsertPatient(
            string maBn, string tenBn, string phai, DateTime ngaySinh, string cccd,
            string soNha, string tenDuong, string quanHuyen, string tinhTp,
            string tienSuBenh, string tienSuBenhGd, string diUngThuoc)
        {
            string sql = @"
                INSERT INTO ADMINHOS.BENHNHAN (
                    MABN, TENBN, PHAI, NGAYSINH, CCCD, 
                    SONHA, TENDUONG, QUANHUYEN, TINHTP, 
                    TIENSUBENH, TIENSUBENHGD, DIUNGTHUOC
                ) VALUES (
                    :maBn, :tenBn, :phai, :ngaySinh, :cccd, 
                    :soNha, :tenDuong, :quanHuyen, :tinhTp, 
                    :tienSuBenh, :tienSuBenhGd, :diUngThuoc
                )
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maBn", OracleDbType.Varchar2) { Value = maBn.Trim() },
                new OracleParameter(":tenBn", OracleDbType.NVarchar2) { Value = tenBn.Trim() },
                new OracleParameter(":phai", OracleDbType.NVarchar2) { Value = phai.Trim() },
                new OracleParameter(":ngaySinh", OracleDbType.Date) { Value = ngaySinh },
                new OracleParameter(":cccd", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(cccd) ? (object)DBNull.Value : cccd.Trim() },
                new OracleParameter(":soNha", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(soNha) ? (object)DBNull.Value : soNha.Trim() },
                new OracleParameter(":tenDuong", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tenDuong) ? (object)DBNull.Value : tenDuong.Trim() },
                new OracleParameter(":quanHuyen", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(quanHuyen) ? (object)DBNull.Value : quanHuyen.Trim() },
                new OracleParameter(":tinhTp", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tinhTp) ? (object)DBNull.Value : tinhTp.Trim() },
                new OracleParameter(":tienSuBenh", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenh) ? (object)DBNull.Value : tienSuBenh.Trim() },
                new OracleParameter(":tienSuBenhGd", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenhGd) ? (object)DBNull.Value : tienSuBenhGd.Trim() },
                new OracleParameter(":diUngThuoc", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(diUngThuoc) ? (object)DBNull.Value : diUngThuoc.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static bool UpdatePatient(
            string maBn, string tenBn, string phai, DateTime ngaySinh, string cccd,
            string soNha, string tenDuong, string quanHuyen, string tinhTp,
            string tienSuBenh, string tienSuBenhGd, string diUngThuoc)
        {
            string sql = @"
                UPDATE ADMINHOS.BENHNHAN 
                SET 
                    TENBN = :tenBn, 
                    PHAI = :phai, 
                    NGAYSINH = :ngaySinh, 
                    CCCD = :cccd, 
                    SONHA = :soNha, 
                    TENDUONG = :tenDuong, 
                    QUANHUYEN = :quanHuyen, 
                    TINHTP = :tinhTp, 
                    TIENSUBENH = :tienSuBenh, 
                    TIENSUBENHGD = :tienSuBenhGd, 
                    DIUNGTHUOC = :diUngThuoc
                WHERE MABN = :maBn
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":tenBn", OracleDbType.NVarchar2) { Value = tenBn.Trim() },
                new OracleParameter(":phai", OracleDbType.NVarchar2) { Value = phai.Trim() },
                new OracleParameter(":ngaySinh", OracleDbType.Date) { Value = ngaySinh },
                new OracleParameter(":cccd", OracleDbType.Varchar2) { Value = string.IsNullOrWhiteSpace(cccd) ? (object)DBNull.Value : cccd.Trim() },
                new OracleParameter(":soNha", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(soNha) ? (object)DBNull.Value : soNha.Trim() },
                new OracleParameter(":tenDuong", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tenDuong) ? (object)DBNull.Value : tenDuong.Trim() },
                new OracleParameter(":quanHuyen", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(quanHuyen) ? (object)DBNull.Value : quanHuyen.Trim() },
                new OracleParameter(":tinhTp", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tinhTp) ? (object)DBNull.Value : tinhTp.Trim() },
                new OracleParameter(":tienSuBenh", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenh) ? (object)DBNull.Value : tienSuBenh.Trim() },
                new OracleParameter(":tienSuBenhGd", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(tienSuBenhGd) ? (object)DBNull.Value : tienSuBenhGd.Trim() },
                new OracleParameter(":diUngThuoc", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(diUngThuoc) ? (object)DBNull.Value : diUngThuoc.Trim() },
                new OracleParameter(":maBn", OracleDbType.Varchar2) { Value = maBn.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }

        public static DataTable GetPatientsForDoctor()
        {
            string sql = @"
                SELECT
                    BN.MABN,
                    BN.TENBN,
                    BN.PHAI,
                    BN.NGAYSINH,
                    FLOOR(MONTHS_BETWEEN(SYSDATE, BN.NGAYSINH) / 12) AS TUOI,
                    BN.CCCD,
                    BN.SONHA,
                    BN.TENDUONG,
                    BN.QUANHUYEN,
                    BN.TINHTP,
                    BN.TIENSUBENH,
                    BN.TIENSUBENHGD,
                    BN.DIUNGTHUOC,
                    (
                        SELECT COUNT(*)
                        FROM ADMINHOS.HSBA HS
                        WHERE HS.MABN = BN.MABN
                    ) AS SO_HSBA,
                    (
                        SELECT COUNT(*)
                        FROM ADMINHOS.DONTHUOC DT
                        JOIN ADMINHOS.HSBA HS
                            ON DT.MAHSBA = HS.MAHSBA
                        WHERE HS.MABN = BN.MABN
                    ) AS SO_DONTHUOC
                FROM ADMINHOS.BENHNHAN BN
                ORDER BY BN.MABN
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static bool UpdatePatientHistory(string maBn, string allergy, string medicalHistory, string familyHistory)
        {
            string sql = @"
                UPDATE ADMINHOS.BENHNHAN
                SET DIUNGTHUOC = :allergy,
                    TIENSUBENH = :medicalHistory,
                    TIENSUBENHGD = :familyHistory
                WHERE MABN = :maBn
            ";

            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":allergy", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(allergy) ? (object)DBNull.Value : allergy.Trim() },
                new OracleParameter(":medicalHistory", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(medicalHistory) ? (object)DBNull.Value : medicalHistory.Trim() },
                new OracleParameter(":familyHistory", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(familyHistory) ? (object)DBNull.Value : familyHistory.Trim() },
                new OracleParameter(":maBn", OracleDbType.Varchar2) { Value = maBn.Trim() }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(sql, parameters, false);
            return result > 0;
        }
    }
}

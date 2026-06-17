using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace HospitalX.DAO
{
    public class PrescriptionDAO
    {
        public static DataTable GetPrescriptionsForDoctor()
        {
            string sql = @"
                SELECT
                    DT.MAHSBA,
                    DT.NGAYDT,
                    HS.MABN,
                    BN.TENBN,
                    BN.PHAI,
                    FLOOR(MONTHS_BETWEEN(SYSDATE, BN.NGAYSINH) / 12) AS TUOI,
                    DT.TENTHUOC,
                    DT.LIEUDUNG
                FROM ADMINHOS.DONTHUOC DT
                JOIN ADMINHOS.HSBA HS
                    ON DT.MAHSBA = HS.MAHSBA
                JOIN ADMINHOS.BENHNHAN BN
                    ON HS.MABN = BN.MABN
                ORDER BY DT.NGAYDT DESC, DT.MAHSBA ASC
            ";
            return DataProvider.Instance.ExecuteQuery(sql, null, false);
        }

        public static bool InsertDrug(string maHsba, DateTime ngayDt, string tenThuoc, string lieuDung)
        {
            string sql = @"
                INSERT INTO ADMINHOS.DONTHUOC (MAHSBA, NGAYDT, TENTHUOC, LIEUDUNG)
                VALUES (:maHsba, :ngayDt, :tenThuoc, :lieuDung)
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":ngayDt", OracleDbType.Date) { Value = ngayDt },
                new OracleParameter(":tenThuoc", OracleDbType.NVarchar2) { Value = tenThuoc.Trim() },
                new OracleParameter(":lieuDung", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(lieuDung) ? (object)DBNull.Value : lieuDung.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(sql, parameters, false) > 0;
        }

        public static bool UpdateDrug(string maHsba, DateTime ngayDt, string oldTenThuoc, string newTenThuoc, string newLieuDung)
        {
            string sql = @"
                UPDATE ADMINHOS.DONTHUOC
                SET TENTHUOC = :newTenThuoc,
                    LIEUDUNG = :newLieuDung
                WHERE MAHSBA = :maHsba
                  AND NGAYDT = :ngayDt
                  AND TENTHUOC = :oldTenThuoc
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":newTenThuoc", OracleDbType.NVarchar2) { Value = newTenThuoc.Trim() },
                new OracleParameter(":newLieuDung", OracleDbType.NVarchar2) { Value = string.IsNullOrWhiteSpace(newLieuDung) ? (object)DBNull.Value : newLieuDung.Trim() },
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":ngayDt", OracleDbType.Date) { Value = ngayDt },
                new OracleParameter(":oldTenThuoc", OracleDbType.NVarchar2) { Value = oldTenThuoc.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(sql, parameters, false) > 0;
        }

        public static bool DeleteDrug(string maHsba, DateTime ngayDt, string tenThuoc)
        {
            string sql = @"
                DELETE FROM ADMINHOS.DONTHUOC
                WHERE MAHSBA = :maHsba
                  AND NGAYDT = :ngayDt
                  AND TENTHUOC = :tenThuoc
            ";
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter(":maHsba", OracleDbType.Varchar2) { Value = maHsba.Trim() },
                new OracleParameter(":ngayDt", OracleDbType.Date) { Value = ngayDt },
                new OracleParameter(":tenThuoc", OracleDbType.NVarchar2) { Value = tenThuoc.Trim() }
            };
            return DataProvider.Instance.ExecuteNonQuery(sql, parameters, false) > 0;
        }
    }
}

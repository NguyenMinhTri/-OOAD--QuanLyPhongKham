using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAOBenhNhan
    {
        public DTOBenhNhan ConvertToBenhNhan(DataRow row)
        {
            DTOBenhNhan benhnhan = new DTOBenhNhan();
            benhnhan.MaBN =int.Parse(row["MaBN"].ToString());
            benhnhan.Ten = row["Ten"].ToString();
            benhnhan.NgheNghiep = row["NgheNghiep"].ToString();
            benhnhan.SDT = row["SDT"].ToString();
            benhnhan.Tuoi = int.Parse(row["Tuoi"].ToString());
            benhnhan.DiaChi = row["DiaChi"].ToString();
            benhnhan.CMND = row["CMND"].ToString();
            return benhnhan;
        }

        public bool Them(DTOBenhNhan BenhNhan)
        {
            if (DatabaseConnection.Instance == null)
                return false;
            string spName = "spBenhNhan_Them";
            SqlParameter sqlprTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 50) { Value = BenhNhan.Ten };
            SqlParameter sqlprTuoi = new SqlParameter("@Tuoi", SqlDbType.Int) { Value = BenhNhan.Tuoi };
            SqlParameter sqlprDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50) { Value = BenhNhan.DiaChi };
            SqlParameter sqlprSDT = new SqlParameter("@SDT", SqlDbType.NVarChar, 50) { Value = BenhNhan.SDT };
            SqlParameter sqlprNgheNghiep = new SqlParameter("@NgheNghiep", SqlDbType.NVarChar, 50) { Value = BenhNhan.NgheNghiep };
            SqlParameter sqlprCMND = new SqlParameter("@NgheNghiep", SqlDbType.NVarChar, 50) { Value = BenhNhan.NgheNghiep };
            return DatabaseConnection.Instance.ExecuteStoredProcedureNonQuery(spName,sqlprTen, sqlprTuoi, sqlprDiaChi,
                sqlprSDT, sqlprNgheNghiep, sqlprCMND);
        }

        public bool Xoa(DTOBenhNhan BenhNhan)
        {
            if (DatabaseConnection.Instance == null)
                return false;
            string spName = "spBenhNhan_Xoa";
            SqlParameter sqlprMaBN = new SqlParameter("@MaBN", SqlDbType.Int) { Value = BenhNhan.MaBN };
            return DatabaseConnection.Instance.ExecuteStoredProcedureNonQuery(spName, sqlprMaBN);
        }

        public bool CapNhat(DTOBenhNhan BenhNhan)
        {
            if (DatabaseConnection.Instance == null)
                return false;
            string spName = "spBenhNhan_CapNhat";
            SqlParameter sqlprMaBN = new SqlParameter("@MaBN", SqlDbType.Int) { Value = BenhNhan.MaBN };
            SqlParameter sqlprTen = new SqlParameter("@Ten", SqlDbType.NVarChar, 50) { Value = BenhNhan.Ten };
            SqlParameter sqlprTuoi = new SqlParameter("@Tuoi", SqlDbType.Int) { Value = BenhNhan.Tuoi };
            SqlParameter sqlprDiaChi = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50) { Value = BenhNhan.DiaChi };
            SqlParameter sqlprSDT = new SqlParameter("@SDT", SqlDbType.NVarChar, 50) { Value = BenhNhan.SDT };
            SqlParameter sqlprNgheNghiep = new SqlParameter("@NgheNghiep", SqlDbType.NVarChar, 50) { Value = BenhNhan.NgheNghiep };
            SqlParameter sqlprCMND = new SqlParameter("@NgheNghiep", SqlDbType.NVarChar, 50) { Value = BenhNhan.NgheNghiep };
            return DatabaseConnection.Instance.ExecuteStoredProcedureNonQuery(spName, sqlprMaBN, sqlprTen, sqlprTuoi, sqlprDiaChi,
                sqlprSDT, sqlprNgheNghiep, sqlprCMND);
        }

        public DTOBenhNhan ThongTin(int MaBN)
        {
            if (DatabaseConnection.Instance == null)
                return null;
            string spName = "spBenhNhan_ThongTin";
            SqlParameter sqlprMaBN = new SqlParameter("@MaBN", SqlDbType.Int) { Value = MaBN };
            DataTable data = DatabaseConnection.Instance.ExecuteStoredProcedure(spName, sqlprMaBN);
            if (data == null || data.Rows.Count == 0)
                return null;
            return ConvertToBenhNhan(data.Rows[0]);
        }
    }
}

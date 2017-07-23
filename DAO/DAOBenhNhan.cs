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
        public bool ThemBenhNhan(DTOBenhNhan BenhNhan)
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
    }
}

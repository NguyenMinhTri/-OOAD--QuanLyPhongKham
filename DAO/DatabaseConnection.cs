using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    //-----------------------------------------
    //Desc: Class thực hiện kết nối với csdl
    //-----------------------------------------
    public class DatabaseConnection
    {
        private static DatabaseConnection instance;
        public static DatabaseConnection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseConnection();
                }
                return instance;
            }
        }
        //-----------------------------------------
        //Desc: Kết nối với csdl sql
        //-----------------------------------------
        private SqlConnection _sqlConn;
        public SqlConnection SqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = value; }
        }
        //-----------------------------------------
        //Desc: Khởi tạo kết nối
        //-----------------------------------------
        private DatabaseConnection()
        {
            _sqlConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\QuanLyDieuTriBenh.mdf;Integrated Security=True");
        }
        //-----------------------------------------
        //Desc: Mở kết nối
        //-----------------------------------------
        public bool Open()
        {
            try
            {
                _sqlConn.Open();
            }
            catch(Exception ex)
            {
                string check = ex.ToString();
                return false;
            }
            return true;
        }

        //-----------------------------------------
        //Desc: Đóng kết nối
        //-----------------------------------------
        public bool Close()
        {
            try
            {
                _sqlConn.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        //-----------------------------------------
        //Desc: thực thi stored procedure trả về datatable
        //-----------------------------------------
        public DataTable ExecuteStoredProcedure(string spName, params SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCmd = new SqlCommand(spName, _sqlConn) { CommandType = CommandType.StoredProcedure };
            if (sqlParameters != null && sqlParameters.Length > 0)
            {
                foreach (SqlParameter sqlParam in sqlParameters)
                {
                    try
                    {
                        sqlCmd.Parameters.Add(sqlParam);
                    }
                    catch { return null; }
                }
            }

            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            if (Open())
            {
                //đổ dữ liệu vào data table
                try
                {
                    sqlDa.Fill(dt);
                }
                catch
                {
                    Close();
                    return null;
                }
                Close();
            }
            else
                return null;
            return dt;
        }

        //-----------------------------------------
        //Desc: thực thi stored procedure trả về true/false
        //-----------------------------------------
        public bool ExecuteStoredProcedureNonQuery(string spName, params SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCmd = new SqlCommand(spName, _sqlConn) { CommandType = CommandType.StoredProcedure };
            if (sqlParameters != null && sqlParameters.Length > 0)
            {
                foreach (SqlParameter sqlParam in sqlParameters)
                {
                    try
                    {
                        sqlCmd.Parameters.Add(sqlParam);
                    }
                    catch { return false; }
                }
            }
            if (Open())
            {
                try
                {
                    sqlCmd.ExecuteNonQuery();
                }
                catch
                {
                    Close();
                    return false;
                }
                Close();
                return true;
            }
            else
                return false;
        }

        //-----------------------------------------
        //Desc: thực thi store procedure trả về số lượng
        //-----------------------------------------
        public object ExecuteStoredProcedureScalar(string spName, params SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCmd = new SqlCommand(spName, _sqlConn) { CommandType = CommandType.StoredProcedure };
            if (sqlParameters != null && sqlParameters.Length > 0)
            {
                foreach (SqlParameter sqlParam in sqlParameters)
                {
                    try
                    {
                        sqlCmd.Parameters.Add(sqlParam);
                    }
                    catch { return null; }
                }
            }
            object obj = new object();
            if (Open())
            {
                try
                {
                    obj = sqlCmd.ExecuteScalar();
                }
                catch
                {
                    Close();
                    return null;
                }
                Close();
                return obj;
            }
            else
                return null;
        }

        //-----------------------------------------
        //Desc: lấy dữ liệu thông qua câu try vấn sql, thất bại trở về null
        //-----------------------------------------
        public DataTable ExecuteQuery(string sql)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, _sqlConn) { CommandType = CommandType.Text };
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            if (Open())
            {
                //đổ dữ liệu vào data table
                try
                {
                    sqlDa.Fill(dt);
                }
                catch
                {
                    Close();
                    return null;
                }
                Close();
            }
            else
                return null;
            return dt;
        }

        //-----------------------------------------
        //Desc: thực thi câu lệnh sql, dùng cho insert, update, delete
        //-----------------------------------------
        public bool ExecuteNonQuery(string sql)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, _sqlConn) { CommandType = CommandType.Text };
            if (Open())
            {
                try
                {
                    sqlCmd.ExecuteNonQuery();
                }
                catch
                {
                    Close();
                    return false;
                }
                Close();
                return true;
            }
            else
                return false;
        }

        //-----------------------------------------
        //Desc: thực thi câu lệnh sql, dùng cho đếm số lượng, ...
        //-----------------------------------------
        public object ExecuteScalar(string sql)
        {
            SqlCommand sqlCmd = new SqlCommand(sql, _sqlConn) { CommandType = CommandType.Text };
            object obj;
            if (Open())
            {
                try
                {
                    obj = sqlCmd.ExecuteScalar();
                }
                catch
                {
                    Close();
                    return null;
                }
                Close();
                return obj;
            }
            else
                return null;
        }
    }
}

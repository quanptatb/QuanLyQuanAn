using DTO_QLQA;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLQA
{
    public class DALMonAn
    {
        public DataTable GetAllMonAn()
        {
            string sql = "SELECT * FROM MonAn";
            return DBUtil.ExecuteQuery(sql);
        }

        public bool InsertMonAn(MonAn monAn)
        {
            string sql = "INSERT INTO MonAn(MaMon, TenMon, ID_LoaiMonAn, GiaBan, ThoiGianNau, HinhAnh) VALUES (@MaMon, @TenMon, @IdLoai, @GiaBan, @ThoiGianNau, @HinhAnh)";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = monAn.MaMon };
            parameters[1] = new SqlParameter("@TenMon", SqlDbType.NVarChar) { Value = monAn.TenMon };
            parameters[2] = new SqlParameter("@IdLoai", SqlDbType.Int) { Value = (object)monAn.IdLoaiMonAn ?? System.DBNull.Value };
            parameters[3] = new SqlParameter("@GiaBan", SqlDbType.Decimal) { Value = monAn.GiaBan };
            parameters[4] = new SqlParameter("@ThoiGianNau", SqlDbType.Int) { Value = monAn.ThoiGianNau };
            parameters[5] = new SqlParameter("@HinhAnh", SqlDbType.NVarChar) { Value = (object)monAn.HinhAnh ?? System.DBNull.Value };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool UpdateMonAn(MonAn monAn)
        {
            string sql = "UPDATE MonAn SET TenMon = @TenMon, ID_LoaiMonAn = @IdLoai, GiaBan = @GiaBan, ThoiGianNau = @ThoiGianNau, HinhAnh = @HinhAnh WHERE MaMon = @MaMon";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@TenMon", SqlDbType.NVarChar) { Value = monAn.TenMon };
            parameters[1] = new SqlParameter("@IdLoai", SqlDbType.Int) { Value = (object)monAn.IdLoaiMonAn ?? System.DBNull.Value };
            parameters[2] = new SqlParameter("@GiaBan", SqlDbType.Decimal) { Value = monAn.GiaBan };
            parameters[3] = new SqlParameter("@ThoiGianNau", SqlDbType.Int) { Value = monAn.ThoiGianNau };
            parameters[4] = new SqlParameter("@HinhAnh", SqlDbType.NVarChar) { Value = (object)monAn.HinhAnh ?? System.DBNull.Value };
            parameters[5] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = monAn.MaMon };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool DeleteMonAn(string maMon)
        {
            string sql = "DELETE FROM MonAn WHERE MaMon = @MaMon";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = maMon };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
    }
}

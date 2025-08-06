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
    public class DALNguyenLieu
    {
        public DataTable GetAllNguyenLieu()
        {
            string sql = "SELECT * FROM NguyenLieu";
            return DBUtil.ExecuteQuery(sql);
        }

        public bool InsertNguyenLieu(NguyenLieu nguyenLieu)
        {
            string sql = "INSERT INTO NguyenLieu(MaNguyenLieu, TenNguyenLieu, DonViTinh, ID_NhaCungCap, SoLuongTon) VALUES (@Ma, @Ten, @DVT, @IdNCC, 0)";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Ma", SqlDbType.NVarChar) { Value = nguyenLieu.MaNguyenLieu };
            parameters[1] = new SqlParameter("@Ten", SqlDbType.NVarChar) { Value = nguyenLieu.TenNguyenLieu };
            parameters[2] = new SqlParameter("@DVT", SqlDbType.NVarChar) { Value = nguyenLieu.DonViTinh };
            parameters[3] = new SqlParameter("@IdNCC", SqlDbType.Int) { Value = (object)nguyenLieu.IdNhaCungCap ?? System.DBNull.Value };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool UpdateNguyenLieu(NguyenLieu nguyenLieu)
        {
            string sql = "UPDATE NguyenLieu SET TenNguyenLieu = @Ten, DonViTinh = @DVT, ID_NhaCungCap = @IdNCC WHERE MaNguyenLieu = @Ma";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@Ten", SqlDbType.NVarChar) { Value = nguyenLieu.TenNguyenLieu };
            parameters[1] = new SqlParameter("@DVT", SqlDbType.NVarChar) { Value = nguyenLieu.DonViTinh };
            parameters[2] = new SqlParameter("@IdNCC", SqlDbType.Int) { Value = (object)nguyenLieu.IdNhaCungCap ?? System.DBNull.Value };
            parameters[3] = new SqlParameter("@Ma", SqlDbType.NVarChar) { Value = nguyenLieu.MaNguyenLieu };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool DeleteNguyenLieu(string maNguyenLieu)
        {
            string sql = "DELETE FROM NguyenLieu WHERE MaNguyenLieu = @Ma";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Ma", SqlDbType.NVarChar) { Value = maNguyenLieu };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
    }
}

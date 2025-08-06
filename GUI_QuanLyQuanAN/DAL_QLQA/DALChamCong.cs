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
    public class DALChamCong
    {
        public DataTable GetAllChamCong()
        {
            string sql = "SELECT * FROM ChamCong";
            return DBUtil.ExecuteQuery(sql);
        }

        public bool InsertChamCong(ChamCong chamCong)
        {
            string sql = "INSERT INTO ChamCong(ID_NhanVien, NgayChamCong, TinhTrang) VALUES (@IdNV, @Ngay, @TinhTrang)";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@IdNV", SqlDbType.NVarChar) { Value = chamCong.IdNhanVien };
            parameters[1] = new SqlParameter("@Ngay", SqlDbType.DateTime) { Value = chamCong.NgayChamCong };
            parameters[2] = new SqlParameter("@TinhTrang", SqlDbType.NVarChar) { Value = chamCong.TinhTrang };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool UpdateChamCong(ChamCong chamCong)
        {
            string sql = "UPDATE ChamCong SET ID_NhanVien = @IdNV, NgayChamCong = @Ngay, TinhTrang = @TinhTrang WHERE ID_ChamCong = @IdCC";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@IdNV", SqlDbType.NVarChar) { Value = chamCong.IdNhanVien };
            parameters[1] = new SqlParameter("@Ngay", SqlDbType.DateTime) { Value = chamCong.NgayChamCong };
            parameters[2] = new SqlParameter("@TinhTrang", SqlDbType.NVarChar) { Value = chamCong.TinhTrang };
            parameters[3] = new SqlParameter("@IdCC", SqlDbType.Int) { Value = chamCong.IdChamCong };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool DeleteChamCong(int idChamCong)
        {
            string sql = "DELETE FROM ChamCong WHERE ID_ChamCong = @IdCC";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdCC", SqlDbType.Int) { Value = idChamCong };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
    }
}

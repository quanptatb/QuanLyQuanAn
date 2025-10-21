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
        /// <summary>
        /// Lấy danh sách chấm công của tất cả nhân viên trong một ngày cụ thể
        /// </summary>
        /// <param name="ngay">Ngày cần lấy dữ liệu</param>
        /// <returns>DataTable chứa thông tin nhân viên và tình trạng chấm công</returns>
        public DataTable GetChamCongByDate(DateTime ngay)
        {
            string sql = @"
        SELECT 
            NV.ID_NhanVien, 
            NV.HoTen, 
            CV.TenChucVu,
            ISNULL(CC.TinhTrang, N'Chưa chấm công') AS TinhTrang,
            ISNULL(CC.ID_ChamCong, -1) AS ID_ChamCong 
        FROM 
            NhanVien NV
        JOIN 
            ChucVu CV ON NV.ID_ChucVu = CV.ID_ChucVu
        LEFT JOIN 
            ChamCong CC ON NV.ID_NhanVien = CC.ID_NhanVien AND CONVERT(date, CC.NgayChamCong) = @Ngay
        WHERE 
            NV.TrangThai = 1"; // Chỉ lấy nhân viên đang làm việc

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date };

            return DBUtil.ExecuteQuery(sql, parameters);
        }
    }
}

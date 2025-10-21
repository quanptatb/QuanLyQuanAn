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
    public class DALChiTietHoaDon
    {
        /// <summary>
        /// Lấy danh sách các món ăn trong một hóa đơn.
        /// </summary>
        /// <param name="idHoaDon">ID của hóa đơn cần xem.</param>
        /// <returns>DataTable chứa danh sách chi tiết.</returns>
        public DataTable GetChiTietByHoaDon(int idHoaDon)
        {
            string sql = @"SELECT MA.TenMon, CT.SoLuong, CT.DonGia, CT.ThanhTien 
                         FROM ChiTietHoaDon CT JOIN MonAn MA ON CT.MaMon = MA.MaMon 
                         WHERE CT.ID_HoaDon = @IdHoaDon";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdHoaDon", SqlDbType.Int) { Value = idHoaDon };

            return DBUtil.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Thêm một món ăn vào hóa đơn. Nếu món đã có thì tăng số lượng.
        /// </summary>
        /// <param name="cthd">Đối tượng ChiTietHoaDon_DTO chứa thông tin món ăn.</param>
        /// <returns>True nếu thành công, false nếu thất bại.</returns>
        public bool InsertChiTiet(ChiTietHoaDon cthd)
        {
            // Kiểm tra nếu món đã tồn tại thì UPDATE số lượng, ngược lại thì INSERT mới.
            string sql = @"
                IF EXISTS (SELECT 1 FROM ChiTietHoaDon WHERE ID_HoaDon = @IdHoaDon AND MaMon = @MaMon)
                    UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong WHERE ID_HoaDon = @IdHoaDon AND MaMon = @MaMon
                ELSE
                    INSERT INTO ChiTietHoaDon(ID_HoaDon, MaMon, SoLuong, DonGia) VALUES (@IdHoaDon, @MaMon, @SoLuong, @DonGia)";

            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@IdHoaDon", SqlDbType.Int) { Value = cthd.IdHoaDon };
            parameters[1] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = cthd.MaMon };
            parameters[2] = new SqlParameter("@SoLuong", SqlDbType.Int) { Value = cthd.SoLuong };
            parameters[3] = new SqlParameter("@DonGia", SqlDbType.Decimal) { Value = cthd.DonGia };

            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
    }
}

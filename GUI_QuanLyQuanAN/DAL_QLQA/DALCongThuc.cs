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
    public class DALCongThuc
    {
        /// <summary>
        /// Lấy chi tiết công thức của một món ăn, bao gồm cả Tên và Đơn vị tính của nguyên liệu
        /// </summary>
        /// <param name="maMonAn">Mã của món ăn cần lấy công thức</param>
        /// <returns>DataTable chứa danh sách nguyên liệu và số lượng</returns>
        public DataTable GetCongThucByMaMonAn(string maMonAn)
        {
            // Sử dụng JOIN để lấy thông tin từ cả 2 bảng
            string sql = @"SELECT CT.MaMon, CT.MaNguyenLieu, NL.TenNguyenLieu, CT.SoLuongTieuHao, NL.DonViTinh 
                         FROM CongThuc CT
                         JOIN NguyenLieu NL ON CT.MaNguyenLieu = NL.MaNguyenLieu
                         WHERE CT.MaMon = @MaMon";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = maMonAn };
            return DBUtil.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Thêm một dòng mới vào công thức (chỉ tác động đến bảng CongThuc)
        /// </summary>
        /// <param name="congThuc">Đối tượng DTO chứa thông tin cần thêm</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool InsertCongThuc(CongThuc congThuc)
        {
            string sql = "INSERT INTO CongThuc(MaMon, MaNguyenLieu, SoLuongTieuHao) VALUES (@MaMon, @MaNL, @SL)";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = congThuc.MaMon };
            parameters[1] = new SqlParameter("@MaNL", SqlDbType.NVarChar) { Value = congThuc.MaNguyenLieu };
            parameters[2] = new SqlParameter("@SL", SqlDbType.Decimal) { Value = congThuc.SoLuongTieuHao }; // Lưu ý kiểu dữ liệu
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// Cập nhật số lượng tiêu hao của một nguyên liệu trong công thức
        /// </summary>
        /// <param name="congThuc">Đối tượng DTO chứa thông tin cần cập nhật</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool UpdateCongThuc(CongThuc congThuc)
        {
            string sql = "UPDATE CongThuc SET SoLuongTieuHao = @SL WHERE MaMon = @MaMon AND MaNguyenLieu = @MaNL";
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@SL", SqlDbType.Decimal) { Value = congThuc.SoLuongTieuHao };
            parameters[1] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = congThuc.MaMon };
            parameters[2] = new SqlParameter("@MaNL", SqlDbType.NVarChar) { Value = congThuc.MaNguyenLieu };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// Xóa một nguyên liệu khỏi công thức của món ăn
        /// </summary>
        /// <param name="maMonAn">Mã món ăn</param>
        /// <param name="maNguyenLieu">Mã nguyên liệu cần xóa</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool DeleteCongThuc(string maMonAn, string maNguyenLieu)
        {
            string sql = "DELETE FROM CongThuc WHERE MaMon = @MaMon AND MaNguyenLieu = @MaNL";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = maMonAn };
            parameters[1] = new SqlParameter("@MaNL", SqlDbType.NVarChar) { Value = maNguyenLieu };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
    }
}

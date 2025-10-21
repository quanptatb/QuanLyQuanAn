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
    public class DALHoaDon
    {
        /// <summary>
        /// Lấy ID hóa đơn chưa thanh toán của một bàn cụ thể.
        /// </summary>
        /// <param name="idBanAn">ID của bàn ăn cần kiểm tra.</param>
        /// <returns>Trả về ID hóa đơn nếu có, ngược lại trả về -1.</returns>
        public int GetUnpaidHoaDonByBanAn(int idBanAn)
        {
            string sql = "SELECT ID_HoaDon FROM HoaDon WHERE ID_BanAn = @IdBanAn AND TrangThai = N'Chưa thanh toán'";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdBanAn", SqlDbType.Int) { Value = idBanAn };

            DataTable dt = DBUtil.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["ID_HoaDon"]);
            }
            return -1; // -1 nghĩa là không có hóa đơn nào chưa thanh toán cho bàn này
        }

        /// <summary>
        /// Thêm một hóa đơn mới vào CSDL.
        /// </summary>
        /// <param name="hoaDon">Đối tượng HoaDon_DTO chứa thông tin cần thêm.</param>
        /// <returns>Trả về ID của hóa đơn vừa được tạo nếu thành công, ngược lại trả về -1.</returns>
        public int InsertHoaDon(HoaDon hoaDon)
        {
            // Sử dụng SCOPE_IDENTITY() để lấy ID tự tăng vừa được tạo
            string sql = "INSERT INTO HoaDon(ID_BanAn, ID_NhanVien, TrangThai) VALUES (@IdBanAn, @IdNhanVien, N'Chưa thanh toán'); SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@IdBanAn", SqlDbType.Int) { Value = hoaDon.IdBanAn };
            parameters[1] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = hoaDon.IdNhanVien };

            object result = DBUtil.ExecuteScalar(sql, parameters);
            return (result != null) ? Convert.ToInt32(result) : -1;
        }

        /// <summary>
        /// Cập nhật trạng thái của hóa đơn thành 'Đã thanh toán'.
        /// </summary>
        /// <param name="idHoaDon">ID của hóa đơn cần cập nhật.</param>
        /// <returns>True nếu cập nhật thành công, false nếu thất bại.</returns>
        public bool UpdateThanhToan(int idHoaDon)
        {
            string sql = "UPDATE HoaDon SET TrangThai = N'Đã thanh toán', ThoiGianRa = GETDATE() WHERE ID_HoaDon = @IdHoaDon";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdHoaDon", SqlDbType.Int) { Value = idHoaDon };

            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// Lấy danh sách tất cả hóa đơn 'Chưa thanh toán' cùng với Tên Bàn
        /// </summary>
        /// <returns>DataTable chứa ID_HoaDon, TenBan, ThoiGianVao</returns>
        public DataTable GetAllUnpaidHoaDonWithTable()
        {
            string sql = @"SELECT HD.ID_HoaDon, BA.TenBan, HD.ThoiGianVao 
                 FROM HoaDon HD JOIN BanAn BA ON HD.ID_BanAn = BA.ID_BanAn 
                 WHERE HD.TrangThai = N'Chưa thanh toán'
                 ORDER BY HD.ThoiGianVao ASC";
            return DBUtil.ExecuteQuery(sql);
        }
        /// <summary>
        /// Lấy danh sách các hóa đơn đã thanh toán trong một ngày cụ thể
        /// </summary>
        public DataTable GetPaidHoaDonByDate(DateTime ngay)
        {
            string sql = @"
        SELECT 
            HD.ID_HoaDon, 
            BA.TenBan, 
            HD.TongTien, 
            HD.ThoiGianRa 
        FROM 
            HoaDon HD 
        JOIN 
            BanAn BA ON HD.ID_BanAn = BA.ID_BanAn 
        WHERE 
            HD.TrangThai = N'Đã thanh toán' AND CONVERT(date, HD.ThoiGianRa) = @Ngay";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date };
            return DBUtil.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Lấy thông tin chi tiết của một hóa đơn bằng ID
        /// </summary>
        public DataTable GetHoaDonById(int idHoaDon)
        {
            string sql = "SELECT * FROM HoaDon WHERE ID_HoaDon = @IdHoaDon";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdHoaDon", SqlDbType.Int) { Value = idHoaDon };
            return DBUtil.ExecuteQuery(sql, parameters);
        }

    }
}

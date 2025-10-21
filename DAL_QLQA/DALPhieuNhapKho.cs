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
    public class DALPhieuNhapKho
    {
        public DataTable GetPhieuNhapByDate(DateTime ngay)
        {
            string sql = @"
                SELECT 
                    PN.ID_PhieuNhap, 
                    NCC.TenNhaCungCap, 
                    NV.HoTen, 
                    PN.NgayNhap, 
                    PN.TongTienNhap 
                FROM 
                    PhieuNhapKho PN 
                LEFT JOIN 
                    NhaCungCap NCC ON PN.ID_NhaCungCap = NCC.ID_NhaCungCap
                JOIN
                    NhanVien NV ON PN.ID_NhanVien = NV.ID_NhanVien
                WHERE 
                    CONVERT(date, PN.NgayNhap) = @Ngay";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date };
            return DBUtil.ExecuteQuery(sql, parameters);
        }
        //select all
        public DataTable GetAllPhieuNhap()
        {
            string sql = @"select * from PhieuNhapKho";
            return DBUtil.ExecuteQuery(sql);
        }
        // Trong DALPhieuNhapKho.cs

        // Thêm phiếu nhập kho - PHIÊN BẢN ĐÃ SỬA LỖI
        public void AddPhieuNhapKho(PhieuNhapKho phieuNhap)
        {
            // ✅ FIX: Loại bỏ cột ID_PhieuNhap khỏi câu lệnh INSERT
            // Cơ sở dữ liệu sẽ tự động tạo giá trị cho cột này
            string sql = @"
        INSERT INTO PhieuNhapKho (ID_NhaCungCap, ID_NhanVien, NgayNhap, TongTienNhap)
        VALUES (@ID_NhaCungCap, @ID_NhanVien, @NgayNhap, @TongTienNhap)";

            // ✅ FIX: Loại bỏ tham số @ID_PhieuNhap khỏi mảng
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = phieuNhap.ID_NhaCungCap },
        new SqlParameter("@ID_NhanVien", SqlDbType.NVarChar) { Value = phieuNhap.ID_NhanVien },
        new SqlParameter("@NgayNhap", SqlDbType.DateTime) { Value = phieuNhap.NgayNhap },
        new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Value = phieuNhap.TongTienNhap }
            };

            DBUtil.ExecuteNonQuery(sql, parameters);
        }

        // Cập nhật phiếu nhập kho - SỬA LẠI CHO NHẤT QUÁN
        public void UpdatePhieuNhapKho(PhieuNhapKho phieuNhap)
        {
            string sql = @"
        UPDATE PhieuNhapKho
        SET
            ID_NhaCungCap = @ID_NhaCungCap,
            ID_NhanVien = @ID_NhanVien,
            NgayNhap = @NgayNhap,
            TongTienNhap = @TongTienNhap
        WHERE
            ID_PhieuNhap = @ID_PhieuNhap";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@ID_NhaCungCap", SqlDbType.Int) { Value = phieuNhap.ID_NhaCungCap },
        new SqlParameter("@ID_NhanVien", SqlDbType.NVarChar) { Value = phieuNhap.ID_NhanVien },
        new SqlParameter("@NgayNhap", SqlDbType.DateTime) { Value = phieuNhap.NgayNhap },
        new SqlParameter("@TongTienNhap", SqlDbType.Decimal) { Value = phieuNhap.TongTienNhap },
        new SqlParameter("@ID_PhieuNhap", SqlDbType.Int) { Value = phieuNhap.ID_PhieuNhap } // Tham số WHERE đặt cuối
            };

            DBUtil.ExecuteNonQuery(sql, parameters);
        }
        // Xóa phiếu nhập kho
        public void DeletePhieuNhapKho(int idPhieuNhap)
        {
            string sql = "DELETE FROM PhieuNhapKho WHERE ID_PhieuNhap = @0";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@0", SqlDbType.Int) { Value = idPhieuNhap };
            DBUtil.ExecuteNonQuery(sql, parameters);
        }
        // Tìm kiếm theo tất cả dữ liệu
        public void SearchPhieuNhapKho(string keyword)
        {
            string sql = @"
                SELECT 
                    PN.ID_PhieuNhap, 
                    NCC.TenNhaCungCap, 
                    NV.HoTen, 
                    PN.NgayNhap, 
                    PN.TongTienNhap 
                FROM 
                    PhieuNhapKho PN 
                LEFT JOIN 
                    NhaCungCap NCC ON PN.ID_NhaCungCap = NCC.ID_NhaCungCap
                JOIN
                    NhanVien NV ON PN.ID_NhanVien = NV.ID_NhanVien
                WHERE 
                    (NCC.TenNhaCungCap LIKE @Keyword OR NV.HoTen LIKE @Keyword)";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Keyword", SqlDbType.NVarChar) { Value = "%" + keyword + "%" };
            DBUtil.ExecuteQuery(sql, parameters);
        }
        //tự động tăng ID_PhieuNhap
        public int GetNextID()
        {
            string sql = "SELECT ISNULL(MAX(ID_PhieuNhap), 0) + 1 FROM PhieuNhapKho";
            object result = DBUtil.ExecuteScalar(sql);
            return result != null ? Convert.ToInt32(result) : 1;
        }
    }
}

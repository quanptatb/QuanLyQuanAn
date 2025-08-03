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
    public class DALNhanVien
    {
        // Phương thức kiểm tra đăng nhập
        public DataTable CheckLogin(NhanVien nhanVien)
        {
            string sql = "SELECT * FROM NhanVien WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar);
            parameters[0].Value = nhanVien.TaiKhoan;

            parameters[1] = new SqlParameter("@MatKhau", SqlDbType.VarChar);
            parameters[1].Value = nhanVien.MatKhau; // Mật khẩu đã được mã hóa ở tầng BUS

            return DBUtil.ExecuteQuery(sql, parameters);
        }

        // Lấy danh sách tất cả nhân viên
        public DataTable GetAllNhanVien()
        {
            string sql = "SELECT * FROM NhanVien";
            return DBUtil.ExecuteQuery(sql);
        }

        // Thêm nhân viên mới (phiên bản đầy đủ)
        public bool InsertNhanVien(NhanVien nhanVien)
        {
            string sql = @"INSERT INTO NhanVien(IdNhanVien, HoTen, IdChucVu, CaLam, DiaChi, SDT, NgaySinh, NgayVaoLam, TaiKhoan, MatKhau, TrangThai) 
                         VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8, @9, @10)";

            // 1. Khởi tạo mảng SqlParameter
            SqlParameter[] parameters = new SqlParameter[11];

            // 2. Gán giá trị cho từng parameter
            parameters[0] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = nhanVien.IdNhanVien };
            parameters[1] = new SqlParameter("@HoTen", SqlDbType.NVarChar) { Value = nhanVien.HoTen };
            parameters[2] = new SqlParameter("@IdChucVu", SqlDbType.Int) { Value = nhanVien.IdChucVu };
            parameters[3] = new SqlParameter("@CaLam", SqlDbType.NVarChar) { Value = nhanVien.CaLam };
            parameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar) { Value = nhanVien.DiaChi };
            parameters[5] = new SqlParameter("@SDT", SqlDbType.VarChar) { Value = nhanVien.Sdt };
            parameters[6] = new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = nhanVien.NgaySinh };
            parameters[7] = new SqlParameter("@NgayVaoLam", SqlDbType.Date) { Value = nhanVien.NgayVaoLam };
            parameters[8] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = nhanVien.TaiKhoan };
            parameters[9] = new SqlParameter("@MatKhau", SqlDbType.VarChar) { Value = nhanVien.MatKhau };
            parameters[10] = new SqlParameter("@TrangThai", SqlDbType.Bit) { Value = nhanVien.TrangThai };

            // 3. Gọi hàm ExecuteNonQuery với câu lệnh sql và mảng parameters
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        // Tương tự, bạn sẽ tạo các hàm UpdateNhanVien và DeleteNhanVien theo mẫu này.
        // Cập nhật thông tin nhân viên
        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            string sql = @"UPDATE NhanVien 
                           SET HoTen = @1, IdChucVu = @2, CaLam = @3, DiaChi = @4, 
                               SDT = @5, NgaySinh = @6, NgayVaoLam = @7, 
                               TaiKhoan = @8, MatKhau = @9, TrangThai = @10 
                           WHERE IdNhanVien = @0";
            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = nhanVien.IdNhanVien };
            parameters[1] = new SqlParameter("@HoTen", SqlDbType.NVarChar) { Value = nhanVien.HoTen };
            parameters[2] = new SqlParameter("@IdChucVu", SqlDbType.Int) { Value = nhanVien.IdChucVu };
            parameters[3] = new SqlParameter("@CaLam", SqlDbType.NVarChar) { Value = nhanVien.CaLam };
            parameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar) { Value = nhanVien.DiaChi };
            parameters[5] = new SqlParameter("@SDT", SqlDbType.VarChar) { Value = nhanVien.Sdt };
            parameters[6] = new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = nhanVien.NgaySinh };
            parameters[7] = new SqlParameter("@NgayVaoLam", SqlDbType.Date) { Value = nhanVien.NgayVaoLam };
            parameters[8] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = nhanVien.TaiKhoan };
            parameters[9] = new SqlParameter("@MatKhau", SqlDbType.VarChar) { Value = nhanVien.MatKhau };
            parameters[10] = new SqlParameter("@TrangThai", SqlDbType.Bit) { Value = nhanVien.TrangThai };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
        // Xóa nhân viên
        public bool DeleteNhanVien(string idNhanVien)
        {
            string sql = "DELETE FROM NhanVien WHERE IdNhanVien = @0";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = idNhanVien };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
    }
}
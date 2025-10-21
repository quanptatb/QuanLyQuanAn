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
        public DataTable CheckLogin(NhanVien nhanVien)
        {
            string sql = "SELECT * FROM NhanVien WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau AND TrangThai = 1";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = nhanVien.TaiKhoan };
            parameters[1] = new SqlParameter("@MatKhau", SqlDbType.VarChar) { Value = nhanVien.MatKhau };
            return DBUtil.ExecuteQuery(sql, parameters);
        }

        public DataTable GetAllNhanVien()
        {
            return DBUtil.ExecuteQuery("SELECT * FROM NhanVien");
        }

        public bool InsertNhanVien(NhanVien nhanVien)
        {
            string sql = @"INSERT INTO NhanVien(Id_NhanVien, HoTen, Id_ChucVu, CaLam, DiaChi, SDT, NgaySinh, NgayVaoLam, TaiKhoan, MatKhau, TrangThai) 
                         VALUES (@IdNhanVien, @HoTen, @IdChucVu, @CaLam, @DiaChi, @SDT, @NgaySinh, @NgayVaoLam, @TaiKhoan, @MatKhau, 1)";
            SqlParameter[] parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = GetNextNhanVienId() };
            parameters[1] = new SqlParameter("@HoTen", SqlDbType.NVarChar) { Value = nhanVien.HoTen };
            parameters[2] = new SqlParameter("@IdChucVu", SqlDbType.Int) { Value = nhanVien.IdChucVu };
            parameters[3] = new SqlParameter("@CaLam", SqlDbType.NVarChar) { Value = nhanVien.CaLam };
            parameters[4] = new SqlParameter("@DiaChi", SqlDbType.NVarChar) { Value = nhanVien.DiaChi };
            parameters[5] = new SqlParameter("@SDT", SqlDbType.VarChar) { Value = nhanVien.Sdt };
            parameters[6] = new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = nhanVien.NgaySinh };
            parameters[7] = new SqlParameter("@NgayVaoLam", SqlDbType.Date) { Value = nhanVien.NgayVaoLam };
            parameters[8] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = nhanVien.TaiKhoan };
            parameters[9] = new SqlParameter("@MatKhau", SqlDbType.VarChar) { Value = nhanVien.MatKhau };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            string sql = @"UPDATE NhanVien SET 
                            HoTen = @HoTen, Id_ChucVu = @IdChucVu, CaLam = @CaLam, DiaChi = @DiaChi, 
                            SDT = @SDT, NgaySinh = @NgaySinh, NgayVaoLam = @NgayVaoLam, 
                            TaiKhoan = @TaiKhoan, MatKhau = @MatKhau, TrangThai = @TrangThai 
                         WHERE Id_NhanVien = @IdNhanVien";
            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@HoTen", SqlDbType.NVarChar) { Value = nhanVien.HoTen };
            parameters[1] = new SqlParameter("@IdChucVu", SqlDbType.Int) { Value = nhanVien.IdChucVu };
            parameters[2] = new SqlParameter("@CaLam", SqlDbType.NVarChar) { Value = nhanVien.CaLam };
            parameters[3] = new SqlParameter("@DiaChi", SqlDbType.NVarChar) { Value = nhanVien.DiaChi };
            parameters[4] = new SqlParameter("@SDT", SqlDbType.VarChar) { Value = nhanVien.Sdt };
            parameters[5] = new SqlParameter("@NgaySinh", SqlDbType.Date) { Value = nhanVien.NgaySinh };
            parameters[6] = new SqlParameter("@NgayVaoLam", SqlDbType.Date) { Value = nhanVien.NgayVaoLam };
            parameters[7] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = nhanVien.TaiKhoan };
            parameters[8] = new SqlParameter("@MatKhau", SqlDbType.VarChar) { Value = nhanVien.MatKhau };
            parameters[9] = new SqlParameter("@TrangThai", SqlDbType.Bit) { Value = nhanVien.TrangThai };
            parameters[10] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = nhanVien.ID_NhanVien };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool DeleteNhanVien(string idNhanVien)
        {
            string sql = "UPDATE NhanVien SET TrangThai = 0 WHERE Id_NhanVien = @IdNhanVien";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = idNhanVien };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
        /// <summary>
        /// Lấy thông tin nhân viên bằng tài khoản (email)
        /// </summary>
        public DataTable GetNhanVienByEmail(string email)
        {
            string sql = "SELECT * FROM NhanVien WHERE TaiKhoan = @TaiKhoan";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = email };
            return DBUtil.ExecuteQuery(sql, parameters);
        }

        /// <summary>
        /// Cập nhật mật khẩu mới cho nhân viên dựa trên tài khoản (email)
        /// </summary>
        public bool UpdatePasswordByEmail(string email, string newPassword)
        {
            string sql = "UPDATE NhanVien SET MatKhau = @MatKhau WHERE TaiKhoan = @TaiKhoan";
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@MatKhau", SqlDbType.VarChar) { Value = newPassword };
            parameters[1] = new SqlParameter("@TaiKhoan", SqlDbType.VarChar) { Value = email };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
        //getnhanvienbyid
        public NhanVien GetNhanVienById(string idNhanVien)
        {
            string sql = "SELECT * FROM NhanVien WHERE Id_NhanVien = @IdNhanVien";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdNhanVien", SqlDbType.NVarChar) { Value = idNhanVien };
            DataTable dt = DBUtil.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new NhanVien
                {
                    ID_NhanVien = row["Id_NhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    IdChucVu = Convert.ToInt32(row["Id_ChucVu"]),
                    CaLam = row["CaLam"].ToString(),
                    DiaChi = row["DiaChi"].ToString(),
                    Sdt = row["SDT"].ToString(),
                    NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                    NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]),
                    TaiKhoan = row["TaiKhoan"].ToString(),
                    MatKhau = row["MatKhau"].ToString(),
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
            }
            return null;
        }
        //mã nv tự tăng
        public string GetNextNhanVienId()
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(Id_NhanVien, 3, LEN(Id_NhanVien) - 2) AS INT)), 0) + 1 FROM NhanVien";
            object result = DBUtil.ExecuteScalar(sql);
            return "NV" + result.ToString().PadLeft(4, '0'); // NV0001, NV0002, ...
        }
    }
}
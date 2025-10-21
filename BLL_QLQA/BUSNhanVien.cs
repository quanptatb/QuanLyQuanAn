using DAL_QLQA;
using DTO_QLQA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTIL_QLQA;

namespace BLL_QLQA
{
    public class BUSNhanVien
    {
        private DALNhanVien dalNhanVien = new DALNhanVien();
        private HelperUtil helper = new HelperUtil();

        /// <summary>
        /// Xử lý logic kiểm tra đăng nhập
        /// </summary>
        /// <param name="nhanVien">Đối tượng NhanVien chứa tài khoản và mật khẩu (chưa mã hóa)</param>
        /// <returns>DataTable chứa thông tin nhân viên nếu đăng nhập thành công, ngược lại trả về null</returns>
        public DataTable CheckLogin(NhanVien nhanVien)
        {
            // 1. Kiểm tra đầu vào (validation)
            if (string.IsNullOrWhiteSpace(nhanVien.TaiKhoan) || string.IsNullOrWhiteSpace(nhanVien.MatKhau))
            {
                return null;
            }

            //// 2. Mã hóa mật khẩu trước khi gửi xuống DAL
            //string hashedPassword = helper.encryption(nhanVien.MatKhau);
            //nhanVien.MatKhau = hashedPassword;

            // 3. Gọi DAL để kiểm tra
            DataTable dt = dalNhanVien.CheckLogin(nhanVien);

            // 4. Trả về kết quả
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        /// <returns>DataTable chứa danh sách nhân viên</returns>
        public DataTable GetAllNhanVien()
        {
            return dalNhanVien.GetAllNhanVien();
        }

        // Các hàm Insert, Update, Delete sẽ theo mẫu dưới đây
        public bool InsertNhanVien(NhanVien nhanVien)
        {
            // Validation logic (ví dụ: kiểm tra SĐT, Email có hợp lệ không,...)
            // if (nhanVien.Sdt.Length != 10) return false;

            //// Mã hóa mật khẩu trước khi lưu
            //nhanVien.MatKhau = helper.encryption(nhanVien.MatKhau);

            // Gọi DAL
            return dalNhanVien.InsertNhanVien(nhanVien);
        }
        public bool UpdateNhanVien(NhanVien nhanVien)
        {
            // Validation logic (ví dụ: kiểm tra SĐT, Email có hợp lệ không,...)
            // if (nhanVien.Sdt.Length != 10) return false;
            // Mã hóa mật khẩu nếu có thay đổi
            if (!string.IsNullOrWhiteSpace(nhanVien.MatKhau))
            {
                //nhanVien.MatKhau = helper.encryption(nhanVien.MatKhau);
            }
            // Gọi DAL
            return dalNhanVien.UpdateNhanVien(nhanVien);
        }
        public bool DeleteNhanVien(string idNhanVien)
        {
            // Validation logic (ví dụ: kiểm tra ID có tồn tại không,...)
            if (string.IsNullOrWhiteSpace(idNhanVien)) return false;
            // Gọi DAL
            return dalNhanVien.DeleteNhanVien(idNhanVien);
        }
        public bool GetNhanVienByEmail(string email)
        {
            DataTable dt = dalNhanVien.GetNhanVienByEmail(email);
            return dt.Rows.Count > 0;
        }

        public bool UpdatePasswordByEmail(string email, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(newPassword))
            {
                return false;
            }
            // Mã hóa mật khẩu mới trước khi cập nhật
            //string hashedPassword = helper.encryption(newPassword);
            return dalNhanVien.UpdatePasswordByEmail(email, newPassword);
        }
        //get nhân viên by id
        public NhanVien GetNhanVienById(string idNhanVien)
        {
            if (string.IsNullOrWhiteSpace(idNhanVien)) return null;
            return dalNhanVien.GetNhanVienById(idNhanVien);
        }
    }
}

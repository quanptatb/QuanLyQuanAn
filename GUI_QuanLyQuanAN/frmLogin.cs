using BLL_QLQA;
using DTO_QLQA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL_QLQA;

namespace GUI_QuanLyQuanAN
{
    public partial class frmLogin : Form
    {
        // Khai báo đối tượng BUS
        private BUSNhanVien busNhanVien = new BUSNhanVien();
        public frmLogin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Xử lý sự kiện khi nhấn nút Đăng nhập
        /// </summary>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ form
            string taiKhoan = txtTaiKhoan.Content;
            string matKhau = txtMatKhau.Content;

            // 2. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(taiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            // 3. Tạo đối tượng DTO và gọi BLL
            NhanVien nv = new NhanVien { TaiKhoan = taiKhoan, MatKhau = matKhau };
            DataTable dtNhanVien = busNhanVien.CheckLogin(nv);

            // 4. Xử lý kết quả
            if (dtNhanVien != null && dtNhanVien.Rows.Count > 0)
            {
                // Đăng nhập thành công, lưu thông tin người dùng
                DataRow row = dtNhanVien.Rows[0];
                AuthUtil.user = new NhanVien
                {
                    ID_NhanVien = row["ID_NhanVien"].ToString(),
                    HoTen = row["HoTen"].ToString(),
                    IdChucVu = Convert.ToInt32(row["ID_ChucVu"]),
                    TaiKhoan = row["TaiKhoan"].ToString()
                    // Thêm các thuộc tính khác nếu cần
                };

                // Mở form chính
                frmMain f = new frmMain();
                this.Hide();
                f.ShowDialog();
                // Hiển thị lại form đăng nhập sau khi form chính đóng
                this.Show();
                txtMatKhau.Content = ""; // Xóa mật khẩu đã nhập
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn vào "Quên mật khẩu"
        /// </summary>
        private void lblQuenMatKhau_Click(object sender, EventArgs e)
        {
            frmResetPW f = new frmResetPW();
            f.ShowDialog();
        }

        /// <summary>
        /// Xử lý sự kiện khi form đóng (nhấn nút X)
        /// </summary>
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

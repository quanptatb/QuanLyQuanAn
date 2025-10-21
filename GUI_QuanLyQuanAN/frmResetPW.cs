using BLL_QLQA;
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
    public partial class frmResetPW : Form
    {
        // Khai báo các đối tượng
        private BUSNhanVien busNhanVien = new BUSNhanVien();
        private HelperUtil helperUtil = new HelperUtil();

        // Biến lưu mã xác nhận được tạo ngẫu nhiên
        private string maXacNhan;

        public frmResetPW()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện khi nhấn nút "Nhận mã"
        /// </summary>
        private void btnnhanma_Click(object sender, EventArgs e)
        {
            string email = cuiTextBox1.Content.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email (tài khoản) của bạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem email có tồn tại trong hệ thống không
            if (busNhanVien.GetNhanVienByEmail(email))
            {
                // Tạo mã xác nhận ngẫu nhiên
                maXacNhan = helperUtil.RandomString(6, false).ToUpper();

                // Giả lập việc gửi email bằng cách hiển thị mã qua MessageBox
                MessageBox.Show($"Mã xác nhận của bạn là: {maXacNhan}\nVui lòng nhập mã này để đổi mật khẩu.", "Mã xác nhận", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Email (tài khoản) không tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sự kiện khi nhấn nút "Đổi mật khẩu"
        /// </summary>
        private void cuiButton1_Click(object sender, EventArgs e) // btnDoiMatKhau
        {
            string email = cuiTextBox1.Content.Trim();
            string code = cuiTextBox2.Content.Trim().ToUpper();
            string newPass = cuiTextBox3.Content;
            string confirmPass = cuiTextBox4.Content;

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(maXacNhan))
            {
                MessageBox.Show("Bạn chưa nhận mã xác nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(code) || code != maXacNhan)
            {
                MessageBox.Show("Mã xác nhận không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPass != confirmPass)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Gọi BLL để cập nhật mật khẩu
            if (busNhanVien.UpdatePasswordByEmail(email, newPass))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Không thể đổi mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using DTO_QLQA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLQA
{
    public partial class frmInputQuantity : Form
    {
        // Các thuộc tính này dùng để trả kết quả về cho form chính
        public int SoLuong { get; private set; }
        public decimal DonGia { get; private set; }

        public frmInputQuantity(string tenNguyenLieu, decimal donGiaGanNhat)
        {
            InitializeComponent();
            // 1. Dùng biến 'tenNguyenLieu' để đặt tiêu đề cho form
            this.Text = $"Số lượng cho: {tenNguyenLieu}";

            // 2. Dùng biến 'donGiaGanNhat' để thiết lập giá trị ban đầu
            txtDonGia.ReadOnly = false;
            txtDonGia.Text = donGiaGanNhat.ToString("N0");

            // --- Cấu hình các control khác ---
            txtThanhTien.ReadOnly = true;
            numSoLuong.Minimum = 1;
            numSoLuong.Maximum = 1000;
            numSoLuong.Value = 1;

            // Tính toán thành tiền ngay khi form mở
            UpdateThanhTien();

            // Gán sự kiện cho các control để tính toán tự động
            numSoLuong.ValueChanged += TinhToan_KhiGiaTriThayDoi;
            txtDonGia.TextChanged += TinhToan_KhiGiaTriThayDoi;
        }
        // Phương thức này được gọi mỗi khi số lượng hoặc đơn giá thay đổi
        private void TinhToan_KhiGiaTriThayDoi(object sender, EventArgs e)
        {
            UpdateThanhTien();
        }

        // Phương thức thực hiện tính toán và cập nhật giao diện
        private void UpdateThanhTien()
        {
            decimal soLuong = numSoLuong.Value;
            // Chuyển đổi chuỗi tiền tệ (có dấu phẩy) thành số một cách an toàn
            decimal.TryParse(txtDonGia.Text.Replace(",", ""), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal donGia);

            decimal thanhTien = soLuong * donGia;
            txtThanhTien.Text = thanhTien.ToString("N0");
        }

        // Sự kiện khi nhấn nút Đồng ý
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Lấy giá trị cuối cùng từ các control để trả về
            this.SoLuong = (int)numSoLuong.Value;
            decimal.TryParse(txtDonGia.Text.Replace(",", ""), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal donGiaCuoi);
            this.DonGia = donGiaCuoi;

            if (this.DonGia <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Sự kiện khi nhấn nút Hủy
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

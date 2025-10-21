using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QLQA;
using DTO_QLQA;
using GUI_QuanLyQuanAN;
using UTIL_QLQA;

namespace GUI_QuanLyQuanAN
{
    public partial class frmnhanvin : Form
    {
        // Khai báo các đối tượng BUS và tiện ích
        private BUSNhanVien busNhanVien = new BUSNhanVien();
        private BUSChucVu busChucVu = new BUSChucVu();
        private HelperUtil helperUtil = new HelperUtil();

        // DataTable để lưu trữ và tra cứu thông tin Chức vụ
        private DataTable dtChucVu;

        public frmnhanvin()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmnhanvin_Load(object sender, EventArgs e)
        {
            LoadGridViewNhanVien();
            LoadComboBoxes();
            ResetFieldsAndButtons();
        }

        #region CÁC HÀM HỖ TRỢ

        /// <summary>
        /// Tải dữ liệu nhân viên lên DataGridView
        /// </summary>
        private void LoadGridViewNhanVien()
        {
            dvgnhanvien.DataSource = busNhanVien.GetAllNhanVien();
            // Tùy chỉnh hiển thị cột
            dvgnhanvien.Columns["ID_NhanVien"].HeaderText = "Mã NV";
            dvgnhanvien.Columns["HoTen"].HeaderText = "Họ Tên";
            dvgnhanvien.Columns["ID_ChucVu"].HeaderText = "Mã CV";
            dvgnhanvien.Columns["CaLam"].HeaderText = "Ca Làm";
            dvgnhanvien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dvgnhanvien.Columns["SDT"].HeaderText = "SĐT";
            dvgnhanvien.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dvgnhanvien.Columns["NgayVaoLam"].HeaderText = "Ngày Vào Làm";
            dvgnhanvien.Columns["TaiKhoan"].HeaderText = "Tài Khoản";
            dvgnhanvien.Columns["MatKhau"].Visible = false; // Ẩn mật khẩu
            dvgnhanvien.Columns["TrangThai"].HeaderText = "Trạng Thái";
        }

        /// <summary>
        /// Tải dữ liệu cho tất cả ComboBox trên form
        /// </summary>
        private void LoadComboBoxes()
        {
            // Tải Chức vụ
            dtChucVu = busChucVu.GetAllChucVu();
            cbochucvu.Items = dtChucVu.AsEnumerable().Select(r => r.Field<string>("TenChucVu")).ToArray();

            // Tải Ca làm
            cbocalam.Items = new string[] { "Hành chính", "Ca sáng", "Ca tối" };

            // Tải Trạng thái (Giả sử cbotrangthai là cbotrangthai)
            cbotrangthai.Items = new string[] { "Đang làm việc", "Đã nghỉ việc" };
        }


        /// <summary>
        /// Xóa trắng các trường nhập liệu và thiết lập lại trạng thái các nút
        /// </summary>
        private void ResetFieldsAndButtons()
        {
            // Xóa trắng các trường nhập liệu
            txtmxnhanvien.Content = "";
            txthoten.Content = "";
            txtdiachi.Content = "";
            txtsdt.Content = "";
            txttaikhoannhanvien.Content = "";
            txtmknhanvien.Content = "";
            ngaysinh.Value = DateTime.Now;
            ngaylam.Value = DateTime.Now;
            // Thiết lập lại trạng thái các nút
            txthoten.Enabled = false;
            txtdiachi.Enabled = false;
            txtsdt.Enabled = false;
            txttaikhoannhanvien.Enabled = false;
            txtmknhanvien.Enabled = false;
            cbochucvu.Enabled = false;
            cbocalam.Enabled = false;
            cbotrangthai.Enabled = false;
            ngaysinh.Enabled = false;
            ngaylam.Enabled = false;
            btnluuthaydoinv.Enabled = false;
            btnxoanhanvien.Enabled = false;
            btnlammoi.Enabled = true;
            btnthemnv.Enabled = true;
            // Làm mới DataGridView
            LoadGridViewNhanVien();

        }

        #endregion

        #region SỰ KIỆN GIAO DIỆN

        /// <summary>
        /// Sự kiện khi click vào một dòng trên DataGridView
        /// </summary>
        private void dvgnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgnhanvien.Rows.Count > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgnhanvien.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các control
                txtmxnhanvien.Content = row.Cells["ID_NhanVien"].Value.ToString();
                txthoten.Content = row.Cells["HoTen"].Value.ToString();
                txtdiachi.Content = row.Cells["DiaChi"].Value.ToString();
                txtsdt.Content = row.Cells["SDT"].Value.ToString();
                txttaikhoannhanvien.Content = row.Cells["TaiKhoan"].Value.ToString();
                txtmknhanvien.Content = ""; // Không hiển thị mật khẩu

                // Tìm và chọn item tương ứng trong cbochucvu
                int idChucVu = Convert.ToInt32(row.Cells["ID_ChucVu"].Value);
                string tenChucVu = dtChucVu.AsEnumerable()
                                    .FirstOrDefault(r => r.Field<int>("ID_ChucVu") == idChucVu)?
                                    .Field<string>("TenChucVu");
                cbochucvu.SelectedItem = tenChucVu;


                cbocalam.SelectedItem = row.Cells["CaLam"].Value.ToString();
                cbotrangthai.SelectedItem = Convert.ToBoolean(row.Cells["TrangThai"].Value) ? "Đang làm việc" : "Đã nghỉ việc";
                ngaysinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                ngaylam.Value = Convert.ToDateTime(row.Cells["NgayVaoLam"].Value);

                // Kích hoạt các nút Sửa, Xóa và các trường nhập liệu
                txthoten.Enabled = true;
                txtdiachi.Enabled = true;
                txtsdt.Enabled = true;
                txttaikhoannhanvien.Enabled = true;
                txtmknhanvien.Enabled = true;
                cbochucvu.Enabled = true;
                cbocalam.Enabled = true;
                cbotrangthai.Enabled = true;
                ngaysinh.Enabled = true;
                ngaylam.Enabled = true;

                btnluuthaydoinv.Enabled = true;
                btnxoanhanvien.Enabled = true;
                btnlammoi.Enabled = true;
                txtmxnhanvien.Enabled = false; // Không cho sửa Mã NV (khóa chính)
                btnthemnv.Enabled = false; // Vô hiệu hóa nút Thêm
            }
        }

        #endregion

        #region SỰ KIỆN NÚT BẤM

        /// <summary>
        /// Kích hoạt chế độ Thêm mới
        /// </summary>
        private void btnthemnv_Click(object sender, EventArgs e)
        {
            ResetFieldsAndButtons();
            txtmxnhanvien.Enabled = true;
            txthoten.Enabled = true;
            txtdiachi.Enabled = true;
            txtsdt.Enabled = true;
            txttaikhoannhanvien.Enabled = true;
            txtmknhanvien.Enabled = true;
            cbochucvu.Enabled = true;
            cbocalam.Enabled = true;
            cbotrangthai.Enabled = true;
            ngaysinh.Enabled = true;
            ngaylam.Enabled = true;

            btnluuthaydoinv.Enabled = true;
            btnlammoi.Enabled = true;
            btnxoanhanvien.Enabled = false;
            btnthemnv.Enabled = false;
            txtmxnhanvien.Focus();
        }

        /// <summary>
        /// Xóa (cập nhật trạng thái nghỉ việc)
        /// </summary>
        private void btnxoanhanvien_Click(object sender, EventArgs e)
        {
            string maNV = txtmxnhanvien.Content;
            if (MessageBox.Show($"Bạn có chắc chắn muốn cho nhân viên '{maNV}' nghỉ việc?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busNhanVien.DeleteNhanVien(maNV))
                {
                    MessageBox.Show("Cập nhật trạng thái thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFieldsAndButtons();
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Hủy thao tác và làm mới form
        /// </summary>
        private void btnlammoi_Click(object sender, EventArgs e)
        {
            ResetFieldsAndButtons();
        }

        /// <summary>
        /// Lưu thông tin (Thêm mới hoặc Cập nhật)
        /// </summary>
        private void btnluuthaydoinv_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtmxnhanvien.Content) ||
                string.IsNullOrWhiteSpace(txthoten.Content) ||
                string.IsNullOrWhiteSpace(txttaikhoannhanvien.Content) ||
                cbochucvu.SelectedItem == null ||
                cbocalam.SelectedItem == null ||
                cbotrangthai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Nếu là thêm mới, mật khẩu là bắt buộc
            if (txtmxnhanvien.Enabled && string.IsNullOrWhiteSpace(txtmknhanvien.Content))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu cho nhân viên mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtmknhanvien.Focus();
                return;
            }

            // Lấy ID chức vụ từ tên chức vụ được chọn
            string selectedChucVu = cbochucvu.SelectedItem.ToString();
            int idChucVu = (int)dtChucVu.AsEnumerable()
                            .FirstOrDefault(r => r.Field<string>("TenChucVu") == selectedChucVu)?
                            .Field<int>("ID_ChucVu");

            // Tạo đối tượng DTO
            NhanVien nv = new NhanVien
            {
                ID_NhanVien = txtmxnhanvien.Content   .Trim(),
                HoTen = txthoten.Content.Trim(),
                DiaChi = txtdiachi.Content.Trim(),
                Sdt = txtsdt.Content.Trim(),
                TaiKhoan = txttaikhoannhanvien.Content.Trim(),
                MatKhau = txtmknhanvien.Content, // Sẽ được mã hóa trong BLL
                IdChucVu = idChucVu,
                CaLam = cbocalam.SelectedItem.ToString(),
                TrangThai = (cbotrangthai.SelectedItem.ToString() == "Đang làm việc"),
                NgaySinh = ngaysinh.Value,
                NgayVaoLam = ngaylam.Value
            };

            // Nếu txtmxnhanvien được kích hoạt, có nghĩa là đang ở chế độ Thêm mới
            if (txtmxnhanvien.Enabled)
            {
                if (busNhanVien.InsertNhanVien(nv))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFieldsAndButtons();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại! Mã nhân viên hoặc tài khoản có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Ngược lại là chế độ Cập nhật
            {
                if (busNhanVien.UpdateNhanVien(nv))
                {
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFieldsAndButtons();
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Mở form chấm công
        /// </summary>
        private void btnchamcong_Click(object sender, EventArgs e)
        {
            frmchamcong f = new frmchamcong();
            f.ShowDialog();
        }

        #endregion
    }
}

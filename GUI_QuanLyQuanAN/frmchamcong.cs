using BLL_QLQA;
using DAL_QLQA;
using DTO_QLQA;
using System;
using System.Data;
using System.Windows.Forms;

namespace GUI_QuanLyQuanAN
{
    public partial class frmchamcong : Form
    {
        // Khai báo đối tượng BUS
        private BUSChamCong busChamCong = new BUSChamCong();
        public frmchamcong()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmchamcong_Load(object sender, EventArgs e)
        {
            // Cấu hình mặc định khi form load
            thang.Format = DateTimePickerFormat.Custom;
            thang.CustomFormat = "MM/yyyy";
            thang.ShowUpDown = true;

            ngay.Format = DateTimePickerFormat.Short;

            CapNhatNgayTheoThang();
            LoadGridViewChamCong(); // Tải dữ liệu cho ngày hiện tại
        }

        #region CÁC HÀM HỖ TRỢ

        /// <summary>
        /// Tải dữ liệu chấm công lên DataGridView
        /// </summary>
        private void LoadGridViewChamCong()
        {
            DateTime selectedDate = ngay.Value;
            dvgchamcong.DataSource = busChamCong.GetChamCongByDate(selectedDate);
            // Tùy chỉnh cột
            dvgchamcong.Columns["ID_NhanVien"].HeaderText = "Mã NV";
            dvgchamcong.Columns["HoTen"].HeaderText = "Họ Tên";
            dvgchamcong.Columns["TenChucVu"].HeaderText = "Chức Vụ";
            dvgchamcong.Columns["TinhTrang"].HeaderText = "Tình Trạng";
            dvgchamcong.Columns["ID_ChamCong"].Visible = false; // Ẩn cột ID
        }

        /// <summary>
        /// Giới hạn ngày trong DateTimePicker "ngay" theo tháng được chọn
        /// </summary>
        private void CapNhatNgayTheoThang()
        {
            int month = thang.Value.Month;
            int year = thang.Value.Year;

            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

            ngay.MinDate = firstDay;
            ngay.MaxDate = lastDay;

            // Nếu ngày hiện tại không nằm trong tháng đó, đặt lại
            if (ngay.Value < firstDay || ngay.Value > lastDay)
            {
                ngay.Value = firstDay;
            }
        }

        #endregion

        #region SỰ KIỆN

        /// <summary>
        /// Sự kiện khi thay đổi tháng, giới hạn lại ngày và tải lại dữ liệu
        /// </summary>
        private void thang_ValueChanged(object sender, EventArgs e)
        {
            DateTime thangDuocChon = thang.Value;
            DateTime thangHienTai = DateTime.Now;

            if (thangDuocChon.Year > thangHienTai.Year ||
               (thangDuocChon.Year == thangHienTai.Year && thangDuocChon.Month > thangHienTai.Month))
            {
                MessageBox.Show("Tháng chưa bắt đầu, vui lòng chọn lại tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                thang.Value = new DateTime(thangHienTai.Year, thangHienTai.Month, 1);
            }
            else
            {
                CapNhatNgayTheoThang();
                LoadGridViewChamCong();
            }
        }

        /// <summary>
        /// Sự kiện khi thay đổi ngày, tải lại dữ liệu
        /// </summary>
        private void ngay_ValueChanged(object sender, EventArgs e)
        {
            LoadGridViewChamCong();
        }

        /// <summary>
        /// Sự kiện khi click vào một dòng trên DataGridView, cập nhật các control bên phải
        /// </summary>
        private void dvgchamcong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dvgchamcong.Rows[e.RowIndex];
                txtmxnhanvien.Content = row.Cells["ID_NhanVien"].Value.ToString();
                txthoten.Content = row.Cells["HoTen"].Value.ToString();
                cbochucvu.Text = row.Cells["TenChucVu"].Value.ToString(); // Giả sử đây là TextBox
                cbotinhtrang.SelectedItem = row.Cells["TinhTrang"].Value.ToString();
            }
        }

        /// <summary>
        /// Sự kiện khi nhấn nút Lưu
        /// </summary>
        private void btnluu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtmxnhanvien.Content) || cbotinhtrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên và tình trạng chấm công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy ID_ChamCong từ DataGridView để biết là INSERT hay UPDATE
            int idChamCong = -1;
            foreach (DataGridViewRow row in dvgchamcong.Rows)
            {
                if (row.Cells["ID_NhanVien"].Value.ToString() == txtmxnhanvien.Content)
                {
                    idChamCong = Convert.ToInt32(row.Cells["ID_ChamCong"].Value);
                    break;
                }
            }

            ChamCong cc = new ChamCong
            {
                IdChamCong = idChamCong,
                IdNhanVien = txtmxnhanvien.Content,
                NgayChamCong = ngay.Value,
                TinhTrang = cbotinhtrang.SelectedItem.ToString()
            };

            if (busChamCong.SaveChamCong(cc))
            {
                MessageBox.Show("Lưu chấm công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGridViewChamCong(); // Tải lại để cập nhật
            }
            else
            {
                MessageBox.Show("Lưu chấm công thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}

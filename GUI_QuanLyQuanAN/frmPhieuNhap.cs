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

namespace GUI_QLQA
{
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        BUSPhieuNhapKho busPhieuNhap = new BUSPhieuNhapKho();

        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            // Tải tất cả dữ liệu cần thiết khi form được mở
            LoadDanhSachPhieuNhap();
            LoadComboNhanVien();
            LoadComboNhaCungCap();
            // Chuẩn bị form cho việc thêm mới
            ClearFormForNew();
        }

        #region === CÁC PHƯƠNG THỨC TẢI DỮ LIỆU ===

        private void LoadDanhSachPhieuNhap()
        {
            dgvPhieuNhap.DataSource = busPhieuNhap.GetAllPhieuNhap();
            // Tùy chỉnh hiển thị cho lưới
            if (dgvPhieuNhap.Columns["ID_NhanVien"] != null) dgvPhieuNhap.Columns["ID_NhanVien"].Visible = false;
            if (dgvPhieuNhap.Columns["ID_NhaCungCap"] != null) dgvPhieuNhap.Columns["ID_NhaCungCap"].Visible = false;
        }

        private void LoadComboNhanVien()
        {
            BUSNhanVien busnhan = new BUSNhanVien();
            cboNhanVien.DataSource = busnhan.GetAllNhanVien();
            cboNhanVien.DisplayMember = "HoTen";
            cboNhanVien.ValueMember = "ID_NhanVien";
        }

        private void LoadComboNhaCungCap()
        {
            BUSNhaCungCap busncc = new BUSNhaCungCap();
            cboNhaCungCap.DataSource = busncc.GetAllNhaCungCap();
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.ValueMember = "ID_NhaCungCap";
        }

        #endregion

        #region === CÁC PHƯƠNG THỨC XỬ LÝ FORM ===

        // Chuẩn bị form cho việc thêm một phiếu nhập MỚI
        private void ClearFormForNew()
        {
            try
            {
                int nextId = busPhieuNhap.GetNextID();
                txtMaPhieuNhap.Text = nextId.ToString();

                // === BƯỚC GỠ RỐI 1 ===
                // Một hộp thoại sẽ hiện ra để xác nhận ID vừa lấy được.
                MessageBox.Show($"ID tiếp theo được lấy là: {nextId}", "Debug - ClearForm");

                txtMaPhieuNhap.ReadOnly = true; // Không cho sửa mã tự động
                txtTongTienNhap.Text = "0";
                txtTongTienNhap.ReadOnly = true;

                cboNhanVien.SelectedIndex = -1;
                cboNhaCungCap.SelectedIndex = -1;
                dtPNgayNhap.Value = DateTime.Now;

                btnThem.Enabled = true; // Bật nút Thêm
                btnSua.Enabled = false;  // Tắt nút Sửa
                btnXoa.Enabled = false;   // Tắt nút Xóa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã phiếu nhập mới: " + ex.Message, "Lỗi nghiêm trọng");
            }
        }

        // Hiển thị thông tin của một phiếu nhập ĐÃ CÓ lên form
        private void LoadDataToForm(DataGridViewRow row)
        {
            DataRowView rowView = row.DataBoundItem as DataRowView;
            if (rowView != null)
            {
                txtMaPhieuNhap.Text = rowView["ID_PhieuNhap"].ToString();
                cboNhanVien.SelectedValue = rowView["ID_NhanVien"];
                cboNhaCungCap.SelectedValue = rowView["ID_NhaCungCap"];
                dtPNgayNhap.Value = Convert.ToDateTime(rowView["NgayNhap"]);
                txtTongTienNhap.Text = rowView["TongTienNhap"].ToString();

                txtMaPhieuNhap.ReadOnly = true;
                btnThem.Enabled = false; // Tắt nút Thêm khi đang xem/sửa
                btnSua.Enabled = true;   // Bật nút Sửa
                btnXoa.Enabled = true;    // Bật nút Xóa
            }
        }

        #endregion

        #region === CÁC SỰ KIỆN CỦA BUTTON ===

        private void btnThem_Click(object sender, EventArgs e)
        {
            // === BƯỚC GỠ RỐI 2 ===
            // Hộp thoại này cho bạn biết giá trị của mã phiếu nhập ngay trước khi thêm.
            MessageBox.Show($"Giá trị Mã Phiếu Nhập trước khi thêm là: '{txtMaPhieuNhap.Text}'", "Debug - btnThem_Click");

            if (cboNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaPhieuNhap.Text, out int idPhieuNhap))
            {
                MessageBox.Show("Mã phiếu nhập không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại nếu không hợp lệ
            }

            try
            {
                PhieuNhapKho phieuNhap = new PhieuNhapKho
                {
                    ID_PhieuNhap = idPhieuNhap,
                    ID_NhaCungCap = Convert.ToInt32(cboNhaCungCap.SelectedValue),
                    ID_NhanVien = cboNhanVien.SelectedValue.ToString(),
                    NgayNhap = dtPNgayNhap.Value,
                    TongTienNhap = 0
                };

                busPhieuNhap.AddPhieuNhapKho(phieuNhap);
                MessageBox.Show("Thêm phiếu nhập thành công! Hãy nhấn đúp vào phiếu để thêm chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadDanhSachPhieuNhap();
                ClearFormForNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn phiếu nhập nào chưa và nút Sửa có đang được bật không
            if (string.IsNullOrEmpty(txtMaPhieuNhap.Text) || !btnSua.Enabled)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập từ lưới để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra các lựa chọn ComboBox
            if (cboNhanVien.SelectedValue == null || cboNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Nhà cung cấp và Nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Tạo đối tượng PhieuNhapKho từ dữ liệu trên form
                PhieuNhapKho phieuNhap = new PhieuNhapKho
                {
                    ID_PhieuNhap = Convert.ToInt32(txtMaPhieuNhap.Text),
                    ID_NhaCungCap = Convert.ToInt32(cboNhaCungCap.SelectedValue),
                    ID_NhanVien = cboNhanVien.SelectedValue.ToString(),
                    NgayNhap = dtPNgayNhap.Value,
                    TongTienNhap = Convert.ToDecimal(txtTongTienNhap.Text) // Lấy tổng tiền đã có
                };

                // Gọi lớp BUS để cập nhật
                busPhieuNhap.UpdatePhieuNhapKho(phieuNhap);
                MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại dữ liệu và chuẩn bị cho thao tác mới
                LoadDanhSachPhieuNhap();
                ClearFormForNew();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // (Code cho nút Xóa ở đây)
            // Kiểm tra xem người dùng đã chọn phiếu nhập nào chưa và nút Xóa có đang được bật không
            if (string.IsNullOrEmpty(txtMaPhieuNhap.Text) || !btnXoa.Enabled)
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập từ lưới để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi xóa
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này? Tất cả chi tiết liên quan cũng sẽ bị xóa.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    int idPhieuNhap = Convert.ToInt32(txtMaPhieuNhap.Text);

                    // Gọi lớp BUS để thực hiện xóa
                    busPhieuNhap.DeletePhieuNhapKho(idPhieuNhap);
                    MessageBox.Show("Xóa phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại dữ liệu và chuẩn bị cho thao tác mới
                    LoadDanhSachPhieuNhap();
                    ClearFormForNew();
                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu có khóa ngoại ràng buộc
                    MessageBox.Show("Lỗi khi xóa phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFormForNew();
        }

        #endregion

        #region === CÁC SỰ KIỆN CỦA DATAGRIDVIEW ===

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadDataToForm(dgvPhieuNhap.Rows[e.RowIndex]);
            }
        }

        private void dgvPhieuNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng không nhấn đúp vào tiêu đề của lưới
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataRowView rowView = dgvPhieuNhap.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (rowView != null)
                {
                    // Tạo đối tượng PhieuNhapKho từ dữ liệu của dòng được chọn
                    PhieuNhapKho selectedPhieuNhap = new PhieuNhapKho
                    {
                        ID_PhieuNhap = Convert.ToInt32(rowView["ID_PhieuNhap"]),
                        ID_NhanVien = rowView["ID_NhanVien"].ToString(),
                        ID_NhaCungCap = Convert.ToInt32(rowView["ID_NhaCungCap"]),
                        NgayNhap = Convert.ToDateTime(rowView["NgayNhap"]),
                        TongTienNhap = Convert.ToDecimal(rowView["TongTienNhap"])
                    };

                    // Mở form chi tiết, truyền đối tượng phiếu nhập vào
                    // Sử dụng "using" để đảm bảo form được giải phóng bộ nhớ đúng cách sau khi đóng
                    using (frmChiTietPhieuNhap frmChiTiet = new frmChiTietPhieuNhap(selectedPhieuNhap))
                    {
                        // Dùng ShowDialog() để form chính phải chờ form chi tiết đóng lại
                        frmChiTiet.ShowDialog();
                    }

                    // Sau khi form chi tiết đóng, tải lại danh sách để cập nhật tổng tiền (nếu có thay đổi)
                    LoadDanhSachPhieuNhap();
                    ClearFormForNew();
                }
            }
        }

        #endregion
    }
}

using BLL_QLQA;
using DTO_QLQA;
using UTIL_QLQA; // Cần thêm để lấy thông tin nhân viên đăng nhập
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_QLQA;

namespace GUI_QLQA
{
    public partial class frmChiTietPhieuNhap : Form
    {
        private PhieuNhapKho PhieuNhapKho;
        private List<ChiTietPhieuNhap> chiTietPhieuNhaps;
        public frmChiTietPhieuNhap(PhieuNhapKho pn)
        {
            InitializeComponent();
            PhieuNhapKho = pn;
            txtDonGia.Visible = false;
            guna2HtmlLabel2.Visible = false;
        }
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            loadInformation();
            loadnguyenlieu();
            loadChiTiet();
        }
        private void loadInformation()
        {
            BUSNhanVien NhanVienBLL = new BUSNhanVien();
            BUSNhaCungCap NccBLL = new BUSNhaCungCap();

            // Lấy tên nhân viên và nhà cung cấp để hiển thị
            lblNhanVien.Text = "NV: " + NhanVienBLL.GetNhanVienById(PhieuNhapKho.ID_NhanVien)?.HoTen ?? "Không rõ";
            lblPhieuNhap.Text = "Phiếu: " + PhieuNhapKho.ID_PhieuNhap.ToString();
            lblNgayLapPhieu.Text = PhieuNhapKho.NgayNhap.ToString("dd/MM/yyyy");
        }
        private void loadnguyenlieu()
        {
            BUSNguyenLieu busNguyenLieu = new BUSNguyenLieu();
            // Lấy danh sách nguyên liệu từ DB và gán cho DataGridView
            dgvNguyenLieu.DataSource = busNguyenLieu.GetAllNguyenLieu();
            // Thiết lập các cột hiển thị
            dgvNguyenLieu.Columns["MaNguyenLieu"].HeaderText = "Mã Nguyên Liệu";
            dgvNguyenLieu.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dgvNguyenLieu.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
        }
        private void loadChiTiet()
        {
            BUSChiTietPhieuNhap chiTietBLL = new BUSChiTietPhieuNhap();
            // Lấy danh sách chi tiết từ DB và gán cho list local
            chiTietPhieuNhaps = chiTietBLL.SelectByMaPhieuNhap(PhieuNhapKho.ID_PhieuNhap.ToString());
            dgvChiTiet.DataSource = chiTietBLL.GetChiTietByPhieuNhap(PhieuNhapKho.ID_PhieuNhap);

            // ✅ BƯỚC 1: CẤU HÌNH CHO PHÉP CHỈNH SỬA
            dgvChiTiet.ReadOnly = false; // Cho phép chỉnh sửa trên toàn bộ lưới
            foreach (DataGridViewColumn column in dgvChiTiet.Columns)
            {
                // Chỉ cho phép sửa cột "SoLuongNhap" và "GiaNhap"
                if (column.Name == "SoLuongNhap" || column.Name == "GiaNhap")
                {
                    column.ReadOnly = false;
                }
                else
                {
                    column.ReadOnly = true; // Khóa các cột còn lại
                }
            }

            if (dgvChiTiet.Columns["MaNguyenLieu"] != null)
            {
                dgvChiTiet.Columns["MaNguyenLieu"].Visible = false;
            }

            UpdateThanhToanUI();
        }
        private void UpdateThanhToanUI()
        {
            decimal tongTien = chiTietPhieuNhaps.Sum(ct => ct.SoLuongNhap * ct.GiaNhap);
            decimal tongSoLuong = chiTietPhieuNhaps.Sum(ct => ct.SoLuongNhap);

            txtSoLuongNhap.Text = tongSoLuong.ToString("N0");
            txtDonGia.Text = PhieuNhapKho.TongTienNhap.ToString("N0"); // Hiển thị tổng tiền đã lưu
            txtThanhTien.Text = tongTien.ToString("N0");
        }
        private void deleteChiTiet()
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvChiTiet.CurrentRow.Cells["ID_PhieuNhap"].Value);
                string nl = dgvChiTiet.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa {nl}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BUSChiTietPhieuNhap bus = new BUSChiTietPhieuNhap();
                    bus.DeleteChiTietPhieuNhap(id, nl);
                    MessageBox.Show("Xóa chi tiết phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadChiTiet();
                }
            }
        }
        private void transfer(string maNguyenLieu, int soLuong, decimal donGia)
        {
            BUSChiTietPhieuNhap bus = new BUSChiTietPhieuNhap();
            // Tìm xem nguyên liệu này đã có trong danh sách chi tiết hiện tại chưa
            ChiTietPhieuNhap existingItem = chiTietPhieuNhaps.FirstOrDefault(item => item.MaNguyenLieu == maNguyenLieu);

            if (existingItem != null)
            {
                // Nếu đã có, chỉ cộng thêm số lượng
                existingItem.SoLuongNhap += soLuong;
                // Cập nhật lại số lượng mới vào database
                bus.UpdateSoLuong(existingItem);
            }
            else
            {
                // Nếu chưa có, tạo một đối tượng ChiTietPhieuNhap mới
                ChiTietPhieuNhap ct = new ChiTietPhieuNhap()
                {
                    Id_PhieuNhap = PhieuNhapKho.ID_PhieuNhap,
                    MaNguyenLieu = maNguyenLieu,
                    SoLuongNhap = soLuong,
                    GiaNhap = donGia // Sử dụng đơn giá từ form input
                };
                // Thêm chi tiết mới này vào database
                bus.InsertChiTietPhieuNhap(ct);
            }

            // Tải lại toàn bộ lưới chi tiết để cập nhật giao diện
            loadChiTiet();
        }
        private void loadThanhToan()
        {
            txtDonGia.Text = "0";
            txtSoLuongNhap.Text = "0";
            txtThanhTien.Text = "0";
        }



        private void dgvNguyenLieu_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo sự kiện xảy ra trên một dòng hợp lệ
            if (e.RowIndex < 0) return;

            try
            {
                // Lấy dòng vừa được chỉnh sửa
                DataGridViewRow row = dgvChiTiet.Rows[e.RowIndex];

                // Lấy các giá trị từ các ô trong dòng đó
                string maNL = row.Cells["MaNguyenLieu"].Value.ToString();
                decimal soLuongMoi = Convert.ToDecimal(row.Cells["SoLuongNhap"].Value);
                decimal giaNhapMoi = Convert.ToDecimal(row.Cells["GiaNhap"].Value);

                // Tìm đối tượng ChiTietPhieuNhap tương ứng trong danh sách local
                ChiTietPhieuNhap chiTietToUpdate = chiTietPhieuNhaps.FirstOrDefault(ct => ct.MaNguyenLieu == maNL);

                if (chiTietToUpdate != null)
                {
                    // Cập nhật giá trị mới vào đối tượng
                    chiTietToUpdate.SoLuongNhap = soLuongMoi;
                    chiTietToUpdate.GiaNhap = giaNhapMoi;

                    // Gọi lớp Business để thực hiện cập nhật xuống Database
                    BUSChiTietPhieuNhap bus = new BUSChiTietPhieuNhap();
                    bus.UpdateSoLuong(chiTietToUpdate); // ***Lưu ý quan trọng ở dưới

                    // Tải lại lưới và cập nhật lại giao diện tổng tiền
                    // Dùng BeginInvoke để tránh lỗi xung đột khi đang ở trong sự kiện của grid
                    this.BeginInvoke((Action)(() =>
                    {
                        loadChiTiet();
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Có thể tải lại để khôi phục giá trị cũ
                loadChiTiet();
            }
        }

        private void dgvNguyenLieu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowInputQuantityAndTransfer();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ShowInputQuantityAndTransfer();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTiet.CurrentRow != null)
            {
                string maNL = dgvChiTiet.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nguyên liệu này khỏi phiếu nhập?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    BUSChiTietPhieuNhap bus = new BUSChiTietPhieuNhap();
                    bus.DeleteChiTietPhieuNhap(PhieuNhapKho.ID_PhieuNhap, maNL);
                    loadChiTiet(); // Tải lại danh sách và cập nhật UI
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đóng mà không lưu các thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Chỉ cần đóng form
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xác nhận và lưu phiếu nhập kho này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Cập nhật tổng tiền cuối cùng vào đối tượng PhieuNhapKho
                    PhieuNhapKho.TongTienNhap = chiTietPhieuNhaps.Sum(ct => ct.SoLuongNhap * ct.GiaNhap);

                    // Gọi BLL để cập nhật phiếu nhập (lưu phiếu + chi tiết đã có)
                    BUSPhieuNhapKho busPN = new BUSPhieuNhapKho();
                    busPN.UpdatePhieuNhapKho(PhieuNhapKho);

                    // --- MỚI: áp dụng số lượng nhập vào tồn kho ---
                    BUSChiTietPhieuNhap busCTPN = new BUSChiTietPhieuNhap();
                    bool stockUpdated = busCTPN.ApplyImportToStock(PhieuNhapKho.ID_PhieuNhap);

                    if (!stockUpdated)
                    {
                        MessageBox.Show("Phiếu nhập đã được lưu nhưng cập nhật tồn kho thất bại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Lưu phiếu nhập kho thành công và đã cập nhật tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.Close(); // Đóng form sau khi xử lý xong
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // Hàm helper để mở form nhập số lượng và xử lý kết quả
        private void ShowInputQuantityAndTransfer()
        {
            // 1. Kiểm tra xem người dùng đã chọn nguyên liệu nào chưa
            if (dgvNguyenLieu.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu từ danh sách bên trái.", "Chưa chọn nguyên liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Lấy thông tin cơ bản của nguyên liệu được chọn
            string maNL = dgvNguyenLieu.CurrentRow.Cells["MaNguyenLieu"].Value.ToString();
            string tenNL = dgvNguyenLieu.CurrentRow.Cells["TenNguyenLieu"].Value.ToString();

            // 3. Lấy giá nhập gần nhất của nguyên liệu này từ database
            BUSChiTietPhieuNhap bus = new BUSChiTietPhieuNhap();
            decimal lastPrice = bus.GetLastImportPrice(maNL);

            // 4. Mở form nhập số lượng (frmInputQuantity) và truyền thông tin vào
            //    Sử dụng 'using' để đảm bảo form được giải phóng bộ nhớ đúng cách
            using (frmInputQuantity inputForm = new frmInputQuantity(tenNL, lastPrice))
            {
                // 5. Nếu người dùng nhấn "Đồng ý" trên form đó
                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    // Lấy kết quả (số lượng và đơn giá) mà người dùng đã nhập/chỉnh sửa
                    int soLuong = inputForm.SoLuong;
                    decimal donGia = inputForm.DonGia;

                    // 6. Gọi phương thức 'transfer' để thêm hoặc cập nhật chi tiết phiếu nhập
                    transfer(maNL, soLuong, donGia);
                }
            }
        }

        private void dgvNguyenLieu_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo sự kiện không xảy ra trên tiêu đề cột/dòng
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // Lấy tên của cột vừa được thay đổi
            string columnName = dgvChiTiet.Columns[e.ColumnIndex].Name;

            // Chỉ thực hiện tính toán khi cột thay đổi là "SoLuongNhap" hoặc "GiaNhap"
            if (columnName == "SoLuongNhap" || columnName == "GiaNhap")
            {
                // Lấy dòng hiện tại
                DataGridViewRow currentRow = dgvChiTiet.Rows[e.RowIndex];

                // Lấy giá trị từ các ô một cách an toàn
                decimal soLuong = 0;
                decimal donGia = 0;

                if (currentRow.Cells["SoLuongNhap"].Value != null)
                {
                    decimal.TryParse(currentRow.Cells["SoLuongNhap"].Value.ToString(), out soLuong);
                }

                if (currentRow.Cells["GiaNhap"].Value != null)
                {
                    decimal.TryParse(currentRow.Cells["GiaNhap"].Value.ToString(), out donGia);
                }

                // Tính toán thành tiền
                decimal thanhTien = soLuong * donGia;

                // ✅ Cập nhật giá trị cho ô "ThanhTien" ngay lập tức trên lưới
                currentRow.Cells["ThanhTien"].Value = thanhTien;
            }
        }
    }
}

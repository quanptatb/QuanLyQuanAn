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

namespace GUI_QuanLyQuanAN
{
    public partial class frmmenu : Form
    {
        // Khai báo các đối tượng BUS
        private BUSMonAn busMonAn = new BUSMonAn();
        private BUSLoaiMonAn busLoaiMonAn = new BUSLoaiMonAn();

        // Biến lưu tên file ảnh khi được chọn
        private string strTenHinhAnh;

        // Biến lưu đường dẫn tới thư mục Images của ứng dụng
        private string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        public frmmenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmmenu_Load(object sender, EventArgs e)
        {
            // Tạo thư mục Images nếu chưa có
            string imageDirectory = Path.Combine(appDirectory, "Images");
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }

            LoadGridViewMonAn();
            LoadComboBoxLoaiMon();
            ResetFieldsAndButtons();
        }

        #region CÁC HÀM HỖ TRỢ

        /// <summary>
        /// Tải dữ liệu món ăn lên DataGridView
        /// </summary>
        private void LoadGridViewMonAn()
        {
            dgvMonAn.DataSource = busMonAn.GetAllMonAn();
            // Tùy chỉnh hiển thị cột
            dgvMonAn.Columns["MaMon"].HeaderText = "Mã Món";
            dgvMonAn.Columns["TenMon"].HeaderText = "Tên Món";
            dgvMonAn.Columns["GiaBan"].HeaderText = "Giá Bán";
            dgvMonAn.Columns["ID_LoaiMonAn"].HeaderText = "Mã Loại";
            dgvMonAn.Columns["ThoiGianNau"].HeaderText = "T.Gian Nấu (phút)";
            dgvMonAn.Columns["HinhAnh"].HeaderText = "Hình Ảnh";
            dgvMonAn.Columns["TrangThai"].Visible = false; // Ẩn cột trạng thái
        }

        /// <summary>
        /// Tải danh sách loại món vào ComboBox
        /// </summary>
        private void LoadComboBoxLoaiMon()
        {
            cboLoaiMon.DataSource = busLoaiMonAn.GetAllLoaiMonAn();
            cboLoaiMon.DisplayMember = "TenLoaiMonAn";
            cboLoaiMon.ValueMember = "ID_LoaiMonAn";
        }

        /// <summary>
        /// Xóa trắng các trường nhập liệu và thiết lập lại trạng thái các nút
        /// </summary>
        private void ResetFieldsAndButtons()
        {
            txttimkiem.Content = "";
            txtmamon.Content = "";
            txttenmon.Content = "";
            txtgiamon.Content = "";
            txtthoigiannau.Content = "";
            cboLoaiMon.SelectedIndex = -1;
            anhmonan.Image = null;
            strTenHinhAnh = "";

            // Vô hiệu hóa các trường nhập và các nút chức năng
            txtmamon.Enabled = false;
            txttenmon.Enabled = false;
            txtgiamon.Enabled = false;
            txtthoigiannau.Enabled = false;
            cboLoaiMon.Enabled = false;
            btnthemanh.Enabled = false;
            btnLuu.Enabled = false;
            btnXoaMon.Enabled = false;
            btnBoQua.Enabled = false;

            // Kích hoạt lại nút Thêm
            btnThemMon.Enabled = true;

            LoadGridViewMonAn(); // Tải lại dữ liệu gốc
        }

        #endregion

        #region SỰ KIỆN GIAO DIỆN

        /// <summary>
        /// Sự kiện khi click vào một dòng trên DataGridView
        /// </summary>
        private void dgvMonAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMonAn.Rows.Count > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMonAn.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các control
                txtmamon.Content = row.Cells["MaMon"].Value.ToString();
                txttenmon.Content = row.Cells["TenMon"].Value.ToString();
                txtgiamon.Content = row.Cells["GiaBan"].Value.ToString();
                txtthoigiannau.Content = row.Cells["ThoiGianNau"].Value.ToString();
                cboLoaiMon.SelectedValue = row.Cells["ID_LoaiMonAn"].Value;

                // Lưu lại tên ảnh
                strTenHinhAnh = row.Cells["HinhAnh"].Value?.ToString();

                // Hiển thị ảnh
                if (!string.IsNullOrEmpty(strTenHinhAnh))
                {
                    string imagePath = Path.Combine(appDirectory, "Images", strTenHinhAnh);
                    if (File.Exists(imagePath))
                    {
                        anhmonan.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        anhmonan.Image = null; // Hoặc một ảnh mặc định
                    }
                }
                else
                {
                    anhmonan.Image = null;
                }

                // Kích hoạt các nút Sửa, Xóa và các trường nhập liệu
                txttenmon.Enabled = true;
                txtgiamon.Enabled = true;
                txtthoigiannau.Enabled = true;
                cboLoaiMon.Enabled = true;
                btnthemanh.Enabled = true;
                btnLuu.Enabled = true;
                btnXoaMon.Enabled = true;
                btnBoQua.Enabled = true;
                txtmamon.Enabled = false; // Không cho sửa Mã Món (khóa chính)
                btnThemMon.Enabled = false; // Vô hiệu hóa nút Thêm
            }
        }

        /// <summary>
        /// Sự kiện khi nhấn nút "Thêm ảnh"
        /// </summary>
        private void btnthemanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên file
                string fileName = Path.GetFileName(openFileDialog.FileName);
                // Tạo đường dẫn đích
                string destPath = Path.Combine(appDirectory, "Images", fileName);

                try
                {
                    // Sao chép file vào thư mục Images (ghi đè nếu đã tồn tại)
                    File.Copy(openFileDialog.FileName, destPath, true);

                    // Hiển thị ảnh lên PictureBox
                    anhmonan.Image = Image.FromFile(destPath);
                    // Lưu lại tên file để chuẩn bị lưu vào CSDL
                    strTenHinhAnh = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region SỰ KIỆN NÚT BẤM

        /// <summary>
        /// Kích hoạt chế độ Thêm mới
        /// </summary>
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            ResetFieldsAndButtons();
            txtmamon.Enabled = true;
            txttenmon.Enabled = true;
            txtgiamon.Enabled = true;
            txtthoigiannau.Enabled = true;
            cboLoaiMon.Enabled = true;
            btnthemanh.Enabled = true;
            btnLuu.Enabled = true;
            btnBoQua.Enabled = true;
            btnXoaMon.Enabled = false;
            btnThemMon.Enabled = false;
            txtmamon.Focus();
        }

        /// <summary>
        /// Xóa món ăn (xóa mềm)
        /// </summary>
        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            string maMon = txtmamon.Content;
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa món '{maMon}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (busMonAn.DeleteMonAn(maMon))
                {
                    MessageBox.Show("Xóa món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFieldsAndButtons();
                }
                else
                {
                    MessageBox.Show("Xóa món ăn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Hủy thao tác và làm mới form
        /// </summary>
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetFieldsAndButtons();
        }

        /// <summary>
        /// Lưu món ăn (Thêm mới hoặc Cập nhật)
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (
                string.IsNullOrWhiteSpace(txttenmon.Content) ||
                string.IsNullOrWhiteSpace(txtgiamon.Content) ||
                string.IsNullOrWhiteSpace(txtthoigiannau.Content) ||
                cboLoaiMon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtgiamon.Content, out decimal giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtgiamon.Focus();
                return;
            }

            if (!int.TryParse(txtthoigiannau.Content, out int thoiGianNau) || thoiGianNau < 0)
            {
                MessageBox.Show("Thời gian nấu không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtthoigiannau.Focus();
                return;
            }

            // Tạo đối tượng DTO
            MonAn monAn = new MonAn()
            {
                MaMon = txtmamon.Content.Trim(),
                TenMon = txttenmon.Content.Trim(),
                GiaBan = giaBan,
                ThoiGianNau = thoiGianNau,
                IdLoaiMonAn = Convert.ToInt32(cboLoaiMon.SelectedValue),
                HinhAnh = strTenHinhAnh
            };

            // Nếu txtmamon được kích hoạt, có nghĩa là đang ở chế độ Thêm mới
            if (txtmamon.Enabled)
            {
                if (busMonAn.InsertMonAn(monAn))
                {
                    MessageBox.Show("Thêm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFieldsAndButtons();
                }
                else
                {
                    MessageBox.Show("Thêm món ăn thất bại! Mã món có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Ngược lại là chế độ Cập nhật
            {
                if (busMonAn.UpdateMonAn(monAn))
                {
                    MessageBox.Show("Cập nhật món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFieldsAndButtons();
                }
                else
                {
                    MessageBox.Show("Cập nhật món ăn thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Tìm kiếm món ăn
        /// </summary>
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenMon = txttimkiem.Content.Trim();
            if (!string.IsNullOrEmpty(tenMon))
            {
                List<MonAn> result = busMonAn.SearchMonAn(tenMon);
            }
            else
            {
                LoadGridViewMonAn(); // Nếu không có từ khóa, tải lại toàn bộ
            }
        }

        #endregion

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }

        private void cuiPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

using BLL_QLQA;
using DTO_QLQA;
using GUI_QLQA;
using System.Data;

namespace GUI_QuanLyQuanAN
{
    public partial class frmkho : Form
    {
        // Khai báo các đối tượng BUS
        private BUSNguyenLieu busNguyenLieu = new BUSNguyenLieu();
        private BUSNhaCungCap busNhaCungCap = new BUSNhaCungCap();

        // DataTable để lưu trữ và tra cứu thông tin Nhà cung cấp
        private DataTable dtNhaCungCap;
        public frmkho()
        {
            InitializeComponent();
            //btnThem.Visible = false; // Ẩn nút Thêm
            //btnSua.Visible = false; // Ẩn nút Sửa
            //btnxuanguyenliau.Visible = false; // Ẩn nút Xóa nguyên liệu
            //btnThem.Enabled = false;
            //btnSua.Enabled = false;
            //btnxuanguyenliau.Enabled = false;
        }
        private void frmkho_Load(object sender, EventArgs e)
        {
            LoadGridViewNguyenLieu();
            LoadComboBoxNhaCungCap();
            LoadDonViTinh();
            ResetFields();
        }

        #region CÁC HÀM HỖ TRỢ

        //load đơn vị tinsh
        private void LoadDonViTinh()
        {
            cboDonViTinh.Items.Clear();
            cboDonViTinh.Items.Add("kg");
            cboDonViTinh.Items.Add("lít");
            cboDonViTinh.Items.Add("cái");
            cboDonViTinh.Items.Add("gói");
            cboDonViTinh.Items.Add("hộp");
            cboDonViTinh.SelectedIndex = 0; // Chọn mặc định là "kg"
        }
        private void LoadGridViewNguyenLieu()
        {
            dgvkho.DataSource = busNguyenLieu.GetAllNguyenLieu();
            dgvkho.Columns["MaNguyenLieu"].HeaderText = "Mã Nguyên Liệu";
            dgvkho.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dgvkho.Columns["DonViTinh"].HeaderText = "Đơn Vị Tính";
            dgvkho.Columns["SoLuongTon"].HeaderText = "Số Lượng";
            dgvkho.Columns["ID_NhaCungCap"].HeaderText = "Nhà Cung Cấp";
            LoadDonViTinh();
        }

        private void LoadComboBoxNhaCungCap()
        {
            dtNhaCungCap = busNhaCungCap.GetAllNhaCungCap();
            cboNhaCungCap.DataSource = dtNhaCungCap;
            cboNhaCungCap.DisplayMember = "TenNhaCungCap"; // Hiển thị tên nhà cung cấp
            cboNhaCungCap.ValueMember = "ID_NhaCungCap"; // Lưu ID nhà cung cấp
            cboNhaCungCap.SelectedIndex = -1; // Không chọn mặc định
        }

        private void ResetFields()
        {
            txtTimKiem.Text = ""; // txtTimKiem
            txtMaNguyenLieu.Text = ""; // txtMaNguyenLieu
            txtTenNguyenLieu.Text = ""; // txtTenNguyenLieu
            cboDonViTinh.Text = ""; // txtGiaNhap
            txtSoLuong.Text = ""; // txtSoLuongNhap
            cboNhaCungCap.SelectedIndex = -1; // cbonhacungcap
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnxuanguyenliau.Enabled = false;
            btnlammoikho.Enabled = false;
            LoadGridViewNguyenLieu();
        }

        #endregion

        #region SỰ KIỆN GIAO DIỆN

        private void dgvkho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvkho.Rows.Count)
            {
                // Lấy dữ liệu từ dòng được chọn
                DataGridViewRow row = dgvkho.Rows[e.RowIndex];
                txtMaNguyenLieu.Text = row.Cells["MaNguyenLieu"].Value.ToString();
                txtTenNguyenLieu.Text = row.Cells["TenNguyenLieu"].Value.ToString();
                cboDonViTinh.Text = row.Cells["DonViTinh"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuongTon"].Value.ToString();

                // Lấy ID nhà cung cấp và gán vào combobox
                int idNhaCungCap = Convert.ToInt32(row.Cells["ID_NhaCungCap"].Value);
                cboNhaCungCap.SelectedValue = idNhaCungCap;
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnxuanguyenliau.Enabled = true;
                btnlammoikho.Enabled = true;
            }
        }

        private void cuiTextBox1_ContentChanged(object sender, EventArgs e)
        {
            string tenNL = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(tenNL))
            {
                dgvkho.DataSource = busNguyenLieu.SearchNguyenLieu(tenNL);
            }
            else
            {
                LoadGridViewNguyenLieu();
            }
        }

        #endregion

        #region SỰ KIỆN NÚT BẤM

        private void btnthemnguyenlieu_Click(object sender, EventArgs e)
        {
            ResetValues();
            // Kích hoạt các control để bắt đầu nhập mới
            txtMaNguyenLieu.Enabled = true; // Mã NL
            txtTenNguyenLieu.Enabled = true; // Tên NL
            cboDonViTinh.Enabled = true; // Giá nhập
            txtSoLuong.Enabled = true; // Số lượng
            cboNhaCungCap.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            txtMaNguyenLieu.Focus();
        }

        private void ResetValues()
        {
            txtMaNguyenLieu.Text = ""; // txtMaNguyenLieu
            txtTenNguyenLieu.Text = ""; // txtTenNguyenLieu
            cboDonViTinh.Text = ""; // cboDonViTinh
            txtSoLuong.Text = ""; // txtSoLuongNhap
            cboNhaCungCap.SelectedIndex = -1; // cbonhacungcap
            txtMaNguyenLieu.Enabled = true; // Kích hoạt nhập mã nguyên liệu
            btnThem.Enabled = true; // Kích hoạt nút Lưu thay đổi
            btnSua.Enabled = true; // Kích hoạt nút Lưu thay đổi
        }

        private void btnxuanguyenliau_Click(object sender, EventArgs e)
        {
            string maNL = txtMaNguyenLieu.Text;
            if (string.IsNullOrEmpty(maNL))
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nguyên liệu '{maNL}'? \nHành động này không thể hoàn tác.", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (busNguyenLieu.DeleteNguyenLieu(maNL))
                    {
                        MessageBox.Show("Xóa nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFields();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Xóa thất bại! Nguyên liệu này có thể đang được sử dụng trong một công thức.", "Lỗi Ràng Buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnluuthaydoi_Click(object sender, EventArgs e) // Nút Lưu thay đổi (Nhập kho)
        {
            string maNL = txtMaNguyenLieu.Text.Trim();
            string tenNL = txtTenNguyenLieu.Text.Trim();
            string donViTinh = cboDonViTinh.Text.Trim();
            string soLuongStr = txtSoLuong.Text.Trim();
            int idNhaCungCap = cboNhaCungCap.SelectedIndex >= 0 ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : -1;
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(maNL) || string.IsNullOrEmpty(tenNL) || string.IsNullOrEmpty(donViTinh) || string.IsNullOrEmpty(soLuongStr) || idNhaCungCap == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(soLuongStr, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NguyenLieu nguyenLieu = new NguyenLieu
            {
                MaNguyenLieu = maNL,
                TenNguyenLieu = tenNL,
                DonViTinh = donViTinh,
                SoLuongTon = soLuong,
                ID_NhaCungCap = idNhaCungCap
            };
            try
            {
                if (busNguyenLieu.InsertNguyenLieu(nguyenLieu))
                {
                    MessageBox.Show("Thêm nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Thêm nguyên liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlammoikho_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void btnlíchsunhap_Click(object sender, EventArgs e)
        {
            PhieuNhapKho pn = new PhieuNhapKho();
            NhaCungCap ncc = new NhaCungCap();
            NhanVien nv = new NhanVien();
            frmPhieuNhap frmPhieuNhap =  new frmPhieuNhap();
            frmPhieuNhap.ShowDialog();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNL = txtMaNguyenLieu.Text.Trim();
            string tenNL = txtTenNguyenLieu.Text.Trim();
            string donViTinh = cboDonViTinh.Text.Trim();
            string soLuongStr = txtSoLuong.Text.Trim();
            int idNhaCungCap = cboNhaCungCap.SelectedIndex >= 0 ? Convert.ToInt32(cboNhaCungCap.SelectedValue) : -1;
            // Kiểm tra các trường bắt buộc
            if (string.IsNullOrEmpty(maNL) || string.IsNullOrEmpty(tenNL) || string.IsNullOrEmpty(donViTinh) || string.IsNullOrEmpty(soLuongStr) || idNhaCungCap == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(soLuongStr, out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Số lượng phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NguyenLieu nguyenLieu = new NguyenLieu
            {
                MaNguyenLieu = maNL,
                TenNguyenLieu = tenNL,
                DonViTinh = donViTinh,
                SoLuongTon = soLuong,
                ID_NhaCungCap = idNhaCungCap
            };
            try
            {
                if (busNguyenLieu.UpdateNguyenLieu(nguyenLieu))
                {
                    MessageBox.Show("Cập nhật nguyên liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFields();
                }
                else
                {
                    MessageBox.Show("Cập nhật nguyên liệu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật nguyên liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}

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
using DTO_QLQA;
using Sunny.UI;

namespace GUI_QLQA
{
    public partial class frmCongThuc : Form
    {
        // Khai báo các đối tượng BUS
        private BUSMonAn busMonAn = new BUSMonAn();
        private BUSCongThuc busCongThuc = new BUSCongThuc();
        private BUSNguyenLieu busNguyenLieu = new BUSNguyenLieu();

        // Biến lưu thông tin
        private string strTenHinhAnh;
        private string currentMaMon;
        private string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        public frmCongThuc()
        {
            InitializeComponent();
        }
        private void frmCongThuc_Load(object sender, EventArgs e)
        {
            string imageDirectory = Path.Combine(appDirectory, "Images");
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }
            LoadGridViewMonAn();
            LoadComboBoxNguyenLieu();
            ResetFields();
        }

        #region CÁC HÀM TẢI DỮ LIỆU

        private void LoadGridViewMonAn()
        {
            uiDataGridView1.DataSource = busMonAn.GetAllMonAn();
            uiDataGridView1.Columns["MaMon"].HeaderText = "Mã Món";
            uiDataGridView1.Columns["TenMon"].HeaderText = "Tên Món";
            uiDataGridView1.Columns["GiaBan"].HeaderText = "Giá Bán";
            uiDataGridView1.Columns["ID_LoaiMonAn"].Visible = false;
            uiDataGridView1.Columns["ThoiGianNau"].Visible = false;
            uiDataGridView1.Columns["HinhAnh"].Visible = false;
            uiDataGridView1.Columns["TrangThai"].Visible = false;
        }

        private void LoadComboBoxNguyenLieu()
        {
            DataTable dtNguyenLieu = busNguyenLieu.GetAllNguyenLieu();
            cboNguyenLieu.DataSource = dtNguyenLieu;
            cboNguyenLieu.DisplayMember = "TenNguyenLieu"; // Hiển thị tên nguyên liệu
            cboNguyenLieu.ValueMember = "MaNguyenLieu"; // Lưu trữ mã nguyên liệu
        }

        private void LoadGridViewCongThuc(string maMon)
        {
            //Giả sử bạn đã thêm DataGridView 'dgvCongThuc'
            dgvCongThuc.DataSource = busCongThuc.GetCongThucByMaMonAn(maMon);
            dgvCongThuc.Columns["MaMon"].Visible = false;
            dgvCongThuc.Columns["MaNguyenLieu"].HeaderText = "Mã NL";
            dgvCongThuc.Columns["TenNguyenLieu"].HeaderText = "Tên Nguyên Liệu";
            dgvCongThuc.Columns["SoLuongTieuHao"].HeaderText = "Số Lượng";
            dgvCongThuc.Columns["DonViTinh"].HeaderText = "ĐVT";
        }

        #endregion

        #region CÁC HÀM XỬ LÝ GIAO DIỆN

        private void ResetFields()
        {
            txtmamon.Text = "";
            txttenmon.Text = "";
            numSoLuongTieuHao.Text = "";
            currentMaMon = null;
            // dgvCongThuc.DataSource = null;
            // cboNguyenLieu.SelectedIndex = -1;
            // numSoLuongTieuHao.Value = 0;
        }

        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = uiDataGridView1.Rows[e.RowIndex];
                currentMaMon = row.Cells["MaMon"].Value.ToString();

                txtmamon.Text = currentMaMon;
                cboNguyenLieu.AccessibilityObject.Value = row.Cells["MaMon"].Value.ToString();
                numSoLuongTieuHao.Text = row.Cells["GiaBan"].Value.ToString();
                LoadGridViewCongThuc(currentMaMon);
            }
        }

        #endregion

        #region SỰ KIỆN NÚT BẤM (QUẢN LÝ MÓN ĂN)

        private void btnthemmon_Click(object sender, EventArgs e)
        {
            // Logic để thêm món ăn mới (tương tự frmmenu)
            // Cần một form nhập liệu riêng để tránh nhầm lẫn
            MessageBox.Show("Chức năng Thêm/Sửa/Xóa món ăn nên được thực hiện ở form Quản lý Menu.", "Thông báo");
        }

        private void btnxoamon_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Thêm/Sửa/Xóa món ăn nên được thực hiện ở form Quản lý Menu.", "Thông báo");
        }

        private void btnluuthaydoi_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Thêm/Sửa/Xóa món ăn nên được thực hiện ở form Quản lý Menu.", "Thông báo");
        }

        #endregion

        #region SỰ KIỆN NÚT BẤM (QUẢN LÝ CÔNG THỨC)

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentMaMon) || cboNguyenLieu.Text == null || string.IsNullOrEmpty(numSoLuongTieuHao.Text))
            {
                MessageBox.Show("Vui lòng chọn món ăn, nguyên liệu và nhập số lượng tiêu hao.", "Thông báo");
                return;
            }

            CongThuc ct = new CongThuc
            {
                MaMon = currentMaMon,
                MaNguyenLieu = cboNguyenLieu.ToString(),
                SoLuongTieuHao = Convert.ToDecimal(numSoLuongTieuHao),
            };

            if (busCongThuc.InsertCongThuc(ct))
            {
                MessageBox.Show("Thêm nguyên liệu vào công thức thành công.");
                LoadGridViewCongThuc(currentMaMon);
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Nguyên liệu có thể đã tồn tại trong công thức.");
            }
        }

        private void btnXoaNL_Click(object sender, EventArgs e)
        {
            if (dgvCongThuc.SelectedRows.Count > 0)
            {
                string maNL = dgvCongThuc.SelectedRows[0].Cells["MaNguyenLieu"].Value.ToString();
                if (busCongThuc.DeleteCongThuc(currentMaMon, maNL))
                {
                    MessageBox.Show("Xóa nguyên liệu khỏi công thức thành công.");
                    LoadGridViewCongThuc(currentMaMon);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.");
                }
            }
        }

        #endregion

        private void btnbothaydoi_Click(object sender, EventArgs e)
        {
            ResetFields();
        }
    }
}

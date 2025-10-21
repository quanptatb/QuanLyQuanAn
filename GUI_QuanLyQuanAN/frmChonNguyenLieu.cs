using System;
using System.Data;
using System.Windows.Forms;
using BLL_QLQA;
using DTO_QLQA;

namespace GUI_QLQA
{
    public partial class frmChonNguyenLieu : Form
    {
        private BUSNguyenLieu busNguyenLieu = new BUSNguyenLieu();
        private string maMon; // Mã món hiện tại

        public frmChonNguyenLieu(string maMon)
        {
            InitializeComponent();
            this.maMon = maMon;
        }

        private void frmChonNguyenLieu_Load(object sender, EventArgs e)
        {
            dgvNguyenLieu.DataSource = busNguyenLieu.GetAllNguyenLieu();
            dgvNguyenLieu.Columns["ID_NhaCungCap"].Visible = false;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (dgvNguyenLieu.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu.", "Thông báo");
                return;
            }

            string maNL = dgvNguyenLieu.SelectedRows[0].Cells["MaNguyenLieu"].Value.ToString();
            string tenNL = dgvNguyenLieu.SelectedRows[0].Cells["TenNguyenLieu"].Value.ToString();
            string dvt = dgvNguyenLieu.SelectedRows[0].Cells["DonViTinh"].Value.ToString();
            decimal soLuong;

            if (!decimal.TryParse(txtSoLuong.Text, out soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng tiêu hao không hợp lệ!", "Lỗi nhập liệu");
                return;
            }

            var busCongThuc = new BUSCongThuc();
            var ct = new CongThuc
            {
                MaMon = maMon,
                MaNguyenLieu = maNL,
                SoLuongTieuHao = soLuong
            };

            if (busCongThuc.InsertCongThuc(ct))
            {
                MessageBox.Show($"Đã thêm {tenNL} vào công thức.", "Thành công");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại (có thể đã tồn tại).", "Lỗi");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

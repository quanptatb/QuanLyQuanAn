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
    public partial class frmlichsu : Form
    {
        // Khai báo các đối tượng BUS
        private BUSHoaDon busHoaDon = new BUSHoaDon();
        private BUSChiTietHoaDon busChiTietHD = new BUSChiTietHoaDon();
        public frmlichsu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmlichsu_Load(object sender, EventArgs e)
        {
            dtplíchuthanhtoan.Value = DateTime.Now;
            btnxacnhan_Click(sender, e); // Tự động tải dữ liệu cho ngày hiện tại
        }

        #region CÁC HÀM HỖ TRỢ

        /// <summary>
        /// Tải danh sách hóa đơn đã thanh toán lên DataGridView bên trái
        /// </summary>
        private void LoadInvoiceList()
        {
            DateTime selectedDate = dtplíchuthanhtoan.Value;
            uiDataGridView1.DataSource = busHoaDon.GetPaidHoaDonByDate(selectedDate);
            // Tùy chỉnh cột
            uiDataGridView1.Columns["ID_HoaDon"].HeaderText = "Mã HĐ";
            uiDataGridView1.Columns["TenBan"].HeaderText = "Tên Bàn";
            uiDataGridView1.Columns["TongTien"].HeaderText = "Tổng Tiền";
            uiDataGridView1.Columns["ThoiGianRa"].HeaderText = "T.Gian Thanh Toán";
            uiDataGridView1.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            uiDataGridView1.Columns["ThoiGianRa"].DefaultCellStyle.Format = "HH:mm:ss";
        }

        /// <summary>
        /// Xóa thông tin trên panel chi tiết
        /// </summary>
        private void ClearDetailPanel()
        {
            labsoban.Text = "số";
            labgiogoi.Text = "giờ";
            labngaythangnamgoi.Text = "ngày, tháng, năm";
            labgiothanhtoan.Text = "giờ";
            labngaythangnamthanhtoan.Text = "ngày, tháng, năm";
            labgials.Text = "giá";
            dgvdanhsachdagoi.DataSource = null;
        }

        #endregion

        #region SỰ KIỆN

        /// <summary>
        /// Sự kiện khi nhấn nút "Xác nhận" để xem lịch sử theo ngày
        /// </summary>
        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            LoadInvoiceList();
            ClearDetailPanel();
        }

        /// <summary>
        /// Sự kiện khi click vào một hóa đơn trong danh sách để xem chi tiết
        /// </summary>
        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idHoaDon = Convert.ToInt32(uiDataGridView1.Rows[e.RowIndex].Cells["ID_HoaDon"].Value);

                // Lấy thông tin hóa đơn
                HoaDon hd = busHoaDon.GetHoaDonById(idHoaDon);
                if (hd != null)
                {
                    // Hiển thị thông tin lên panel
                    labsoban.Text = uiDataGridView1.Rows[e.RowIndex].Cells["TenBan"].Value.ToString().Replace("Bàn ", "");
                    labgiogoi.Text = hd.ThoiGianVao.ToString("HH:mm");
                    labngaythangnamgoi.Text = hd.ThoiGianVao.ToString("dd/MM/yyyy");
                    labgials.Text = hd.TongTien.ToString("N0") + " VND";

                    if (hd.ThoiGianRa.HasValue)
                    {
                        labgiothanhtoan.Text = hd.ThoiGianRa.Value.ToString("HH:mm");
                        labngaythangnamthanhtoan.Text = hd.ThoiGianRa.Value.ToString("dd/MM/yyyy");
                    }

                    // Hiển thị chi tiết các món ăn
                    dgvdanhsachdagoi.DataSource = busChiTietHD.GetChiTietByHoaDon(idHoaDon);
                    dgvdanhsachdagoi.Columns["TenMon"].HeaderText = "Tên Món";
                    dgvdanhsachdagoi.Columns["SoLuong"].HeaderText = "SL";
                    dgvdanhsachdagoi.Columns["DonGia"].HeaderText = "Đơn Giá";
                    dgvdanhsachdagoi.Columns["ThanhTien"].HeaderText = "Thành Tiền";
                    dgvdanhsachdagoi.Columns["DonGia"].DefaultCellStyle.Format = "N0";
                    dgvdanhsachdagoi.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
                }
            }
        }

        /// <summary>
        /// Sự kiện nút OK để đóng form
        /// </summary>
        private void btnload_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}

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

namespace GUI_QuanLyQuanAN
{
    public partial class frmbep : Form
    {
        // Khai báo các đối tượng BUS
        private BUSHoaDon busHoaDon = new BUSHoaDon();
        private BUSChiTietHoaDon busChiTietHD = new BUSChiTietHoaDon();

        // Timer để tự động làm mới - Chỉ định rõ System.Windows.Forms.Timer để tránh lỗi
        private System.Windows.Forms.Timer refreshTimer = new System.Windows.Forms.Timer();

        // Biến lưu hóa đơn đang được chọn
        private int currentInvoiceId = -1;
        public frmbep()
        {
            InitializeComponent();
            SetupTimer();
        }
        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmbep_Load(object sender, EventArgs e)
        {
            LoadPendingOrders();
            refreshTimer.Start(); // Bắt đầu tự động làm mới
        }

        #region CÁC HÀM HỖ TRỢ

        /// <summary>
        /// Cài đặt Timer
        /// </summary>
        private void SetupTimer()
        {
            refreshTimer.Interval = 30000; // 30 giây
            refreshTimer.Tick += RefreshTimer_Tick;
        }

        /// <summary>
        /// Tải danh sách các order đang chờ lên DataGridView bên trái
        /// </summary>
        private void LoadPendingOrders()
        {
            dgvtrai.DataSource = busHoaDon.GetAllUnpaidHoaDonWithTable();
            // Tùy chỉnh cột
            dgvtrai.Columns["ID_HoaDon"].HeaderText = "Mã HĐ";
            dgvtrai.Columns["TenBan"].HeaderText = "Tên Bàn";
            dgvtrai.Columns["ThoiGianVao"].HeaderText = "Thời Gian Vào";
            dgvtrai.Columns["ThoiGianVao"].DefaultCellStyle.Format = "HH:mm:ss";
        }

        /// <summary>
        /// Xóa thông tin chi tiết order
        /// </summary>
        private void ClearOrderDetail()
        {
            labbanorder.Text = "số";
            uiDataGridView2.DataSource = null;
            dgvtrai.Refresh();
            labloighichu.Text = "(Không có ghi chú)";
            currentInvoiceId = -1;
        }

        #endregion

        #region SỰ KIỆN

        /// <summary>
        /// Sự kiện Tick của Timer, tự động tải lại danh sách order
        /// </summary>
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadPendingOrders();
        }

        /// <summary>
        /// Sự kiện khi click vào một order trong danh sách
        /// </summary>
        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvtrai.Rows[e.RowIndex];
                currentInvoiceId = Convert.ToInt32(row.Cells["ID_HoaDon"].Value);
                string tenBan = row.Cells["TenBan"].Value.ToString();

                // Hiển thị số bàn
                labbanorder.Text = tenBan.Replace("Bàn ", "");

                // Hiển thị chi tiết các món ăn
                uiDataGridView2.DataSource = busChiTietHD.GetChiTietByHoaDon(currentInvoiceId);
                uiDataGridView2.Columns["TenMon"].HeaderText = "Tên Món";
                uiDataGridView2.Columns["SoLuong"].HeaderText = "SL";
                uiDataGridView2.Columns["DonGia"].Visible = false;
                uiDataGridView2.Columns["ThanhTien"].Visible = false;
            }
        }

        /// <summary>
        /// Sự kiện khi nhấn nút "Đã hoàn thành"
        /// </summary>
        private void cuiButton1_Click(object sender, EventArgs e)
        {
            if (currentInvoiceId != -1)
            {
                // Trong thực tế, có thể cập nhật trạng thái món ăn hoặc hóa đơn
                // Ở đây, chúng ta chỉ hiển thị thông báo
                MessageBox.Show($"Đã xác nhận hoàn thành các món cho hóa đơn {currentInvoiceId}.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa chi tiết và tải lại danh sách (để loại bỏ order vừa hoàn thành nếu có logic cập nhật CSDL)
                ClearOrderDetail();
                LoadPendingOrders();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một order để xác nhận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Dừng Timer khi form đóng lại
        /// </summary>
        private void frmbep_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshTimer.Stop();
        }

        #endregion
    }
}

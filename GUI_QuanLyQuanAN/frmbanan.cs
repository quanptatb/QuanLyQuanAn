using BLL_QLQA;
using CuoreUI.Controls;
using DTO_QLQA;
using System.Data;

namespace GUI_QuanLyQuanAN
{
    public partial class frmbanan : Form
    {
        // Khai báo các đối tượng BUS
        private BUSBanAn busBanAn = new BUSBanAn();
        private BUSHoaDon busHoaDon = new BUSHoaDon();
        private BUSChiTietHoaDon busChiTietHD = new BUSChiTietHoaDon();

        // Danh sách để quản lý các button bàn
        private List<cuiButton> listTableButtons;

        // Biến lưu thông tin hóa đơn đang được chọn
        private int currentInvoiceId = -1;
        private int currentTableId = -1;
        public frmbanan()
        {
            InitializeComponent();
            InitializeTableButtons();
        }
        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmbanan_Load(object sender, EventArgs e)
        {
            LoadTableStatus();
            ResetBillInfo();
        }

        #region CÁC HÀM KHỞI TẠO VÀ TẢI DỮ LIỆU

        /// <summary>
        /// Thêm các control button bàn vào danh sách để dễ quản lý
        /// </summary>
        private void InitializeTableButtons()
        {
            listTableButtons = new List<cuiButton>
            {
                ban1, ban2, ban3, ban4, ban5, ban6,
                ban7, ban8, ban9, ban10, ban11, ban12
            };

            // Gán sự kiện click chung cho tất cả các button
            foreach (var btn in listTableButtons)
            {
                btn.Click += Table_Click;
            }
        }

        /// <summary>
        /// Tải và cập nhật trạng thái trực quan của các bàn ăn
        /// </summary>
        private void LoadTableStatus()
        {
            List<BanAn> listBanAn = busBanAn.GetAllBanAn();
            foreach (BanAn ban in listBanAn)
            {
                cuiButton btn = listTableButtons.FirstOrDefault(b => b.Name == "ban" + ban.IdBanAn);
                if (btn != null)
                {
                    btn.Content = ban.TenBan;
                    btn.Tag = ban; // Lưu toàn bộ đối tượng BanAn vào Tag

                    switch (ban.TrangThai)
                    {
                        case "Trống":
                            btn.NormalBackground = Color.SteelBlue;
                            break;
                        case "Đang phục vụ":
                            btn.NormalBackground = Color.Crimson;
                            break;
                        default:
                            btn.NormalBackground = Color.Gray;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Xóa thông tin trên panel hóa đơn
        /// </summary>
        private void ResetBillInfo()
        {
            labban.Text = "Chọn bàn";
            uiDataGridView1.DataSource = null;
            labtonggia.Text = "0 VND";
            btnthanhtoan.Enabled = false;
            currentInvoiceId = -1;
            currentTableId = -1;
        }

        #endregion

        #region SỰ KIỆN

        /// <summary>
        /// Sự kiện click chung cho tất cả các bàn
        /// </summary>
        private void Table_Click(object sender, EventArgs e)
        {
            cuiButton btnClicked = sender as cuiButton;
            if (btnClicked?.Tag is BanAn selectedBan)
            {
                currentTableId = selectedBan.IdBanAn;
                labban.Text = selectedBan.TenBan;

                if (selectedBan.TrangThai == "Đang phục vụ")
                {
                    // Lấy thông tin hóa đơn chưa thanh toán
                    currentInvoiceId = busHoaDon.GetUnpaidHoaDonByBanAn(currentTableId);
                    if (currentInvoiceId != -1)
                    {
                        // Hiển thị chi tiết hóa đơn
                        DataTable dtChiTiet = busChiTietHD.GetChiTietByHoaDon(currentInvoiceId);
                        uiDataGridView1.DataSource = dtChiTiet;

                        // Tính và hiển thị tổng tiền
                        decimal tongTien = 0;
                        if (dtChiTiet.Rows.Count > 0)
                        {
                            tongTien = Convert.ToDecimal(dtChiTiet.Compute("SUM(ThanhTien)", string.Empty));
                        }
                        labtonggia.Text = tongTien.ToString("N0") + " VND";
                        btnthanhtoan.Enabled = true;
                    }
                }
                else
                {
                    // Nếu bàn trống thì xóa thông tin hóa đơn
                    ResetBillInfo();
                    labban.Text = selectedBan.TenBan;
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện thanh toán hóa đơn
        /// </summary>
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            if (currentInvoiceId != -1)
            {
                if (MessageBox.Show($"Xác nhận thanh toán cho {labban.Text}?", "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busHoaDon.ThanhToan(currentInvoiceId))
                    {
                        MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadTableStatus(); // Cập nhật lại trạng thái bàn
                        ResetBillInfo();
                    }
                    else
                    {
                        MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion
    }
}

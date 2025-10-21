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
    public partial class frmlíchunhap : Form
    {
        private BUSPhieuNhapKho busPhieuNhap = new BUSPhieuNhapKho();
        private BUSChiTietPhieuNhap busChiTietPN = new BUSChiTietPhieuNhap();
        public frmlíchunhap()
        {
            InitializeComponent();
        }
        private void frmlichsunhap_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = DateTime.Now;
            LoadPhieuNhapList();

            // Gán sự kiện DoubleClick cho DataGridView
            uiDataGridView1.CellDoubleClick += uiDataGridView1_CellDoubleClick;
        }

        private void LoadPhieuNhapList()
        {
            DateTime selectedDate = guna2DateTimePicker1.Value;
            uiDataGridView1.DataSource = busPhieuNhap.GetPhieuNhapByDate(selectedDate);
            // Tùy chỉnh cột
            uiDataGridView1.Columns["ID_PhieuNhap"].HeaderText = "Mã Phiếu";
            uiDataGridView1.Columns["TenNhaCungCap"].HeaderText = "Nhà Cung Cấp";
            uiDataGridView1.Columns["HoTen"].HeaderText = "Nhân Viên Nhập";
            uiDataGridView1.Columns["NgayNhap"].HeaderText = "Ngày Nhập";
            uiDataGridView1.Columns["TongTienNhap"].HeaderText = "Tổng Tiền";
            uiDataGridView1.Columns["TongTienNhap"].DefaultCellStyle.Format = "N0";
        }

        private void cuiButton1_Click(object sender, EventArgs e) // Nút Xác nhận
        {
            LoadPhieuNhapList();
        }

        /// <summary>
        /// Sự kiện khi double-click vào một phiếu nhập để xem chi tiết
        /// </summary>
        private void uiDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idPhieuNhap = Convert.ToInt32(uiDataGridView1.Rows[e.RowIndex].Cells["ID_PhieuNhap"].Value);
                DataTable dtChiTiet = busChiTietPN.GetChiTietByPhieuNhap(idPhieuNhap);

                StringBuilder detailMessage = new StringBuilder();
                detailMessage.AppendLine($"Chi tiết phiếu nhập số: {idPhieuNhap}");
                detailMessage.AppendLine("------------------------------------");

                foreach (DataRow row in dtChiTiet.Rows)
                {
                    string tenNL = row["TenNguyenLieu"].ToString();
                    decimal soLuong = Convert.ToDecimal(row["SoLuongNhap"]);
                    string dvt = row["DonViTinh"].ToString();
                    decimal giaNhap = Convert.ToDecimal(row["GiaNhap"]);
                    decimal thanhTien = Convert.ToDecimal(row["ThanhTien"]);

                    detailMessage.AppendLine($"- {tenNL}: {soLuong} {dvt} x {giaNhap:N0} = {thanhTien:N0} VND");
                }

                MessageBox.Show(detailMessage.ToString(), "Chi Tiết Phiếu Nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

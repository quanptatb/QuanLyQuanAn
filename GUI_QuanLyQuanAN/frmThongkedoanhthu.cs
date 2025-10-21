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
    public partial class frmthongkedoanhthu : Form
    {
        // Khai báo đối tượng BUS
        private BUSThongKe busThongKe = new BUSThongKe();
        public frmthongkedoanhthu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện khi form được tải, mặc định thống kê 7 ngày gần nhất
        /// </summary>
        private void frmthongkedoanhthu_Load(object sender, EventArgs e)
        {
            dtpketthuc.Value = DateTime.Now;
            dtpbatdau.Value = DateTime.Now.AddDays(-6);
            btnxacnhan_Click(sender, e); // Tự động tải dữ liệu khi form mở
        }

        /// <summary>
        /// Xử lý sự kiện khi nhấn nút "Xác nhận" để xem thống kê
        /// </summary>
        private void btnxacnhan_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpbatdau.Value;
            DateTime denNgay = dtpketthuc.Value;

            // Kiểm tra tính hợp lệ của ngày
            if (tuNgay > denNgay)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Gọi BLL để lấy dữ liệu thống kê
                DataTable dtDoanhThu = busThongKe.ThongKeDoanhThu(tuNgay, denNgay);

                // Xử lý dữ liệu để vẽ biểu đồ
                if (dtDoanhThu != null && dtDoanhThu.Rows.Count > 0)
                {
                    // Chuyển đổi cột DoanhThu sang mảng float[]
                    List<float> dataPoints = new List<float>();
                    foreach (DataRow row in dtDoanhThu.Rows)
                    {
                        dataPoints.Add(Convert.ToSingle(row["DoanhThu"]));
                    }

                    // Gán dữ liệu cho biểu đồ
                    cuiChartLine1.DataPoints = dataPoints.ToArray();
                }
                else
                {
                    // Nếu không có dữ liệu, hiển thị biểu đồ trống
                    cuiChartLine1.DataPoints = new float[0];
                    MessageBox.Show("Không có dữ liệu doanh thu trong khoảng thời gian này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

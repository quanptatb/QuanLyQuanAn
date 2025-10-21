using DAL_QLQA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLQA
{
    public class BUSThongKe
    {
        private DALThongKe dalThongKe = new DALThongKe();

        public DataTable ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            //// Validation: kiểm tra ngày bắt đầu không được lớn hơn ngày kết thúc
            //if (tuNgay > denNgay)
            //{
            //    // Có thể throw exception hoặc trả về null/bảng rỗng
            //    return null;
            //}
            //return dalThongKe.ThongKeDoanhThu(tuNgay, denNgay);
            try
            {
                // Kiểm tra ngày bắt đầu không được lớn hơn ngày kết thúc
                if (tuNgay > denNgay)
                {
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                }
                // Gọi DAL để lấy dữ liệu thống kê doanh thu
                return dalThongKe.ThongKeDoanhThu(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần, ví dụ ghi log hoặc ném lại exception
                throw new Exception("Lỗi khi thống kê doanh thu: " + ex.Message);
            }
        }
    }
}

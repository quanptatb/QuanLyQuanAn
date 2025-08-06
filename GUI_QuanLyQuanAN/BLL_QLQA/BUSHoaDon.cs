using DAL_QLQA;
using DTO_QLQA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLQA
{
    public class BUSHoaDon
    {
        private DALHoaDon dalHoaDon = new DALHoaDon();

        public int GetUnpaidHoaDonByBanAn(int idBanAn)
        {
            try
            {
                // Logic trước khi lấy hóa đơn, ví dụ kiểm tra xem bàn có tồn tại không,...
                return dalHoaDon.GetUnpaidHoaDonByBanAn(idBanAn);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw new Exception("Lỗi khi lấy hóa đơn chưa thanh toán: " + ex.Message);
            }
        }

        public int InsertHoaDon(HoaDon hoaDon)
        {
            try
            {
                // Logic trước khi thêm hóa đơn, ví dụ kiểm tra xem bàn có đang sử dụng không,...
                return dalHoaDon.InsertHoaDon(hoaDon);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw new Exception("Lỗi khi thêm hóa đơn: " + ex.Message);
            }
        }

        public bool ThanhToan(int idHoaDon)
        {
            try
            {
                // Logic trước khi thanh toán, ví dụ kiểm tra xem hóa đơn có tồn tại không,...
                return dalHoaDon.UpdateThanhToan(idHoaDon);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw new Exception("Lỗi khi thanh toán hóa đơn: " + ex.Message);
            }
        }
    }
}

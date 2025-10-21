using DAL_QLQA;
using DTO_QLQA;
using System;
using System.Collections.Generic;
using System.Data;
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
        public DataTable GetAllUnpaidHoaDonWithTable()
        {
            return dalHoaDon.GetAllUnpaidHoaDonWithTable();
        }
        public DataTable GetPaidHoaDonByDate(DateTime ngay)
        {
            return dalHoaDon.GetPaidHoaDonByDate(ngay);
        }

        public HoaDon GetHoaDonById(int idHoaDon)
        {
            DataTable dt = dalHoaDon.GetHoaDonById(idHoaDon);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new HoaDon
                {
                    IdHoaDon = Convert.ToInt32(row["ID_HoaDon"]),
                    IdBanAn = Convert.ToInt32(row["ID_BanAn"]),
                    IdNhanVien = row["ID_NhanVien"].ToString(),
                    ThoiGianVao = Convert.ToDateTime(row["ThoiGianVao"]),
                    ThoiGianRa = row["ThoiGianRa"] != DBNull.Value ? Convert.ToDateTime(row["ThoiGianRa"]) : (DateTime?)null,
                    TrangThai = row["TrangThai"].ToString(),
                    GiamGia = Convert.ToDecimal(row["GiamGia"]),
                    TongTien = Convert.ToDecimal(row["TongTien"])
                };
            }
            return null;
        }

    }
}

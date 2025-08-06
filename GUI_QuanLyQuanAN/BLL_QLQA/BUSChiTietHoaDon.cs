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
    public class BUSChiTietHoaDon
    {
        private DALChiTietHoaDon dalChiTiet = new DALChiTietHoaDon();

        public DataTable GetChiTietByHoaDon(int idHoaDon)
        {
            return dalChiTiet.GetChiTietByHoaDon(idHoaDon);
        }

        public bool InsertChiTiet(ChiTietHoaDon cthd)
        {
            if (cthd.SoLuong <= 0) return false;
            return dalChiTiet.InsertChiTiet(cthd);
        }
    }
}

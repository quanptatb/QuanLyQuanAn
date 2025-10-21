using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class HoaDon
    {
        public int IdHoaDon { get; set; }
        public int IdBanAn { get; set; }
        public string IdNhanVien { get; set; }
        public DateTime ThoiGianVao { get; set; }
        public DateTime? ThoiGianRa { get; set; }
        public string TrangThai { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongTien { get; set; }
    }
}

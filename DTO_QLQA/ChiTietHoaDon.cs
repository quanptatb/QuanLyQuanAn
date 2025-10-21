using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class ChiTietHoaDon
    {
        public int IdHoaDon { get; set; }
        public string MaMon { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        // ThanhTien có thể tính toán nên không cần đưa vào DTO
    }
}

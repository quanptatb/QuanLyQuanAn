using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class ChiTietPhieuNhap
    {
        public int Id_PhieuNhap { get; set; }
        public string MaNguyenLieu { get; set; }
        public decimal SoLuongNhap { get; set; }
        public decimal GiaNhap { get; set; }
        // ThanhTien có thể tính toán nên không cần đưa vào DTO
    }
}

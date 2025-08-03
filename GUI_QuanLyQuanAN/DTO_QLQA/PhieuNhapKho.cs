using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class PhieuNhapKho
    {
        public int IdPhieuNhap { get; set; }
        public string IdNhanVien { get; set; }
        public int? IdNhaCungCap { get; set; } // Có thể null
        public DateTime NgayNhap { get; set; }
        public decimal TongTienNhap { get; set; }
    }
}

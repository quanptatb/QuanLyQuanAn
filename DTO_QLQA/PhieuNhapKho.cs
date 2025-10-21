using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class PhieuNhapKho
    {
        public int ID_PhieuNhap { get; set; }
        public string ID_NhanVien { get; set; }
        public int ID_NhaCungCap { get; set; }
        public DateTime NgayNhap { get; set; }
        public decimal TongTienNhap { get; set; }
    }
}

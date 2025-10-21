using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class MonAn
    {
        public string MaMon { get; set; }
        public string TenMon { get; set; }
        public int? IdLoaiMonAn { get; set; }
        public decimal GiaBan { get; set; }
        public int ThoiGianNau { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
    }
}

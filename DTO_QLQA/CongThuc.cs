using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    // DTO
    public class CongThuc
    {
        public string MaMon { get; set; }
        public string MaNguyenLieu { get; set; }
        public decimal SoLuongTieuHao { get; set; }
        public string TenNguyenLieu { get; set; }    // added
        public string DonViTinh { get; set; }        // added
    }
}

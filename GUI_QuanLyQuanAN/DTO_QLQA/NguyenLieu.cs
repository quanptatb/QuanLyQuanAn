using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class NguyenLieu
    {
        public string MaNguyenLieu { get; set; }
        public string TenNguyenLieu { get; set; }
        public float SoLuong { get; set; }
        public float DonGia { get; set; }
        public DateTime NgayNhap { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string XuatXu { get; set; }
        public string DonViTinh { get; set; }
        public string MaNhaCungCap { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLQA
{
    public class NhanVien
    {
        public string ID_NhanVien { get; set; }
        public string HoTen { get; set; }
        public int IdChucVu { get; set; }
        public string CaLam { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public DateTime NgaySinh { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public bool TrangThai { get; set; }
    }
}

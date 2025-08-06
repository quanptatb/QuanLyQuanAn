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
    public class BUSNguyenLieu
    {
        private DALNguyenLieu dalNguyenLieu = new DALNguyenLieu();

        public List<NguyenLieu> GetAllNguyenLieu()
        {
            List<NguyenLieu> listNguyenLieu = new List<NguyenLieu>();
            DataTable dt = dalNguyenLieu.GetAllNguyenLieu();
            foreach (DataRow row in dt.Rows)
            {
                NguyenLieu nl = new NguyenLieu
                {
                    MaNguyenLieu = row["MaNguyenLieu"].ToString(),
                    TenNguyenLieu = row["TenNguyenLieu"].ToString(),
                    SoLuong = Convert.ToSingle(row["SoLuong"]),
                    DonGia = Convert.ToSingle(row["DonGia"]),
                    NgayNhap = Convert.ToDateTime(row["NgayNhap"]),
                    NgayHetHan = Convert.ToDateTime(row["NgayHetHan"]),
                    XuatXu = row["XuatXu"].ToString(),
                    DonViTinh = row["DonViTinh"].ToString(),
                    MaNhaCungCap = row["MaNhaCungCap"].ToString()
                };
                listNguyenLieu.Add(nl);
            }
            return listNguyenLieu;
        }

        public bool InsertNguyenLieu(NguyenLieu nguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(nguyenLieu.MaNguyenLieu) || string.IsNullOrWhiteSpace(nguyenLieu.TenNguyenLieu)) return false;
            if (nguyenLieu.SoLuong < 0 || nguyenLieu.DonGia < 0) return false;
            if (nguyenLieu.NgayHetHan < nguyenLieu.NgayNhap) return false;
            return dalNguyenLieu.InsertNguyenLieu(nguyenLieu);
        }

        public bool UpdateNguyenLieu(NguyenLieu nguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(nguyenLieu.TenNguyenLieu)) return false;
            if (nguyenLieu.SoLuong < 0 || nguyenLieu.DonGia < 0) return false;
            if (nguyenLieu.NgayHetHan < nguyenLieu.NgayNhap) return false;
            return dalNguyenLieu.UpdateNguyenLieu(nguyenLieu);
        }

        public bool DeleteNguyenLieu(string maNguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(maNguyenLieu)) return false;
            return dalNguyenLieu.DeleteNguyenLieu(maNguyenLieu);
        }
    }
}

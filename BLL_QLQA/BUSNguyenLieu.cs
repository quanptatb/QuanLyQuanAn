using DAL_QLQA;
using DTO_QLQA;
using Microsoft.Identity.Client;
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

        public DataTable GetAllNguyenLieu()
        {
            return dalNguyenLieu.GetAllNguyenLieu();
        }

        public bool InsertNguyenLieu(NguyenLieu nguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(nguyenLieu.MaNguyenLieu) || string.IsNullOrWhiteSpace(nguyenLieu.TenNguyenLieu)) return false;
            return dalNguyenLieu.InsertNguyenLieu(nguyenLieu);
        }

        public bool UpdateNguyenLieu(NguyenLieu nguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(nguyenLieu.TenNguyenLieu)) return false;
            return dalNguyenLieu.UpdateNguyenLieu(nguyenLieu);
        }

        public bool DeleteNguyenLieu(string maNguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(maNguyenLieu)) return false;
            return dalNguyenLieu.DeleteNguyenLieu(maNguyenLieu);
        }
        public DataTable SearchNguyenLieu(string tenNL)
        {
            return dalNguyenLieu.SearchNguyenLieu(tenNL);
        }
        public void GetAllNguyenLieus()
        {
            dalNguyenLieu.GetAllNguyenLieus();
        }
    }
}

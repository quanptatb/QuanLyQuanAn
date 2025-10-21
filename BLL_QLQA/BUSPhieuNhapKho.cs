using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLQA;
using DTO_QLQA;

namespace BLL_QLQA
{
    public class BUSPhieuNhapKho
    {
        private DALPhieuNhapKho dalPhieuNhap = new DALPhieuNhapKho();
        public DataTable GetPhieuNhapByDate(DateTime ngay)
        {
            return dalPhieuNhap.GetPhieuNhapByDate(ngay);
        }
        public DataTable GetAllPhieuNhap()
        {
            return dalPhieuNhap.GetAllPhieuNhap();
        }
        public void AddPhieuNhapKho(PhieuNhapKho phieuNhap)
        {
            dalPhieuNhap.AddPhieuNhapKho(phieuNhap);
        }
        // Cập nhật phiếu nhập kho
        public void UpdatePhieuNhapKho(PhieuNhapKho phieuNhap)
        {
            dalPhieuNhap.UpdatePhieuNhapKho(phieuNhap);
        }
        // Xóa phiếu nhập kho
        public void DeletePhieuNhapKho(int idPhieuNhap)
        {
            dalPhieuNhap.DeletePhieuNhapKho(idPhieuNhap);
        }
        // Tìm kiếm theo tất cả dữ liệu
        public void SearchPhieuNhapKho(string keyword)
        {
            dalPhieuNhap.SearchPhieuNhapKho(keyword);
        }
        public int GetNextID()
        {
            return dalPhieuNhap.GetNextID();
        }
    }
}

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
    public class BUSChiTietPhieuNhap
    {
        private DALChiTietPhieuNhap dalChiTietPN = new DALChiTietPhieuNhap();

        public DataTable GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            return dalChiTietPN.GetChiTietByPhieuNhap(idPhieuNhap);
        }
        //select by sql
        public List<DTO_QLQA.ChiTietPhieuNhap> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            return dalChiTietPN.SelectBySql(sql, args, cmdType);
        }
        //select chi tiết by ma phiếu nhập
        public List<DTO_QLQA.ChiTietPhieuNhap> SelectByMaPhieuNhap(string maPhieuNhap)
        {
            return dalChiTietPN.SelectByMaPhieuNhap(maPhieuNhap);
        }
        //insert chi tiết phiếu nhập
        public void InsertChiTietPhieuNhap(DTO_QLQA.ChiTietPhieuNhap ctpn)
        {
            dalChiTietPN.InsertChiTietPhieuNhap(ctpn);
        }
        //update chi tiết phiếu nhập
        public void UpdateChiTietPhieuNhap(DTO_QLQA.ChiTietPhieuNhap ctpn)
        {
            dalChiTietPN.UpdateChiTietPhieuNhap(ctpn);
        }
        //delete chi tiết phiếu nhập
        public void DeleteChiTietPhieuNhap(int idPhieuNhap, string maNguyenLieu)
        {
            dalChiTietPN.DeleteChiTietPhieuNhap(idPhieuNhap, maNguyenLieu);
        }
        //updatesoluong
        public void UpdateSoLuongNhap(ChiTietPhieuNhap ct)
        {
            dalChiTietPN.updatesoluong(ct);
        }
        // Trong BUSChiTietPhieuNhap.cs

        public decimal GetLastImportPrice(string maNguyenLieu)
        {
            object result = dalChiTietPN.GetLastImportPrice(maNguyenLieu);
            // Nếu không tìm thấy giá nhập (sản phẩm mới), trả về 0
            if (result == null || result == DBNull.Value)
            {
                return 0;
            }
            return Convert.ToDecimal(result);
        }
    }
}

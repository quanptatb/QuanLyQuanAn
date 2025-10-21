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
        public void InsertChiTietPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            dalChiTietPN.InsertChiTietPhieuNhap(ctpn);
        }

        public void DeleteChiTietPhieuNhap(int idPhieuNhap, string maNguyenLieu)
        {
            dalChiTietPN.DeleteChiTietPhieuNhap(idPhieuNhap, maNguyenLieu);
        }

        public void UpdateSoLuong(ChiTietPhieuNhap ct)
        {
            dalChiTietPN.updatesoluong(ct);
        }

        public decimal GetLastImportPrice(string maNguyenLieu)
        {
            object result = dalChiTietPN.GetLastImportPrice(maNguyenLieu);
            if (result == null || result == DBNull.Value) return 0;
            return Convert.ToDecimal(result);
        }

        /// <summary>
        /// Wrapper để cập nhật tồn kho khi một phiếu nhập được lưu.
        /// </summary>
        public bool ApplyImportToStock(int idPhieuNhap)
        {
            return dalChiTietPN.ApplyImportToStock(idPhieuNhap);
        }

        public DataTable GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            return dalChiTietPN.GetChiTietByPhieuNhap(idPhieuNhap);
        }
    }
}

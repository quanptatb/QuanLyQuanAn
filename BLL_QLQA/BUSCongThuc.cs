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
    public class BUSCongThuc
    {
        private DALCongThuc dalCongThuc = new DALCongThuc();

        /// <summary>
        /// Lấy danh sách công thức của một món ăn dưới dạng List<CongThuc>
        /// </summary>
        /// <param name="maMonAn">Mã món ăn</param>
        /// <returns>Danh sách các đối tượng CongThuc</returns>
        public List<CongThuc> GetCongThucByMaMonAn(string maMonAn)
        {
            List<CongThuc> listCongThuc = new List<CongThuc>();
            DataTable dt = dalCongThuc.GetCongThucByMaMonAn(maMonAn);

            // Duyệt qua từng dòng của DataTable và chuyển nó thành đối tượng DTO
            foreach (DataRow row in dt.Rows)
            {
                CongThuc ct = new CongThuc
                {
                    MaMon = row["MaMon"].ToString(),
                    MaNguyenLieu = row["MaNguyenLieu"].ToString(),
                    SoLuongTieuHao = Convert.ToDecimal(row["SoLuongTieuHao"]),
                    TenNguyenLieu = row["TenNguyenLieu"]?.ToString(),
                    DonViTinh = row["DonViTinh"]?.ToString()
                };
                listCongThuc.Add(ct);
            }
            return listCongThuc;
        }

        /// <summary>
        /// Thêm một nguyên liệu vào công thức
        /// </summary>
        /// <param name="congThuc">Đối tượng DTO cần thêm</param>
        /// <returns>True nếu thành công</returns>
        public bool InsertCongThuc(CongThuc congThuc)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(congThuc.MaMon) || string.IsNullOrWhiteSpace(congThuc.MaNguyenLieu))
            {
                return false;
            }
            if (congThuc.SoLuongTieuHao <= 0)
            {
                return false;
            }
            return dalCongThuc.InsertCongThuc(congThuc);
        }

        /// <summary>
        /// Cập nhật một nguyên liệu trong công thức
        /// </summary>
        /// <param name="congThuc">Đối tượng DTO cần cập nhật</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateCongThuc(CongThuc congThuc)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(congThuc.MaMon) || string.IsNullOrWhiteSpace(congThuc.MaNguyenLieu))
            {
                return false;
            }
            if (congThuc.SoLuongTieuHao <= 0)
            {
                return false;
            }
            return dalCongThuc.UpdateCongThuc(congThuc);
        }

        /// <summary>
        /// Xóa một nguyên liệu khỏi công thức
        /// </summary>
        /// <param name="maMonAn">Mã món ăn</param>
        /// <param name="maNguyenLieu">Mã nguyên liệu</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteCongThuc(string maMonAn, string maNguyenLieu)
        {
            if (string.IsNullOrWhiteSpace(maMonAn) || string.IsNullOrWhiteSpace(maNguyenLieu))
            {
                return false;
            }
            return dalCongThuc.DeleteCongThuc(maMonAn, maNguyenLieu);
        }

        // in BUSCongThuc, add a method that returns DataTable (or expose DAL result)
        public DataTable GetCongThucDataTableByMaMonAn(string maMon)
        {
            return dalCongThuc.GetCongThucByMaMonAn(maMon);
        }
    }
}

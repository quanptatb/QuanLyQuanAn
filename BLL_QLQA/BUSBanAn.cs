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
    public class BUSBanAn
    {
        private DALBanAn dalBanAn = new DALBanAn();

        /// <summary>
        /// Lấy danh sách tất cả bàn ăn dưới dạng List DTO
        /// </summary>
        /// <returns></returns>
        public List<BanAn> GetAllBanAn()
        {
            List<BanAn> listBanAn = new List<BanAn>();
            DataTable dt = dalBanAn.GetAllBanAn();
            foreach (DataRow row in dt.Rows)
            {
                BanAn banAn = new BanAn
                {
                    IdBanAn = Convert.ToInt32(row["ID_BanAn"]),
                    TenBan = row["TenBan"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                listBanAn.Add(banAn);
            }
            return listBanAn;
        }
    }
}

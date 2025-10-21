using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLQA
{
    public class DALBanAn
    {
        // Lấy danh sách và trạng thái các bàn ăn
        public DataTable GetAllBanAn()
        {
            return DBUtil.ExecuteQuery("SELECT * FROM BanAn");
        }
    }
}

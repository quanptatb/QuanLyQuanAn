using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLQA
{
    public class DALNhaCungCap
    {
        public DataTable GetAllNhaCungCap()
        {
            return DBUtil.ExecuteQuery("SELECT * FROM NhaCungCap");
        }
    }
}

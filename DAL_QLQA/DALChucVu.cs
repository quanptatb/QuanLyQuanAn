using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLQA
{
    public class DALChucVu
    {
        public DataTable GetAllChucVu()
        {
            return DBUtil.ExecuteQuery("SELECT * FROM ChucVu");
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLQA
{
    public class DALThongKe
    {
        public DataTable ThongKeDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            string sql = "EXEC sp_ThongKeDoanhThu @TuNgay, @DenNgay";

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay };
            parameters[1] = new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay };

            return DBUtil.ExecuteQuery(sql, parameters);
        }
    }
}

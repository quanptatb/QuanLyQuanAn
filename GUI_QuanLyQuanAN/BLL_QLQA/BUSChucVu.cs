using DAL_QLQA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLQA
{
    public class BUSChucVu
    {
        private DALChucVu dalChucVu = new DALChucVu();
        public DataTable GetAllChucVu()
        {
            return dalChucVu.GetAllChucVu();
        }
    }
}

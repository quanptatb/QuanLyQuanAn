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
    public class BUSMonAn
    {
        private DALMonAn dalMonAn = new DALMonAn();

        public DataTable GetAllMonAn()
        {
            return dalMonAn.GetAllMonAn();
        }

        public bool InsertMonAn(MonAn monAn)
        {
            if (string.IsNullOrWhiteSpace(monAn.TenMon) || monAn.GiaBan < 0)
            {
                return false;
            }
            return dalMonAn.InsertMonAn(monAn);
        }

        public bool UpdateMonAn(MonAn monAn)
        {
            if (string.IsNullOrWhiteSpace(monAn.TenMon) || monAn.GiaBan < 0)
            {
                return false;
            }
            return dalMonAn.UpdateMonAn(monAn);
        }

        public bool DeleteMonAn(string maMon)
        {
            if (string.IsNullOrWhiteSpace(maMon))
            {
                return false;
            }
            return dalMonAn.DeleteMonAn(maMon);
        }
        //TimKiem
        public List<MonAn> SearchMonAn(string maMonAn)
        {
            if (string.IsNullOrWhiteSpace(maMonAn))
            {
                return new List<MonAn>();
            }
            List<MonAn> result = dalMonAn.SearchMonAn(maMonAn);
            return result ?? new List<MonAn>();
        }
    }
}

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
    public class BUSChamCong
    {
        private DALChamCong dalChamCong = new DALChamCong();

        public DataTable GetAllChamCong()
        {
            return dalChamCong.GetAllChamCong();
        }

        public bool InsertChamCong(ChamCong chamCong)
        {
            if (string.IsNullOrWhiteSpace(chamCong.IdNhanVien) || string.IsNullOrWhiteSpace(chamCong.TinhTrang))
            {
                return false;
            }
            return dalChamCong.InsertChamCong(chamCong);
        }

        public bool UpdateChamCong(ChamCong chamCong)
        {
            if (string.IsNullOrWhiteSpace(chamCong.IdNhanVien) || string.IsNullOrWhiteSpace(chamCong.TinhTrang))
            {
                return false;
            }
            return dalChamCong.UpdateChamCong(chamCong);
        }

        public bool DeleteChamCong(int idChamCong)
        {
            return dalChamCong.DeleteChamCong(idChamCong);
        }
    }
}

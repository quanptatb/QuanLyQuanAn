
using DTO_QLQA;

namespace UTIL_QLQA
{
    public class AuthUtil
    {
        public static NhanVien user = null;
        public static bool IsLogin()
        {
            if (user == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(user.IdNhanVien))
            {
                return false;
            }
            return true;
        }
    }
}

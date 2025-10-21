using DTO_QLQA;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLQA
{
    public class DALMonAn
    {
        /// <summary>
        /// Lấy tất cả các món ăn đang kinh doanh (TrangThai = 1)
        /// </summary>
        public DataTable GetAllMonAn()
        {
            string sql = "SELECT * FROM MonAn WHERE TrangThai = 1";
            return DBUtil.ExecuteQuery(sql);
        }

        public bool InsertMonAn(MonAn monAn)
        {
            // Thêm TrangThai = 1 khi tạo món mới
            string sql = "INSERT INTO MonAn(MaMon, TenMon, ID_LoaiMonAn, GiaBan, ThoiGianNau, HinhAnh, TrangThai) VALUES (@MaMon, @TenMon, @IdLoai, @GiaBan, @ThoiGianNau, @HinhAnh, 1)";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = GenerateNextMaMon()}; //monAn.MaMon 
            parameters[1] = new SqlParameter("@TenMon", SqlDbType.NVarChar) { Value = monAn.TenMon };
            parameters[2] = new SqlParameter("@IdLoai", SqlDbType.Int) { Value = (object)monAn.IdLoaiMonAn ?? DBNull.Value };
            parameters[3] = new SqlParameter("@GiaBan", SqlDbType.Decimal) { Value = monAn.GiaBan };
            parameters[4] = new SqlParameter("@ThoiGianNau", SqlDbType.Int) { Value = monAn.ThoiGianNau };
            parameters[5] = new SqlParameter("@HinhAnh", SqlDbType.NVarChar) { Value = (object)monAn.HinhAnh ?? DBNull.Value };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        public bool UpdateMonAn(MonAn monAn)
        {
            string sql = "UPDATE MonAn SET TenMon = @TenMon, ID_LoaiMonAn = @IdLoai, GiaBan = @GiaBan, ThoiGianNau = @ThoiGianNau, HinhAnh = @HinhAnh WHERE MaMon = @MaMon";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@TenMon", SqlDbType.NVarChar) { Value = monAn.TenMon };
            parameters[1] = new SqlParameter("@IdLoai", SqlDbType.Int) { Value = (object)monAn.IdLoaiMonAn ?? DBNull.Value };
            parameters[2] = new SqlParameter("@GiaBan", SqlDbType.Decimal) { Value = monAn.GiaBan };
            parameters[3] = new SqlParameter("@ThoiGianNau", SqlDbType.Int) { Value = monAn.ThoiGianNau };
            parameters[4] = new SqlParameter("@HinhAnh", SqlDbType.NVarChar) { Value = (object)monAn.HinhAnh ?? DBNull.Value };
            parameters[5] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = monAn.MaMon };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// Xóa mềm: Cập nhật trạng thái của món ăn thành 0 (ngừng bán)
        /// </summary>
        /// <param name="maMon">Mã món ăn cần xóa</param>
        public bool DeleteMonAn(string maMon)
        {
            string sql = "UPDATE MonAn SET TrangThai = 0 WHERE MaMon = @MaMon";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaMon", SqlDbType.NVarChar) { Value = maMon };
            return DBUtil.ExecuteNonQuery(sql, parameters);
        }
        public List<MonAn> SearchMonAn(string maMonAn)
        {
            string sql = "SELECT * FROM MonAn WHERE MaMon LIKE @MaMonAn AND TrangThai = 1";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaMonAn", SqlDbType.NVarChar) { Value = "%" + maMonAn + "%" };
            DataTable dt = DBUtil.ExecuteQuery(sql, parameters);
            List<MonAn> listMonAn = new List<MonAn>();
            foreach (DataRow row in dt.Rows)
            {
                MonAn monAn = new MonAn
                {
                    MaMon = row["MaMon"].ToString(),
                    TenMon = row["TenMon"].ToString(),
                    IdLoaiMonAn = row["ID_LoaiMonAn"] as int?,
                    GiaBan = Convert.ToDecimal(row["GiaBan"]),
                    ThoiGianNau = Convert.ToInt32(row["ThoiGianNau"]),
                    HinhAnh = row["HinhAnh"] as string,
                    TrangThai = Convert.ToBoolean(row["TrangThai"])
                };
                listMonAn.Add(monAn);
            }
            return listMonAn;
        }
        //generate
        public void genarateMa()
        {
            string sql = "SELECT MAX(MaMon) FROM MonAn";
            object result = DBUtil.ExecuteScalar(sql);
            if (result != null && result != DBNull.Value)
            {
                string maxMaMon = result.ToString();
                int nextId = int.Parse(maxMaMon.Substring(2)) + 1; // Giả sử MaMon có định dạng "MA001", "MA002", ...
                string newMaMon = "MA" + nextId.ToString("D3"); // Tạo mã mới với định dạng "MA00X"
                Console.WriteLine("Mã món ăn tiếp theo: " + newMaMon);
            }
            else
            {
                Console.WriteLine("Không có món ăn nào trong cơ sở dữ liệu.");
            }
        }

        //Tạo mã mới với định dạng "MA00X"
        public string GenerateNextMaMon()
        {
            
            string newMaMon = "";
            string sql = "SELECT 'MA' + RIGHT('000' + CAST(ISNULL(MAX(CAST(SUBSTRING(MaMon, 3, LEN(MaMon)) AS INT)), 0) + 1 AS VARCHAR), 3) AS NewMaMon FROM MonAn;";

            object result = DBUtil.ExecuteScalar(sql);
            if (result != null && result != DBNull.Value)
            {
                newMaMon = result.ToString();                
            }

            return newMaMon;
        }
    }
}

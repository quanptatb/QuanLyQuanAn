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
    public class DALChiTietPhieuNhap
    {
        public DataTable GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            string sql = @"
        SELECT
            CTPN.MaNguyenLieu,
            NL.TenNguyenLieu,
            CTPN.SoLuongNhap,
            NL.DonViTinh,
            CTPN.GiaNhap,
            (CTPN.SoLuongNhap * CTPN.GiaNhap) AS ThanhTien -- Tính toán sẵn ở đây
        FROM
            ChiTietPhieuNhap CTPN
        JOIN
            NguyenLieu NL ON CTPN.MaNguyenLieu = NL.MaNguyenLieu
        WHERE
            CTPN.ID_PhieuNhap = @IdPhieuNhap";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdPhieuNhap", SqlDbType.Int) { Value = idPhieuNhap };
            return DBUtil.ExecuteQuery(sql, parameters);
        }
        //select by sql
        public List<ChiTietPhieuNhap> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<ChiTietPhieuNhap> list = new List<ChiTietPhieuNhap>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    ChiTietPhieuNhap entity = new ChiTietPhieuNhap
                    {
                        Id_PhieuNhap = Convert.ToInt32(reader["ID_PhieuNhap"]),
                        MaNguyenLieu = reader["MaNguyenLieu"].ToString(),
                        SoLuongNhap = Convert.ToDecimal(reader["SoLuongNhap"]),
                        GiaNhap = Convert.ToDecimal(reader["GiaNhap"])
                    };
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        //select chi tiết by ma phiếu nhập
        public List<ChiTietPhieuNhap> SelectByMaPhieuNhap(string maPhieuNhap)
        {
            string sql = "SELECT * FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @0";

            // ✅ FIX: Truyền trực tiếp giá trị
            List<object> args = new List<object>();
            args.Add(maPhieuNhap);

            return SelectBySql(sql, args);
        }
        //insert chi tiết phiếu nhập
        public void InsertChiTietPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            string sql = "INSERT INTO ChiTietPhieuNhap (ID_PhieuNhap, MaNguyenLieu, SoLuongNhap, GiaNhap) VALUES (@IdPhieuNhap, @MaNguyenLieu, @SoLuongNhap, @GiaNhap)";

            // ✅ FIX: Chuyển sang sử dụng SqlParameter[]
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@IdPhieuNhap", SqlDbType.Int) { Value = ctpn.Id_PhieuNhap },
        new SqlParameter("@MaNguyenLieu", SqlDbType.NVarChar) { Value = ctpn.MaNguyenLieu },
        new SqlParameter("@SoLuongNhap", SqlDbType.Decimal) { Value = ctpn.SoLuongNhap },
        new SqlParameter("@GiaNhap", SqlDbType.Decimal) { Value = ctpn.GiaNhap }
            };

            // Giả sử DBUtil.Update cũng nhận SqlParameter[]. Nếu không, bạn cần tạo DBUtil.ExecuteNonQuery.
            DBUtil.ExecuteNonQuery(sql, parameters);
        }
        //update chi tiết phiếu nhập
        // Trong DALChiTietPhieuNhap.cs
        public void UpdateChiTietPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            string sql = "UPDATE ChiTietPhieuNhap SET SoLuongNhap = @SoLuong, GiaNhap = @Gia WHERE ID_PhieuNhap = @IdPN AND MaNguyenLieu = @MaNL";

            // ✅ FIX: Chuyển sang sử dụng SqlParameter[]
            SqlParameter[] parameters = new SqlParameter[]
           {
        new SqlParameter("@SoLuong", SqlDbType.Decimal) { Value = ctpn.SoLuongNhap },
        new SqlParameter("@Gia", SqlDbType.Decimal) { Value = ctpn.GiaNhap },
        new SqlParameter("@IdPN", SqlDbType.Int) { Value = ctpn.Id_PhieuNhap },
        new SqlParameter("@MaNL", SqlDbType.NVarChar) { Value = ctpn.MaNguyenLieu }
           };

            DBUtil.ExecuteNonQuery(sql, parameters);
        }
        //delete chi tiết phiếu nhập
        public void DeleteChiTietPhieuNhap(int idPhieuNhap, string maNguyenLieu)
        {
            string sql = "DELETE FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @0 AND MaNguyenLieu = @1";
            List<object> args = new List<object>();
            args.Add(idPhieuNhap);
            args.Add(maNguyenLieu);
            DBUtil.Update(sql, args);
        }
        public void updatesoluong(ChiTietPhieuNhap ct)
        {
            string sql = "UPDATE ChiTietPhieuNhap SET SoLuongNhap = @2 WHERE ID_PhieuNhap = @0 AND MaNguyenLieu = @1";

            // ✅ FIX: Truyền trực tiếp các giá trị vào danh sách
            List<object> args = new List<object>();
            args.Add(ct.SoLuongNhap);
            args.Add(ct.Id_PhieuNhap);
            args.Add(ct.MaNguyenLieu);

            // Thứ tự thêm vào 'args' phải khớp với thứ tự các tham số trong câu lệnh SQL
            DBUtil.Update(sql, args);
        }
        // Trong DALChiTietPhieuNhap.cs

        // Lấy giá nhập gần nhất của một nguyên liệu
        public object GetLastImportPrice(string maNguyenLieu)
        {
            string sql = @"
        SELECT TOP 1 GiaNhap
        FROM ChiTietPhieuNhap
        WHERE MaNguyenLieu = @MaNL
        ORDER BY ID_PhieuNhap DESC";

            // ✅ FIX: Tạo một mảng SqlParameter
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaNL", SqlDbType.NVarChar) { Value = maNguyenLieu };

            return DBUtil.ExecuteScalar(sql, parameters);
        }
    }
}

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
        /// <summary>
        /// Thêm chi tiết phiếu nhập (hoặc cập nhật số lượng nếu tồn tại)
        /// </summary>
        public void InsertChiTietPhieuNhap(ChiTietPhieuNhap ctpn)
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @IdPN AND MaNguyenLieu = @MaNL)
                    UPDATE ChiTietPhieuNhap SET SoLuongNhap = SoLuongNhap + @SoLuong, GiaNhap = @Gia WHERE ID_PhieuNhap = @IdPN AND MaNguyenLieu = @MaNL
                ELSE
                    INSERT INTO ChiTietPhieuNhap(ID_PhieuNhap, MaNguyenLieu, SoLuongNhap, GiaNhap) VALUES (@IdPN, @MaNL, @SoLuong, @Gia)";
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@IdPN", System.Data.SqlDbType.Int) { Value = ctpn.Id_PhieuNhap };
            parameters[1] = new SqlParameter("@MaNL", System.Data.SqlDbType.NVarChar) { Value = ctpn.MaNguyenLieu };
            parameters[2] = new SqlParameter("@SoLuong", System.Data.SqlDbType.Int) { Value = ctpn.SoLuongNhap };
            parameters[3] = new SqlParameter("@Gia", System.Data.SqlDbType.Decimal) { Value = ctpn.GiaNhap };

            DBUtil.ExecuteNonQuery(sql, parameters);
        }

        // delete chi tiết phiếu nhập
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

            // Truyền trực tiếp các giá trị vào danh sách (thứ tự phải khớp)
            List<object> args = new List<object>();
            args.Add(ct.SoLuongNhap);
            args.Add(ct.Id_PhieuNhap);
            args.Add(ct.MaNguyenLieu);

            DBUtil.Update(sql, args);
        }

        // Lấy giá nhập gần nhất của một nguyên liệu
        public object GetLastImportPrice(string maNguyenLieu)
        {
            string sql = @"
        SELECT TOP 1 GiaNhap
        FROM ChiTietPhieuNhap
        WHERE MaNguyenLieu = @MaNL
        ORDER BY ID_PhieuNhap DESC";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@MaNL", System.Data.SqlDbType.NVarChar) { Value = maNguyenLieu };

            return DBUtil.ExecuteScalar(sql, parameters);
        }

        /// <summary>
        /// Áp dụng số lượng nhập trong ChiTietPhieuNhap vào bảng NguyenLieu (tăng SoLuongTon)
        /// Gộp cập nhật tất cả nguyên liệu thuộc một phiếu nhập bằng 1 câu lệnh để tránh vòng lặp DB.
        /// </summary>
        /// <param name="idPhieuNhap">ID phiếu nhập đã lưu</param>
        /// <returns>True nếu cập nhật thành công</returns>
        public bool ApplyImportToStock(int idPhieuNhap)
        {
            string sql = @"
                UPDATE NL
                SET NL.SoLuongTon = ISNULL(NL.SoLuongTon, 0) + CT.SoLuongNhap
                FROM NguyenLieu NL
                INNER JOIN ChiTietPhieuNhap CT ON NL.MaNguyenLieu = CT.MaNguyenLieu
                WHERE CT.ID_PhieuNhap = @IdPN";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdPN", System.Data.SqlDbType.Int) { Value = idPhieuNhap };

            return DBUtil.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// (Ví dụ) Lấy danh sách chi tiết theo phiếu nhập
        /// </summary>
        public DataTable GetChiTietByPhieuNhap(int idPhieuNhap)
        {
            string sql = "SELECT * FROM ChiTietPhieuNhap WHERE ID_PhieuNhap = @IdPN";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@IdPN", System.Data.SqlDbType.Int) { Value = idPhieuNhap };
            return DBUtil.ExecuteQuery(sql, parameters);
        }
    }
}

using BLL_QLQA;
using DTO_QLQA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTIL_QLQA;

namespace GUI_QuanLyQuanAN
{
    public partial class frmorder : Form
    {
        // Khai báo các đối tượng BUS
        private BUSMonAn busMonAn = new BUSMonAn();
        private BUSBanAn busBanAn = new BUSBanAn();
        private BUSHoaDon busHoaDon = new BUSHoaDon();
        private BUSChiTietHoaDon busChiTietHD = new BUSChiTietHoaDon();

        // DataTable để quản lý danh sách món ăn và order hiện tại
        private DataTable dtMenu;
        private DataTable dtOrder;
        public frmorder()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmorder_Load(object sender, EventArgs e)
        {
            labtime.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
            LoadMenu();
            LoadBanAn();
            InitializeOrderTable();
        }

        #region CÁC HÀM TẢI DỮ LIỆU VÀ KHỞI TẠO

        /// <summary>
        /// Tải danh sách món ăn lên DataGridView
        /// </summary>
        private void LoadMenu()
        {
            dtMenu = busMonAn.GetAllMonAn();
            uiDataGridView2.DataSource = dtMenu;
            // Tùy chỉnh cột
            uiDataGridView2.Columns["MaMon"].HeaderText = "Mã Món";
            uiDataGridView2.Columns["TenMon"].HeaderText = "Tên Món";
            uiDataGridView2.Columns["GiaBan"].HeaderText = "Đơn Giá";
            uiDataGridView2.Columns["ID_LoaiMonAn"].Visible = false;
            uiDataGridView2.Columns["ThoiGianNau"].Visible = false;
            uiDataGridView2.Columns["HinhAnh"].Visible = false;
            uiDataGridView2.Columns["TrangThai"].Visible = false;
        }

        /// <summary>
        /// Tải danh sách bàn ăn vào ComboBox
        /// </summary>
        private void LoadBanAn()
        {
            List<BanAn> listBanAn = busBanAn.GetAllBanAn();
            cboban.DataSource = listBanAn;
            cboban.DisplayMember = "TenBan";
            cboban.ValueMember = "IdBanAn";
        }

        /// <summary>
        /// Khởi tạo cấu trúc cho DataTable chứa các món được order
        /// </summary>
        private void InitializeOrderTable()
        {
            dtOrder = new DataTable();
            dtOrder.Columns.Add("MaMon", typeof(string));
            dtOrder.Columns.Add("TenMon", typeof(string));
            dtOrder.Columns.Add("SoLuong", typeof(int));
            dtOrder.Columns.Add("DonGia", typeof(decimal));
            dtOrder.Columns.Add("ThanhTien", typeof(decimal), "SoLuong * DonGia");

            uiDataGridView1.DataSource = dtOrder;
            // Tùy chỉnh cột
            uiDataGridView1.Columns["MaMon"].HeaderText = "Mã Món";
            uiDataGridView1.Columns["TenMon"].HeaderText = "Tên Món";
            uiDataGridView1.Columns["SoLuong"].HeaderText = "SL";
            uiDataGridView1.Columns["DonGia"].HeaderText = "Đơn Giá";
            uiDataGridView1.Columns["ThanhTien"].HeaderText = "Thành Tiền";
        }

        /// <summary>
        /// Làm mới lại toàn bộ form để sẵn sàng cho order mới
        /// </summary>
        private void ResetForm()
        {
            dtOrder.Clear();
            cboban.SelectedIndex = 0;
            txttimkiemmonan.Text = "";
            cuiTextBox1.Text = ""; // Ghi chú
            UpdateTotalPrice();
        }

        #endregion

        #region SỰ KIỆN GIAO DIỆN

        /// <summary>
        /// Sự kiện khi double-click vào một món ăn trong menu để thêm vào order
        /// </summary>
        private void uiDataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string maMon = uiDataGridView2.Rows[e.RowIndex].Cells["MaMon"].Value.ToString();
            string tenMon = uiDataGridView2.Rows[e.RowIndex].Cells["TenMon"].Value.ToString();
            decimal donGia = Convert.ToDecimal(uiDataGridView2.Rows[e.RowIndex].Cells["GiaBan"].Value);

            // Hỏi số lượng
            int soLuong = InputBox.Show("Nhập số lượng:", "Thêm món");
            if (soLuong > 0)
            {
                // Kiểm tra xem món đã có trong order chưa
                DataRow existingRow = dtOrder.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaMon") == maMon);
                if (existingRow != null)
                {
                    // Nếu có, tăng số lượng
                    existingRow["SoLuong"] = (int)existingRow["SoLuong"] + soLuong;
                }
                else
                {
                    // Nếu chưa, thêm dòng mới
                    dtOrder.Rows.Add(maMon, tenMon, soLuong, donGia);
                }
                UpdateTotalPrice();
            }
        }

        /// <summary>
        /// Cập nhật tổng tiền hiển thị trên giao diện
        /// </summary>
        private void UpdateTotalPrice()
        {
            decimal tongTien = 0;
            if (dtOrder.Rows.Count > 0)
            {
                tongTien = Convert.ToDecimal(dtOrder.Compute("SUM(ThanhTien)", string.Empty));
            }
            lblgia.Text = tongTien.ToString("N0") + " VND";
        }

        /// <summary>
        /// Lọc danh sách món ăn khi người dùng gõ vào ô tìm kiếm
        /// </summary>
        private void txttimkiemmonan_TextChanged(object sender, EventArgs e)
        {
            string filter = txttimkiemmonan.Text.Trim();
            if (string.IsNullOrEmpty(filter))
            {
                dtMenu.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                dtMenu.DefaultView.RowFilter = $"TenMon LIKE '%{filter}%'";
            }
        }

        #endregion

        #region SỰ KIỆN NÚT BẤM

        /// <summary>
        /// Xóa món ăn đã chọn khỏi order
        /// </summary>
        private void cuiButton1_Click(object sender, EventArgs e) // Nút Xóa
        {
            if (uiDataGridView1.SelectedRows.Count > 0)
            {
                DataRowView drv = (DataRowView)uiDataGridView1.SelectedRows[0].DataBoundItem;
                drv.Row.Delete();
                UpdateTotalPrice();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xác nhận và lưu order vào CSDL
        /// </summary>
        private void btnorder_Click(object sender, EventArgs e)
        {
            // Kiểm tra điều kiện
            if (cboban.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn bàn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtOrder.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm món vào order!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idBanAn = (int)cboban.SelectedValue;

            // Kiểm tra xem bàn có hóa đơn chưa thanh toán không
            int idHoaDon = busHoaDon.GetUnpaidHoaDonByBanAn(idBanAn);

            // Nếu không có, tạo hóa đơn mới
            if (idHoaDon == -1)
            {
                HoaDon hoaDonMoi = new HoaDon { IdBanAn = idBanAn, IdNhanVien = AuthUtil.user.ID_NhanVien };
                idHoaDon = busHoaDon.InsertHoaDon(hoaDonMoi);
            }

            // Nếu tạo hóa đơn thành công (hoặc đã có sẵn)
            if (idHoaDon != -1)
            {
                bool success = true;
                // Thêm từng món trong order vào ChiTietHoaDon
                foreach (DataRow row in dtOrder.Rows)
                {
                    ChiTietHoaDon cthd = new ChiTietHoaDon
                    {
                        IdHoaDon = idHoaDon,
                        MaMon = row["MaMon"].ToString(),
                        SoLuong = Convert.ToInt32(row["SoLuong"]),
                        DonGia = Convert.ToDecimal(row["DonGia"])
                    };
                    if (!busChiTietHD.InsertChiTiet(cthd))
                    {
                        success = false;
                        break; // Dừng lại nếu có lỗi
                    }
                }

                if (success)
                {
                    MessageBox.Show("Order thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetForm();
                }
                else
                {
                    MessageBox.Show("Order thất bại! Đã có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không thể tạo hóa đơn mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /// <summary>
        /// Lớp tĩnh để tạo một InputBox đơn giản
        /// </summary>
        public static class InputBox
        {
            public static int Show(string prompt, string title)
            {
                Form form = new Form();
                Label label = new Label();
                NumericUpDown numericUpDown = new NumericUpDown();
                Button buttonOk = new Button();
                Button buttonCancel = new Button();

                form.Text = title;
                label.Text = prompt;
                numericUpDown.Value = 1;
                numericUpDown.Minimum = 1;
                numericUpDown.Maximum = 100;

                buttonOk.Text = "OK";
                buttonCancel.Text = "Cancel";
                buttonOk.DialogResult = DialogResult.OK;
                buttonCancel.DialogResult = DialogResult.Cancel;

                label.SetBounds(9, 20, 372, 13);
                numericUpDown.SetBounds(12, 36, 372, 20);
                buttonOk.SetBounds(228, 72, 75, 23);
                buttonCancel.SetBounds(309, 72, 75, 23);

                label.AutoSize = true;
                numericUpDown.Anchor = numericUpDown.Anchor | AnchorStyles.Right;
                buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

                form.ClientSize = new Size(396, 107);
                form.Controls.AddRange(new Control[] { label, numericUpDown, buttonOk, buttonCancel });
                form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.AcceptButton = buttonOk;
                form.CancelButton = buttonCancel;

                DialogResult dialogResult = form.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    return (int)numericUpDown.Value;
                }
                return 0; // Trả về 0 nếu người dùng hủy
            }
        }
    }
}

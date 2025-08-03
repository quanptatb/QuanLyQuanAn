using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyQuanAN
{
    public partial class frmchamcong : Form
    {
        public frmchamcong()
        {
            InitializeComponent();
        }

        private void frmchamcong_Load(object sender, EventArgs e)
        {
            // Cấu hình mặc định khi form load
            thang.Format = DateTimePickerFormat.Custom;
            thang.CustomFormat = "MM/yyyy";
            thang.ShowUpDown = true;

            ngay.Format = DateTimePickerFormat.Short;

            CapNhatNgayTheoThang();
        }

        private void thang_ValueChanged(object sender, EventArgs e)
        {
            DateTime thangDuocChon = thang.Value;
            DateTime thangHienTai = DateTime.Now;

            if (thangDuocChon.Year > thangHienTai.Year ||
               (thangDuocChon.Year == thangHienTai.Year && thangDuocChon.Month > thangHienTai.Month))
            {
                MessageBox.Show("Tháng chưa bắt đầu, vui lòng chọn lại tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                thang.Value = new DateTime(thangHienTai.Year, thangHienTai.Month, 1);
            }
            else
            {
                CapNhatNgayTheoThang();
            }
        }

        private void CapNhatNgayTheoThang()
        {
            int month = thang.Value.Month;
            int year = thang.Value.Year;

            DateTime firstDay = new DateTime(year, month, 1);
            DateTime lastDay = firstDay.AddMonths(1).AddDays(-1);

            ngay.MinDate = firstDay;
            ngay.MaxDate = lastDay;

            // Nếu ngày hiện tại không nằm trong tháng đó, đặt lại
            if (ngay.Value < firstDay || ngay.Value > lastDay)
            {
                ngay.Value = firstDay;
            }
        }

    }
}

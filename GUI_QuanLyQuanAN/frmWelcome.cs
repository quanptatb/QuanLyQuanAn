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
    public partial class frmWelcome : Form
    {
        // Khai báo Timer, chỉ định rõ là System.Windows.Forms.Timer
        private System.Windows.Forms.Timer timer;
        public frmWelcome()
        {
            InitializeComponent();
            SetupTimer();
        }
        /// <summary>
        /// Cài đặt các thuộc tính cho Timer
        /// </summary>
        private void SetupTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // Tốc độ chạy của progress bar
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Sự kiện khi form được tải
        /// </summary>
        private void frmWelcome_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer.Start(); // Bắt đầu chạy Timer
        }

        /// <summary>
        /// Sự kiện Tick của Timer, được gọi lặp đi lặp lại
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Tăng giá trị của progress bar
            progressBar1.Value += 1;

            // Khi progress bar đầy
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer.Stop(); // Dừng timer
                this.Hide();  // Ẩn form hiện tại
                frmLogin loginForm = new frmLogin();
                loginForm.ShowDialog(); // Hiển thị form đăng nhập
                this.Close(); // Đóng form chào mừng sau khi form đăng nhập được đóng
            }
        }
    }
}

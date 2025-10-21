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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

        }



        private Form currentFormChild;

        private void openChildForm(Form formChild)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = formChild;
            formChild.TopLevel = false;
            formChild.FormBorderStyle = FormBorderStyle.None;
            formChild.Dock = DockStyle.Fill;
            PICANH.Controls.Add(formChild);
            PICANH.Tag = formChild;
            formChild.BringToFront();
            formChild.Show();
        }

        public void CloseChildForm()
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
                currentFormChild = null;
            }
        }

        private void lblUser_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Xử lý phân quyền dựa trên chức vụ của người dùng
        /// </summary>
        private void PhanQuyen()
        {
            if (AuthUtil.IsLogin())
            {
                labtennhanvien.Text = "Xin chào, " + AuthUtil.user.HoTen;
                int idChucVu = AuthUtil.user.IdChucVu;

                // 1: Quản lý, 2: Thu ngân, 3: Phục vụ, 4: Đầu bếp
                switch (idChucVu)
                {
                    case 1: // Quản lý: full quyền
                        // Mặc định tất cả đều visible
                        break;
                    case 2: // Thu ngân
                        btnnhanvien.Visible = false;
                        btnkho.Visible = false;
                        btnbep.Visible = false;
                        break;
                    case 3: // Phục vụ
                        btnnhanvien.Visible = false;
                        btnkho.Visible = false;
                        btnbep.Visible = false;
                        btnthongke.Visible = false;
                        btnlichsu.Visible = false;
                        btnmenu.Visible = false;
                        break;
                    case 4: // Đầu bếp
                        btnmenu.Visible = false;
                        btnorder.Visible = false;
                        btnnhanvien.Visible = false;
                        btnban.Visible = false;
                        btnlichsu.Visible = false;
                        btnkho.Visible = false;
                        btnthongke.Visible = false;
                        break;
                    default: // Không xác định
                        // Ẩn hết các chức năng nghiệp vụ
                        btnmenu.Visible = false;
                        btnorder.Visible = false;
                        btnnhanvien.Visible = false;
                        btnban.Visible = false;
                        btnlichsu.Visible = false;
                        btnbep.Visible = false;
                        btnkho.Visible = false;
                        btnthongke.Visible = false;
                        break;
                }
            }
            else
            {
                // Trường hợp không có ai đăng nhập (chạy trực tiếp frmMain)
                // Nên ẩn hết để tránh lỗi
                this.Close();
            }
        }

        private void btnorder_Click(object sender, EventArgs e)
        {
            openChildForm(new frmorder());
            labtenfrm.Text = "Order";
        }

        private void btnnhanvien_Click(object sender, EventArgs e)
        {
            openChildForm(new frmnhanvin());
            labtenfrm.Text = "Nhân viên";
        }

        private void btnban_Click(object sender, EventArgs e)
        {
            openChildForm(new frmbanan());
            labtenfrm.Text = "Bàn";
        }

        private void thoatchuongtrinh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void vetrangchu_Click(object sender, EventArgs e)
        {
            CloseChildForm();
            labtenfrm.Text = "Trang chủ";
        }

        private void btnlichsu_Click(object sender, EventArgs e)
        {
            openChildForm(new frmlichsu());
            labtenfrm.Text = "Lịch sử bàn";
        }

        private void btnthongke_Click(object sender, EventArgs e)
        {
            openChildForm(new frmthongkedoanhthu());
            labtenfrm.Text = "Doanh thu";
        }

        private void btnbep_Click(object sender, EventArgs e)
        {
            openChildForm(new frmbep());
            labtenfrm.Text = "Bếp";
        }

        private void btnkho_Click(object sender, EventArgs e)
        {
            openChildForm(new frmkho());
            labtenfrm.Text = "Kho";
        }

        private void btndangxuat_Click(object sender, EventArgs e)
        {
            AuthUtil.user = null; // Xóa thông tin người dùng
            this.Close(); // Đóng form chính để quay về form đăng nhập
        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            openChildForm(new frmResetPW());
            labtenfrm.Text = "Đổi mật khẩu";
        }

        private void frmmian_Load(object sender, EventArgs e)
        {
            PhanQuyen();
            vetrangchu_Click(sender, e); // Mặc định hiển thị trang chủ
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            openChildForm(new frmmenu());
            labtenfrm.Text = "Menu";
        }
    }
}

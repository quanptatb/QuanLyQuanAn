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
    public partial class frmmian : Form
    {
        public frmmian()
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

        private void btnmenu_MouseClick(object sender, MouseEventArgs e)
        {
            openChildForm(new frmmenu());
            labtenfrm.Text = "Menu";
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
            DialogResult result = MessageBox.Show(
           "Bạn có chắc chắn muốn dừng chương trình không?",
           "Xác nhận thoát",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
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

        private void btnmenu_Click(object sender, EventArgs e)
        {

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

        }

        private void btndoimk_Click(object sender, EventArgs e)
        {
            openChildForm(new Quenmk());
            labtenfrm.Text = "Đổi mật khẩu";
        }
    }
}

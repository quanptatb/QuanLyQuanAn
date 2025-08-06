using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI_QuanLyQuanAN;

namespace GUI_QuanLyQuanAN
{
    public partial class frmnhanvin : Form
    {
        public frmnhanvin()
        {
            InitializeComponent();
        }

        private void btnchamcong_Click(object sender, EventArgs e)
        {
            frmchamcong f = new frmchamcong();
            f.ShowDialog();
        }
    }
}

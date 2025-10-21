namespace GUI_QuanLyQuanAN
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            cuiGroupBox1 = new CuoreUI.Controls.cuiGroupBox();
            pictureBox1 = new PictureBox();
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            label1 = new Label();
            cuiButton1 = new CuoreUI.Controls.cuiButton();
            txtMatKhau = new CuoreUI.Controls.cuiTextBox();
            txtTaiKhoan = new CuoreUI.Controls.cuiTextBox();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            cuiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            cuiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // cuiGroupBox1
            // 
            cuiGroupBox1.BackColor = SystemColors.ButtonHighlight;
            cuiGroupBox1.BorderColor = Color.FromArgb(64, 128, 128, 128);
            cuiGroupBox1.Content = "";
            cuiGroupBox1.Controls.Add(pictureBox1);
            cuiGroupBox1.Controls.Add(cuiPanel1);
            cuiGroupBox1.Location = new Point(12, 12);
            cuiGroupBox1.Name = "cuiGroupBox1";
            cuiGroupBox1.Padding = new Padding(4, 27, 4, 4);
            cuiGroupBox1.Rounding = new Padding(4);
            cuiGroupBox1.Size = new Size(857, 459);
            cuiGroupBox1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 41);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(389, 352);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // cuiPanel1
            // 
            cuiPanel1.Controls.Add(label1);
            cuiPanel1.Controls.Add(cuiButton1);
            cuiPanel1.Controls.Add(txtMatKhau);
            cuiPanel1.Controls.Add(txtTaiKhoan);
            cuiPanel1.Controls.Add(guna2HtmlLabel2);
            cuiPanel1.Controls.Add(guna2HtmlLabel1);
            cuiPanel1.Location = new Point(460, 30);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.PanelColor = Color.White;
            cuiPanel1.PanelOutlineColor = Color.Silver;
            cuiPanel1.Rounding = new Padding(8);
            cuiPanel1.Size = new Size(364, 401);
            cuiPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Location = new Point(87, 290);
            label1.Name = "label1";
            label1.Size = new Size(151, 25);
            label1.TabIndex = 6;
            label1.Text = " Quên mật khẩu ";
            label1.Click += lblQuenMatKhau_Click;
            // 
            // cuiButton1
            // 
            cuiButton1.CheckButton = false;
            cuiButton1.Checked = false;
            cuiButton1.CheckedBackground = Color.FromArgb(255, 106, 0);
            cuiButton1.CheckedForeColor = Color.White;
            cuiButton1.CheckedImageTint = Color.White;
            cuiButton1.CheckedOutline = Color.FromArgb(255, 106, 0);
            cuiButton1.Content = "Đăng nhập";
            cuiButton1.DialogResult = DialogResult.None;
            cuiButton1.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cuiButton1.ForeColor = Color.White;
            cuiButton1.HoverBackground = Color.MediumTurquoise;
            cuiButton1.HoverForeColor = Color.Black;
            cuiButton1.HoverImageTint = Color.White;
            cuiButton1.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            cuiButton1.Image = null;
            cuiButton1.ImageAutoCenter = true;
            cuiButton1.ImageExpand = new Point(0, 0);
            cuiButton1.ImageOffset = new Point(0, 0);
            cuiButton1.Location = new Point(109, 242);
            cuiButton1.Name = "cuiButton1";
            cuiButton1.NormalBackground = Color.SteelBlue;
            cuiButton1.NormalForeColor = Color.White;
            cuiButton1.NormalImageTint = Color.White;
            cuiButton1.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.OutlineThickness = 1F;
            cuiButton1.PressedBackground = Color.WhiteSmoke;
            cuiButton1.PressedForeColor = Color.FromArgb(32, 32, 32);
            cuiButton1.PressedImageTint = Color.White;
            cuiButton1.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            cuiButton1.Rounding = new Padding(8);
            cuiButton1.Size = new Size(153, 45);
            cuiButton1.TabIndex = 4;
            cuiButton1.TextAlignment = StringAlignment.Center;
            cuiButton1.TextOffset = new Point(0, 0);
            cuiButton1.Click += btnDangNhap_Click;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BackgroundColor = Color.WhiteSmoke;
            txtMatKhau.Content = "";
            txtMatKhau.Cursor = Cursors.IBeam;
            txtMatKhau.FocusBackgroundColor = Color.White;
            txtMatKhau.FocusImageTint = Color.White;
            txtMatKhau.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtMatKhau.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.ForeColor = Color.Gray;
            txtMatKhau.Image = null;
            txtMatKhau.ImageExpand = new Point(0, 0);
            txtMatKhau.ImageOffset = new Point(0, 0);
            txtMatKhau.Location = new Point(29, 178);
            txtMatKhau.Margin = new Padding(4);
            txtMatKhau.Multiline = false;
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.NormalImageTint = Color.White;
            txtMatKhau.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txtMatKhau.Padding = new Padding(15, 14, 15, 0);
            txtMatKhau.PasswordChar = false;
            txtMatKhau.PlaceholderColor = SystemColors.WindowText;
            txtMatKhau.PlaceholderText = "";
            txtMatKhau.Rounding = new Padding(8);
            txtMatKhau.Size = new Size(310, 42);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.TextOffset = new Size(0, 0);
            txtMatKhau.UnderlinedStyle = true;
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.BackColor = SystemColors.ButtonHighlight;
            txtTaiKhoan.BackgroundColor = Color.WhiteSmoke;
            txtTaiKhoan.Content = "";
            txtTaiKhoan.Cursor = Cursors.IBeam;
            txtTaiKhoan.FocusBackgroundColor = Color.White;
            txtTaiKhoan.FocusImageTint = Color.White;
            txtTaiKhoan.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtTaiKhoan.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTaiKhoan.ForeColor = Color.Gray;
            txtTaiKhoan.Image = null;
            txtTaiKhoan.ImageExpand = new Point(0, 0);
            txtTaiKhoan.ImageOffset = new Point(0, 0);
            txtTaiKhoan.Location = new Point(29, 73);
            txtTaiKhoan.Margin = new Padding(4);
            txtTaiKhoan.Multiline = false;
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.NormalImageTint = Color.White;
            txtTaiKhoan.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txtTaiKhoan.Padding = new Padding(15, 14, 15, 0);
            txtTaiKhoan.PasswordChar = false;
            txtTaiKhoan.PlaceholderColor = SystemColors.WindowText;
            txtTaiKhoan.PlaceholderText = "";
            txtTaiKhoan.Rounding = new Padding(8);
            txtTaiKhoan.Size = new Size(310, 42);
            txtTaiKhoan.TabIndex = 2;
            txtTaiKhoan.TextOffset = new Size(0, 0);
            txtTaiKhoan.UnderlinedStyle = true;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Calibri", 14.25F, FontStyle.Bold);
            guna2HtmlLabel2.Location = new Point(29, 144);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(78, 25);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "Mật khẩu";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Calibri", 14.25F, FontStyle.Bold);
            guna2HtmlLabel1.Location = new Point(29, 39);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(159, 25);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Emai hoặc tài khoản";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(881, 483);
            Controls.Add(cuiGroupBox1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "frmLogin";
            Text = "Login";
            FormClosing += Login_FormClosing;
            cuiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CuoreUI.Controls.cuiGroupBox cuiGroupBox1;
        private PictureBox pictureBox1;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private CuoreUI.Controls.cuiButton cuiButton1;
        private CuoreUI.Controls.cuiTextBox txtMatKhau;
        private CuoreUI.Controls.cuiTextBox txtTaiKhoan;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Label label1;
    }
}
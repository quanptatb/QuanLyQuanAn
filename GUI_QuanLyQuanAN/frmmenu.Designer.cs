namespace GUI_QuanLyQuanAN
{
    partial class frmmenu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmenu));
            groupBox1 = new GroupBox();
            btnTimKiem = new CuoreUI.Controls.cuiButton();
            dgvMonAn = new Sunny.UI.UIDataGridView();
            txttimkiem = new CuoreUI.Controls.cuiTextBox();
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            btnXoaMon = new CuoreUI.Controls.cuiButton();
            btnThemMon = new CuoreUI.Controls.cuiButton();
            cboLoaiMon = new Sunny.UI.UIComboBox();
            guna2HtmlLabel5 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            btnthemanh = new CuoreUI.Controls.cuiButton();
            btnLuu = new CuoreUI.Controls.cuiButton();
            btnBoQua = new CuoreUI.Controls.cuiButton();
            txtthoigiannau = new CuoreUI.Controls.cuiTextBox();
            txtgiamon = new CuoreUI.Controls.cuiTextBox();
            txttenmon = new CuoreUI.Controls.cuiTextBox();
            txtmamon = new CuoreUI.Controls.cuiTextBox();
            guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            anhmonan = new PictureBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).BeginInit();
            cuiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)anhmonan).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(btnTimKiem);
            groupBox1.Controls.Add(dgvMonAn);
            groupBox1.Controls.Add(txttimkiem);
            groupBox1.Controls.Add(cuiPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1005, 681);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(224, 224, 224);
            btnTimKiem.CheckButton = false;
            btnTimKiem.Checked = false;
            btnTimKiem.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnTimKiem.CheckedForeColor = Color.White;
            btnTimKiem.CheckedImageTint = Color.White;
            btnTimKiem.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnTimKiem.Content = "Tìm kiếm";
            btnTimKiem.DialogResult = DialogResult.None;
            btnTimKiem.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.HoverBackground = Color.Lime;
            btnTimKiem.HoverForeColor = Color.White;
            btnTimKiem.HoverImageTint = Color.White;
            btnTimKiem.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnTimKiem.Image = null;
            btnTimKiem.ImageAutoCenter = true;
            btnTimKiem.ImageExpand = new Point(0, 0);
            btnTimKiem.ImageOffset = new Point(0, 0);
            btnTimKiem.Location = new Point(459, 22);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.NormalBackground = Color.SteelBlue;
            btnTimKiem.NormalForeColor = Color.White;
            btnTimKiem.NormalImageTint = Color.White;
            btnTimKiem.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnTimKiem.OutlineThickness = 1F;
            btnTimKiem.PressedBackground = Color.WhiteSmoke;
            btnTimKiem.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnTimKiem.PressedImageTint = Color.White;
            btnTimKiem.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnTimKiem.Rounding = new Padding(8);
            btnTimKiem.Size = new Size(105, 35);
            btnTimKiem.TabIndex = 16;
            btnTimKiem.TextAlignment = StringAlignment.Center;
            btnTimKiem.TextOffset = new Point(0, 0);
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvMonAn
            // 
            dgvMonAn.AllowUserToAddRows = false;
            dgvMonAn.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvMonAn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMonAn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMonAn.BackgroundColor = Color.White;
            dgvMonAn.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMonAn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMonAn.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvMonAn.DefaultCellStyle = dataGridViewCellStyle3;
            dgvMonAn.EnableHeadersVisualStyles = false;
            dgvMonAn.Font = new Font("Microsoft Sans Serif", 12F);
            dgvMonAn.GridColor = Color.FromArgb(80, 160, 255);
            dgvMonAn.Location = new Point(7, 77);
            dgvMonAn.Name = "dgvMonAn";
            dgvMonAn.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvMonAn.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvMonAn.RowHeadersWidth = 51;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgvMonAn.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvMonAn.SelectedIndex = -1;
            dgvMonAn.Size = new Size(568, 598);
            dgvMonAn.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvMonAn.TabIndex = 4;
            dgvMonAn.CellClick += dgvMonAn_CellClick;
            // 
            // txttimkiem
            // 
            txttimkiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txttimkiem.BackgroundColor = Color.White;
            txttimkiem.Content = "";
            txttimkiem.FocusBackgroundColor = Color.White;
            txttimkiem.FocusImageTint = Color.White;
            txttimkiem.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txttimkiem.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txttimkiem.ForeColor = Color.Black;
            txttimkiem.Image = (Image)resources.GetObject("txttimkiem.Image");
            txttimkiem.ImageExpand = new Point(0, 0);
            txttimkiem.ImageOffset = new Point(0, 0);
            txttimkiem.Location = new Point(7, 21);
            txttimkiem.Margin = new Padding(4);
            txttimkiem.Multiline = false;
            txttimkiem.Name = "txttimkiem";
            txttimkiem.NormalImageTint = Color.White;
            txttimkiem.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txttimkiem.Padding = new Padding(18, 9, 18, 0);
            txttimkiem.PasswordChar = false;
            txttimkiem.PlaceholderColor = SystemColors.WindowText;
            txttimkiem.PlaceholderText = "";
            txttimkiem.Rounding = new Padding(8);
            txttimkiem.Size = new Size(445, 36);
            txttimkiem.TabIndex = 1;
            txttimkiem.Tag = "";
            txttimkiem.TextOffset = new Size(0, 0);
            txttimkiem.UnderlinedStyle = true;
            // 
            // cuiPanel1
            // 
            cuiPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            cuiPanel1.Controls.Add(btnXoaMon);
            cuiPanel1.Controls.Add(btnThemMon);
            cuiPanel1.Controls.Add(cboLoaiMon);
            cuiPanel1.Controls.Add(guna2HtmlLabel5);
            cuiPanel1.Controls.Add(btnthemanh);
            cuiPanel1.Controls.Add(btnLuu);
            cuiPanel1.Controls.Add(btnBoQua);
            cuiPanel1.Controls.Add(txtthoigiannau);
            cuiPanel1.Controls.Add(txtgiamon);
            cuiPanel1.Controls.Add(txttenmon);
            cuiPanel1.Controls.Add(txtmamon);
            cuiPanel1.Controls.Add(guna2HtmlLabel4);
            cuiPanel1.Controls.Add(guna2HtmlLabel3);
            cuiPanel1.Controls.Add(guna2HtmlLabel2);
            cuiPanel1.Controls.Add(guna2HtmlLabel1);
            cuiPanel1.Controls.Add(anhmonan);
            cuiPanel1.Location = new Point(581, 21);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.PanelColor = Color.FromArgb(224, 224, 224);
            cuiPanel1.PanelOutlineColor = Color.White;
            cuiPanel1.Rounding = new Padding(8);
            cuiPanel1.Size = new Size(418, 654);
            cuiPanel1.TabIndex = 0;
            cuiPanel1.Paint += cuiPanel1_Paint;
            // 
            // btnXoaMon
            // 
            btnXoaMon.BackColor = Color.FromArgb(224, 224, 224);
            btnXoaMon.CheckButton = false;
            btnXoaMon.Checked = false;
            btnXoaMon.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnXoaMon.CheckedForeColor = Color.White;
            btnXoaMon.CheckedImageTint = Color.White;
            btnXoaMon.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnXoaMon.Content = "Xoá";
            btnXoaMon.DialogResult = DialogResult.None;
            btnXoaMon.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnXoaMon.ForeColor = Color.White;
            btnXoaMon.HoverBackground = Color.Lime;
            btnXoaMon.HoverForeColor = Color.White;
            btnXoaMon.HoverImageTint = Color.White;
            btnXoaMon.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnXoaMon.Image = (Image)resources.GetObject("btnXoaMon.Image");
            btnXoaMon.ImageAutoCenter = true;
            btnXoaMon.ImageExpand = new Point(0, 0);
            btnXoaMon.ImageOffset = new Point(0, 0);
            btnXoaMon.Location = new Point(219, 538);
            btnXoaMon.Name = "btnXoaMon";
            btnXoaMon.NormalBackground = Color.SteelBlue;
            btnXoaMon.NormalForeColor = Color.White;
            btnXoaMon.NormalImageTint = Color.White;
            btnXoaMon.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnXoaMon.OutlineThickness = 1F;
            btnXoaMon.PressedBackground = Color.WhiteSmoke;
            btnXoaMon.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnXoaMon.PressedImageTint = Color.White;
            btnXoaMon.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnXoaMon.Rounding = new Padding(8);
            btnXoaMon.Size = new Size(178, 45);
            btnXoaMon.TabIndex = 15;
            btnXoaMon.TextAlignment = StringAlignment.Center;
            btnXoaMon.TextOffset = new Point(0, 0);
            btnXoaMon.Click += btnXoaMon_Click;
            // 
            // btnThemMon
            // 
            btnThemMon.BackColor = Color.FromArgb(224, 224, 224);
            btnThemMon.CheckButton = false;
            btnThemMon.Checked = false;
            btnThemMon.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnThemMon.CheckedForeColor = Color.White;
            btnThemMon.CheckedImageTint = Color.White;
            btnThemMon.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnThemMon.Content = "Thêm";
            btnThemMon.DialogResult = DialogResult.None;
            btnThemMon.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnThemMon.ForeColor = Color.White;
            btnThemMon.HoverBackground = Color.Lime;
            btnThemMon.HoverForeColor = Color.White;
            btnThemMon.HoverImageTint = Color.White;
            btnThemMon.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnThemMon.Image = (Image)resources.GetObject("btnThemMon.Image");
            btnThemMon.ImageAutoCenter = true;
            btnThemMon.ImageExpand = new Point(0, 0);
            btnThemMon.ImageOffset = new Point(0, 0);
            btnThemMon.Location = new Point(26, 538);
            btnThemMon.Name = "btnThemMon";
            btnThemMon.NormalBackground = Color.SteelBlue;
            btnThemMon.NormalForeColor = Color.White;
            btnThemMon.NormalImageTint = Color.White;
            btnThemMon.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnThemMon.OutlineThickness = 1F;
            btnThemMon.PressedBackground = Color.WhiteSmoke;
            btnThemMon.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnThemMon.PressedImageTint = Color.White;
            btnThemMon.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnThemMon.Rounding = new Padding(8);
            btnThemMon.Size = new Size(178, 45);
            btnThemMon.TabIndex = 14;
            btnThemMon.TextAlignment = StringAlignment.Center;
            btnThemMon.TextOffset = new Point(0, 0);
            btnThemMon.Click += btnThemMon_Click;
            // 
            // cboLoaiMon
            // 
            cboLoaiMon.DataSource = null;
            cboLoaiMon.FillColor = Color.White;
            cboLoaiMon.Font = new Font("Microsoft Sans Serif", 12F);
            cboLoaiMon.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboLoaiMon.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboLoaiMon.Location = new Point(26, 483);
            cboLoaiMon.Margin = new Padding(4, 5, 4, 5);
            cboLoaiMon.MinimumSize = new Size(63, 0);
            cboLoaiMon.Name = "cboLoaiMon";
            cboLoaiMon.Padding = new Padding(0, 0, 30, 2);
            cboLoaiMon.Radius = 10;
            cboLoaiMon.Size = new Size(371, 36);
            cboLoaiMon.SymbolSize = 24;
            cboLoaiMon.TabIndex = 13;
            cboLoaiMon.Text = "Chọn loại món";
            cboLoaiMon.TextAlignment = ContentAlignment.MiddleLeft;
            cboLoaiMon.Watermark = "";
            // 
            // guna2HtmlLabel5
            // 
            guna2HtmlLabel5.BackColor = Color.Transparent;
            guna2HtmlLabel5.Font = new Font("Calibri", 12F, FontStyle.Italic);
            guna2HtmlLabel5.Location = new Point(26, 449);
            guna2HtmlLabel5.Name = "guna2HtmlLabel5";
            guna2HtmlLabel5.Size = new Size(77, 26);
            guna2HtmlLabel5.TabIndex = 12;
            guna2HtmlLabel5.Text = "Loại món";
            guna2HtmlLabel5.Click += guna2HtmlLabel5_Click;
            // 
            // btnthemanh
            // 
            btnthemanh.BackColor = Color.FromArgb(224, 224, 224);
            btnthemanh.CheckButton = false;
            btnthemanh.Checked = false;
            btnthemanh.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnthemanh.CheckedForeColor = Color.White;
            btnthemanh.CheckedImageTint = Color.White;
            btnthemanh.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnthemanh.Content = "Thêm ảnh";
            btnthemanh.DialogResult = DialogResult.None;
            btnthemanh.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnthemanh.ForeColor = Color.White;
            btnthemanh.HoverBackground = Color.Lime;
            btnthemanh.HoverForeColor = Color.White;
            btnthemanh.HoverImageTint = Color.White;
            btnthemanh.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnthemanh.Image = (Image)resources.GetObject("btnthemanh.Image");
            btnthemanh.ImageAutoCenter = true;
            btnthemanh.ImageExpand = new Point(0, 0);
            btnthemanh.ImageOffset = new Point(0, 0);
            btnthemanh.Location = new Point(128, 215);
            btnthemanh.Name = "btnthemanh";
            btnthemanh.NormalBackground = Color.SteelBlue;
            btnthemanh.NormalForeColor = Color.White;
            btnthemanh.NormalImageTint = Color.White;
            btnthemanh.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnthemanh.OutlineThickness = 1F;
            btnthemanh.PressedBackground = Color.WhiteSmoke;
            btnthemanh.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnthemanh.PressedImageTint = Color.White;
            btnthemanh.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnthemanh.Rounding = new Padding(8);
            btnthemanh.Size = new Size(153, 45);
            btnthemanh.TabIndex = 11;
            btnthemanh.TextAlignment = StringAlignment.Center;
            btnthemanh.TextOffset = new Point(0, 0);
            btnthemanh.Click += btnthemanh_Click;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(224, 224, 224);
            btnLuu.CheckButton = false;
            btnLuu.Checked = false;
            btnLuu.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnLuu.CheckedForeColor = Color.White;
            btnLuu.CheckedImageTint = Color.White;
            btnLuu.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnLuu.Content = "Lưu";
            btnLuu.DialogResult = DialogResult.None;
            btnLuu.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.HoverBackground = Color.Lime;
            btnLuu.HoverForeColor = Color.White;
            btnLuu.HoverImageTint = Color.White;
            btnLuu.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnLuu.Image = (Image)resources.GetObject("btnLuu.Image");
            btnLuu.ImageAutoCenter = true;
            btnLuu.ImageExpand = new Point(0, 0);
            btnLuu.ImageOffset = new Point(0, 0);
            btnLuu.Location = new Point(219, 589);
            btnLuu.Name = "btnLuu";
            btnLuu.NormalBackground = Color.SteelBlue;
            btnLuu.NormalForeColor = Color.White;
            btnLuu.NormalImageTint = Color.White;
            btnLuu.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnLuu.OutlineThickness = 1F;
            btnLuu.PressedBackground = Color.WhiteSmoke;
            btnLuu.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnLuu.PressedImageTint = Color.White;
            btnLuu.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnLuu.Rounding = new Padding(8);
            btnLuu.Size = new Size(178, 45);
            btnLuu.TabIndex = 10;
            btnLuu.TextAlignment = StringAlignment.Center;
            btnLuu.TextOffset = new Point(0, 0);
            btnLuu.Click += btnLuu_Click;
            // 
            // btnBoQua
            // 
            btnBoQua.BackColor = Color.FromArgb(224, 224, 224);
            btnBoQua.CheckButton = false;
            btnBoQua.Checked = false;
            btnBoQua.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnBoQua.CheckedForeColor = Color.White;
            btnBoQua.CheckedImageTint = Color.White;
            btnBoQua.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnBoQua.Content = "Huỷ bỏ";
            btnBoQua.DialogResult = DialogResult.None;
            btnBoQua.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold);
            btnBoQua.ForeColor = Color.White;
            btnBoQua.HoverBackground = Color.Lime;
            btnBoQua.HoverForeColor = Color.White;
            btnBoQua.HoverImageTint = Color.White;
            btnBoQua.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnBoQua.Image = (Image)resources.GetObject("btnBoQua.Image");
            btnBoQua.ImageAutoCenter = true;
            btnBoQua.ImageExpand = new Point(0, 0);
            btnBoQua.ImageOffset = new Point(0, 0);
            btnBoQua.Location = new Point(26, 589);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.NormalBackground = Color.SteelBlue;
            btnBoQua.NormalForeColor = Color.White;
            btnBoQua.NormalImageTint = Color.White;
            btnBoQua.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnBoQua.OutlineThickness = 1F;
            btnBoQua.PressedBackground = Color.WhiteSmoke;
            btnBoQua.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnBoQua.PressedImageTint = Color.White;
            btnBoQua.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnBoQua.Rounding = new Padding(8);
            btnBoQua.Size = new Size(178, 45);
            btnBoQua.TabIndex = 9;
            btnBoQua.TextAlignment = StringAlignment.Center;
            btnBoQua.TextOffset = new Point(0, 0);
            btnBoQua.Click += btnBoQua_Click;
            // 
            // txtthoigiannau
            // 
            txtthoigiannau.BackColor = Color.FromArgb(224, 224, 224);
            txtthoigiannau.BackgroundColor = Color.White;
            txtthoigiannau.Content = "";
            txtthoigiannau.FocusBackgroundColor = Color.White;
            txtthoigiannau.FocusImageTint = Color.White;
            txtthoigiannau.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtthoigiannau.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtthoigiannau.ForeColor = Color.Gray;
            txtthoigiannau.Image = null;
            txtthoigiannau.ImageExpand = new Point(0, 0);
            txtthoigiannau.ImageOffset = new Point(0, 0);
            txtthoigiannau.Location = new Point(190, 397);
            txtthoigiannau.Margin = new Padding(4);
            txtthoigiannau.Multiline = false;
            txtthoigiannau.Name = "txtthoigiannau";
            txtthoigiannau.NormalImageTint = Color.White;
            txtthoigiannau.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txtthoigiannau.Padding = new Padding(18, 8, 18, 0);
            txtthoigiannau.PasswordChar = false;
            txtthoigiannau.PlaceholderColor = SystemColors.WindowText;
            txtthoigiannau.PlaceholderText = "";
            txtthoigiannau.Rounding = new Padding(8);
            txtthoigiannau.Size = new Size(207, 35);
            txtthoigiannau.TabIndex = 8;
            txtthoigiannau.TextOffset = new Size(0, 0);
            txtthoigiannau.UnderlinedStyle = true;
            // 
            // txtgiamon
            // 
            txtgiamon.BackColor = Color.FromArgb(224, 224, 224);
            txtgiamon.BackgroundColor = Color.White;
            txtgiamon.Content = "";
            txtgiamon.FocusBackgroundColor = Color.White;
            txtgiamon.FocusImageTint = Color.White;
            txtgiamon.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtgiamon.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtgiamon.ForeColor = Color.Gray;
            txtgiamon.Image = null;
            txtgiamon.ImageExpand = new Point(0, 0);
            txtgiamon.ImageOffset = new Point(0, 0);
            txtgiamon.Location = new Point(26, 397);
            txtgiamon.Margin = new Padding(4);
            txtgiamon.Multiline = false;
            txtgiamon.Name = "txtgiamon";
            txtgiamon.NormalImageTint = Color.White;
            txtgiamon.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txtgiamon.Padding = new Padding(18, 8, 18, 0);
            txtgiamon.PasswordChar = false;
            txtgiamon.PlaceholderColor = SystemColors.WindowText;
            txtgiamon.PlaceholderText = "";
            txtgiamon.Rounding = new Padding(8);
            txtgiamon.Size = new Size(156, 35);
            txtgiamon.TabIndex = 7;
            txtgiamon.TextOffset = new Size(0, 0);
            txtgiamon.UnderlinedStyle = true;
            // 
            // txttenmon
            // 
            txttenmon.BackColor = Color.FromArgb(224, 224, 224);
            txttenmon.BackgroundColor = Color.White;
            txttenmon.Content = "";
            txttenmon.FocusBackgroundColor = Color.White;
            txttenmon.FocusImageTint = Color.White;
            txttenmon.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txttenmon.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txttenmon.ForeColor = Color.Gray;
            txttenmon.Image = null;
            txttenmon.ImageExpand = new Point(0, 0);
            txttenmon.ImageOffset = new Point(0, 0);
            txttenmon.Location = new Point(190, 303);
            txttenmon.Margin = new Padding(4);
            txttenmon.Multiline = false;
            txttenmon.Name = "txttenmon";
            txttenmon.NormalImageTint = Color.White;
            txttenmon.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txttenmon.Padding = new Padding(18, 8, 18, 0);
            txttenmon.PasswordChar = false;
            txttenmon.PlaceholderColor = SystemColors.WindowText;
            txttenmon.PlaceholderText = "";
            txttenmon.Rounding = new Padding(8);
            txttenmon.Size = new Size(207, 35);
            txttenmon.TabIndex = 6;
            txttenmon.TextOffset = new Size(0, 0);
            txttenmon.UnderlinedStyle = true;
            // 
            // txtmamon
            // 
            txtmamon.BackColor = Color.FromArgb(224, 224, 224);
            txtmamon.BackgroundColor = Color.White;
            txtmamon.Content = "";
            txtmamon.FocusBackgroundColor = Color.White;
            txtmamon.FocusImageTint = Color.White;
            txtmamon.FocusOutlineColor = Color.FromArgb(255, 106, 0);
            txtmamon.Font = new Font("Microsoft Sans Serif", 9.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtmamon.ForeColor = Color.Gray;
            txtmamon.Image = null;
            txtmamon.ImageExpand = new Point(0, 0);
            txtmamon.ImageOffset = new Point(0, 0);
            txtmamon.Location = new Point(26, 303);
            txtmamon.Margin = new Padding(4);
            txtmamon.Multiline = false;
            txtmamon.Name = "txtmamon";
            txtmamon.NormalImageTint = Color.White;
            txtmamon.OutlineColor = Color.FromArgb(128, 128, 128, 128);
            txtmamon.Padding = new Padding(18, 8, 18, 0);
            txtmamon.PasswordChar = false;
            txtmamon.PlaceholderColor = SystemColors.WindowText;
            txtmamon.PlaceholderText = "";
            txtmamon.Rounding = new Padding(8);
            txtmamon.Size = new Size(156, 35);
            txtmamon.TabIndex = 5;
            txtmamon.TextOffset = new Size(0, 0);
            txtmamon.UnderlinedStyle = true;
            // 
            // guna2HtmlLabel4
            // 
            guna2HtmlLabel4.BackColor = Color.Transparent;
            guna2HtmlLabel4.Font = new Font("Calibri", 12F, FontStyle.Italic);
            guna2HtmlLabel4.Location = new Point(190, 369);
            guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            guna2HtmlLabel4.Size = new Size(114, 26);
            guna2HtmlLabel4.TabIndex = 4;
            guna2HtmlLabel4.Text = "Thời gian nấu";
            // 
            // guna2HtmlLabel3
            // 
            guna2HtmlLabel3.BackColor = Color.Transparent;
            guna2HtmlLabel3.Font = new Font("Calibri", 12F, FontStyle.Italic);
            guna2HtmlLabel3.Location = new Point(26, 369);
            guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            guna2HtmlLabel3.Size = new Size(31, 26);
            guna2HtmlLabel3.TabIndex = 3;
            guna2HtmlLabel3.Text = "Giá";
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Calibri", 12F, FontStyle.Italic);
            guna2HtmlLabel2.Location = new Point(190, 275);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(74, 26);
            guna2HtmlLabel2.TabIndex = 2;
            guna2HtmlLabel2.Text = "Tên món";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Calibri", 12F, FontStyle.Italic);
            guna2HtmlLabel1.Location = new Point(26, 275);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(71, 26);
            guna2HtmlLabel1.TabIndex = 1;
            guna2HtmlLabel1.Text = "Mã món";
            // 
            // anhmonan
            // 
            anhmonan.Location = new Point(26, 10);
            anhmonan.Name = "anhmonan";
            anhmonan.Size = new Size(371, 199);
            anhmonan.SizeMode = PictureBoxSizeMode.StretchImage;
            anhmonan.TabIndex = 0;
            anhmonan.TabStop = false;
            // 
            // frmmenu
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1043, 705);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "frmmenu";
            Text = "Món ăn";
            WindowState = FormWindowState.Maximized;
            Load += frmmenu_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMonAn).EndInit();
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)anhmonan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private Sunny.UI.UIDataGridView dgvMonAn;
        private CuoreUI.Controls.cuiTextBox txttimkiem;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private PictureBox anhmonan;
        private CuoreUI.Controls.cuiTextBox txtthoigiannau;
        private CuoreUI.Controls.cuiTextBox txtgiamon;
        private CuoreUI.Controls.cuiTextBox txttenmon;
        private CuoreUI.Controls.cuiTextBox txtmamon;
        private CuoreUI.Controls.cuiButton btnLuu;
        private CuoreUI.Controls.cuiButton btnBoQua;
        private CuoreUI.Controls.cuiButton btnthemanh;
        private Sunny.UI.UIComboBox cboLoaiMon;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel5;
        private CuoreUI.Controls.cuiButton btnXoaMon;
        private CuoreUI.Controls.cuiButton btnThemMon;
        private CuoreUI.Controls.cuiButton btnTimKiem;
    }
}
namespace GUI_QuanLyQuanAN
{
    partial class frmthongkedoanhthu
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmthongkedoanhthu));
            groupBox1 = new GroupBox();
            cuiChartLine1 = new CuoreUI.Controls.Charts.cuiChartLine();
            cuiPanel1 = new CuoreUI.Controls.cuiPanel();
            dtpketthuc = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtpbatdau = new Guna.UI2.WinForms.Guna2DateTimePicker();
            btnxacnhan = new CuoreUI.Controls.cuiButton();
            guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            groupBox1.SuspendLayout();
            cuiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor = Color.White;
            groupBox1.Controls.Add(cuiChartLine1);
            groupBox1.Controls.Add(cuiPanel1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1004, 681);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // cuiChartLine1
            // 
            cuiChartLine1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cuiChartLine1.AutoMaxValue = false;
            cuiChartLine1.AxisColor = Color.Gray;
            cuiChartLine1.ChartLineColor = Color.FromArgb(255, 106, 0);
            cuiChartLine1.ChartPadding = 40;
            cuiChartLine1.DataPoints = new float[]
    {
    100F,
    90F,
    80F,
    75F,
    70F,
    65F,
    60F
    };
            cuiChartLine1.DayColor = Color.DarkGray;
            cuiChartLine1.Font = new Font("Microsoft YaHei UI", 8.25F);
            cuiChartLine1.GradientBackground = true;
            cuiChartLine1.Location = new Point(6, 105);
            cuiChartLine1.Margin = new Padding(4, 3, 4, 3);
            cuiChartLine1.MaxValue = 100F;
            cuiChartLine1.Name = "cuiChartLine1";
            cuiChartLine1.PointColor = Color.FromArgb(255, 106, 0);
            cuiChartLine1.ShortDates = true;
            cuiChartLine1.ShowLines = true;
            cuiChartLine1.Size = new Size(991, 570);
            cuiChartLine1.TabIndex = 1;
            cuiChartLine1.UseBezier = false;
            cuiChartLine1.UsePercent = true;
            // 
            // cuiPanel1
            // 
            cuiPanel1.Controls.Add(dtpketthuc);
            cuiPanel1.Controls.Add(dtpbatdau);
            cuiPanel1.Controls.Add(btnxacnhan);
            cuiPanel1.Controls.Add(guna2HtmlLabel2);
            cuiPanel1.Controls.Add(guna2HtmlLabel1);
            cuiPanel1.Location = new Point(6, 18);
            cuiPanel1.Name = "cuiPanel1";
            cuiPanel1.OutlineThickness = 1F;
            cuiPanel1.PanelColor = Color.WhiteSmoke;
            cuiPanel1.PanelOutlineColor = Color.White;
            cuiPanel1.Rounding = new Padding(8);
            cuiPanel1.Size = new Size(992, 67);
            cuiPanel1.TabIndex = 0;
            // 
            // dtpketthuc
            // 
            dtpketthuc.Checked = true;
            dtpketthuc.CustomizableEdges = customizableEdges1;
            dtpketthuc.FillColor = Color.White;
            dtpketthuc.Font = new Font("Segoe UI", 9F);
            dtpketthuc.Format = DateTimePickerFormat.Short;
            dtpketthuc.Location = new Point(558, 21);
            dtpketthuc.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpketthuc.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpketthuc.Name = "dtpketthuc";
            dtpketthuc.ShadowDecoration.CustomizableEdges = customizableEdges2;
            dtpketthuc.Size = new Size(200, 36);
            dtpketthuc.TabIndex = 4;
            dtpketthuc.Value = new DateTime(2025, 8, 1, 14, 34, 36, 9);
            // 
            // dtpbatdau
            // 
            dtpbatdau.Checked = true;
            dtpbatdau.CustomizableEdges = customizableEdges3;
            dtpbatdau.FillColor = Color.White;
            dtpbatdau.Font = new Font("Segoe UI", 9F);
            dtpbatdau.Format = DateTimePickerFormat.Short;
            dtpbatdau.Location = new Point(267, 21);
            dtpbatdau.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtpbatdau.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtpbatdau.Name = "dtpbatdau";
            dtpbatdau.ShadowDecoration.CustomizableEdges = customizableEdges4;
            dtpbatdau.Size = new Size(200, 36);
            dtpbatdau.TabIndex = 3;
            dtpbatdau.Value = new DateTime(2025, 8, 1, 14, 34, 40, 237);
            // 
            // btnxacnhan
            // 
            btnxacnhan.CheckButton = false;
            btnxacnhan.Checked = false;
            btnxacnhan.CheckedBackground = Color.FromArgb(255, 106, 0);
            btnxacnhan.CheckedForeColor = Color.White;
            btnxacnhan.CheckedImageTint = Color.White;
            btnxacnhan.CheckedOutline = Color.FromArgb(255, 106, 0);
            btnxacnhan.Content = "Xác nhận";
            btnxacnhan.DialogResult = DialogResult.None;
            btnxacnhan.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnxacnhan.ForeColor = Color.White;
            btnxacnhan.HoverBackground = Color.Lime;
            btnxacnhan.HoverForeColor = Color.White;
            btnxacnhan.HoverImageTint = Color.White;
            btnxacnhan.HoverOutline = Color.FromArgb(32, 128, 128, 128);
            btnxacnhan.Image = (Image)resources.GetObject("btnxacnhan.Image");
            btnxacnhan.ImageAutoCenter = true;
            btnxacnhan.ImageExpand = new Point(0, 0);
            btnxacnhan.ImageOffset = new Point(0, 0);
            btnxacnhan.Location = new Point(821, 13);
            btnxacnhan.Name = "btnxacnhan";
            btnxacnhan.NormalBackground = Color.SteelBlue;
            btnxacnhan.NormalForeColor = Color.White;
            btnxacnhan.NormalImageTint = Color.White;
            btnxacnhan.NormalOutline = Color.FromArgb(64, 128, 128, 128);
            btnxacnhan.OutlineThickness = 1F;
            btnxacnhan.PressedBackground = Color.WhiteSmoke;
            btnxacnhan.PressedForeColor = Color.FromArgb(32, 32, 32);
            btnxacnhan.PressedImageTint = Color.White;
            btnxacnhan.PressedOutline = Color.FromArgb(64, 128, 128, 128);
            btnxacnhan.Rounding = new Padding(8);
            btnxacnhan.Size = new Size(153, 45);
            btnxacnhan.TabIndex = 2;
            btnxacnhan.TextAlignment = StringAlignment.Center;
            btnxacnhan.TextOffset = new Point(0, 0);
            btnxacnhan.Click += btnxacnhan_Click;
            // 
            // guna2HtmlLabel2
            // 
            guna2HtmlLabel2.BackColor = Color.Transparent;
            guna2HtmlLabel2.Font = new Font("Calibri", 15.75F, FontStyle.Italic);
            guna2HtmlLabel2.Location = new Point(510, 22);
            guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            guna2HtmlLabel2.Size = new Size(42, 34);
            guna2HtmlLabel2.TabIndex = 1;
            guna2HtmlLabel2.Text = "đến ";
            // 
            // guna2HtmlLabel1
            // 
            guna2HtmlLabel1.BackColor = Color.Transparent;
            guna2HtmlLabel1.Font = new Font("Calibri", 15.75F, FontStyle.Italic);
            guna2HtmlLabel1.Location = new Point(3, 22);
            guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            guna2HtmlLabel1.Size = new Size(295, 34);
            guna2HtmlLabel1.TabIndex = 0;
            guna2HtmlLabel1.Text = "Bảng thống kê doanh thu từ ";
            // 
            // frmthongkedoanhthu
            // 
            AutoScaleDimensions = new SizeF(13F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SteelBlue;
            ClientSize = new Size(1028, 705);
            Controls.Add(groupBox1);
            Font = new Font("Segoe UI", 14F);
            Margin = new Padding(5);
            Name = "frmthongkedoanhthu";
            Text = "frmthongkedoanhthu";
            WindowState = FormWindowState.Maximized;
            Load += frmthongkedoanhthu_Load;
            groupBox1.ResumeLayout(false);
            cuiPanel1.ResumeLayout(false);
            cuiPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private CuoreUI.Controls.cuiPanel cuiPanel1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpbatdau;
        private CuoreUI.Controls.cuiButton btnxacnhan;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private CuoreUI.Controls.Charts.cuiChartLine cuiChartLine1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpketthuc;
    }
}
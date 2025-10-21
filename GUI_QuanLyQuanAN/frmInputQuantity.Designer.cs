namespace GUI_QLQA
{
    partial class frmInputQuantity
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            numSoLuong = new NumericUpDown();
            btnOK = new Guna.UI2.WinForms.Guna2Button();
            btnCancel = new Guna.UI2.WinForms.Guna2Button();
            label2 = new Label();
            label3 = new Label();
            txtDonGia = new Guna.UI2.WinForms.Guna2TextBox();
            txtThanhTien = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(155, 30);
            label1.TabIndex = 0;
            label1.Text = "Nhập số lượng";
            // 
            // numSoLuong
            // 
            numSoLuong.Font = new Font("Segoe UI", 16F);
            numSoLuong.Location = new Point(182, 9);
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(120, 36);
            numSoLuong.TabIndex = 1;
            // 
            // btnOK
            // 
            btnOK.CustomizableEdges = customizableEdges1;
            btnOK.DisabledState.BorderColor = Color.DarkGray;
            btnOK.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOK.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnOK.ForeColor = Color.White;
            btnOK.Location = new Point(21, 70);
            btnOK.Name = "btnOK";
            btnOK.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnOK.Size = new Size(127, 40);
            btnOK.TabIndex = 2;
            btnOK.Text = "OK";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.CustomizableEdges = customizableEdges3;
            btnCancel.DisabledState.BorderColor = Color.DarkGray;
            btnCancel.DisabledState.CustomBorderColor = Color.DarkGray;
            btnCancel.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnCancel.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnCancel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(175, 70);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnCancel.Size = new Size(127, 40);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.Click += btnCancel_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(21, 128);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 4;
            label2.Text = "Đơn giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(182, 128);
            label3.Name = "label3";
            label3.Size = new Size(102, 25);
            label3.TabIndex = 5;
            label3.Text = "Thành tiền";
            // 
            // txtDonGia
            // 
            txtDonGia.CustomizableEdges = customizableEdges5;
            txtDonGia.DefaultText = "";
            txtDonGia.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDonGia.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDonGia.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDonGia.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDonGia.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDonGia.Font = new Font("Segoe UI", 9F);
            txtDonGia.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDonGia.Location = new Point(21, 156);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.PasswordChar = '\0';
            txtDonGia.PlaceholderText = "";
            txtDonGia.SelectedText = "";
            txtDonGia.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDonGia.Size = new Size(127, 36);
            txtDonGia.TabIndex = 6;
            // 
            // txtThanhTien
            // 
            txtThanhTien.CustomizableEdges = customizableEdges7;
            txtThanhTien.DefaultText = "";
            txtThanhTien.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtThanhTien.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtThanhTien.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtThanhTien.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtThanhTien.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtThanhTien.Font = new Font("Segoe UI", 9F);
            txtThanhTien.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtThanhTien.Location = new Point(175, 156);
            txtThanhTien.Name = "txtThanhTien";
            txtThanhTien.PasswordChar = '\0';
            txtThanhTien.PlaceholderText = "";
            txtThanhTien.SelectedText = "";
            txtThanhTien.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtThanhTien.Size = new Size(127, 36);
            txtThanhTien.TabIndex = 7;
            // 
            // frmInputQuantity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 232);
            Controls.Add(txtThanhTien);
            Controls.Add(txtDonGia);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(numSoLuong);
            Controls.Add(label1);
            Name = "frmInputQuantity";
            Text = "frmInputQuantity";
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private NumericUpDown numSoLuong;
        private Guna.UI2.WinForms.Guna2Button btnOK;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Label label2;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtDonGia;
        private Guna.UI2.WinForms.Guna2TextBox txtThanhTien;
    }
}
namespace QuanLyBanHang.Forms
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            label1 = new Label();
            txtTenDangNhap = new TextBox();
            label2 = new Label();
            txtMatKhau = new TextBox();
            label3 = new Label();
            btnDangNhap = new Button();
            btnHuy = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(315, 64);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên đăng nhâp:";
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.Location = new Point(315, 87);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.Size = new Size(308, 27);
            txtTenDangNhap.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label2.Location = new Point(369, 9);
            label2.Name = "label2";
            label2.Size = new Size(227, 46);
            label2.TabIndex = 2;
            label2.Text = "ĐĂNG NHẬP";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(315, 151);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(308, 27);
            txtMatKhau.TabIndex = 4;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(315, 128);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 3;
            label3.Text = "Mật khẩu:";
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new Point(315, 194);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(98, 40);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = true;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(525, 194);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(98, 40);
            btnHuy.TabIndex = 6;
            btnHuy.Text = "Hủy bỏ";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 225);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // frmDangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 259);
            Controls.Add(pictureBox1);
            Controls.Add(btnHuy);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtTenDangNhap);
            Controls.Add(label1);
            Name = "frmDangNhap";
            Text = "frmDangNhap";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnDangNhap;
        private Button btnHuy;
        public TextBox txtTenDangNhap;
        public TextBox txtMatKhau;
        private PictureBox pictureBox1;
    }
}
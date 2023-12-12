namespace Client.Views
{
    partial class DangKyForm
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
            this.btnDangKy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tvHoTen = new System.Windows.Forms.TextBox();
            this.lnkDangNhap = new System.Windows.Forms.LinkLabel();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tvDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.wDangKy = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(139, 110);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(75, 23);
            this.btnDangKy.TabIndex = 3;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ tên";
            // 
            // tvHoTen
            // 
            this.tvHoTen.Location = new System.Drawing.Point(93, 19);
            this.tvHoTen.Name = "tvHoTen";
            this.tvHoTen.Size = new System.Drawing.Size(167, 20);
            this.tvHoTen.TabIndex = 0;
            this.tvHoTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvHoTen_KeyDown);
            // 
            // lnkDangNhap
            // 
            this.lnkDangNhap.AutoSize = true;
            this.lnkDangNhap.Location = new System.Drawing.Point(107, 145);
            this.lnkDangNhap.Name = "lnkDangNhap";
            this.lnkDangNhap.Size = new System.Drawing.Size(139, 13);
            this.lnkDangNhap.TabIndex = 4;
            this.lnkDangNhap.TabStop = true;
            this.lnkDangNhap.Text = "Đăng nhập nếu đã đăng ký";
            this.lnkDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangNhap_LinkClicked);
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.Location = new System.Drawing.Point(93, 49);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(167, 20);
            this.dtNgaySinh.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Điện thoại";
            // 
            // tvDienThoai
            // 
            this.tvDienThoai.Location = new System.Drawing.Point(93, 79);
            this.tvDienThoai.Mask = "(999) 000-0000";
            this.tvDienThoai.Name = "tvDienThoai";
            this.tvDienThoai.Size = new System.Drawing.Size(167, 20);
            this.tvDienThoai.TabIndex = 2;
            this.tvDienThoai.Enter += new System.EventHandler(this.tvDienThoai_Enter);
            this.tvDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDienThoai_KeyDown);
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb.Location = new System.Drawing.Point(0, 186);
            this.pb.MarqueeAnimationSpeed = 1;
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(295, 3);
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb.TabIndex = 7;
            this.pb.Visible = false;
            // 
            // wDangKy
            // 
            this.wDangKy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wDangKy_DoWork);
            this.wDangKy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wDangKy_RunWorkerCompleted);
            // 
            // DangKyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 189);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.tvDienThoai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtNgaySinh);
            this.Controls.Add(this.lnkDangNhap);
            this.Controls.Add(this.tvHoTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDangKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangKyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DangKyForm_FormClosed);
            this.Load += new System.EventHandler(this.DangKyForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tvHoTen;
        private System.Windows.Forms.LinkLabel lnkDangNhap;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tvDienThoai;
        private System.Windows.Forms.ProgressBar pb;
        private System.ComponentModel.BackgroundWorker wDangKy;
    }
}
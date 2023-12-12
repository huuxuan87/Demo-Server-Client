namespace Client.Views
{
    partial class DangNhapForm
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
            this.lnk_DangKy = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.tvDienThoai = new System.Windows.Forms.MaskedTextBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.wDangNhap = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // lnk_DangKy
            // 
            this.lnk_DangKy.AutoSize = true;
            this.lnk_DangKy.Location = new System.Drawing.Point(85, 105);
            this.lnk_DangKy.Name = "lnk_DangKy";
            this.lnk_DangKy.Size = new System.Drawing.Size(66, 13);
            this.lnk_DangKy.TabIndex = 2;
            this.lnk_DangKy.TabStop = true;
            this.lnk_DangKy.Text = "Đăng ký mới";
            this.lnk_DangKy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_DangKy_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập số điện thoại";
            // 
            // tvDienThoai
            // 
            this.tvDienThoai.Location = new System.Drawing.Point(51, 37);
            this.tvDienThoai.Mask = "(999) 000-0000";
            this.tvDienThoai.Name = "tvDienThoai";
            this.tvDienThoai.Size = new System.Drawing.Size(134, 20);
            this.tvDienThoai.TabIndex = 0;
            this.tvDienThoai.Enter += new System.EventHandler(this.txtDienThoai_Enter);
            this.tvDienThoai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDienThoai_KeyDown);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Location = new System.Drawing.Point(81, 69);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(75, 23);
            this.btnDangNhap.TabIndex = 1;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pb.Location = new System.Drawing.Point(0, 150);
            this.pb.MarqueeAnimationSpeed = 1;
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(245, 3);
            this.pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pb.TabIndex = 3;
            this.pb.Visible = false;
            // 
            // wDangNhap
            // 
            this.wDangNhap.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wDangNhap_DoWork);
            this.wDangNhap.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wDangNhap_RunWorkerCompleted);
            // 
            // DangNhapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 153);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.tvDienThoai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lnk_DangKy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DangNhapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DangNhapForm_FormClosed);
            this.Load += new System.EventHandler(this.DangNhapForm_Load);
            this.Shown += new System.EventHandler(this.DangNhapForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnk_DangKy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox tvDienThoai;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.ProgressBar pb;
        private System.ComponentModel.BackgroundWorker wDangNhap;
    }
}
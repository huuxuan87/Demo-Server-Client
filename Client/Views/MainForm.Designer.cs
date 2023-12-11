namespace Client.Views
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "1"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "1", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "22/11/2023 - 23 gio"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "1"),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "✔", System.Drawing.SystemColors.WindowText, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
            this.tvDatSo = new System.Windows.Forms.MaskedTextBox();
            this.btnDatSo = new System.Windows.Forms.Button();
            this.grpDatSo = new System.Windows.Forms.GroupBox();
            this.lblClock = new System.Windows.Forms.Label();
            this.pbDatSo = new System.Windows.Forms.ProgressBar();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.pbThongTin = new System.Windows.Forms.ProgressBar();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDienThoai = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpSoDaDat = new System.Windows.Forms.GroupBox();
            this.pbSoDaDat = new System.Windows.Forms.ProgressBar();
            this.lvSoDaDat = new System.Windows.Forms.ListView();
            this.col0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSoDat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNgayGioKetQua = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKetQuaQuaySo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDaTrung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wDatSo = new System.ComponentModel.BackgroundWorker();
            this.wThongTin = new System.ComponentModel.BackgroundWorker();
            this.wSoDaDat = new System.ComponentModel.BackgroundWorker();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.wTimer = new System.ComponentModel.BackgroundWorker();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.pbThoiGian = new System.Windows.Forms.ProgressBar();
            this.grpDatSo.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpSoDaDat.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvDatSo
            // 
            this.tvDatSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvDatSo.Location = new System.Drawing.Point(26, 23);
            this.tvDatSo.Mask = "0";
            this.tvDatSo.Name = "tvDatSo";
            this.tvDatSo.Size = new System.Drawing.Size(75, 62);
            this.tvDatSo.TabIndex = 0;
            this.tvDatSo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tvDatSo.ValidatingType = typeof(int);
            this.tvDatSo.Click += new System.EventHandler(this.tvDatSo_Click);
            this.tvDatSo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvDatSo_KeyDown);
            // 
            // btnDatSo
            // 
            this.btnDatSo.Location = new System.Drawing.Point(106, 23);
            this.btnDatSo.Name = "btnDatSo";
            this.btnDatSo.Size = new System.Drawing.Size(75, 62);
            this.btnDatSo.TabIndex = 2;
            this.btnDatSo.Text = "Đặt số";
            this.btnDatSo.UseVisualStyleBackColor = true;
            this.btnDatSo.Click += new System.EventHandler(this.btnDatSo_Click);
            // 
            // grpDatSo
            // 
            this.grpDatSo.Controls.Add(this.pbDatSo);
            this.grpDatSo.Controls.Add(this.btnDatSo);
            this.grpDatSo.Controls.Add(this.tvDatSo);
            this.grpDatSo.Controls.Add(this.lblClock);
            this.grpDatSo.Controls.Add(this.pbThoiGian);
            this.grpDatSo.Location = new System.Drawing.Point(12, 12);
            this.grpDatSo.Name = "grpDatSo";
            this.grpDatSo.Size = new System.Drawing.Size(210, 128);
            this.grpDatSo.TabIndex = 6;
            this.grpDatSo.TabStop = false;
            this.grpDatSo.Text = "Đặt số";
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.Blue;
            this.lblClock.Location = new System.Drawing.Point(39, 101);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(129, 13);
            this.lblClock.TabIndex = 9;
            this.lblClock.Text = "22/11/2023 17:30:05";
            // 
            // pbDatSo
            // 
            this.pbDatSo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbDatSo.Location = new System.Drawing.Point(3, 122);
            this.pbDatSo.MarqueeAnimationSpeed = 1;
            this.pbDatSo.Name = "pbDatSo";
            this.pbDatSo.Size = new System.Drawing.Size(204, 3);
            this.pbDatSo.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbDatSo.TabIndex = 3;
            this.pbDatSo.Visible = false;
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.pbThongTin);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.label6);
            this.grpThongTin.Controls.Add(this.lblDienThoai);
            this.grpThongTin.Controls.Add(this.label4);
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.label1);
            this.grpThongTin.Controls.Add(this.btnLogout);
            this.grpThongTin.Location = new System.Drawing.Point(15, 159);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(207, 145);
            this.grpThongTin.TabIndex = 7;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin";
            // 
            // pbThongTin
            // 
            this.pbThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbThongTin.Location = new System.Drawing.Point(3, 139);
            this.pbThongTin.MarqueeAnimationSpeed = 1;
            this.pbThongTin.Name = "pbThongTin";
            this.pbThongTin.Size = new System.Drawing.Size(201, 3);
            this.pbThongTin.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbThongTin.TabIndex = 9;
            this.pbThongTin.Visible = false;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(66, 53);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(63, 13);
            this.lblNgaySinh.TabIndex = 13;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ngày sinh:";
            // 
            // lblDienThoai
            // 
            this.lblDienThoai.AutoSize = true;
            this.lblDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDienThoai.Location = new System.Drawing.Point(66, 77);
            this.lblDienThoai.Name = "lblDienThoai";
            this.lblDienThoai.Size = new System.Drawing.Size(65, 13);
            this.lblDienThoai.TabIndex = 11;
            this.lblDienThoai.Text = "Điện thoại";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Điện thoại:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(66, 29);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(45, 13);
            this.lblHoTen.TabIndex = 9;
            this.lblHoTen.Text = "Họ tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Họ tên:";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(47, 105);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(143, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Thoát đăng nhập lại";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // grpSoDaDat
            // 
            this.grpSoDaDat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSoDaDat.Controls.Add(this.pbSoDaDat);
            this.grpSoDaDat.Controls.Add(this.lvSoDaDat);
            this.grpSoDaDat.Location = new System.Drawing.Point(0, 10);
            this.grpSoDaDat.Name = "grpSoDaDat";
            this.grpSoDaDat.Size = new System.Drawing.Size(360, 295);
            this.grpSoDaDat.TabIndex = 8;
            this.grpSoDaDat.TabStop = false;
            this.grpSoDaDat.Text = "Số đã đặt";
            // 
            // pbSoDaDat
            // 
            this.pbSoDaDat.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbSoDaDat.Location = new System.Drawing.Point(3, 289);
            this.pbSoDaDat.MarqueeAnimationSpeed = 1;
            this.pbSoDaDat.Name = "pbSoDaDat";
            this.pbSoDaDat.Size = new System.Drawing.Size(354, 3);
            this.pbSoDaDat.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbSoDaDat.TabIndex = 10;
            this.pbSoDaDat.Visible = false;
            // 
            // lvSoDaDat
            // 
            this.lvSoDaDat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col0,
            this.colSoDat,
            this.colNgayGioKetQua,
            this.colKetQuaQuaySo,
            this.colDaTrung});
            this.lvSoDaDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSoDaDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSoDaDat.FullRowSelect = true;
            this.lvSoDaDat.GridLines = true;
            this.lvSoDaDat.HideSelection = false;
            this.lvSoDaDat.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem9});
            this.lvSoDaDat.Location = new System.Drawing.Point(3, 16);
            this.lvSoDaDat.Name = "lvSoDaDat";
            this.lvSoDaDat.Size = new System.Drawing.Size(354, 276);
            this.lvSoDaDat.TabIndex = 9;
            this.lvSoDaDat.UseCompatibleStateImageBehavior = false;
            this.lvSoDaDat.View = System.Windows.Forms.View.Details;
            // 
            // col0
            // 
            this.col0.Text = "";
            this.col0.Width = 0;
            // 
            // colSoDat
            // 
            this.colSoDat.Text = "Số đặt";
            this.colSoDat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colNgayGioKetQua
            // 
            this.colNgayGioKetQua.Text = "Ngày giờ ra kết quả";
            this.colNgayGioKetQua.Width = 120;
            // 
            // colKetQuaQuaySo
            // 
            this.colKetQuaQuaySo.Text = "Kết quả quay số";
            this.colKetQuaQuaySo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colKetQuaQuaySo.Width = 90;
            // 
            // colDaTrung
            // 
            this.colDaTrung.Text = "Thông báo";
            this.colDaTrung.Width = 80;
            // 
            // wDatSo
            // 
            this.wDatSo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wDatSo_DoWork);
            this.wDatSo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wDatSo_RunWorkerCompleted);
            // 
            // wThongTin
            // 
            this.wThongTin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wThongTin_DoWork);
            this.wThongTin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wThongTin_RunWorkerCompleted);
            // 
            // wSoDaDat
            // 
            this.wSoDaDat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wSoDaDat_DoWork);
            this.wSoDaDat.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wSoDaDat_RunWorkerCompleted);
            // 
            // timerClock
            // 
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // wTimer
            // 
            this.wTimer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wTimer_DoWork);
            this.wTimer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wTimer_RunWorkerCompleted);
            // 
            // panelLeft
            // 
            this.panelLeft.AutoScroll = true;
            this.panelLeft.Controls.Add(this.grpDatSo);
            this.panelLeft.Controls.Add(this.grpThongTin);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(241, 318);
            this.panelLeft.TabIndex = 9;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.grpSoDaDat);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(241, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(372, 318);
            this.panelRight.TabIndex = 10;
            // 
            // pbThoiGian
            // 
            this.pbThoiGian.Location = new System.Drawing.Point(43, 113);
            this.pbThoiGian.MarqueeAnimationSpeed = 1;
            this.pbThoiGian.Name = "pbThoiGian";
            this.pbThoiGian.Size = new System.Drawing.Size(121, 3);
            this.pbThoiGian.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbThoiGian.TabIndex = 10;
            this.pbThoiGian.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 318);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xổ số kiến thiết Con Gà Trống";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpDatSo.ResumeLayout(false);
            this.grpDatSo.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpSoDaDat.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox tvDatSo;
        private System.Windows.Forms.Button btnDatSo;
        private System.Windows.Forms.GroupBox grpDatSo;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblDienThoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox grpSoDaDat;
        private System.Windows.Forms.ListView lvSoDaDat;
        private System.Windows.Forms.ColumnHeader col0;
        private System.Windows.Forms.ColumnHeader colNgayGioKetQua;
        private System.Windows.Forms.ColumnHeader colDaTrung;
        private System.Windows.Forms.ColumnHeader colKetQuaQuaySo;
        private System.Windows.Forms.ColumnHeader colSoDat;
        private System.Windows.Forms.ProgressBar pbDatSo;
        private System.Windows.Forms.ProgressBar pbThongTin;
        private System.Windows.Forms.ProgressBar pbSoDaDat;
        private System.Windows.Forms.Label lblClock;
        private System.ComponentModel.BackgroundWorker wDatSo;
        private System.ComponentModel.BackgroundWorker wThongTin;
        private System.ComponentModel.BackgroundWorker wSoDaDat;
        private System.Windows.Forms.Timer timerClock;
        private System.ComponentModel.BackgroundWorker wTimer;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.ProgressBar pbThoiGian;
    }
}
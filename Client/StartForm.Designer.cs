namespace Client
{
    partial class StartForm
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
            this.wLoad = new System.ComponentModel.BackgroundWorker();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.lblLoading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wLoad
            // 
            this.wLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.wLoad_DoWork);
            this.wLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.wLoad_RunWorkerCompleted);
            // 
            // pbLoad
            // 
            this.pbLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbLoad.Location = new System.Drawing.Point(0, 139);
            this.pbLoad.MarqueeAnimationSpeed = 1;
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(279, 3);
            this.pbLoad.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbLoad.TabIndex = 0;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(107, 63);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(56, 13);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Đang tải...";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(279, 142);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.pbLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StartForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker wLoad;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.Label lblLoading;
    }
}


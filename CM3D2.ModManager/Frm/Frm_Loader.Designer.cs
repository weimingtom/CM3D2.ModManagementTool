namespace CM3D2.ModManager
{
    partial class Frm_Loader
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_Logs = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_ProgressDetail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Logs
            // 
            this.lb_Logs.FormattingEnabled = true;
            this.lb_Logs.ItemHeight = 12;
            this.lb_Logs.Location = new System.Drawing.Point(12, 12);
            this.lb_Logs.Name = "lb_Logs";
            this.lb_Logs.Size = new System.Drawing.Size(618, 280);
            this.lb_Logs.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 298);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(618, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            // 
            // lbl_ProgressDetail
            // 
            this.lbl_ProgressDetail.AutoSize = true;
            this.lbl_ProgressDetail.Location = new System.Drawing.Point(12, 324);
            this.lbl_ProgressDetail.Name = "lbl_ProgressDetail";
            this.lbl_ProgressDetail.Size = new System.Drawing.Size(29, 12);
            this.lbl_ProgressDetail.TabIndex = 2;
            this.lbl_ProgressDetail.Text = "대기";
            // 
            // Frm_Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(644, 344);
            this.Controls.Add(this.lbl_ProgressDetail);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_Logs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_Loader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "모드리스트를 만드는중...";
            this.Load += new System.EventHandler(this.Frm_Init_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Logs;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_ProgressDetail;
    }
}


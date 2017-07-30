using System.Windows.Forms;

namespace CM3D2.ModManagementTool
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
            this.cb_cacheType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_StartProcess = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_Logs
            // 
            this.lb_Logs.FormattingEnabled = true;
            this.lb_Logs.ItemHeight = 12;
            this.lb_Logs.Location = new System.Drawing.Point(12, 50);
            this.lb_Logs.Name = "lb_Logs";
            this.lb_Logs.Size = new System.Drawing.Size(618, 280);
            this.lb_Logs.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 336);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(618, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            // 
            // lbl_ProgressDetail
            // 
            this.lbl_ProgressDetail.AutoSize = true;
            this.lbl_ProgressDetail.Location = new System.Drawing.Point(10, 362);
            this.lbl_ProgressDetail.Name = "lbl_ProgressDetail";
            this.lbl_ProgressDetail.Size = new System.Drawing.Size(29, 12);
            this.lbl_ProgressDetail.TabIndex = 2;
            this.lbl_ProgressDetail.Text = "대기";
            // 
            // cb_cacheType
            // 
            this.cb_cacheType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cacheType.FormattingEnabled = true;
            this.cb_cacheType.Items.AddRange(new object[] {
            "모든 캐시를 사용합니다 (파일 유효성 미검사)",
            "모든 캐시를 사용합니다 (파일 유효성 검사)",
            "파일 내부정보 캐시만 사용합니다 (파일목록 재생성)",
            "캐시를 사용하지 않습니다."});
            this.cb_cacheType.Location = new System.Drawing.Point(12, 24);
            this.cb_cacheType.Name = "cb_cacheType";
            this.cb_cacheType.Size = new System.Drawing.Size(618, 20);
            this.cb_cacheType.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "캐시의 처리방식";
            // 
            // btn_StartProcess
            // 
            this.btn_StartProcess.Location = new System.Drawing.Point(12, 377);
            this.btn_StartProcess.Name = "btn_StartProcess";
            this.btn_StartProcess.Size = new System.Drawing.Size(615, 23);
            this.btn_StartProcess.TabIndex = 5;
            this.btn_StartProcess.Text = "모드 리스트 불러오기";
            this.btn_StartProcess.UseVisualStyleBackColor = true;
            this.btn_StartProcess.Click += new System.EventHandler(this.btn_StartProcess_Click);
            // 
            // Frm_Loader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 411);
            this.Controls.Add(this.btn_StartProcess);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_cacheType);
            this.Controls.Add(this.lbl_ProgressDetail);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lb_Logs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_Loader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "모드리스트 로더";
            this.Load += new System.EventHandler(this.Frm_Init_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Logs;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_ProgressDetail;
        private System.Windows.Forms.ComboBox cb_cacheType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_StartProcess;
    }
}


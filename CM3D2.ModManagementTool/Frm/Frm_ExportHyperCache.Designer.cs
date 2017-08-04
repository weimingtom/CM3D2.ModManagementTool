namespace CM3D2.ModManagementTool.Frm
{
    partial class Frm_ExportHyperCache
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
            this.lb_Logs = new System.Windows.Forms.ListBox();
            this.btn_Start = new System.Windows.Forms.Button();
            this.pb_Status = new System.Windows.Forms.ProgressBar();
            this.lbl_ProgressDetail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Logs
            // 
            this.lb_Logs.FormattingEnabled = true;
            this.lb_Logs.ItemHeight = 12;
            this.lb_Logs.Location = new System.Drawing.Point(12, 12);
            this.lb_Logs.Name = "lb_Logs";
            this.lb_Logs.Size = new System.Drawing.Size(742, 400);
            this.lb_Logs.TabIndex = 0;
            // 
            // btn_Start
            // 
            this.btn_Start.Location = new System.Drawing.Point(12, 472);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(742, 23);
            this.btn_Start.TabIndex = 1;
            this.btn_Start.Text = "작업 시작";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // pb_Status
            // 
            this.pb_Status.Location = new System.Drawing.Point(12, 418);
            this.pb_Status.Name = "pb_Status";
            this.pb_Status.Size = new System.Drawing.Size(742, 23);
            this.pb_Status.TabIndex = 2;
            // 
            // lbl_ProgressDetail
            // 
            this.lbl_ProgressDetail.AutoSize = true;
            this.lbl_ProgressDetail.Location = new System.Drawing.Point(10, 447);
            this.lbl_ProgressDetail.Name = "lbl_ProgressDetail";
            this.lbl_ProgressDetail.Size = new System.Drawing.Size(29, 12);
            this.lbl_ProgressDetail.TabIndex = 3;
            this.lbl_ProgressDetail.Text = "대기";
            // 
            // Frm_ExportHyperCache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 504);
            this.Controls.Add(this.lbl_ProgressDetail);
            this.Controls.Add(this.pb_Status);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.lb_Logs);
            this.Name = "Frm_ExportHyperCache";
            this.Text = "HyperCache용으로 내보내기";
            this.Load += new System.EventHandler(this.Frm_ExportHyperCache_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Logs;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.ProgressBar pb_Status;
        private System.Windows.Forms.Label lbl_ProgressDetail;
    }
}
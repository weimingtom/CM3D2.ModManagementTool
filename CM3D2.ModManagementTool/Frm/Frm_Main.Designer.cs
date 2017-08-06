namespace CM3D2.ModManagementTool.Frm
{
    partial class Frm_Main
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
            this.btn_RefreshList = new System.Windows.Forms.Button();
            this.btn_ExportHyperCache = new System.Windows.Forms.Button();
            this.btn_ShowProblemViewer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_RefreshList
            // 
            this.btn_RefreshList.Location = new System.Drawing.Point(12, 12);
            this.btn_RefreshList.Name = "btn_RefreshList";
            this.btn_RefreshList.Size = new System.Drawing.Size(75, 23);
            this.btn_RefreshList.TabIndex = 0;
            this.btn_RefreshList.Text = "목록 갱신";
            this.btn_RefreshList.UseVisualStyleBackColor = true;
            this.btn_RefreshList.Click += new System.EventHandler(this.btn_RefreshList_Click);
            // 
            // btn_ExportHyperCache
            // 
            this.btn_ExportHyperCache.Location = new System.Drawing.Point(187, 12);
            this.btn_ExportHyperCache.Name = "btn_ExportHyperCache";
            this.btn_ExportHyperCache.Size = new System.Drawing.Size(191, 23);
            this.btn_ExportHyperCache.TabIndex = 1;
            this.btn_ExportHyperCache.Text = "HyperCache용으로 내보내기";
            this.btn_ExportHyperCache.UseVisualStyleBackColor = true;
            this.btn_ExportHyperCache.Click += new System.EventHandler(this.btn_ExportHyperCache_Click);
            // 
            // btn_ShowProblemViewer
            // 
            this.btn_ShowProblemViewer.Location = new System.Drawing.Point(93, 12);
            this.btn_ShowProblemViewer.Name = "btn_ShowProblemViewer";
            this.btn_ShowProblemViewer.Size = new System.Drawing.Size(88, 23);
            this.btn_ShowProblemViewer.TabIndex = 2;
            this.btn_ShowProblemViewer.Text = "문제점 뷰어";
            this.btn_ShowProblemViewer.UseVisualStyleBackColor = true;
            this.btn_ShowProblemViewer.Click += new System.EventHandler(this.btn_ShowProblemViewer_Click);
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 589);
            this.Controls.Add(this.btn_ShowProblemViewer);
            this.Controls.Add(this.btn_ExportHyperCache);
            this.Controls.Add(this.btn_RefreshList);
            this.Name = "Frm_Main";
            this.Text = "CM3D2 모드 관리 툴";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_RefreshList;
        private System.Windows.Forms.Button btn_ExportHyperCache;
        private System.Windows.Forms.Button btn_ShowProblemViewer;
    }
}
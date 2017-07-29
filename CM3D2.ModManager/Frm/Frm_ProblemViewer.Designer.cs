namespace CM3D2.ModManager.Frm
{
    partial class Frm_ProblemViewer
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
            this.lb_Errors = new System.Windows.Forms.ListBox();
            this.lbl_fileName = new System.Windows.Forms.Label();
            this.lbl_filePath = new System.Windows.Forms.Label();
            this.tb_ErrorMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OpenPath = new System.Windows.Forms.Button();
            this.lb_FileList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_FirstFile = new System.Windows.Forms.Label();
            this.lbl_SecondFile = new System.Windows.Forms.Label();
            this.btn_Cleanup = new System.Windows.Forms.Button();
            this.btn_ReplaceFile = new System.Windows.Forms.Button();
            this.btn_refreshStore = new System.Windows.Forms.Button();
            this.btn_RenameIt = new System.Windows.Forms.Button();
            this.btn_openFirst = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_Errors
            // 
            this.lb_Errors.FormattingEnabled = true;
            this.lb_Errors.ItemHeight = 12;
            this.lb_Errors.Location = new System.Drawing.Point(12, 12);
            this.lb_Errors.Name = "lb_Errors";
            this.lb_Errors.Size = new System.Drawing.Size(303, 508);
            this.lb_Errors.TabIndex = 0;
            this.lb_Errors.SelectedIndexChanged += new System.EventHandler(this.lb_Errors_SelectedIndexChanged);
            // 
            // lbl_fileName
            // 
            this.lbl_fileName.AutoSize = true;
            this.lbl_fileName.Location = new System.Drawing.Point(321, 12);
            this.lbl_fileName.Name = "lbl_fileName";
            this.lbl_fileName.Size = new System.Drawing.Size(49, 12);
            this.lbl_fileName.TabIndex = 1;
            this.lbl_fileName.Text = "파일명: ";
            // 
            // lbl_filePath
            // 
            this.lbl_filePath.AutoSize = true;
            this.lbl_filePath.Location = new System.Drawing.Point(321, 33);
            this.lbl_filePath.Name = "lbl_filePath";
            this.lbl_filePath.Size = new System.Drawing.Size(65, 12);
            this.lbl_filePath.TabIndex = 2;
            this.lbl_filePath.Text = "파일 경로: ";
            // 
            // tb_ErrorMessage
            // 
            this.tb_ErrorMessage.BackColor = System.Drawing.Color.White;
            this.tb_ErrorMessage.Location = new System.Drawing.Point(323, 69);
            this.tb_ErrorMessage.Multiline = true;
            this.tb_ErrorMessage.Name = "tb_ErrorMessage";
            this.tb_ErrorMessage.ReadOnly = true;
            this.tb_ErrorMessage.Size = new System.Drawing.Size(566, 136);
            this.tb_ErrorMessage.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(321, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "오류 메시지";
            // 
            // btn_OpenPath
            // 
            this.btn_OpenPath.Location = new System.Drawing.Point(321, 497);
            this.btn_OpenPath.Name = "btn_OpenPath";
            this.btn_OpenPath.Size = new System.Drawing.Size(104, 23);
            this.btn_OpenPath.TabIndex = 6;
            this.btn_OpenPath.Text = "파일 경로 열기";
            this.btn_OpenPath.UseVisualStyleBackColor = true;
            this.btn_OpenPath.Click += new System.EventHandler(this.btn_OpenPath_Click);
            // 
            // lb_FileList
            // 
            this.lb_FileList.FormattingEnabled = true;
            this.lb_FileList.ItemHeight = 12;
            this.lb_FileList.Location = new System.Drawing.Point(321, 223);
            this.lb_FileList.Name = "lb_FileList";
            this.lb_FileList.Size = new System.Drawing.Size(568, 172);
            this.lb_FileList.TabIndex = 7;
            this.lb_FileList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lb_FileList_MouseClick);
            this.lb_FileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_FileList_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(407, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "파일 목록 (왼쪽 더블 클릭으로 1번, 오른쪽 마우스버튼으로 2번 파일 선택)";
            // 
            // lbl_FirstFile
            // 
            this.lbl_FirstFile.AutoSize = true;
            this.lbl_FirstFile.Location = new System.Drawing.Point(321, 398);
            this.lbl_FirstFile.Name = "lbl_FirstFile";
            this.lbl_FirstFile.Size = new System.Drawing.Size(59, 12);
            this.lbl_FirstFile.TabIndex = 9;
            this.lbl_FirstFile.Text = "1번 파일: ";
            // 
            // lbl_SecondFile
            // 
            this.lbl_SecondFile.AutoSize = true;
            this.lbl_SecondFile.Location = new System.Drawing.Point(321, 420);
            this.lbl_SecondFile.Name = "lbl_SecondFile";
            this.lbl_SecondFile.Size = new System.Drawing.Size(59, 12);
            this.lbl_SecondFile.TabIndex = 10;
            this.lbl_SecondFile.Text = "2번 파일: ";
            // 
            // btn_Cleanup
            // 
            this.btn_Cleanup.Location = new System.Drawing.Point(323, 435);
            this.btn_Cleanup.Name = "btn_Cleanup";
            this.btn_Cleanup.Size = new System.Drawing.Size(192, 23);
            this.btn_Cleanup.TabIndex = 11;
            this.btn_Cleanup.Text = "1번 파일을 제외하고 전부 지우기";
            this.btn_Cleanup.UseVisualStyleBackColor = true;
            this.btn_Cleanup.Click += new System.EventHandler(this.btn_Cleanup_Click);
            // 
            // btn_ReplaceFile
            // 
            this.btn_ReplaceFile.Location = new System.Drawing.Point(521, 435);
            this.btn_ReplaceFile.Name = "btn_ReplaceFile";
            this.btn_ReplaceFile.Size = new System.Drawing.Size(228, 23);
            this.btn_ReplaceFile.TabIndex = 12;
            this.btn_ReplaceFile.Text = "2번 파일을 1번 파일로 복사한 뒤 삭제";
            this.btn_ReplaceFile.UseVisualStyleBackColor = true;
            this.btn_ReplaceFile.Click += new System.EventHandler(this.btn_ReplaceFile_Click);
            // 
            // btn_refreshStore
            // 
            this.btn_refreshStore.Location = new System.Drawing.Point(765, 501);
            this.btn_refreshStore.Name = "btn_refreshStore";
            this.btn_refreshStore.Size = new System.Drawing.Size(124, 23);
            this.btn_refreshStore.TabIndex = 13;
            this.btn_refreshStore.Text = "정보 갱신";
            this.btn_refreshStore.UseVisualStyleBackColor = true;
            this.btn_refreshStore.Click += new System.EventHandler(this.btn_refreshStore_Click);
            // 
            // btn_RenameIt
            // 
            this.btn_RenameIt.Location = new System.Drawing.Point(323, 464);
            this.btn_RenameIt.Name = "btn_RenameIt";
            this.btn_RenameIt.Size = new System.Drawing.Size(192, 23);
            this.btn_RenameIt.TabIndex = 14;
            this.btn_RenameIt.Text = "1번 파일의 파일명을 수정하기";
            this.btn_RenameIt.UseVisualStyleBackColor = true;
            this.btn_RenameIt.Click += new System.EventHandler(this.btn_RenameIt_Click);
            // 
            // btn_openFirst
            // 
            this.btn_openFirst.Location = new System.Drawing.Point(521, 464);
            this.btn_openFirst.Name = "btn_openFirst";
            this.btn_openFirst.Size = new System.Drawing.Size(228, 23);
            this.btn_openFirst.TabIndex = 15;
            this.btn_openFirst.Text = "1번 파일의 경로 열기";
            this.btn_openFirst.UseVisualStyleBackColor = true;
            this.btn_openFirst.Click += new System.EventHandler(this.btn_openFirst_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(12, 539);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(492, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "갱신하기 전까지, 오류는 실질적으로 해결되었더라도 목록에서 제거되지 않습니다.";
            // 
            // Frm_ProblemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 560);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_openFirst);
            this.Controls.Add(this.btn_RenameIt);
            this.Controls.Add(this.btn_refreshStore);
            this.Controls.Add(this.btn_ReplaceFile);
            this.Controls.Add(this.btn_Cleanup);
            this.Controls.Add(this.lbl_SecondFile);
            this.Controls.Add(this.lbl_FirstFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_FileList);
            this.Controls.Add(this.btn_OpenPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_ErrorMessage);
            this.Controls.Add(this.lbl_filePath);
            this.Controls.Add(this.lbl_fileName);
            this.Controls.Add(this.lb_Errors);
            this.Name = "Frm_ProblemViewer";
            this.Text = "오류 탐색기";
            this.Load += new System.EventHandler(this.Frm_ProblemViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_Errors;
        private System.Windows.Forms.Label lbl_fileName;
        private System.Windows.Forms.Label lbl_filePath;
        private System.Windows.Forms.TextBox tb_ErrorMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OpenPath;
        private System.Windows.Forms.ListBox lb_FileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_FirstFile;
        private System.Windows.Forms.Label lbl_SecondFile;
        private System.Windows.Forms.Button btn_Cleanup;
        private System.Windows.Forms.Button btn_ReplaceFile;
        private System.Windows.Forms.Button btn_refreshStore;
        private System.Windows.Forms.Button btn_RenameIt;
        private System.Windows.Forms.Button btn_openFirst;
        private System.Windows.Forms.Label label3;
    }
}
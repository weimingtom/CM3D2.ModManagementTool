using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CM3D2.ModManager.Utils;
using CM3D2.ModManager.Mod.Problem;
using System.IO;
using System.Diagnostics;
using CM3D2.ModManager.Mod;
using CM3D2.ModManager.Mod.File;

namespace CM3D2.ModManager.Frm
{


    public partial class Frm_ProblemViewer : Form
    {
        public static string ShowDialog(string text, string caption, string boxText = "")
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Text = boxText };
            Button confirmation = new Button() { Text = "진행", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public BaseFile getListedFile(int inx)
        {
            if (selected is DuplicateProblem)
            {
                return selected.getIssueFile().duplicateFiles[inx];
            }
            return null;
        }
        
        private List<BaseProblem> problems = new List<BaseProblem>();

        private const string notInited = "설정 안됨";

        private BaseProblem selected = null;
        private int selected_inx;

        private BaseFile first_file = null;
        private int first_inx = -1;
        private BaseFile second_file = null;
        private int second_inx = -1;

        public void setFileName(string name)
        {
            lbl_fileName.Text = "파일명: " + name;
        }

        public void setFilePath(string path)
        {
            lbl_filePath.Text = "파일경로: " + path;
        }

        public void setSelected(BaseProblem problem)
        {
            lb_FileList.Items.Clear();

            selected = problem;
            setFileName( Path.GetFileName( problem.getIssueFile().path ) );
            setFilePath(problem.getIssueFile().relativePath);

            tb_ErrorMessage.Text = problem.getDescription();

            if(problem.getIssueFile().duplicateFiles != null && problem is DuplicateProblem)
            {
                foreach(BaseFile file in problem.getIssueFile().duplicateFiles)
                {
                    lb_FileList.Items.Add(file.relativePath);
                }
            }
        }

        public void refreshSelected()
        {
            if(selected != null)
            {
                setSelected(selected);
            }
        }

        public void setFirstFile(BaseFile file)
        {
            first_file = file;
            lbl_FirstFile.Text = "1번 파일: " + (file != null ? file.path : notInited);
        }

        public void setSecondFile(BaseFile file)
        {
            second_file = file;
            lbl_SecondFile.Text = "2번 파일: " + (file != null ? file.path : notInited);
        }

        public void reset()
        {
            setFileName(notInited);
            setFilePath(notInited);
            setFirstFile(null);
            setSecondFile(null);
        }

        public Frm_ProblemViewer()
        {
            InitializeComponent();
        }

        private void Frm_ProblemViewer_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void lb_Errors_SelectedIndexChanged(object sender, EventArgs e)
        {
            reset();

            if(lb_Errors.SelectedIndex == -1)
            {
                return;
            }
            selected_inx = lb_Errors.SelectedIndex;
            setSelected(problems[selected_inx]);
        }

        private void btn_refreshStore_Click(object sender, EventArgs e)
        {
            new Frm_Loader().ShowDialog();
            problems.Clear();
            lb_Errors.Items.Clear();
            
            ModContainer.Single.foreachFiles(item =>
            {
                foreach (var error in item.errors)
                {
                    problems.Add(error);
                    lb_Errors.Items.Add(error.getSummary());
                }
            });
        }

        private void btn_OpenPath_Click(object sender, EventArgs e)
        {
            if(selected != null)
            {
                FileHelper.openInExplorer( selected.getIssueFile().path );
            }
        }

        private void btn_openFirst_Click(object sender, EventArgs e)
        {
            if(first_file != null)
            {
                FileHelper.openInExplorer( first_file.path );
            }
        }
        
        private void Frm_ProblemViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (selected == null)
            {
                return;
            }

            if (selected.getIssueFile().duplicateFiles.Count == 0)
            {
                return;
            }


            if (e.KeyCode == Keys.F2)
            {
                first_inx = lb_FileList.SelectedIndex;
                setFirstFile( getListedFile(first_inx) );
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F3)
            {
                second_inx = lb_FileList.SelectedIndex;
                setSecondFile( getListedFile(second_inx) );
                e.SuppressKeyPress = true;
            }
        }

        private void btn_RenameIt_Click(object sender, EventArgs e)
        {
            if (first_file == null)
            {
                return;
            }

            string orig = Path.GetFileName(first_file.path);
            string rename = ShowDialog("바꿀 파일명을 입력하세요\r\n취소하려면 비우거나 똑같은 파일명을 쓰세요.", "파일 이름 변경", orig);

            if( rename == ""  || rename == orig)
            {
                return;
            }

            string parent = Path.GetDirectoryName(first_file.path) + @"\";

            File.Move(Path.GetFullPath(parent + orig), Path.GetFullPath(parent + rename));

            selected.getIssueFile().duplicateFiles[first_inx] = new BaseFile(ConfigManager.Single.getRoot(), first_file.relativePath.Replace(orig, rename));
            first_file = selected.getIssueFile().duplicateFiles[first_inx];
            refreshSelected();
        }

        private void btn_Cleanup_Click(object sender, EventArgs e)
        {
            if(first_file == null)
            {
                return;
            }
            DialogResult result = MessageBox.Show("정말로 " + first_file.relativePath + " 를 제외한 다른 중복 파일을 지웁니까?\r\n" +
                "이 작업은 취소할 수 없습니다.", "파일 삭제전 확인", MessageBoxButtons.YesNo);

            if(result != DialogResult.Yes)
            {
                return;
            }

            List<BaseFile> duplicate = selected.getIssueFile().duplicateFiles;
            duplicate.RemoveAll(item =>
            {
                if(item != first_file)
                {
                    File.Delete(item.path);
                    return true;
                }
                return false;
            });

            second_file = null; //first_file 이외에 다른 파일이 삭제되었기 때문에, 이 변수는 더이상 유효하지 않음
            refreshSelected();
        }

        private void btn_ReplaceFile_Click(object sender, EventArgs e)
        {
            if(first_file == null || second_file == null)
            {
                return;
            }
            DialogResult result = MessageBox.Show("정말로 " + first_file.relativePath + " 를\r\n" +
                second_file.relativePath + "로 교체합니까? 첫번째 파일은 삭제됩니다." +
                "이 작업은 취소할 수 없습니다.", "파일 작업전 확인", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
            {
                return;
            }

            File.Delete(first_file.path);
            File.Move(second_file.path, first_file.path);

            selected.getIssueFile().duplicateFiles[first_inx] = new BaseFile(ConfigManager.Single.getRoot(), first_file.relativePath);

            first_file = selected.getIssueFile().duplicateFiles[first_inx];

            //제거되었으므로 더이상 유효하지 않음
            selected.getIssueFile().duplicateFiles.RemoveAt(second_inx);
            second_file = null;
        }

        private void Frm_ProblemViewer_Resize(object sender, EventArgs e)
        {
            tb_ErrorMessage.Width = Width - tb_ErrorMessage.Location.X - 32;
            lb_FileList.Width = Width - lb_FileList.Location.X - 32;
        }

        private void btn_OpenAllFiles_Click(object sender, EventArgs e)
        {
            if (selected is DuplicateProblem)
            {
                foreach (var file in selected.getIssueFile().duplicateFiles)
                {
                    FileHelper.openInExplorer(file.path);
                }
            }
        }
    }
}

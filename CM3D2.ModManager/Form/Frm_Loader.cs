using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using CM3D2.ModManager.Utils;
using System.Diagnostics;

namespace CM3D2.ModManager
{
    public partial class Frm_Loader : Form
    {
        private Thread processingThread;

        public Frm_Loader()
        {
            InitializeComponent();
        }

        private bool isSybaris = Directory.Exists("Sybaris");

        private void Frm_Init_Load(object sender, EventArgs e)
        {
            if (!File.Exists("CM3D2.exe"))
            {
                MessageBox.Show("CM3D2.exe 를 발견하지 못했습니다. 이 프로그램을 커메 2가 있는 위치에서 실행하세요!", "에러!");
                Application.Exit();
                return;
            }

            processingThread = new Thread(new ThreadStart(Processing));
            processingThread.Start();
        }

        public void updateStatus(string status)
        {
            if (this.InvokeRequired)
            {
                // create a delegate pointing back to this same function
                // the Invoke method will cause the delegate to be invoked on the main UI thread
                this.Invoke(new Action<string>(updateStatus), status);
                return;
            }

            lb_Logs.Items.Add(status);
            lbl_ProgressDetail.Text = status;
        }

        public void updateStatusWithoutLog(string status)
        {
            if (this.InvokeRequired)
            {
                // create a delegate pointing back to this same function
                // the Invoke method will cause the delegate to be invoked on the main UI thread
                this.Invoke(new Action<string>(updateStatusWithoutLog), status);
                return;
            }

            lbl_ProgressDetail.Text = status;
        }

        private string boolToString(bool value)
        {
            if (value)
            {
                return "있음";
            }
            else
            {
                return "없음";
            }
        }

        private Stopwatch receiverWatch = new Stopwatch();

        public void MessageReceived(string message)
        {
            if( receiverWatch.IsRunning && receiverWatch.ElapsedMilliseconds <= 1000)
            {
                return;
            }
            receiverWatch.Restart();

            updateStatusWithoutLog(message);
        }

        public void Processing()
        {
            updateStatus("시바리스: " + boolToString(isSybaris));

            updateStatus("시스템 초기화 및 사용 가능한 내장 아이템 탐색");
            Injected.DLLManager.Initialize();
            Injected.GameUty.Init();

            updateStatus("모드목록을 만드는중...");
            ModContainer.MessageReceiver receiver = new ModContainer.MessageReceiver(MessageReceived);
            //TODO: User INPUT!!!
            ModContainer.createModContainer(@"D:\GameNK\Hs\3D\Custom Maid\MODS_COLLECTION", receiver);

            updateStatus("모드의 문제점을 찾는중...");
            ModContainer.Single.analyzeMods(false);

            updateStatus("문제점 목록을 내보내는중...");
            ModContainer.Single.dumpErrorMessages("_errors.txt");

            updateStatus("만든 목록의 일부를 파일에 기록하는중...");
            ModContainer.Single.writeCache();

            updateStatus("초기화 완료");
        }
    }
}

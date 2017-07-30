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

using CM3D2.ModManagementTool.Utils;
using System.Diagnostics;
using CM3D2.ModManagementTool.Mod;

namespace CM3D2.ModManagementTool
{
    public partial class Frm_Loader : Form
    {
        private Thread processingThread;

        public Frm_Loader()
        {
            InitializeComponent();
        }

        private bool isSybaris = Directory.Exists("Sybaris");

        private CacheLoadOption _cacheLoadOption;

        private void Frm_Init_Load(object sender, EventArgs e)
        {
            
        }

        public void SafeClose()
        {
            SafeCloseInvoke(null);
        }

        public void SafeCloseInvoke(string dummy)
        {
            if (InvokeRequired)
            {
                //God... why Action require one argument...?
                Invoke( new Action<string>(SafeCloseInvoke), "");
                return;
            }
            
            Close();
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

            if (Injected.GameUty.MenuFiles != null)
            {
                updateStatus("시스템이 이미 초기화 되어 있음, 넘어감");
            }
            else
            {
                updateStatus("시스템 초기화 및 사용 가능한 내장 아이템 탐색");
                Injected.DLLManager.Initialize();
                Injected.GameUty.Init();
            }

            ModContainer.MessageReceiver receiver = new ModContainer.MessageReceiver(MessageReceived);
            ModContainer container;
            if (ModContainer.Single != null)
            {
                ModContainer.Single.messages += receiver;
                updateStatus("모드목록을 재확인 하는중...");
                switch (_cacheLoadOption)
                {
                    case CacheLoadOption.NO_CACHE:
                        ModContainer.Single.LoadFileList(_cacheLoadOption);
                        break;
                    case CacheLoadOption.READ_ALL_CHECK_EXIST:
                        ModContainer.Single.CacheStore.VerifyRelativePaths();
                        ModContainer.Single.Reload();
                        break;
                    case CacheLoadOption.READ_ONLY_REFERENCE:
                        ModContainer.Single.RebuildPaths();
                        ModContainer.Single.Reload();
                        break;
                    case CacheLoadOption.READ_ONLY_PATHS:
                        ModContainer.Single.CacheStore.ClearExtraData();
                        ModContainer.Single.Reload();
                        break;
                }
            }
            else
            {
                updateStatus("모드목록을 만드는중...");
                ModContainer.createModContainer(ConfigManager.Single.getRoot(), receiver);
                ModContainer.Single.LoadFileList(_cacheLoadOption);
            }
            updateStatus("모드의 문제점을 찾는중...");
            ModContainer.Single.analyzeMods(true);

            //updateStatus("문제점 목록을 내보내는중...");
            //ModContainer.Single.dumpErrorMessages("_errors.txt");

            updateStatus("만든 목록을 파일에 기록하는중...");
            ModContainer.Single.writeCache();

            updateStatus("초기화 완료");

            ModContainer.Single.messages -= receiver;
            SafeClose();
        }

        private void btn_StartProcess_Click(object sender, EventArgs e)
        {
            if (cb_cacheType.SelectedIndex == -1)
            {
                MessageBox.Show("캐시의 처리방식을 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            switch ( cb_cacheType.SelectedIndex )
            {
                    case 0:
                        _cacheLoadOption = CacheLoadOption.READ_ALL;
                        break;
                    case 1:
                        _cacheLoadOption = CacheLoadOption.READ_ALL_CHECK_EXIST;
                        break;
                    case 2:
                        _cacheLoadOption = CacheLoadOption.READ_ONLY_REFERENCE;
                        break;
                    case 3:
                        _cacheLoadOption = CacheLoadOption.READ_ONLY_PATHS;
                        break;
                    case 4:
                        _cacheLoadOption = CacheLoadOption.NO_CACHE;
                        break;
            }
            
            processingThread = new Thread(new ThreadStart(Processing));
            processingThread.Start();
        }
    }
}

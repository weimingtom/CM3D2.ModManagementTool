using CM3D2.ModManagementTool.Mod;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM3D2.ModManagementTool.Frm
{
    public partial class Frm_ExportHyperCache : Form
    {
        public Frm_ExportHyperCache()
        {
            InitializeComponent();
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
                Invoke(new Action<string>(SafeCloseInvoke), "");
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

        private Thread workingThread;

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if(workingThread != null)
            {
                return;
            }

            workingThread = new Thread(Processing);
            workingThread.Start();
        }

        private Stopwatch watch = new Stopwatch();

        private void Processing()
        {
            updateStatus("작업 시작");

            BinaryWriter writer = new BinaryWriter( new FileStream("CM3D2.HyperCache.dat", FileMode.Create) );
            writer.Write(ModContainer.Single.rootDir);

            writer.Write(ModContainer.Single.FilesCount());
            watch.Start();
            ModContainer.Single.foreachFiles(item =>
            {
                if (watch.ElapsedMilliseconds > 1000)
                {
                    watch.Restart();
                    updateStatusWithoutLog("작업중:" + item.path);
                }
                writer.Write(item.relativePath);

                BinaryReader reader = new BinaryReader(new FileStream(item.path, FileMode.Open));

                try
                {
                    reader.ReadString();
                    reader.ReadInt32();
                    string internalPath = reader.ReadString();
                    writer.Write(Path.GetFileName(internalPath));
                } catch(Exception ae)
                {
                    writer.Write("");
                }

                try
                {
                    reader.Close();
                }
                catch (Exception e)
                {

                }
            });

            writer.Close();

            updateStatus("작업 종료");
        }

        private void Frm_ExportHyperCache_Load(object sender, EventArgs e)
        {

        }
    }
}

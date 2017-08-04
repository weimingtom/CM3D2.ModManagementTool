using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM3D2.ModManagementTool
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (!File.Exists("CM3D2.exe"))
            {
                MessageBox.Show("CM3D2.exe 를 발견하지 못했습니다. 이 프로그램을 커메 2가 있는 위치에서 실행하세요!", "에러!");
                Application.Exit();
                return;
            }
            
            Application.Run(new Frm.Frm_Main());
        }
    }
}

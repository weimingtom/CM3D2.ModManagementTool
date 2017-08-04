using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CM3D2.ModManagementTool.Frm
{
    public partial class Frm_Main : Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void btn_RefreshList_Click(object sender, EventArgs e)
        {
            new Frm_Loader().ShowDialog();
        }

        private void btn_ShowProblemViewer_Click(object sender, EventArgs e)
        {
            new Frm_ProblemViewer().ShowDialog();
        }

        private void btn_ExportHyperCache_Click(object sender, EventArgs e)
        {
            new Frm_ExportHyperCache().ShowDialog();
        }
    }
}

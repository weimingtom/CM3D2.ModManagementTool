using CM3D2.ModManagementTool.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM3D2.ModManagementTool.Mod.File;

namespace CM3D2.ModManagementTool.Mod.Problem
{
    public abstract class BaseProblem
    {
        //오류의 설명을 가져옵니다
        public abstract string getDescription();

        //오류의 한줄 요약을 가져옵니다.
        public abstract string getSummary();

        public abstract BaseFile getIssueFile();
    }
}

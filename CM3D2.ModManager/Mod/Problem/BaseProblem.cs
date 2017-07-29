using CM3D2.ModManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3D2.ModManager.Mod.Problem
{
    public abstract class BaseProblem
    {
        //오류의 설명을 가져옵니다
        public abstract string getDescription();

        public abstract BaseFile getIssueFile();
    }
}

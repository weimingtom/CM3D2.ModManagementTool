using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM3D2.ModManager.Mod.File;
using CM3D2.ModManager.Utils;

namespace CM3D2.ModManager.Mod.Problem
{
    public class InvalidPathProblem : BaseProblem
    {
        public BaseFile file;
        public string invalidPath;

        public InvalidPathProblem(BaseFile file, string invalidPath)
        {
            this.file = file;
            this.invalidPath = invalidPath;
        }

        public override string getDescription()
        {
            return "경로에 사용할 수 없는 문자가 포함됨: " + invalidPath;
        }

        public override BaseFile getIssueFile()
        {
            return file;
        }

        public override string getSummary()
        {
            return "경로이상: " + invalidPath;
        }
    }
}

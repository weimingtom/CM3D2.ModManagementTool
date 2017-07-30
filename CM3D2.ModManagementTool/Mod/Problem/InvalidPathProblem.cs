using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CM3D2.ModManagementTool.Mod.File;
using CM3D2.ModManagementTool.Utils;

namespace CM3D2.ModManagementTool.Mod.Problem
{
    public class InvalidPathProblem : BaseProblem
    {
        public BaseFile file;
        public string invalidPath;
        public Exception e;

        public InvalidPathProblem(BaseFile file, string invalidPath, Exception e)
        {
            this.file = file;
            this.invalidPath = invalidPath;
            this.e = e;
        }

        public override string getDescription()
        {
            return "이 파일, 혹은 이 파일이 참조하는 파일명중 적합하지 않은 문구가 포함되어 있습니다: " + invalidPath;
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

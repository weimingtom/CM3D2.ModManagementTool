using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CM3D2.ModManager.Utils;
using System.IO;

namespace CM3D2.ModManager.Mod.Problem
{
    public class InternalProblem : BaseProblem
    {
        public BaseFile file;
        public Exception e;

        public InternalProblem(BaseFile file, Exception e)
        {
            this.file = file;
            this.e = e;
        }

        public override string getDescription()
        {
            return "내부 오류: " + e.Message;
        }

        public override BaseFile getIssueFile()
        {
            return file;
        }

        public override string getSummary()
        {
            return "내부문제: " + Path.GetFileName(file.path);
        }
    }
}

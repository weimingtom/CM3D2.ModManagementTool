using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CM3D2.ModManager.Utils;

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
    }
}

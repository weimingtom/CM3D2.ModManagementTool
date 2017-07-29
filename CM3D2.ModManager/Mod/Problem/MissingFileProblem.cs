using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CM3D2.ModManager.Utils;

namespace CM3D2.ModManager.Mod.Problem
{
    //대상 파일에서 요청되는 파일이 없는경우
    public class MissingFileProblem : BaseProblem
    {
        public ReferenceFile modFile;
        public string request;

        public MissingFileProblem(ReferenceFile file, string request)
        {
            this.modFile = file;
            this.request = request;
        }

        public override string getDescription()
        {
            return "파일 없음: " + request;
        }
    }
}

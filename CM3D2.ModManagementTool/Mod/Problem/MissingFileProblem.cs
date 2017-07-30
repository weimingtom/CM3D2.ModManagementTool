using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CM3D2.ModManagementTool.Utils;
using System.IO;
using CM3D2.ModManagementTool.Mod.File;

namespace CM3D2.ModManagementTool.Mod.Problem
{
    //대상 파일에서 요청되는 파일이 없는경우
    public class MissingFileProblem : BaseProblem
    {
        public ReferenceFile file;
        public string request;

        public MissingFileProblem(ReferenceFile file, string request)
        {
            this.file = file;
            this.request = request;
        }

        public override string getDescription()
        {
            return "파일 없음: " + request;
        }

        public override BaseFile getIssueFile()
        {
            return file;
        }

        public override string getSummary()
        {
            return "파일누락: " + Path.GetFileName(file.path);
        }
    }
}

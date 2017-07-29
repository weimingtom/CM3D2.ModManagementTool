using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CM3D2.ModManager.Utils;

namespace CM3D2.ModManager.Mod.Problem
{
    public class DuplicateProblem : BaseProblem
    {
        public BaseFile file;

        public DuplicateProblem(BaseFile file)
        {
            this.file = file;
        }

        public override string getDescription()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("파일이 두개이상 존재합니다.\r\n");
            builder.Append(file.dumpFile(file.path, file.relativePath, "\t") + "\r\n");
            foreach (BaseFile file in file.duplicateFiles)
            {
                builder.Append(file.dumpFile(file.path, file.relativePath, "\t") + "\r\n");
            }
            return "파일 중복";
        }
    }
}

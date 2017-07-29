﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CM3D2.ModManager.Utils;

namespace CM3D2.ModManager.Mod.Problem
{
    class InvalidCMFileProblem : BaseProblem
    {
        private BaseFile file;

        public InvalidCMFileProblem(BaseFile file)
        {
            this.file = file;
        }

        public override string getDescription()
        {
            return "손상된 파일: " + file.path;
        }

        public override BaseFile getIssueFile()
        {
            return file;
        }
    }
}

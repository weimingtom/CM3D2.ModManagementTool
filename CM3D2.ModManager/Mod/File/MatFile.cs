using System.IO;

namespace CM3D2.ModManager.Utils
{
    class MatFile : BaseFile
    {
        public MatFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public MatFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }
}
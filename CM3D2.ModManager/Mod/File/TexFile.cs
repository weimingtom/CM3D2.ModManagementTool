using System.IO;

namespace CM3D2.ModManager.Mod.File
{
    class TexFile : BaseFile
    {
        public TexFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }
        
        public TexFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }
}
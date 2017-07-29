using System.IO;

namespace CM3D2.ModManager.Mod.File
{
    class ModelFile : BaseFile
    {
        public ModelFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public ModelFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }
}
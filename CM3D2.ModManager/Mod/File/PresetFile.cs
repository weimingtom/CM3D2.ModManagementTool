using System.IO;

namespace CM3D2.ModManager.Utils
{
    class PresetFile : BaseFile
    {
        public PresetFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public PresetFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }
}
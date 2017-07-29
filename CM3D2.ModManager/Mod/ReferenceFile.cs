using System.Collections.Generic;
using System.IO;

namespace CM3D2.ModManager.Utils
{
    class ReferenceFile : BaseFile
    {
        //이 파일이 가지고 있는 외부파일(이 파일이 사용하는 파일의) 레퍼런스, Verify 이후 생성됩니다.
        protected List<string> references = new List<string>();
        protected bool isFromCache = false;

        public ReferenceFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public ReferenceFile(BinaryReader reader, string root) : base(reader, root)
        {
            int count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                references.Add(reader.ReadString());
            }

            isFromCache = true;
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);

            writer.Write(references.Count);
            foreach (string s in references)
            {
                writer.Write(s);
            }
        }
    }
}
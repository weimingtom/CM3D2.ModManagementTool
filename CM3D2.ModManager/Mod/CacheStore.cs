using System.Collections.Generic;
using System.IO;
using System.Linq;
using CM3D2.ModManager.Mod.File;

namespace CM3D2.ModManager.Mod
{
    public class CacheStore
    {
        public readonly List<string> relativePaths = new List<string>();
        private Dictionary<string, List<string>> references = new Dictionary<string, List<string>>();

        public void Clear()
        {
            relativePaths.Clear();
            references.Clear();
        }
        
        public void Load(BinaryReader reader)
        {
            relativePaths.Clear();
            references.Clear();

            int relativeCount = reader.ReadInt32();
            for (int i = 0; i < relativeCount; i++)
            {
                relativePaths.Add( reader.ReadString() );
            }
            
            int count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                string relativePath = reader.ReadString();
                int referCount = reader.ReadInt32();

                List<string> refers = new List<string>(referCount);
                for (int read = 0; read < referCount; read++)
                {
                    refers.Add( reader.ReadString() );
                }
                references[relativePath] = refers;
            }
        }

        public void RegisterRelativePath(string relativePath)
        {
            this.relativePaths.Add(relativePath);
        }

        //사라진 파일의 레퍼런스 정보를 삭제합니다
        public void CleanUp()
        {
            Dictionary<string, object> cache = new Dictionary<string, object>();
            foreach (string str in relativePaths)
            {
                cache[str] = null;
            }

            var remove = references.Where(item => !cache.ContainsKey(item.Key));
            foreach (var setPair in remove)
            {
                references.Remove(setPair.Key);
            }
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(relativePaths.Count);
            foreach (var relativePath in relativePaths)
            {
                writer.Write(relativePath);
            }
            
            writer.Write(references.Count);
            foreach(var set in references)
            {
                writer.Write(set.Key);
                writer.Write(set.Value.Count);

                foreach (var refer in set.Value)
                {
                    writer.Write(refer);
                }
            }
        }

        public List<string> QueryReferences(string relativePath)
        {
            if (!references.ContainsKey(relativePath))
            {
                return null;
            }
            return references[relativePath];
        }

        public void RegisterReference(ReferenceFile referenceFile)
        {
            references[referenceFile.relativePath] = referenceFile.references;
        }
    }
}
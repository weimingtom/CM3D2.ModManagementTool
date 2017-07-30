using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CM3D2.ModManagementTool.Mod.File;
using CM3D2.ModManagementTool.Utils;

namespace CM3D2.ModManagementTool.Mod
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
        
        public void Load(BinaryReader reader, CacheLoadOption option)
        {
            relativePaths.Clear();
            references.Clear();

            if (option == CacheLoadOption.NO_CACHE)
            {
                return;
            }

            int bytesLen = reader.ReadInt32();
            if (option != CacheLoadOption.READ_ONLY_REFERENCE)
            {
                int relativeCount = reader.ReadInt32();
                
                for (int i = 0; i < relativeCount; i++)
                {
                    string relative = reader.ReadString();
                    try //잘못된 경로를 일단 넘어감
                    {
                        if (option == CacheLoadOption.READ_ALL_CHECK_EXIST &&
                            !System.IO.File.Exists(ConfigManager.Single.relativePathToAbsolutePath(relative)))
                        {
                            continue;
                        }
                    }
                    catch(ArgumentException ae)
                    {
                    }
                    relativePaths.Add(relative);
                }
            }
            else
            {
                reader.BaseStream.Seek(bytesLen, SeekOrigin.Current);
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

        public void UnregisterRelativePaths(List<string> relativePaths)
        {
            Dictionary<string, object> cache = new Dictionary<string, object>();
            foreach (string str in relativePaths)
            {
                cache[str] = null;
            }

            this.relativePaths.RemoveAll(item => cache.ContainsKey(item));
        }
        
        //캐시에 존재하는 RelativePath중 유효하지 않은 경로를 제거합니다
        public void VerifyRelativePaths()
        {
            relativePaths.RemoveAll(item =>
                !System.IO.File.Exists(ConfigManager.Single.relativePathToAbsolutePath(item)));
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
            MemoryStream ms = new MemoryStream();
            BinaryWriter msBinaryWriter = new BinaryWriter( ms );
            
            msBinaryWriter.Write(relativePaths.Count);
            foreach (var relativePath in relativePaths)
            {
                msBinaryWriter.Write(relativePath);
            }

            byte[] buf = ms.ToArray();
            writer.Write( buf.Length );
            writer.BaseStream.Write(buf, 0, buf.Length);
            
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

        public void UnregisterReference(string relativePath)
        {
            references.Remove(relativePath);
        }
    }
}
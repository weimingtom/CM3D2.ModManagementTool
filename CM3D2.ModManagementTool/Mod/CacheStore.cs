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
        internal readonly List<string> relativePaths = new List<string>();
        private Dictionary<string, List<string>> references = new Dictionary<string, List<string>>(); //Reference 파일이 가지고 있는 Reference 정보입니다
        private Dictionary<string, List<string>> includeFiles = new Dictionary<string, List<string>>(); //.mod 파일이 포함하고 있는 추가파일의 목록입니다

        public void Clear()
        {
            relativePaths.Clear();
            references.Clear();
            includeFiles.Clear();
        }

        public void ClearExtraData()
        {
            references.Clear();
            includeFiles.Clear();
        }

        public void ClearPaths()
        {
            relativePaths.Clear();
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

            if (option != CacheLoadOption.READ_ONLY_PATHS)
            {
                ReadStringArrayDict(reader, references);
                ReadStringArrayDict(reader, includeFiles);
            }
        }

        //대상파일을 캐시에서 제외시킵니다
        public void Invalid(string relativePath, bool includeFile)
        {
            if (includeFile)
            {
                this.relativePaths.RemoveAll(item => item == relativePath);
            }

            if(references.ContainsKey(relativePath))
                references.Remove(relativePath);

            if (includeFiles.ContainsKey(relativePath))
                includeFiles.Remove(relativePath);
        }

        public void Invalid(bool includeFile, params BaseFile[] relativePaths)
        {
            Dictionary<string, object> dict = null;
            if (includeFile)
            {
                dict = new Dictionary<string, object>();
            }
            foreach (var relative in relativePaths)
            {
                if (includeFile)
                {
                    dict.Add(relative.relativePath, null);
                }
                if(references.ContainsKey(relative.relativePath))
                    references.Remove(relative.relativePath);

                if (includeFiles.ContainsKey(relative.relativePath))
                    includeFiles.Remove(relative.relativePath);
            }
            
            if (includeFile)
            {
                this.relativePaths.RemoveAll(item => dict.ContainsKey(item));
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

            remove = includeFiles.Where(item => !cache.ContainsKey(item.Key));
            foreach (var setPair in remove)
            {
                includeFiles.Remove(setPair.Key);
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
            
            WriteStringArrayDict(writer, references);
            WriteStringArrayDict(writer, includeFiles);
        }

        private static void ReadStringArrayDict(BinaryReader reader, Dictionary<string, List<string>> dict)
        {
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
                dict[relativePath] = refers;
            }
        }

        private static void WriteStringArrayDict(BinaryWriter writer, Dictionary<string, List<string>> dict)
        {
            writer.Write(dict.Count);
            foreach(var set in dict)
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
        
        public List<string> QueryIncludeFiles(string relativePath)
        {
            if (!includeFiles.ContainsKey(relativePath))
            {
                return null;
            }
            return includeFiles[relativePath];
        }

        public void RegisterIncludeFiles(string relativePath, List<string> includeFiles)
        {
            this.includeFiles[relativePath] = includeFiles;
        }

        public void UnregisterIncludeFiles(string relativePath)
        {
            includeFiles.Remove(relativePath);
        }
    }
}
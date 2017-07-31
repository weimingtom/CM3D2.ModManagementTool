using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;
using System.Threading;
using CM3D2.ModManagementTool.Mod.File;
using CM3D2.ModManagementTool.Mod.Problem;
using CM3D2.ModManagementTool.Utils;

namespace CM3D2.ModManagementTool.Mod
{
    class ModContainer
    {
        //주어진 파일들을 삭제합니다.
        public void DeleteFile(params BaseFile[] files)
        {
            foreach (var file in files)
            {
                System.IO.File.Delete(file.path);
                CacheStore.Invalid(file.relativePath, true);
            }
        }

        //dest를 삭제하고 dest의 경로로 src 파일을 옮깁니다.
        public void OverMoveFile(BaseFile src, BaseFile dest)
        {
            System.IO.File.Delete(dest.path);
            System.IO.File.Move(src.path, dest.path);
            
            CacheStore.Invalid(src.relativePath, true);
            CacheStore.Invalid(dest.relativePath, false);
        }

        //파일을 이동합니다
        public void MoveFile(BaseFile file, string destPath)
        {
            System.IO.File.Move(file.path, destPath);
            
            CacheStore.Invalid(file.relativePath, true);
            CacheStore.Invalid(destPath, false);
        }

        public event MessageReceiver messages;
        public delegate void MessageReceiver(string message);

        private static ModContainer single;
        public static ModContainer Single
        {
            get
            {
                return single;
            }
        }

        public static void createModContainer(string folder)
        {
            createModContainer(folder, null);
        }

        public static void createModContainer(string folder, MessageReceiver receiver)
        {
            single = new ModContainer(folder);

            if(receiver != null)
            {
                single.messages += receiver;
            }
        }

        private const string CACHE = @"\CM3D2.ModManager.ModListCache";

        private readonly ModDictionary fileNameDict = new ModDictionary(true);
        public BaseFile queryFile(string name)
        {
            return fileNameDict.query(name);
        }
        public void foreachFiles(ModDictionary.forEachItems each)
        {
            fileNameDict.forEach(each);
        }

        public readonly CacheStore CacheStore = new CacheStore();

        private bool analyzed = false;

        public readonly string rootDir;
        public ModContainer(string path)
        {
            this.rootDir = path;
        }

        public string toRelativePath(string path)
        {
            return path.Replace(this.rootDir, "");
        }

        public void LoadFileList(CacheLoadOption option)
        {
            CacheStore.Clear();
            
            if(!Directory.Exists(rootDir))
            {
                throw new Exception("대상 폴더가 존재하지 않습니다.");
            }

            if( System.IO.File.Exists(rootDir + @"\CM3D2.ModManager.ModListCache") && option != CacheLoadOption.NO_CACHE )
            {
                readCache(option);

                if (option == CacheLoadOption.READ_ONLY_REFERENCE)
                {
                    readFolder();
                }
            }
            else
            {
                readFolder();
            }
            
            Reload();
        }

        public void RebuildPaths()
        {
            CacheStore.ClearPaths();
            readFolder();
        }

        public void Reload()
        {
            fileNameDict.Clear();
            List<string> invalids = new List<string>();
            foreach (string relativePath in CacheStore.relativePaths)
            {
                messages("로드: " + relativePath);

                BaseFile mod = null;
                try
                {
                    mod = BaseFile.createFileFromPath(rootDir, relativePath);
                }
                catch (FileNotFoundException fne)
                {
                    invalids.Add(relativePath);
                }
                if(mod == null)
                {
                    continue;
                }
                fileNameDict.insert( FileHelper.relativePathToAbsoultePath(rootDir, relativePath) , mod);
            }
            
            CacheStore.UnregisterRelativePaths(invalids);
        }

        public void analyzeMods(bool force)
        {
            if(analyzed && !force)
            {
                return;
            }

            fileNameDict.forEach(item =>
            {
                messages("검증: " + toRelativePath(item.path) );
                item.Verify();
            });

            analyzed = true;
        }

        public void dumpErrorMessages(string name)
        {
            StreamWriter writer = new StreamWriter(rootDir + "\\" + name);

            fileNameDict.forEach( item => dumpErrorMessages(item, writer) );

            writer.Close();
        }

        private void dumpErrorMessages(BaseFile file, StreamWriter writer)
        {
            if (file.errors.Count != 0)
            {
                writer.WriteLine(file.relativePath);
                writer.WriteLine("--------------------");

                foreach (BaseProblem message in file.errors)
                {
                    writer.WriteLine(message.getDescription());
                }

                writer.WriteLine("");
                writer.WriteLine("");
            }
        }

        private void readCache(CacheLoadOption option)
        {
            messages("캐시 파일 읽는중");
            BinaryReader reader = new BinaryReader( new FileStream(rootDir + CACHE, FileMode.Open) );

            CacheStore.Load(reader, option);

            reader.Close();
        }
        
        public void writeCache()
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(rootDir + CACHE, FileMode.Create));

            CacheStore.Save(writer);

            writer.Close();
        }

        private void readFolder()
        {
            foreach(string path in Directory.EnumerateFiles(rootDir, "*.*", SearchOption.AllDirectories))
            {
                string relativePath = toRelativePath(path);
                messages("탐색: " + relativePath);
                CacheStore.RegisterRelativePath(relativePath);
            }
        }

        public void deleteCache()
        {
            System.IO.File.Delete(rootDir + CACHE);
        }
    }
}

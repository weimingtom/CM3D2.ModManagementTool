using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

namespace CM3D2.ModManager.Utils
{
    class ModContainer
    {
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

            single.Init();
        }

        private const string CACHE = @"\CM3D2.ModManager.ModListCache";

        private ModDictionary fileNameDict = new ModDictionary(true);

        public BaseFile queryFile(string name)
        {
            return fileNameDict.query(name);
        }

        private bool analyzed = false;

        public readonly string rootDir;
        public ModContainer(string path)
        {
            this.rootDir = path;
        }

        public string trimPath(string path)
        {
            return path.Replace(this.rootDir, "");
        }

        protected void Init()
        {
            if(!Directory.Exists(rootDir))
            {
                throw new Exception("대상 폴더가 존재하지 않습니다.");
            }

            if( File.Exists(rootDir + @"\CM3D2.ModManager.ModListCache") )
            {
                readCache();
            }
            else
            {
                readFolder();
            }
        }

        public void analyzeMods(bool force)
        {
            if(analyzed && !force)
            {
                return;
            }

            fileNameDict.forEach(item =>
            {
                messages("검증: " + trimPath(item.path) );
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
            if (file.errorMessages.Count != 0)
            {
                writer.WriteLine(file.relativePath);
                writer.WriteLine("--------------------");

                foreach (string message in file.errorMessages)
                {
                    writer.WriteLine(message);
                }

                writer.WriteLine("");
                writer.WriteLine("");
            }
        }

        private void readCache()
        {
            messages("캐시 파일 읽는중");
            BinaryReader reader = new BinaryReader( new FileStream(rootDir + CACHE, FileMode.Open) );

            void insertIfExist(BaseFile file)
            {
                if (!File.Exists(file.path))
                {
                    return;
                }
                fileNameDict.insert(file.path, file);
            }

            int count;
            count = reader.ReadInt32();
            for(int i = 0; i < count; i++)
            {
                insertIfExist(new ModFile(reader, rootDir));
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                insertIfExist(new MenuFile(reader, rootDir));
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                insertIfExist(new TexFile(reader, rootDir));
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                insertIfExist(new MatFile(reader, rootDir));
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                insertIfExist(new ModelFile(reader, rootDir));
            }

            count = reader.ReadInt32();
            for (int i = 0; i < count; i++)
            {
                insertIfExist(new PresetFile(reader, rootDir));
            }

            reader.Close();
        }

        public void refreshCache()
        {

        }

        public void writeCache()
        {
            BinaryWriter writer = new BinaryWriter(new FileStream(rootDir + CACHE, FileMode.Create));

            writer.Write(fileNameDict.modFiles.Count);
            foreach(BaseFile file in fileNameDict.modFiles.Values)
            {
                file.Save(writer);
            }

            writer.Write(fileNameDict.menuFiles.Count);
            foreach (BaseFile file in fileNameDict.menuFiles.Values)
            {
                file.Save(writer);
            }

            writer.Write(fileNameDict.texFiles.Count);
            foreach (BaseFile file in fileNameDict.texFiles.Values)
            {
                file.Save(writer);
            }

            writer.Write(fileNameDict.matFiles.Count);
            foreach (BaseFile file in fileNameDict.matFiles.Values)
            {
                file.Save(writer);
            }

            writer.Write(fileNameDict.modelFiles.Count);
            foreach (BaseFile file in fileNameDict.modelFiles.Values)
            {
                file.Save(writer);
            }

            writer.Write(fileNameDict.presetFiles.Count);
            foreach (BaseFile file in fileNameDict.presetFiles.Values)
            {
                file.Save(writer);
            }

            writer.Close();
        }

        private void readFolder()
        {
            List<string> paths = new List<string>(); //Better Performance?

            foreach(string path in Directory.EnumerateFiles(rootDir, "*.*", SearchOption.AllDirectories))
            {
                messages("탐색: " + trimPath(path));
                paths.Add(path);
            }

            foreach (string path in paths)
            {
                string relativePath = trimPath(path);
                messages("로드: " + relativePath);

                BaseFile mod = BaseFile.createFileFromPath(rootDir, relativePath);
                if(mod == null)
                {
                    continue;
                }
                fileNameDict.insert(path, mod);
            }
        }

        public void deleteCache()
        {
            File.Delete(rootDir + CACHE);
        }
    }
}

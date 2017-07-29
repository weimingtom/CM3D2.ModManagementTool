﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;
using CM3D2.ModManager.Mod.File;
using CM3D2.ModManager.Mod.Problem;
using CM3D2.ModManager.Utils;

namespace CM3D2.ModManager.Mod
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

            if( System.IO.File.Exists(rootDir + @"\CM3D2.ModManager.ModListCache") )
            {
                readCache();
            }
            else
            {
                readFolder();
            }
            
            foreach (string relativePath in CacheStore.relativePaths)
            {
                messages("로드: " + relativePath);

                BaseFile mod = BaseFile.createFileFromPath(rootDir, relativePath);
                if(mod == null)
                {
                    continue;
                }
                fileNameDict.insert( Path.GetFullPath(rootDir + relativePath) , mod);
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

        private void readCache()
        {
            messages("캐시 파일 읽는중");
            BinaryReader reader = new BinaryReader( new FileStream(rootDir + CACHE, FileMode.Open) );

            CacheStore.Load(reader);

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
            CacheStore.Clear();

            foreach(string path in Directory.EnumerateFiles(rootDir, "*.*", SearchOption.AllDirectories))
            {
                string relativePath = trimPath(path);
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

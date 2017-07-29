using System;
using System.Collections.Generic;
using System.IO;

using CM3D2.ModManager.Mod.Problem;

namespace CM3D2.ModManager.Utils
{
    /**
 * 파일의 정보를 기록하는데 쓰이는 기초 클래스
*/

    public class BaseFile
    {
        public static BaseFile createFileFromPath(string rootDir, string relativePath)
        {
            string path = Path.GetFullPath(rootDir + relativePath);
            if( !File.Exists(path) )
            {
                return null;
            }

            string exten = Path.GetExtension(path).ToLower();
            if (exten == CMExtensions.EXTENSION_MOD)
            {
                return new ModFile(rootDir, relativePath);
            }
            else if (exten == CMExtensions.EXTENSION_MENU)
            {
                return new MenuFile(rootDir, relativePath);
            }
            else if (exten == CMExtensions.EXTENSION_TEX)
            {
                return new TexFile(rootDir, relativePath);
            }
            else if (exten == CMExtensions.EXTENSION_MAT)
            {
                return new MatFile(rootDir, relativePath);
            }
            else if (exten == CMExtensions.EXTENSION_MODEL)
            {
                return new ModelFile(rootDir, relativePath);
            }
            else if (exten == CMExtensions.EXTENSION_PRESET)
            {
                return new PresetFile(rootDir, relativePath);
            }

            return null;
        }

        public static void saveBasicData(BaseFile file, BinaryWriter writer)
        {
            writer.Write(file.relativePath);

            writer.Write(file.duplicateFiles.Count);
            foreach (BaseFile dup in file.duplicateFiles)
            {
                saveBasicData(dup, writer);
            }
        }

        /**
            캐시되어 있거나 폴더 검색으로 얻은 경로

            Verify의 실행전 반드시 존재여부를 확인해야 합니다.
        */
        public readonly string path;

        public readonly string root;
        /**
         * 모드 폴더를 제외한 경로
        */
        public readonly string relativePath;

        public readonly List<BaseFile> duplicateFiles = new List<BaseFile>();

        public readonly List<BaseProblem> errors = new List<BaseProblem>();

        public BaseFile(string root, string path)
        {
            this.path = Path.GetFullPath(root + path);

            this.root = root;
            this.relativePath = path;
        }
        
        /**
         * 저장된 데이터로 부터 파일정보를 만듭니다
        */
        public BaseFile(BinaryReader reader, string root)
        {
            this.root = root;
            this.relativePath = reader.ReadString();

            this.path = Path.GetFullPath(root + relativePath);

            int count = reader.ReadInt32();
            for(int i = 0; i < count; i++)
            {
                BaseFile duplicate = new BaseFile(reader, root);
                duplicateFiles.Add(duplicate);
            }
        }

        /**
            대상파일의 문제점을 찾고, 존재하는경우 errorList에 넣습니다.
        */
        public virtual void Verify()
        {
            errors.Clear();

            if (duplicateFiles.Count != 0) {
                errors.Add(new DuplicateProblem(this));
            }
        }

        /**
         * 대상 파일의 정보를 덤프합니다.
         * 
         * Verify에서 주로 쓰이기 때문에, 중복 체크가 가능한 파일 크기와 마지막 수정일이 포함됩니다.
        */
        public string dumpFile(string path, string displayPath, string offset = "")
        {
            if(!File.Exists(path))
            {
                return offset + displayPath + " 파일이 없습니다.";
            }

            DateTime dt = File.GetLastWriteTime(path);

            return offset + displayPath + "\r\n" +
                   offset + "\t마지막 수정: " + dt.ToLongDateString() + " " + dt.ToLongTimeString() + "\r\n" +
                   offset + "\t파일 크기: " + new FileInfo(path).Length;
        }

        /**
            대상 파일의 정보를 저장합니다
        */
        public virtual void Save(BinaryWriter writer)
        {
            saveBasicData(this, writer);
        }

        public static bool isCM3D2Extension(string exten)
        {
            exten = exten.ToLower();
            return exten == CMExtensions.EXTENSION_MOD || exten == CMExtensions.EXTENSION_MENU || exten == CMExtensions.EXTENSION_TEX || exten == CMExtensions.EXTENSION_MAT || exten == CMExtensions.EXTENSION_MODEL || exten == CMExtensions.EXTENSION_PRESET;
        }
    }
}
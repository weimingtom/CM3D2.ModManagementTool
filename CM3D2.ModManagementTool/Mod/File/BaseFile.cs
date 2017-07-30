using System;
using System.Collections.Generic;
using System.IO;

using CM3D2.ModManagementTool.Mod.Problem;
using CM3D2.ModManagementTool.Utils;

namespace CM3D2.ModManagementTool.Mod.File
{
    /**
     * 파일의 정보를 기록하는데 쓰이는 기초 클래스
    */

    public class BaseFile
    {
        public static BaseFile createFileFromPath(string rootDir, string relativePath)
        {
            string path = FileHelper.relativePathToAbsoultePath(rootDir, relativePath);
            
            /*
            if( !System.IO.File.Exists(path) )
            {
                throw new FileNotFoundException();
            }
            */

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
            this.path = FileHelper.relativePathToAbsoultePath(root, path);

            this.root = root;
            this.relativePath = path;

            duplicateFiles.Add(this);
        }

        /**
            대상파일의 문제점을 찾고, 존재하는경우 errorList에 넣습니다.
        */
        public virtual void Verify()
        {
            errors.Clear();

            if (duplicateFiles.Count != 1) {
                errors.Add(new DuplicateProblem(this));
            }
        }

        public static bool isContainsCM3D2ExtensionString(string str)
        {
            return str.Contains(CMExtensions.EXTENSION_MAT) || str.Contains(CMExtensions.EXTENSION_MENU)
                   || str.Contains(CMExtensions.EXTENSION_MOD) || str.Contains(CMExtensions.EXTENSION_MODEL)
                   || str.Contains(CMExtensions.EXTENSION_PRESET) || str.Contains(CMExtensions.EXTENSION_TEX);
        }

        public static bool isCM3D2Extension(string exten)
        {
            exten = exten.ToLower();
            return exten == CMExtensions.EXTENSION_MOD || exten == CMExtensions.EXTENSION_MENU || exten == CMExtensions.EXTENSION_TEX || exten == CMExtensions.EXTENSION_MAT || exten == CMExtensions.EXTENSION_MODEL || exten == CMExtensions.EXTENSION_PRESET;
        }
    }
}
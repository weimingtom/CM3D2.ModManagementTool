using System;
using System.Collections.Generic;
using System.IO;

using CM3D2.ModManager.Mod.Problem;

namespace CM3D2.ModManager.Utils
{
    /**
 * ������ ������ ����ϴµ� ���̴� ���� Ŭ����
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
            ĳ�õǾ� �ְų� ���� �˻����� ���� ���

            Verify�� ������ �ݵ�� ���翩�θ� Ȯ���ؾ� �մϴ�.
        */
        public readonly string path;

        public readonly string root;
        /**
         * ��� ������ ������ ���
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
         * ����� �����ͷ� ���� ���������� ����ϴ�
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
            ��������� �������� ã��, �����ϴ°�� errorList�� �ֽ��ϴ�.
        */
        public virtual void Verify()
        {
            errors.Clear();

            if (duplicateFiles.Count != 0) {
                errors.Add(new DuplicateProblem(this));
            }
        }

        /**
         * ��� ������ ������ �����մϴ�.
         * 
         * Verify���� �ַ� ���̱� ������, �ߺ� üũ�� ������ ���� ũ��� ������ �������� ���Ե˴ϴ�.
        */
        public string dumpFile(string path, string displayPath, string offset = "")
        {
            if(!File.Exists(path))
            {
                return offset + displayPath + " ������ �����ϴ�.";
            }

            DateTime dt = File.GetLastWriteTime(path);

            return offset + displayPath + "\r\n" +
                   offset + "\t������ ����: " + dt.ToLongDateString() + " " + dt.ToLongTimeString() + "\r\n" +
                   offset + "\t���� ũ��: " + new FileInfo(path).Length;
        }

        /**
            ��� ������ ������ �����մϴ�
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
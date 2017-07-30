using System.IO;

using Injected;
using System;
using System.Diagnostics;
using CM3D2.ModManagementTool.Mod;
using CM3D2.ModManagementTool.Mod.File;

namespace CM3D2.ModManagementTool.Utils
{
    public abstract class Readable
    {
        protected abstract Stream OpenIfCan();
        protected abstract byte[] ReadAll();
    }

    public class CM3D2Readable : Readable
    {
        private AFileBase fb;

        public CM3D2Readable(AFileBase fb)
        {
            if(!fb.IsValid())
            {
                throw new Exception("Valid check failure");
            }
        }

        protected override Stream OpenIfCan()
        {
            throw new NotImplementedException();
        }

        protected override byte[] ReadAll()
        {
            return fb.ReadAll();
        }
    }

    public class FileReadable : Readable
    {
        private string path;

        public FileReadable(string path)
        {
            this.path = path;
            if( !File.Exists(path) )
            {
                throw new Exception("File not exist: " + path);
            }
        }

        protected override Stream OpenIfCan()
        {
            return new FileStream(path, FileMode.Open);
        }

        protected override byte[] ReadAll()
        {
            return File.ReadAllBytes(path);
        }
    }

    static class FileHelper
    {
        public static bool isExist(string name)
        {
            BaseFile file = ModContainer.Single.queryFile(name);

            if(file != null)
            {
                return true;
            }
            
            AFileBase _fileBase = GameUty.FileOpen(name);

            if( _fileBase.IsValid() )
            {
                _fileBase.Dispose();
                return true;
            }

            _fileBase.Dispose();
            return false;
        }

        public static Readable GetReadable(string name)
        {
            AFileBase _fileBase = GameUty.FileOpen(name);

            if (_fileBase.IsValid())
            {
                return new CM3D2Readable(_fileBase);
            }

            BaseFile file = ModContainer.Single.queryFile(name);

            if (file != null)
            {
                return new FileReadable( file.path );
            }

            return null;
        }

        public static string relativePathToAbsoultePath(string root, string relative)
        {
            return Path.GetFullPath(root + relative);
        }

        public static void openInExplorer(string path)
        {
            Process.Start("explorer.exe", $"/select,\"{path}\"");
        }
        
        /**
         * 대상 파일의 정보를 덤프합니다.
         * 
         * Verify에서 주로 쓰이기 때문에, 중복 체크가 가능한 파일 크기와 마지막 수정일이 포함됩니다.
        */
        public static string dumpFile(string path, string displayPath, string offset = "")
        {
            if(!System.IO.File.Exists(path))
            {
                return offset + displayPath + " 파일이 없습니다.";
            }

            DateTime dt = System.IO.File.GetLastWriteTime(path);

            return offset + displayPath + "\r\n" +
                   offset + "\t마지막 수정: " + dt.ToLongDateString() + " " + dt.ToLongTimeString() + "\r\n" +
                   offset + "\t파일 크기: " + new FileInfo(path).Length;
        }
    }
}

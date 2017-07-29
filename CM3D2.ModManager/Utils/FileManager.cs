using System.IO;

using Injected;
using System;

namespace CM3D2.ModManager.Utils
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
            Injected.AFileBase _fileBase = Injected.GameUty.FileOpen(name);

            if( _fileBase.IsValid() )
            {
                return true;
            }

            BaseFile file = ModContainer.Single.queryFile(name);

            if(file != null)
            {
                return true;
            }

            return false;
        }

        public static Readable GetReadable(string name)
        {
            Injected.AFileBase _fileBase = Injected.GameUty.FileOpen(name);

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
    }
}

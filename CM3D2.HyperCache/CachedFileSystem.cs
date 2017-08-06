using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CM3D2.HyperCache
{
    //Reference https://github.com/asm256/CM3D2.ArchiveReplacer/blob/master/CM3D2.ArchiveReplacer.Hook.cs :AFile
    public class WindowsFile : AFileBase
    {
        public override DLLFile.Data object_data
        {
            get
            {
                Console.WriteLine("tried DLL Pointer for: " + path);
                throw new NotImplementedException();
            }
        }
        private string path;
        private FileStream stream;

        public WindowsFile(string path)
        {
            this.path = path;
            try
            {
                stream = new FileStream(path, FileMode.Open);
            }
            catch(Exception e)
            {
                Console.WriteLine("failed open file for: " + path);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                stream = null;
            }
        }

        public override int GetSize()
        {
            return (int) stream.Length;
        }

        public override bool IsValid()
        {
            if(stream == null)
            {
                Console.WriteLine("invalid file for: " + path);
            }
            return stream != null;
        }

        public override int Read(ref byte[] f_byBuf, int f_nReadSize)
        {
            return stream.Read(f_byBuf, 0, f_nReadSize);
        }

        public override byte[] ReadAll()
        {
            int len = (int)stream.Length;
            byte[] buf = new byte[len];
            stream.Read(buf, 0, len);
            return buf;
        }

        public override int Seek(int f_unPos, bool absolute_move)
        {
            return (int)stream.Seek(f_unPos, absolute_move ? SeekOrigin.Begin : SeekOrigin.Current);
        }

        public override int Tell()
        {
            return (int)stream.Position;
        }

        protected override void Dispose(bool is_release_managed_code)
        {
            try
            {
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }

    public class CachedFileSystem : FileSystemArchive
    {
        private Dictionary<string, string> files = new Dictionary<string, string>();
        private Dictionary<string, string> internalNameFiles = new Dictionary<string, string>();
        private string[] modFiles;
        private string root;

        private static CachedFileSystem system;

        public static string[] GetModFiles()
        {
            return system.modFiles;//((CachedFileSystem) GameUty.FileSystem).modFiles;
        }

        public CachedFileSystem()
        {
            system = this;
            string fullPath = System.Environment.CurrentDirectory;

            BinaryReader reader = null;
            try
            {
                reader = new BinaryReader(new FileStream(Path.Combine(fullPath, "CM3D2.HyperCache.dat"), FileMode.Open));
                root = reader.ReadString();

                long count = reader.ReadInt64();
                List<string> mods = new List<string>();
                for (int i = 0; i < count; i++)
                {
                    string relativePath = reader.ReadString();
                    string internalName = reader.ReadString();

                    if (relativePath.EndsWith(".mod"))
                    {
                        mods.Add(Path.Combine(root, relativePath));
                    }
                    else
                    {
                        files[Path.GetFileName(relativePath).ToLower()] = relativePath;
                        if (internalName != "")
                        {
                            internalNameFiles[internalName.ToLower()] = relativePath;
                        }
                    }
                }

                modFiles = mods.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                try
                {
                    reader.Close();
                }
                catch
                {

                }
            }
            
        }

        public override bool IsExistentFile(string file_name)
        {
            string lower = file_name.ToLower();

            if(internalNameFiles.ContainsKey(lower))
            {
                return true;
            }

            return files.ContainsKey(lower) ? true : base.IsExistentFile(file_name);
        }

        public override AFileBase FileOpen(string file_name)
        {
            string lower = file_name.ToLower();

            if (internalNameFiles.ContainsKey(lower))
            {
                return new WindowsFile(Path.GetFullPath(root + internalNameFiles[lower]));
            }

            if ( files.ContainsKey(lower))
            {
                return new WindowsFile(Path.GetFullPath(root + files[lower]));
            }
            return base.FileOpen(file_name);
        }

        public override string[] GetList(string f_str_path, ListType type)
        {
            string[] list = base.GetList(f_str_path, type);
            if (type == ListType.AllFile)
            {
                HashSet<string> duplicateTest = new HashSet<string>();
                foreach (var s in list)
                {
                    duplicateTest.Add(s);
                }

                var ll = from p in files
                         where Regex.IsMatch(p.Key, string.Format("\\.{0}$", f_str_path)) && !duplicateTest.Contains(p.Key)
                         select p.Key;

                return ll.Concat(list).ToArray();
            }
            return list;
        }
    }
}

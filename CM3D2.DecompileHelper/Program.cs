using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using Utility;

namespace CM3D2.DecompileHelper
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            Injected.DLLManager.Initialize();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            Injected.FileSystemWindows windows = new Injected.FileSystemWindows();
            windows.SetBaseDirectory( Path.GetFullPath(".\\") );
            windows.AddFolder("Mod");

            var info = Directory.GetParent(@"C:\KISS\CM3D2\Mod\[upkiss3101] 3가지 얼굴 행태를 추가합니다\GameData\menu\menu\kai\kai0face006_i_.menu");
            while(true)
            {
                if(info.Name == "Mod")
                {
                    break;
                }
                windows.AddAutoPath(info.FullName);
                info = info.Parent;
            }

            //windows.AddAutoPathForAllFolder();

            Console.WriteLine("FileSystem Init Time: " + watch.ElapsedMilliseconds);
            //windows.AddAutoPathForAllFolder();
            string fn = @"Mod\[upkiss3101] 3가지 얼굴 행태를 추가합니다\GameData\menu\menu\kai\kai0face006_i_.menu";

            if(!windows.IsValid())
            {
                Console.WriteLine("FileSystem is NOT valid...");
            }

            Console.WriteLine("Enter to Open/Read from FileSystemWindows");
            Console.ReadLine();

            Injected.AFileBase file = windows.FileOpen( Path.GetFileName(fn) );
            dump(fn, file);
            File.WriteAllBytes("a_menuDump.dat", file.ReadAll());

            /*
            Injected.AFileBase file = Injected.GameUty.FileOpen( Injected.GameUty.MenuFiles[2] );
            byte[] dummy = new byte[8];
            BinaryWriter writer = new BinaryWriter(new MemoryStream(dummy));

            writer.Write((long)00003939);

            writer.Flush();
            writer.Close();

            byte[] _valid = file.ReadAll();
            Marshal.Copy(dummy, 0, file.object_data.object_pointer, 8);

            Console.WriteLine("Enter to Do 'Replaced' data with csvParser");
            Console.ReadLine();
            IntPtr parser = Injected.DLLManager.cm3d2dll.function_.csv_parser.CreateCsvParser();
            Injected.DLLManager.cm3d2dll.function_.csv_parser.Open(parser, file.object_data.object_pointer);
            */

            /*
            dump(Injected.GameUty.MenuFiles[0]);
            Console.ReadLine();

            dump(Injected.GameUty.MenuFiles[100]);
            Console.ReadLine();
            */
            //Utility.MinidumpWriter.MakeDump(@"C:\KISS\CM3D2\afilebase.dmp", Process.GetCurrentProcess().Id);
        }

        static void dump(string fn)
        {
            Injected.AFileBase file = Injected.GameUty.FileOpen(fn);


            dump(fn, file);

        }

        static void dump(string fn, Injected.AFileBase file)
        {
            Console.WriteLine("file name: " + fn);
            Console.WriteLine("file pointer: " + file.object_data.object_pointer.ToString("x8"));

            byte[] origbuf = new byte[40];
            Marshal.Copy(file.object_data.object_pointer, origbuf, 0, 40);
            
            IntPtr system_pointer = Injected.DLLManager.cm3d2dll.function_.file_system.pack.module_handle_;
            IntPtr file_pointer = Injected.DLLManager.cm3d2dll.function_.file.pack.module_handle_;

            BinaryReader binaryReader = new BinaryReader(new MemoryStream(origbuf));
            long data = binaryReader.ReadInt64();

            IntPtr handle = new IntPtr(binaryReader.ReadInt64());

            IntPtr ptr = new IntPtr(data);
            byte[] buf = new byte[1024];

            Marshal.Copy(file.object_data.object_pointer, buf, 0, 1024);
            File.WriteAllBytes("a_" + Path.GetFileNameWithoutExtension(fn) + ".dat", buf);
            Console.WriteLine(ptr.ToString("x8"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace CM3D2.ModManager.Utils
{
    class CMExtensions
    {
        public const string EXTENSION_MOD = ".mod";
        public const string EXTENSION_MENU = ".menu";
        public const string EXTENSION_TEX = ".tex";
        public const string EXTENSION_MAT = ".mat";
        public const string EXTENSION_MODEL = ".model";
        public const string EXTENSION_PRESET = ".preset";
    }

    class ModDictionary
    {
        public Dictionary<string, ModFile> modFiles = new Dictionary<string, ModFile>();
        public Dictionary<string, MenuFile> menuFiles = new Dictionary<string, MenuFile>();
        public Dictionary<string, TexFile> texFiles = new Dictionary<string, TexFile>();
        public Dictionary<string, MatFile> matFiles = new Dictionary<string, MatFile>();
        public Dictionary<string, ModelFile> modelFiles = new Dictionary<string, ModelFile>();
        public Dictionary<string, PresetFile> presetFiles = new Dictionary<string, PresetFile>();

        private bool duplicateCheck;

        public ModDictionary(bool duplicateCheck)
        {
            this.duplicateCheck = duplicateCheck;
        }

        public delegate void forEachItems(BaseFile file);

        public void forEach(forEachItems each)
        {
            foreach (BaseFile file in modFiles.Values)
            {
                each.Invoke(file);
            }

            foreach (BaseFile file in menuFiles.Values)
            {
                each.Invoke(file);
            }

            foreach (BaseFile file in texFiles.Values)
            {
                each.Invoke(file);
            }

            foreach (BaseFile file in matFiles.Values)
            {
                each.Invoke(file);
            }

            foreach (BaseFile file in modelFiles.Values)
            {
                each.Invoke(file);
            }

            foreach (BaseFile file in presetFiles.Values)
            {
                each.Invoke(file);
            }
        }

        public void insert(string path, BaseFile file)
        {
            if(path == null)
            {
                System.Diagnostics.Debug.WriteLine("insert path is null");
                Console.WriteLine("insert path is null");
                return;
            }

            string name = Path.GetFileName(path);

            void insert<Type>(Dictionary<string, Type> store, Type data) where Type: BaseFile
            {
                if (store.ContainsKey(name))
                {
                    if (duplicateCheck)
                    {
                        store[name].duplicateFiles.Add(file);
                    }
                }
                else
                {
                    store.Add(name, data);
                }
            }

            if(file is ModFile)
            {
                insert(modFiles, (ModFile) file);
            }
            else if (file is MenuFile)
            {
                insert(menuFiles, (MenuFile)file);
            }
            else if (file is TexFile)
            {
                insert(texFiles, (TexFile)file);
            }
            else if (file is MatFile)
            {
                insert(matFiles, (MatFile)file);
            }
            else if (file is ModelFile)
            {
                insert(modelFiles, (ModelFile)file);
            }
            else if (file is PresetFile)
            {
                insert(presetFiles, (PresetFile)file);
            }
            else
            {
                throw new Exception("Not manageable BaseFile!");
            }
        }

        public BaseFile query(string name)
        {
            if (modFiles.ContainsKey(name))
            {
                return modFiles[name];
            }

            if (menuFiles.ContainsKey(name))
            {
                return menuFiles[name];
            }

            if (texFiles.ContainsKey(name))
            {
                return texFiles[name];
            }

            if (matFiles.ContainsKey(name))
            {
                return matFiles[name];
            }

            if (modelFiles.ContainsKey(name))
            {
                return modelFiles[name];
            }

            if (presetFiles.ContainsKey(name))
            {
                return presetFiles[name];
            }

            return null;
        }
    }

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

        public readonly List<string> errorMessages = new List<string>();

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
            errorMessages.Clear();

            if (duplicateFiles.Count != 0) {
                errorMessages.Add("파일이 두개이상 존재합니다.");
                errorMessages.Add("\t" + relativePath + "(마지막 수정일: " + File.GetLastWriteTime(path).ToLongDateString() + ")");
                foreach (BaseFile file in duplicateFiles)
                {
                    errorMessages.Add("\t" + file.relativePath + "(마지막 수정일: " + File.GetLastWriteTime(file.path).ToLongDateString() + ")");
                }
            }
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

    class ReferenceFile : BaseFile
    {
        //이 파일이 가지고 있는 외부파일(이 파일이 사용하는 파일의) 레퍼런스, Verify 이후 생성됩니다.
        protected List<string> references = new List<string>();
        protected bool isFromCache = false;

        public ReferenceFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public ReferenceFile(BinaryReader reader, string root) : base(reader, root)
        {
            int count = reader.ReadInt32();

            for (int i = 0; i < count; i++)
            {
                references.Add(reader.ReadString());
            }

            isFromCache = true;
        }

        public override void Save(BinaryWriter writer)
        {
            base.Save(writer);

            writer.Write(references.Count);
            foreach (string s in references)
            {
                writer.Write(s);
            }
        }
    }

    class ModFile : ReferenceFile
    {
        public ModFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public ModFile(BinaryReader reader, string root) : base(reader, root)
        {

        }

        public override void Verify()
        {
            base.Verify();

            if(!isFromCache)
            {
                BinaryReader binaryReader = null;
                try
                {
                    binaryReader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.UTF8);
                    string text = binaryReader.ReadString();
                    if (text != "CM3D2_MOD")
                    {
                        errorMessages.Add("올바르지 않은 모드파일");
                        return;
                    }
                    binaryReader.ReadInt32();
                    binaryReader.ReadString();
                    binaryReader.ReadString();
                    string strMenuName = binaryReader.ReadString();
                    string strCateName = binaryReader.ReadString();
                    string text2 = binaryReader.ReadString();
                    string text3 = binaryReader.ReadString();
                    Injected.MPN mpn = Injected.MPN.null_mpn;
                    try
                    {
                        mpn = (Injected.MPN)((int)Enum.Parse(typeof(Injected.MPN), text3));
                    }
                    catch(Exception e)
                    {
                        errorMessages.Add("올바르지 않은 모드파일");
                        return;
                    }
                    string text4 = string.Empty;
                    if (mpn != Injected.MPN.null_mpn)
                    {
                        text4 = binaryReader.ReadString();
                    }
                    string s = binaryReader.ReadString();
                    binaryReader.ReadInt32();
                    int size = (int)binaryReader.BaseStream.Position;
                    binaryReader.Close();
                    binaryReader = null;
                    using (StringReader stringReader = new StringReader(s))
                    {
                        string empty = string.Empty;
                        string text5;
                        while ((text5 = stringReader.ReadLine()) != null)
                        {
                            string[] array = text5.Split(new char[]
                            {
                    '\t',
                    ' '
                            }, StringSplitOptions.RemoveEmptyEntries);
                            foreach (string value in array)
                            {
                                string lower = value.ToLower();
                                if (lower.Contains("*"))
                                {
                                    continue;
                                }
                                string exten = Path.GetFileName(lower);
                                if (isCM3D2Extension(exten))
                                {
                                    references.Add(value);
                                }
                            }
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    var invalidPathChars = path.Where(Path.GetInvalidPathChars().Contains).ToArray();

                    string dat = string.Join(string.Empty, invalidPathChars);

                    errorMessages.Add("부적절한 문자 때문에 접근할수 없는 경로: " + path);
                }
                catch (Exception e)
                {
                    errorMessages.Add("내부 에러: " + e.Message);
                }
                finally
                {
                    try
                    {
                        if (binaryReader != null)
                            binaryReader.Close();
                    }
                    catch { }
                }
            }

            foreach(string path in references)
            {
                if( !FileHelper.isExist(path) )
                {
                    errorMessages.Add("파일 없음: " + path);
                }
            }
        }
    }

    class MenuFile : ReferenceFile
    {
        public MenuFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public MenuFile(BinaryReader reader, string root) : base(reader, root)
        {

        }

        public override void Verify()
        {
            base.Verify();

            byte[] data = File.ReadAllBytes(this.path);
            BinaryReader binaryReader = null;
            try
            {
                binaryReader = new BinaryReader(new MemoryStream(data), Encoding.UTF8);
                string text = binaryReader.ReadString();
                if (text != "CM3D2_MENU")
                {
                    errorMessages.Add("올바르지 않은 메뉴파일");
                    return;
                }
                binaryReader.ReadInt32();
                string path = binaryReader.ReadString();
                binaryReader.ReadString();
                binaryReader.ReadString();
                binaryReader.ReadString();
                binaryReader.ReadInt32();
                int num = 0;
                string text2 = null;
                string text3 = string.Empty;
                string text4 = string.Empty;
                string empty = string.Empty;
                for (;;)
                {
                    int num2 = (int)binaryReader.ReadByte();
                    text4 = text3;
                    text3 = string.Empty;
                    if (num2 == 0)
                    {
                        break;
                    }
                    for (int i = 0; i < num2; i++)
                    {
                        text3 = text3 + "\"" + binaryReader.ReadString() + "\" ";
                    }
                    if (!(text3 == string.Empty))
                    {
                        string stringCom = Injected.UTY.GetStringCom(text3);
                        string[] stringList = Injected.UTY.GetStringList(text3);

                        foreach (string value in stringList)
                        {
                            string lower = value.ToLower();
                            if (lower.Contains("*"))
                            {
                                continue;
                            }
                            string exten = Path.GetFileName(lower);
                            if (isCM3D2Extension(exten))
                            {
                                references.Add(value);
                            }
                        }
                    }
                }
            }
            catch (ArgumentException ae)
            {
                var invalids = System.IO.Path.GetInvalidPathChars().Select(x => Convert.ToByte(x));

                var found = System.Text.Encoding.Default.GetBytes(path).Intersect(invalids);

                errorMessages.Add("부적절한 문자 때문에 접근할수 없는 경로: " + path);
            }
            catch (Exception e)
            {
                errorMessages.Add("내부 에러: " + e.Message);
            }
            finally
            {
                try
                {
                    if (binaryReader != null)
                        binaryReader.Close();
                }
                catch { }
            }

            foreach (string path in references)
            {
                if (!FileHelper.isExist(path))
                {
                    errorMessages.Add("파일 없음: " + path);
                }
            }
        }
        
    }

    class TexFile : BaseFile
    {
        public TexFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }
        
        public TexFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }

    class MatFile : BaseFile
    {
        public MatFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public MatFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }

    class ModelFile : BaseFile
    {
        public ModelFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public ModelFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }

    class PresetFile : BaseFile
    {
        public PresetFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public PresetFile(BinaryReader reader, string root) : base(reader, root)
        {

        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CM3D2.ModManager.Utils
{
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

            if(!verifyChecked)
            {
                references.Clear();
                BinaryReader binaryReader = null;
                try
                {
                    binaryReader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.UTF8);
                    string text = binaryReader.ReadString();
                    if (text != "CM3D2_MOD")
                    {
                        errors.Add("올바르지 않은 모드파일");
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
                        errors.Add("올바르지 않은 모드파일");
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
                    verifyChecked = true;
                }
                catch (ArgumentException ae)
                {
                    var invalidPathChars = path.Where(Path.GetInvalidPathChars().Contains).ToArray();

                    string dat = string.Join(string.Empty, invalidPathChars);

                    errors.Add("부적절한 문자 때문에 접근할수 없는 경로: " + path);
                }
                catch (Exception e)
                {
                    errors.Add("내부 에러: " + e.Message);
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
                verifyChecked = true;
            }

            foreach(string path in references)
            {
                if( !FileHelper.isExist(path) )
                {
                    errors.Add("파일 없음: " + path);
                }
            }
        }
    }
}
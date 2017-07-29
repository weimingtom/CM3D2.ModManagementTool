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

            if(!isFromCache)
            {
                BinaryReader binaryReader = null;
                try
                {
                    binaryReader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.UTF8);
                    string text = binaryReader.ReadString();
                    if (text != "CM3D2_MOD")
                    {
                        errorMessages.Add("�ùٸ��� ���� �������");
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
                        errorMessages.Add("�ùٸ��� ���� �������");
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

                    errorMessages.Add("�������� ���� ������ �����Ҽ� ���� ���: " + path);
                }
                catch (Exception e)
                {
                    errorMessages.Add("���� ����: " + e.Message);
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
                    errorMessages.Add("���� ����: " + path);
                }
            }
        }
    }
}
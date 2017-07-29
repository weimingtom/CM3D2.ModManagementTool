using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CM3D2.ModManager.Utils
{
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
            
            if (!verifyChecked)
            {
                references.Clear();
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
                    verifyChecked = true;
                }
                catch (ArgumentException ae)
                {
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

            foreach (string path in references)
            {
                if (!FileHelper.isExist(path))
                {
                    errorMessages.Add("파일 없음: " + path);
                }
            }
        }
        
    }
}
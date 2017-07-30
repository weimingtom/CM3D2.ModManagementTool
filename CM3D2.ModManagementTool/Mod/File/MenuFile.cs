using System;
using System.IO;
using System.Linq;
using System.Text;

using CM3D2.ModManagementTool.Mod.Problem;
using CM3D2.ModManagementTool.Utils;

namespace CM3D2.ModManagementTool.Mod.File
{
    class MenuFile : ReferenceFile
    {
        public MenuFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public override void Verify()
        {
            base.Verify();
            
            if (!referenceLoaded)
            {
                references.Clear();
                byte[] data = System.IO.File.ReadAllBytes(this.path);
                BinaryReader binaryReader = null;
                try
                {
                    binaryReader = new BinaryReader(new MemoryStream(data), Encoding.UTF8);
                    string text = binaryReader.ReadString();
                    if (text != "CM3D2_MENU")
                    {
                        errors.Add(new InvalidCMFileProblem(this));
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
                                try
                                {
                                    string lower = value.ToLower();
                                    if (lower.Contains("*") || !isContainsCM3D2ExtensionString(lower))
                                    {
                                        continue;
                                    }
                                    
                                    string exten = Path.GetExtension(lower);
                                    
                                    if (isCM3D2Extension(exten))
                                    {
                                        references.Add(value);
                                    }
                                }
                                catch (ArgumentException ae)
                                {
                                    errors.Add(new InvalidPathProblem(this, value, ae));
                                }
                            }
                        }
                    }
                    OnReferenceLoad();
                }
                catch (ArgumentException ae)
                {
                    errors.Add(new InvalidPathProblem(this, path, ae));
                }
                catch (Exception e)
                {
                    errors.Add(new InternalProblem(this, e));
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
                    errors.Add(new MissingFileProblem(this, path));
                }
            }
        }
        
    }
}
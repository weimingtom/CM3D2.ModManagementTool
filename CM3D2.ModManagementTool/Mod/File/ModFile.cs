using CM3D2.ModManagementTool.Mod.Problem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CM3D2.ModManagementTool.Utils;

namespace CM3D2.ModManagementTool.Mod.File
{
    class ModFile : ReferenceFile
    {
        //이 모드파일이 내장하고 있는 파일
        private List<string> includeFiles;
        
        public ModFile(string path, string trimRoot) : base(path, trimRoot)
        {

        }

        public override void Verify()
        {
            base.Verify();

            includeFiles = ModContainer.Single.CacheStore.QueryIncludeFiles(relativePath);
            
            if(!referenceLoaded || includeFiles == null)
            {
                includeFiles = new List<string>();
                references.Clear();
                BinaryReader binaryReader = null;
                try
                {
                    binaryReader = new BinaryReader(new FileStream(path, FileMode.Open), Encoding.UTF8);
                    string text = binaryReader.ReadString();
                    if (text != "CM3D2_MOD")
                    {
                        errors.Add(new InvalidCMFileProblem(this));
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
                        errors.Add(new InvalidCMFileProblem(this));
                        return;
                    }
                    string text4 = string.Empty;
                    if (mpn != Injected.MPN.null_mpn)
                    {
                        text4 = binaryReader.ReadString();
                    }
                    string s = binaryReader.ReadString();
                    int includeLength = binaryReader.ReadInt32();
                    for (int i = 0; i < includeLength; i++)
                    {
                        includeFiles.Add( binaryReader.ReadString().ToLower() );
                        binaryReader.BaseStream.Seek(binaryReader.ReadInt32(), SeekOrigin.Current);
                    }
                    binaryReader.Close();
                    binaryReader = null;

                    ModContainer.Single.CacheStore.RegisterIncludeFiles(relativePath, includeFiles);
                    
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
                        binaryReader?.Close();
                    }
                    catch { }
                }
            }

            foreach(string fileName in references)
            {
                if( !FileHelper.isExist(fileName) && (includeFiles != null && !includeFiles.Contains(fileName.ToLower())) )
                {
                    errors.Add(new MissingFileProblem(this, fileName));
                }
            }
        }
    }
}
using Mono.Cecil;
using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CM3D2.HyperCache.Patcher
{
    //Reference https://github.com/asm256/CM3D2.ArchiveReplacer/blob/master/CM3D2.ArchiveReplacer.Patcher.cs
    class HyperCachePatcher : ReiPatcher.Patch.PatchBase
    {
        const string patchTag = "CM3D2_HYPERCACHE_PATCHED";
        AssemblyDefinition hookdef;

        public override bool CanPatch(ReiPatcher.Patch.PatcherArguments args)
        {
            return args.Assembly.Name.Name == "Assembly-CSharp" && !base.GetPatchedAttributes(args.Assembly).Any(a => a.Info == patchTag);
        }
        public override void PrePatch()
        {
            ReiPatcher.RPConfig.RequestAssembly("Assembly-CSharp.dll");
            string path = Path.Combine(base.AssembliesDir, "CM3D2.HyperCache.dll");
            using (Stream str = File.OpenRead(path))
            {
                hookdef = AssemblyDefinition.ReadAssembly(str);
            }
        }
        public override void Patch(ReiPatcher.Patch.PatcherArguments args)
        {
            TypeDefinition gameuty = args.Assembly.MainModule.GetType("GameUty");
            var initmethod = gameuty.Methods.First((MethodDefinition def) => def.Name == "Init");
            foreach (var il in initmethod.Body.Instructions)
            {
                if (il.OpCode == OpCodes.Newobj)
                {
                    MethodReference oprnd = (MethodReference)il.Operand;
                    if (oprnd.DeclaringType.ToString() == "FileSystemArchive")
                    {
                        var defHook_ctor = hookdef.MainModule.GetType("CM3D2.HyperCache.CachedFileSystem")
                                .Methods.First((MethodDefinition def) => def.Name == ".ctor");

                        il.Operand = args.Assembly.MainModule.Import(defHook_ctor);
                    }
                }
            }

            TypeDefinition type = args.Assembly.MainModule.GetType("SceneEdit");
            if (type != null)
            {
                MethodDefinition methodDefinition = type.Methods.FirstOrDefault((MethodDefinition meth) => meth.Name == "GetModFiles");
                if (methodDefinition != null)
                {
                    ILProcessor ilprocessor = methodDefinition.Body.GetILProcessor();
                    try
                    {
                        var src = hookdef.MainModule.GetType("CM3D2.HyperCache.CachedFileSystem").Methods.First((MethodDefinition def) => def.Name == "GetModFiles");
                        methodDefinition.Body.Instructions.Clear();
                        MethodReference method = methodDefinition.Module.Import(src);
                        methodDefinition.Body.Instructions.Add(ilprocessor.Create(OpCodes.Call, method));
                        methodDefinition.Body.Instructions.Add(ilprocessor.Create(OpCodes.Ret));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }

            TypeDefinition menu = args.Assembly.MainModule.GetType("Menu");
            if (menu != null)
            {
                MethodDefinition methodDefinition = menu.Methods.FirstOrDefault((MethodDefinition meth) => meth.Name == "ProcScript");
                if (methodDefinition != null)
                {
                    ILProcessor ilprocessor = methodDefinition.Body.GetILProcessor();
                    try
                    {
                        var src = hookdef.MainModule.GetType("CM3D2.HyperCache.CachedFileSystem").Methods.First((MethodDefinition def) => def.Name == "GetModPath");
                        int insertInx = -1;
                        for(int i = 0; i < ilprocessor.Body.Instructions.Count; i++)
                        {
                            var il = ilprocessor.Body.Instructions[i];
                            if(il.Operand is MethodReference)
                            {
                                MethodReference _dest = (MethodReference) il.Operand;

                                if(_dest.Name == "GetBaseItemFromMod")
                                {
                                    insertInx = i - 2; //Argument Inst
                                    break;
                                }
                            }
                        }

                        if(insertInx == -1)
                        {
                            throw new Exception("CM3D2.HyperCache가 가진 정보로는 현재 버젼의 커스텀 메이드를 패치할 수 없습니다!");
                        }
                        
                        MethodReference method = methodDefinition.Module.Import(src);
                        methodDefinition.Body.Instructions.Insert(insertInx++, ilprocessor.Create(OpCodes.Stloc_1) );
                        methodDefinition.Body.Instructions.Insert(insertInx++, ilprocessor.Create(OpCodes.Ldarg_1) );
                        methodDefinition.Body.Instructions.Insert(insertInx++, ilprocessor.Create(OpCodes.Call, method));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }

            base.SetPatchedAttribute(args.Assembly, patchTag);
        }
    }
}

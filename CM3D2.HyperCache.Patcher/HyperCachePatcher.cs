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
                    }
                }
            }

            base.SetPatchedAttribute(args.Assembly, patchTag);
        }
    }
}

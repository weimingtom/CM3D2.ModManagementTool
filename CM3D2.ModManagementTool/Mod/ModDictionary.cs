using System;
using System.Collections.Generic;
using System.IO;
using CM3D2.ModManager.Mod.File;

namespace CM3D2.ModManager.Mod
{
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

        public void Clear()
        {
            modFiles.Clear();
            menuFiles.Clear();
            texFiles.Clear();
            matFiles.Clear();
            modelFiles.Clear();
            presetFiles.Clear();
        }
    }
}
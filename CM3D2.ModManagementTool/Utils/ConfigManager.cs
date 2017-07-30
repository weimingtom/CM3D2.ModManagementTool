using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM3D2.ModManagementTool.Utils
{
    class ConfigManager
    {
        private static ConfigManager single;

        public static ConfigManager Single
        {
            get {
                if(single == null)
                {
                    single = new ConfigManager();
                }
                return single;
            }
        }

        public string getRoot()
        {
            return @"D:\GameNK\Hs\3D\Custom Maid\MODS_COLLECTION"; //TODO: Replace with user data
        }

        public string relativePathToAbsolutePath(string relativePath)
        {
            return FileHelper.relativePathToAbsoultePath(getRoot(), relativePath);
        }
    }
}

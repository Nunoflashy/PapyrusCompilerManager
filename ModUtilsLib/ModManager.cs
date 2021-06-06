using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapyrusLibrary.Script;

namespace ModUtilsLib
{
    public static class ModManager
    {
        public static ModInfo GetModFromPath(string path)
        {
            return new ModInfo(path);
        }

        public static ModInfo[] GetMods(string path)
        {
            List<ModInfo> mods = new List<ModInfo>();

            DirectoryInfo modsPath = new DirectoryInfo(path);
            DirectoryInfo[] modsDirectories = modsPath.GetDirectories();

            foreach(DirectoryInfo modDir in modsDirectories) {
                mods.Add(new ModInfo(modDir.FullName));
            }

            return mods.ToArray();
        }
        
        //public static string[] GetScripts(ModInfo mod)
        //{
        //    List<string> scripts = new List<string>();
        //    foreach(ScriptInfo script in mod.SourceScripts) {
        //        scripts.Add(script.Name);
        //    }
        //    return scripts.ToArray();
        //}

        //public static ModInfo[] GetAllMods(DirectoryInfo rootModsDirectory)
        //{
        //    List<ModInfo> mods = new List<ModInfo>();
            
        //    DirectoryInfo[] modsDirectories = rootModsDirectory.GetDirectories();

        //    foreach(DirectoryInfo modDir in modsDirectories) {
        //        mods.Add(new ModInfo(modDir));
        //    }

        //    return mods.ToArray();
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PapyrusLibrary.Script;

namespace ModUtilsLib
{
    /// <summary>
    /// Exposes instance methods for getting the numerous mod related directories and files.
    /// </summary>
    public class ModInfo
    {
        private enum ModDirectoryType {
            None            = 0,
            Scripts         = 2,
            Meshes          = 3 << 1,
            Textures        = 4 << 1,
            SKSE            = 5 << 1,
            Sound           = 6 << 1,
            SourceScripts   = 7 << 1
        }

        private string modPath = null;

        /// <summary>
        /// Initializes a new instance of the ModInfo class on the specified path(Usually mod organizer's mod directory.)
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <param name="modPath"></param>
        public ModInfo(string modPath)
        {
            if(string.IsNullOrEmpty(modPath)) {
                throw new ArgumentNullException(nameof(modPath));
            }

            this.modPath = modPath;
        }

        private string MeshesPath        => GetDirectory(ModDirectoryType.Meshes).FullName;
        private string TexturesPath      => GetDirectory(ModDirectoryType.Textures).FullName;
        private string SoundPath         => GetDirectory(ModDirectoryType.Sound).FullName;
        private string SourceScriptsPath => GetDirectory(ModDirectoryType.SourceScripts).FullName;
        private string ScriptsPath       => GetDirectory(ModDirectoryType.Scripts).FullName;
        private string SKSEPath          => GetDirectory(ModDirectoryType.SKSE).FullName;

        public bool HasSourceScripts => GetDirectory(ModDirectoryType.SourceScripts).GetFiles().Length > 0;
        public bool HasScripts       => GetDirectory(ModDirectoryType.Scripts).GetFiles().Length > 0;
        public bool HasTextures      => GetDirectory(ModDirectoryType.Textures).GetFiles().Length > 0;

        private DirectoryInfo GetDirectory(ModDirectoryType directoryType)
        {
            string path = null;

            switch(directoryType) {
                case ModDirectoryType.Meshes:        path = $@"{modPath}\meshes"; break; //requires recursive iteration
                case ModDirectoryType.Textures:      path = $@"{modPath}\textures"; break; //requires recursive iteration
                case ModDirectoryType.Sound:         path = $@"{modPath}\sound"; break; //requires recursive iteration
                case ModDirectoryType.SourceScripts: path = $@"{modPath}\scripts\source"; break;
                case ModDirectoryType.Scripts:       path = $@"{modPath}\scripts"; break;
                case ModDirectoryType.SKSE:          path = $@"{modPath}\SKSE"; break; //requires recursive iteration
            }

            DirectoryInfo directory = new DirectoryInfo(path);

            if(!directory.Exists) {
                throw new DirectoryNotFoundException($"{Name} does not contain a {directory.Name} directory.");
            }

            return new DirectoryInfo(path);
        }

        public ScriptInfo[] SourceScripts
        {
            get {
                // Store all scripts
                List<ScriptInfo> sourceScriptsInMod = new List<ScriptInfo>();

                // Get all scripts that pertain to this mod
                FileInfo[] scripts = GetDirectory(ModDirectoryType.SourceScripts).GetFiles();

                for (int i = 0; i < scripts.Length; i++) {
                    // Get the path to the script and create a new instance from it
                    ScriptInfo script = new ScriptInfo(scripts[i].FullName);

                    if(script.IsValidSource){
                        sourceScriptsInMod.Add(script);
                    }
                }

                return sourceScriptsInMod.ToArray();
            }
        }

        public ScriptInfo[] Scripts {
            get {
                List<ScriptInfo> scriptsInMod = new List<ScriptInfo>();
                FileInfo[] scriptFiles = GetDirectory(ModDirectoryType.Scripts).GetFiles();
                foreach(var file in scriptFiles) {
                    ScriptInfo script = new ScriptInfo(file.FullName);
                    if(script.IsValid)
                        scriptsInMod.Add(script);
                }
                return scriptsInMod.ToArray();
            }
        }

        public FileInfo[] Textures
        {
            get {
                List<FileInfo> texturesInMod = new List<FileInfo>();
                foreach(FileInfo texture in new DirectoryInfo(TexturesPath).GetFiles()) {
                    texturesInMod.Add(texture);
                }

                return texturesInMod.ToArray();
            }
        }

        /// <summary>
        /// Gets the name of the mod, this is retrieved by parsing the path and getting the mod's directory name.
        /// </summary>
        public string Name
        {
            get {
                DirectoryInfo di = new DirectoryInfo(modPath);
                return di.Name;
            }
        }

        /// <summary>
        /// Retrieves all the sources of the scripts from this mod.
        /// </summary>
        /// <exception cref="ScriptsDirectoryNotFoundException">Thrown when the mod does not contain a scripts source directory.</exception>
        /// <exception cref="ScriptNotFoundException">Thrown when the mod does not contain any scripts.</exception>
        /// <returns></returns>
        //public FileInfo[] GetSourceScripts()
        //{
        //    string sourceScriptsPath = $@"{modPath}\scripts\source".ToLower();

        //    if (!Directory.Exists(sourceScriptsPath)) {
        //        // This should happen quite often as many mods do not contain any scripts.
        //        throw new ScriptsDirectoryNotFoundException($"Mod does not contain a scripts source directory.");
        //    }

        //    DirectoryInfo di = new DirectoryInfo(sourceScriptsPath);
        //    FileInfo[] scripts = di.GetFiles();

        //    if(scripts.Length == 0) {
        //        /*This shouldn't happen at all, since the mods that do contain the script directory 
        //         * also contain scripts, and is therefore considered an error.*/
        //        throw new ScriptNotFoundException("Mod contains a scripts directory but does not contain any scripts!");
        //    }

        //    return scripts;
        //}

    }
}

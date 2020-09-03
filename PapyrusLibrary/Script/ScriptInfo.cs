using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PapyrusLibrary.Script
{
    public class ScriptInfo
    {
        private FileInfo file = null;

        public ScriptInfo(string scriptPath)
        {
            file = new FileInfo(scriptPath);
        }

        /// <summary>
        /// Retrieve this script from the desired mod, faster than searching all mod subdirectories.
        /// </summary>
        /// <param name="scriptName"></param>
        /// <param name="modPath"></param>
        public ScriptInfo(string scriptName, string modPath) : this($@"{modPath}\scripts\source\{scriptName}")
        {
            
        }

        public bool IsValid
        {
            get {
                return file.Extension == ".psc";
            }
        }

        /// <summary>
        /// Gets whether or not this script inherits from another script
        /// Ex: ObjectReference, ReferenceAlias, Quest, etc...
        /// </summary>
        public bool Inherits
        {
            get { return Extends != null; }
        }

        public string Name
        {
            get {
                if(file == null) {
                    throw new ArgumentNullException(nameof(file));
                }

                return file.Name;
            }
        }

        public string Extends
        {
            get {
                using(StreamReader reader = new StreamReader(file.FullName)) {
                    string wantedLine = reader.ReadLine();
                    string extendsLine = null;
                    string retval = null;
                    if (wantedLine.Contains("extends")) {
                        extendsLine = wantedLine.Remove(0, wantedLine.IndexOf("extends"));
                        retval = extendsLine.Remove(extendsLine.IndexOf("extends"), "extends".Length);
                    }
                    return retval;
                }
            }
        }

        private string[] GetImportedScripts()
        {
            List<string> importedScripts = new List<string>();
            using(StreamReader reader = new StreamReader(file.FullName)) {
                while(!reader.EndOfStream) {
                    string line = reader.ReadLine();
                    // We reached the section of importing scripts
                    if(line.Contains("import")) {
                        // Get the actual dependency script name and add it
                        string script = line.Remove(0, line.IndexOf("import"));
                        importedScripts.Add(script);
                    }
                }
                return importedScripts.ToArray();
            }
        }

        public ScriptInfo[] Imports
        {
            get {
                List<ScriptInfo> importScripts = new List<ScriptInfo>();
                using (StreamReader reader = new StreamReader(file.FullName)) {
                    while(!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        if(line.Contains("import")) {
                            // Get the actual dependency script name and add it
                            string script = line.Remove(0, line.IndexOf("imports"));
                            importScripts.Add(new ScriptInfo(script));
                        }
                    }
                    return importScripts.ToArray();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PapyrusLibrary.Script
{
    public class ScriptInfo
    {
        private FileInfo file = null;

        public string Path { get; private set; }

        public int LinesOfCode { get; private set; }

        public ScriptInfo(string scriptPath)
        {
            file = new FileInfo(scriptPath);
            Path = scriptPath;
            RefreshScript();
        }

        private Dictionary<string, PapyrusFunction> functions = new Dictionary<string, PapyrusFunction>();
        private Dictionary<string, PapyrusEvent> events = new Dictionary<string, PapyrusEvent>();
        /// <summary>
        /// Read all of the states that are in the script and add them to the state list
        /// </summary>
        private void LoadStates() {

        }

        /// <summary>
        /// Read all of the functions that are in the script and add them to the function list
        /// </summary>
        private void LoadFunctions() {
            string functionDefinition = @"(\w+ )?(function) (\w+)([(]((\w+ \w+)*)?[)])";
            Regex regex = new Regex(functionDefinition);

            foreach(string line in scriptRawData) {
                if(regex.IsMatch(line)) {
                    Match m = regex.Match(line);

                    string returnType   = m.Groups[0].Value;
                    string name         = m.Groups[1].Value;

                    functions[name] = new PapyrusFunction() {
                        ReturnType = returnType,
                        Name = name,
                    };
                }
            }

            functions["ArrestPlayer"] = new PapyrusFunction("");
        }

        /// <summary>
        /// Read all of the events that are in the script and add them to the event list
        /// </summary>
        private void LoadEvents() {
            events["OnKeyUp"] = new PapyrusEvent("");
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

        //public ScriptInfo[] Imports
        //{
        //    get {
        //        List<ScriptInfo> importScripts = new List<ScriptInfo>();
        //        using (StreamReader reader = new StreamReader(file.FullName)) {
        //            while(!reader.EndOfStream) {
        //                string line = reader.ReadLine();
        //                if(line.Contains("import")) {
        //                    // Get the actual dependency script name and add it
        //                    string script = line.Remove(0, line.IndexOf("imports"));
        //                    importScripts.Add(new ScriptInfo(script));
        //                }
        //            }
        //            return importScripts.ToArray();
        //        }
        //    }
        //}

        public string[] Imports {
            get {
                List<string> importedScripts = new List<string>();
                foreach(string line in scriptRawData) {
                    try {
                        if (string.Equals(line.Substring(0, line.IndexOf(' ')), "Import", StringComparison.OrdinalIgnoreCase)) {
                            importedScripts.Add(line.Replace("import", ""));
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
                return importedScripts.ToArray();
            }
        }

        /// <summary>
        /// Gets all the functions in a script
        /// TODO: Check whether or not the function is inside a state or not
        /// </summary>
        public PapyrusFunction[] Functions {
            get {
                List<PapyrusFunction> functions = new List<PapyrusFunction>();
                foreach (string line in scriptRawData) {
                    if (PapyrusFunction.IsValidFunction(line)) {
                        functions.Add(new PapyrusFunction(line));
                    }
                }
                return functions.ToArray();
            }
        }

        /// <summary>
        /// Gets all the fragment functions in a script fragment
        /// </summary>
        public PapyrusFunction[] Fragments {
            get {
                List<PapyrusFunction> fragments = new List<PapyrusFunction>();
                foreach(PapyrusFunction function in Functions) {
                    if(function.IsFragment()) {
                        fragments.Add(function);
                    }
                }
                return fragments.ToArray();
            }
        }

        /// <summary>
        /// Gets all the properties in a script
        /// </summary>
        public PapyrusVariable[] Properties => PapyrusVariable.GetPropertiesFromScript(this);

        /// <summary>
        /// Gets all the events in a script
        /// </summary>
        public PapyrusEvent[] Events => PapyrusEvent.GetEvents(this);

        /// <summary>
        /// Checks whether or not this script has functions
        /// </summary>
        public bool HasFunctions => Functions.Length != 0;

        /// <summary>
        /// Checks whether or not this script has events
        /// </summary>
        public bool HasEvents => Events.Length != 0;

        public string[] States {
            get {
                List<string> states = new List<string>();
                foreach (string line in scriptRawData) {
                    try {
                        string fw = line.Substring(0, line.IndexOf(' ')).Trim();
                        if (PapyrusState.IsValidState(fw)) {
                            states.Add(line);

                        }
                    }
                    catch (Exception) {

                        
                    }
                }
                return states.ToArray();
            }
        }

        public PapyrusICallable[] Callables {
            get {
                return null;
            }
        }

        private List<string> scriptRawData = new List<string>();

        public string[] Data {
            get {
                return scriptRawData.ToArray();
            }
        }

        public void RefreshScript() {
            if(scriptRawData != null)
                scriptRawData.Clear();

            using(StreamReader r = new StreamReader(file.FullName)) {
                while(!r.EndOfStream) {
                    string line = r.ReadLine();
                    LinesOfCode += 1;
                    scriptRawData.Add(line);
                }
            }
        }
    }

    public static class Extensions {
        public static PapyrusVariable[] GetVariablesOfType(this ScriptInfo script, string type)
            => PapyrusVariable.GetVariablesOfType(script, type);

        public static PapyrusFunction GetFunctionByName(this ScriptInfo script, string name) {
            return null;
        }
    }

}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Compiler {
    public static class PapyrusCompilerConfig {

        public static string Path { get; private set; }

        public static PapyrusArgumentHandler Arguments { get; private set; }


        public static void Load() {
            var config = new IniFile("config.ini");
            string path      = config["compiler"]["path"].GetString();
            string arguments = config["compiler"]["arguments"].GetString();

            Path = path;
            PapyrusArgumentHandler argumentHandler = JsonConvert.DeserializeObject<PapyrusArgumentHandler>(arguments);
            Arguments = argumentHandler;

        }

        public static void Save() {
            PapyrusCompiler.Arguments.Script = null;
            
            var ini = new IniFile("config.ini");
            ini["compiler"]["path"] = PapyrusCompiler.Path;
            ini["compiler"]["arguments"] = JsonConvert.SerializeObject(PapyrusCompiler.Arguments);
            ini.Save("config.ini");
        }
    }
}

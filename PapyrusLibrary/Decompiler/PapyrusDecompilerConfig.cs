using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Decompiler {
    public static class PapyrusDecompilerConfig {

        public static string Path { get; private set; }

        public static DecompilerArgumentHandler Arguments { get; private set; }


        public static void Load() {
            var config = new IniFile("config.ini");
            string path      = config["decompiler"]["path"].GetString();
            string arguments = config["decompiler"]["arguments"].GetString();

            Path = path;
            DecompilerArgumentHandler argumentHandler = JsonConvert.DeserializeObject<DecompilerArgumentHandler>(arguments);
            Arguments = argumentHandler;

        }

        public static void Save() {
            PapyrusDecompiler.Arguments.Script = null;
            
            var ini = new IniFile("config.ini");
            ini["decompiler"]["path"] = PapyrusDecompiler.Path;
            ini["decompiler"]["arguments"] = JsonConvert.SerializeObject(PapyrusDecompiler.Arguments);
            ini.Save("config.ini");
        }
    }
}

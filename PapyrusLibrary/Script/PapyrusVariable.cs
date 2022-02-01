using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Script {
    public class PapyrusVariable {
        public string Data { get; private set; }
        public PapyrusVariable(string property) {
            Data = property;
        }
        public static PapyrusVariable[] GetProperties(ScriptInfo script) {
            List<PapyrusVariable> properties = new List<PapyrusVariable>();
            foreach(string line in script.Data) {
                if(line.Contains("Property ")) {
                    properties.Add(new PapyrusVariable(line));
                }
            }
            return properties.ToArray();
        }

        public static PapyrusVariable[] GetVariablesOfType(ScriptInfo script, string type) {
            return null;
        }

        /// <summary>
        /// The type of this property
        /// </summary>
        public string Type {
            get {
                return null;
            }
        }
    }
}

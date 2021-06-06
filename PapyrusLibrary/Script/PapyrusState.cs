using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Script {
    public class PapyrusState {
        public string Name { get; private set; }
        public string Data { get; private set; }

        public PapyrusState(string stateLine) {
            Data = stateLine;
            string fw = stateLine.Substring(0, stateLine.IndexOf(' '));

        }

        public static List<PapyrusState> GetScriptStates(ScriptInfo script) {
            return null;
        }

        /// <summary>
        /// Retrieves the line where this State starts in the script
        /// </summary>
        /// <returns></returns>
        public int GetLineBegin() {
            return 0;
        }

        /// <summary>
        /// Retrieves the line where this State ends in the script
        /// </summary>
        /// <returns></returns>
        public int GetLineEnd() {
            return 0;
        }

        public static bool IsValidState(string stateLine) {
            return string.Equals(stateLine, "State", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(stateLine, "Auto State", StringComparison.OrdinalIgnoreCase);
        }
    }
}

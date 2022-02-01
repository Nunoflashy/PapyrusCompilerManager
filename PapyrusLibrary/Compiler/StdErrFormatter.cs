using PapyrusLibrary.Script;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary.Compiler {
    /*Standard Error representation from Papyrus:
     * ScriptName(Line, Column): ErrorMessage
     * TempleBlessing.psc(4, 32): mismatched input 'Property' expecting FUNCTION
     */
    //test
    /// <summary>
    /// Wrapper class to handle standard error from the compiler
    /// </summary>
    public sealed class StdErrFormatter
    {
        /// <summary>
        /// Gets an instance of the script referenced in the error
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ScriptInfo GetScriptAtIndex(int index) {
            return new ScriptInfo(GetScriptPathAtIndex(index));
        }

        public static ScriptInfo[] Scripts {
            get {
                string[] stderr = CompilerInfo.StdErr;
                ScriptInfo[] scripts = new ScriptInfo[stderr.Length];
                for(int i = 0; i < stderr.Length; i++)
                    scripts[i] = GetScriptAtIndex(i);

                return scripts;
            }
        }

        public static string[] Messages {
            get {
                string[] stderr = CompilerInfo.StdErr;
                string[] messages = new string[stderr.Length];
                for(int i = 0; i < stderr.Length; i++)
                    messages[i] = GetMessageAtIndex(i);

                return messages;
            }
        }

        /// <summary>
        /// Gets the full path of the script at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetScriptPathAtIndex(int index) {
            string stderr = CompilerInfo.StdErr[index];
            if(string.IsNullOrEmpty(stderr))
                return null;

            return $"{stderr.Substring(0, stderr.IndexOf('('))}";
        }

        /// <summary>
        /// Gets the line in the script of where this error occurred
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetLineAtIndex(int index) {
            string stderr = CompilerInfo.StdErr[index];
            if (string.IsNullOrEmpty(stderr))
                return 0;

            string lineStart = stderr.Substring(stderr.IndexOf('(') + 1);
            string line = lineStart.Substring(0, lineStart.IndexOf(','));
            //Console.WriteLine($"GetLineAtIndex({index}): start = {lineStart}, end = {line}");
            return int.Parse(line);
        }

        /// <summary>
        /// Gets the column (horizontal position on a line) in the script where the error occurred
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetColumnAtIndex(int index) {
            string stderr = CompilerInfo.StdErr[index];
            if (string.IsNullOrEmpty(stderr))
                return 0;

            string lineEnd = stderr.Substring(stderr.IndexOf(',') + 1);
            string column = lineEnd.Substring(0, lineEnd.IndexOf(')'));

            return int.Parse(column);
        }

        public static string GetMessageAtIndex(int index) {
            string stderr = CompilerInfo.StdErr[index];
            if (string.IsNullOrEmpty(stderr))
                return null;

            string noPath = stderr.Substring(stderr.LastIndexOf('\\') + 1);
            string message = noPath.Substring(noPath.IndexOf(':') + 1);
            return message.Trim();
        }

        //public string GetErrorAtIndex(int index)
        //{
        //    if(index > CompilerInfo.storedStdErr.Count) {
        //        throw new IndexOutOfRangeException();
        //    }

        //    string errorAtIndex = CompilerInfo.storedStdErr[index];
        //    return errorAtIndex;
        //}

        //public static string ScriptName
        //{
        //    get {
        //        string script = CompilerInfo.ScriptErrorMessage[0];
        //        string output = script.Remove(script.IndexOf('('));
        //        return output;
        //    }
        //}

        //public static uint ErrorLine
        //{
        //    get {
        //        string script = CompilerInfo.ScriptErrorMessage[0];
        //        string output = script.Remove(0, script.IndexOf('(')+1);
        //        string x = output.Remove(output.IndexOf(':')).Remove(output.IndexOf(','));
        //        uint returnValue = uint.Parse(x);
        //        return returnValue;
        //    }
        //}

        //public static string Message
        //{
        //    get {
        //        string script = Error[0];
        //        string output = script.Remove(0, script.IndexOf(':') + 2);
        //        return output;
        //    }
        //}

    }
}

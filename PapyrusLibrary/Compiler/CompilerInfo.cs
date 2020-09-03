using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary
{
    /* Standard error representation from Papyrus:
     * ScriptName(ErrorLine,Col): ErrorMessage
     * TempleBlessing.psc(4,32): mismatched input 'Property' expecting FUNCTION
     */

    public static class CompilerInfo
    {
        /// <summary>
        /// Internal list used to store StdErr, we can't manipulate the compiler's
        /// error output directly since it defaults to a whitespace after it's shown once,
        /// this list should be used to manipulate the output.
        /// </summary>
        private static List<string> storedStdErr = new List<string>();

        public static string[] StdErr
        {
            get {
                /* Reads StdErr from the compiler and splits the errors into lines,
                 * this is the raw output and cannot be manipulated directly.*/
                string[] output = PapyrusCompiler.StdErr.Split(Environment.NewLine.ToCharArray());

                /* Due to the nature of how the compiler generates StdErr,
                 * we have to check if it hasn't already been generated(if it has, it will be empty string),
                 * if not, then we assign it to a local list for easier string manip.*/
                if (!string.IsNullOrWhiteSpace(output[0])) {
                    storedStdErr = output.ToList();
                }

                return storedStdErr.ToArray();
            }
        }


        /// <summary>
        /// Gets the path of the current script to compile.
        /// </summary>
        public static string ScriptPath
        {
            get { return PapyrusCompiler.Arguments.InputPath; }
        }

        public static string ScriptName
        {
            get {
                string name = storedStdErr[0]
                .Remove(storedStdErr[0].IndexOf('('))
                .Replace(PapyrusCompiler.Arguments.InputPath, "")
                .Trim('\\');
                
                return name;
            }
        }

        public static uint ErrorLine
        {
            get {
                string script = storedStdErr[0];
                string output = script.Remove(0, script.IndexOf('(') + 1);
                string x = output.Remove(output.IndexOf(':')).Remove(output.IndexOf(','));
                uint returnValue = uint.Parse(x);
                return returnValue;
            }
        }

        public static string[] ArrayErrorLine
        {
            get {
                string[] output = new string[storedStdErr.Count];

                for(int i = 0; i < storedStdErr.Count; i++) {
                    output[i] = storedStdErr[i].Remove(0, storedStdErr[i].IndexOf('(') + 1);
                }

                return output;
            }
        }

        public static string[] ErrorLineArray
        {
            get {
                string[] output = new string[storedStdErr.Count];

                for(int i = 0; i < storedStdErr.Count; i++) {
                    string script = storedStdErr[i];
                    string x = script.Remove(0, script.IndexOf('(') + 1);
                    //string y = x.Remove(x.IndexOf(':')).Remove(x.IndexOf(','));

                    output[i] = x;//uint.Parse(y);
                }

                return output;
            }
        }

        public static string[] LineNumber
        {
            get {
                string[] output = new string[storedStdErr.Count];
                for(int i = 0; i < storedStdErr.Count; i++) {
                    string currentLine = 
                        storedStdErr[i]
                        .Replace(PapyrusCompiler.Arguments.InputPath, "")
                        .Replace(ScriptName, "")
                        .Trim('\\')
                        ;

                    output[i] = currentLine;
                }
                return output;
            }
        }

        public static string[] Message
        {
            get {
                string[] output = new string[storedStdErr.Count];

                for(int i = 0; i < storedStdErr.Count; i++) {
                    if(storedStdErr[i].Length > 0) {
                        if (!storedStdErr[i].Contains("unable")) {
                            output[i] =
                                storedStdErr[i].Replace(ScriptPath, "").Trim('\\')
                                .Remove(0, storedStdErr[i].IndexOf(':') + 2);
                        }
                        else {
                            output[i] = storedStdErr[i];
                        }
                    }
                }
                return output;
            }
        }
    }
}

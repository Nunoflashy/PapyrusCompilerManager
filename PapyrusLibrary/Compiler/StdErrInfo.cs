using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapyrusLibrary
{
    /*Standard Error representation from Papyrus:
     * ScriptName(ErrorLine, x): ErrorMessage
     * TempleBlessing.psc(4, 32): mismatched input 'Property' expecting FUNCTION
     */

    /// <summary>
    /// Wrapper class to handle standard error from the compiler
    /// </summary>
    //public static class StdErrInfo
    //{
    //    private static string[] error = ToArray();

    //    /// <summary>
    //    /// Splits StdErr into multiple lines for easier manipulation
    //    /// </summary>
    //    /// <returns></returns>
    //    public static string[] ToArray() => 
    //        PapyrusCompiler.StdErr.Split(Environment.NewLine.ToCharArray());

    //    public static string ScriptPath => PapyrusCompiler.Arguments.InputPath;

    //    public static string ScriptName
    //    {
    //        get {
    //            string script = CompilerInfo.ScriptErrorMessage[0];
    //            string output = script.Remove(script.IndexOf('('));
    //            return output;
    //        }
    //    }

    //    public static string[] Message
    //    {
    //        get {
    //            string[] output = new string[error.Length];
                
    //            for(int i = 0; i < output.Length; i++) {
    //                string subStr = error[i].Replace(PapyrusCompiler.Arguments.InputPath, "")
    //                                        .Trim('\\');
    //                output[i] += subStr
    //                    ;//.Remove(error[i].IndexOf(':'));
    //            }
    //            return output;
    //        }
    //    }
    //}
    public sealed class StdErrInfo
    {
        public string ScriptPath
        {
            get {
                return PapyrusCompiler.Arguments.InputPath;
            }
        }

        public uint Line
        {
            get;
            internal set;
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

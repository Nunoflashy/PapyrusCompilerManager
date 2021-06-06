using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PapyrusLibrary.Script {
    public class PapyrusFunction {
        private string functionData;
        public string Data { get; set; }
        public string ReturnType { get; set; }
        public string Name { get; set; }
        public string Parameters { get; set; }

        public PapyrusFunction() {

        }

        public PapyrusFunction(string functionLine) {
            functionData = functionLine;
            Data = functionLine;

            string firstWord = functionLine.Substring(0, functionLine.IndexOf(' '));
            if (firstWord.ToLower() == "function") {
                string functionName = functionLine.Replace("Function ", "").
                                                   Replace("function ", "").Trim();
                //Console.WriteLine("functionLine: " + functionLine);
                //Console.WriteLine("functionName: " + functionName);
                Name = functionName;
            }
            else {
                Name = "null";
                ReturnType = firstWord;
                string functionName = Data.Substring(Data.ToLower().IndexOf("function") + "function".Length);
                Name = $"{functionName}";
                //Console.WriteLine("ReturnType: " + firstWord);
                //Console.WriteLine("Data: " + functionName);
            }
        }

        public static PapyrusFunction GetFunctionByName(ScriptInfo script, string name) {
            return null;
        }
        public static PapyrusFunction GetFunctionAtLine(ScriptInfo script, int line) {
            return null;
        }
        public static PapyrusFunction[] GetFunctions(ScriptInfo script) {
            return null;
        }

        public static bool IsProcedure(string function) =>
             GetReturnType(function) == "void";

        /// <summary>
        /// Temporary: Check if the function is a fragment(inside a script fragment)
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public static bool IsFragment(string function) {
            return function.Contains("Fragment_", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsFragment() => IsFragment(Data);

        public static string GetReturnType(string function) {
            string fw = function.Substring(0, function.IndexOf(' '));
            if(fw.ToLower() == "function") return "void";
            else                           return fw.Trim();
        }

        public static bool IsValidFunction(string functionLine) {
            string functionDefinition = @"(\w+ )?(function) (\w+)([(]((\w+ \w+)*)?[)])";
            Regex regex = new Regex(functionDefinition);
            //return regex.IsMatch(functionLine);

            return functionLine.ToLower().Contains("function") &&
                   !functionLine.ToLower().Contains("endfunction") &&
                   !functionLine.Contains(';');
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PapyrusLibrary.Decompiler {
    /// <summary>
    /// Wrapper class to pass in arguments to the papyrus decompiler.
    /// </summary>
    public class DecompilerArgumentHandler {

        /// <summary>
        /// The script to be decompiled into a source PSC file.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// The path(s) to get scripts from in case of wanting to decompile multiple scripts in one action.
        /// </summary>
        public string InputPath { get; set; }

        /// <summary>
        /// The path to where the scripts should be exported when decompiled 
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// The path to where the assembly files should be exported to.
        /// </summary>
        public string AssemblyPath { get; set; }

        /// <summary>
        /// The script will be annotated with the assembly instruction corresponding to the decompiled line.
        /// </summary>
        public bool Comment { get; set; }

        /// <summary>
        /// The decompiler will run in multi-threaded mode
        /// </summary>
        public bool Threaded { get; set; }

        public string Parse() {
            /**
                * Output line for the decompiler
                * -p path to the output directory
                * -a path to the assembly directory
                * -c comment on each instruction
                * -t multi-threaded decompilation
            */
            string scriptToDecompile = Path.Combine(InputPath, Script);


            if(scriptToDecompile == null)
                throw new NullReferenceException("The script is invalid!");

            string output = $"\"{scriptToDecompile}\" " +
                             $"-p \"{OutputPath}\" " +
                             $"{(AssemblyPath != null ? $" -a \"{AssemblyPath}\"" : "")}" +
                             $"{(Comment    ? " -c" : "")}" +
                             $"{(Threaded   ? " -t" : "")}";

            return output;
             
        }

        public override string ToString() {
            return $"Script = {Script}\n" +
                   $"InputPath = {InputPath}\n" +
                   $"OutputPath = {OutputPath}\n" +
                   $"AssemblyPath = {AssemblyPath}\n" +
                   $"Comment = {Comment}\n" +
                   $"Threaded = {Threaded}\n";
        }
    }
}

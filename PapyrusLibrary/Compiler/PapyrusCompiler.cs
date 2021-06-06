using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using PapyrusLibrary.Compiler;

namespace PapyrusLibrary
{
    /// <summary>
    /// Object representing the papyrus compiler and the necessary options to make it work.
    /// </summary>
    public static class PapyrusCompiler
    {
        private enum IntegrityStatus
        {
            Invalid, Valid
        };

        public static bool CompiledSuccessfully() {
            return StdOut.Contains("Assembly succeeded");
        }

        private static readonly Process papyrus = new Process();

        public static bool RedirectStdOut { get; set; } = true;
        public static bool RedirectStdErr { get; set; } = true;

        static PapyrusCompiler()
        {
            SetDefaultParameters();
        }


        private static void SetDefaultParameters()
        {
            papyrus.StartInfo.UseShellExecute = false;
            papyrus.StartInfo.CreateNoWindow  = true;
            papyrus.StartInfo.RedirectStandardOutput = RedirectStdOut;
            papyrus.StartInfo.RedirectStandardError  = RedirectStdErr;
            

            papyrus.EnableRaisingEvents = true;

            #region Output Streams
            papyrus.OutputDataReceived += (sender, e) =>
                                        StdOut += e.Data + Environment.NewLine ?? "";

            papyrus.ErrorDataReceived  += (sender, e) =>
                                        StdErr += e.Data + Environment.NewLine ?? "";
            #endregion

        }

        private static void ResetOutputStreams()
        {
            StdOut = "";
            StdErr = "";
        }

        private static IntegrityStatus CheckIntegrity()
        {
            return IntegrityStatus.Valid;
        }

        public static string Path
        {
            get { return papyrus.StartInfo.FileName; }

            set {
                if(File.Exists(value)) {
                    papyrus.StartInfo.FileName = value;
                }
                else {
                    throw new FileNotFoundException($"{value} does not point to a valid papyrus compiler.");
                }
            }
        }

        /// <summary>
        /// Gets the standard output from the compiler.
        /// </summary>
        public static string StdOut
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the standard output from the compiler when an error has occurred.
        /// </summary>
        public static string StdErr
        {
            get;
            private set;
        }

        private static PapyrusArgumentHandler argumentHandler;
        /// <summary>
        /// Argument handler for the compiler, pass in the necessary arguments here.
        /// </summary>
        public static PapyrusArgumentHandler Arguments {
            get { return argumentHandler; }
            set {
                argumentHandler = value;
                RefreshArguments();
            }
        }

        /// <summary>
        /// Alias for PapyrusArgumentHandler AddPath
        /// </summary>
        /// <param name="path"></param>
        public static void AddPath(string path) {
            argumentHandler.AddPath(path);
        }

        /// <summary>
        /// Helper method to refresh the arguments passed in to the compiler,
        /// used everytime we need to compile a different script.
        /// </summary>
        private static void RefreshArguments() => papyrus.StartInfo.Arguments = argumentHandler.Parse();

        /// <summary>
        /// Validate whether or not enough data has been passed in to the compiler.
        /// </summary>
        /// <returns></returns>
        private static bool IsValid() => !(papyrus == null && string.IsNullOrEmpty(Path)) && argumentHandler.IsValid();

        public static void Compile()
        {
            if(IsValid()) {
                papyrus.Start();

                // Get output streams async to avoid deadlocks
                if(RedirectStdOut) papyrus.BeginOutputReadLine();
                if(RedirectStdErr) papyrus.BeginErrorReadLine();

                ResetOutputStreams();

                papyrus.WaitForExit();

                // Cancel reading from the output streams.
                if(RedirectStdOut) papyrus.CancelOutputRead();
                if(RedirectStdErr) papyrus.CancelErrorRead();
                
            }
        }

        /// <summary>
        /// Refreshes the arguments passed in and compiles this script.
        /// </summary>
        /// <param name="scriptName">The script to be compiled.</param>
        public static void Compile(string scriptName)
        {
            Arguments.Script = scriptName;
            RefreshArguments();
            Compile();
        }

        /// <summary>
        /// Does not perform any checks, compiles directly.
        /// </summary>
        /// <param name="arguments"></param>
        public static void DirectCompile(string arguments)
        {
            papyrus.StartInfo.Arguments = arguments;
            papyrus.Start();
            papyrus.WaitForExit();
        }

        //public static CompilationStatus Compile(string[] scripts)
        //{
        //    if(scripts == null) {
        //        throw new ArgumentNullException();
        //    }

        //    CompilationStatus result = CompilationStatus.Failed;

        //    foreach(string script in scripts) {
        //        result = Compile(script);
        //    }
        //    return result;
        //}

        /// <summary>
        /// Allows the use of the compiler directly by passing in all arguments
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static void Compile(PapyrusArgumentHandler arguments)
        {
            Arguments = arguments;
            RefreshArguments();
            Compile();
        }
    }
}

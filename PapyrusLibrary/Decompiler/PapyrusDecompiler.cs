using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using PapyrusLibrary.Script;

namespace PapyrusLibrary.Decompiler {

    /// <summary>
    /// Representation of the papyrus decompiler and the necessary options to make it work.
    /// </summary>
    public class PapyrusDecompiler {
        static PapyrusDecompiler() {
            SetDefaultParameters();
        }

        private static void ResetOutputStreams() {
            StdOut = "";
            StdErr = "";
        }

        /// <summary>
        /// Gets the standard output from the compiler.
        /// </summary>
        public static string StdOut { get; private set; } = null;

        /// <summary>
        /// Gets the standard output from the compiler when an error has occurred.
        /// </summary>
        public static string StdErr { get;  private set; } = null;

        //public static void Decompile(string scriptname) {
        //    argumentHandler.Script = scriptname;
        //    Start();
        //}

        public static void Decompile(DecompilerArgumentHandler args) {
            Arguments = args;
            RefreshArguments();
            Start();
        }

        public static void Decompile() {
            if(Arguments == null)
                throw new NullReferenceException("Arguments must be passed in to the decompiler!");

            RefreshArguments();
            Start();
            OnDecompiled(StdOut);
        }

        /// <summary>
        /// Refreshes the arguments passed in and decompiles this script.
        /// </summary>
        /// <param name="scriptName">The script to be decompiled.</param>
        public static void Decompile(string scriptName) {
            Arguments.Script = scriptName;
            RefreshArguments();
            Decompile();
        }

        /// <summary>
        /// Refreshes the arguments passed in and decompiles this script.
        /// </summary>
        /// <param name="scriptName">The script to be decompiled.</param>
        public static void Decompile(ScriptInfo script) {
            Arguments.Script = script.Name;
            RefreshArguments();
            Decompile();
        }

        private static void Start() {
            decompiler.Start();

            // Get output streams async to avoid deadlocks
            if (RedirectStdOut) decompiler.BeginOutputReadLine();
            if (RedirectStdErr) decompiler.BeginErrorReadLine();

            decompiler.WaitForExit();

            if (RedirectStdOut) decompiler.CancelOutputRead();
            if (RedirectStdErr) decompiler.CancelErrorRead();
        }

        public static string Path {
            get { return decompiler.StartInfo.FileName; }

            set {
                if (File.Exists(value)) {
                    decompiler.StartInfo.FileName = value;
                }
                else {
                    throw new FileNotFoundException($"{value} does not point to a valid papyrus decompiler.");
                }
            }
        }

        private static void SetDefaultParameters() {
            decompiler.StartInfo.UseShellExecute = false;
            decompiler.StartInfo.CreateNoWindow = true;
            decompiler.StartInfo.RedirectStandardOutput = RedirectStdOut;
            decompiler.StartInfo.RedirectStandardError = RedirectStdErr;


            decompiler.EnableRaisingEvents = true;

            #region Output Streams
            decompiler.OutputDataReceived += (sender, e) =>
                                        StdOut += e.Data + Environment.NewLine ?? "";

            decompiler.ErrorDataReceived += (sender, e) =>
                                       StdErr += e.Data + Environment.NewLine ?? "";
            #endregion

        }

        private static DecompilerArgumentHandler argumentHandler;
        public static DecompilerArgumentHandler Arguments {
            get { return argumentHandler; }
            set {
                argumentHandler = value;
                RefreshArguments();
            }
        }

        private static void RefreshArguments() => decompiler.StartInfo.Arguments = argumentHandler.Parse();

        public static event DecompileEvent OnDecompiled;

        public delegate void DecompileEvent(string stdout);

        public static bool RedirectStdOut { get; set; } = true;
        public static bool RedirectStdErr { get; set; } = true;

        private static readonly Process decompiler = new Process();
        
    }
}

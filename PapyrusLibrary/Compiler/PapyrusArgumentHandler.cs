using System.IO;

namespace PapyrusLibrary
{
    /// <summary>
    /// Wrapper class to pass in arguments to the papyrus compiler.
    /// </summary>
    public class PapyrusArgumentHandler
    {
        /// <summary>
        /// The compiler's flag path, required by the compiler.
        /// </summary>
        public string FlagPath { get; set; }

        /// <summary>
        /// The path to where the scripts should be exported when compiled.
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// The path(s) to get scripts from, this can contain multiple paths separated by a semicolon.
        /// </summary>
        public string InputPath { get;  set; }

        /// <summary>
        /// The path to the script that is to be compiled. Due to the nature of the papyrus compiler,
        /// we can only compile one script at a time.
        /// </summary>
        public string Script { get; set; }

        /// <summary>
        /// Whether to optimize the compiled script or not, should be set to true when releasing scripts.
        /// </summary>
        public bool Optimize { get; set; }

        /// <summary>
        /// Enables debugging of the script
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// Does not report progress or success (only failures)
        /// </summary>
        public bool Quiet { get; set; }

        /// <summary>
        /// Does not generate an assembly file and does not run the assembler.
        /// </summary>
        public bool NoAssembly { get; set; }

        /// <summary>
        /// Keeps the assembly file after running the assembler.
        /// </summary>
        public bool KeepAssembly { get; set; }

        /// <summary>
        /// Generates an assembly file but does not run the assembler.
        /// </summary>
        public bool AssemblyOnly { get; set; }

        /// <summary>
        /// Combine input path with the desired script to compile for easier use.
        /// </summary>
        private string scriptToCompile { get { return $@"{mostRecentPath}\{Script}"; } }

        private string ScriptToCompile {
            get {
                if(Script == null) return null;
                return Path.Combine(mostRecentPath, Script);
            }
        }

        /// <summary>
        /// Adds the desired input path to search for scripts.
        /// </summary>
        /// <param name="path"></param>
        public void AddPath(string path)
        {
            /* Valid input path is as follows:
             * C:\Skyrim\Data\Scripts\Source;C:\Skyrim\MO\(ModName)\scripts\source; ...
             */
             string[] allPaths = InputPath.Split(';');

            for(int i = 0; i < allPaths.Length; i++) {
                System.Console.WriteLine($"Path {i}: {allPaths[i]}");

                //If the path already exists, return, we don't want duplicates.
                if(path == allPaths[i])
                    return;
            }

            InputPath += $";{path}";
            mostRecentPath = path;
        }

        private string mostRecentPath = "";

        /// <summary>
        /// Return the arguments in a known format by the compiler.
        /// </summary>
        /// <returns></returns>
        public string Parse()
        {
            /* Output line for the compiler
             * -f= path to the flag file
             * -i= path to the input scripts (.psc files)
             * -o= path to output, where the compiled scripts will go 
               -op optimize code for release mode 
               -d enable debugging mode for the script*/
            string output = $"\"{ScriptToCompile}\" " +
                            $"-f=\"{FlagPath}\" " +
                            $"-i=\"{InputPath}\" " +
                            $"-o=\"{OutputPath}\" " +
                            $"{(Optimize ? "-op" : "")}" +
                            $"{(Debug    ? "-d"  : "")}" +
                            $"{(Quiet    ? "-q"  : "")}" +

                            //Assembly Options
                            $"{(NoAssembly   ?   "-noasm"   : "")}" +
                            $"{(KeepAssembly ?   "-keepasm" : "")}" +
                            $"{(AssemblyOnly ?   "-asmonly" : "")}";
#if DEBUG
            System.Reflection.MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
            System.Console.WriteLine($"{method.ReflectedType.Name}.{method.Name}() -> {output}");
#endif
            return output;
        }

        /// <summary>
        /// Validate whether or not enough arguments have been passed to the compiler.
        /// </summary>
        /// <returns></returns>
        public bool IsValid() => !(string.IsNullOrEmpty(FlagPath)  && string.IsNullOrEmpty(OutputPath) &&
                                   string.IsNullOrEmpty(InputPath) && string.IsNullOrEmpty(Script));
    }
}

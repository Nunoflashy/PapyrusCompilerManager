using PapyrusUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModUtilsLib;
using PapyrusLibrary;
using PapyrusLibrary.Compiler;
using PapyrusLibrary.Decompiler;
using System.IO;

namespace PapyrusUI {
    public partial class ConfigCompilerForm : BorderlessDynamicForm {
        public ConfigCompilerForm() {
            base.InitializeComponent();
            InitializeComponent();

            mainContainer.Location = new Point(mainContainer.Location.X + 2, mainContainer.Location.Y + 2);
        }

        private void ConfigCompilerForm_SizeChanged(object sender, EventArgs e) {
            mainContainer.Width     = this.Width - 4;
            mainContainer.Height    = (this.Height-30) - 4;
        }

        private void MainContainer_Resize(object sender, EventArgs e) {
            
        }

        private string localMoPath = $@"{Application.StartupPath}\MO\mods";
        private void LoadModPaths() {
            ModInfo[] mods = ModManager.GetMods(localMoPath);
            foreach (ModInfo mod in mods) {
                try {
                    if (mod.HasSourceScripts) {
                        PapyrusCompiler.Arguments.AddPath($"{localMoPath}\\{mod.Name}\\scripts\\source");
                    }
                }
                catch (DirectoryNotFoundException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void OkBtn_Click(object sender, EventArgs e) {
            PapyrusCompiler.Path = mainPath.Text;
            PapyrusCompiler.Arguments.FlagPath = flagPath.Text;
            PapyrusCompiler.Arguments.InputPath = inputPath.Text;
            LoadModPaths();
            PapyrusCompilerConfig.Save();
        }

        private string GetFirstInputPath() {
            return PapyrusCompilerConfig.Arguments.InputPath.Substring(0, PapyrusCompilerConfig.Arguments.InputPath.IndexOf(';'));
        }

        private void ConfigCompilerForm_Load(object sender, EventArgs e) {
            PapyrusCompilerConfig.Load();

            if (PapyrusCompilerConfig.Path.Contains(Application.StartupPath)) {
                PapyrusCompiler.Path = PapyrusCompilerConfig.Path.Substring(Application.StartupPath.Length);
                Console.WriteLine("Contains Path: " + true);
            }

            mainPath.Text = PapyrusCompilerConfig.Path;

            Console.WriteLine("Startup Path: " + Application.StartupPath);

            if (PapyrusCompilerConfig.Arguments.FlagPath.Contains(Application.StartupPath)) {
                flagPath.Text = PapyrusCompilerConfig.Arguments.FlagPath.Substring(Application.StartupPath.Length);
            }
            else {
                flagPath.Text = PapyrusCompilerConfig.Arguments.FlagPath;
            }

            inputPath.Text = GetFirstInputPath();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using PapyrusLibrary;
using System.IO;
using NLog;
using ModUtilsLib;
using ModUtilsLib.Exception;
using PapyrusLibrary.Compiler;
using PapyrusLibrary.Script;

namespace PapyrusUI
{
    public partial class MainUI : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        private static void InitializeNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "gata.log"};
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
            
            logconsole.Layout = "[${date:format=dd/MM/yyyy - HH\\:mm\\:sstt}] ${level:uppercase=true}: ${message}";
            logfile.Layout    = "[${date:format=dd/MM/yyyy - HH\\:mm\\:sstt}] ${level:uppercase=true}: ${message}";
        }

        #region Resizable/Movable Window
        const int HTCLIENT      = 1;
        const int HTCAPTION     = 2;
        const int HTTOPLEFT     = 13;
        const int HTTOP         = 12;
        const int HTTOPRIGHT    = 14;
        const int HTLEFT        = 10;
        const int HTRIGHT       = 11;
        const int HTBOTTOMLEFT   = 16;
        const int HTBOTTOM      = 15;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == HTCLIENT)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);                        
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr) HTTOPLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr) HTTOP;
                            else
                                m.Result = (IntPtr) HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr) HTLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr) HTCAPTION;
                            else
                                m.Result = (IntPtr) HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr) HTBOTTOMLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr) HTBOTTOM;
                            else
                                m.Result = (IntPtr) HTBOTTOMRIGHT;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // Minimize on double click from taskbar
                return cp;
            }
        }
        #endregion

        bool maximized = false;
        private void MaximizeAndRestore()
        {
            this.WindowState = maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            maximized = !maximized;

            if(maximized) {
                maximizeBtn.Image = Properties.Resources.restore;
            }
            else {
                maximizeBtn.Image = Properties.Resources.maximize;
            }
            MainUI_Paint(this, null);
        }

        public MainUI()
        {
            InitializeComponent();
            InitializeNLog();
        }

        private void StartCompile()
        {
            //papyrus.StartInfo.Arguments = @"c:\Program Files (x86)\Steam\steamapps\common\Skyrim\Data\scripts\Source\mzin_sslb_lockedalias.psc" +
            //                  @"-f=C:\Program Files(x86)\Steam\steamapps\common\Skyrim\Data\scripts\Source\TESV_Papyrus_Flags.flg" +
            //                  @"-i=C:\Program Files (x86)\Steam\steamapps\common\Skyrim\Data\Scripts\Source" +
            //                  @"-o=C:\Program Files(x86)\Steam\steamapps\common\Skyrim\Data\Scripts -op";
        }

        private void SetPapyrusConfig()
        {
            globalConfigForm.CompilerPath = $@"{Application.StartupPath}\Papyrus Compiler\PapyrusCompiler.exe";
            globalConfigForm.InputScriptsPath = $@"{Application.StartupPath}\scripts\source";
            globalConfigForm.CompilerFlagPath = $@"{globalConfigForm.InputScriptsPath}\TESV_Papyrus_Flags.flg";
            globalConfigForm.OutputScriptsPath = $@"{Application.StartupPath}\output";
        }

        private void SetScriptsToLoad()
        {
            string scriptPath = PapyrusCompiler.Arguments.InputPath;
            DirectoryInfo di = new DirectoryInfo(scriptPath);
            FileInfo[] files = di.GetFiles();

            foreach (FileInfo file in files) {
                if(file.Name.Contains("mzin"))
                    scriptList.Items.Add(file);
            }

            string dir = Path.GetDirectoryName(scriptPath);
            string root = Directory.GetParent(dir).FullName;
            Console.WriteLine($"Directory is: {dir}");
            Console.WriteLine($"Parent directory is: {root}");
        }
        
        private void MainUI_Load(object sender, EventArgs e)
        {
            SetPapyrusConfig();

            PapyrusCompiler.Path = globalConfigForm.CompilerPath;
            PapyrusCompiler.Arguments = new PapyrusArgumentHandler() {
                FlagPath    = globalConfigForm.CompilerFlagPath,
                InputPath   = globalConfigForm.InputScriptsPath,
                OutputPath  = globalConfigForm.OutputScriptsPath,
                Script      = scriptList.GetItemText(scriptList.SelectedItem),
                Optimize    = true
            };

            Console.WriteLine(PapyrusCompiler.Path);
            Console.WriteLine(PapyrusCompiler.Arguments.FlagPath);
            Console.WriteLine(PapyrusCompiler.Arguments.InputPath);
            Console.WriteLine(PapyrusCompiler.Arguments.OutputPath);
            Console.WriteLine(PapyrusCompiler.Arguments.Script);

            //SetScriptsToLoad();

            string[] dirs = Directory.GetDirectories(localMoPath);


            LoadModList();

        }

        private string modOrganizerModsPath = @"C:\Program Files (x86)\Steam\steamapps\common\Skyrim\ModOrganizer2\mods\";
        private string localMoPath          = $@"{Application.StartupPath}\MO\mods";

        private void LoadModList()
        {
            ModInfo[] mods = ModManager.GetMods(localMoPath);

            foreach(ModInfo mod in mods) {
                projectList.Items.Add(mod.Name);

                if(!modDependencyList.ContainsKey(mod.Name)) {
                    modDependencyList[mod.Name] = new List<string>();
                }
            }
        }

        private ModInfo SelectedMod =>
            new ModInfo(Path.Combine(localMoPath, projectList.GetItemText(projectList.SelectedItem)));

        private void LoadScriptList()
        {
            scriptList.Items.Clear();

            // Gets the current mod from the list
            string selectedMod = projectList.GetItemText(projectList.SelectedItem);
            ModInfo mod = new ModInfo(Path.Combine(localMoPath, selectedMod));

            try {
                ScriptInfo[] sources = SelectedMod.SourceScripts;
                Console.WriteLine($"Has Scripts - {(SelectedMod.HasSourceScripts ? "Yes" : "No")}: {sources.Length}");

                for(int i = 0; i < sources.Length; i++) {
                    ScriptInfo script = sources[i];
                    Console.WriteLine(script.Name + (script.Inherits ? (" <----" + script.Extends) : null));
                    scriptList.Items.Add(script.Name);
                }

                //foreach (ScriptInfo script in sources) {
                //    Console.WriteLine(script.Name + (script.Inherits ? (" <----"  + SelectedMod.SourceScripts[0].Extends) : null));
                //    scriptList.Items.Add(script.Name);
                //}
            }
            catch (DirectoryNotFoundException) {
                logger.Info($"{SelectedMod.Name} -> Mod does not contain a source scripts directory.");
            }
            //string modPath = $@"C:\Program Files (x86)\Steam\steamapps\common\Skyrim\ModOrganizer2\mods\Death Alternative - Captured\scripts\source";

            //Console.WriteLine($"Papyrus Input Path: {PapyrusCompiler.Arguments.InputPath}");

            ////PapyrusCompiler.Arguments.InputPath = $"{scriptsSourceDir.FullName}";

            //if(scriptsSourceDir.Exists) {
                
            //    FileInfo[] sourceScripts = scriptsSourceDir.GetFiles();

            //    if(sourceScripts != null) {
            //        Console.WriteLine("Mod has scripts");
                    
            //        foreach(FileInfo script in sourceScripts) {
            //            scriptList.Items.Add(script.Name);
            //        }
            //    }

            //}
        }

        private void MainUI_DoubleClick(object sender, EventArgs e) => MaximizeAndRestore();

        private void MainUI_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
            Graphics gfx = CreateGraphics();
            gfx.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));

            brush.Color = Color.FromArgb(200, 200, 200);
            //gfx.DrawString(this.Text, new Font("Verdana", 7), brush, new Point(this.Width / 2 - (this.Text.Length / 2 + 24), 5));
            TextRenderer.DrawText(gfx, Text, new Font("Verdana", 7), new Point(this.Width / 2 - (this.Text.Length / 2 + 24), 5), brush.Color);
            brush.Dispose();
            gfx.Dispose();
        }

        private void MainUI_SizeChanged(object sender, EventArgs e)
        {
            // Force painting on resize
            MainUI_Paint(null, null);

            const int padding = 3; // To get the buttons closer to the edge of the window
            actionButtonsPanel.Location = new Point(this.Width - actionButtonsPanel.Width + padding, 0);
            
            sideBar.Location = new Point(1, 1);
            sideBar.Size     = new Size(220, Height-2);

            //extendedTabControl1.Size = new Size(Width-22, Height-22);
            extendedTabControl1.Width = Width-222;
            extendedTabControl1.Height = Height-30;
            //headerPanel1.Location = new Point(headerPanel1.Location.X, Height-205);
            //headerPanel1.Width = Width-222;
            //headerPanel1.Height = Height-10;
        }

        private void MainUI_KeyDown(object sender, KeyEventArgs e)
        {
        }

        #region Close Button
        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.FromArgb(208, 20, 46);
            closeBtn.Image = Properties.Resources.close_enter;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.FromArgb(30, 30, 30);
            closeBtn.Image = Properties.Resources.close;
        }

        private void closeBtn_MouseDown(object sender, MouseEventArgs e)
        {
            closeBtn.BackColor = Color.FromArgb(188, 0, 26);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion Close Button

        #region Maximize_Restore Button
        private void maximizeBtn_MouseEnter(object sender, EventArgs e)
        {
            maximizeBtn.BackColor = Color.FromArgb(82, 82, 82);
            if(!maximized)
                maximizeBtn.Image     = Properties.Resources.maximize_enter;
            else
                maximizeBtn.Image     = Properties.Resources.restore_enter;
        }

        private void maximizeBtn_MouseLeave(object sender, EventArgs e)
        {
            maximizeBtn.BackColor = Color.FromArgb(30, 30, 30);
            if(!maximized)
                maximizeBtn.Image     = Properties.Resources.maximize;
            else
                maximizeBtn.Image     = Properties.Resources.restore;
        }

        private void maximizeBtn_Click(object sender, EventArgs e) => MaximizeAndRestore();

        #endregion Maximize_Restore Button

        #region Minimize Button
        private void minimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            minimizeBtn.BackColor = Color.FromArgb(82, 82, 82);
            minimizeBtn.Image     = Properties.Resources.minimize_enter;
        }

        private void minimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            minimizeBtn.BackColor = Color.FromArgb(30, 30, 30);
            minimizeBtn.Image     = Properties.Resources.minimize;
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion Minimize Button

        

        private void StartCompilation()
        {
            textBox1.Text = "";
            //PapyrusCompiler.Compile(scriptList.GetItemText(scriptList.SelectedItem));
            //PapyrusCompiler.Arguments.InputPath = globalConfigForm.InputScriptsPath;
            //PapyrusCompiler.Arguments.InputPath += $@";{Application.StartupPath}\scripts\combat";
            //PapyrusCompiler.Arguments.AddPath($@"{Application.StartupPath}\scripts\combat");
            //PapyrusCompiler.Arguments.AddPath($@"{localMoPath}\{projectList.GetItemText(projectList.SelectedItem)}\scripts\source");
            DirectoryInfo modPath = new DirectoryInfo($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source");
            
            // Add the mod's dependencies from the list to the compiler's input path
            foreach (string dependency in dependsOnList.Items) {
                PapyrusCompiler.Arguments.AddPath(dependency);
            }
            PapyrusCompiler.Arguments.AddPath($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source");
            
            string selectedMod = projectList.GetItemText(projectList.SelectedItem);
            string[] selectedScripts = (from string script in scriptList.SelectedItems select script).ToArray();
            
            new Thread(() => {
                foreach(string script in selectedScripts) {
                    PapyrusCompiler.Arguments.OutputPath = $@"{Application.StartupPath}\output\{selectedMod}\scripts";

                    PapyrusCompiler.Compile(script);

                    if(PapyrusCompiler.StdOut.Contains("Assembly succeeded")) {
                        textBox1.Text += PapyrusCompiler.StdOut;
                    }
                    else {
                        textBox1.Text += PapyrusCompiler.StdErr;
                    }
                    //ShowErrorOutput();
                }
            }).Start();
            
            
            outputTextBox.ForeColor = Color.Red;
        }

        private void compileBtn_Click(object sender, EventArgs e)
        {
            StartCompilation();
        }

        private void ShowErrorOutput()
        {
            //foreach (string line in CompilerInfo.StdErr) {
            //    //Console.WriteLine(line);
            //    outputListBox.Items.Add(line);
            //    textBox1.ForeColor = Color.Red;
            //    textBox1.Text += line + Environment.NewLine;
            //}

            foreach (string line in CompilerInfo.StdErr) {
                Console.WriteLine(line);
                //logger.Error(line);
            }
        }

        private void projectsPanel_Click(object sender, EventArgs e)
        {
            projectsPanel.ExpandAndCollapse();
        }

        private void scriptsPanel_Click(object sender, EventArgs e)
        {
            scriptsPanel.ExpandAndCollapse();
        }

        private void extendedLabel8_Click(object sender, EventArgs e)
        {
            //string path = Path.Combine(globalConfigForm.InputScriptsPath, scriptsPath.Text);
            //Console.WriteLine(path);
            ////Console.WriteLine(System.IO.File.ReadAllBytes($@"{globalConfigForm.InputScriptsPath}\{scriptsPath.Text}"));
            //textBox1.Text = File.ReadAllText(path);
        }

        private void projectsPanel_MouseEnter(object sender, EventArgs e)
        {
            Console.WriteLine("Mouse enter");
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            Console.WriteLine("item activated");
        }

        private void scriptFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MainUI_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return) {
                if(!projectList.Items.Contains(addToProjectList.Text))
                    projectList.Items.Add(addToProjectList.Text);
            }
        }

        private void clearLogBtn_Click(object sender, EventArgs e)
        {
            outputListBox.Items.Clear();
            Console.Clear();
            Console.WriteLine(PapyrusCompiler.StdErr);
        }

        /// <summary>
        /// Retrieves all the mods currently in this path.
        /// </summary>
        /// <param name="moPath">The path to mod organizer's mod directory.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns></returns>
        //private FileInfo[] GetMods(string moPath)
        //{
        //    //Get the base directory of where all mods reside
        //    DirectoryInfo modsPath = new DirectoryInfo(moPath);

        //    //Get the mods' folders themselves
        //    FileInfo[] mods = modsPath.GetFiles();

        //    if(mods == null) {
        //        throw new DirectoryNotFoundException();
        //    }

        //    return mods;
        //}

        /// <summary>
        /// Retrieves all the mods currently in this path.
        /// </summary>
        /// <param name="moPath">The path to mod organizer's mod directory.</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <returns></returns>
        private DirectoryInfo[] GetModDirectories(string moPath)
        {
            //Get the base directory of where all mods reside
            DirectoryInfo modsPath = new DirectoryInfo(moPath);

            DirectoryInfo[] mods = modsPath.GetDirectories();

            return mods;
        }

        private DirectoryInfo[] GetModData(string path)
        {
            DirectoryInfo modData = new DirectoryInfo(path);

            DirectoryInfo[] subFolders = modData.GetDirectories();


            return subFolders;
        }
        

        private void modList_SelectedIndexChanged(object sender, EventArgs e)
        {
            modScriptList.Items.Clear();
            string path = @"C:\Program Files (x86)\Steam\steamapps\common\Skyrim\ModOrganizer2\mods\";
            string modName = modList.GetItemText(modList.SelectedItem);

            DirectoryInfo[] modDirectory = GetModDirectories(path);

            foreach(DirectoryInfo mod in modDirectory) {
                if(mod.Name.Contains("Death Alternative")) {
                    foreach(DirectoryInfo modSubFolder in GetModData(mod.FullName))
                    if(modSubFolder.Name.Contains("scripts")) {
                        foreach(FileInfo script in modSubFolder.GetFiles()) {
                                modScriptList.Items.Add($"{modSubFolder.Name}\\{script.Name}");
                        }            
                    }
                        
                }
            }

            

            //DirectoryInfo[] mods = GetModDirectories(path);
            //foreach(DirectoryInfo mod in mods) {
            //    string modPath = $@"{path}\{mod.Name}";
            //    foreach(DirectoryInfo subModFolder in new DirectoryInfo(modPath).GetDirectories()) {
            //        //Console.WriteLine($"{mod.Name}:{subModFolder.Name}");
            //        FileInfo[] scripts = subModFolder.GetFiles();
            //        foreach (FileInfo script in scripts) {
            //            if(script.Extension == ".psc" || script.Extension == ".pex")
            //            modScriptList.Items.Add(script);
            //        }
            //    }
            //}

            //string[] dirs = Directory.GetDirectories($"{path}\\{modName}");

            //DirectoryInfo modScriptsFolder = new DirectoryInfo($@"{path}\{modName}\scripts");
            //FileInfo[] modScriptsFiles     = modScriptsFolder.GetFiles();

            //foreach (string dir in dirs) {
            //    //string modScriptFolder = $@"{dir}\scripts\source";
            //    try {
            //        if (modScriptsFolder.Exists) {
            //            modScriptList.Items.Add(
            //            dir.Replace(path, "")
            //            .Replace(modList.GetItemText(modList.SelectedItem), "")
            //            .Trim('\\'));
            //        }
            //    }
            //    catch (Exception ex) {
            //        logger.Error(ex);
            //        throw;
            //    }


            //}
        }

        private void addPathBtn_Click(object sender, EventArgs e)
        {
            if(!importScriptsListBox.Items.Contains(globalConfigForm.InputScriptsPath))
                importScriptsListBox.Items.Add(globalConfigForm.InputScriptsPath);

            if(importScriptsTextBox.Text != string.Empty && Directory.Exists(importScriptsTextBox.Text))
                importScriptsListBox.Items.Add(importScriptsTextBox.Text);
            
        }

        private Dictionary<string, List<string>> modDependencyList = new Dictionary<string, List<string>>();

        private void projectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            dependsOnList.Items.Clear();

            try {
                //dependsOnList.Items.Add(modDependencyList[SelectedMod.Name]);
                foreach(string path in modDependencyList[SelectedMod.Name]) {
                    dependsOnList.Items.Add(path);
                }
            }
            catch (KeyNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }

            LoadScriptList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string modOrganizerModsPath = @"C:\Program Files (x86)\Steam\steamapps\common\Skyrim\ModOrganizer2\mods\";
            
            //Get MO's mod directory
            DirectoryInfo moModsDirectory = new DirectoryInfo(modOrganizerModsPath);

            //Get all mods directories in ModOrganizer/mods
            DirectoryInfo[] modDirectories = moModsDirectory.GetDirectories();

            //Get all mods that contain source scripts
            foreach(DirectoryInfo mod in modDirectories) {
                string currentDirectory = mod.FullName;

                if(Directory.Exists($@"{currentDirectory}\scripts\source")) {
                    string localModScriptsPath = $@"{localMoPath}\{mod.Name}\scripts\source";
                    Directory.CreateDirectory(localModScriptsPath);

                    // Get all source scripts from this mod
                    DirectoryInfo sourceScriptsDirectory = new DirectoryInfo($@"{moModsDirectory}\{mod.Name}\scripts\source");
                    FileInfo[] modSourceScripts = sourceScriptsDirectory.GetFiles();

                    foreach(FileInfo sourceScript in modSourceScripts) {

                        //if(!sourceScript.Exists) {
                            sourceScript.CopyTo($@"{localModScriptsPath}\{sourceScript.Name}");
                            Console.WriteLine($"{sourceScript.Name} copied.");
                        //}
                    }
                }
            }
        }

        private void directCompileBtn_Click(object sender, EventArgs e)
        {
            PapyrusCompiler.DirectCompile(compilerArguments.Text);
            ShowErrorOutput();
            Console.WriteLine(PapyrusCompiler.StdOut);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // modDependencyList[SelectedMod.Name] = dependencyTextBox.Text;

            bool containsMod = modDependencyList.ContainsKey(SelectedMod.Name);

            Console.WriteLine(containsMod);
            modDependencyList[SelectedMod.Name].Add(dependencyTextBox.Text);
            dependsOnList.Items.Add(modDependencyList[SelectedMod.Name][0]);
            //try {
            //    modDependencyList[SelectedMod.Name].Add(dependencyTextBox.Text);
            //}
            //catch (KeyNotFoundException) {
            //    modDependencyList[SelectedMod.Name] = new List<string>();
            //}
        }

        private void ScriptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ScriptInfo script in SelectedMod.SourceScripts)
            {
               
            }
            Console.WriteLine(SelectedMod.SourceScripts[scriptList.SelectedIndex].Extends);
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Adds a mod to the list of items of a ListBox
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mod"></param>
        public static void AddMod(this ListBox.ObjectCollection collection, ModInfo mod) => collection.Add(mod.Name);
    }

}
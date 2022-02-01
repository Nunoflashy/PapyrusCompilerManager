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
using PapyrusLibrary.Decompiler;
using PapyrusLibrary.Script;
using PapyrusLibrary.Compiler;
using System.Reflection;
using System.Linq.Expressions;

namespace PapyrusUI
{
    public partial class MainUI : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private PropertiesUI properties = new PropertiesUI();

        private enum ActionMode { Compilation, Decompilation };

        private ActionMode action = ActionMode.Compilation;
        
        ContextMenu cm = new ContextMenu();
        
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
        bool canBeMaximized = true;
        private void MaximizeAndRestore()
        {
            if(!canBeMaximized)
                return;

            Console.WriteLine("Maximized");
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
        private void MainUI_MouseDoubleClick(object sender, MouseEventArgs e) => MaximizeAndRestore();

        public MainUI()
        {
            InitializeComponent();
            InitializeNLog();

            cm.MenuItems.Add("OPEN IN EDITOR", (sender, e) => {
                Console.WriteLine("Opened in editor");
            });
            scriptList.ContextMenu = cm;

            this.Width = 600;
        }
        
        private void MainUI_Load(object sender, EventArgs e)
        {


            //PapyrusDecompilerConfig.Load();

            //PapyrusDecompiler.Path = PapyrusDecompilerConfig.Path;
            //PapyrusDecompiler.Arguments = PapyrusDecompilerConfig.Arguments;

            ////PapyrusDecompilerConfig.Save();

            //Console.WriteLine($"PapyrusDecompiler.Path: {PapyrusDecompiler.Path}");
            //Console.WriteLine($"PapyrusDecompiler.Arguments: {PapyrusDecompiler.Arguments.InputPath}");


            //PapyrusArgumentHandler args = PapyrusCompiler.Arguments.Deserialize();
            //Console.WriteLine(args.FlagPath);

            LoadModPaths();
            LoadModList();

            SetupCompiler();
            PapyrusCompilerConfig.Save();

            projectsPanel.MinimumHeight = 15;
            projectsPanel.MaximumHeight = (int)(13.3 * projectList.Items.Count);

            scriptsPanel.MinimumHeight = 15;
            scriptsPanel.MaximumHeight = Height - projectsPanel.Height;

            mainContainer.Location = new Point(2, menuStripPanel.Height);

            scriptInfoPanel.MinimumHeight = 15;
            scriptInfoPanel.MaximumHeight = 400;

            modsInstalledCount.Text = $"{projectList.Items.Count} Mods Installed";
            scriptsFromModCount.Text = $"{scriptList.Items.Count} Scripts";

        }
        
        private string modOrganizerModsPath = @"C:\Program Files (x86)\Steam\steamapps\common\Skyrim\ModOrganizer2\mods\";
        private string localMoPath          = $@"{Application.StartupPath}\MO\mods";

        private void LoadModList()
        {
            ModInfo[] mods = ModManager.GetMods(localMoPath);

            foreach(ModInfo mod in mods) {
                projectList.Items.AddMod(mod);

                if (!modDependencyList.ContainsKey(mod.Name)) {
                    modDependencyList[mod.Name] = new List<string>();
                }
            }


            LoadModPaths();
        }

        private ModInfo SelectedMod =>
            new ModInfo(Path.Combine(localMoPath, projectList.GetItemText(projectList.SelectedItem)));

        private ScriptInfo SelectedScript =>
            new ScriptInfo($"{localMoPath}\\{SelectedMod.Name}\\{(action == ActionMode.Compilation ? "scripts\\source" : "scripts")}\\{scriptList.GetItemText(scriptList.SelectedItem)}");

        private void LoadCompiledScriptsList() {
            scriptList.Items.Clear();

            try {
                ScriptInfo[] scripts = SelectedMod.Scripts;
                Console.WriteLine($"Has Scripts - {(SelectedMod.HasScripts ? "Yes" : "No")}: {scripts.Length}");
                foreach(ScriptInfo script in scripts) {
                    scriptList.Items.Add(script.Name);
                }
            }
            catch (DirectoryNotFoundException) {
                logger.Info($"{SelectedMod.Name} -> Mod does not contain a scripts directory.");
                errorList.AddError($"Info: {SelectedMod.Name} -> Mod does not contain a scripts directory.");
            }

            scriptsFromModCount.Text = $"{scriptList.Items.Count} Scripts";
        }

        private void LoadScriptList()
        {
            scriptList.Items.Clear();

            // Gets the current mod from the list
            string selectedMod = projectList.GetItemText(projectList.SelectedItem);
            ModInfo mod = new ModInfo(Path.Combine(localMoPath, selectedMod));
            
            try {
                ScriptInfo[] sources = SelectedMod.SourceScripts;
                Console.WriteLine($"Has Scripts - {(SelectedMod.HasSourceScripts ? "Yes" : "No")}: {sources.Length}");

                foreach(ScriptInfo source in sources) {
                    Console.WriteLine(source.Name + (source.Inherits ? (" extends" + source.Extends) : null));
                    scriptList.Items.Add(source.Name);
                }
            }
            catch (DirectoryNotFoundException) {
                logger.Info($"{SelectedMod.Name} -> Mod does not contain a source scripts directory.");
                errorList.AddError($"Info: {SelectedMod.Name} -> Mod does not contain a source scripts directory.");
            }

            scriptsFromModCount.Text = $"{scriptList.Items.Count} Scripts";
        }

        private void MainUI_DoubleClick(object sender, EventArgs e) => MaximizeAndRestore();

        private void MainUI_Paint(object sender, PaintEventArgs e) {
            using(Graphics gfx = CreateGraphics()) {
                Color MainBackColor = Color.FromArgb(30, 30, 30);
                Color MainForeColor = Color.FromArgb(200, 200, 200);
                using (SolidBrush brush = new SolidBrush(MainBackColor)) {
                    // Draw Titlebar
                    gfx.FillRectangle(brush, new Rectangle(1, 1, this.Width - 2, 24));
                    // Draw Titlebar's text
                    TextRenderer.DrawText(gfx, Text, new Font("Verdana", 7), new Point(this.Width / 2 - (this.Text.Length / 2 + 24), 5), MainForeColor);
                }
            }
        }

        private void MainUI_SizeChanged(object sender, EventArgs e) {
            const int padding = 1; // To get the buttons closer to the edge of the window
            actionButtonsPanel.Location = new Point(this.Width - actionButtonsPanel.Width-1, 1);
            
            //sideBar.Location = new Point(1, 1 + menuStripPanel.Height);
            sideBar.Size     = new Size(sideBar.Width, Height-20);

            if (WindowState == FormWindowState.Maximized) {
                maximizeBtn.Image = Properties.Resources.restore;
            }

            sideBarRight.Size = new Size(sideBarRight.Width, Height-50-(Height-bottomSplitter.Location.Y));
            mainContainer.Size = new Size(Width-3, Height - menuStripPanel.Height-1);
            //BackColor = Color.DodgerBlue;
            if(scriptsPanel.MaximumHeight > Height - projectsPanel.Height-20 ||
                scriptsPanel.Height < Height - projectsPanel.Height - 20) {
                scriptsPanel.Height = Height - projectsPanel.Height - 20;
            }
            scriptsPanel.Height = Height - projectsPanel.Height - 20 - errorList.Height;

            if(!sideBarRight.Visible) {
                sideBar.Width = this.Width;
            }

            UpdateControlLocation(modsInstalledCount);
            UpdateControlLocation(scriptsFromModCount);
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

        private void SetupCompiler() {
            PapyrusCompilerConfig.Load();
            PapyrusCompiler.Path = PapyrusCompilerConfig.Path;
            PapyrusCompiler.Arguments = PapyrusCompilerConfig.Arguments;
        }

        private void SetupDecompiler() {
            PapyrusDecompilerConfig.Load();
            PapyrusDecompiler.Path = PapyrusDecompilerConfig.Path;
            PapyrusDecompiler.Arguments = PapyrusDecompilerConfig.Arguments;
        }

        private void StartDecompilation() {
            SetupDecompiler();
            Console.WriteLine(PapyrusDecompilerConfig.Arguments);

            //PapyrusDecompilerConfig.Save();
            
            PapyrusDecompiler.OnDecompiled += (stdout) => {
                Console.WriteLine(stdout);
                statusBarLabel.Text = stdout != null ? "Decompiled Successfully" : "Decompilation Failed";
            };
            PapyrusDecompiler.Decompile(SelectedScript);
        }

        private string _stdout = null;
        private string _stderr = null;
        private void CompileScript() {
            string selectedMod = SelectedMod.Name;
            string selectedScript = SelectedScript.Name;

            PapyrusCompiler.Arguments.OutputPath = $@"{Application.StartupPath}\output\{selectedMod}\scripts";
            PapyrusCompiler.Arguments.ModPath = $@"{Application.StartupPath}\output\{selectedMod}\scripts\source";
            PapyrusCompiler.Compile(selectedScript);

            _stdout = PapyrusCompiler.StdOut;
            _stderr = PapyrusCompiler.StdErr;

            Console.WriteLine($"StdOut: {_stdout}");
            Console.WriteLine($"StdErr: {_stderr}");

        }



        private void StartCompilation() {
            textBox1.Text = "";
            errorList.Clear();
            CompileScript();

            if (PapyrusCompiler.CompiledSuccessfully()) {
                statusBarLabel.Text = "Build Successful";
                //textBox1.Text = _stdout;

                //string stdOutNoPath = PapyrusCompiler.StdOut.Substring
                //(0, PapyrusCompiler.StdOut.IndexOf(projectList.GetItemText(projectList.SelectedItem)));
                //textBox1.Text += stdOutNoPath;

            }
            else {
                statusBarLabel.Text = "Build Failed";

                var result = CompilerInfo.StdErr;
                for(int i = 0; i < result.Length; i++) {
                    string msg      = StdErrFormatter.GetMessageAtIndex(i);
                    ScriptInfo script   = StdErrFormatter.GetScriptAtIndex(i);
                    int line        = StdErrFormatter.GetLineAtIndex(i);
                    int col         = StdErrFormatter.GetColumnAtIndex(i);
                    Console.WriteLine($"{msg}: {script} [{line}, {col}]");
                    //errorList.AddError($"{msg}: {script} [{line}, {col}]");
                    errorList.AddError(msg, SelectedMod, script, line, col);
                }
                textBox1.Text = PapyrusCompiler.StdErr;
            }

            //Console.WriteLine(PapyrusCompiler.Arguments.Parse());
            Console.WriteLine(PapyrusCompiler.StdErr);

            errorListTabs.Visible = true;
        }

        //private void StartCompilation()
        //{
        //    textBox1.Text = "";
        //    //PapyrusCompiler.Arguments.AddPath("source");
        //    //PapyrusCompiler.Arguments.AddPath($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source");
        //    //Console.WriteLine(PapyrusCompiler.Arguments.Serialize());
        //    string selectedMod = projectList.GetItemText(projectList.SelectedItem);

        //    string[] selectedScripts = (from string script in scriptList.SelectedItems select script).ToArray();

        //    //List<string> selectedScripts = new List<string>();
        //    //foreach(ListViewItem lvi in scriptListView.SelectedItems) {
        //    //    selectedScripts.Add(lvi.Text);
        //    //}
            
        //    //ScriptInfo[] SelectedScripts = null;
        //    //foreach(ScriptInfo script in SelectedScripts) {
        //    //    new Thread(() => {

        //    //    });
        //    //}

        //    new Thread(() => {
        //        foreach (string script in selectedScripts) {
        //            PapyrusCompiler.Arguments.OutputPath = $@"{Application.StartupPath}\output\{selectedMod}\scripts";

        //            PapyrusCompiler.Compile(script);

        //            if(PapyrusCompiler.CompiledSuccessfully()) {
        //                statusBarLabel.Text = "Build Successful";
        //                textBox1.Text = PapyrusCompiler.StdOut;
        //            } else {
        //                statusBarLabel.Text = "Build Failed";
        //                textBox1.Text = PapyrusCompiler.StdErr;
        //            }

        //            if (PapyrusCompiler.CompiledSuccessfully()) {
        //                string stdOutNoPath = PapyrusCompiler.StdOut.Substring
        //                (0, PapyrusCompiler.StdOut.IndexOf(projectList.GetItemText(projectList.SelectedItem)));
        //                textBox1.Text += stdOutNoPath;
        //            }
        //            /*else*/
        //            {
        //                var result = PapyrusCompiler.StdErr.Split(new[] { '\n' });
        //                int index = 0;
        //                foreach (string line in result) {
        //                    try {
        //                        if (line != string.Empty && line != " " && line != "\n") {
        //                            Console.WriteLine($"{line.Substring(line.LastIndexOf("\\") + 1)}");
        //                            string currentMod = projectList.GetItemText(projectList.SelectedItem);
        //                            textBox1.Text = PapyrusCompiler.StdOut;
        //                            string itemToAdd = $"{line.Substring(line.LastIndexOf("\\") + 1)}";
        //                            string errorMessage = $"{itemToAdd.Substring(itemToAdd.IndexOf(':') + 2)}";
        //                            textBox1.Text = errorMessage;
        //                            Console.WriteLine(errorMessage);
        //                            //if (itemToAdd.Contains("unable to locate script")) {
        //                            //    itemToAdd += " (missing dependency)";
        //                            //}
        //                            errorList.AddError(itemToAdd);
        //                            //errorList.Items.Add(itemToAdd);
        //                            //errorCountLabel.Text = $"{errorList.Items.Count.ToString()} Errors";
        //                            statusBarLabel.Text = "Build Failed";
        //                        }
        //                    }
        //                    catch (Exception ex) {
        //                        Console.WriteLine(ex.Message);
        //                        logger.Error(ex);
        //                    }

        //                }
        //                //textBox1.Text = PapyrusCompiler.StdErr;
        //            }
        //            ShowErrorOutput();
        //        }
        //    }).Start();

        //    errorListTabs.Visible = true;

        //    //outputTextBox.ForeColor = Color.Red;
        //}

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
            }
        }

        private void projectsPanel_Click(object sender, EventArgs e)
        {
            // Determine maximum height of the script panel based on the project panel
            scriptsPanel.MaximumHeight = Height - projectsPanel.Height-50;
            //projectsPanel.ExpandAndCollapse();
        }

        private void scriptsPanel_Click(object sender, EventArgs e)
        {
            //scriptsPanel.ExpandAndCollapse();
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

        private void MainUI_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return) {
                //if(!projectList.Items.Contains(addToProjectList.Text))
                    //projectList.Items.Add(addToProjectList.Text);
            }
        }

        private Dictionary<string, List<string>> modDependencyList = new Dictionary<string, List<string>>();

        private void projectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            sideBarRight.Visible = false;
            decompileScriptPanel.Visible = false;
            buildScriptPanel.Visible = false;

            //this.Width = sideBar.Width;
            sideBar.Width = this.Width;
            this.canBeMaximized = false;

            if (this.WindowState == FormWindowState.Maximized) {
                this.WindowState = FormWindowState.Normal;
            }

            Console.WriteLine(projectList.GetItemText(projectList.SelectedItem));

            statusBarLabel.Text = "No Script Selected";

            swapToDecompileImage.Visible = SelectedMod.HasScripts;
            swapToBuildImage.Visible = SelectedMod.HasSourceScripts;

            if (action == ActionMode.Compilation)        LoadScriptList();
            //else if(action == ActionMode.Compilation)   LoadCompiledScriptsList();

                if (scriptsPanel.Height == scriptsPanel.MinimumHeight) {
                scriptsPanel.ExpandAndCollapse();
            }
        }

        private void ShowScriptInfo(ScriptInfo script) {
            if (script.Extends != null)
                scriptnameLabel.Text = $"{script.Name.Replace(".psc", "")} : {script.Extends}";
            else {
                scriptnameLabel.Text = $"{script.Name.Replace(".psc", "")}";
            }

            scriptnameLabel.Text += $" ({script.LinesOfCode} LOC)";
        }

        private void ShowScriptStates(ScriptInfo script) {
            stateList.Items.Clear();
            foreach (var state in script.States) {
                ListViewItem lvi = new ListViewItem(state, 0) {
                    StateImageIndex = 0,
                    ForeColor = Color.White
                };
                stateList.Items.Add(lvi);
            }
        }

        private void ShowScriptImports(ScriptInfo script) {
            if (script.Imports.Length != 0) {
                foreach (var import in script.Imports) {
                    ListViewItem lvi = new ListViewItem(import, 1);
                    lvi.StateImageIndex = 1;
                    lvi.ForeColor = Color.White;
                    stateList.Items.Add(lvi);
                }
            }
        }

        private void ShowScriptFunctions(ScriptInfo script) {
            functionList.AddFunctions(script.Functions);
        }

        private void ShowScriptFragments(ScriptInfo script) {
            functionList.AddFragments(script.Fragments);
        }

        private void ShowScriptEvents(ScriptInfo script) {
            functionList.AddEvents(script.Events);
        }

        private void ShowScriptProperties(ScriptInfo script) {
            propertyList.Add(script.Properties);
        }

        /// <summary>
        /// Stores the previous script when selecting a new one
        /// </summary>
        private string _oldScriptName = null;

        private void ScriptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scriptList.SelectedItem == null || scriptList.GetItemText(scriptList.SelectedItem) == _oldScriptName)
                return;

            functionList.Clear();
            propertyList.Clear();

            scriptsFromModCount.Text = $"{scriptList.Items.Count} Scripts ({scriptList.SelectedItems.Count} selected)";

            ScriptInfo script = null;

            if(action == ActionMode.Compilation) {
                script = new ScriptInfo($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source\\{scriptList.GetItemText(scriptList.SelectedItem)}");
            }
            else if(action == ActionMode.Decompilation) {
                script = new ScriptInfo($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\{scriptList.GetItemText(scriptList.SelectedItem)}");
            }

            if(script == null)
                return;

            _oldScriptName = SelectedScript.Name;

            ShowScriptInfo(script);

            if(script.HasStates)     ShowScriptStates(script);
            if(script.HasImports)    ShowScriptImports(script);
            if(script.HasFunctions)  ShowScriptFunctions(script);
            if(script.HasFragments)  ShowScriptFragments(script);
            if(script.HasEvents)     ShowScriptEvents(script);
            if(script.HasProperties) ShowScriptProperties(script);
            
            sideBarRight.Visible = script.HasFunctions || script.HasFragments || script.HasEvents;



            if (sideBarRight.Visible) {
                //this.Width = 800;
                this.canBeMaximized = true;
                sideBar.Width = this.Width / 2;
            }

            
            if(action == ActionMode.Compilation)         SetupBuildScriptPanel();
            else if (action == ActionMode.Decompilation) SetupDecompileScriptPanel();

            statusBarLabel.Text = "Ready";

            UpdateControlLocation(modsInstalledCount);
            UpdateControlLocation(scriptsFromModCount);
        }

        private void BuildScriptMenuItem_Click(object sender, EventArgs e) {
            StartCompilation();
        }

        private void ClearBuildLogMenuItem_Click(object sender, EventArgs e) {
            Console.Clear();
            Console.WriteLine(PapyrusCompiler.StdErr);
        }

        private void CopyMOScriptsMenuItem_Click(object sender, EventArgs e) {
            string modOrganizerModsPath = @"C:\Program Files (x86)\Steam\steamapps\common\Skyrim\ModOrganizer2\mods\";

            //Get MO's mod directory
            DirectoryInfo moModsDirectory = new DirectoryInfo(modOrganizerModsPath);

            //Get all mods directories in ModOrganizer/mods
            DirectoryInfo[] modDirectories = moModsDirectory.GetDirectories();

            //Get all mods that contain source scripts
            foreach (DirectoryInfo mod in modDirectories) {
                string currentDirectory = mod.FullName;

                if (Directory.Exists($@"{currentDirectory}\scripts\source")) {
                    string localModScriptsPath = $@"{localMoPath}\{mod.Name}\scripts\source";
                    Directory.CreateDirectory(localModScriptsPath);

                    // Get all source scripts from this mod
                    DirectoryInfo sourceScriptsDirectory = new DirectoryInfo($@"{moModsDirectory}\{mod.Name}\scripts\source");
                    FileInfo[] modSourceScripts = sourceScriptsDirectory.GetFiles();

                    foreach (FileInfo sourceScript in modSourceScripts) {

                        //if(!sourceScript.Exists) {
                        sourceScript.CopyTo($@"{localModScriptsPath}\{sourceScript.Name}");
                        Console.WriteLine($"{sourceScript.Name} copied.");
                        //}
                    }
                }
            }
        }

        private void ScriptList_DoubleClick(object sender, EventArgs e) {
            //string selectedScript = scriptList.GetItemText(scriptList.SelectedItem);
            //if(scriptList.SelectedItem != null && !mainTabControl.TabPages.ContainsKey(selectedScript)) {
            //    mainTabControl.TabPages.Add(selectedScript);
            //}
            if(action == ActionMode.Compilation) {
                ScriptViewer sv = new ScriptViewer();
                sv.ViewScript(SelectedScript);
            }
        }

        //private void ErrorListTextbox_TextChanged(object sender, EventArgs e) {
        //    if(errorList.Items.Contains(errorListTextbox.Text)) {
        //        errorList.Items.Clear();
        //        var result = PapyrusCompiler.StdErr.Split(new[] { '\n' });
        //        foreach (string line in result) {
        //            try {
        //                if (line != string.Empty && line != " ") {
        //                    Console.WriteLine($"{line.Substring(line.LastIndexOf("\\") + 1)}");
        //                    string currentMod = projectList.GetItemText(projectList.SelectedItem);
        //                    textBox1.Text = PapyrusCompiler.StdOut;
        //                    string itemToAdd = $"{line.Substring(line.LastIndexOf("\\") + 1)}";
        //                    if (itemToAdd.Contains("unable to locate script")) {
        //                        itemToAdd += " (missing dependency)";
        //                    }

        //                    errorList.Items.Add(itemToAdd);
        //                    errorCountLabel.Text = $"{errorList.Items.Count.ToString()} Errors";
        //                }
        //            }
        //            catch (Exception ex) {
        //                Console.WriteLine(ex.Message);
        //                throw;
        //            }

        //        }
        //    }
        //}

        private void BottomSplitter_SplitterMoved(object sender, SplitterEventArgs e) {
            const int padding = 20;
            sideBarRight.Size = new Size(sideBarRight.Width, Height - padding - (Height - bottomSplitter.Location.Y));
            //mainTabControl.Height = Height - padding - (Height - bottomSplitter.Location.Y);
            sideBar.Height = Height - padding - (Height - bottomSplitter.Location.Y);
            scriptsPanel.MaximumHeight = Height - padding - (Height - bottomSplitter.Location.Y);
        }

        private void HeaderPanel1_Click(object sender, EventArgs
            e) {
            //headerPanel1.ExpandAndCollapse();
        }

        private void LoadModPaths() {
            ModInfo[] mods = ModManager.GetMods(localMoPath);
            foreach(ModInfo mod in mods) {
                try {
                    if(mod.HasSourceScripts) {
                        //PapyrusCompiler.Arguments.AddPath($"{localMoPath}\\{mod.Name}\\scripts\\source");
                    }
                }
                catch (DirectoryNotFoundException ex) {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void SplitterMiddle_SplitterMoved(object sender, SplitterEventArgs e) {
            UpdateControlLocation(modsInstalledCount);
            UpdateControlLocation(scriptsFromModCount);

            if(action == ActionMode.Compilation)
                UpdateControlLocation(buildScriptBtn);

            if(action == ActionMode.Decompilation)
                UpdateControlLocation(decompileScriptBtn);
        }

        /// <summary>
        /// Updates the specified control, should be used when a resize/resizing event occurs
        /// to keep the controls centered if the control specified depends on the control said event is modifying.
        /// </summary>
        /// <param name="c">the control to have its location updated</param>
        private void UpdateControlLocation(Control c) {
            if(c == modsInstalledCount) {
                // Center the mod count label based on the width of its container
                Point modsCountOldLoc = modsInstalledCount.Location;
                modsInstalledCount.Location = new Point((panel4.Width / 2) - (modsInstalledCount.Width / 2), modsCountOldLoc.Y);
                return;
            }
            if(c == scriptsFromModCount) {
                // Center the script count label based on the width of its container
                Point scriptCountOldLoc = scriptsFromModCount.Location;
                scriptsFromModCount.Location = new Point((panel6.Width / 2) - (scriptsFromModCount.Width / 2), scriptCountOldLoc.Y);
                return;
            }
            if (c == buildScriptBtn) {
                Point buildScriptBtnOldLoc = buildScriptBtn.Location;
                buildScriptBtn.Location = new Point((buildScriptPanel.Width / 2) - (buildScriptBtn.Width / 2), buildScriptBtnOldLoc.Y);
                return;
            }
            if(c == decompileScriptBtn) {
                Point decompileScriptBtnOldLoc = decompileScriptBtn.Location;
                decompileScriptBtn.Location = new Point((decompileScriptPanel.Width / 2) - (decompileScriptBtn.Width / 2), decompileScriptBtnOldLoc.Y);
                return;
            }
        }

        private void SplitterMiddle_SplitterMoving(object sender, SplitterEventArgs e) {
            Console.WriteLine($"Splitter location: {splitterMiddle.Location}");
        }


        private void SetupBuildScriptPanel() {
            buildScriptPanel.Visible = true;
            decompileScriptPanel.Visible = false;
            UpdateControlLocation(buildScriptBtn);
            UpdateControlLocation(decompileScriptBtn);
        }

        private void SetupDecompileScriptPanel() {
            decompileScriptPanel.Visible = true;
            buildScriptPanel.Visible = false;
            UpdateControlLocation(decompileScriptBtn);
            UpdateControlLocation(buildScriptBtn);
        }

        private void BuildScriptBtn_Click(object sender, EventArgs e) {
            StartCompilation();
        }

        private void DecompileScriptBtn_Click(object sender, EventArgs e) {
            StartDecompilation();
        }

        private void SwapToDecompileImage_Click(object sender, EventArgs e) {
            action = ActionMode.Decompilation;
            LoadCompiledScriptsList();
            SetupDecompileScriptPanel();
        }

        private void SwapToBuildImage_Click(object sender, EventArgs e) {
            action = ActionMode.Compilation;
            LoadScriptList();
            SetupBuildScriptPanel();
        }

        private void MainUI_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 'd') Console.WriteLine(SelectedScript.Path);
            if (e.KeyChar == 'm') Console.WriteLine(SelectedMod.Name);
        }

        private void FunctionList_FunctionAdded(PapyrusFunction function) {
            Console.WriteLine($"Function added: {function.Name}");
        }

        private void CfgCompilerMenuItem_Click(object sender, EventArgs e) {
            ConfigCompilerForm compilerCfg = new ConfigCompilerForm();
            compilerCfg.ShowDialog();
        }

        private void MainUI_Resize(object sender, EventArgs e) {
            Invalidate();
        }



        //private void LoadModPaths() {
        //    string[] paths = new string[] {
        //        $"{localMoPath}\\SkyrimBase\\scripts\\source",
        //        $"{localMoPath}\\SexLab Framework\\scripts\\source",
        //        $"{localMoPath}\\ZAZ Animation Pack\\scripts\\source"
        //    };

        //    List<string> allPaths = new List<string>();
        //    foreach(string mod in projectList.Items) {
        //        //allPaths.Add($"{localMoPath}\\{mod}\\scripts\\source");

        //        string currentPath = $"{localMoPath}\\{mod}";
        //        ModInfo mi = new ModInfo(currentPath);
        //        try {
        //            if (mi.HasSourceScripts) {
        //                Console.WriteLine(mod);
        //                PapyrusCompiler.Arguments.AddPath($"{currentPath}\\scripts\\source");
        //            }
        //        }
        //        catch (DirectoryNotFoundException ex) {
        //            Console.WriteLine(ex.Message);
        //        }
        //    }

        //    foreach(string path in paths) {
        //        // PapyrusCompiler.Arguments.AddPath(path);
        //        // Console.WriteLine($"Loaded Path: {path}\n");
        //    }

        //    Console.WriteLine();
        //    PapyrusCompiler.Arguments.Parse();
        //}
    }



    public static class Extensions
    {
        /// <summary>
        /// Adds a mod to the list of items of a ListBox
        /// </summary>
        /// <param name="list"></param>
        /// <param name="mod"></param>
        public static void AddMod(this ListBox.ObjectCollection collection, ModInfo mod) => collection.Add(mod.Name);

        private delegate void SetPropertyThreadSafeDelegate<TResult>(
    Control @this,
    Expression<Func<TResult>> property,
    TResult value);

        public static void SetPropertyThreadSafe<TResult>(
            this Control @this,
            Expression<Func<TResult>> property,
            TResult value) {
            var propertyInfo = (property.Body as MemberExpression).Member
                as PropertyInfo;

            if (propertyInfo == null ||
                !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
                @this.GetType().GetProperty(
                    propertyInfo.Name,
                    propertyInfo.PropertyType) == null) {
                throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            }

            if (@this.InvokeRequired) {
                @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
                (SetPropertyThreadSafe),
                new object[] { @this, property, value });
            }
            else {
                @this.GetType().InvokeMember(
                    propertyInfo.Name,
                    BindingFlags.SetProperty,
                    null,
                    @this,
                    new object[] { value });
            }
        }

    }

}
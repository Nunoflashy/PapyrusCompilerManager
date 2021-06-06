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

        private PropertiesUI properties = new PropertiesUI();
        
        ContextMenu cm = new ContextMenu();

        private ModInfo ActiveMod = null;
        private ScriptInfo SelectedScript = null;
        
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
        }

        private void StartCompile()
        {
            //papyrus.StartInfo.Arguments = @"c:\Program Files (x86)\Steam\steamapps\common\Skyrim\Data\scripts\Source\mzin_sslb_lockedalias.psc" +
            //                  @"-f=C:\Program Files(x86)\Steam\steamapps\common\Skyrim\Data\scripts\Source\TESV_Papyrus_Flags.flg" +
            //                  @"-i=C:\Program Files (x86)\Steam\steamapps\common\Skyrim\Data\Scripts\Source" +
            //                  @"-o=C:\Program Files(x86)\Steam\steamapps\common\Skyrim\Data\Scripts -op";
        }

        private void SetupScintilla() {
            //scintilla1.Text = "";
            //scintilla1.Margins[0].Width = 10;
            //scintilla1.Styles[ScintillaNET.Style.Default].BackColor = Color.FromArgb(30, 30, 30);
            //scintilla1.Styles[ScintillaNET.Style.Cpp.GlobalClass].BackColor = Color.FromArgb(30, 30, 30);
            //scintilla1.Lexer = ScintillaNET.Lexer.Cpp;
            //scintilla1.Styles[ScintillaNET.Style.Cpp.String].Font = "Consolas";
            //scintilla1.Styles[ScintillaNET.Style.Cpp.String].Size = 14;
            //scintilla1.Styles[ScintillaNET.Style.Cpp.String].BackColor = Color.FromArgb(30, 30, 30);
            //scintilla1.Styles[ScintillaNET.Style.Cpp.String].ForeColor = Color.White;
            //scintilla1.SetKeywords(0, "event function bool int while");
            //scintilla1.SetKeywords(1, "GlobalVariable Property Auto ReadOnly AutoReadOnly");
            //scintilla1.Styles[ScintillaNET.Style.Cpp.Word].BackColor = Color.FromArgb(30, 30, 30);
            //scintilla1.Styles[ScintillaNET.Style.Cpp.Word].ForeColor = Color.DodgerBlue;
            //scintilla1.Styles[ScintillaNET.Style.Cpp.Word2].BackColor = Color.FromArgb(30, 30, 30);
            //scintilla1.Styles[ScintillaNET.Style.Cpp.Word2].ForeColor = Color.Coral;
            //scintilla1.Styles[ScintillaNET.Style.LineNumber].BackColor = Color.FromArgb(30, 30, 30);
            //scintilla1.Styles[ScintillaNET.Style.LineNumber].ForeColor = Color.White;
            //Console.WriteLine(scintilla1.DescribeKeywordSets());
        }

        private void SetPapyrusConfig() {
            globalConfigForm.CompilerPath = $@"{Application.StartupPath}\Papyrus Compiler\PapyrusCompiler.exe";
            globalConfigForm.InputScriptsPath = $@"{Application.StartupPath}\scripts\source";
            globalConfigForm.CompilerFlagPath = $@"{globalConfigForm.InputScriptsPath}\TESV_Papyrus_Flags.flg";
            globalConfigForm.OutputScriptsPath = $@"{Application.StartupPath}\output";
        }
        
        private void MainUI_Load(object sender, EventArgs e)
        {
            // SetupScintilla();
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

            projectsPanel.MinimumHeight = 15;
            //projectsPanel.MaximumHeight = 280;
            projectsPanel.MaximumHeight = (int)(13.3 * projectList.Items.Count);

            scriptsPanel.MinimumHeight = 15;
            scriptsPanel.MaximumHeight = Height - projectsPanel.Height;

            //sideBarRight.Size = new Size(sideBarRight.Width, Height-40);
            mainContainer.Location = new Point(2, menuStripPanel.Height);

            headerPanel1.MinimumHeight = 15;
            headerPanel1.MaximumHeight = 400;

            modsInstalledCount.Text = $"{projectList.Items.Count} Mods Installed";
            scriptsFromModCount.Text = $"{scriptList.Items.Count} Scripts";

            headerPanel1.AnimationSpeed = 8;

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

        private void LoadScriptList()
        {
            scriptList.Items.Clear();

            // Gets the current mod from the list
            string selectedMod = projectList.GetItemText(projectList.SelectedItem);
            ModInfo mod = new ModInfo(Path.Combine(localMoPath, selectedMod));
            ActiveMod = mod;
            try {
                ScriptInfo[] sources = SelectedMod.SourceScripts;
                Console.WriteLine($"Has Scripts - {(SelectedMod.HasSourceScripts ? "Yes" : "No")}: {sources.Length}");

                for(int i = 0; i < sources.Length; i++) {
                    ScriptInfo script = sources[i];
                    Console.WriteLine(script.Name + (script.Inherits ? (" extends" + script.Extends) : null));
                    scriptList.Items.Add(script.Name);
                }

                //foreach (ScriptInfo script in sources) {
                //    Console.WriteLine(script.Name + (script.Inherits ? (" <----"  + SelectedMod.SourceScripts[0].Extends) : null));
                //    scriptList.Items.Add(script.Name);
                //}
            }
            catch (DirectoryNotFoundException) {
                logger.Info($"{SelectedMod.Name} -> Mod does not contain a source scripts directory.");
                errorList.Items.Add($"Info: {SelectedMod.Name} -> Mod does not contain a source scripts directory.");
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
            //scriptsPanel.MaximumHeight = Height-projectsPanel.Height-150;
            //scriptsPanel.MaximumHeight = Height - projectsPanel.Height;
            Console.WriteLine("Scripts Panel Height: " + scriptsPanel.Height);
        }

        private void MainUI_SizeChanged(object sender, EventArgs e) {
            // Force painting on resize
            MainUI_Paint(null, null);

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
            //foreach (string dependency in dependsOnList.Items) {
            //    PapyrusCompiler.Arguments.AddPath(dependency);
            //}
            PapyrusCompiler.Arguments.AddPath($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source");
            
            string selectedMod = projectList.GetItemText(projectList.SelectedItem);

            string[] selectedScripts = (from string script in scriptList.SelectedItems select script).ToArray();

            //List<string> selectedScripts = new List<string>();
            //foreach(ListViewItem lvi in scriptListView.SelectedItems) {
            //    selectedScripts.Add(lvi.Text);
            //}
            
            //ScriptInfo[] SelectedScripts = null;
            //foreach(ScriptInfo script in SelectedScripts) {
            //    new Thread(() => {

            //    });
            //}

            new Thread(() => {
                foreach (string script in selectedScripts) {
                    PapyrusCompiler.Arguments.OutputPath = $@"{Application.StartupPath}\output\{selectedMod}\scripts";

                    PapyrusCompiler.Compile(script);

                    if(PapyrusCompiler.CompiledSuccessfully()) {
                        statusBarLabel.Text = "Build Successful";
                        textBox1.Text = PapyrusCompiler.StdOut;
                    } else {
                        statusBarLabel.Text = "Build Failed";
                        textBox1.Text = PapyrusCompiler.StdErr;
                    }

                    //if (PapyrusCompiler.CompiledSuccessfully()) {
                    //    string stdOutNoPath = PapyrusCompiler.StdOut.Substring
                    //    (0, PapyrusCompiler.StdOut.IndexOf(projectList.GetItemText(projectList.SelectedItem)));
                    //    textBox1.Text += stdOutNoPath;
                    //}
                    /*else*/
                    //{
                    //    var result = PapyrusCompiler.StdErr.Split(new[] { '\n' });
                    //    int index = 0;
                    //    foreach (string line in result) {
                    //        try {
                    //            if (line != string.Empty && line != " ") {
                    //                Console.WriteLine($"{line.Substring(line.LastIndexOf("\\") + 1)}");
                    //                string currentMod = projectList.GetItemText(projectList.SelectedItem);
                    //                textBox1.Text = PapyrusCompiler.StdOut;
                    //                string itemToAdd = $"{line.Substring(line.LastIndexOf("\\") + 1)}";
                    //                string errorMessage = $"{itemToAdd.Substring(itemToAdd.IndexOf(':') + 2)}";
                    //                Console.WriteLine(errorMessage);
                    //                if (itemToAdd.Contains("unable to locate script")) {
                    //                    itemToAdd += " (missing dependency)";
                    //                }

                    //                errorList.Items.Add(itemToAdd);
                    //                errorCountLabel.Text = $"{errorList.Items.Count.ToString()} Errors";
                    //                statusBarLabel.Text = "Build Failed";
                    //            }
                    //        }
                    //        catch (Exception ex) {
                    //            Console.WriteLine(ex.Message);
                    //            logger.Error(ex);
                    //        }

                    //    }
                    //    //textBox1.Text = PapyrusCompiler.StdErr;
                    //}
                    //ShowErrorOutput();
                }
            }).Start();


            //outputTextBox.ForeColor = Color.Red;
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

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            Console.WriteLine("item activated");
        }

        private void MainUI_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Return) {
                //if(!projectList.Items.Contains(addToProjectList.Text))
                    //projectList.Items.Add(addToProjectList.Text);
            }
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

        private DirectoryInfo[] GetModData(string path) {
            DirectoryInfo modData = new DirectoryInfo(path);
            DirectoryInfo[] subFolders = modData.GetDirectories();
            return subFolders;
        }
        

        private void addPathBtn_Click(object sender, EventArgs e)
        {
            //if(!importScriptsListBox.Items.Contains(globalConfigForm.InputScriptsPath))
            //    importScriptsListBox.Items.Add(globalConfigForm.InputScriptsPath);

            //if(importScriptsTextBox.Text != string.Empty && Directory.Exists(importScriptsTextBox.Text))
            //    importScriptsListBox.Items.Add(importScriptsTextBox.Text);
            
        }

        private Dictionary<string, List<string>> modDependencyList = new Dictionary<string, List<string>>();

        private void projectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //dependsOnList.Items.Clear();

            try {
                //dependsOnList.Items.Add(modDependencyList[SelectedMod.Name]);
                foreach(string path in modDependencyList[SelectedMod.Name]) {
                    //dependsOnList.Items.Add(path);
                    
                }
                Console.WriteLine(projectList.GetItemText(projectList.SelectedItem));
            }
            catch (KeyNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }

            LoadScriptList();

            if(scriptsPanel.Height == scriptsPanel.MinimumHeight) {
                scriptsPanel.ExpandAndCollapse();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool containsMod = modDependencyList.ContainsKey(SelectedMod.Name);
            Console.WriteLine(containsMod);
        }

        private void LoadFunctionList() {
            functionList.Items.Clear();

            //extendedTabControl1.Visible = true;
            sideBarRight.Visible = true;

            string currentScript =
                $"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source\\{scriptList.GetItemText(scriptList.SelectedItem)}";


            const int IMAGELIST_FUNCTION = 0;
            const int IMAGELIST_FRAGMENT = 1;
            const int IMAGELIST_EVENT    = 2;

            ScriptInfo script = new ScriptInfo(currentScript);
            SelectedScript = script;

            if(script.Extends != null)
                scriptnameLabel.Text = $"{script.Name.Replace(".psc", "")} : {script.Extends}";
            else {
                scriptnameLabel.Text = $"{script.Name.Replace(".psc", "")}";
            }

            //foreach(var callable in script.Callables) {
            //    switch(callable.Type) {
            //        case CallableType.Function:
            //            // Parse functions
            //        break;
            //        case CallableType.Fragment:
            //            // Parse fragment functions
            //        break;
            //        case CallableType.Event:
            //            // Parse events
            //        break;
            //    }
            //}

            stateList.Items.Clear();
            foreach(var state in script.States) {
                ListViewItem lvi = new ListViewItem(state, 0) {
                    StateImageIndex = 0,
                    ForeColor = Color.White
                };
                stateList.Items.Add(lvi);
            }
            foreach(var import in script.Imports) {
                ListViewItem lvi = new ListViewItem(import);
                lvi.StateImageIndex = 1;
                lvi.ForeColor = Color.White;
                stateList.Items.Add(lvi);
            }

            //foreach(var state in PapyrusState.GetScriptStates(script)) {
            //    int start = state.GetLineBegin();
            //    int end   = state.GetLineEnd();

            //}

            foreach(var function in script.Functions) {
                functionList.Items.AddFunction(function);
            }
            foreach(var ev in script.Events) {
                functionList.Items.AddEvent(ev);
            }
            tabPage4.Controls.Clear();
            foreach(var prop in script.Properties) {
                List<ExtendedLabel> lbls = new List<ExtendedLabel>();
                ExtendedLabel lbl = new ExtendedLabel() {
                    BackColor = extendedLabel5.BackColor,
                    Image = extendedLabel5.Image,
                    ForeColor = extendedLabel5.ForeColor,
                    TextAlign = extendedLabel5.TextAlign,
                    AutoSize = extendedLabel5.AutoSize,
                    Font = extendedLabel5.Font,
                    ImageAlign = extendedLabel5.ImageAlign,
                    Size = extendedLabel5.Size,
                    Dock = DockStyle.Top
                };
                lbl.Text = prop.Data;
                lbls.Add(lbl);
                foreach(ExtendedLabel el in lbls) {
                    tabPage4.Controls.Add(el);
                }
            }

            bool shouldDisplayFunctionList = false;

            var functionCount = script.Functions.Length;
            var eventCount    = script.Events.Length;
            var fragmentCount = script.Fragments.Length;

            if(functionCount > 0) {
                functionListCountPanel.Visible = true;
                functionCountLabel.Text = $"{functionCount} {(functionCount == 1 ? "Function" : "Functions")}";
                shouldDisplayFunctionList = true;
                functionListSeparator.Visible = true;
            }
            else {
                functionListCountPanel.Visible = false;
                functionListSeparator.Visible = false;
            }

            if(eventCount > 0) {
                eventListCountPanel.Visible = true;
                eventCountLabel.Text = $"{eventCount} {(eventCount == 1 ? "Event" : "Events")}";
                shouldDisplayFunctionList = true;
            }
            else {
                eventListCountPanel.Visible = false;
            }

            if(fragmentCount > 0) {
                fragmentListCountPanel.Visible = true;
                fragmentCountLabel.Text = $"{fragmentCount} {(fragmentCount == 1 ? "Fragment" : "Fragments")}";
                functionListSeparator2.Visible = true;
            }
            else {
                fragmentListCountPanel.Visible = false;
                functionListSeparator2.Visible = false;
            }

            if(shouldDisplayFunctionList) {
                functionListStatusPanel.Visible = true;
            }
            else {
                functionListStatusPanel.Visible = false;
            }

            if(script.HasFunctions || script.HasEvents) {
                sideBarRight.Visible = true;
            }
            else {
                sideBarRight.Visible = false;
            }

            //mainTabControl.Width = Width - 218 - (sideBarRight.Visible ? sideBarRight.Width : 0);
        }

        private void ScriptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFunctionList();

            ScriptInfo si = new ScriptInfo($"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source\\{scriptList.GetItemText(scriptList.SelectedItem)}");
            using (StreamReader r = new StreamReader(si.Path)) {
                //fastColoredTextBox1.Text = r.ReadToEnd();
            }
            locCount.Text = $"{si.LinesOfCode} LOC";
            //scintilla1.Text = "";
            //foreach(string line in si.Data) {
            //    scintilla1.Text += line + "\n";
            //}
        }

        private void PropertiesToolStripMenuItem_Click(object sender, EventArgs e) {
            properties.Show();
        }


        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void BuildScriptMenuItem_Click(object sender, EventArgs e) {
            StartCompilation();
        }

        private void ClearBuildLogMenuItem_Click(object sender, EventArgs e) {
            // outputListBox.Items.Clear();
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
            string selectedScript = scriptList.GetItemText(scriptList.SelectedItem);
            //if(scriptList.SelectedItem != null && !mainTabControl.TabPages.ContainsKey(selectedScript)) {
            //    mainTabControl.TabPages.Add(selectedScript);
            //}
        }

        private void ErrorListTextbox_TextChanged(object sender, EventArgs e) {
            if(errorList.Items.Contains(errorListTextbox.Text)) {
                errorList.Items.Clear();
                var result = PapyrusCompiler.StdErr.Split(new[] { '\n' });
                foreach (string line in result) {
                    try {
                        if (line != string.Empty && line != " ") {
                            Console.WriteLine($"{line.Substring(line.LastIndexOf("\\") + 1)}");
                            string currentMod = projectList.GetItemText(projectList.SelectedItem);
                            textBox1.Text = PapyrusCompiler.StdOut;
                            string itemToAdd = $"{line.Substring(line.LastIndexOf("\\") + 1)}";
                            if (itemToAdd.Contains("unable to locate script")) {
                                itemToAdd += " (missing dependency)";
                            }

                            errorList.Items.Add(itemToAdd);
                            errorCountLabel.Text = $"{errorList.Items.Count.ToString()} Errors";
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine(ex.Message);
                        throw;
                    }

                }
            }
        }

        private void BottomSplitter_SplitterMoved(object sender, SplitterEventArgs e) {
            const int padding = 20;
            sideBarRight.Size = new Size(sideBarRight.Width, Height - padding - (Height - bottomSplitter.Location.Y));
            //mainTabControl.Height = Height - padding - (Height - bottomSplitter.Location.Y);
            sideBar.Height = Height - padding - (Height - bottomSplitter.Location.Y);
            scriptsPanel.MaximumHeight = Height - padding - (Height - bottomSplitter.Location.Y);
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
            string currentScript =
                $"{localMoPath}\\{projectList.GetItemText(projectList.SelectedItem)}\\scripts\\source\\{scriptList.GetItemText(scriptList.SelectedItem)}";

            //fastColoredTextBox1.SaveToFile(currentScript, Encoding.UTF8);
        }

        private void HeaderPanel1_Click(object sender, EventArgs e) {
            //headerPanel1.ExpandAndCollapse();
        }

        private void LoadModPaths() {
            ModInfo[] mods = ModManager.GetMods(localMoPath);
            foreach(ModInfo mod in mods) {
                try {
                    if(mod.HasSourceScripts) {
                        Console.WriteLine(mod.Name);
                        PapyrusCompiler.Arguments.AddPath($"{localMoPath}\\{mod.Name}\\scripts\\source");

                    }
                }
                catch (DirectoryNotFoundException ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine();
            PapyrusCompiler.Arguments.Parse();
        }

        private void NewProjectToolStripMenuItem_Click(object sender, EventArgs e) {
            AddScriptForm addScript = new AddScriptForm();
            addScript.Show();
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

        public static void AddFunction(this ListView.ListViewItemCollection lvic, PapyrusFunction function) {
            const int IMAGELIST_FUNCTION = 0;
            const int IMAGELIST_FRAGMENT = 1;

            var returnType    = PapyrusFunction.GetReturnType(function.Data);
            var displayedName = PapyrusFunction.IsProcedure(function.Data) ?
                                function.Name : $"{returnType} {function.Name}";

            ListViewItem lvi = new ListViewItem(displayedName);
            lvi.StateImageIndex = IMAGELIST_FUNCTION;
            lvi.ForeColor       = Color.White;

            if(function.IsFragment()) {
                lvi.StateImageIndex = IMAGELIST_FRAGMENT;
            }

            lvic.Add(lvi);
        }

        public static void AddEvent(this ListView.ListViewItemCollection lvic, PapyrusEvent ev) {
            const int IMAGELIST_EVENT = 2;

            ListViewItem lvi = new ListViewItem(ev.Name);
            lvi.StateImageIndex = IMAGELIST_EVENT;
            lvi.ForeColor = Color.White;
            lvic.Add(lvi);
        }

    }

}
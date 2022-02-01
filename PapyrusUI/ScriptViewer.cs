using PapyrusLibrary.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PapyrusUI {
    public partial class ScriptViewer : Form {
        public ScriptViewer() {
            InitializeComponent();
        }

        public ScriptViewer(ScriptInfo script) : this() {
            Load(script);
        }

        public void Load(ScriptInfo script) {
            this.Text = script.Name;
            textbox.Text = File.ReadAllText(script.Path);
        }
        public void ViewScript(ScriptInfo script) {
            Load(script);
            this.ShowDialog();
        }
    }
}

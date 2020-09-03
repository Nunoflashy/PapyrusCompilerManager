using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapyrusUI
{
    public partial class GlobalConfigurationPanel : UserControl
    {
        public GlobalConfigurationPanel()
        {
            InitializeComponent();
        }

        public string CompilerPath
        {
            get { return compilerPath.Text; }
            set { compilerPath.Text = value; }
        }

        public string CompilerFlagPath
        {
            get { return compilerFlagPath.Text; }
            set { compilerFlagPath.Text = value; }
        }

        public string InputScriptsPath
        {
            get { return importsPath.Text; }
            set { importsPath.Text = value; }
        }

        public string OutputScriptsPath
        {
            get { return outputPath.Text; }
            set { outputPath.Text = value; }
        }

        public new enum Handle { CompilerPath }

        public PlaceholderTextbox this[Handle handle]
        {
            get 
            {
                switch(handle) {
                    case Handle.CompilerPath:
                        return compilerPath;
                }
                return null;
            }
        }

    }
}

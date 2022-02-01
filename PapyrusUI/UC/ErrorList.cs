using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModUtilsLib;
using PapyrusLibrary.Script;

namespace PapyrusUI.UC {
    public partial class ErrorList : UserControl {
        public ErrorList() {
            InitializeComponent();
        }

        [Browsable(false)]
        public int Errors { get; private set; } = 0;

        [Browsable(false)]
        public int Warnings { get; private set; } = 0;

        [Browsable(false)]
        public int Messages { get; private set; } = 0;

        public bool HasErrors { get => Errors > 0; }

        public bool HasWarnings { get => Warnings > 0; }

        public bool HasMessages { get => Messages > 0; }

        public bool DisplayErrors {
            get => errorPanel.Visible;
            set => errorPanel.Visible = value;
        }
        public bool DisplayWarnings {
            get => warningPanel.Visible;
            set => warningPanel.Visible = value;
        }
        public bool DisplayMessages {
            get => messagePanel.Visible;
            set => messagePanel.Visible = value;
        }

        [Category("Images"), Browsable(true)]
        public Image ErrorImage { get; set; }

        [Category("Images"), Browsable(true)]
        public Image WarningImage { get; set; }

        public delegate void ErrorEventHandler(string error);

        [Browsable(true)]
        public event ErrorEventHandler OnErrorAdded;

        [Browsable(true)]
        public event ErrorEventHandler OnErrorRemoved;


        [Category("Images"), Browsable(true)]
        public Image MessageImage { get; set; }

        public void AddError(string error) {
            if(error.Length < 2)
                return;

            _ = listbox.Items.Add(error);
            Errors++;
            errorCountLbl.Text = $"{Errors} Errors";
            //OnErrorAdded(error);
        }

        public void AddError(string[] error) {
            ListViewItem item = new ListViewItem(error);
            listbox.Columns[0].Width = error[0].Length * 10;
            listbox.Items.Add(item);
            Errors++;
            errorCountLbl.Text = $"{Errors} Errors";
        }

        public void AddError(string message, ModInfo mod, ScriptInfo script, int line, int column) {
            ListViewItem item = new ListViewItem(new[] { message, mod.Name, script.Name, line.ToString(), column.ToString() });
            listbox.Columns[0].Width = message.Length * 10;
            listbox.Items.Add(item);
            Errors++;
            errorCountLbl.Text = $"{Errors} Errors";
        }

        public void AddWarning(string warning) {
            listbox.Items.Add(warning);
        }

        public void AddMessage(string message) {
            listbox.Items.Add(message);
        }

        public string[] GetErrors() {
            string[] items = new string[listbox.Items.Count];
            for(int i = 0; i < items.Length; i++) {
                items[i] = listbox.Items[i].Text;
            }
            return items;
        }

        public string GetErrorAtIndex(int index) {
            return listbox.Items[index].Text;
        }

        public void Clear() {
            listbox.Items.Clear();
            Errors = 0;
            Warnings = 0;
            Messages = 0;
            Update();
        }

        private new void Update() {
            errorCountLbl.Text   = $"{Errors} Errors";
            warningCountLbl.Text = $"{Warnings} Warnings";
            messageCountLbl.Text = $"{Messages} Messages";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScintillaNET;
using System.Drawing;

namespace PapyrusUI.Controls {
    class PapyrusEditor : Scintilla {
        public PapyrusEditor() : base() {
            Lexer = Lexer.Null;
            SetupStyles();
            SetupKeywords();
        }

        const int KEYWORD_PRIMARY = 0;
        const int KEYWORD_SECONDARY = 1;

        private void SetupStyles() {
            Styles[Style.Default].BackColor = Color.FromArgb(30, 30, 30);
            Styles[Style.Default].ForeColor = Color.White;

            // Margins
            Margins[0].Width = 32;
            Styles[Style.LineNumber].BackColor = Color.FromArgb(30, 30, 30);
            Styles[Style.LineNumber].ForeColor = Color.DodgerBlue;

            // Keyword styles
            Styles[1].ForeColor = Color.DodgerBlue;
            Styles[2].ForeColor = Color.Purple;


        }

        private void SetupKeywords() {
            SetKeywords(KEYWORD_PRIMARY, "event function bool int string while");
            SetKeywords(KEYWORD_SECONDARY, "GlobalVariable Property Auto ReadOnly AutoReadOnly");
        }

        public HashSet<string> PrimaryKeywords { get; set; }
        public HashSet<string> SecondaryKeywords { get; set; }

        protected override void OnStyleChanged(EventArgs e) {
            base.OnStyleChanged(e);
        }
    }
}

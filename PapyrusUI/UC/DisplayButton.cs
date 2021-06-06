using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapyrusUI.UC {
    public partial class DisplayButton : UserControl {
        public DisplayButton() {
            InitializeComponent();
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public override string Text {
            get { return btnLabel.Text; }
            set { btnLabel.Text = value; }
        }

        [Category("Appearance"), Browsable(true)]
        public Image Image {
            get { return btnImg.Image; }
            set { btnImg.Image = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PapyrusUI
{
    public partial class ExtendedTabControl : UserControl
    {
        private Panel tabPage1 = new Panel();

        public ExtendedTabControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(Brushes.AliceBlue, ClientRectangle);
        }

        private void tabPage1Btn_Click(object sender, EventArgs e)
        {
            mainContainer.Controls.Add(tabPage1);
            tabPage1.BackColor = Color.FromArgb(50, 50, 50);
            tabPage1.Dock = DockStyle.Fill;

            RichTextBox rtb = new RichTextBox();
            
            tabPage1.Controls.Add(rtb);
            rtb.Dock = DockStyle.Fill;
            rtb.Text = "dgsg";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapyrusUI
{
    public class ExtendedLabel : Label
    {
        [Browsable(true)]
        public  Color MouseEnterColor { get; set; }
        private Color originalBackColor { get; set; }
        private Color originalForeColor { get; set; }

        protected override void OnCreateControl()
        {
            originalBackColor = BackColor;
            originalForeColor = ForeColor;

            base.OnCreateControl();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if(!Focused)
                BackColor = MouseEnterColor;

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if(!Focused) {
                BackColor = originalBackColor;
                ForeColor = originalForeColor;
            }

            base.OnMouseLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            Focus();
            if(Focused) {
                BackColor = Color.FromArgb(55, 55, 61);
                Console.WriteLine($"Focused ?: {Focused} - {Name}");
            }
            base.OnClick(e);
        }
    }
}

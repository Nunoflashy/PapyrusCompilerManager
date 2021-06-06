using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PapyrusUI
{
    public class ExtendedTextEntry : TextBox
    {
        private Rectangle border;

        public ExtendedTextEntry()
        {
            SetStyle(ControlStyles.UserPaint, true);

            border = new Rectangle(0, 0, Width, Height);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            Refresh();

            base.OnTextChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using(Pen pen = new Pen(Color.Red)) {
                e.Graphics.DrawRectangle(pen, border);
            }

            base.OnPaint(e);
        }
    }
}

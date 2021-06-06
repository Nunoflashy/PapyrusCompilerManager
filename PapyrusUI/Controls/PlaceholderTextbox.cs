using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace PapyrusUI
{
    public class PlaceholderTextbox : TextBox
    {
        private Color originalForeColor { get; set; }

        [Browsable(true)]
        public string InactiveText { get; set; }

        [Category("Color"), DisplayName("EmptyForeColor"), Description("Esgatanha")]
        public Color EmptyForeColor { get; set; }

        [Category("Color"), DisplayName("EmptyBackColor"), Description("Esgatanha")]
        public Color EmptyBackColor { get; set; }

        private void SetDefaultProperties()
        {
            if (Text == InactiveText) {
                ForeColor = EmptyForeColor;
            }

            if (InactiveText == string.Empty) {
                InactiveText = Text;
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            SetDefaultProperties();
            originalForeColor = ForeColor;

        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);

            if(Text == InactiveText) {
                Text = string.Empty;
            }

            ForeColor = originalForeColor;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if(Text == string.Empty) {
                ForeColor = EmptyForeColor;
                Text = InactiveText;
            }
        }
    }
}

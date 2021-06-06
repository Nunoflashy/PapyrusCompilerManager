using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PapyrusUI.Controls
{
    public class ExtendedListBox : ListBox
    {
        /// <summary>
        /// The color of the selection rectangle to display when an item is selected.
        /// </summary>
        public Color SelectedItemBackColor { get; set; } = Color.FromArgb(40, 40, 40);

        /// <summary>
        /// The color of the text to display when an item is selected.
        /// </summary>
        public Color SelectedItemForeColor { get; set; } = Color.DodgerBlue;

        /// <summary>
        /// The font to be used when an item is selected.
        /// </summary>
        public Font SelectedItemFont { get; set; }

        /// <summary>
        /// Get whether or not this list has at least one element, if not, we don't need to draw the items.
        /// </summary>
        private bool HasItems => (Items.Count >= 1);

        private void SetDefaults()
        {
            DrawMode         = DrawMode.OwnerDrawFixed;
            BackColor        = Color.FromArgb(47, 47, 47);
            ForeColor        = Color.FromArgb(200, 200, 200);
            BorderStyle      = BorderStyle.None;
            Font             = new Font("Verdana", 7);
            SelectedItemFont = Font;
        }

        public ExtendedListBox()
        {
            SetDefaults();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= 0) {

                object item = null;
                
                if (!HasItems) {
                    return;
                }
                item = Items[e.Index];
                
                e.DrawBackground();

                Size size = Size.Round(e.Graphics.MeasureString(item.ToString(), e.Font));
                Point location = new Point(e.Bounds.Left + (e.Bounds.Width / 2 - size.Width /2), e.Bounds.Top + (e.Bounds.Height /2 - size.Height /2));

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                    e.Graphics.FillRectangle(new SolidBrush(SelectedItemBackColor), e.Bounds);
                    Font selectedItemFont = new Font(SelectedItemFont, SelectedItemFont.Style);
                    TextRenderer.DrawText(e.Graphics, item.ToString(), selectedItemFont, location, SelectedItemForeColor);
                    return;
                }
                TextRenderer.DrawText(e.Graphics, item.ToString(), e.Font, location, e.ForeColor);
            }
            base.OnDrawItem(e);
        }
    }
}

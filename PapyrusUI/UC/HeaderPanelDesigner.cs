using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PapyrusUI
{
    public class HeaderPanelDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            var contentsPanel = ((HeaderPanel)Control).ContentsPanel;
            EnableDesignMode(contentsPanel, "ContentsPanel");
        }

        public override bool CanParent(Control control)
        {
            return false;
        }

        protected override void OnDragOver(DragEventArgs de)
        {
            base.OnDragOver(de);
            de.Effect = DragDropEffects.None;
        }

        protected override IComponent[] CreateToolCore(ToolboxItem tool, int x, int y, int width, int height, bool hasLocation, bool hasSize)
        {
            return null;
        }

        public override SelectionRules SelectionRules
        {
            get
            {
                SelectionRules selectionRules = base.SelectionRules;
                //selectionRules &= SelectionRules.AllSizeable;
                return selectionRules;
            }
        }

        protected override void PostFilterAttributes(IDictionary attributes)
        {
            base.PostFilterAttributes(attributes);
            attributes[typeof(DockingAttribute)] = new DockingAttribute(DockingBehavior.Never);
        }

        //protected override void PostFilterProperties(IDictionary properties)
        //{
        //    base.PostFilterProperties(properties);
        //    var propertiesToRemove = new string[] {
        //        "Dock", "Anchor",
        //        "Size", "Location", "Width", "Height",
        //        "MinimumSize", "MaximumSize",
        //        "AutoSize", "AutoSizeMode",
        //        "Visible", "Enabled",
        //    };
        //    foreach (var item in propertiesToRemove) {
        //        if (properties.Contains(item))
        //            properties[item] = TypeDescriptor.CreateProperty(this.Component.GetType(),
        //                (PropertyDescriptor)properties[item],
        //                new BrowsableAttribute(false));
        //    }
        //}
    }
}

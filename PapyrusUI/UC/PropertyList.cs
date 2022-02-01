using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PapyrusLibrary.Script;

namespace PapyrusUI.UC {
    public partial class PropertyList : UserControl {
        public PropertyList() {
            InitializeComponent();
        }

        public int Properties { get; private set; }

        public bool HasProperties { get => Properties > 0; }

        public bool DisplayProperties {
            get => panel.Visible;
            set => panel.Visible = value;
        }

        public Image CategoryImage {
            get => img.Image;
            set => img.Image = value;
        }

        [Category("Images"), Browsable(true)]
        public Image PropertyImage {
            get => imageList.Images[0];
            set => imageList.Images[0] = value;
        }

        public void Add(PapyrusVariable property) {
            listview.Items.Add(new ListViewItem(property.Data) { StateImageIndex = 0 });
            Properties++;
        }
        public void Add(PapyrusVariable[] properties) {
            foreach(PapyrusVariable property in properties) {
                Add(property);
            }
            Update();
        }

        public void Clear() {
            Properties = 0;
            listview.Items.Clear();
            Update();
        }

        private new void Update() {
            if(HasProperties) {
                DisplayProperties = true;
                this.Visible = true;
                propertyCount.Text = $"{Properties} {(Properties == 1 ? "Property" : "Properties")}";
                return;
            }
            DisplayProperties = false;
            this.Visible = false;
            propertyCount.Text = "0 Properties";
        }

    }
}

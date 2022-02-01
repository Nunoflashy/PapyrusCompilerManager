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
    public partial class ImageLabel : UserControl {
        public ImageLabel() {
            InitializeComponent();
            labelX = label.Location.X;
            labelY = label.Location.Y;
        }
        int labelX;
        int labelY;
        private void ImageLabel_Resize(object sender, EventArgs e) {
            //int imageX = image.Location.X;
            //int imageY = image.Location.Y;
            //image.Location = new Point(imageX, imageY);


            label.Location = new Point(labelX + Width/2, labelY);
        }
    }
}

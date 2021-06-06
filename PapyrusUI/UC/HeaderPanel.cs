using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PapyrusUI
{
    [Designer(typeof(HeaderPanelDesigner))]
    public partial class HeaderPanel : UserControl
    {
        private Color defaultHeaderForeColor;
        public Color HeaderMouseEnterColor { get; set; }

        public HeaderPanel()
        {
            InitializeComponent();
            //TypeDescriptor.AddAttributes(contentsPanel, new DesignerAttribute(typeof(HeaderPanelDesigner)));
            defaultHeaderForeColor = headerTitle.ForeColor;
            SetStyle(ControlStyles.UserPaint, true);
            ResizeRedraw = true;
            DoubleBuffered = true;
        }

        private void SetTitleLocation()
        {
            headerTitle.Location = new Point(Width / 2 - (headerTitle.Width / 2), 1);
        }

        private void HeaderPanel_Load(object sender, EventArgs e)
        {
            SetTitleLocation();
        }

        protected override void OnResize(EventArgs e)
        {
            SetTitleLocation();

            base.OnResize(e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel ContentsPanel
        {
            get { return contentsPanel; }
        }

        /// <summary>
        /// Determines whether or not the panel can be collapsed
        /// </summary>
        public bool Collapsable { get; set; } = true;

        public string Title
        {
            get { return headerTitle.Text; }
            set { headerTitle.Text = value; }
        }

        public int HeaderSize
        {
            get { return header.Height; }
            set { header.Height = value; }
        }

        private bool expanded = false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int MinimumHeight { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int MaximumHeight { get; set; }

        public int AnimationSpeed { get; set; } = 3;

        public void ExpandAndCollapse()
        {
            if(Collapsable) {
            //Thread animationThread = new Thread(
            //        delegate() {
                        if(expanded) {
                            while(Height > MinimumHeight) {
                                Height-= AnimationSpeed;
                                expanded = false;
                            }
                        }
                        else {
                            while(Height < MaximumHeight) {
                                Height+= AnimationSpeed;
                                expanded = true;
                            }
                        }
            }
            //        });
            //animationThread.Start();

        }

        private void header_Click(object sender, EventArgs e) {
            ExpandAndCollapse();
            base.OnClick(e);
        }
        private void headerTitle_Click(object sender, EventArgs e) {
            ExpandAndCollapse();
            base.OnClick(e);
        }
        private void headerTitle_MouseEnter(object sender, EventArgs e)
        {
            headerTitle.ForeColor = HeaderMouseEnterColor;
        }

        private void headerTitle_MouseLeave(object sender, EventArgs e)
        {
            headerTitle.ForeColor = defaultHeaderForeColor;
        }


        //private void header_Paint(object sender, PaintEventArgs e)
        //{
        //    using (SolidBrush brush = new SolidBrush(Color.FromArgb(225, 225, 225))) {
        //        e.Graphics.DrawString(Title, new Font("Verdana", 7, FontStyle.Bold), brush, new Point(Width / 2 - (headerTitle.Width / 2), 1));
        //    }

        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapyrusUI {
    public partial class PropertiesUI : Form {
        public PropertiesUI() {
            InitializeComponent();
        }

        #region Resizable/Movable Window
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        const int HTTOPLEFT = 13;
        const int HTTOP = 12;
        const int HTTOPRIGHT = 14;
        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTBOTTOMLEFT = 16;
        const int HTBOTTOM = 15;
        const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m) {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg) {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == HTCLIENT) {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)HTTOP;
                            else
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE)) {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)HTCAPTION;
                            else
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)HTBOTTOM;
                            else
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // Minimize on double click from taskbar
                return cp;
            }
        }
        #endregion

        public GlobalConfigurationPanel gcp = new GlobalConfigurationPanel();

        private void PropertiesUI_Load(object sender, EventArgs e) {

        }

        private void PropertiesUI_Paint(object sender, PaintEventArgs e) {
            SolidBrush brush = new SolidBrush(Color.FromArgb(30, 30, 30));
            Graphics gfx = CreateGraphics();
            gfx.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));

            brush.Color = Color.FromArgb(200, 200, 200);
            TextRenderer.DrawText(gfx, Text, new Font("Verdana", 7), new Point(this.Width / 2 - (this.Text.Length / 2 + 24), 5), brush.Color);
            brush.Dispose();
            gfx.Dispose();
        }

        private void CloseBtn_MouseEnter(object sender, EventArgs e) {
            closeBtn.BackColor = Color.FromArgb(208, 20, 46);
            closeBtn.Image = Properties.Resources.close_enter;
        }

        private void CloseBtn_MouseLeave(object sender, EventArgs e) {
            closeBtn.BackColor = Color.FromArgb(30, 30, 30);
            closeBtn.Image = Properties.Resources.close;
        }

        private void CloseBtn_MouseDown(object sender, MouseEventArgs e) {
            closeBtn.BackColor = Color.FromArgb(188, 0, 26);
        }

        private void CloseBtn_Click(object sender, EventArgs e) {
            Close();
        }
    }
}

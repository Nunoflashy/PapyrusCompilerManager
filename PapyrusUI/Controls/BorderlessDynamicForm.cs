using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Drawing.Design;
using System.Collections;

namespace PapyrusUI.Controls {

    public class BorderlessDynamicForm : Form {
        private Panel actionButtonsPanel;
        private PictureBox minimizeBtn;
        private PictureBox maximizeBtn;
        private PictureBox closeBtn;

        bool _maximized = false;
        bool _canBeMaximized = true;

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

        protected void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorderlessDynamicForm));
            this.actionButtonsPanel = new System.Windows.Forms.Panel();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            this.maximizeBtn = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.actionButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // actionButtonsPanel
            // 
            this.actionButtonsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.actionButtonsPanel.Controls.Add(this.minimizeBtn);
            this.actionButtonsPanel.Controls.Add(this.maximizeBtn);
            this.actionButtonsPanel.Controls.Add(this.closeBtn);
            this.actionButtonsPanel.Location = new System.Drawing.Point(496, -1);
            this.actionButtonsPanel.Name = "actionButtonsPanel";
            this.actionButtonsPanel.Size = new System.Drawing.Size(100, 24);
            this.actionButtonsPanel.TabIndex = 7;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(4, 0);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(32, 24);
            this.minimizeBtn.TabIndex = 4;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtn_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtn_MouseLeave);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.maximizeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.maximizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("maximizeBtn.Image")));
            this.maximizeBtn.Location = new System.Drawing.Point(36, 0);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(32, 24);
            this.maximizeBtn.TabIndex = 3;
            this.maximizeBtn.TabStop = false;
            this.maximizeBtn.Click += new System.EventHandler(this.MaximizeBtn_Click);
            this.maximizeBtn.MouseEnter += new System.EventHandler(this.MaximizeBtn_MouseEnter);
            this.maximizeBtn.MouseLeave += new System.EventHandler(this.MaximizeBtn_MouseLeave);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(68, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(32, 24);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            this.closeBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseBtn_MouseDown);
            this.closeBtn.MouseEnter += new System.EventHandler(this.CloseBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.CloseBtn_MouseLeave);
            // 
            // BorderlessDynamicForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(594, 348);
            this.Controls.Add(this.actionButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BorderlessDynamicForm";
            this.ResizeEnd += new System.EventHandler(this.BorderlessDynamicForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.BorderlessDynamicForm_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BorderlessDynamicForm_Paint);
            this.Resize += new System.EventHandler(this.BorderlessDynamicForm_Resize);
            this.actionButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);

        }

        private void ToggleMaximize() {
            if (!_canBeMaximized)
                return;

            this.WindowState = _maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            _maximized = !_maximized;

            if (_maximized) {
                maximizeBtn.Image = Properties.Resources.restore;
            }
            else {
                maximizeBtn.Image = Properties.Resources.maximize;
            }
        }

        private void MinimizeBtn_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MaximizeBtn_Click(object sender, EventArgs e) {
            ToggleMaximize();
        }

        private void CloseBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void MaximizeBtn_MouseEnter(object sender, EventArgs e) {
            maximizeBtn.BackColor = Color.FromArgb(82, 82, 82);
            if (!_maximized)
                maximizeBtn.Image = Properties.Resources.maximize_enter;
            else
                maximizeBtn.Image = Properties.Resources.restore_enter;
        }

        private void MaximizeBtn_MouseLeave(object sender, EventArgs e) {
            maximizeBtn.BackColor = Color.FromArgb(30, 30, 30);
            if (!_maximized)
                maximizeBtn.Image = Properties.Resources.maximize;
            else
                maximizeBtn.Image = Properties.Resources.restore;
        }

        private void MinimizeBtn_MouseEnter(object sender, EventArgs e) {
            minimizeBtn.BackColor = Color.FromArgb(82, 82, 82);
            minimizeBtn.Image = Properties.Resources.minimize_enter;
        }

        private void MinimizeBtn_MouseLeave(object sender, EventArgs e) {
            minimizeBtn.BackColor = Color.FromArgb(30, 30, 30);
            minimizeBtn.Image = Properties.Resources.minimize;
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

        private void BorderlessDynamicForm_Paint(object sender, PaintEventArgs e) {
            using (Graphics gfx = CreateGraphics()) {
                Color MainBackColor = Color.FromArgb(30, 30, 30);
                Color MainForeColor = Color.FromArgb(200, 200, 200);
                using (SolidBrush brush = new SolidBrush(MainBackColor)) {
                    // Draw Titlebar
                    gfx.FillRectangle(brush, new Rectangle(1, 1, this.Width - 2, 24));
                    // Draw Titlebar's text
                    TextRenderer.DrawText(gfx, Text, new Font("Verdana", 7), new Point(this.Width / 2 - (this.Text.Length / 2 + 24), 5), MainForeColor);
                }
                using(Pen outliner = new Pen(Color.FromArgb(15, 15, 15))) {
                    const int MARGIN = 2;
                    gfx.DrawLine(outliner, new Point(0, 0), new Point(Width - MARGIN, 0));
                    gfx.DrawLine(outliner, new Point(0, 0), new Point(0, Height - MARGIN));
                    gfx.DrawLine(outliner, new Point(0, Height - MARGIN), new Point(Width - MARGIN, Height - MARGIN));
                    gfx.DrawLine(outliner, new Point(Width - MARGIN, Height - MARGIN), new Point(Width - MARGIN, 0));
                }
            }
        }

        private void BorderlessDynamicForm_SizeChanged(object sender, EventArgs e) {
            actionButtonsPanel.Location = new Point(this.Width - actionButtonsPanel.Width - 2, 1);
        }

        private void BorderlessDynamicForm_ResizeEnd(object sender, EventArgs e) {
            Invalidate();
        }

        private void BorderlessDynamicForm_Resize(object sender, EventArgs e) {
            Invalidate();
        }
    }
}

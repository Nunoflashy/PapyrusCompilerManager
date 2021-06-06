namespace PapyrusUI {
    partial class PropertiesUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesUI));
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.headerPanel1 = new PapyrusUI.HeaderPanel();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.headerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(439, -2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(32, 24);
            this.closeBtn.TabIndex = 5;
            this.closeBtn.TabStop = false;
            this.closeBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            this.closeBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CloseBtn_MouseDown);
            this.closeBtn.MouseEnter += new System.EventHandler(this.CloseBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.CloseBtn_MouseLeave);
            // 
            // headerPanel1
            // 
            this.headerPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            // 
            // headerPanel1.ContentsPanel
            // 
            this.headerPanel1.ContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerPanel1.ContentsPanel.Location = new System.Drawing.Point(0, 15);
            this.headerPanel1.ContentsPanel.Name = "ContentsPanel";
            this.headerPanel1.ContentsPanel.Size = new System.Drawing.Size(473, 231);
            this.headerPanel1.ContentsPanel.TabIndex = 1;
            this.headerPanel1.HeaderMouseEnterColor = System.Drawing.Color.Empty;
            this.headerPanel1.HeaderSize = 15;
            this.headerPanel1.Location = new System.Drawing.Point(-2, 24);
            this.headerPanel1.Name = "headerPanel1";
            this.headerPanel1.Size = new System.Drawing.Size(473, 246);
            this.headerPanel1.TabIndex = 6;
            this.headerPanel1.Title = "";
            // 
            // PropertiesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(470, 270);
            this.Controls.Add(this.headerPanel1);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PropertiesUI";
            this.Text = "Properties";
            this.Load += new System.EventHandler(this.PropertiesUI_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PropertiesUI_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.headerPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox closeBtn;
        private HeaderPanel headerPanel1;
    }
}
namespace PapyrusUI
{
    partial class HeaderPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header = new System.Windows.Forms.Panel();
            this.headerTitle = new System.Windows.Forms.Label();
            this.contentsPanel = new System.Windows.Forms.Panel();
            this.header.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.header.Controls.Add(this.headerTitle);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(476, 15);
            this.header.TabIndex = 0;
            this.header.Click += new System.EventHandler(this.header_Click);
            // 
            // headerTitle
            // 
            this.headerTitle.AutoSize = true;
            this.headerTitle.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.headerTitle.Location = new System.Drawing.Point(3, 1);
            this.headerTitle.Name = "headerTitle";
            this.headerTitle.Size = new System.Drawing.Size(34, 12);
            this.headerTitle.TabIndex = 1;
            this.headerTitle.Text = "TITLE";
            this.headerTitle.Click += new System.EventHandler(this.headerTitle_Click);
            this.headerTitle.MouseEnter += new System.EventHandler(this.headerTitle_MouseEnter);
            this.headerTitle.MouseLeave += new System.EventHandler(this.headerTitle_MouseLeave);
            // 
            // contentsPanel
            // 
            this.contentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentsPanel.Location = new System.Drawing.Point(0, 15);
            this.contentsPanel.Name = "contentsPanel";
            this.contentsPanel.Size = new System.Drawing.Size(476, 369);
            this.contentsPanel.TabIndex = 1;
            // 
            // HeaderPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.contentsPanel);
            this.Controls.Add(this.header);
            this.Name = "HeaderPanel";
            this.Size = new System.Drawing.Size(476, 384);
            this.Load += new System.EventHandler(this.HeaderPanel_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel contentsPanel;
        private System.Windows.Forms.Label headerTitle;
    }
}

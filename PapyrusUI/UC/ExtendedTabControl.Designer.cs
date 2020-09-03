namespace PapyrusUI
{
    partial class ExtendedTabControl
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
            this.mainContainer = new System.Windows.Forms.Panel();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.tabPage1Btn = new PapyrusUI.ExtendedLabel();
            this.extendedLabel1 = new PapyrusUI.ExtendedLabel();
            this.mainContainer.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Controls.Add(this.headerPanel);
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(583, 392);
            this.mainContainer.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.extendedLabel1);
            this.headerPanel.Controls.Add(this.tabPage1Btn);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(583, 17);
            this.headerPanel.TabIndex = 0;
            // 
            // tabPage1Btn
            // 
            this.tabPage1Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage1Btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabPage1Btn.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1Btn.ForeColor = System.Drawing.Color.White;
            this.tabPage1Btn.Location = new System.Drawing.Point(0, 0);
            this.tabPage1Btn.MouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.tabPage1Btn.Name = "tabPage1Btn";
            this.tabPage1Btn.Size = new System.Drawing.Size(73, 17);
            this.tabPage1Btn.TabIndex = 3;
            this.tabPage1Btn.Text = "TabPage1";
            this.tabPage1Btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.tabPage1Btn.Click += new System.EventHandler(this.tabPage1Btn_Click);
            // 
            // extendedLabel1
            // 
            this.extendedLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.extendedLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.extendedLabel1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extendedLabel1.ForeColor = System.Drawing.Color.White;
            this.extendedLabel1.Location = new System.Drawing.Point(73, 0);
            this.extendedLabel1.MouseEnterColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.extendedLabel1.Name = "extendedLabel1";
            this.extendedLabel1.Size = new System.Drawing.Size(73, 17);
            this.extendedLabel1.TabIndex = 4;
            this.extendedLabel1.Text = "TabPage2";
            this.extendedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExtendedTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.mainContainer);
            this.Name = "ExtendedTabControl";
            this.Size = new System.Drawing.Size(583, 392);
            this.mainContainer.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.Panel headerPanel;
        private ExtendedLabel tabPage1Btn;
        private ExtendedLabel extendedLabel1;
    }
}

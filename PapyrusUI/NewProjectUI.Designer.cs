namespace PapyrusUI
{
    partial class NewProjectUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.extendedTabControl1 = new PapyrusUI.ExtendedTabControl();
            this.SuspendLayout();
            // 
            // extendedTabControl1
            // 
            this.extendedTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.extendedTabControl1.Location = new System.Drawing.Point(12, 12);
            this.extendedTabControl1.Name = "extendedTabControl1";
            this.extendedTabControl1.Size = new System.Drawing.Size(583, 392);
            this.extendedTabControl1.TabIndex = 0;
            // 
            // NewProjectUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(792, 457);
            this.Controls.Add(this.extendedTabControl1);
            this.Name = "NewProjectUI";
            this.Text = "NewProjectUI";
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedTabControl extendedTabControl1;
    }
}
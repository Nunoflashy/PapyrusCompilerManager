namespace PapyrusUI.UC {
    partial class DisplayButton {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnLabel = new System.Windows.Forms.Label();
            this.btnImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnImg)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLabel
            // 
            this.btnLabel.AutoSize = true;
            this.btnLabel.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLabel.ForeColor = System.Drawing.Color.White;
            this.btnLabel.Location = new System.Drawing.Point(29, 4);
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Size = new System.Drawing.Size(61, 12);
            this.btnLabel.TabIndex = 1;
            this.btnLabel.Text = "0 Warnings";
            // 
            // btnImg
            // 
            this.btnImg.Image = global::PapyrusUI.Properties.Resources.warningIcon;
            this.btnImg.Location = new System.Drawing.Point(7, 2);
            this.btnImg.Name = "btnImg";
            this.btnImg.Size = new System.Drawing.Size(16, 16);
            this.btnImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnImg.TabIndex = 0;
            this.btnImg.TabStop = false;
            // 
            // DisplayButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.Controls.Add(this.btnLabel);
            this.Controls.Add(this.btnImg);
            this.Name = "DisplayButton";
            this.Size = new System.Drawing.Size(104, 20);
            ((System.ComponentModel.ISupportInitialize)(this.btnImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label btnLabel;
        private System.Windows.Forms.PictureBox btnImg;
    }
}

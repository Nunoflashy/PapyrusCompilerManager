namespace PapyrusUI.UC {
    partial class ErrorList {
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
            this.categoryPanel = new System.Windows.Forms.Panel();
            this.warningPanel = new System.Windows.Forms.Panel();
            this.warningCountLbl = new System.Windows.Forms.Label();
            this.warningIcon = new System.Windows.Forms.PictureBox();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.messageCountLbl = new System.Windows.Forms.Label();
            this.messageIcon = new System.Windows.Forms.PictureBox();
            this.errorPanel = new System.Windows.Forms.Panel();
            this.errorCountLbl = new System.Windows.Forms.Label();
            this.errorIcon = new System.Windows.Forms.PictureBox();
            this.listbox = new System.Windows.Forms.ListView();
            this.message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.script = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryPanel.SuspendLayout();
            this.warningPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningIcon)).BeginInit();
            this.messagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).BeginInit();
            this.errorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryPanel
            // 
            this.categoryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.categoryPanel.Controls.Add(this.warningPanel);
            this.categoryPanel.Controls.Add(this.messagePanel);
            this.categoryPanel.Controls.Add(this.errorPanel);
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(432, 28);
            this.categoryPanel.TabIndex = 46;
            // 
            // warningPanel
            // 
            this.warningPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.warningPanel.Controls.Add(this.warningCountLbl);
            this.warningPanel.Controls.Add(this.warningIcon);
            this.warningPanel.Location = new System.Drawing.Point(210, 3);
            this.warningPanel.Name = "warningPanel";
            this.warningPanel.Size = new System.Drawing.Size(104, 21);
            this.warningPanel.TabIndex = 49;
            // 
            // warningCountLbl
            // 
            this.warningCountLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.warningCountLbl.AutoSize = true;
            this.warningCountLbl.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningCountLbl.ForeColor = System.Drawing.Color.White;
            this.warningCountLbl.Location = new System.Drawing.Point(30, 4);
            this.warningCountLbl.Name = "warningCountLbl";
            this.warningCountLbl.Size = new System.Drawing.Size(61, 12);
            this.warningCountLbl.TabIndex = 1;
            this.warningCountLbl.Text = "0 Warnings";
            // 
            // warningIcon
            // 
            this.warningIcon.Image = global::PapyrusUI.Properties.Resources.warningIcon;
            this.warningIcon.Location = new System.Drawing.Point(8, 2);
            this.warningIcon.Name = "warningIcon";
            this.warningIcon.Size = new System.Drawing.Size(16, 16);
            this.warningIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.warningIcon.TabIndex = 0;
            this.warningIcon.TabStop = false;
            // 
            // messagePanel
            // 
            this.messagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.messagePanel.Controls.Add(this.messageCountLbl);
            this.messagePanel.Controls.Add(this.messageIcon);
            this.messagePanel.Location = new System.Drawing.Point(95, 3);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(109, 21);
            this.messagePanel.TabIndex = 48;
            // 
            // messageCountLbl
            // 
            this.messageCountLbl.AutoSize = true;
            this.messageCountLbl.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageCountLbl.ForeColor = System.Drawing.Color.White;
            this.messageCountLbl.Location = new System.Drawing.Point(32, 4);
            this.messageCountLbl.Name = "messageCountLbl";
            this.messageCountLbl.Size = new System.Drawing.Size(66, 12);
            this.messageCountLbl.TabIndex = 1;
            this.messageCountLbl.Text = "0 Messages";
            // 
            // messageIcon
            // 
            this.messageIcon.Image = global::PapyrusUI.Properties.Resources.infoIcon;
            this.messageIcon.Location = new System.Drawing.Point(8, 2);
            this.messageIcon.Name = "messageIcon";
            this.messageIcon.Size = new System.Drawing.Size(16, 16);
            this.messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.messageIcon.TabIndex = 0;
            this.messageIcon.TabStop = false;
            // 
            // errorPanel
            // 
            this.errorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.errorPanel.Controls.Add(this.errorCountLbl);
            this.errorPanel.Controls.Add(this.errorIcon);
            this.errorPanel.Location = new System.Drawing.Point(2, 3);
            this.errorPanel.Name = "errorPanel";
            this.errorPanel.Size = new System.Drawing.Size(87, 21);
            this.errorPanel.TabIndex = 40;
            // 
            // errorCountLbl
            // 
            this.errorCountLbl.AutoSize = true;
            this.errorCountLbl.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorCountLbl.ForeColor = System.Drawing.Color.White;
            this.errorCountLbl.Location = new System.Drawing.Point(32, 4);
            this.errorCountLbl.Name = "errorCountLbl";
            this.errorCountLbl.Size = new System.Drawing.Size(46, 12);
            this.errorCountLbl.TabIndex = 1;
            this.errorCountLbl.Text = "0 Errors";
            // 
            // errorIcon
            // 
            this.errorIcon.Image = global::PapyrusUI.Properties.Resources.errorIcon1;
            this.errorIcon.Location = new System.Drawing.Point(7, 2);
            this.errorIcon.Name = "errorIcon";
            this.errorIcon.Size = new System.Drawing.Size(16, 16);
            this.errorIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.errorIcon.TabIndex = 0;
            this.errorIcon.TabStop = false;
            // 
            // listbox
            // 
            this.listbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listbox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.message,
            this.mod,
            this.script,
            this.line,
            this.column});
            this.listbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listbox.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listbox.ForeColor = System.Drawing.Color.White;
            this.listbox.FullRowSelect = true;
            this.listbox.HideSelection = false;
            this.listbox.LabelWrap = false;
            this.listbox.Location = new System.Drawing.Point(0, 28);
            this.listbox.Name = "listbox";
            this.listbox.Scrollable = false;
            this.listbox.Size = new System.Drawing.Size(432, 212);
            this.listbox.TabIndex = 49;
            this.listbox.UseCompatibleStateImageBehavior = false;
            this.listbox.View = System.Windows.Forms.View.Details;
            // 
            // message
            // 
            this.message.Text = "Message";
            this.message.Width = 600;
            // 
            // script
            // 
            this.script.Text = "Script";
            this.script.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // line
            // 
            this.line.Text = "Line";
            this.line.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column
            // 
            this.column.Text = "Column";
            this.column.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // mod
            // 
            this.mod.Text = "Mod";
            this.mod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ErrorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listbox);
            this.Controls.Add(this.categoryPanel);
            this.Name = "ErrorList";
            this.Size = new System.Drawing.Size(432, 240);
            this.categoryPanel.ResumeLayout(false);
            this.warningPanel.ResumeLayout(false);
            this.warningPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warningIcon)).EndInit();
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).EndInit();
            this.errorPanel.ResumeLayout(false);
            this.errorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel categoryPanel;
        private System.Windows.Forms.Panel warningPanel;
        private System.Windows.Forms.Label warningCountLbl;
        private System.Windows.Forms.PictureBox warningIcon;
        private System.Windows.Forms.Panel messagePanel;
        private System.Windows.Forms.Label messageCountLbl;
        private System.Windows.Forms.PictureBox messageIcon;
        private System.Windows.Forms.Panel errorPanel;
        private System.Windows.Forms.Label errorCountLbl;
        private System.Windows.Forms.PictureBox errorIcon;
        private System.Windows.Forms.ListView listbox;
        private System.Windows.Forms.ColumnHeader message;
        private System.Windows.Forms.ColumnHeader script;
        private System.Windows.Forms.ColumnHeader line;
        private System.Windows.Forms.ColumnHeader column;
        private System.Windows.Forms.ColumnHeader mod;
    }
}

namespace PapyrusUI {
    partial class AddScriptForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddScriptForm));
            this.actionButtonsPanel = new System.Windows.Forms.Panel();
            this.maximizeBtn = new System.Windows.Forms.PictureBox();
            this.minimizeBtn = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.PictureBox();
            this.errorListTextbox = new PapyrusUI.PlaceholderTextbox();
            this.placeholderTextbox1 = new PapyrusUI.PlaceholderTextbox();
            this.statusBarLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.placeholderTextbox2 = new PapyrusUI.PlaceholderTextbox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.actionButtonsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // actionButtonsPanel
            // 
            this.actionButtonsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.actionButtonsPanel.BackColor = System.Drawing.Color.Transparent;
            this.actionButtonsPanel.Controls.Add(this.maximizeBtn);
            this.actionButtonsPanel.Controls.Add(this.minimizeBtn);
            this.actionButtonsPanel.Controls.Add(this.closeBtn);
            this.actionButtonsPanel.Location = new System.Drawing.Point(254, 0);
            this.actionButtonsPanel.Name = "actionButtonsPanel";
            this.actionButtonsPanel.Size = new System.Drawing.Size(100, 24);
            this.actionButtonsPanel.TabIndex = 6;
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.maximizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("maximizeBtn.Image")));
            this.maximizeBtn.Location = new System.Drawing.Point(36, -1);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(32, 24);
            this.maximizeBtn.TabIndex = 3;
            this.maximizeBtn.TabStop = false;
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimizeBtn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBtn.Image")));
            this.minimizeBtn.Location = new System.Drawing.Point(4, -1);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(32, 24);
            this.minimizeBtn.TabIndex = 4;
            this.minimizeBtn.TabStop = false;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Image = ((System.Drawing.Image)(resources.GetObject("closeBtn.Image")));
            this.closeBtn.Location = new System.Drawing.Point(68, -1);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(32, 24);
            this.closeBtn.TabIndex = 2;
            this.closeBtn.TabStop = false;
            // 
            // errorListTextbox
            // 
            this.errorListTextbox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.errorListTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.errorListTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorListTextbox.EmptyBackColor = System.Drawing.Color.Empty;
            this.errorListTextbox.EmptyForeColor = System.Drawing.Color.Gray;
            this.errorListTextbox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorListTextbox.ForeColor = System.Drawing.Color.Gray;
            this.errorListTextbox.InactiveText = "Path to all the script sources from the game ...";
            this.errorListTextbox.Location = new System.Drawing.Point(84, 46);
            this.errorListTextbox.Multiline = true;
            this.errorListTextbox.Name = "errorListTextbox";
            this.errorListTextbox.Size = new System.Drawing.Size(247, 21);
            this.errorListTextbox.TabIndex = 48;
            this.errorListTextbox.Text = "NewScript";
            this.errorListTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // placeholderTextbox1
            // 
            this.placeholderTextbox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.placeholderTextbox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.placeholderTextbox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.placeholderTextbox1.EmptyBackColor = System.Drawing.Color.Empty;
            this.placeholderTextbox1.EmptyForeColor = System.Drawing.Color.Gray;
            this.placeholderTextbox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderTextbox1.ForeColor = System.Drawing.Color.Gray;
            this.placeholderTextbox1.InactiveText = "Path to all the script sources from the game ...";
            this.placeholderTextbox1.Location = new System.Drawing.Point(84, 86);
            this.placeholderTextbox1.Multiline = true;
            this.placeholderTextbox1.Name = "placeholderTextbox1";
            this.placeholderTextbox1.Size = new System.Drawing.Size(247, 21);
            this.placeholderTextbox1.TabIndex = 49;
            this.placeholderTextbox1.Text = "ReferenceAlias";
            this.placeholderTextbox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusBarLabel
            // 
            this.statusBarLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.statusBarLabel.AutoSize = true;
            this.statusBarLabel.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBarLabel.ForeColor = System.Drawing.Color.White;
            this.statusBarLabel.Location = new System.Drawing.Point(20, 49);
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new System.Drawing.Size(38, 12);
            this.statusBarLabel.TabIndex = 50;
            this.statusBarLabel.Text = "Name:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "Extends:";
            // 
            // placeholderTextbox2
            // 
            this.placeholderTextbox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.placeholderTextbox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.placeholderTextbox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.placeholderTextbox2.EmptyBackColor = System.Drawing.Color.Empty;
            this.placeholderTextbox2.EmptyForeColor = System.Drawing.Color.Gray;
            this.placeholderTextbox2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.placeholderTextbox2.ForeColor = System.Drawing.Color.Gray;
            this.placeholderTextbox2.InactiveText = "Path to all the script sources from the game ...";
            this.placeholderTextbox2.Location = new System.Drawing.Point(22, 198);
            this.placeholderTextbox2.Multiline = true;
            this.placeholderTextbox2.Name = "placeholderTextbox2";
            this.placeholderTextbox2.Size = new System.Drawing.Size(309, 71);
            this.placeholderTextbox2.TabIndex = 52;
            this.placeholderTextbox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(84, 113);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 16);
            this.checkBox1.TabIndex = 53;
            this.checkBox1.Text = "Hidden";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(84, 135);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(81, 16);
            this.checkBox2.TabIndex = 54;
            this.checkBox2.Text = "Conditional";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 12);
            this.label2.TabIndex = 55;
            this.label2.Text = "Documentation String:";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(146, 283);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 21);
            this.button2.TabIndex = 56;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(243, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 21);
            this.button1.TabIndex = 57;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 12);
            this.label3.TabIndex = 58;
            this.label3.Text = "Add New Script";
            // 
            // AddScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(353, 319);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.placeholderTextbox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBarLabel);
            this.Controls.Add(this.placeholderTextbox1);
            this.Controls.Add(this.errorListTextbox);
            this.Controls.Add(this.actionButtonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddScriptForm";
            this.Text = "AddScriptForm";
            this.actionButtonsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maximizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimizeBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeBtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel actionButtonsPanel;
        private System.Windows.Forms.PictureBox maximizeBtn;
        private System.Windows.Forms.PictureBox minimizeBtn;
        private System.Windows.Forms.PictureBox closeBtn;
        private PlaceholderTextbox errorListTextbox;
        private PlaceholderTextbox placeholderTextbox1;
        private System.Windows.Forms.Label statusBarLabel;
        private System.Windows.Forms.Label label1;
        private PlaceholderTextbox placeholderTextbox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}
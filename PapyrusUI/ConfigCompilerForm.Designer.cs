namespace PapyrusUI {
    partial class ConfigCompilerForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigCompilerForm));
            this.mainContainer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.inputPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.flagPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buildScriptBtn = new System.Windows.Forms.Button();
            this.mainPath = new System.Windows.Forms.TextBox();
            this.scriptnameLabel = new System.Windows.Forms.Label();
            this.mainContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.mainContainer.Controls.Add(this.panel2);
            this.mainContainer.Controls.Add(this.okBtn);
            this.mainContainer.Controls.Add(this.button3);
            this.mainContainer.Controls.Add(this.inputPath);
            this.mainContainer.Controls.Add(this.label2);
            this.mainContainer.Controls.Add(this.button2);
            this.mainContainer.Controls.Add(this.flagPath);
            this.mainContainer.Controls.Add(this.label1);
            this.mainContainer.Controls.Add(this.buildScriptBtn);
            this.mainContainer.Controls.Add(this.mainPath);
            this.mainContainer.Controls.Add(this.scriptnameLabel);
            this.mainContainer.Location = new System.Drawing.Point(-1, 25);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(617, 272);
            this.mainContainer.TabIndex = 0;
            this.mainContainer.Resize += new System.EventHandler(this.MainContainer_Resize);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(116, 167);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 28);
            this.panel2.TabIndex = 59;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::PapyrusUI.Properties.Resources.play16x16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 58;
            this.button1.Text = "Test Compiler";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.okBtn.FlatAppearance.BorderSize = 0;
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.ForeColor = System.Drawing.Color.White;
            this.okBtn.Image = ((System.Drawing.Image)(resources.GetObject("okBtn.Image")));
            this.okBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.okBtn.Location = new System.Drawing.Point(116, 119);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(400, 28);
            this.okBtn.TabIndex = 57;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::PapyrusUI.Properties.Resources.browseDirectoryIcon;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(536, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 28);
            this.button3.TabIndex = 56;
            this.button3.Text = "Browse";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // inputPath
            // 
            this.inputPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.inputPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputPath.Enabled = false;
            this.inputPath.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputPath.ForeColor = System.Drawing.Color.White;
            this.inputPath.Location = new System.Drawing.Point(116, 83);
            this.inputPath.Multiline = true;
            this.inputPath.Name = "inputPath";
            this.inputPath.Size = new System.Drawing.Size(400, 20);
            this.inputPath.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(23, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "Input Path";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::PapyrusUI.Properties.Resources.browseDirectoryIcon;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(536, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 28);
            this.button2.TabIndex = 53;
            this.button2.Text = "Browse";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // flagPath
            // 
            this.flagPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flagPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.flagPath.Enabled = false;
            this.flagPath.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flagPath.ForeColor = System.Drawing.Color.White;
            this.flagPath.Location = new System.Drawing.Point(116, 48);
            this.flagPath.Multiline = true;
            this.flagPath.Name = "flagPath";
            this.flagPath.Size = new System.Drawing.Size(400, 20);
            this.flagPath.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(23, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 12);
            this.label1.TabIndex = 51;
            this.label1.Text = "Compiler Flag";
            // 
            // buildScriptBtn
            // 
            this.buildScriptBtn.FlatAppearance.BorderSize = 0;
            this.buildScriptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildScriptBtn.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildScriptBtn.ForeColor = System.Drawing.Color.White;
            this.buildScriptBtn.Image = global::PapyrusUI.Properties.Resources.browseDirectoryIcon;
            this.buildScriptBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buildScriptBtn.Location = new System.Drawing.Point(536, 9);
            this.buildScriptBtn.Name = "buildScriptBtn";
            this.buildScriptBtn.Size = new System.Drawing.Size(70, 28);
            this.buildScriptBtn.TabIndex = 50;
            this.buildScriptBtn.Text = "Browse";
            this.buildScriptBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buildScriptBtn.UseVisualStyleBackColor = true;
            // 
            // mainPath
            // 
            this.mainPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.mainPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainPath.Enabled = false;
            this.mainPath.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainPath.ForeColor = System.Drawing.Color.White;
            this.mainPath.Location = new System.Drawing.Point(116, 13);
            this.mainPath.Multiline = true;
            this.mainPath.Name = "mainPath";
            this.mainPath.Size = new System.Drawing.Size(400, 20);
            this.mainPath.TabIndex = 3;
            // 
            // scriptnameLabel
            // 
            this.scriptnameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scriptnameLabel.AutoSize = true;
            this.scriptnameLabel.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptnameLabel.ForeColor = System.Drawing.Color.White;
            this.scriptnameLabel.Location = new System.Drawing.Point(23, 17);
            this.scriptnameLabel.Name = "scriptnameLabel";
            this.scriptnameLabel.Size = new System.Drawing.Size(76, 12);
            this.scriptnameLabel.TabIndex = 2;
            this.scriptnameLabel.Text = "Compiler Path";
            // 
            // ConfigCompilerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(617, 300);
            this.Controls.Add(this.mainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(617, 300);
            this.MinimumSize = new System.Drawing.Size(617, 300);
            this.Name = "ConfigCompilerForm";
            this.Text = "Compiler Settings";
            this.Load += new System.EventHandler(this.ConfigCompilerForm_Load);
            this.SizeChanged += new System.EventHandler(this.ConfigCompilerForm_SizeChanged);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.TextBox mainPath;
        private System.Windows.Forms.Label scriptnameLabel;
        private System.Windows.Forms.Button buildScriptBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox flagPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox inputPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}
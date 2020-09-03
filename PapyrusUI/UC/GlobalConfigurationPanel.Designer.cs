namespace PapyrusUI
{
    partial class GlobalConfigurationPanel
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
            this.compilerPath = new PapyrusUI.PlaceholderTextbox();
            this.compilerFlagPath = new PapyrusUI.PlaceholderTextbox();
            this.papyrusCompilerLabel = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.importsPath = new PapyrusUI.PlaceholderTextbox();
            this.importsLabel = new System.Windows.Forms.Label();
            this.papyrusFlagLabel = new System.Windows.Forms.Label();
            this.outputPath = new PapyrusUI.PlaceholderTextbox();
            this.container = new System.Windows.Forms.Panel();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // compilerPath
            // 
            this.compilerPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.compilerPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compilerPath.EmptyBackColor = System.Drawing.Color.Empty;
            this.compilerPath.EmptyForeColor = System.Drawing.Color.Gray;
            this.compilerPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compilerPath.ForeColor = System.Drawing.Color.Gray;
            this.compilerPath.InactiveText = "Path to the papyrus compiler (usually located in the Skyrim directory) ...";
            this.compilerPath.Location = new System.Drawing.Point(21, 30);
            this.compilerPath.Name = "compilerPath";
            this.compilerPath.Size = new System.Drawing.Size(512, 13);
            this.compilerPath.TabIndex = 48;
            this.compilerPath.Text = "Path to the papyrus compiler (usually located in the Skyrim directory) ...";
            // 
            // compilerFlagPath
            // 
            this.compilerFlagPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.compilerFlagPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.compilerFlagPath.EmptyBackColor = System.Drawing.Color.Empty;
            this.compilerFlagPath.EmptyForeColor = System.Drawing.Color.Gray;
            this.compilerFlagPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compilerFlagPath.ForeColor = System.Drawing.Color.Gray;
            this.compilerFlagPath.InactiveText = "Path to the papyrus flag file (usually in the scripts source directory) ...";
            this.compilerFlagPath.Location = new System.Drawing.Point(19, 81);
            this.compilerFlagPath.Name = "compilerFlagPath";
            this.compilerFlagPath.Size = new System.Drawing.Size(512, 13);
            this.compilerFlagPath.TabIndex = 47;
            this.compilerFlagPath.Text = "Path to the papyrus flag file (usually in the scripts source directory) ...";
            // 
            // papyrusCompilerLabel
            // 
            this.papyrusCompilerLabel.AutoSize = true;
            this.papyrusCompilerLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.papyrusCompilerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.papyrusCompilerLabel.Location = new System.Drawing.Point(210, 11);
            this.papyrusCompilerLabel.Name = "papyrusCompilerLabel";
            this.papyrusCompilerLabel.Size = new System.Drawing.Size(138, 13);
            this.papyrusCompilerLabel.TabIndex = 39;
            this.papyrusCompilerLabel.Text = "Papyrus Compiler Path";
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.outputLabel.Location = new System.Drawing.Point(225, 170);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(105, 13);
            this.outputLabel.TabIndex = 43;
            this.outputLabel.Text = "Output Scripts To";
            // 
            // importsPath
            // 
            this.importsPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.importsPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.importsPath.EmptyBackColor = System.Drawing.Color.Empty;
            this.importsPath.EmptyForeColor = System.Drawing.Color.Gray;
            this.importsPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importsPath.ForeColor = System.Drawing.Color.Gray;
            this.importsPath.InactiveText = "Path to all the script sources from the game ...";
            this.importsPath.Location = new System.Drawing.Point(19, 138);
            this.importsPath.Name = "importsPath";
            this.importsPath.Size = new System.Drawing.Size(512, 13);
            this.importsPath.TabIndex = 46;
            this.importsPath.Text = "Path to all the script sources from the game ...";
            // 
            // importsLabel
            // 
            this.importsLabel.AutoSize = true;
            this.importsLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.importsLabel.Location = new System.Drawing.Point(216, 119);
            this.importsLabel.Name = "importsLabel";
            this.importsLabel.Size = new System.Drawing.Size(122, 13);
            this.importsLabel.TabIndex = 41;
            this.importsLabel.Text = "Import Scripts From";
            // 
            // papyrusFlagLabel
            // 
            this.papyrusFlagLabel.AutoSize = true;
            this.papyrusFlagLabel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.papyrusFlagLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.papyrusFlagLabel.Location = new System.Drawing.Point(237, 63);
            this.papyrusFlagLabel.Name = "papyrusFlagLabel";
            this.papyrusFlagLabel.Size = new System.Drawing.Size(80, 13);
            this.papyrusFlagLabel.TabIndex = 42;
            this.papyrusFlagLabel.Text = "Papyrus Flag";
            // 
            // outputPath
            // 
            this.outputPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.outputPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.outputPath.EmptyBackColor = System.Drawing.Color.Empty;
            this.outputPath.EmptyForeColor = System.Drawing.Color.Gray;
            this.outputPath.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputPath.ForeColor = System.Drawing.Color.Gray;
            this.outputPath.InactiveText = "Path to where the compiled scripts should go ...";
            this.outputPath.Location = new System.Drawing.Point(21, 190);
            this.outputPath.Name = "outputPath";
            this.outputPath.Size = new System.Drawing.Size(512, 13);
            this.outputPath.TabIndex = 45;
            this.outputPath.Text = "Path to where the compiled scripts should go ...";
            // 
            // container
            // 
            this.container.Controls.Add(this.compilerPath);
            this.container.Controls.Add(this.papyrusCompilerLabel);
            this.container.Controls.Add(this.compilerFlagPath);
            this.container.Controls.Add(this.outputPath);
            this.container.Controls.Add(this.papyrusFlagLabel);
            this.container.Controls.Add(this.outputLabel);
            this.container.Controls.Add(this.importsLabel);
            this.container.Controls.Add(this.importsPath);
            this.container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(555, 220);
            this.container.TabIndex = 49;
            // 
            // GlobalConfigurationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.container);
            this.Name = "GlobalConfigurationPanel";
            this.Size = new System.Drawing.Size(555, 220);
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PlaceholderTextbox compilerPath;
        private PlaceholderTextbox compilerFlagPath;
        private System.Windows.Forms.Label papyrusCompilerLabel;
        private System.Windows.Forms.Label outputLabel;
        private PlaceholderTextbox importsPath;
        private System.Windows.Forms.Label importsLabel;
        private System.Windows.Forms.Label papyrusFlagLabel;
        private PlaceholderTextbox outputPath;
        private System.Windows.Forms.Panel container;
    }
}

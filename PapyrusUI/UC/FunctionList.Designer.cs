namespace PapyrusUI.UC {
    partial class FunctionList {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FunctionList));
            this.categoryPanel = new System.Windows.Forms.Panel();
            this.eventsPanel = new System.Windows.Forms.Panel();
            this.eventsLbl = new System.Windows.Forms.Label();
            this.eventImg = new System.Windows.Forms.PictureBox();
            this.functionListSeparator = new System.Windows.Forms.Panel();
            this.fragmentsPanel = new System.Windows.Forms.Panel();
            this.fragmentsLbl = new System.Windows.Forms.Label();
            this.fragmentImg = new System.Windows.Forms.PictureBox();
            this.functionListSeparator2 = new System.Windows.Forms.Panel();
            this.functionsPanel = new System.Windows.Forms.Panel();
            this.functionsLbl = new System.Windows.Forms.Label();
            this.functionImg = new System.Windows.Forms.PictureBox();
            this.listview = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.categoryPanel.SuspendLayout();
            this.eventsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventImg)).BeginInit();
            this.fragmentsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentImg)).BeginInit();
            this.functionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.functionImg)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryPanel
            // 
            this.categoryPanel.Controls.Add(this.eventsPanel);
            this.categoryPanel.Controls.Add(this.functionListSeparator);
            this.categoryPanel.Controls.Add(this.fragmentsPanel);
            this.categoryPanel.Controls.Add(this.functionListSeparator2);
            this.categoryPanel.Controls.Add(this.functionsPanel);
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(448, 23);
            this.categoryPanel.TabIndex = 47;
            // 
            // eventsPanel
            // 
            this.eventsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.eventsPanel.Controls.Add(this.eventsLbl);
            this.eventsPanel.Controls.Add(this.eventImg);
            this.eventsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.eventsPanel.Location = new System.Drawing.Point(246, 0);
            this.eventsPanel.Name = "eventsPanel";
            this.eventsPanel.Size = new System.Drawing.Size(105, 23);
            this.eventsPanel.TabIndex = 42;
            // 
            // eventsLbl
            // 
            this.eventsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsLbl.AutoSize = true;
            this.eventsLbl.BackColor = System.Drawing.Color.Transparent;
            this.eventsLbl.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventsLbl.ForeColor = System.Drawing.Color.White;
            this.eventsLbl.Location = new System.Drawing.Point(32, 4);
            this.eventsLbl.Name = "eventsLbl";
            this.eventsLbl.Size = new System.Drawing.Size(50, 12);
            this.eventsLbl.TabIndex = 1;
            this.eventsLbl.Text = "0 Events";
            // 
            // eventImg
            // 
            this.eventImg.Image = global::PapyrusUI.Properties.Resources.eventIcon16x16;
            this.eventImg.Location = new System.Drawing.Point(7, 3);
            this.eventImg.Name = "eventImg";
            this.eventImg.Size = new System.Drawing.Size(16, 16);
            this.eventImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.eventImg.TabIndex = 0;
            this.eventImg.TabStop = false;
            // 
            // functionListSeparator
            // 
            this.functionListSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.functionListSeparator.Location = new System.Drawing.Point(238, 0);
            this.functionListSeparator.Name = "functionListSeparator";
            this.functionListSeparator.Size = new System.Drawing.Size(8, 23);
            this.functionListSeparator.TabIndex = 43;
            // 
            // fragmentsPanel
            // 
            this.fragmentsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fragmentsPanel.Controls.Add(this.fragmentsLbl);
            this.fragmentsPanel.Controls.Add(this.fragmentImg);
            this.fragmentsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.fragmentsPanel.Location = new System.Drawing.Point(123, 0);
            this.fragmentsPanel.Name = "fragmentsPanel";
            this.fragmentsPanel.Size = new System.Drawing.Size(115, 23);
            this.fragmentsPanel.TabIndex = 45;
            // 
            // fragmentsLbl
            // 
            this.fragmentsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fragmentsLbl.AutoSize = true;
            this.fragmentsLbl.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fragmentsLbl.ForeColor = System.Drawing.Color.White;
            this.fragmentsLbl.Location = new System.Drawing.Point(32, 4);
            this.fragmentsLbl.Name = "fragmentsLbl";
            this.fragmentsLbl.Size = new System.Drawing.Size(68, 12);
            this.fragmentsLbl.TabIndex = 1;
            this.fragmentsLbl.Text = "0 Fragments";
            // 
            // fragmentImg
            // 
            this.fragmentImg.Image = global::PapyrusUI.Properties.Resources.fragment16x16;
            this.fragmentImg.Location = new System.Drawing.Point(7, 3);
            this.fragmentImg.Name = "fragmentImg";
            this.fragmentImg.Size = new System.Drawing.Size(16, 16);
            this.fragmentImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fragmentImg.TabIndex = 0;
            this.fragmentImg.TabStop = false;
            // 
            // functionListSeparator2
            // 
            this.functionListSeparator2.Dock = System.Windows.Forms.DockStyle.Left;
            this.functionListSeparator2.Location = new System.Drawing.Point(115, 0);
            this.functionListSeparator2.Name = "functionListSeparator2";
            this.functionListSeparator2.Size = new System.Drawing.Size(8, 23);
            this.functionListSeparator2.TabIndex = 44;
            // 
            // functionsPanel
            // 
            this.functionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.functionsPanel.Controls.Add(this.functionsLbl);
            this.functionsPanel.Controls.Add(this.functionImg);
            this.functionsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.functionsPanel.Location = new System.Drawing.Point(0, 0);
            this.functionsPanel.Name = "functionsPanel";
            this.functionsPanel.Size = new System.Drawing.Size(115, 23);
            this.functionsPanel.TabIndex = 41;
            // 
            // functionsLbl
            // 
            this.functionsLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.functionsLbl.AutoSize = true;
            this.functionsLbl.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionsLbl.ForeColor = System.Drawing.Color.White;
            this.functionsLbl.Location = new System.Drawing.Point(32, 4);
            this.functionsLbl.Name = "functionsLbl";
            this.functionsLbl.Size = new System.Drawing.Size(64, 12);
            this.functionsLbl.TabIndex = 1;
            this.functionsLbl.Text = "0 Functions";
            // 
            // functionImg
            // 
            this.functionImg.Image = global::PapyrusUI.Properties.Resources.functionIcon16x16;
            this.functionImg.Location = new System.Drawing.Point(7, 3);
            this.functionImg.Name = "functionImg";
            this.functionImg.Size = new System.Drawing.Size(16, 16);
            this.functionImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.functionImg.TabIndex = 0;
            this.functionImg.TabStop = false;
            // 
            // listview
            // 
            this.listview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.listview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listview.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview.HideSelection = false;
            this.listview.LabelWrap = false;
            this.listview.Location = new System.Drawing.Point(0, 23);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(448, 306);
            this.listview.StateImageList = this.imageList;
            this.listview.TabIndex = 48;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 600;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "functionIcon12x12.png");
            this.imageList.Images.SetKeyName(1, "fragment16x16.png");
            this.imageList.Images.SetKeyName(2, "eventIcon12x12.png");
            // 
            // FunctionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.listview);
            this.Controls.Add(this.categoryPanel);
            this.Name = "FunctionList";
            this.Size = new System.Drawing.Size(448, 329);
            this.categoryPanel.ResumeLayout(false);
            this.eventsPanel.ResumeLayout(false);
            this.eventsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventImg)).EndInit();
            this.fragmentsPanel.ResumeLayout(false);
            this.fragmentsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fragmentImg)).EndInit();
            this.functionsPanel.ResumeLayout(false);
            this.functionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.functionImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel categoryPanel;
        private System.Windows.Forms.Panel eventsPanel;
        private System.Windows.Forms.Label eventsLbl;
        private System.Windows.Forms.PictureBox eventImg;
        private System.Windows.Forms.Panel functionListSeparator;
        private System.Windows.Forms.Panel fragmentsPanel;
        private System.Windows.Forms.Label fragmentsLbl;
        private System.Windows.Forms.PictureBox fragmentImg;
        private System.Windows.Forms.Panel functionListSeparator2;
        private System.Windows.Forms.Panel functionsPanel;
        private System.Windows.Forms.Label functionsLbl;
        private System.Windows.Forms.PictureBox functionImg;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ImageList imageList;
    }
}

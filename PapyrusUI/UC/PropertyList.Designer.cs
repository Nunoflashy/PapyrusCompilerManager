namespace PapyrusUI.UC {
    partial class PropertyList {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyList));
            this.panel = new System.Windows.Forms.Panel();
            this.functionsPanel = new System.Windows.Forms.Panel();
            this.propertyCount = new System.Windows.Forms.Label();
            this.img = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listview = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel.SuspendLayout();
            this.functionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.functionsPanel);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(448, 23);
            this.panel.TabIndex = 47;
            // 
            // functionsPanel
            // 
            this.functionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.functionsPanel.Controls.Add(this.propertyCount);
            this.functionsPanel.Controls.Add(this.img);
            this.functionsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.functionsPanel.Location = new System.Drawing.Point(0, 0);
            this.functionsPanel.Name = "functionsPanel";
            this.functionsPanel.Size = new System.Drawing.Size(115, 23);
            this.functionsPanel.TabIndex = 41;
            // 
            // propertyCount
            // 
            this.propertyCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyCount.AutoSize = true;
            this.propertyCount.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propertyCount.ForeColor = System.Drawing.Color.White;
            this.propertyCount.Location = new System.Drawing.Point(32, 4);
            this.propertyCount.Name = "propertyCount";
            this.propertyCount.Size = new System.Drawing.Size(67, 12);
            this.propertyCount.TabIndex = 1;
            this.propertyCount.Text = "0 Properties";
            // 
            // img
            // 
            this.img.Image = global::PapyrusUI.Properties.Resources.var44x44;
            this.img.Location = new System.Drawing.Point(7, 3);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(16, 16);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "var12x12.png");
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
            this.listview.ForeColor = System.Drawing.Color.White;
            this.listview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listview.HideSelection = false;
            this.listview.LabelWrap = false;
            this.listview.Location = new System.Drawing.Point(0, 23);
            this.listview.Name = "listview";
            this.listview.Size = new System.Drawing.Size(448, 306);
            this.listview.StateImageList = this.imageList;
            this.listview.TabIndex = 49;
            this.listview.UseCompatibleStateImageBehavior = false;
            this.listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 600;
            // 
            // PropertyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.listview);
            this.Controls.Add(this.panel);
            this.Name = "PropertyList";
            this.Size = new System.Drawing.Size(448, 329);
            this.panel.ResumeLayout(false);
            this.functionsPanel.ResumeLayout(false);
            this.functionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel functionsPanel;
        private System.Windows.Forms.Label propertyCount;
        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listview;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

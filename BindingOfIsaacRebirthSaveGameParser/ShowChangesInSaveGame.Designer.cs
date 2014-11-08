namespace BindingOfIsaacRebirthSaveGameParser {
    partial class ShowChangesInSaveGame {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnLoadOldFile = new System.Windows.Forms.Button();
            this.btnLoadNewFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Courier New", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 93);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(406, 246);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btnLoadOldFile
            // 
            this.btnLoadOldFile.AllowDrop = true;
            this.btnLoadOldFile.Location = new System.Drawing.Point(12, 12);
            this.btnLoadOldFile.Name = "btnLoadOldFile";
            this.btnLoadOldFile.Size = new System.Drawing.Size(200, 75);
            this.btnLoadOldFile.TabIndex = 1;
            this.btnLoadOldFile.Text = "Load Old File";
            this.btnLoadOldFile.UseVisualStyleBackColor = true;
            this.btnLoadOldFile.Click += new System.EventHandler(this.btnLoadOldFile_Click);
            this.btnLoadOldFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnLoadOldFile_DragDrop);
            this.btnLoadOldFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.button_DragEnter);
            // 
            // btnLoadNewFile
            // 
            this.btnLoadNewFile.AllowDrop = true;
            this.btnLoadNewFile.Location = new System.Drawing.Point(218, 12);
            this.btnLoadNewFile.Name = "btnLoadNewFile";
            this.btnLoadNewFile.Size = new System.Drawing.Size(200, 75);
            this.btnLoadNewFile.TabIndex = 2;
            this.btnLoadNewFile.Text = "Load New File";
            this.btnLoadNewFile.UseVisualStyleBackColor = true;
            this.btnLoadNewFile.Click += new System.EventHandler(this.btnLoadNewFile_Click);
            this.btnLoadNewFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnLoadNewFile_DragDrop);
            this.btnLoadNewFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.button_DragEnter);
            // 
            // ShowChangesInSaveGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 351);
            this.Controls.Add(this.btnLoadNewFile);
            this.Controls.Add(this.btnLoadOldFile);
            this.Controls.Add(this.richTextBox1);
            this.MinimumSize = new System.Drawing.Size(446, 390);
            this.Name = "ShowChangesInSaveGame";
            this.Text = "Changes in Save Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnLoadOldFile;
        private System.Windows.Forms.Button btnLoadNewFile;
    }
}
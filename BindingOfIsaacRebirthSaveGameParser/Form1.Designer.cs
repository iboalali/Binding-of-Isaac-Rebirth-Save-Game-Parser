namespace BindingOfIsaacRebirthSaveGameParser {
    partial class Form1 {
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDeaths = new System.Windows.Forms.Label();
            this.btnOpenSaveGame = new System.Windows.Forms.Button();
            this.btnShowFile = new System.Windows.Forms.Button();
            this.btnShowChanges = new System.Windows.Forms.Button();
            this.btnShowChangesRealTime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(336, 236);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Deaths";
            // 
            // lblDeaths
            // 
            this.lblDeaths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeaths.Location = new System.Drawing.Point(311, 9);
            this.lblDeaths.Name = "lblDeaths";
            this.lblDeaths.Size = new System.Drawing.Size(100, 23);
            this.lblDeaths.TabIndex = 2;
            // 
            // btnOpenSaveGame
            // 
            this.btnOpenSaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSaveGame.Location = new System.Drawing.Point(220, 236);
            this.btnOpenSaveGame.Name = "btnOpenSaveGame";
            this.btnOpenSaveGame.Size = new System.Drawing.Size(110, 23);
            this.btnOpenSaveGame.TabIndex = 3;
            this.btnOpenSaveGame.Text = "Open Save Game";
            this.btnOpenSaveGame.UseVisualStyleBackColor = true;
            this.btnOpenSaveGame.Click += new System.EventHandler(this.btnOpenSaveGame_Click);
            // 
            // btnShowFile
            // 
            this.btnShowFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowFile.Location = new System.Drawing.Point(336, 207);
            this.btnShowFile.Name = "btnShowFile";
            this.btnShowFile.Size = new System.Drawing.Size(75, 23);
            this.btnShowFile.TabIndex = 4;
            this.btnShowFile.Text = "Show File";
            this.btnShowFile.UseVisualStyleBackColor = true;
            this.btnShowFile.Click += new System.EventHandler(this.btnShowFile_Click);
            // 
            // btnShowChanges
            // 
            this.btnShowChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowChanges.Location = new System.Drawing.Point(220, 207);
            this.btnShowChanges.Name = "btnShowChanges";
            this.btnShowChanges.Size = new System.Drawing.Size(110, 23);
            this.btnShowChanges.TabIndex = 5;
            this.btnShowChanges.Text = "Show Changes";
            this.btnShowChanges.UseVisualStyleBackColor = true;
            this.btnShowChanges.Click += new System.EventHandler(this.btnShowChanges_Click);
            // 
            // btnShowChangesRealTime
            // 
            this.btnShowChangesRealTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowChangesRealTime.Location = new System.Drawing.Point(53, 236);
            this.btnShowChangesRealTime.Name = "btnShowChangesRealTime";
            this.btnShowChangesRealTime.Size = new System.Drawing.Size(161, 23);
            this.btnShowChangesRealTime.TabIndex = 6;
            this.btnShowChangesRealTime.Text = "Show Changes in Real Time";
            this.btnShowChangesRealTime.UseVisualStyleBackColor = true;
            this.btnShowChangesRealTime.Click += new System.EventHandler(this.btnShowChangesRealTime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 271);
            this.Controls.Add(this.btnShowChangesRealTime);
            this.Controls.Add(this.btnShowChanges);
            this.Controls.Add(this.btnShowFile);
            this.Controls.Add(this.btnOpenSaveGame);
            this.Controls.Add(this.lblDeaths);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Binding of Isaac Rebirt Save Game Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDeaths;
        private System.Windows.Forms.Button btnOpenSaveGame;
        private System.Windows.Forms.Button btnShowFile;
        private System.Windows.Forms.Button btnShowChanges;
        private System.Windows.Forms.Button btnShowChangesRealTime;
    }
}


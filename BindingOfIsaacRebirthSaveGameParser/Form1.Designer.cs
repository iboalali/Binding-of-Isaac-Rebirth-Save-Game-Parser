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
            this.btnOpenSaveGame = new System.Windows.Forms.Button();
            this.btnShowFile = new System.Windows.Forms.Button();
            this.btnShowChanges = new System.Windows.Forms.Button();
            this.btnShowChangesRealTime = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSaveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGame1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGame2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGame3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareTwoSaveGamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRealTimeChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(325, 257);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOpenSaveGame
            // 
            this.btnOpenSaveGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSaveGame.Location = new System.Drawing.Point(209, 257);
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
            this.btnShowFile.Location = new System.Drawing.Point(325, 228);
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
            this.btnShowChanges.Location = new System.Drawing.Point(209, 228);
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
            this.btnShowChangesRealTime.Location = new System.Drawing.Point(42, 257);
            this.btnShowChangesRealTime.Name = "btnShowChangesRealTime";
            this.btnShowChangesRealTime.Size = new System.Drawing.Size(161, 23);
            this.btnShowChangesRealTime.TabIndex = 6;
            this.btnShowChangesRealTime.Text = "Show Changes in Real Time";
            this.btnShowChangesRealTime.UseVisualStyleBackColor = true;
            this.btnShowChangesRealTime.Click += new System.EventHandler(this.btnShowChangesRealTime_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.Location = new System.Drawing.Point(15, 27);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(389, 253);
            this.listView.TabIndex = 7;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 80;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(416, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSaveGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openSaveGameToolStripMenuItem
            // 
            this.openSaveGameToolStripMenuItem.Name = "openSaveGameToolStripMenuItem";
            this.openSaveGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openSaveGameToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.openSaveGameToolStripMenuItem.Text = "Open Save Game";
            this.openSaveGameToolStripMenuItem.Click += new System.EventHandler(this.btnOpenSaveGame_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveGame1ToolStripMenuItem,
            this.saveGame2ToolStripMenuItem,
            this.saveGame3ToolStripMenuItem});
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            // 
            // saveGame1ToolStripMenuItem
            // 
            this.saveGame1ToolStripMenuItem.Name = "saveGame1ToolStripMenuItem";
            this.saveGame1ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.saveGame1ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.saveGame1ToolStripMenuItem.Text = "Open Save Game 1";
            this.saveGame1ToolStripMenuItem.Click += new System.EventHandler(this.saveGame1ToolStripMenuItem_Click);
            // 
            // saveGame2ToolStripMenuItem
            // 
            this.saveGame2ToolStripMenuItem.Name = "saveGame2ToolStripMenuItem";
            this.saveGame2ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.saveGame2ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.saveGame2ToolStripMenuItem.Text = "Open Save Game 2";
            this.saveGame2ToolStripMenuItem.Click += new System.EventHandler(this.saveGame2ToolStripMenuItem_Click);
            // 
            // saveGame3ToolStripMenuItem
            // 
            this.saveGame3ToolStripMenuItem.Name = "saveGame3ToolStripMenuItem";
            this.saveGame3ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.saveGame3ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.saveGame3ToolStripMenuItem.Text = "Open Save Game 3";
            this.saveGame3ToolStripMenuItem.Click += new System.EventHandler(this.saveGame3ToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compareTwoSaveGamesToolStripMenuItem,
            this.showRealTimeChangesToolStripMenuItem,
            this.hexViewerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // compareTwoSaveGamesToolStripMenuItem
            // 
            this.compareTwoSaveGamesToolStripMenuItem.Name = "compareTwoSaveGamesToolStripMenuItem";
            this.compareTwoSaveGamesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.compareTwoSaveGamesToolStripMenuItem.Text = "Compare Two Save Games";
            this.compareTwoSaveGamesToolStripMenuItem.Click += new System.EventHandler(this.btnShowChanges_Click);
            // 
            // showRealTimeChangesToolStripMenuItem
            // 
            this.showRealTimeChangesToolStripMenuItem.Name = "showRealTimeChangesToolStripMenuItem";
            this.showRealTimeChangesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showRealTimeChangesToolStripMenuItem.Text = "Show Real Time Changes";
            this.showRealTimeChangesToolStripMenuItem.Click += new System.EventHandler(this.btnShowChangesRealTime_Click);
            // 
            // hexViewerToolStripMenuItem
            // 
            this.hexViewerToolStripMenuItem.Name = "hexViewerToolStripMenuItem";
            this.hexViewerToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.hexViewerToolStripMenuItem.Text = "Hex Viewer";
            this.hexViewerToolStripMenuItem.Click += new System.EventHandler(this.btnShowFile_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 294);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnShowChangesRealTime);
            this.Controls.Add(this.btnShowChanges);
            this.Controls.Add(this.btnShowFile);
            this.Controls.Add(this.btnOpenSaveGame);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(432, 333);
            this.Name = "Form1";
            this.Text = "Binding of Isaac Rebirt Save Game Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOpenSaveGame;
        private System.Windows.Forms.Button btnShowFile;
        private System.Windows.Forms.Button btnShowChanges;
        private System.Windows.Forms.Button btnShowChangesRealTime;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSaveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGame1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGame2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGame3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compareTwoSaveGamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRealTimeChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexViewerToolStripMenuItem;
    }
}


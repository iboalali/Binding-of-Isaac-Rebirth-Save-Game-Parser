namespace BindingOfIsaacRebirthSaveGameParser {
    partial class SaveFileHex {
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
            this.rtbHex = new System.Windows.Forms.RichTextBox();
            this.btnHex = new System.Windows.Forms.Button();
            this.btnDec = new System.Windows.Forms.Button();
            this.btnBin = new System.Windows.Forms.Button();
            this.txtOffsetHeader = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchWord = new System.Windows.Forms.TextBox();
            this.btnResetSearch = new System.Windows.Forms.Button();
            this.btnBeyondTheByteSearch = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbHex
            // 
            this.rtbHex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbHex.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.rtbHex.Location = new System.Drawing.Point(12, 83);
            this.rtbHex.Name = "rtbHex";
            this.rtbHex.Size = new System.Drawing.Size(400, 409);
            this.rtbHex.TabIndex = 0;
            this.rtbHex.Text = "";
            this.rtbHex.SelectionChanged += new System.EventHandler(this.rtbHex_SelectionChanged);
            // 
            // btnHex
            // 
            this.btnHex.Location = new System.Drawing.Point(12, 6);
            this.btnHex.Name = "btnHex";
            this.btnHex.Size = new System.Drawing.Size(55, 23);
            this.btnHex.TabIndex = 1;
            this.btnHex.Text = "Hex";
            this.btnHex.UseVisualStyleBackColor = true;
            this.btnHex.Click += new System.EventHandler(this.btnHex_Click);
            // 
            // btnDec
            // 
            this.btnDec.Location = new System.Drawing.Point(73, 6);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(55, 23);
            this.btnDec.TabIndex = 2;
            this.btnDec.Text = "Decimal";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // btnBin
            // 
            this.btnBin.Location = new System.Drawing.Point(134, 6);
            this.btnBin.Name = "btnBin";
            this.btnBin.Size = new System.Drawing.Size(55, 23);
            this.btnBin.TabIndex = 3;
            this.btnBin.Text = "Binary";
            this.btnBin.UseVisualStyleBackColor = true;
            this.btnBin.Click += new System.EventHandler(this.btnBin_Click);
            // 
            // txtOffsetHeader
            // 
            this.txtOffsetHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOffsetHeader.Font = new System.Drawing.Font("Courier New", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffsetHeader.Location = new System.Drawing.Point(12, 61);
            this.txtOffsetHeader.Name = "txtOffsetHeader";
            this.txtOffsetHeader.Size = new System.Drawing.Size(400, 21);
            this.txtOffsetHeader.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(304, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchWord
            // 
            this.txtSearchWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchWord.Location = new System.Drawing.Point(271, 35);
            this.txtSearchWord.Name = "txtSearchWord";
            this.txtSearchWord.Size = new System.Drawing.Size(141, 20);
            this.txtSearchWord.TabIndex = 6;
            // 
            // btnResetSearch
            // 
            this.btnResetSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetSearch.Location = new System.Drawing.Point(271, 6);
            this.btnResetSearch.Name = "btnResetSearch";
            this.btnResetSearch.Size = new System.Drawing.Size(27, 23);
            this.btnResetSearch.TabIndex = 7;
            this.btnResetSearch.Text = "R";
            this.btnResetSearch.UseVisualStyleBackColor = true;
            this.btnResetSearch.Click += new System.EventHandler(this.btnResetSearch_Click);
            // 
            // btnBeyondTheByteSearch
            // 
            this.btnBeyondTheByteSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeyondTheByteSearch.Enabled = false;
            this.btnBeyondTheByteSearch.Location = new System.Drawing.Point(385, 6);
            this.btnBeyondTheByteSearch.Name = "btnBeyondTheByteSearch";
            this.btnBeyondTheByteSearch.Size = new System.Drawing.Size(27, 23);
            this.btnBeyondTheByteSearch.TabIndex = 8;
            this.btnBeyondTheByteSearch.Text = "A";
            this.btnBeyondTheByteSearch.UseVisualStyleBackColor = true;
            this.btnBeyondTheByteSearch.Click += new System.EventHandler(this.btnBeyondTheByteSearch_Click);
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Location = new System.Drawing.Point(195, 11);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(13, 13);
            this.lblSelection.TabIndex = 9;
            this.lblSelection.Text = "0";
            // 
            // SaveFileHex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 504);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.btnBeyondTheByteSearch);
            this.Controls.Add(this.btnResetSearch);
            this.Controls.Add(this.txtSearchWord);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtOffsetHeader);
            this.Controls.Add(this.btnBin);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnHex);
            this.Controls.Add(this.rtbHex);
            this.MinimumSize = new System.Drawing.Size(440, 543);
            this.Name = "SaveFileHex";
            this.Text = "SaveFileHex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHex;
        private System.Windows.Forms.Button btnHex;
        private System.Windows.Forms.Button btnDec;
        private System.Windows.Forms.Button btnBin;
        private System.Windows.Forms.TextBox txtOffsetHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchWord;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Button btnBeyondTheByteSearch;
        private System.Windows.Forms.Label lblSelection;
    }
}
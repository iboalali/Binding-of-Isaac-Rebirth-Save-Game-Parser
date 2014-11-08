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
            this.SuspendLayout();
            // 
            // rtbHex
            // 
            this.rtbHex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbHex.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.rtbHex.Location = new System.Drawing.Point(12, 35);
            this.rtbHex.Name = "rtbHex";
            this.rtbHex.Size = new System.Drawing.Size(400, 457);
            this.rtbHex.TabIndex = 0;
            this.rtbHex.Text = "";
            // 
            // btnHex
            // 
            this.btnHex.Location = new System.Drawing.Point(12, 6);
            this.btnHex.Name = "btnHex";
            this.btnHex.Size = new System.Drawing.Size(75, 23);
            this.btnHex.TabIndex = 1;
            this.btnHex.Text = "HEX";
            this.btnHex.UseVisualStyleBackColor = true;
            this.btnHex.Click += new System.EventHandler(this.btnHex_Click);
            // 
            // btnDec
            // 
            this.btnDec.Location = new System.Drawing.Point(93, 6);
            this.btnDec.Name = "btnDec";
            this.btnDec.Size = new System.Drawing.Size(75, 23);
            this.btnDec.TabIndex = 2;
            this.btnDec.Text = "DEC";
            this.btnDec.UseVisualStyleBackColor = true;
            this.btnDec.Click += new System.EventHandler(this.btnDec_Click);
            // 
            // SaveFileHex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 504);
            this.Controls.Add(this.btnDec);
            this.Controls.Add(this.btnHex);
            this.Controls.Add(this.rtbHex);
            this.MinimumSize = new System.Drawing.Size(440, 543);
            this.Name = "SaveFileHex";
            this.Text = "SaveFileHex";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbHex;
        private System.Windows.Forms.Button btnHex;
        private System.Windows.Forms.Button btnDec;
    }
}
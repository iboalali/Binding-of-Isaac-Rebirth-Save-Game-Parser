namespace BindingOfIsaacRebirthSaveGameParser {
    partial class ShowChanges_RealTime {
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblSnapShot1 = new System.Windows.Forms.Label();
            this.rtbChanges = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnLocationToTrack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblSnapShot1
            // 
            this.lblSnapShot1.Location = new System.Drawing.Point(90, 52);
            this.lblSnapShot1.Name = "lblSnapShot1";
            this.lblSnapShot1.Size = new System.Drawing.Size(159, 19);
            this.lblSnapShot1.TabIndex = 2;
            this.lblSnapShot1.Text = "[Date and Time]";
            this.lblSnapShot1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rtbChanges
            // 
            this.rtbChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbChanges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbChanges.Font = new System.Drawing.Font("Courier New", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbChanges.Location = new System.Drawing.Point(12, 74);
            this.rtbChanges.Name = "rtbChanges";
            this.rtbChanges.Size = new System.Drawing.Size(673, 229);
            this.rtbChanges.TabIndex = 4;
            this.rtbChanges.Text = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(75, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(14, 229);
            this.panel1.TabIndex = 5;
            // 
            // lblCounter
            // 
            this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounter.Location = new System.Drawing.Point(595, 52);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(90, 19);
            this.lblCounter.TabIndex = 6;
            this.lblCounter.Text = "0";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLocationToTrack
            // 
            this.btnLocationToTrack.Enabled = false;
            this.btnLocationToTrack.Location = new System.Drawing.Point(174, 12);
            this.btnLocationToTrack.Name = "btnLocationToTrack";
            this.btnLocationToTrack.Size = new System.Drawing.Size(180, 23);
            this.btnLocationToTrack.TabIndex = 7;
            this.btnLocationToTrack.Text = "Add Location To Track";
            this.btnLocationToTrack.UseVisualStyleBackColor = true;
            this.btnLocationToTrack.Visible = false;
            this.btnLocationToTrack.Click += new System.EventHandler(this.btnLocationToTrack_Click);
            // 
            // ShowChanges_RealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 315);
            this.Controls.Add(this.btnLocationToTrack);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rtbChanges);
            this.Controls.Add(this.lblSnapShot1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(713, 354);
            this.Name = "ShowChanges_RealTime";
            this.Text = "ShowChanges_RealTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowChanges_RealTime_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblSnapShot1;
        private System.Windows.Forms.RichTextBox rtbChanges;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnLocationToTrack;
    }
}
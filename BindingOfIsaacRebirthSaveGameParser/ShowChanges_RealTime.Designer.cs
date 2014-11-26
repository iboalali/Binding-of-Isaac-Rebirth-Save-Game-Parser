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
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnLocationToTrack = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // lblCounter
            // 
            this.lblCounter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounter.Location = new System.Drawing.Point(522, 52);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(90, 19);
            this.lblCounter.TabIndex = 6;
            this.lblCounter.Text = "0";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLocationToTrack
            // 
            this.btnLocationToTrack.Location = new System.Drawing.Point(174, 12);
            this.btnLocationToTrack.Name = "btnLocationToTrack";
            this.btnLocationToTrack.Size = new System.Drawing.Size(180, 23);
            this.btnLocationToTrack.TabIndex = 7;
            this.btnLocationToTrack.Text = "[debug] time line";
            this.btnLocationToTrack.UseVisualStyleBackColor = true;
            this.btnLocationToTrack.Visible = false;
            this.btnLocationToTrack.Click += new System.EventHandler(this.btnLocationToTrack_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView.Location = new System.Drawing.Point(12, 74);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(600, 229);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Location";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "From";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "To";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Comments";
            this.columnHeader4.Width = 400;
            // 
            // ShowChanges_RealTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 315);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.btnLocationToTrack);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.lblSnapShot1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(640, 354);
            this.Name = "ShowChanges_RealTime";
            this.Text = "Show Real Time Changes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowChanges_RealTime_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblSnapShot1;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnLocationToTrack;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
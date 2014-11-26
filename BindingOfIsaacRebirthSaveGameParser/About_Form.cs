using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingOfIsaacRebirthSaveGameParser {
    public partial class About_Form : Form {
        public About_Form () {
            InitializeComponent();
            //Icon i = new System.Drawing.Icon( global::BindingOfIsaacRebirthSaveGameParser.Properties.Resources.isaac_ng_101, 32, 32 );

            pictureBox1.Image = Form1.appIcon.ToBitmap();

            LinkLabel.Link linkLicense = new LinkLabel.Link();
            linkLicense.LinkData = "http://www.apache.org/licenses/LICENSE-2.0";
            linkLabelLicense.Links.Add( linkLicense );

            LinkLabel.Link linkEmail = new LinkLabel.Link();
            linkEmail.LinkData = "mailto:iboalali@gmail.com";
            linkLabelEmail.Links.Add( linkEmail );

            LinkLabel.Link linkPage = new LinkLabel.Link();
            linkPage.LinkData = "http://iboalali.com";
            linkLabelPage.Links.Add( linkPage );

            LinkLabel.Link linkTwitter = new LinkLabel.Link();
            linkTwitter.LinkData = "https://twitter.com/iboalali";
            linkLabelTwitter.Links.Add( linkTwitter );
        }


        private void linkLabel_LinkClicked ( object sender, LinkLabelLinkClickedEventArgs e ) {
            Process.Start( e.Link.LinkData as string );
        }

        private void btnClose_Click ( object sender, EventArgs e ) {
            this.Close();
        }

    }
}

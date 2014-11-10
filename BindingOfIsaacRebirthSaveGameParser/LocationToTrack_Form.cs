using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingOfIsaacRebirthSaveGameParser {
    public partial class LocationToTrack_Form : Form {
        public LocationToTrack_Form () {
            InitializeComponent();

        }

        private void listView_KeyPress ( object sender, KeyPressEventArgs e ) {
            // delete the selected row
            // not tested

            if ( listView.SelectedItems.Count > 0 ) {
                for ( int i = listView.SelectedItems.Count - 1; i >= 0; i-- ) {
                    ListViewItem itm = listView.SelectedItems[i];
                    listView.Items[itm.Index].Remove();
                }
            }
        }

        private void LocationToTrack_Form_Load ( object sender, EventArgs e ) {
            MessageBox.Show( "delete from the listview is still not tested" );

        }



    }
}

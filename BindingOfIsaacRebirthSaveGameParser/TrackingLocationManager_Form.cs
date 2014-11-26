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
    public partial class TrackingLocationManager_Form : Form {

        public TrackingLocationManager_Form () {
            InitializeComponent();
            this.Icon = Form1.appIcon;

            List<string> list = new List<string>();
            list.Add( "New Entry" );

            foreach ( var item in StatLocation.locations ) {
                list.Add( item.Name );
            }

            BindingSource source = new BindingSource();
            source.DataSource = list.ToArray();

            comboBox1.DataSource = source;
            

        }

        private void TrackingLocationManager_Form_Load ( object sender, EventArgs e ) {

        }

        private void comboBox1_SelectedIndexChanged ( object sender, EventArgs e ) {
            string selected = ( string ) ( sender as ComboBox ).SelectedItem;

            if ( selected == "New Entry" ) {
                btnRemove.Visible = false;
                btnUpdate.Visible = false;
                txtName.Text = txtFrom.Text = txtTo.Text = string.Empty;

                


            } else {
                btnRemove.Visible = true;
                btnUpdate.Visible = true;

                txtName.Text = selected;
                txtFrom.Text = StatLocation.GetLocation_From( selected ).ToString();
                txtTo.Text = StatLocation.GetLocation_To( selected ).ToString();



            }


        }

        private void button1_Click ( object sender, EventArgs e ) {
            this.Close();

        }

        private void btnRemove_Click ( object sender, EventArgs e ) {
            StatLocation.RemoveLocation( ( string ) comboBox1.SelectedItem );
            txtName.Text = txtFrom.Text = txtTo.Text = string.Empty;

            List<string> list = new List<string>();
            list.Add( "New Entry" );

            foreach ( var item in StatLocation.locations ) {
                list.Add( item.Name );
            }

            BindingSource source = new BindingSource();
            source.DataSource = list.ToArray();

            comboBox1.DataSource = source;

        }

        private void btnAdd_Click ( object sender, EventArgs e ) {
            StatLocation.Location l = new StatLocation.Location();
            l.Name = txtName.Text;
            l.From = int.Parse( txtFrom.Text );
            l.To = int.Parse( txtTo.Text );

            StatLocation.AddNewLocation( l );
            txtName.Text = txtFrom.Text = txtTo.Text = string.Empty;

            List<string> list = new List<string>();
            list.Add( "New Entry" );

            foreach ( var item in StatLocation.locations ) {
                list.Add( item.Name );
            }

            BindingSource source = new BindingSource();
            source.DataSource = list.ToArray();

            comboBox1.DataSource = source;

        }


        private void btnUpdate_Click ( object sender, EventArgs e ) {
            StatLocation.Location l = new StatLocation.Location();
            l.Name = txtName.Text;
            l.From = int.Parse( txtFrom.Text );
            l.To = int.Parse( txtTo.Text );

            StatLocation.UpdateLocation( ( string ) comboBox1.SelectedItem, l );

            txtName.Text = txtFrom.Text = txtTo.Text = string.Empty;

            List<string> list = new List<string>();
            list.Add( "New Entry" );

            foreach ( var item in StatLocation.locations ) {
                list.Add( item.Name );
            }

            BindingSource source = new BindingSource();
            source.DataSource = list.ToArray();

            comboBox1.DataSource = source;

            comboBox1.SelectedItem = l.Name;

        }

        private void digitsOnly_KeyPress ( object sender, KeyPressEventArgs e ) {
            if ( !char.IsDigit( e.KeyChar ) && !char.IsControl( e.KeyChar ) ) {
                e.Handled = true;

            }

        }
    }
}

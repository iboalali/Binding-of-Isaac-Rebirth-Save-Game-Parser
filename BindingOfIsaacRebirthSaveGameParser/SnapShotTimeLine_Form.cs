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
    public partial class SnapShotTimeLine_Form : Form {
        private List<SaveGameSnapShot> saveGames;
        private int index;

        public SnapShotTimeLine_Form ( List<SaveGameSnapShot> saveGames ) {
            InitializeComponent();

            this.index = 1;
            this.saveGames = saveGames;

        }

        private void SnapShotTimeLine_Form_Load ( object sender, EventArgs e ) {
            columnHeaderLast.Text = "Value on " + saveGames[0].Date.ToString();
            columnHeaderCurrent.Text = "Value on " + saveGames[1].Date.ToString();

            for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ ) {
                if ( saveGames[0].SnapShot[i] != saveGames[1].SnapShot[i] ) {

                    listView.Items.Add(
                        new ListViewItem(
                            new string[] {
                                i.ToString("X4"),
                                saveGames[0].SnapShot[i].ToString("X2"),
                                saveGames[1].SnapShot[i].ToString("X2"),
                                                                
                            }
                        )
                    );



                }
            }
        }

        private void btnClose_Click ( object sender, EventArgs e ) {
            this.Close();

        }

        private void btnNext_Click ( object sender, EventArgs e ) {

            if ( ++index >= saveGames.Count ) {
                System.Media.SystemSounds.Exclamation.Play();
                --index;
                return;
            }

            listView.Items.Clear();

            columnHeaderLast.Text = "Value on " + saveGames[index - 1].Date.ToString();
            columnHeaderCurrent.Text = "Value on " + saveGames[index].Date.ToString();

            for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ ) {
                if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] ) {

                    listView.Items.Add(
                        new ListViewItem(
                            new string[] {
                                i.ToString("X4"),
                                saveGames[index - 1].SnapShot[i].ToString("X2"),
                                saveGames[index].SnapShot[i].ToString("X2"),
                                                                
                            }
                        )
                    );



                }
            }


        }

        private void btnPrevious_Click ( object sender, EventArgs e ) {
            if ( --index < 1 ) {
                System.Media.SystemSounds.Exclamation.Play();
                ++index;
                return;
            }
            listView.Items.Clear();

            columnHeaderLast.Text = "Value on " + saveGames[index - 1].Date.ToString();
            columnHeaderCurrent.Text = "Value on " + saveGames[index].Date.ToString();

            for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ ) {
                if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] ) {

                    listView.Items.Add(
                        new ListViewItem(
                            new string[] {
                                i.ToString("X4"),
                                saveGames[index - 1].SnapShot[i].ToString("X2"),
                                saveGames[index].SnapShot[i].ToString("X2"),
                                                                
                            }
                        )
                    );



                }
            }

        }









    }


}

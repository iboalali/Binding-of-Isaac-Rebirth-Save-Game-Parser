using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace BindingOfIsaacRebirthSaveGameParser {

    public partial class SnapShotTimeLine_Form : Form {
        private List<SaveGameSnapShot> saveGames;
        private int index;

        public SnapShotTimeLine_Form ( List<SaveGameSnapShot> saveGames ) {
            InitializeComponent();

            this.Icon = Form1.appIcon;
            this.index = 1;
            this.saveGames = saveGames;

        }

        public SnapShotTimeLine_Form () {
            InitializeComponent();

            this.Icon = Form1.appIcon;
        }

        private void SnapShotTimeLine_Form_Load ( object sender, EventArgs e ) {
            if ( saveGames == null ) {
                return;
            }

            columnHeaderLast.Text = "Value on " + saveGames[0].Date.ToString();
            columnHeaderCurrent.Text = "Value on " + saveGames[1].Date.ToString();

            for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ ) {
                if ( saveGames[0].SnapShot[i] != saveGames[1].SnapShot[i] ) {

                    if ( StatLocation.ContainsLocation( i ) ) {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    i.ToString( "X4" ) + " - " + ( i + StatLocation.GetNumberOfByteMinusOne( i ) ).ToString( "X4" ),
                                    StatLocation.GetValue( saveGames[0].SnapShot, i ).ToString(),
                                    StatLocation.GetValue( saveGames[1].SnapShot, i ).ToString(),
                                    StatLocation.GetLocation_Name( i )                             
                                }
                            )
                        );

                    } else {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    i.ToString("X4"),
                                    saveGames[index - 1].SnapShot[i].ToString("X2"),
                                    saveGames[index].SnapShot[i].ToString("X2"),
                                }
                            )
                        );

                    } // end if ( StatLocation.ContainsLocation( i ) ) else
                } // end if ( saveGames[0].SnapShot[i] != saveGames[1].SnapShot[i] )
            } // end for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ )

        } // end private void SnapShotTimeLine_Form_Load ( object sender, EventArgs e )

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
                    if ( StatLocation.ContainsLocation( i ) ) {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    i.ToString( "X4" ) + " - " + ( i + StatLocation.GetNumberOfByteMinusOne( i ) ).ToString( "X4" ),
                                    StatLocation.GetValue( saveGames[index - 1].SnapShot, i ).ToString(),
                                    StatLocation.GetValue( saveGames[index].SnapShot, i ).ToString(),
                                    StatLocation.GetLocation_Name( i )                             
                                }
                            )
                        );

                    } else {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    i.ToString("X4"),
                                    saveGames[index - 1].SnapShot[i].ToString("X2"),
                                    saveGames[index].SnapShot[i].ToString("X2"),
                                }
                            )
                        );

                    } // end if ( StatLocation.ContainsLocation( i ) ) else
                } // end if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] )
            } // end for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ )

        } // end private void btnNext_Click ( object sender, EventArgs e )

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
                    if ( StatLocation.ContainsLocation( i ) ) {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    i.ToString( "X4" ) + " - " + ( i + StatLocation.GetNumberOfByteMinusOne( i ) ).ToString( "X4" ),
                                    StatLocation.GetValue( saveGames[index - 1].SnapShot, i ).ToString(),
                                    StatLocation.GetValue( saveGames[index].SnapShot, i ).ToString(),
                                    StatLocation.GetLocation_Name( i )                             
                                }
                            )
                        );

                    } else {
                        listView.Items.Add(
                            new ListViewItem(
                                new string[] {
                                    i.ToString("X4"),
                                    saveGames[index - 1].SnapShot[i].ToString("X2"),
                                    saveGames[index].SnapShot[i].ToString("X2"),
                                }
                            )
                        );

                    } // end if ( StatLocation.ContainsLocation( i ) ) else
                } // end if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] )
            } // end for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ )

        }

        private delegate void SetControlPropertyThreadSafeDelegate ( Control control, string propertyName, object propertyValue );

        public static void SetControlPropertyThreadSafe ( Control control, string propertyName, object propertyValue ) {
            if ( control.InvokeRequired ) {
                control.Invoke( new SetControlPropertyThreadSafeDelegate( SetControlPropertyThreadSafe ), new object[] { control, propertyName, propertyValue } );
            } else {
                control.GetType().InvokeMember( propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue } );
            }
        }

        private void openFileToolStripMenuItem_Click ( object sender, EventArgs e ) {
            // Import a binary file here
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TBoIR Stats File (*.tboi)|*.tboi";

            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                try {
                    using ( Stream stream = File.OpenRead( ofd.FileName ) ) {
                        BinaryFormatter bin = new BinaryFormatter();
                        saveGames = ( List<SaveGameSnapShot> ) bin.Deserialize( stream );

                    }

                } catch ( IOException ioex ) {
                    MessageBox.Show( ioex.Message, "Error While Reading" );

                }

            }

            if ( saveGames == null ) {
                return;
            }

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

        void exportToBinaryFileToolStripMenuItem_Click ( object sender, EventArgs e ) {
            // export to binary file here

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "TBoIR Stats File (*.tboi)|*.tboi";
            sfd.FileName = "tboir_" + GetSafeFilename( saveGames.First().Date.ToString() );

            if ( sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                try {
                    using ( Stream stream = File.OpenWrite( sfd.FileName ) ) {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize( stream, saveGames );

                    }
                } catch ( IOException ioex ) {
                    MessageBox.Show( ioex.Message, "Error While Writing" );

                }


            }



        }

        void exportToTextFileToolStripMenuItem_Click ( object sender, EventArgs e ) {
            // export to text file here
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Log File (*.log)|*.log";
            sfd.FileName = "tboir_" + GetSafeFilename( saveGames.First().Date.ToString() );

            if ( sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                using ( StreamWriter sw = new StreamWriter( sfd.FileName ) ) {
                    for ( int index = 1; index < saveGames.Count; index++ ) {
                        sw.WriteLine( saveGames[index].Index.ToString( "D6" ) + ", " + saveGames[index].Date.ToString() );

                        for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ ) {
                            if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] ) {
                                sw.WriteLine(
                                     i.ToString( "X4" ) + "\t"
                                     + saveGames[index - 1].SnapShot[i].ToString( "X2" ) + "\t"
                                     + saveGames[index].SnapShot[i].ToString( "X2" ) + "\t"
                                     + StatLocation.GetLocation_Name( i )
                                );

                            } // end if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] )
                        } // end for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ )
                        sw.Write( "------------------------------------------" );
                        sw.Write( Environment.NewLine );

                    } // end for ( int index = 0; index < saveGames.Count; index++ )
                } // end using ( StreamWriter sw = new StreamWriter( ( string ) e.Argument ) )

            }

        }

        public string GetSafeFilename ( string filename ) {
            return string.Join( "_", filename.Split( Path.GetInvalidFileNameChars() ) );

        }


    }


}

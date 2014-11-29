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

    public struct ExportData {
        public static int Counter = 0;
        public int Index;
        public DateTime Date;
        public List<int> Location;
        public List<byte> PreviousByte;
        public List<byte> CurrentByte;

    }

    public partial class SnapShotTimeLine_Form : Form {
        private List<SaveGameSnapShot> saveGames;
        private List<ExportData> saveGameChanges;
        private int index;
        BackgroundWorker bw;

        public SnapShotTimeLine_Form ( List<SaveGameSnapShot> saveGames ) {
            InitializeComponent();

            bw = new BackgroundWorker();
            bw.DoWork += bw_DoWork;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;

            this.Icon = Form1.appIcon;
            this.index = 1;
            this.saveGames = saveGames;

        }

        public SnapShotTimeLine_Form () {
            InitializeComponent();

            /*
            MenuButton mb = new MenuButton();
            mb.Location = new System.Drawing.Point( 165, 316 );
            mb.Size = new System.Drawing.Size( 75, 23 );
            mb.Name = "btnExportMenu";
            mb.Text = "Export";
            this.toolTip1.SetToolTip( mb, "Wait until the data is processed" );
            mb.UseVisualStyleBackColor = true;
            mb.Enabled = true;
            mb.Anchor = ( ( System.Windows.Forms.AnchorStyles ) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );

            ContextMenu menu = new ContextMenu();

            //ToolStripMenuItem exportToBinaryFileToolStripMenuItem = new ToolStripMenuItem();
            //exportToBinaryFileToolStripMenuItem.Name = "exportToBinaryFileToolStripMenuItem";
            //exportToBinaryFileToolStripMenuItem.Size = new System.Drawing.Size( 207, 22 );
            //exportToBinaryFileToolStripMenuItem.Text = "To File";
            //exportToBinaryFileToolStripMenuItem.Click += new System.EventHandler( this.exportToBinaryFileToolStripMenuItem_Click );

            //ToolStripMenuItem exportToTextFileToolStripMenuItem = new ToolStripMenuItem();
            //exportToBinaryFileToolStripMenuItem.Name = "exportToTextFileToolStripMenuItem";
            //exportToBinaryFileToolStripMenuItem.Size = new System.Drawing.Size( 207, 22 );
            //exportToBinaryFileToolStripMenuItem.Text = "To Text File";
            //exportToBinaryFileToolStripMenuItem.Click += new System.EventHandler( this.exportToTextFileToolStripMenuItem_Click );


            menu.MenuItems.Add( "To File", new System.EventHandler( this.exportToBinaryFileToolStripMenuItem_Click ) );
            menu.MenuItems.Add( "To Text File", new System.EventHandler( this.exportToTextFileToolStripMenuItem_Click ) );

            mb.ContextMenu = menu;

            this.Controls.Add( mb );
             * */

            //menu.Show( mb, new Point( 165, 340 ) );

            this.Icon = Form1.appIcon;
        }

        void bw_DoWork ( object sender, DoWorkEventArgs e ) {
            ExportData ed;
            ed.CurrentByte = new List<byte>();
            ed.PreviousByte = new List<byte>();
            ed.Location = new List<int>();

            for ( int i = 0; i < saveGames.First().SnapShot.Length; i++ ) {
                if ( saveGames[index - 1].SnapShot[i] != saveGames[index].SnapShot[i] ) {
                    ed = new ExportData();
                    ed.Index = saveGames[index].Index;
                    ed.PreviousByte.Add( saveGames[index - 1].SnapShot[i] );
                    ed.CurrentByte.Add( saveGames[index].SnapShot[i] );
                    ed.Location.Add( i );

                    listView.Items.Add(
                        new ListViewItem(
                            new string[] {
                                i.ToString("X4"),
                                saveGames[index - 1].SnapShot[i].ToString("X2"),
                                saveGames[index].SnapShot[i].ToString("X2"),
                                                                
                            }
                        )
                    );

                    saveGameChanges.Add( ed );

                }
            }
        }

        void bw_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e ) {
            //SetControlPropertyThreadSafe( exportToolStripMenuItem, "Enable", true );
            //SetControlPropertyThreadSafe( toolTip1, "Active", false );
            toolTip1.Active = false;
            exportToolStripMenuItem.Enabled = true;

        }

        private void SnapShotTimeLine_Form_Load ( object sender, EventArgs e ) {
            if ( saveGames == null ) {
                return;
            }

            columnHeaderLast.Text = "Value on " + saveGames[0].Date.ToString();
            columnHeaderCurrent.Text = "Value on " + saveGames[1].Date.ToString();
            saveGameChanges = new List<ExportData>();

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
                    MessageBox.Show( ioex.Message, "Error While Writing" );

                }

            }

            if ( saveGames == null ) {
                return;
            }

            columnHeaderLast.Text = "Value on " + saveGames[0].Date.ToString();
            columnHeaderCurrent.Text = "Value on " + saveGames[1].Date.ToString();
            saveGameChanges = new List<ExportData>();

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
            sfd.FileName = "tboir_" + GetSafeFilename( DateTime.Now.ToString() );

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
            sfd.FileName = "TBoIR_" + DateTime.Now.ToString() + ".log";

            if ( sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                using ( StreamWriter sw = new StreamWriter( sfd.FileName ) ) {
                    foreach ( var item in saveGameChanges ) {
                        sw.WriteLine( item.Index.ToString( "D6" ) + "\t" + item.Date.ToString() );

                        for ( int i = 0; i < item.CurrentByte.Count; i++ ) {
                            sw.WriteLine(
                                item.Location.ElementAt( i ).ToString( "X4" ) + "\t"
                                + item.PreviousByte.ElementAt( i ).ToString( "D3" ) + "\t"
                                + item.CurrentByte.ElementAt( i ).ToString( "D3" )
                            );

                        }

                        sw.Write( Environment.NewLine );

                    }

                }
            }

        }

        public string GetSafeFilename ( string filename ) {
            return string.Join( "_", filename.Split( Path.GetInvalidFileNameChars() ) );

        }


    }


}

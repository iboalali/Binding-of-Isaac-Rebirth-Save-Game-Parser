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

namespace BindingOfIsaacRebirthSaveGameParser {

    [Serializable]
    public struct SaveGameSnapShot {
        public int Index { get; set; }
        public byte[] SnapShot { get; set; }
        public DateTime Date { get; set; }
        public static int Counter { get; set; }

    }

    public partial class ShowChanges_RealTime : Form {
        private FileSystemWatcher watcher;
        private List<SaveGameSnapShot> SaveGame_OverTime;
        private string FileName { get; set; }
        private string Path { get; set; }
        private BinaryReader br;
        private bool recordingStarted;
        private byte[] firstSnapShot;
        private bool didSomethingChange;

        public ShowChanges_RealTime ( string path, string fileName ) {
            InitializeComponent();

            this.Icon = Form1.appIcon;

            this.Path = path;
            this.FileName = fileName;
            this.SaveGame_OverTime = new List<SaveGameSnapShot>();
            this.didSomethingChange = false;

            SaveGameSnapShot.Counter = 0;
            recordingStarted = false;

            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = fileName;
            watcher.Path = path;
            watcher.Changed += watcher_Changed;


        }

        void watcher_Changed ( object sender, FileSystemEventArgs e ) {
            byte[] snapshot;

            while ( true ) {
                try {
                    LoadFile( Path + '\\' + FileName, out snapshot );
                    SaveGameSnapShot sgss = new SaveGameSnapShot();
                    sgss.Date = DateTime.Now;
                    sgss.Index = SaveGameSnapShot.Counter++;
                    sgss.SnapShot = snapshot;
                    SaveGame_OverTime.Add( sgss );

                    SetControlPropertyThreadSafe( lblCounter, "Text", SaveGameSnapShot.Counter.ToString() );

                    ShowChanges();
                    break;
                    // Delete from the begining if it gets too large
                    //if ( SaveGame_OverTime.Count >= 50000 ) {
                    //    
                    //}

                } catch ( IOException ) {
                    continue;

                }
            }
        }

        private void btnStart_Click ( object sender, EventArgs e ) {
            LoadFile( Path + '\\' + FileName, out firstSnapShot );

            SaveGameSnapShot sgss = new SaveGameSnapShot();
            sgss.Date = DateTime.Now;
            sgss.Index = SaveGameSnapShot.Counter++;
            sgss.SnapShot = firstSnapShot;
            SaveGame_OverTime.Add( sgss );

            lblCounter.Text = SaveGameSnapShot.Counter.ToString();
            lblSnapShot1.Text = DateTime.Now.ToString();

            watcher.EnableRaisingEvents = true;
            recordingStarted = true;
        }

        private void btnStop_Click ( object sender, EventArgs e ) {
            watcher.EnableRaisingEvents = false;

            if ( recordingStarted ) {
                recordingStarted = false;

                if ( SaveGame_OverTime.Count < 2 ) {
                    MessageBox.Show( "You need more than two snapshots.", "Too Few Snapshots" );
                    return;

                }
                new SnapShotTimeLine_Form( SaveGame_OverTime ).Show();

            }
        }

        private void LoadFile ( string path, out byte[] buffer ) {
            using ( br = new BinaryReader( File.Open( path, FileMode.Open ) ) ) {
                buffer = new byte[br.BaseStream.Length];
                int r = br.Read( buffer, 0, buffer.Length );

            }

        }

        private void ShowChanges () {
            if ( firstSnapShot == null || SaveGame_OverTime.Count < 1 ) {
                return;

            }

            StringBuilder result = new StringBuilder();
            if ( SaveGame_OverTime.Count == 1 ) {
                for ( int i = 0; i < firstSnapShot.Length; i++ ) {
                    SetControlPropertyThreadSafe( lblSnapShot1, "Text", SaveGame_OverTime.Last().Date.ToString() );

                    if ( firstSnapShot[i] != SaveGame_OverTime.Last().SnapShot[i] ) {
                        result.Append( i.ToString( "X4" ) + "\t\t" + SaveGame_OverTime.Last().SnapShot[i].ToString() );
                        result.Append( "\t\t" );
                        if ( StatLocation.ContainsLocation( i ) ) {
                            result.Append( StatLocation.GetLocation_Name( i ) );
                            i += StatLocation.GetNumberOfByteMinusOne( i );

                        }
                        result.Append( Environment.NewLine );
                        didSomethingChange = true;

                    }
                }



            } else {
                for ( int i = 0; i < firstSnapShot.Length; i++ ) {
                    SetControlPropertyThreadSafe( lblSnapShot1, "Text", SaveGame_OverTime.Last().Date.ToString() );

                    if ( SaveGame_OverTime[SaveGame_OverTime.Count - 2].SnapShot[i] != SaveGame_OverTime.Last().SnapShot[i] ) {
                        result.Append( i.ToString( "X4" ) + "\t\t" + StatLocation.GetValue( SaveGame_OverTime.Last().SnapShot, i ) );
                        result.Append( "\t\t" );
                        if ( StatLocation.ContainsLocation( i ) ) {
                            result.Append( StatLocation.GetLocation_Name( i ) );
                            i += StatLocation.GetNumberOfByteMinusOne( i );

                        }
                        result.Append( Environment.NewLine );
                        didSomethingChange = true;

                    }
                }



            }

            if ( !didSomethingChange ) {
                SaveGame_OverTime.RemoveAt( SaveGame_OverTime.Count - 1 );
                SaveGameSnapShot.Counter--;
                SetControlPropertyThreadSafe( lblCounter, "Text", SaveGameSnapShot.Counter.ToString() );

            } else {
                SetControlPropertyThreadSafe( rtbChanges, "Text", result.ToString() );

            }
            didSomethingChange = false;

        }

        private void btnLocationToTrack_Click ( object sender, EventArgs e ) {
            new SnapShotTimeLine_Form().Show();

        }

        private delegate void SetControlPropertyThreadSafeDelegate ( Control control, string propertyName, object propertyValue );

        public static void SetControlPropertyThreadSafe ( Control control, string propertyName, object propertyValue ) {
            if ( control.InvokeRequired ) {
                control.Invoke( new SetControlPropertyThreadSafeDelegate( SetControlPropertyThreadSafe ), new object[] { control, propertyName, propertyValue } );
            } else {
                control.GetType().InvokeMember( propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue } );
            }
        }

        private void ShowChanges_RealTime_FormClosing ( object sender, FormClosingEventArgs e ) {
            watcher.EnableRaisingEvents = false;

        }



    }
}

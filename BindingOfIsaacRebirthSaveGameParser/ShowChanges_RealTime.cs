using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingOfIsaacRebirthSaveGameParser {

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


        public ShowChanges_RealTime ( string path, string fileName ) {
            InitializeComponent();

            this.Path = path;
            this.FileName = fileName;
            this.SaveGame_OverTime = new List<SaveGameSnapShot>();
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

            watcher.EnableRaisingEvents = true;
            recordingStarted = true;
        }

        private void btnStop_Click ( object sender, EventArgs e ) {
            watcher.EnableRaisingEvents = false;

            if ( recordingStarted ) {
                recordingStarted = false;
                new SnapShotTimeLine_Form( SaveGame_OverTime ).Show();

            }
        }

        private void LoadFile ( string path, out byte[] buffer ) {
            using ( br = new BinaryReader( File.Open( path, FileMode.Open ) ) ) {
                buffer = new byte[br.BaseStream.Length];
                int r = br.Read( buffer, 0, buffer.Length );

            }

        }

        private void ShowChanges ( SaveGameSnapShot sgss ) {
            if ( firstSnapShot == null || SaveGame_OverTime.Count < 1 ) {
                return;

            }

            StringBuilder result = new StringBuilder();
            if ( SaveGame_OverTime.Count == 1 ) {
                for ( int i = 0; i < firstSnapShot.Length; i++ ) {
                    lblSnapShot1.Text = SaveGame_OverTime.Last().Date.ToString();
                    lblCounter.Text = SaveGame_OverTime.Last().Index.ToString();

                    if ( firstSnapShot[i] != SaveGame_OverTime.Last().SnapShot[i] ) {
                        //result.Append( i.ToString( "X4" ) + "\t\t" + SaveGame_OverTime.Last().SnapShot[i].ToString() );



                    }
                }



            } else {




            }




        }

        private void btnLocationToTrack_Click ( object sender, EventArgs e ) {

        }





    }
}

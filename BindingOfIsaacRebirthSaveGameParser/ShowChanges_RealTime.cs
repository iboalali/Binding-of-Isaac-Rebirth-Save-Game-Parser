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
    public partial class ShowChanges_RealTime : Form {
        private FileSystemWatcher watcher;
        private List<byte[]> SaveGame_OverTime;
        private string FileName { get; set; }
        private string Path { get; set; }
        private BinaryReader br;


        public ShowChanges_RealTime ( string path, string fileName ) {
            InitializeComponent();

            this.Path = path;
            this.FileName = fileName;
            this.SaveGame_OverTime = new List<byte[]>();

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
                    

                } catch ( IOException ) {
                    continue;

                }
            }
        }

        private void btnStart_Click ( object sender, EventArgs e ) {
            byte[] firstSnapShot;
            LoadFile( Path + '\\' + FileName, out firstSnapShot );
            SaveGame_OverTime.Add( firstSnapShot );
            watcher.EnableRaisingEvents = true;

        }

        private void btnStop_Click ( object sender, EventArgs e ) {
            watcher.EnableRaisingEvents = false;

        }

        private void LoadFile ( string path, out byte[] buffer ) {
            using ( br = new BinaryReader( File.Open( path, FileMode.Open ) ) ) {
                buffer = new byte[br.BaseStream.Length];
                int r = br.Read( buffer, 0, buffer.Length );

            }

        }

        private void ShowChanges () {



        }





    }
}

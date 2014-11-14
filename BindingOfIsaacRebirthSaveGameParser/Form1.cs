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
    public partial class Form1 : Form {

        private byte[] buffer;
        private BinaryReader br;
        /// <summary>
        /// The "My Documnet" folder path
        /// </summary>
        private string MyDocument_Path = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );

        /// <summary>
        /// The path inside the "My Document" Folder
        /// </summary>
        private string SaveGameFile_Path = @"My Games\Binding of Isaac Rebirth";

        /// <summary>
        /// Default file name for the first save game file
        /// </summary>
        private string CurrentFileName = "persistentgamedata1.dat";
        private string SaveGame_FileName1 = "persistentgamedata1.dat";
        private string SaveGame_FileName2 = "persistentgamedata2.dat";
        private string SaveGame_FileName3 = "persistentgamedata3.dat";
        private string C_Path = string.Empty;

        private FileSystemWatcher watcher;

        public Form1 () {
            InitializeComponent();

            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = CurrentFileName;
            watcher.Path = Path.Combine( MyDocument_Path, SaveGameFile_Path );
            watcher.Changed += watcher_Changed;

        }

        void watcher_Changed ( object sender, FileSystemEventArgs e ) {
            while ( true ) {
                try {
                    LoadBinaryFile( Path.Combine( MyDocument_Path, SaveGameFile_Path ) + '\\' + CurrentFileName, out this.buffer );
                    ParseFile_ThreadSafe();
                    break;

                } catch ( IOException ) {
                    continue;

                }
            }
        }

        private void Form1_Load ( object sender, EventArgs e ) {

            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + CurrentFileName;
            Bitmap bIcon = Bitmap.FromHicon( global::BindingOfIsaacRebirthSaveGameParser.Properties.Resources.isaac_ng_101.Handle );
            Color c;
            for ( int i = 0; i < bIcon.Width; i++ ) {
                for ( int j = 0; j < bIcon.Height; j++ ) {
                    c = bIcon.GetPixel( i, j );
                    bIcon.SetPixel( i, j,
                        Color.FromArgb(
                            c.A,
                            ( int ) ( c.R * 0.8 ),
                            ( int ) ( c.G * 0.8 ),
                            ( int ) ( c.B * 0.8 )

                        )
                    );
                }
            }

            this.Icon = Icon.FromHandle( bIcon.GetHicon() );



            LoadBinaryFile( completePath, out this.buffer );
            ParseFile();
            watcher.EnableRaisingEvents = true;

        }

        private void btnExit_Click ( object sender, EventArgs e ) {
            Environment.Exit( Environment.ExitCode );
        }

        private void btnShowFile_Click ( object sender, EventArgs e ) {
            new SaveFileHex( this.buffer ).Show();
        }

        private void btnShowChanges_Click ( object sender, EventArgs e ) {
            new ShowChangesInSaveGame().Show();
        }

        private void btnOpenSaveGame_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();

            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {

                LoadBinaryFile( ofd.FileName, out this.buffer );
                CurrentFileName = ofd.SafeFileName;
                C_Path = ofd.FileName.Substring( 0, ofd.FileName.LastIndexOf( '\\' ) );

                watcher.EnableRaisingEvents = false;
                watcher.Filter = ofd.SafeFileName;
                watcher.Path = C_Path;
                watcher.EnableRaisingEvents = true;

                ParseFile();
            }
        }

        /// <summary>
        /// Loads the file as binary into a byte array
        /// </summary>
        /// <param name="path">Path to the file</param>
        /// <param name="buffer">The byte array to fill</param>
        private void LoadBinaryFile ( string path, out byte[] buffer ) {
            using ( br = new BinaryReader( File.Open( path, FileMode.Open ) ) ) {
                //SaveGameLength = br.BaseStream.Length;
                buffer = new byte[br.BaseStream.Length];
                int r = br.Read( buffer, 0, buffer.Length );

            }

        }

        /// <summary>
        /// Extract using the known location of the information
        /// </summary>
        private void ParseFile () {
            if ( this.buffer == null ) {
                return;
            }

            listView.Items.Clear();

            foreach ( var item in StatLocation.locations ) {
                listView.Items.Add(
                    new ListViewItem(
                        new string[]{
                            item.Name,
                            StatLocation.GetValueFromSaveGame( this.buffer, item.From, item.To ).ToString()
                        }
                    )
               );

            }

        }

        /// <summary>
        /// Extract using the known location of the information
        /// </summary>
        private void ParseFile_ThreadSafe () {
            if ( this.buffer == null ) {
                return;
            }

            List<string[]> lvi = new List<string[]>();
            ClearValuesFromListViewThreadSafe( listView );

            foreach ( var item in StatLocation.locations ) {
                lvi.Add(
                    new string[]{
                        item.Name,
                        StatLocation.GetValueFromSaveGame( this.buffer, item.From, item.To ).ToString()
                    }
                );

            }

            SetValuesForListViewThreadSafe( listView, lvi );

        }

        private void btnShowChangesRealTime_Click ( object sender, EventArgs e ) {
            if ( C_Path == string.Empty ) {
                new ShowChanges_RealTime( Path.Combine( MyDocument_Path, SaveGameFile_Path ), CurrentFileName ).Show();
            } else {
                new ShowChanges_RealTime( C_Path, CurrentFileName ).Show();

            }
        }

        private void saveGame1ToolStripMenuItem_Click ( object sender, EventArgs e ) {
            CurrentFileName = SaveGame_FileName1;
            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + CurrentFileName;
            LoadBinaryFile( completePath, out this.buffer );

            watcher.EnableRaisingEvents = false;
            watcher.Filter = CurrentFileName;
            watcher.EnableRaisingEvents = true;

            ParseFile();

        }

        private void saveGame2ToolStripMenuItem_Click ( object sender, EventArgs e ) {
            CurrentFileName = SaveGame_FileName2;
            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + CurrentFileName;
            LoadBinaryFile( completePath, out this.buffer );

            watcher.EnableRaisingEvents = false;
            watcher.Filter = CurrentFileName;
            watcher.EnableRaisingEvents = true;

            ParseFile();

        }

        private void saveGame3ToolStripMenuItem_Click ( object sender, EventArgs e ) {
            CurrentFileName = SaveGame_FileName3;
            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + CurrentFileName;
            LoadBinaryFile( completePath, out this.buffer );

            watcher.EnableRaisingEvents = false;
            watcher.Filter = CurrentFileName;
            watcher.EnableRaisingEvents = true;

            ParseFile();

        }

        private void aboutToolStripMenuItem_Click ( object sender, EventArgs e ) {
            new About_Form().Show();

        }

        private void exitToolStripMenuItem_Click ( object sender, EventArgs e ) {
            Environment.Exit( Environment.ExitCode );

        }

        private delegate void SetControlPropertyThreadSafeDelegate ( Control control, string propertyName, object propertyValue );

        public static void SetControlPropertyThreadSafe ( Control control, string propertyName, object propertyValue ) {
            if ( control.InvokeRequired ) {
                control.Invoke( new SetControlPropertyThreadSafeDelegate( SetControlPropertyThreadSafe ), new object[] { control, propertyName, propertyValue } );
            } else {
                control.GetType().InvokeMember( propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue } );
            }
        }

        private delegate void SetValuesForListViewThreadSafeDelegate ( ListView control, List<string[]> values );

        public static void SetValuesForListViewThreadSafe ( ListView control, List<string[]> values ) {
            if ( control.InvokeRequired ) {
                control.Invoke( new SetValuesForListViewThreadSafeDelegate( SetValuesForListViewThreadSafe ), new object[] { control, values } );

            } else {
                foreach ( var item in values ) {
                    control.Items.Add(
                        new ListViewItem(
                            item
                        )
                    );

                }

            }
        }

        private delegate void ClearValuesFromListViewThreadSafeDelegate ( ListView control );

        public static void ClearValuesFromListViewThreadSafe ( ListView control ) {
            if ( control.InvokeRequired ) {
                control.Invoke( new ClearValuesFromListViewThreadSafeDelegate( ClearValuesFromListViewThreadSafe ), new object[] { control } );

            } else {
                control.Items.Clear();
            }
        }

        private void Form1_FormClosing ( object sender, FormClosingEventArgs e ) {
            watcher.EnableRaisingEvents = false;

        }


    }
}

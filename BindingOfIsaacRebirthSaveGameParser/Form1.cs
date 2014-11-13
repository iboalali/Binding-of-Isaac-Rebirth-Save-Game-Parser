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
        //public static long SaveGameLength;
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
        private string File_Name = "persistentgamedata1.dat";
        private string SaveGame_FileName1 = "persistentgamedata1.dat";
        private string SaveGame_FileName2 = "persistentgamedata2.dat";
        private string SaveGame_FileName3 = "persistentgamedata3.dat";
        private string C_Path = string.Empty;

        /// <summary>
        /// Known location of the statistics
        /// Key: Name, Value: Location (in decimel)
        /// </summary>
        public static Dictionary<string, int> info_Location
            = new Dictionary<string, int>() 
                        { 
                            { "Deaths", 259 }, 
                            { "Rocks", 231 },
                            { "Poop", 239 },
                            // ...
                        };

        /// <summary>
        /// Known location of the statistics
        /// Key: Location (in decimel), Value: Name
        /// </summary>
        public static Dictionary<int, string> info_Location_R
            = new Dictionary<int, string>() 
                        { 
                            { 259, "Deaths" },
                            { 231, "Rocks" },
                            { 239, "Poop" },
                            // ...
                        };

        private FileSystemWatcher watcher;


        public Form1 () {
            InitializeComponent();
            watcher = new FileSystemWatcher();
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = File_Name;
            watcher.Path = Path.Combine( MyDocument_Path, SaveGameFile_Path );
            watcher.Changed += watcher_Changed;

        }

        void watcher_Changed ( object sender, FileSystemEventArgs e ) {
            while ( true ) {
                try {
                    LoadBinaryFile( Path.Combine( MyDocument_Path, SaveGameFile_Path ) + '\\' + File_Name, out this.buffer );
                    ParseFile_ThreadSafe();
                    break;

                } catch ( IOException ) {
                    continue;

                }
            }
        }

        private void Form1_Load ( object sender, EventArgs e ) {

            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + File_Name;
            this.Icon = global::BindingOfIsaacRebirthSaveGameParser.Properties.Resources.isaac_ng_101;

            LoadBinaryFile( completePath, out this.buffer );
            ParseFile();

        }

        private void btnExit_Click ( object sender, EventArgs e ) {
            Environment.Exit( Environment.ExitCode );
        }

        private void btnShowFile_Click ( object sender, EventArgs e ) {
            new SaveFileHex( this.buffer ).Show();
        }

        private void btnShowChanges_Click ( object sender, EventArgs e ) {
            new ShowChangesInSaveGame( info_Location_R ).Show();
        }

        private void btnOpenSaveGame_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();

            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {

                LoadBinaryFile( ofd.FileName, out this.buffer );
                File_Name = ofd.SafeFileName;
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

            foreach ( var item in info_Location_R ) {
                listView.Items.Add(
                    new ListViewItem(
                        new string[]{
                            item.Value,
                            this.buffer[item.Key].ToString()
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

            foreach ( var item in info_Location_R ) {
                lvi.Add(
                    new string[]{
                        item.Value,
                        this.buffer[item.Key].ToString()
                    }
                );

            }

            SetValuesForListViewThreadSafe( listView, lvi );

        }

        private void btnShowChangesRealTime_Click ( object sender, EventArgs e ) {
            if ( C_Path == string.Empty ) {
                new ShowChanges_RealTime( Path.Combine( MyDocument_Path, SaveGameFile_Path ), File_Name ).Show();
            } else {
                new ShowChanges_RealTime( C_Path, File_Name ).Show();

            }
        }

        private void saveGame1ToolStripMenuItem_Click ( object sender, EventArgs e ) {
            File_Name = SaveGame_FileName1;
            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + File_Name;
            LoadBinaryFile( completePath, out this.buffer );

            watcher.EnableRaisingEvents = false;
            watcher.Filter = File_Name;
            watcher.EnableRaisingEvents = true;

            ParseFile();

        }

        private void saveGame2ToolStripMenuItem_Click ( object sender, EventArgs e ) {
            File_Name = SaveGame_FileName2;
            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + File_Name;
            LoadBinaryFile( completePath, out this.buffer );

            watcher.EnableRaisingEvents = false;
            watcher.Filter = File_Name;
            watcher.EnableRaisingEvents = true;

            ParseFile();

        }

        private void saveGame3ToolStripMenuItem_Click ( object sender, EventArgs e ) {
            File_Name = SaveGame_FileName3;
            string completePath = Path.Combine( MyDocument_Path, SaveGameFile_Path ) + "\\" + File_Name;
            LoadBinaryFile( completePath, out this.buffer );

            watcher.EnableRaisingEvents = false;
            watcher.Filter = File_Name;
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


    }
}

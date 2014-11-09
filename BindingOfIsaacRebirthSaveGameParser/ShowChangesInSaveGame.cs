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
    public partial class ShowChangesInSaveGame : Form {
        byte[] old_File_Buffer;
        byte[] new_File_Buffer;

        public BinaryReader br;


        Dictionary<int, string> info_Location_R;
        public ShowChangesInSaveGame ( Dictionary<int, string> info_Location_R ) {
            InitializeComponent();
            this.info_Location_R = info_Location_R;

        }

        private void btnLoadOldFile_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();

            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                LoadFile( ofd.FileName, out old_File_Buffer );
                btnLoadOldFile.Text = "Load Old File" + Environment.NewLine + ofd.SafeFileName;
                ShowChanges();
            }

        }

        private void btnLoadNewFile_Click ( object sender, EventArgs e ) {
            OpenFileDialog ofd = new OpenFileDialog();

            if ( ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
                LoadFile( ofd.FileName, out new_File_Buffer );
                btnLoadNewFile.Text = "Load New File" + Environment.NewLine + ofd.SafeFileName;
                ShowChanges();
            }
        }

        private void ShowChanges () {
            if ( old_File_Buffer == null || new_File_Buffer == null ) {
                return;
            }

            int d = 0;

            StringBuilder result = new StringBuilder();
            result.Append( "Loc  Old File    New File    Difference (DEC)   is Known?" + Environment.NewLine );

            for ( int i = 0; i < old_File_Buffer.Length; i++ ) {
                if ( old_File_Buffer[i] != new_File_Buffer[i] ) {

                    d = new_File_Buffer[i] - old_File_Buffer[i];

                    result.Append( i.ToString( "X4" ) );
                    result.Append( " " );
                    result.Append( old_File_Buffer[i].ToString( "X2" ) );
                    result.Append( "       -> " );
                    result.Append( new_File_Buffer[i].ToString( "X2" ) );

                    if ( d < 0 ) {
                        result.Append( "          " );

                    } else {
                        result.Append( "           " );

                    }

                    result.Append( d.ToString( "D8" ) );
                    result.Append( "           " );

                    if ( info_Location_R.ContainsKey( i ) ) {
                        result.Append( "Yes (" + info_Location_R[i] + ")" );

                    } else {
                        result.Append( "No" );

                    }

                    result.Append( Environment.NewLine );
                }
            }

            richTextBox1.Text = result.ToString();

        }

        private void LoadFile ( string path, out byte[] buffer ) {
            using ( br = new BinaryReader( File.Open( path, FileMode.Open ) ) ) {
                buffer = new byte[br.BaseStream.Length];
                int r = br.Read( buffer, 0, buffer.Length );

            }

        }

        private void button_DragEnter ( object sender, DragEventArgs e ) {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void btnLoadOldFile_DragDrop ( object sender, DragEventArgs e ) {
            string[] s = ( string[] ) e.Data.GetData( DataFormats.FileDrop, false );

            try {
                LoadFile( s.First(), out old_File_Buffer );
                ShowChanges();
                btnLoadOldFile.Text = "Load Old File" + Environment.NewLine + GetSafeFileName( s.First() );


            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "Error" );
            }
        }

        private void btnLoadNewFile_DragDrop ( object sender, DragEventArgs e ) {
            string[] s = ( string[] ) e.Data.GetData( DataFormats.FileDrop, false );

            try {
                LoadFile( s.First(), out new_File_Buffer );
                ShowChanges();
                btnLoadNewFile.Text = "Load New File" + Environment.NewLine + GetSafeFileName( s.First() );


            } catch ( Exception ex ) {
                MessageBox.Show( ex.Message, "Error" );
            }
        }

        private string GetSafeFileName ( string FileName ) {
            string[] s = FileName.Split( new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries );
            return s.Last();

        }



    }
}

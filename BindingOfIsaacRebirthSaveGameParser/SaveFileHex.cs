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

    public partial class SaveFileHex : Form {

        byte[] buffer;
        string[] binaryBuffer;
        string completeBinary;

        public SaveFileHex ( byte[] buffer ) {
            InitializeComponent();
            this.buffer = new byte[buffer.Length];
            this.binaryBuffer = new string[buffer.Length];
            this.completeBinary = string.Empty;

            buffer.CopyTo( this.buffer, 0 );

            //this.rtbHex.Text = ByteToHex( this.buffer );

            switch ( SettingManager.ReadOption( "CurrentHexEditorView" ) ) {
                case "Hex":
                    btnHex_Click( null, null );
                    break;
                case "Dec":
                    btnDec_Click( null, null );
                    break;
                case "Bin":
                    btnBin_Click( null, null );
                    break;

                default:
                    break;
            }


        }

        private void btnHex_Click ( object sender, EventArgs e ) {
            this.rtbHex.Text = ByteToHex( this.buffer );
            this.MinimumSize = new Size( 440, 543 );
            this.Size = new Size( 440, 543 );
            this.rtbHex.Font = new System.Drawing.Font( "Courier New", 9.25F );
            this.txtOffsetHeader.Font = new System.Drawing.Font( "Courier New", 9.25F );
            this.btnBeyondTheByteSearch.Enabled = false;
            SettingManager.WriteOption( "CurrentHexEditorView", "Hex" );

        }

        private void btnDec_Click ( object sender, EventArgs e ) {
            this.rtbHex.Text = ByteToDec( this.buffer );
            this.MinimumSize = new Size( 550, 543 );
            this.Size = new Size( 550, 543 );
            this.rtbHex.Font = new System.Drawing.Font( "Courier New", 9.25F );
            this.txtOffsetHeader.Font = new System.Drawing.Font( "Courier New", 9.25F );
            this.btnBeyondTheByteSearch.Enabled = false;
            SettingManager.WriteOption( "CurrentHexEditorView", "Dec" );

        }

        private void btnBin_Click ( object sender, EventArgs e ) {
            this.rtbHex.Text = ByteToBin( this.buffer );
            this.MinimumSize = new Size( 1110, 543 );
            this.Size = new Size( 1110, 543 );
            this.txtOffsetHeader.Font = new System.Drawing.Font( "Courier New", 8.25F );
            this.rtbHex.Font = new System.Drawing.Font( "Courier New", 8.25F );
            this.btnBeyondTheByteSearch.Enabled = true;
            SettingManager.WriteOption( "CurrentHexEditorView", "Bin" );

        }

        private string ByteToHex ( byte[] buffer ) {
            StringBuilder result = new StringBuilder();

            this.txtOffsetHeader.Text = "     00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F";
            result.Append( "0000 " );

            for ( int i = 0; i < buffer.Length; i++ ) {
                result.Append( buffer[i].ToString( "X2" ) );
                result.Append( " " );

                if ( ( ( i + 1 ) % 16 ) == 0 ) {
                    result.Append( Environment.NewLine );
                    result.Append( ( ( i / 16 ) + 1 ).ToString( "X3" ).PadRight( 4, '0' ) + " " );
                }
            }


            return result.ToString();

        }

        private string ByteToDec ( byte[] buffer ) {
            StringBuilder result = new StringBuilder();

            this.txtOffsetHeader.Text = "     00  01  02  03  04  05  06  07  08  09  0A  0B  0C  0D  0E  0F";
            result.Append( "0000 " );

            for ( int i = 0; i < buffer.Length; i++ ) {
                result.Append( buffer[i].ToString( "D3" ) );
                result.Append( " " );

                if ( ( ( i + 1 ) % 16 ) == 0 ) {
                    result.Append( Environment.NewLine );
                    result.Append( ( ( i / 16 ) + 1 ).ToString( "X3" ).PadRight( 4, '0' ) + " " );
                }
            }



            return result.ToString();

        }

        private string ByteToBin ( byte[] buffer ) {
            StringBuilder result = new StringBuilder();
            this.txtOffsetHeader.Text = "        00       01       02       03       04       05       "
                + "06       07       08       09       0A       0B       0C       0D       0E       0F";

            result.Append( "0000 " );
            string bin = string.Empty;

            for ( int i = 0; i < buffer.Length; i++ ) {
                bin = Convert.ToString( buffer[i], 2 );
                bin = bin.PadLeft( 8, '0' );
                binaryBuffer[i] = bin;

                result.Append( bin );
                result.Append( " " );

                if ( ( ( i + 1 ) % 16 ) == 0 ) {
                    result.Append( Environment.NewLine );
                    result.Append( ( ( i / 16 ) + 1 ).ToString( "X3" ).PadRight( 4, '0' ) + " " );
                }
            }

            foreach ( string item in binaryBuffer ) {
                completeBinary += item;
            }


            return result.ToString();
        }

        private void btnSearch_Click ( object sender, EventArgs e ) {
            if ( txtSearchWord.Text == string.Empty ) {
                return;
            }

            rtbHex.SelectAll();
            rtbHex.SelectionColor = Color.Black;
            rtbHex.DeselectAll();

            HighlightText( rtbHex, txtSearchWord.Text, Color.Red );

        }

        private void HighlightText ( RichTextBox myRtb, string word, Color color ) {
            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            while ( ( index = myRtb.Text.IndexOf( word, startIndex ) ) != -1 ) {
                myRtb.Select( index, word.Length );
                myRtb.SelectionColor = color;

                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = Color.Black;
        }

        private void btnResetSearch_Click ( object sender, EventArgs e ) {
            rtbHex.SelectAll();
            rtbHex.SelectionColor = Color.Black;
            rtbHex.DeselectAll();
        }

        private void btnBeyondTheByteSearch_Click ( object sender, EventArgs e ) {

            if ( txtSearchWord.Text == string.Empty ) {
                return;
            }

            rtbHex.SelectAll();
            rtbHex.SelectionColor = Color.Black;
            rtbHex.DeselectAll();

            int[] indecies = indexOfAnyBits( completeBinary, txtSearchWord.Text );

            //new Indecies_Form( indecies ).Show();

            SelectBitsInRtb( indecies );

        }

        private void SelectBitsInRtb ( int[] indecies ) {
            int s_start = rtbHex.SelectionStart;

            for ( int i = 0; i < indecies.Length; i++ ) {
                if ( ( ( indecies[i] % 8 ) + txtSearchWord.Text.Length ) >= 8 ) {
                    if ( ( indecies[i] % ( 8 * 16 ) ) + txtSearchWord.Text.Length >= ( 8 * 16 ) ) {
                        int rem = ( ( 8 * 16 ) * ( ( indecies[i] / ( 8 * 16 ) ) + 1 ) ) - indecies[i];
                        rtbHex.Select( GetLocationInRtb( indecies[i] / 8, indecies[i] % 8 ), rem );
                        rtbHex.SelectionColor = Color.Red;

                        rtbHex.Select( GetLocationInRtb( ( indecies[i] + rem ) / 8, ( indecies[i] + rem ) % 8 ), txtSearchWord.Text.Length - rem );
                        rtbHex.SelectionColor = Color.Red;
                    } else {
                        rtbHex.Select( GetLocationInRtb( indecies[i] / 8, indecies[i] % 8 ), txtSearchWord.Text.Length + 1 );

                    }


                } else {
                    rtbHex.Select( GetLocationInRtb( indecies[i] / 8, indecies[i] % 8 ), txtSearchWord.Text.Length );

                }

                rtbHex.SelectionColor = Color.Red;



            }
            rtbHex.SelectionStart = s_start;
            rtbHex.SelectionLength = 0;
            rtbHex.SelectionColor = Color.Black;

        }

        /// <summary>
        /// Get the location in a RichTextBox
        /// </summary>
        /// <param name="i">Byte Number</param>
        /// <param name="j">Bit Number in the Byte</param>
        /// <returns></returns>
        private int GetLocationInRtb ( int i, int j ) {
            //                Location              Bytes    Bits      New Line
            return ( 5 * ( ( i / 16 ) + 1 ) ) + ( i * 9 ) + j + ( ( i / 16 ) );

        }

        public static int[] indexOfAnyBits ( string completeBinary, string s ) {
            List<int> index = new List<int>();
            int ind;

            for ( int i = 0; i < completeBinary.Length; i++ ) {
                ind = completeBinary.IndexOf( s, i );
                if ( ind == -1 ) {
                    break;
                }
                index.Add( ind );
                i = ind + s.Length;
                if ( i >= completeBinary.Length ) {
                    break;
                }
            }

            return index.ToArray();
        }

        // for debug
        private void rtbHex_SelectionChanged ( object sender, EventArgs e ) {
            lblSelection.Text = ( sender as RichTextBox ).SelectionStart.ToString();
        }



    }
}

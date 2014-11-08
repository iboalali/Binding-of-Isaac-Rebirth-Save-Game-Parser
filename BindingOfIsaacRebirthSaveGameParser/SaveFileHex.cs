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

        public SaveFileHex ( byte[] buffer ) {
            InitializeComponent();
            this.buffer = new byte[buffer.Length];
            buffer.CopyTo( this.buffer, 0 );

            rtbHex.Text = ByteToHex( this.buffer );



        }

        private void btnHex_Click ( object sender, EventArgs e ) {
            rtbHex.Text = ByteToHex( this.buffer );
            this.MinimumSize = new Size( 440, 543 );
            this.Size = new Size( 440, 543 );
        }

        private void btnDec_Click ( object sender, EventArgs e ) {
            rtbHex.Text = ByteToDec( this.buffer );
            this.MinimumSize = new Size( 550, 543 );
            this.Size = new Size( 550, 543 );

        }

        private string ByteToHex ( byte[] buffer ) {
            StringBuilder result = new StringBuilder();
            result.Append( "     00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F" + Environment.NewLine );
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
            result.Append( "     00  01  02  03  04  05  06  07  08  09  0A  0B  0C  0D  0E  0F" + Environment.NewLine );
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



    }
}

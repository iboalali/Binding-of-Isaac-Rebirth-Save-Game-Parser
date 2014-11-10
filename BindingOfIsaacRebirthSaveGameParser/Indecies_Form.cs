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
    public partial class Indecies_Form : Form {
        public Indecies_Form ( int[] indecies ) {
            InitializeComponent();

            for ( int i = 0; i < indecies.Length; i++ ) {
                richTextBox1.Text += indecies[i] + ",  " + indecies[i].ToString( "X4" )
                    + ",  " + ( indecies[i] / 8 ).ToString( "X4" ) + ", " + ( ( indecies[i] % 8 ) + 1 )
                    + Environment.NewLine;

            }

        }
    }
}

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
    public partial class SnapShotTimeLine_Form : Form {
        List<SaveGameSnapShot> saveGames;

        public SnapShotTimeLine_Form ( List<SaveGameSnapShot> saveGames ) {
            InitializeComponent();

            this.saveGames = saveGames;

        }









    }


}

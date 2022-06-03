using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQW {
    public partial class EQW : Form {
        public EQW() {
            InitializeComponent();
            GameProcess g = new GameProcess();
            g.LaunchGame();
        }

    }
}

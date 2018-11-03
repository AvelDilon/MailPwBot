using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FL
{
    public partial class UCSettings : UserControl
    {
        public static int UCID = 999;
        public UCSettings()
        {
            InitializeComponent();
            LOFSF.Checked = PwLib.Config.GetBool("LocalOffsets");
        }

        private void LOFSF_CheckedChanged(object sender, EventArgs e)
        {
            PwLib.Config.SetBool("LocalOffsets", LOFSF.Checked);
        }
    }
}

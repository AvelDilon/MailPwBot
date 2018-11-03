using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PwLib;

namespace FL
{
    public partial class UCMisc : UserControl
    {
        public static int UCID = 4;
        public static int DIID = 0;
        public UCMisc()
        {
            InitializeComponent();
        }

        private void OpenStart_Click(object sender, EventArgs e)
        {
            AutoItemOpen aio = new AutoItemOpen(Client.CC.CHR, int.Parse(open_item.Text), int.Parse(open_delay.Text));
            aio.RunAutoOpen();
        }

        private void INV_SELECT_Click(object sender, EventArgs e)
        {
            UCL.ReplaceUC(UCMisc.UCID, new UCInventory(Client.CC.CHR));
        }

        private void UCMisc_Paint(object sender, PaintEventArgs e)
        {
            open_item.Text = "" + DIID;
        }
    }
}

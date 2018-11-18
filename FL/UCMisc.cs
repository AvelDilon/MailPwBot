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
            AutoItemOpen aio = Client.CC.CHR.GetClass<AutoItemOpen>();
            aio.item = int.Parse(open_item.Text);
            aio.delay = int.Parse(open_delay.Text);
            if(aio.IsRun)
                aio.Stop();
            else
                aio.Run();
        }

        private void INV_SELECT_Click(object sender, EventArgs e)
        {
            UCL.ReplaceUC(UCID, new UCInventory(Client.CC.CHR, UCID));
        }

        private void UCMisc_Paint(object sender, PaintEventArgs e)
        {
            open_item.Text = "" + DIID;
        }

        private void INV_SELECT_Paint(object sender, PaintEventArgs e)
        {
            if (Client.CC == null)
            {
                INV_SELECT.Enabled = false;
                return;
            }
            INV_SELECT.Enabled = true;
        }

        private void OpenStart_Paint(object sender, PaintEventArgs e)
        {
            if (Client.CC == null)
            {
                OpenStart.Enabled = false;
                return;
            }
            OpenStart.Enabled = true;
            if (Client.CC.CHR.GetClass<AutoItemOpen>().IsRun)
                OpenStart.Text = "Стоп";
            else
                OpenStart.Text = "Начать";
        }
    }
}

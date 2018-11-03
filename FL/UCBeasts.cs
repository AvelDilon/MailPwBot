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
    public partial class UCBeasts : UserControl
    {
        public static UCBeasts Instance = null;
        public static int UCID = 3;
        public UCBeasts()
        {
            Instance = this;
            InitializeComponent();
        }

        public static void RefreshMe()
        {
            if(Instance != null)
                Instance.BB_RUN.Refresh();
        }

        private void BB_RUN_Click(object sender, EventArgs e)
        {
            if (BB_RUN.Text.Equals("Запустить"))
            {
                Client.CC.CHR.MBF.OpenBags = OBCB.Checked;
                Client.CC.CHR.MBF.SkipBattles = SBCB.Checked;
                try { Client.CC.CHR.MBF.PointLimit = Int32.Parse(PointLimit.Text); } catch { }
                Client.CC.CHR.MBF.RunBeastBattle();
                BB_RUN.Text = "Остановить";
            }
            else
            {
                Client.CC.CHR.MBF.StopBeastBattle();
                BB_RUN.Text = "Запустить";
            }
        }

        private void BB_RUN_Paint(object sender, PaintEventArgs e)
        {
            if (Client.CC == null)
            {
                BB_RUN.Enabled = false;
                return;
            }
            BB_RUN.Enabled = true;
            if (Client.CC.CHR.MBF.IsRun)
                BB_RUN.Text = "Остановить";
            else
                BB_RUN.Text = "Запустить";
        }
    }
}

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
    public partial class UCFairy : UserControl
    {
        public static UCFairy Instance;
        public static int UCID = 2;
        public UCFairy()
        {
            Instance = this;
            InitializeComponent();
        }

        public static void RefreshMe()
        {
            if (Instance != null)
                Instance.FairyStart.Refresh();
        }

        private void FairyStart_Click(object sender, EventArgs e)
        {
            if (FairyStart.Text.Equals("Запустить"))
            {
                try { Client.CC.CHR.FAIRY.GOODNEES = 100 - UInt32.Parse(FG.Text); } catch { FG.Text = "70"; }
                Client.CC.CHR.FAIRY.RunFairyEnchancement();
                FairyStart.Text = "Остановить";
            }
            else
            {
                Client.CC.CHR.FAIRY.StopFairyEnchancement();
                FairyStart.Text = "Запустить";
            }
        }

        private void FairyStart_Paint(object sender, PaintEventArgs e)
        {
            if (Client.CC == null)
            {
                FairyStart.Enabled = false;
                return;
            }
            FairyStart.Enabled = true;
            if (Client.CC.CHR.FAIRY.IsRun)
                FairyStart.Text = "Остановить";
            else
                FairyStart.Text = "Запустить";
        }
    }
}

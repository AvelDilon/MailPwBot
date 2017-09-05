using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PwBot
{
    public partial class Debug : Form
    {
        public static Debug Instance = null;

        public static Debug GetInctance()
        {
            if (Instance != null)
                return Instance;
            return new Debug();
        }

        public Debug()
        {
            InitializeComponent();
            Instance = this;
        }

        public static void LOG(string msg)
        {
            GetInctance().LTB.AppendText(msg + "\r\n");
        }

        private void INF_Click(object sender, EventArgs e)
        {
            Client.CC.CHR.Load();
            LTB.Clear();
            LTB.AppendText("Персонаж: " + Client.CC.CHR.Name + "\r\n");
            LTB.AppendText("ID: " + Client.CC.CHR.ID + "\r\n");
            LTB.AppendText("================================\r\n");
            LTB.AppendText("X: " + Client.CC.CHR.LOC.x + "\t [" + Client.CC.CHR.LOC.gx + "]\r\n");
            LTB.AppendText("Y: " + Client.CC.CHR.LOC.y + "\t [" + Client.CC.CHR.LOC.gy + "]\r\n");
            LTB.AppendText("Z: " + Client.CC.CHR.LOC.z + "\t [" + Client.CC.CHR.LOC.gz + "]\r\n");
            LTB.AppendText("================================\r\n");
            LTB.AppendText("LVL: " + Client.CC.CHR.LVL + "\r\n");
            LTB.AppendText("================================\r\n");
            LTB.AppendText("LOC: " + Client.CC.CHR.LOC_NAME + " [" + Client.CC.CHR.LOC_ID + "]\r\n");
            LTB.AppendText("================================\r\n");
        }

        private void TEST_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("[======= RUN TEST! =======]\r\n");
            Client.CC.CHR.MBF.LoadMine();
            Client.CC.CHR.MBF.LoadEnemy();
            Beast[] BB = Client.CC.CHR.MBF.AnalizeEnemy();
            LTB.AppendText("[GamesRemain    " + Client.CC.CHR.MBF.GamesRemain + "   =======]\r\n");
            LTB.AppendText("[Points         " + Client.CC.CHR.MBF.Points + "    =======]\r\n");
            LTB.AppendText("[Reward         " + Client.CC.CHR.MBF.Reward + "    =======]\r\n");
            LTB.AppendText("[======= MY! =======]\r\n");
            foreach (Beast b in Client.CC.CHR.MBF.MY.Values)
            {
                LTB.AppendText("ID:" + b.ID + "\r\n");
                LTB.AppendText("IID:" + b.ItemId + "\r\n");
                LTB.AppendText("ID2:" + b.ID2 + "\r\n");
                LTB.AppendText("Name:" + b.Name + "\r\n");
                LTB.AppendText("Power:" + b.Power + "\r\n");
                LTB.AppendText("LVL:" + b.Level + "\r\n");
                LTB.AppendText("Class:" + b.Class + "\r\n");
                LTB.AppendText("ELEMENTS:" + b.Element + "\r\n");
                LTB.AppendText("ENEMY:" + b.Enemies + "\r\n");
                LTB.AppendText("IMPROVE:" + b.NeedImprove + "\r\n");
                LTB.AppendText("DAMAGE_ANAL:" + b.DAR + "\r\n");
                LTB.AppendText("[========================]\r\n");
            }
            LTB.AppendText("[======= ENEMY! =======]\r\n");
            foreach (Beast b in Client.CC.CHR.MBF.ENEMY.Values)
            {
                LTB.AppendText("ID:" + b.ID + "\r\n");
                LTB.AppendText("Name:" + b.Name + "\r\n");
                LTB.AppendText("Power:" + b.Power + "\r\n");
                LTB.AppendText("LVL:" + b.Level + "\r\n");
                LTB.AppendText("Class:" + b.Class + "\r\n");
                LTB.AppendText("ELEMENTS:" + b.Element + "\r\n");
                LTB.AppendText("ENEMY:" + b.Enemies + "\r\n");
                LTB.AppendText("[========================]\r\n");
            }
            LTB.AppendText("[======= My BEST =======]\r\n");
            foreach (Beast b in BB)
            {
                LTB.AppendText("ID:" + b.ID + "\r\n");
                LTB.AppendText("IID:" + b.ItemId + "\r\n");
                LTB.AppendText("ID2:" + b.ID2 + "\r\n");
                LTB.AppendText("Name:" + b.Name + "\r\n");
                LTB.AppendText("Power:" + b.Power + "\r\n");
                LTB.AppendText("LVL:" + b.Level + "\r\n");
                LTB.AppendText("Class:" + b.Class + "\r\n");
                LTB.AppendText("ELEMENTS:" + b.Element + "\r\n");
                LTB.AppendText("ENEMY:" + b.Enemies + "\r\n");
                LTB.AppendText("IMPROVE:" + b.NeedImprove + "\r\n");
                LTB.AppendText("DAMAGE_ANAL:" + b.DAR + "\r\n");
                LTB.AppendText("[========================]\r\n");
            }
            LTB.AppendText("[======= INVENTARY! =======]\r\n");
            foreach (BeastItem bi in Client.CC.CHR.MBF.BIL.Values)
            {
                 LTB.AppendText("ID:" + bi.id + "\r\n");
                 LTB.AppendText("Count:" + bi.count + "\r\n");
                 LTB.AppendText("INCUBE:" + bi.NeedIncube + "\r\n");
                 LTB.AppendText("[========================]\r\n");
            }
        }

        private void Debug_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instance = null;
        }

        private void CurWin_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== Current WINDOW ============\r\n");
            GameWindow w = Client.CC.CHR.WND.GetCurrentWindow();
            LTB.AppendText(w.name + " [" + w.ptr.ToString("X4") + "] {" + w.visibility + "}\r\n");
            foreach (WindowControl c in w.CL)
                LTB.AppendText(c.name + " ==> [" + c.ptr.ToString("X4") + "]\r\n" + c.CN + " (LNG: " + c.CN.Length + ") ==> [" + c.CP.ToString("X4") + "]\r\n");
        }

        private void AllWin_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== WINDOWS ============\r\n");
            foreach (GameWindow w in Client.CC.CHR.WND.WL)
                if (w.visibility > 0)
                {
                    LTB.AppendText("WIN: " + w.name + " ==> [" + w.visibility + "] ~~ " + w.ptr + " (" + w.GF.ToString("X4") + ")\r\n");
                    /*foreach (WindowControl c in w.CL)
                        LTB.AppendText("  CNT: " + c.name + " ==> [" + c.CN + "]\r\n");*/
                }
        }

        private void NPC_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== MOBs ============\r\n");
            Client.CC.CHR.ENV.ScanLoot();
            foreach (NPC n in Client.CC.CHR.ENV.NPC_LIST)
                LTB.AppendText(n.id + " [" + n.wid.ToString("X4") + "] (" + n.type + ") ~~ " + n.name +
                    "\r\n[DIST: " + n.distance + "] [LOC: " + n.LOC.x + "; " + n.LOC.y + "; " + n.LOC.z + "]\r\n");
        }

        private void Loot_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== Loot ============\r\n");
            Client.CC.CHR.ENV.ScanLoot();
            foreach (Item i in Client.CC.CHR.ENV.LOOT_LIST)
                LTB.AppendText(i.DebugString());
        }

        private void KMSS_Click(object sender, EventArgs e)
        {
            Client.CC.CHR.EnterHome();
        }

        private void CTRL_Click(object sender, EventArgs e)
        {
            if (TV1.Text.Length > 0 && TV2.Text.Length > 0)
            {
                LTB.Clear();
                LTB.AppendText("CLICK control (" + TV2.Text + ") in window [" + TV1.Text + "]\r\n");
                Client.CC.CHR.WND.Click(TV1.Text, TV2.Text);
            }
        }

        private void Debug_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                if (Visible)
                    Hide();
            }
        }

        private void Debug_Move(object sender, EventArgs e)
        {
            if (!this.ContainsFocus)
                return;
            PwBot MWI = PwBot.Instance;
            if (MWI == null)
                return;
            MWI.Left = Left - MWI.Width + 2 * Utils.GetOS_X_Fix();
            MWI.Top = Top;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== FAIRY ============\r\n");
            FairyItem FFE = Client.CC.CHR.FAIRY.SelectFairyForEnchance();
            foreach (FairyItem FI in Client.CC.CHR.FAIRY.FL)
            {
                LTB.AppendText("ID:" + FI.id + "\r\n");
                LTB.AppendText("LVL:" + FI.lvl + "\r\n");
                LTB.AppendText("===============================\r\n");
            }
            LTB.AppendText("[SELCTED] ID:" + FFE.id + "\r\n");
            LTB.AppendText("[SELCTED] LVL:" + FFE.lvl + "\r\n");
        }
    }
}

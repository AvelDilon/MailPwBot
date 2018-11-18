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
    public partial class UCDebug : UserControl
    {
        public static int UCID = 1000;
        public UCDebug()
        {
            InitializeComponent();
        }

        private void INF_Click(object sender, EventArgs e)
        {
            Client.CC.CHR.Load();
            LTB.Clear();
            LTB.AppendText("Персонаж: " + Client.CC.CHR.Name + "\r\n");
            LTB.AppendText("ID: " + Client.CC.CHR.ID + " [" + Client.CC.CHR.ID.ToString("X4") + "]\r\n");
            LTB.AppendText("================================\r\n");
            LTB.AppendText("X: " + Client.CC.CHR.LOC.x + "\t [" + Client.CC.CHR.LOC.gx + "]\r\n");
            LTB.AppendText("Y: " + Client.CC.CHR.LOC.y + "\t [" + Client.CC.CHR.LOC.gy + "]\r\n");
            LTB.AppendText("Z: " + Client.CC.CHR.LOC.z + "\t [" + Client.CC.CHR.LOC.gz + "]\r\n");
            LTB.AppendText("================================\r\n");
            LTB.AppendText("LVL: " + Client.CC.CHR.GetVar("LVL") + "\r\n");
            LTB.AppendText("WALK_MODE: " + Client.CC.CHR.GetVar("WalkMode") + "\r\n");
            LTB.AppendText("================================\r\n");
            LTB.AppendText("LOC: " + Client.CC.CHR.LOC_NAME + " [" + Client.CC.CHR.LOC_ID + "]\r\n");
            LTB.AppendText("================================\r\n");
        }

        private void ENV_Click(object sender, EventArgs e)
        {
            PwLib.Environment ENV = Client.CC.CHR.GetClass<PwLib.Environment>();
            ENV.Scan();
            LTB.Clear();
            LTB.AppendText("============== Players ============\r\n");
            foreach (PwPlayer n in ENV.GetList<PwPlayer>())
                LTB.AppendText("(" + n.id.ToString("X4") + ") [" + n.cls.name + "] " + n.name + " [DIST: " + n.distance + "] [loc: " + n.loc.x + "; " + n.loc.y + "; " + n.loc.z + "]\r\n");
            LTB.AppendText("============== MOBs ============\r\n");
            foreach (PwMob n in ENV.GetList<PwMob>())
                LTB.AppendText(n.id + " [" + n.wid.ToString("X4") + "] (" + n.type + ") ~~ " + n.name + "\r\n[DIST: " + n.distance + "] [loc: " + n.loc.x + "; " + n.loc.y + "; " + n.loc.z + "]\r\n");
            LTB.AppendText("============== NPCs ============\r\n");
            foreach (PwNpc n in ENV.GetList<PwNpc>())
                LTB.AppendText(n.id + " [" + n.wid.ToString("X4") + "] (" + n.type + ") ~~ " + n.name + "\r\n[DIST: " + n.distance + "] [loc: " + n.loc.x + "; " + n.loc.y + "; " + n.loc.z + "]\r\n");
            LTB.AppendText("============== PETs ============\r\n");
            foreach (PwPet n in ENV.GetList<PwPet>())
                LTB.AppendText(n.id + " [" + n.wid.ToString("X4") + "] (" + n.type + ") ~~ " + n.name + "\r\n[DIST: " + n.distance + "] [loc: " + n.loc.x + "; " + n.loc.y + "; " + n.loc.z + "]\r\n");
            LTB.AppendText("============== Loot ============\r\n");
            foreach (ItemLoot n in ENV.GetList<ItemLoot>())
                LTB.AppendText(n.DebugString(true));
            LTB.AppendText("============== Mines ============\r\n");
            foreach (PwMine n in ENV.GetList<PwMine>())
                LTB.AppendText(n.DebugString(true));
        }

        private void TEST_Click(object sender, EventArgs e)
        {
            BeastFactory MBF = Client.CC.CHR.GetClass<BeastFactory>();
            LTB.Clear();
            LTB.AppendText("[======= RUN TEST! =======]\r\n");
            //Client.CC.CHR.MBF.OpenBattle();
            MBF.LoadMine();
            MBF.LoadEnemy();
            Beast[] BB = MBF.AnalizeEnemy();
            LTB.AppendText("[GamesRemain    " + MBF.GamesRemain + "   =======]\r\n");
            LTB.AppendText("[Points         " + MBF.Points + "    =======]\r\n");
            LTB.AppendText("[Reward         " + MBF.Reward + "    =======]\r\n");
            LTB.AppendText("[======= MY! =======]\r\n");
            foreach (Beast b in MBF.MY.Values)
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
            foreach (Beast b in MBF.ENEMY.Values)
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
            foreach (ItemBeast bi in MBF.BIL.Values)
            {
                LTB.AppendText("ID:" + bi.id + "\r\n");
                LTB.AppendText("Count:" + bi.count + "\r\n");
                LTB.AppendText("INCUBE:" + bi.NeedIncube + "\r\n");
                LTB.AppendText("[========================]\r\n");
            }
        }

        private void CurWin_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== Current WINDOW ============\r\n");
            GameWindow w = Client.CC.CHR.GetClass<GUI>().GetCurrentWindow();
            LTB.AppendText(w.name + " [" + w.ptr.ToString("X4") + "] {" + w.visibility + "}\r\n");
            foreach (WindowControl c in w.CL)
                LTB.AppendText(c.name + " ==> [" + c.ptr.ToString("X4") + "]\r\n" + c.CN + " (LNG: " + c.CN.Length + ") ==> [" + c.CP.ToString("X4") + "]\r\n");
        }

        private void AllWin_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== WINDOWS ============\r\n");
            Client.CC.CHR.GetClass<GUI>().LoadAllWindows();
            foreach (GameWindow w in Client.CC.CHR.GetClass<GUI>().WL)
            {
                LTB.AppendText(w.name + " ==> [" + w.visibility + "] ~~ " + w.ptr + " (" + w.GF.ToString("X4") + ")\r\n");
                /*foreach (WindowControl c in w.CL)
                    LTB.AppendText("  CNT: " + c.name + " ==> [" + c.CN + "]\r\n");*/
            }
        }

        private void EH_Click(object sender, EventArgs e)
        {
            Client.CC.CHR.EnterHome();
        }

        private void CTRL_Click(object sender, EventArgs e)
        {
            if (TV1.Text.Length > 0 && TV2.Text.Length > 0)
            {
                LTB.Clear();
                LTB.AppendText("CLICK control (" + TV2.Text + ") in window [" + TV1.Text + "]\r\n");
                Client.CC.CHR.GetClass<GUI>().Click(TV1.Text, TV2.Text);
            }
        }

        private void FAIRY_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== FAIRY ============\r\n");
            ItemFairy FFE = Client.CC.CHR.GetClass<FairyFactory>().SelectFairyForEnchance();
            foreach (ItemFairy FI in Client.CC.CHR.GetClass<FairyFactory>().FL)
            {
                LTB.AppendText("ID:" + FI.id + "\r\n");
                LTB.AppendText("LVL:" + FI.lvl + "\r\n");
                LTB.AppendText("===============================\r\n");
            }
            LTB.AppendText("[SELECTED] ID:" + FFE.id + "\r\n");
            LTB.AppendText("[SELECTED] LVL:" + FFE.lvl + "\r\n");
        }

        private void CritCtrl_Click(object sender, EventArgs e)
        {
            if (TV1.Text.Length > 0 && TV2.Text.Length > 0)
            {
                LTB.Clear();
                LTB.AppendText("CLICK control (" + TV2.Text + ") in window [" + TV1.Text + "]\r\n");
                Client.CC.CHR.GetClass<GUI>().Click(TV1.Text, TV2.Text);
            }
        }

        private void MoveChar_Click(object sender, EventArgs e)
        {
            Location CL = Client.CC.CHR.LoadLocation();
            CL.Add(2.5F, 2.5F, Client.CC.CHR.GetVar("WalkMode") == 2 ? 2.5F : 0);
            Client.CC.CHR.Move(CL);
        }

        private void ShInv_Click(object sender, EventArgs e)
        {
            LTB.Clear();
            LTB.AppendText("============== Inventary ============\r\n");
            Client.CC.CHR.GetClass<Inventory>().Load();
            foreach (ItemInventory i in Client.CC.CHR.GetClass<Inventory>().IL)
                LTB.AppendText("ID: " + i.id + " [" + i.id.ToString("X4") + "] TYPE=(" + i.type + ") ~~ PLACE: " + i.place + " COUNT: " + i.count + "\r\n");
        }

        private void OpenWnd_Click(object sender, EventArgs e)
        {
            Client.CC.CHR.GetClass<GUI>().Open(TV1.Text);
        }

        private void Interract_Click(object sender, EventArgs e)
        {
            if (Client.CC.CHR.GetClass<PwLib.Environment>().TargetByName(TV1.Text) is PwNpc t)
                t.Interract(true);
        }

        private void Dig_Click(object sender, EventArgs e)
        {
            Client.CC.CHR.LoadLocation();
            Client.CC.CHR.GetClass<PwLib.Environment>().Scan();
            PwMine CM = Client.CC.CHR.GetClass<PwLib.Environment>().GetClosest<PwMine>();
            if (CM == null)
                return;
            Client.CC.CHR.Move(CM.loc, true, 1);
            CM.Dig();
        }

        private void ItemUse_Click(object sender, EventArgs e)
        {
            try
            {
                ItemInventory ii = Client.CC.CHR.GetClass<Inventory>().GetFirstById(int.Parse(TV1.Text));
                if (ii == null)
                    return;
                LTB.Clear();
                LTB.AppendText("============== USE ITEM ============\r\n");
                LTB.AppendText("ID: " + ii.id + " [" + ii.id.ToString("X4") + "] TYPE=(" + ii.type + ") ~~ PLACE: " + ii.place + " COUNT: " + ii.count + "\r\n");
                ii.Use();
            }
            catch { }
        }
    }
}

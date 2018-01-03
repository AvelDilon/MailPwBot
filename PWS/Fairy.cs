using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwBot
{
    public class FairyItem : Item
    {
        public int lvl;
        public int fsc;
        public int P1;
        public int P2;

        public FairyItem(Character CHR) : base(CHR) { }

        public Boolean IsGood()
        {
            if (id > 0 && (lvl < CHR.FAIRY.GOODNEES + 10 || (P2 - P1 < CHR.FAIRY.GOODNEES && lvl < 100)))
                return true;
            return false;
        }

        public FairyItem LoadEquipedFairy()
        {
            id  = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_EqFairy_Arr+Player_EqFairy_Id");
            lvl = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_EqFairy_Arr+Player_EqFairy_Lvl");
            fsc = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_EqFairy_Arr+Player_EqFairy_FSC");
            P1 = lvl < 10 ? 0 : fsc - lvl + 1;
            P2 = lvl < 10 ? 0 : (lvl / 10) * 10;
            place = 0x17;
            return this;
        }

        public static FairyItem LoadInventoryFairy(Item i)
        {
            int FIA = Memory.RD(i.CHR.HNDL, i.ptr + OFS.GetInt("Inventory_Item_Fairy_INF"));
            FairyItem NFI = new FairyItem(i.CHR);
            NFI.id = i.id;
            NFI.place = i.place;
            NFI.lvl = FIA & 0xFF;
            NFI.fsc = (FIA >> 16) & 0xFF;
            NFI.P1 = NFI.lvl < 10 ? 0 : NFI.fsc - NFI.lvl + 1;
            NFI.P2 = NFI.lvl < 10 ? 0 : (NFI.lvl / 10) * 10;
            return NFI;
        }
    }

    public class Fairy
    {
        private Character CHR;
        public uint GOODNEES = 30;
        public Boolean IsRun = false;
        public List<FairyItem> FL = new List<FairyItem>();
        public static RZA RAS = new RZA(3);

        public struct RZA
        {
            public int[] RZ;
            public int SIZE;
            public RZA(int size = 2)
            {
                this.RZ = new int[size];
                this.SIZE = size;
                for (int i = 0; i < size; i++)
                    RZ[i] = 10;
            }
            public void Add(int val)
            {
                for (int i = 0; i < SIZE; i++)
                    RZ[i] = (i == SIZE - 1) ? val : RZ[i + 1];
            }
            public Boolean Analize(double percent_criteria = 65.0)
            {
                int sum = 0;
                for (int i = 0; i < SIZE; i++)
                    sum += RZ[i];
                if (RZ[SIZE - 1] > 8)
                    return true;
                if (RZ[SIZE - 1] < 4)
                    return false;
                return (double)sum / ((double)SIZE * 10.0) > percent_criteria / 100.0;
            }
        }
 
        public Fairy(Character CHR)
        {
            this.CHR = CHR;
            LoadFairiesFromInventory();
        }

        public void LoadFairiesFromInventory()
        {
            CHR.INV.Load();
            FL.Clear();
            foreach (Item i in CHR.INV.IL)
            {
                if (i.id == 0 || i.ptr == 0 || i.type != 41)
                    continue;
                FL.Add(FairyItem.LoadInventoryFairy(i));
            }
        }

        public FairyItem GetEquiped()
        {
            return new FairyItem(CHR).LoadEquipedFairy();
        }

        public FairyItem SelectFairyForEnchance()
        {
            if (GetEquiped().id > 0)
            {
                int IP = CHR.INV.GetFirstFreePlace();
                if (IP > 0)
                    Item.Equip(CHR.HNDL, IP, 0x17);
            }
            Thread.Sleep(2000);
            LoadFairiesFromInventory();
            FairyItem BEST = new FairyItem(CHR);
            FairyItem WORST = new FairyItem(CHR);
            BEST.P1 = 0;
            BEST.P2 = 1;
            WORST.P1 = 1;
            WORST.P2 = 1;
            int count = 0;
            foreach (FairyItem FI in FL)
                if (FI.IsGood())
                {
                    if (FI.lvl < 10)
                    {
                        Item.Equip(CHR.HNDL, FI.place, 0x17);
                        return FI;
                    }
                    BEST = ((double)FI.P1 / (double)FI.P2 >= (double)BEST.P1 / (double)BEST.P2) ? FI : BEST;
                    WORST = ((double)FI.P1 / (double)FI.P2 < (double)WORST.P1 / (double)WORST.P2) ? FI : WORST;
                    count++;
                }
            if (count == 0)
                return new FairyItem(CHR);
            BEST = BEST.id == 0 ? WORST : BEST;
            Boolean RA = RAS.Analize();
            (RA ? WORST : BEST).Equip(0x17);
            return RA ? WORST : BEST;
        }

        public Boolean LevelUpForSpirit()
        {
            FairyItem FI = GetEquiped();
            if (!FI.IsGood())
                return false;
            int DSU = (int)((double)Level.EXP[FI.lvl] * 0.4 / (FI.lvl < 11 ? 0.5 : Math.Round((double)FI.lvl / (double)CHR.LVL, 2) * 5));
            Packet P = new Packet(CHR.HNDL, "71-00-00-00-00-00-01");
            P.Copy(DSU, 2, 4);
            P.Send();
            return true;
        }

        public void Detach()
        {
            new Packet(CHR.HNDL, "73-00-01").Send();
        }

        public void FairyEnchancementThead()
        {
            IsRun = true;
            FairyItem FFE = SelectFairyForEnchance();
            if (FFE.id == 0)
                return;
            Thread.Sleep(1000);
            FairyItem F1 = GetEquiped();
            while (LevelUpForSpirit())
            {
                Thread.Sleep(2200);
                FairyItem F2 = GetEquiped();
                if (F2.P1 > F1.P1)
                {
                    RAS.Add(F2.P1 - F1.P1);
                    break;
                }
            }
            Thread.Sleep(2000);
            FairyItem FF = GetEquiped();
            if (!FF.IsGood() && FF.lvl < 100)
                Detach();
            FairyEnchancementThead();
            THH.SelfStop("FET:" + CHR.Name);
            IsRun = false;
        }

        public void RunFairyEnchancement()
        {
            THH.StartNewThread(FairyEnchancementThead, "FET:" + CHR.Name);
        }

        public void StopFairyEnchancement()
        {
            THH.StopThread("FET:" + CHR.Name);
            IsRun = false;
        }
    }
}

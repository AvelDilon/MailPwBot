using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwLib
{
    public class FairyFactory : UserClassObject
    {
        public uint GOODNEES = 20;
        public Boolean IsRun = false;
        public List<ItemFairy> FL = new List<ItemFairy>();
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
 
        public FairyFactory(Character CHR) : base(CHR) { LoadFairiesFromInventory(); }

        public void LoadFairiesFromInventory()
        {
            CHR.GetClass<Inventory>().Load();
            FL.Clear();
            foreach (ItemInventory i in CHR.GetClass<Inventory>().IL)
            {
                if (i.id == 0 || i.ptr == 0 || i.type != 41)
                    continue;
                FL.Add(ItemFairy.LoadInvFairy(i));
            }
        }

        public ItemFairy GetEquiped()
        {
            return ItemFairy.LoadEquipedFairy(CHR);
        }

        public ItemFairy SelectFairyForEnchance()
        {
            if (GetEquiped().id > 0)
            {
                int IP = CHR.GetClass<Inventory>().GetFirstFreePlace();
                if (IP > 0)
                    ItemInventory.Equip(CHR.HNDL, IP, 0x17);
            }
            Thread.Sleep(2000);
            LoadFairiesFromInventory();
            ItemFairy BEST = new ItemFairy(CHR);
            ItemFairy WORST = new ItemFairy(CHR);
            BEST.P1 = 0;
            BEST.P2 = 1;
            WORST.P1 = 1;
            WORST.P2 = 1;
            int count = 0;
            foreach (ItemFairy FI in FL)
                if (FI.IsGood())
                {
                    if (FI.lvl < 10)
                    {
                        ItemInventory.Equip(CHR.HNDL, FI.place, 0x17);
                        return FI;
                    }
                    BEST = ((double)FI.P1 / (double)FI.P2 >= (double)BEST.P1 / (double)BEST.P2) ? FI : BEST;
                    WORST = ((double)FI.P1 / (double)FI.P2 < (double)WORST.P1 / (double)WORST.P2) ? FI : WORST;
                    count++;
                }
            if (count == 0)
                return new ItemFairy(CHR);
            BEST = BEST.id == 0 ? WORST : BEST;
            Boolean RA = RAS.Analize();
            (RA ? WORST : BEST).Equip(0x17);
            return RA ? WORST : BEST;
        }

        public Boolean LevelUpForSpirit()
        {
            ItemFairy FI = GetEquiped();
            if (!FI.IsGood())
                return false;
            int DSU = (int)((double)Level.EXP[FI.lvl] * 0.4 / (FI.lvl < 11 ? 0.5 : Math.Round((double)FI.lvl / (double)CHR.GetVar("LVL"), 2) * 5));
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
            ItemFairy FFE = SelectFairyForEnchance();
            if (FFE.id == 0)
                return;
            Thread.Sleep(1000);
            ItemFairy F1 = GetEquiped();
            while (LevelUpForSpirit())
            {
                Thread.Sleep(2200);
                ItemFairy F2 = GetEquiped();
                if (F2.P1 > F1.P1)
                {
                    RAS.Add(F2.P1 - F1.P1);
                    break;
                }
            }
            Thread.Sleep(2000);
            ItemFairy FF = GetEquiped();
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

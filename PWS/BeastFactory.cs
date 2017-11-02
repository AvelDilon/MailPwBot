using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    public class BeastFactory
    {
        public static int MBO = OFS.GetInt("BeastStruct");
        private static int[] BagsId = new int[] { 51759, 51758, 51757, 51756 };
        public Boolean IsRun = false;
        private Character CHR = null;
        public Dictionary<int, Beast> MY = new Dictionary<int, Beast>();
        public Dictionary<int, Beast> ENEMY = new Dictionary<int, Beast>();
        public Dictionary<int, BeastItem> BIL = new Dictionary<int, BeastItem>();
        public int Points = -1;
        public int PointLimit = 3000;
        public int Reward = -1;
        public int GamesRemain = -1;
        public Boolean OpenBags = true;
        public Boolean SkipBattles = true;

        public BeastFactory(Character CHR) { this.CHR = CHR; Beast.Init(); BeastReward.Init(); }

        public void Run()
        {
            IsRun = true;
            CHR.EnterHome();
            CHR.WND.WaitForWindow("Win_Chat", 20, false);
            Utils.RandomDelay();
            LoadMine();
            Utils.RandomDelay();
            if (GamesRemain < 1 || Points > PointLimit)
                return;
            OpenBattle();
            Utils.RandomDelay();
            int EC = GetRandomEnemyCommander();
            SelectEnemy(EC);
            Utils.RandomDelay();
            LoadEnemy();
            Utils.RandomDelay();
            Beast[] BB = AnalizeEnemy();
            Utils.RandomDelay();
            StartBattle(BB, EC);
            Utils.RandomDelay();
            if (SkipBattles)
            {
                if (CHR.WND.WaitForWindow("Win_HomePetPrepare", 10))
                    CHR.WND.Click("Win_HomePetPrepare", "Btn_Skip");
            }
            if (CHR.WND.WaitForWindow("Win_HomePetFirstAward", SkipBattles ? 10 : 60))
            {
                GetPrizeBag();
                CHR.WND.Click("Win_HomePetFirstAward", "Btn_Close");
            }
            Run();
            THH.SelfStop("BeastBattle:" + CHR.Name);
            IsRun = false;
        }

        public void RunBeastBattle()
        {
            THH.StartNewThread(Run, "BeastBattle:" + CHR.Name);
        }

        public void StopBeastBattle()
        {
            THH.StopThread("BeastBattle:" + CHR.Name);
            IsRun = false;
        }

        public void LoadMine()
        {
            Points = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_Points"));
            Reward = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_GetRewards"));
            GamesRemain = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_GamesRemain"));
            GetReward();
            OpenAllBags();
            MoveAllBeastsToStore();
            LoadInventory();
            LoadMyBeastStruct();
            LoadMyDynamic();
            while (Improve());
        }

        public void LoadInventory()
        {
            BIL.Clear();
            int rr = -1;
            int BIB = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_InventoryBegin"));
            int BIE = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_InventoryEnd"));
            while (BIB < BIE)
            {
                byte[] buffer = new byte[OFS.GetInt("BS_InventoryItemSize")];
                EF.ReadProcessMemory(CHR.HNDL, BIB, buffer, buffer.Length, ref rr);
                int[] oa = new int[buffer.Length / 4];
                Buffer.BlockCopy(buffer, 0, oa, 0, buffer.Length);
                BeastItem NBI = new BeastItem(CHR);
                NBI.id = oa[OFS.GetInt("BS_BI_ID") / 4];
                NBI.count = oa[OFS.GetInt("BS_BI_Count") / 4];
                BIL.Add(NBI.id, NBI);
                BIB += OFS.GetInt("BS_InventoryItemSize");
            }
        }

        public void LoadMyBeastStruct()
        {
            MY.Clear();
            int rr = -1;
            int MAB = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_ArrayBegin"));
            int MAE = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_ArrayEnd"));
            while (MAB < MAE)
            {
                byte[] buffer = new byte[OFS.GetInt("BS_ArrayItemSize")];
                EF.ReadProcessMemory(CHR.HNDL, MAB, buffer, buffer.Length, ref rr);
                uint[] oa = new uint[buffer.Length / 4];
                Buffer.BlockCopy(buffer, 0, oa, 0, buffer.Length);
                Beast NB = Beast.Parse(oa, CHR);
                if (NB != null && !MY.ContainsKey(NB.ID))
                    MY.Add(NB.ID, NB);
                MAB += OFS.GetInt("BS_ArrayItemSize");
            }
        }

        public void LoadMyDynamic()
        {
            int rr = -1;
            int DSB = Memory.RD(CHR.HNDL, CHR.CSP, "PL_BS_Struct+PL_BS_P1+PL_BS_P2+PL_BS_Begin");
            int DSE = Memory.RD(CHR.HNDL, CHR.CSP, "PL_BS_Struct+PL_BS_P1+PL_BS_P2+PL_BS_End");
            int DSL = OFS.GetInt("PL_BS_Length");
            while (DSB < DSE)
            {
                byte[] buffer = new byte[DSL];
                EF.ReadProcessMemory(CHR.HNDL, DSB, buffer, buffer.Length, ref rr);
                uint[] oa = new uint[buffer.Length / 4];
                Buffer.BlockCopy(buffer, 0, oa, 0, buffer.Length);
                int ID1 = (int)oa[OFS.GetInt("PL_BS_Item_ID1") / 4];
                int ID2 = (int)oa[OFS.GetInt("PL_BS_Item_ID2") / 4];
                if (MY.ContainsKey(ID1))
                    MY[ID1].ID2 = ID2;
                DSB += DSL;
            }
        }

        public void LoadEnemy()
        {
            ENEMY.Clear();
            int rr = -1;
            int EAB = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_EnemyArrayBegin"));
            int EAE = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_EnemyArrayEnd"));
            while (EAB < EAE)
            {
                byte[] buffer = new byte[OFS.GetInt("BS_ArrayItemSize")];
                EF.ReadProcessMemory(CHR.HNDL, EAB, buffer, buffer.Length, ref rr);
                uint[] oa = new uint[buffer.Length / 4];
                Buffer.BlockCopy(buffer, 0, oa, 0, buffer.Length);
                Beast NB = Beast.Parse(oa, CHR);
                if (NB != null && !ENEMY.ContainsKey(NB.ID))
                    ENEMY.Add(NB.ID, NB);
                EAB += OFS.GetInt("BS_ArrayItemSize");
            }
        }

        public int GetRandomEnemyCommander()
        {
            List<int> ECL = new List<int>();
            int ECB = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_EnemyCommanderBegin"));
            int ECE = Memory.RD(CHR.HNDL, MBO + OFS.GetInt("BS_EnemyCommanderEnd"));
            while (ECB < ECE)
            {
                ECL.Add(Memory.RD(CHR.HNDL, ECB));
                ECB += 0x04;
            }
            return ECL[new Random().Next(0, ECL.Count - 1)];
        }

        public void MoveAllBeastsToStore()
        {
            CHR.INV.Load();
            foreach (Item i in CHR.INV.IL)
                if (i.id >= Beast.ITEM_BASE + Beast.MIN_ITEM && i.id <= Beast.ITEM_BASE + Beast.MAX_ITEM)
                    BeastItem.FromItem(i).PutToBI();
        }

        public void OpenAllBags()
        {
            if (!OpenBags)
                return;
            CHR.INV.Load();
            while (CHR.INV.HasItemsFromList(BagsId))
            {
                foreach (Item i in CHR.INV.IL)
                    if (BagsId.Contains(i.id))
                        i.Use();
                Utils.RandomDelay(3500, 4500);
                MoveAllBeastsToStore();
            }
        }

        public Boolean Improve()
        {
            foreach (int iid in BIL.Keys)
            {
                Boolean find = false;
                foreach (Beast B in MY.Values)
                    if (B.ItemId == iid)
                    {
                        B.NeedImprove = BIL[iid].count >= Beast.IMPROVE_TABLE[B.Level - 1] && Beast.IMPROVE_TABLE[B.Level - 1] > -1;
                        find = true;
                        break;
                    }
                BIL[iid].NeedIncube = !find;
            }
            Boolean RESULT = false;
            foreach (BeastItem BI in BIL.Values)
                if (BI.NeedIncube)
                {
                    RESULT = true;
                    BI.GetFromBI();
                    BI.Incube();
                }
            if (RESULT)
            {
                MoveAllBeastsToStore();
                LoadInventory();
                LoadMyBeastStruct();
                LoadMyDynamic();
            }
            foreach (Beast B in MY.Values)
                if (B.NeedImprove && BIL.ContainsKey(B.ItemId))
                {
                    BIL[B.ItemId].GetFromBI();
                    B.Improve();
                    RESULT = true;
                }
            if (RESULT)
            {
                MoveAllBeastsToStore();
                LoadInventory();
                LoadMyBeastStruct();
                LoadMyDynamic();
            }
            return RESULT;
        }

        public Beast[] AnalizeEnemy()
        {
            foreach (Beast MB in MY.Values)
            {
                MB.DAR = 0.0;
                foreach (Beast EB in ENEMY.Values)
                {
                    double MD = MB.Power;
                    double ED = EB.Power;
                    MD *= (MB.Enemies & EB.Class) > 0 ? 1.5 : 1.0;
                    ED *= (EB.Enemies & MB.Class) > 0 ? 1.5 : 1.0;
                    double ElemMult = 1.3;  /// не точно...
                    switch (MB.Element)
                    {
                        case 1:
                            if (EB.Element == 2 || EB.Element == 16)
                                MD *= ElemMult;
                            else if (EB.Element != 1)
                                ED *= ElemMult;
                            break;
                        case 2:
                            if (EB.Element == 4 || EB.Element == 16)
                                MD *= ElemMult;
                            else if (EB.Element != 2)
                                ED *= ElemMult;
                            break;
                        case 4:
                            if (EB.Element == 1 || EB.Element == 8)
                                MD *= ElemMult;
                            else if (EB.Element != 4)
                                ED *= ElemMult;
                            break;
                        case 8:
                            if (EB.Element == 1 || EB.Element == 2)
                                MD *= ElemMult;
                            else if (EB.Element != 8)
                                ED *= ElemMult;
                            break;
                        case 16:
                            if (EB.Element == 4 || EB.Element == 8)
                                MD *= ElemMult;
                            else if (EB.Element != 16)
                                ED *= ElemMult;
                            break;
                    }
                    MB.DAR += MD;
                    MB.DAR -= ED;
                }
            }
            Beast[] SA = MY.Values.OrderByDescending(b => b.DAR).ToArray();
            return new Beast[] { SA[0], SA[1], SA[2] };
        }

        public void OpenBattle()
        {
            Packet P = new Packet(CHR.HNDL, "C0-00-2B-15-00-00-0C-00-00-00-00-A4-1E-AA-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.Send();
            Utils.RandomDelay();
        }

        public void SelectEnemy(int EC)
        {
            Packet P = new Packet(CHR.HNDL, "C0-00-3F-15-00-00-10-00-00-00-73-8B-D0-20-00-00-00-00-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.CopyR(EC, 22, 4);
            P.Send();
            Utils.RandomDelay();
        }

        public void StartBattle(Beast[] BB, int EC)
        {
            Packet P = new Packet(CHR.HNDL, "C0-00-2E-15-00-00-1D-00-00-00-00-19-E7-B8-00-00-00-00-00-00-00-00-03-00-00-00-1C-00-00-00-1D-00-00-00-10-00-00-00-05");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.CopyR(BB[0].ID2, 23, 4);
            P.CopyR(BB[1].ID2, 27, 4);
            P.CopyR(BB[2].ID2, 31, 4);
            P.CopyR(EC, 35, 4);
            P.Send();
            Utils.RandomDelay();
        }

        public void GetPrizeBag()
        {
            if (CHR.INV.GetFreeCount() < 1)
                return;
            Packet P = new Packet(CHR.HNDL, "C0-00-3A-15-00-00-0C-00-00-00-00-A4-20-1A-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.Send();
            Utils.RandomDelay();
        }

        public void GetReward()
        {
            int RN = BeastReward.GetRewardNumber(Points, Reward);
            if (RN < 1 || CHR.INV.GetFreeCount() < 1)
                return;
            Packet P = new Packet(CHR.HNDL, "C0-00-3B-15-00-00-10-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.CopyR(RN, 22, 4);
            P.Send();
            Utils.RandomDelay();
        }
    }
}

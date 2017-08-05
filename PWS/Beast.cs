using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    public class Beast
    {
        public static Dictionary<int, Beast> INF = new Dictionary<int, Beast>();
        public static int ITEM_BASE = 50938;
        public static int MIN_ITEM = 682;
        public static int MAX_ITEM = 718;
        public static int[] IMPROVE_TABLE = new int[] { 2, 4, 10, 20, 50, 100, 200, 400 };

        public int ID;
        public int ID2;
        public int ItemId;
        public int[] LVL;
        public String Name;
        public int Class = -1;
        private Character CHR;

        public uint[] BS;
        public int Level;
        public int Power;
        public uint Enemies;
        public uint Element;
        public double DAR = 0.0;
        public Boolean NeedImprove = false;

        public Beast(int id = 0) { ID = id; }
        public Beast(int id, int CLS, String name, int[] ls)
        {
            ID = id;
            ItemId = id + ITEM_BASE;
            Name = name;
            LVL = ls;
            Class = CLS;
        }

        public void Improve()
        {
            if (!NeedImprove)
                return;
            Packet P = new Packet(CHR.HNDL, "C0-00-35-15-00-00-14-00-00-00-00-90-AA-14-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.CopyR(ID2, 22, 4);
            P.CopyR(Level, 26, 4);
            P.Send();
            Utils.RandomDelay();
        }

        public static void Init()
        {
            if (INF.Count > 0)
                return;
            INF.Clear();
            INF.Add(682, new Beast(682, 1, "Ледяной тигр", new int[] { 1000, 1200, 1440, 1730, 2079, 2490, 2990, 3589, 4300 }));
            INF.Add(683, new Beast(683, 1, "Механический тигр", new int[] { 1007, 1208, 1450, 1742, 2094, 2507, 3010, 3615, 4330 }));
            INF.Add(684, new Beast(684, 2, "Молчащий феникс", new int[] { 1014, 1216, 1460, 1754, 2109, 2524, 3031, 3640, 4360 }));
            INF.Add(685, new Beast(685, 2, "Волшебный журавль", new int[] { 1021, 1225, 1470, 1766, 2123, 2542, 3052, 3665, 4390 }));
            INF.Add(686, new Beast(686, 4, "Жук-щелкун", new int[] { 1029, 1234, 1481, 1780, 2140, 2562, 3076, 3694, 4424 }));
            INF.Add(687, new Beast(687, 4, "Жук-охотник", new int[] { 1036, 1243, 1491, 1792, 2154, 2579, 3097, 3719, 4454 }));
            INF.Add(688, new Beast(688, 8, "Оленёнок", new int[] { 1043, 1251, 1501, 1804, 2169, 2597, 3118, 3744, 4484 }));
            INF.Add(689, new Beast(689, 8, "Цветной олень", new int[] { 1050, 1260, 1512, 1816, 2183, 2614, 3139, 3769, 4515 }));
            INF.Add(690, new Beast(690, 16, "Каменный тролль", new int[] { 1057, 1268, 1522, 1828, 2198, 2631, 3160, 3794, 4545 }));
            INF.Add(691, new Beast(691, 16, "Волшебный тролль", new int[] { 1064, 1276, 1532, 1840, 2213, 2649, 3181, 3819, 4575 }));
            INF.Add(692, new Beast(692, 32, "Дух леса", new int[] { 1071, 1285, 1542, 1852, 2227, 2666, 3202, 3844, 4605 }));
            INF.Add(693, new Beast(693, 32, "Колдовская лиана", new int[] { 1079, 1294, 1553, 1866, 2244, 2686, 3226, 3873, 4639 }));
            INF.Add(694, new Beast(694, 64, "Короткорог", new int[] { 1086, 1303, 1563, 1878, 2258, 2704, 3247, 3898, 4669 }));
            INF.Add(695, new Beast(695, 64, "Горный буйвол", new int[] { 1093, 1311, 1573, 1890, 2273, 2721, 3268, 3923, 4699 }));
            INF.Add(696, new Beast(696, 128, "Яшмовый дракон", new int[] { 1100, 1320, 1584, 1903, 2287, 2739, 3289, 3948, 4730 }));

            INF.Add(698, new Beast(698, 1, "Королевский тигренок", new int[] { 1440, 1728, 2073, 2491, 2995, 3585, 4305, 5169, -1 }));
            INF.Add(699, new Beast(699, 2, "Колдовская птица", new int[] { 1456, 1747, 2096, 2518, 3028, 3625, 4353, 5227, -1 }));
            INF.Add(700, new Beast(700, 4, "Костяной малыш", new int[] { 1472, 1766, 2119, 2546, 3061, 3665, 4401, 5284, -1 }));
            INF.Add(701, new Beast(701, 8, "Многоцветный олень", new int[] { 1488, 1785, 2142, 2574, 3095, 3705, 4449, 5341, -1 }));
            INF.Add(702, new Beast(702, 16, "Шептун", new int[] { 1504, 1804, 2165, 2601, 3128, 3744, 4496, 5399, -1 }));
            INF.Add(703, new Beast(703, 32, "Древесный патриарх", new int[] { 1520, 1824, 2188, 2629, 3161, 3784, 4544, 5456, -1 }));
            INF.Add(704, new Beast(704, 64, "Пламенный длиннорог", new int[] { 1536, 1843, 2211, 2657, 3194, 3824, 4592, 5514, -1 }));
            INF.Add(705, new Beast(705, 128, "Земляной цилинь", new int[] { 1552, 1862, 2234, 2684, 3228, 3864, 4640, 5571, -1 }));
            INF.Add(706, new Beast(706, 256, "Наг-палач", new int[] { 1568, 1881, 2257, 2712, 3261, 3904, 4688, 5629, -1 }));
            INF.Add(707, new Beast(707, 512, "Лавовый кузнец", new int[] { 1584, 1900, 2280, 2740, 3294, 3944, 4736, 5686, -1 }));

            INF.Add(714, new Beast(714, 256, "Белоснежный феникс", new int[] { 2074, 2488, 2986, 3588, 4313, 5164, 6201, -1, - 1 }));
            INF.Add(715, new Beast(715, 512, "Пожиратель пламени", new int[] { 2125, 2550, 3060, 3676, 4420, 5291, 6353, -1, - 1 }));
            INF.Add(716, new Beast(716, 1024, "Синий призрак", new int[] { 2177, 2612, 3134, 3766, 4528, 5420, 6509, -1, - 1 }));
            INF.Add(717, new Beast(717, 1024, "Гивр", new int[] { 2229, 2674, 3209, 3856, 4636, 5550, 6664, -1, - 1 }));
            INF.Add(718, new Beast(718, 2048, "Небесный дракон", new int[] { 2281, 2737, 3284, 3946, 4744, 5679, 6820, -1, - 1 }));
        }

        public static Beast Parse(uint[] BS, Character CHR)
        {
            int id = (int)BS[OFS.GetInt("BS_BL_ID") / 4];
            if (!INF.ContainsKey(id))
                return null;
            Beast RB = new Beast(id);
            RB.BS = BS;
            RB.Level = (int)BS[OFS.GetInt("BS_BL_Level") / 4];
            RB.Enemies = BS[OFS.GetInt("BS_BL_Enemies") / 4];
            RB.Element = (BS[OFS.GetInt("BS_BL_Elements") / 4] & 0xFF);
            RB.Power = INF[id].LVL[RB.Level - 1];
            RB.Name = INF[id].Name;
            RB.ItemId = INF[id].ItemId;
            RB.Class = INF[id].Class;
            RB.CHR = CHR;
            return RB;
        }
    }

    public class BeastItem : Item
    {
        public Boolean NeedIncube = false;
        public BeastItem(Character CHR) : base(CHR) { IT = ItemType.BeastInventory; }

        public static BeastItem FromItem(Item i) { BeastItem bi = new BeastItem(i.CHR); bi.id = i.id; bi.count = i.count; return bi; }

        public void PutToBI() { new Packet(CHR.HNDL, "C7-00-00-00-00-00-00-00-00-00-00-00-00-00").Copy(id, 6, 4).Copy(count, 10, 4).Send(); Utils.RandomDelay(); }
        public void GetFromBI() { new Packet(CHR.HNDL, "C7-00-01-00-00-00-00-00-00-00-00-00-00-00").Copy(id, 6, 4).Copy(count, 10, 4).Send(); Utils.RandomDelay(); }

        public void Incube()
        {
            if (!NeedIncube)
                return;
            Packet P = new Packet(CHR.HNDL, "C0-00-32-15-00-00-10-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.CopyR(id, 22, 4);
            P.Send();
            Utils.RandomDelay();
        }
    }

    public class BeastReward
    {
        private static List<BeastReward> BRL = new List<BeastReward>();
        private static int[] PRIZE_LIST = new int[] { 200, 400, 600, 800, 1000, 1200, 1400, 1600, 1800, 2000, 2300, 2600, 3000 };
        private int Points = -1;
        private int Num = -1;
        private int RewNum = -1;

        public BeastReward(int pts, int num, int RN) { Points = pts; Num = num; RewNum = RN; }

        public static void Init()
        {
            if (BRL.Count > 0)
                return;
            BRL.Clear();
            int i = 1;
            foreach (int j in PRIZE_LIST)
            {
                BRL.Add(new BeastReward(j, i, (1 << (i - 1)) - 1));
                i++;
            }
        }

        public static int GetRewardNumber(int pts, int rwn)
        {
            foreach (BeastReward BR in BRL)
                if (pts > BR.Points && rwn == BR.RewNum)
                    return BR.Num;
            return -1;
        }
    }
}
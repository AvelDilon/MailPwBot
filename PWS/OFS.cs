using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    class OFS
    {
        private static Dictionary<String, String> OFSL = new Dictionary<String, String>();

        private static void Put(String key, String value) { OFSL.Add(key, value); }
        public static String Get(String key) { return OFSL.ContainsKey(key) ? OFSL[key] : key; }
        public static int GetInt(String key) { return Convert.ToInt32(Get(key), 16); }
        public static uint GetUInt(String key) { return Convert.ToUInt32(Get(key), 16); }
        private static void Empty() { OFSL.Clear(); }

        public static int BA = 0;
        public static int PA = 0;
        public static int GUI = 0;

        public static void Init()
        {
            Empty();
            Put("BA", "0xDFCBA0");
            Put("GA_OFS", "0x1C");
            Put("MS_OFS", "0x1C");
            //------------------------------------------------------
            Put("LOCATION_ID", "0x90");
            Put("LOCATION_NAME", "0x60");
            Put("LOCATION_NAME_OFS", "0x4");
            //------------------------------------------------------
            Put("SendPacket", "0x7F2560");
            Put("GUI", "0x9CBD40");
            Put("NTDLL_CriticalSectionPtr", "0x560B750");
            Put("NTDLL_EnterCriticalSection", "0xC2F2CC");
            Put("NTDLL_LeaveCriticalSection", "0xC2F2D0");
            //------------------------------------------------------
            Put("Gui_O1", "0x18");
            Put("Gui_O2", "0x8");
            Put("Gui_TopW_Struct", "0xAC");
            Put("Gui_LowW_Struct", "0x8C");
            Put("Gui_Win_Current", "0x74");
            Put("Gui_Win_Ptr", "0x8");
            Put("Gui_Win_Name", "0x4C");
            Put("Gui_Win_Visibility", "0x90");
            Put("Gui_Win_Ctrl_Array", "0x1C8");
            Put("Gui_Win_Ctrl_Ptr", "0x8");
            Put("Gui_Win_Ctrl_Name", "0x18");
            Put("Gui_Win_Ctrl_Function", "0x1C");
            Put("Gui_Win_Ctrl_Next", "0xC");
            //------------------------------------------------------
            Put("PlayerStruct", "0x34");
            Put("PlayerName", "0x748");
            Put("Player_LocX", "0x3C");
            Put("Player_LocY", "0x44");
            Put("Player_LocZ", "0x40");
            Put("Player_ID", "0x4B4");
            Put("Player_Lvl", "0x4C0");
            Put("Player_WalkMode", "0x758");
            Put("Player_FlyId", "0x5F4");
            Put("Player_EqFairyId", "0x634");
            Put("Player_EqFairy_Arr", "0x404");
            Put("Player_EqFairy_Lvl", "0x70");
            Put("Player_EqFairy_FSC", "0x74");
            Put("Player_Action_Struct", "0x15BC");
            Put("Player_Inventory_Struct", "0x1158");
            //------------------------------------------------------
            Put("Inventory_Array", "0xC");
            Put("Inventory_MaxSize", "0x14");
            Put("Inventory_Item_ID", "0xC");
            Put("Inventory_Item_Type", "0x8");
            Put("Inventory_Item_Count", "0x14");
            Put("Inventory_Item_Price", "0x1C");
            Put("Inventory_Item_MaxCount", "0x18");
            Put("Inventory_Item_Fairy_INF", "0xEC");
            //------------------------------------------------------
            Put("Mob_Struct", "0x20");
            Put("Mob_Count", "0x18");
            Put("Mob_Array", "0x5C");
            Put("Mob_Type", "0xB4");
            Put("Mob_Id", "0x11C");
            Put("Mob_WId", "0x114");
            Put("Mob_Name", "0x260");
            Put("Mob_LocX", "0x3C");
            Put("Mob_LocY", "0x44");
            Put("Mob_LocZ", "0x40");
            Put("Mob_Distance", "0x284");
            //------------------------------------------------------
            Put("Loot_Struct", "0x24");
            Put("Loot_Count", "0x14");
            Put("Loot_Array", "0x1C");
            Put("Loot_LocX", "0x3C");
            Put("Loot_LocY", "0x44");
            Put("Loot_LocZ", "0x40");
            Put("Loot_ID", "0x114");
            Put("Loot_WID", "0x110");
            Put("Loot_Type", "0x150");
            //------------------------------------------------------
            Put("action_1", "0x4E24D0");
            Put("action_2", "0x4E7C90");
            Put("action_3", "0x4E35F0");
            //------------------------------------------------------
            Put("BeastStruct", "0xE224D8");
            Put("BS_ArrayBegin", "0x00");
            Put("BS_ArrayEnd", "0x04");
            Put("BS_EnemyArrayBegin", "0x30");
            Put("BS_EnemyArrayEnd", "0x34");
            Put("BS_Points", "0x84");
            Put("BS_GetRewards", "0x90");
            Put("BS_GamesRemain", "0x98");
            Put("BS_EnemyCommanderBegin", "0xB8");
            Put("BS_EnemyCommanderEnd", "0xBC");
            Put("BS_InventoryBegin", "0xDC");
            Put("BS_InventoryEnd", "0xE0");
            Put("BS_ArrayItemSize", "0x20");
            Put("BS_InventoryItemSize", "0x08");
            Put("BS_BL_ID", "0x00");
            Put("BS_BL_Level", "0x04");
            Put("BS_BL_Enemies", "0x0C");
            Put("BS_BL_Elements", "0x10");
            Put("BS_BI_ID", "0x00");
            Put("BS_BI_Count", "0x04");
            //------------------------------------------------------
            Put("PL_BS_Struct", "0x1928");
            Put("PL_BS_P1", "0x18");
            Put("PL_BS_P2", "0xA4");
            Put("PL_BS_Begin", "0x00");
            Put("PL_BS_End", "0x04");
            Put("PL_BS_Length", "0x64");
            Put("PL_BS_Item_ID2", "0x00");
            Put("PL_BS_Item_ID1", "0x04");
            //------------------------------------------------------
            BA = GetInt("BA");
            PA = GetInt("SendPacket");
            GUI = GetInt("GUI");
        }

         public static String COFS(String OL)
        {
            List<String> b = new List<String>();
            foreach (String c in OL.Split('+'))
                b.Add(Get(c));
            return String.Join("+", b);
        }
    }
}

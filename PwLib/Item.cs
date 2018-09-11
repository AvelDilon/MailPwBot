using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Item
    {
        public Character CHR;
        public enum ItemType { Inventory, Equiped, Loot, BeastInventory, Koms }

        public int id;
        public uint wid;
        public int ptr;
        public byte place;
        public int count;
        public int max_count;
        public int type;
        public int price;
        public Location loc;
        public ItemType IT;

        public Item(Character CHR, int ptr = 0) { this.CHR = CHR; this.ptr = ptr; }

        public void LoadLootItem()
        {
            id = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Loot_ID"));
            wid = Memory.RUD(CHR.HNDL, ptr + OFS.GetInt("Loot_WID"));
            type = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Loot_Type"));
            loc = new Location(Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocX")), Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocY")), Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocZ")));
            IT = ItemType.Loot;
        }

        public void LoadInventoryItem()
        {
            id = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_ID"));
            type = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_Type"));
            count = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_Count"));
            max_count = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_MaxCount"));
            price = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_Price"));
            IT = ItemType.Inventory;
        }

        public void Use()
        {
            if (IT != ItemType.Inventory)
                return;
            new Packet(CHR.HNDL, "28-00-00-01-0D-00-AD-21-00-00").Copy(place, 4, 1).Copy(id, 6, 4).Send();
        }

        public static void Equip(int HNDL, int INV, byte EQP)
        {
            new Packet(HNDL, "11-00-FF-FF").Copy(INV, 2, 1).Copy(EQP, 3, 1).Send();
            new Packet(HNDL, "15-00").Send();
        }

        public void Equip(byte EQP)
        {
            Equip(CHR.HNDL, place, EQP);
        }

        public String DebugStructure(int count = 1024)
        {
            StringBuilder bu = new StringBuilder();
            for (int i = 0; i < count; i++)
                bu.Append("[OFFSET:" + (i * 0x4).ToString("X4") + "]\t [VALUE: " + Memory.RD(CHR.HNDL, ptr + i * 0x4) + "]\r\n");
            return bu.ToString();
        }

        public String DebugString(Boolean with_loc = false)
        {
            return "ID: " + id + ", WID: " + wid.ToString("X4") + ", TYPE: " + type + (with_loc ? "\r\n" + loc.DebugString() : "\r\n");
        }
    }
}

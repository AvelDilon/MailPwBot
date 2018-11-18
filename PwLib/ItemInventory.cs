using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PwLib
{
    public class ItemInventory : Item
    {
        public byte place;
        public int count;
        public int max_count;
        public int price;

        public ItemInventory() : base() {}
        public ItemInventory(Character CHR) : base(CHR) {}
        public ItemInventory(Character CHR, int ptr) : base(CHR, ptr) {}

        public ItemInventory Load(byte place)
        {
            id = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_ID"));
            type = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_Type"));
            count = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_Count"));
            max_count = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_MaxCount"));
            price = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Inventory_Item_Price"));
            this.place = place;
            if (id == 0)
                return this;
            desc = ReadDescription();
            String[] sa = new Regex("\\^[0-9a-f]{6}").Split(desc);
            if (sa.Length < 2)
                return this;
            String ps = sa[1].Trim();
            name = (ps.IndexOf('(') > 0 ? ps.Substring(0, ps.IndexOf('(')) : ps.Substring(0, ps.IndexOf('\\'))).Trim();
            return this;
        }

        public static List<T> LoadStruct<T>(Character CHR, int PTR, int MAX_ITEMS) where T : class
        {
            if (!typeof(T).IsSubclassOf(typeof(ItemInventory)) && typeof(T) != typeof(ItemInventory))
                return null;
            List<T> LIL = new List<T>();
            for (byte i = 0; i < MAX_ITEMS; i++)
                LIL.Add(new ItemInventory(CHR, Memory.RD(CHR.HNDL, PTR + i * 0x4)).Load(i) as T);
            return LIL;
        }

        private String ReadDescription()
        {
            byte[] WP =
            {
                0x60,                                       // pushad
                0xB9, 0x00, 0x00, 0x00, 0x00,               // mov ecx, CELL_PTR
                0x8B, 0x01,                                 // mov eax, [ecx]
                0x6A, 0x00,                                 // push 00
                0xFF, 0x50, 0x40,                           // call [eax + 0x40]
                0xA3, 0x00, 0x00, 0x00, 0x00,               // [ALLOCATED_MEMORY], eax
                0x61, 0xC3                                  // popad, ret
            };
            Packet P = new Packet(CHR.HNDL, WP);
            P.Copy(ptr, 2, 4);
            byte[] RA = new byte[4];
            RA = P.Execute(RA, 14);
            return Memory.RS(CHR.HNDL, BitConverter.ToInt32(RA, 0), 2048);
        }

        public void Use() { new Packet(CHR.HNDL, "28-00-00-01-0D-00-AD-21-00-00").Copy(place, 4, 1).Copy(id, 6, 4).Send(); }

        public void Equip(byte EQP) { Equip(CHR.HNDL, place, EQP); }

        public static void Equip(int HNDL, int INV, byte EQP)
        {
            new Packet(HNDL, "11-00-FF-FF").Copy(INV, 2, 1).Copy(EQP, 3, 1).Send();
            new Packet(HNDL, "15-00").Send();
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
            return "ID: " + id + ", WID: " + wid.ToString("X4") + ", TYPE: " + type;
        }

        public override String ToString()
        {
            return name + " (" + count + ")";
        }
    }
}

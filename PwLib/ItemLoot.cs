using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class ItemLoot : PwWorldObject
    {
        Boolean IsCoin = false;
        public ItemLoot(Character CHR, int ptr) : base(CHR, ptr) { }

        public new ItemLoot Load()
        {
            id = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Loot_ID"));
            wid = Memory.RUD(CHR.HNDL, ptr + OFS.GetInt("Loot_WID"));
            type = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Loot_Type"));
            loc = new Location(Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocX")), Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocY")), Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocZ")));
            CalculateDistance();
            IsCoin = (type == 3);
            return this;
        }

        public String DebugString(Boolean with_loc = false)
        {
            return "ID: " + id + ", WID: " + wid.ToString("X4") + ", TYPE: " + type + (with_loc ? "\r\n" + loc.DebugString() : "\r\n");
        }
    }
}

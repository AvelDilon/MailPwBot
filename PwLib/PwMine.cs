using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwMine : PwWorldObject
    {
        public PwMine(Character CHR, int ptr) : base(CHR, ptr) { }
        public new PwMine Load()
        {
            type = 2;
            id = Memory.RD(CHR.HNDL, ptr + OFS.GetInt("Loot_ID"));
            wid = Memory.RUD(CHR.HNDL, ptr + OFS.GetInt("Loot_WID"));
            loc = new Location(Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocX")), Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocY")), Memory.RF(CHR.HNDL, ptr + OFS.GetInt("Loot_LocZ")));
            CalculateDistance();
            return this;
        }

        public void Dig()
        {
            new Packet(HNDL, "36-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00").Copy(wid, 2, 4).Send();
        }

        public String DebugString(Boolean with_loc = false)
        {
            return "ID: " + id + ", WID: " + wid.ToString("X4") + ", TYPE: " + type + (with_loc ? "\r\n" + loc.DebugString() : "\r\n");
        }
    }
}

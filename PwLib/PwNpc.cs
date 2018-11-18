using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwNpc : PwTargetable
    {
        public PwNpc(Character CHR) : base(CHR) {}
        public PwNpc(Character CHR, int ptr) : base(CHR, ptr) { }

        public new PwNpc Load()
        {
            id = Memory.RD(HNDL, ptr + OFS.GetInt("Mob_Id"));
            wid = Memory.RUD(HNDL, ptr + OFS.GetInt("Mob_WId"));
            type = Memory.RD(HNDL, ptr + OFS.GetInt("Mob_Type"));
            name = Memory.RS(HNDL, Memory.RD(HNDL, ptr + OFS.GetInt("Mob_Name")));
            distance = Memory.RF(HNDL, ptr + OFS.GetInt("Mob_Distance"));
            loc = new Location(Memory.RF(HNDL, ptr + OFS.GetInt("Mob_LocX")), Memory.RF(HNDL, ptr + OFS.GetInt("Mob_LocY")), Memory.RF(HNDL, ptr + OFS.GetInt("Mob_LocZ")));
            return this;
        }

        public void Interract(Boolean approach = false)
        {
            if (HNDL < 1 || wid < 1)
                return;
            if (approach)
            {
                Approach();
                Utils.RandomDelay(200, 500);
            }
            new Packet(HNDL, "23-00-00-00-00-00").Copy(wid, 2, 4).Send();
        }
    }
}

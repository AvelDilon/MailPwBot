using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwPlayer : PwTargetable
    {
        public int lvl = 0;
        public PwClass cls;

        public PwPlayer() : base() { }
        public PwPlayer(Character CHR) : base(CHR) { }
        public PwPlayer(Character CHR, int ptr) : base(CHR, ptr) { }

        public new PwPlayer Load()
        {
            id = Memory.RD(HNDL, ptr + OFS.GetInt("Player_ID"));
            cls = new PwClass(Memory.RD(HNDL, ptr + OFS.GetInt("Player_ClassId")));
            name = Memory.RS(HNDL, Memory.RD(HNDL, ptr + OFS.GetInt("PlayerName")));
            loc = new Location(Memory.RF(HNDL, ptr + OFS.GetInt("Player_LocX")), Memory.RF(HNDL, ptr + OFS.GetInt("Player_LocY")), Memory.RF(HNDL, ptr + OFS.GetInt("Player_LocZ")));
            CalculateDistance();
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class NPC
    {
        public int HNDL;

        public int id = 0;
        public uint wid = 0;
        public int ptr = -1;
        public int type;
        public float distance;
        public String name;
        public Location LOC;

        public NPC(int HNDL) { this.HNDL = HNDL; this.wid = 0; }
        public NPC(int HNDL, int ptr) { this.HNDL = HNDL; this.ptr = ptr; }

        public NPC Load()
        {
            id = Memory.RD(HNDL, ptr + OFS.GetInt("Mob_Id"));
            wid = Memory.RUD(HNDL, ptr + OFS.GetInt("Mob_WId"));
            type = Memory.RD(HNDL, ptr + OFS.GetInt("Mob_Type"));
            name = Memory.RS(HNDL, Memory.RD(HNDL, ptr + OFS.GetInt("Mob_Name")));
            distance = Memory.RF(HNDL, ptr + OFS.GetInt("Mob_Distance"));
            LOC = new Location(Memory.RF(HNDL, ptr + OFS.GetInt("Mob_LocX")), Memory.RF(HNDL, ptr + OFS.GetInt("Mob_LocY")), Memory.RF(HNDL, ptr + OFS.GetInt("Mob_LocZ")));
            return this;
        }

        public void Target()
        {
            if (HNDL < 1 || wid < 1)
                return;
            new Packet(HNDL, "02-00-01-00-00-00").Copy(wid, 2, 4).Send();
        }

        public void Interract()
        {
            if (HNDL < 1 || wid < 1)
                return;
            new Packet(HNDL, "23-00-00-00-00-00").Copy(wid, 2, 4).Send();
        }

        public void UseSkill(int id)
        {
            new Packet(HNDL, "29-00-2B-01-00-00-00-01-F9-16-10-80").Copy(id, 2, 4).Copy(wid, 8, 4).Send();
        }

        public void PetAttack()
        {
            new Packet(HNDL, "67-00-00-00-00-80-01-00-00-00-00").Copy(wid, 2, 4).Send();
        }
    }
}

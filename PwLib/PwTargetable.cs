using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwTargetable : PwWorldObject
    {
        public PwTargetable() : base() { }
        public PwTargetable(Character CHR) : base(CHR) { }
        public PwTargetable(Character CHR, int ptr) : base(CHR, ptr) { }

        public PwTargetable Target()
        {
            if (HNDL < 1 || wid < 1)
                return null;
            new Packet(HNDL, "02-00-01-00-00-00").Copy(wid, 2, 4).Send();
            return this;
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

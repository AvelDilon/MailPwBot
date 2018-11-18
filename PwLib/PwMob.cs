using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwMob : PwNpc
    {
        public PwMob(Character CHR) : base(CHR) { }
        public PwMob(Character CHR, int ptr) : base(CHR, ptr) { }

        public new PwMob Load()
        {
            PwMob nm = base.Load() as PwMob;
            return nm;
        }
    }
}

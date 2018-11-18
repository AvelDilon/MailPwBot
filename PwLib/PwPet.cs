using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwPet : PwNpc
    {
        PwPlayer owner;

        public PwPet(Character CHR) : base(CHR) { }
        public PwPet(Character CHR, int ptr) : base(CHR, ptr) { }

        public new PwPet Load()
        {
            PwPet np = base.Load() as PwPet;
            return np;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class PwObject
    {
        public int id;
        public uint wid;
        public int ptr;
        public int type;

        public int HNDL = -1;
        public Character CHR = null;
        public PwObject() { }
        public PwObject(Character CHR) { this.CHR = CHR; this.HNDL = CHR.HNDL; }
        public PwObject(Character CHR, int ptr) { this.CHR = CHR; this.HNDL = CHR.HNDL; this.ptr = ptr; }

        public virtual PwObject Load() { return this; }
    }
}

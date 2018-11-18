using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Item : PwObject
    {
        public String name = "NULL";
        public String desc = "NULL";

        public Item() : base() {}
        public Item(Character CHR) : base(CHR) {}
        public Item(Character CHR, int ptr) : base(CHR, ptr) {}
    }
}

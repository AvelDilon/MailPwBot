using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class ItemBeast : ItemInventory
    {
        public Boolean NeedIncube = false;
        public ItemBeast(Character CHR) : base(CHR) { }

        public static ItemBeast FromItem(ItemInventory i) { ItemBeast bi = new ItemBeast(i.CHR); bi.id = i.id; bi.count = i.count; return bi; }

        public void PutToBI() { new Packet(CHR.HNDL, "C7-00-00-00-00-00-00-00-00-00-00-00-00-00").Copy(id, 6, 4).Copy(count, 10, 4).Send(); Utils.RandomDelay(); }
        public void GetFromBI() { new Packet(CHR.HNDL, "C7-00-01-00-00-00-00-00-00-00-00-00-00-00").Copy(id, 6, 4).Copy(count, 10, 4).Send(); Utils.RandomDelay(); }

        public void Incube()
        {
            if (!NeedIncube)
                return;
            Packet P = new Packet(CHR.HNDL, "C0-00-32-15-00-00-10-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00");
            P.CopyR(CHR.ID, 14, 4);
            P.CopyR(CHR.ID, 18, 4);
            P.CopyR(id, 22, 4);
            P.Send();
            Utils.RandomDelay();
        }
    }
}

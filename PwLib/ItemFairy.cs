using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class ItemFairy : ItemInventory
    {
        public int lvl;
        public int fsc;
        public int P1;
        public int P2;

        public ItemFairy(Character CHR) { this.CHR = CHR; }

        public Boolean IsGood()
        {
            if (id > 0 && (lvl < CHR.GetClass<FairyFactory>().GOODNEES + 10 || (P2 - P1 < CHR.GetClass<FairyFactory>().GOODNEES && lvl < 100)))
                return true;
            return false;
        }

        public static ItemFairy LoadEquipedFairy(Character CHR)
        {
            ItemFairy NFI = new ItemFairy(CHR);
            NFI.id = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_EqFairy_Arr+Player_EqFairy_Id");
            NFI.lvl = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_EqFairy_Arr+Player_EqFairy_Lvl");
            NFI.fsc = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_EqFairy_Arr+Player_EqFairy_FSC");
            NFI.P1 = NFI.lvl < 10 ? 0 : NFI.fsc - NFI.lvl + 1;
            NFI.P2 = NFI.lvl < 10 ? 0 : (NFI.lvl / 10) * 10;
            NFI.place = 0x17;
            return NFI;
        }

        public static ItemFairy LoadInvFairy(ItemInventory i)
        {
            int FIA = Memory.RD(i.CHR.HNDL, i.ptr + OFS.GetInt("Inventory_Item_Fairy_INF"));
            ItemFairy NFI = new ItemFairy(i.CHR);
            NFI.id = i.id;
            NFI.place = i.place;
            NFI.lvl = FIA & 0xFF;
            NFI.fsc = (FIA >> 16) & 0xFF;
            NFI.P1 = NFI.lvl < 10 ? 0 : NFI.fsc - NFI.lvl + 1;
            NFI.P2 = NFI.lvl < 10 ? 0 : (NFI.lvl / 10) * 10;
            return NFI;
        }
    }
}

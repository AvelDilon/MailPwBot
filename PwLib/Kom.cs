using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class KomItem : Item
    {
        public KomItem(Character CHR) : base(CHR) { }
    }

    public class Kom
    {
        public Character CHR;
        public List<Item> BUY = new List<Item>();
        public List<Item> SELL = new List<Item>();
        public List<Item> STORE = new List<Item>();

        public Kom(Character CHR)
        {
            this.CHR = CHR;
            Load();
        }

        public void Load()
        {
            BUY.Clear();
            SELL.Clear();
            STORE.Clear();
            BUY = Inventory.LoadStruct(CHR, Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+P_Kom_Array+Kom_Buy"), 20);
            SELL = Inventory.LoadStruct(CHR, Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+P_Kom_Array+Kom_Sell"), 20);
            STORE = Inventory.LoadStruct(CHR, Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+P_Kom_Array+Kom_Store"), 40);
        }

    }
}

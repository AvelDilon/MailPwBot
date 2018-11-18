using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Inventory : UserClassObject
    {
        private int PTR;
        private int MAX_ITEMS;
        public List<ItemInventory> IL = new List<ItemInventory>();

        public Inventory(Character CHR) : base(CHR) { Load(); }

        public void Load()
        {
            IL.Clear();
            PTR = Memory.RD(CHR.HNDL, "BA+GA_OFS+PlayerStruct+Player_Inventory_Struct");
            MAX_ITEMS = Memory.RD(CHR.HNDL, PTR + OFS.GetInt("Inventory_MaxSize"));
            IL = ItemInventory.LoadStruct<ItemInventory>(CHR, Memory.RD(CHR.HNDL, PTR + OFS.GetInt("Inventory_Array")), MAX_ITEMS);
        }

        public int GetFirstFreePlace()
        {
            Load();
            foreach (ItemInventory i in IL)
                if (i.id == 0 || i.ptr == 0)
                    return i.place;
            return -1;
        }

        public int GetFreeCount()
        {
            Load();
            int FC = 0;
            foreach (ItemInventory i in IL)
                if (i.id == 0 || i.ptr == 0)
                    FC++;
            return FC;
        }

        public Boolean HasItemsFromList(int[] ids)
        {
            Organize();
            foreach (ItemInventory i in IL)
                if (ids.Contains(i.id))
                    return true;
            return false;
        }

        public int GetCountById(int id)
        {
            Load();
            int sum = 0;
            foreach (ItemInventory i in IL)
                if (i.id == id)
                    sum += i.count;
            return sum;
        }

        public ItemInventory GetFirstById(int id)
        {
            Load();
            foreach (ItemInventory i in IL)
                if (i.id == id)
                    return i;
            return null;
        }

        public void MoveItem(int FROM_PLACE, int TO_PLACE)
        {
            Packet P = new Packet(CHR.HNDL, "0C-00-FF-FF");
            P.Copy(FROM_PLACE, 2, 1);
            P.Copy(TO_PLACE, 3, 1);
            P.Send();
            System.Threading.Thread.Sleep(500);
            Load();
        }

        public void MoveItemOver(int FROM_PLACE, int TO_PLACE, int count)
        {
            Packet P = new Packet(CHR.HNDL, "0D-00-FF-FF-FF-FF-FF-FF");
            P.Copy(FROM_PLACE, 2, 1);
            P.Copy(TO_PLACE, 3, 1);
            P.Copy(count, 4, 4);
            P.Send();
            System.Threading.Thread.Sleep(500);
            Load();
        }

        public void Organize()
        {
            Load();
            ItemInventory[] l = new ItemInventory[MAX_ITEMS];
            foreach (ItemInventory i in IL)
                l[i.place] = i;
            for (int i = 0; i < MAX_ITEMS; i++)
                if (l[i].id > 0 && l[i].max_count > l[i].count)
                    for (int j = i + 1; j < MAX_ITEMS; j++)
                        if (l[j].id == l[i].id)
                            MoveItemOver(l[j].place, l[i].place, (l[i].max_count - l[i].count >= l[j].count ? l[j].count : l[i].max_count - l[i].count));
        }
    }
}

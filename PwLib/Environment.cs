using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Environment : UserClassObject
    {
        public List<PwWorldObject> EL = new List<PwWorldObject>();

        public Environment(Character CHR) : base(CHR) { Scan(); }

        public void Scan()
        {
            EL.Clear();
            CHR.LoadLocation();
            ScanNPC();
            ScanLoot();
            ScanPlayers();
        }

        private void ScanNPC()
        {
            int MP = Memory.RD(CHR.HNDL, "BA+GA_OFS+MS_OFS+Mob_Struct");
            int COUNT = Memory.RD(CHR.HNDL, MP + OFS.GetInt("Mob_Count"));
            int MA = Memory.RD(CHR.HNDL, MP + OFS.GetInt("Mob_Array"));
            if (COUNT == 0)
                return;
            for (int i = 0; i < COUNT; i++)
            {
                int PTR = Memory.RD(CHR.HNDL, MA + i * 0x4);
                int TYPE = Memory.RD(CHR.HNDL, PTR + OFS.GetInt("Mob_Type"));
                switch (TYPE)
                {
                    case 7:
                        EL.Add(new PwNpc(CHR, PTR).Load());
                        break;
                    case 6:
                        EL.Add(new PwMob(CHR, PTR).Load());
                        break;
                    case 9:
                        EL.Add(new PwPet(CHR, PTR).Load());
                        break;
                    default:
                        EL.Add(new PwNpc(CHR, PTR).Load());
                        break;
                }
            }
        }

        private void ScanLoot()
        {
            int LP = Memory.RD(CHR.HNDL, "BA+GA_OFS+MS_OFS+Loot_Struct");
            int LA = Memory.RD(CHR.HNDL, LP + OFS.GetInt("Loot_Array"));
            int COUNT = Memory.RD(CHR.HNDL, LP + OFS.GetInt("Loot_Count"));
            if (COUNT == 0)
                return;
            for (int i = 0; i < 0x300; i++)
            {
                int PTR = Memory.RD(CHR.HNDL, Memory.RD(CHR.HNDL, LA + i * 0x4) + 0x4);
                if (PTR == 0)
                    continue;
                int TYPE = Memory.RD(CHR.HNDL, PTR + OFS.GetInt("Loot_Type"));
                if (TYPE == 2)
                    EL.Add(new PwMine(CHR, PTR).Load());
                else
                    EL.Add(new ItemLoot(CHR, PTR).Load());
            }
        }

        private void ScanPlayers()
        {
            int PP = Memory.RD(CHR.HNDL, "BA+GA_OFS+MS_OFS+Players_Struct");
            int PA = Memory.RD(CHR.HNDL, PP + OFS.GetInt("Players_Array"));
            int COUNT = Memory.RD(CHR.HNDL, PP + OFS.GetInt("Players_Count"));
            if (COUNT == 0)
                return;
            for (int i = 0; i < COUNT; i++)
                EL.Add(new PwPlayer(CHR, Memory.RD(CHR.HNDL, PA + i * 0x4)).Load());
        }

        public List<T> GetList<T>(Boolean order_by_distance = false) where T : class
        {
            List<T> r = new List<T>();
            foreach (PwWorldObject i in EL)
                if (i.GetType().Equals(typeof(T)))
                    r.Add(i as T);
            return order_by_distance ? r.OrderBy(o => (o as PwWorldObject).distance).ToList() : r;
        }

        public T GetClosest<T>() where T : class
        {
            if (!typeof(T).IsSubclassOf(typeof(PwWorldObject)))
                return null;
            List<T> L = GetList<T>(true);
            if (L.Count == 0)
                return null;
            return L.First<T>();
        }

        public T TargetClosest<T>() where T : class
        {
            if (!typeof(T).IsSubclassOf(typeof(PwTargetable)))
                return null;
            T cn = GetClosest<T>();
            if (cn == null || (cn as PwTargetable).id == 0)
                return null;
            (cn as PwTargetable).Target();
            return cn;
        }

        public PwTargetable TargetById(int id)
        {
            foreach (PwObject n in EL)
                if (n.id == id && n.GetType().IsSubclassOf(typeof(PwTargetable)))
                    return (n as PwTargetable).Target();
            return null;
        }

        public PwTargetable TargetByWId(uint wid)
        {
            foreach (PwObject n in EL)
                if (n.wid == wid && n.GetType().IsSubclassOf(typeof(PwTargetable)))
                    return (n as PwTargetable).Target();
            return null;
        }

        public PwTargetable TargetByName(String name)
        {
            foreach (PwTargetable n in EL)
                if (n.GetType().IsSubclassOf(typeof(PwTargetable)) && n.name.Equals(name))
                    return (n as PwTargetable).Target();
            return null;
        }
    }
}

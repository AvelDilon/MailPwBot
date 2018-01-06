using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Environment
    {
        private Character CHR;
        public List<NPC> NPC_LIST = new List<NPC>();
        public List<Item> LOOT_LIST = new List<Item>();

        public Environment(Character CHR) { this.CHR = CHR; Scan(); }

        public void Scan()
        {
            ScanNPC();
            ScanLoot();
        }

        public void ScanNPC()
        {
            int MP = Memory.RD(CHR.HNDL, "BA+GA_OFS+MS_OFS+Mob_Struct");
            int COUNT = Memory.RD(CHR.HNDL, MP + OFS.GetInt("Mob_Count"));
            int MA = Memory.RD(CHR.HNDL, MP + OFS.GetInt("Mob_Array"));
            NPC_LIST.Clear();
            if (COUNT == 0)
                return;
            for (int i = 0; i < COUNT; i++)
                NPC_LIST.Add(new NPC(CHR.HNDL, Memory.RD(CHR.HNDL, MA + i * 0x4)).Load());
        }

        public void ScanLoot()
        {
            int LP = Memory.RD(CHR.HNDL, "BA+GA_OFS+MS_OFS+Loot_Struct");
            int LA = Memory.RD(CHR.HNDL, LP + OFS.GetInt("Loot_Array"));
            int COUNT = Memory.RD(CHR.HNDL, LP + OFS.GetInt("Loot_Count"));
            LOOT_LIST.Clear();
            if (COUNT == 0)
                return;
            for (int i = 0; i < 0x300; i++)
            {
                Item it = new Item(CHR, Memory.RD(CHR.HNDL, Memory.RD(CHR.HNDL, LA + i * 0x4) + 0x4));
                if (it.ptr == 0)
                    continue;
                it.LoadLootItem();
                LOOT_LIST.Add(it);
            }
        }

        public NPC GetClosestNpc(int type = 7)
        {
            Scan();
            NPC cn = new NPC(CHR.HNDL);
            cn.distance = 1000;
            foreach (NPC n in NPC_LIST)
                cn = n.distance < cn.distance ? n : cn;
            return cn;
        }

        public NPC TargetClosest(int type = 7)
        {
            NPC cn = GetClosestNpc(type);
            if (cn.id == 0)
                return cn;
            cn.Target();
            return cn;
        }

        public NPC TargetById(int id)
        {
            Scan();
            foreach (NPC n in NPC_LIST)
                if (n.id == id)
                {
                    n.Target();
                    return n;
                }
            return new NPC(CHR.HNDL);
        }

        public NPC TargetByName(String name)
        {
            Scan();
            foreach (NPC n in NPC_LIST)
                if (n.name.Equals(name))
                {
                    n.Target();
                    return n;
                }
            return new NPC(CHR.HNDL);
        }
    }
}

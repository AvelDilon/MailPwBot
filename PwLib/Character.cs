using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Character
    {
        public int HNDL;
        public Client CLNT;
        public int CSP;
        public Boolean INGAME = false;
        public String Name;
        public int ID;
        public int LOC_ID;
        public String LOC_NAME = "N/A";
        public Location LOC;
        private List<UserClassObject> UCO = new List<UserClassObject>();
        private Dictionary<String, Object> VRS = new Dictionary<String, Object>();

        public Character(Client CLNT)
        {
            this.CLNT = CLNT;
            this.HNDL = CLNT.HNDL;
            Load();
        }

        public void Load()
        {
            CSP = Memory.RD(HNDL, "BA+GA_OFS+PlayerStruct");
            Name = Memory.RS(HNDL, Memory.RD(HNDL, CSP + OFS.GetInt("PlayerName")));
            INGAME = Name.Trim().Length > 0;
            Name = INGAME ? Name : "N/A";
            ID = Memory.RD(HNDL, CSP + OFS.GetInt("Player_ID"));
            LoadVars();
            LoadLocation();
            LoadUserClasses();
        }

        public T AddClass<T>(T o) where T : class
        {
            if (!typeof(T).IsSubclassOf(typeof(UserClassObject)))
                return null;
            UserClassObject AO = o as UserClassObject;
            AO.TOT = o.GetType();
            UCO.Add(AO);
            return AO as T;
        }

        public T GetClass<T>() where T : class
        {
            if (!typeof(T).IsSubclassOf(typeof(UserClassObject)))
                return null;
            foreach (UserClassObject o in UCO)
                if (typeof(T).Equals(o.TOT))
                    return o as T;
            return null;
        }

        public void AddVar(String name, Object o)
        {
            VRS.Add(name, o);
        }

        public dynamic GetVar(String name)
        {
            return VRS[name];
        }

        public void LoadUserClasses()
        {
            UCO.Clear();
            AddClass<Inventory>(new Inventory(this));
            AddClass<AutoItemOpen>(new AutoItemOpen(this));
            AddClass<FairyFactory>(new FairyFactory(this));
            AddClass<BeastFactory>(new BeastFactory(this));
            AddClass<Environment>(new Environment(this));
            AddClass<GUI>(new GUI(this));
        }

        public void LoadVars()
        {
            VRS.Clear();
            AddVar("LVL", Memory.RD(HNDL, CSP + OFS.GetInt("Player_Lvl")));
            AddVar("WalkMode", Convert.ToByte(Memory.RD(HNDL, CSP + OFS.GetInt("Player_WalkMode"))));
        }

        public Location LoadLocation()
        {
            LOC = new Location(Memory.RF(HNDL, CSP + OFS.GetInt("Player_LocX")), Memory.RF(HNDL, CSP + OFS.GetInt("Player_LocY")), Memory.RF(HNDL, CSP + OFS.GetInt("Player_LocZ")));
            LOC_ID = Memory.RD(HNDL, "BA+GA_OFS+MS_OFS+LOCATION_ID");
            return LOC;
        }

        public void TargetOff() { new Packet(HNDL, "08-00").Send(); }

        public void Fly()
        {
            int FlyId = Memory.RD(HNDL, CSP + OFS.GetInt("Player_FlyId"));
            if(FlyId > 0)
                new Packet(HNDL, "28-00-01-01-0C-00-FF-FF-FF-FF").Copy(FlyId, 6, 4).Send();
        }

        public void CallPet(byte nom)
        {
            new Packet(HNDL, "64-00-01-00-00-00").Copy(nom, 2, 1).Send();
        }

        public void Sell(ItemInventory i, int count)
        {
            Packet P = new Packet(HNDL, "25-00-02-00-00-00-10-00-00-00-01-00-00-00-FF-FF-00-00-FF-00-00-00-D0-07-00-00");
            P.Copy(i.place, 18, 1);
            P.Copy(count, 22, 4);
            P.Copy(i.id, 14, 4);
            P.Send();
        }

        public void Buy(byte NPCcell, int kol, int ID)
        {
            Packet P = new Packet(HNDL, "25-00-01-00-00-00-28-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-01-00-00-00-A5-21-00-00-06-00-00-00-01-00-00-00");
            P.Copy(NPCcell, 42, 1);
            P.Copy(kol, 46, 4);
            P.Copy(ID, 38, 4);
            P.Send();
        }

        public void Repair() { new Packet(HNDL, "25-00-03-00-00-00-06-00-00-00-FF-FF-FF-FF-00-00").Send(); }
        public void Res() { new Packet(HNDL, "04-00").Send(); }

        public void EnterHome(Boolean wait = true)
        {
            LoadLocation();
            if (LOC_ID == 180)
                return;
            Packet P = new Packet(HNDL, "C4-00-FF-FF-FF-FF-FF-FF-FF-FF-01-00-00-00");
            P.Copy(this.ID, 2, 4);
            P.Copy(this.ID, 6, 4);
            P.Send();
            while(wait && LOC_ID != 180)
            {
                LoadLocation();
                Utils.RandomDelay();
            }
        }

        public void ExitHome()
        {
            LoadLocation();
            if (LOC_ID == 180)
                new Packet(HNDL, "C1-00-02").Send();
        }

        public void Move(Location loc, Boolean wait = false, double accuracy = 0.5)
        {
            byte[] WP =
            {
                0x60,                                       //pushad
                0xB8, /*2*/0x00, 0x00, 0x00, 0x00,          //mov eax, BA
                0x8B, 0x00,                                 //mox eax, [eax]
                0x8B, 0x40, 0x1C,                           //mov eax, [eax + 1C]
                0x8B, 0x70, 0x34,                           //mov esi, [eax + 0x34]
                0x8B, 0x8E, 0x00, 0x00, 0x00, 0x00,         //mov ecx, [esi + ACTION]
                0x6A, 0x01,                                 //push 1
                0xB8, /*23*/0x00, 0x00, 0x00, 0x00,         //mov eax, action_1
                0xFF, 0xD0,                                 //call eax
                0x8D, 0x54, 0x24, 0x38,                     //lea edx, [esp + 0x38]
                0x8B, 0xD8,                                 //mov ebx, eax
                0x52,                                       //push edx
                0x6A, /*37*/0x00,                           //push walk_mode
                0x8B, 0xCB,                                 //mov ecx, ebx
                0xB8, /*41*/0x00, 0x00, 0x00, 0x00,         //mov eax, action_2
                0xFF, 0xD0,                                 //call eax
                0x8B, 0x8E, 0x00, 0x00, 0x00, 0x00,         //mov ecx, [esi + ACTION]
                0xB8, /*54*/0x00, 0x00, 0x00, 0x00,         //mov eax, x
                0x89, 0x43, 0x20,                           //mov [ebx + 0x20], eax
                0xB8, /*62*/0x00, 0x00, 0x00, 0x00,         //mov eax, z
                0x89, 0x43, 0x24,                           //mov [ebx + 0x24], eax
                0xB8, /*70*/0x00, 0x00, 0x00, 0x00,         //mov eax, y
                0x89, 0x43, 0x28,                           //mov [ebx + 0x28], eax
                0x6A, 0x00,                                 //push 0
                0x53,                                       //push ebx
                0x6A, 0x01,                                 //push 1
                0xB8, /*83*/0x00, 0x00, 0x00, 0x00,         //mov eax, action_3
                0xFF, 0xD0,                                 //call eax
                0x61, 0xC3                                  //popad, ret
            };
            Packet P = new Packet(HNDL, WP);
            P.Copy(OFS.BA, 2, 4);
            P.Copy(OFS.GetUInt("Player_Action_Struct"), 16, 4);
            P.Copy(OFS.GetUInt("Player_Action_Struct"), 49, 4);
            P.Copy(OFS.GetUInt("action_1"), 23, 4);
            P.Copy(OFS.GetUInt("action_2"), 41, 4);
            P.Copy(OFS.GetUInt("action_3"), 83, 4);
            P.Copy(loc.x, 54, 4);
            P.Copy(loc.y, 70, 4);
            P.Copy(loc.z, 62, 4);
            if(GetVar("WalkMode") == 2)
                P.Copy(GetVar("WalkMode"), 37, 1);
            P.Execute();
            if (wait)
                while (LOC.GetDistance(loc) > accuracy)
                {
                    LoadLocation();
                    System.Threading.Thread.Sleep(200);
                }
        }
    }
}

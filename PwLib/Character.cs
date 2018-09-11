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
        public Inventory INV;
        public Fairy FAIRY;
        public Environment ENV;
        public GUI WND;
        public BeastFactory MBF;
        public String Name;
        public int ID;
        public int LOC_ID;
        public int LVL;
        public String LOC_NAME = "N/A";
        public Location LOC;
        public Kom KO;

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
            LVL = Memory.RD(HNDL, CSP + OFS.GetInt("Player_Lvl"));
            LoadLocation();
            INV = new Inventory(this);
            FAIRY = new Fairy(this);
            ENV = new Environment(this);
            WND = new GUI(this);
            MBF = new BeastFactory(this);
            KO = new Kom(this);
        }

        public void LoadLocation()
        {
            LOC = new Location(Memory.RF(HNDL, CSP + OFS.GetInt("Player_LocX")), Memory.RF(HNDL, CSP + OFS.GetInt("Player_LocY")), Memory.RF(HNDL, CSP + OFS.GetInt("Player_LocZ")));
            LOC_ID = Memory.RD(HNDL, "BA+GA_OFS+MS_OFS+LOCATION_ID");
        }

        public void TargetOff() { new Packet(HNDL, "08-00").Send(); }

        public void Fly()
        {
            int FlyId = Memory.RD(HNDL, CSP + OFS.GetInt("Player_FlyId"));
            new Packet(HNDL, "28-00-01-01-0C-00-FF-FF-FF-FF").Copy(FlyId, 6, 4).Send();
        }

        public void CallPet(byte nom)
        {
            new Packet(HNDL, "64-00-01-00-00-00").Copy(nom, 2, 1).Send();
        }

        public void Sell(Item i, int count)
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
                0x8B, 0x00,                                 //mox eax, dword ptr [eax]
                0x8B, 0x40, 0x1C,                           //mov eax, dword ptr[eax + 1C]
                0x8B, 0x78, 0x34,                           //mov edi, dword ptr[eax + 0x34]
                0x8B, 0x8F, 0xC4, 0x15, 0x00, 0x00,         //mov ecx, dword ptr[edi + 0x154C]
                0x6A, 0x01,                                 //push 1
                0xB8, /*23*/0x00, 0x00, 0x00, 0x00,         //mov eax, action_1
                0xFF, 0xD0,                                 //call eax
                0x8D, 0x54, 0x24, 0x1C,                     //lea edx, dword ptr[esp + 0x1C]
                0x8B, 0xD8,                                 //mov ebx, eax
                0x52,                                       //push edx
                0x68, /*37*/0x00, 0x00, 0x00, 0x00,         //push walk_mode
                0x8B, 0xCB,                                 //mov ecx, ebx
                0xB8, /*44*/0x00, 0x00, 0x00, 0x00,         //mov eax, action_2
                0xFF, 0xD0,                                 //call eax
                0x8B, 0x8F, 0xC4, 0x15, 0x00, 0x00,         //mov ecx, dword ptr [edi + 0x154C]
                0xB8, /*57*/0x00, 0x00, 0x00, 0x00,         //mov eax, x
                0x89, 0x43, 0x20,                           //mov dword ptr[ebx + 0x20], eax
                0xB8, /*65*/0x00, 0x00, 0x00, 0x00,         //mov eax, z
                0x89, 0x43, 0x24,                           //mov dword ptr[ebx + 0x24], eax
                0xB8, /*73*/0x00, 0x00, 0x00, 0x00,         //mov eax, y
                0x89, 0x43, 0x28,                           //mov dword ptr[ebx + 0x28], eax
                0x6A, 0x00,                                 //push 0
                0x53,                                       //push ebx
                0x6A, 0x01,                                 //push 1
                0xB8, /*86*/0x00, 0x00, 0x00, 0x00,         //mov eax, action_3
                0xFF, 0xD0,                                 //call eax
                0x61,                                       //popad
                0xC3                                        //ret
            };
            Packet P = new Packet(HNDL, WP);
            P.Copy(OFS.BA, 2, 4);
            P.Copy(OFS.GetUInt("Player_Action_Struct"), 16, 4);
            P.Copy(OFS.GetUInt("Player_Action_Struct"), 52, 4);
            P.Copy(OFS.GetUInt("action_1"), 23, 4);
            P.Copy(OFS.GetUInt("action_2"), 44, 4);
            P.Copy(OFS.GetUInt("action_3"), 86, 4);
            P.Copy(loc.x, 57, 4);
            P.Copy(loc.y, 73, 4);
            P.Copy(loc.z, 65, 4);
            int WalkMode = Memory.RD(HNDL, CSP + OFS.GetInt("Player_WalkMode"));
            P.Copy(WalkMode > 0 ? 1 : 0, 37, 4);
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

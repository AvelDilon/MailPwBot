using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    public class Client
    {
        public static List<Client> CL = new List<Client>();
        public static Client CC = null;
        public static String SERVER = "altair";

        public int PID = -1;
        public int HNDL;
        public String Title = "";
        public Character CHR;

        public static void Init()
        {
            Finish();
            Process[] p = Process.GetProcessesByName("elementclient");
            if (p == null)
                return;
            if (p.Length > 0)
                for (int i = 0; i < p.Length; i++)
                {
                    Client n = new Client();
                    n.PID = p[i].Id;
                    n.Title = p[i].MainWindowTitle;
                    n.Load();
                    CL.Add(n);
                }
            if (CL.Count > 0)
                CC = CL.First();
        }

        public static void Finish()
        {
            foreach (Client C in CL)
                EF.CloseHandle(C.HNDL);
            CL.Clear();
        }

        public static Client GetByTitle(String title)
        {
            Init();
            foreach (Client IC in CL)
                if (IC.Title.Equals(title))
                    return IC;
            return null;
        }

        public void Load()
        {
            if (PID == 0)
                return;
            HNDL = EF.OpenProcess(2035711, false, PID);
            CHR = new Character(this);
        }

        public Boolean WaitEnterTheGame(int time_sec = 30)
        {
            DateTime WU = DateTime.Now.AddSeconds(time_sec);
            do
            {
                if (DateTime.Now.CompareTo(WU) > 0)
                    return false;
                EF.CloseHandle(HNDL);
                Load();
                Utils.Delay(500);
            }
            while (!CHR.INGAME);
            return true;
        }

        public Boolean IsRun()
        {
            uint R = 0;
            EF.GetExitCodeProcess(HNDL, out R);
            return R == 259;
        }

        public void Halt()
        {
            EF.TerminateProcess(HNDL, 0);
        }
    }
}

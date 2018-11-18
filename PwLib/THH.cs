using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwLib
{
    public class THH
    {
        public static Dictionary<String, Thread> THL = new Dictionary<String, Thread>();

        public static void StartNewThread(ThreadStart P, string TName, Action CallBack = null)
        {
            if (THL.Keys.Contains(TName))
                return;
            P += () => { THH.SelfStop(TName); CallBack?.Invoke(); };
            Thread CT = new Thread(P) { Name = TName };
            THL.Add(TName, CT);
            CT.Start();
        }

        public static void StopThread(string Name)
        {
            if (THL.Keys.Contains(Name))
            {
                THL[Name].Abort();
                THL.Remove(Name);
            }
        }

        public static void SelfStop(string Name)
        {
            if (THL.Keys.Contains(Name))
                THL.Remove(Name);
        }

        public static void StopAll()
        {
            foreach (Thread t in THL.Values)
                t.Abort();
        }
    }
}

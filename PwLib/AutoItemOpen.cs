using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwLib
{
    public class AutoItemOpen : UserClassObject
    {
        public int item = -1;
        public int delay = 1;
        public bool IsRun = false;

        public AutoItemOpen(Character CHR) : base(CHR) { }

        public void OpenItem()
        {
            //CHR.GetClass<Inventory>().Load();
            ItemInventory UI = CHR.GetClass<Inventory>().GetFirstById(item);
            if (UI == null)
                return;
            UI.Use();
            Utils.RandomDelay(delay * 1000 - 300, (delay + 1) * 1000 + 300);
            OpenItem();
        }

        public void Run()
        {
            IsRun = true;
            THH.StartNewThread(new ThreadStart(OpenItem), "AutoOpen:" + CHR.Name);
        }

        public void Stop()
        {
            THH.StopThread("AutoOpen:" + CHR.Name);
            IsRun = false;
        }
    }
}

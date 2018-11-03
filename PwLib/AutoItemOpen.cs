using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwLib
{
    public class AutoItemOpen
    {
        public int item = 1;
        public int delay = 1;
        public bool IsRun;
        public Character CHR;

        public AutoItemOpen(Character CHR, int item, int delay)
        {
            this.CHR = CHR;
            this.item = item;
            this.delay = delay;
        }

        public void OpenItem()
        {
            CHR.INV.Load();
            Item UI = CHR.INV.GetFirstById(item);
            if (UI == null)
                return;
            UI.Use();
            Utils.RandomDelay(delay * 1000 - 300, (delay + 1) * 1000 + 300);
            this.OpenItem();
        }

        public void RunAutoOpen()
        {
            this.IsRun = true;
            THH.StartNewThread(new ThreadStart(this.OpenItem), "AutoShop:" + this.CHR.Name);
        }
    }
}

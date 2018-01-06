using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwLib
{
    public class Utils
    {
        public static void Delay(int msec) { Thread.Sleep(msec); }

        public static void RandomDelay(int from = 500, int to = 1000)
        {
            Delay(new Random().Next(from, to));
        }
    }
}

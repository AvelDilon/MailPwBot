using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PwBot
{
    class Utils
    {
        public static void Delay(int msec) { Thread.Sleep(msec); }

        public static void RandomDelay(int from = 500, int to = 1000)
        {
            Delay(new Random().Next(from, to));
        }

        public static int  GetOS_X_Fix()
        {
            return System.Environment.OSVersion.Version.Major.ToString().Equals("10") ? 7 : 0;
        }
    }
}

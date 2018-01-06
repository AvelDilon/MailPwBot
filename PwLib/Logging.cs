using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Logging
    {
        private static String LF = @"log.txt";
        private static Boolean busy = false;

        public static void Log(String msg, String CLS = "")
        {
            while (busy)
                Utils.Delay(10);
            busy = true;
            try
            {
                String date = DateTime.Now.ToString("dd.MM.yyyy [HH:mm:ss]");
                StreamWriter GL = new StreamWriter(LF, true);
                GL.WriteLine(date + (CLS.Length > 0 ? " {" + CLS + "} => " : " => ") + msg + "\n");
                GL.Close();
                if (CLS.Length > 0)
                {
                    StreamWriter CL = new StreamWriter("log_" + CLS + ".txt", true);
                    CL.WriteLine(date + " => " + msg + "\n");
                    CL.Close();
                }
            }
            catch { }
            busy = false;
        }
    }
}

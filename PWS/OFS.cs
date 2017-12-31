using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PwBot
{
    class OFS
    {
        private static Dictionary<String, String> OFSL = new Dictionary<String, String>();

        private static void Put(String key, String value) { OFSL.Add(key, value); }
        public static String Get(String key) { return OFSL.ContainsKey(key) ? OFSL[key] : key; }
        public static int GetInt(String key) { return Convert.ToInt32(Get(key), 16); }
        public static uint GetUInt(String key) { return Convert.ToUInt32(Get(key), 16); }
        private static void Empty() { OFSL.Clear(); }

        public static int BA = 0;
        public static int PA = 0;

        public static void Init()
        {
            Empty();
            //TODO: DEBUG
            //if (!ReadFromWeb())
                ReadLocalFile();
            BA = GetInt("BA");
            PA = GetInt("SendPacket");
        }

        public static void ReadLocalFile()
        {
            String RL;
            System.IO.StreamReader SF = new System.IO.StreamReader(@"OFS.ini");
            while ((RL = SF.ReadLine()) != null)
            {
                RL = RL.Trim();
                if (RL.Length == 0 || RL[0].Equals('/') || RL[0].Equals('#'))
                    continue;
                String[] RA = Regex.Split(RL, @"\s");
                if (RA.Length > 1)
                    Put(RA[0], RA[RA.Length - 1]);
            }
        }

        public static Boolean ReadFromWeb()
        {
            Web wr = new Web("https://raw.githubusercontent.com/AvelDilon/MailPwBot/master/PWS/OFS.ini");
            wr.Get().SplitOnBlocks("\n");
            Dictionary<String, String> OL = new Dictionary<String, String>();
            foreach(String L in wr.blocks)
            {
                String RL = L.Trim();
                if (RL.Length == 0 || RL[0].Equals('/') || RL[0].Equals('#'))
                    continue;
                String[] RA = Regex.Split(RL, @"\s");
                if (RA.Length > 1)
                    OL.Add(RA[0], RA[RA.Length - 1]);
            }
            if(OL.ContainsKey("BA") && OL.ContainsKey("SendPacket"))
            {
                OFSL = OL;
                return true;
            }
            return false;
        }

        public static String COFS(String OL)
        {
            List<String> b = new List<String>();
            foreach (String c in OL.Split('+'))
                b.Add(Get(c));
            return String.Join("+", b);
        }
    }
}

using PwLib.PwDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Config
    {
        public static String Get(String var)
        {
            ConfigTableAdapter CTA = new ConfigTableAdapter();
            return CTA.GetOne(var);
        }

        public static void Set(String var, String val)
        {
            ConfigTableAdapter CTA = new ConfigTableAdapter();
            if (CTA.GetCount(var) == 0)
                CTA.Insert(var, val);
            else
                CTA.Upd(val, var);
        }

        public static int GetInt(String var) { try { return Int32.Parse(Get(var)); } catch { } return -1; }
        public static void SetInt(String var, int val) { Set(var, val.ToString()); }

        public static uint GetUInt(String var) { try { return UInt32.Parse(Get(var)); } catch { } return 0; }
        public static void SetUInt(String var, uint val) { Set(var, val.ToString()); }

        public static Boolean GetBool(String var) { try { return Boolean.Parse(Get(var)); } catch { } return false; }
        public static void SetBool(String var, Boolean val) { Set(var, val.ToString()); }
    }
}

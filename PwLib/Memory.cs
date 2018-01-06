using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    class Memory
    {
        public static int WD(int HNDL, int PTR, int value)
        {
            byte[] buffer = new byte[4];
            int[] vv = new int[1] { value };
            Buffer.BlockCopy(vv, 0, buffer, 0, 4);
            int write = 0;
            EF.WriteProcessMemory(HNDL, PTR, buffer, 4, ref write);
            return write;
        }

        public static int RD(int HNDL, int PTR)
        {
            byte[] buffer = new byte[4];
            int read = 0;
            EF.ReadProcessMemory(HNDL, PTR, buffer, 4, ref read);
            return BitConverter.ToInt32(buffer, 0);
        }

        public static uint RUD(int HNDL, int PTR) { return (uint)RD(HNDL, PTR); }

        public static String RS(int HNDL, int PTR, int size = 64, Boolean IsUnicode = true)
        {
            byte[] buffer = new byte[size];
            int read = 0;
            EF.ReadProcessMemory(HNDL, PTR, buffer, size, ref read);
            if (!IsUnicode)
            {
                int c = 0;
                for (int i = 0; i < size; i++)
                    if (buffer[i] == 0)
                        break;
                    else
                        c++;
                byte[] cb = new byte[c];
                Buffer.BlockCopy(buffer, 0, cb, 0, c);
                return System.Text.Encoding.Default.GetString(cb);
            }
            else
            {
                char[] cb = new char[size / 2];
                Buffer.BlockCopy(buffer, 0, cb, 0, (int)size);
                int c = 0;
                for (int i = 0; i < size / 2; i++)
                    if (cb[i] == 0)
                        break;
                    else
                        c++;
                char[] str = new char[c];
                Buffer.BlockCopy(cb, 0, str, 0, c * 2);
                return new String(str);
            }
        }

        public static float RF(int HNDL, int PTR)
        {
            byte[] buffer = new byte[4];
            int read = 0;
            EF.ReadProcessMemory(HNDL, PTR, buffer, 4, ref read);
            float[] lc = new float[1];
            Buffer.BlockCopy(buffer, 0, lc, 0, 4);
            return lc[0];
        }

        public static int RD(int HNDL, string PTRL)
        {
            string[] ss = OFS.COFS(PTRL).Split('+');
            int LPTR = RD(HNDL, (int)Convert.ToUInt32(ss[0].Trim(), 16));
            for (int i = 1; i < ss.Length; i ++)
                LPTR = RD(HNDL, LPTR + Convert.ToInt32(ss[i].Trim(), 16));
            return LPTR;
        }

        public static int RD(int HNDL, int START_PTR, string PTRL)
        {
            string[] ss = OFS.COFS(PTRL).Split('+');
            int LPTR = START_PTR;
            for (int i = 0; i < ss.Length; i++)
                LPTR = RD(HNDL, LPTR + Convert.ToInt32(ss[i].Trim(), 16));
            return LPTR;
        }

        public static String RS(int HNDL, string PTRL, int size = 64, Boolean IsUnicode = true)
        {
            return RS(HNDL, (int)RD(HNDL, PTRL), size, IsUnicode);
        }

        public static int CRD(int PTR) { return RD(Client.CC.HNDL, PTR); }
        public static String CRS(int PTR, int size = 32, Boolean IsUnicode = true) { return RS(Client.CC.HNDL, PTR, size, IsUnicode); }
        public static int CRD(string PTRL) { return RD(Client.CC.HNDL, PTRL); }
        public static String CRS(string PTRL, int size = 32, Boolean IsUnicode = true) { return RS(Client.CC.HNDL, PTRL, size, IsUnicode); }
    }
}

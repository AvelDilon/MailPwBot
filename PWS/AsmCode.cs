using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    public class AsmCode<T> where T: AsmCode<T>
    {
        protected int HNDL = 0;
        public CODE CD;

        public struct CODE
        {
            public int LENGTH;
            public byte[] DATA;
        }

        public AsmCode(int HNDL, byte[] data)
        {
            CD = new CODE();
            CD.DATA = data;
            CD.LENGTH = data.Length;
            this.HNDL = HNDL;
        }

        public AsmCode(int HNDL, string data)
        {
            CD = new CODE();
            CD.DATA = STBA(data);
            CD.LENGTH = CD.DATA.Length;
            this.HNDL = HNDL;
        }

        static byte[] STBA(string str)
        {
            string[] ss = str.Split('-');
            byte[] bytes = new byte[ss.Length];
            for (int i = 0; i < ss.Length; i++)
                bytes[i] = Convert.ToByte(ss[i], 16);
            return bytes;
        }

        public void DeBug()
        {
            Debug.LOG("-===== CODE DEBUG =====-");
            Debug.LOG("LENGTH: " + CD.LENGTH);
            Debug.LOG("DATA: " + BitConverter.ToString(CD.DATA));
        }

        public T Copy(byte[] data, int offset, int byte_count) { Buffer.BlockCopy(data, 0, CD.DATA, offset, byte_count); return (T)this; }
        public T CopyR(byte[] data, int offset, int byte_count) { Array.Reverse(data); return Copy(data, offset, byte_count); }
        public T Copy(int data, int offset, int byte_count) { return Copy(BitConverter.GetBytes(data), offset, byte_count); }
        public T CopyR(int data, int offset, int byte_count) { return CopyR(BitConverter.GetBytes(data), offset, byte_count); }
        public T Copy(uint data, int offset, int byte_count) { return Copy(BitConverter.GetBytes(data), offset, byte_count); }
        public T CopyR(uint data, int offset, int byte_count) { return CopyR(BitConverter.GetBytes(data), offset, byte_count); }
        public T Copy(float data, int offset, int byte_count) { return Copy(BitConverter.GetBytes(data), offset, byte_count); }
        public T CopyR(float data, int offset, int byte_count) { return CopyR(BitConverter.GetBytes(data), offset, byte_count); }

        public Boolean Execute()
        {
            if (HNDL == 0)
                return false;
            int wrt = 0;
            int FP = EF.VirtualAllocEx(HNDL, 0, CD.LENGTH, 0x1000, 4);
            EF.WriteProcessMemory(HNDL, FP, CD.DATA, CD.LENGTH, ref wrt);
            int TH = EF.CreateRemoteThread(HNDL, 0, 0, FP, 0, 0, ref wrt);
            if (TH == -1) { EF.VirtualFreeEx(HNDL, FP, CD.LENGTH, 0x8); return false; }
            EF.WaitForSingleObject(TH, 0xFFFFFFFF);
            EF.CloseHandle(TH);
            EF.VirtualFreeEx(HNDL, FP, CD.LENGTH, 0x8);
            return true;
        }

        public byte[] Execute(byte[] EA, int pointer_position)
        {
            if (HNDL == 0) return EA;
            if (EA.Length < 1) { Execute(); return EA; }
            int wrt = 0;
            int FP = EF.VirtualAllocEx(HNDL, 0, CD.LENGTH, 0x1000, 4);
            int OP = EF.VirtualAllocEx(HNDL, 0, EA.Length, 0x1000, 4);
            Copy(OP, pointer_position, 4);
            EF.WriteProcessMemory(HNDL, FP, CD.DATA, CD.LENGTH, ref wrt);
            EF.WriteProcessMemory(HNDL, OP, EA, EA.Length, ref wrt);
            int TH = EF.CreateRemoteThread(HNDL, 0, 0, FP, 0, 0, ref wrt);
            if (TH == -1) { EF.VirtualFreeEx(HNDL, FP, CD.LENGTH, 0x8); EF.VirtualFreeEx(HNDL, OP, EA.Length, 0x8); return EA; }
            EF.WaitForSingleObject(TH, 0xFFFFFFFF);
            EF.ReadProcessMemory(HNDL, OP, EA, EA.Length, ref wrt);
            EF.CloseHandle(TH);
            EF.VirtualFreeEx(HNDL, FP, CD.LENGTH, 0x8);
            EF.VirtualFreeEx(HNDL, OP, EA.Length, 0x8);
            return EA;
        }
    }
}

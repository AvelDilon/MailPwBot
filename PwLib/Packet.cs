using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwLib
{
    public class Packet : AsmCode<Packet>
    {
        public Packet(int HNDL, byte[] data) : base(HNDL, data) { }
        public Packet(int HNDL, string data) : base(HNDL, data) { }

        public Boolean Send()
        {
            if (HNDL == 0)
                return false;
            byte[] WP =
            {
                0x60,                                   // PUSHAH
                0x8B, 0x0D, 0x00, 0x00, 0x00, 0x00,     // mov ecx, [BA]
                0x8B, 0x49, 0x20,                       // mov ecx, [ecx + 20]
                0x68, 0x11, 0x11, 0x11, 0x11,           // push PACKET_LENGTH
                0x68, 0x22, 0x22, 0x22, 0x22,           // push PACKET_PTR
                0xB8, 0x33, 0x33, 0x33, 0x33,           // mov eax, SendPacketFunction
                0xFF, 0xD0,                             // call eax
                0x61, 0xC3                              // POPAD, RET
            };
            Packet FD = new Packet(HNDL, WP);
            FD.Copy(OFS.BA, 3, 4);
            FD.Copy(OFS.PA, 21, 4);
            FD.Copy(CD.LENGTH, 11, 4);
            int FP = -1; int PP = -1; int wrt = -1;
            try
            {
                FP = EF.VirtualAllocEx(HNDL, 0, FD.CD.LENGTH, 0x1000, 4);
                PP = EF.VirtualAllocEx(HNDL, 0, CD.LENGTH, 0x1000, 4);
                FD.Copy(PP, 16, 4);
                EF.WriteProcessMemory(HNDL, FP, FD.CD.DATA, FD.CD.LENGTH, ref wrt);
                EF.WriteProcessMemory(HNDL, PP, CD.DATA, CD.LENGTH, ref wrt);
            }
            catch(Exception)
            {
                if (FP > 0)
                    EF.VirtualFreeEx(HNDL, FP, FD.CD.LENGTH, 0x8);
                if (PP > 0)
                    EF.VirtualFreeEx(HNDL, PP, CD.LENGTH, 0x8);
                return false;
            }
            int hProcThread = EF.CreateRemoteThread(HNDL, 0, 0, FP, 0, 0, ref wrt);
            if (hProcThread == -1)
            {
                EF.VirtualFreeEx(HNDL, FP, FD.CD.LENGTH, 0x8);
                EF.VirtualFreeEx(HNDL, PP, CD.LENGTH, 0x8);
                return false;
            }
            EF.WaitForSingleObject(hProcThread, 0xFFFFFFFF);
            EF.CloseHandle(hProcThread);
            EF.VirtualFreeEx(HNDL, FP, FD.CD.LENGTH, 0x8);
            EF.VirtualFreeEx(HNDL, PP, CD.LENGTH, 0x8);
            return true;
        }
    }
}

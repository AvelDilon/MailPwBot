using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    class Packet : AsmCode<Packet>
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

        /*public void Test()
        {
            int wrt = -1;
            int STRS = 1024;
            byte[] CBU = new byte[STRS];
            Memory.ReadProcessMemory(CHR.HNDL, 0x00E69258, CBU, STRS, ref wrt);
            CBU[0x1F0] = 2;
            CBU[0x14] = 0xF1; CBU[0x15] = 0xB1; CBU[0x16] = 0xAA; CBU[0x17] = 0x00;

            uint[] UI = new uint[] { 0x5D4D60 };
            byte[] WP =
            {
                0x60,                                       //pushad
                0x8B, 0x05, 0x00, 0x00, 0x00, 0x00,         //mox eax, [BA]                         #1
                0x8B, 0x40, 0x1C,                           //mov eax, [eax + 1C]
                0x8B, 0x40, 0x34,                           //mov eax, [eax + 0x34]
                0x8B, 0x98, 0x5C, 0x18, 0x00, 0x00,         //mov ebx, [eax + 0x185C]

                0xBF, 0x02, 0x00, 0x00, 0x00,               //mov edi, 0x2
                0x89, 0xBB, 0xF0, 0x01, 0x00, 0x00,         //mov [ebx+1f0], edi

                0xBF, 0x28, 0x50, 0xCC, 0x13,               //- mov edi, 1344B028
                0xBE, 0x00, 0x00, 0x00, 0x00,               //- mov esi, 00CED128 (??)
                0x8B, 0x16,                                 //- mov edx,[esi]
                0x8B, 0x42, 0x24,                           //- mov eax,[edx + 24]
                0x56,                                       //- push esi
                0x8B, 0xCE,                                 //- mov ecx, esi
                0xFF, 0xD0,                                 //- call eax
                0x50,                                       //- push eax
                0x8B, 0xCB,                                 //- mov ecx, ebx
                0xFF, 0x15, 0x00, 0x00, 0x00, 0x00,         //- call [PTR]

                0x61,                                       //popad
                0xC3                                        //ret
            };
            Packet P = new Packet(CHR.HNDL, WP);
            P.Copy(OFS.BA, 3, 4);
            int FP = Memory.VirtualAllocEx(CHR.HNDL, 0, P.CD.LENGTH, 0x1000, 4);
            int DUA = Memory.VirtualAllocEx(CHR.HNDL, 0, UI.Length * 4, 0x1000, 4);
            int STP = Memory.VirtualAllocEx(CHR.HNDL, 0, CBU.Length, 0x1000, 4);
            P.Copy(STP, 36, 4);
            P.Copy(DUA + 0, 55, 4);
            Memory.WriteProcessMemory(CHR.HNDL, FP, P.CD.DATA, P.CD.LENGTH, ref wrt);
            byte[] UB = new byte[UI.Length * sizeof(int)];
            Buffer.BlockCopy(UI, 0, UB, 0, UB.Length);
            Memory.WriteProcessMemory(CHR.HNDL, DUA, UB, UB.Length, ref wrt);
            Memory.WriteProcessMemory(CHR.HNDL, STP, CBU, CBU.Length, ref wrt);
            int hProcThread = Memory.CreateRemoteThread(CHR.HNDL, 0, 0, FP, 0, 0, ref wrt);
            if (hProcThread == -1)
            {
                Memory.VirtualFreeEx(CHR.HNDL, FP, P.CD.LENGTH, 0x8);
                Memory.VirtualFreeEx(CHR.HNDL, DUA, UB.Length, 0x8);
                Memory.VirtualFreeEx(CHR.HNDL, STP, CBU.Length, 0x8);
                return;
            }
            Memory.WaitForSingleObject(hProcThread, 0xFFFFFFFF);
            Memory.CloseHandle(hProcThread);
            Memory.VirtualFreeEx(CHR.HNDL, FP, P.CD.LENGTH, 0x8);
            Memory.VirtualFreeEx(CHR.HNDL, DUA, UB.Length, 0x8);
            Memory.VirtualFreeEx(CHR.HNDL, STP, CBU.Length, 0x8);
        }*/
    }
}

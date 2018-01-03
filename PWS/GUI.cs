using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PwBot
{
    public class GameWindow
    {
        public int HNDL = -1;
        public int ptr;
        public int GF;
        public String name;
        public int name_ptr;
        public int visibility;
        public List<WindowControl> CL;

        public GameWindow(int HNDL) { this.HNDL = HNDL; }

        public void OpenWindow()
        {
            if (HNDL < 0 || name.Length < 1)
                return;
            byte[] WP =
            {
                0x60,                                       //pushad
                0x8B, 0x05, 0x00, 0x00, 0x00, 0x00,         //mox eax, [BA]
                0x8B, 0x40, 0x1C,                           //mov eax, [eax + 1C]
                0x8B, 0x78, 0x34,                           //mov edi, [eax + 0x34]
                0x8B, 0x8F, 0x5C, 0x18, 0x00, 0x00,         //mov ecx, [edi + 0x185C]
                0x8B, 0x09,                                 //mov ecx,[ecx]
                0x8B, 0x11,                                 //mov edx,[ecx]
                0x8B, 0x42, 0x38,                           //mov eax,[edx + 38]
                0x68, 0x00, 0x00, 0x00, 0x00,               //push ["Win_Name"]
                0xFF, 0xD0,                                 //call eax
                0x8B, 0x10,                                 //mov edx,[eax]
                0x6A, 0x01,                                 //push 01
                0x6A, 0x00,                                 //push 00
                0x8B, 0xC8,                                 //mov ecx, eax
                0x8B, 0x42, 0x1C,                           //mov eax,[edx + 1C]
                0x6A, 0x01,                                 //push 01
                0xFF, 0xD0,                                 //call eax
                0x61,                                       //popad
                0xC3                                        //ret
            };
            Packet P = new Packet(HNDL, WP);
            P.Copy(OFS.BA, 3, 4);
            P.Execute(Encoding.ASCII.GetBytes(name), 27);
        }
    }

    public class WindowControl
    {
        private GameWindow WND = null;
        public int ptr;
        public String name;
        public int name_ptr;
        public String CN;
        public int CP;

        public WindowControl(GameWindow WND) { this.WND = WND; }

        public bool Click()
        {
            String CtrlName = CN.Trim().Length > 0 ? CN : (name.Trim().Length > 0 ? name : null);
            if (CtrlName == null)
                return false;
            byte[] WP =
            {
                    0x60,                                   // PUSHAH
                    0xBE, 0x00, 0x00, 0x00, 0x00,           // mov esi, WinPtr
                    0x8B, 0x16,                             // mov edx,[esi]
                    0x8B, 0x42, 0x30,                       // mov eax,[edx + 30]
                    0xBD, 0x00, 0x00, 0x00, 0x00,           // mov ebp, ControlStringPtr
                    0x55,                                   // push ebp
                    0x8B, 0xCE,                             // mov ecx, esi
                    0xFF, 0xD0,                             // call eax
                    0x61, 0xC3                              // POPAD, RET
            };
            Packet P = new Packet(WND.HNDL, WP);
            P.Copy(WND.ptr, 2, 4);
            byte[] R = P.Execute(Encoding.ASCII.GetBytes(CtrlName), 12);
            return R.Length > 0;
        }
    }

    public class GUI
    {
        private Character CHR;
        private int GO = 0;

        public List<GameWindow> WL = new List<GameWindow>();

        public GUI(Character CHR)
        {
            this.CHR = CHR;
            LoadAllWindows();
        }

        public void LoadAllWindows()
        {
            GO = Memory.RD(CHR.HNDL, "BA+GA_OFS+Gui_O1+Gui_O2");
            if (GO == 0)
                return;
            WL.Clear();
            int P = Memory.RD(CHR.HNDL, GO + OFS.GetInt("Gui_LowW_Struct"));
            while (true)
            {
                if (P == 0)
                    break;
                try
                {
                    GameWindow w = new GameWindow(CHR.HNDL);
                    w.ptr = Memory.RD(CHR.HNDL, P + OFS.GetInt("Gui_Win_Ptr"));
                    w.GF = Memory.RD(CHR.HNDL, Memory.RD(CHR.HNDL, w.ptr) + 0x30);
                    w.name_ptr = Memory.RD(CHR.HNDL, w.ptr + OFS.GetInt("Gui_Win_Name"));
                    w.name = Memory.RS(CHR.HNDL, w.name_ptr, 64, false);
                    w.visibility = Memory.RD(CHR.HNDL, w.ptr + OFS.GetInt("Gui_Win_Visibility"));
                    w.CL = new List<WindowControl>();
                    WL.Add(w);
                    P = Memory.RD(CHR.HNDL, P);
                }
                catch (Exception e)
                {
                    Debug.LOG(e.ToString());
                    break;
                }
            }
            P = Memory.RD(CHR.HNDL, GO + OFS.GetInt("Gui_TopW_Struct"));
            while (true)
            {
                if (P == 0)
                    break;
                try
                {
                    GameWindow w = new GameWindow(CHR.HNDL);
                    w.ptr = Memory.RD(CHR.HNDL, P + OFS.GetInt("Gui_Win_Ptr"));
                    w.name_ptr = Memory.RD(CHR.HNDL, w.ptr + OFS.GetInt("Gui_Win_Name"));
                    w.name = Memory.RS(CHR.HNDL, w.name_ptr, 64, false);
                    w.visibility = Memory.RD(CHR.HNDL, w.ptr + OFS.GetInt("Gui_Win_Visibility"));
                    w.CL = new List<WindowControl>();
                    WL.Add(w);
                    P = Memory.RD(CHR.HNDL, P);
                }
                catch (Exception e)
                {
                    Debug.LOG(e.ToString());
                    break;
                }
            }
            foreach (GameWindow w in WL)
            {
                P = Memory.RD(CHR.HNDL, w.ptr + OFS.GetInt("Gui_Win_Ctrl_Array"));
                while (true)
                {
                    if (P == 0)
                        break;
                    try
                    {
                        WindowControl c = new WindowControl(w);
                        c.ptr = Memory.RD(CHR.HNDL, P + OFS.GetInt("Gui_Win_Ctrl_Ptr"));
                        c.name_ptr = Memory.RD(CHR.HNDL, c.ptr + OFS.GetInt("Gui_Win_Ctrl_Name"));
                        c.name = Memory.RS(CHR.HNDL, c.name_ptr, 64, false);
                        c.CP = Memory.RD(CHR.HNDL, c.ptr + OFS.GetInt("Gui_Win_Ctrl_Function"));
                        c.CN = Memory.RS(CHR.HNDL, c.CP, 64, false);
                        w.CL.Add(c);
                        P = Memory.RD(CHR.HNDL, P + OFS.GetInt("Gui_Win_Ctrl_Next"));
                    }
                    catch (Exception e)
                    {
                        Debug.LOG(e.ToString());
                        break;
                    }
                }
            }
        }

        public GameWindow GetCurrentWindow()
        {
            LoadAllWindows();
            int P = Memory.RD(CHR.HNDL, GO + OFS.GetInt("Gui_Win_Current"));
            String name = Memory.RS(CHR.HNDL, Memory.RD(CHR.HNDL, P + OFS.GetInt("Gui_Win_Name")), 64, false);
            foreach (GameWindow w in WL)
                if (w.ptr == P && w.name.Equals(name))
                    return w;
            return new GameWindow(CHR.HNDL);
        }

        public Boolean CheckCurrentWindow(String[] names)
        {
            int P = Memory.RD(CHR.HNDL, GO + OFS.GetInt("Gui_Win_Current"));
            String cwn = Memory.RS(CHR.HNDL, Memory.RD(CHR.HNDL, P + OFS.GetInt("Gui_Win_Name")), 64, false);
            return names.Contains(cwn);
        }

        public Boolean CheckCurrentWindow(String name) { return CheckCurrentWindow(new String[] { name }); }
        public Boolean IsWindowOpen(String name, Boolean strict = true) { foreach (GameWindow w in WL) if (w.name.Equals(name) && (strict ? w.visibility == 1 : w.visibility > 0)) return true; return false; }
        public Boolean WaitForWindow(String name, int sec, Boolean strict = true, Boolean NeedOpen = true)
        {
            DateTime WU = DateTime.Now.AddSeconds(sec);
            while (true)
            {
                if (!CHR.CLNT.IsRun())
                    return false;
                LoadAllWindows();
                if (!(NeedOpen ^ IsWindowOpen(name, strict)))
                {
                    Utils.Delay(500);
                    return true;
                }
                if (DateTime.Now.CompareTo(WU) > 0)
                    return false;
                Utils.Delay(200);
            }
        }

        public Boolean Click(String window, String control)
        {
            LoadAllWindows();
            foreach (GameWindow w in WL)
                if (w.name.Equals(window))
                {
                    foreach (WindowControl c in w.CL)
                        if (c.name.Trim().Equals(control) || c.CN.Trim().Equals(control))
                            c.Click();
                    break;
                }
            return false;
        }
    }
}

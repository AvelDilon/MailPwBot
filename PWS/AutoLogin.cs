using Newtonsoft.Json;
using PwBot.PwDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static PwBot.PwDataSet;

namespace PwBot
{
    class AutoLogin
    {
        public static UInt64 UID1 = 16358179426615842353;
        public static UInt64 UID2 = 6699790601842480689;
        public static String PW_PATH = "";
        public Boolean Force = false;

        private int DbId = -1;
        private String Login = "";
        private String Password = "";
        private String refresh_token = "";
        private String access_token = "";
        private DateTime expire;
        private String PersId;
        private String _PersId;
        private String token2;
        private String CMD_PARAMS = "";
        private String ACC_DESC;
        private Boolean AuthResult = false;
        private LoginTableAdapter LTA;
        private int character_number = 1;

        private class AuthObj { public String access_token = ""; public String refresh_token = ""; public String expires_in = ""; }

        public AutoLogin(int DB_ID)
        {
            this.DbId = DB_ID;
            LTA = new LoginTableAdapter();
            foreach (LoginRow r in LTA.GetById(DB_ID))
            {
                this.Login = r.login;
                this.Password = r.password;
                this.refresh_token = r.refresh_token;
                this.ACC_DESC = r.description;
                this.character_number = r.pers_num;
                this.expire = r.expire.Length > 0 ? DateTime.Parse(r.expire) : DateTime.Now.AddSeconds(-60);
            }
            AuthResult = Auth();
            UpdatePath();
        }

        private void TokenAuth()
        {
            if (refresh_token.Length == 0 || DateTime.Now.CompareTo(expire) > 0)
                return;
            access_token = "";
            try
            {
                Web w = new Web("https://o2.mail.ru/token");
                Dictionary<String, String> PA = new Dictionary<String, String>();
                PA.Add("client_id", "gamecenter.mail.ru");
                PA.Add("grant_type", "refresh_token");
                PA.Add("refresh_token", refresh_token);
                w.Post(PA);
                AuthObj obj = JsonConvert.DeserializeObject<AuthObj>(w.response);
                access_token = obj.access_token;
                if (access_token.Length > 0)
                    LTA.UpdateToken(obj.refresh_token, DateTime.Now.AddSeconds(Int32.Parse(obj.expires_in)).ToString(), DbId);
            }
            catch { access_token = ""; }
            return;
        }

        private void PassAuth()
        {
            if (access_token.Length > 0 || Login.Length == 0 || Password.Length == 0)
                return;
            access_token = "";
            try
            {
                Web w = new Web("https://o2.mail.ru/token");
                Dictionary<String, String> PA = new Dictionary<String, String>();
                PA.Add("client_id", "gamecenter.mail.ru");
                PA.Add("grant_type", "password");
                PA.Add("username", Login);
                PA.Add("password", Password);
                w.Post(PA);
                AuthObj obj = JsonConvert.DeserializeObject<AuthObj>(w.response);
                access_token = obj.access_token;
                if (access_token.Length > 0)
                    LTA.UpdateToken(obj.refresh_token, DateTime.Now.AddSeconds(Int32.Parse(obj.expires_in)).ToString(), DbId);
            }
            catch { access_token = ""; }
            return;
        }

        private Boolean Auth()
        {
            //TokenAuth();
            PassAuth();
            if (access_token.Length == 0)
                return false;
            try
            {
                Web w = new Web("https://o2.mail.ru/userinfo");
                Dictionary<String, String> PA = new Dictionary<String, String>();
                PA = new Dictionary<String, String>();
                PA.Add("client_id", "gamecenter.mail.ru");
                PA.Add("access_token", access_token);
                w.Post(PA);
                w = new Web("https://authdl.mail.ru/ec.php?hint=MrPage2");
                w.Post("<?xml version=\"1.0\" encoding=\"UTF-8\"?><MrPage2 SessionKey=\"" + access_token + "\" Page=\"http://dl.mail.ru/robots.txt\"/>");
                XmlReader XR = XmlReader.Create(new StringReader(w.response));
                XR.ReadToFollowing("MrPage2");
                XR.MoveToAttribute("Location");
                String NL = XR.Value;
                w = new Web(NL);
                w.Get();
                String Mpop = "";
                foreach (Cookie c in Web.CC.GetCookies(new Uri("https://authdl.mail.ru")))
                {
                    String[] aa = c.ToString().Split('=');
                    if (aa[0].Trim().Equals("Mpop"))
                        Mpop = aa[1].Trim();
                }
                if (Mpop.Length == 0)
                    return false;
                w = new Web("https://authdl.mail.ru/ec.php?hint=Auth");
                w.Post("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Auth UserId=\"" + UID1 + "\" UserId2=\"" + UID2 + "\" Soft=\"1\" Cookie=\"" + Mpop + "\" AppId=\"\" ChannelId=\"27\"/>");
                XR = XmlReader.Create(new StringReader(w.response));
                //RET: <? xml version = "1.0" encoding = "UTF-8" ?>< Auth SessionKey = "37b9ae4d1e3ba6869b8f41feeba83fe6" Uid = "8428393197924253246" Sex = "M" BirthDate = "2.6.1986" RefreshToken = "5d68e0e6510418f167a7697f73c374c3" AppId = "570177" AppKey = "06fc0f5283b3a5b3f62d62bd21ac2aff" FirstName = "Proxima" LastName = "Altaira" NickName = "Proxima Altaira" SUid = "1033371198" MinVersion = "1112" Timestamp = "1500764815" >< Project Id = "61:0" LastLogin = "1500755096" Paid = "0" Beta = "0" />< Project Id = "10091:0" LastLogin = "1500755096" Paid = "0" Beta = "0" />< Project Id = "0:0" LastLogin = "0" Paid = "0" Beta = "0" /></ Auth >
                w = new Web("https://authdl.mail.ru/sz.php?hint=AutoLogin");
                w.Post("<?xml version=\"1.0\" encoding=\"UTF-8\"?><AutoLogin ProjectId=\"61\" SubProjectId=\"0\" ShardId=\"0\" UserId=\"" + UID1 + "\" UserId2=\"" + UID2 + "\" Mpop=\"" + Mpop + "\"/>");
                XR = XmlReader.Create(new StringReader(w.response));
                //RET: <?xml version="1.0" encoding="UTF-8"?><AutoLogin PersId="595206826" RegionServer="" Key="4086d0cd97eaae03583f2dbcf6c8973a68072544b9bc6113fd04bf5925e7ae81" />
                XR.ReadToFollowing("AutoLogin");
                XR.MoveToAttribute("Key");
                token2 = XR.Value;
                w = new Web("https://authdl.mail.ru/sz.php?hint=PersList");
                w.Post("<?xml version=\"1.0\" encoding=\"UTF-8\"?><PersList ProjectId=\"61\" SubProjectId=\"0\" ShardId=\"0\" UserId=\"" + UID1 + "\" UserId2=\"" + UID2 + "\" Mpop=\"" + Mpop + "\"/>");
                XR = XmlReader.Create(new StringReader(w.response));
                //RET: <?xml version="1.0" encoding="UTF-8"?><PersList PersId="595206826"><Pers Id="150817621" Title="u_579dd9bec0" Cli="--account=150817621"/></PersList>
                XR.ReadToFollowing("PersList");
                XR.MoveToAttribute("PersId");
                _PersId = XR.Value;
                XR.ReadToFollowing("Pers");
                XR.MoveToAttribute("Id");
                PersId = XR.Value;
                CMD_PARAMS = "console:1 startbypatcher user:" + PersId + " _user:" + _PersId + " token2:" + token2;
                return true;
            }
            catch { return false; }
        }

        public void ThreadRun()
        {
            PwBot.RunClient_ButtonChange();
            THH.StartNewThread(RunHandler, "RUN CLIENT: " + ACC_DESC);
        }

        private void RunHandler()
        {
            Run();
            THH.SelfStop("RUN CLIENT: " + ACC_DESC);
            PwBot.RunClient_ButtonChange();
        }

        private void Run()
        {
            if (!AuthResult || CMD_PARAMS.Length == 0 || PW_PATH.Length == 0)
                return;
            Process p = new Process();
            p.StartInfo.FileName = PW_PATH + "\\elementclient.exe";
            p.StartInfo.Arguments = CMD_PARAMS;
            p.StartInfo.WorkingDirectory = PW_PATH;
            p.Start();
            p.WaitForInputIdle();
            ImproveWindow(p.MainWindowHandle);
            EnterTheGame();
            Boolean R = CheckResult();
            if (Force && !R)
                Run();
        }

        public void ImproveWindow(IntPtr WP)
        {
            int fix = Utils.GetOS_X_Fix();
            EF.MoveWindow(WP, -fix, 0, Screen.PrimaryScreen.WorkingArea.Width + 2 * fix, Screen.PrimaryScreen.WorkingArea.Height + fix, true);
            EF.SetWindowText(WP, ACC_DESC);
        }

        public bool CheckResult()
        {
            Client CL = Client.GetByTitle(ACC_DESC);
            if (CL == null)
                return false;
            if (CL.CHR.INGAME)
            {
                CL.CHR.LoadLocation();
                CL.CHR.LOC.Add(0.1F, 0.1F, 0F);
                CL.CHR.Move(CL.CHR.LOC);
                return true;
            }
            CL.Halt();
            return false;
        }

        public bool EnterTheGame()
        {
            DateTime WU = DateTime.Now.AddSeconds(60);
            while (true)
            {
                if (DateTime.Now.CompareTo(WU) > 0)
                    return false;
                Client CL = Client.GetByTitle(ACC_DESC);
                if (CL == null) { Utils.Delay(1000); continue; }
                if (!CL.CHR.WND.WaitForWindow("Win_LoginServerListButton", 20))
                    return false;
                Utils.Delay(1500);
                CL.CHR.WND.Click("Win_LoginServerListButton", "confirm");
                if (!CL.CHR.WND.WaitForWindow("Win_PwdHint", 10, false))
                    return false;
                Utils.Delay(1000);
                CL.CHR.WND.Click("Win_PwdHint", "IDCANCEL");
                if (!CL.CHR.WND.WaitForWindow("Win_Select", 10, false))
                    return false;
                Utils.Delay(1000);
                CL.CHR.WND.Click("Win_Select", "Rdo_Char" + character_number);
                if (!CL.CHR.WND.WaitForWindow("Win_Manage", 10, false))
                    return false;
                Utils.Delay(1000);
                CL.CHR.WND.Click("Win_Manage", "Btn_Game");
                return CL.WaitEnterTheGame(40);
            }
        }

        public static Dictionary<int, String> GetAccs()
        {
            Dictionary<int, String> O = new Dictionary<int, String>();
            LoginTableAdapter LTA = new LoginTableAdapter();
            foreach(LoginRow r in LTA.GetData())
                O.Add(r.id, r.description);
            return O;
        }

        public static void UpdatePath(String path = "")
        {
            if (path.Length == 0)
                PW_PATH = Config.Get("PW_PATH");
            else
            {
                PW_PATH = path;
                Config.Set("PW_PATH", path);
            }
        }
    }
}

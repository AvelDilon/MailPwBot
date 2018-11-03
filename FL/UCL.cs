using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FL
{
    public class UCL
    {
        private static List<UCL> LST = new List<UCL>();
        public int ID;
        public String name;
        public UserControl uc;
        public Boolean visible;
        public TabPage TP;

        public UCL(int id, String name, UserControl uc, Boolean visible)
        {
            this.ID = id;
            this.name = name;
            this.uc = uc;
            this.visible = visible;
            TP = new TabPage();
            TP.Text = name;
            TP.Controls.Add(uc);
        }

        public static void Init()
        {
            LST.Clear();
            LST.Add(new UCL(UCAL.UCID, "Логин", new UCAL(), true));
            LST.Add(new UCL(UCFairy.UCID, "Джины", new UCFairy(), true));
            LST.Add(new UCL(UCBeasts.UCID, "Звери", new UCBeasts(), true));
            LST.Add(new UCL(UCMisc.UCID, "Разное", new UCMisc(), true));
            LST.Add(new UCL(UCSettings.UCID, "Настройки", new UCSettings(), true));
            LST.Add(new UCL(UCDebug.UCID, "DEBUG", new UCDebug(), false));
        }

        public static void Add(UserControl u, String name, Boolean visible = true)
        {
            LST.Add(new UCL(LST.Count, name, u, visible));
        }

        public static List<UCL> GetList()
        {
            return LST.OrderBy(o => o.ID).ToList();
        }

        public static UCL Get(int id)
        {
            foreach (UCL u in LST)
                if (u.ID == id)
                    return u;
            return null;
        }

        public static void ReplaceUC(int id, UserControl u)
        {
            UCL lu = Get(id);
            lu.TP.Controls.Clear();
            lu.TP.Controls.Add(u);
        }

        public static void ReturnUC(int id)
        {
            UCL lu = Get(id);
            lu.TP.Controls.Clear();
            lu.TP.Controls.Add(lu.uc);
        }

        public static void SetVisible(int id, Boolean visible)
        {
            foreach (UCL u in LST)
                if (u.ID == id)
                    u.visible = visible;
        }

        public static void ChangeVisibility(int id)
        {
            foreach (UCL u in LST)
                if (u.ID == id)
                    u.visible = !u.visible;
        }
    }
}

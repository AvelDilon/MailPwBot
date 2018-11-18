using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using PwLib;
using FL;

namespace PwBot
{
    public partial class PwBot : Form
    {
        public static PwBot Instance = null;

        public PwBot()
        {
            Instance = this;
            InitializeComponent();
            TrayIcon.Visible = false;
            Init();
        }

        public void Init()
        {
            OFS.Init();
            UCL.Init();
            Controls.Add(new UCClients());
            FillTc();
            UCAL.Instance.DrawAccs();
            DrawTrayLogins();
        }

        private void FillTc()
        {
            int csi = TC1.SelectedIndex;
            TC1.TabPages.Clear();
            foreach (UCL i in UCL.GetList())
                if (i.visible)
                    TC1.TabPages.Add(i.TP);
            TC1.SelectedIndex = csi;
        }

        private void PWS_FormClosing(object sender, FormClosingEventArgs e)
        {
            THH.StopAll();
        }

        private void PWS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                UCL.ChangeVisibility(UCDebug.UCID);
                FillTc();
            }
        }

        public void DrawTrayLogins()
        {
            ToolStripMenuItem RTM = TrayMenu.Items["RunTrayMenu"] as ToolStripMenuItem;
            RTM.DropDownItems.Clear();
            foreach (GameAccount acc in AutoLogin.GetAccs())
            {
                Image ii = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "icons\\" + acc.icon);
                RTM.DropDownItems.Add(acc.name, LU.ScaleImage(ii, 16, 16), TrayRun);
            }
        }

        private void TrayRun(object sender, EventArgs e)
        {
            foreach (GameAccount acc in AutoLogin.GetAccs())
                if (acc.name.Equals(sender.ToString()))
                {
                    AutoLogin ALI = new AutoLogin(acc.id);
                    ALI.Force = false;
                    ALI.ThreadRun();
                }
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                TrayIcon.Visible = false;
                this.ShowInTaskbar = true;
                WindowState = FormWindowState.Normal;
            }
        }

        private void PwBot_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                TrayIcon.Visible = true;
                UCAL.Instance.DrawAccs();
                DrawTrayLogins();
            }
        }

        private void BotClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

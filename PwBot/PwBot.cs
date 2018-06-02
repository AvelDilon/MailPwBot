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
            OFS.Init(LOFSF.Checked);
            ScanClients();
            DrawAccs();
        }
            private void ScanClients()
        {
            PRS.Items.Clear();
            Client.Init();
            foreach (Client IC in Client.CL)
                PRS.Items.Add(IC.CHR.Name);
            if (Client.CL.Count > 0)
                PRS.SelectedIndex = PRS.Items.IndexOf(Client.CC.CHR.Name);
        }

        private void SCAN_Click(object sender, EventArgs e)
        {
            ScanClients();
        }

        private void PRS_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Client IC in Client.CL)
                if (IC.CHR.Name.Equals(PRS.SelectedItem))
                    Client.CC = IC;
            BB_RUN.Refresh();
            FairyStart.Refresh();
        }

        private void PWS_FormClosing(object sender, FormClosingEventArgs e)
        {
            THH.StopAll();
        }

        public void DrawAccs()
        {
            ToolStripMenuItem RTM = TrayMenu.Items["RunTrayMenu"] as ToolStripMenuItem;
            ImageList IL = new ImageList();
            IL.ImageSize = new Size(64, 64);
            IL.ColorDepth = ColorDepth.Depth32Bit;
            PIL.LargeImageList = IL;
            PIL.Items.Clear();
            RTM.DropDownItems.Clear();
            foreach (GameAccount acc in AutoLogin.GetAccs())
            {
                Image ii = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "icons\\" + acc.icon);
                IL.Images.Add(LU.ScaleImage(ii, 64, 64));
                ListViewItem item = new ListViewItem();
                item.ImageIndex = IL.Images.Count - 1;
                item.Text = acc.name;
                PIL.Items.Add(item);
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

        private void AddAcc_Click(object sender, EventArgs e)
        {
            LoginAddForm LF = LoginAddForm.GetInstance();
            LF.Owner = this;
            LF.Left = Left + Width;
            LF.Top = Top;
            LF.ShowDialog();
        }

        private void PWS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.D)
            {
                Debug DW = Debug.GetInctance();
                if (DW.Visible)
                    DW.Hide();
                else
                {
                    DW.Show();
                    DW.Left = Left + Width - 2 * LU.GetOS_X_Fix();
                    DW.Top = Top;
                }
            }
        }

        private void SetClient_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "PW Client (elementclient.exe)|elementclient.exe";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
                AutoLogin.UpdatePath(Path.GetDirectoryName(OFD.FileName));
        }

        private void PWS_Move(object sender, EventArgs e)
        {
            if (!this.ContainsFocus)
                return;
            Debug DW = Debug.GetInctance();
            DW.Left = Left + Width - 2 * LU.GetOS_X_Fix();
            DW.Top = Top;
        }

        private void BB_RUN_Click(object sender, EventArgs e)
        {
            if (BB_RUN.Text.Equals("Запустить"))
            {
                Client.CC.CHR.MBF.OpenBags = OBCB.Checked;
                Client.CC.CHR.MBF.SkipBattles = !SBCB.Checked;
                try { Client.CC.CHR.MBF.PointLimit = Int32.Parse(PointLimit.Text); } catch { }
                Client.CC.CHR.MBF.RunBeastBattle();
                BB_RUN.Text = "Остановить";
            }
            else
            {
                Client.CC.CHR.MBF.StopBeastBattle();
                BB_RUN.Text = "Запустить";
            }
        }

        private void BB_RUN_Paint(object sender, PaintEventArgs e)
        {
            if (Client.CC == null)
            {
                BB_RUN.Enabled = false;
                return;
            }
            BB_RUN.Enabled = true;
            if (Client.CC.CHR.MBF.IsRun)
                BB_RUN.Text = "Остановить";
            else
                BB_RUN.Text = "Запустить";
        }

        private void FairyStart_Click(object sender, EventArgs e)
        {
            if (FairyStart.Text.Equals("Запустить"))
            {
                try { Client.CC.CHR.FAIRY.GOODNEES = 100 - UInt32.Parse(FG.Text); } catch { FG.Text = "70"; }
                Client.CC.CHR.FAIRY.RunFairyEnchancement();
                FairyStart.Text = "Остановить";
            }
            else
            {
                Client.CC.CHR.FAIRY.StopFairyEnchancement();
                FairyStart.Text = "Запустить";
            }
        }

        private void FairyStart_Paint(object sender, PaintEventArgs e)
        {
            if (Client.CC == null)
            {
                FairyStart.Enabled = false;
                return;
            }
            FairyStart.Enabled = true;
            if (Client.CC.CHR.FAIRY.IsRun)
                FairyStart.Text = "Остановить";
            else
                FairyStart.Text = "Запустить";
        }

        private void PIL_DoubleClick(object sender, EventArgs e)
        {
            foreach (GameAccount acc in AutoLogin.GetAccs())
                if(acc.name.Equals(PIL.SelectedItems[0].Text))
                {
                    AutoLogin ALI = new AutoLogin(acc.id);
                    ALI.Force = false;
                    ALI.ThreadRun();
                }
        }

        private void AccAdd_Click(object sender, EventArgs e)
        {
            LoginAddForm LF = LoginAddForm.GetInstance();
            LF.Owner = this;
            LF.Left = Left + Width;
            LF.Top = Top;
            LF.ShowDialog();
        }

        private void AccDel_Click(object sender, EventArgs e)
        {
            if (PIL.Items.Count == 0 || PIL.SelectedItems.Count == 0)
                return;
            LoginDeleteForm DF = new LoginDeleteForm();
            DF.Owner = this;
            DF.Left = Left + Width;
            DF.Top = Top;
            DF.OpenMe(PIL.SelectedItems[0].Text);
        }

        private void AccEdit_Click(object sender, EventArgs e)
        {
            if (PIL.SelectedItems.Count == 0)
                return;
            foreach (GameAccount acc in AutoLogin.GetAccs())
                if (acc.name.Equals(PIL.SelectedItems[0].Text))
                {
                    LoginEditForm LF = new LoginEditForm(acc);
                    LF.Owner = this;
                    LF.Left = Left + Width;
                    LF.Top = Top;
                    LF.ShowDialog();
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
                DrawAccs();
            }
        }

        private void BotClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LOFSF_CheckedChanged(object sender, EventArgs e)
        {
            Init();
        }
    }
}

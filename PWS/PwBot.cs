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

namespace PwBot
{
    public partial class PwBot : Form
    {
        public static PwBot Instance = null;

        public PwBot()
        {
            Instance = this;
            InitializeComponent();
            OFS.Init();
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

        private void ShopSettings_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("shop.xlsx");
        }

        public void DrawAccs()
        {
            LGS.Items.Clear();
            Dictionary<int, String> AL = AutoLogin.GetAccs();
            foreach (String an in AL.Values)
            {
                LGS.Items.Add(an);
                LGS.SelectedIndex = LGS.Items.IndexOf(an);
            }
        }

        private void RunClient_Click(object sender, EventArgs e)
        {
            Dictionary<int, String> AL = AutoLogin.GetAccs();
            if (AL.ContainsValue(LGS.SelectedItem.ToString()))
            {
                AutoLogin ALI = new AutoLogin(AL.FirstOrDefault(x => x.Value.Equals(LGS.SelectedItem.ToString())).Key);
                ALI.Force = false;
                ALI.ThreadRun();
            }
        }

        public static void RunClient_ButtonChange()
        {
            if (Instance == null)
                return;
            Instance.RunClient.Invoke((ThreadStart)delegate () { Instance.RunClient.Enabled = !Instance.RunClient.Enabled; });
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
                    DW.Left = Left + Width - 2 * Utils.GetOS_X_Fix();
                    DW.Top = Top;
                }
            }
        }

        private void RemAcc_Click(object sender, EventArgs e)
        {
            if (LGS.Items.Count == 0 || LGS.SelectedItem.ToString().Length == 0)
                return;
            LoginDeleteForm DF = new LoginDeleteForm();
            DF.Owner = this;
            DF.Left = Left + Width;
            DF.Top = Top;
            DF.OpenMe(LGS.SelectedItem.ToString());
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
            DW.Left = Left + Width - 2 * Utils.GetOS_X_Fix();
            DW.Top = Top;
        }

        private void BB_RUN_Click(object sender, EventArgs e)
        {
            if (BB_RUN.Text.Equals("Запустить"))
            {
                Client.CC.CHR.MBF.OpenBags = OBCB.Checked;
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
            if (Client.CC.CHR.FAIRY.IsRun)
                BB_RUN.Text = "Остановить";
            else
                BB_RUN.Text = "Запустить";
        }
    }
}

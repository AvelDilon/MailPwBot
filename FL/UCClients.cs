using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PwLib;
using System.Threading;

namespace FL
{
    public partial class UCClients : UserControl
    {
        public static Boolean State = true;
        public UCClients()
        {
            InitializeComponent();
            RunScan();
        }

        public void ChEn(Boolean st)
        {
            State = st;
            if (ClientsList.InvokeRequired)
                ClientsList.BeginInvoke(new Action(() => { ClientsList.Enabled = st; }));
            else
                ClientsList.Enabled = st;
            if (ClientsScan.InvokeRequired)
                ClientsScan.BeginInvoke(new Action(() => { ClientsScan.Enabled = st; }));
            else
                ClientsScan.Enabled = st;
        }

        private void Fill()
        {
            ClearList();
            foreach (Client IC in Client.CL)
                AddToList(IC.CHR.Name);
            if (Client.CL.Count > 0)
                SetIndexByName(Client.CC.CHR.Name);
            ChEn(true);
        }

        private void ClearList()
        {
            if (ClientsList.InvokeRequired)
                ClientsList.BeginInvoke(new Action(() => { ClientsList.Items.Clear(); }));
            else
                ClientsList.Items.Clear();
        }

        private void AddToList(String name)
        {
            if (ClientsList.InvokeRequired)
                ClientsList.BeginInvoke(new Action(() => { ClientsList.Items.Add(name); }));
            else
                ClientsList.Items.Add(name);
        }

        private void SetIndexByName(String name)
        {
            if (ClientsList.InvokeRequired)
                ClientsList.BeginInvoke(new Action(() => { ClientsList.SelectedIndex = ClientsList.Items.IndexOf(name); }));
            else
                ClientsList.SelectedIndex = ClientsList.Items.IndexOf(name);
        }

        private void RunScan()
        {
            if (!State)
                return;
            THH.StartNewThread(() => { ChEn(false); Client.Init(); }, "CLSCT", Fill);
        }

        private void ClientsScan_Click(object sender, EventArgs e)
        {
            RunScan();
        }

        private void ClientsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Client IC in Client.CL)
                if (IC.CHR.Name.Equals(ClientsList.SelectedItem))
                    Client.CC = IC;
            UCBeasts.RefreshMe();
            UCFairy.RefreshMe();
        }
    }
}

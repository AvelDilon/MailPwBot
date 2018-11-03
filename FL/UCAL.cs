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
using System.IO;

namespace FL
{
    public partial class UCAL : UserControl
    {
        public static UCAL Instance = null;
        public static int UCID = 1;
        public UCAL()
        {
            Instance = this;
            InitializeComponent();
        }

        private void SetClient_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "PW Client (elementclient.exe)|elementclient.exe";
            OFD.Multiselect = false;
            if (OFD.ShowDialog() == DialogResult.OK)
                AutoLogin.UpdatePath(Path.GetDirectoryName(OFD.FileName));
        }

        private void AddAcc_Click(object sender, EventArgs e)
        {
            UCL.ReplaceUC(UCAL.UCID, new UCLoginAdd());
        }

        private void PIL_DoubleClick(object sender, EventArgs e)
        {
            foreach (GameAccount acc in AutoLogin.GetAccs())
                if (acc.name.Equals(PIL.SelectedItems[0].Text))
                {
                    AutoLogin ALI = new AutoLogin(acc.id);
                    ALI.Force = false;
                    ALI.ThreadRun();
                }
        }

        private void AccAdd_Click(object sender, EventArgs e)
        {
            UCL.ReplaceUC(UCAL.UCID, new UCLoginAdd());
        }

        private void AccDel_Click(object sender, EventArgs e)
        {
            if (PIL.Items.Count == 0 || PIL.SelectedItems.Count == 0)
                return;
            UCL.ReplaceUC(UCAL.UCID, new UCLoginDel(PIL.SelectedItems[0].Text));
        }

        private void AccEdit_Click(object sender, EventArgs e)
        {
            if (PIL.SelectedItems.Count == 0)
                return;
            foreach (GameAccount acc in AutoLogin.GetAccs())
                if (acc.name.Equals(PIL.SelectedItems[0].Text))
                    UCL.ReplaceUC(UCAL.UCID, new UCLoginEdit(acc));
        }

        public void DrawAccs()
        {
            ImageList IL = new ImageList();
            IL.ImageSize = new Size(64, 64);
            IL.ColorDepth = ColorDepth.Depth32Bit;
            PIL.LargeImageList = IL;
            PIL.Items.Clear();
            foreach (GameAccount acc in AutoLogin.GetAccs())
            {
                Image ii = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "icons\\" + acc.icon);
                IL.Images.Add(LU.ScaleImage(ii, 64, 64));
                ListViewItem item = new ListViewItem();
                item.ImageIndex = IL.Images.Count - 1;
                item.Text = acc.name;
                PIL.Items.Add(item);
            }
        }
    }
}

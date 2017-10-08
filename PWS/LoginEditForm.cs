using PwBot.PwDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PwBot
{
    public partial class LoginEditForm : Form
    {
        private int ID = -1;
        String ICON = "001.png";

        public LoginEditForm(GameAccount acc)
        {
            InitializeComponent();
            ActiveControl = AddButton;
            LGN.Text = acc.Login;
            PSW.Text = acc.Password;
            DES.Text = acc.name;
            PNU.Text = acc.PERS_ID.ToString();
            ID = acc.id;
            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "icons\\" + acc.icon);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (LGN.Text.Length == 0 || PSW.Text.Length == 0 || DES.Text.Length == 0)
                return;
            try
            {
                LoginTableAdapter LTA = new LoginTableAdapter();
                int PNU_R = PNU.Text.Length == 0 ? 1 : Int32.Parse(PNU.Text);
                LTA.UpdateLogin(LGN.Text, PSW.Text, DES.Text, PNU_R, ICON, ID);
            }
            catch { }
            ((PwBot)Owner).DrawAccs();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "All Files (*.*)|*.*";
            OFD.FilterIndex = 1;
            OFD.Multiselect = false;
            OFD.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "icons";
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ICON = OFD.SafeFileName;
                    pictureBox1.Image = Utils.LoadImage(AppDomain.CurrentDomain.BaseDirectory + "icons\\" + ICON, 64, 64);
                } catch { };
            }
        }
    }
}

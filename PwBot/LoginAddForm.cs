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
    public partial class LoginAddForm : Form
    {
        public static String LGN_DEF = "your@mail.ru";
        public static String PSW_DEF = "пароль";
        public static String PNU_DEF = "1";
        public static String DES_DEF = "Антоний";
        public String ICON = "001.png";

        public static LoginAddForm Instance = null;

        public static LoginAddForm GetInstance()
        {
            return Instance == null ? new LoginAddForm() : Instance;
        }

        public LoginAddForm()
        {
            InitializeComponent();
            SetGrayText(LGN, LGN_DEF);
            SetGrayText(PSW, PSW_DEF);
            SetGrayText(PNU, PNU_DEF);
            SetGrayText(DES, DES_DEF);
            ActiveControl = AddButton;
            Instance = this;
        }

        private void SetGrayText(TextBox TB, String txt)
        {
            if (TB.Text.Length == 0)
            {
                TB.Text = txt;
                TB.ForeColor = SystemColors.GrayText;
            }
        }

        private void RemoveText(TextBox TB, String txt)
        {
            if (TB.Text.Equals(txt))
            {
                TB.Text = "";
                TB.ForeColor = SystemColors.WindowText;
            }
        }

        private void LGN_Leave(object sender, EventArgs e)
        {
            SetGrayText((TextBox)sender, LGN_DEF);
        }

        private void LGN_Enter(object sender, EventArgs e)
        {
            RemoveText((TextBox)sender, LGN_DEF);
        }

        private void PSW_Enter(object sender, EventArgs e)
        {
            RemoveText((TextBox)sender, PSW_DEF);
        }

        private void PSW_Leave(object sender, EventArgs e)
        {
            SetGrayText((TextBox)sender, PSW_DEF);
        }

        private void PNU_Enter(object sender, EventArgs e)
        {
            RemoveText((TextBox)sender, PNU_DEF);
        }

        private void PNU_Leave(object sender, EventArgs e)
        {
            SetGrayText((TextBox)sender, PNU_DEF);
        }

        private void DES_Enter(object sender, EventArgs e)
        {
            RemoveText((TextBox)sender, DES_DEF);
        }

        private void DES_Leave(object sender, EventArgs e)
        {
            SetGrayText((TextBox)sender, DES_DEF);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginTableAdapter LTA = new LoginTableAdapter();
                String LGN_R = LGN.Text.Length == 0 ? LGN_DEF : LGN.Text;
                String PSW_R = PSW.Text.Length == 0 ? PSW_DEF : PSW.Text;
                String DES_R = DES.Text.Length == 0 ? DES_DEF : DES.Text;
                int PNU_R = PNU.Text.Length == 0 ? 1 : Int32.Parse(PNU.Text);
                foreach (GameAccount acc in AutoLogin.GetAccs())
                    if (acc.name.Equals(DES_R))
                        return;
                LTA.AddLogin(LGN_R, PSW_R, DES_R, PNU_R, ICON);
            }
            catch { }
            ((PwBot)Owner).DrawAccs();
            this.Close();
        }

        private void LoginAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instance = null;
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
                    pictureBox1.Image = LU.LoadImage(AppDomain.CurrentDomain.BaseDirectory + "icons\\" + ICON, 64, 64);
                } catch { };
            }
        }
    }
}

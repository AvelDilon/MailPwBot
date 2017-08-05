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
    public partial class LoginDeleteForm : Form
    {
        public String account;

        public LoginDeleteForm()
        {
            InitializeComponent();
        }

        public void OpenMe(String account)
        {
            this.account = account;
            DAL.Text = "Удалить аккаунт: <" + account + ">?";
            ShowDialog();
        }

        private void DAB_Click(object sender, EventArgs e)
        {
            if(account.Length > 0)
            {
                LoginTableAdapter LTA = new LoginTableAdapter();
                LTA.DeleteByDesc(account);
            }
            ((PwBot)Owner).DrawAccs();
            this.Close();
        }
    }
}

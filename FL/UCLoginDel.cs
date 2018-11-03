using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PwLib.PwDataSetTableAdapters;

namespace FL
{
    public partial class UCLoginDel : UserControl
    {
        public String account;

        public UCLoginDel(String acc)
        {
            InitializeComponent();
            account = acc;
            DAL.Text = "Удалить аккаунт: <" + acc + ">?";
        }

        private void DAB_Click(object sender, EventArgs e)
        {
            if (account.Length > 0)
            {
                LoginTableAdapter LTA = new LoginTableAdapter();
                LTA.DeleteByDesc(account);
            }
            UCL.ReturnUC(UCAL.UCID);
            FL.UCAL.Instance.DrawAccs();
        }
    }
}

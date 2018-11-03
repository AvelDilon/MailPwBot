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

namespace FL
{
    public partial class UCInventory : UserControl
    {
        public UCInventory(Character CHR)
        {
            InitializeComponent();
            ListInv(CHR);
        }

        private void InvCancel_Click(object sender, EventArgs e)
        {
            UCL.ReturnUC(UCMisc.UCID);
        }

        private void ListInv(Character CHR)
        {
            CHR.INV.Load();
            List<Item> LA = new List<Item>();
            foreach (Item i in CHR.INV.IL)
                if (i.id > 0)
                    LA.Add(i);
            ISLB.Items.AddRange(LA.ToArray());
        }

        private void ISLB_DoubleClick(object sender, EventArgs e)
        {
            Item si = (Item)ISLB.SelectedItem;
            UCMisc.DIID = si.id;
            UCL.ReturnUC(UCMisc.UCID);
        }
    }
}

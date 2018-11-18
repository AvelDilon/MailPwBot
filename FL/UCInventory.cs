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
        public static int UCID = 4;
        public UCInventory(Character CHR, int PARENT)
        {
            InitializeComponent();
            UCID = PARENT;
            ListInv(CHR);
        }

        private void InvCancel_Click(object sender, EventArgs e)
        {
            UCL.ReturnUC(UCID);
        }

        private void ListInv(Character CHR)
        {
            CHR.GetClass<Inventory>().Load();
            List<ItemInventory> LA = new List<ItemInventory>();
            foreach (ItemInventory i in CHR.GetClass<Inventory>().IL)
                if (i.id > 0)
                    LA.Add(i);
            ISLB.Items.AddRange(LA.ToArray());
        }

        private void ISLB_DoubleClick(object sender, EventArgs e)
        {
            ItemInventory si = (ItemInventory)ISLB.SelectedItem;
            UCMisc.DIID = si.id;
            UCL.ReturnUC(UCID);
        }
    }
}

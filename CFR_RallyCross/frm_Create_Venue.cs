using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFR_RallyCross
{
    public partial class frm_Create_Venue : Form
    {
        public frm_Create_Venue()
        {
            InitializeComponent();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Address.Clear();
            txt_City.Clear();
            txt_Name.Clear();
            txt_State.Clear();
            txt_Zip.Clear();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

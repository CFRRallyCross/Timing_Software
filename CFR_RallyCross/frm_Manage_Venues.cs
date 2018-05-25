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
    public partial class frm_Manage_Venues : Form
    {
        public frm_Manage_Venues()
        {
            InitializeComponent();
            SQL_Commands.Venues.Get.Venues(dgv_Venues);
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Create_Venue>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                new frm_Create_Venue().Show();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }

    }
}

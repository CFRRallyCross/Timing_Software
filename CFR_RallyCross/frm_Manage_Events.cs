using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CFR_RallyCross
{
    public partial class frm_Manage_Events : Form
    {
        public frm_Manage_Events()
        {
            InitializeComponent();
            SQL_Commands.Events.Get.Events(dgv_Events);
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Create_Event>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                new frm_Create_Event().Show();
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SQL_Commands.Events.Update.Event(dgv_Events);
            SQL_Commands.Events.Get.Events(dgv_Events);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Resources.Confirm_Delete() == false) { return; }

            SQL_Commands.Events.Remove.Events(dgv_Events);
            SQL_Commands.Events.Get.Events(dgv_Events);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

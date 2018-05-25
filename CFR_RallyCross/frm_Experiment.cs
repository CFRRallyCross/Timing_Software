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
using System.Data.OleDb;

namespace CFR_RallyCross
{
    public partial class frm_Experiment : Form
    {
        public frm_Experiment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                List<Timing_Data> lst_TD = SQL_Commands.Timing.Get.DNF(SQL);

                SQL_Commands.Timing.Set.DNF(lst_TD, SQL);
            }
            SQL.Close();
        }
    }
}

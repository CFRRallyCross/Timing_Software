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
    public partial class frm_Create_Event : Form
    {
        public frm_Create_Event()
        {
            InitializeComponent();
            Update_Venues();
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string str_EventNumber = txt_Number.Text;
            int int_VenueID = Get_Venue_ID(cmb_Venue.Text);
            string str_EventName = txt_Name.Text;
            DateTime dt_Date = Convert.ToDateTime(dt_Event_Date.Text);

            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (var Transaction = SQL.BeginTransaction())
            {
                try
                {
                    String Query = "INSERT INTO tbl_Event " +
                                   "(Number,Name,Date,Status,Venue_ID) " +
                                   "VALUES (@Num,@N,@D,@S,@V)";
                    SqlCommand Command = new SqlCommand(Query, SQL, Transaction);
                    Command.Parameters.AddWithValue("@Num", str_EventNumber);
                    Command.Parameters.AddWithValue("@N", str_EventName);
                    Command.Parameters.AddWithValue("@D", dt_Date);
                    Command.Parameters.AddWithValue("@S", false);
                    Command.Parameters.AddWithValue("@V", int_VenueID);
                    Command.ExecuteNonQuery();
                    Transaction.Commit();
                }
                catch (Exception excepted)
                {
                    MessageBox.Show(excepted.ToString());
                    Transaction.Rollback();
                }
            }
            SQL.Close();

            //Clear Form After Event Created
            MessageBox.Show("Event Created Sucessfully");
            cmb_Venue.SelectedIndex = -1;
            txt_Name.Text = "";
            txt_Number.Text = "";
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Name.Text = "";
            txt_Number.Text = "";
            dt_Event_Date.Text = "";
            cmb_Venue.SelectedIndex = -1;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Update_Venues()
        {
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                List<string> lst_Temp = new List<string>();
                SqlCommand Command;
                SqlDataReader Reader;
                Command = new SqlCommand("SELECT DISTINCT Name FROM tbl_Venue",SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lst_Temp.Add(Reader.GetString(0));
                }
                Reader.Close();

                lst_Temp.Sort();
                cmb_Venue.DataSource = lst_Temp.ToArray();
                cmb_Venue.Update();
            }
        }

        private int Get_Venue_ID(string Venue)
        {
            int tempID = 0;
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                SqlCommand Command;
                SqlDataReader Reader;
                Command = new SqlCommand("SELECT DISTINCT Venue_ID FROM tbl_Venue WHERE Name = '" + Venue + "'", SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    tempID = Reader.GetInt32(0);
                }
                Reader.Close();
            }

            return tempID;
        }

    }
}

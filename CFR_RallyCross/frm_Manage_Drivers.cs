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
    public partial class frm_Manage_Drivers : Form
    {
        public frm_Manage_Drivers()
        {
            InitializeComponent();
            SQL_Commands.Drivers.Controls.Update_DataGridView(dgv_Drivers);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                foreach (DataGridViewRow tempRow in dgv_Drivers.Rows)
                {
                    if (tempRow.IsNewRow == false)
                    {
                        int intID = Convert.ToInt32(tempRow.Cells[0].Value);
                        string strLast = tempRow.Cells[1].Value.ToString();
                        string strFirst = tempRow.Cells[2].Value.ToString();
                        string strMemberNumber = tempRow.Cells[3].Value.ToString();
                        string strHometown = tempRow.Cells[4].Value.ToString();
                        string strEmail = tempRow.Cells[5].Value.ToString();


                        using (var dbTransaction = SQL.BeginTransaction())
                        {

                            try
                            {
                                string strQuery = "UPDATE tbl_Driver " +
                                                  "SET Last_Name = @LN, First_Name = @FN, Member_Number = @MN, Hometown = @H, Email = @E " +
                                                  "WHERE Driver_ID = @T";
                                SqlCommand dbCommand = new SqlCommand(strQuery, SQL, dbTransaction);
                                dbCommand.Parameters.AddWithValue("@T", intID);
                                dbCommand.Parameters.AddWithValue("@LN", strLast);
                                dbCommand.Parameters.AddWithValue("@FN", strFirst);
                                dbCommand.Parameters.AddWithValue("@MN", strMemberNumber);
                                dbCommand.Parameters.AddWithValue("@H", strHometown);
                                dbCommand.Parameters.AddWithValue("@E", strEmail);
                                dbCommand.ExecuteNonQuery();
                                dbTransaction.Commit();
                            }
                            catch (Exception exception)
                            {
                                dbTransaction.Rollback();
                                MessageBox.Show(exception.ToString());
                            }
                        }
                    }
                }
            }
            SQL.Close();

            SQL_Commands.Drivers.Controls.Update_DataGridView(dgv_Drivers);
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Resources.Confirm_Delete() == false) { return; }

            //Delete row
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                foreach (DataGridViewRow tempRow in dgv_Drivers.SelectedRows)
                {
                    using (var transaction = SQL.BeginTransaction())
                    {
                        try
                        {
                            int intID;
                            intID = Convert.ToInt32(tempRow.Cells[0].Value);

                            string strQuery = "DELETE FROM tbl_Driver WHERE Driver_ID = @ID";

                            SqlCommand Command = new SqlCommand(strQuery, SQL, transaction);
                            Command.Parameters.AddWithValue("@ID", intID);
                            Command.ExecuteNonQuery();
                            transaction.Commit();

                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.ToString());
                            transaction.Rollback();
                        }
                    }
                }
            }
            SQL.Close();

            SQL_Commands.Drivers.Controls.Update_DataGridView(dgv_Drivers);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace CFR_RallyCross
{
    public partial class frm_Enter_Time : System.Windows.Forms.Form
    {
        public frm_Enter_Time()
        {
            InitializeComponent();
            Globals.dtLastEntry = DateTime.MinValue;
            SQL_Commands.Timing.Controls.Vehicle_Number(cmb_Vehicle_Number);
            SQL_Commands.Timing.Controls.Stages_Completed(dgv_Stages_Completed);
            SQL_Commands.Timing.Controls.Stage_Times(dgv_TimeEntry);
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //Verify Mandatory Fields are Selected
            if (Resources.Check_Fields(cmb_Vehicle_Number, txt_RawTime) == true) { return; }

            //Check Off Course Status
            bool blOffCourse = false;
            if (chk_OffCourse.CheckState == CheckState.Checked) { blOffCourse = true; }

            //Check Competitor Status
            string strCompetitor = cmb_Vehicle_Number.Text;

            //Check Stage Count
            int intStage = Resources.Get_Current_Stage2(strCompetitor);

            //Check Cones Status
            int intCones = 0;
            intCones = Convert.ToInt32(num_Cones.Value);

            //Check Gates Status
            int intGates = 0;
            intGates = Convert.ToInt32(num_Gates.Value);

            //Check Stage Time Status
            decimal decStageTime = Convert.ToDecimal(txt_RawTime.Text);

            //Calculate Total Time
            decimal decTotalTime = Resources.Caluclate_FinishTime(decStageTime, intCones, intGates, blOffCourse);

            //Write Results
            Resources.Write_Results2(strCompetitor, intStage, decStageTime, intCones, intGates, blOffCourse, decTotalTime);

            //Update Stages Completed                  
            SQL_Commands.Timing.Controls.Stages_Completed(dgv_Stages_Completed);

            //Update Time Datagrid
            SQL_Commands.Timing.Controls.Stage_Times(dgv_TimeEntry);

            //Export Query to Wordpress
            Reports.UploadClassResults();
            Reports.UploadOverallResults();
            Reports.UploadStages();

            //Export Overall Stages
            Reports.ExportStages();

            //Upload Results to FTP
            Thread FTP_Upload = new Thread(FTP_Commands.FTP_Upload_Recent_Stages);
            FTP_Upload.Start();

            Clear_Form();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                foreach (DataGridViewRow tempRow in dgv_TimeEntry.Rows)
                {
                    int intTimeID = Convert.ToInt32(tempRow.Cells[0].Value);
                    int intStage = Convert.ToInt32(tempRow.Cells[4].Value);
                    decimal decStageTime = Convert.ToDecimal(tempRow.Cells[5].Value);
                    int intCones = Convert.ToInt32(tempRow.Cells[6].Value);
                    int intGates = Convert.ToInt32(tempRow.Cells[7].Value);
                    bool Off_Course = Convert.ToBoolean(tempRow.Cells[8].Value);
                    decimal decTotalTime = Resources.Caluclate_FinishTime(decStageTime, intCones, intGates, Off_Course);

                    using (var dbTransaction = SQL.BeginTransaction())
                    {

                        try
                        {
                            string strQuery = "UPDATE tbl_Time " +
                                              "SET Stage_Number = @SN, Stage_Time = @ST, Cones_Hit = @C, Gates_Missed = @G, Off_Course = @OC, Total_Time = @TT " +
                                              "WHERE Time_ID = @T";
                            SqlCommand dbCommand = new SqlCommand(strQuery, SQL, dbTransaction);
                            dbCommand.Parameters.AddWithValue("@SN", intStage);
                            dbCommand.Parameters.AddWithValue("@ST", decStageTime);
                            dbCommand.Parameters.AddWithValue("@C", intCones);
                            dbCommand.Parameters.AddWithValue("@G", intGates);
                            dbCommand.Parameters.AddWithValue("@OC", Off_Course);
                            dbCommand.Parameters.AddWithValue("@TT", decTotalTime);
                            dbCommand.Parameters.AddWithValue("@T", intTimeID);
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
            SQL.Close();

            //Update Stages Completed                  
            SQL_Commands.Timing.Controls.Stages_Completed(dgv_Stages_Completed);

            //Update Time Datagrid
            SQL_Commands.Timing.Controls.Stage_Times(dgv_TimeEntry);

            //Export Query to Wordpress
            Reports.UploadClassResults();
            Reports.UploadOverallResults();
            Reports.UploadStages();

            //Export Overall Stages
            Reports.ExportStages();

            //Upload Results to FTP
            FTP_Commands.FTP_Upload_Recent_Stages();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear_Form();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (Resources.Confirm_Delete() == false) { return; }

            //Delete row
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                foreach (DataGridViewRow tempRow in dgv_TimeEntry.SelectedRows)
                {
                    using (var transaction = SQL.BeginTransaction())
                    {
                        try
                        {
                            int intID;
                            intID = Convert.ToInt32(tempRow.Cells[0].Value);

                            string strQuery = "DELETE FROM tbl_Time WHERE Time_ID = @ID";

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

            //Update Stages Completed                  
            SQL_Commands.Timing.Controls.Stages_Completed(dgv_Stages_Completed);

            //Update Time Datagrid
            SQL_Commands.Timing.Controls.Stage_Times(dgv_TimeEntry);

            //Update Class Results
            Reports.ExportClassResults();

            //Export Query to Wordpress
            Reports.UploadClassResults();
            Reports.UploadOverallResults();
            Reports.UploadStages();

            //Export Overall Stages
            Reports.ExportStages();

            //Upload Results to FTP
            FTP_Commands.FTP_Upload_Recent_Stages();
        }

        private void Clear_Form()
        {
            cmb_Vehicle_Number.SelectedIndex = -1;
            txt_RawTime.Text = "";
            num_Cones.Value = 0;
            num_Gates.Value = 0;
            chk_OffCourse.Checked = false;
        }

        private void chk_OffCourse_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_OffCourse.Checked == true)
            {
                chk_OffCourse.Text = "YES";
            }
            else
            {
                chk_OffCourse.Text = "NO";
            }

        }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CFR_RallyCross
{
    public partial class frm_Main_Menu : Form
    {
        int doDebugStuff = 0;
        bool DebugMode = false;

        public frm_Main_Menu()
        {
            InitializeComponent();


            if (SQL_Commands.IsServerConnected() == false)
            {
                MessageBox.Show("SQL Server is not currently online." + Environment.NewLine + "All data will be locally cached until server returns online.");
                tslbl_SQLStatus.BackColor = Color.OrangeRed;
            }
            else
            {
                tslbl_SQLStatus.BackColor = Color.Green;
            }
        }

        private void btn_Register_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Register_Driver>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                frm_Register_Driver frmRDriver = new frm_Register_Driver()
                {
                    MdiParent = this
                };
                frmRDriver.Show();
            }
        }

        private void btn_Time_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Enter_Time>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                frm_Enter_Time frmETime = new frm_Enter_Time()
                {
                    MdiParent = this
                };
                frmETime.Show();
            }
        }

        private void btn_Final_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            tspb_Progress.Value = 0;
            tspb_Progress.Maximum = 80;
            try
            {
                //Update DNF Results
                SqlConnection SQL = SQL_Commands.Connect();
                SQL.Open();
                using (SQL)
                {
                    List<Timing_Data> lst_TD = SQL_Commands.Timing.Get.DNF(SQL);
                    SQL_Commands.Timing.Set.DNF(lst_TD, SQL);
                }
                SQL.Close();

                //Export Report to HTML
                Reports.ExportStages();
                tspb_Progress.Value = 10;

                //Update Class Results
                Reports.ExportClassResults();
                tspb_Progress.Value = 20;

                //Update Overall Results
                Reports.ExportOverallResults();
                tspb_Progress.Value = 30;

                //Test Upload Duration
                DateTime dtStart = DateTime.Now;

                //Export Query to Wordpress
                Reports.UploadClassResults();
                tspb_Progress.Value = 40;
                Reports.UploadOverallResults();
                tspb_Progress.Value = 50;

                //Upload Results
                Thread Drivers = new Thread(FTP_Commands.FTP_Upload_Drivers);
                Drivers.Start();
                tspb_Progress.Value = 60;
                Thread Results = new Thread(FTP_Commands.FTP_Upload_Event_Results);
                Results.Start();
                tspb_Progress.Value = 70;
                Thread Stages = new Thread(FTP_Commands.FTP_Upload_Recent_Stages);
                Stages.Start();
                tspb_Progress.Value = 80;

                //Complete Upload Duration Test
                DateTime dtFinish = DateTime.Now;
                TimeSpan tsCompleted = dtFinish - dtStart;
                Console.WriteLine(tsCompleted);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Cursor = this.DefaultCursor;
                tspb_Progress.Value = 0;
            };
        }

        private void btn_Manage_Events_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Manage_Events>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                frm_Manage_Events frmMEvents = new frm_Manage_Events()
                {
                    MdiParent = this
                };
                frmMEvents.Show();
            }
        }

        private void btn_Manage_Venues_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Manage_Venues>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                frm_Manage_Venues frmMVenues = new frm_Manage_Venues()
                {
                    MdiParent = this
                };
                frmMVenues.Show();
            }
        }

        private void btn_Manage_Drivers_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Manage_Drivers>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                frm_Manage_Drivers frmMDrivers = new frm_Manage_Drivers
                {
                    MdiParent = this
                };
                frmMDrivers.Show();
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tslbl_Status_Click(object sender, EventArgs e)
        {
            doDebugStuff++;
            if (doDebugStuff > 10)
            {
                DebugMode = true;
                btn_Debug_1.Visible = true;
            }

        }

        private void btn_Debug_1_Click(object sender, EventArgs e)
        {
            var frm_Temp = Application.OpenForms.OfType<frm_Experiment>().FirstOrDefault();
            if (frm_Temp != null)
            {
                frm_Temp.Activate();
            }
            else
            {
                frm_Experiment frmTest = new frm_Experiment
                {
                    MdiParent = this
                };
                frmTest.Show();
            }
        }
    }
}

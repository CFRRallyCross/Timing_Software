using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CFR_RallyCross
{
    public partial class frm_Register_Driver : Form
    {
        public frm_Register_Driver()
        {
            InitializeComponent();
            SQL_Commands.Registration.Get.Registration(dgv_Registration);
            SQL_Commands.Registration.Update.Event(cmb_Event);
            SQL_Commands.Registration.Update.Driver(cmb_FirstName, cmb_LastName, cmb_MemberNumber, cmb_Hometown);
            SQL_Commands.Registration.Update.Class(cmb_Class);
            SQL_Commands.Registration.Update.Vehicle(cmb_Year, cmb_Make, cmb_Model);
            Clear_Form();
        }

        private void cmb_MemberNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_MemberNumber.Text != "")
            {
                string strMemberNumber = cmb_MemberNumber.Text;

                SqlConnection SQL = SQL_Commands.Connect();
                SQL.Open();
                using (SQL)
                {
                    SqlCommand SQLCommand = new SqlCommand("SELECT DISTINCT First_Name, Last_Name, Hometown FROM tbl_Driver WHERE Member_Number = '" + strMemberNumber + "'", SQL);
                    SqlDataReader SQLReader = SQLCommand.ExecuteReader();

                    {
                        while (SQLReader.Read())
                        {
                            cmb_FirstName.Text = SQLReader.GetString(0);
                            cmb_LastName.Text = SQLReader.GetString(1);
                            cmb_Hometown.Text = SQLReader.GetString(2);
                        }
                        SQLReader.Close();
                    }
                }
                SQL.Close();
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear_Form();
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //Verify All Fields Have Data
            if (CheckSwitches() == false) { return; }

            //Define Variables required
            double dblEvent = Convert.ToDouble(cmb_Event.Text);
            double dblPaymentAmount = Convert.ToDouble(txt_PaymentAmount.Text);
            int intEventID = 0;
            int intDriverID = 0;
            int intNumberID = 0;
            int intVehicleID = 0;
            int intClassID = 0;
            int intVehicleNumber = Convert.ToInt32(txt_VehicleNumber.Text);
            int intYear = Convert.ToInt32(cmb_Year.Text);
            string strFirstName = cmb_FirstName.Text;
            string strLastName = cmb_LastName.Text;
            string strHometown = cmb_Hometown.Text;
            string strMemberNumber = cmb_MemberNumber.Text;
            string strClass = cmb_Class.Text;
            string strMake = cmb_Make.Text;
            string strModel = cmb_Model.Text;
            string strPaymentType = cmb_PaymentType.Text;
            bool blPaymentReceived = Convert.ToBoolean(cmb_PaymentReceived.Text);
            bool blCheckedIn = Convert.ToBoolean(cmb_CheckedIn.Text);

            //Update Current Registration Data
            SQL_Commands.Registration.Update.Registration(dgv_Registration);

            //Insert New Drivers
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                //Get Event_ID
                intEventID = SQL_Commands.Registration.Get.Event(dblEvent, SQL);

                //Get Driver_ID
                intDriverID = SQL_Commands.Registration.Get.Driver(strLastName, strFirstName, SQL);
                if (intDriverID == 0)
                {
                    SQL_Commands.Registration.Create.Driver(strLastName, strFirstName, strMemberNumber, strHometown, SQL);
                    intDriverID = SQL_Commands.Registration.Get.Driver(strLastName, strFirstName, SQL);
                }

                //Get Number ID
                intNumberID = SQL_Commands.Registration.Get.Number(intVehicleNumber, SQL);
                if (intNumberID == 0)
                {
                    SQL_Commands.Registration.Create.Number(intVehicleNumber, SQL);
                    intNumberID = SQL_Commands.Registration.Get.Number(intVehicleNumber, SQL);
                }
                //Get Class ID
                intClassID = SQL_Commands.Registration.Get.Class(strClass, SQL);

                //Get Vehicle ID
                intVehicleID = SQL_Commands.Registration.Get.Vehicle(intYear, strMake, strModel, SQL);
                if (intVehicleID == 0)
                {
                    SQL_Commands.Registration.Create.Vehicle(intYear, strMake, strModel, SQL);
                    intVehicleID = SQL_Commands.Registration.Get.Vehicle(intYear, strMake, strModel, SQL);
                }

                //Check for Duplicates
                if (SQL_Commands.Registration.Find_Dup_Reg(intClassID, intNumberID, SQL) == true)
                {
                    MessageBox.Show("Duplicate Number/Class Combination. Please verify registration data.");
                    SQL.Close();
                    return;
                }
                if (SQL_Commands.Registration.Find_Dup_Driver(intDriverID, SQL) == true)
                {
                    MessageBox.Show("Driver is already registered. Please verify registration data.");
                    SQL.Close();
                    return;
                }

                SQL_Commands.Registration.Submit_Registration(intEventID, intDriverID, intClassID, intVehicleID, intNumberID, strPaymentType, dblPaymentAmount, blPaymentReceived, blCheckedIn, false, SQL);
            }
            SQL.Close();

            SQL_Commands.Registration.Get.Registration(dgv_Registration);
            Reports.ExportRegistration();
            Reports.ExportDriverReport();
            Reports.UploadDriverReport();

            Clear_Form();
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            List<DLB_Data> lstImport = new List<DLB_Data>();

            //Get Import File
            string txt_FileName = Globals.GetFile();
            FileInfo fi = new FileInfo(txt_FileName);

            //Check if File is locked
            if (Globals.IsFileLocked(fi) == true)
            {
                MessageBox.Show("Source file is currently in a read-only state." + Environment.NewLine + "Please verify file is not being accessed by an additional program and try again.");
                return;
            }
            else if (fi.Exists == false)
            {
                MessageBox.Show("Incorrect File Name Entered Into Text Field" + Environment.NewLine + "Please verify file name and try again");
                return;
            }

            //Read IMport File
            lstImport = File_Manager.ReadSource(fi);

            //Upload data to the registration table.
            SQL_Commands.Registration.Import.Registration(lstImport, dgv_Registration);
            SQL_Commands.Registration.Get.Registration(dgv_Registration);
            MessageBox.Show("Import Completed Succesfully");
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SQL_Commands.Registration.Update.Registration(dgv_Registration);
            Reports.ExportRegistration();
            Reports.ExportDriverReport();
            Reports.UploadDriverReport();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            //Cancel Delete if selected as NO
            if (Resources.Confirm_Delete() == false) { return; }

            //Delete row
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                using (var transaction = SQL.BeginTransaction())
                {
                    foreach (DataGridViewRow tempRow in dgv_Registration.SelectedRows)
                    {
                        try
                        {
                            int intRegistrationID;
                            intRegistrationID = Convert.ToInt32(tempRow.Cells[0].Value);

                            string strQuery = "DELETE FROM tbl_Registration WHERE Registration_ID = @ID";

                            SqlCommand Command = new SqlCommand(strQuery, SQL, transaction);
                            Command.Parameters.AddWithValue("@ID", intRegistrationID);
                            Command.ExecuteNonQuery();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.ToString());
                            transaction.Rollback();
                            SQL.Close();
                            return;
                        }
                    }
                    transaction.Commit();
                }
            }
            SQL.Close();

            SQL_Commands.Registration.Update.Registration(dgv_Registration);
            SQL_Commands.Registration.Get.Registration(dgv_Registration);
            Reports.ExportRegistration();
            Reports.ExportDriverReport();
            Reports.UploadDriverReport();
        }

        public bool CheckSwitches()
        {
            List<string> lstData = new List<string>();
            lstData.Add("The following fields are missing data:");
            if (cmb_Event.Text == "") { lstData.Add("-Event Number"); }
            if (cmb_FirstName.Text == "") { lstData.Add("-First Name"); }
            if (cmb_LastName.Text == "") { lstData.Add("-Last Name"); }
            if (cmb_Hometown.Text == "") { lstData.Add("-Hometown"); }
            if (txt_VehicleNumber.Text == "") { lstData.Add("-Vehicle Number"); }
            if (cmb_Class.Text == "") { lstData.Add("-Class"); }
            if (cmb_Year.Text == "") { lstData.Add("-Year"); }
            if (cmb_Make.Text == "") { lstData.Add("-Make"); }
            if (cmb_Model.Text == "") { lstData.Add("-Model"); }
            if (cmb_PaymentType.Text == "") { lstData.Add("-Payment Type"); }
            if (cmb_PaymentReceived.Text == "") { lstData.Add("-Payment Received"); }
            if (cmb_CheckedIn.Text == "") { lstData.Add("-Checked In"); }
            if (txt_PaymentAmount.Text == "") { lstData.Add("-Payment Amount"); }

            if (lstData.Count > 1)
            {
                var message = string.Join(Environment.NewLine, lstData);
                MessageBox.Show(message);
                return false;
            }
            else { return true; }
        }

        private void Clear_Form()
        {
            SQL_Commands.Registration.Update.Driver(cmb_FirstName, cmb_LastName, cmb_MemberNumber, cmb_Hometown);
            SQL_Commands.Registration.Update.Class(cmb_Class);
            SQL_Commands.Registration.Update.Vehicle(cmb_Year, cmb_Make, cmb_Model);

            cmb_MemberNumber.SelectedIndex = -1;
            cmb_FirstName.SelectedIndex = -1;
            cmb_LastName.SelectedIndex = -1;
            cmb_Hometown.SelectedIndex = -1;
            txt_VehicleNumber.Text = "";
            cmb_Class.SelectedIndex = -1;
            cmb_Year.SelectedIndex = -1;
            cmb_Make.SelectedIndex = -1;
            cmb_Model.SelectedIndex = -1;
            cmb_PaymentType.SelectedIndex = -1;
            cmb_PaymentReceived.SelectedIndex = -1;
            cmb_CheckedIn.SelectedIndex = -1;
            txt_PaymentAmount.Text = "";
        }


    }
}

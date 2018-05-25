using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using Microsoft.Office.Interop.Excel;

namespace CFR_RallyCross
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new frm_Main_Menu());
        }
    }

    public class Reports
    {
        public static void ExportRecentStages()
        {
            Resources.Destination_Directory();

            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            string strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCross\Stage_Times.html";

            //Upload New Query
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                string strQuery = "SELECT TOP(50) C.Class_Name, N.Number, D.First_Name, D.Last_Name, T.Stage_Number, T.Stage_Time, T.Cones_Hit, T.Gates_Missed, T.Off_Course, T.Total_Time " +
                                    "FROM tbl_Time as T " +
                                    "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                    "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                    "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                    "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                    "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                    "WHERE E.Status = 1 " +
                                    "ORDER BY T.Time_ID DESC";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader[0].ToString() + "," +
                                Reader[1].ToString() + "," +
                                Reader[2].ToString() + "," +
                                Reader[3].ToString() + "," +
                                Reader[4].ToString() + "," +
                                Reader[5].ToString() + "," +
                                Reader[6].ToString() + "," +
                                Reader[7].ToString() + "," +
                                Reader[8].ToString() + "," +
                                Reader[9].ToString()
                                );
                }
                Reader.Close();
            }
            SQL.Close();

            //Create New File
            lstExport.Add("<HTML>" + Environment.NewLine +
                "<HEAD>" + Environment.NewLine +
                "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                "<TITLE>Stage Times</TITLE>" + Environment.NewLine +
                "</HEAD>" + Environment.NewLine +
                "<BODY>" + Environment.NewLine +
                "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine + Environment.NewLine + //<FONT FACE=\"Calibri\" COLOR=#000000><CAPTION><B>Stage Times</B></CAPTION></FONT>
                "<THEAD>" + Environment.NewLine +
                "<TR>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Stage</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Time</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>DNF</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:20pt FACE=\"Calibri\" COLOR=#000000>Total</FONT></TH>" + Environment.NewLine + Environment.NewLine +
                "</TR>" + Environment.NewLine +
                "</THEAD>" + Environment.NewLine +
                "<TBODY>" + Environment.NewLine + Environment.NewLine);

            //Write Query Data to File
            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:18pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[9] + "</FONT></TD>" + Environment.NewLine + Environment.NewLine +
                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }

        public static void ExportRegistration()
        {
            Resources.Destination_Directory();

            List<string> lstData = new List<string>();
            lstData.Add("Class,Number,First Name,Last Name,Year,Make,Model,Checked In,Payment Received,Payment Amount, Payment Type");

            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                string strQuery = "SELECT C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model, R.Checked_In, R.Payment_Received, R.Payment_Amount, R.Payment_Type " +
                                            "FROM tbl_Registration as R " +
                                            "INNER JOIN tbl_Event as E ON R.Event_ID = E.Event_ID " +
                                            "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                            "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                            "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                            "INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
                                            "WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader.GetString(0) + "," + Reader.GetInt32(1).ToString() + "," + Reader.GetString(2) + "," + Reader.GetString(3) + "," + Reader.GetInt32(4).ToString() + "," + Reader.GetString(5) + "," + Reader.GetString(6) + "," + Reader.GetBoolean(7).ToString() + "," + Reader.GetBoolean(8).ToString() + "," + Reader.GetDecimal(9).ToString() + "," + Reader.GetString(10));
                }
                Reader.Close();
            }
            SQL.Close();

            string strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCross\Registration_Export_" + DateTime.Now.Date.ToString("yyyyMMdd") + ".csv";

            try { File.WriteAllLines(strFileName, lstData); }
            catch { MessageBox.Show("Registration Report File is currently open. Please close file before continuing."); }
        }

        public static void ExportDriverReport()
        {
            Resources.Destination_Directory();

            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            string strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCross\Drivers_List.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {

                SqlCommand Command;
                SqlDataReader Reader;
                string strQuery;

                strQuery =
                    "SELECT C.Class_Name, D.First_Name, D.Last_Name, N.Number, V.Year, V.Make, V.Model, D.Hometown " +
                    "FROM tbl_Registration AS R " +
                    "INNER JOIN tbl_Event AS E ON R.Event_ID = E.Event_ID " +
                    "INNER JOIN tbl_Driver AS D on R.Driver_ID = D.Driver_ID " +
                    "INNER JOIN tbl_Class AS C on R.Class_ID = C.Class_ID " +
                    "INNER JOIN tbl_Number AS N on R.Number_ID = N.Number_ID " +
                    "INNER JOIN tbl_Vehicle AS V on R.Vehicle_ID = V.Vehicle_ID " +
                    "WHERE E.Status = 1 AND R.Checked_In = 1" +
                    "ORDER BY C.Class_Name, D.Last_Name, D.First_Name ";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader.GetString(0) + "," +
                                Reader.GetString(1) + "," +
                                Reader.GetString(2) + "," +
                                Reader.GetInt32(3).ToString() + "," +
                                Reader.GetInt32(4).ToString() + "," +
                                Reader.GetString(5) + "," +
                                Reader.GetString(6) + "," +
                                Reader.GetString(7));
                }
                Reader.Close();

                strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();
            }
            SQL.Close();

            lstExport.Add("<HTML>" + Environment.NewLine +
                "<HEAD>" + Environment.NewLine +
                "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                "<TITLE>Driver's List</TITLE>" + Environment.NewLine +
                "</HEAD>" + Environment.NewLine +
                "<BODY>" + Environment.NewLine +
                "<FONT FACE=\"Calibri\" COLOR=#000000><B>Driver's List</B></FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                "<THEAD>" + Environment.NewLine +
                "<TR>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Hometown</FONT></TH>" + Environment.NewLine +
                "</TR>" + Environment.NewLine +
                "</THEAD>" + Environment.NewLine +
                "<TBODY>" + Environment.NewLine + Environment.NewLine);

            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }

        public static void ExportClassResults()
        {
            Resources.Destination_Directory();

            List<string> lstExport = new List<string>();
            string strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCross\Event_Results.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            //Get Classes
            List<int> lstClassID = new List<int>();
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                //Get Classes
                string strQuery = "SELECT DISTINCT C.Class_ID FROM tbl_Class as C " +
                                  "INNER JOIN tbl_Registration as R on C.Class_ID = R.Class_ID " +
                                  "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                  "WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstClassID.Add(Reader.GetInt32(0));
                }
                Reader.Close();

                //Get Event Information
                strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();

                //Write File Header
                lstExport.Add("<HTML>" + Environment.NewLine +
                    "<HEAD>" + Environment.NewLine +
                    "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                    "<TITLE>Class Results</TITLE>" + Environment.NewLine +
                    "</HEAD>" + Environment.NewLine +
                    "<BODY>" + Environment.NewLine +
                    "<FONT FACE=\"Calibri\" COLOR=#000000><B>Class Results</B></FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                    "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                    "<THEAD>" + Environment.NewLine +
                    "<TR>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Rank</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Completed</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stage Time</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>OC/DNF</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Total Time</FONT></TH>" + Environment.NewLine +
                    "</TR>" + Environment.NewLine +
                    "</THEAD>" + Environment.NewLine +
                    "<TBODY>" + Environment.NewLine);

                //Get Report
                foreach (int ID in lstClassID)
                {
                    List<string> lstData = new List<string>();
                    strQuery = "SELECT	ROW_NUMBER() OVER (Order By SUM(T.Total_Time) ASC) AS [Row#], C.Class_Name, N.Number, " +
                                "D.First_Name, D.Last_Name, V.Year, V.Make,	V.Model, SUM(CASE WHEN T.Off_Course = 1 THEN 0 ELSE 1 END), Count(T.Stage_Time), SUM(Stage_Time), " +
                                "SUM(T.Cones_Hit), SUM(T.Gates_Missed), SUM(CAST(T.Off_Course AS Int)), SUM(T.Total_Time) as [sumT] " +
                                "FROM tbl_Time as T INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
                                "INNER Join tbl_Event as E on R.Event_ID = E.Event_ID WHERE E.Status = 1 AND C.Class_ID = " + ID + " " +
                                "Group By C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model Order by [Row#]";
                    Command = new SqlCommand(strQuery, SQL);
                    Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        lstData.Add(Reader.GetInt64(0).ToString() + "," +
                            Reader.GetString(1) + "," +
                            Reader.GetInt32(2).ToString() + "," +
                            Reader.GetString(3) + "," +
                            Reader.GetString(4) + "," +
                            Reader.GetInt32(5).ToString() + "," +
                            Reader.GetString(6) + "," +
                            Reader.GetString(7) + "," +
                            Reader.GetInt32(8).ToString() + "," +
                            Reader.GetInt32(9).ToString() + "," +
                            Reader.GetDecimal(10).ToString() + "," +
                            Reader.GetInt32(11).ToString() + "," +
                            Reader.GetInt32(12).ToString() + "," +
                            Reader.GetInt32(13).ToString() + "," +
                            Reader.GetDecimal(14).ToString()
                            );
                    }
                    Reader.Close();

                    foreach (string item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ',' });
                        lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "/" + strSplit[9] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[10] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[11] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[12] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[13] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[14] + "</FONT></TD>" + Environment.NewLine +
                                            "</TR>" + Environment.NewLine + Environment.NewLine);
                    }
                    lstExport.Add("<TR BORDER=0 HEIGHT=10><TD ColSpan=\"14\"/></TD></TR>" + Environment.NewLine);
                }
            }
            SQL.Close();
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }

        public static void ExportOverallResults()
        {
            Resources.Destination_Directory();

            string strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCross\Event_Results_Overall.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            //Get Classes
            List<int> lstClassID = new List<int>();
            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                //Get Event Information
                string strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();

                //Write File Header
                lstExport.Add("<HTML>" + Environment.NewLine +
                    "<HEAD>" + Environment.NewLine +
                    "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                    "<TITLE>Overall Results</TITLE>" + Environment.NewLine +
                    "</HEAD>" + Environment.NewLine +
                    "<BODY>" + Environment.NewLine +
                    "<FONT FACE=\"Calibri\" COLOR=#000000><B>Overall Results</B></FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                    "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                    "<THEAD>" + Environment.NewLine +
                    "<TR>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Rank</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Completed</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stage Time</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>OC/DNF</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Total Time</FONT></TH>" + Environment.NewLine +
                    "</TR>" + Environment.NewLine +
                    "</THEAD>" + Environment.NewLine +
                    "<TBODY>" + Environment.NewLine);

                //Get Report

                strQuery = "SELECT ROW_NUMBER() OVER (Order By SUM(T.Total_Time) ASC) AS [Row#], C.Class_Name, N.Number, " +
                        "D.First_Name, D.Last_Name, V.Year, V.Make,	V.Model, SUM(CASE WHEN T.Off_Course = 1 THEN 0 ELSE 1 END), Count(T.Stage_Time), SUM(T.Stage_Time), " +
                        "SUM(T.Cones_Hit), SUM(T.Gates_Missed), SUM(CAST(T.Off_Course AS Int)), SUM(T.Total_Time) as [sumT] " +
                        "FROM tbl_Time as T INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                        "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                        "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
                        "INNER Join tbl_Event as E on R.Event_ID = E.Event_ID WHERE E.Status = 1 " +
                        "Group By C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model Order by [Row#]";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader.GetInt64(0).ToString() + "," +
                        Reader.GetString(1) + "," +
                        Reader.GetInt32(2).ToString() + "," +
                        Reader.GetString(3) + "," +
                        Reader.GetString(4) + "," +
                        Reader.GetInt32(5).ToString() + "," +
                        Reader.GetString(6) + "," +
                        Reader.GetString(7) + "," +
                        Reader.GetInt32(8).ToString() + "," +
                        Reader.GetInt32(9).ToString() + "," +
                        Reader.GetDecimal(10).ToString() + "," +
                        Reader.GetInt32(11).ToString() + "," +
                        Reader.GetInt32(12).ToString() + "," +
                        Reader.GetInt32(13).ToString() + "," +
                        Reader.GetDecimal(14).ToString()
                        );
                }
                Reader.Close();
            }
            SQL.Close();

            //Add Report Results to Export List

            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "/" + strSplit[9] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[10] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[11] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[12] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[13] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[14] + "</FONT></TD>" + Environment.NewLine +
                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);

            //    //Write File Header
            //    File.WriteAllText(strFileName,
            //        "<HTML>" + Environment.NewLine +
            //        "<HEAD>" + Environment.NewLine +
            //        "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
            //        "<TITLE>Overall Results</TITLE>" + Environment.NewLine +
            //        "</HEAD>" + Environment.NewLine +
            //        "<BODY>" + Environment.NewLine +
            //        "<FONT FACE=\"Calibri\" COLOR=#000000><B>Overall Results</B></FONT><BR/>" + Environment.NewLine +
            //        "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
            //        "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
            //        "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
            //        "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
            //        "<THEAD>" + Environment.NewLine +
            //        "<TR>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Rank</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stages Comp.</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stage Time</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Total Time</FONT></TH>" + Environment.NewLine +
            //        "</TR>" + Environment.NewLine +
            //        "</THEAD>" + Environment.NewLine +
            //        "<TBODY>" + Environment.NewLine);

            //    //Get Report

            //    strQuery = "SELECT	ROW_NUMBER() OVER (Order By SUM(T.Total_Time) ASC) AS [Row#], C.Class_Name, N.Number, " +
            //                    "D.First_Name, D.Last_Name, V.Year, V.Make,	V.Model, SUM(CASE WHEN T.Off_Course = 0 THEN 1 ELSE NULL END), SUM(Stage_Time), " +
            //                    "SUM(T.Cones_Hit), SUM(T.Gates_Missed), SUM(T.Total_Time) as [sumT] " +
            //                    "FROM tbl_Time as T INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
            //                    "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
            //                    "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
            //                    "INNER Join tbl_Event as E on R.Event_ID = E.Event_ID WHERE E.Status = 1" +
            //                    "Group By C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model Order by [Row#]";
            //    Command = new SqlCommand(strQuery, SQL);
            //    Reader = Command.ExecuteReader();
            //    while (Reader.Read())
            //    {
            //        lstData.Add(Reader.GetInt64(0).ToString() + "," +
            //            Reader.GetString(1) + "," +
            //            Reader.GetInt32(2).ToString() + "," +
            //            Reader.GetString(3) + "," +
            //            Reader.GetString(4) + "," +
            //            Reader.GetInt32(5).ToString() + "," +
            //            Reader.GetString(6) + "," +
            //            Reader.GetString(7) + "," +
            //            Reader.GetInt32(8).ToString() + "," +
            //            Reader.GetDecimal(9).ToString() + "," +
            //            Reader.GetInt32(10).ToString() + "," +
            //            Reader.GetInt32(11).ToString() + "," +
            //            Reader.GetDecimal(12).ToString()
            //            );
            //    }
            //    Reader.Close();

            //}
            //SQL.Close();

            //foreach (string item in lstData)
            //{
            //    string[] strSplit = item.Split(new Char[] { ',' });
            //    File.AppendAllText(strFileName, "<TR VALIGN=TOP>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[9] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[10] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[11] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[12] + "</FONT></TD>" + Environment.NewLine +
            //                        "</TR>" + Environment.NewLine + Environment.NewLine);
            //}
            //File.AppendAllText(strFileName, "</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");
        }

        public static void ExportStages()
        {
            Resources.Destination_Directory();

            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            string strFileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCross\Stages_Overall.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            //Upload New Query
            SqlConnection SQL = SQL_Commands.Connect(); ;
            SQL.Open();
            using (SQL)
            {
                //Get Event Information
                string strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();

                strQuery = "SELECT C.Class_Name, N.Number, D.First_Name, D.Last_Name, T.Stage_Number, T.Stage_Time, T.Cones_Hit, T.Gates_Missed, T.Off_Course, T.Total_Time " +
                                     "FROM tbl_Time as T " +
                                     "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                     "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                     "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                     "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                     "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                     "WHERE E.Status = 1 " +
                                     "ORDER BY C.Class_Name, D.Last_Name, D.First_Name, T.Stage_Number";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader[0].ToString() + "," +
                                Reader[1].ToString() + "," +
                                Reader[2].ToString() + "," +
                                Reader[3].ToString() + "," +
                                Reader[4].ToString() + "," +
                                Reader[5].ToString() + "," +
                                Reader[6].ToString() + "," +
                                Reader[7].ToString() + "," +
                                Reader[8].ToString() + "," +
                                Reader[9].ToString()
                                );
                }
                Reader.Close();
            }
            SQL.Close();

            //Create New File
            lstExport.Add("<HTML>" + Environment.NewLine +
                "<HEAD>" + Environment.NewLine +
                "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                "<TITLE>Stages Overall</TITLE>" + Environment.NewLine +
                "</HEAD>" + Environment.NewLine +
                "<BODY>" + Environment.NewLine +
                "<FONT FACE=\"Calibri\" COLOR=#000000><B>Stages Overall</B></FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                "<THEAD>" + Environment.NewLine +
                "<TR>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Stage</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Time</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>DNF</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Total</FONT></TH>" + Environment.NewLine + Environment.NewLine +
                "</TR>" + Environment.NewLine +
                "</THEAD>" + Environment.NewLine +
                "<TBODY>" + Environment.NewLine + Environment.NewLine);

            //Write Query Data to File
            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[9] + "</FONT></TD>" + Environment.NewLine + Environment.NewLine +
                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }

        public static void UploadStages()
        {

            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            string strFileName = @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Stage_Times.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            //Upload New Query
            SqlConnection SQL = SQL_Commands.Connect(); ;
            SQL.Open();
            using (SQL)
            {
                //Get Event Information
                string strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();

                strQuery = "SELECT TOP(50) C.Class_Name, N.Number, D.First_Name, D.Last_Name, T.Stage_Number, T.Stage_Time, T.Cones_Hit, T.Gates_Missed, T.Off_Course, T.Total_Time " +
                                     "FROM tbl_Time as T " +
                                     "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                     "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                     "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                     "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                     "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                     "WHERE E.Status = 1 " +
                                     "ORDER BY T.TIme_ID DESC";


                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader[0].ToString() + "," +
                                Reader[1].ToString() + "," +
                                Reader[2].ToString() + "," +
                                Reader[3].ToString() + "," +
                                Reader[4].ToString() + "," +
                                Reader[5].ToString() + "," +
                                Reader[6].ToString() + "," +
                                Reader[7].ToString() + "," +
                                Reader[8].ToString() + "," +
                                Reader[9].ToString()
                                );
                }
                Reader.Close();
            }
            SQL.Close();

            //Create New File
            lstExport.Add("<HTML>" + Environment.NewLine +
                "<HEAD>" + Environment.NewLine +
                "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                "<TITLE>Stages Overall</TITLE>" + Environment.NewLine +
                "</HEAD>" + Environment.NewLine +
                "<BODY>" + Environment.NewLine +
                "<FONT FACE=\"Calibri\" COLOR=#000000><B>Recent Stages</B></FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                "<THEAD>" + Environment.NewLine +
                "<TR>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Stage</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Time</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>DNF</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>Total</FONT></TH>" + Environment.NewLine + Environment.NewLine +
                "</TR>" + Environment.NewLine +
                "</THEAD>" + Environment.NewLine +
                "<TBODY>" + Environment.NewLine + Environment.NewLine);

            //Write Query Data to File
            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-Size:12pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[9] + "</FONT></TD>" + Environment.NewLine + Environment.NewLine +
                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }

        public static void UploadOverallResults()
        {

            string strFileName = @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Event_Results_Overall.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            //Get Classes
            List<int> lstClassID = new List<int>();
            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                //Get Event Information
                string strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();

                //Write File Header
                lstExport.Add("<HTML>" + Environment.NewLine +
                    "<HEAD>" + Environment.NewLine +
                    "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                    "<TITLE>Overall Results</TITLE>" + Environment.NewLine +
                    "</HEAD>" + Environment.NewLine +
                    "<BODY>" + Environment.NewLine +
                    "<FONT FACE=\"Calibri\" COLOR=#000000><B>Overall Results</B></FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                    "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                    "<THEAD>" + Environment.NewLine +
                    "<TR>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Rank</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Completed</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stage Time</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>OC/DNF</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Total Time</FONT></TH>" + Environment.NewLine +
                    "</TR>" + Environment.NewLine +
                    "</THEAD>" + Environment.NewLine +
                    "<TBODY>" + Environment.NewLine);

                //Get Report

                strQuery = "SELECT ROW_NUMBER() OVER (Order By SUM(T.Total_Time) ASC) AS [Row#], C.Class_Name, N.Number, " +
                        "D.First_Name, D.Last_Name, V.Year, V.Make,	V.Model, SUM(CASE WHEN T.Off_Course = 1 THEN 0 ELSE 1 END), Count(T.Stage_Time), SUM(T.Stage_Time), " +
                        "SUM(T.Cones_Hit), SUM(T.Gates_Missed), SUM(CAST(T.Off_Course AS Int)), SUM(T.Total_Time) as [sumT] " +
                        "FROM tbl_Time as T INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                        "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                        "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
                        "INNER Join tbl_Event as E on R.Event_ID = E.Event_ID WHERE E.Status = 1 " +
                        "Group By C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model Order by [Row#]";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader.GetInt64(0).ToString() + "," +
                        Reader.GetString(1) + "," +
                        Reader.GetInt32(2).ToString() + "," +
                        Reader.GetString(3) + "," +
                        Reader.GetString(4) + "," +
                        Reader.GetInt32(5).ToString() + "," +
                        Reader.GetString(6) + "," +
                        Reader.GetString(7) + "," +
                        Reader.GetInt32(8).ToString() + "," +
                        Reader.GetInt32(9).ToString() + "," +
                        Reader.GetDecimal(10).ToString() + "," +
                        Reader.GetInt32(11).ToString() + "," +
                        Reader.GetInt32(12).ToString() + "," +
                        Reader.GetInt32(13).ToString() + "," +
                        Reader.GetDecimal(14).ToString()
                        );
                }
                Reader.Close();
            }
            SQL.Close();

            //Add Report Results to Export List

            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "/" + strSplit[9] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[10] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[11] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[12] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[13] + "</FONT></TD>" + Environment.NewLine +
                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[14] + "</FONT></TD>" + Environment.NewLine +
                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);

            //    //Write File Header
            //    File.WriteAllText(strFileName,
            //        "<HTML>" + Environment.NewLine +
            //        "<HEAD>" + Environment.NewLine +
            //        "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
            //        "<TITLE>Overall Results</TITLE>" + Environment.NewLine +
            //        "</HEAD>" + Environment.NewLine +
            //        "<BODY>" + Environment.NewLine +
            //        "<FONT FACE=\"Calibri\" COLOR=#000000><B>Overall Results</B></FONT><BR/>" + Environment.NewLine +
            //        "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
            //        "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
            //        "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
            //        "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
            //        "<THEAD>" + Environment.NewLine +
            //        "<TR>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Rank</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stages Comp.</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stage Time</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
            //        "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Total Time</FONT></TH>" + Environment.NewLine +
            //        "</TR>" + Environment.NewLine +
            //        "</THEAD>" + Environment.NewLine +
            //        "<TBODY>" + Environment.NewLine);

            //    //Get Report

            //    strQuery = "SELECT	ROW_NUMBER() OVER (Order By SUM(T.Total_Time) ASC) AS [Row#], C.Class_Name, N.Number, " +
            //                    "D.First_Name, D.Last_Name, V.Year, V.Make,	V.Model, SUM(CASE WHEN T.Off_Course = 0 THEN 1 ELSE NULL END), SUM(Stage_Time), " +
            //                    "SUM(T.Cones_Hit), SUM(T.Gates_Missed), SUM(T.Total_Time) as [sumT] " +
            //                    "FROM tbl_Time as T INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
            //                    "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
            //                    "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
            //                    "INNER Join tbl_Event as E on R.Event_ID = E.Event_ID WHERE E.Status = 1" +
            //                    "Group By C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model Order by [Row#]";
            //    Command = new SqlCommand(strQuery, SQL);
            //    Reader = Command.ExecuteReader();
            //    while (Reader.Read())
            //    {
            //        lstData.Add(Reader.GetInt64(0).ToString() + "," +
            //            Reader.GetString(1) + "," +
            //            Reader.GetInt32(2).ToString() + "," +
            //            Reader.GetString(3) + "," +
            //            Reader.GetString(4) + "," +
            //            Reader.GetInt32(5).ToString() + "," +
            //            Reader.GetString(6) + "," +
            //            Reader.GetString(7) + "," +
            //            Reader.GetInt32(8).ToString() + "," +
            //            Reader.GetDecimal(9).ToString() + "," +
            //            Reader.GetInt32(10).ToString() + "," +
            //            Reader.GetInt32(11).ToString() + "," +
            //            Reader.GetDecimal(12).ToString()
            //            );
            //    }
            //    Reader.Close();

            //}
            //SQL.Close();

            //foreach (string item in lstData)
            //{
            //    string[] strSplit = item.Split(new Char[] { ',' });
            //    File.AppendAllText(strFileName, "<TR VALIGN=TOP>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[9] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[10] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[11] + "</FONT></TD>" + Environment.NewLine +
            //                        "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[12] + "</FONT></TD>" + Environment.NewLine +
            //                        "</TR>" + Environment.NewLine + Environment.NewLine);
            //}
            //File.AppendAllText(strFileName, "</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");
        }

        public static void UploadDriverReport()
        {
            List<string> lstData = new List<string>();
            List<string> lstExport = new List<string>();
            string strFileName = @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Drivers_List.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {

                SqlCommand Command;
                SqlDataReader Reader;
                string strQuery;

                strQuery =
                    "SELECT C.Class_Name, D.First_Name, D.Last_Name, N.Number, V.Year, V.Make, V.Model, D.Hometown " +
                    "FROM tbl_Registration AS R " +
                    "INNER JOIN tbl_Event AS E ON R.Event_ID = E.Event_ID " +
                    "INNER JOIN tbl_Driver AS D on R.Driver_ID = D.Driver_ID " +
                    "INNER JOIN tbl_Class AS C on R.Class_ID = C.Class_ID " +
                    "INNER JOIN tbl_Number AS N on R.Number_ID = N.Number_ID " +
                    "INNER JOIN tbl_Vehicle AS V on R.Vehicle_ID = V.Vehicle_ID " +
                    "WHERE E.Status = 1 AND R.Checked_In = 1" +
                    "ORDER BY C.Class_Name, D.Last_Name, D.First_Name ";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstData.Add(Reader.GetString(0) + "," +
                                Reader.GetString(1) + "," +
                                Reader.GetString(2) + "," +
                                Reader.GetInt32(3).ToString() + "," +
                                Reader.GetInt32(4).ToString() + "," +
                                Reader.GetString(5) + "," +
                                Reader.GetString(6) + "," +
                                Reader.GetString(7));
                }
                Reader.Close();

                strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();
            }
            SQL.Close();

            lstExport.Add("<HTML>" + Environment.NewLine +
                "<HEAD>" + Environment.NewLine +
                "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                "<TITLE>Driver's List</TITLE>" + Environment.NewLine +
                "</HEAD>" + Environment.NewLine +
                "<BODY>" + Environment.NewLine +
                "<FONT FACE=\"Calibri\" COLOR=#000000><B>Driver's List</B></FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                "<THEAD>" + Environment.NewLine +
                "<TR>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
                "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Hometown</FONT></TH>" + Environment.NewLine +
                "</TR>" + Environment.NewLine +
                "</THEAD>" + Environment.NewLine +
                "<TBODY>" + Environment.NewLine + Environment.NewLine);

            foreach (string item in lstData)
            {
                string[] strSplit = item.Split(new Char[] { ',' });
                lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                                    "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                                    "</TR>" + Environment.NewLine + Environment.NewLine);
            }
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }

        public static void UploadClassResults()
        {

            List<string> lstExport = new List<string>();
            string strFileName = @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Event_Results.html";
            string strEventName = "";
            string strVenueName = "";
            DateTime dtEventDate = DateTime.Now;

            //Get Classes
            List<int> lstClassID = new List<int>();
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                //Get Classes
                string strQuery = "SELECT DISTINCT C.Class_ID FROM tbl_Class as C " +
                                  "INNER JOIN tbl_Registration as R on C.Class_ID = R.Class_ID " +
                                  "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                  "WHERE E.Status = 1";
                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    lstClassID.Add(Reader.GetInt32(0));
                }
                Reader.Close();

                //Get Event Information
                strQuery = "SELECT E.Date, E.Name, V.Name FROM tbl_Event AS E INNER JOIN tbl_Venue as V ON E.Venue_ID = V.Venue_ID WHERE E.Status = 1";
                Command = new SqlCommand(strQuery, SQL);
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    dtEventDate = Reader.GetDateTime(0).Date;
                    strEventName = Reader.GetString(1);
                    strVenueName = Reader.GetString(2);
                }
                Reader.Close();

                //Write File Header
                lstExport.Add("<HTML>" + Environment.NewLine +
                    "<HEAD>" + Environment.NewLine +
                    "<META HTTP-EQUIV=\"Content-Type\" CONTENT=\"text/html;charset=windows-1252\">" + Environment.NewLine +
                    "<TITLE>Class Results</TITLE>" + Environment.NewLine +
                    "</HEAD>" + Environment.NewLine +
                    "<BODY>" + Environment.NewLine +
                    "<FONT FACE=\"Calibri\" COLOR=#000000><B>Class Results</B></FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Event Name: </B>" + strEventName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Venue Name: </B>" + strVenueName + "</FONT><BR/>" + Environment.NewLine +
                    "<FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000><B>Date: </B>" + dtEventDate.ToString("MM/dd/yyyy") + "</FONT><HR>" + Environment.NewLine +
                    "<TABLE BORDER=1 BGCOLOR=#ffffff CELLSPACING=0>" + Environment.NewLine +
                    "<THEAD>" + Environment.NewLine +
                    "<TR>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Rank</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Class</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Number</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>First</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Last</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Year</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Make</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Model</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Completed</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Stage Time</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Cones</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Gates</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>OC/DNF</FONT></TH>" + Environment.NewLine +
                    "<TH BGCOLOR=#c0c0c0 BORDERCOLOR=#000000 ><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>Total Time</FONT></TH>" + Environment.NewLine +
                    "</TR>" + Environment.NewLine +
                    "</THEAD>" + Environment.NewLine +
                    "<TBODY>" + Environment.NewLine);

                //Get Report
                foreach (int ID in lstClassID)
                {
                    List<string> lstData = new List<string>();
                    strQuery = "SELECT	ROW_NUMBER() OVER (Order By SUM(T.Total_Time) ASC) AS [Row#], C.Class_Name, N.Number, " +
                                "D.First_Name, D.Last_Name, V.Year, V.Make,	V.Model, SUM(CASE WHEN T.Off_Course = 1 THEN 0 ELSE 1 END), Count(T.Stage_Time), SUM(Stage_Time), " +
                                "SUM(T.Cones_Hit), SUM(T.Gates_Missed), SUM(CAST(T.Off_Course AS Int)), SUM(T.Total_Time) as [sumT] " +
                                "FROM tbl_Time as T INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID INNER JOIN tbl_Vehicle as V on R.Vehicle_ID = V.Vehicle_ID " +
                                "INNER Join tbl_Event as E on R.Event_ID = E.Event_ID WHERE E.Status = 1 AND C.Class_ID = " + ID + " " +
                                "Group By C.Class_Name, N.Number, D.First_Name, D.Last_Name, V.Year, V.Make, V.Model Order by [Row#]";
                    Command = new SqlCommand(strQuery, SQL);
                    Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        lstData.Add(Reader.GetInt64(0).ToString() + "," +
                            Reader.GetString(1) + "," +
                            Reader.GetInt32(2).ToString() + "," +
                            Reader.GetString(3) + "," +
                            Reader.GetString(4) + "," +
                            Reader.GetInt32(5).ToString() + "," +
                            Reader.GetString(6) + "," +
                            Reader.GetString(7) + "," +
                            Reader.GetInt32(8).ToString() + "," +
                            Reader.GetInt32(9).ToString() + "," +
                            Reader.GetDecimal(10).ToString() + "," +
                            Reader.GetInt32(11).ToString() + "," +
                            Reader.GetInt32(12).ToString() + "," +
                            Reader.GetInt32(13).ToString() + "," +
                            Reader.GetDecimal(14).ToString()
                            );
                    }
                    Reader.Close();

                    foreach (string item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ',' });
                        lstExport.Add("<TR VALIGN=TOP>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[0] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[1] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[2] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[3] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[4] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[5] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[6] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=LEFT><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[7] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[8] + "/" + strSplit[9] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[10] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[11] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[12] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[13] + "</FONT></TD>" + Environment.NewLine +
                                            "<TD BORDERCOLOR=#d0d7e5 ALIGN=CENTER><FONT style=FONT-SIZE:11pt FACE=\"Calibri\" COLOR=#000000>" + strSplit[14] + "</FONT></TD>" + Environment.NewLine +
                                            "</TR>" + Environment.NewLine + Environment.NewLine);
                    }

                    lstExport.Add("<TR BORDER=0 HEIGHT=10><TD ColSpan=\"14\"/></TD></TR>" + Environment.NewLine);
                }
            }
            SQL.Close();
            lstExport.Add("</TBODY><TFOOT></TFOOT></TABLE></BODY></HTML>");

            File.WriteAllLines(strFileName, lstExport);
        }
    }
    public class Resources
    {
        public static decimal Caluclate_FinishTime(decimal StageTime, int Cones, int Gates, bool OffCourse)
        {
            double FinishTime;
            if (OffCourse == true)
            {
                FinishTime = 999.999;
            }
            else
            {
                FinishTime = Convert.ToDouble(StageTime) + (Cones * 2) + (Gates * 10);
            }
            return Convert.ToDecimal(FinishTime);
        }

        public static bool Check_Fields(ComboBox cmbNumber, MaskedTextBox mskStageTime)
        {
            bool blResult = false;
            if (cmbNumber.SelectedIndex == -1)
            {
                blResult = true;
            }
            if (mskStageTime.MaskFull == false)
            {
                blResult = true;
            }

            if (blResult == true)
            {
                MessageBox.Show("Incomplete Fields Entries, Please Verify Entries");
            }
            return blResult;
        }

        public static void Write_Results(int Number, int Stage, decimal StageTime, int Cones, int Gates, bool OffCourse, decimal TotalTime)
        {
            //Get Connection
            SqlConnection SQL = SQL_Commands.Connect();

            //Get Registration ID
            int intRegID = 0;

            SQL.Open();
            using (SQL)
            {
                string strQuery = "SELECT R.Registration_ID " +
                                    "FROM tbl_Registration as R " +
                                    "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                    "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                    "WHERE E.Status = 1 AND N.Number = " + Number;
                SqlCommand dbCommand = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = dbCommand.ExecuteReader();
                while (Reader.Read())
                {
                    intRegID = Reader.GetInt32(0);
                }
                Reader.Close();
            }
            SQL.Close();

            //Define Insert Query
            SqlCommand Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = "INSERT INTO tbl_Time (Registration_ID, Stage_Number, Stage_Time, Cones_Hit, Gates_Missed, Off_Course, Total_Time) " +
                                        "VALUES (@RI, @SN, @ST, @CH, @GM, @OC, @TT)";
            Command.Parameters.AddWithValue("@RI", intRegID);
            Command.Parameters.AddWithValue("@SN", Stage);
            Command.Parameters.AddWithValue("@ST", StageTime);
            Command.Parameters.AddWithValue("@CH", Cones);
            Command.Parameters.AddWithValue("@GM", Gates);
            Command.Parameters.AddWithValue("@OC", OffCourse);
            Command.Parameters.AddWithValue("@TT", TotalTime);

            //Open Connection and Execute Query
            Command.Connection = SQL;
            SQL.Open();
            Command.ExecuteNonQuery();
            SQL.Close();
        }

        //Sample Code to be Tested 
        public static void Write_Results2(string Number, int Stage, decimal StageTime, int Cones, int Gates, bool OffCourse, decimal TotalTime)
        {
            //Get Connection
            SqlConnection SQL = SQL_Commands.Connect();

            //Get Registration ID
            int intRegID = 0;
            int intVehicleNumber = Convert.ToInt32(Number.Split(new Char[] { ' ' })[0]);
            string strClass = Number.Split(new Char[] { ' ' })[1];

            SQL.Open();
            using (SQL)
            {
                string strQuery = "SELECT R.Registration_ID " +
                                    "FROM tbl_Registration as R " +
                                    "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                    "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                    "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                    "WHERE E.Status = 1 AND N.Number = " + intVehicleNumber + " AND C.Class_Name = '" + strClass + "'";
                SqlCommand dbCommand = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = dbCommand.ExecuteReader();
                while (Reader.Read())
                {
                    intRegID = Reader.GetInt32(0);
                }
                Reader.Close();
            }
            SQL.Close();

            //Define Insert Query
            SqlCommand Command = new SqlCommand();
            Command.CommandType = CommandType.Text;
            Command.CommandText = "INSERT INTO tbl_Time (Registration_ID, Stage_Number, Stage_Time, Cones_Hit, Gates_Missed, Off_Course, Total_Time) " +
                                        "VALUES (@RI, @SN, @ST, @CH, @GM, @OC, @TT)";
            Command.Parameters.AddWithValue("@RI", intRegID);
            Command.Parameters.AddWithValue("@SN", Stage);
            Command.Parameters.AddWithValue("@ST", StageTime);
            Command.Parameters.AddWithValue("@CH", Cones);
            Command.Parameters.AddWithValue("@GM", Gates);
            Command.Parameters.AddWithValue("@OC", OffCourse);
            Command.Parameters.AddWithValue("@TT", TotalTime);

            //Open Connection and Execute Query
            SQL = SQL_Commands.Connect();
            Command.Connection = SQL;
            SQL.Open();
            Command.ExecuteNonQuery();
            SQL.Close();
        }

        public static bool Confirm_Delete()
        {
            bool confirm = false;
            var result = new DialogResult();

            result = MessageBox.Show("Please confirm you want to delete these drivers.", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                confirm = true;
            }
            return confirm;
        }

        //Sample Code to be Tested
        public static int Get_Current_Stage2(string VehicleNumber)
        {
            int intStages = 0;
            int intVehicleNumber = Convert.ToInt32(VehicleNumber.Split(new Char[] { ' ' })[0]);
            string strClass = VehicleNumber.Split(new Char[] { ' ' })[1];
            //Test Vehicle Number And Class Code
            Console.WriteLine(intVehicleNumber + " // " + strClass);


            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                string strQuery = "SELECT Count(T.Stage_Number) " +
                                    "FROM tbl_Time as T " +
                                    "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                    "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                    "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                    "INNER JOIN tbl_Class as C on C.Class_ID = R.Class_ID " +
                                    "WHERE E.Status = 1 AND N.Number = " + intVehicleNumber + " AND C.Class_Name = '" + strClass + "'";

                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    intStages = Reader.GetInt32(0) + 1;
                }
                Reader.Close();
            }
            SQL.Close();
            return intStages;
        }

        public static int Get_Current_Stage(int VehicleNumber)
        {
            int intStages = 0;
            SqlConnection SQL = SQL_Commands.Connect();
            SQL.Open();
            using (SQL)
            {
                string strQuery = "SELECT Count(T.Stage_Number) " +
                                    "FROM tbl_Time as T " +
                                    "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                    "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                    "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                    "WHERE E.Status = 1 AND N.Number = " + VehicleNumber;

                SqlCommand Command = new SqlCommand(strQuery, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    intStages = Reader.GetInt32(0) + 1;
                }
                Reader.Close();
            }
            SQL.Close();
            return intStages;
        }

        public static void Destination_Directory()
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCRoss\") == false)
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\CFR_RallyCRoss\");
            }
        }
    }

    public class SQL_Commands
    {
        public static SqlConnection Connect()
        {
            return new SqlConnection(@"Data Source=(local)\SQLExpress; Initial Catalog=CFR_RallyCross_Timing_Database; Trusted_Connection=True;");
            //return new SqlConnection(@"Data Source=23.253.3.36,4120;Initial Catalog=885958_cfrallyx3;Integrated Security=False;User ID=885958_cfrallyx3;Password=Adh5mJRzCi26;Connect Timeout=30;Encrypt=False;Packet Size=4096");
        }

        public static bool IsServerConnected()
        {

            SqlConnection SQL = SQL_Commands.Connect();
            try
            {
                SQL.Open();
                SQL.Close();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }

            //using (var SQLConnection = new SqlConnection(@"Data Source=(local)\SQLExpress; Initial Catalog=CFR_RallyCross_Timing_Database; Trusted_Connection=True;"))
            //{
            //    try
            //    {
            //        SQLConnection.Open();
            //        return true;
            //    }
            //    catch (SqlException)
            //    {
            //    return false;
            //    }
            //}
        }

        public static class Timing
        {
            public static class Controls
            {
                public static void Vehicle_Number(ComboBox cmbbox)
                {
                    List<string> lstData = new List<string>();

                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        string strQuery = "SELECT DISTINCT N.Number, C.Class_Name FROM tbl_Registration as R " +
                                          "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                          "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                          "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                          "WHERE E.Status = 1 AND R.Checked_In = 1 " +
                                          "ORDER BY N.Number";
                        SqlCommand Command = new SqlCommand(strQuery, SQL);
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            lstData.Add(Reader.GetInt32(0).ToString() + " " + Reader.GetString(1));
                        }
                        Reader.Close();
                    }
                    cmbbox.DataSource = lstData.ToArray();
                    cmbbox.Update();
                }

                public static void Stages_Completed(DataGridView dgv)
                {
                    //Clear Pre-existing Rows
                    dgv.Rows.Clear();

                    //Upload New Query
                    List<string> lstData = new List<string>();
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        string strQuery = "SELECT D.First_Name, D.Last_Name, C.Class_Name, N.Number, Count(T.Stage_Number) " +
                                          "FROM tbl_Registration as R " +
                                          "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                          "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                          "INNER JOIN tbl_Number as N on N.Number_ID = R.Number_ID " +
                                          "INNER JOIN tbl_Time as T on R.Registration_ID = T.Registration_ID " +
                                          "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                          "GROUP BY D.Last_Name, D.First_Name, C.Class_Name, N.Number, E.Status " +
                                          "HAVING E.Status = 1 " +
                                          "ORDER BY Count(T.Stage_Number), C.Class_Name, D.Last_Name, D.First_Name";
                        SqlCommand Command = new SqlCommand(strQuery, SQL);
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            lstData.Add(Reader.GetString(0) + "," + Reader.GetString(1) + "," + Reader.GetString(2) + "," + Reader.GetInt32(3).ToString() + "," + Reader.GetInt32(4).ToString());
                        }
                        Reader.Close();
                    }
                    SQL.Close();

                    //Write Results to Datagrid
                    foreach (var item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ',' });
                        DataGridViewRow tempRow = (DataGridViewRow)dgv.Rows[0].Clone();
                        tempRow.Cells[0].Value = strSplit[0];
                        tempRow.Cells[1].Value = strSplit[1];
                        tempRow.Cells[2].Value = strSplit[2];
                        tempRow.Cells[3].Value = strSplit[3];
                        tempRow.Cells[4].Value = strSplit[4];
                        dgv.Rows.Add(tempRow);
                    }
                }

                public static void Stage_Times(DataGridView dgv)
                {
                    //Clear Pre-existing Rows
                    dgv.Rows.Clear();

                    List<string> lstData = new List<string>();
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        string strQuery = "SELECT T.Time_ID, D.First_Name, D.Last_Name, N.Number, T.Stage_Number, T.Stage_Time, T.Cones_Hit, T.Gates_Missed, T.Off_Course " +
                                          "FROM tbl_Time as T " +
                                          "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                                          "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                          "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                          "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                          "WHERE E.Status = 1 ORDER BY T.Time_ID DESC";
                        SqlCommand Command = new SqlCommand(strQuery, SQL);
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            lstData.Add(Reader.GetInt32(0).ToString() + "," +
                                        Reader.GetString(1) + "," +
                                        Reader.GetString(2) + "," +
                                        Reader.GetInt32(3).ToString() + "," +
                                        Reader.GetInt32(4).ToString() + "," +
                                        Reader.GetDecimal(5).ToString() + "," +
                                        Reader.GetInt32(6).ToString() + "," +
                                        Reader.GetInt32(7).ToString() + "," +
                                        Reader.GetBoolean(8).ToString());
                        }
                        Reader.Close();
                    }
                    SQL.Close();

                    //Write Results to Datagrid
                    foreach (var item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ',' });
                        DataGridViewRow tempRow = (DataGridViewRow)dgv.Rows[0].Clone();
                        tempRow.Cells[0].Value = strSplit[0];
                        tempRow.Cells[1].Value = strSplit[1];
                        tempRow.Cells[2].Value = strSplit[2];
                        tempRow.Cells[3].Value = strSplit[3];
                        tempRow.Cells[4].Value = strSplit[4];
                        tempRow.Cells[5].Value = strSplit[5];
                        tempRow.Cells[6].Value = strSplit[6];
                        tempRow.Cells[7].Value = strSplit[7];
                        tempRow.Cells[8].Value = strSplit[8];
                        dgv.Rows.Add(tempRow);
                    }
                }
            }
            public static class Get
            {
                //Get List of All DNF in an Event
                public static List<Timing_Data> DNF(SqlConnection SQL)
                {
                    List<Timing_Data> lstTD = new List<Timing_Data>();
                    SqlCommand Command = new SqlCommand("SELECT T.Time_ID, C.Class_ID, R.Registration_ID, T.Stage_Number, T.Stage_Time, T.Cones_Hit, T.Gates_Missed, T.Off_Course, T.Total_Time from tbl_Time as T " +
                                                        "INNER JOIN tbl_Registration as R ON T.Registration_ID = R.Registration_ID " +
                                                        "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                                        "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                                                        "WHERE Off_Course = 1 AND E.Status = 1", SQL);
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        lstTD.Add(new Timing_Data
                        {
                            Time_ID = Reader.GetInt32(0),
                            Class_ID = Reader.GetInt32(1),
                            Registration_ID = Reader.GetInt32(2),
                            Stage_Number = Reader.GetInt32(3),
                            Stage_Time = Reader.GetDecimal(4),
                            Cones_Hit = Reader.GetInt32(5),
                            Gates_Missed = Reader.GetInt32(6),
                            Off_Course = Reader.GetBoolean(7),
                            Total_Time = Reader.GetDecimal(8)
                        });
                    }
                    Reader.Close();
                    return lstTD;
                }

                //Get Max Stage Time Per Class Per Stage
                public static decimal MaxStage(Timing_Data td, SqlConnection SQL)
                {
                    decimal dec_StageMax = 0;
                    SqlCommand Command = new SqlCommand("SELECT Max(T.Total_Time) from tbl_Time as T " +
                        "INNER JOIN tbl_Registration as R on T.Registration_ID = R.Registration_ID " +
                        "INNER JOIN tbl_Event as E on R.Event_ID = E.Event_ID " +
                        "WHERE R.Class_ID = " + td.Class_ID + " AND T.Stage_Number = " + td.Stage_Number + " AND Off_Course = 0 AND E.Status = 1", SQL);
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        dec_StageMax = Reader.GetDecimal(0);
                    }
                    Reader.Close();
                    return dec_StageMax;
                }

            }

            public static class Set
            {
                public static void DNF(List<Timing_Data> lstTD, SqlConnection SQL)
                {
                    foreach(Timing_Data td in lstTD)
                    {
                        decimal MaxStage = SQL_Commands.Timing.Get.MaxStage(td, SQL);
                        decimal AdjustedMax = MaxStage + 10;

                        using (var transaction = SQL.BeginTransaction())
                        {
                            try
                            {
                                SqlCommand Command = new SqlCommand("UPDATE tbl_Time " +
                                                                    "SET Registration_ID = @RegID, Stage_Number = @StageNum, Stage_Time = @StageTime, Cones_Hit = @Cones, Gates_Missed = @Gates, Off_Course = @DNF, Total_Time = @Total WHERE Time_ID = @TimeID", SQL, transaction);
                                Command.Parameters.AddWithValue("@TimeID", td.Time_ID);
                                Command.Parameters.AddWithValue("@RegID", td.Registration_ID);
                                Command.Parameters.AddWithValue("@StageNum", td.Stage_Number);
                                Command.Parameters.AddWithValue("@StageTime", AdjustedMax);
                                Command.Parameters.AddWithValue("@Cones", td.Cones_Hit);
                                Command.Parameters.AddWithValue("@Gates", td.Gates_Missed);
                                Command.Parameters.AddWithValue("@DNF", td.Off_Course);
                                Command.Parameters.AddWithValue("@Total", AdjustedMax);
                                Command.ExecuteNonQuery();
                                transaction.Commit();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                                transaction.Rollback();
                            }
                        }
                    }
                }
            }
        }

        public static class Venues
        {
            public static class Get
            {
                public static void Venues(DataGridView dgv)
                {
                    dgv.Rows.Clear();

                    List<string> lstData = new List<string>();
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        string strQuery = "SELECT * FROM Tbl_Venue";
                        SqlCommand Command = new SqlCommand(strQuery, SQL);
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            lstData.Add(Reader.GetInt32(0).ToString() + ";" +
                                        Reader.GetString(1) + ";" +
                                        Reader.GetString(2) + ";" +
                                        Reader.GetString(3) + ";" +
                                        Reader.GetString(4) + ";" +
                                        Reader.GetString(5));
                        }
                        Reader.Close();
                    }
                    SQL.Close();

                    //Write Results to Datagrid
                    foreach (var item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ';' });
                        DataGridViewRow tempRow = (DataGridViewRow)dgv.Rows[0].Clone();
                        tempRow.Cells[0].Value = strSplit[0];
                        tempRow.Cells[1].Value = strSplit[1];
                        tempRow.Cells[2].Value = strSplit[2];
                        tempRow.Cells[3].Value = strSplit[3];
                        tempRow.Cells[4].Value = strSplit[4];
                        tempRow.Cells[5].Value = strSplit[5];
                        dgv.Rows.Add(tempRow);
                    }
                }
            }
        }

        public static class Events
        {
            public static class Get
            {
                public static void Events(DataGridView dgv)
                {
                    //Clear Pre-existing Rows
                    dgv.Rows.Clear();

                    List<string> lstData = new List<string>();
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        string strQuery = "SELECT * FROM Tbl_Event";
                        SqlCommand Command = new SqlCommand(strQuery, SQL);
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            lstData.Add(Reader.GetInt32(0).ToString() + ";" +
                                        Reader.GetDecimal(1).ToString() + ";" +
                                        Reader.GetString(2) + ";" +
                                        Reader.GetDateTime(3).ToString() + ";" +
                                        Reader.GetBoolean(4).ToString() + ";" +
                                        Reader.GetInt32(5).ToString());
                        }
                        Reader.Close();
                    }
                    SQL.Close();

                    //Write Results to Datagrid
                    foreach (var item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ';' });
                        DataGridViewRow tempRow = (DataGridViewRow)dgv.Rows[0].Clone();
                        tempRow.Cells[0].Value = strSplit[0];
                        tempRow.Cells[1].Value = strSplit[1];
                        tempRow.Cells[2].Value = strSplit[2];
                        tempRow.Cells[3].Value = strSplit[3];
                        tempRow.Cells[4].Value = strSplit[4];
                        tempRow.Cells[5].Value = strSplit[5];
                        dgv.Rows.Add(tempRow);
                    }
                }
            }

            public static class Remove
            {
                public static void Events(DataGridView dgv)
                {
                    //Delete row
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        foreach (DataGridViewRow tempRow in dgv.SelectedRows)
                        {
                            using (var transaction = SQL.BeginTransaction())
                            {
                                try
                                {
                                    int intID;
                                    intID = Convert.ToInt32(tempRow.Cells[0].Value);

                                    string strQuery = "DELETE FROM tbl_Event WHERE Event_ID = @ID";

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
                }
            }

            public static class Update
            {
                public static void Event(DataGridView dgv)
                {
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        foreach (DataGridViewRow tempRow in dgv.Rows)
                        {
                            if (tempRow.IsNewRow == false)
                            {
                                int intID = Convert.ToInt32(tempRow.Cells[0].Value);
                                decimal decNumber = Convert.ToDecimal(tempRow.Cells[1].Value.ToString());
                                string strName = tempRow.Cells[2].Value.ToString();
                                DateTime dtDate = Convert.ToDateTime(tempRow.Cells[3].Value.ToString());
                                bool blStatus = Convert.ToBoolean(tempRow.Cells[4].Value.ToString());
                                int intVenueID = Convert.ToInt32(tempRow.Cells[5].Value.ToString());

                                using (var dbTransaction = SQL.BeginTransaction())
                                {

                                    try
                                    {
                                        string strQuery = "UPDATE tbl_Event " +
                                                          "SET Number = @N, Name = @NA, Date = @D, Status = @S, Venue_ID = @VD " +
                                                          "WHERE Event_ID = @E";
                                        SqlCommand dbCommand = new SqlCommand(strQuery, SQL, dbTransaction);
                                        dbCommand.Parameters.AddWithValue("@E", intID);
                                        dbCommand.Parameters.AddWithValue("@N", decNumber);
                                        dbCommand.Parameters.AddWithValue("@NA", strName);
                                        dbCommand.Parameters.AddWithValue("@D", dtDate);
                                        dbCommand.Parameters.AddWithValue("@S", blStatus);
                                        dbCommand.Parameters.AddWithValue("@VD", intVenueID);
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
                }
            }
        }

        public static class Drivers
        {
            public static class Controls
            {
                public static void Update_DataGridView(DataGridView dgv)
                {
                    //Clear Pre-existing Rows
                    dgv.Rows.Clear();

                    List<string> lstData = new List<string>();
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        string strQuery = "SELECT * FROM Tbl_Driver";
                        SqlCommand Command = new SqlCommand(strQuery, SQL);
                        SqlDataReader Reader = Command.ExecuteReader();
                        while (Reader.Read())
                        {
                            lstData.Add(Reader.GetInt32(0).ToString() + ";" +
                                        Reader.GetString(1) + ";" +
                                        Reader.GetString(2) + ";" +
                                        Reader.GetString(3) + ";" +
                                        Reader.GetString(4) + ";" +
                                        Reader.GetString(5));

                        }
                        Reader.Close();
                    }
                    SQL.Close();

                    //Write Results to Datagrid
                    foreach (var item in lstData)
                    {
                        string[] strSplit = item.Split(new Char[] { ';' });
                        DataGridViewRow tempRow = (DataGridViewRow)dgv.Rows[0].Clone();
                        tempRow.Cells[0].Value = strSplit[0];
                        tempRow.Cells[1].Value = strSplit[1];
                        tempRow.Cells[2].Value = strSplit[2];
                        tempRow.Cells[3].Value = strSplit[3];
                        tempRow.Cells[4].Value = strSplit[4];
                        tempRow.Cells[5].Value = strSplit[5];
                        dgv.Rows.Add(tempRow);
                    }
                }
            }
        }

        public static class Registration
        {
            public static class Update
            {
                public static void Driver(ComboBox cmb_FirstName, ComboBox cmb_LastName, ComboBox cmb_MemberNumber, ComboBox cmb_Hometown)
                {
                    List<string> lstFirstName = new List<string>();
                    List<string> lstLastName = new List<string>();
                    List<string> lstMemberNumber = new List<string>();
                    List<string> lstHomeTown = new List<string>();

                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        SqlCommand SQLCommand;
                        SqlDataReader SQLReader;

                        SQLCommand = new SqlCommand("SELECT DISTINCT * FROM tbl_Driver", SQL);
                        SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            lstLastName.Add(SQLReader.GetString(1));
                            lstFirstName.Add(SQLReader.GetString(2));
                            if (SQLReader[3] != null && SQLReader[3] != DBNull.Value)
                            {
                                lstMemberNumber.Add(SQLReader.GetString(3));
                            }
                            if (SQLReader[4] != null && SQLReader[4] != DBNull.Value)
                            {
                                lstHomeTown.Add(SQLReader.GetString(4));
                            }

                        }
                        SQLReader.Close();
                    }
                    SQL.Close();

                    lstFirstName.Sort();
                    cmb_FirstName.DataSource = lstFirstName.Distinct().ToArray();
                    cmb_FirstName.Update();
                    cmb_FirstName.SelectedIndex = -1;

                    lstLastName.Sort();
                    cmb_LastName.DataSource = lstLastName.Distinct().ToArray();
                    cmb_LastName.Update();
                    cmb_LastName.SelectedIndex = -1;

                    lstMemberNumber.Sort();
                    cmb_MemberNumber.DataSource = lstMemberNumber.Distinct().ToArray();
                    cmb_MemberNumber.Update();
                    cmb_MemberNumber.SelectedIndex = -1;

                    lstHomeTown.Sort();
                    cmb_Hometown.DataSource = lstHomeTown.Distinct().ToArray();
                    cmb_Hometown.Update();
                    cmb_Hometown.SelectedIndex = -1;
                }

                public static void Class(ComboBox cmb_Class)
                {
                    List<string> lstData = new List<string>();

                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        SqlCommand SQLCommand = new SqlCommand("Select DISTINCT Class_Name FROM tbl_Class", SQL);
                        SqlDataReader SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            lstData.Add(SQLReader.GetString(0));
                        }
                        SQLReader.Close();
                    }
                    SQL.Close();

                    //Sort and Eliminate Duplicates
                    lstData.Sort();
                    cmb_Class.DataSource = lstData.Distinct().ToArray();
                    cmb_Class.Update();
                    cmb_Class.SelectedIndex = -1;
                }

                public static void Vehicle(ComboBox cmb_Year, ComboBox cmb_Make, ComboBox cmb_Model)
                {
                    List<int> lstYear = new List<int>();
                    List<string> lstMake = new List<string>();
                    List<string> lstModel = new List<string>();

                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        SqlCommand SQLCommand;
                        SqlDataReader SQLReader;

                        //Get Year
                        SQLCommand = new SqlCommand("SELECT DISTINCT Year FROM tbl_Vehicle", SQL);
                        SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            lstYear.Add(SQLReader.GetInt32(0));
                        }
                        SQLReader.Close();

                        //Get Make
                        SQLCommand = new SqlCommand("SELECT DISTINCT Make FROM tbl_Vehicle", SQL);
                        SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            lstMake.Add(SQLReader.GetString(0));
                        }
                        SQLReader.Close();

                        //Get Model
                        SQLCommand = new SqlCommand("SELECT DISTINCT Model FROM tbl_Vehicle", SQL);
                        SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            lstModel.Add(SQLReader.GetString(0));
                        }
                        SQLReader.Close();
                    }
                    SQL.Close();

                    //Sort and Eliminate Duplicates
                    lstYear.Sort();
                    cmb_Year.DataSource = lstYear.Distinct().ToList();
                    cmb_Year.Update();
                    cmb_Year.SelectedIndex = -1;
                    //Sort and Eliminate Duplicates
                    lstMake.Sort();
                    cmb_Make.DataSource = lstMake.Distinct().ToList();
                    cmb_Make.Update();
                    cmb_Make.SelectedIndex = -1;
                    //Sort and Eliminate Duplicates
                    lstModel.Sort();
                    cmb_Model.DataSource = lstModel.Distinct().ToList();
                    cmb_Model.Update();
                    cmb_Model.SelectedIndex = -1;
                }

                public static void Event(ComboBox cmb)
                {
                    List<string> lstData = new List<string>();
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        SqlCommand SQLCommand = new SqlCommand("SELECT DISTINCT Number FROM tbl_Event WHERE Status = 1", SQL);
                        SqlDataReader SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            lstData.Add(SQLReader.GetDecimal(0).ToString());
                        }
                        SQLReader.Close();
                    }
                    SQL.Close();

                    cmb.DataSource = lstData.ToArray();
                }

                public static void Registration(DataGridView dgv_Registration)
                {
                    SqlConnection SQL = SQL_Commands.Connect();
                    SQL.Open();
                    using (SQL)
                    {
                        foreach (DataGridViewRow row in dgv_Registration.Rows)
                        {
                            if (row.IsNewRow) { break; };
                            int intRegID = Convert.ToInt32(row.Cells[0].Value.ToString());
                            int intClassID = SQL_Commands.Registration.Get.Class(row.Cells[3].Value.ToString(), SQL);
                            int intNumberID = SQL_Commands.Registration.Get.Number(Convert.ToInt32(row.Cells[4].Value.ToString()), SQL);
                            if (intNumberID == 0)
                            {
                                SQL_Commands.Registration.Create.Number(Convert.ToInt32(row.Cells[4].Value.ToString()), SQL);
                                intNumberID = SQL_Commands.Registration.Get.Number(Convert.ToInt32(row.Cells[4].Value.ToString()), SQL);
                            }
                            double dblPaymentAmount = Convert.ToDouble(row.Cells[5].Value.ToString());
                            bool PayReceived = Convert.ToBoolean(row.Cells[6].Value.ToString());
                            bool CheckedIn = Convert.ToBoolean(row.Cells[7].Value.ToString());
                            using (var transaction = SQL.BeginTransaction())
                            {
                                try
                                {
                                    SqlCommand Command = new SqlCommand("UPDATE tbl_Registration " +
                                                                        "SET Class_ID = @Class, Number_ID = @Number, Payment_Amount = @PayAmnt, Payment_Received = @PayRec, Checked_In = @ChkIn WHERE Registration_ID = @RegID", SQL, transaction);
                                    Command.Parameters.AddWithValue("@RegID", intRegID);
                                    Command.Parameters.AddWithValue("@Class", intClassID);
                                    Command.Parameters.AddWithValue("@Number", intNumberID);
                                    Command.Parameters.AddWithValue("@PayAmnt", dblPaymentAmount);
                                    Command.Parameters.AddWithValue("@PayRec", PayReceived);
                                    Command.Parameters.AddWithValue("@ChkIn", CheckedIn);
                                    Command.ExecuteNonQuery();
                                    transaction.Commit();
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.ToString());
                                    transaction.Rollback();
                                }
                            }

                        }
                    }
                    SQL.Close();
                }
            }

            public static class Get
            {
                public static int Event(double EventNumber, SqlConnection SQL)
                {
                    int intData = 0;
                    SqlCommand Command = new SqlCommand("SELECT DISTINCT Event_ID FROM tbl_Event WHERE Status = 1 AND Number = " + EventNumber, SQL);
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        intData = Reader.GetInt32(0);
                    }
                    Reader.Close();

                    return intData;
                }

                public static int Class(string Class, SqlConnection SQL)
                {
                    int intData = 0;
                    SqlCommand Command = new SqlCommand("SELECT DISTINCT Class_ID FROM tbl_Class WHERE Class_Name = '" + Class + "'", SQL);
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        intData = Reader.GetInt32(0);
                    }
                    Reader.Close();

                    return intData;
                }

                public static int Driver(string LastName, string FirstName, SqlConnection SQL)
                {
                    int intData = 0;
                    SqlCommand Command;
                    SqlDataReader Reader;
                    Command = new SqlCommand("SELECT DISTINCT Driver_ID FROM tbl_Driver WHERE Last_Name = '" + LastName + "' AND First_Name = '" + FirstName + "'", SQL);
                    Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        intData = Reader.GetInt32(0);
                    }
                    Reader.Close();

                    return intData;

                }

                public static int Number(int Number, SqlConnection SQL)
                {
                    int intData = 0;

                    SqlCommand Command = new SqlCommand("SELECT DISTINCT Number_ID FROM tbl_Number WHERE Number = " + Number, SQL);
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        intData = Reader.GetInt32(0);
                    }
                    Reader.Close();

                    return intData;
                }

                public static int Vehicle(int Year, string Make, string Model, SqlConnection SQL)
                {
                    int intData = 0;
                    SqlCommand Command = new SqlCommand("SELECT DISTINCT Vehicle_ID FROM tbl_Vehicle WHERE Year = " + Year + " AND Make = '" + Make + "' AND MODEL = '" + Model + "'", SQL);
                    SqlDataReader Reader = Command.ExecuteReader();
                    while (Reader.Read())
                    {
                        intData = Reader.GetInt32(0);
                    }
                    Reader.Close();

                    return intData;
                }

                public static void Registration(DataGridView dgv_Registration)
                {
                    dgv_Registration.Rows.Clear();

                    SqlConnection SQL = SQL_Commands.Connect();
                    SqlCommand SQLCommand;
                    SqlDataReader SQLReader;
                    SQL.Open();
                    using (SQL)
                    {
                        SQLCommand = new SqlCommand("SELECT R.Registration_ID, D.First_Name, D.Last_Name, C.Class_Name, N.Number, R.Payment_Amount, R.Payment_Received, R.Checked_In " +
                                                    "FROM tbl_Registration as R " +
                                                    "INNER JOIN tbl_Event as E ON R.Event_ID = E.Event_ID " +
                                                    "INNER JOIN tbl_Driver as D on R.Driver_ID = D.Driver_ID " +
                                                    "INNER JOIN tbl_Class as C on R.Class_ID = C.Class_ID " +
                                                    "INNER JOIN tbl_Number as N on R.Number_ID = N.Number_ID " +
                                                    "WHERE E.Status = 1", SQL);
                        SQLReader = SQLCommand.ExecuteReader();
                        while (SQLReader.Read())
                        {
                            DataGridViewRow tempRow = (DataGridViewRow)dgv_Registration.Rows[0].Clone();
                            tempRow.Cells[0].Value = SQLReader.GetInt32(0);
                            tempRow.Cells[1].Value = SQLReader.GetString(1);
                            tempRow.Cells[2].Value = SQLReader.GetString(2);
                            tempRow.Cells[3].Value = SQLReader.GetString(3);
                            tempRow.Cells[4].Value = SQLReader.GetInt32(4);
                            tempRow.Cells[5].Value = SQLReader.GetDecimal(5);
                            tempRow.Cells[6].Value = SQLReader.GetBoolean(6);
                            tempRow.Cells[7].Value = SQLReader.GetBoolean(7);
                            dgv_Registration.Rows.Add(tempRow);
                        }
                        SQLReader.Close();
                    }
                    SQL.Close();
                }
            }

            public static class Create
            {
                public static void Driver(string LastName, string FirstName, string MemberNumber, string Hometown, SqlConnection SQL)
                {
                    using (var Transaction = SQL.BeginTransaction())
                    {
                        try
                        {
                            String Query = "INSERT INTO tbl_Driver (Last_Name, First_Name,Member_Number,Hometown,Email) " +
                                           "VALUES (@LAST,@FIRST,@MEMBER,@Town,@Email)";
                            SqlCommand Command = new SqlCommand(Query, SQL, Transaction);
                            Command.Parameters.AddWithValue("@LAST", LastName);
                            Command.Parameters.AddWithValue("@FIRST", FirstName);
                            Command.Parameters.AddWithValue("@MEMBER", MemberNumber);
                            Command.Parameters.AddWithValue("@Town", Hometown);
                            Command.Parameters.AddWithValue("@Email", "");
                            Command.ExecuteNonQuery();
                            Transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            Transaction.Rollback();
                        }
                    }
                }

                public static void Vehicle(int Year, string Make, string Model, SqlConnection SQL)
                {
                    using (var Transaction = SQL.BeginTransaction())
                    {
                        try
                        {
                            String Query = "INSERT INTO tbl_Vehicle (Year,Make,Model) VALUES (@Year,@Make,@Model)";
                            SqlCommand Command = new SqlCommand(Query, SQL, Transaction);
                            Command.Parameters.AddWithValue("@Year", Year);
                            Command.Parameters.AddWithValue("@Make", Make);
                            Command.Parameters.AddWithValue("@Model", Model);
                            Command.ExecuteNonQuery();
                            Transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            Transaction.Rollback();
                        }
                    }
                }

                public static void Number(int number, SqlConnection SQL)
                {
                    using (var Transaction = SQL.BeginTransaction())
                    {
                        try
                        {
                            String Query = "INSERT INTO tbl_Number (Number) VALUES (@Number)";
                            SqlCommand Command = new SqlCommand(Query, SQL, Transaction);
                            Command.Parameters.AddWithValue("@Number", number);
                            Command.ExecuteNonQuery();
                            Transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            Transaction.Rollback();
                        }
                    }
                }
            }

            public static class Import
            {
                public static void Registration(List<DLB_Data> xl_Import, DataGridView dgv_Registration)
                {
                    foreach (DLB_Data item in xl_Import)
                    {
                        //Variables//
                        double dblPaymentAmount = Convert.ToDouble(item.Total_Cost);
                        double dblEventNumber = 0;
                        int intEventID = 0;
                        int intDriverID = 0;
                        int intNumberID = 0;
                        int intVehicleID = 0;
                        int intClassID = 0;
                        int intVehicleNumber = item.Number;
                        int intYear = item.Year;
                        string strFirstName = item.First_Name;
                        string strLastName = item.Last_Name;
                        string strHometown = item.Hometown;
                        string strMemberNumber = item.Member_Number;
                        string strClass = item.Class;
                        string strMake = item.Make;
                        string strModel = item.Model;
                        string strPaymentType = item.Payment_Method;
                        string strEmail = item.E_mail;
                        bool blPaymentReceived = false;
                        bool blCheckedIn = false;


                        //Update Current Registration Data
                        SQL_Commands.Registration.Update.Registration(dgv_Registration);

                        //Insert New Drivers
                        SqlConnection SQL = SQL_Commands.Connect();
                        SQL.Open();
                        using (SQL)
                        {
                            List<string> lstData = new List<string>();
                            SqlCommand SQLCommand = new SqlCommand("SELECT DISTINCT Number FROM tbl_Event WHERE Status = 1", SQL);
                            SqlDataReader SQLReader = SQLCommand.ExecuteReader();
                            while (SQLReader.Read())
                            {
                                lstData.Add(SQLReader.GetDecimal(0).ToString());
                            }
                            SQLReader.Close();
                            dblEventNumber = Convert.ToDouble(lstData[0]);


                            intEventID = SQL_Commands.Registration.Get.Event(dblEventNumber, SQL);

                            //Get Driver_ID
                            intDriverID = SQL_Commands.Registration.Get.Driver(strLastName, strFirstName, SQL);
                            if (intDriverID == 0)
                            {
                                SQL_Commands.Registration.Import.Driver(strLastName, strFirstName, strMemberNumber, strHometown, strEmail, SQL);
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
                                break;
                            }
                            if (SQL_Commands.Registration.Find_Dup_Driver(intDriverID, SQL) == true)
                            {
                                MessageBox.Show("Driver is already registered. Please verify registration data.");
                                SQL.Close();
                                break;
                            }

                            if (item.Payment_Method == "Credit ")
                            {
                                blPaymentReceived = true;
                            }

                            SQL_Commands.Registration.Submit_Registration(intEventID, intDriverID, intClassID, intVehicleID, intNumberID, strPaymentType, dblPaymentAmount, blPaymentReceived, blCheckedIn, false, SQL);
                        }
                        SQL.Close();
                    }
                }

                public static void Driver(string LastName, string FirstName, string MemberNumber, string Hometown, string E_mail, SqlConnection SQL)
                {
                    using (var Transaction = SQL.BeginTransaction())
                    {
                        try
                        {
                            String Query = "INSERT INTO tbl_Driver (Last_Name, First_Name,Member_Number,Hometown,Email) " +
                                           "VALUES (@LAST,@FIRST,@MEMBER,@Town,@Email)";
                            SqlCommand Command = new SqlCommand(Query, SQL, Transaction);
                            Command.Parameters.AddWithValue("@LAST", LastName);
                            Command.Parameters.AddWithValue("@FIRST", FirstName);
                            Command.Parameters.AddWithValue("@MEMBER", MemberNumber);
                            Command.Parameters.AddWithValue("@Town", Hometown);
                            Command.Parameters.AddWithValue("@Email", E_mail);
                            Command.ExecuteNonQuery();
                            Transaction.Commit();
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());
                            Transaction.Rollback();
                        }
                    }
                }
            }

            public static void Submit_Registration(int Event, int Driver, int Class, int Vehicle, int Number, string PType, double PAmnt, bool PayRec, bool ChkIn, bool Tech, SqlConnection SQL)
            {
                using (var Transaction = SQL.BeginTransaction())
                {
                    try
                    {
                        String Query = "INSERT INTO tbl_Registration " +
                                       "(Event_ID,Driver_ID,Class_ID,Vehicle_ID,Number_ID,Payment_Type,Payment_Amount,Payment_Received,Checked_In,Tech_Inspection) " +
                                       "VALUES (@E,@D,@C,@V,@N,@PT,@PA,@PR,@CI,@TI)";
                        SqlCommand Command = new SqlCommand(Query, SQL, Transaction);
                        Command.Parameters.AddWithValue("@E", Event);
                        Command.Parameters.AddWithValue("@D", Driver);
                        Command.Parameters.AddWithValue("@C", Class);
                        Command.Parameters.AddWithValue("@V", Vehicle);
                        Command.Parameters.AddWithValue("@N", Number);
                        Command.Parameters.AddWithValue("@PT", PType);
                        Command.Parameters.AddWithValue("@PA", PAmnt);
                        Command.Parameters.AddWithValue("@PR", PayRec);
                        Command.Parameters.AddWithValue("@CI", ChkIn);
                        Command.Parameters.AddWithValue("@TI", Tech);
                        Command.ExecuteNonQuery();
                        Transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        Transaction.Rollback();
                    }
                }
            }

            public static bool Find_Dup_Reg(int Class, int Number, SqlConnection SQL)
            {
                int intData = 0;
                string Query = "SELECT Registration_ID " +
                               "FROM tbl_Registration as R " +
                               "INNER JOIN tbl_Event as E ON R.Event_ID = E.Event_ID " +
                               "WHERE Class_ID = " + Class + " AND Number_ID = " + Number + " AND E.Status = 1";
                SqlCommand Command = new SqlCommand(Query, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    intData = Reader.GetInt32(0);
                }
                Reader.Close();

                if (intData > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public static bool Find_Dup_Driver(int Driver, SqlConnection SQL)
            {
                int intData = 0;
                string Query = "SELECT Registration_ID " +
                               "FROM tbl_Registration as R " +
                               "INNER JOIN tbl_Event as E ON R.Event_ID = E.Event_ID " +
                               "WHERE Driver_ID = " + Driver + " AND E.Status = 1";
                SqlCommand Command = new SqlCommand(Query, SQL);
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    intData = Reader.GetInt32(0);
                }
                Reader.Close();

                if (intData > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
    public class FTP_Commands
    {
        public static void FTP_Upload_Event_Results()
        {
            try
            {
                using (WebClient wcUploader = new WebClient())
                {
                    wcUploader.Credentials = new NetworkCredential("chrisprally", "Pinkert1357!");
                    wcUploader.UploadFile("ftp://50.21.189.45/wp-content/uploads/Event_Results.html", "STOR", @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Event_Results.html");
                    wcUploader.UploadFile("ftp://50.21.189.45/wp-content/uploads/Event_Results_Overall.html", "STOR", @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Event_Results_Overall.html");
                }
            }
            catch (Exception ftp_error)
            {
                File.AppendAllText(@"C:\Users\ChristopherPi\Desktop\CFR_RallyCRoss\ftp_error.txt", Environment.NewLine + Environment.NewLine + ftp_error);
            }

        }

        public static void FTP_Upload_Recent_Stages()
        {
            Console.WriteLine(Globals.dtLastEntry);
            Console.WriteLine(DateTime.Now);
            if (DateTime.Now.AddMinutes(-5) >= Globals.dtLastEntry)
            {
                try
                {
                    using (WebClient wcUploader = new WebClient())
                    {
                        wcUploader.Credentials = new NetworkCredential("chrisprally", "Pinkert1357!");
                        wcUploader.UploadFile("ftp://50.21.189.45/wp-content/uploads/Recent_Stages.html", "STOR", @"C:/Users/ChristopherPi/Desktop/CFR_RallyCRoss/Stages_Overall.html");
                    }
                }
                catch (Exception ftp_error)
                {
                    File.AppendAllText(@"C:\Users\ChristopherPi\Desktop\CFR_RallyCRoss\ftp_error.txt", Environment.NewLine + Environment.NewLine + ftp_error);
                }
                Globals.dtLastEntry = DateTime.Now;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine("Fail");
            }
        }

        public static void FTP_Upload_Drivers()
        {
            try
            {
                using (WebClient wcUploader = new WebClient())
                {
                    wcUploader.Credentials = new NetworkCredential("chrisprally", "Pinkert1357!");
                    wcUploader.UploadFile("ftp://50.21.189.45/wp-content/uploads/Drivers_List.html", "STOR", @"C:/Bitnami/wordpress-4.9.1-0/apps/wordpress/htdocs/wp-content/uploads/Drivers_List.html");
                }
            }
            catch (Exception ftp_error)
            {
                File.AppendAllText(@"C:\Users\ChristopherPi\Desktop\CFR_RallyCRoss\ftp_error.txt", Environment.NewLine + Environment.NewLine + ftp_error);
            }
        }
    }

    public static class File_Manager
    {
        //Get DLBRacing.com Records from the csv import file
        public static List<DLB_Data> ImportDLB(FileInfo file)
        {
            List<DLB_Data> lstImport = new List<DLB_Data>();

            //Export Excel Data
            return lstImport;
        }

        public static List<DLB_Data> ReadSource(FileInfo fiSource)
        {
            Console.WriteLine("Read Source");
            int int_Index = 0;
            int xl_Columns = 0;
            int xl_Rows = 0;

            List<DLB_Data> lstImport = new List<DLB_Data>();

            Microsoft.Office.Interop.Excel.Application xl_Application;
            Microsoft.Office.Interop.Excel.Workbook xl_WorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xl_WorkSheet;
            Microsoft.Office.Interop.Excel.Range xl_Range;

            xl_Application = new Microsoft.Office.Interop.Excel.Application();
            xl_Application.Visible = false;
            xl_Application.DisplayAlerts = false;

            xl_WorkBook = xl_Application.Workbooks.Open(fiSource.FullName, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            xl_WorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xl_WorkBook.Worksheets[1];

            xl_Range = xl_WorkSheet.UsedRange;
            xl_Columns = xl_Range.Columns.Count;
            xl_Rows = xl_Range.Rows.Count;

            int_Index = 2;

            while (int_Index <= xl_Rows && xl_WorkSheet.Cells[int_Index, 1].Text() != "")
            {
                try
                {
                    lstImport.Add(new DLB_Data
                    {
                        Member_Number = xl_WorkSheet.Cells[int_Index, 1].Text(),
                        First_Name = xl_WorkSheet.Cells[int_Index, 2].Text(),
                        Last_Name = xl_WorkSheet.Cells[int_Index, 3].Text(),
                        Hometown = xl_WorkSheet.Cells[int_Index, 4].Text(),
                        State = xl_WorkSheet.Cells[int_Index, 5].Text(),
                        Number = Convert.ToInt32(xl_WorkSheet.Cells[int_Index, 6].Text()),
                        Class = xl_WorkSheet.Cells[int_Index, 7].Text(),
                        Year = Convert.ToInt32(xl_WorkSheet.Cells[int_Index, 8].Text()),
                        Make = xl_WorkSheet.Cells[int_Index, 9].Text(),
                        Model = xl_WorkSheet.Cells[int_Index, 10].Text(),
                        Payment_Method = xl_WorkSheet.Cells[int_Index, 11].Text(),
                        Total_Cost = Convert.ToDouble(xl_WorkSheet.Cells[int_Index, 12].Text()),
                        E_mail = xl_WorkSheet.Cells[int_Index, 14].Text(),
                    });
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.ToString());
                }
                int_Index++;
            }

            xl_WorkBook.Close();
            xl_Application.Quit();

            return lstImport;
        }
    }

    public static class Globals
    {
        public static DateTime dtLastEntry;

        public static bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        public static string GetFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = (@"Excel Files|*.xls;*.xlsx;*.xlsm");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                return fi.FullName;
            }
            else
            {
                MessageBox.Show("No File Selected");
                return "";
            }
        }
    }

    public class DLB_Data
    {
        public string Member_Number { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Hometown { get; set; }
        public string State { get; set; }
        public int Number { get; set; }
        public string Class { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Payment_Method { get; set; }
        public double Total_Cost { get; set; }
        public string Transaction_ID { get; set; }
        public string E_mail { get; set; }
        public string Date_Registered { get; set; }
        public string Saturday { get; set; }
        public string Sunday { get; set; }
        public string Sponsors { get; set; }
        public string Region { get; set; }
        public string Work_Assignment { get; set; }
    }

    public class Timing_Data
    {
        public int Time_ID { get; set; }
        public int Class_ID { get; set; }
        public int Registration_ID { get; set; }
        public int Stage_Number { get; set; }
        public decimal Stage_Time { get; set; }
        public int Cones_Hit { get; set; }
        public int Gates_Missed { get; set; }
        public bool Off_Course { get; set; }
        public decimal Total_Time { get; set; }
    }
}

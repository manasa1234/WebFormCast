﻿using ACLGDataAaccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormCast.ACLG;

namespace WebFormCast.attorney
{
    public partial class editH1_B : System.Web.UI.Page
    {
        int intAttorney_id = 0;
        string scomp;
        string strack;
        string sstatus;
        string sstatuspet;

        Nullable<DateTime> sfedex;
        Nullable<DateTime> suscis;
        Nullable<DateTime> sstatusexp;
        string steam;
        //Nullable<DateTime>  rfeuscist1;
        //Nullable<DateTime> rfeuscisdt;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
            }
            catch { }
            if (intAttorney_id <= 0)
            {
                Response.Redirect("index.aspx");
            }
            try
            {
                //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
                lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
                if (Request.QueryString["ID"] == "Add")
                {
                    FormView1.ChangeMode(FormViewMode.Insert);
                }
                else
                {
                    if (Request.QueryString["custMode"] != null && Request.QueryString["custMode"] == "edit")
                    {


                        FormView1.ChangeMode(FormViewMode.Edit);
                       
                        checkdraftStatus();
                        checkdraftStatuslabel();
                        FormView1.Focus();
                    }
                    //if (FormView1.FindControl("TrackingNoTextBox") != null)
                    //    {
                    //        FormView1.FindControl("TrackingNoTextBox").Focus();
                    //    }
                }
            }

            catch
            { }

            if (!IsPostBack)
            {
                AcglGeneral objG = new AcglGeneral();
                lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
                //string s = Bind("Current_Status");
            


                    checkdraftStatuslabel();
                //checkI140RFEOther();
            }
        }

        protected void FormView1_ItemDeleted(object sender, System.Web.UI.WebControls.FormViewDeletedEventArgs e)
        {
        }


        public System.Data.IDataReader getCandID()
        {

            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string queryString = "SELECT Employee_id FROM Employee where Tracking_No = '" + ((DataRowView)this.FormView1.DataItem)["RLTrackingNumber"] + "'";
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = queryString;
            dbCommand.Connection = dbConnection;

            dbConnection.Open();
            System.Data.IDataReader dataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                Session["candID"] = dataReader["Employee_id"];
            }
            return dataReader;

        }
        public string getUserNameById()
        {

            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string queryString = "SELECT User_Display_Name FROM Users WHERE User_ID = '" + ((DataRowView)this.FormView1.DataItem)["AssignedTo"] + "'";
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = queryString;
            dbCommand.Connection = dbConnection;

            dbConnection.Open();
            System.Data.IDataReader dataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            string ret = "";
            if (dataReader.Read())
            {
                ret = (string)dataReader["User_Display_Name"];
            }
            return ret;
        }

        public int InsertNotes(int sCandID, string sNotes, System.DateTime sDatefiled, int sAuID)
        {
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string queryString = "INSERT INTO [Notes] ([Record_id],[Comments],[Commented_Date],[Updated_By_User_ID]) VALUES (@sCandID, @sNotes,@sDatefiled,@sAuID)";
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = queryString;
            dbCommand.Connection = dbConnection;

            System.Data.IDataParameter dbParam_sCandID = new System.Data.SqlClient.SqlParameter();
            dbParam_sCandID.ParameterName = "@sCandID";
            dbParam_sCandID.Value = sCandID;
            dbParam_sCandID.DbType = System.Data.DbType.Int32;
            dbCommand.Parameters.Add(dbParam_sCandID);

            System.Data.IDataParameter dbParam_sDatefiled = new System.Data.SqlClient.SqlParameter();
            dbParam_sDatefiled.ParameterName = "@sDatefiled";
            dbParam_sDatefiled.Value = sDatefiled;
            dbParam_sDatefiled.DbType = System.Data.DbType.DateTime;
            dbCommand.Parameters.Add(dbParam_sDatefiled);

            System.Data.IDataParameter dbParam_sNotes = new System.Data.SqlClient.SqlParameter();
            dbParam_sNotes.ParameterName = "@sNotes";
            dbParam_sNotes.Value = sNotes;
            dbParam_sNotes.DbType = System.Data.DbType.String;
            dbCommand.Parameters.Add(dbParam_sNotes);

            System.Data.IDataParameter dbParam_aID = new System.Data.SqlClient.SqlParameter();
            dbParam_aID.ParameterName = "@sAuID";
            dbParam_aID.Value = sAuID;
            dbParam_aID.DbType = System.Data.DbType.Int32;
            dbCommand.Parameters.Add(dbParam_aID);

            int rowsAffected = 0;
            dbConnection.Open();


            try
            {
                rowsAffected = dbCommand.ExecuteNonQuery();
            }
            finally
            {
                dbConnection.Close();
            }

            return rowsAffected;
        }

        //public int ClearNIVNotes(int pid)
        //{
        //    ACLGDB DB = new ACLGDB();
        //    string connectionString = DB.ConnectionString;
        //    System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        //    string queryString = "UPDATE [NIVtracking] SET [Notes] = null WHERE [ID] = @ID";
        //    System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
        //    dbCommand.CommandText = queryString;
        //    dbCommand.Connection = dbConnection;

        //    System.Data.IDataParameter dbParam_ID = new System.Data.SqlClient.SqlParameter();
        //    dbParam_ID.ParameterName = "@ID";
        //    dbParam_ID.Value = pid;
        //    dbParam_ID.DbType = System.Data.DbType.Int32;
        //    dbCommand.Parameters.Add(dbParam_ID);

        //    int rowsAffected = 0;
        //    dbConnection.Open();
        //    try
        //    {
        //        rowsAffected = dbCommand.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        dbConnection.Close();
        //    }
        //    return rowsAffected;
        //}

        protected void btnchange()
        {
            FormView1.DataBind();
            getCandID();
            string STnotes = getNotes();
            DateTime saveNow = DateTime.Now;
            InsertNotes((int)Session["candID"], STnotes, saveNow, (int)Session["Attorney_User_Id"]);
            //ClearNIVNotes((int)((DataRowView)this.FormView1.DataItem)["ID"]);
        }

        protected void OnDSUpdatedHandler(Object source, SqlDataSourceStatusEventArgs e)
        {
            if (e.AffectedRows > 0)
            {
                // Perform any additional processing, such as adding notes           
                FormView1.DataBind();
                getCandID();
                string STnotes = getNotes();
                DateTime saveNow = DateTime.Now;
                InsertNotes((int)Session["candID"], STnotes, saveNow, (int)Session["Attorney_User_Id"]);
                //ClearNIVNotes((int)((DataRowView)this.FormView1.DataItem)["ID"]);

            }
        }

        protected string getNotes()
        {
            string STnotes = null;
            STnotes = " Receipt#: " + (((DataRowView)this.FormView1.DataItem)["RLTrackingNumber"] != null ? ((DataRowView)this.FormView1.DataItem)["RLTrackingNumber"].ToString() : "");
            STnotes += " | LCA Tracking No: " + (((DataRowView)this.FormView1.DataItem)["LCATrackNumber"] != null ? ((DataRowView)this.FormView1.DataItem)["LCATrackNumber"].ToString() : "");
            STnotes += " | LCA File:: " + (((DataRowView)this.FormView1.DataItem)["LCAfiled"] != null ? ((DataRowView)this.FormView1.DataItem)["LCAfiled"].ToString() : "");
            STnotes += " | Due Date:" + (((DataRowView)this.FormView1.DataItem)["DueDate"] != null ? ((DataRowView)this.FormView1.DataItem)["DueDate"].ToString() : "");
            STnotes += " | Draft Status: " + (((DataRowView)this.FormView1.DataItem)["DraftStatus"] != null ? ((DataRowView)this.FormView1.DataItem)["DraftStatus"].ToString() : "");
            STnotes += " | Sig Pages: " + (((DataRowView)this.FormView1.DataItem)["SigPages"] != null ? ((DataRowView)this.FormView1.DataItem)["SigPages"].ToString() : "");
            STnotes += " |Premium Processing: " + (((DataRowView)this.FormView1.DataItem)["Premium_Processing"] != null ? ((DataRowView)this.FormView1.DataItem)["Premium_Processing"].ToString() : "");
            STnotes += " | Checks: " + (((DataRowView)this.FormView1.DataItem)["Check"] != null ? ((DataRowView)this.FormView1.DataItem)["Check"].ToString() : "");
            STnotes += " | Case Type:" + (((DataRowView)this.FormView1.DataItem)["Case_Type"] != null ? ((DataRowView)this.FormView1.DataItem)["Case_Type"].ToString() : "");
            if (((DataRowView)this.FormView1.DataItem)["RFE_Type"].ToString() != null)
            {

                STnotes += " | RFE Type:" + (((DataRowView)this.FormView1.DataItem)["RFE_Type"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Type"].ToString() : "");
                STnotes += " | RFE Date Received:" + (((DataRowView)this.FormView1.DataItem)["RFEDateReceive"] != null ? ((DataRowView)this.FormView1.DataItem)["RFEDateReceive"].ToString() : "");
                STnotes += " | Date R4D sent:" + (((DataRowView)this.FormView1.DataItem)["Date_R4D_Sent"] != null ? ((DataRowView)this.FormView1.DataItem)["Date_R4D_Sent"].ToString() : "");
                STnotes += " |RFE USCIS DueDate:" + (((DataRowView)this.FormView1.DataItem)["RFE_Uscis_DueDate"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Uscis_DueDate"].ToString() : "");
                STnotes += " |RFE Internal DueDate:" + (((DataRowView)this.FormView1.DataItem)["RFE_Internal_Due_Date"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Internal_Due_Date"].ToString() : "");
                STnotes += " |RFE Last Ship Date:" + (((DataRowView)this.FormView1.DataItem)["RFE_LastShip_Date"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_LastShip_Date"].ToString() : "");
                STnotes += " |RFE Eval Filed:" + (((DataRowView)this.FormView1.DataItem)["RFE_Evaluation_Filed"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Evaluation_Filed"].ToString() : "");
                STnotes += " |RFE Missing Docs:" + (((DataRowView)this.FormView1.DataItem)["RFE_Missing_Docs"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Missing_Docs"].ToString() : "");
                STnotes += " |RFE Drafted:" + (((DataRowView)this.FormView1.DataItem)["RFE_Drafted"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Drafted"].ToString() : "");
                STnotes += " |RFE Status:" + (((DataRowView)this.FormView1.DataItem)["RFE_Status"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_Status"].ToString() : "");
                STnotes += " |RFE last Update:" + (((DataRowView)this.FormView1.DataItem)["RFE_LastUpdated"] != null ? ((DataRowView)this.FormView1.DataItem)["RFE_LastUpdated"].ToString() : "");
            }
            else
            {
                STnotes += " |";

            }

            STnotes += " | Status Expires:" + (((DataRowView)this.FormView1.DataItem)["Status_Expires"] != null ? ((DataRowView)this.FormView1.DataItem)["Status_Expires"].ToString() : "");
            STnotes += " | H-4 Tracking No: " + (((DataRowView)this.FormView1.DataItem)["H4TrackNumber"] != null ? ((DataRowView)this.FormView1.DataItem)["H4TrackNumber"].ToString() : "");
            STnotes += " | H-4 sigpages sent: " + (((DataRowView)this.FormView1.DataItem)["H4_SigPages"] != null ? ((DataRowView)this.FormView1.DataItem)["H4_SigPages"].ToString() : "");
            //STnotes += " | Last Action on Case: " + txtlastcaseactn.Text;
            STnotes += " | Location of Case:" + (((DataRowView)this.FormView1.DataItem)["location"] != null ? ((DataRowView)this.FormView1.DataItem)["location"].ToString() : "");
            STnotes += " |  Assigned To:" + (((DataRowView)this.FormView1.DataItem)["User_Id"] != null ? ((DataRowView)this.FormView1.DataItem)["User_Id"].ToString() : "");
            STnotes += " | Invoice:" + (((DataRowView)this.FormView1.DataItem)["Invoice"] != null ? ((DataRowView)this.FormView1.DataItem)["Invoice"].ToString() : "");
            STnotes += " |Last Updated: " + (((DataRowView)this.FormView1.DataItem)["Last_Updated"] != null ? ((DataRowView)this.FormView1.DataItem)["Last_Updated"].ToString() : "");
            STnotes += " | Paid: " + (((DataRowView)this.FormView1.DataItem)["Paid"] != null ? ((DataRowView)this.FormView1.DataItem)["Paid"].ToString() : "");


            return STnotes;
        }

        protected void fv_DataBound(object sender, EventArgs e)
        {
            DataRowView dataRow = ((DataRowView)FormView1.DataItem);
         
            if (dataRow == null)
            {
                return;
            }
            LinkButton del = (LinkButton)FormView1.FindControl("LinkButtonDelete");
            if (del != null)
            {
                Boolean check = false;
                if (Convert.ToInt16(Session["Attorney_User_Id"]) > 0)
                {
                    AttorneyUser AU = new AttorneyUser(Convert.ToInt16(Session["Attorney_User_Id"]));
                    check = (AU.User_Type != null && AU.User_Type.ToLower().Equals("admin"));
                }
                if (!check)
                {
                    del.Enabled = false;
                    del.Visible = false;
                }
            }


            if (dataRow["Last_Updated"] != System.DBNull.Value)
            {
                DateTime now = DateTime.Today;
                TimeSpan diff = now - (DateTime)dataRow["Last_Updated"];
                if (diff.Days==0)
                {
                    TextBox lud = (TextBox)FormView1.FindControl("txtlstupdated");
                    if (lud != null)
                    {
                        lud.BackColor = System.Drawing.Color.Green;
                    }
                    Label ludl = (Label)FormView1.FindControl("lstupdatedLabel");
                    if (ludl != null)
                    {
                        ludl.BackColor = System.Drawing.Color.Green;
                    }
                }
                if (diff.Days >= 7)
                {
                    TextBox lud = (TextBox)FormView1.FindControl("txtlstupdated");
                    if (lud != null)
                    {
                        lud.BackColor = System.Drawing.Color.Red;
                    }

                    Label ludl = (Label)FormView1.FindControl("lstupdatedLabel");
                    if (ludl != null)
                    {
                        ludl.BackColor = System.Drawing.Color.Red;
                    }
                }
                if (diff.Days < 7 && diff.Days >= 1)
                {
                    TextBox lud = (TextBox)FormView1.FindControl("txtlstupdated");
                    if (lud != null)
                    {
                        lud.BackColor = System.Drawing.Color.Yellow;
                    }

                    Label ludl = (Label)FormView1.FindControl("lstupdatedLabel");
                    if (ludl != null)
                    {
                        ludl.BackColor = System.Drawing.Color.Yellow;
                    }
                }
            }
            checkdraftStatus();
            checkdraftStatuslabel();
            //    checkINIVRFEOther();
        }


        //protected void LastUpdDate_Changed(object sender, EventArgs e)
        //{
        //    TextBox ludt = (TextBox)FormView1.FindControl("txtlstupdated");
        //    if (!isInactivatedI140Status() && !String.IsNullOrEmpty(ludt.Text))
        //    {
        //        DateTime now = DateTime.Today;
        //        DateTime lud = Convert.ToDateTime(ludt.Text);
        //        TimeSpan diff = now - lud;
        //        if (diff.Days > 7)
        //        {
        //            ludt.BackColor = System.Drawing.Color.Yellow;
        //        }
        //        else
        //        {
        //            ludt.BackColor = System.Drawing.Color.YellowGreen;
        //        }
        //    }
        //    Page.SetFocus("FormView1_txtlstupdated");
        //}


        //protected void lstUsersI140_Changed(object sender, EventArgs e)
        //{
        //    Page.SetFocus("FormView1_lstUsersI140");
        //}

        //protected void I140Status_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    checkI140Status();
        //    Page.SetFocus("FormView1_lstI140Status");
        //}

        protected void checkdraftStatus()
        {
            DropDownList ps = (DropDownList)FormView1.FindControl("lstDraftstatus");
            Panel p = FormView1.FindControl("rfehidden1") as Panel;
            if (ps != null)
            {
                if ( ps.SelectedValue == "RFE" || ps.SelectedValue == "Denial" || ps.SelectedValue == "NOIR" || ps.SelectedValue == "NOID")
                {
                    p.Visible = true;
                 
                }
                else
                {
                    p.Visible = false;
                }
                //else
                //{
                //    Panel p1 = FormView1.FindControl("rfehidden") as Panel;
                //    p1.Visible = false;
                  
                //}
            }
        }
        protected void checkdraftStatuslabel()
        {
           
            Label permStatusLbl = (Label)FormView1.FindControl("draftstatusLabel");
            Panel p = FormView1.FindControl("rfehidden") as Panel;
            if (permStatusLbl != null)
            {
                if ( permStatusLbl.Text.Equals("RFE") || permStatusLbl.Text.Equals("Denial") || permStatusLbl.Text.Equals("NOIR") || permStatusLbl.Text.Equals("NOID"))
                {
                   
                    p.Visible = true;
                  
                }
                else
                {
                    p.Visible = false;
                   
                }
            }
        }

        //protected void I140RFEOther_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (checkI140RFEOther())
        //    {
        //        Page.SetFocus("FormView1_txtI140RFEOtherNotes");
        //    }
        //    else
        //    {
        //        Page.SetFocus("FormView1_txtI140Comments");
        //    }
        //}

        //protected Boolean checkI140RFEOther()
        //{
        //    Boolean ret = false;
        //    CheckBox chko = (CheckBox)FormView1.FindControl("chkOther");
        //    if (chko != null)
        //    {
        //        TextBox dd = (TextBox)FormView1.FindControl("txtI140RFEOtherNotes");
        //        if (chko.Checked)
        //        {
        //            dd.Enabled = true;
        //            ret = true;
        //        }
        //        else
        //        {
        //            dd.Enabled = false;
        //        }
        //    }
        //    return ret;
        //}

        protected void lstDraftstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            DropDownList ps = (DropDownList)sender;
             Panel p = FormView1.FindControl("rfehidden1") as Panel;
                //FormView1.FindControl("lstDraftstatus") as DropDownList;
            //Label permStatusLbl = (Label)FormView1.FindControl("draftstatusLabel");
            if (ps.SelectedValue != null && ps.SelectedValue == "RFE" || ps.SelectedValue == "Denial" || ps.SelectedValue == "NOIR" || ps.SelectedValue == "NOID")
                  
            {
               
                p.Visible=true;
                //checkdraftStatus();
            }
            else
            {
                p.Visible=false;
            }
        }
        
        protected void txtrfeuscisdt__Leave(object sender, EventArgs e)
        {
            TextBox t= FormView1.FindControl("txtrfeuscisdt") as TextBox;
            TextBox tint = FormView1.FindControl("txtinternalduedt") as TextBox;
            TextBox tlast  = (TextBox)FormView1.FindControl("txtlastshipdt");
            
            //TextBox tlast = FormView1.FindControl("RFE_LastShip_Date") as TextBox;
            DateTime rfelatestshipdt1;
            DateTime rfelatestshipdt;
            DateTime rfeuscist1;
            DateTime rfeuscisdt;
            DateTime rfeinternaldt;
           
            if (t.Text == "")
            {
                tint.Text = "";
                tlast.Text = "";
            }
            else
            {
                rfeuscist1 = Convert.ToDateTime(t.Text);
                rfeuscisdt = Convert.ToDateTime(t.Text);
                if ((int)rfeuscist1.DayOfWeek == 1)
                {
                    rfelatestshipdt1 = rfeuscist1.AddDays(-3);


                }
                rfelatestshipdt = rfeuscist1.AddDays(-1);
                //lastshipdt =

                tlast.Text =  rfelatestshipdt.ToString();
           
                rfeinternaldt = rfeuscist1.AddDays(-20);
                //internaldt =
                tint.Text = rfeinternaldt.ToString();
            }
        }
       
        

       
        public editH1_B()
        {
            Load += Page_Load;
        }

        protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddCompany.SelectedValue.Equals("All"))
            {
                TrackingNotxt.Text = "";
            }
        }

        protected void ddStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddStatus.SelectedValue.Equals("All"))
            {
                TrackingNotxt.Text = "";
            }
        }
        protected void reset_Click(object sender, System.EventArgs e)
        {
            //Handle visible fields
            ddCompany.SelectedValue = "All";
            //ddReport.SelectedValue = "";
            //ddStatus.SelectedValue = "All";
            ddstatuespetetion.SelectedValue = "";
            ddteam.SelectedValue = "";
            ddStatus.SelectedValue = "";
            TrackingNotxt.Text = "";
            ddStatus.Enabled = true;
            TrackingNotxt.Enabled = true;
            //lblInfo.Visible = false;

            //Handle report selection related non-visible fields
            //this.lstUsers.SelectedValue = "0";
            //this.txtDateFrom.Text = "";
            //this.txtDateTo.Text = "";
            //checkReport();

            //gvH1B.Visible = false;
            //this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
            //this.lbStatus.Text = this.ddStatus.Text;
            //this.lbTrackId.Text = "";
            ////this.lbReport.Text = "";
            //this.lbCount.Text = "";
        }

        protected void H1BSearch_Click(object sender, EventArgs e)
        {
            sstatus = ddStatus.SelectedValue;
            scomp = ddCompany.SelectedValue;
            sstatuspet = ddStatus.SelectedValue;
            strack = TrackingNotxt.Text;
            steam = ddteam.SelectedValue;
            if (fedexshippedtxt.Text == "")
            {
                sfedex = null;
            }
            else
            {
                sfedex = Convert.ToDateTime(fedexshippedtxt.Text);
            }
            if (uscisdttxt.Text == "")
            {
                suscis = null;
            }
            else
            {
                suscis = Convert.ToDateTime(uscisdttxt.Text);
            }
            if (statusexptxt.Text == "")
            {
                sstatusexp = null;
            }
            else
            {
                sstatusexp = Convert.ToDateTime(statusexptxt.Text);
            }
            int check = 1;
            Session["check"] = Convert.ToString(check);
            Session["strackno"] = strack;
            Session["sstatus"] = sstatus;
            Session["sstatuspetetion"] = sstatuspet;
            Session["scompany"] = scomp;
            Session["sfedexdt"] = sfedex;
            Session["suscisdt"] = suscis;
            Session["sstausexpdt"] = sstatusexp;
            Session["sTeams"] = steam;
            Session["CaseRequestPage"] = "H1B";
            Response.Redirect("H1-B.aspx");
        }
   


     

    }
}
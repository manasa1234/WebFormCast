using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using WebFormCast.ACLG;
using ACLGDataAaccess;

public partial class attorney_EditI140 : System.Web.UI.Page
{
    int intAttorney_id = 0;
    string company;
    string track;
    string status;
    string reports;
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
                    if (FormView1.FindControl("txtI140Comments") != null)
                    {
                        FormView1.FindControl("txtI140Comments").Focus();
                    }
                }
            }
        }
        catch
        { }

        if (!IsPostBack)
        {
            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
            //ddCompany.DataBind();
            checkI140Status();
            checkI140RFEOther();
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

        string queryString = "SELECT Employee_id FROM Employee where Tracking_No = '" + ((DataRowView)this.FormView1.DataItem)["TrackingNo"] + "'";
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

    public int ClearI140Notes(int pid)
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "UPDATE [I140Tracking] SET [I140Notes] = null WHERE [ID] = @ID";
        System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
        dbCommand.CommandText = queryString;
        dbCommand.Connection = dbConnection;

        System.Data.IDataParameter dbParam_ID = new System.Data.SqlClient.SqlParameter();
        dbParam_ID.ParameterName = "@ID";
        dbParam_ID.Value = pid;
        dbParam_ID.DbType = System.Data.DbType.Int32;
        dbCommand.Parameters.Add(dbParam_ID);

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

    protected void btnchange()
    {
        FormView1.DataBind();
        getCandID();
        string STnotes = getNotes();
        DateTime saveNow = DateTime.Now;
        InsertNotes((int)Session["candID"], STnotes, saveNow, (int)Session["Attorney_User_Id"]);
        ClearI140Notes((int)((DataRowView)this.FormView1.DataItem)["ID"]);
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
            ClearI140Notes((int)((DataRowView)this.FormView1.DataItem)["ID"]);
        }
    }

    protected string getNotes()
    {
        string STnotes = null;
        STnotes = "I-140 Receipt#: " + (((DataRowView)this.FormView1.DataItem)["I140ReceiptNo"] != null ? ((DataRowView)this.FormView1.DataItem)["I140ReceiptNo"].ToString() : "");
        STnotes += " | I-140 Status: " + (((DataRowView)this.FormView1.DataItem)["I140Status"] != null ? ((DataRowView)this.FormView1.DataItem)["I140Status"].ToString() : "");
        STnotes += " | Last Updated Date: " + (((DataRowView)this.FormView1.DataItem)["I140LastUpdDate"] != null ? ((DataRowView)this.FormView1.DataItem)["I140LastUpdDate"].ToString() : "");
        if (((DataRowView)this.FormView1.DataItem)["I140Notes"] != null && ((DataRowView)this.FormView1.DataItem)["I140Notes"] != "")
        {
            STnotes += " | I-140 Comments: " + ((DataRowView)this.FormView1.DataItem)["I140Notes"];
        }
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

        if (dataRow["I140LastUpdDate"] != System.DBNull.Value)
        {
            DateTime now = DateTime.Today;
            TimeSpan diff = now - (DateTime)dataRow["I140LastUpdDate"];
            if (diff.Days > 7)
            {
                TextBox lud = (TextBox)FormView1.FindControl("DateLastUpdatedTextBox");
                if (lud != null)
                {
                    lud.BackColor = System.Drawing.Color.Yellow;
                }

                Label ludl = (Label)FormView1.FindControl("DateLastUpdatedLabel");
                if (ludl != null)
                {
                    ludl.BackColor = System.Drawing.Color.Yellow;
                }
            }
            if (diff.Days <= 7)
            {
                TextBox lud = (TextBox)FormView1.FindControl("DateLastUpdatedTextBox");
                if (lud != null)
                {
                    lud.BackColor = System.Drawing.Color.GreenYellow;
                }

                Label ludl = (Label)FormView1.FindControl("DateLastUpdatedLabel");
                if (ludl != null)
                {
                    ludl.BackColor = System.Drawing.Color.GreenYellow;
                }
            }
        }
        checkI140Status();
        checkI140RFEOther();
    }


    protected void LastUpdDate_Changed(object sender, EventArgs e)
    {
        TextBox ludt = (TextBox)FormView1.FindControl("DateLastUpdatedTextBox");
        if (!isInactivatedI140Status() && !String.IsNullOrEmpty(ludt.Text))
        {
            DateTime now = DateTime.Today;
            DateTime lud = Convert.ToDateTime(ludt.Text);
            TimeSpan diff = now - lud;
            if (diff.Days > 7)
            {
                ludt.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                ludt.BackColor = System.Drawing.Color.YellowGreen;
            }
        }
        Page.SetFocus("FormView1_DateLastUpdatedTextBox");
    }


    protected void lstUsersI140_Changed(object sender, EventArgs e)
    {
        Page.SetFocus("FormView1_lstUsersI140");
    }

    protected void I140Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        checkI140Status();
        Page.SetFocus("FormView1_lstI140Status");
    }

    protected void checkI140Status()
    {
        DropDownList ps = (DropDownList)FormView1.FindControl("lstI140Status");
        if (ps != null)
        {
            if (ps.SelectedValue != null && ps.SelectedValue == "RFE")
            {
                ((TextBox)FormView1.FindControl("txtI140RFEDueDate")).Enabled = true;
                ((DropDownList)FormView1.FindControl("lstI140RFEStatus")).Enabled = true;
                ((CheckBox)FormView1.FindControl("chkPayAbility")).Enabled = true;
                ((CheckBox)FormView1.FindControl("chkAcademics")).Enabled = true;
                ((CheckBox)FormView1.FindControl("chkExperience")).Enabled = true;
                ((CheckBox)FormView1.FindControl("chkOther")).Enabled = true;
            }
            else
            {
                ((TextBox)FormView1.FindControl("txtI140RFEDueDate")).Enabled = false;
                ((DropDownList)FormView1.FindControl("lstI140RFEStatus")).Enabled = false;
                ((CheckBox)FormView1.FindControl("chkPayAbility")).Enabled = false;
                ((CheckBox)FormView1.FindControl("chkAcademics")).Enabled = false;
                ((CheckBox)FormView1.FindControl("chkExperience")).Enabled = false;
                ((CheckBox)FormView1.FindControl("chkOther")).Enabled = false;
            }
        }
    }

    protected void I140RFEOther_CheckedChanged(object sender, EventArgs e)
    {
        if (checkI140RFEOther())
        {
            Page.SetFocus("FormView1_txtI140RFEOtherNotes");
        }
        else
        {
            Page.SetFocus("FormView1_txtI140Comments");
        }
    }

    protected Boolean checkI140RFEOther()
    {
        Boolean ret = false;
        CheckBox chko = (CheckBox)FormView1.FindControl("chkOther");
        if (chko != null)
        {
            TextBox dd = (TextBox)FormView1.FindControl("txtI140RFEOtherNotes");
            if (chko.Checked)
            {
                dd.Enabled = true;
                ret = true;
            }
            else
            {
                dd.Enabled = false;
            }
        }
        return ret;
    }

    protected Boolean isInactivatedI140Status()
    {
        Boolean ret = false;
        DropDownList ps = (DropDownList)FormView1.FindControl("lstI140Status");
        Label permStatusLbl = (Label)FormView1.FindControl("I140StatusLabel");
        if ((ps != null && ps.SelectedValue != null && ps.SelectedValue == "Inactivated")
            ||
            (permStatusLbl != null && permStatusLbl.Text.ToLower().Equals("inactivated"))
            )
        {
            ret = true;
        }
        return ret;
    }

    public attorney_EditI140()
    {
        Load += Page_Load;
    }
    protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddCompany.SelectedValue.Equals("All"))
        {
            txtTrackingNo.Text = "";
        }
        company = ddCompany.SelectedValue;
    }

    protected void ddStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddStatus.SelectedValue.Equals("All"))
        {
            txtTrackingNo.Text = "";
        }
        status = ddStatus.SelectedValue;
    }
    protected void i140Search_Click(object sender, System.EventArgs e)
    {
        reports = ddReport.SelectedValue;
        company = ddCompany.SelectedValue;
        status = ddStatus.SelectedValue;
        track = txtTrackingNo.Text;
        int check = 1;
        Session["check"] = Convert.ToString(check);
        Session["strack"] = track;
        Session["sstatus"] = status;
        Session["sreports"] = reports;
        Session["scompany"] = company;
        Session["CaseRequestPage"] = "i140";
        Response.Redirect("i140.aspx");
    }

    protected void ddReport_Changed(object sender, EventArgs e)
    {
        reports = ddReport.SelectedValue;
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        ddCompany.SelectedValue = "All";
        ddReport.SelectedValue = "";
        ddStatus.SelectedValue = "All";
        txtTrackingNo.Text = "";
        ddStatus.Enabled = true;
        txtTrackingNo.Enabled = true;
        lblInfo.Visible = false;

        //Handle report selection related non-visible fields
        this.lstUsers.SelectedValue = "0";
        this.txtDateFrom.Text = "";
        this.txtDateTo.Text = "";

    }

}

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
//using System.Windows.Forms;

public partial class attorney_AddI140 : System.Web.UI.Page
{
    int intAttorney_id=0;
    int intCompany_id = 0;
    string company;
    string track;
    string status;
    string reports;
    [System.Web.Services.WebMethodAttribute()]
    [System.Web.Script.Services.ScriptMethodAttribute()]

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
        }
        catch
        { }

        if (!IsPostBack)
        {
            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
            try
            {
                intCompany_id = getCompanyId();
            }
            catch { }
            if (intCompany_id > 0)
            {
                lstCompany.SelectedValue = intCompany_id.ToString();
                Company oC = new Company(intCompany_id);
                Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
            }
        }

    }

    protected void lstTrackNo_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        getCandID();
        // Response.Write(Session("candID"))
        lstName.Text = this.lstTrackNo.SelectedItem.Value;
        populateI140DueDate();
        if (checkI140S())
        {
            lblTrackNo.Visible = true;
        }
        else
        {
            lblTrackNo.Visible = false;
        }
        Page.SetFocus("lstTrackNo");
    }

    protected void lstCompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        lstName.Text = "";
        Page.SetFocus("lstCompany");
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        RequiredFieldValidator4.Validate();// This is not fired because of the calendar widget
        if (!RequiredFieldValidator4.IsValid)
        {
            return;
        }
        string STnotes = null;
        STnotes = "I-140 Receipt#: " + txtReceiptNo.Text;
        STnotes += " | I-140 Status: " + lstI140Status.Text;
        STnotes += " | Last Updated Date: " + txtLastUpdDate.Text;
        if (txtI140Comments.Text != null && txtI140Comments.Text != "")
        {
            STnotes += " | I-140 Comments: " + txtI140Comments.Text;
        }

        bool[] i140CheckList = new bool[4];
        i140CheckList[0] = chkDrafted.Checked;
        i140CheckList[1] = chkPermPages.Checked;
        i140CheckList[2] = chkPremium.Checked;
        i140CheckList[3] = chkI140Filed.Checked;

        bool[] rfeTypes = new bool[8];
        rfeTypes[0] = chkPayAbility.Checked;
        rfeTypes[1] = chkAcademics.Checked;
        rfeTypes[2] = chkExperience.Checked;
        rfeTypes[3] = chkOther.Checked;

        InsertNewI140(this.lstTrackNo.SelectedItem.Text, lstCompany.SelectedItem.Value, lstName.Text, txtReceiptNo.Text, txtI140DueDate.Text
            , chkI140Docs.Checked, txtLastUpdDate.Text, lstUsersI140.SelectedItem.Value, txtI140MissingDocs.Text, i140CheckList, txtI140FiledDate.Text
            , txtI140InvNo.Text, chkI140Payment.Checked, lstI140Status.SelectedItem.Text, txtI140RFEDueDate.Text
            , lstI140RFEStatus.SelectedItem.Text, rfeTypes, txtI140RFEOtherNotes.Text, txtI140Comments.Text);
        InsertNotes((int)Session["candID"], STnotes, DateTime.Now, (int)Session["Attorney_User_Id"]);
        int intCompanyId = 0;
        if (!lstCompany.SelectedValue.Equals("-- Select Company Name"))
        {
            intCompanyId = Convert.ToInt16(lstCompany.SelectedValue);
            setCompanyId(intCompanyId);
            Company oC = new Company(intCompanyId);
            Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
        }
        Response.Redirect("i140.aspx");
    }

    public int InsertNewI140(string sTrackingNo, string sCompany, string sBeneficiary, string sI140ReceiptNo, string sI140DueDate
        , Boolean sI140Docs, string sI140LastUpdDate, string sI140AssignedTo, string sI140MissingDocs, bool[] sI140CheckList, string sI140FiledDate
        , string sI140InvNo, Boolean sI140Payment, string sI140Status, string sI140RFEDueDate, string sI140RFEStatus, bool[] rfeTypes
        , string sI140RFEOtherNotes, string sI140Comments)
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "INSERT INTO I140Tracking (TrackingNo, Company, Beneficiary, I140ReceiptNo, I140DueDate, I140DocsReceived, I140LastUpdDate, I140AssignedTo, I140DocsMissing, I140Drafted, I140PERMSentSignature, I140Premium, I140Filed, I140FiledDate, I140InvNo, I140PaymentRcvd, I140Status, I140RFEDueDate, I140RFEStatus, I140RFETypeAP, I140RFETypeA, I140RFETypeE, I140RFETypeO, I140RFETypeOtherComments, I140Notes) ";
        queryString += " VALUES (@TrackingNo, @Company, @Beneficiary, @I140ReceiptNo, @I140DueDate, @I140DocsReceived, @I140LastUpdDate, @I140AssignedTo, @I140DocsMissing, @I140Drafted, @I140PERMSentSignature, @I140Premium, @I140Filed, @I140FiledDate, @I140InvNo, @I140PaymentRcvd, @I140Status, @I140RFEDueDate, @I140RFEStatus, @I140RFETypeAP, @I140RFETypeA, @I140RFETypeE, @I140RFETypeO, @I140RFETypeOtherComments, @I140Notes) ";
        System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
        dbCommand.CommandText = queryString;
        dbCommand.Connection = dbConnection;

        System.Data.IDataParameter dbParam_sTrackingNo = new System.Data.SqlClient.SqlParameter();
        dbParam_sTrackingNo.ParameterName = "@TrackingNo";
        if (String.IsNullOrEmpty(sTrackingNo)){
            dbParam_sTrackingNo.Value = DBNull.Value;
        } else {
            dbParam_sTrackingNo.Value = sTrackingNo;
        }
        dbParam_sTrackingNo.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sTrackingNo);

        System.Data.IDataParameter dbParam_sCompany = new System.Data.SqlClient.SqlParameter();
        dbParam_sCompany.ParameterName = "@Company";
        if ( String.IsNullOrEmpty(sCompany) || sCompany == "0" ){
            dbParam_sCompany.Value = DBNull.Value;
        } else {
            dbParam_sCompany.Value = int.Parse(sCompany);
        }
        dbParam_sCompany.DbType = System.Data.DbType.Int32;
        dbCommand.Parameters.Add(dbParam_sCompany);

        System.Data.IDataParameter dbParam_sBeneficiary = new System.Data.SqlClient.SqlParameter();
        dbParam_sBeneficiary.ParameterName = "@Beneficiary";
        if (String.IsNullOrEmpty(sBeneficiary)){
            dbParam_sBeneficiary.Value = DBNull.Value;
        } else {
            dbParam_sBeneficiary.Value = sBeneficiary;
        }
        dbParam_sBeneficiary.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sBeneficiary);

        System.Data.IDataParameter dbParam_sI140ReceiptNo = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140ReceiptNo.ParameterName = "@I140ReceiptNo";
        if (String.IsNullOrEmpty(sI140ReceiptNo))
        {
            dbParam_sI140ReceiptNo.Value = DBNull.Value;
        } else {
            dbParam_sI140ReceiptNo.Value = sI140ReceiptNo;
        }
        dbParam_sI140ReceiptNo.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140ReceiptNo);

        System.Data.IDataParameter dbParam_sI140DueDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140DueDate.ParameterName = "@I140DueDate";
        if (String.IsNullOrEmpty(sI140DueDate))
        {
            dbParam_sI140DueDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140DueDate.Value = Convert.ToDateTime(sI140DueDate);
        }
        dbParam_sI140DueDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sI140DueDate);

        System.Data.IDataParameter dbParam_sI140Docs = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140Docs.ParameterName = "@I140DocsReceived";
        dbParam_sI140Docs.Value = sI140Docs;
        dbParam_sI140Docs.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sI140Docs);
        
        System.Data.IDataParameter dbParam_sI140LastUpdDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140LastUpdDate.ParameterName = "@I140LastUpdDate";
        if (String.IsNullOrEmpty(sI140LastUpdDate))
        {
            dbParam_sI140LastUpdDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140LastUpdDate.Value = Convert.ToDateTime(sI140LastUpdDate);
        }
        dbParam_sI140LastUpdDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sI140LastUpdDate);

        System.Data.IDataParameter dbParam_sI140AssignedTo = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140AssignedTo.ParameterName = "@I140AssignedTo";
        if (String.IsNullOrEmpty(sI140AssignedTo))
        {
            dbParam_sI140AssignedTo.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140AssignedTo.Value = sI140AssignedTo;
        }
        dbParam_sI140AssignedTo.DbType = System.Data.DbType.Int32;
        dbCommand.Parameters.Add(dbParam_sI140AssignedTo);

        System.Data.IDataParameter dbParam_sI140MissingDocs = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140MissingDocs.ParameterName = "@I140DocsMissing";
        if (String.IsNullOrEmpty(sI140MissingDocs))
        {
            dbParam_sI140MissingDocs.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140MissingDocs.Value = sI140MissingDocs;
        }
        dbParam_sI140MissingDocs.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140MissingDocs);

        System.Data.IDataParameter dbParam_I140Drafted = new System.Data.SqlClient.SqlParameter();
        dbParam_I140Drafted.ParameterName = "@I140Drafted";
        dbParam_I140Drafted.Value = sI140CheckList[0];
        dbParam_I140Drafted.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140Drafted);

        System.Data.IDataParameter dbParam_I140PERMSentSignature = new System.Data.SqlClient.SqlParameter();
        dbParam_I140PERMSentSignature.ParameterName = "@I140PERMSentSignature";
        dbParam_I140PERMSentSignature.Value = sI140CheckList[1];
        dbParam_I140PERMSentSignature.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140PERMSentSignature);

        System.Data.IDataParameter dbParam_I140Premium = new System.Data.SqlClient.SqlParameter();
        dbParam_I140Premium.ParameterName = "@I140Premium";
        dbParam_I140Premium.Value = sI140CheckList[2];
        dbParam_I140Premium.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140Premium);

        System.Data.IDataParameter dbParam_I140Filed = new System.Data.SqlClient.SqlParameter();
        dbParam_I140Filed.ParameterName = "@I140Filed";
        dbParam_I140Filed.Value = sI140CheckList[3];
        dbParam_I140Filed.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140Filed);

        System.Data.IDataParameter dbParam_sI140FiledDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140FiledDate.ParameterName = "@I140FiledDate";
        if (String.IsNullOrEmpty(sI140FiledDate))
        {
            dbParam_sI140FiledDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140FiledDate.Value = Convert.ToDateTime(sI140FiledDate);
        }
        dbParam_sI140FiledDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sI140FiledDate);

        System.Data.IDataParameter dbParam_sI140InvNo = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140InvNo.ParameterName = "@I140InvNo";
        if (String.IsNullOrEmpty(sI140InvNo))
        {
            dbParam_sI140InvNo.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140InvNo.Value = sI140InvNo;
        }
        dbParam_sI140InvNo.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140InvNo);

        System.Data.IDataParameter dbParam_sI140Payment = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140Payment.ParameterName = "@I140PaymentRcvd";
        dbParam_sI140Payment.Value = sI140Payment;
        dbParam_sI140Payment.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sI140Payment);

        System.Data.IDataParameter dbParam_sI140Status = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140Status.ParameterName = "@I140Status";
        if (String.IsNullOrEmpty(sI140Status))
        {
            dbParam_sI140Status.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140Status.Value = sI140Status;
        }
        dbParam_sI140Status.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140Status);

        System.Data.IDataParameter dbParam_sI140RFEDueDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140RFEDueDate.ParameterName = "@I140RFEDueDate";
        if (String.IsNullOrEmpty(sI140RFEDueDate))
        {
            dbParam_sI140RFEDueDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140RFEDueDate.Value = Convert.ToDateTime(sI140RFEDueDate);
        }
        dbParam_sI140RFEDueDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sI140RFEDueDate);

        System.Data.IDataParameter dbParam_sI140RFEStatus = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140RFEStatus.ParameterName = "@I140RFEStatus";
        if (String.IsNullOrEmpty(sI140RFEStatus))
        {
            dbParam_sI140RFEStatus.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140RFEStatus.Value = sI140RFEStatus;
        }
        dbParam_sI140RFEStatus.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140RFEStatus);

        System.Data.IDataParameter dbParam_I140RFETypeAP = new System.Data.SqlClient.SqlParameter();
        dbParam_I140RFETypeAP.ParameterName = "@I140RFETypeAP";
        dbParam_I140RFETypeAP.Value = rfeTypes[0];
        dbParam_I140RFETypeAP.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140RFETypeAP);

        System.Data.IDataParameter dbParam_I140RFETypeA = new System.Data.SqlClient.SqlParameter();
        dbParam_I140RFETypeA.ParameterName = "@I140RFETypeA";
        dbParam_I140RFETypeA.Value = rfeTypes[1];
        dbParam_I140RFETypeA.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140RFETypeA);

        System.Data.IDataParameter dbParam_I140RFETypeE = new System.Data.SqlClient.SqlParameter();
        dbParam_I140RFETypeE.ParameterName = "@I140RFETypeE";
        dbParam_I140RFETypeE.Value = rfeTypes[2];
        dbParam_I140RFETypeE.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140RFETypeE);

        System.Data.IDataParameter dbParam_I140RFETypeO = new System.Data.SqlClient.SqlParameter();
        dbParam_I140RFETypeO.ParameterName = "@I140RFETypeO";
        dbParam_I140RFETypeO.Value = rfeTypes[3];
        dbParam_I140RFETypeO.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_I140RFETypeO);

        System.Data.IDataParameter dbParam_sI140RFEOtherNotes = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140RFEOtherNotes.ParameterName = "@I140RFETypeOtherComments";
        if (String.IsNullOrEmpty(sI140RFEOtherNotes))
        {
            dbParam_sI140RFEOtherNotes.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140RFEOtherNotes.Value = sI140RFEOtherNotes;
        }
        dbParam_sI140RFEOtherNotes.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140RFEOtherNotes);

        System.Data.IDataParameter dbParam_sI140Comments = new System.Data.SqlClient.SqlParameter();
        dbParam_sI140Comments.ParameterName = "@I140Notes";
        if (String.IsNullOrEmpty(sI140Comments))
        {
            dbParam_sI140Comments.Value = DBNull.Value;
        }
        else
        {
            dbParam_sI140Comments.Value = sI140Comments;
        }
        dbParam_sI140Comments.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sI140Comments);

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

    public System.Data.IDataReader getCandID()
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "SELECT Employee_id FROM Employee where Tracking_No = '" + this.lstTrackNo.SelectedItem.Text + "'";
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
    public attorney_AddI140()
    {
        Load += Page_Load;
    }

    protected int getCompanyId()
    {
        int intCompany_id = 0;
        try
        {
            intCompany_id = Convert.ToInt16(Session["ACompany_Id"]);
        }
        catch { }
        if (intCompany_id <= 0)
        {
            try
            {
                intCompany_id = Convert.ToInt16(Request.Cookies["Attorney"]["ACompany_Id"]);
            }
            catch { }
        }
        return intCompany_id;
    }

    protected void setCompanyId(int intCompanyId)
    {
        Session["ACompany_Id"] = intCompanyId;
        HttpCookie myCookie = new HttpCookie("Attorney");
        myCookie["ACompany_Id"] = intCompanyId.ToString();
        myCookie.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(myCookie);
    }

    protected void lstUsers_Changed(object sender, EventArgs e)
    {
        Page.SetFocus("lstUsers");
    }

    protected void LastUpdDate_Changed(object sender, EventArgs e)
    {
        if (!(lstI140Status != null && lstI140Status.Text != null && lstI140Status.Text.ToLower().Equals("inactivate")))
        {
            if (!String.IsNullOrEmpty(txtLastUpdDate.Text))
            {
                DateTime now = DateTime.Today;
                DateTime lud = Convert.ToDateTime(txtLastUpdDate.Text);
                TimeSpan diff = now - lud;
                if (diff.Days > 14)
                {
                    txtLastUpdDate.BackColor = System.Drawing.Color.Yellow;
                }
                else
                {
                    txtLastUpdDate.BackColor = System.Drawing.Color.YellowGreen;
                }
            }
        }
        Page.SetFocus("txtLastUpdDate");
    }

    protected void lstUsersI140_Changed(object sender, EventArgs e)
    {
        Page.SetFocus("lstUsersI140");
    }

    protected void I140Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstI140Status.SelectedValue != null && lstI140Status.SelectedValue == "RFE")
        {
            this.txtI140RFEDueDate.Enabled = true;
            this.lstI140RFEStatus.Enabled = true;
            this.chkPayAbility.Enabled = true;
            this.chkAcademics.Enabled = true;
            this.chkExperience.Enabled = true;
            this.chkOther.Enabled = true;
        }
        else
        {
            this.txtI140RFEDueDate.Enabled = false;
            this.lstI140RFEStatus.Enabled = false;
            this.chkPayAbility.Enabled = false;
            this.chkAcademics.Enabled = false;
            this.chkExperience.Enabled = false;
            this.chkOther.Enabled = false;
        }
        Page.SetFocus("lstI140Status");
    }

    protected void I140RFEOther_CheckedChanged(object sender, EventArgs e)
    {
        if (chkOther.Checked)
        {
            this.txtI140RFEOtherNotes.Enabled = true;
            Page.SetFocus("txtI140RFEOtherNotes");
        }
        else
        {
            this.txtI140RFEOtherNotes.Enabled = false;
            Page.SetFocus("txtI140Comments");
        }
    }

    protected Boolean checkI140S()
    {
        Boolean ret = false;
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "SELECT ID FROM I140Tracking where TrackingNo = '" + this.lstTrackNo.SelectedItem.Text + "'";
        System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
        dbCommand.CommandText = queryString;
        dbCommand.Connection = dbConnection;

        dbConnection.Open();
        System.Data.IDataReader dataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        if (dataReader.Read())
        {
            ret = true;
        } 
        return ret;
    }

    protected void populateI140DueDate()
    {
        if (!(String.IsNullOrEmpty(txtI140DueDate.Text)))
        {
            return;
        }
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "SELECT convert(varchar(10),max(PERMI140DueDate), 101) DUEDATE FROM PERMTracking where TrackingNo = '" + this.lstTrackNo.SelectedItem.Text + "'";
        System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
        dbCommand.CommandText = queryString;
        dbCommand.Connection = dbConnection;

        dbConnection.Open();
        System.Data.IDataReader dataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        if (dataReader.Read() && dataReader["DUEDATE"] != null)
        {
            txtI140DueDate.Text = dataReader["DUEDATE"].ToString();
        }
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
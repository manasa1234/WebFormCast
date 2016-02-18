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

public partial class attorney_AddPERM : System.Web.UI.Page
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
            checkPERMStatus();
            checkPERMCertDate();
        }

    }

    protected void lstTrackNo_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        getCandID();
        // Response.Write(Session("candID"))
        lstName.Text = this.lstTrackNo.SelectedItem.Value;
        if (checkPERMS())
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
        Boolean valid = true;
        RequiredFieldValidator4.Validate(); // This is not fired because of the calendar widget
        if (!RequiredFieldValidator4.IsValid)
        {
            valid = false;
        } 
        if (lstUsers.SelectedItem.Text == "Select User")
        {
            RequiredFieldValidator8.IsValid = false;
            valid = false;
        }
        if (!valid)
        {
            return;
        }
        string STnotes = null;
        STnotes = "PERM#: " + txtPERMTrack.Text;
        STnotes += " | PERM Status: " + lstPERMStatus.Text;
        STnotes += " | Last Updated Date: " + txtLastUpdDate.Text;
        STnotes += " | PERM Assigned To: " + lstUsers.SelectedItem.Text;
        if (txtPERMNotes.Text != null && txtPERMNotes.Text != "")
        {
            STnotes += " | PERM Comments: " + txtPERMNotes.Text;
        }
        bool[] auditTypes = new bool[8];
        auditTypes[0] = chkAuditTypeTR.Checked;
        auditTypes[1] = chkAuditTypeERP.Checked;
        auditTypes[2] = chkAuditTypeEP.Checked;
        auditTypes[3] = chkAuditTypeR.Checked;
        auditTypes[4] = chkAuditTypeRD.Checked;
        auditTypes[5] = chkAuditTypeRR.Checked;
        auditTypes[6] = chkAuditTypeBN.Checked;
        auditTypes[7] = chkAuditTypeO.Checked;

        InsertNewPERM(this.lstTrackNo.SelectedItem.Text, lstCompany.SelectedItem.Value, txtPWDTrack.Text, lstName.Text, txtLastUpdDate.Text
            , lstPERMCat.SelectedItem.Text, txtDatePWDFiled.Text, txtDatePWDIss.Text, txtDatePWDExp.Text, lstPWDStatus.SelectedItem.Text, txtJobTitle.Text
            , txtSal.Text, txtRecStartDate.Text, txtRecEndDate.Text, lstUsers.SelectedItem.Value, txtPERMPriDate.Text, txtPERMTrack.Text
            , lstPERMStatus.SelectedItem.Text, txtPERMDueDate.Text, txtAuditDueDate.Text, lstAuditStatus.SelectedItem.Text, auditTypes, txtAudTypeOtherNotes.Text, txtPERMCertDate.Text
            , txtI140DueDate.Text, txtInvNo.Text, chkPmnt.Checked, ""
           );
        InsertNotes((int)Session["candID"], STnotes, DateTime.Now, (int)Session["Attorney_User_Id"]);
        int intCompanyId = 0;
        if (!lstCompany.SelectedValue.Equals("-- Select Company Name"))
        {
            intCompanyId = Convert.ToInt16(lstCompany.SelectedValue);
            setCompanyId(intCompanyId);
            Company oC = new Company(intCompanyId);
            Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
        }
        Response.Redirect("perm.aspx");
    }

    public int InsertNewPERM(string sTrackingNo, string sCompany, string sPWDTrackingNo, string sBeneficiary, string sDateLastUpdated
        , string sPERMCat, string sPWDFiledDate, string sPWDIssDate, string sPWDExpDate, string sPWDStatus, string sJobTitle
        , string sSalary, string sRecStartDate, string sRecEndDate, string sPERMAssTo, string sPERMFileDate, string sPERMTrackingNo
        , string sPERMStatus, string sPERMDueDate, string sAuditDueDate, string sAuditStatus, bool[] sAuditTypes, string sAuditTypeOtherNotes, string sPERMCertDate
        , string sPERMI140DueDate, string sInvNo, Boolean sPaymentReceived, string sPERMNotes)
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "INSERT INTO PERMTracking (TrackingNo, Company, PWDTrackingNo, Beneficiary, DateLastUpdated, PERMCategory, DatePWDFiled, DatePWDIssued, DatePWDExpiry, PWDStatus, JobTitle, Salary, DateRecruitmentStart, DateRecruitmentEnd, PERMAssignedTo, PERMFilingDate, PERMTrackingNo, PERMStatus, PERMDueDate, AuditDueDate, AuditStatus, AuditTypeTR, AuditTypeERP, AuditTypeEP, AuditTypeR, AuditTypeRD, AuditTypeRR, AuditTypeBN, AuditTypeO, AuditTypeOtherComments, PERMCertDate, PERMI140DueDate, InvNo, PaymentReceived, PERMNotes) ";
        queryString += " VALUES (@TrackingNo, @Company, @PWDTrackingNo, @Beneficiary, @DateLastUpdated, @PERMCategory, @DatePWDFiled, @DatePWDIssued, @DatePWDExpiry, @PWDStatus, @JobTitle, @Salary, @DateRecruitmentStart, @DateRecruitmentEnd, @PERMAssignedTo, @PERMFilingDate, @PERMTrackingNo, @PERMStatus, @PERMDueDate, @AuditDueDate, @AuditStatus, @AuditTypeTR, @AuditTypeERP, @AuditTypeEP, @AuditTypeR, @AuditTypeRD, @AuditTypeRR, @AuditTypeBN, @AuditTypeO, @AuditTypeOtherComments, @PERMCertDate, @PERMI140DueDate, @InvNo, @PaymentReceived, @PERMNotes) ";
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

        System.Data.IDataParameter dbParam_sPWDTrackingNo = new System.Data.SqlClient.SqlParameter();
        dbParam_sPWDTrackingNo.ParameterName = "@PWDTrackingNo";
        if (String.IsNullOrEmpty(sPWDTrackingNo)){
            dbParam_sPWDTrackingNo.Value = DBNull.Value;
        } else {
            dbParam_sPWDTrackingNo.Value = sPWDTrackingNo;
        }
        dbParam_sPWDTrackingNo.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sPWDTrackingNo);

        System.Data.IDataParameter dbParam_sBeneficiary = new System.Data.SqlClient.SqlParameter();
        dbParam_sBeneficiary.ParameterName = "@Beneficiary";
        if (String.IsNullOrEmpty(sBeneficiary)){
            dbParam_sBeneficiary.Value = DBNull.Value;
        } else {
            dbParam_sBeneficiary.Value = sBeneficiary;
        }
        dbParam_sBeneficiary.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sBeneficiary);

        System.Data.IDataParameter dbParam_sDateLastUpdated = new System.Data.SqlClient.SqlParameter();
        dbParam_sDateLastUpdated.ParameterName = "@DateLastUpdated";
        if (String.IsNullOrEmpty(sDateLastUpdated))
        {
            dbParam_sDateLastUpdated.Value = DBNull.Value;
        }
        else
        {
            dbParam_sDateLastUpdated.Value = Convert.ToDateTime(sDateLastUpdated);
        }
        dbParam_sDateLastUpdated.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sDateLastUpdated);

        System.Data.IDataParameter dbParam_sPERMCategory = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMCategory.ParameterName = "@PERMCategory";
        if (String.IsNullOrEmpty(sPERMCat)){
            dbParam_sPERMCategory.Value = DBNull.Value;
        } else {
            dbParam_sPERMCategory.Value = sPERMCat;
        }
        dbParam_sPERMCategory.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sPERMCategory);

        System.Data.IDataParameter dbParam_sDatePWDFiled = new System.Data.SqlClient.SqlParameter();
        dbParam_sDatePWDFiled.ParameterName = "@DatePWDFiled";
        if (String.IsNullOrEmpty(sPWDFiledDate))
        {
            dbParam_sDatePWDFiled.Value = DBNull.Value;
        }
        else
        {
            dbParam_sDatePWDFiled.Value = Convert.ToDateTime(sPWDFiledDate); 
        }
        dbParam_sDatePWDFiled.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sDatePWDFiled);

        System.Data.IDataParameter dbParam_sDatePWDIssued = new System.Data.SqlClient.SqlParameter();
        dbParam_sDatePWDIssued.ParameterName = "@DatePWDIssued";
        if (String.IsNullOrEmpty(sPWDIssDate))
        {
            dbParam_sDatePWDIssued.Value = DBNull.Value;
        }
        else
        {
            dbParam_sDatePWDIssued.Value = Convert.ToDateTime(sPWDIssDate); 
        }
        dbParam_sDatePWDIssued.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sDatePWDIssued);

        System.Data.IDataParameter dbParam_sDatePWDExpiry = new System.Data.SqlClient.SqlParameter();
        dbParam_sDatePWDExpiry.ParameterName = "@DatePWDExpiry";
        if (String.IsNullOrEmpty(sPWDExpDate))
        {
            dbParam_sDatePWDExpiry.Value = DBNull.Value;
        }
        else
        {
            dbParam_sDatePWDExpiry.Value = Convert.ToDateTime(sPWDExpDate);
        }
        dbParam_sDatePWDExpiry.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sDatePWDExpiry);

        System.Data.IDataParameter dbParam_sPWDStatus = new System.Data.SqlClient.SqlParameter();
        dbParam_sPWDStatus.ParameterName = "@PWDStatus";
        if (String.IsNullOrEmpty(sPWDStatus)){
            dbParam_sPWDStatus.Value = DBNull.Value;
        } else {
            dbParam_sPWDStatus.Value = sPWDStatus;
        }
        dbParam_sPWDStatus.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sPWDStatus);

        System.Data.IDataParameter dbParam_sJobtitle = new System.Data.SqlClient.SqlParameter();
        dbParam_sJobtitle.ParameterName = "@JobTitle";
        if (String.IsNullOrEmpty(sJobTitle)){
            dbParam_sJobtitle.Value = DBNull.Value;
        } else {
            dbParam_sJobtitle.Value = sJobTitle;
        }
        dbParam_sJobtitle.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sJobtitle);

        System.Data.IDataParameter dbParam_sSalary = new System.Data.SqlClient.SqlParameter();
        dbParam_sSalary.ParameterName = "@Salary";
        if (String.IsNullOrEmpty(sSalary)){
            dbParam_sSalary.Value = DBNull.Value;
        } else {
            dbParam_sSalary.Value = sSalary;
        }
        dbParam_sSalary.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sSalary);

        System.Data.IDataParameter dbParam_sDateRecruitmentStart = new System.Data.SqlClient.SqlParameter();
        dbParam_sDateRecruitmentStart.ParameterName = "@DateRecruitmentStart";
        if (String.IsNullOrEmpty(sRecStartDate))
        {
            dbParam_sDateRecruitmentStart.Value = DBNull.Value;
        }
        else
        {
            dbParam_sDateRecruitmentStart.Value = Convert.ToDateTime(sRecStartDate);
        }
        dbParam_sDateRecruitmentStart.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sDateRecruitmentStart);

        System.Data.IDataParameter dbParam_sDateRecruitmentEnd = new System.Data.SqlClient.SqlParameter();
        dbParam_sDateRecruitmentEnd.ParameterName = "@DateRecruitmentEnd";
        if (String.IsNullOrEmpty(sRecEndDate))
        {
            dbParam_sDateRecruitmentEnd.Value = DBNull.Value;
        }
        else
        {
            dbParam_sDateRecruitmentEnd.Value = Convert.ToDateTime(sRecEndDate);
        }
        dbParam_sDateRecruitmentEnd.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sDateRecruitmentEnd);

        System.Data.IDataParameter dbParam_sPERMAssignedTo = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMAssignedTo.ParameterName = "@PERMAssignedTo";
        if (String.IsNullOrEmpty(sPERMAssTo))
        {
            dbParam_sPERMAssignedTo.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMAssignedTo.Value = sPERMAssTo;
        }
        dbParam_sPERMAssignedTo.DbType = System.Data.DbType.Int32;
        dbCommand.Parameters.Add(dbParam_sPERMAssignedTo);

        System.Data.IDataParameter dbParam_sPERMFilingDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMFilingDate.ParameterName = "@PERMFilingDate";
        if (String.IsNullOrEmpty(sPERMFileDate))
        {
            dbParam_sPERMFilingDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMFilingDate.Value = Convert.ToDateTime(sPERMFileDate);
        }
        dbParam_sPERMFilingDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sPERMFilingDate);

        System.Data.IDataParameter dbParam_sPERMTrackinNo = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMTrackinNo.ParameterName = "@PERMTrackingNo";
        if (String.IsNullOrEmpty(sPERMTrackingNo)){
            dbParam_sPERMTrackinNo.Value = DBNull.Value;
        } else {
            dbParam_sPERMTrackinNo.Value = sPERMTrackingNo;
        }
        dbParam_sPERMTrackinNo.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sPERMTrackinNo);

        System.Data.IDataParameter dbParam_sPERMStatus = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMStatus.ParameterName = "@PERMStatus";
        if (String.IsNullOrEmpty(sPERMStatus))
        {
            dbParam_sPERMStatus.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMStatus.Value = sPERMStatus;
        }
        dbParam_sPERMStatus.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sPERMStatus);

        System.Data.IDataParameter dbParam_sPERMDueDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMDueDate.ParameterName = "@PERMDueDate";
        if (String.IsNullOrEmpty(sPERMDueDate))
        {
            dbParam_sPERMDueDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMDueDate.Value = Convert.ToDateTime(sPERMDueDate);
        }
        dbParam_sPERMDueDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sPERMDueDate);

        System.Data.IDataParameter dbParam_sAuditDueDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditDueDate.ParameterName = "@AuditDueDate";
        if (String.IsNullOrEmpty(sAuditDueDate))
        {
            dbParam_sAuditDueDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sAuditDueDate.Value = Convert.ToDateTime(sAuditDueDate);
        }
        dbParam_sAuditDueDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sAuditDueDate);

        System.Data.IDataParameter dbParam_sAuditStatus = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditStatus.ParameterName = "@AuditStatus";
        if (String.IsNullOrEmpty(sAuditStatus))
        {
            dbParam_sAuditStatus.Value = DBNull.Value;
        }
        else
        {
            dbParam_sAuditStatus.Value = sAuditStatus;
        }
        dbParam_sAuditStatus.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sAuditStatus);

        // Audit Types
        System.Data.IDataParameter dbParam_sAuditTypeTR = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeTR.ParameterName = "@AuditTypeTR";
        dbParam_sAuditTypeTR.Value = sAuditTypes[0];
        dbParam_sAuditTypeTR.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeTR);
        //
        System.Data.IDataParameter dbParam_sAuditTypeER = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeER.ParameterName = "@AuditTypeERP";
        dbParam_sAuditTypeER.Value = sAuditTypes[1];
        dbParam_sAuditTypeER.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeER);
        //
        System.Data.IDataParameter dbParam_sAuditTypeEP = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeEP.ParameterName = "@AuditTypeEP";
        dbParam_sAuditTypeEP.Value = sAuditTypes[2];
        dbParam_sAuditTypeEP.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeEP);
        //
        System.Data.IDataParameter dbParam_sAuditTypeR = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeR.ParameterName = "@AuditTypeR";
        dbParam_sAuditTypeR.Value = sAuditTypes[3];
        dbParam_sAuditTypeR.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeR);
        //
        System.Data.IDataParameter dbParam_sAuditTypeRD = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeRD.ParameterName = "@AuditTypeRD";
        dbParam_sAuditTypeRD.Value = sAuditTypes[4];
        dbParam_sAuditTypeRD.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeRD);
        //
        System.Data.IDataParameter dbParam_sAuditTypeRR = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeRR.ParameterName = "@AuditTypeRR";
        dbParam_sAuditTypeRR.Value = sAuditTypes[5];
        dbParam_sAuditTypeRR.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeRR);
        //
        System.Data.IDataParameter dbParam_sAuditTypeBN = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeBN.ParameterName = "@AuditTypeBN";
        dbParam_sAuditTypeBN.Value = sAuditTypes[6];
        dbParam_sAuditTypeBN.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeBN);
        //
        System.Data.IDataParameter dbParam_sAuditTypeO = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeO.ParameterName = "@AuditTypeO";
        dbParam_sAuditTypeO.Value = sAuditTypes[7];
        dbParam_sAuditTypeO.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sAuditTypeO);


        System.Data.IDataParameter dbParam_sAuditTypeOtherComments = new System.Data.SqlClient.SqlParameter();
        dbParam_sAuditTypeOtherComments.ParameterName = "@AuditTypeOtherComments";
        if (String.IsNullOrEmpty(sAuditTypeOtherNotes))
        {
            dbParam_sAuditTypeOtherComments.Value = DBNull.Value;
        }
        else
        {
            dbParam_sAuditTypeOtherComments.Value = sAuditTypeOtherNotes;
        }
        dbParam_sAuditTypeOtherComments.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sAuditTypeOtherComments);

        System.Data.IDataParameter dbParam_sPERMCertDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMCertDate.ParameterName = "@PERMCertDate";
        if (String.IsNullOrEmpty(sPERMCertDate))
        {
            dbParam_sPERMCertDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMCertDate.Value = Convert.ToDateTime(sPERMCertDate);
        }
        dbParam_sPERMCertDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sPERMCertDate);

        System.Data.IDataParameter dbParam_sPERMI140DueDate = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMI140DueDate.ParameterName = "@PERMI140DueDate";
        if (String.IsNullOrEmpty(sPERMI140DueDate))
        {
            dbParam_sPERMI140DueDate.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMI140DueDate.Value = Convert.ToDateTime(sPERMI140DueDate);
        }
        dbParam_sPERMI140DueDate.DbType = System.Data.DbType.DateTime;
        dbCommand.Parameters.Add(dbParam_sPERMI140DueDate);

        System.Data.IDataParameter dbParam_sInvNo = new System.Data.SqlClient.SqlParameter();
        dbParam_sInvNo.ParameterName = "@InvNo";
        if (String.IsNullOrEmpty(sInvNo))
        {
            dbParam_sInvNo.Value = DBNull.Value;
        }
        else
        {
            dbParam_sInvNo.Value = sInvNo;
        }
        dbParam_sInvNo.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sInvNo);

        System.Data.IDataParameter dbParam_sPaymentReceived = new System.Data.SqlClient.SqlParameter();
        dbParam_sPaymentReceived.ParameterName = "@PaymentReceived";
        dbParam_sPaymentReceived.Value = sPaymentReceived;

        dbParam_sPaymentReceived.DbType = System.Data.DbType.Boolean;
        dbCommand.Parameters.Add(dbParam_sPaymentReceived);

        System.Data.IDataParameter dbParam_sPERMNotes = new System.Data.SqlClient.SqlParameter();
        dbParam_sPERMNotes.ParameterName = "@PERMNotes";
        if (String.IsNullOrEmpty(sPERMNotes))
        {
            dbParam_sPERMNotes.Value = DBNull.Value;
        }
        else
        {
            dbParam_sPERMNotes.Value = sPERMNotes;
        }
        dbParam_sPERMNotes.DbType = System.Data.DbType.String;
        dbCommand.Parameters.Add(dbParam_sPERMNotes);

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
    public attorney_AddPERM()
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

    protected void PERMStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        checkPERMStatus();
        Page.SetFocus("lstPERMStatus");
    }

    protected void checkPERMStatus()
    {
        if (lstPERMStatus.SelectedValue != null && lstPERMStatus.SelectedValue == "Audit")
        {
            this.txtAuditDueDate.Enabled = true;
            this.lstAuditStatus.Enabled = true;
            this.chkAuditTypeTR.Enabled = true;
            this.chkAuditTypeERP.Enabled = true;
            this.chkAuditTypeEP.Enabled = true;
            this.chkAuditTypeR.Enabled = true;
            this.chkAuditTypeRD.Enabled = true;
            this.chkAuditTypeRR.Enabled = true;
            this.chkAuditTypeBN.Enabled = true;
            this.chkAuditTypeO.Enabled = true;
            if (chkAuditTypeO.Checked)
            {
                this.txtAudTypeOtherNotes.Enabled = true;
            }
            else
            {
                this.txtAudTypeOtherNotes.Enabled = false;
            }
        }
        else
        {
            this.txtAuditDueDate.Enabled = false;
            this.lstAuditStatus.Enabled = false;
            this.chkAuditTypeTR.Enabled = false;
            this.chkAuditTypeERP.Enabled = false;
            this.chkAuditTypeEP.Enabled = false;
            this.chkAuditTypeR.Enabled = false;
            this.chkAuditTypeRD.Enabled = false;
            this.chkAuditTypeRR.Enabled = false;
            this.chkAuditTypeBN.Enabled = false;
            this.chkAuditTypeO.Enabled = false;
            this.txtAudTypeOtherNotes.Enabled = false;
        }
    }

    protected void AuditTypeO_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAuditTypeO.Checked)
        {
            this.txtAudTypeOtherNotes.Enabled = true;
        }
        else
        {
            this.txtAudTypeOtherNotes.Enabled = false;
        }
        Page.SetFocus("txtAudTypeOtherNotes");
    }

    protected void PERMCertDate_Changed(object sender, EventArgs e)
    {
        checkPERMCertDate();
        Page.SetFocus("txtPERMCertDate");
    }

    protected void checkPERMCertDate()
    {
        if (!String.IsNullOrEmpty(txtPERMCertDate.Text))
        {
            DateTime dt = (Convert.ToDateTime(txtPERMCertDate.Text)).AddDays(180);
            this.txtI140DueDate.Text = dt.ToString("MM/dd/yyyy");
        }
    }

    protected void lstUsers_Changed(object sender, EventArgs e)
    {
        Page.SetFocus("lstUsers");
    }

    protected void LastUpdDate_Changed(object sender, EventArgs e)
    {
        if (!(lstPERMStatus != null && lstPERMStatus.Text != null && lstPERMStatus.Text.ToLower().Equals("inactivate")))
        {
            if (!String.IsNullOrEmpty(txtLastUpdDate.Text))
            {
                DateTime now = DateTime.Today;
                DateTime lud = Convert.ToDateTime(txtLastUpdDate.Text);
                TimeSpan diff = now - lud;
                if (diff.Days > 7)
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

    protected Boolean checkPERMS()
    {
        Boolean ret = false;
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

        string queryString = "SELECT ID FROM PERMTracking where TrackingNo = '" + this.lstTrackNo.SelectedItem.Text + "'";
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
    protected void permSearch_Click(object sender, System.EventArgs e)
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
        Session["CaseRequestPage"] = "perm";
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
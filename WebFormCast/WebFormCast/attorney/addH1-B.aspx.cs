using ACLGDataAaccess;
using System;
using System.Collections;
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
    public partial class addH1_B : System.Web.UI.Page
    {
        string scomp;
        string strack;
        string sstatus;
        string sstatuspet;
      
        Nullable<DateTime> sfedex;
        Nullable<DateTime> suscis;
        Nullable<DateTime> sstatusexp;
        string steam;
        string date = "mm/dd/yyyy";
        int intAttorney_id = 0;
        int intCompany_id = 0;
        string lcatrac = "";
        Nullable<DateTime> Dtfiled;
        Nullable<DateTime> rfedtreceived;
        Nullable<DateTime> r4ddtsent;
        DateTime rfeuscist1;
        //Nullable<DateTime> rfeuscisdt;
        Nullable<DateTime> rfeuscisdt;
        Nullable<DateTime> rfelatestshipdt;
        Nullable<DateTime> rfeinternaldt;
        string rfetypenw = "";
        string rfetype = "";
        string rfeeval = "";
        string rfemissingdoc = "";
        string rfedrafted = "";
        string rfestatus = "";
        string item = "";
        Nullable<DateTime> rfelastupdated;
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
                this.Label1.Text = "";
            }
            catch
            { }

            if (!IsPostBack)
            {
              
           
               
                assignedto();
                fedexassigned();
                RFEtype();
                getcasetypevalues();
                GetStatesList();
                txtdateinitiated.Text = DateTime.Now.ToString("MM/dd/yyyy");
                AcglGeneral objG = new AcglGeneral();
                lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
                try
                {
                    intCompany_id = getCompanyId();
                }
                catch { }
                if (intCompany_id > 0)
                {
                    lstcompany.SelectedValue = intCompany_id.ToString();
                    Company oC = new Company(intCompany_id);
                    Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
                }
            }
        }

        //protected void RlTrack_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    // Response.Write(Session("candID"))
        //    //lstname.Text = this.RlTrack.SelectedItem.Value;
        //    lstname.Text = getCandID();
        //}

        //protected void lstcompany_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    lstname.Text = "";
        //}

        //protected void Button1_Click(object sender, System.EventArgs e)
        //{

        //}

        //public int InsertNIVTrackingNumber(string NIVtrackNumber, int Company, string RLCtracking, string LCtracking, DateTime? LCAfiled, DateTime? DueDate, string Draftstatus, string sigpages, string checks,
        //    string premiumprocessing, string casetype, DateTime? statusexpires, string location, string H4trackno, string H4sigpages, string invoice, DateTime? lastupdated,
        //    string paid, int userid, string RFEtype, DateTime? RFEdatereceive, DateTime? R4Dsent, DateTime? RFEinternalduedt, DateTime? lastshipdate, DateTime? uscisduedate,
        //    string RFEeval, string RFEmissingdocs, string RFEdrafted, string RFEstatus, DateTime? RFElastupdated, string sNotes)
        //{
        //    ACLGDB DB = new ACLGDB();
        //    string connectionString = DB.ConnectionString;
        //    System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);
        //    //ACLGDB DB = new ACLGDB();
        //    //string connectionString = DB.ConnectionString;

        //    string queryString = "INSERT INTO [NIVtracking] ([NIVTrackingNumber],[Company],[RLTrackingNumber],[LCATrackNumber],[LCAfiled] ,[DueDate] ,[DraftStatus],[SigPages],[Check],[Premium_Processing],[Case_Type],[Status_Expires],[location],[H4TrackNumber],[H4_SigPages],[Invoice],[Last_Updated],[Paid],[User_Id],[RFE_Type] ,[RFEDateReceive],[Date_R4D_Sent],[RFE_Internal_Due_Date],[RFE_LastShip_Date],[RFE_Uscis_DueDate],[RFE_Evaluation_Filed],[RFE_Missing_Docs],[RFE_Drafted],[RFE_Status],[RFE_LastUpdated],[Notes]) Values (@NIVtrackNumber,@Company,@RLCtracking,@LCtracking,@LCAfiled,@DueDate,@Draftstatus,@sigpages,@checks,@premiumprocessing,@casetype,@statusexpires,@location,@H4trackno,@H4sigpages,@invoice,@lastupdated, @paid,@userid,@RFEtype,@RFEdatereceive,@R4Dsent,@RFEinternalduedt,@lastshipdate,@uscisduedate,@RFEeval,@RFEmissingdocs,@RFEdrafted,@RFEstatus,@RFElastupdated,@sNotes)";
        //    System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
        //    dbCommand.CommandText = queryString;
        //    dbCommand.Connection = dbConnection;

        //    System.Data.IDataParameter dbParam_NIVtrackNumber = new System.Data.SqlClient.SqlParameter();
        //    dbParam_NIVtrackNumber.ParameterName = "@NIVtrackNumber";
        //    dbParam_NIVtrackNumber.Value = NIVtrackNumber;
        //    dbParam_NIVtrackNumber.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_NIVtrackNumber);

        //    System.Data.IDataParameter dbParam_Company = new System.Data.SqlClient.SqlParameter();
        //    dbParam_Company.ParameterName = "@Company";
        //    dbParam_Company.Value = Company;
        //    dbParam_Company.DbType = System.Data.DbType.Int32;
        //    dbCommand.Parameters.Add(dbParam_Company);

        //    System.Data.IDataParameter dbParam_RLCtracking = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RLCtracking.ParameterName = "@RLCtracking";
        //    dbParam_RLCtracking.Value = RLCtracking;
        //    dbParam_RLCtracking.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_RLCtracking);

        //    System.Data.IDataParameter dbParam_LCtracking = new System.Data.SqlClient.SqlParameter();
        //    dbParam_LCtracking.ParameterName = "@LCtracking";
        //    dbParam_LCtracking.Value = LCtracking;
        //    dbParam_LCtracking.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_LCtracking);

        //    System.Data.IDataParameter dbParam_LCAfiled = new System.Data.SqlClient.SqlParameter();
        //    dbParam_LCAfiled.ParameterName = "@LCAfiled";
        //    dbParam_LCAfiled.Value = LCAfiled;
        //    dbParam_LCAfiled.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_LCAfiled);


        //    System.Data.IDataParameter dbParam_DueDate = new System.Data.SqlClient.SqlParameter();
        //    dbParam_DueDate.ParameterName = "@DueDate";
        //    dbParam_DueDate.Value = DueDate;
        //    dbParam_DueDate.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_DueDate);

        //    System.Data.IDataParameter dbParam_Draftstatus = new System.Data.SqlClient.SqlParameter();
        //    dbParam_Draftstatus.ParameterName = "@Draftstatus";
        //    dbParam_Draftstatus.Value = Draftstatus;
        //    dbParam_Draftstatus.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_Draftstatus);

        //    System.Data.IDataParameter dbParam_sigpages = new System.Data.SqlClient.SqlParameter();
        //    dbParam_sigpages.ParameterName = "@sigpages";
        //    dbParam_sigpages.Value = sigpages;
        //    dbParam_sigpages.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_sigpages);

        //    System.Data.IDataParameter dbParam_checks = new System.Data.SqlClient.SqlParameter();
        //    dbParam_checks.ParameterName = "@checks";
        //    dbParam_checks.Value = checks;
        //    dbParam_checks.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_checks);

        //    System.Data.IDataParameter dbParam_premiumprocessing = new System.Data.SqlClient.SqlParameter();
        //    dbParam_premiumprocessing.ParameterName = "@premiumprocessing";
        //    dbParam_premiumprocessing.Value = premiumprocessing;
        //    dbParam_premiumprocessing.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_premiumprocessing);

        //    System.Data.IDataParameter dbParam_casetype = new System.Data.SqlClient.SqlParameter();
        //    dbParam_casetype.ParameterName = "@casetype";
        //    dbParam_casetype.Value = casetype;
        //    dbParam_casetype.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_casetype);

        //    System.Data.IDataParameter dbParam_statusexpires = new System.Data.SqlClient.SqlParameter();
        //    dbParam_statusexpires.ParameterName = "@statusexpires";
        //    dbParam_statusexpires.Value = statusexpires;
        //    dbParam_statusexpires.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_statusexpires);

        //    System.Data.IDataParameter dbParam_location = new System.Data.SqlClient.SqlParameter();
        //    dbParam_location.ParameterName = "@location";
        //    dbParam_location.Value = location;
        //    dbParam_location.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_location);

        //    System.Data.IDataParameter dbParam_H4trackno = new System.Data.SqlClient.SqlParameter();
        //    dbParam_H4trackno.ParameterName = "@H4trackno";
        //    dbParam_H4trackno.Value = H4trackno;
        //    dbParam_H4trackno.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_H4trackno);

        //    System.Data.IDataParameter dbParam_H4sigpages = new System.Data.SqlClient.SqlParameter();
        //    dbParam_H4sigpages.ParameterName = "@H4sigpages";
        //    dbParam_H4sigpages.Value = H4sigpages;
        //    dbParam_H4sigpages.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_H4sigpages);

        //    System.Data.IDataParameter dbParam_invoice = new System.Data.SqlClient.SqlParameter();
        //    dbParam_invoice.ParameterName = "@invoice";
        //    dbParam_invoice.Value = invoice;
        //    dbParam_invoice.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_invoice);

        //    System.Data.IDataParameter dbParam_lastupdated = new System.Data.SqlClient.SqlParameter();
        //    dbParam_lastupdated.ParameterName = "@lastupdated";
        //    dbParam_lastupdated.Value = lastupdated;
        //    dbParam_lastupdated.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_lastupdated);

        //    System.Data.IDataParameter dbParam_paid = new System.Data.SqlClient.SqlParameter();
        //    dbParam_paid.ParameterName = "@paid";
        //    dbParam_paid.Value = paid;
        //    dbParam_paid.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_paid);

        //    System.Data.IDataParameter dbParam_userid = new System.Data.SqlClient.SqlParameter();
        //    dbParam_userid.ParameterName = "@userid";
        //    dbParam_userid.Value = userid;
        //    dbParam_userid.DbType = System.Data.DbType.Int32;
        //    dbCommand.Parameters.Add(dbParam_userid);

        //    System.Data.IDataParameter dbParam_RFEtype = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEtype.ParameterName = "@RFEtype";
        //    dbParam_RFEtype.Value = RFEtype;
        //    dbParam_RFEtype.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_RFEtype);

        //    System.Data.IDataParameter dbParam_RFEdatereceive = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEdatereceive.ParameterName = "@RFEDateReceive";
        //    dbParam_RFEdatereceive.Value = RFEdatereceive;
        //    dbParam_RFEdatereceive.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_RFEdatereceive);

        //    System.Data.IDataParameter dbParam_R4Dsent = new System.Data.SqlClient.SqlParameter();
        //    dbParam_R4Dsent.ParameterName = "@R4Dsent";
        //    dbParam_R4Dsent.Value = R4Dsent;
        //    dbParam_R4Dsent.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_R4Dsent);

        //    System.Data.IDataParameter dbParam_RFEinternalduedt = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEinternalduedt.ParameterName = "@RFEinternalduedt";
        //    dbParam_RFEinternalduedt.Value = RFEinternalduedt;
        //    dbParam_RFEinternalduedt.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_RFEinternalduedt);

        //    System.Data.IDataParameter dbParam_lastshipdate = new System.Data.SqlClient.SqlParameter();
        //    dbParam_lastshipdate.ParameterName = "@lastshipdate";
        //    dbParam_lastshipdate.Value = lastshipdate;
        //    dbParam_lastshipdate.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_lastshipdate);

        //    System.Data.IDataParameter dbParam_uscisduedate = new System.Data.SqlClient.SqlParameter();
        //    dbParam_uscisduedate.ParameterName = "@uscisduedate";
        //    dbParam_uscisduedate.Value = uscisduedate;
        //    dbParam_uscisduedate.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_uscisduedate);

        //    System.Data.IDataParameter dbParam_RFEeval = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEeval.ParameterName = "@RFEeval";
        //    dbParam_RFEeval.Value = RFEeval;
        //    dbParam_RFEeval.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_RFEeval);

        //    System.Data.IDataParameter dbParam_RFEmissingdocs = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEmissingdocs.ParameterName = "@RFEmissingdocs";
        //    dbParam_RFEmissingdocs.Value = RFEmissingdocs;
        //    dbParam_RFEmissingdocs.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_RFEmissingdocs);

        //    System.Data.IDataParameter dbParam_RFEdrafted = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEdrafted.ParameterName = "@RFEdrafted";
        //    dbParam_RFEdrafted.Value = RFEdrafted;
        //    dbParam_RFEdrafted.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_RFEdrafted);


        //    System.Data.IDataParameter dbParam_RFEstatus = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFEstatus.ParameterName = "@RFEstatus";
        //    dbParam_RFEstatus.Value = RFEstatus;
        //    dbParam_RFEstatus.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_RFEstatus);


        //    System.Data.IDataParameter dbParam_RFElastupdated = new System.Data.SqlClient.SqlParameter();
        //    dbParam_RFElastupdated.ParameterName = "@RFElastupdated";
        //    dbParam_RFElastupdated.Value = RFElastupdated;
        //    dbParam_RFElastupdated.DbType = System.Data.DbType.DateTime;
        //    dbCommand.Parameters.Add(dbParam_RFElastupdated);

        //    System.Data.IDataParameter dbParam_sNotes = new System.Data.SqlClient.SqlParameter();
        //    dbParam_sNotes.ParameterName = "@sNotes";
        //    dbParam_sNotes.Value = sNotes;
        //    dbParam_sNotes.DbType = System.Data.DbType.String;
        //    dbCommand.Parameters.Add(dbParam_sNotes);
        //    int rowsAffected = 0;
        //    dbConnection.Open();

        //    try
        //    {
        //        //Response.Write(queryString)
        //        //Response.End()
        //        rowsAffected = dbCommand.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        dbConnection.Close();
        //    }

        //    return rowsAffected;



        //}

        public int InsertNIVTrackingNumber(int Company, string RLCtracking, string LCtracking, DateTime? LCAfiled, DateTime? DueDate, string Draftstatus, string sigpages, string checks,
           string premiumprocessing, string casetype, DateTime? statusexpires, int location, string H4trackno, string H4sigpages, string invoice, DateTime? lastupdated,
           string paid, int userid, string RFEtype, DateTime? RFEdatereceive, DateTime? R4Dsent, DateTime? RFEinternalduedt, DateTime? lastshipdate, DateTime? uscisduedate,
           string RFEeval, string RFEmissingdocs, string RFEdrafted, string RFEstatus, DateTime? RFElastupdated, string sNotes, DateTime? Date_Initiated, string cstatus, string fedextrack, int fedexshippedby, DateTime? fedexshippeddt, string petetionstatus, string team, string Contract, string h1pending)
        {
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            string queryString = "INSERT INTO [dbo].[NIVtracking] ([Company],[RLTrackingNumber],[LCATrackNumber],[LCAfiled],[DueDate],[DraftStatus],[SigPages],[Check],[Premium_Processing],[Case_Type] ,[Status_Expires],[location],[H4TrackNumber],[H4_SigPages],[Invoice],[Last_Updated],[Paid],[User_Id],[RFE_Type],[RFEDateReceive],[Date_R4D_Sent],[RFE_Internal_Due_Date],[RFE_LastShip_Date],[RFE_Uscis_DueDate],[RFE_Evaluation_Filed] ,[RFE_Missing_Docs],[RFE_Drafted],[RFE_Status],[RFE_LastUpdated],[Notes],[Date_Initiated],[Current_Status],[FedexTracking],[Fedex_ShippedBy],[Fedex_DateShipped],[PetetionStatus],[Team],[Contractualseesion],[Pending_documents]) VALUES (@Company,@RLTrackingNumber,@LCATrackNumber,@LCAfiled,@DueDate,@DraftStatus,@SigPages,@Check,@Premium_Processing,@Case_Type,@Status_Expires,@location,@H4TrackNumber,@H4_SigPages,@Invoice,@Last_Updated,@Paid,@User_Id,@RFE_Type,@RFEDateReceive,@Date_R4D_Sent,@RFE_Internal_Due_Date,@RFE_LastShip_Date,@RFE_Uscis_DueDate,@RFE_Evaluation_Filed,@RFE_Missing_Docs,@RFE_Drafted,@RFE_Status,@RFE_LastUpdated,@Notes,@Date_Initiated,@Current_Status,@FedexTracking,@Fedex_ShippedBy,@Fedex_DateShipped,@PetetionStatus,@Team,@Contractualseesion,@Pending_documents)";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = queryString;
            cmd.Connection = con;
            cmd.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
            cmd.Parameters.Add("@RLTrackingNumber", SqlDbType.NVarChar, 255).Value = RLCtracking;
            
            if (String.IsNullOrEmpty(LCtracking))
            {
                cmd.Parameters.AddWithValue("@LCATrackNumber", DBNull.Value); 
            }
             else
            {
                cmd.Parameters.Add("@LCATrackNumber", SqlDbType.NVarChar, 255).Value = LCtracking;
            }
            if (LCAfiled == null)
            {
                cmd.Parameters.AddWithValue("@LCAfiled", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@LCAfiled", SqlDbType.DateTime).Value = LCAfiled;
            }
            if (DueDate == null)
            {
                cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@DueDate", SqlDbType.DateTime).Value = DueDate;
            }
            
                cmd.Parameters.Add("@DraftStatus", SqlDbType.NVarChar, 255).Value = Draftstatus;
            
           
                cmd.Parameters.Add("@SigPages", SqlDbType.VarChar, 50).Value = sigpages;
           
                cmd.Parameters.Add("@Check", SqlDbType.VarChar, 50).Value = checks;
            
         
                cmd.Parameters.Add("@Premium_Processing", SqlDbType.VarChar, 50).Value = premiumprocessing;
            
                cmd.Parameters.Add("@Case_Type", SqlDbType.VarChar, 100).Value = casetype;
            
            if (statusexpires == null)
            {
                cmd.Parameters.AddWithValue("@Status_Expires", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Status_Expires", SqlDbType.DateTime).Value = statusexpires;
            }
            
                cmd.Parameters.Add("@location", SqlDbType.Int).Value = location;
            
            if (String.IsNullOrEmpty(H4trackno))
            {
                cmd.Parameters.AddWithValue("@H4TrackNumber", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@H4TrackNumber", SqlDbType.NVarChar, 255).Value = H4trackno;
            }
            if (String.IsNullOrEmpty(H4sigpages))
            {
                cmd.Parameters.AddWithValue("@H4_SigPages", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@H4_SigPages", SqlDbType.VarChar, 50).Value = H4sigpages;
            }
            if (String.IsNullOrEmpty(invoice))
            {
                cmd.Parameters.AddWithValue("@Invoice", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Invoice", SqlDbType.NVarChar, 255).Value = invoice;
            }
            if (lastupdated == null)
            {
                cmd.Parameters.AddWithValue("@Last_Updated", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Last_Updated", SqlDbType.DateTime).Value = lastupdated;
            }
            
                cmd.Parameters.Add("@Paid", SqlDbType.VarChar, 50).Value = paid;
            cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = userid;
            if (String.IsNullOrEmpty(RFEtype))
            {
                cmd.Parameters.AddWithValue("@RFE_Type", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_Type", SqlDbType.VarChar, 100).Value = RFEtype;
            }
            if (RFEdatereceive == null)
            {
                cmd.Parameters.AddWithValue("@RFEDateReceive", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFEDateReceive", SqlDbType.DateTime).Value = RFEdatereceive;
            }
            if (R4Dsent == null)
            {
                cmd.Parameters.AddWithValue("@Date_R4D_Sent", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Date_R4D_Sent", SqlDbType.DateTime).Value = R4Dsent;
            }
            if (RFEinternalduedt == null)
            {
                cmd.Parameters.AddWithValue("@RFE_Internal_Due_Date", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_Internal_Due_Date", SqlDbType.DateTime).Value = RFEinternalduedt;
            }
            if (lastshipdate == null)
            {
                cmd.Parameters.AddWithValue("@RFE_LastShip_Date", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_LastShip_Date", SqlDbType.DateTime).Value = lastshipdate;
            }
            if (uscisduedate == null)
            {
                cmd.Parameters.AddWithValue("@RFE_Uscis_DueDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_Uscis_DueDate", SqlDbType.DateTime).Value = uscisduedate;
            }
            
                cmd.Parameters.Add("@RFE_Evaluation_Filed", SqlDbType.NVarChar, 50).Value = RFEeval;
            
            if (String.IsNullOrEmpty(RFEmissingdocs))
            {
                cmd.Parameters.AddWithValue("@RFE_Missing_Docs", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_Missing_Docs", SqlDbType.NVarChar, 255).Value = RFEmissingdocs;
            }
            cmd.Parameters.Add("@RFE_Drafted", SqlDbType.NVarChar, 50).Value = RFEdrafted;
            if (String.IsNullOrEmpty(RFEstatus))
            {
                cmd.Parameters.AddWithValue("@RFE_Status", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_Status", SqlDbType.VarChar, 50).Value = RFEstatus;
            }
            if (RFElastupdated == null)
            {
                cmd.Parameters.AddWithValue("@RFE_LastUpdated", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@RFE_LastUpdated", SqlDbType.DateTime).Value = RFElastupdated;
            }
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = sNotes;
            if (Date_Initiated == null)
            {
                cmd.Parameters.AddWithValue("@Date_Initiated", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Date_Initiated", SqlDbType.DateTime).Value = Date_Initiated;
            }
            //cmd.Parameters.Add("@Type_Of_RFE", SqlDbType.NVarChar, 100).Value = Type_Of_RFE;
            cmd.Parameters.Add("@Current_Status", SqlDbType.NVarChar, 100).Value = cstatus;
            if (String.IsNullOrEmpty(fedextrack))
            {
                cmd.Parameters.AddWithValue("@FedexTracking", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@FedexTracking", SqlDbType.NVarChar, 100).Value = fedextrack;
            }
            cmd.Parameters.Add("@Fedex_ShippedBy", SqlDbType.Int).Value = fedexshippedby;
                if (fedexshippeddt== null)
            {
                cmd.Parameters.AddWithValue("@Fedex_DateShipped", DBNull.Value);
            }
            else
            {
            cmd.Parameters.Add("@Fedex_DateShipped", SqlDbType.DateTime).Value = fedexshippeddt;
                }
            cmd.Parameters.Add("@PetetionStatus", SqlDbType.NVarChar, 100).Value = petetionstatus;
            cmd.Parameters.Add("@Team", SqlDbType.NVarChar, 100).Value = team;
            if (String.IsNullOrEmpty(Contract))
            {
                cmd.Parameters.AddWithValue("@Contractualseesion", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Contractualseesion", SqlDbType.NVarChar, 255).Value = Contract;
            }
            if (String.IsNullOrEmpty(h1pending))
            {
                cmd.Parameters.AddWithValue("@Pending_documents", DBNull.Value);
            }
            else
            {

                cmd.Parameters.Add("@Pending_documents", SqlDbType.NVarChar, 255).Value = h1pending;
            }
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = queryString;
            //cmd.Connection = con;
            int rowsAffected = 0;
            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // error here
            }
            finally
            {
                con.Close();
            }
            return rowsAffected;

            //    string queryString = "INSERT INTO [NIVtracking] ([NIVTrackingNumber],[Company],[RLTrackingNumber],[LCATrackNumber],[LCAfiled] ,[DueDate] ,[DraftStatus],[SigPages],[Check],[Premium_Processing],[Case_Type],[Status_Expires],[location],[H4TrackNumber],[H4_SigPages],[Invoice],[Last_Updated],[Paid],[User_Id],[RFE_Type] ,[RFEDateReceive],[Date_R4D_Sent],[RFE_Internal_Due_Date],[RFE_LastShip_Date],[RFE_Uscis_DueDate],[RFE_Evaluation_Filed],[RFE_Missing_Docs],[RFE_Drafted],[RFE_Status],[RFE_LastUpdated],[Notes]) Values (@NIVtrackNumber,@Company,@RLCtracking,@LCtracking,@LCAfiled,@DueDate,@Draftstatus,@sigpages,@checks,@premiumprocessing,@casetype,@statusexpires,@location,@H4trackno,@H4sigpages,@invoice,@lastupdated, @paid,@userid,@RFEtype,@RFEdatereceive,@R4Dsent,@RFEinternalduedt,@lastshipdate,@uscisduedate,@RFEeval,@RFEmissingdocs,@RFEdrafted,@RFEstatus,@RFElastupdated,@sNotes)";
        }
        public string getCandID()
        {
            ACLGDB DB = new ACLGDB();

            string connectionString = DB.ConnectionString;
            System.Data.IDbConnection dbConnection = new System.Data.SqlClient.SqlConnection(connectionString);

            string queryString = "SELECT Employee_id,Tracking_No,  [First_Name] +' '+ [Last_Name] as Name FROM Employee where Tracking_No = '" + this.RlTrack.SelectedItem.Text + "'";
            System.Data.IDbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
            dbCommand.CommandText = queryString;
            dbCommand.Connection = dbConnection;

            dbConnection.Open();
            System.Data.IDataReader dataReader = dbCommand.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            string name = "";
            while (dataReader.Read())
            {
                Session["candID"] = dataReader["Employee_id"];
                name = (string)dataReader["Name"];
            }
            return name;

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
        //public attorney_addH1_B()
        //{
        //    Load += Page_Load;
        //}

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

        protected string getLCAtrck()
        {
            ACLGDB DB = new ACLGDB();

            string connectionString = DB.ConnectionString;
            string queryString = "SELECT LCATrackNumber,Datefiled FROM LCtracking where RLTrackingNumber = '" + RlTrack.SelectedItem.Text + "'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = queryString;
            string lcacasefile;
            cmd.Connection = con;
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();
            lsttrackno.Text = "";
            lstlcafiles.Text = "";
            while (read.Read())
            {


                lsttrackno.Text = (read["LCATrackNumber"].ToString());

                lstlcafiles.Text =  (read["Datefiled"]).ToString();

            }
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            con.Close();
            con.Dispose();
            //}
            DateTime dt;
            string duedt;
            if (lstlcafiles.Text == "")
            {
                txtduedate.Text = "";
            }
            else
            {
                dt = Convert.ToDateTime(lstlcafiles.Text);

                dt = dt.AddDays(8);
                //duedt =
                txtduedate.Text = Convert.ToString( dt);
            }
            return lsttrackno.Text;
        }

        protected void ddcasestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddcasestatus.SelectedValue == "RFE" || ddcasestatus.SelectedValue == "Denial" || ddcasestatus.SelectedValue == "NOID" || ddcasestatus.SelectedValue == "NOIR")
            {
                RFEhidden.Visible = true;
    
                //RFEtype();
                //RFEvalues();

            }
            else
                RFEhidden.Visible = false;
        }
        public void RFEtype()
        {

            //lstRFEStatus.Items.Add(new ListItem("--Select RFEType--", ""));
            // lstRFEStatus.AppendDataBoundItems = true;
            // ACLGDB DB = new ACLGDB();
            // string connectionString = DB.ConnectionString;
            // String strQuery = "select Visa_Type_Id,Visa_Type_Name from Visa_Type where Visa_Type.Category_Id=1";
            // SqlConnection con = new SqlConnection(connectionString);
            // SqlCommand cmd = new SqlCommand();
            // cmd.CommandType = CommandType.Text;
            // cmd.CommandText = strQuery;
            // cmd.Connection = con;
            // try
            // {
            //     con.Open();
            //     lstRFEStatus.DataSource = cmd.ExecuteReader();
            //     lstRFEStatus.DataTextField = "Visa_Type_Name";
            //     lstRFEStatus.DataValueField = "Visa_Type_Id";
            //     lstRFEStatus.DataBind();
            // }
            // catch (Exception ex)
            // {
            //     throw ex;
            // }
            // finally
            // {

            //     con.Close();
            //     con.Dispose();

            // }


        }
        public void RFEvalues()
        {
            DateTime NullDate = DateTime.MinValue;
            rfetypenw = txtrfetype.Text;
            string s = txtdatereceived.Text;
            string s1 = txtr4dsent.Text;

            if (s == "")
            {
                rfedtreceived = null;
            }
            else
            {
                rfedtreceived = Convert.ToDateTime(s);

            }
            if (s1 == "")
            {
                r4ddtsent = null;
            }
            else
            {
                r4ddtsent = Convert.ToDateTime(txtr4dsent.Text);
            }


            //rfetype = txttypeofRFE.Text;
            rfeeval = ddevalfiled.SelectedValue;
            rfemissingdoc = txtdocs.Text;
            rfedrafted = Convert.ToString(dddrafted.SelectedValue);
            rfestatus = txtrfestatus.Text;
        }



        public void assignedto()
        {
            lstUsers.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            lstUsers.Items.Clear();
            //ddCasetype.SelectedValue = "0";
            //ddCasetype.SelectedItem.Text = "--Select CaseType--";
            //ListItem li = new ListItem("--Select Category--", "");
            //ddCasetype.Items.Insert(0, li);
            string connectionString = DB.ConnectionString;
            String strQuery = "select User_ID,User_Display_Name from Users";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                lstUsers.DataSource = cmd.ExecuteReader();

                lstUsers.DataTextField = "User_Display_Name";
                lstUsers.DataValueField = "User_ID";

                lstUsers.DataBind();
                //ListItem li = new ListItem("Select User", "0");
                //lstUsers.Items.Insert(0, li);

            }
            catch (Exception ex)
            {
                lstUsers.SelectedValue = "";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            item = RlTrack.SelectedItem.Text;
            string STnotes = null;
            RFEtype();
            RFEvalues();
            rfedates();
            getLCAtrck();
            getCandID();
            string paid = "";
            DateTime NullDate = DateTime.MinValue;
            Nullable<DateTime> dateinitated;
            Nullable<DateTime> datedue;
            Nullable<DateTime> statusexp;
            Nullable<DateTime> lstupdt;
            Nullable<DateTime> fedexshiipeddt;

            string lctrackno = "";
            //Nullable<DateTime> rfedt;
            Nullable<DateTime> lcacasefiled;

            if (lsttrackno.Text == "")
            {
                lctrackno = "";
            }
            else
            {
                lctrackno = lsttrackno.Text;
            }
            if (lstlcafiles.Text == "")
            {
                lcacasefiled = null;
            }
            else
            {
                lcacasefiled = Convert.ToDateTime(lstlcafiles.Text);
            }
            if (txtdatereceived.Text == "")
            {
                rfedtreceived = null;
            }
            else
            {
                rfedtreceived = Convert.ToDateTime(txtdatereceived.Text);
            }
            //if (txtdateinitiated.Text == "")
            //{
            //    dateinitated = null;

            //}
            //else
            //{
            //    dateinitated = Convert.ToDateTime(txtdateinitiated.Text);
            ////}
            //dateinitated = DateTime.Now.ToString();
            if (txtrfelstupdated.Text == "")
            {
                rfelastupdated = null;

            }
            else
            {
                rfelastupdated = Convert.ToDateTime(txtrfelstupdated.Text);
            }
            if (lcacasefiled == null)
            {
                datedue = null;

            }
            else
            {
                datedue = Convert.ToDateTime(txtduedate.Text);
            }
            if (txtfeddtshipped.Text == "")
            {
                fedexshiipeddt = null;

            }
            else
            {
                fedexshiipeddt = Convert.ToDateTime(txtfeddtshipped.Text);
            }

            if (txtstatusexpires.Text == "")
            {
                statusexp = null;

            }
            else
            {
                statusexp = Convert.ToDateTime(txtstatusexpires.Text);
            }
            //STnotes = "H1-B#: " + txtNIVtrack.Text;
            STnotes += " | Date Initiated: " + txtdateinitiated.Text;
            STnotes += " | LCA Tracking No: " + lsttrackno.Text;
            STnotes += " | LCA File:: " + lstlcafiles.Text;
            STnotes += " | Due Date:" + datedue;
            STnotes += " | Draft Status: " + ddcasestatus.SelectedItem;
            STnotes += " | Sig Pages: " + ddsigpages.SelectedItem;
            STnotes += " |Premium Processing: " + ddpremiumprocessing.SelectedItem;
            STnotes += " | Checks: " + ddchecks.SelectedItem;
            STnotes += " | Case Type:" + ddcasetype.SelectedValue;
            if (ddcasestatus.SelectedItem.Text == "RFE")
            {

                STnotes += " | RFE Type:" + rfetypenw;
                STnotes += " | RFE Date Received:" + rfedtreceived;
                STnotes += " | Date R4D sent:" + r4ddtsent;
                STnotes += " |RFE USCIS DueDate:" + rfeuscisdt;
                STnotes += " |RFE Internal DueDate:" + rfeinternaldt;
                STnotes += " |RFE Last Ship Date:" + rfelatestshipdt;
                STnotes += " |RFE Type of RFE:" + rfetype;
                STnotes += " |RFE Eval Filed:" + rfeeval;
                STnotes += " |RFE Missing Docs:" + rfemissingdoc;
                STnotes += " |RFE Drafted:" + rfedrafted;
                STnotes += " |RFE Status:" + rfestatus;
                STnotes += " |RFE last Update:" + rfelastupdated;
            }
            else
            {
                STnotes += " |";
                rfetypenw = "";
                rfedtreceived = null;
                r4ddtsent = null;
                rfeuscisdt = null;
                rfeinternaldt = null;
                rfelatestshipdt = null;
                rfetype = "";
                rfeeval = "";
                rfemissingdoc = "";
                rfedrafted = "";
                rfestatus = "";
                rfelastupdated = null;



            }
            if (txtlstupdated.Text == "")
            {
                lstupdt = null;

            }
            else
            {
                lstupdt = Convert.ToDateTime(txtlstupdated.Text);
            }
            paid = rlstpaid.SelectedValue;
            STnotes += " | Status Expires:" + txtstatusexpires.Text;
            STnotes += " | H-4 Tracking No: " + txth4trkno.Text;
            STnotes += " | H-4 sigpages sent: " + Txth4sigpagessent.Text;
            //STnotes += " | Last Action on Case: " + txtlastcaseactn.Text;
            STnotes += " | Location of Case:" + ddlstates.SelectedItem;
            int userid;
            userid = Convert.ToInt16(lstUsers.SelectedValue);
            STnotes += " |  Assigned To:" + userid;
            STnotes += " | Invoice:" + txtinvoice.Text;
            STnotes += " |Last Updated: " + txtlstupdated.Text;
            STnotes += " | Paid: " + paid;

            if (txtnotes.Text != null && txtnotes.Text != "")
            {
                STnotes += " | Notes: " + txtnotes.Text;
            }
            InsertNIVTrackingNumber(int.Parse(lstcompany.SelectedItem.Value), this.RlTrack.SelectedItem.Text, lctrackno, lcacasefiled,
                                    datedue, ddcasestatus.SelectedItem.Text, ddsigpages.SelectedItem.Text, ddchecks.SelectedItem.Text, ddpremiumprocessing.SelectedItem.Text, ddcasetype.SelectedValue,
                                   statusexp,Convert.ToInt32(ddlstates.SelectedItem.Value), txth4trkno.Text, Txth4sigpagessent.Text, txtinvoice.Text, lstupdt,
                                    paid, userid, rfetypenw, rfedtreceived, r4ddtsent, rfeinternaldt, rfelatestshipdt, rfeuscisdt,
                                    rfeeval, rfemissingdoc, rfedrafted, rfestatus, rfelastupdated,txtnotes.Text, Convert.ToDateTime(txtdateinitiated.Text), ddcstatus.SelectedItem.Text, txtfedextrck.Text, Convert.ToInt32(ddfedexshipped.SelectedItem.Value), fedexshiipeddt, ddpetetionstatus.SelectedItem.Text, ddteams.SelectedItem.Text, txtcontract.Text, txth1pending.Text);
            InsertNotes((int)Session["candID"], STnotes, DateTime.Now, (int)Session["Attorney_User_Id"]);
            this.Label1.Text = "Successfully Added";
            int intCompanyId = 0;
            if (!lstcompany.SelectedValue.Equals("-- Select Company Name"))
            {
                intCompanyId = Convert.ToInt16(lstcompany.SelectedValue);
                setCompanyId(intCompanyId);
                Company oC = new Company(intCompanyId);
                Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
            }
            Response.Redirect("H1-B.aspx?cid="+int.Parse(lstcompany.SelectedItem.Value));
        }

        protected void RlTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = RlTrack.SelectedItem.Text;
            getLCAtrck();
        }

        protected void txtuscisdate__Leave(object sender, EventArgs e)
        {
            rfedates();
        }
        public void rfedates()
        {
            Nullable<DateTime> rfelatestshipdt1;
            string lastshipdt;
            string internaldt;
            if (txtuscisdate.Text == "")
            {
                rfeuscisdt = null;
                rfelatestshipdt = null;
                rfeinternaldt = null;
            }
            else
            {
                rfeuscist1 = Convert.ToDateTime(txtuscisdate.Text);
                rfeuscisdt = Convert.ToDateTime(txtuscisdate.Text);
                if ((int)rfeuscist1.DayOfWeek == 1)
                {
                    rfelatestshipdt1 = rfeuscist1.AddDays(-3);


                }
                rfelatestshipdt = rfeuscist1.AddDays(-1);
                //lastshipdt =
                txtlastshipdt.Text = Convert.ToString( rfelatestshipdt);
                rfeinternaldt = rfeuscist1.AddDays(-20);
                //internaldt =
                txtinternalduedt.Text = Convert.ToString(rfeinternaldt);
            }
        }
        public void getcasetypevalues()
        {
            //ddcasetype.Items.Add(new ListItem("--Select CaseType--", ""));
            ddcasetype.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            String strQuery = "select Visa_Type_Id,Visa_Type_Name from Visa_Type where Visa_Type.Category_Id=1";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddcasetype.DataSource = cmd.ExecuteReader();
                ddcasetype.DataTextField = "Visa_Type_Name";
                ddcasetype.DataValueField = "Visa_Type_Id";
                ddcasetype.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
                con.Dispose();

            }

        }
        protected void ddcasetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            getcasetypevalues();
        }
        public void fedexassigned()
        {
            ddfedexshipped.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            ddfedexshipped.Items.Clear();
            //ddfedexshipped.SelectedValue = "0";
            //ddfedexshipped.SelectedItem.Text = "--Select User--";
            //ListItem li = new ListItem("--Select User--", "");
            //ddfedexshipped.Items.Insert(0, li);
            string connectionString = DB.ConnectionString;
            String strQuery = "select User_ID,User_Display_Name from Users";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddfedexshipped.DataSource = cmd.ExecuteReader();

                ddfedexshipped.DataTextField = "User_Display_Name";
                ddfedexshipped.DataValueField = "User_ID";

                ddfedexshipped.DataBind();
                //ListItem li = new ListItem("Select User", "0");
                //ddfedexshipped.Items.Insert(0, li);

            }
            catch (Exception ex)
            {
                ddfedexshipped.SelectedValue = "";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public void GetStatesList()
        {


            ddlstates.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            ddlstates.Items.Clear();
            //ddCasetype.SelectedValue = "0";
            //ddCasetype.SelectedItem.Text = "--Select CaseType--";
            // ListItem li = new ListItem("--Select Category--", "");
            //ddCasetype.Items.Insert(0, li);
            string connectionString = DB.ConnectionString;
            String strQuery = "select User_ID,User_Display_Name from Users";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlstates.DataSource = cmd.ExecuteReader();

                ddlstates.DataTextField = "User_Display_Name";
                ddlstates.DataValueField = "User_ID";

                ddlstates.DataBind();
                //ListItem li = new ListItem("Select User", "0");
                //ddlstates.Items.Insert(0, li);

            }
            catch (Exception ex)
            {
                ddlstates.SelectedValue = "";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

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
            ddteams.SelectedValue = "";
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
            if(fedexshippedtxt.Text=="")
            {
                sfedex = null;
            }
            else
            {
                sfedex = Convert.ToDateTime(fedexshippedtxt.Text);
            }
            if(uscisdttxt.Text=="")
            {
                suscis = null;
            }
            else
            {
                suscis = Convert.ToDateTime(uscisdttxt.Text);
            }
            if(statusexptxt.Text=="")
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
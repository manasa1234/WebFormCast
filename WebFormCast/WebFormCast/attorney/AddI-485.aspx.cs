using ACLGDataAaccess;
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
    public partial class AddI_485 : System.Web.UI.Page
    {
        string scomp;
        string strack;
        string sdraftstatus;
        string scasestatus;
        int intAttorney_id = 0;
        int intCompany_id = 0;
        Nullable<DateTime> internalduedt;
        Nullable<DateTime> Dtinitiated;
        Nullable<DateTime> prioritydt;
        Nullable<DateTime> dtcasefiled;
        Nullable<DateTime> lastupdated;
        Nullable<DateTime> rfedtreceived;
        Nullable<DateTime> r4ddtsent;
        Nullable<DateTime> rfeuscisdt;
        Nullable<DateTime> rfelatestshipdt;
        Nullable<DateTime> rfeinternaldt;
        Nullable<DateTime> rfelastupdated;
        string rfetypenw = "";
        string rfetype = "";
        string rfeeval = "";
        string rfemissingdoc = "";
        string rfedrafted = "";
        string rfestatus = "";
        string item = "";
        
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

      

        public int InsertI485tracking(int Company, string RLCtracking,  DateTime? DateInitiated, DateTime? PriorityDate, string CountryofBirth,DateTime? InternalDueDate,string DraftSatatus, string Draftsent,
           string SigPagesReceived, string BioAppointment, string CaseStatus, DateTime? CaseFiled, string Invoice, DateTime? Last_Updated,
           string Paid, string RFEtype, DateTime? RFEdatereceive, DateTime? R4Dsent, DateTime? RFEinternalduedt, DateTime? lastshipdate, DateTime? uscisduedate,
            string RFEmissingdocs, string RFEdrafted, string RFEstatus, DateTime? RFElastupdated, string sNotes, string DependentTrackno)
        {
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            string queryString = "INSERT INTO [dbo].[I485tracking]([Company],[RLTrackingNumber],[DateInitiated],[PriorityDate],[CountryofBirth],[InternalDueDate],[DraftStatus],[Draftsent],[SigPagesReceived],[BioAppointment],[CaseStatus],[CaseFiled],[Invoice],[Last_Updated],[Paid],[RFE_Type],[RFEDateReceive],[Date_R4D_Sent],[RFE_Internal_Due_Date],[RFE_LastShip_Date],[RFE_Uscis_DueDate],[RFE_Missing_Docs],[RFE_Drafted],[RFE_Status],[RFE_LastUpdated],[Notes],[DependentTrackno])VALUES(@Company,@RLTrackingNumber,@DateInitiated,@PriorityDate,@CountryofBirth,@InternalDueDate,@DraftStatus,@Draftsent,@SigPagesReceived,@BioAppointment,@CaseStatus,@CaseFiled,@Invoice,@Last_Updated,@Paid,@RFE_Type,@RFEDateReceive,@Date_R4D_Sent,@RFE_Internal_Due_Date,@RFE_LastShip_Date,@RFE_Uscis_DueDate,@RFE_Missing_Docs,@RFE_Drafted,@RFE_Status,@RFE_LastUpdated,@Notes,@DependentTrackno)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(queryString, con);
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = queryString;
            cmd.Connection = con;
            cmd.Parameters.Add("@Company", SqlDbType.Int).Value = Company;
            cmd.Parameters.Add("@RLTrackingNumber", SqlDbType.NVarChar, 255).Value = RLCtracking;


            if (DateInitiated == null)
            {
                cmd.Parameters.AddWithValue("@DateInitiated", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@DateInitiated", SqlDbType.DateTime).Value = DateInitiated;
            }
            if (PriorityDate == null)
            {
                cmd.Parameters.AddWithValue("@PriorityDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@PriorityDate", SqlDbType.DateTime).Value = PriorityDate;
            }
            if (String.IsNullOrEmpty(CountryofBirth))
            {
                cmd.Parameters.AddWithValue("@CountryofBirth", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@CountryofBirth", SqlDbType.NVarChar, 255).Value = CountryofBirth;
            }
            if (InternalDueDate == null)
            {
                cmd.Parameters.AddWithValue("@InternalDueDate", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@InternalDueDate", SqlDbType.DateTime).Value = InternalDueDate;
            }
            if (String.IsNullOrEmpty(Draftsent))
            {
                cmd.Parameters.AddWithValue("@Draftsent", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@Draftsent", SqlDbType.NVarChar, 255).Value = Draftsent;
            }
            if (String.IsNullOrEmpty(DraftSatatus))
            {
                cmd.Parameters.AddWithValue("@DraftStatus", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@DraftStatus", SqlDbType.NVarChar, 255).Value = DraftSatatus;
            }
            if (String.IsNullOrEmpty(SigPagesReceived))
            {
                cmd.Parameters.AddWithValue("@SigPagesReceived", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@SigPagesReceived", SqlDbType.VarChar, 50).Value = SigPagesReceived;
            }

            if (String.IsNullOrEmpty(BioAppointment))
            {
                cmd.Parameters.AddWithValue("@BioAppointment", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@BioAppointment", SqlDbType.VarChar, 50).Value = BioAppointment;
            }
            if (String.IsNullOrEmpty(DependentTrackno))
            {
                cmd.Parameters.AddWithValue("@DependentTrackno", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@DependentTrackno", SqlDbType.NVarChar,255).Value = DependentTrackno;
            }
            if (String.IsNullOrEmpty(CaseStatus))
            {
                cmd.Parameters.AddWithValue("@CaseStatus", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@CaseStatus", SqlDbType.NVarChar, 255).Value = CaseStatus;
            }
            if (CaseFiled == null)
            {
                cmd.Parameters.AddWithValue("@CaseFiled", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@CaseFiled", SqlDbType.DateTime).Value = CaseFiled;
            }
            if (String.IsNullOrEmpty(Invoice))
            {
                cmd.Parameters.AddWithValue("@Invoice", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@Invoice", SqlDbType.NVarChar, 255).Value = Invoice;
            }
            if (Last_Updated == null)
            {
                cmd.Parameters.AddWithValue("@Last_Updated", DBNull.Value);
            }
            else
            {
                cmd.Parameters.Add("@Last_Updated", SqlDbType.DateTime).Value = Last_Updated;
            }
            if (String.IsNullOrEmpty(Paid))
            {
                cmd.Parameters.AddWithValue("@Paid", DBNull.Value);

            }
            else
            {
                cmd.Parameters.Add("@Paid", SqlDbType.VarChar, 50).Value = Paid;
            }

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

       
     
        
       



        protected void Button1_Click1(object sender, EventArgs e)
        {
            item = RlTrack.SelectedItem.Text;
            string STnotes = null;
            getCandID();
          if(txtdateinitiated.Text=="")
          {
              Dtinitiated = null;
          }
          else
          {
              Dtinitiated = Convert.ToDateTime(txtdateinitiated.Text);
          }
            if(txtpripritydt.Text=="")
            {
                prioritydt = null;
                internalduedt = null;
            }
            else
            {
                prioritydt = Convert.ToDateTime(txtpripritydt.Text);
            }
           if(txtdtcasefiled.Text=="")
              {
                  dtcasefiled = null;
                }
           else
           {
               dtcasefiled = Convert.ToDateTime(txtdtcasefiled.Text);
           }
            if(txtlstupdated.Text=="")
            {
                lastupdated = null;
            }
            else
            {
                lastupdated = Convert.ToDateTime(txtlstupdated.Text);
            }
            if (txtdatereceived.Text=="")
            {
                rfedtreceived = null;
            }
            else
            {
                rfedtreceived = Convert.ToDateTime(txtdatereceived.Text);
            }
            if (txtr4dsent.Text=="")
            {
                r4ddtsent = null;
            }
            else
            {
                r4ddtsent = Convert.ToDateTime(txtr4dsent.Text);
            }
            if(txtinternalduedt.Text=="")
            {
                rfeinternaldt = null;
            }
            if(txtuscisdate.Text=="")
            {
                rfeuscisdt = null;
            }
            else
            {
                rfeuscisdt=Convert.ToDateTime(txtuscisdate.Text);
            }
            if(txtlastshipdt.Text=="")
            {
                rfelatestshipdt = null;
            }
            else
            {
                rfelatestshipdt = Convert.ToDateTime(txtlastshipdt.Text);
            }
            if(txtrfelstupdated.Text=="")
            {
                rfelastupdated = null;
                    
            }
            else
            {
                rfelastupdated= Convert.ToDateTime(txtrfelstupdated.Text);
            }
            //STnotes = "H1-B#: " + txtNIVtrack.Text;
            STnotes += " | Date Initiated: " + txtdateinitiated.Text;
            STnotes += " |Priority Date:" + prioritydt;
            STnotes += " |Country of Birth:" + txtcountryofbirth.Text;
            STnotes += " |Internal Duedate:" + internalduedt;
            STnotes += " | Draft Status: " + dddraftstatus.SelectedItem;
            STnotes += " | Draft Sent To Client: " + txtdraftsentclient.Text;
            STnotes += " | Sig Pages: " + ddsigpages.SelectedItem;
            STnotes += " |Biomatrics Appointment: " + ddbioappnt.SelectedItem;
            STnotes += " | Casee Status:" + ddcasestatus.SelectedValue;
            if (ddcasestatus.SelectedItem.Text == "RFE")
            {

                STnotes += " | RFE Type:" + ddrfetype.SelectedItem;
                STnotes += " | RFE Date Received:" + rfedtreceived;
                STnotes += " | Date R4D sent:" + r4ddtsent;
                STnotes += " |RFE USCIS DueDate:" + rfeuscisdt;
                STnotes += " |RFE Internal DueDate:" + rfeinternaldt;
                STnotes += " |RFE Last Ship Date:" + rfelatestshipdt;
                STnotes += " |RFE Missing Docs:" + txtdocs.Text;
                STnotes += " |RFE Drafted:" + dddrafted.SelectedItem;
                STnotes += " |RFE Status:" + ddrfestatus.SelectedItem;
                STnotes += " |RFE last Update:" + rfelastupdated;
            }
            else
            {
                STnotes += " |";
               
                rfedtreceived = null;
                r4ddtsent = null;
                rfeuscisdt = null;
                rfeinternaldt = null;
                rfelatestshipdt = null;
              
               


            }
          
            
            STnotes += " | Date CaseFiled:" + dtcasefiled;
            STnotes += " | Invoice: " + txtinvoice.Text;
            STnotes += " | Last Updated: " + lastupdated;
            //STnotes += " | Last Action on Case: " + txtlastcaseactn.Text;
            STnotes += " | Paid:" + rlstpaid.SelectedValue;

            if (txtnotes.Text != null && txtnotes.Text != "")
            {
                STnotes += " | Notes: " + txtnotes.Text;
            }
            else { }
            
            InsertI485tracking(int.Parse(lstcompany.SelectedItem.Value), this.RlTrack.SelectedItem.Text, Dtinitiated, prioritydt, txtcountryofbirth.Text, internalduedt, dddraftstatus.SelectedItem.Text, txtdraftsentclient.Text,
                                        ddsigpages.SelectedItem.Text, ddbioappnt.SelectedItem.Text, ddcasestatus.SelectedItem.Text, dtcasefiled, txtinvoice.Text, lastupdated, rlstpaid.SelectedValue, ddrfetype.SelectedItem.Text,
                                        rfedtreceived, r4ddtsent, rfeinternaldt, rfelatestshipdt, rfeuscisdt, txtdocs.Text, dddrafted.SelectedItem.Text, ddrfestatus.SelectedItem.Text, rfelastupdated, txtnotes.Text, txtdependenttrackno.Text);
            this.Label1.Text = "Successfully Added";
            int intCompanyId = 0;
            if (!lstcompany.SelectedValue.Equals("-- Select Company Name--"))
            {
                intCompanyId = Convert.ToInt16(lstcompany.SelectedValue);
                setCompanyId(intCompanyId);
                Company oC = new Company(intCompanyId);
                Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
            }
            Response.Redirect("I-485.aspx?cid=" + int.Parse(lstcompany.SelectedItem.Value));
        }

        protected void RlTrack_SelectedIndexChanged(object sender, EventArgs e)
        {
            item = RlTrack.SelectedItem.Text;
        
        }

        protected void txtuscisdate__Leave(object sender, EventArgs e)
        {
            DateTime uscisdt;
            if(txtuscisdate.Text=="")
            {
                txtrfeinternal.Text = "";
                rfeinternaldt = null;
            }
            else
            {
                uscisdt = Convert.ToDateTime(txtuscisdate.Text);
                rfeinternaldt = uscisdt.AddDays(-25);
                txtrfeinternal.Text = Convert.ToString(rfeinternaldt);
            }
        }
      
     

        //protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (!ddCompany.SelectedValue.Equals("All"))
        //    {
        //        TrackingNotxt.Text = "";
        //    }
        //}

        //protected void ddStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (!ddStatus.SelectedValue.Equals("All"))
        //    {
        //        TrackingNotxt.Text = "";
        //    }
        //}



        protected void I485Search_Click(object sender, EventArgs e)
        {
            scomp = ddCompany.SelectedValue;
            strack = txtTrackingNo.Text;
            sdraftstatus = lstdraftstatus.SelectedValue;
            scasestatus = lstcasestatus.SelectedValue;
            int check = 1;
            Session["check"] = Convert.ToString(check);
            Session["strackno"] = strack;
            Session["scasestatus"] = scasestatus;
            Session["sdraftstatus"] = sdraftstatus;
            Session["scompany"] = scomp;
            Session["CaseRequestPage"] = "I485";
            Response.Redirect("I-485.aspx");
        }

        protected void reset_Click1(object sender, EventArgs e)
        {
            ddCompany.SelectedValue = "All";
            lstcasestatus.SelectedValue = "";

            lstdraftstatus.SelectedValue = "";
            txtTrackingNo.Text = "";
            lstcasestatus.Enabled = true;
            txtTrackingNo.Enabled = true;
           
        }

        //    int check = 1;
        //    Session["check"] = Convert.ToString(check);
        //    Session["strackno"] = strack;
        //    Session["sstatus"] = sstatus;
        //    Session["sstatuspetetion"] = sstatuspet;
        //    Session["scompany"] = scomp;
        //    Session["sfedexdt"] = sfedex;
        //    Session["suscisdt"] = suscis;
        //    Session["sstausexpdt"] = sstatusexp;
        //    Session["sTeams"] = steam;
        //    Session["CaseRequestPage"] = "H1B";
        //    Response.Redirect("H1-B.aspx");
        //}

        protected void ddcasestatus_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddcasestatus.SelectedValue == "RFE")
            {
                RFEhidden.Visible = true;

            }
            else
                RFEhidden.Visible = false;
        }

        protected void ltxtpripritydt_Leave(object sender, EventArgs e)
        {
            DateTime prioritydt;
            if(txtpripritydt.Text=="")
            {
                internalduedt = null;
                txtinternalduedt.Text = "";
            }
            else
            {
                prioritydt = Convert.ToDateTime(txtpripritydt.Text);
                internalduedt = prioritydt.AddDays(9);
                txtinternalduedt.Text = Convert.ToString(internalduedt);
            }
        }

        protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
          if( ddCompany.SelectedValue == "All")
          {
          }
          else
          {
              scomp = ddCompany.SelectedValue;
          }
        }

        protected void lstdraftstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstdraftstatus.SelectedValue=="")
            { }
            else { sdraftstatus = lstdraftstatus.SelectedValue; }
        }

        protected void lstcasestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstcasestatus.SelectedValue=="")
            {
            }
            else
            {
                scasestatus = lstcasestatus.SelectedValue;
            }
        }

       






    }
}
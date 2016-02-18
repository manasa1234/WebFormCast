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

public partial class attorney_AddLCA : System.Web.UI.Page
{
    int intAttorney_id=0;
    int intCompany_id = 0;
    string scompany;
    string sstatus;
    string strack;
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

    protected void RlTrack_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        // Response.Write(Session("candID"))
        //lstname.Text = this.RlTrack.SelectedItem.Value;
        lstname.Text = getCandID();
    }

    protected void lstcompany_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        lstname.Text = "";
    }

    protected void Button1_Click(object sender, System.EventArgs e)
    {
        Nullable<DateTime> dtfiled;
        Nullable<DateTime> empstrtdate;
        Nullable<DateTime> empenddt;
        Nullable<DateTime> dtapprd;
        string STnotes = null;
        STnotes = "LCA#: " + txtLCTrack.Text;
        STnotes += " | LCA Type: " + lstType.Text;
        STnotes += " | Date Filed: " + txtdatefiled.Text;
        STnotes += " | Employement Start Date: " + EmpStartdate.Text;
        STnotes += " | Employement End Date: " + EmpEnddate.Text;
        STnotes += " | Job Title: " + txttitle.Text;
        STnotes += " | LCA Location: " + txtloc.Text;
        STnotes += " | County: " + txtCounty.Text;
        STnotes += " | SOC: " + txtSOC.Text;
        STnotes += " | Salary: " + txtsal.Text;
        STnotes += " | Level: " + lstSalLevel.Text;
        STnotes += " | Date of Action: " + txtdateaprd.Text;
        STnotes += " | LCA Staus: " + lststatus.Text;
        if (txtnotes.Text != null && txtnotes.Text != "")
        {
            STnotes += " | Notes: " + txtnotes.Text;
        }
     
        if(txtdatefiled.Text=="")
        {
            dtfiled = null;
        }
        else
        {
            dtfiled = Convert.ToDateTime(txtdatefiled.Text);
        }
        if(EmpStartdate.Text=="")
        {
            empstrtdate = null;
        }
        else
        {
            empstrtdate = Convert.ToDateTime(EmpStartdate.Text);
        }
        if(EmpEnddate.Text=="")
        {
            empenddt = null;
        }
        else
        {
            empenddt=Convert.ToDateTime(EmpEnddate.Text);
        }
        if(txtdateaprd.Text=="")
        {
            dtapprd=null;
        }
        else{
            dtapprd=Convert.ToDateTime(txtdateaprd.Text);
        }
        InsertNewLCA(int.Parse(lstcompany.SelectedItem.Value), lstname.Text, this.RlTrack.SelectedItem.Text, txtLCTrack.Text, lstType.Text, dtfiled, empstrtdate, empenddt, txttitle.Text, txtloc.Text, txtCounty.Text,
        txtSOC.Text, txtsal.Text, lstSalLevel.SelectedItem.Value,dtapprd, lststatus.Text, txtnotes.Text);
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
        Response.Redirect("lca.aspx");
    }

    public int InsertNewLCA(int sCompany, string sBeneficiary, string sRLCtracking, string sLCtracking, string sTypeofLCA,DateTime? sDatefiled, DateTime? sEmpStartdate, DateTime? sEmpEndDate, string sJobtitle, string sLCAlocation, string sCounty,
    string sSOC, string sSalary, string sLevel, DateTime? sdateappd, string sStatus, string sNotes)
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        string queryString = "INSERT INTO [LCtracking] ([Company], [Beneficiary],[RLTrackingNumber],[LCATrackNumber], " + "[TypeofLCA], [Datefiled],[EmpStartdate],[EmpEndDate], [Jobtitle],[LCAlocation],[SOC],[salaryandlevel],[SalLevel],[Dateapproved],[CurrentStatus],[Notes]) VALUES (@Company, @Beneficiary,@RLTrackingNumber, @LCATrackNumber, @TypeofLCA, @Datefiled,@EmpStartdate,@EmpEndDate,@Jobtitle,@LCAlocation,@SOC,@salaryandlevel,@SalLevel,@dateappd,@CurrentStatus,@Notes)";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryString, con);
        //cmd.CommandType = CommandType.Text;
        //cmd.CommandText = queryString;
        cmd.Connection = con;
        cmd.Parameters.Add("@Company", SqlDbType.Int).Value = sCompany;
        if (String.IsNullOrEmpty(sBeneficiary))
        {
            cmd.Parameters.AddWithValue("@Beneficiary", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@Beneficiary", SqlDbType.NVarChar, 255).Value = sBeneficiary;
        }
        
        cmd.Parameters.Add("@RLTrackingNumber", SqlDbType.NVarChar, 255).Value = sRLCtracking;
        if (String.IsNullOrEmpty(sLCtracking))
        {
            cmd.Parameters.AddWithValue("@LCATrackNumber", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@LCATrackNumber", SqlDbType.NVarChar, 255).Value = sLCtracking;
        }
        if (String.IsNullOrEmpty(sTypeofLCA))
        {
            cmd.Parameters.AddWithValue("@TypeofLCA", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@TypeofLCA", SqlDbType.NVarChar, 255).Value = sTypeofLCA;
        }

       
        if (sDatefiled == null)
        {
            cmd.Parameters.AddWithValue("@Datefiled", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@Datefiled", SqlDbType.DateTime).Value = sDatefiled;
        }
        
        if (sEmpStartdate == null)
        {
            cmd.Parameters.AddWithValue("@EmpStartdate", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@EmpStartdate", SqlDbType.DateTime).Value = sEmpStartdate;
        }
        if (sEmpEndDate == null)
        {
            cmd.Parameters.AddWithValue("@EmpEndDate", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@EmpEndDate", SqlDbType.DateTime).Value = sEmpEndDate;
        }

       
        cmd.Parameters.Add("@Jobtitle", SqlDbType.NVarChar, 255).Value = sJobtitle;
        cmd.Parameters.Add("@LCAlocation", SqlDbType.NVarChar, 255).Value = sLCAlocation;
        cmd.Parameters.Add("@County", SqlDbType.NVarChar, 25).Value = sCounty;
        cmd.Parameters.Add("@salaryandlevel", SqlDbType.NVarChar, 255).Value = sSalary;
        cmd.Parameters.Add("@SalLevel", SqlDbType.NVarChar, 3).Value = sLevel;
        if (sdateappd == null)
        {
            cmd.Parameters.AddWithValue("@dateappd", DBNull.Value);
        }
        else
        {
            cmd.Parameters.Add("@dateappd", SqlDbType.DateTime).Value = sdateappd;
        }
        
        cmd.Parameters.Add("@CurrentStatus", SqlDbType.NVarChar, 255).Value = sStatus;
        cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = sNotes;
        cmd.Parameters.Add("@SOC", SqlDbType.NVarChar, 10).Value = sSOC;

        int rowsAffected = 0;
        con.Open();

        try
        {
            //Response.Write(queryString)
            //Response.End()
            rowsAffected = cmd.ExecuteNonQuery();
        }
        finally
        {
            con.Close();
        }
        if(rowsAffected >0)
        {
            Nullable<DateTime> duedt;
           if(sDatefiled==null)
           {
               duedt = null;
           }
           else
           {
            string s = Convert.ToString(sDatefiled);
           string  s1 = String.Format("{0:MM/dd/yyyy}", s);
            DateTime t = Convert.ToDateTime(s1);
            
            duedt = t.AddDays(8);

            }
            updateh1b(sLCtracking, sDatefiled,duedt,sCompany);
        }
        return rowsAffected;
    }

    private void updateh1b(string sLCtracking, DateTime? sDatefiled, DateTime? duedt,int company)
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        string queryString = "UPDATE [dbo].[NIVtracking] SET [LCATrackNumber] = @LCATrackNumber,[LCAfiled] = @LCAfiled,[DueDate] = @DueDate WHERE Company=" + company + " and RLTrackingNumber='" + this.RlTrack.SelectedItem.Text + "'";

        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(queryString, con);
        int rowsAffected = 0;
        cmd.Parameters.Add("@LCATrackNumber", SqlDbType.NVarChar, 255).Value = sLCtracking;
        cmd.Parameters.Add("@LCAfiled", SqlDbType.DateTime).Value = sDatefiled;
        cmd.Parameters.Add("@DueDate ", SqlDbType.DateTime).Value = duedt;
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
            name = (string) dataReader["Name"];
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
    public attorney_AddLCA()
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

    protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (!ddCompany.SelectedValue.Equals("All"))
        //{
        //    txtTrackingNo.Text = "";
        //}

        scompany = ddCompany.SelectedValue;
      
        //Response.Redirect("lca.aspx");
    }

    protected void ddStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddStatus.SelectedValue.Equals("All"))
        {
            txtTrackingNo.Text = "";
        }

        sstatus = ddStatus.SelectedValue;
    }

    
   

    protected void lcasearch_Click(object sender, EventArgs e)
    {
        strack = txtTrackingNo.Text;
        scompany = ddCompany.SelectedValue;
        sstatus = ddStatus.SelectedValue;
        int i = 1;
        Session["check"] = Convert.ToString(i);
        Session["trackno"] = strack;
        Session["status"] = sstatus;
        Session["company"] = scompany;
        Session["CaseRequestPage"] = "LCA";
        Response.Redirect("lca.aspx");

        //Response.Redirect("lca.aspx?cid=" + scompany + "&status=" + sstatus + "&trackno=" + strack);
    }

}

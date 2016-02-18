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

public partial class attorney_EditLCA : System.Web.UI.Page
{
    int intAttorney_id=0;
    string scompany;
    string sstatus;
    string strack;
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
                    if (FormView1.FindControl("notesTextbox") != null)
                    {
                        FormView1.FindControl("notesTextbox").Focus();
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

    protected void btnchange()
    {        
        FormView1.DataBind();
        string STnotes = null;
        getCandID();
        STnotes = "LCA Type: " + ((DataRowView)this.FormView1.DataItem)["TypeofLCA"].ToString() + " LCA Staus: " + ((DataRowView)this.FormView1.DataItem)["CurrentStatus"].ToString() + " | " + ((DataRowView)this.FormView1.DataItem)["Notes"].ToString();
        DateTime saveNow = DateTime.Now;
        InsertNotes((int)Session["candID"], STnotes, saveNow, (int)Session["Attorney_User_Id"]);
    }

    protected void OnDSUpdatedHandler(Object source, SqlDataSourceStatusEventArgs e)
    {
        if (e.AffectedRows > 0)
        {
            // Perform any additional processing, such as adding notes           
            FormView1.DataBind();
            string STnotes = null;
            getCandID();
            STnotes = "LCA#: " + ((DataRowView)this.FormView1.DataItem)["LCATrackNumber"].ToString() + " | LCA Staus: " + ((DataRowView)this.FormView1.DataItem)["CurrentStatus"].ToString();
            if (((DataRowView)this.FormView1.DataItem)["Notes"].ToString() != "")
            {
                STnotes += " | Notes: " + ((DataRowView)this.FormView1.DataItem)["Notes"].ToString();
            }
            DateTime saveNow = DateTime.Now;
            InsertNotes((int)Session["candID"], STnotes, saveNow, (int)Session["Attorney_User_Id"]);
        
            Nullable<DateTime> duedt;
            string sLCtracking=((DataRowView)this.FormView1.DataItem)["LCATrackNumber"].ToString();
            string Datefiled=((DataRowView)this.FormView1.DataItem)["Datefiled"].ToString();
            string company = ((DataRowView)this.FormView1.DataItem)["Company"].ToString();
            int sCompany = Convert.ToInt32(company);
            Nullable<DateTime> sDatefiled = Convert.ToDateTime(Datefiled);
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
    }


    private void updateh1b(string sLCtracking, DateTime? sDatefiled, DateTime? duedt, int company)
    {
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        string queryString = "UPDATE [dbo].[NIVtracking] SET [LCATrackNumber] = @LCATrackNumber,[LCAfiled] = @LCAfiled,[DueDate] = @DueDate WHERE Company=" + company + " and RLTrackingNumber='" + ((DataRowView)this.FormView1.DataItem)["RLTrackingNumber"] + "'";

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

    public attorney_EditLCA()
    {
        Load += Page_Load;
    }

    protected void lcaSearch_Click(object sender, EventArgs e)
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
    }

    protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        scompany = ddCompany.SelectedValue;
       
    }

    protected void ddStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddStatus.SelectedValue.Equals("All"))
        {
            txtTrackingNo.Text = "";
        }

        sstatus = ddStatus.SelectedValue;
    }

}

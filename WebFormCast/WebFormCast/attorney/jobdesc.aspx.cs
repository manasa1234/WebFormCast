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
using ACLGDataAaccess;
using System.Data.SqlClient;
using WebFormCast.ACLG;

public partial class attorney_jobdesc : System.Web.UI.Page
{
    int intAttorney_id = 0;
    string strSignature = "";
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

        
            if (Request.QueryString["new"] != null || Request.QueryString["edit"] != null)
            {
                panNew.Visible = true;
                gvEmployees.Visible = false;
                if (Request.QueryString["edit"] != null)
                {
                    strSignature = Request.QueryString["signature"];
                    if (!IsPostBack)
                    {
                        fillForm();
                    }
                }
            }
            else
            {
                panNew.Visible = false;
                gvEmployees.Visible = true;
            }

            if (!IsPostBack)
            {
                AcglGeneral objG = new AcglGeneral();
                lbNavigation.Text = objG.GetNavLinks("TEMPLATE");

                ShowGrid();
            }

    }
    protected void ShowGrid()
    {
        int intCompanyId = 0;

        ACLGDB DB = new ACLGDB();
        DataSet ds = new DataSet();
        ds = DB.getSPResults("Attorney_JobTitles", "@AttorneyId", intAttorney_id.ToString());
        gvEmployees.DataSource = ds;
        gvEmployees.DataBind();
    }
    protected void fillForm()
    {
        SqlDataReader dr;
        ACLGDB DB = new ACLGDB();
        string strSql = "";
        strSignature = strSignature.Replace("'","");
        strSignature = strSignature.Replace(";","");
        strSignature = strSignature.Replace("--","");

        strSql = "Select * from JobTitels where Attorneyid=" + intAttorney_id + " And Signature='" + strSignature + "'";
        dr = DB.getReader(strSql);

        if (dr.Read())
        {
            txtJobTitle.Text = dr["Job_Title"].ToString();
            txtOccupation_Code.Text = dr["Occupation_Code"].ToString();
            txtJobDesc.Text = dr["Job_Description"].ToString();
            txtNTJobDesc.Text = dr["NT_Job_Description"].ToString();
        }
        dr.Close();
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strTitle = "";
        string strOccupation_Code = "";
        string strNTDesc = "";
        string strDesc = "";
        string strSql = "";
        AcglGeneral OG = new AcglGeneral();
        strTitle = OG.ClrText(txtJobTitle.Text);
        strOccupation_Code = OG.ClrText(txtOccupation_Code.Text);
        strDesc = OG.ClrText(txtJobDesc.Text);
        strNTDesc = OG.ClrText(txtNTJobDesc.Text);

        if (Request.QueryString["new"] != null || Request.QueryString["edit"] != null)
        {
            ACLGDB DB = new ACLGDB();
            if (Request.QueryString["new"] != null)
            {
                strSql = "insert into JobTitels(AttorneyId,Job_Title,Occupation_Code,Job_Description,NT_Job_Description,Signature) values(" + intAttorney_id + ",'" + strTitle + "','" + strOccupation_Code + "','" + strDesc + "','" + strNTDesc + "','" + GetAccessKey() + "')";
                DB.ExeQuery(strSql);
                txtJobDesc.Text = "";
                txtJobTitle.Text = "";
                txtOccupation_Code.Text = "";
                txtNTJobDesc.Text = "";
                Response.Redirect("jobdesc.aspx");
            }
            if (Request.QueryString["edit"] != null)
            {
                strSql = "Update JobTitels set Job_Title='" + strTitle + "',Occupation_Code='" + strOccupation_Code + "',Job_Description='" + strDesc + "',NT_Job_Description='" + strNTDesc + "' Where attorneyid=" + intAttorney_id + " And Signature='" + strSignature + "'";
                DB.ExeQuery(strSql);
                txtJobDesc.Text = "";
                txtJobTitle.Text = "";
                txtOccupation_Code.Text = "";
                txtNTJobDesc.Text = "";
                Response.Redirect("jobdesc.aspx");
            }
            
        }
        

    }
    public string GetAccessKey()
    {
        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Replace("-", "");
        //guidResult = guidResult.Substring(1, 6);
        return guidResult.ToUpper();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("jobdesc.aspx");
    }
}

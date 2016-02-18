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
using WebFormCast.ACLG;
using System.Data.SqlClient;

public partial class employer_employeer : System.Web.UI.Page
{
    int intCompanyId = 1;
    public string strCompanyInfo = "";
    public string strCompanyName = "";
    public string strContactPerson = "";
    public string strDesignation = "";
     
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intCompanyId = Convert.ToInt16(Session["Company_Id"]);
        }
        catch { }

        if (intCompanyId <= 0)
        {
            Response.Redirect("index.aspx");
        }

        if(!IsPostBack)
       ShowGrid();
        try
        {
            lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Company_Person_Name"].ToString();
        }
        catch
        { }
    }

    protected void FillCompamyInfo()
    {
        Company oC = new Company();
    }


    protected void ShowGrid()
    {
        Company oC = new Company(intCompanyId);
        strCompanyName = oC.Legal_Name;
        strContactPerson = oC.Person_FullName;
        strDesignation = oC.Person_Designation;
        strCompanyInfo = oC.Person_FullName + "%0D%0A" + oC.Person_Designation + "%0D%0A" + oC.Legal_Name + "%0D%0A";

        if (oC.Phone_No != "")
        {
            strCompanyInfo += oC.Phone_No_Code + "-" + oC.Phone_No + " (Ph)%0D%0A";
        }
        if (oC.Fax_No != "")
        {
            strCompanyInfo += oC.Fax_No + " (Fax)";
        }
        DataSet ds = new DataSet();
        ds=oC.GetEmployerEmployeesList(intCompanyId);
        gvEmployees.DataSource = ds;
        gvEmployees.DataBind(); 
    }

    protected void ShowGrid(string strTracking)
    {
       Company oC = new Company();
        DataSet ds = new DataSet();
        ds = oC.GetEmployerEmployeesList(intCompanyId, strTracking);
        gvEmployees.DataSource = ds;
        gvEmployees.DataBind();
    }


    protected void gvEmployees_PageIndexChanged(object sender, EventArgs e)
    {
        
        ShowGrid();
    }
    protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployees.PageIndex = e.NewPageIndex;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string strTrackingNo = "";
        strTrackingNo = txtSearch.Text.Replace("'", "''").Trim();

        if (strTrackingNo != "")
        {
            ShowGrid(strTrackingNo);
        }
        else
            ShowGrid();

    }
    protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        try
        {
            index = Convert.ToInt32(e.CommandArgument);
            string item = gvEmployees.DataKeys[index].Value.ToString();
            Session["Employer_Employee_Id"] = item.ToString();
            if (e.CommandName.Equals("select"))
            {
                Response.Redirect("employeeview.aspx");
            }
        }
        catch { }
    }
}

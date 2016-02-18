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



public partial class attorneyclientmanager : System.Web.UI.Page
{
    int intAttorney_id = 0;
    public string strScript = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);

        }
        catch { }
        //intAttorney_id = 1;
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
        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("CLIENT");
        ShowGrid();
    }

    protected void ShowGrid()
    {
        int intCompanyId = 0;
        string strCompanyName = "";
        strCompanyName = txtCompanyName.Text.Replace("'", "''").Trim();

        clsAttorney OA = new clsAttorney();
        DataSet ds = new DataSet();

        if (strCompanyName != "")
        {
            ds = OA.GetEmployerListByName(intAttorney_id, strCompanyName);
        }
        else
        {
            ds = OA.GetEmployerList(intAttorney_id);
        }
        gvEmployees.DataSource = ds;
        gvEmployees.DataBind();

    }


    protected void gvEmployees_PageIndexChanged(object sender, EventArgs e)
    {

        ShowGrid();
        //ShowGrid_withSorting();
    }
    protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployees.PageIndex = e.NewPageIndex;
    }
    protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = 0;


        if (!e.CommandName.Equals("Sort"))
        {
            index = Convert.ToInt32(e.CommandArgument);
            string item = gvEmployees.DataKeys[index].Value.ToString();
            Session["Company_Id"] = item.ToString();

            if (e.CommandName.Equals("Edit"))
            {
                Response.Redirect("employer_account.aspx");
            }

            if (e.CommandName.Equals("Login"))
            {
                Company OC = new Company(Convert.ToInt16(item.ToString()));
                Session["Company_Id"] = OC.Company_id;
                Session["Company_Person_Name"] = OC.Person_FullName;
                Session["Company_Name"] = OC.Legal_Name;
                strScript = "<script language='javascript'>window.open('../employer/employer.aspx','client','');</script>";                
            }


            if (e.CommandName.Equals("Show"))
            {
                Response.Redirect("companyview.aspx");
            }
        }
        else
        {
            gvEmployees.PageIndex = 0; 
        }
    }

    protected void ShowGrid_withSorting()
    {
        clsAttorney OA = new clsAttorney();
        DataSet ds = new DataSet();
        ds = OA.GetEmployerList(intAttorney_id);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        DataView dataView = new DataView(dt);

        if (ViewState["sortexp"] != null)
        {
            dataView.Sort = ViewState["sortexp"] + " " + ConvertSortDirectionToPage();
            gvEmployees.DataSource = dataView;
            gvEmployees.DataBind();
        }
    }

    protected void gvEmployees_Sorting(object sender, GridViewSortEventArgs e)
    {
        clsAttorney OA = new clsAttorney();
        DataSet ds = new DataSet();
        ds = OA.GetEmployerList(intAttorney_id);
        DataTable dt = new DataTable();
        dt = ds.Tables[0];
        DataView dataView = new DataView(dt);

        if (ViewState["sortexp"] == null)
            GridViewSortDirection = SortDirection.Descending;
        else if (ViewState["sortexp"].ToString() != e.SortExpression.ToString())
            GridViewSortDirection = SortDirection.Descending;

        ViewState["sortexp"] = e.SortExpression.ToString();
        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql();
        gvEmployees.DataSource = dataView;
        gvEmployees.DataBind();
    }



    private string ConvertSortDirectionToSql()
    {
        string newSortDirection = String.Empty;

        switch (GridViewSortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "DESC";
                GridViewSortDirection = SortDirection.Descending;
                break;

            case SortDirection.Descending:
                GridViewSortDirection = SortDirection.Ascending;
                newSortDirection = "ASC";
                break;
        }
        return newSortDirection;
    }

    private string ConvertSortDirectionToPage()
    {
        string newSortDirection = String.Empty;

        switch (GridViewSortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;
            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }
        return newSortDirection;
    }

    public SortDirection GridViewSortDirection
    {

        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }
        set { ViewState["sortDirection"] = value; }

    }

}

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


public partial class cases : System.Web.UI.Page
{
    int intAttorney_id = 0;
    int intCompany_id = 0;
    int intEmployeeId = 0;
    string strEmployeeSignature = "";
    string strEmployeeTrackingNo = "";
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
            if (Session["txtTrackingNo"] != null)
            {
                txtTrackingNo.Text = Session["txtTrackingNo"].ToString();
            }
            Session["CaseRequestPage"] = "cases";
        }
        catch
        { }
        //Response.Write(IsPostBack.ToString());
        if (!IsPostBack)
        {

            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("CASE");

            if (Request.QueryString["select"] != null || Request.QueryString["edit"] != null)
            {
                intEmployeeId = Convert.ToInt16(Request["id"]);
                Session["Attorney_Employee_Id"] = intEmployeeId;
                Session["CaseRequestPage"] = "cases";
                try
                {
                    strEmployeeSignature = Request["signature"].ToString();
                }
                catch { }
                try
                {
                    strEmployeeTrackingNo = Request["Tracking"].ToString();
                }
                catch { }
                Session["Attorney_Employee_TrackingNo"] = strEmployeeTrackingNo;
                Session["Attorney_Employee_Signature"] = strEmployeeSignature;
                if (Request.QueryString["select"] != null)
                {
                    Response.Redirect("case.aspx?action=edit");
                }
                else
                {
                    Response.Redirect("case.aspx?action=editScroll");
                }
            }

            clsAttorney OA = new clsAttorney(intAttorney_id);
            OA.bindCompanyCombo(ddEmployer, 0);


            if (Request["txtTrackingNo"] != null)
            {
                string strTrckingno = "";
                strTrckingno = Request["txtTrackingNo"].ToString().Trim();
                txtTrackingNo.Text = strTrckingno;
                ShowGrid();
            }
            else if (Request["MySearch$txtTrackingNo"] != null)
            {
                string strTrckingno = "";
                strTrckingno = Request["MySearch$txtTrackingNo"].ToString().Trim();
                txtTrackingNo.Text = strTrckingno;
                ShowGrid();
            }
            else
            {
                try
                {
                    intCompany_id = getCompanyId();
                }
                catch { }
                if (intCompany_id > 0)
                {
                    ddEmployer.SelectedValue = intCompany_id.ToString();
                    Company oC = new Company(intCompany_id);
                    Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
                    lbCompanyName1.Text = oC.Legal_Name.ToString();
                    lbClientName.Text = oC.Legal_Name.ToString();
                    ShowGrid();
                }
            }



        }


    }

    protected void ShowGrid()
    {
        int intCompanyId = 0;
        if (ddEmployer.SelectedIndex > 0)
            intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);

        string strTrackingNo = "";
        strTrackingNo = txtTrackingNo.Text.Replace("'", "''").Trim();

        clsAttorney OA = new clsAttorney();
        DataSet ds = new DataSet();

        if (strTrackingNo != "")
        {
            ds = OA.GetCasesSearchList1(intAttorney_id, strTrackingNo);
        }
        else
        {
            ds = OA.GetEmployeesCaseTypeSearchList(intCompanyId);
        }
        gvEmployees.DataSource = ds;
        gvEmployees.DataBind();
    }
    protected void ShowGrid(string strTracking)
    {
        clsAttorney OA = new clsAttorney();
        Company oC = new Company();
        DataSet ds = new DataSet();
        ds = OA.GetCasesSearchList1(intAttorney_id, strTracking);
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

    protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {
        int intCompanyId = 0;
        intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
        setCompanyId(intCompanyId);
        Company oC = new Company(intCompanyId);

        lbCompanyName1.Text = oC.Legal_Name.ToString();
        lbClientName.Text = oC.Legal_Name.ToString();
        Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
        txtTrackingNo.Text = "";
        ShowGrid();
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
    protected void txtSearch_Click(object sender, EventArgs e)
    {

        if (txtTrackingNo.Text.Trim() != "")
        {
            ddEmployer.SelectedValue = "0";
            lbClientName.Text = "Search Results";
            lbCompanyName1.Text = "Search Results";
        }

        ShowGrid();
    }
    protected void gvEmployees_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName.Equals("select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string item = gvEmployees.DataKeys[index].Value.ToString();
            Session["Attorney_Employee_Id"] = item.ToString();
            Session["CaseRequestPage"] = "cases";
            Response.Redirect("case.aspx");
        }

        if (e.CommandName.Equals("edit"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string item = gvEmployees.DataKeys[index].Value.ToString();
            Session["Attorney_Employee_Id"] = item.ToString();
            Session["CaseRequestPage"] = "cases";
            Response.Redirect("case.aspx?action=editScroll");
        }

    }
}


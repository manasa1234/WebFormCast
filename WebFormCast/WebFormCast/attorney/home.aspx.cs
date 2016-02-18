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


public partial class attorneyhome : System.Web.UI.Page
{
    int intAttorney_id = 0;
    int intCompany_id = 0;
    int intEmployeeId=0;
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
        }
        catch
        { }


        if (!IsPostBack)
        {

            if (Request.QueryString["select"] != null)
            {
                intEmployeeId = Convert.ToInt16(Request["id"]);
                Session["Attorney_Employee_Id"] = intEmployeeId;
                try{
                    strEmployeeSignature = Request["signature"].ToString();
                }catch{}
                try{
                    strEmployeeTrackingNo = Request["Tracking"].ToString();
                }catch{}
                Session["Attorney_Employee_TrackingNo"] = strEmployeeTrackingNo;
                Session["Attorney_Employee_Signature"] = strEmployeeSignature;
                Response.Redirect("employeeview.aspx");
            }



            //clsAttorney OA = new clsAttorney(intAttorney_id);
            //OA.bindCompanyCombo(ddEmployer, 0);

            //try
            //{
            //    intCompany_id = getCompanyId();
            //}
            //catch { }
            //if (intCompany_id > 0)
            //{
            //    ddEmployer.SelectedValue = intCompany_id.ToString();
            //    Company oC = new Company(intCompany_id);
            //    Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
            //    lbCompanyName.Text = oC.Legal_Name.ToString() + " Case List";
            //    lbCompanyName1.Text = oC.Legal_Name.ToString(); 

                ShowGrid();
            //}
        }
        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("HOME");
        
    }

    protected void ShowGrid()
    {
        clsAttorney OA = new clsAttorney(intAttorney_id);
        DataSet ds = new DataSet();
        ds = OA.GetNewEmployeesList(intAttorney_id);
        gvEmployees.DataSource = ds;
        gvEmployees.DataBind();
    }
    //protected void ShowGrid(string strTracking)
    //{
    //    int intCompanyId = 0;
    //    if (ddEmployer.SelectedIndex > 0)
    //        intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
    //    Company oC = new Company();
    //    DataSet ds = new DataSet();
    //    ds = oC.GetAttorneyEmployeesList(intCompanyId, strTracking);
    //    gvEmployees.DataSource = ds;
    //    gvEmployees.DataBind();
    //}

    protected void gvEmployees_PageIndexChanged(object sender, EventArgs e)
    {
        ShowGrid();
    }
    protected void gvEmployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEmployees.PageIndex = e.NewPageIndex;
    }

    //protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    int intCompanyId = 0;
    //    intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
    //    setCompanyId(intCompanyId);
    //    Company oC = new Company(intCompanyId);
    //    lbCompanyName.Text = oC.Legal_Name.ToString() + " Case List";
    //    lbCompanyName1.Text = oC.Legal_Name.ToString() ; 
    //    Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
    //    ShowGrid();
    //}

    //protected int getCompanyId()
    //{
        
    //    int intCompany_id=0;
    //    try
    //    {
    //        intCompany_id = Convert.ToInt16(Session["ACompany_Id"]);
    //    }
    //    catch { }


    //    if (intCompany_id <= 0)
    //    {
       
    //        try
    //        {
    //            intCompany_id = Convert.ToInt16(Request.Cookies["Attorney"]["ACompany_Id"]);
    //        }
    //        catch{}
            
    //    }

    //    return intCompany_id;
    //}


    //protected void  setCompanyId(int intCompanyId)
    //{
    //    Session["ACompany_Id"] = intCompanyId; 
    //    HttpCookie myCookie = new HttpCookie("Attorney");
    //    myCookie["ACompany_Id"] = intCompanyId.ToString();
    //    myCookie.Expires = DateTime.Now.AddDays(30);
    //    Response.Cookies.Add(myCookie);
    //}
    //protected void txtSearch_Click(object sender, EventArgs e)
    //{
    //    string strTrackingNo = "";
    //    strTrackingNo = txtTrackingNo.Text.Replace("'", "''").Trim();

    //    if (strTrackingNo != "")
    //    {
    //        ShowGrid(strTrackingNo);
    //    }


    //}
}

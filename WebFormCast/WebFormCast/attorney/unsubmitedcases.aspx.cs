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
public partial class unsubmitedcases : System.Web.UI.Page
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
        }
        catch
        { }
        if (!IsPostBack)
        {

            if (Request.QueryString["select"] != null)
            {
                intEmployeeId = Convert.ToInt16(Request["id"]);
                Session["Attorney_Employee_Id"] = intEmployeeId;
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
                Response.Redirect("employeeview.aspx");
            }


            FillClients();
            ShowGrid();
        }
        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("HOME");

    }

    protected void FillClients()
    {
        clsAttorney OA = new clsAttorney();
        OA.BindUnSubmitedClientsList(ddUnApprovedClients, intAttorney_id); 
        
    }
    protected void ShowGrid()
    {
        int intCompanyid = 0;
        clsAttorney OA = new clsAttorney(intAttorney_id);
        DataSet ds = new DataSet();
        intCompanyid = Convert.ToInt16(ddUnApprovedClients.SelectedValue);
        ds = OA.GetUnSubmitedEmployeesList(intAttorney_id, intCompanyid);
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


    protected void ddUnApprovedClients_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowGrid();
    }
}

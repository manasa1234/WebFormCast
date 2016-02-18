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

public partial class attorney_searchbox : System.Web.UI.UserControl
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }

        try
        {
            intEmployeeId = Convert.ToInt16(Session["Attorney_Employee_Id"]);
            AcglEmployee oE = new AcglEmployee(intEmployeeId);
            clsAttorney OA = new clsAttorney(intAttorney_id);
            OA.bindCompanyCombo(ddEmployer, oE.Company_id);
            oE = null;
            OA = null;
            
        }
        catch { }
    }
    protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        int intCompanyId=0;
        intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
        setCompanyId(intCompanyId);
        Response.Redirect("cases.aspx");
    }
    protected void setCompanyId(int intCompanyId)
    {
        Session["ACompany_Id"] = intCompanyId;
        HttpCookie myCookie = new HttpCookie("Attorney");
        myCookie["ACompany_Id"] = intCompanyId.ToString();
        myCookie.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(myCookie);
    }

    protected void txtTrackingNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtSearch_Click(object sender, EventArgs e)
    {

    }
}

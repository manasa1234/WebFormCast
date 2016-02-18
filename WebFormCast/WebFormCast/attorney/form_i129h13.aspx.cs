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
public partial class form_i129h13 : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    string strEmployeeSignature = "";

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
            //strEmployeeSignature =Session["Attorney_Employee_Signature"].ToString();
        }
        catch { }
        try
        {
            strEmployeeSignature = Request["signature"].ToString();
        }
        catch { }
        try
        {

            lbtrackingno.Text = Session["Attorney_Employee_TrackingNo"].ToString(); ;
        }
        catch { }
        try
        {

            lbCompanyName.Text = Session["Attorney_CompanyName"].ToString();
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

            
            AcglGeneral objG = new AcglGeneral();
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strEmployeeSignature);
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 13);
            lbNavigation.Text = objG.GetNavLinks("CASE");
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }

    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);

        f13_Print_Name.Text = OF.f13_Print_Name;
        f13_Title.Text = OF.f13_Title;
 
    }

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f13_Print_Name = OG.ClrText(f13_Print_Name.Text);
        OF.f13_Title = OG.ClrText(f13_Title.Text);

        
        flag=OF.Form_13_Update(intEmployeeId);

        
        //Response.Redirect("form_i129h02.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

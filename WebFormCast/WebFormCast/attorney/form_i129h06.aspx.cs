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
public partial class form_i129h06 : System.Web.UI.Page
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
            lbNavigation.Text = objG.GetNavLinks("CASE");
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 6);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }

    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);
        f6_Daytime_Phone_Number1.Text = OF.f6_Daytime_Phone_Number1;
        f6_Daytime_Phone_Number1_Code.Text = OF.f6_Daytime_Phone_Number1_Code;
        f6_Daytime_Phone_Number2_Code.Text = OF.f6_Daytime_Phone_Number2_Code;
        f6_Print_Name1.Text = OF.f6_Print_Name1;
        f6_Date1.Text = OF.f6_Date1;
        f6_Daytime_Phone_Number2.Text = OF.f6_Daytime_Phone_Number2;
        f6_Print_Name2.Text = OF.f6_Print_Name2;

        string txt = OF.f6_Firm_Name_and_Address;
        string removedBreaks = txt;
        if (string.IsNullOrEmpty(txt) == false) {
            string replaceWith = ", ";
            removedBreaks = txt.Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
        }
        f6_Firm_Name_and_Address.Text = removedBreaks;

        f6_Date2.Text = OF.f6_Date2;
        f6_Print_Name3.Text = OF.f6_Print_Name1;


    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f6_Daytime_Phone_Number1 = OG.ClrText(f6_Daytime_Phone_Number1.Text);
        OF.f6_Daytime_Phone_Number1_Code = OG.ClrText(f6_Daytime_Phone_Number1_Code.Text);
        OF.f6_Daytime_Phone_Number2_Code = OG.ClrText(f6_Daytime_Phone_Number2_Code.Text);
        OF.f6_Print_Name1 = OG.ClrText(f6_Print_Name1.Text);
        OF.f6_Date1 = OG.ClrText(f6_Date1.Text);
        OF.f6_Daytime_Phone_Number2 = OG.ClrText(f6_Daytime_Phone_Number2.Text);
        OF.f6_Print_Name2 = OG.ClrText(f6_Print_Name2.Text);
        OF.f6_Firm_Name_and_Address = OG.ClrText(f6_Firm_Name_and_Address.Text);
        OF.f6_Date2 = OG.ClrText(f6_Date2.Text);


        flag = OF.Form_06_Update(intEmployeeId);

        if (flag)
        Response.Redirect("form_i129h07.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

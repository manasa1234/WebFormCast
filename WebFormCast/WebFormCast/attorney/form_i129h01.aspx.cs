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
public partial class form_i129h01 : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    string strEmployeeSignature = "";
    int visaid = 0;  protected void Page_Load(object sender, EventArgs e)
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

            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 1);
            //hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature;
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();

            

            Initialize();
        }
    }

    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);

        txtCity.Text = OF.f1_CompanyCity;
        txtCompanyName.Text = OF.f1_CompanyName;
        txtCompanyPhoneNo.Text = OF.f1_CompanyPhone;
        txtCompanyPhoneNo_Code.Text  = OF.f1_CompanyPhone_Code;
        txtCountry.Text = OF.f1_CompanyCountry;
        txtEmailAddress.Text  = OF.f1_CompanyEmail;
        txtFederalNo.Text = OF.f1_CompanyFederalIdentification;
        txtFirstName.Text = OF.f1_Person_First_Name;
        txtIndividualTax.Text = OF.f1_CompanyIndividualTax;
        txtLastName.Text = OF.f1_Person_Last_Name;
        txtCareOf.Text = OF.f6_Print_Name1;
        txtMailingAddress.Text = OF.f1_CompanyStreet;
        txtMiddleName.Text = OF.f1_Person_Middle_Name;
        txtSocialSecurity.Text = OF.f1_ComapnySocialSecurity;
        txtState.Text = OF.f1_CompanyState;
        txtSuiteNo.Text = OF.f1_CompanySuite;
        txtZip.Text = OF.f1_CompanyZip;
        
  
        
    }

    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f1_CompanyCity=OG.ClrText(txtCity.Text );
        OF.f1_CompanyName=OG.ClrText(txtCompanyName.Text );
        OF.f1_CompanyPhone_Code=OG.ClrText(txtCompanyPhoneNo_Code.Text) ;
        OF.f1_CompanyPhone = OG.ClrText(txtCompanyPhoneNo.Text);
        OF.f1_CompanyCountry = OG.ClrText(txtCountry.Text);
        OF.f1_CompanyEmail=OG.ClrText(txtEmailAddress.Text) ;
        OF.f1_CompanyFederalIdentification=OG.ClrText(txtFederalNo.Text );
        OF.f1_Person_First_Name=OG.ClrText(txtFirstName.Text );
        OF.f1_CompanyIndividualTax=OG.ClrText(txtIndividualTax.Text );
        OF.f1_Person_Last_Name=OG.ClrText(txtLastName.Text );
        OF.f1_CompanyStreet=OG.ClrText(txtMailingAddress.Text) ;
        OF.f1_Person_Middle_Name=OG.ClrText(txtMiddleName.Text) ;
        OF.f1_ComapnySocialSecurity=OG.ClrText(txtSocialSecurity.Text );
        OF.f1_CompanyState=OG.ClrText(txtState.Text );
        OF.f1_CompanySuite=OG.ClrText(txtSuiteNo.Text) ;
        OF.f1_CompanyZip = OG.ClrText(txtZip.Text);
        
        flag=OF.Form_01_Update(intEmployeeId);

        if(flag)
            Response.Redirect("form_i129h02.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

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
public partial class form_i129h07 : System.Web.UI.Page
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
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 7);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }

    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);
        f8_Name_of_organization_filing_petition.Text = OF.f8_Name_of_organization_filing_petition;
        f8_Name_of_person.Text = OF.f8_Name_of_person;
        f8_Classification_sought1.Checked  = OF.f8_Classification_sought==1;
        f8_Classification_sought2.Checked = OF.f8_Classification_sought == 2;
        f8_Classification_sought3.Checked = OF.f8_Classification_sought == 3;
        f8_Classification_sought4.Checked = OF.f8_Classification_sought == 4;
        f8_Classification_sought5.Checked = OF.f8_Classification_sought == 5;
        f8_Classification_sought6.Checked = OF.f8_Classification_sought == 6;
        f8_Classification_sought7.Checked = OF.f8_Classification_sought == 7;
        
        f8_Describe_the_proposed_duties.Text = OF.f8_Describe_the_proposed_duties;
        f8_Aliens_present_occupation.Text = OF.f8_Aliens_present_occupation;
        f8_Print_or_Type_Name1.Text = OF.f8_Print_or_Type_Name1;
        f8_Print_or_Type_Name2.Text = OF.f8_Print_or_Type_Name2;
        f8_DATE1.Text = OF.f8_DATE1;
        f8_DATE2.Text = OF.f8_DATE2;

        f8_SubjectsName1.Text  = OF.f8_SubjectsName1;
        f8_Period_From1.Text = OF.f8_Period_From1;
        f8_Period_To1.Text = OF.f8_Period_To1;

        f8_SubjectsName2.Text = OF.f8_SubjectsName2;
        f8_Period_From2.Text = OF.f8_Period_From2;
        f8_Period_To2.Text = OF.f8_Period_To2;

        f8_SubjectsName3.Text = OF.f8_SubjectsName3;
        f8_Period_From3.Text = OF.f8_Period_From3;
        f8_Period_To3.Text = OF.f8_Period_To3;

        f8_SubjectsName4.Text = OF.f8_SubjectsName4;
        f8_Period_From4.Text = OF.f8_Period_From4;
        f8_Period_To4.Text = OF.f8_Period_To4;
 
        

        
        

 
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f8_Name_of_organization_filing_petition = OG.ClrText(f8_Name_of_organization_filing_petition.Text);
        OF.f8_Name_of_person = OG.ClrText(f8_Name_of_person.Text);
        if (f8_Classification_sought1.Checked)
            OF.f8_Classification_sought = 1;
        if (f8_Classification_sought2.Checked)
            OF.f8_Classification_sought = 2;
        if (f8_Classification_sought3.Checked)
            OF.f8_Classification_sought = 3;
        if (f8_Classification_sought4.Checked)
            OF.f8_Classification_sought = 4;
        if (f8_Classification_sought5.Checked)
            OF.f8_Classification_sought = 5;
        if (f8_Classification_sought6.Checked)
            OF.f8_Classification_sought = 6;
        if (f8_Classification_sought7.Checked)
            OF.f8_Classification_sought = 7;
        

        OF.f8_Describe_the_proposed_duties = OG.ClrText(f8_Describe_the_proposed_duties.Text);
        OF.f8_Aliens_present_occupation = OG.ClrText(f8_Aliens_present_occupation.Text);
        OF.f8_Print_or_Type_Name1 = OG.ClrText(f8_Print_or_Type_Name1.Text);
        OF.f8_Print_or_Type_Name2 = OG.ClrText(f8_Print_or_Type_Name2.Text);
        OF.f8_DATE1 = OG.ClrText(f8_DATE1.Text);
        OF.f8_DATE2 = OG.ClrText(f8_DATE2.Text);


        OF.f8_SubjectsName1 = f8_SubjectsName1.Text;
        OF.f8_Period_From1 = f8_Period_From1.Text;
        OF.f8_Period_To1 = f8_Period_To1.Text;

        OF.f8_SubjectsName2 = f8_SubjectsName2.Text;
        OF.f8_Period_From2 = f8_Period_From2.Text;
        OF.f8_Period_To2 = f8_Period_To2.Text;

        OF.f8_SubjectsName3 = f8_SubjectsName3.Text;
        OF.f8_Period_From3 = f8_Period_From3.Text;
        OF.f8_Period_To3 = f8_Period_To3.Text;

        OF.f8_SubjectsName4 = f8_SubjectsName4.Text;
        OF.f8_Period_From4 = f8_Period_From4.Text;
        OF.f8_Period_To4 = f8_Period_To4.Text;


        flag = OF.Form_08_Update(intEmployeeId);

        if (flag)
        Response.Redirect("form_i129h08.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

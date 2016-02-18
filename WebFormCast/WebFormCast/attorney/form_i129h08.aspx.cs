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
public partial class form_i129h08 : System.Web.UI.Page
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
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 8);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }

    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);

        f11_Petitioners_Name.Text = OF.f11_Petitioners_Name;
        f11_Is_the_petitioner_a_dependent_employerYes.Checked  = OF.f11_Is_the_petitioner_a_dependent_employer;
        f11_Is_the_petitioner_a_dependent_employerNo.Checked = !OF.f11_Is_the_petitioner_a_dependent_employer;

        f11_found_to_be_a_willful_violatorYes.Checked = OF.f11_found_to_be_a_willful_violator;
        f11_found_to_be_a_willful_violatorNo.Checked = !OF.f11_found_to_be_a_willful_violator;

        f11_exempt_H1B_nonimmigrant1Yes.Checked  = OF.f11_exempt_H1B_nonimmigrant1;
        f11_exempt_H1B_nonimmigrant1No.Checked = !OF.f11_exempt_H1B_nonimmigrant1;

        f11_exempt_H1B_nonimmigrant2Yes.Checked   = OF.f11_exempt_H1B_nonimmigrant2;
        f11_exempt_H1B_nonimmigrant2No.Checked = !OF.f11_exempt_H1B_nonimmigrant2;

        f11_BeneficiaryAnnualMaster2.Checked = OF.f11_BeneficiaryAnnualMaster;
        f11_BeneficiaryAnnualMaster1.Checked = !OF.f11_BeneficiaryAnnualMaster;
        


        f11_Highest_Level_of_Education1.Checked  = OF.f11_Highest_Level_of_Education==1;
        f11_Highest_Level_of_Education2.Checked = OF.f11_Highest_Level_of_Education == 2;
        f11_Highest_Level_of_Education3.Checked = OF.f11_Highest_Level_of_Education == 3;
        f11_Highest_Level_of_Education4.Checked = OF.f11_Highest_Level_of_Education == 4;
        f11_Highest_Level_of_Education5.Checked = OF.f11_Highest_Level_of_Education == 5;
        f11_Highest_Level_of_Education6.Checked = OF.f11_Highest_Level_of_Education == 6;
        f11_Highest_Level_of_Education7.Checked = OF.f11_Highest_Level_of_Education == 7;
        f11_Highest_Level_of_Education8.Checked = OF.f11_Highest_Level_of_Education == 8;
        f11_Highest_Level_of_Education9.Checked = OF.f11_Highest_Level_of_Education == 9;

        f11_Primary_Field_of_Study.Text = OF.f11_Primary_Field_of_Study;
        f11_Rate_of_Pay_Per_Year.Text = OF.f11_Rate_of_Pay_Per_Year;
        f11_LCA_Code.Text = OF.f11_LCA_Code;
        f11_NAICS_Code.Text = OF.f11_NAICS_Code;
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f11_Petitioners_Name = OG.ClrText(f11_Petitioners_Name.Text);
        OF.f11_Is_the_petitioner_a_dependent_employer = f11_Is_the_petitioner_a_dependent_employerYes.Checked;
        OF.f11_found_to_be_a_willful_violator = f11_found_to_be_a_willful_violatorYes.Checked;
        OF.f11_exempt_H1B_nonimmigrant1 = f11_exempt_H1B_nonimmigrant1Yes.Checked;
        OF.f11_exempt_H1B_nonimmigrant2 = f11_exempt_H1B_nonimmigrant2Yes.Checked;
        if (f11_Highest_Level_of_Education1.Checked)
            OF.f11_Highest_Level_of_Education = 1;
        if (f11_Highest_Level_of_Education2.Checked)
            OF.f11_Highest_Level_of_Education = 2;
        if (f11_Highest_Level_of_Education3.Checked)
            OF.f11_Highest_Level_of_Education = 3;
        if (f11_Highest_Level_of_Education4.Checked)
            OF.f11_Highest_Level_of_Education = 4;
        if (f11_Highest_Level_of_Education5.Checked)
            OF.f11_Highest_Level_of_Education = 5;
        if (f11_Highest_Level_of_Education6.Checked)
            OF.f11_Highest_Level_of_Education = 6;
        if (f11_Highest_Level_of_Education7.Checked)
            OF.f11_Highest_Level_of_Education = 7;
        if (f11_Highest_Level_of_Education8.Checked)
            OF.f11_Highest_Level_of_Education = 8;
        if (f11_Highest_Level_of_Education9.Checked)
            OF.f11_Highest_Level_of_Education = 9;

        OF.f11_Primary_Field_of_Study = OG.ClrText(f11_Primary_Field_of_Study.Text);
        OF.f11_Rate_of_Pay_Per_Year = OG.ClrText(f11_Rate_of_Pay_Per_Year.Text);
        OF.f11_LCA_Code = OG.ClrText(f11_LCA_Code.Text);
        OF.f11_NAICS_Code = OG.ClrText(f11_NAICS_Code.Text);

        if (f11_BeneficiaryAnnualMaster1.Checked)
            OF.f11_BeneficiaryAnnualMaster = false;
        else
            OF.f11_BeneficiaryAnnualMaster = true;


        flag = OF.Form_11_Update(intEmployeeId);

        if (flag)
        Response.Redirect("form_i129h09.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

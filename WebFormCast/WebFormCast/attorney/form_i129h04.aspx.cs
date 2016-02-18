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
public partial class form_i129h04 : System.Web.UI.Page
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
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 4);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }

    protected void Initialize()
    {

        AcglEmployee OE = new AcglEmployee(intEmployeeId);

        
        

        Form_i129H OF = new Form_i129H(intEmployeeId);

        f4_Type_of_Office1.Checked = OF.f4_Type_of_Office == 1;
        f4_Type_of_Office2.Checked = OF.f4_Type_of_Office == 2;
        f4_Type_of_Office3.Checked = OF.f4_Type_of_Office == 3;
        f4_Office_Address.Text = OF.f4_Office_Address;
        f4_US_State_or_Foreign_Country.Text = OF.f4_US_State_or_Foreign_Country;
        f4_Persons_Foreign_Address.Text = OF.f4_Persons_Foreign_Address;

        f4_Have_a_valid_passpor1.Checked  = OF.f4_Have_a_valid_passpor==1;
        f4_Have_a_valid_passpor2.Checked = OF.f4_Have_a_valid_passpor==2;
        f4_Have_a_valid_passpor3.Checked = OF.f4_Have_a_valid_passpor==3;

        f4_Anyother_petitionsYes.Checked = OF.f4_Anyother_petitions ;
        f4_Anyother_petitionsNo.Checked  = !OF.f4_Anyother_petitions;

        f4_Anyother_petitions_HowMany.Text = OF.f4_Anyother_petitions_HowMany;

        f4_Are_applications_for_replacementYes.Checked = OF.f4_Are_applications_for_replacement;
        f4_Are_applications_for_replacementNo.Checked = !OF.f4_Are_applications_for_replacement;
        f4_Are_applications_for_replacement_howmany.Text = OF.f4_Are_applications_for_replacement_howmany;

        if (OE.Visa_Type_id == 1)
        {
            f4_dependents_being_filedYes.Checked =false;
            f4_dependents_being_filedYes.Enabled = false;
            f4_dependents_being_filedNo.Checked = true;
            f4_dependents_being_filedNo.Enabled = false;
            f4_dependents_being_filed_HowMany.Text ="";
            f4_dependents_being_filed_HowMany.Enabled = false;
        }
        else
        {
            f4_dependents_being_filedYes.Checked = OF.f4_dependents_being_filed;
            f4_dependents_being_filedNo.Checked = !OF.f4_dependents_being_filed;
            f4_dependents_being_filed_HowMany.Text = OF.f4_dependents_being_filed_HowMany;
        }

        f4_Removal_proceedingsYes.Checked  = OF.f4_Removal_proceedings;
        f4_Removal_proceedingsNo.Checked = !OF.f4_Removal_proceedings;

        f4_Have_you_ever_filed_an_immigrant_petitionYes.Checked = OF.f4_Have_you_ever_filed_an_immigrant_petition;
        f4_Have_you_ever_filed_an_immigrant_petitionNo.Checked = !OF.f4_Have_you_ever_filed_an_immigrant_petition;

        f4_Have_you_ever_filed_an_immigrant_petitionYes.Checked = OF.f4_Have_you_ever_filed_an_immigrant_petition;
        f4_Have_you_ever_filed_an_immigrant_petitionNo.Checked = !OF.f4_Have_you_ever_filed_an_immigrant_petition;

        f4_Thepast_seven_years1Yes.Checked = OF.f4_Thepast_seven_years1;
        f4_Thepast_seven_years1No.Checked = !OF.f4_Thepast_seven_years1;

        f4_Thepast_seven_years2Yes.Checked = OF.f4_Thepast_seven_years2;
        f4_Thepast_seven_years2No.Checked = !OF.f4_Thepast_seven_years2;

        f4_Ever_previously_filed_a_petition_for_this_persoYes.Checked = OF.f4_Ever_previously_filed_a_petition_for_this_perso;
        f4_Ever_previously_filed_a_petition_for_this_persoNo.Checked = !OF.f4_Ever_previously_filed_a_petition_for_this_perso;

        f4_If_you_are_filing_for_an_entertainment_groupYes.Checked = OF.f4_If_you_are_filing_for_an_entertainment_group;
        f4_If_you_are_filing_for_an_entertainment_groupNo.Checked = !OF.f4_If_you_are_filing_for_an_entertainment_group;
             
    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        if(f4_Type_of_Office1.Checked )
            OF.f4_Type_of_Office = 1;
        else if(f4_Type_of_Office2.Checked )
            OF.f4_Type_of_Office = 2;
        else if(f4_Type_of_Office3.Checked )
            OF.f4_Type_of_Office = 3;

        OF.f4_Office_Address = f4_Office_Address.Text;
        OF.f4_US_State_or_Foreign_Country = f4_US_State_or_Foreign_Country.Text;
        OF.f4_Persons_Foreign_Address=f4_Persons_Foreign_Address.Text;

        if(f4_Have_a_valid_passpor1.Checked )
            OF.f4_Have_a_valid_passpor = 1;
        else if(f4_Have_a_valid_passpor2.Checked )
            OF.f4_Have_a_valid_passpor = 2;
        else if(f4_Have_a_valid_passpor3.Checked )
            OF.f4_Have_a_valid_passpor = 3;


        if (f4_Anyother_petitionsYes.Checked)
            OF.f4_Anyother_petitions = true;
        else
            OF.f4_Anyother_petitions = false;

        OF.f4_Anyother_petitions_HowMany = f4_Anyother_petitions_HowMany.Text;

        if (f4_Are_applications_for_replacementYes.Checked)
            OF.f4_Are_applications_for_replacement = true;
        else
            OF.f4_Are_applications_for_replacement=false;

        OF.f4_Are_applications_for_replacement_howmany = f4_Are_applications_for_replacement_howmany.Text;

        if (f4_dependents_being_filedYes.Enabled)
        {
            if (f4_dependents_being_filedYes.Checked)
                OF.f4_dependents_being_filed = true;
            else
                OF.f4_dependents_being_filed = false;

            OF.f4_dependents_being_filed_HowMany = f4_dependents_being_filed_HowMany.Text;
        }
        else
        {
            OF.f4_dependents_being_filed = false;
            OF.f4_dependents_being_filed_HowMany = "";
        }

        if (f4_Removal_proceedingsYes.Checked)
            OF.f4_Removal_proceedings = true;
        else
            OF.f4_Removal_proceedings = false;

        if(f4_Have_you_ever_filed_an_immigrant_petitionYes.Checked )
            OF.f4_Have_you_ever_filed_an_immigrant_petition=true ;
        else
            OF.f4_Have_you_ever_filed_an_immigrant_petition=false;

        OF.f4_Have_you_ever_filed_an_immigrant_petition = f4_Have_you_ever_filed_an_immigrant_petitionYes.Checked;
        OF.f4_Thepast_seven_years1 = f4_Thepast_seven_years1Yes.Checked;
        OF.f4_Thepast_seven_years2 = f4_Thepast_seven_years2Yes.Checked;
        OF.f4_Ever_previously_filed_a_petition_for_this_perso = f4_Ever_previously_filed_a_petition_for_this_persoYes.Checked;
        OF.f4_If_you_are_filing_for_an_entertainment_group = f4_If_you_are_filing_for_an_entertainment_groupYes.Checked;
        
       flag = OF.Form_04_Update(intEmployeeId);

        if (flag)
        Response.Redirect("form_i129h05.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using WebFormCast.ACLG;  

public partial class attorney_companyview : System.Web.UI.Page
{
    int _CompanyId = 0;
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
            _CompanyId = Convert.ToInt16(Session["Company_Id"]);
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

        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("CLIENT");

        if (!IsPostBack)
        {
            FillCompay();
        }

    }
    protected bool FillCompay()
    {

        Company oC = new Company(_CompanyId);

        lbCompnayName.Text = oC.Legal_Name;
        txtAlternate_Phone_No.Text = oC.Alternate_Phone_No;
        txtAlternate_Phone_No_Code.Text = oC.Alternate_Phone_No_Code;
        txtAnnualIncome.Text = oC.AnnualIncome.ToString();
        txtComments.Text = oC.Comments;
        txtCompany_Type.Text = oC.Company_Type;
        txtDescription.Text = oC.Description;
        txtDocuments_Address.Text = oC.Documents_Address;
        txtEIN_Number.Text = oC.EIN_Number;
        txtFax_No.Text = oC.Fax_No;
        //txtFileToDate.Text = oC.FileToDate.ToString();
        //txtH1bPetitionsDenied.Text = oC.H1bPetitionsDenied;
        txtHaveAffiliates.Text = oC.HaveAffiliates.ToString();
        txtLastYearIncome.Text = oC.LastYearIncome.ToString();
        txtLastYearNetIncome.Text = oC.LastYearNetIncome.ToString();
        txtLegal_Name.Text = oC.Legal_Name;
        //txtMailing_Address.Text = oC.Mailing_Address;
        txtNetAnnualIncome.Text = oC.NetAnnualIncome.ToString();
        txtNoofEmployees.Text = oC.NoofEmployees.ToString();
        txtNoofH1BEmployees.Text = oC.NoofH1BEmployees.ToString();
        txtPerson_CellNo.Text = oC.Person_CellNo;
        txtPerson_Email.Text = oC.Person_Email;
        txtPerson_Fax.Text = oC.Person_FullName;
        txtPerson_Designation.Text = oC.Person_Designation;
        txtPerson_FullName.Text = oC.Person_FullName;
        txtPhone_No.Text = oC.Phone_No;
        txtPhone_No_Code.Text = oC.Phone_No_Code;
        txtRegistered_Date.Value = oC.Registered_Date;
        txtRegistration_State.Text = oC.Registration_State;
        txtWeb_Address.Text = oC.Web_Address;
        //txtWithdrawanyH1Bs.Text = oC.WithdrawanyH1Bs;
        txtAptNo.Text = oC.Add_AptNo;
        txtStreet.Text = oC.Add_Street;
        txtCity.Text = oC.Add_City;
        txtState.Text = oC.Add_State;
        txtZipCode.Text = oC.Add_Zip;
        txtNaics_Code.Text = oC.Naics_Code;
        txtContact_Info.Text = oC.Contact_Info;
        txtNIV_Contact_Info.Text = oC.NIV_Contact_Info;
        txtIV_Contact_Info.Text = oC.IV_Contact_Info;
        txtAcc_Contact_Info.Text = oC.Acc_Contact_Info;
        txtTemp_Contact_Info.Text = oC.Temp_Contact_Info;
        txtH1B_Dependent.Text = oC.H1B_Dependent;
        txtPublic_Law.Text = oC.Public_Law;
        txtPreferences.Text = oC.Preferences;

        return true;
    }
}

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
using System.Data.SqlClient;
using WebFormCast.ACLG;

public partial class employer_account : System.Web.UI.Page
{
    int _CompanyId = 0;
    string _Short_Name = "";
    string _Legal_Name = "";
    string _Mailing_Address = "";
    string _Documents_Address = "";
    string _Company_Type = "";
    string _Phone_No = "";
    string _Fax_No = "";
    string _Alternate_Phone_No = "";
    string _Web_Address = "";
    string _EIN_Number = "";
    string _Registered_Date = "";
    string _Registration_State = "";
    string _Registration_Date = "";
    string _Person_FullName = "";
    string _Person_Designation = "";
    string _Person_CellNo = "";
    string _Person_Email = "";
    string _Person_Fax = "";
    string _Description = "";
    string _HaveAffiliates = "";
    int _NoofEmployees = 0;
    int _NoofH1BEmployees = 0;
    int _FileToDate = 0;
    string _WithdrawanyH1Bs = "";
    string _H1bPetitionsDenied = "";
    string  _AnnualIncome = "";
    string  _LastYearIncome = "";
    string  _NetAnnualIncome = "";
    string  _LastYearNetIncome = "";
    string _Comments = "";
    string _CreatedDate = "";
    string _AttoneyUpdated_Date = "";
    string _SelfUpdated_Date = "";
    int _Next_Sequence_No = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        _CompanyId = 1;

        try
        {
            _CompanyId = Convert.ToInt16(Session["Company_Id"]);
        }
        catch { }

        if (_CompanyId <= 0)
        {
            Response.Redirect("index.aspx");
        }



        if (!IsPostBack)
        {
            FillCompay();
        }
        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("CLIENT");
    }


    protected bool  FillCompay()
    {

        Company oC = new Company(_CompanyId);
        lbCompanyName.Text = oC.Legal_Name + " Account";

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
        txtPassword.Text = oC.Password;
        txtPerson_Fax.Text = oC.Fax_No;
        txtPerson_Designation.Text = oC.Person_Designation; 
        txtPerson_FullName.Text = oC.Person_FullName;
        txtPhone_No.Text = oC.Phone_No;
        txtPhone_No_Code.Text = oC.Phone_No_Code;  
        txtRegistered_Date.Value  = oC.Registered_Date;
        txtNaics_Code.Text = oC.Naics_Code;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Company oC = new Company(_CompanyId);
        //oC.Legal_Name  = clrText("INFO");
        oC.Company_id = _CompanyId;  
        oC.Legal_Name  = clrText(txtLegal_Name.Text);
        //oC.Mailing_Address  = clrText(txtMailing_Address.Text);
        oC.Documents_Address  =clrText(txtDocuments_Address.Text);
        oC.Company_Type  =clrText(txtCompany_Type.Text) ;
        oC.Phone_No = clrText(txtPhone_No.Text);
        oC.Phone_No_Code = clrText(txtPhone_No_Code.Text);
        oC.Fax_No = clrText(txtFax_No.Text);
        oC.Alternate_Phone_No = clrText(txtAlternate_Phone_No.Text);
        oC.Alternate_Phone_No_Code = clrText(txtAlternate_Phone_No_Code.Text);
        oC.Web_Address = clrText(txtWeb_Address.Text);
        oC.EIN_Number = clrText(txtEIN_Number.Text);
        oC.Registered_Date = clrText(txtRegistered_Date.Value  );
        oC.Registration_State = clrText(txtRegistration_State.Text);
        oC.Naics_Code = clrText(txtNaics_Code.Text);
        oC.Person_FullName = clrText(txtPerson_FullName.Text);
        oC.Person_Designation = clrText(txtPerson_Designation.Text);
        oC.Person_CellNo = clrText(txtPerson_CellNo.Text);
        oC.Person_Email = clrText(txtPerson_Email.Text);
        oC.Person_Fax = clrText(txtPerson_Fax.Text);
        oC.Description = clrText(txtDescription.Text);
        oC.HaveAffiliates = clrText(txtHaveAffiliates.Text);
        try
        {
            oC.NoofEmployees = Convert.ToInt32(clrText(txtNoofEmployees.Text));
        }
        catch { }
        try
        {
            oC.NoofH1BEmployees = Convert.ToInt32(clrText(txtNoofH1BEmployees.Text));
        }
        catch { }
        //try
        //{
        //    oC.FileToDate = Convert.ToInt32(clrText(txtFileToDate.Text));
        //}
        //catch { }

        //oC.WithdrawanyH1Bs = clrText(txtWithdrawanyH1Bs.Text);
        //oC.H1bPetitionsDenied = clrText(txtH1bPetitionsDenied.Text);
        oC.AnnualIncome =  clrText(txtAnnualIncome.Text);
        oC.LastYearIncome = clrText(txtLastYearIncome.Text);
        oC.NetAnnualIncome = clrText(txtNetAnnualIncome.Text);
        oC.LastYearNetIncome =clrText(txtLastYearNetIncome.Text);
        oC.Comments = clrText(txtComments.Text);
        oC.Add_AptNo = clrText(txtAptNo.Text);
        oC.Add_Street = clrText(txtStreet.Text);
        oC.Add_City = clrText(txtCity.Text);
        oC.Add_State = clrText(txtState.Text);
        oC.Add_Zip = clrText(txtZipCode.Text);
        oC.Password = txtPassword.Text;
        oC.ATTYStateLicense = "";

        oC.Naics_Code = clrText(txtNaics_Code.Text);
        oC.Contact_Info = clrText(txtContact_Info.Text);
        oC.NIV_Contact_Info = clrText(txtNIV_Contact_Info.Text);
        oC.IV_Contact_Info = clrText(txtIV_Contact_Info.Text);
        oC.Acc_Contact_Info = clrText(txtAcc_Contact_Info.Text);
        oC.Temp_Contact_Info = clrText(txtTemp_Contact_Info.Text);
        oC.H1B_Dependent = clrText(txtH1B_Dependent.Text);
        oC.Public_Law = clrText(txtPublic_Law.Text);
        oC.Preferences = clrText(txtPreferences.Text);

        oC.UpdateCompany();
    }

    private string clrText(string str)
    {
        return str;
    }

}

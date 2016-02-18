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

public partial class employer_manage : System.Web.UI.Page
{

    int intCompanyId = 0;
    int intEmployeeId = 0;
    public string strCompanyInfo = "";
    public string strCompanyName = "";
    public string strContactPerson = "";
    public string strDesignation = "";

    protected void Page_Load(object sender, EventArgs e)
    {
    
    
        // ************************** 
        // **************************
        try
        {
            intCompanyId = Convert.ToInt16(Session["Company_Id"]);
        }
        catch { }

        if (intCompanyId <= 0)
        {
            Response.Redirect("index.aspx");
        }


        if (!IsPostBack)
        {
            FillTypes();
        }

        try
        {
            lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Company_Person_Name"].ToString();
        }
        catch
        { }
        InitializeCompany();

        panDisplay.Visible = false;
    }


    protected void InitializeCompany()
    {
        Company oC = new Company(intCompanyId);
        strCompanyName = oC.Legal_Name;
        strContactPerson = oC.Person_FullName;
        strDesignation = oC.Person_Designation;
        strCompanyInfo = oC.Person_FullName + "%0D%0A" + oC.Person_Designation + "%0D%0A" + oC.Legal_Name + "%0D%0A";

        if (oC.Phone_No != "")
        {
            strCompanyInfo += oC.Phone_No_Code + "-" + oC.Phone_No + " (Ph)%0D%0A";
        }
        if (oC.Fax_No != "")
        {
            strCompanyInfo += oC.Fax_No + " (Fax)";
        }
    }
    protected void FillTypes()
    {
        SqlDataReader dr;
        Company objCompany = new Company(intCompanyId);
        objCompany.bindTypeCombo(ddType,0);

        clsAttorney OA = new clsAttorney(objCompany.AttorneyId);
        OA.bindJobTitleCombo(ddJobTitle, 0); 

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
       AcglEmployee objE = new AcglEmployee();
       intEmployeeId =CreateEmployee();

       if (intEmployeeId == -1)
       {
           lbMeg.Text = "Email Already Exists, Please try another";
           lbMeg.ForeColor = System.Drawing.Color.Red;
           return ;
       }
       if (intEmployeeId > 0)
       {
           objE = new AcglEmployee(intEmployeeId);
           lbMeg.Text = " New Employee has been created";
           txtFirst_Name.Text = "";
           txtLast_Name.Text = "";
           txtEmail_Address.Text = "";
           //txtMessage.Text = "";
           ddType.SelectedIndex = 0;
           lbFirstName.Text = objE.FirstName;
           lbLastName.Text = objE.LastName;
           lbTrackingNo.Text = objE.TrackingNo;
           hlEmail.NavigateUrl = "mailto:" + objE.Email + "?Subject=Welcome%20to%20" + strCompanyName + "%20Immigration%20Management%20System&Body=Dear%20" + objE.FirstName + " " + objE.LastName + "%0D%0A%0D%0AWelcome%20to%20our%20web-based%20immigration%20management%20system.%20Please%20click%20on%20the%20link%20below%20and%20use%20the%20provided%20username%20and%20password%20to%20login.%20Please%20complete%20all%20the%20information%20in%3A%0D%0A%0D%0A1. Personal Information%0D%0A2. Education Details%0D%0A3. Experience Details%0D%0A%0D%0APlease do not finalize the form until you have entered all the information correctly. Once you finalize the application, you cannot modify your information!%0D%0A%0D%0Ahttp://webformcast.azurewebsites.net/employee/index.aspx%0D%0A%0D%0AUsername : " + objE.Email + "%0D%0APassword : " + objE.AccessKey + "%0D%0A%0D%0A%0D%0A%0D%0AThank You%0D%0A%0D%0A" + strCompanyInfo;
           panForm.Visible = false;
           panDisplay.Visible =true ;
       }
       else
       {
           panForm.Visible = true;
           panDisplay.Visible = false;
       }
        
    }

    protected int CreateEmployee()
    {
        AcglGeneral oG = new AcglGeneral();
        AcglEmployee objE = new AcglEmployee();
        string strEmail = oG.ClrText(txtEmail_Address.Text);

        if(objE.EmailisExists(strEmail))
        {
            return -1;
        }

        DataTable Dt = new DataTable();
        Company objc = new Company(intCompanyId);
        
        string strFirstName= txtFirst_Name.Text;
        string strLastName = txtLast_Name.Text;
        
        string strMessage = "";//txtMessage.Text;
        string strTrackingNO = objc.NextTrackingNo;
        int intType = Convert.ToInt16(ddType.SelectedValue) ;
        int intJobTitleId = Convert.ToInt32(ddJobTitle.SelectedValue);  
        int EmpId = 0;
        EmpId = objE.CreateNewEmployee(intCompanyId, strFirstName, strLastName, strEmail, intType, intJobTitleId,strTrackingNO, strMessage);
        return EmpId;
    }

    protected void btnSaveEmail_Click(object sender, EventArgs e)
    {
        intEmployeeId = CreateEmployee();
        if (intEmployeeId > 0)
        {
            AcglEmployee objE = new AcglEmployee(intEmployeeId);
            objE.SendEmployeeAccessMail();
            //lbMeg.Text = " New Employee has been created";

            txtFirst_Name.Text = "";
            txtLast_Name.Text = "";
            txtEmail_Address.Text = "";
            //txtMessage.Text = "";
            ddType.SelectedIndex = 0;
            lbFirstName.Text = objE.FirstName;
            lbLastName.Text = objE.LastName;
            lbTrackingNo.Text = objE.TrackingNo;
            hlEmail.NavigateUrl = "mailto:" + objE.Email + "?Subject=Welcome%20to%20" + strCompanyName + "%20Immigration%20Management%20System&Body=Dear%20" + objE.FirstName + " " + objE.LastName + "%0D%0A%0D%0AWelcome%20to%20our%20web-based%20immigration%20management%20system.%20Please%20click%20on%20the%20link%20below%20and%20use%20the%20provided%20username%20and%20password%20to%20login.%20Please%20complete%20all%20the%20information%20in%3A%0D%0A%0D%0A1. Personal Information%0D%0A2. Education Details%0D%0A3. Experience Details%0D%0A%0D%0APlease do not finalize the form until you have entered all the information correctly. Once you finalize the application, you cannot modify your information!%0D%0A%0D%0Ahttp://webformcast.azurewebsites.net/employee/index.aspx%0D%0A%0D%0AUsername : " + objE.Email + "%0D%0APassword : " + objE.AccessKey + "%0D%0A%0D%0A%0D%0A%0D%0AThank You%0D%0A%0D%0A" + strCompanyInfo;
            panForm.Visible = true;
        }
        else
        {
            panDisplay.Visible = true;
        }
    }
}

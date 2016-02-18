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


public partial class employer_employee : System.Web.UI.Page
{
    public string strRow1 = "";
    public string strRow2 = "";
    string strAction = "";
    int intRecId = 0;
    string strSignature = "";

    public string strPRRow1 = "";
    public string strPRRow2 = "";
    string strPRAction = "";
    int intPRRecId = 0;
    string strPRSignature = "";

    public string strStayRow1 = "";
    public string strStayRow2 = "";
    string strStayAction = "";
    int intStayRecId = 0;
    string strStaySignature = "";

    public string strEdRow1 = "";
    public string strEdRow2 = "";
    string strEdAction = "";
    int intEdRecId = 0;
    string strEdSignature = "";

    public string strExpRow1 = "";
    public string strExpRow2 = "";
    string strExpAction = "";
    int intExpRecId = 0;
    string strExpSignature = "";

    public string strDepRow1 = "";
    public string strDepRow2 = "";
    string strDepAction = "";
    int intDepRecId = 0;
    string strDepSignature = "";

    int intStatus = 0;
    public string strScript = "";
    int intEmployeeId = 0;
    int intCompanyId = 0;


    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intCompanyId = Convert.ToInt16(Session["Company_Id"]);
        }
        catch { }
        if (intCompanyId <= 0)
        {
            Response.Redirect("index.aspx");
        }

        try
        {
            intEmployeeId = Convert.ToInt16(Session["Employer_Employee_Id"]);
            //strEmployeeSignature =Session["Attorney_Employee_Signature"].ToString();
        }
        catch { }

        if (intEmployeeId <= 0)
            Response.Redirect("employer.aspx");

        try
        {
            lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Company_Person_Name"].ToString();
        }
        catch
        { }

        if (intEmployeeId <= 0)
        {
            Response.Redirect("home.aspx");
        }

        try
        {
            strAction = Request["action"].ToString();
        }
        catch { }

        try
        {
            intRecId = Convert.ToInt16(Request["order"]);
        }
        catch { }

        try
        {
            strSignature = Request["signature"].ToString();
        }
        catch { }
        try
        {
            strPRAction = Request["actionPR"] == null ? "" : Request["actionPR"].ToString();
            intPRRecId = Request["orderPR"] == null ? 0 : Convert.ToInt16(Request["orderPR"]);
            strPRSignature = Request["signaturePR"] == null ? "" : Request["signaturePR"].ToString();
        }
        catch { }
        try
        {
            strStayAction = Request["actionStay"] == null ? "" : Request["actionStay"].ToString();
            intStayRecId = Request["orderStay"] == null ? 0 : Convert.ToInt16(Request["orderStay"]);
            strStaySignature = Request["signatureStay"] == null ? "" : Request["signatureStay"].ToString();

        }
        catch { }
        try
        {
            strEdAction = Request["actionEd"] == null ? "" : Request["actionEd"].ToString();
            intEdRecId = Request["orderEd"] == null ? 0 : Convert.ToInt16(Request["orderEd"]);
            strEdSignature = Request["signatureEd"] == null ? "" : Request["signatureEd"].ToString();
        }
        catch { }

        try
        {
            strExpAction = Request["actionExp"] == null ? "" : Request["actionExp"].ToString();
            intExpRecId = Request["orderExp"] == null ? 0 : Convert.ToInt16(Request["orderExp"]);
            strExpSignature = Request["signatureExp"] == null ? "" : Request["signatureExp"].ToString();
        }
        catch { }

        try
        {
            strDepAction = Request["actionDep"] == null ? "" : Request["actionDep"].ToString();
            intDepRecId = Request["orderDep"] == null ? 0 : Convert.ToInt16(Request["orderDep"]);
            strDepSignature = Request["signatureDep"] == null ? "" : Request["signatureDep"].ToString();
            panDisplay.Visible = false;
        }
        catch { }

        if (!IsPostBack)
        {
            if (strAction == "delete" || strPRAction == "delete" || strStayAction == "delete" || strEdAction == "delete"
                || strExpAction == "delete" || strDepAction == "delete")
            {
                AcglEmployee OE = new AcglEmployee();
                if (strAction == "delete")
                {
                    OE.DeleteVendor(intEmployeeId, strSignature);
                    Response.Redirect("employee.aspx#Vendor");
                }
                if (strPRAction == "delete")
                {
                    OE.DeletePrevReceipt(intEmployeeId, strPRSignature);
                    Response.Redirect("employee.aspx#PrevReceipt");
                }
                if (strStayAction == "delete")
                {
                    OE.DeletePrevStay(intEmployeeId, strStaySignature);
                    Response.Redirect("employee.aspx#PrevStay");
                }
                if (strEdAction == "delete")
                {
                    OE.DeleteEducation(intEmployeeId, strEdSignature);
                    Response.Redirect("employee.aspx#Education");
                }
                if (strExpAction == "delete")
                {
                    OE.DeleteProfession(intEmployeeId, strExpSignature);
                    Response.Redirect("employee.aspx#Experience");
                }
                if (strDepAction == "delete")
                {
                    OE.DeleteDependant(intEmployeeId, strDepSignature);
                    Response.Redirect("employee.aspx#Dependent");
                }
            }
            //Education
            fillMonths(ddMonth1);
            fillMonths(ddMonth2);
            fillMonths(ddExpMonth1);
            fillMonths(ddExpMonth2);
            fillYears(ddYear1);
            fillYears(ddYear2);
            fillYears(ddYear3);
            fillYears(ddExpYear1);
            fillYears(ddExpYear2);
            //Dependent
            AcglGeneral OG = new AcglGeneral();
            OG.bindCountryCombo(ddCountryofBirthDep, "");
            OG.bindCountryCombo(txtCountryPassportIssuance, "");
            OG.bindCountryCombo(ddCountryofCitizensip, "");
            
            Initialize();
            displayLists();
        }

        if (Session["Attorney_Msg"] != null)
        {
            loading.InnerHtml = Session["Attorney_Msg"].ToString();
            Session["Attorney_Msg"] = null;
        }

    }
    protected void Initialize()
    {
        AcglEmployee oE = new AcglEmployee(intEmployeeId);
        AcglGeneral objG = new AcglGeneral();

        txtFirst_Name.Text = oE.FirstName;
        txtLast_Name.Text = oE.LastName;
        txtMiddle_Name.Text = "";
        txtEmail_Address.Text = oE.Email;

        //Initial Questions
        if (oE.Q_isUSResident != null)
        {
            if (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && oE.Q_isUSResident.ToString().Equals("Y"))
                rbUsResident1.Checked = true;
            if (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && oE.Q_isUSResident.ToString().Equals("N"))
                rbUsResident2.Checked = true;
        }
        if (oE.Q_isThirdParty != null)
        {
            if (!String.IsNullOrEmpty(oE.Q_isThirdParty.ToString()) && oE.Q_isThirdParty.ToString().Equals("Y"))
                rbThirdParty1.Checked = true;
            if (!String.IsNullOrEmpty(oE.Q_isThirdParty.ToString()) && oE.Q_isThirdParty.ToString().Equals("N"))
                rbThirdParty2.Checked = true;
        }
        if (oE.Q_isPremiumFee != null)
        {
            if (!String.IsNullOrEmpty(oE.Q_isPremiumFee.ToString()) && oE.Q_isPremiumFee.ToString().Equals("Y"))
                rbPremiumFee1.Checked = true;
            if (!String.IsNullOrEmpty(oE.Q_isPremiumFee.ToString()) && oE.Q_isPremiumFee.ToString().Equals("N"))
                rbPremiumFee2.Checked = true;
        }
        if (oE.Q_isEmpRelated != null)
        {
            if (!String.IsNullOrEmpty(oE.Q_isEmpRelated.ToString()) && oE.Q_isEmpRelated.ToString().Equals("Y"))
                rbEmpRelated1.Checked = true;
            if (!String.IsNullOrEmpty(oE.Q_isEmpRelated.ToString()) && oE.Q_isEmpRelated.ToString().Equals("N"))
                rbEmpRelated2.Checked = true;
        }
        if (oE.Q_isFileDependents != null)
        {
            if (!String.IsNullOrEmpty(oE.Q_isFileDependents.ToString()) && oE.Q_isFileDependents.ToString().Equals("Y"))
                rbFileDependents1.Checked = true;
            if (!String.IsNullOrEmpty(oE.Q_isFileDependents.ToString()) && oE.Q_isFileDependents.ToString().Equals("N"))
                rbFileDependents2.Checked = true;
        }
        if (oE.Q_isPrevEmployed != null)
        {
            if (!String.IsNullOrEmpty(oE.Q_isPrevEmployed.ToString()) && oE.Q_isPrevEmployed.ToString().Equals("Y"))
                rbPrevEmployed1.Checked = true;
            if (!String.IsNullOrEmpty(oE.Q_isPrevEmployed.ToString()) && oE.Q_isPrevEmployed.ToString().Equals("N"))
                rbPrevEmployed2.Checked = true;
        }

        checkQuestionUSResident();
        txtMiddle_Name.Text = oE.MiddleName.ToString();
        txtOther_Name1.Text = oE.OtherName1.ToString();
        txtOther_Name2.Text = oE.OtherName2.ToString();
        txtOther_Name3.Text = oE.OtherName3.ToString();
        txtTelNo.Text = oE.TelNo.ToString();
        txtDateofBirth.Value = oE.DateofBirth.ToString();
        txtSocialSecurity.Text = oE.SocialSecurity.ToString();
        txtANumber.Text = oE.ANumber.ToString();
        txtStateofBirth.Text = oE.StateofBirth.ToString();
        objG.bindCountryCombo(ddCountryofBirth, oE.CountryofBirth.ToString());
        objG.bindCountryCombo(ddCountryofCitixenship, oE.CountryofCitixenship.ToString());

        txtI94.Text = oE.I94.ToString();
        txtDateofFirstEntry.Value = oE.DateofFirstEntry.ToString();
        txtDateofLastArrival.Value = oE.DateofLastArrival.ToString();
        txtPassportNumber.Text = oE.PassportNumber.ToString();
        txtPassportissuedate.Value = oE.Passportissuedate.ToString();
        txtPassportExpiresDate.Value = oE.PassportExpiresDate.ToString();
        txtPassportIssueCountry.Text = oE.PassportIssueCountry.ToString();
        txtCNIStatus.Text = oE.CNIStatus.ToString();
        txtSevisNo.Text = oE.SevisNo.ToString();
        txtStdEADNo.Text = oE.StdEADNo.ToString();

        txtCNIDateStatusExpires.Value = oE.CNIDateStatusExpires.ToString();
        txtConsulateCityCountry.Text = oE.ConsulateCityCountry.ToString();
        txtConsulateCityCountry1.Text = oE.ConsulateCityCountry1.ToString();


        txtForeignAddress_Street.Text = oE.ForeignAddress_Street;
        txtForeignAddress_AppNo.Text = oE.ForeignAddress_AppNo;
        txtForeignAddress_City.Text = oE.ForeignAddress_City;
        txtForeignAddress_State.Text = oE.ForeignAddress_State;
        txtForeignAddress_Country.Text = oE.ForeignAddress_Country;
        txtForeignAddress_Zip.Text = oE.ForeignAddress_Zip;
        //txtForeignAddress.Text  = oE.ForeignAddress.ToString();
        txtUSAddress_Street.Text = oE.USAddress_Street;
        txtUSAddress_AppNo.Text = oE.USAddress_AppNo;
        txtUSAddress_City.Text = oE.USAddress_City;
        txtUSAddress_State.Text = oE.USAddress_State;
        txtUSAddress_Zip.Text = oE.USAddress_Zip;
        if (Convert.ToBoolean(oE.H1Bwithnpast7yrs.ToString()) == true)
            rbH1B1.Checked = true;
        else
            rbH1B2.Checked = true;

        if (Convert.ToBoolean(oE.H1Bwithnpast7yrs.ToString()) == true)
            rbDenied1.Checked = true;
        else
            rbDenied2.Checked = true;

        checkPastH1B();
        txtSkills.Text = oE.Skills.ToString();

        //if(oE.Title=="Mr.")

        rdCurrentAddress1.Checked = oE.CurrentAddress == 1;
        rdCurrentAddress2.Checked = oE.CurrentAddress == 2;
        rbTitle1.Checked = (oE.Title == "Mr." || oE.Title == "Male" || oE.Title == "M");
        rbTitle2.Checked = (oE.Title == "Ms." || oE.Title == "Female" || oE.Title == "F");

        txtEC_JobTitle.Text = oE.EC_JobTitle.ToString();
        txtEC_Name.Text = oE.EC_Name.ToString();
        txtEC_Address.Text = oE.EC_Address.ToString();
        txtEC_MgrName.Text = oE.EC_MgrName.ToString();
        txtEC_Email.Text = oE.EC_Email.ToString();
        txtEC_Phone.Text = oE.EC_Phone.ToString();

        txtPERMDateFiled.Value = oE.PERM_DateFiled.ToString();
        txtPERM_CaseNo.Text = oE.PERM_CaseNo.ToString();
        txtI140_ReceiptNo.Text = oE.I140_ReceiptNo.ToString();
        txtPend_App_Type.Text = oE.Pend_App_Type.ToString();
        txtPend_App_ReceiptNo.Text = oE.Pend_App_ReceiptNo.ToString();

        checkQuestionThirdParty();
        checkQuestionPrevEmployed();

        if (oE.Employee_Access == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) {
            btnSubmit.Enabled = true;
            btnQuestionsSubmit.Enabled = true;
        }
        else
        {
            btnSubmit.Enabled = false;
            btnQuestionsSubmit.Enabled = false;
        }
        lbStatus.Text = oE.StatusText;
        intStatus = oE.Employee_Access;

        lbName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName + " - " + oE.TrackingNo;
        if (oE.Status == 6)
            lbStatus.Text = "New";
        else if (oE.Status == 10)
            lbStatus.Text = "In Review";
        else if (oE.Status == 11)
            lbStatus.Text = "Accepted";
        else if (oE.Status == 12)
            lbStatus.Text = "In Progress";
        else if (oE.Status == 15)
            lbStatus.Text = "Filed";

        Company OC = new Company(oE.Company_id);
        lbCompanyLogoText.Text = OC.Legal_Name;

        //Education
        rbHighestLeve1.Checked = oE.HighestLeve == 1;
        rbHighestLeve2.Checked = oE.HighestLeve == 2;
        rbHighestLeve3.Checked = oE.HighestLeve == 3;
        rbHighestLeve4.Checked = oE.HighestLeve == 4;
        rbHighestLeve5.Checked = oE.HighestLeve == 5;
        rbHighestLeve6.Checked = oE.HighestLeve == 6;
        rbHighestLeve7.Checked = oE.HighestLeve == 7;
        rbHighestLeve8.Checked = oE.HighestLeve == 8;
        rbHighestLeve9.Checked = oE.HighestLeve == 9;

        chMasterDegreeFromUS1.Checked = oE.MasterDegreeFromUS;
        chMasterDegreeFromUS2.Checked = !oE.MasterDegreeFromUS;

        txtPrimaryFieldofStudy.Text = oE.PrimaryFieldofStudy;
        txtUSInstitutionName.Text = oE.USInstitutionName;
        txtUSDateDegreeAwarded.Text = oE.USDateDegreeAwarded;
        txtUSDegreeType.Text = oE.USDegreeType;
        txtUSInstitutionAddress.Text = oE.USInstitutionAddress;

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SaveData();
        Session["Attorney_Msg"] = "Personal information saved successfully";
        Response.Redirect("employee.aspx");
    }

    protected void btnQuestionsSubmit_Click(object sender, EventArgs e)
    {
        AcglEmployee oE = new AcglEmployee();
        SaveQuestionsData(oE);
        Session["Attorney_Msg"] = "Initial questions information saved successfully";
        Response.Redirect("employee.aspx");
    }

    protected bool SaveData()
    {
        string strTitle = "";
        if (rbTitle1.Checked)
            strTitle = "Male";
        if (rbTitle2.Checked)
            strTitle = "Female";
        int intCurAdd = 0;

        if (rdCurrentAddress1.Checked)
            intCurAdd = 1;
        if (rdCurrentAddress2.Checked)
            intCurAdd = 2;

        AcglEmployee oE = new AcglEmployee();
        SaveQuestionsData(oE);
        oE.Update1Employee(intEmployeeId,
            clearText(txtFirst_Name.Text),
            clearText(txtLast_Name.Text),
            clearText(txtMiddle_Name.Text),
            clearText(txtOther_Name1.Text),
            clearText(txtOther_Name2.Text),
            clearText(txtOther_Name3.Text),
            clearText(txtTelNo.Text),
            clearText(txtDateofBirth.Value),
            clearText(txtSocialSecurity.Text),
            clearText(txtANumber.Text),
            clearText(ddCountryofBirth.SelectedValue),
            clearText(txtStateofBirth.Text),
            clearText(ddCountryofCitixenship.Text),
            clearText(txtI94.Text),
            clearText(txtDateofFirstEntry.Value),
            clearText(txtDateofLastArrival.Value),
            clearText(txtPassportNumber.Text),
            clearText(txtPassportissuedate.Value),
            clearText(txtPassportExpiresDate.Value),
            clearText(txtCNIStatus.Text),
            clearText(txtCNIDateStatusExpires.Value),
            clearText(txtConsulateCityCountry.Text),
            clearText(txtConsulateCityCountry1.Text),
            clearText(""),
            clearText(txtForeignAddress_Street.Text),
            clearText(txtForeignAddress_AppNo.Text),
            clearText(txtForeignAddress_City.Text),
            clearText(txtForeignAddress_State.Text),
            clearText(txtForeignAddress_Country.Text),
            clearText(txtForeignAddress_Zip.Text),
            clearText(txtUSAddress_Street.Text),
            clearText(txtUSAddress_AppNo.Text),
            clearText(txtUSAddress_City.Text),
            clearText(txtUSAddress_State.Text),
            clearText(txtUSAddress_Zip.Text),
            rbH1B1.Checked,
            rbDenied1.Checked,
            clearText(txtSkills.Text),
            strTitle,
            intCurAdd,
            clearText(txtSevisNo.Text),
            clearText(txtStdEADNo.Text),
            clearText(txtPassportIssueCountry.Text),
            clearText(txtEC_JobTitle.Text),
            clearText(txtEC_Name.Text),
            clearText(txtEC_Address.Text),
            clearText(txtEC_MgrName.Text),
            clearText(txtEC_Email.Text),
            clearText(txtEC_Phone.Text),
            clearText(txtPERMDateFiled.Value),
            clearText(txtPERM_CaseNo.Text),
            clearText(txtI140_ReceiptNo.Text),
            clearText(txtPend_App_Type.Text),
            clearText(txtPend_App_ReceiptNo.Text)
            );

        SaveEducationData(oE);
        return true;
    }

    protected bool SaveQuestionsData(AcglEmployee oE)
    {
        oE.UpdateInitialQuestions(intEmployeeId, (rbUsResident1.Checked ? "Y" : "N"), (rbThirdParty1.Checked ? "Y" : "N")
            , (rbPremiumFee1.Checked ? "Y" : "N")
            , (rbEmpRelated1.Checked ? "Y" : "N")
            , (rbFileDependents1.Checked ? "Y" : "N")
            , (rbPrevEmployed1.Checked ? "Y" : "N")
            );
        return true;
    }

    protected bool SaveEducationData(AcglEmployee oE)
    {
        int HighestLeve = 0;
        bool USdegree = false;

        USdegree = chMasterDegreeFromUS1.Checked;

        if (rbHighestLeve1.Checked)
            HighestLeve = 1;
        if (rbHighestLeve2.Checked)
            HighestLeve = 2;
        if (rbHighestLeve3.Checked)
            HighestLeve = 3;
        if (rbHighestLeve4.Checked)
            HighestLeve = 4;
        if (rbHighestLeve5.Checked)
            HighestLeve = 5;
        if (rbHighestLeve6.Checked)
            HighestLeve = 6;
        if (rbHighestLeve7.Checked)
            HighestLeve = 7;
        if (rbHighestLeve8.Checked)
            HighestLeve = 8;
        if (rbHighestLeve9.Checked)
            HighestLeve = 9;

        AcglGeneral OG = new AcglGeneral();

        oE.HighestLeve = HighestLeve;
        oE.MasterDegreeFromUS = USdegree;
        oE.PrimaryFieldofStudy = OG.ClrText(txtPrimaryFieldofStudy.Text);
        oE.USInstitutionName = OG.ClrText(txtUSInstitutionName.Text);
        oE.USDateDegreeAwarded = OG.ClrText(txtUSDateDegreeAwarded.Text);
        oE.USDegreeType = OG.ClrText(txtUSDegreeType.Text);
        oE.USInstitutionAddress = OG.ClrText(txtUSInstitutionAddress.Text);

        oE.UpdateEmployeeEducation(intEmployeeId);

        return true;
    }

    protected void setCompanyId(int intCompanyId)
    {
        Session["ACompany_Id"] = intCompanyId;
        HttpCookie myCookie = new HttpCookie("Employer");
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

    protected string clearText(string strtxt)
    {
        return strtxt;
    }

    protected void btnFinalize_Click(object sender, EventArgs e)
    {
        AcglEmployee OE = new AcglEmployee();
        bool flag = false;
        flag = OE.UpdateStatus(intEmployeeId, 3);
        if (flag)
        {
            strScript = "<script language='javascript'>alert('Your Information has been Finalized!')</script>";
            //btnFinalize.Enabled = false;
            lbStatus.Text = "Finalized";
        }
        else
            strScript = "<script language='javascript'>alert('Your Information could not Finalizedz!)</script>";
    }

    protected void radioUsResident_CheckedChanged(object sender, EventArgs e)
    {
        checkQuestionUSResident();
        displayLists();
    }

    protected void radioThirdParty_CheckedChanged(object sender, EventArgs e)
    {
        checkQuestionThirdParty();
        displayLists();
    }

    protected void checkQuestionUSResident()
    {
        if (rbUsResident1.Checked)
        {
            panDependent.Visible = true;
            tbPart1USInfo.Visible = true;
            rbFileDependents1.Enabled = true;
            rbFileDependents2.Enabled = true;
            if (rbFileDependents2.Checked)
            {
                panDependent.Visible = false;
            }
        }
        if (rbUsResident2.Checked)
        {
            panDependent.Visible = false;
            tbPart1USInfo.Visible = false;
            rbFileDependents1.Enabled = false;
            rbFileDependents2.Enabled = false;
        }
    }

    protected void checkQuestionThirdParty()
    {
        if (rbThirdParty1.Checked)
        {
            divPart2Info.Visible = true;
            tbPart2Info.Visible = true;
            displayVendorList();
        }
        if (rbThirdParty2.Checked)
        {
            divPart2Info.Visible = false;
            tbPart2Info.Visible = false;
        }
    }

    protected void rbH1B_CheckedChanged(object sender, EventArgs e)
    {
        checkPastH1B();
        displayLists();
        rbH1B1.Focus();
        //Response.Redirect("employee.aspx#QPrevStay");
    }

    protected void checkPastH1B()
    {
        if (rbH1B1.Checked)
        {
            tbPastH1BRcpt.Visible = true;
            tbPastH1BStay.Visible = true;
            displayPrevReceiptList();
            displayPrevStayList();
        }
        if (rbH1B2.Checked)
        {
            tbPastH1BRcpt.Visible = false;
            tbPastH1BStay.Visible = false;
        }
    }

    protected void radioFileDependents_CheckedChanged(object sender, EventArgs e)
    {
        checkQuestionFileDependents();
        displayLists();
    }

    protected void checkQuestionFileDependents()
    {
        if (rbFileDependents1.Checked)
        { 
            panDependent.Visible = true;
        }
        if (rbFileDependents2.Checked)
        {
            panDependent.Visible = false;
        }
    }

    protected void radioPrevEmployed_CheckedChanged(object sender, EventArgs e)
    {
        checkQuestionPrevEmployed();
        displayLists();
    }

    protected void checkQuestionPrevEmployed()
    {
        if (rbPrevEmployed1.Checked)
        {
            panExperience.Visible = true;
        }
        if (rbPrevEmployed2.Checked)
        {
            panExperience.Visible = false;
        }
    }

    protected void displayLists()
    {
        displayVendorList();
        displayPrevReceiptList();
        displayPrevStayList();
        displayEducationList();
        displayExperienceList();
        displayDependentList();
    }

    protected void displayVendorList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        intStatus = OE.Employee_Access;
        ds = OE.GetVendorList(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;
        strRow1 = "";
        strRow2 = "";
        if (strAction != "edit")
            intRecId = 0;
        eRecId = intRecId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cRecId = i + 1;
            if (eRecId == cRecId)
            {
                txtName.Text = ds.Tables[0].Rows[i]["Name"].ToString();
                txtContactName.Text = ds.Tables[0].Rows[i]["Contact_Name"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[i]["Email"].ToString();
                txtPhone.Text = ds.Tables[0].Rows[i]["Phone_Number"].ToString();
            }
            else if (cRecId < eRecId || intRecId <= 0)
            {
                strRow1 += "<tr>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Contact_Name"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Email"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Phone_Number"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strRow1 += "<td><a href='employee.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Vendor'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Vendor'>Delete</a></td>";
                else
                    strRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strRow1 += "</tr>";
            }
            else
            {
                strRow2 += "<tr>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Contact_Name"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Email"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Phone_Number"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strRow2 += "<td><a href='employee.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Vendor'>Edit</a>&nbsp;&nbsp;<a href='employee.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Vendor'>Delete</a></td>";
                else
                    strRow2 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strRow2 += "</tr>";
            }


        }

    }

    protected void displayPrevReceiptList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        intStatus = OE.Employee_Access;
        ds = OE.GetPrevReceiptList(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;
        strPRRow1 = "";
        strPRRow2 = "";
        if (strPRAction != "edit")
            intPRRecId = 0;
        eRecId = intPRRecId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cRecId = i + 1;
            if (eRecId == cRecId)
            {
                txtReceiptNo.Text = ds.Tables[0].Rows[i]["Receipt_No"].ToString();
                txtReceiptEmpName.Text = ds.Tables[0].Rows[i]["Employer_Name"].ToString();
            }
            else if (cRecId < eRecId || intPRRecId <= 0)
            {
                strPRRow1 += "<tr>";
                strPRRow1 += "<td>" + ds.Tables[0].Rows[i]["Receipt_No"].ToString() + "</td>";
                strPRRow1 += "<td>" + ds.Tables[0].Rows[i]["Employer_Name"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strPRRow1 += "<td><a href='employee.aspx?actionPR=edit&orderPR=" + cRecId.ToString() + "&signaturePR=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevReceipt'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee.aspx?actionPR=delete&orderPR=" + cRecId.ToString() + "&signaturePR=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevReceipt'>Delete</a></td>";
                else
                    strPRRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strPRRow1 += "</tr>";
            }
            else
            {
                strPRRow2 += "<tr>";
                strPRRow2 += "<td>" + ds.Tables[0].Rows[i]["Receipt_No"].ToString() + "</td>";
                strPRRow2 += "<td>" + ds.Tables[0].Rows[i]["Employer_Name"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strPRRow2 += "<td><a href='employee.aspx?actionPR=edit&orderPR=" + cRecId.ToString() + "&signaturePR=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevReceipt'>Edit</a>&nbsp;&nbsp;<a href='employee.aspx?actionPR=delete&orderPR=" + cRecId.ToString() + "&signaturePR=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevReceipt'>Delete</a></td>";
                else
                    strPRRow2 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strPRRow2 += "</tr>";
            }


        }

    }

    protected void displayPrevStayList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        intStatus = OE.Employee_Access;
        ds = OE.GetPrevStayList(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;
        strStayRow1 = "";
        strStayRow2 = "";
        if (strStayAction != "edit")
            intStayRecId = 0;
        eRecId = intStayRecId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cRecId = i + 1;
            if (eRecId == cRecId)
            {
                txtStayStatus.Text = ds.Tables[0].Rows[i]["Status"].ToString();
                txtStayDateIn.Value = ds.Tables[0].Rows[i]["DateIn"].ToString();
                txtStayDateOut.Value = ds.Tables[0].Rows[i]["DateOut"].ToString();
            }
            else if (cRecId < eRecId || intStayRecId <= 0)
            {
                strStayRow1 += "<tr>";
                strStayRow1 += "<td>" + ds.Tables[0].Rows[i]["Status"].ToString() + "</td>";
                strStayRow1 += "<td>" + ds.Tables[0].Rows[i]["DateIn"].ToString() + "</td>";
                strStayRow1 += "<td>" + ds.Tables[0].Rows[i]["DateOut"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strStayRow1 += "<td><a href='employee.aspx?actionStay=edit&orderStay=" + cRecId.ToString() + "&signatureStay=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevStay'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");' href='employee.aspx?actionStay=delete&orderStay=" + cRecId.ToString() + "&signatureStay=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevStay'>Delete</a></td>";
                else
                    strStayRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strStayRow1 += "</tr>";
            }
            else
            {
                strStayRow2 += "<tr>";
                strStayRow2 += "<td>" + ds.Tables[0].Rows[i]["Status"].ToString() + "</td>";
                strStayRow2 += "<td>" + ds.Tables[0].Rows[i]["DateIn"].ToString() + "</td>";
                strStayRow2 += "<td>" + ds.Tables[0].Rows[i]["DateOut"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strStayRow2 += "<td><a href='employee.aspx?actionStay=edit&orderStay=" + cRecId.ToString() + "&signatureStay=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevStay'>Edit</a>&nbsp;&nbsp;<a href='employee.aspx?actionStay=delete&orderStay=" + cRecId.ToString() + "&signatureStay=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#PrevStay'>Delete</a></td>";
                else
                    strStayRow2 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strStayRow2 += "</tr>";
            }


        }

    }

    protected void displayEducationList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        intStatus = OE.Employee_Access;
        ds = OE.GetEducationList(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;

        if (strEdAction != "edit")
            intEdRecId = 0;
        eRecId = intEdRecId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cRecId = i + 1;
            if (eRecId == cRecId)
            {
                txtUniversity.Text = ds.Tables[0].Rows[i]["University"].ToString();
                txtDegree.Text = ds.Tables[0].Rows[i]["Degree_Name"].ToString();
                ddMonth1.SelectedValue = ds.Tables[0].Rows[i]["FromMonth"].ToString();
                ddYear1.SelectedValue = ds.Tables[0].Rows[i]["FromYear"].ToString();
                ddMonth2.SelectedValue = ds.Tables[0].Rows[i]["ToMonth"].ToString();
                ddYear2.SelectedValue = ds.Tables[0].Rows[i]["ToYear"].ToString();
                ddYear3.SelectedValue = ds.Tables[0].Rows[i]["GradYear"].ToString();
            }
            else if (cRecId < eRecId || intEdRecId <= 0)
            {
                strEdRow1 += "<tr>";
                strEdRow1 += "<td>" + ds.Tables[0].Rows[i]["University"].ToString() + "</td>";
                strEdRow1 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strEdRow1 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strEdRow1 += "<td>" + ds.Tables[0].Rows[i]["GradYear"].ToString() + "</td>";
                strEdRow1 += "<td>" + ds.Tables[0].Rows[i]["Degree_Name"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strEdRow1 += "<td><a href='employee.aspx?actionEd=edit&orderEd=" + cRecId.ToString() + "&signatureEd=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee.aspx?actionEd=delete&orderEd=" + cRecId.ToString() + "&signatureEd=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Delete</a></td>";
                else
                    strEdRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strEdRow1 += "</tr>";
            }
            else
            {
                strEdRow2 += "<tr>";
                strEdRow2 += "<td>" + ds.Tables[0].Rows[i]["University"].ToString() + "</td>";
                strEdRow2 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strEdRow2 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strEdRow2 += "<td>" + ds.Tables[0].Rows[i]["GradYear"].ToString() + "</td>";
                strEdRow2 += "<td>" + ds.Tables[0].Rows[i]["Degree_Name"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strEdRow2 += "<td><a href='employee.aspx?actionEd=edit&orderEd=" + cRecId.ToString() + "&signatureEd=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Edit</a>&nbsp;&nbsp;<a href='employee.aspx?actionEd=delete&orderEd=" + cRecId.ToString() + "&signatureEd=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Delete</a></td>";
                else
                    strEdRow2 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strEdRow2 += "</tr>";
            }
        }
    }

    protected void displayExperienceList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        intStatus = OE.Employee_Access;
        ds = OE.GetProfession(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;

        if (strExpAction != "edit")
            intRecId = 0;
        eRecId = intExpRecId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cRecId = i + 1;
            if (eRecId == cRecId)
            {
                txtEmployer.Text = ds.Tables[0].Rows[i]["Employer"].ToString();
                ddExpMonth1.SelectedValue = ds.Tables[0].Rows[i]["FromMonth"].ToString();
                ddExpYear1.SelectedValue = ds.Tables[0].Rows[i]["FromYear"].ToString();
                ddExpMonth2.SelectedValue = ds.Tables[0].Rows[i]["ToMonth"].ToString();
                ddExpYear2.SelectedValue = ds.Tables[0].Rows[i]["ToYear"].ToString();
                txtExpSkills.Text = ds.Tables[0].Rows[i]["Skills"].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[i]["Designation"].ToString();
            }
            else if (cRecId < eRecId || intExpRecId <= 0)
            {
                strExpRow1 += "<tr>";
                strExpRow1 += "<td>" + ds.Tables[0].Rows[i]["Employer"].ToString() + "</td>";
                strExpRow1 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strExpRow1 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strExpRow1 += "<td>" + ds.Tables[0].Rows[i]["Skills"].ToString() + "</td>";
                strExpRow1 += "<td>" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>";
                if (OE.Employee_Access == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strExpRow1 += "<td><a href='employee.aspx?actionExp=edit&orderExp=" + cRecId.ToString() + "&signatureExp=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Experience'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee.aspx?actionExp=delete&orderExp=" + cRecId.ToString() + "&signatureExp=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Experience'>Delete</a></td>";
                else
                    strExpRow1 += "<td>&nbsp;</td>";
                strExpRow1 += "</tr>";
            }
            else
            {
                strExpRow2 += "<tr>";
                strExpRow2 += "<td>" + ds.Tables[0].Rows[i]["Employer"].ToString() + "</td>";
                strExpRow2 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strExpRow2 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strExpRow2 += "<td>" + ds.Tables[0].Rows[i]["Skills"].ToString() + "</td>";
                strExpRow2 += "<td>" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>";
                strExpRow2 += "<td><a href='employee.aspx?actionExp=edit&orderExp=" + cRecId.ToString() + "&signatureExp=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Experience'>Edit</a>&nbsp;&nbsp;<a href='employee.aspx?actionExp=delete&orderExp=" + cRecId.ToString() + "&signatureExp=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Experience'>Delete</a></td>";
                strExpRow2 += "</tr>";
            }


        }

    }

    protected void displayDependentList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee(intEmployeeId);

        ds = OE.GetDepentents(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;

        if (strDepAction != "edit")
            intDepRecId = 0;
        eRecId = intDepRecId;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            cRecId = i + 1;
            if (eRecId == cRecId)
            {
                //txtEmployer.Text = ds.Tables[0].Rows[i]["Employer"].ToString();
                txtLastName.Text = ds.Tables[0].Rows[i]["Last_Name"].ToString();
                txtFirstName.Text = ds.Tables[0].Rows[i]["First_Name"].ToString();
                txtMiddleName.Text = ds.Tables[0].Rows[i]["Middle_Name"].ToString();
                txtOtherName.Text = ds.Tables[0].Rows[i]["Other_Name"].ToString();
                txtDateofBirth0.Value = ds.Tables[0].Rows[i]["DateofBirht"].ToString();
                ddCountryofBirthDep.SelectedValue = ds.Tables[0].Rows[i]["CountryofBirth"].ToString();
                ddCountryofCitizensip.SelectedValue = ds.Tables[0].Rows[i]["CountryofCitizenship"].ToString();
                txtCountryPassportIssuance.SelectedValue = ds.Tables[0].Rows[i]["CountryPassportIssuance"].ToString();

                txtUSSocialSecurityNo.Text = ds.Tables[0].Rows[i]["USSocialSecurityNo"].ToString();
                txtANumber.Text = ds.Tables[0].Rows[i]["ANumber"].ToString();
                txtI94.Text = ds.Tables[0].Rows[i]["I94"].ToString();
                txtDateofFirstEntry0.Value = ds.Tables[0].Rows[i]["DateofFirstEntry"].ToString();
                txtDateofLastArrival0.Value = ds.Tables[0].Rows[i]["DateofLastArrival"].ToString();
                txtPassportNo.Text = ds.Tables[0].Rows[i]["PassportNo"].ToString();
                txtPassportIssueDate0.Value = ds.Tables[0].Rows[i]["PassportIssueDate"].ToString();
                txtPassportExpireDate.Value = ds.Tables[0].Rows[i]["PassportExpireDate"].ToString();
                txtCurrentNonimigrationStatus.Text = ds.Tables[0].Rows[i]["CurrentNonimigrationStatus"].ToString();
                txtDateStatusExpire.Text = ds.Tables[0].Rows[i]["DateStatusExpire"].ToString();

                txtForeignaddress.Text = ds.Tables[0].Rows[i]["Foreignaddress"].ToString();
                txtDaytimeTelephonenumber.Text = ds.Tables[0].Rows[i]["DaytimeTelephonenumber"].ToString();
                txtEmailaddress.Text = ds.Tables[0].Rows[i]["Emailaddress"].ToString();
                txtRelation.Text = ds.Tables[0].Rows[i]["Relation"].ToString();
                txtUSAddress.Text = ds.Tables[0].Rows[i]["USAddress"].ToString();
                panDisplay.Visible = true;

            }
            else
            {
                strDepRow1 += "<tr>";
                strDepRow1 += "<td>" + ds.Tables[0].Rows[i]["FULLNAME"].ToString() + "&nbsp;</td>";
                strDepRow1 += "<td>" + ds.Tables[0].Rows[i]["DateofBirht"].ToString() + "&nbsp;</td>";
                strDepRow1 += "<td>" + ds.Tables[0].Rows[i]["PassportNo"].ToString() + "&nbsp;</td>";
                strDepRow1 += "<td>" + ds.Tables[0].Rows[i]["Emailaddress"].ToString() + "&nbsp;</td>";
                if (OE.Employee_Access == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                    strDepRow1 += "<td><a href='employee.aspx?actionDep=edit&orderDep=" + cRecId.ToString() + "&signatureDep=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Dependent'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee.aspx?actionDep=delete&orderDep=" + cRecId.ToString() + "&signatureDep=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Dependent'>Delete</a></td>";
                else
                    strDepRow1 += "<td><a href='employee.aspx?actionDep=edit&orderDep=" + cRecId.ToString() + "&signatureDep=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>View</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strDepRow1 += "</tr>";
            }

        }
    }

    protected void btnVendorButton_Click(object sender, EventArgs e)
    {
        string strName = "";
        string strContactName = "";
        string strEmail = "";
        string strPhone = "";
        bool flag = false;
        strName = clrText(txtName.Text);
        strContactName = clrText(txtContactName.Text);
        strEmail = clrText(txtEmail.Text);
        strPhone = clrText(txtPhone.Text);
        AcglEmployee oE = new AcglEmployee();

        if (strAction == "edit")
        {
            if (!string.IsNullOrEmpty(strName))
            {
                flag = oE.UpdateVendor(intEmployeeId, strName, strContactName, strEmail, strPhone, strSignature);
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(strName))
            {
                flag = oE.AddVendor(intEmployeeId, strName, strContactName, strEmail, strPhone);
            }
        }
        if (flag)
        {
            txtName.Text = "";
            txtContactName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        Response.Redirect("employee.aspx#Vendor");
    }

    protected void btnPrevReceiptButton_Click(object sender, EventArgs e)
    {
        string strReceiptNo = "";
        string strEmpName = "";
        bool flag = false;
        strReceiptNo = clrText(txtReceiptNo.Text);
        strEmpName = clrText(txtReceiptEmpName.Text);
        AcglEmployee oE = new AcglEmployee();

        if (strPRAction == "edit")
        {
            if (!string.IsNullOrEmpty(strReceiptNo))
            {
                flag = oE.UpdatePrevReceipt(intEmployeeId, strReceiptNo, strEmpName, strPRSignature);
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(strReceiptNo))
            {
                flag = oE.AddPrevReceipt(intEmployeeId, strReceiptNo, strEmpName);
            }
        }
        if (flag)
        {
            txtReceiptNo.Text = "";
            txtReceiptEmpName.Text = "";
        }

        Response.Redirect("employee.aspx#PrevReceipt");
    }

    protected void btnPrevStayButton_Click(object sender, EventArgs e)
    {
        string strStatus = "";
        string strDateIn = "";
        string strDateOut = "";
        bool flag = false;
        strStatus = clrText(txtStayStatus.Text);
        strDateIn = clrText(txtStayDateIn.Value);
        strDateOut = clrText(txtStayDateOut.Value);
        AcglEmployee oE = new AcglEmployee();

        if (strStayAction == "edit")
        {
            if (!string.IsNullOrEmpty(strStatus) || !string.IsNullOrEmpty(strDateIn) || !string.IsNullOrEmpty(strDateOut))
            {
                flag = oE.UpdatePrevStay(intEmployeeId, strStatus, strDateIn, strDateOut, strStaySignature);
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(strStatus) || !string.IsNullOrEmpty(strDateIn) || !string.IsNullOrEmpty(strDateOut))
            {
                flag = oE.AddPrevStay(intEmployeeId, strStatus, strDateIn, strDateOut);
            }
        }
        if (flag)
        {
            txtStayStatus.Text = "";
            txtStayDateIn.Value = "";
            txtStayDateOut.Value = "";
        }

        Response.Redirect("employee.aspx#PrevStay");
    }

    protected void btnEducationButton_Click(object sender, EventArgs e)
    {
        string strUniversity = "";
        string strDegree = "";
        int intFromMonth = 0;
        int intFromYear = 0;
        int intToMonth = 0;
        int intToYear = 0;
        int intGradYear = 0;
        bool flag = false;
        strUniversity = clrText(txtUniversity.Text);
        strDegree = clrText(txtDegree.Text);
        intFromMonth = Convert.ToInt16(ddMonth1.SelectedValue);
        intToMonth = Convert.ToInt16(ddMonth2.SelectedValue);
        intFromYear = Convert.ToInt16(ddYear1.SelectedValue);
        intToYear = Convert.ToInt16(ddYear2.SelectedValue);
        intGradYear = Convert.ToInt16(ddYear3.SelectedValue);
        AcglEmployee oE = new AcglEmployee();

        if (strEdAction == "edit")
            flag = oE.UpdateEducation(intEmployeeId, strUniversity, intFromMonth, intFromYear, intToMonth, intToYear, intGradYear, strDegree, strEdSignature);
        else
            flag = oE.AddEducation(intEmployeeId, strUniversity, intFromMonth, intFromYear, intToMonth, intToYear, intGradYear, strDegree);
        if (flag)
        {
            txtUniversity.Text = "";
            txtDegree.Text = "";
            ddMonth1.SelectedIndex = 0;
            ddMonth2.SelectedIndex = 0;
            ddYear1.SelectedIndex = 0;
            ddYear2.SelectedIndex = 0;
            ddYear3.SelectedIndex = 0;

        }
        //displayList();
        Response.Redirect("employee.aspx#Education");
    }

    protected void btnExperienceButton_Click(object sender, EventArgs e)
    {
        string strEmployer = "";
        string strSkills = "";
        string strDesignation = "";
        int intFromMonth = 0;
        int intFromYear = 0;
        int intToMonth = 0;
        int intToYear = 0;
        bool flag = false;
        strEmployer = clrText(txtEmployer.Text);
        strSkills = clrText(txtExpSkills.Text);
        strDesignation = clrText(txtDesignation.Text);
        intFromMonth = Convert.ToInt16(ddExpMonth1.SelectedValue);
        intToMonth = Convert.ToInt16(ddExpMonth2.SelectedValue);
        intFromYear = Convert.ToInt16(ddExpYear1.SelectedValue);
        intToYear = Convert.ToInt16(ddExpYear2.SelectedValue);
        AcglEmployee oE = new AcglEmployee();

        if (strExpAction == "edit")
            flag = oE.UpdateProfession(intEmployeeId, strEmployer, strSkills, strDesignation, intFromMonth, intFromYear, intToMonth, intToYear, strExpSignature);
        else
            flag = oE.AddProfession(intEmployeeId, strEmployer, strSkills, strDesignation, intFromMonth, intFromYear, intToMonth, intToYear);
        if (flag)
        {
            txtEmployer.Text = "";
            txtExpSkills.Text = "";
            ddExpMonth1.SelectedIndex = 0;
            ddExpMonth2.SelectedIndex = 0;
            ddExpYear1.SelectedIndex = 0;
            ddExpYear2.SelectedIndex = 0;
            Response.Redirect("employee.aspx#Experience");
        }
    }

    protected void btnNewDependent_Click(object sender, EventArgs e)
    {
        displayLists();
        panDisplay.Visible = true;
        btnNewDependent.Visible = false;
        txtRelation.Focus();
    }

    protected void btnAddDependent_Click(object sender, EventArgs e)
    {
        bool flag = false;

        string Last_Name = clrText(txtLastName.Text);
        string First_Name = clrText(txtFirstName.Text);
        string Middle_Name = clrText(txtMiddleName.Text);
        string Other_Name = clrText(txtOtherName.Text);
        string DateofBirht = clrText(txtDateofBirth0.Value);
        string CountryofBirth = ddCountryofBirthDep.SelectedValue;
        string CountryofCitizenship = ddCountryofCitizensip.SelectedValue;
        string USSocialSecurityNo = clrText(txtUSSocialSecurityNo.Text);
        string ANumber = clrText(txtANumber.Text);
        string I94 = clrText(txtI94.Text);
        string DateofFirstEntry = clrText(txtDateofFirstEntry0.Value);
        string DateofLastArrival = clrText(txtDateofLastArrival0.Value);
        string PassportNo = clrText(txtPassportNo.Text);
        string PassportIssueDate = clrText(txtPassportIssueDate0.Value);
        string PassportExpireDate = clrText(txtPassportExpireDate.Value);
        string CurrentNonimigrationStatus = clrText(txtCurrentNonimigrationStatus.Text);
        string DateStatusExpire = clrText(txtDateStatusExpire.Text);
        string CountryPassportIssuance = clrText(txtCountryPassportIssuance.SelectedValue);
        string Foreignaddress = clrText(txtForeignaddress.Text);
        string DaytimeTelephonenumber = clrText(txtDaytimeTelephonenumber.Text);
        string Emailaddress = clrText(txtEmailaddress.Text);
        string Relation = clrText(txtRelation.Text);
        string USAddress = clrText(txtUSAddress.Text);

        AcglEmployee oE = new AcglEmployee();

        if (strDepAction == "edit")
        {
            flag = oE.UpdateDependent(intEmployeeId, Last_Name, First_Name, Middle_Name, Other_Name, DateofBirht, CountryofBirth, CountryofCitizenship, USSocialSecurityNo, ANumber, I94, DateofFirstEntry, DateofLastArrival, PassportNo, PassportIssueDate, PassportExpireDate, CurrentNonimigrationStatus, DateStatusExpire, CountryPassportIssuance, Foreignaddress, DaytimeTelephonenumber, Emailaddress, Relation, USAddress, strDepSignature);
        }
        else
            flag = oE.AddDependent(intEmployeeId, Last_Name, First_Name, Middle_Name, Other_Name, DateofBirht, CountryofBirth, CountryofCitizenship, USSocialSecurityNo, ANumber, I94, DateofFirstEntry, DateofLastArrival, PassportNo, PassportIssueDate, PassportExpireDate, CurrentNonimigrationStatus, DateStatusExpire, CountryPassportIssuance, Foreignaddress, DaytimeTelephonenumber, Emailaddress, Relation, USAddress);

        if (flag)
        {
            txtLastName.Text = "";
            txtFirstName.Text = ""; ;
            txtMiddleName.Text = "";
            txtOtherName.Text = "";
            txtDateofBirth.Value = "";
            ddCountryofBirthDep.SelectedValue = "";
            ddCountryofCitizensip.SelectedValue = "";
            txtUSSocialSecurityNo.Text = "";
            txtANumber.Text = "";
            txtI94.Text = "";
            txtDateofFirstEntry.Value = "";
            txtDateofLastArrival.Value = "";
            txtPassportNo.Text = "";
            txtPassportIssueDate0.Value = "";
            txtPassportExpireDate.Value = "";
            txtCurrentNonimigrationStatus.Text = "";
            txtDateStatusExpire.Text = "";
            txtCountryPassportIssuance.SelectedValue = "";
            txtForeignaddress.Text = "";
            txtDaytimeTelephonenumber.Text = "";
            txtEmailaddress.Text = "";
            txtRelation.Text = "";
            txtUSAddress.Text = "";
            Response.Redirect("employee.aspx#Dependent");
        }
    }
    protected void btnCancelDependent_Click(object sender, EventArgs e)
    {
        Response.Redirect("employee.aspx#Dependent");
    }

    protected string clrText(string strVal)
    {
        return strVal;
    }

    protected void fillMonths(DropDownList dd)
    {
        dd.Items.Add(new ListItem("Month", "0"));
        for (int i = 1; i <= 12; i++)
        {
            dd.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    protected void fillYears(DropDownList dd)
    {
        dd.Items.Add(new ListItem("Year", "0"));
        for (int i = 2010; i >= 1950; i--)
        {
            dd.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    protected string GetRunAtServerProperty()
    {
        return "runat=\"server\"";
    }
}



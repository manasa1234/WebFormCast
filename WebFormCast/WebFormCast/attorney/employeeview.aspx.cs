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
using System.Text;
public partial class attorney_employeeview : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    public string strRowEducation = "";
    public string strRowProfesnal = "";
    public string strDependents = "";
    public string strPRRow = "";
    public string strStayRow = "";
    public string strVendorRow = "";
    string strEmployeeSignature = "";
    int visaid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        //try
        //{
        //    intEmployeeId = Convert.ToInt16(Request["id"]);
        //}
        //catch
        //{
        //    intEmployeeId = 0;
        //}

        //try{
        //    strEmployeeSignature = Request["signature"].ToString();
        //}catch{}
        try
        {
            //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
        }
        catch
        { }
        try
        {
            intEmployeeId = Convert.ToInt16(Session["Attorney_Employee_Id"]);
            //strEmployeeSignature =Session["Attorney_Employee_Signature"].ToString();
        }
        catch { }
        try
        {

            lbtrackingno.Text = Session["Attorney_Employee_TrackingNo"].ToString();
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

        if (intEmployeeId <= 0)
            Response.Redirect("home.aspx");

        if (!IsPostBack)
        {
            string strQString = "";
       
            AcglGeneral objG = new AcglGeneral();
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strEmployeeSignature);
            
            lbNavigation.Text = objG.GetNavLinks("CASE");
            Initialize();
        }
        displayEducation(intEmployeeId);
        displayProffesionalInfo(intEmployeeId);
        displayDependents(intEmployeeId);
        displayPrevReceipts(intEmployeeId);
        displayPrevStay(intEmployeeId);
        displayVendors(intEmployeeId);
    }


    protected void Initialize()
    {
        AcglEmployee oE = new AcglEmployee(intEmployeeId);
        AcglGeneral objG = new AcglGeneral();
        clsAttorney OA = new clsAttorney(intAttorney_id);
        OA.bindCompanyCombo(ddEmployer, oE.Company_id); 

        txtFirst_Name.Text = oE.FirstName;
        txtLast_Name.Text = oE.LastName;
        txtMiddle_Name.Text = "";
        txtEmail_Address.Text = oE.Email;

        txtMiddle_Name.Text   = oE.MiddleName.ToString();
        txtOther_Name1.Text   = oE.OtherName1.ToString();
        txtOther_Name2.Text = oE.OtherName2.ToString();
        txtOther_Name3.Text = oE.OtherName3.ToString();

        txtTelNo.Text   = oE.TelNo.ToString();
        txtDateofBirth.Text = oE.DateofBirth.ToString();
        txtSocialSecurity.Text  = oE.SocialSecurity.ToString();
        txtANumber.Text  = oE.ANumber.ToString();
        txtStateofBirth.Text = oE.StateofBirth.ToString();
        ddCountryofBirth.Text =oE.CountryofBirth.ToString();
        ddCountryofCitixenship.Text  = oE.CountryofCitixenship.ToString();

        if (oE.Title == "Mr." || oE.Title == "Male" || oE.Title == "M")
        {
            rbGender.Text = "Male";
        }
        if (oE.Title == "Ms." || oE.Title == "Female" || oE.Title == "F"){
            rbGender.Text = "Female";
        }

        txtI94.Text  = oE.I94.ToString();
        txtDateofFirstEntry.Text = oE.DateofFirstEntry.ToString();
        txtDateofLastArrival.Text = oE.DateofLastArrival.ToString();
        txtPassportNumber.Text  = oE.PassportNumber.ToString();
        txtPassportissuedate.Text = oE.Passportissuedate.ToString();
        txtPassportExpiresDate.Text = oE.PassportExpiresDate.ToString();
        txtPassportIssueCountry.Text = oE.PassportIssueCountry.ToString();
        txtCNIStatus.Text = oE.CNIStatus.ToString();
        txtCNIDateStatusExpires.Text = oE.CNIDateStatusExpires.ToString();
        txtSevis.Text = oE.SevisNo.ToString();
        txtStdEADNo.Text = oE.StdEADNo.ToString();
        txtConsulateCityCountry.Text = oE.ConsulateCityCountry.ToString() + " / " + oE.ConsulateCityCountry1.ToString();
        txtForeignAddress.Text = oE.ForeignAddress_Street.ToString() + ", " + oE.ForeignAddress_AppNo.ToString() + ", " + oE.ForeignAddress_City.ToString() + ", " + oE.ForeignAddress_State.ToString() + "-" + oE.ForeignAddress_Country.ToString() + ", " + oE.ForeignAddress_Zip.ToString();    
        txtUSAddress.Text = oE.USAddress_Street.ToString() + ", " + oE.USAddress_AppNo.ToString() + ", " + oE.USAddress_City.ToString() + ", " + oE.USAddress_State.ToString() + ", " + oE.USAddress_Zip.ToString();    
        if (Convert.ToBoolean(oE.H1Bwithnpast7yrs.ToString()) == true)
            rbH1B1.Text = "Yes";
        else
            rbH1B1.Text = "No";

        if (Convert.ToBoolean(oE.H1Bwithnpast7yrs.ToString()) == true)
            rbDenied1.Text = "Yes";
        else
            rbDenied1.Text = "No";

        txtSkills.Text = oE.Skills.ToString();
        txtEC_JobTitle.Text = oE.EC_JobTitle.ToString();
        txtEC_Name.Text = oE.EC_Name.ToString();
        txtEC_Address.Text = oE.EC_Address.ToString();
        txtEC_MgrName.Text = oE.EC_MgrName.ToString();
        txtEC_Email.Text = oE.EC_Email.ToString();
        txtEC_Phone.Text = oE.EC_Phone.ToString();

        txtPERMDateFiled.Text = oE.PERM_DateFiled.ToString();
        txtPERM_CaseNo.Text = oE.PERM_CaseNo.ToString();
        txtI140_ReceiptNo.Text = oE.I140_ReceiptNo.ToString();
        txtPend_App_Type.Text = oE.Pend_App_Type.ToString();
        txtPend_App_ReceiptNo.Text = oE.Pend_App_ReceiptNo.ToString();

        txtLCANo.Text = oE.LCA_Case_Code;
        txtNAICS.Text = oE.NAICS_Code;
        txtOtherCompensation.Text = oE.Other_Compensation;
        if (oE.work_experience.Trim() == "")
        {
            txtWorkExperience.Text = oE.Title + " "  + oE.LastName + " has more than two(2) years of experience as " + oE.JobTitel + ".  The beneficiary is involved in " + oE.Skills + "  See attached letter in support of H1B filed by the Petitioner. See also, Beneficiary's resume and experience letters for a detailed description of the Beneficiary's prior work experience.";
        }
        else
            txtWorkExperience.Text = oE.work_experience;
        OA.bindJobTitleCombo(ddJobTitle, oE.JobTitleId);
        txtDateIntendedFrom.Value = oE.DateIntendedFrom;
        txtDateIntendedTo.Value = oE.DateIntendedTo;
        FulltimeYes.Checked = oE.isFulltime;
        FulltimeNo.Checked = !oE.isFulltime;
        txtHoursperWeek.Text = oE.Hours_per_week;
        txtWagsperYear.Text = oE.WagsperYear;
        txtWorkLocation.Text = oE.WorkLocation;

        if (oE.Status == 6)
            oE.UpdateStatus(intEmployeeId, 10);

        if (oE.Status == 6)
            lbStatus.Text = "New";
        else if (oE.Status == 10)
            lbStatus.Text = "In Review";
        else if (oE.Status == 11)
            lbStatus.Text = "Accepted";
        else if (oE.Status == 12)
            lbStatus.Text = "In Progress";
        else if (oE.Status == 15)
            lbStatus.Text ="Filed";


    }

    protected void displayEducation(int intEmployeeId)
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetEducationList(intEmployeeId);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strRowEducation += "<tr>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["University"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["GradYear"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["Degree_Name"].ToString() + "</td>";
            strRowEducation += "</tr>";
        }

    }

    protected void displayProffesionalInfo(int intEmployeeId)
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetProfession(intEmployeeId);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strRowProfesnal += "<tr>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["Employer"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["Skills"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>";
            strRowProfesnal += "</tr>";
        }

    }
    protected void displayDependents(int intEmployeeId)
    {

        StringBuilder SB = new StringBuilder();
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetDepentents(intEmployeeId);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            SB.AppendLine("<h5>DEPENDENT #:" + (i + 1) + "</h5><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Last Name</td><td>" + ds.Tables[0].Rows[i]["Last_Name"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">First Name</td><td>" + ds.Tables[0].Rows[i]["First_Name"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Middle Name</td><td>" + ds.Tables[0].Rows[i]["Middle_Name"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Other Names</td><td>" + ds.Tables[0].Rows[i]["Other_Name"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Date of Birth</td><td>" + ds.Tables[0].Rows[i]["DateofBirht"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Country of Birth</td><td>" + ds.Tables[0].Rows[i]["CountryofBirth"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Country of Citizenship</td><td>" + ds.Tables[0].Rows[i]["CountryofCitizenship"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">U.S. Social Security #</td><td>" + ds.Tables[0].Rows[i]["USSocialSecurityNo"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">'A' Number</td><td>" + ds.Tables[0].Rows[i]["ANumber"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">I-94 #</td><td>" + ds.Tables[0].Rows[i]["I94"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Date of First Entry in USA</td><td>" + ds.Tables[0].Rows[i]["DateofFirstEntry"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Date of Last Arrival in USA</td><td>" + ds.Tables[0].Rows[i]["DateofLastArrival"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Passport Number</td><td>" + ds.Tables[0].Rows[i]["PassportNo"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Passport Issue Date</td><td>" + ds.Tables[0].Rows[i]["PassportIssueDate"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Date Passport Expires</td><td>" + ds.Tables[0].Rows[i]["PassportExpireDate"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Current Nonimmigrant Status</td><td>" + ds.Tables[0].Rows[i]["CurrentNonimigrationStatus"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Date Status Expires</td><td>" + ds.Tables[0].Rows[i]["DateStatusExpire"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Country of Passport Issuance</td><td>" + ds.Tables[0].Rows[i]["CountryPassportIssuance"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Foreign address (as in passport)</td><td colspan=\"5\">" + ds.Tables[0].Rows[i]["Foreignaddress"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr>");
            SB.AppendLine("<tr>");
            SB.AppendLine("<td align=\"right\">Daytime Telephone number</td><td>" + ds.Tables[0].Rows[i]["DaytimeTelephonenumber"].ToString() + "&nbsp;</td>");
            SB.AppendLine("<td align=\"right\">Email address</td><td colspan=\"3\">" + ds.Tables[0].Rows[i]["Emailaddress"].ToString() + "&nbsp;</td>");
            SB.AppendLine("</tr></table><br>");
            strDependents = SB.ToString();

        }
    }

    protected void displayVendors(int intEmployeeId)
    {
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetVendorList(intEmployeeId);
        strVendorRow = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strVendorRow += "<tr>";
            strVendorRow += "<td>" + ds.Tables[0].Rows[i]["Name"].ToString() + "</td>";
            strVendorRow += "<td>" + ds.Tables[0].Rows[i]["Contact_Name"].ToString() + "</td>";
            strVendorRow += "<td>" + ds.Tables[0].Rows[i]["Email"].ToString() + "</td>";
            strVendorRow += "<td>" + ds.Tables[0].Rows[i]["Phone_Number"].ToString() + "</td>";
            strVendorRow += "</tr>";
        }
    }

    protected void displayPrevReceipts(int intEmployeeId)
    {
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetPrevReceiptList(intEmployeeId);
        strPRRow = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strPRRow += "<tr>";
            strPRRow += "<td>" + ds.Tables[0].Rows[i]["Receipt_No"].ToString() + "</td>";
            strPRRow += "<td>" + ds.Tables[0].Rows[i]["Employer_Name"].ToString() + "</td>";
            strPRRow += "</tr>";
        }        
    }

    protected void displayPrevStay(int intEmployeeId)
    {
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetPrevStayList(intEmployeeId);
        strStayRow = "";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strStayRow += "<tr>";
            strStayRow += "<td>" + ds.Tables[0].Rows[i]["Status"].ToString() + "</td>";
            strStayRow += "<td>" + ds.Tables[0].Rows[i]["DateIn"].ToString() + "</td>";
            strStayRow += "<td>" + ds.Tables[0].Rows[i]["DateOut"].ToString() + "</td>";
            strStayRow += "</tr>";
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      
    
    }


    protected string  clearText(string strtxt)
    {
        return strtxt; 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    protected void SaveData()
    {
        AcglGeneral OG = new AcglGeneral();
        AcglEmployee OE = new AcglEmployee();
        OE.UpdateAttorneyValues(intEmployeeId, Convert.ToInt16(ddJobTitle.SelectedValue), OG.ClrText(txtLCANo.Text), OG.ClrText(txtNAICS.Text), OG.ClrText(txtOtherCompensation.Text), OG.ClrText(txtWorkExperience.Text), OG.ClrText(txtDateIntendedFrom.Value), OG.ClrText(txtDateIntendedTo.Value), FulltimeYes.Checked, OG.ClrText(txtHoursperWeek.Text), OG.ClrText(txtWagsperYear.Text), OG.ClrText(txtWorkLocation.Text));
    }
    protected void btnSave_Click1(object sender, EventArgs e)
    {

    }

    protected bool CreateForm129H()
    {
       
        return true;

    }
    protected void btnAccept_Click(object sender, EventArgs e)
    {
        SaveData();
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        Company OC = new Company(OE.Company_id);
        clsAttorney OA = new clsAttorney(intAttorney_id);
        AcglGeneral OG = new AcglGeneral();
        Form_i129H OF = new Form_i129H(intEmployeeId);
        ACLGDataAaccess.ACLGDB OD = new ACLGDataAaccess.ACLGDB();
        bool Flag1 = false;
        bool Flag2 = false;
        bool Flag3 = false;
        bool Flag4 = false;
        bool Flag5 = false;
        bool Flag6 = false;
        bool Flag8 = false;
        bool Flag11 = false;
        bool Flag13 = false;
        bool Flag12 = false;
        bool FlagG28 = false;
        
        if (!OF.isApproved)
        {
            
            OD.ExeQuery("Insert into Form_I129H(Employee_id,CreatedDate,CreatedBy) values(" + intEmployeeId + ",getdate(),0)");
        }

        OF.f1_CompanyName = OC.Legal_Name;
        OF.f1_CompanyPhone_Code = OC.Phone_No_Code;
        OF.f1_CompanyPhone = OC.Phone_No;
        OF.f1_CompanyStreet = OC.Add_Street;
        OF.f1_CompanySuite = OC.Add_AptNo;
        OF.f1_CompanyCity = OC.Add_City;
        OF.f1_CompanyState = OC.Add_State;
        OF.f1_CompanyZip = OC.Add_Zip;
        OF.f1_CompanyCountry = "USA";
        OF.f1_CompanyInCareOf = OC.Person_FullName;
        OF.f1_CompanyEmail = OA.Email;
        OF.f1_CompanyFederalIdentification = OC.EIN_Number;    // ********************
        OF.f1_ComapnySocialSecurity = OC.SocialSecurity;
        OF.f1_CompanyIndividualTax = OC.IndividualTax;
        OF.f1_ATTY_State_License = OA.AttyStateLicense;
        Flag1 = OF.Form_01_Update(intEmployeeId);

        OF.f2_RequestedNonimmigrantClassification = "H-1B";
        
        
        if(OE.Visa_Type_id==1)
            OF.f2_BasisforClassification = 1;
        else if(OE.Visa_Type_id==2)
            OF.f2_BasisforClassification = 5;
        else if (OE.Visa_Type_id == 3)
            OF.f2_BasisforClassification = 2;


        OF.f2_receipt_number = OE.PrevReceiptNo;
        OF.f2_Prior_Petition = OE.PrevReceiptNo;
        
        if (OE.Visa_Type_id == 1)
            OF.f2_RequestedAction = 1;
        else if (OE.Visa_Type_id == 2 || OE.Visa_Type_id == 3)
            OF.f2_RequestedAction = 3;

        OF.f2_Totalnumberofworkersinpetition = "1";
        Flag2 = OF.Form_02_Update(intEmployeeId);

        OF.f3_Last_Name = OG.Capitilaze(OE.LastName);
        OF.f3_First_Name = OG.Capitilaze(OE.FirstName);
        OF.f3_Middle_Name = OG.Capitilaze(OE.MiddleName);
        OF.f3_Other_Name1 = OG.Capitilaze(OE.OtherName1);
        OF.f3_Other_Name2 = OG.Capitilaze(OE.OtherName2);
        OF.f3_Other_Name3 = OG.Capitilaze(OE.OtherName3);
        OF.f3_Date_of_Birth = OE.DateofBirth;
        OF.f3_US_Social_Security = OE.SocialSecurity;
        OF.f3_Anumber = OE.ANumber;
        OF.f3_Country_of_Birth = OE.CountryofBirth;
        OF.f3_Province_of_Birth = OE.StateofBirth;
        OF.f3_Country_of_Citizenship = OE.CountryofCitixenship;
        OF.f3_Date_of_Last_Arrival = OE.DateofLastArrival;
        OF.f3_I94 = OE.I94;
        
        OF.f3_Current_Nonimmigrant_Status = OE.CNIStatus;
        OF.f3_Date_Status_Expires = OE.CNIDateStatusExpires;
        OF.f3_Passport_Number = OE.PassportNumber;
        OF.f3_Date_Passport_Issued = OE.Passportissuedate;
        OF.f3_Date_Passport_Expires = OE.PassportExpiresDate;
        OF.f3_Current_US_Address =  OE.USAddress_AppNo +  ", "  +  OE.USAddress_Street + ", " + OE.USAddress_City + ", " + OE.USAddress_State + ", " + OE.USAddress_Zip;
        Flag3 = OF.Form_03_Update(intEmployeeId);

        OF.f4_Type_of_Office = 1;
        OF.f4_Office_Address = OE.ConsulateCityCountry;
        OF.f4_US_State_or_Foreign_Country = OE.ConsulateCityCountry1;
        OF.f4_Persons_Foreign_Address = OE.ForeignAddress_Street + ", " + OE.ForeignAddress_AppNo + ", " + OE.ForeignAddress_City + ", " + OE.ForeignAddress_State + "," + OE.ForeignAddress_Country + ", " + OE.ForeignAddress_Zip;   

        OF.f4_Have_a_valid_passpor = 3;
        OF.f4_Anyother_petitions = false;
        OF.f4_Anyother_petitions_HowMany = "";
        OF.f4_Are_applications_for_replacement = false;
        OF.f4_Are_applications_for_replacement_howmany = "";

        if (OE.Visa_Type_id == 1)
        {
            OF.f4_dependents_being_filed = false;
            OF.f4_dependents_being_filed_HowMany = "";
        }
        else
        {
            if (OE.Dependents ==false)
            {
                OF.f4_dependents_being_filed = false;
                OF.f4_dependents_being_filed_HowMany = "";
            }
            else
            {
                OF.f4_dependents_being_filed = true;
                OF.f4_dependents_being_filed_HowMany = OE.DependentsCount.ToString();
            }
        }


        OF.f4_Removal_proceedings = false;
        OF.f4_Have_you_ever_filed_an_immigrant_petition = false;

        if (OE.Visa_Type_id == 1)
            OF.f4_Thepast_seven_years1 = false;
        else
            OF.f4_Thepast_seven_years1 = true;
       
        OF.f4_Thepast_seven_years2 = false;
        
        OF.f4_Ever_previously_filed_a_petition_for_this_perso = false;
        OF.f4_If_you_are_filing_for_an_entertainment_group = false;
        Flag4 = OF.Form_04_Update(intEmployeeId);
        
        OF.f5_Job_Title = OE.JobTitel;
        OF.f5_Nontechnical_Job_Description = ""; // *********************************************
        OF.f5_LCA_Case_Number = OE.LCA_Case_Code;
        OF.f5_NAICS_Code = OE.NAICS_Code;
        if (OE.WorkLocation.Trim() == "")
            OF.f5_different_from_address = "Same as in Part 1";
        else
            OF.f5_different_from_address = OE.WorkLocation;

        OF.f5_Is_this_a_fulltime_position = OE.isFulltime;

        if (OE.isFulltime)
            OF.f5_Wages_per_week_Year = OE.WagsperYear;
        else
            OF.f5_Hours_per_week = OE.Hours_per_week;

        OF.f5_Nontechnical_Job_Description = OE.NT_Job_Description;
        OF.f5_Other_Compensation = OE.Other_Compensation;
        OF.f5_Dates_of_intended_employment1 = OE.DateIntendedFrom;
        OF.f5_Dates_of_intended_employment2 = OE.DateIntendedTo;
        OF.f5_Type_of_Petitioner = 2;
        OF.f5_Type_of_Business = OC.Description;
        OF.f5_Year_Established = OC.Registered_Date; // **************************** OC.Registration_Date; 
        OF.f5_Current_Number_of_Employees = OC.NoofEmployees.ToString();
        OF.f5_Gross_Annual_Income = OC.LastYearIncome; // ***********************
        OF.f5_Net_Annual_Income = OC.LastYearNetIncome; // ******************************
        Flag5 = OF.Form_05_Update(intEmployeeId);

        OF.f6_Daytime_Phone_Number1 = OC.Phone_No;
        OF.f6_Daytime_Phone_Number1_Code = OC.Phone_No_Code;
        OF.f6_Print_Name1 = OC.Person_FullName;

        OF.f6_Print_Name2 = OA.Name;
        OF.f6_Daytime_Phone_Number2 = OA.Phone;
        OF.f6_Daytime_Phone_Number2_Code = OA.Phone_Code;
        OF.f6_Firm_Name_and_Address = OA.Firm_Name + System.Environment.NewLine + OA.Street + ", " + OA.Suite + System.Environment.NewLine + OA.City + ", " + OA.State + " " + OA.Zip; 
        Flag6 = OF.Form_06_Update(intEmployeeId);

        OF.f8_Name_of_organization_filing_petition = OC.Legal_Name;
        OF.f8_Name_of_person = OE.LastName.ToUpper() + ", " + OG.Capitilaze(OE.FirstName) + " " + OG.Capitilaze(OE.MiddleName);
        OF.f8_Classification_sought = 1;
        

        OF.f8_Describe_the_proposed_duties = OE.NT_Job_Description;
        OF.f8_Aliens_present_occupation = OG.ClrText(OE.work_experience);
        OF.f8_Print_or_Type_Name1 = OC.Person_FullName;
        OF.f8_Print_or_Type_Name2 = OC.Person_FullName;


        if (OE.Visa_Type_id == 2 || OE.Visa_Type_id == 3)
        {
            
            DataSet ds = new DataSet();
            AcglEmployee OE1 = new AcglEmployee();
            ds = OE1.GetDepentents(intEmployeeId);
            OE1 = null; 
            string strSubjectName = "";
            strSubjectName = OE.LastName.ToUpper() + ", " + OG.Capitilaze(OE.FirstName) + " " + OG.Capitilaze(OE.MiddleName);

            if (OE.DateIn4 != "")
            {
                OF.f8_Period_From1 = OE.DateIn4;
                OF.f8_Period_To1 = OE.DateOut4;
            }
            else if (OE.DateIn3 != "")
            {
                OF.f8_Period_From1 = OE.DateIn3;
                OF.f8_Period_To1 = OE.DateOut3;
            }
            else if (OE.DateIn2 != "")
            {
                OF.f8_Period_From1 = OE.DateIn2;
                OF.f8_Period_To1 = OE.DateOut2;
            }
            else if (OE.DateIn1 != "")
            {
                OF.f8_Period_From1 = OE.DateIn1;
                OF.f8_Period_To1 = OE.DateOut1;
            }
            
            OF.f8_SubjectsName1 = strSubjectName;
            
            if(ds.Tables[0].Rows.Count>0)
            {
                strSubjectName = "";
                strSubjectName = OG.Capitilaze(ds.Tables[0].Rows[0]["Last_Name"].ToString());
                strSubjectName += ", " + ds.Tables[0].Rows[0]["First_Name"].ToString();
                strSubjectName += " " + ds.Tables[0].Rows[0]["Middle_Name"].ToString();

                OF.f8_SubjectsName2 = strSubjectName;
                OF.f8_Period_From2 = ds.Tables[0].Rows[0]["DateofLastArrival"].ToString();
                OF.f8_Period_To1 = "present";

            }

            if (ds.Tables[0].Rows.Count > 1)
            {
                strSubjectName = "";
                strSubjectName = OG.Capitilaze(ds.Tables[0].Rows[1]["Last_Name"].ToString());
                strSubjectName += ", " + ds.Tables[0].Rows[1]["First_Name"].ToString();
                strSubjectName += " " + ds.Tables[0].Rows[1]["Middle_Name"].ToString();
                OF.f8_SubjectsName3 = strSubjectName;
                OF.f8_Period_From3 = ds.Tables[0].Rows[1]["DateofLastArrival"].ToString();
                OF.f8_Period_To3 = "present";

            }

            if (ds.Tables[0].Rows.Count > 2)
            {
                strSubjectName = "";
                strSubjectName = OG.Capitilaze(ds.Tables[0].Rows[2]["Last_Name"].ToString());
                strSubjectName += ", " + ds.Tables[0].Rows[2]["First_Name"].ToString();
                strSubjectName += " " + ds.Tables[0].Rows[2]["Middle_Name"].ToString();
                OF.f8_SubjectsName4 = strSubjectName;
                OF.f8_Period_From4 = ds.Tables[0].Rows[2]["DateofLastArrival"].ToString();
                OF.f8_Period_To4 = "present";
            }
            
        }

        

        Flag8 = OF.Form_08_Update(intEmployeeId);

        OF.f11_Petitioners_Name = OC.Legal_Name;
        OF.f11_Is_the_petitioner_a_dependent_employer = true;
        OF.f11_found_to_be_a_willful_violator = false;
        
        string  strSal = "";
        strSal = OE.WagsperYear;
        strSal = strSal.Replace("$", "");
        strSal = strSal.Replace(".00", "");
        strSal = strSal.Replace(".", "");
        strSal = strSal.Replace(",", "");
        OF.f11_BeneficiaryAnnualMaster= OF.f11_Highest_Level_of_Education == 6;
        if(strSal!="")
            OF.f11_exempt_H1B_nonimmigrant2 = (Convert.ToInt32(strSal) >= 60000);
        OF.f11_exempt_H1B_nonimmigrant1 = (OF.f11_BeneficiaryAnnualMaster || OF.f11_exempt_H1B_nonimmigrant2); 
        OF.f11_Beneficiarys_Last_Name = OG.Capitilaze(OE.LastName);
        OF.f11_First_Name = OG.Capitilaze(OE.FirstName);
        OF.f11_Middle_Name = OG.Capitilaze(OE.MiddleName);

        if (OE.CurrentAddress == 2)
        {
            OF.f11_Current_Street_Number_and_Name = OE.USAddress_Street ; // **************************************
            OF.f11_AptNo = OE.USAddress_AppNo;
            OF.f11_City = OE.USAddress_City;
            OF.f11_State = OE.USAddress_State;
            OF.f11_Zip = OE.USAddress_Zip;
        }
        else if (OE.CurrentAddress == 1)
        {
            OF.f11_Current_Street_Number_and_Name = OE.ForeignAddress_Street;// OE.ForeignAddress;
            OF.f11_AptNo = OE.ForeignAddress_AppNo;
            OF.f11_City = OE.ForeignAddress_City;
            OF.f11_State = OE.ForeignAddress_State + " " + OE.ForeignAddress_Country;
            OF.f11_Zip = OE.ForeignAddress_Zip;
        }

        if (OE.SocialSecurity.Trim() != "")
            OF.f11_Social_Security = OE.SocialSecurity;
        else
            OF.f11_Social_Security = "None";
        OF.f11_I94 = OE.I94;
        OF.f11_Previous_Receipt = OE.PrevReceiptNo;
        OF.f11_Highest_Level_of_Education = OE.HighestLeve;
        OF.f11_Primary_Field_of_Study = OE.PrimaryFieldofStudy;
        OF.f11_higher_degree_from_a_US = !OE.MasterDegreeFromUS;
        OF.f11_Name_of_the_US_institution = OE.USInstitutionName;
        OF.f11_Date_Degree_Awarded = OE.USDateDegreeAwarded;
        OF.f11_Type_of_US_Degree = OE.USDegreeType;
        OF.f11_Address_of_the_US_institution = OE.USInstitutionAddress;
        OF.f11_Rate_of_Pay_Per_Year = OE.WagsperYear;
        OF.f11_LCA_Code = "030";
        OF.f11_NAICS_Code = OE.NAICS_Code;
        Flag11 = OF.Form_11_Update(intEmployeeId);

        OF.f12_Fee_Exemption_1 = false;
        OF.f12_Fee_Exemption_2 = false;
        OF.f12_Fee_Exemption_3 = false;
        OF.f12_Fee_Exemption_4 = false;
        OF.f12_Fee_Exemption_5 = false;
        OF.f12_Fee_Exemption_6 = false;
        OF.f12_Fee_Exemption_7 = false;
        OF.f12_Fee_Exemption_8 = false;

        if (OC.NoofEmployees <= 25)
            OF.f12_Fee_Exemption_9 = true;
        else
            OF.f12_Fee_Exemption_9 = false;
        OF.f12_Numerical_Limitation_1 = false;
        OF.f12_Numerical_Limitation_2 = false;
        OF.f12_Numerical_Limitation_3 = false;
        OF.f12_Numerical_Limitation_4 = false;
        OF.f12_Numerical_Limitation_5 = false;
        OF.f12_Numerical_Limitation_6 = false;
        OF.f12_Numerical_Limitation_7 = false;
        Flag12 = OF.Form_12_Update(intEmployeeId);

        OF.f13_Print_Name = OC.Person_FullName;
        OF.f13_Title = OC.Person_Designation;
        Flag13 = OF.Form_13_Update(intEmployeeId);
      

        if (Flag1 && Flag2 && Flag3 && Flag4 && Flag5 && Flag6 && Flag8 && Flag11 && Flag12 && Flag13)
        {
            lbFillStatus.Text = "Form I129H Filling Completed Successfully.";
            lbFillStatus.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lbFillStatus.Text = "Form I129H Filling Completed with Errors.";
            lbFillStatus.ForeColor = System.Drawing.Color.Red;
        }


        Form_G28 FG = new Form_G28(intEmployeeId);
        if (!FG.isApproved)
        {

            OD.ExeQuery("Insert into Form_G28(Employee_id) values(" + intEmployeeId + ")");
        }
        FG.InRe = OE.LastName.ToUpper() + ", " + OG.Capitilaze(OE.FirstName) + " " + OG.Capitilaze(OE.MiddleName);
        FG.Name1 = OC.Legal_Name;
        FG.NameType1 = "1";
        FG.Street1 = OC.Add_Street;
        FG.AptNo1 = OC.Add_AptNo;
        FG.City1 = OC.Add_City;
        FG.State1 = OC.Add_State;
        FG.Zip1 = OC.Add_Zip;
        FG.AttorneyFirmNameAddress = OA.Firm_Name + System.Environment.NewLine + OA.Street + ", " + OA.Suite + System.Environment.NewLine + OA.City + ", " + OA.State + " " + OA.Zip; 
        FG.AttorneyName = OA.Name;
        FG.AttorneyPhone = OA.Phone_Code + " " + OA.Phone;
        FG.AttorneyName2 = OA.Name;
        FG.Form129Name = "In RE " + OE.LastName.ToUpper()  + ", " + OG.Capitilaze(OE.FirstName) + " " + OG.Capitilaze(OE.MiddleName)  + " ; Form I-129";
        FG.CompanyPersonName = OC.Person_FullName;
        FlagG28 = FG.Form_G28_Update(intEmployeeId);

        if (FlagG28)
        {
            lbFillStatus.Text += "<br>Form G28 Filling Completed Successfully.";
            lbFillStatus.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lbFillStatus.Text += "<br>Form G28 Filling Completed with Errors.";
            lbFillStatus.ForeColor = System.Drawing.Color.Red;
        }




    }
    protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {

        int intCompanyId = 0;
        intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
        setCompanyId(intCompanyId);
        Response.Redirect("cases.aspx");
    }
    protected void setCompanyId(int intCompanyId)
    {
        Session["ACompany_Id"] = intCompanyId;
        HttpCookie myCookie = new HttpCookie("Attorney");
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
}

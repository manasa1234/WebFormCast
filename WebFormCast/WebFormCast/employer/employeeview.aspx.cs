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
using System.Text;
using WebFormCast.ACLG;

public partial class employer_employeeview : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intCompanyId = 0;
    string strEmployeeSignature = "";
    public string strRowEducation = "";
    public string strRowProfesnal = "";
    public string strDependents = "";
    public string strPRRow = "";
    public string strStayRow = "";
    public string strVendorRow = "";

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
        }
        catch
        {
            intEmployeeId = 0;
        }

        try
        {
            strEmployeeSignature = Request["signature"].ToString();
        }
        catch { }


        if (!IsPostBack)
        {
        
            Initialize();
        }
        displayEducation(intEmployeeId);
        displayProffesionalInfo(intEmployeeId);
        displayDependents(intEmployeeId);
        displayPrevReceipts(intEmployeeId);
        displayPrevStay(intEmployeeId);
        displayVendors(intEmployeeId);
        try
        {
            lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Company_Person_Name"].ToString();
        }
        catch
        { }
        
    }

    protected void Initialize()
    {
        AcglEmployee oE = new AcglEmployee(intEmployeeId);
        AcglGeneral objG = new AcglGeneral();
        Company objCompany = new Company(intCompanyId);
        clsAttorney OA = new clsAttorney(objCompany.AttorneyId);
        OA.bindJobTitleCombo(ddJobTitle, oE.JobTitleId);

        if (oE.Status == 3)
        {
            oE.UpdateStatus(intEmployeeId, 4);
        }
        lbName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName + " - " + oE.TrackingNo;

        txtFirst_Name.Text = oE.FirstName;
        txtLast_Name.Text = oE.LastName;
        txtMiddle_Name.Text = "";
        txtEmail_Address.Text = oE.Email;

        txtMiddle_Name.Text = oE.MiddleName.ToString();
        txtOther_Name1.Text = oE.OtherName1.ToString();
        txtOther_Name2.Text = oE.OtherName2.ToString();
        txtOther_Name3.Text = oE.OtherName3.ToString();

        txtTelNo.Text = oE.TelNo.ToString();
        txtDateofBirth.Text = oE.DateofBirth.ToString();
        txtSocialSecurity.Text = oE.SocialSecurity.ToString();
        txtANumber.Text = oE.ANumber.ToString();
        txtStateofBirth.Text = oE.StateofBirth.ToString();
        ddCountryofBirth.Text = oE.CountryofBirth.ToString();
        ddCountryofCitixenship.Text = oE.CountryofCitixenship.ToString();

        if (oE.Title == "Mr." || oE.Title == "Male" || oE.Title == "M")
        {
            rbGender.Text = "Male";
        }
        if (oE.Title == "Ms." || oE.Title == "Female" || oE.Title == "F")
        {
            rbGender.Text = "Female";
        }

        txtI94.Text = oE.I94.ToString();
        txtDateofFirstEntry.Text = oE.DateofFirstEntry.ToString();
        txtDateofLastArrival.Text = oE.DateofLastArrival.ToString();
        txtPassportNumber.Text = oE.PassportNumber.ToString();
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
        txtDateIntendedFrom.Value = oE.DateIntendedFrom;
        txtDateIntendedTo.Value = oE.DateIntendedTo;
        FulltimeYes.Checked = oE.isFulltime;
        FulltimeNo.Checked = !oE.isFulltime;
        txtHoursperWeek.Text = oE.Hours_per_week;
        txtWagsperYear.Text = oE.WagsperYear;
        txtWorkLocation.Text = oE.WorkLocation;

        if (oE.Status == 4 || oE.CaseOwner==1)
        {
            btnApprove.Enabled = true;
        }
        else
        {
            btnApprove.Enabled = false;
        }

        if (oE.Status < 6)
            btnSubmit.Enabled = true;
        else
            btnSubmit.Enabled = false;

        if(oE.Status==5)
            lbStatus.Text = "Approved"; 
        else
            lbStatus.Text = oE.StatusText; 

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
    protected string clearText(string strtxt)
    {
        return strtxt;
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        AcglGeneral OG = new AcglGeneral();
        OE.UpdateEmployment(intEmployeeId, Convert.ToInt32(ddJobTitle.SelectedValue), OG.ClrText(txtDateIntendedFrom.Value), OG.ClrText(txtDateIntendedTo.Value), FulltimeYes.Checked, OG.ClrText(txtHoursperWeek.Text), OG.ClrText(txtWagsperYear.Text), OG.ClrText(txtWorkLocation.Text));
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        bool flag = false;
        AcglEmployee OE = new AcglEmployee();
        flag = OE.ApproveCaseAndSubmite(intEmployeeId, intCompanyId);
        flag = OE.UpdateStatus(intEmployeeId, 5);
        if (flag)
            Response.Redirect("employeeview.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "#a");

    }

}

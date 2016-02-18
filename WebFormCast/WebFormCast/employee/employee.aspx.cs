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

public partial class employee : System.Web.UI.Page
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

    int intStatus = 0;
    public string strScript = "";
    int intEmployeeId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            intEmployeeId = Convert.ToInt16(Session["Employee_id"]);
        }
        catch
        {
            intEmployeeId = 0;
        }
        if (intEmployeeId <= 0)
        {
            Response.Redirect("index.aspx");
        }
        try
        {
            strAction = Request["action"] == null? "" : Request["action"].ToString();
            strPRAction = Request["actionPR"] == null ? "" : Request["actionPR"].ToString();
            strStayAction = Request["actionStay"] == null ? "" : Request["actionStay"].ToString();
            intRecId = Request["order"] == null ? 0 : Convert.ToInt16(Request["order"]);
            intPRRecId = Request["orderPR"] == null ? 0 : Convert.ToInt16(Request["orderPR"]);
            intStayRecId = Request["orderStay"] == null ? 0 : Convert.ToInt16(Request["orderStay"]);
            strSignature = Request["signature"] == null ? "" : Request["signature"].ToString();
            strPRSignature = Request["signaturePR"] == null ? "" : Request["signaturePR"].ToString();
            strStaySignature = Request["signatureStay"] == null ? "" : Request["signatureStay"].ToString();
        }
        catch { }

        if (!IsPostBack)
        {

            if (strAction == "delete" || strPRAction == "delete" || strStayAction == "delete")
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
            }
            Initialize();
            displayLists();
        }
    }

    protected void Initialize()
    {
        AcglEmployee oE = new AcglEmployee(intEmployeeId);
        AcglGeneral objG = new AcglGeneral();


        if (oE.Status == 1)
        {
            oE.UpdateStatus(intEmployeeId, 2);
        }

        //if (oE.Visa_Type_id == 1)
        //{
        //    tbDependent.Visible = false;
        //    divDependent.Visible = false;
        //}

        txtFirst_Name.Text = oE.FirstName;
        txtLast_Name.Text = oE.LastName;
        txtMiddle_Name.Text = "";
        txtEmail_Address.Text = oE.Email;

        lbName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName;
        lbUserName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName;

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
        txtOther_Name1.Text   = oE.OtherName1.ToString();
        txtOther_Name2.Text = oE.OtherName2.ToString();
        txtOther_Name3.Text = oE.OtherName3.ToString();
        txtTelNo.Text   = oE.TelNo.ToString();
        txtDateofBirth.Value  = oE.DateofBirth.ToString();
        txtSocialSecurity.Text  = oE.SocialSecurity.ToString();
        txtANumber.Text  = oE.ANumber.ToString();
        txtStateofBirth.Text = oE.StateofBirth.ToString();
        objG.bindCountryCombo(ddCountryofBirth,oE.CountryofBirth.ToString());
        objG.bindCountryCombo(ddCountryofCitixenship, oE.CountryofCitixenship.ToString());

        txtI94.Text  = oE.I94.ToString();
        txtDateofFirstEntry.Value   = oE.DateofFirstEntry.ToString();
        txtDateofLastArrival.Value   = oE.DateofLastArrival.ToString();
        txtPassportNumber.Text  = oE.PassportNumber.ToString();
        txtPassportissuedate.Value   = oE.Passportissuedate.ToString();
        txtPassportExpiresDate.Value   = oE.PassportExpiresDate.ToString();
        txtPassportIssueCountry.Text = oE.PassportIssueCountry.ToString();
        txtCNIStatus.Text  = oE.CNIStatus.ToString();
        txtSevisNo.Text = oE.SevisNo.ToString();
        txtStdEADNo.Text = oE.StdEADNo.ToString();

        txtCNIDateStatusExpires.Value   = oE.CNIDateStatusExpires.ToString();
        txtConsulateCityCountry.Text  = oE.ConsulateCityCountry.ToString();
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
        txtSkills.Text  = oE.Skills.ToString();
        
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
        //if (oE.Status < 5)
        //    btnFinalize.Enabled = true;
        //else
        //{
        //    btnFinalize.Enabled = false;
        //}

        if(oE.Employee_Access == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
            btnSubmit.Enabled = true;
        else
            btnSubmit.Enabled = false;
        lbStatus.Text = oE.StatusText;
        intStatus = oE.Employee_Access;

        Company OC = new Company(oE.Company_id);
        lbCompanyLogoText.Text = OC.Legal_Name;       

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
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
        oE.UpdateInitialQuestions(intEmployeeId, (rbUsResident1.Checked ? "Y" : "N"), (rbThirdParty1.Checked ? "Y" : "N")
            , (rbPremiumFee1.Checked ? "Y" : "N")
            , (rbEmpRelated1.Checked ? "Y" : "N")
            , (rbFileDependents1.Checked ? "Y" : "N")
            , (rbPrevEmployed1.Checked ? "Y" : "N")
            );
        oE.Update1Employee(intEmployeeId,
            clearText(txtFirst_Name.Text),
            clearText(txtLast_Name.Text),
            clearText(txtMiddle_Name.Text),
            clearText(txtOther_Name1.Text),
            clearText(txtOther_Name2.Text),
            clearText(txtOther_Name3.Text),
            clearText(txtTelNo.Text),
            clearText(txtDateofBirth.Value ),
            clearText(txtSocialSecurity.Text),
            clearText(txtANumber.Text),
            clearText(ddCountryofBirth.SelectedValue),
            clearText(txtStateofBirth.Text),
            clearText(ddCountryofCitixenship.Text),
            clearText(txtI94.Text),
            clearText(txtDateofFirstEntry.Value ),
            clearText(txtDateofLastArrival.Value ),
            clearText(txtPassportNumber.Text),
            clearText(txtPassportissuedate.Value ),
            clearText(txtPassportExpiresDate.Value ),
            clearText(txtCNIStatus.Text),
            clearText(txtCNIDateStatusExpires.Value ),
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
        Session["Attorney_Msg"] = "Personal information saved successfully";
        Response.Redirect("employee2.aspx");
    
    }


    protected string  clearText(string strtxt)
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
            tbDependent.Visible = true;
            tbPart1USInfo.Visible = true;
            rbFileDependents1.Enabled = true;
            rbFileDependents2.Enabled = true;
            if (rbFileDependents2.Checked)
            {
                tbDependent.Visible = false;
            }
        }
        if (rbUsResident2.Checked)
        {
            tbDependent.Visible = false;
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
            tbDependent.Visible = true;
        }
        if (rbFileDependents2.Checked)
        {
            tbDependent.Visible = false;
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
            tbEmployment.Visible = true;
        }
        if (rbPrevEmployed2.Checked)
        {
            tbEmployment.Visible = false;
        }
    }

    protected void displayLists()
    {
        displayVendorList();
        displayPrevReceiptList();
        displayPrevStayList();
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
    
    protected string clrText(string strVal)
    {
        return strVal;
    }

    protected string GetRunAtServerProperty()
    {
        return "runat=\"server\"";
    }

}

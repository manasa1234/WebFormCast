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

public partial class employee_employee4 : System.Web.UI.Page
{
    public string strRow1 = "";
    public string strRow2 = "";
    int intEmployeeId = 0;
    string strAction = "";
    int intRecId = 0;
    string strSignature = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        panDisplay.Visible = false;
        btnButton.Visible =true ;
        //btnCancel.Visible =true ;
        try
        {
            intEmployeeId = Convert.ToInt16(Session["Employee_id"]);
        }
        catch
        {
            intEmployeeId = 0;
        }
        //intEmployeeId = 1;

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
        if (intEmployeeId <= 0)
        {
            Response.Redirect("index.aspx");
        }
        if (!IsPostBack)
        {

            AcglEmployee OE = new AcglEmployee();
            if (strAction == "delete")
            {
                
                OE.DeleteDependant(intEmployeeId, strSignature);
                Response.Redirect("employee4.aspx");
            }
            AcglGeneral OG = new AcglGeneral();

            OG.bindCountryCombo(ddCountryofBirht, "");
            OG.bindCountryCombo(txtCountryPassportIssuance, "");
            OG.bindCountryCombo(ddCountryofCitizensip, ""); 
            //Initialize();
            displayList();
        }
        
    }

    protected void displayList()
    {

        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        lbUserName.Text = OE.LastName + " " + OE.FirstName + " " + OE.MiddleName;
        lbName.Text = OE.LastName + " " + OE.FirstName + " " + OE.MiddleName;
        Company OC = new Company(OE.Company_id);
        lbCompanyLogoText.Text = OC.Legal_Name; 
        //if (OE.Visa_Type_id == 1)
        //    Response.Redirect("finalize.aspx");

        if (Session["Attorney_Msg"] != null)
        {
            loading.InnerHtml = Session["Attorney_Msg"].ToString();
            Session["Attorney_Msg"] = null;
        }
        lbStatus.Text = OE.StatusText;
        if (OE.Employee_Access == Convert.ToInt16( AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
        {

            btnNew.Enabled = true;
            btnButton.Visible = true;
        }
        else
        {
            btnNew.Enabled = false;
            btnButton.Visible = false;
        }
        ds = OE.GetDepentents(intEmployeeId);
        int eRecId = 2;
        int cRecId = 0;

        if (strAction != "edit")
            intRecId = 0;
        eRecId = intRecId;
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
                txtDateofBirth.Value = ds.Tables[0].Rows[i]["DateofBirht"].ToString();
                ddCountryofBirht.SelectedValue = ds.Tables[0].Rows[i]["CountryofBirth"].ToString();
                ddCountryofCitizensip.SelectedValue = ds.Tables[0].Rows[i]["CountryofCitizenship"].ToString();
                txtCountryPassportIssuance.SelectedValue = ds.Tables[0].Rows[i]["CountryPassportIssuance"].ToString();

                txtUSSocialSecurityNo.Text = ds.Tables[0].Rows[i]["USSocialSecurityNo"].ToString();
                txtANumber.Text = ds.Tables[0].Rows[i]["ANumber"].ToString();
                txtI94.Text = ds.Tables[0].Rows[i]["I94"].ToString();
                txtDateofFirstEntry.Value = ds.Tables[0].Rows[i]["DateofFirstEntry"].ToString();
                txtDateofLastArrival.Value = ds.Tables[0].Rows[i]["DateofLastArrival"].ToString();
                txtPassportNo.Text = ds.Tables[0].Rows[i]["PassportNo"].ToString();
                txtPassportIssueDate.Value = ds.Tables[0].Rows[i]["PassportIssueDate"].ToString();
                txtPassportExpireDate.Value = ds.Tables[0].Rows[i]["PassportExpireDate"].ToString();
                txtCurrentNonimigrationStatus.Text = ds.Tables[0].Rows[i]["CurrentNonimigrationStatus"].ToString();
                txtDateStatusExpire.Text = ds.Tables[0].Rows[i]["DateStatusExpire"].ToString();
                                         
                txtForeignaddress.Text = ds.Tables[0].Rows[i]["Foreignaddress"].ToString();
                txtDaytimeTelephonenumber.Text = ds.Tables[0].Rows[i]["DaytimeTelephonenumber"].ToString();
                txtEmailaddress.Text = ds.Tables[0].Rows[i]["Emailaddress"].ToString();
                txtRelation.Text = ds.Tables[0].Rows[i]["Relation"].ToString();
                txtUSAddress.Text = ds.Tables[0].Rows[i]["USAddress"].ToString();
                panDisplay.Visible = true;
                btnButton.Visible =false ;
                //btnCancel.Visible =false ;

            }
            else
            {
                strRow1 += "<tr>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["FULLNAME"].ToString() + "&nbsp;</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["DateofBirht"].ToString() + "&nbsp;</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["PassportNo"].ToString() + "&nbsp;</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Emailaddress"].ToString() + "&nbsp;</td>";
                if (OE.Employee_Access == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
                    strRow1 += "<td><a href='employee4.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee4.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>Delete</a></td>";
                else
                    strRow1 += "<td><a href='employee4.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>View</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strRow1 += "</tr>";
            }

        }

        checkQuestions(
         (!String.IsNullOrEmpty(OE.Q_isUSResident.ToString()) && OE.Q_isUSResident.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isUSResident.ToString()) && OE.Q_isUSResident.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(OE.Q_isFileDependents.ToString()) && OE.Q_isFileDependents.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isFileDependents.ToString()) && OE.Q_isFileDependents.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(OE.Q_isPrevEmployed.ToString()) && OE.Q_isPrevEmployed.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isPrevEmployed.ToString()) && OE.Q_isPrevEmployed.ToString().Equals("N"))
        );

    }


    protected void btnButton_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("finalize.aspx");
        
    }

    protected string clrText(string strVal)
    {
        return strVal;
    }
    //protected void btnCancel_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("employee4.aspx");
    //}
    protected void btnNew_Click(object sender, EventArgs e)
    {
        displayList();
        panDisplay.Visible = true;
        //btnCancel.Visible =false;
        btnButton.Visible =false ;
        btnNew.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool flag = false;

        string Last_Name = clrText(txtLastName.Text);
        string First_Name = clrText(txtFirstName.Text);
        string Middle_Name= clrText(txtMiddleName.Text);
        string Other_Name = clrText(txtOtherName.Text) ;
        string DateofBirht = clrText(txtDateofBirth.Value) ;
        string CountryofBirth = ddCountryofBirht.SelectedValue; 
        string CountryofCitizenship = ddCountryofCitizensip.SelectedValue;  
        string USSocialSecurityNo = clrText(txtUSSocialSecurityNo.Text);
        string ANumber = clrText(txtANumber.Text);
        string I94 = clrText(txtI94.Text);
        string DateofFirstEntry = clrText(txtDateofFirstEntry.Value);
        string DateofLastArrival = clrText(txtDateofLastArrival.Value);
        string PassportNo= clrText(txtPassportNo.Text);
        string PassportIssueDate = clrText(txtPassportIssueDate.Value);
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

        if (strAction == "edit")
        {
            flag = oE.UpdateDependent(intEmployeeId, Last_Name, First_Name, Middle_Name, Other_Name, DateofBirht, CountryofBirth, CountryofCitizenship, USSocialSecurityNo, ANumber, I94, DateofFirstEntry, DateofLastArrival, PassportNo, PassportIssueDate, PassportExpireDate, CurrentNonimigrationStatus, DateStatusExpire, CountryPassportIssuance, Foreignaddress, DaytimeTelephonenumber, Emailaddress, Relation, USAddress, strSignature);
        }
        else
            flag = oE.AddDependent(intEmployeeId,Last_Name,First_Name,Middle_Name,Other_Name,DateofBirht,CountryofBirth,CountryofCitizenship,USSocialSecurityNo,ANumber,I94,DateofFirstEntry,DateofLastArrival,PassportNo,PassportIssueDate,PassportExpireDate,CurrentNonimigrationStatus,DateStatusExpire,CountryPassportIssuance,Foreignaddress,DaytimeTelephonenumber,Emailaddress, Relation, USAddress);

        if (flag)
        {
            txtLastName.Text = "";
            txtFirstName.Text = ""; ;
            txtMiddleName.Text = "";
            txtOtherName.Text = "";
            txtDateofBirth.Value = "";
            ddCountryofBirht.SelectedValue = "";
            ddCountryofCitizensip.SelectedValue = "";
            txtUSSocialSecurityNo.Text = "";
            txtANumber.Text = "";
            txtI94.Text = "";
            txtDateofFirstEntry.Value = "";
            txtDateofLastArrival.Value = "";
            txtPassportNo.Text = "";
            txtPassportIssueDate.Value = "";
            txtPassportExpireDate.Value = "";
            txtCurrentNonimigrationStatus.Text = "";
            txtDateStatusExpire.Text = "";
            txtCountryPassportIssuance.SelectedValue = "";
            txtForeignaddress.Text = "";
            txtDaytimeTelephonenumber.Text = "";
            txtEmailaddress.Text = "";
            txtRelation.Text = "";
            txtUSAddress.Text = "";
            Response.Redirect("employee4.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("employee4.aspx");
    }

    protected void checkQuestions(Boolean usResidentYes, Boolean usResidentNo
        , Boolean fileDependentsYes, Boolean fileDependentsNo
        , Boolean prevEmployedYes, Boolean prevEmployedNo)
    {
        if (usResidentYes)
        {
            tbDependent.Visible = true;
        }
        if (usResidentNo)
        {
            tbDependent.Visible = false;
        }

        if (fileDependentsNo)
        {
            tbDependent.Visible = false;
        }

        if (prevEmployedYes)
        {
            tbEmployment.Visible = true;
        }
        if (prevEmployedNo)
        {
            tbEmployment.Visible = false;
        }
    }
}

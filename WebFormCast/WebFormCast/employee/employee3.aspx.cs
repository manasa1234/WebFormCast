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

public partial class employee_employee3 : System.Web.UI.Page
{
    public string strRow1 = "";
    public string strRow2 = "";
    int intEmployeeId = 0;
    string strAction = "";
    int intRecId = 0;
    string strSignature = "";
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

            if (strAction == "delete")
            {
                AcglEmployee OE = new AcglEmployee();
                OE.DeleteProfession(intEmployeeId, strSignature);
                Response.Redirect("employee3.aspx");
            }

            fillMonths(ddMonth1);
            fillMonths(ddMonth2);
            fillYears(ddYear1);
            fillYears(ddYear2);
            //Initialize();
            displayList();
        }

        if (Session["Attorney_Msg"] != null)
        {
            loading.InnerHtml = Session["Attorney_Msg"].ToString();
            Session["Attorney_Msg"] = null;
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

        lbStatus.Text = OE.StatusText;
        //if (OE.Visa_Type_id == 1)
        //    tbDependent.Visible = false;

        if (OE.Employee_Access ==  Convert.ToInt16( AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
        {
            btnButton.Enabled = true;
        }
        else
        {
            btnButton.Enabled = false;
        }

        checkQuestions(
         (!String.IsNullOrEmpty(OE.Q_isUSResident.ToString()) && OE.Q_isUSResident.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isUSResident.ToString()) && OE.Q_isUSResident.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(OE.Q_isFileDependents.ToString()) && OE.Q_isFileDependents.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isFileDependents.ToString()) && OE.Q_isFileDependents.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(OE.Q_isPrevEmployed.ToString()) && OE.Q_isPrevEmployed.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isPrevEmployed.ToString()) && OE.Q_isPrevEmployed.ToString().Equals("N"))
        );

        ds = OE.GetProfession(intEmployeeId);
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
                txtEmployer.Text = ds.Tables[0].Rows[i]["Employer"].ToString();
                ddMonth1.SelectedValue = ds.Tables[0].Rows[i]["FromMonth"].ToString();
                ddYear1.SelectedValue = ds.Tables[0].Rows[i]["FromYear"].ToString();
                ddMonth2.SelectedValue = ds.Tables[0].Rows[i]["ToMonth"].ToString();
                ddYear2.SelectedValue = ds.Tables[0].Rows[i]["ToYear"].ToString();
                txtSkills.Text = ds.Tables[0].Rows[i]["Skills"].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[i]["Designation"].ToString();
            }
            else if (cRecId < eRecId || intRecId <= 0)
            {
                strRow1 += "<tr>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Employer"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Skills"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>";
                if (OE.Employee_Access  == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
                    strRow1 += "<td><a href='employee3.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee3.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>Delete</a></td>";
                else
                    strRow1 += "<td>&nbsp;</td>";
                strRow1 += "</tr>";
            }
            else
            {
                strRow2 += "<tr>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Employer"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Skills"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>";
                strRow1 += "<td><a href='employee3.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>Edit</a>&nbsp;&nbsp;<a href='employee3.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "'>Delete</a></td>";
                strRow2 += "</tr>";
            }


        }

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
        for (int i = 2020; i >= 1950; i--)
        {
            dd.Items.Add(new ListItem(i.ToString(), i.ToString()));

        }

    }
    protected void btnButton_Click(object sender, EventArgs e)
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
        strSkills = clrText(txtSkills.Text);
        strDesignation = clrText(txtDesignation.Text);
        intFromMonth = Convert.ToInt16(ddMonth1.SelectedValue);
        intToMonth = Convert.ToInt16(ddMonth2.SelectedValue);
        intFromYear = Convert.ToInt16(ddYear1.SelectedValue);
        intToYear = Convert.ToInt16(ddYear2.SelectedValue);
        AcglEmployee oE = new AcglEmployee();

        if (strAction == "edit")
            flag = oE.UpdateProfession(intEmployeeId, strEmployer, strSkills, strDesignation, intFromMonth, intFromYear, intToMonth, intToYear,strSignature);
        else
            flag = oE.AddProfession(intEmployeeId, strEmployer, strSkills, strDesignation, intFromMonth, intFromYear, intToMonth, intToYear);
        if (flag)
        {
            txtEmployer.Text = "";
            txtSkills.Text = "";
            ddMonth1.SelectedIndex = 0;
            ddMonth2.SelectedIndex = 0;
            ddYear1.SelectedIndex = 0;
            ddYear2.SelectedIndex = 0;
            Response.Redirect("employee3.aspx");
        }
    }

    protected string clrText(string strVal)
    {
        return strVal;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("employee3.aspx");
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Session["Attorney_Msg"] = "Experience Details Saved Successfully";
        if (tbDependent.Visible)
        {
            Response.Redirect("employee4.aspx");
        }
        else
        {
            Response.Redirect("finalize.aspx");
        }
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

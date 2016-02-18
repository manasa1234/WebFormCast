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

public partial class employee_employee2 : System.Web.UI.Page
{
    public string strRow1 = "";
    public string strRow2 = "";
    int intEmployeeId = 0;
    string strAction = "";
    int intRecId = 0;
    string strSignature = "";
    int intStatus = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(System.Guid.NewGuid().ToString());
        try
        {
            intEmployeeId = Convert.ToInt16(Session["Employee_id"]);
        }
        catch
        {
            intEmployeeId = 0;
        }

        try
        {
            strAction = Request["action"].ToString();
        }
        catch{}

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
                OE.DeleteEducation(intEmployeeId, strSignature);
                Response.Redirect("employee2.aspx");
            }
          
            fillMonths(ddMonth1);
            fillMonths(ddMonth2);
            fillYears(ddYear1);
            fillYears(ddYear2);
            fillYears(ddYear3);
            Initialize();
            displayList();
        }
        if (Session["Attorney_Msg"] != null)
        {
            loading.InnerHtml = Session["Attorney_Msg"].ToString();
            Session["Attorney_Msg"] = null;
        }
    }

    protected void Initialize()
    {
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        lbUserName.Text = OE.LastName + " " + OE.FirstName + " " + OE.MiddleName;
        lbName.Text = OE.LastName + " " + OE.FirstName + " " + OE.MiddleName;
        Company OC = new Company(OE.Company_id);
        lbCompanyLogoText.Text = OC.Legal_Name;

        if (OE.Employee_Access == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
        {
            btnSave1.Enabled = true;
            btnButton.Enabled = true;
        }
        else
        {
            btnSave1.Enabled =false ;
            btnButton.Enabled =false ;
        }
        lbStatus.Text = OE.StatusText;
        intStatus = OE.Employee_Access;

        //if (OE.Visa_Type_id == 1)
        //    tbDependent.Visible = false;

        rbHighestLeve1.Checked = OE.HighestLeve == 1;
        rbHighestLeve2.Checked = OE.HighestLeve == 2;
        rbHighestLeve3.Checked = OE.HighestLeve == 3;
        rbHighestLeve4.Checked = OE.HighestLeve == 4;
        rbHighestLeve5.Checked = OE.HighestLeve == 5;
        rbHighestLeve6.Checked = OE.HighestLeve == 6;
        rbHighestLeve7.Checked = OE.HighestLeve == 7;
        rbHighestLeve8.Checked = OE.HighestLeve == 8;
        rbHighestLeve9.Checked = OE.HighestLeve == 9;

        chMasterDegreeFromUS1.Checked = OE.MasterDegreeFromUS;
        chMasterDegreeFromUS2.Checked = !OE.MasterDegreeFromUS;

        txtPrimaryFieldofStudy.Text = OE.PrimaryFieldofStudy;
        txtUSInstitutionName.Text = OE.USInstitutionName;
        txtUSDateDegreeAwarded.Text = OE.USDateDegreeAwarded;
        txtUSDegreeType.Text = OE.USDegreeType;
        txtUSInstitutionAddress.Text = OE.USInstitutionAddress;

        checkQuestions(
         (!String.IsNullOrEmpty(OE.Q_isUSResident.ToString()) && OE.Q_isUSResident.ToString().Equals("Y"))
         ,(!String.IsNullOrEmpty(OE.Q_isUSResident.ToString()) && OE.Q_isUSResident.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(OE.Q_isFileDependents.ToString()) && OE.Q_isFileDependents.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isFileDependents.ToString()) && OE.Q_isFileDependents.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(OE.Q_isPrevEmployed.ToString()) && OE.Q_isPrevEmployed.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(OE.Q_isPrevEmployed.ToString()) && OE.Q_isPrevEmployed.ToString().Equals("N"))
        );

    }
    

    protected void displayList()
    {
        
        DataSet ds = new DataSet();
        AcglEmployee  OE = new AcglEmployee();
        ds = OE.GetEducationList(intEmployeeId);
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
                txtUniversity.Text = ds.Tables[0].Rows[i]["University"].ToString();
                txtDegree.Text = ds.Tables[0].Rows[i]["Degree_Name"].ToString();
                ddMonth1.SelectedValue = ds.Tables[0].Rows[i]["FromMonth"].ToString();
                ddYear1.SelectedValue = ds.Tables[0].Rows[i]["FromYear"].ToString();
                ddMonth2.SelectedValue = ds.Tables[0].Rows[i]["ToMonth"].ToString();
                ddYear2.SelectedValue = ds.Tables[0].Rows[i]["ToYear"].ToString();
                ddYear3.SelectedValue = ds.Tables[0].Rows[i]["GradYear"].ToString(); 
            }
            else if (cRecId < eRecId || intRecId<=0)
            {
                strRow1 += "<tr>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["University"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["GradYear"].ToString() + "</td>";
                strRow1 += "<td>" + ds.Tables[0].Rows[i]["Degree_Name"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
                    strRow1 += "<td><a href='employee2.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='employee2.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Delete</a></td>";
                else
                        strRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                strRow1 += "</tr>";
            }
            else
            {
                strRow2 += "<tr>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["University"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["GradYear"].ToString() + "</td>";
                strRow2 += "<td>" + ds.Tables[0].Rows[i]["Degree_Name"].ToString() + "</td>";
                if (intStatus == Convert.ToInt16( AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES)) 
                    strRow1 += "<td><a href='employee2.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Edit</a>&nbsp;&nbsp;<a href='employee2.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Education'>Delete</a></td>";
                else
                    strRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
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
        dd.Items.Add(new ListItem("Year","0"));
        for (int i = 2010; i>=1950; i--)
        {
            dd.Items.Add(new ListItem(i.ToString(),i.ToString()));
 
        }

    }
    protected void btnButton_Click(object sender, EventArgs e)
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

        if(strAction=="edit")
            flag = oE.UpdateEducation(intEmployeeId, strUniversity, intFromMonth, intFromYear, intToMonth, intToYear, intGradYear, strDegree,strSignature);
        else
            flag=oE.AddEducation(intEmployeeId, strUniversity, intFromMonth, intFromYear, intToMonth, intToYear, intGradYear,strDegree);
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
        SaveData();
        Response.Redirect("employee2.aspx#Education");
    }

    protected string clrText(string strVal)
    {
        return strVal;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("employee2.aspx#Education");
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
        SaveData();
        if (tbEmployment.Visible)
        {
            Response.Redirect("employee3.aspx#Education");
        }
        else if (tbDependent.Visible)
        {
            Response.Redirect("employee4.aspx");
        }
        else
        {
            Response.Redirect("finalize.aspx");
        }
    }

    protected bool SaveData()
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

        AcglEmployee OE = new AcglEmployee();
        AcglGeneral OG = new AcglGeneral();

        OE.HighestLeve = HighestLeve;
        OE.MasterDegreeFromUS = USdegree;
        OE.PrimaryFieldofStudy = OG.ClrText(txtPrimaryFieldofStudy.Text);
        OE.USInstitutionName = OG.ClrText(txtUSInstitutionName.Text);
        OE.USDateDegreeAwarded = OG.ClrText(txtUSDateDegreeAwarded.Text);
        OE.USDegreeType = OG.ClrText(txtUSDegreeType.Text);
        OE.USInstitutionAddress = OG.ClrText(txtUSInstitutionAddress.Text);
        OE.UpdateEmployeeEducation(intEmployeeId);
        Session["Attorney_Msg"] = "Education information saved successfully";
        return true;
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

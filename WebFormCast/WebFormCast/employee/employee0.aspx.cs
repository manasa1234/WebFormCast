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

public partial class employee0 : System.Web.UI.Page
{
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
        if (!IsPostBack)
        {

            Initialize();
        }
    }

    protected void Initialize()
    {
        AcglEmployee oE = new AcglEmployee(intEmployeeId);
        AcglGeneral objG = new AcglGeneral();
        Company OC = new Company(oE.Company_id);
        lbName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName;
        lbUserName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName;

        if (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && oE.Q_isUSResident.ToString().Equals("Y"))
            rbUsResident1.Checked = true;
        if (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && oE.Q_isUSResident.ToString().Equals("N"))
            rbUsResident2.Checked = true;

        if (!String.IsNullOrEmpty(oE.Q_isThirdParty.ToString()) && oE.Q_isThirdParty.ToString().Equals("Y"))
            rbThirdParty1.Checked = true;
        if (!String.IsNullOrEmpty(oE.Q_isThirdParty.ToString()) && oE.Q_isThirdParty.ToString().Equals("N"))
            rbThirdParty2.Checked = true;

        if (!String.IsNullOrEmpty(oE.Q_isPremiumFee.ToString()) && oE.Q_isPremiumFee.ToString().Equals("Y"))
            rbPremiumFee1.Checked = true;
        if (!String.IsNullOrEmpty(oE.Q_isPremiumFee.ToString()) && oE.Q_isPremiumFee.ToString().Equals("N"))
            rbPremiumFee2.Checked = true;

        if (!String.IsNullOrEmpty(oE.Q_isEmpRelated.ToString()) && oE.Q_isEmpRelated.ToString().Equals("Y"))
            rbEmpRelated1.Checked = true;
        if (!String.IsNullOrEmpty(oE.Q_isEmpRelated.ToString()) && oE.Q_isEmpRelated.ToString().Equals("N"))
            rbEmpRelated2.Checked = true;

        if (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && !String.IsNullOrEmpty(oE.Q_isThirdParty.ToString()) && !String.IsNullOrEmpty(oE.Q_isPremiumFee.ToString()) && !String.IsNullOrEmpty(oE.Q_isEmpRelated.ToString())) { 
            Response.Redirect("employee.aspx");    
        }


    }

    protected void radioUsResident_CheckedChanged(object sender, EventArgs e)
    {
        checkQuestionUSResident();
    }

    protected void checkQuestionUSResident()
    {
        if (rbUsResident1.Checked)
        {
            rbFileDependents1.Enabled = true;
            rbFileDependents2.Enabled = true;
        }
        if (rbUsResident2.Checked)
        {
            rbFileDependents1.Enabled = false;
            rbFileDependents2.Enabled = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        AcglEmployee oE = new AcglEmployee();
        oE.UpdateInitialQuestions(intEmployeeId, (rbUsResident1.Checked ? "Y" : "N"), (rbThirdParty1.Checked ? "Y" : "N")
            , (rbPremiumFee1.Checked ? "Y" : "N")
            , (rbEmpRelated1.Checked ? "Y" : "N")
            , (rbFileDependents1.Checked ? "Y" : "N")
            , (rbPrevEmployed1.Checked ? "Y" : "N")
            );
        Session["Attorney_Msg"] = "Initial information saved successfully";
        Response.Redirect("employee.aspx");    
    }

}

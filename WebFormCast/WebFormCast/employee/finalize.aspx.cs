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
using ACLGDataAaccess;
 
public partial class employee_finalize : System.Web.UI.Page
{
    int intEmployeeId = 0;
    public string strScript = "";
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

        lbName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName;
        lbUserName.Text = oE.LastName + " " + oE.FirstName + " " + oE.MiddleName;
        //if (oE.Visa_Type_id == 1)
        //    tbDependent.Visible = false;

        if (oE.Status < 5)
            btnFinalize.Enabled = true;
        else
        {
            btnFinalize.Enabled = false;
        }
        lbStatus.Text = oE.StatusText;
        lbTracking.Text = oE.TrackingNo;
        txtComments.Text = oE.Comments;

        Company OC = new Company(oE.Company_id);
        lbCompanyLogoText.Text = OC.Legal_Name;
        lbEmployerEmail.Text = OC.Person_Email;

        checkQuestions(
         (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && oE.Q_isUSResident.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(oE.Q_isUSResident.ToString()) && oE.Q_isUSResident.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(oE.Q_isFileDependents.ToString()) && oE.Q_isFileDependents.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(oE.Q_isFileDependents.ToString()) && oE.Q_isFileDependents.ToString().Equals("N"))
         , (!String.IsNullOrEmpty(oE.Q_isPrevEmployed.ToString()) && oE.Q_isPrevEmployed.ToString().Equals("Y"))
         , (!String.IsNullOrEmpty(oE.Q_isPrevEmployed.ToString()) && oE.Q_isPrevEmployed.ToString().Equals("N"))
        );
    }

    protected void btnFinalize_Click(object sender, EventArgs e)
    {
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        Company OC = new Company(OE.Company_id);
        string strBody = "";
        bool flag = false;
        flag = OE.UpdateComments(intEmployeeId, clrText(txtComments.Text));
        flag = OE.UpdateStatus(intEmployeeId, 3);
        if (flag)
        {
            OE.SetEmployeeAccess(intEmployeeId,Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_NO)); 
            clsSendEmail objMail = new clsSendEmail();
            objMail.SendTo = OC.Person_Email;  
            objMail.FromName = "support@webformcast.com";
            strBody = OE.FirstName + " " + OE.LastName + " with tracking number " + OE.TrackingNo + "  has completed filling the document.";
            objMail.BCc = "ramineni@raminenilaw.com";
            objMail.Subject = OE.TrackingNo + " - has completed filling the document"; 
            objMail.Send();
            strScript = "<script language='javascript'>alert('Your Information has been Finalized!')</script>";
            //btnFinalize.Enabled = false;
            lbStatus.Text = "Finalized";
            loading.InnerHtml = "Your Information Finalized Successfully";
        }
        else
            strScript = "<script language='javascript'>alert('Your Information could not Finalizedz!)</script>";

    }

    protected string clrText(string strVal)
    {
        return strVal;
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

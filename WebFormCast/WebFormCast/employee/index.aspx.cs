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

public partial class employee_login : System.Web.UI.Page
{
    int intEmployeeid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            Session["Employee_id"] = null;
            Session["LogedIn"] = null;
            Session["Employee_Code"] = null;
            Session.Abandon();
            lbmsg.Text = "You have logged out.<br>";
            lbmsg.ForeColor = System.Drawing.Color.Blue;
        }
        //lbmsg.Text = "";
        //Session.Abandon();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            string strEmail="";
            string strPassword = "";
           
            AcglGeneral oG = new AcglGeneral();
            AcglEmployee oE = new AcglEmployee();  
            strEmail = txtEmail.Text.Trim();
            strPassword = txtPassword.Text.Trim();
            strEmail = oG.ClrText(strEmail);
            strPassword = oG.ClrText(strPassword);
            intEmployeeid=oE.CheckAuthontication(strEmail, strPassword);
            
            if (intEmployeeid > 0)
            {
                oE = new AcglEmployee(intEmployeeid);
                Session["Employee_id"] = oE.EmployeeId;
                Session["LogedIn"]="EMPLOYEE";
                Session["Employee_Code"] = oE.EmployeeCode;
                Response.Redirect("employee0.aspx");
            }
            else
            {
                lbmsg.Text = "Invalid Username/Password";
                lbmsg.ForeColor = System.Drawing.Color.Red;
            }

    }

}

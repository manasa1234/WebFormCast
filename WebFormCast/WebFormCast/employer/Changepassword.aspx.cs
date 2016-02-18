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
using ACLGDataAaccess;
using WebFormCast.ACLG; 

public partial class employer_Changepassword : System.Web.UI.Page
{
    int _CompanyId=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            _CompanyId = Convert.ToInt16(Session["Company_Id"]);
        }
        catch { }

        if (_CompanyId <= 0)
        {
            Response.Redirect("index.aspx");
        }
        try
        {
            lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Company_Person_Name"].ToString();
        }
        catch
        { }

        if (Session["Employer_Msg"] != null)
        {
            loading.InnerHtml = Session["Employer_Msg"].ToString();
            Session["Employer_Msg"] = null;
        }
        else
        {
            loading.InnerHtml = "";
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string strPassword1 = "";
        string strPassword2 = "";

        strPassword1 = txtPassword.Text;
        strPassword2 = txtPassword1.Text; 
        if (strPassword1.Trim() == "" || strPassword2.Trim() == "")
        {
            lbMsg.Text = "Invalid Old Password";
            lbMsg.ForeColor = System.Drawing.Color.Red; 
            return;
        }

        Company OC = new Company();

        if (OC.ChangePassword(_CompanyId, strPassword1, strPassword2))
        {
            lbMsg.Text = "Password has been changed Successfully";
            lbMsg.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lbMsg.Text = "Invalid Old Password";
            lbMsg.ForeColor = System.Drawing.Color.Red;
        }

 

    }
}

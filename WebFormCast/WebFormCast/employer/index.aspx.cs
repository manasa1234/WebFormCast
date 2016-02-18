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

public partial class employer_index : System.Web.UI.Page
{
    int intCompanyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["action"] != null)
        {
            Session["Company_Id"] =null ;
            Session["Company_Person_Name"] = null;
            Session["Company_Name"] = null ;
            Session.Abandon();
            lbmsg.Text = "You have logged out.<br>";
            lbmsg.ForeColor = System.Drawing.Color.Blue; 
        }

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

        AcglGeneral OG = new AcglGeneral(); 
        string strEmail = "";
        string strPassword = "";

        try
        {
            strEmail = OG.ClrText(txtEmail.Text);
            strPassword = OG.ClrText(txtPassword.Text);
            Company OC = new Company();
            intCompanyId = OC.CheckAuthontication(strEmail, strPassword);

            if (intCompanyId <= 0)
            {
                lbmsg.Text = "Invalid Username/password";
                lbmsg.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Session["Company_Id"] = intCompanyId;
                Session["Company_Person_Name"] = OC.Person_FullName;
                Session["Company_Name"] = OC.Legal_Name;
                Response.Redirect("employer.aspx");
            }
        }
        catch (Exception ex)
        {
            lbmsg.Text = ex.Message;
        }


}
}

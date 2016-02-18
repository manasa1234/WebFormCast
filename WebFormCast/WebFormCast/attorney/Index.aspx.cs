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

public partial class attorney_index : System.Web.UI.Page
{
    int intAttorneyId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Attorney_Id"] = "";
        Session["Attorney_User_Type"] = "";
        Session["Attorney_User_Id"] = "";

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        bool Flag = false;
        AcglGeneral OG = new AcglGeneral();
        AttorneyUser OU = new AttorneyUser(); 
        string strEmail = "";
        string strPassword = "";

        strEmail = OG.ClrText(txtEmail.Text);
        strPassword = OG.ClrText(txtPassword.Text);

        Flag = OU.CheckAuthentication(strEmail);

        if (!Flag )
            lbmsg.Text = "Invalid Username/password";
        else
        {
            if (OU.Password == strPassword && strPassword!="")
            {
                Session["Attorney_Id"] = OU.Attorney_id;
                Session["Attorney_User_Type"] = OU.User_Type;
                Session["Attorney_User_Id"] = OU.User_ID;
                Session["Attorney_User_DisplayName"] = OU.User_Display_Name;

                OU.UpdateLoginDate();
                Response.Redirect("casespending.aspx");
            }
            else
                lbmsg.Text = "Invalid Username/password";
        }

}
}

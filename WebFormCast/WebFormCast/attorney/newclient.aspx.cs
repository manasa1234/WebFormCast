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
public partial class newclient : System.Web.UI.Page
{
    int intAttorney_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        
       if (intAttorney_id <= 0)
        {
            Response.Redirect("index.aspx");
        }
       try
       {
           //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
           lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
       }
       catch
       { }

       AcglGeneral objG = new AcglGeneral();
       lbNavigation.Text = objG.GetNavLinks("CLIENT");

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int intCompanyId = 0;
        bool bFlag = true;
        AcglGeneral OG = new AcglGeneral();
        Company OC = new Company();
        string strAccessKey = GetAccessKey();
        OC.AttorneyId = intAttorney_id;
        OC.Legal_Name = OG.ClrText(txtCompanyName.Text);
        OC.Short_Name = OG.ClrText(txtShortName.Text);
        OC.Person_FullName= OG.ClrText(txtPerson_Name.Text);
        OC.Person_Email = OG.ClrText(txtPerson_Email.Text);
        OC.Password = strAccessKey;

        if(OC.isExistShortName(OG.ClrText(txtShortName.Text)))
        {
            bFlag = false;
            lbShortName.Text = "already exists";
        }

        if (OC.isExistCompanyEmail(OG.ClrText(txtPerson_Email.Text)))
        {
            bFlag = false;
            lbEmail.Text = "already exists";
        }
        
        if (bFlag)
        {
            intCompanyId = OC.CreateCompany();
            
            if (intCompanyId > 0)
            {
                panDisp.Visible = false;
                //txtMessage.Text = "New Employer has been created and login information has been sent to Employer";
                txtMessage.Text = "New Company has been created.<br>Please click on 'Mail User info' link in clients list page to send user information.";
                //OC.SendEmployerInvitation();
            }
            else
            {
                txtMessage.Text = "Could not able to create new Company";
                txtMessage.ForeColor = System.Drawing.Color.Red;
            }

        }         


    }
    public string GetAccessKey()
    {
        string guidResult = System.Guid.NewGuid().ToString();
        guidResult = guidResult.Substring(1, 6);
        return guidResult;

    }
}

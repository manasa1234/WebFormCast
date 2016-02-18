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

public partial class attoreymyaccount : System.Web.UI.Page
{
    int intAttorney_id=0;
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

        if (!IsPostBack)
        {
            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("MYACCOUNT");

            clsAttorney OA = new clsAttorney(intAttorney_id);
            txtName.Text = OA.Name;
            txtFirmName.Text = OA.Firm_Name;
            txtSuite.Text = OA.Suite;
            txtStreet.Text = OA.Street;
            txtCity.Text = OA.City;
            txtState.Text = OA.State;
            txtZip.Text = OA.Zip;
            txtEmail.Text = OA.Email;
            txtFax.Text = OA.Fax;
            txtTel.Text = OA.Phone;
            txtTel_Code.Text = OA.Phone_Code;
            txtAttyStateLicense.Text = OA.AttyStateLicense;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool flag = false;
        AcglGeneral OG = new AcglGeneral();
        clsAttorney OA = new clsAttorney();
        flag = OA.Update_Attorney(intAttorney_id, OG.ClrText(txtName.Text),OG.ClrText(txtFirmName.Text), OG.ClrText(txtSuite.Text),OG.ClrText(txtStreet.Text) , OG.ClrText(txtCity.Text) , OG.ClrText(txtState.Text) , OG.ClrText(txtZip.Text) , OG.ClrText(txtEmail.Text), OG.ClrText(txtTel.Text),OG.ClrText(txtTel_Code.Text) , OG.ClrText(txtFax.Text),OG.ClrText(txtAttyStateLicense.Text));
        if (flag == true)
            lbmsg.Text = "Information has been saved.";
        else
        {
            lbmsg.Text = "Your Information have not saved.";
            lbmsg.ForeColor = System.Drawing.Color.Red;  
        }


       
    }
}

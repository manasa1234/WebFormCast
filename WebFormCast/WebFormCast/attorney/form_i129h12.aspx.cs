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
public partial class form_i129h12 : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    string strEmployeeSignature = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        try
        {
            intEmployeeId = Convert.ToInt16(Session["Attorney_Employee_Id"]);
            //strEmployeeSignature =Session["Attorney_Employee_Signature"].ToString();
        }
        catch { }
        try
        {
            strEmployeeSignature = Request["signature"].ToString();
        }
        catch { }
        try
        {

            lbtrackingno.Text = Session["Attorney_Employee_TrackingNo"].ToString(); ;
        }
        catch { }
        try
        {

            lbCompanyName.Text = Session["Attorney_CompanyName"].ToString();
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
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strEmployeeSignature);
            lbNavigation.Text = objG.GetNavLinks("CASE");
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 12);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }


    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);

        f12_Fee_Exemption_1_Yes.Checked = OF.f12_Fee_Exemption_1;
        f12_Fee_Exemption_1_No.Checked = !OF.f12_Fee_Exemption_1;
        f12_Fee_Exemption_2_Yes.Checked = OF.f12_Fee_Exemption_2;
        f12_Fee_Exemption_2_No.Checked = !OF.f12_Fee_Exemption_2;
        f12_Fee_Exemption_3_Yes.Checked = OF.f12_Fee_Exemption_3;
        f12_Fee_Exemption_3_No.Checked = !OF.f12_Fee_Exemption_3;
        f12_Fee_Exemption_4_Yes.Checked = OF.f12_Fee_Exemption_4;
        f12_Fee_Exemption_4_No.Checked = !OF.f12_Fee_Exemption_4;
        f12_Fee_Exemption_5_Yes.Checked = OF.f12_Fee_Exemption_5;
        f12_Fee_Exemption_5_No.Checked = !OF.f12_Fee_Exemption_5;
        f12_Fee_Exemption_6_Yes.Checked = OF.f12_Fee_Exemption_6;
        f12_Fee_Exemption_6_No.Checked = !OF.f12_Fee_Exemption_6;
        f12_Fee_Exemption_7_Yes.Checked = OF.f12_Fee_Exemption_7;
        f12_Fee_Exemption_7_No.Checked = !OF.f12_Fee_Exemption_7;
        f12_Fee_Exemption_8_Yes.Checked = OF.f12_Fee_Exemption_8;
        f12_Fee_Exemption_8_No.Checked = !OF.f12_Fee_Exemption_8;
        f12_Fee_Exemption_9_Yes.Checked = OF.f12_Fee_Exemption_9;
        f12_Fee_Exemption_9_No.Checked = !OF.f12_Fee_Exemption_9;

        f12_Numerical_Limitation_1_Yes.Checked = OF.f12_Numerical_Limitation_1;
        f12_Numerical_Limitation_1_No.Checked = !OF.f12_Numerical_Limitation_1;
        f12_Numerical_Limitation_2_Yes.Checked = OF.f12_Numerical_Limitation_2;
        f12_Numerical_Limitation_2_No.Checked = !OF.f12_Numerical_Limitation_2;
        f12_Numerical_Limitation_3_Yes.Checked = OF.f12_Numerical_Limitation_3;
        f12_Numerical_Limitation_3_No.Checked = !OF.f12_Numerical_Limitation_3;
        f12_Numerical_Limitation_4_Yes.Checked = OF.f12_Numerical_Limitation_4;
        f12_Numerical_Limitation_4_No.Checked = !OF.f12_Numerical_Limitation_4;
        f12_Numerical_Limitation_5_Yes.Checked = OF.f12_Numerical_Limitation_5;
        f12_Numerical_Limitation_5_No.Checked = !OF.f12_Numerical_Limitation_5;
        f12_Numerical_Limitation_6_Yes.Checked = OF.f12_Numerical_Limitation_6;
        f12_Numerical_Limitation_6_No.Checked = !OF.f12_Numerical_Limitation_6;
        f12_Numerical_Limitation_7_Yes.Checked = OF.f12_Numerical_Limitation_7;
        f12_Numerical_Limitation_7_No.Checked = !OF.f12_Numerical_Limitation_7;

    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f12_Fee_Exemption_1 = f12_Fee_Exemption_1_Yes.Checked;
        OF.f12_Fee_Exemption_2 = f12_Fee_Exemption_2_Yes.Checked ;
        OF.f12_Fee_Exemption_3 = f12_Fee_Exemption_3_Yes.Checked ;
        OF.f12_Fee_Exemption_4 = f12_Fee_Exemption_4_Yes.Checked ;
        OF.f12_Fee_Exemption_5 = f12_Fee_Exemption_5_Yes.Checked ;
        OF.f12_Fee_Exemption_6 = f12_Fee_Exemption_6_Yes.Checked ;
        OF.f12_Fee_Exemption_7 = f12_Fee_Exemption_7_Yes.Checked ;
        OF.f12_Fee_Exemption_8 = f12_Fee_Exemption_8_Yes.Checked ;
        OF.f12_Fee_Exemption_9 = f12_Fee_Exemption_9_Yes.Checked ;

        OF.f12_Numerical_Limitation_1 = f12_Numerical_Limitation_1_Yes.Checked;
        OF.f12_Numerical_Limitation_2 = f12_Numerical_Limitation_2_Yes.Checked;
        OF.f12_Numerical_Limitation_3 = f12_Numerical_Limitation_3_Yes.Checked;
        OF.f12_Numerical_Limitation_4 = f12_Numerical_Limitation_4_Yes.Checked;
        OF.f12_Numerical_Limitation_5 = f12_Numerical_Limitation_5_Yes.Checked;
        OF.f12_Numerical_Limitation_6 = f12_Numerical_Limitation_6_Yes.Checked;
        OF.f12_Numerical_Limitation_7 = f12_Numerical_Limitation_7_Yes.Checked;

        


        flag = OF.Form_12_Update(intEmployeeId);

        Response.Redirect("form_i129h13.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

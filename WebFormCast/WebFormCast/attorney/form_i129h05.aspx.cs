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
public partial class form_i129h05 : System.Web.UI.Page
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
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 5);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }

    protected void Initialize()
    {
        
        Form_i129H OF = new Form_i129H(intEmployeeId);

        f5_Job_Title.Text = OF.f5_Job_Title;
        f5_LCA_Case_Number.Text = OF.f5_LCA_Case_Number;
        f5_different_from_address.Text = OF.f5_different_from_address;
        f5_Is_this_a_fulltime_positionYes.Checked  = OF.f5_Is_this_a_fulltime_position;
        f5_Is_this_a_fulltime_positionNo.Checked = !OF.f5_Is_this_a_fulltime_position;

        f5_Hours_per_week.Text = OF.f5_Hours_per_week;
        f5_Wages_per_week_Year.Text = OF.f5_Wages_per_week_Year;
        f5_Other_Compensation.Text = OF.f5_Other_Compensation;
        f5_Dates_of_intended_employment1.Value   = OF.f5_Dates_of_intended_employment1;
        f5_Dates_of_intended_employment2.Value  = OF.f5_Dates_of_intended_employment2;
        f5_Type_of_Business.Text = OF.f5_Type_of_Business;
        f5_Year_Established.Text = OF.f5_Year_Established;
        f5_Current_Number_of_Employees.Text = OF.f5_Current_Number_of_Employees;
        f5_Gross_Annual_Income.Text = OF.f5_Gross_Annual_Income;
        f5_Net_Annual_Income.Text = OF.f5_Net_Annual_Income;


    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;
        OF.f5_Job_Title = OG.ClrText(f5_Job_Title.Text);
        OF.f5_LCA_Case_Number = OG.ClrText(f5_LCA_Case_Number.Text);
        OF.f5_different_from_address = OG.ClrText(f5_different_from_address.Text);
        OF.f5_Is_this_a_fulltime_position = f5_Is_this_a_fulltime_positionYes.Checked;
        OF.f5_Hours_per_week = OG.ClrText(f5_Hours_per_week.Text);
        OF.f5_Wages_per_week_Year = OG.ClrText(f5_Wages_per_week_Year.Text);
        OF.f5_Other_Compensation = OG.ClrText(f5_Other_Compensation.Text);
        OF.f5_Dates_of_intended_employment1 = OG.ClrText(f5_Dates_of_intended_employment1.Value );
        OF.f5_Dates_of_intended_employment2 = OG.ClrText(f5_Dates_of_intended_employment2.Value );

        OF.f5_Type_of_Business = OG.ClrText(f5_Type_of_Business.Text);
        OF.f5_Year_Established = OG.ClrText(f5_Year_Established.Text);
        OF.f5_Current_Number_of_Employees = OG.ClrText(f5_Current_Number_of_Employees.Text);
        OF.f5_Gross_Annual_Income = OG.ClrText(f5_Gross_Annual_Income.Text);
        OF.f5_Net_Annual_Income = OG.ClrText(f5_Net_Annual_Income.Text);

        flag = OF.Form_05_Update(intEmployeeId);

        Response.Redirect("form_i129h06.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

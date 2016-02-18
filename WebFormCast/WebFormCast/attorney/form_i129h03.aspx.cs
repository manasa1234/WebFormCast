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
public partial class form_i129h03 : System.Web.UI.Page
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
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 3);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }

    }

    protected void Initialize()
    {
        Form_i129H OF = new Form_i129H(intEmployeeId);
        f3_Entertainment_Group_Name.Text = OF.f3_Entertainment_Group_Name;
        f3_Last_Name.Text = OF.f3_Last_Name;
        f3_First_Name.Text = OF.f3_First_Name;
        f3_Middle_Name.Text = OF.f3_Middle_Name;
        f3_Other_Name1.Text = OF.f3_Other_Name1;
        f3_Other_Name2.Text = OF.f3_Other_Name2;
        f3_Other_Name3.Text = OF.f3_Other_Name3;
        f3_Date_of_Birth.Text = OF.f3_Date_of_Birth;
        f3_US_Social_Security.Text = OF.f3_US_Social_Security;
        f3_Anumber.Text = OF.f3_Anumber;
        f3_Country_of_Birth.Text = OF.f3_Country_of_Birth;
        f3_Province_of_Birth.Text = OF.f3_Province_of_Birth;
        f3_Country_of_Citizenship.Text = OF.f3_Country_of_Citizenship;
        f3_Date_of_Last_Arrival.Text = OF.f3_Date_of_Last_Arrival;
        f3_I94.Text = OF.f3_I94;
        f3_Current_Nonimmigrant_Status.Text = OF.f3_Current_Nonimmigrant_Status;
        f3_Date_Status_Expires.Text = OF.f3_Date_Status_Expires;
        f3_Passport_Number.Text = OF.f3_Passport_Number;
        f3_Date_Passport_Issued.Text = OF.f3_Date_Passport_Issued;
        f3_Date_Passport_Expires.Text = OF.f3_Date_Passport_Expires;
        f3_Current_US_Address.Text = OF.f3_Current_US_Address;

    }
    

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Form_i129H OF = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        OF.f3_Entertainment_Group_Name = OG.ClrText(f3_Entertainment_Group_Name.Text);
        OF.f3_Last_Name = OG.ClrText(f3_Last_Name.Text);
        OF.f3_First_Name = OG.ClrText(f3_First_Name.Text);
        OF.f3_Middle_Name = OG.ClrText(f3_Middle_Name.Text);
        OF.f3_Other_Name1 = OG.ClrText(f3_Other_Name1.Text);
        OF.f3_Other_Name2 = OG.ClrText(f3_Other_Name2.Text);
        OF.f3_Other_Name3 = OG.ClrText(f3_Other_Name3.Text);
        OF.f3_Date_of_Birth = OG.ClrText(f3_Date_of_Birth.Text);
        OF.f3_US_Social_Security = OG.ClrText(f3_US_Social_Security.Text);
        OF.f3_Anumber = OG.ClrText(f3_Anumber.Text);
        OF.f3_Country_of_Birth = OG.ClrText(f3_Country_of_Birth.Text);
        OF.f3_Province_of_Birth = OG.ClrText(f3_Province_of_Birth.Text);
        OF.f3_Country_of_Citizenship = OG.ClrText(f3_Country_of_Citizenship.Text);
        OF.f3_Date_of_Last_Arrival = OG.ClrText(f3_Date_of_Last_Arrival.Text);
        OF.f3_I94 = OG.ClrText(f3_I94.Text);
        OF.f3_Current_Nonimmigrant_Status = OG.ClrText(f3_Current_Nonimmigrant_Status.Text);
        OF.f3_Date_Status_Expires = OG.ClrText(f3_Date_Status_Expires.Text);
        OF.f3_Passport_Number = OG.ClrText(f3_Passport_Number.Text);
        OF.f3_Date_Passport_Issued = OG.ClrText(f3_Date_Passport_Issued.Text);
        OF.f3_Date_Passport_Expires = OG.ClrText(f3_Date_Passport_Expires.Text);
        OF.f3_Current_US_Address = OG.ClrText(f3_Current_US_Address.Text);


        flag = OF.Form_03_Update(intEmployeeId);

        if (flag)
        Response.Redirect("form_i129h04.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}

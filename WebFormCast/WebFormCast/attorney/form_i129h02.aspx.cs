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
public partial class form_i129h02 : System.Web.UI.Page
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
            divSublinks.InnerHtml = objG.GetSubLinks(intEmployeeId, strEmployeeSignature, 2);
            hlDownloadPdf.NavigateUrl = "formi129hpdf.aspx?attachment=yes&id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString();
            Initialize();
        }
    }
    protected void Initialize()
    {

        

        
        

        Form_i129H Form129 = new Form_i129H(intEmployeeId);
        txtPreReceiptNo.Text =  Form129.f2_receipt_number;
        txtf2_RequestedNonimmigrantClassification.Text = Form129.f2_RequestedNonimmigrantClassification;
        txtf2_Totalnumberofworkersinpetition.Text = Form129.f2_Totalnumberofworkersinpetition;

        rbf2_BasisforClassification_a.Checked = Form129.f2_BasisforClassification == 1;
        rbf2_BasisforClassification_b.Checked = Form129.f2_BasisforClassification == 2;
        rbf2_BasisforClassification_c.Checked = Form129.f2_BasisforClassification == 3;
        rbf2_BasisforClassification_d.Checked = Form129.f2_BasisforClassification == 4;
        rbf2_BasisforClassification_e.Checked = Form129.f2_BasisforClassification == 5;
        rbf2_BasisforClassification_f.Checked = Form129.f2_BasisforClassification == 6;
        rbf2_RequestedAction_a.Checked = Form129.f2_RequestedAction == 1;
        rbf2_RequestedAction_b.Checked = Form129.f2_RequestedAction == 2;
        rbf2_RequestedAction_c.Checked = Form129.f2_RequestedAction == 3;
        rbf2_RequestedAction_d.Checked = Form129.f2_RequestedAction == 4;
        rbf2_RequestedAction_e.Checked = Form129.f2_RequestedAction == 5;
        rbf2_RequestedAction_f.Checked = Form129.f2_RequestedAction == 6;
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Form_i129H Form129 = new Form_i129H();
        AcglGeneral OG = new AcglGeneral();
        bool flag = false;

        Form129.f2_receipt_number = OG.ClrText(txtPreReceiptNo.Text);
        Form129.f2_RequestedNonimmigrantClassification = OG.ClrText( txtf2_RequestedNonimmigrantClassification.Text);
        Form129.f2_Totalnumberofworkersinpetition = OG.ClrText(txtf2_Totalnumberofworkersinpetition.Text);

        if(rbf2_BasisforClassification_a.Checked)
            Form129.f2_BasisforClassification = 1;
        else if(rbf2_BasisforClassification_b.Checked)
         Form129.f2_BasisforClassification = 2;
        else if(rbf2_BasisforClassification_c.Checked )
            Form129.f2_BasisforClassification = 3;
        else if(rbf2_BasisforClassification_d.Checked )
            Form129.f2_BasisforClassification = 4;
        else if(rbf2_BasisforClassification_e.Checked )
            Form129.f2_BasisforClassification = 5;
        else if(rbf2_BasisforClassification_f.Checked )
            Form129.f2_BasisforClassification = 6;

        if(rbf2_RequestedAction_a.Checked )
            Form129.f2_RequestedAction = 1;
        else if(rbf2_RequestedAction_b.Checked )
            Form129.f2_RequestedAction = 2;
        else if(rbf2_RequestedAction_c.Checked )
            Form129.f2_RequestedAction = 3;
        else if(rbf2_RequestedAction_d.Checked )
            Form129.f2_RequestedAction = 4;
        else if(rbf2_RequestedAction_e.Checked )
            Form129.f2_RequestedAction = 5;
        else if(rbf2_RequestedAction_f.Checked )
            Form129.f2_RequestedAction = 6;

        flag = Form129.Form_02_Update(intEmployeeId);

        if (flag)
        Response.Redirect("form_i129h03.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
            


    }
    
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("form_i129h03.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature);
    }
}


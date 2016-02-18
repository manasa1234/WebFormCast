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

public partial class formg28 : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    string strEmployeeSignature = "";
    string strEmployeeTrackingNo = "";
   
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        //try
        //{
        //    intEmployeeId = Convert.ToInt16(Request["id"]);
        //}
        //catch
        //{
        //    intEmployeeId = 0;
        //}
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
            
            lbtrackingno.Text = Session["Attorney_Employee_TrackingNo"].ToString();  
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

            //clsAttorney OA = new clsAttorney(intAttorney_id);
            //OA.bindCompanyCombo(ddEmployer, 0);
            AcglGeneral objG = new AcglGeneral();
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strEmployeeSignature);
            lbNavigation.Text = objG.GetNavLinks("CASE");
            hlDownloadPdf.NavigateUrl = "formg28pdf.aspx?id=" + intEmployeeId.ToString() + "&signature=" + System.Guid.NewGuid().ToString(); 
            Initialize();
        }
    }
    protected void Initialize()
    {
        WebFormCast.ACLG.Form_G28 OF = new WebFormCast.ACLG.Form_G28(intEmployeeId);
        InRe.Text =OF.InRe;
        Date1.Text = OF.Date1  ;
        FileNo.Text =OF.FileNo  ;
        Name1.Text = OF.Name1 ;

        NameType1_1.Checked = OF.NameType1 == "1";
        NameType1_2.Checked = OF.NameType1 == "2";
        NameType1_3.Checked = OF.NameType1 == "3";

        NameType2_1.Checked = OF.NameType2 == "1";
        NameType2_2.Checked = OF.NameType2 == "2";
        NameType2_3.Checked = OF.NameType2 == "3";

        AptNo1.Text = OF.AptNo1  ;
        Street1.Text = OF.Street1  ;
        City1.Text = OF.City1  ;
        State1.Text = OF.Street1  ;
        Zip1.Text = OF.Zip1  ;
        Name2.Text = OF.Name2  ;
        
        AptNo2.Text = OF.AptNo2 ;
        Street2.Text = OF.Street2  ;
        City2.Text = OF.City2 ;
        State2.Text = OF.Street2  ;
        Zip2.Text = OF.Zip2  ;
        AttorneyFirmNameAddress.Text = OF.AttorneyFirmNameAddress  ;
        AttorneyName.Text = OF.AttorneyName  ;
        AttorneyPhone.Text = OF.AttorneyPhone   ;
        AttorneyName2.Text = OF.AttorneyName2  ;
        Form129Name.Text = OF.Form129Name  ;
        CompanyPersonName.Text = OF.CompanyPersonName  ;
        Date2.Text = OF.Date2  ;
        Note.Text  = OF.Note  ;
    }
    protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int intCompanyId = 0;
        //intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
        //Company oC = new Company(intCompanyId);
        //lbCompanyName.Text = oC.Legal_Name.ToString() + " Case List";
        //ShowGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Form_G28 OF = new Form_G28();
        OF.InRe=InRe.Text  ;
        OF.Date1=Date1.Text;
        OF.FileNo=FileNo.Text;
        OF.Name1=Name1.Text;

        if(NameType1_1.Checked)
            OF.NameType1 = "1";
        if(NameType1_2.Checked)
            OF.NameType1 = "2";
        if(NameType1_3.Checked)
            OF.NameType1 = "3";

        if(NameType2_1.Checked)
            OF.NameType2 = "1";
        if(NameType2_2.Checked)
            OF.NameType2 = "2";
        if(NameType2_3.Checked)
             OF.NameType2 = "3";

        OF.AptNo1 = AptNo1.Text;
        OF.Street1 = Street1.Text;
        OF.City1 = City1.Text;
        OF.Street1 = State1.Text;
        OF.Zip1 = Zip1.Text;
        OF.Name2 = Name2.Text;

        OF.AptNo2 = AptNo2.Text;
        OF.Street2 = Street2.Text;
        OF.City2 = City2.Text;
        OF.Street2 = State2.Text;
        OF.Zip2 = Zip2.Text;
        OF.AttorneyFirmNameAddress = AttorneyFirmNameAddress.Text;
        OF.AttorneyName = AttorneyName.Text;
        OF.AttorneyPhone = AttorneyPhone.Text;
        OF.AttorneyName2 = AttorneyName2.Text;
        OF.Form129Name = Form129Name.Text;
        OF.CompanyPersonName = CompanyPersonName.Text;
        OF.Date2 = Date2.Text;
        OF.Note = Note.Text;
        OF.Form_G28_Update(intEmployeeId); 


    }
}

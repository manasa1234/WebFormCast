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
//using WebSupergoo.ABCpdf5;
public partial class attorney_formg28pdf : System.Web.UI.Page
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


        if (intAttorney_id <= 0)
        {
            Response.Redirect("index.aspx");
        }
        try
        {
            //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            //lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
        }
        catch
        { }
        if (!IsPostBack)
        {
            Initialize();
        }
    }
    protected void Initialize()
    {
        //ACLG.Form_G28 FG = new Form_G28(intEmployeeId);
        
        //AcglGeneral objG = new AcglGeneral();
        
        

        //Doc theDoc = new Doc();
        //theDoc.SetInfo(0, "License", "322-594-815-276-4005-092 ABCpdf .NET Pro 5");
        // theDoc.Read(Server.MapPath("../orgpdf/G28.pdf"));

        // theDoc.Form["memInRe"].Value = FG.InRe;
        //    if(FG.Date1=="")
        //    theDoc.Form["txtDate"].Value = DateTime.Now.ToString("MM/dd/yyyy");
        //    else
        //    theDoc.Form["txtDate"].Value = FG.Date1;
        // theDoc.Form["memName1"].Value = FG.Name1;
         
        // theDoc.Form["memMatter"].Value = FG.Form129Name; 
        ////theDoc.Form["memOthers"].Value ="#########";
        // theDoc.Form["txtAptNo1"].Value = FG.AptNo1;
        // theDoc.Form["txtCity1"].Value = FG.City1;
        // theDoc.Form["txtNumSt1"].Value = FG.Street1;
        // theDoc.Form["txtState1"].Value = FG.State1;
        // theDoc.Form["txtZipCode1"].Value = FG.Zip1;

        // theDoc.Form["chkPetit1"].Value = SetYesOff(FG.NameType1,"1");
        // theDoc.Form["chkApp1"].Value = SetYesOff(FG.NameType1 , "2");
        // theDoc.Form["chkBenef1"].Value = SetYesOff(FG.NameType1, "3");

        // theDoc.Form["chkPetit2"].Value = SetYesOff(FG.NameType2, "1");
        // theDoc.Form["chkBenef2"].Value = SetYesOff(FG.NameType2, "2");
        // theDoc.Form["chkApp2"].Value = SetYesOff(FG.NameType2, "3");
        
        //theDoc.Form["chkItem1"].Value ="Yes";
        //theDoc.Form["chkItem2"].Value ="Off";
        //theDoc.Form["chkItem3"].Value ="Off";
        //theDoc.Form["chkItem4"].Value ="Off";
        
        //theDoc.Form["Attorneys_FirstName+Attorneys_MiddleName+Attorneys_LastName"].Value = FG.AttorneyName;
        //theDoc.Form["Attorneys_FirstName+Attorneys_MiddleName+Attorneys_LastName1"].Value = FG.AttorneyName2;
        //theDoc.Form["Attorneys_FirmName+Attorneys_StreetAddress+Attorneys_SuiteNumber+Attorneys_City+Attorneys_State+Attorneys_ZipCode"].Value = FG.AttorneyFirmNameAddress; 

        ////theDoc.Form["Attorneys_LicensedArea"].Value = "Attorneys_LicensedArea";
        //theDoc.Form["Attorneys_PhoneNumber"].Value = FG.AttorneyPhone;
        //theDoc.Form["PersName"].Value = FG.CompanyPersonName;
        //theDoc.Form["Rider"].Value = FG.Note;
        
        //Byte[] theData = theDoc.GetData();
        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-length", theData.Length.ToString());
        
        //if (Request.QueryString["attachment"] != null)
        //    Response.AddHeader("content-disposition", "attachment; filename=MyPDF.PDF");
        //else
        //    Response.AddHeader("content-disposition", "inline; filename=MyPDF.PDF");

        //Response.BinaryWrite(theData);

        ////theDoc.Save(Server.MapPath("eformstamp.pdf")); 
        ////txtInre.Text = oE.LastName.ToUpper() + ", " + objG.Capitilaze(oE.FirstName) + " " + objG.Capitilaze(oE.MiddleName);
        ////txtEmployerName.Text = OE1.Legal_Name.ToString();
        ////txtAptNo.Text = OE1.Add_AptNo;
        ////txtStreet.Text = OE1.Add_Street;
        ////txtCity.Text = OE1.Add_City;
        ////txtState.Text = OE1.Add_State;
        ////txtZip.Text = OE1.Add_Zip;
        ////txtAttorney_Address.Text = OA.Address;
        ////txtAttorney_Name1.Text = OA.Name;
        ////txtAttorney_Phone.Text = OA.Phone;
        ////txtAttorney_Fax.Text = OA.Fax;
        ////txtAttorney_Name2.Text = OA.Name;
        ////txtEmployeeName.Text = "In RE: " + oE.LastName.ToUpper() + " " + objG.Capitilaze(oE.FirstName) + " " + objG.Capitilaze(oE.MiddleName) + " FORM-I-539";
        ////txtEmpoyer1.Text = OE1.Person_FullName;
    }
    protected string GetChar(string v1, int p)
    {

        string strCh = "";
        if (v1.Length >= p)
            strCh = v1.Substring(p - 1, 1);
        return strCh;
    }

    protected string SetYesOff(bool v1, bool v2)
    {
        if (v1 == v2)
            return "Yes";
        else
            return "Off";
    }
    protected string SetYesOff(string  v1, string  v2)
    {
        if (v1 == v2)
            return "Yes";
        else
            return "Off";
    }
    protected string SetYesOff(int v1, int v2)
    {
        if (v1 == v2)
            return "Yes";
        else
            return "Off";
    }
}

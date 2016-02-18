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
public partial class attorney_templatedit : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    int intTemplateId = 0;
    string strEmployeeSignature = "";
    string strToday = "";
    int visaid = 0;
    int companyid = 0;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        strToday = DateTime.Today.ToString("m") + ", " + DateTime.Today.Year.ToString();
        
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        try
        {
            //intEmployeeId = Convert.ToInt32(Request.Cookies["empid"].Value);
            intEmployeeId = Convert.ToInt32(Session["Attorney_Employee_Id"]);
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
            intTemplateId = Convert.ToInt32(Request["template"]);
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
            AcglGeneral objG = new AcglGeneral();
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strEmployeeSignature);
          
            lbNavigation.Text = objG.GetNavLinks("CASE");

            visaid = Convert.ToInt32(Request.QueryString[1]);
            companyid = Convert.ToInt32(Request.QueryString[2]);
            if(intTemplateId==0)
            {
                intTemplateId = Convert.ToInt32(Request.QueryString[0]);
            }
                 txtTemplateBody.Text = getTemplate(visaid,companyid);
                 //hlDownloadPdf.NavigateUrl = "templatepdf.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "&template=" + intTemplateId;
                 if (intTemplateId == 1)
                     lbTemplate.Text = "Offer of Employment";
                 else if (intTemplateId == 3)
                     lbTemplate.Text = "Itinerary";
                 else if (intTemplateId == 2)
                     lbTemplate.Text = "Support Letter";
            

        }

    }

    protected string getTemplate(int intvisaid,int intcompanyid)
    {
        string strBody = "";
        string strHeader = "";
        string strFooter = "";
        int intHH = 0;
        int intFH = 0;
        string strCustBody = "";
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        clsAttorney OA = new clsAttorney(intAttorney_id);
        clsTemplate OT = new clsTemplate();
        AcglGeneral OG = new AcglGeneral();
        
        //strBody = OT.Get_TemplateBody(intAttorney_id, OE.Company_id, OE.Visa_Type_id, intTemplateId);
        hfTemplateID.Value = OT.TemplateID.ToString();
        strCustBody = OT.Get_CustomTemplateBody1(intTemplateId, intcompanyid, intvisaid);

        if (strCustBody != "")
        {
            //hlDelete.Visible = true;
            return strCustBody;
        }



        strHeader = OT.Header;
        strFooter = OT.Footer;
        intHH = OT.HHeight;
        intFH = OT.FHeight;
        strHeader = strHeader.Replace("src=\"../", "src=\"http://webformcast.azurewebsites.net/");
        strBody = strBody.Replace("#DATE#", strToday);
        strBody = strBody.Replace("#LASTNAME#", OE.LastName.ToUpper());
        strBody = strBody.Replace("#LastName#", OG.Capitilaze(OE.LastName));
        strBody = strBody.Replace("#FirstName#", OG.Capitilaze(OE.FirstName));
        strBody = strBody.Replace("#JobTitle#", OG.Capitilaze(OE.JobTitel));
        strBody = strBody.Replace("#Skills#", OG.Capitilaze(OE.Skills));
        strBody = strBody.Replace("#JobDescription#", OG.Capitilaze(OE.JobDescription));
        strBody = strBody.Replace("#Wages#", OG.Capitilaze(OE.WagsperYear));
        strBody = strBody.Replace("#AttorneyName#", OA.Name);
        strBody = strBody.Replace("#EmployerCity#", OE.USAddress_City);

        if (strBody.IndexOf("#EducationDetails#") > 0)
        {
            strBody = strBody.Replace("#EducationDetails#", displayEducation(intEmployeeId));
        }

        if (strBody.IndexOf("#ExperienceDetails#") > 0)
        {
            strBody = strBody.Replace("#ExperienceDetails#", displayProfesnalInfo(intEmployeeId));
        }


        //if (intHH > 0)
        //{
        //    strBody = strHeader + strBody;
        //    strBody = strBody.Replace("</p>##<p>", "<br>");
        //}


        //if (intFH > 0)
        //{
        //    strBody = strBody + strFooter;
        //    strBody = strBody.Replace("</p>##<p>", "<br>");
        //}

        return strBody;
    }

    protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int intCompanyId = 0;
        //intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
        //Company oC = new Company(intCompanyId);
        //lbCompanyName.Text = oC.Legal_Name.ToString() + " Case List";
        //ShowGrid();
    }
    
    protected string displayEducation(int intEmployeeId)
    {

        string strRowEducation = "";
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetEducationList(intEmployeeId);
        strRowEducation = "<table border='1' cellspacing='0' cellpadding='0' width='100%'>";
        strRowEducation += "<tr><td><b>UNIVERSITY / BOARD</b></td><td><b>FROM MM/YY</b></td><td><b>TO MM/YY</b></td><td><b>GRAD YR</b></td><td><b>DEGREE / DIPLOMA</b></td></tr>";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strRowEducation += "<tr>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["University"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["GradYear"].ToString() + "</td>";
            strRowEducation += "<td>" + ds.Tables[0].Rows[i]["Degree_Name"].ToString() + "</td>";
            strRowEducation += "</tr>";
        }
        strRowEducation += "</table>";
        return strRowEducation;
    }


    protected string displayProfesnalInfo(int intEmployeeId)
    {
        string strRowProfesnal;
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetProfession(intEmployeeId);
        strRowProfesnal = "<table border='1' cellspacing='0' cellpadding='0' width='100%'>";
        strRowProfesnal += "<tr><td><b>EMPLOYER & ADDRESS</b></td><td><b>FROM MM/YY</b></td><td><b>TO MM/YY</b></td><td><b>SKILLS USED</b></td><td><b>DESIGNATION</b></td></tr>";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            strRowProfesnal += "<tr>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["Employer"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["FromMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["FromYear"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["ToMonth"].ToString() + "/" + ds.Tables[0].Rows[i]["ToYear"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["Skills"].ToString() + "</td>";
            strRowProfesnal += "<td>" + ds.Tables[0].Rows[i]["Designation"].ToString() + "</td>";
            strRowProfesnal += "</tr>";
        }
        strRowProfesnal += "</table>";
        return strRowProfesnal;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strBody = "";
        int intTemplateId = 0;
        strBody = txtTemplateBody.Text;
        intTemplateId = Convert.ToInt16(hfTemplateID.Value);
        clsTemplate OT = new clsTemplate();
        visaid = Convert.ToInt32(Session["visaid"]);
        companyid = Convert.ToInt32(Session["companyid"]);
        OT.Update_CustTemplate1(visaid,intEmployeeId, intTemplateId, strBody);
      
      string visaid1 =Request.QueryString[1];
      string  companyid1 = Request.QueryString[2];
      intTemplateId = Convert.ToInt32(Request.QueryString[0]);
      Response.Redirect("templateview.aspx?template=" + intTemplateId + "&visaid1=" + visaid1 + "&companyid1=" + companyid1);
    }
}
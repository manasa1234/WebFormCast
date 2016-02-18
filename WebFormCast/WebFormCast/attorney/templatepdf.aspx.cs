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

public partial class attorney_templatepdf : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    int intTemplateId = 0;
    string strEmployeeSignature = "";
    string strPdf = "";
    string strToday = "";
    string strHeader = "";
    string strFooter = "";
    int intHHeight = 0;
    int intFHeight = 0;
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
            intTemplateId = Convert.ToInt16(Request["template"]);
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


        Response.Expires = -1000;
        //Doc theDoc = new Doc();
        //string strPdf = "";
        //int theID = 0;
        //int w = 612;
        //int h = 792;
        ////int x1 = 0;
        ////int y1 = 0;
        
        //int x1 = 0;
        //int x2 = 0;
        //int Fy1 = 0;
        //int Fy2 = 0;
        //int Hy1 = 0;
        //int Hy2 = 0;
        //int By1 = 0;
        //int By2 = 0;


        //int Height = 792;
        //int Width = 612;
        //int leftM = 60;
        //int rightM = 30;
        //int topM = 10;
        //int bottomM = 10;
        //int Hheight = 98;
        //int Fheight = 60;


        //x1 = leftM;
        //x2 = Width - rightM;

        //Fy1 = bottomM;
        //Fy2 = bottomM + Fheight;



        //Hy1 = Height - (topM + Hheight);
        //Hy2 = Height - topM;

        //By1 = Fy2;
        //By2 = Hy1;

        ////try
        ////{
        ////    w = Convert.ToInt16(Request["w"]);
        ////}
        ////catch { }
        ////try
        ////{
        ////    h = Convert.ToInt16(Request["h"]);
        ////}
        ////catch { }
        ////try
        ////{
        ////    x1 = Convert.ToInt16(Request["x"]);
        ////}
        ////catch { }
        ////try
        ////{
        ////    y1 = Convert.ToInt16(Request["y"]);
        ////}
        ////catch { }


        //strPdf = getTemplateBody();
        ////theDoc.Rect.SetRect(x1, y1, w, h);
        //theDoc.Rect.String = x1.ToString() + " " + By1.ToString() + " " + x2.ToString() + " " + By2.ToString();
        //theID = theDoc.AddImageHtml(strPdf, true, 0, false); //(strPdf, True, 0, False);

        //while(theDoc.GetInfo(theID, "Truncated")== "1")
        // {
        //    theDoc.Page = theDoc.AddPage();
        //    theID = theDoc.AddImageToChain(theID);
        //    //theDoc.FrameRect()
        // }


        //int theCount = 0;
        //int i;
        //i = 0;
        //theCount = theDoc.PageCount;
        ////theDoc.Rect.String = "30 750 570 780";

        //if (strHeader != "")
        //{
        //    theDoc.Rect.String = x1.ToString() + " " + Hy1.ToString() + " " + x2.ToString() + " " + Hy2.ToString();
        //    //theDoc.HPos = 0.5;
        //    //theDoc.VPos = 0.5;
        //    //theDoc.Color.String = "0 255 0";
        //    //theDoc.FontSize = 10;
        //    for (i = 1; i <= theCount; i++)
        //    {
        //        theDoc.PageNumber = i;
        //        theDoc.AddImageHtml(strHeader, true, 0, false);
        //        //theDoc.FrameRect();
        //    }

        //}

        //if (strFooter != "")
        //{
        //    theDoc.Rect.String = x1.ToString() + " " + Fy1.ToString() + " " + x2.ToString() + " " + Fy2.ToString();
        //    //theDoc.HPos = 0.5;
        //    //theDoc.VPos = 0.5;
        //    //theDoc.Color.String = "0 255 0";
        //    //theDoc.FontSize = 10;
        //    for (i = 1; i <= theCount; i++)
        //    {
        //        theDoc.PageNumber = i;
        //        theDoc.AddImageHtml(strFooter, true, 0, false);
        //        //theDoc.FrameRect();
        //    }

        //}

        //theDoc.Rect.String = x1.ToString() + " 1 " + x2.ToString() + " 20";
        //theDoc.HPos = 1.0;
        //theDoc.VPos = 0.5;
        //theDoc.FontSize = 10;
        //theCount = theDoc.PageCount;
        //for (i = 1; i <= theCount; i++)
        //{
        //    theDoc.PageNumber = i;
        //    theDoc.AddText("Page " + i.ToString() + " of " + theCount);
        //}

        // for (int I = 1; I <= theDoc.PageCount; I++)
        // {
        //     theDoc.PageNumber = I;
        //     theDoc.Flatten();
        // }

        //Byte[] theData = theDoc.GetData();
        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-length", theData.Length.ToString());
        //if (Request.QueryString["attachment"] != null)
        //    Response.AddHeader("content-disposition", "attachment; filename=MyPDF.PDF");
        //else
        //    Response.AddHeader("content-disposition", "inline; filename=MyPDF.PDF");

        //Response.BinaryWrite(theData);
    }
    protected string  getTemplateBody()
    {
        string strBody = "";
        string strCustBody = "";
        string strAddress = "";
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        clsAttorney OA = new clsAttorney();
        AcglGeneral OG = new AcglGeneral();
        clsTemplate OT = new clsTemplate();

        strBody = OT.Get_TemplateBody(intAttorney_id, OE.Company_id, OE.Visa_Type_id, intTemplateId);
        strHeader = OT.Header;
        strFooter = OT.Footer;
        intHHeight = OT.HHeight;
        intFHeight = OT.FHeight;
        strCustBody = OT.Get_CustomTemplateBody(OT.TemplateID, intEmployeeId);

        if (strCustBody != "")
        {
            strBody= strCustBody;
        }
        strBody = strBody.Replace("#AttorneyName#", OA.Name);
        strBody = strBody.Replace("#EmployerCity#", OE.USAddress_City);
        if (OE.CurrentAddress == 1)
            strAddress = OE.ForeignAddress;
        else
        {
            strAddress = OE.USAddress_Street + ", " + OE.USAddress_AppNo;
            strAddress += "<br>" + OE.USAddress_City + "," + OE.USAddress_State + " " + OE.USAddress_Zip;
        }

        strHeader = strHeader.Replace("src=\"../", "src=\"http://webformcast.azurewebsites.net/");
        strFooter = strFooter.Replace("src=\"../", "src=\"http://webformcast.azurewebsites.net/");
        strBody = strBody.Replace("#Date#", strToday);
        strBody = strBody.Replace("#Title#", OE.Title);
        strBody = strBody.Replace("..", ".");
        strBody = strBody.Replace("''", "'");
        strBody = strBody.Replace("''''", "''");
        strBody = strBody.Replace("#Address#", strAddress);
        strBody = strBody.Replace("#LASTNAME#", OE.LastName.ToUpper());
        strBody = strBody.Replace("#LastName#", OG.Capitilaze(OE.LastName));
        strBody = strBody.Replace("#MiddleName#", OG.Capitilaze(OE.MiddleName));
        strBody = strBody.Replace("#FirstName#", OG.Capitilaze(OE.FirstName));
        strBody = strBody.Replace("#JobTitle#", OG.Capitilaze(OE.JobTitel));
        strBody = strBody.Replace("#Skills#", OG.Capitilaze(OE.Skills));
        strBody = strBody.Replace("#JobDescription#", OG.Capitilaze(OE.JobDescription));
        strBody = strBody.Replace("#Wages#", OG.Capitilaze(OE.WagsperYear));
        strBody = strBody.Replace("#SecondLocation#", OE.WorkLocation);
        strBody = strBody.Replace("#Citizen#", OE.CountryofCitixenship);
        strBody = strBody.Replace("#StartDate#", OE.DateIntendedFrom);
        strBody = strBody.Replace("#EndDate#", OE.DateIntendedTo);

        
        
        

        if (strBody.IndexOf("#EducationDetails#") > 0)
        {
            strBody = strBody.Replace("#EducationDetails#", displayEducation(intEmployeeId));
        }

        if (strBody.IndexOf("#ExperienceDetails#") > 0)
        {
            strBody = strBody.Replace("#ExperienceDetails#", displayProfesnalInfo(intEmployeeId));
        }


        return strBody;
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
}

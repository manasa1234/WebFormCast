using ACLGDataAaccess;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebFormCast.ACLG;
using System.IO;
using  iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Text.RegularExpressions;
//using WebSupergoo.ABCpdf5;
public partial class attorneytemplateview : System.Web.UI.Page
{
    int intEmployeeId = 0;
    int intAttorney_id = 0;
    int intTemplateId = 0;
    string companyname = "";
    string strEmployeeSignature = "";
    string strToday = "";
    int visaid = 0;
    int companyid = 0;
    string trackno = "";
    string path = @"c:\PDF_Files\"; int val = 0;


    
    protected void Page_Load(object sender, EventArgs e)
    {
        strToday = DateTime.Today.ToString("m") + ", " + DateTime.Today.Year.ToString();
        tmp.Visible = false;
        
 
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        try
        {
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
            intTemplateId = Convert.ToInt16(Request["template"]);
        }catch{}


        try
        {

            lbtrackingno.Text = Session["Attorney_Employee_TrackingNo"].ToString();
            trackno = Session["Attorney_Employee_TrackingNo"].ToString();
        }
        catch { }
        try
        {

            lbCompanyName.Text = Session["Attorney_CompanyName"].ToString();
            companyname = Session["Attorney_CompanyName"].ToString();
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
            //lbFormLinks.Text = objG.GetFormLinks(intTemplateId, visaid);
            //lbTemplatebody.Text = getTemplate();
            //path = "templatepdf.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "&template=" + intTemplateId;
            //WebClient client = new WebClient();
            //Byte[] buffer = client.DownloadData(hlDownloadPdf.NavigateUrl + getTemplate());
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-length", buffer.Length.ToString());
            //Response.BinaryWrite(buffer);
            //hlEdit.NavigateUrl = "templatedit.aspx?template=" + intTemplateId;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            int t = CountQueryStringKey(url);
            

            if (t>1)
            {
                visaid = Convert.ToInt32(Request.QueryString[1]);
                companyid = Convert.ToInt32(Request.QueryString[2]);
                tmp.Visible = true;
                dropdown.Visible = false;
                lbTemplatebody.Text = getTemplate(visaid, companyid);
            } 
            else
            {if (intTemplateId == 1)
                    lbTemplate.Text = "Offer of Employment";
                else if (intTemplateId == 3)
                    lbTemplate.Text = "Itinerary";
                else if (intTemplateId == 2)
                    lbTemplate.Text = "Support Letter";
                getvisvalues();
                companyid = getcompanyid();
            }
          
        }
    }
    public int CountQueryStringKey(string urlString)
    {
        string urlWithoutKey = urlString.Substring(0, urlString.IndexOf("?"));
        string allKeyString = urlString.Substring(urlString.IndexOf("?") + 1);
        string[] allKeyAndValue = allKeyString.Split('&');
        return allKeyAndValue.Length;
    }
    protected string getTemplate(int visaid, int companyid)
    {

        string strSql = "";
        SqlDataReader dr;
        ACLGDB DB = new ACLGDB();
        strSql = "SELECT [Template_Body] FROM [dbo].[Employee_Templates] where Template_Id=" + intTemplateId + "and Employee_id=" + intEmployeeId + "and Visa_Type=" + visaid;
        string strBody= "";
        dr = DB.getReader(strSql);
        if (dr.Read())
        {

            strBody = dr["Template_Body"].ToString();
            strBody = HttpContext.Current.Server.HtmlDecode(strBody);
        }
        dr.Close();
       

        return strBody;
    }
  
    private int getcompanyid()
    {
        string strSql = "";
        SqlDataReader dr;
        ACLGDB DB = new ACLGDB();
        strSql = "SELECT [CompanyID] FROM [dbo].[Company] where [Legal_Name]='" + companyname+"'";
        companyid = 0;
        dr = DB.getReader(strSql);
        if (dr.Read())
        {
            companyid = Convert.ToInt32(dr["CompanyID"].ToString());
            
        }
        dr.Close();
        return companyid;
    }

    private void getvisvalues()
    {
        ddvisatype.Items.Add(new System.Web.UI.WebControls.ListItem("--Select Visa Type--", ""));
        ddvisatype.AppendDataBoundItems = true;
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        String strQuery = "select Visa_Type_Id,Visa_Type_Name from Visa_Type ";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strQuery;
        cmd.Connection = con;
        try
        {
            con.Open();
            ddvisatype.DataSource = cmd.ExecuteReader();
            ddvisatype.DataTextField = "Visa_Type_Name";
            ddvisatype.DataValueField = "Visa_Type_Id";
            ddvisatype.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            con.Close();
            con.Dispose();

        }
    }

    protected string getTemplate()
    {
        tmp.Visible = true;
        dropdown.Visible = false;
     
        string strBody = "";
        string strHeader = "";
        string strFooter = "";
        string strCustBody = "";
        string strAddress = "";
        int intHH = 0;
        int intFH = 0;
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        clsAttorney OA = new clsAttorney(intAttorney_id);
        clsTemplate OT = new clsTemplate(intAttorney_id, OE.Company_id, OE.Visa_Type_id, intTemplateId);
        AcglGeneral OG = new AcglGeneral();
        strBody = OT.Body; 
        strHeader = OT.Header;
        strFooter = OT.Footer;
        intHH = OT.HHeight;
        intFH = OT.FHeight;
        companyid = getcompanyid();
        if(ddvisatype.SelectedValue=="")
        {

        }
        else
        visaid=Convert.ToInt32(ddvisatype.SelectedValue);
        strCustBody = OT.Get_CustomTemplateBody1(intTemplateId, companyid, visaid);

        if (strCustBody != "")
        {
            hlDelete.Visible = true;
            //return strCustBody;
            strBody = strCustBody;
        }
        

        hlDelete.Visible = false;
        //strHeader = strHeader.Replace("src=\"../", "src=\"http://webformcast.azurewebsites.net/");

        strBody = strBody.Replace("#AttorneyName#", OA.Name);
        strBody = strBody.Replace("#EmployerCity#", OE.USAddress_City);
        if (OE.CurrentAddress == 1)
            strAddress = OE.ForeignAddress;
        else
        {
            strAddress = OE.USAddress_Street + ", " + OE.USAddress_AppNo;
            strAddress += "<br>" + OE.USAddress_City + "," + OE.USAddress_State + " " + OE.USAddress_Zip; 
        }


        strBody = strBody.Replace("#Date#", strToday);
        strBody = strBody.Replace("#Title#", OE.Title );
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
        

        //if (intHH > 0)
        //{
        //    strBody = strHeader +   strBody;
        //    strBody = strBody.Replace("</p>##<p>","<br>");
        //}
        //if (intFH > 0)
        //{
        //    strBody = strBody +  strFooter;
        //    strBody = strBody.Replace("</p>##<p>","<br>");
        //}

         return  strBody;
    }
    //protected string ReplaceWEBVariables(string strBody)
    //{
        
    //}
    protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int intCompanyId = 0;
        //intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue);
        //Company oC = new Company(intCompanyId);
        //lbCompanyName.Text = oC.Legal_Name.ToString() + " Case List";
        //ShowGrid();
    }
    //protected void btnPdfGenerate_Click(object sender, EventArgs e)
    //{

    //    string strPdf = "";
    //    Session["doc"] = new Doc();
    //    Doc theDoc = (Doc)Session["doc"];
    //    //theDoc.SetInfo(0, "License", "322-594-815-276-4005-092 ABCpdf .NET Pro 5");
    //    int w = 530;
    //    int h = 800;
    //    int x1 = 30;
    //    int y1 = 0;
    //    int theID = 0;
    //    theDoc.Rect.SetRect(x1, y1, w, h);
    //    strPdf = getTemplateBody();
    //    theID = theDoc.AddImageHtml(strPdf, true, 0, false); //(strPdf, True, 0, False);
    //    Response.Write("<script language='javascript'>window.open('templatepdf.aspx?attachment=true','pdf');</script>");
    //}

    protected string  displayEducation(int intEmployeeId)
    {

        string strRowEducation = "";
        DataSet ds = new DataSet();
        AcglEmployee OE = new AcglEmployee();
        ds = OE.GetEducationList(intEmployeeId);
        strRowEducation="<table border='1' cellspacing='0' cellpadding='0' width='100%'>";
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


    protected string  displayProfesnalInfo(int intEmployeeId)
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

    protected void ddvisatype_SelectedIndexChanged(object sender, EventArgs e)
    {
        visaid = Convert.ToInt32(ddvisatype.SelectedValue);
        dropdown.Visible = false;
        tmp.Visible = true;
        lbTemplatebody.Text = getTemplate();
        string strBody = lbTemplatebody.Text;
        clsTemplate OT = new clsTemplate();
        //OT.Update_CustTemplate1(visaid, intEmployeeId, intTemplateId, strBody);
        //string url=HttpContext.Current.Request.Url.AbsoluteUri;
        //Context.RewritePath(url + "&visa=" + visaid);
        //val = Convert.ToInt32(Session["visaid"].ToString());
    
    }
    

    protected void hlDownloadPdf_Click(object sender, EventArgs e)
    {
        AcglEmployee OE = new AcglEmployee(intEmployeeId);
        path = OE.LastName + " templatepdf.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "&template=" + intTemplateId;
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename="+path+".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
       lbTemplatebody.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End(); 
    }

    protected void hlEdit_Click(object sender, EventArgs e)
    {
        tmp.Visible = true;
        //Session["visaid"] =ddvisatype.SelectedValue;
        companyid = getcompanyid();
       //Session["companyid"] = Convert.ToString(companyid);
       //Session["empid"]= Convert.ToString(intEmployeeId);
     //lbTemplatebody.Visible = false;

     //txtTemplateBody.Visible = true;
     //string str = lbTemplatebody.Text.ToString();
     ////str = Regex.Replace(str, "<(.|\n)*?>", "");
     //str = Server.HtmlDecode(str);
     //txtTemplateBody.Text = str.ToString();'
        if (ddvisatype.SelectedValue == "")
        {
            visaid = 0;
        }
            
        else
        {
            visaid = Convert.ToInt32(ddvisatype.SelectedValue);
        }
        if(visaid==0)
        {
            visaid = Convert.ToInt32(Request.QueryString[1]);
        }
        if(intTemplateId==0)
        {
            intTemplateId=Convert.ToInt32(Request.QueryString[0]);
        }
        Response.Redirect("templatedit.aspx?template=" + intTemplateId+"&visaid="+visaid+"&companyid="+companyid);

    }

    protected void hlDelete_Click(object sender, EventArgs e)
    {

        string strSql = "";
        SqlDataReader dr;
        ACLGDB DB = new ACLGDB();
        strSql = "Delete FROM [dbo].[Employee_Templates] where Template_Id=" + intTemplateId + "and Employee_id=" + intEmployeeId + "and Visa_Type=" + visaid;
        string strBody = "";
        dr = DB.getReader(strSql);
        
        dr.Close();


       
    }
   
    
}

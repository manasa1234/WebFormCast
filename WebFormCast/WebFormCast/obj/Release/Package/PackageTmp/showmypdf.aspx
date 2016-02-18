<%@ Page Language="C#" %>
<%@ Assembly Name="ABCpdf" %>
<%@ Import Namespace="WebSupergoo.ABCpdf5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    protected void Page_Load(object sender, EventArgs e)
    {

        string theURL="";

        try
        {

            theURL = Request["txturl"].ToString();
        }
        catch { }
        

        if (theURL != "")
        {
            Doc theDoc = new Doc();


			//theDoc.SetInfo(0, "License", "719-253-057-515-1225-12762521 ABCpdf ASP Pro 7");

            if (!theURL.StartsWith("http"))
                theURL = "http://" + theURL;

            bool pagedOutput = Request.Form["PagedOutput"] == "on";
            theDoc.HtmlOptions.PageCacheEnabled = false;
            theDoc.HtmlOptions.AddForms = true;
            theDoc.HtmlOptions.AddLinks = true;
            theDoc.HtmlOptions.AddMovies = false;
            theDoc.HtmlOptions.FontEmbed = true;
            theDoc.HtmlOptions.UseResync = true;
            theDoc.HtmlOptions.UseVideo = false;
            //theDoc.HtmlOptions.UseJava = Request.Form["UseJava"] == "on";
            //theDoc.HtmlOptions.UseActiveX = Request.Form["UseActiveX"] == "on";
            theDoc.HtmlOptions.UseScript = false;
            theDoc.HtmlOptions.HideBackground = false;
            //theDoc.HtmlOptions.Timeout = ValidateRangeInt(Request.Form["Timeout"], 1000, 100000, "Incorrect timeout value");
            //theDoc.HtmlOptions.LogonName = Request.Form["UserName"];
            //theDoc.HtmlOptions.LogonPassword = Request.Form["Password"];

            theDoc.HtmlOptions.BrowserWidth = 0;

            theDoc.HtmlOptions.ImageQuality = 101;

            theDoc.Rect.SetRect(30, 0, 530, 800);

            // Add url to document.
            try
            {
                int theID = theDoc.AddImageUrl(theURL);
                if (pagedOutput)
                { // Add up to 3 pages.
                    for (int i = 1; i <= 3; i++)
                    {
                        if (!theDoc.Chainable(theID))
                            break;
                        theDoc.Page = theDoc.AddPage();
                        theID = theDoc.AddImageToChain(theID);
                    }
                    theDoc.PageNumber = 1;
                }
            }
            catch
            {

                Response.Write("<p>Web page is inaccessible. Please try another URL.</p>");

            }
            Response.Expires = -1000;
            byte[] theData = theDoc.GetData();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", theData.Length.ToString());
            if (Request.QueryString["attachment"] != null)
                Response.AddHeader("content-disposition", "attachment; filename=MyPDF.PDF");
            else
                Response.AddHeader("content-disposition", "inline; filename=MyPDF.PDF");
            Response.BinaryWrite(theData);
        }
        else
            Response.Write("<p>Web page is inaccessible. Please try another URL.</p>");
    }
</script>


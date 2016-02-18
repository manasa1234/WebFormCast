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
public partial class attorney_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Session["Attorney_Id"] = null;
        Session["Attorney_User_Type"] = null;
        Session["Attorney_User_Id"] = null;
        Session.Clear();
        Session.Abandon();
        Response.Redirect("index.aspx?action=1");
    }
}

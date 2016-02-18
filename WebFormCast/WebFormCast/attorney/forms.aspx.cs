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
public partial class attorneyforms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("FORMS");
    }
}

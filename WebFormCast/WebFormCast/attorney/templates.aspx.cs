using ACLGDataAaccess;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebFormCast.ACLG;

public partial class attorneytemplatesnew : System.Web.UI.Page
{
    int intAttorney_id = 0;
    int intCompany_id = 0;
    int intTemplate_id = 0;
    int intVisaType_id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbmsg.Text = "&nbsp;";
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
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
            clsAttorney OA = new clsAttorney(intAttorney_id);
            OA.bindCompanyCombo(ddCompany, 0);

            AcglGeneral OG = new AcglGeneral();
            OG.bindTypeCombo(ddVisaType, 0);
            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("TEMPLATE");

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddCompany.SelectedIndex > 0 && ddTemplates.SelectedIndex > 0 && ddVisaType.SelectedIndex > 0)
        {
            intCompany_id = Convert.ToInt16(ddCompany.SelectedValue);
            intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
            intVisaType_id = Convert.ToInt16(ddVisaType.SelectedValue);
        }

        string strBody = "";
        string strHeader = "";
        string strFooter = "";
        int strHH = 0;
        int strFH = 0;
        strBody = txtTemplateBody.Text;
        //strBody = strBody.Replace("'", "''");

        strHeader = txtTemplateHeader.Text;
        strFooter = txtTemplateFooter.Text;
        strHH = Convert.ToInt32(txtHHeight.Text);
        strFH = Convert.ToInt32(txtFHeight.Text);

        clsTemplate OT = new clsTemplate();

        if (intCompany_id > 0 && intTemplate_id > 0 && intVisaType_id > 0)
        {
            OT.Update_Template(intAttorney_id, intCompany_id, intTemplate_id, intVisaType_id, strBody, strHeader, strFooter, strHH, strFH);
            lbmsg.Text = "Template has been saved!";
        }


    }

    protected void getTemplateBody()
    {
        //txtTemplateBody.Text = "";
        //if (ddCompany.SelectedIndex > 0 && ddTemplates.SelectedIndex > 0 && ddVisaType.SelectedIndex > 0)
        //{
        //    intCompany_id = Convert.ToInt16(ddCompany.SelectedValue);
        //    intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
        //    intVisaType_id = Convert.ToInt16(ddVisaType.SelectedValue); 
        //    clsTemplate OT = new clsTemplate();
        //    txtTemplateBody.Text = OT.Get_TemplateBody(intAttorney_id, intCompany_id, intVisaType_id, intTemplate_id);
        //    txtTemplateHeader.Text = OT.Header;
        //    txtTemplateFooter.Text = OT.Footer;
        //    txtHHeight.Text = OT.HHeight.ToString();
        //    txtFHeight.Text = OT.FHeight.ToString();
        //}
        if (ddTemplates.SelectedIndex > 0 && ddVisaType.SelectedIndex > 0)
        {
            intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
            intVisaType_id = Convert.ToInt16(ddVisaType.SelectedValue);
            clsTemplate OT = new clsTemplate();
            txtTemplateBody.Text = OT.TemplateBody(intVisaType_id, intTemplate_id);
        }
        if (ddCompany.SelectedIndex > 0)
        {
            intCompany_id = Convert.ToInt16(ddCompany.SelectedValue);
            clsTemplate OT = new clsTemplate();
            OT.Get_TemplateHeader(intAttorney_id, intCompany_id);
            txtTemplateHeader.Text = OT.Header;
            //txtTemplateHeader.Height = 20;
            txtTemplateFooter.Text = OT.Footer;
            txtHHeight.Text = OT.HHeight.ToString();
            txtFHeight.Text = OT.FHeight.ToString();
            //count = OT.TemplateHeadercount(intAttorney_id, intCompany_id);
        }

    }
    protected void ddTemplates_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbldt.Visible = true;
        getTemplateBody();
        ACLGDB DB = new ACLGDB();
        string connectionString = DB.ConnectionString;
        string comname = "";
        string fullname = "";
        //string mname = "";
        String strQuery = "SELECT [Legal_Name],[Person_FullName]FROM [dbo].[Company] where CompanyID='" + ddCompany.SelectedValue + "'";
        SqlConnection con = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(strQuery, con);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {    //Every new row will create a new dictionary that holds the columns
                comname = reader["Legal_Name"].ToString();
                fullname = reader["Person_FullName"].ToString();
                //lname = reader["Last_Name"].ToString();

            }
            reader.Close();

        }
        catch (Exception ex)
        {
            //ddrltrack.SelectedValue = "";
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
        if (!string.IsNullOrEmpty(Convert.ToString(txtTemplateBody.Text)))
        {
            //System.IO.StringWriter myWriter = new System.IO.StringWriter();
            // HttpUtility.HtmlDecode(txtTemplateBody.Text,myWriter);

            //string IdOrder = myWriter.ToString();
            String text = Regex.Replace(txtTemplateBody.Text, @"<(.|\n)*?>", string.Empty);
            text = text = Regex.Replace(text, "&nbsp", " ");
            text = text = Regex.Replace(text, ";", " ");
            string IdOrder = text.ToString();
            IdOrder = IdOrder.Trim();
            //replacing "enter" i.e. "\n" by ","
            string temp = IdOrder.Replace("\r\n", " ");
            //Regex.Replace(IdOrder, "#FirstName", fname, RegexOptions.IgnoreCase);
            string[] ArrIdOrders = Regex.Split(temp, " ");

            for (int i = 0; i < ArrIdOrders.Length; i++)
            {
                //string name = fname + " " + mname + " " + lname;
                string input = ArrIdOrders[i];
                //Regex.Replace(ArrIdOrders[i], "#FirstName", name, RegexOptions.IgnoreCase);
                ArrIdOrders[i] = ArrIdOrders[i].ToUpper();
                if (ArrIdOrders[i].Contains("#COMPANY"))
                {
                    txtTemplateBody.Text = Regex.Replace(txtTemplateBody.Text, ArrIdOrders[i], comname, RegexOptions.IgnoreCase);
                }
                else if (ArrIdOrders[i].Contains("#PRESIDENT"))
                {
                    txtTemplateBody.Text = Regex.Replace(txtTemplateBody.Text, ArrIdOrders[i], fullname, RegexOptions.IgnoreCase);
                }
                //else if (ArrIdOrders[i].Contains("#LAST"))
                //{
                //    txtTemplateBody.Text = Regex.Replace(txtTemplateBody.Text, ArrIdOrders[i], lname, RegexOptions.IgnoreCase);
                //}
                //else if (ArrIdOrders[i] == "#NAME")
                //{
                //    txtTemplateBody.Text = Regex.Replace(txtTemplateBody.Text, ArrIdOrders[i], name, RegexOptions.IgnoreCase);
                //}
            }
        }
    }
    public static string CaseInsenstiveReplace(string originalString, string oldValue, string newValue)
    {
        Regex regEx = new Regex(oldValue,
           RegexOptions.IgnoreCase | RegexOptions.Multiline);
        return regEx.Replace(originalString, newValue);
    }
    protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        getTemplateBody();
        //getrltrack();
    }

    //private void getrltrack()
    //{
    //    ACLGDB DB = new ACLGDB();
    //    ddrltrack.Visible = true;
    //    ddrltrack.Items.Clear();
    //    //ddCasetype.SelectedValue = "0";
    //    //ddCasetype.SelectedItem.Text = "--Select CaseType--";
    //    ListItem li = new ListItem("--Select TrackingNo--", "");
    //    ddrltrack.Items.Insert(0, li);
    //    string connectionString = DB.ConnectionString;
    //    String strQuery = "SELECT [Tracking_No] FROM [dbo].[Employee] where Company_id=" + ddCompany.SelectedValue;
    //    SqlConnection con = new SqlConnection(connectionString);
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = strQuery;
    //    cmd.Connection = con;
    //    try
    //    {
    //        con.Open();
    //        ddrltrack.DataSource = cmd.ExecuteReader();

    //        ddrltrack.DataTextField = "Tracking_No";
    //        ddrltrack.DataValueField = "Tracking_No";

    //        ddrltrack.DataBind();
    //        //   ListItem li = new ListItem("--Select CaseType--", "0");
    //        //ddCasetype.Items.Insert(0, li);

    //    }
    //    catch (Exception ex)
    //    {
    //        ddrltrack.SelectedValue = "";
    //    }
    //    finally
    //    {
    //        con.Close();
    //        con.Dispose();
    //    }
    //}
    protected void ddVisaType_SelectedIndexChanged(object sender, EventArgs e)
    {
        getTemplateBody();
    }

}

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient; 
using ACLGDataAaccess;
using WebFormCast.ACLG;
public partial class attorney_usersaccounts : System.Web.UI.Page
{

    public StringBuilder strBody = new StringBuilder();
    public string strAction = "";
    int intUID = 0;
    string strFlag = "";
    int intAttorney_id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {       
        string strName = "";
        string strPassword = "";
        string strDName = "";
        string strType = "";
        string strSql = "";

        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }

        try
        {
            //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
        }
        catch
        { }

        if (Request["action"] != null)
        {
            strFlag = Request["action"].ToString();
        }

        if (Session["Attorney_User_Type"] == null)
        {
            Response.Redirect("index.aspx");
        }
        else
        {
            if (Session["Attorney_User_Type"].ToString() != "Admin")
            {
                Response.Redirect("index.aspx");
            }
        }

        if (!IsPostBack)
        {
            if (strFlag=="edit")
            {
                intUID = Convert.ToInt16(Request["uid"].ToString());
                strAction = "useraccounts.aspx?update=edit&uid=" + intUID;
            }
            else if (strFlag == "new")
            {
                strAction = "useraccounts.aspx?update=new&uid=" + intUID;
            }
            else if (!string.IsNullOrEmpty(Request["update"]))
            {
                intUID = Convert.ToInt16(Request["uid"].ToString());
                strName = Request["txtname"].ToString();
                strPassword = Request["txtPassword"].ToString();
                strDName = Request["txtDname"].ToString();
                strType = Request["selUserType"].ToString();

                if (Request["update"].ToString() == "edit")
                {
                    strSql = "Update Users set User_Name='" + strName + "',[Password]='" + strPassword + "',User_Display_Name='" + strDName + "',User_Type='" + strType + "' Where User_Id=" + intUID;
                }
                else
                {
                    strSql = "Insert into Users(User_Name,[Password],User_Display_Name,User_Type,attorney_id) values('" + strName + "','" + strPassword + "','" + strDName + "','" + strType + "'," + intAttorney_id.ToString()  + ")";
                }
                ACLGDB  obj = new ACLGDB();
                obj.ExeQuery(strSql);
                Response.Redirect("useraccounts.aspx");
            }
        }

        GetTable();
        AcglGeneral objG = new AcglGeneral();
        lbNavigation.Text = objG.GetNavLinks("USER");
    }

    public void GetTable()
    {
        SqlDataReader Dr = default(SqlDataReader);
        ACLGDB Db = new ACLGDB();
        StringBuilder sbBody = new StringBuilder();
        int sno = 0;
        string intUid = "0";

        if (!string.IsNullOrEmpty(Request["uid"]))
        {
            intUid = Request["uid"];
        }
        Dr = Db.getReader("Select * from Users");
        while (Dr.Read())
        {
            sno = sno + 1;
            if (intUid != Dr["User_Id"].ToString())
            {
                if (sno >= 108)
                {
                    //system is crashing ???? @@@SB strBody size is > 21000. Investigate
                }
                sbBody.AppendLine("<tr>");
                sbBody.AppendLine("<td><a href='useraccounts.aspx?action=edit&uid=" + Dr["User_Id"].ToString() + "'>Edit</a></td>");
                sbBody.AppendLine("<td>" + sno + "</td>");
                sbBody.AppendLine("<td>" + Dr["User_Name"].ToString() + "</td>");
                sbBody.AppendLine("<td>" + Dr["Password"].ToString() + "</td>");
                sbBody.AppendLine("<td>" + Dr["User_Display_Name"].ToString() + "</td>");
                sbBody.AppendLine("<td>" + Dr["User_Type"].ToString() + "</td>");
                sbBody.AppendLine("<td>" + Dr["Last_Access_Date"].ToString() + "</td>");
                sbBody.AppendLine("<tr>");
            }
            else
            {
                sbBody.AppendLine(getEditRow(sno, Dr["User_Name"].ToString(), Dr["Password"].ToString(), Dr["User_Display_Name"].ToString(), Dr["User_Type"].ToString(), Dr["Last_Access_Date"].ToString()));
            }
        }

        Dr.Close();
        if (strFlag == "new")
        {
            sbBody.AppendLine(getEditRow(sno, "", "", "", "", ""));
        }

        strBody.Append(sbBody.ToString());
    }
    public string getEditRow(int sno, string strUN, string strP, string strDN, string strT, string strLAD)
    {
        string strRow = "";
        strRow = "<tr>";
        strRow += "<td><a href='#' onclick='javascript:document.form1.submit();'>Update</a>&nbsp;<a href='useraccounts.aspx'>Cancel</a></td>";
        strRow += "<td>" + sno + "</td>";
        strRow += "<td><input type='text' name='txtName' value='" + strUN + "'></td>";
        strRow += "<td><input type='text' name='txtPassword' value='" + strP + "'></td>";
        strRow += "<td><input type='text' name='txtDName' value='" + strDN + "'></td>";
        strRow += "<td>";
        strRow += "<Select name='selUserType'>";
        strRow += "<Option ";
        if (strT == "Normal")
        {
            strRow += " SELECTED ";
        }
        strRow += " value='Normal'>Normal</Option>";
        strRow += "<Option ";
        if (strT == "Admin")
        {
            strRow += " SELECTED ";
        }
        strRow += " value='Admin'>Admin</Option>";
        strRow += "<td class='td_row1'>" + strLAD + "</td>";
        strRow += "<tr>";
        return strRow;
    } 
}

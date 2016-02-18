using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ACLGDataAaccess;
namespace WebFormCast.ACLG
{
    public class AcglGeneral
    {


        public enum EMPLOYEE
        {
            READ_YES_EDIT_YES = 1,
            READ_YES_EDIT_NO = 2,
            READ_NO_EDIT_NO = 3
        }

        public enum EMPLOYER_ACCESS
        {
            CAN_EDIT = 1,
            NO_EDIT = 2
        }


        public AcglGeneral()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string ClrText(string strVal)
        {
            strVal = strVal.Trim();
            strVal = strVal.Replace("'", "''");
            return strVal;
        }

        public void bindTypeCombo(DropDownList ddl, int selVal)
        {
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            dr = DB.getReader("Select * from Visa_type");

            ddl.DataTextField = "Visa_Type_Name";
            ddl.DataValueField = "Visa_Type_Id";
            ddl.DataSource = dr;
            ddl.DataBind();
            dr.Close();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
            ddl.SelectedValue = selVal.ToString();
        }

        public void bindUserCombo(DropDownList ddl, int selVal)
        {
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            dr = DB.getReader("Select * from Users");

            ddl.DataTextField = "User_Display_Name";
            ddl.DataValueField = "User_Id";
            ddl.DataSource = dr;
            ddl.DataBind();
            dr.Close();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
            ddl.SelectedValue = selVal.ToString();
        }

        public string Capitilaze(string strVal)
        {
            if (strVal.Length <= 0)
                return strVal;

            int len = strVal.Length;
            string strFirstChar = "";
            string strRestChars = "";
            string strResult = "";
            strFirstChar = strVal.Substring(0, 1);
            strFirstChar = strFirstChar.ToUpper();
            strRestChars = strVal.Substring(1, len - 1);
            strRestChars = strRestChars.ToLower();
            strResult = strFirstChar + strRestChars;
            return strResult;

        }
        public void bindCountryCombo(DropDownList ddl, string selVal)
        {
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            dr = DB.getReader("Select * from Country");

            ddl.DataTextField = "CountryName";
            ddl.DataValueField = "CountryName";
            ddl.DataSource = dr;
            ddl.DataBind();
            dr.Close();
            ddl.Items.Insert(0, new ListItem("Select", ""));
            ddl.SelectedValue = selVal.ToString();
            ddl.SelectedValue = selVal;
        }

        public string ExtractQueryString(string strVal)
        {
            string strQstring = "";
            char[] splitter = { '?' };
            string[] arInfo = null;
            arInfo = strVal.Split(splitter);

            if (arInfo.Length > 0)
                strQstring = arInfo[1];

            return strQstring;

        }

        public string GetFormLinks_old(int intEmployeeId, string strEmployeeSignature)
        {
            string strBody = "";


            strBody += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"5\">";
            strBody += "<tr>";
            strBody += "<td>&raquo;<a href='employeeview.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "'> Employee Info</></td>";
            strBody += "<td>&raquo;<a href='formg28.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "'> Form G-28</></td>";
            strBody += "<td>&raquo;<a href='form_i129h01.aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "'> Form I-129H</a></td>";
            strBody += "</tr>";
            strBody += "<tr>";
            strBody += "<td>&raquo;<a href='templateview.aspx?template=1&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "'> Offer of Employment</a></td>";
            strBody += "<td>&raquo;<a href='templateview.aspx?template=3&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "'> Itinerary</a></td>";
            strBody += "<td>&raquo;<a href='templateview.aspx?template=2&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "'> Support Letter</a></td>";
            strBody += "</tr>";
            strBody += "</table>";

            return strBody;
        }


        //public string GetFormLinks(int intEmployeeId, string strEmployeeSignature)
        //{
        //    string strBody = "";


        //    strBody += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"5\">";
        //    strBody += "<tr>";
        //    strBody += "<td>&raquo;<a href='employeeview.aspx'> Employee Info</></td>";
        //    strBody += "<td>&raquo;<a href='formg28.aspx'> Form G-28</></td>";
        //    strBody += "<td>&raquo;<a href='form_i129h01.aspx'> Form I-129H</a></td>";
        //    strBody += "</tr>";
        //    strBody += "<tr>";
        //    strBody += "<td>&raquo;<a href='templateview.aspx?template=1&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "&item=" + visaid + "'> Offer of Employment</a></td>";
        //    strBody += "<td>&raquo;<a href='templateview.aspx?template=3&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "&item=" + visaid + "'> Itinerary</a></td>";
        //    strBody += "<td>&raquo;<a href='templateview.aspx?template=2&id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "&item=" + visaid + "'> Support Letter</a></td>";
           
        //    //strBody += "<td>&raquo;<a href='templateview.aspx?template=1'> Offer of Employment</a></td>";
        //    //strBody += "<td>&raquo;<a href='templateview.aspx?template=3'> Itinerary</a></td>";
        //    //strBody += "<td>&raquo;<a href='templateview.aspx?template=2'> Support Letter</a></td>";
        //    strBody += "</tr>";
        //    strBody += "</table>";

        //    return strBody;
        //}


        public string GetFormLinks(int intEmployeeId, string strEmployeeSignature)
        {
            string strBody = "";


            strBody += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"5\">";
            strBody += "<tr>";
            strBody += "<td>&raquo;<a href='employeeview.aspx'> Employee Info</></td>";
            strBody += "<td>&raquo;<a href='formg28.aspx'> Form G-28</></td>";
            strBody += "<td>&raquo;<a href='form_i129h01.aspx'> Form I-129H</a></td>";
            strBody += "</tr>";
            strBody += "<tr>";

            strBody += "<td>&raquo;<a href='templateview.aspx?template=1'> Offer of Employment</a></td>";
            strBody += "<td>&raquo;<a href='templateview.aspx?template=3'> Itinerary</a></td>";
            strBody += "<td>&raquo;<a href='templateview.aspx?template=2'> Support Letter</a></td>";
            strBody += "</tr>";
            strBody += "</table>";

            return strBody;
        }

        public string GetNavLinks(string strTab)
        {
            string strBody = "";
            string strUType = "";
            try
            {
                strUType = HttpContext.Current.Session["Attorney_User_Type"].ToString();
            }
            catch { }
            strBody += "<ul class=\"topNav\">";

            if (strTab.ToUpper() == "HOME")
                strBody += "<li class=\"current\"><a href=\"home.aspx\"><b>Home</b></a></li>";
            else
                strBody += "<li><a href=\"home.aspx\"><b>Home</b></a></li>";

            if (strTab.ToUpper() == "CASE")
                strBody += "<li class=\"current\"><a href=\"cases.aspx\"><b>Cases</b></a></li>";
            else
                strBody += "<li><a href=\"cases.aspx\"><b>Cases</b></a></li>";

            if (strTab.ToUpper() == "CLIENT")
                strBody += "<li class=\"current\"><a href=\"clientmanager.aspx\"><b>Client Manager</b></a></li>";
            else
                strBody += "<li><a href=\"clientmanager.aspx\"><b>Client Manager</b></a></li>";

            if (strUType.ToUpper().Trim() == "ADMIN")
            {

                if (strTab.ToUpper() == "USER")
                    strBody += "<li class=\"current\"><a href=\"useraccounts.aspx\"><b>User Accounts</b></a></li>";
                else
                    strBody += "<li><a href=\"useraccounts.aspx\"><b>User Accounts</b></a></li>";
            }
           
            if (strTab.ToUpper() == "TEMPLATE")
                strBody += "<li class=\"current\"><a href=\"templates.aspx\"><b>Templates</b></a></li>";
            else
                strBody += "<li><a href=\"templates.aspx\"><b>Templates</b></a></li>";

            //if (strTab.ToUpper() == "FORMS")
            //    strBody += "<li class=\"current\"><a href=\"forms.aspx\"><b>Forms</b></a></li>";
            //else
            //    strBody += "<li><a href=\"forms.aspx\"><b>Forms</b></a></li>";

            if (strTab.ToUpper() == "MYACCOUNT")
                strBody += "<li class=\"current\"><a href=\"myaccount.aspx\"><b>My Account</b></a></li>";
            else
                strBody += "<li><a href=\"myaccount.aspx\"><b>My Account</b></a></li>";

            if (strTab.ToUpper() == "REPORTS")
                strBody += "<li class=\"current\"><a href=\"userlog.aspx\"><b>Reports</b></a></li>";
            else
                strBody += "<li><a href=\"userlog.aspx\"><b>Reports</b></a></li>";

            if (strTab.ToUpper() == "TRACK. SYS.")
                strBody += "<li class=\"current\"><a href=\"trackingSys.aspx\"><b>Track. Sys.</b></a></li>";
            else
                strBody += "<li><a href=\"trackingSys.aspx\"><b>Track. Sys.</b></a></li>";

            //strBody += "<li><a href=\"logout.aspx\"><b>Logout</b></a></li>";
            strBody += " </ul>";

            return strBody;
        }









        public string GetSubLinks(int intEmployeeId, string strEmployeeSignature, int intSno)
        {
            string strBody = "";
            string strNo = "01";

            for (int i = 1; i <= 9; i++)
            {
                if (i < 10)
                    strNo = "0" + i.ToString();
                else
                    strNo = i.ToString();
                if (i == intSno)
                    strBody += "<div class=\"pnum_act\"><a href=\"form_i129h" + strNo + ".aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "\">" + i.ToString() + "</a></div>";
                else
                    strBody += "<div class=\"pnum_dis\"><a href=\"form_i129h" + strNo + ".aspx?id=" + intEmployeeId.ToString() + "&signature=" + strEmployeeSignature + "\">" + i.ToString() + "</a></div>";
                //<div class="pnum_dis"><a href="#">2</a></div>
            }
            return strBody;
        }
    }
}

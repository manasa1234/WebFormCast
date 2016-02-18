using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using ACLGDataAaccess;

/// <summary>
/// Summary description for clsTemplate
/// </summary>
namespace WebFormCast.ACLG
{

    public class clsTemplate
    {
        public int TemplateID = 0;
        public int AttorneyId = 0;
        public int CompanyID = 0;
        public int VisaTypeid = 0;
        public string Body = "";
        public string Header = "";
        public string Footer = "";
        public int HHeight = 0;
        public int FHeight = 0;
        public string CustomBody = "";

        public clsTemplate()
        {

        }

        public clsTemplate(int intAttoreyId, int intCompanyId, int intVisaTypeId, int intTemplateId)
        {
            Get_TemplateBody1(intAttoreyId, intCompanyId, intVisaTypeId, intTemplateId);
        }


        public bool Update_CustTemplate(int intEmployeeId, int intTemplateID, string strBody)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_Template_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = intTemplateID;
            cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = intEmployeeId;
            cmd.Parameters.Add("@Template_Body", SqlDbType.Text).Value = strBody;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }
        public bool Update_CustTemplate1(int visaid,int intEmployeeId, int intTemplateID, string strBody)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_Template_Update1";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@visaid", SqlDbType.Int).Value = visaid;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = intTemplateID;
            cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = intEmployeeId;
            cmd.Parameters.Add("@Template_Body", SqlDbType.Text).Value = strBody;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool Update_Template(int intAttoreyId, int intCompanyId, int intTempateid, int intVisaTypeid, string strBody, string strHeader, string strFooter, int intHHeight, int intFHeight)
        {
            strBody = HttpContext.Current.Server.HtmlEncode(strBody);
            strHeader = HttpContext.Current.Server.HtmlEncode(strHeader);
            strFooter = HttpContext.Current.Server.HtmlEncode(strFooter);
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Attorney_Template_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@AttorneyId", SqlDbType.Int).Value = intAttoreyId;
            cmd.Parameters.Add("@Companyid", SqlDbType.Int).Value = intCompanyId;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = intTempateid;
            cmd.Parameters.Add("@VisaTypeid", SqlDbType.Int).Value = intVisaTypeid;
            cmd.Parameters.Add("@Template_Body", SqlDbType.Text).Value = strBody;
            cmd.Parameters.Add("@Template_Header", SqlDbType.Text).Value = strHeader;
            cmd.Parameters.Add("@Template_Footer", SqlDbType.Text).Value = strFooter;
            cmd.Parameters.Add("@Template_HH", SqlDbType.Int).Value = intHHeight;
            cmd.Parameters.Add("@Template_FH", SqlDbType.Int).Value = intFHeight;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public String Get_TemplateBody(int intAttoreyId, int intCompanyId, int intVisaTypeId, int intTemplateId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            string strBody = "";

            Ds = DB.getSPResults("Attorney_Template_Select", "@AttorneyId", intAttoreyId.ToString(), "@CompanyId", intCompanyId.ToString(), "@Templateid", intTemplateId.ToString(), "@VisaTypeId", intVisaTypeId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                Body = Ds.Tables[0].Rows[0]["Template_body"].ToString();
                Header = Ds.Tables[0].Rows[0]["Template_Header"].ToString();
                Footer = Ds.Tables[0].Rows[0]["Template_Footer"].ToString();
                try
                {
                    HHeight = Convert.ToInt32(Ds.Tables[0].Rows[0]["Header_Height"].ToString());
                }
                catch { }
                try
                {

                    FHeight = Convert.ToInt32(Ds.Tables[0].Rows[0]["Footer_Height"].ToString());
                }
                catch { }
                TemplateID = Convert.ToInt32(Ds.Tables[0].Rows[0]["TemplateID"].ToString());
                AttorneyId = Convert.ToInt32(Ds.Tables[0].Rows[0]["AttorneyId"].ToString());
                CompanyID = Convert.ToInt32(Ds.Tables[0].Rows[0]["CompanyID"].ToString());
                VisaTypeid = Convert.ToInt32(Ds.Tables[0].Rows[0]["VisaTypeid"].ToString());
                Body = HttpContext.Current.Server.HtmlDecode(Body);
                Header = HttpContext.Current.Server.HtmlDecode(Header);
                Footer = HttpContext.Current.Server.HtmlDecode(Footer);
            }
            strBody = Body;
            return strBody;
        }
        public void Get_TemplateBody1(int intAttoreyId, int intCompanyId, int intVisaTypeId, int intTemplateId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            string strBody = "";

            Ds = DB.getSPResults("Attorney_Template_Select", "@AttorneyId", intAttoreyId.ToString(), "@CompanyId", intCompanyId.ToString(), "@Templateid", intTemplateId.ToString(), "@VisaTypeId", intVisaTypeId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                Body = Ds.Tables[0].Rows[0]["Template_body"].ToString();
                Header = Ds.Tables[0].Rows[0]["Template_Header"].ToString();
                Footer = Ds.Tables[0].Rows[0]["Template_Footer"].ToString();
                try
                {
                    HHeight = Convert.ToInt32(Ds.Tables[0].Rows[0]["Header_Height"].ToString());
                }
                catch { }
                try
                {

                    FHeight = Convert.ToInt32(Ds.Tables[0].Rows[0]["Footer_Height"].ToString());
                }
                catch { }
                TemplateID = Convert.ToInt32(Ds.Tables[0].Rows[0]["TemplateID"].ToString());
                AttorneyId = Convert.ToInt32(Ds.Tables[0].Rows[0]["AttorneyId"].ToString());
                CompanyID = Convert.ToInt32(Ds.Tables[0].Rows[0]["CompanyID"].ToString());
                VisaTypeid = Convert.ToInt32(Ds.Tables[0].Rows[0]["VisaTypeid"].ToString());
                Body = HttpContext.Current.Server.HtmlDecode(Body);
                Header = HttpContext.Current.Server.HtmlDecode(Header);
                Footer = HttpContext.Current.Server.HtmlDecode(Footer);
            }
            strBody = Body;
        }

        public string Get_CustomTemplateBody(int intTemplateId, int intEmployeeId)
        {
            string strSql = "";
            SqlDataReader dr;
            ACLGDB DB = new ACLGDB();
            strSql = "Select * from Employee_Templates Where Template_Id=" + intTemplateId + "  And Employee_id=" + intEmployeeId;
            CustomBody = "";
            dr = DB.getReader(strSql);
            if (dr.Read())
            {
                CustomBody = dr["Template_Body"].ToString();
               
            }
            dr.Close();
            return CustomBody;
        }
        public string Get_CustomTemplateBody1(int intTemplateId, int CompanyID,int visaid)
        {
            string strSql = "";
            SqlDataReader dr;
            ACLGDB DB = new ACLGDB();
            strSql = "Select [Template_Body],[Template_Header],[Template_Footer] from AttorneyTemplates Where TemplateID=" + intTemplateId + "  And CompanyID=" + CompanyID + "  And VisaTypeid=" + visaid;
            CustomBody = "";
            dr = DB.getReader(strSql);
            if (dr.Read())
            {
                
                CustomBody= dr["Template_Body"].ToString();
                CustomBody = HttpContext.Current.Server.HtmlDecode(CustomBody);
            }
            dr.Close();
            return CustomBody;
        }
        public bool insert_TemplateBody(int intTempateid, int intVisaTypeid, string strBody)
        {
            strBody = HttpContext.Current.Server.HtmlEncode(strBody);
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Attorney_TemplateBody_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = intTempateid;
            cmd.Parameters.Add("@VisaTypeid", SqlDbType.Int).Value = intVisaTypeid;
            cmd.Parameters.Add("@Template_Body", SqlDbType.Text).Value = strBody;

            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }
        public String TemplateBody(int intVisaTypeId, int intTemplateId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            string strBody = "";

            Ds = DB.getSPResults("AttorneyTemplate_Body_Select", "@Templateid", intTemplateId.ToString(), "@VisaTypeId", intVisaTypeId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                Body = Ds.Tables[0].Rows[0]["Template_body"].ToString();

                TemplateID = Convert.ToInt32(Ds.Tables[0].Rows[0]["TemplateID"].ToString());

                VisaTypeid = Convert.ToInt32(Ds.Tables[0].Rows[0]["VisaTypeid"].ToString());
                Body = HttpContext.Current.Server.HtmlDecode(Body);

            }
            strBody = Body;
            return strBody;
        }
        public bool DeleteTemplateBody(int intVisaTypeId, int intTemplateId)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AttorneyTemplate_Body_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = intTemplateId;
            cmd.Parameters.Add("@VisaTypeid", SqlDbType.Int).Value = intVisaTypeId;

            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }
        public int TemplateBodycount(int intVisaTypeId, int intTemplateId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            string strBody = "";
            int count = 0;

            Ds = DB.getSPResults("AttorneyTemplate_Body_Select", "@Templateid", intTemplateId.ToString(), "@VisaTypeId", intVisaTypeId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                count = count + 1;
            }
            else
                count = 0;
            return count;
        }
        public bool Update_TemplateHeader(int intAttoreyId, int intCompanyId, string strHeader, string strFooter, int intHHeight, int intFHeight)
        {

            strHeader = HttpContext.Current.Server.HtmlEncode(strHeader);
            strFooter = HttpContext.Current.Server.HtmlEncode(strFooter);
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Attorney_TemplateHeader_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@AttorneyId", SqlDbType.Int).Value = intAttoreyId;
            cmd.Parameters.Add("@Companyid", SqlDbType.Int).Value = intCompanyId;
            cmd.Parameters.Add("@Template_Header", SqlDbType.Text).Value = strHeader;
            cmd.Parameters.Add("@Template_Footer", SqlDbType.Text).Value = strFooter;
            cmd.Parameters.Add("@Template_HH", SqlDbType.Int).Value = intHHeight;
            cmd.Parameters.Add("@Template_FH", SqlDbType.Int).Value = intFHeight;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }
        public bool Get_TemplateHeader(int intAttoreyId, int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            string strBody = "";

            Ds = DB.getSPResults("Attorney_TemplateHeader_Select", "@AttorneyId", intAttoreyId.ToString(), "@CompanyId", intCompanyId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {

                Header = Ds.Tables[0].Rows[0]["Template_Header"].ToString();
                Footer = Ds.Tables[0].Rows[0]["Template_Footer"].ToString();
                try
                {
                    HHeight = Convert.ToInt32(Ds.Tables[0].Rows[0]["Header_Height"].ToString());
                }
                catch { }
                try
                {

                    FHeight = Convert.ToInt32(Ds.Tables[0].Rows[0]["Footer_Height"].ToString());
                }
                catch { }
                AttorneyId = Convert.ToInt32(Ds.Tables[0].Rows[0]["AttorneyId"].ToString());
                CompanyID = Convert.ToInt32(Ds.Tables[0].Rows[0]["CompanyID"].ToString());
                Header = HttpContext.Current.Server.HtmlDecode(Header);
                Footer = HttpContext.Current.Server.HtmlDecode(Footer);

            }
            return true;
        }

        public int TemplateHeadercount(int intAttoreyId, int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            string strBody = "";
            int count = 0;
            Ds = DB.getSPResults("Attorney_TemplateHeader_Select", "@AttorneyId", intAttoreyId.ToString(), "@CompanyId", intCompanyId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                count = count + 1;
            }
            else
                count = 0;
            return count;
        }

        public bool DeleteTemplateHeader(int intAttoreyId, int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Attorney_TemplateHeader_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@AttorneyId", SqlDbType.Int).Value = intAttoreyId;
            cmd.Parameters.Add("@Companyid", SqlDbType.Int).Value = intCompanyId;

            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }
    }
}
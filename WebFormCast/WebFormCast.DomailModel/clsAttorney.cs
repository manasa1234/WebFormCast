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
/// Summary description for clsAttorney
/// </summary>
namespace WebFormCast.ACLG
{
    public class clsAttorney
    {
        int _Attorney_id = 0;
        string _Name = "";
        string _Address = "";
        string _Suite = "";
        string _Street = "";
        string _City = "";
        string _State = "";
        string _Zip = "";
        string _FirmName = "";
        string _Phone = "";
        string _Phone_Code = "";
        string _Fax = "";
        string _Email = "";
        string _Password = "";
        string _AttyStateLicense = "";


        public string AttyStateLicense
        {
            get
            {
                return _AttyStateLicense;
            }
        }


        public string Suite
        {
            get
            {
                return _Suite;
            }
        }

        public string Street
        {
            get
            {
                return _Street;
            }
        }

        public string City
        {
            get
            {
                return _City;
            }
        }

        public string State
        {
            get
            {
                return _State;
            }
        }

        public string Zip
        {
            get
            {
                return _Zip;
            }
        }


        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public string Firm_Name
        {
            get
            {
                return _FirmName;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }
        }



        public string Phone_Code
        {
            get
            {
                return _Phone_Code;
            }
        }
        public string Phone
        {
            get
            {
                return _Phone;
            }
        }

        public string Fax
        {
            get
            {
                return _Fax;
            }
        }


        public string Email
        {
            get
            {
                return _Email;
            }
        }

        public clsAttorney()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public clsAttorney(int AttorneyId)
        {
            _Attorney_id = AttorneyId;
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;

            Ds = DB.getSPResults("attorney_Select", "@AttorneyId", AttorneyId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                _Name = Ds.Tables[0].Rows[0]["Name"].ToString();
                _FirmName = Ds.Tables[0].Rows[0]["Firm_Name"].ToString();
                _Suite = Ds.Tables[0].Rows[0]["Add_Suite"].ToString();
                _Street = Ds.Tables[0].Rows[0]["Add_Street"].ToString();
                _City = Ds.Tables[0].Rows[0]["Add_City"].ToString();
                _State = Ds.Tables[0].Rows[0]["Add_State"].ToString();
                _Zip = Ds.Tables[0].Rows[0]["Add_Zip"].ToString();
                _Phone = Ds.Tables[0].Rows[0]["Phone"].ToString();
                _Phone_Code = Ds.Tables[0].Rows[0]["Phone_Code"].ToString();
                _Fax = Ds.Tables[0].Rows[0]["Fax"].ToString();
                _Email = Ds.Tables[0].Rows[0]["Email"].ToString();
                _Password = Ds.Tables[0].Rows[0]["Password"].ToString();
                _AttyStateLicense = Ds.Tables[0].Rows[0]["AttyStateLicense"].ToString();
            }
        }

        public bool Update_Attorney(int intAttoreyId, string strName, string Firm_Name, string strSuite, string strStreet, string strCity, string strState, string strZip, string strEmail, string strPhone, string strPhoneCode, string strFax, string strAttyStateLicense)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Attorney_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 200).Value = strName;
            cmd.Parameters.Add("@Firm_Name", SqlDbType.VarChar, 1000).Value = Firm_Name;
            cmd.Parameters.Add("@Suite", SqlDbType.VarChar, 100).Value = strSuite;
            cmd.Parameters.Add("@Street", SqlDbType.VarChar, 100).Value = strStreet;
            cmd.Parameters.Add("@City", SqlDbType.VarChar, 100).Value = strCity;
            cmd.Parameters.Add("@State", SqlDbType.VarChar, 100).Value = strState;
            cmd.Parameters.Add("@Zip", SqlDbType.VarChar, 50).Value = strZip;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = strEmail;
            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 100).Value = strPhone;
            cmd.Parameters.Add("@Phone_Code", SqlDbType.VarChar, 100).Value = strPhoneCode;
            cmd.Parameters.Add("@Fax", SqlDbType.VarChar, 100).Value = strFax;
            cmd.Parameters.Add("@AttyStateLicense", SqlDbType.VarChar, 100).Value = strAttyStateLicense;
            cmd.Parameters.Add("@AttorenyId", SqlDbType.Int).Value = intAttoreyId;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }


        public int CheckAuthontication(string strEmail, String strPassword)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            int intEid = 0;
            Ds = DB.getSPResults("attorney_Select_Email", "@EmailAddress", strEmail);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0]["password"].ToString() == strPassword)
                {
                    flag = true;
                    intEid = Convert.ToInt32(Ds.Tables[0].Rows[0]["attorney_id"].ToString());
                }
            }

            return intEid;


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

        public DataSet GetEmployeesSearchList(int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_Search1", "@CompanyId", intCompanyId.ToString());
        }
        public DataSet GetEmployeesCaseTypeSearchList(int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_CaseTyp1_Search1", "@CompanyId", intCompanyId.ToString());
        }

        public DataSet GetEmployeesSearchList(int intAttorneyId, string strTrackingNo)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_Search3", "@AttorneyId", intAttorneyId.ToString(), "@TrackingNo", strTrackingNo);
        }

        public DataSet GetCasesSearchList1(int intAttorneyId, string strTrackingNo)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_CaseType_Search3", "@AttorneyId", intAttorneyId.ToString(), "@TrackingNo", strTrackingNo);

        }


        public void bindCompanyCombo(DropDownList ddl, int selVal)
        {
            ACLGDB DB = new ACLGDB();
            DataSet ds = new DataSet();
            ds = DB.getSPResults("Attorney_Companies_Select", "@AttorneyId", _Attorney_id.ToString());
            //SqlDataReader dr;
            //dr = DB.getReader("Select * from Visa_type");

            ddl.DataTextField = "Legal_Name";
            ddl.DataValueField = "CompanyID";
            ddl.DataSource = ds;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
            ddl.SelectedValue = selVal.ToString();
        }

        public void bindJobTitleCombo(DropDownList ddl, int selVal)
        {
            ACLGDB DB = new ACLGDB();
            DataSet ds = new DataSet();
            ds = DB.getSPResults("Attorney_JobTitles", "@AttorneyId", _Attorney_id.ToString());
            //SqlDataReader dr;
            //dr = DB.getReader("Select * from Visa_type");

            ddl.DataTextField = "Job_Title";
            ddl.DataValueField = "JobTitle_Id";
            ddl.DataSource = ds;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Select", "0"));
            ddl.SelectedValue = selVal.ToString();
        }
        public DataSet GetEmployerList(int intAttorneyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Company_Select_All", "@AttorneyId", intAttorneyId.ToString());
        }

        public DataSet GetEmployerListByName(int intAttorneyId, string companyName)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Company_Select_Att_LegalName", "@AttorneyId", intAttorneyId.ToString(), "@LegalName", companyName);
        }

        public bool isExistCompanyEmail(string strEmail)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            Ds = DB.getSPResults("attorney_Select_Email", "@EmailAddress", strEmail);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }

            return flag;


        }

        public bool isExistShortName(string strName)
        {
            string strSql = "Select * from Company where Short_Name='" + strName + "'";
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            bool Flag = false;

            dr = DB.getReader(strSql);

            if (dr.Read())
            {
                Flag = true;
            }
            dr.Close();
            return Flag;
        }

        public DataSet GetNewEmployeesList(int intAttorneyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_unApproved", "@AttorenyId", intAttorneyId.ToString());
        }
        public bool BindUnSubmitedClientsList(DropDownList ddl, int intAttorneyId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet ds = new DataSet();
            ds = DB.getSPResults("Attorney_Employer_UnSubmited", "@AttorenyId", intAttorneyId.ToString());
            ddl.DataTextField = "Legal_Name";
            ddl.DataValueField = "Company_ID";
            ddl.DataSource = ds;
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("All", "0"));
            return true;
        }
        public DataSet GetUnSubmitedEmployeesList(int intAttorneyId, int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_UnSubmited", "@AttorenyId", intAttorneyId.ToString(), "@Companyid", intCompanyId.ToString());
        }
    }
}

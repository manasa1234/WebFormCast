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
/// Summary description for clsCompany
/// </summary>
namespace WebFormCast.ACLG
{
    public class Company
    {

        #region Veriables
        int _CompanyId = 0;
        int _AttorneyId = 0;
        string _Short_Name = "";
        string _Legal_Name = "";
        string _Mailing_Address = "";
        string _Add_AptNo = "";
        string _Add_Street = "";
        string _Add_City = "";
        string _Add_State = "";
        string _Add_ZipCode = "";
        string _Documents_Address = "";
        string _Company_Type = "";
        string _Phone_No = "";
        string _Phone_No_Code = "";
        string _Fax_No = "";
        string _Alternate_Phone_No = "";
        string _Alternate_Phone_No_Code = "";
        string _Web_Address = "";
        string _EIN_Number="";
        string _SocialSecurity="";
        string _IndividualTax="";
        string _ATTYStateLicense = "";
        string  _Registered_Date="";
        string _Registration_State="";
        string _Registration_Date="";
        string _Person_FullName="";
        string _Person_Designation = "";
        string _Person_CellNo="";
        string _Person_Email="";
        string _Person_Fax="";
        string _Description="";
        string _HaveAffiliates="";
        int _NoofEmployees=0;
        int  _NoofH1BEmployees=0;
        int  _FileToDate=0;
        string _WithdrawanyH1Bs="";
        string _H1bPetitionsDenied="";
        string    _AnnualIncome="";
        string _LastYearIncome = "";
        string _NetAnnualIncome = "";
        string _LastYearNetIncome = "";
        string _Comments="";
        string _CreatedDate="";
        string _AttoneyUpdated_Date="";
        string _SelfUpdated_Date="";
        int _Next_Sequence_No = 0;
        string _Password = "";
        string _Naics_Code = "";
        string _Contact_Info = "";
        string _NIV_Contact_Info = "";
        string _IV_Contact_Info = "";
        string _Acc_Contact_Info = "";
        string _Temp_Contact_Info = "";
        string _H1B_Dependent = "";
        string _Public_Law = "";
        string _Preferences = "";

        #endregion


        #region MyClass Properties
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

        public int AttorneyId
        {
            get
            {
                return _AttorneyId;
            }
            set
            {
                _AttorneyId = value;
            }
        }
        public string Short_Name
        {
            get
            {
                return _Short_Name; 

            }
            set
            {
                _Short_Name= value;
            }

        }
        public string Legal_Name{
            get
            {
                return _Legal_Name;
            }
            set
            {
                _Legal_Name = value;
            }

        }
        public string Mailing_Address{
            get
            {
                return _Mailing_Address;

            }
            set
            {
                _Mailing_Address = value;
            }

        }

        public string Add_AptNo
        {
            get
            {
                return _Add_AptNo;
            }
            set
            {
                _Add_AptNo = value;
            }
        }
        public string Add_Street
        {
            get
            {
                return _Add_Street; 
            }
            set
            {
                _Add_Street = value;
            }
        }

        public string Add_City
        {
            get
            {
                return _Add_City; 
            }

            set
            {
                _Add_City = value;
            }
        }

        public string Add_State
        {
            get
            {
                return _Add_State; 
            }
            set
            {
                _Add_State = value;
            }
        }

        public string Add_Zip
        {

            get
            {
                return _Add_ZipCode; 
            }
            set
            {
                _Add_ZipCode = value; 
            }
        }


        public string Documents_Address{
            get
            {
                return _Documents_Address;

            }
            set
            {
                _Documents_Address = value;
            }

        }
        public string Company_Type{
            get
            {
                return _Company_Type;
            }
            set
            {
                _Company_Type = value;
            }

        }
        public string Phone_No{
            get
            {
                return _Phone_No;
            }
            set
            {
                _Phone_No = value;
            }

        }
        public string Phone_No_Code
        {
            get
            {
                return _Phone_No_Code;
            }
            set
            {
                _Phone_No_Code = value;
            }

        }
        public string Fax_No{
            get
            {
                return _Fax_No;

            }
            set
            {
                _Fax_No = value;
            }

        }
        public string Alternate_Phone_No{
            get
            {
                return _Alternate_Phone_No;

            }
            set
            {
                _Alternate_Phone_No = value;
            }
        }
        public string Alternate_Phone_No_Code
        {
            get
            {
                return _Alternate_Phone_No_Code;

            }
            set
            {
                _Alternate_Phone_No_Code = value;
            }
        }
        public string Web_Address{
            get
            {
                return _Web_Address;
            }
            set
            {
                _Web_Address = value;
            }

        }
        public string EIN_Number{
            get
            {
                return _EIN_Number;
            }
            set
            {
                _EIN_Number = value;
            }

        }
        

        public string SocialSecurity
        {
            get
            {
                return _SocialSecurity;
            }

            set
            {
                _SocialSecurity =value;
            }
        }
        public string IndividualTax
        {
            get
            {
                return _IndividualTax;
            }

            set
            {
                _IndividualTax=value;
            }
        }
        public string ATTYStateLicense
        {
            get
            {
                return _ATTYStateLicense;
            }
            set
            {
                _ATTYStateLicense = value;
            }
        }

        public string Registered_Date{
            get
            {
                return _Registered_Date;
            }
            set
            {
                _Registered_Date = value;
            }

        }
        public string Registration_State{
            get
            {
                return _Registration_State;  
            }
            set
            {
                _Registration_State = value;
            }

        }
        public string Registration_Date{
            get
            {
                return _Registration_Date; 
            }
            set
            {
                _Registration_Date = value;
            }

        }
        public string Person_FullName{
            get
            {
                return _Person_FullName; 

            }
            set
            {
                _Person_FullName = value;  
            }
        }

        public string Person_Designation
        {
            get
            {
                return _Person_Designation; 
            }
            set
            {
                _Person_Designation = value; 
            }
        }
        public string Person_CellNo{
            get
            {
                return _Person_CellNo; 
            }
            set
            {
                _Person_CellNo = value;
            }

        }
        public string Person_Email{
            get
            {
                return _Person_Email; 
            }
            set
            {
                _Person_Email = value; 
            }

        }
        public string Person_Fax{
            get
            {
                return _Person_Fax; 

            }
            set
            {
                _Person_Fax = value;
            }
        }
        public string Description{
            get
            {
                return _Description;

            }

            set
            {
                _Description = value;
            }
        }
        public string HaveAffiliates{
            get
            {
                return _HaveAffiliates;
            }
            set
            {
                _HaveAffiliates = value;
            }

        }
        public int NoofEmployees
        {
            get
            {
                return _NoofEmployees; 
            }
            set
            {
                _NoofEmployees = value;
            }
        }
        public int NoofH1BEmployees
        {
            get
            {
                return _NoofH1BEmployees; 
            }
            set
            {
                _NoofH1BEmployees = value; 
            }
        }
        public int FileToDate{
            get
            {
                return _FileToDate;

            }
            set
            {
                _FileToDate = value;
            }

        }
        public string WithdrawanyH1Bs{
            get
            {
                return _WithdrawanyH1Bs; 

            }
            set
            {
                _WithdrawanyH1Bs = value;
            }
        }
        public string H1bPetitionsDenied{
            get
            {
                return _H1bPetitionsDenied; 

            }
            set
            {
                _H1bPetitionsDenied = value;
            }

        }
        public string  AnnualIncome{
            get
            {
                return _AnnualIncome;

            }
            set
            {
                _AnnualIncome = value;
            }

        }
        public string  LastYearIncome{
            get
            {
                return _LastYearIncome; 

            }
            set
            {
                _LastYearIncome = value;
            }

        }
        public string  NetAnnualIncome{
            get
            {
                return _NetAnnualIncome;

            }
            set
            {
                _NetAnnualIncome = value;
            }

        }
        public string  LastYearNetIncome{
            get
            {
                return _LastYearNetIncome;

            }
            set
            {
                _LastYearNetIncome = value;
            }

        }
        public string Comments{
            get
            {
                return _Comments;

            }
            set
            {
                _Comments = value;
            }

        }
        public string Naics_Code
        {
            get
            {
                return _Naics_Code;

            }
            set
            {
                _Naics_Code = value;
            }

        }

        public string Contact_Info
        {
            get
            {
                return _Contact_Info;

            }
            set
            {
                _Contact_Info = value;
            }

        }
        
        public string NIV_Contact_Info
        {
            get
            {
                return _NIV_Contact_Info;

            }
            set
            {
                _NIV_Contact_Info = value;
            }

        }

        public string IV_Contact_Info
        {
            get
            {
                return _IV_Contact_Info;

            }
            set
            {
                _IV_Contact_Info = value;
            }

        }

        public string Acc_Contact_Info
        {
            get
            {
                return _Acc_Contact_Info;

            }
            set
            {
                _Acc_Contact_Info = value;
            }

        }

        public string Temp_Contact_Info
        {
            get
            {
                return _Temp_Contact_Info;

            }
            set
            {
                _Temp_Contact_Info = value;
            }

        }

        public string H1B_Dependent
        {
            get
            {
                return _H1B_Dependent;

            }
            set
            {
                _H1B_Dependent = value;
            }

        }

        public string Public_Law
        {
            get
            {
                return _Public_Law;

            }
            set
            {
                _Public_Law = value;
            }

        }

        public string Preferences
        {
            get
            {
                return _Preferences;

            }
            set
            {
                _Preferences = value;
            }

        }
        
        public string CreatedDate
        {
            get
            {
                return _CreatedDate;

            }

        }
        public string AttoneyUpdated_Date{
            get
            {
                return _AttoneyUpdated_Date;

            }

        }
        public string SelfUpdated_Date{
            get
            {
                return _SelfUpdated_Date; 

            }

        }
        public string  NextTrackingNo
        {
            get
            {
                return GenerateNextTrackingNo();
            }

        }

        public int Company_id
        {
            get
            {
                return _CompanyId; 
            }
            set
            {
                _CompanyId = value;
            }
        }
        #endregion

        public Company()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public Company(int intCompanyId)
        {
            _CompanyId = intCompanyId;
            Initialize(intCompanyId);
        }


        public void Initialize(int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            Ds = DB.getSPResults("Company_Select", "@CompanyId", intCompanyId.ToString());


            if (Ds.Tables[0].Rows.Count > 0)
            {
                
                if (!(Ds.Tables[0].Rows[0]["Next_Sequence_No"] == DBNull.Value))
                    _Next_Sequence_No = Convert.ToInt32(Ds.Tables[0].Rows[0]["Next_Sequence_No"]);
                _CompanyId = Convert.ToInt32(Ds.Tables[0].Rows[0]["CompanyId"].ToString());
                _AttorneyId = Convert.ToInt32(Ds.Tables[0].Rows[0]["AttorneyId"].ToString());
                _Short_Name = Ds.Tables[0].Rows[0]["Short_Name"].ToString();
                _Legal_Name = Ds.Tables[0].Rows[0]["Legal_Name"].ToString();
                _Mailing_Address = Ds.Tables[0].Rows[0]["Mailing_Address"].ToString();
                _Documents_Address = Ds.Tables[0].Rows[0]["Documents_Address"].ToString();
                _Company_Type = Ds.Tables[0].Rows[0]["Company_Type"].ToString();
                _Phone_No = Ds.Tables[0].Rows[0]["Phone_No"].ToString();
                _Phone_No_Code = Ds.Tables[0].Rows[0]["Phone_No_Code"].ToString();
                _Fax_No = Ds.Tables[0].Rows[0]["Fax_No"].ToString();
                _Alternate_Phone_No = Ds.Tables[0].Rows[0]["Alternate_Phone_No"].ToString();
                _Alternate_Phone_No_Code = Ds.Tables[0].Rows[0]["Alternate_Phone_No_Code"].ToString();
                _Web_Address = Ds.Tables[0].Rows[0]["Web_Address"].ToString();
                _EIN_Number = Ds.Tables[0].Rows[0]["EIN_Number"].ToString();
                _SocialSecurity = Ds.Tables[0].Rows[0]["SocialSecurity"].ToString();
                _IndividualTax = Ds.Tables[0].Rows[0]["IndividualTax"].ToString();
                _ATTYStateLicense = Ds.Tables[0].Rows[0]["ATTYStateLicense"].ToString();
                _Registered_Date = Ds.Tables[0].Rows[0]["Registered_Date"].ToString();
                _Registration_State = Ds.Tables[0].Rows[0]["Registration_State"].ToString();
                _Registration_Date = Ds.Tables[0].Rows[0]["Registration_Date"].ToString();
                _Person_FullName = Ds.Tables[0].Rows[0]["Person_FullName"].ToString();
                _Person_Designation = Ds.Tables[0].Rows[0]["Person_Designation"].ToString();
                _Person_CellNo = Ds.Tables[0].Rows[0]["Person_CellNo"].ToString();
                _Person_Email = Ds.Tables[0].Rows[0]["Person_Email"].ToString();
                _Password = Ds.Tables[0].Rows[0]["Password"].ToString();
                _Person_Fax = Ds.Tables[0].Rows[0]["Person_Fax"].ToString();
                _Description = Ds.Tables[0].Rows[0]["Description"].ToString();
                _HaveAffiliates = Ds.Tables[0].Rows[0]["HaveAffiliates"].ToString();
                if(!(Ds.Tables[0].Rows[0]["NoofEmployees"]==DBNull.Value))
                    _NoofEmployees = Convert.ToInt32(Ds.Tables[0].Rows[0]["NoofEmployees"].ToString());
                if (!(Ds.Tables[0].Rows[0]["NoofH1BEmployees"] == DBNull.Value))
                    _NoofH1BEmployees = Convert.ToInt32(Ds.Tables[0].Rows[0]["NoofH1BEmployees"].ToString());

                if (!(Ds.Tables[0].Rows[0]["NoofH1BEmployees"] == DBNull.Value))
                    _FileToDate = Convert.ToInt32(Ds.Tables[0].Rows[0]["FileToDate"].ToString());

                if (!(Ds.Tables[0].Rows[0]["WithdrawanyH1Bs"] == DBNull.Value))
                    _WithdrawanyH1Bs = Ds.Tables[0].Rows[0]["WithdrawanyH1Bs"].ToString();

                _H1bPetitionsDenied = Ds.Tables[0].Rows[0]["H1bPetitionsDenied"].ToString();

                if (!(Ds.Tables[0].Rows[0]["AnnualIncome"] == DBNull.Value))
                    _AnnualIncome = Ds.Tables[0].Rows[0]["AnnualIncome"].ToString();

                if (!(Ds.Tables[0].Rows[0]["LastYearIncome"] == DBNull.Value))
                    _LastYearIncome = Ds.Tables[0].Rows[0]["LastYearIncome"].ToString();

                if (!(Ds.Tables[0].Rows[0]["NetAnnualIncome"] == DBNull.Value))
                    _NetAnnualIncome = Ds.Tables[0].Rows[0]["NetAnnualIncome"].ToString();

                if (!(Ds.Tables[0].Rows[0]["LastYearNetIncome"] == DBNull.Value))
                    _LastYearNetIncome = Ds.Tables[0].Rows[0]["LastYearNetIncome"].ToString();

                _Comments = Ds.Tables[0].Rows[0]["Comments"].ToString();
                _CreatedDate = Ds.Tables[0].Rows[0]["CreatedDate"].ToString();
                _AttoneyUpdated_Date = Ds.Tables[0].Rows[0]["AttoneyUpdated_Date"].ToString();
                _SelfUpdated_Date = Ds.Tables[0].Rows[0]["SelfUpdated_Date"].ToString();
                _Add_AptNo = Ds.Tables[0].Rows[0]["Add_AptNo"].ToString();
                _Add_Street = Ds.Tables[0].Rows[0]["Add_Street"].ToString();
                _Add_City= Ds.Tables[0].Rows[0]["Add_City"].ToString();
                _Add_State= Ds.Tables[0].Rows[0]["Add_State"].ToString();
                _Add_ZipCode = Ds.Tables[0].Rows[0]["Add_ZipCode"].ToString();
                _Naics_Code = Ds.Tables[0].Rows[0]["Naics_Code"].ToString();

                _Contact_Info = Ds.Tables[0].Rows[0]["Contact_Info"].ToString();
                _NIV_Contact_Info = Ds.Tables[0].Rows[0]["NIV_Contact_Info"].ToString();
                _IV_Contact_Info = Ds.Tables[0].Rows[0]["IV_Contact_Info"].ToString();
                _Acc_Contact_Info = Ds.Tables[0].Rows[0]["Acc_Contact_Info"].ToString();
                _Temp_Contact_Info = Ds.Tables[0].Rows[0]["Temp_Contact_Info"].ToString();
                _H1B_Dependent = Ds.Tables[0].Rows[0]["H1B_Dependent"].ToString();
                _Public_Law = Ds.Tables[0].Rows[0]["Public_Law"].ToString();
                _Preferences = Ds.Tables[0].Rows[0]["Preferences"].ToString();

            }

        }
        protected string GenerateNextTrackingNo()
        {
            string strNextTrackingNo="";
            string strYear="";
            strYear = DateTime.Today.Year.ToString();
            strYear = strYear.ToString().Replace("20", "");

            if (_Next_Sequence_No.ToString() == "" || _Next_Sequence_No.ToString() == "0")
            {
                strNextTrackingNo="01";
            }
            else if (_Next_Sequence_No > 0 && _Next_Sequence_No <= 9)
            {
                strNextTrackingNo = "0" + _Next_Sequence_No.ToString();
            }
            else
            {
                strNextTrackingNo = _Next_Sequence_No.ToString();
            }

            strNextTrackingNo = strYear + _Short_Name + strNextTrackingNo;
            return strNextTrackingNo;
        }
        public void bindTypeCombo(DropDownList ddl,int selVal)
        {
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            dr = DB.getReader("Select * from Visa_type Where Visa_Type_id<=3");

            ddl.DataTextField = "Visa_Type_Name";
            ddl.DataValueField = "Visa_Type_Id";
            ddl.DataSource = dr;
            ddl.DataBind();
            dr.Close();
            ddl.Items.Insert(0,new ListItem("Select","0"));
            ddl.SelectedValue = selVal.ToString(); 
        }

        public int UpdateCompany()
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Company_Update1";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = this.Company_id;
        cmd.Parameters.Add("@Short_Name", SqlDbType.VarChar,5).Value = this.Short_Name;
        cmd.Parameters.Add("@Legal_Name", SqlDbType.VarChar,200).Value = this.Legal_Name;
        cmd.Parameters.Add("@Mailing_Address", SqlDbType.VarChar, 500).Value = this.Mailing_Address;
        cmd.Parameters.Add("@Add_AptNo", SqlDbType.VarChar, 500).Value = this.Add_AptNo;
        cmd.Parameters.Add("@Add_Street", SqlDbType.VarChar, 500).Value = this.Add_Street;
        cmd.Parameters.Add("@Add_City", SqlDbType.VarChar, 500).Value = this.Add_City;
        cmd.Parameters.Add("@Add_State", SqlDbType.VarChar, 500).Value = this.Add_State;
        cmd.Parameters.Add("@Add_ZipCode", SqlDbType.VarChar, 500).Value = this.Add_Zip;
        cmd.Parameters.Add("@Documents_Address", SqlDbType.VarChar, 500).Value = this.Documents_Address;
        cmd.Parameters.Add("@Company_Type", SqlDbType.VarChar, 20).Value = this.Company_Type;
        cmd.Parameters.Add("@Phone_No", SqlDbType.VarChar, 50).Value = this.Phone_No;
        cmd.Parameters.Add("@Phone_No_Code", SqlDbType.VarChar, 50).Value = this.Phone_No_Code;
        cmd.Parameters.Add("@Fax_No", SqlDbType.VarChar, 50).Value = this.Fax_No;
        cmd.Parameters.Add("@Alternate_Phone_No", SqlDbType.VarChar, 50).Value = this.Alternate_Phone_No;
        cmd.Parameters.Add("@Alternate_Phone_No_Code", SqlDbType.VarChar, 50).Value = this.Alternate_Phone_No_Code;
        cmd.Parameters.Add("@Web_Address", SqlDbType.VarChar, 100).Value = this.Web_Address;
        cmd.Parameters.Add("@EIN_Number", SqlDbType.VarChar, 50).Value = this.EIN_Number;
        try
        {
            cmd.Parameters.Add("@Registered_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(this.Registered_Date).ToString();
        }
        catch { }
        cmd.Parameters.Add("@Registration_State", SqlDbType.VarChar, 50).Value = this.Registration_State;
        try
        {
            cmd.Parameters.Add("@Registration_Date", SqlDbType.DateTime).Value = Convert.ToDateTime(this.Registration_Date).ToString();
        }
        catch { }
        cmd.Parameters.Add("@Person_FullName", SqlDbType.VarChar, 100).Value = this.Person_FullName;
        cmd.Parameters.Add("@Person_Designation", SqlDbType.VarChar, 100).Value = this.Person_Designation;
        cmd.Parameters.Add("@Person_CellNo", SqlDbType.VarChar, 20).Value = this.Person_CellNo;
        cmd.Parameters.Add("@Person_Email", SqlDbType.VarChar, 100).Value = this.Person_Email;
        cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = this.Password;
        cmd.Parameters.Add("@Person_Fax", SqlDbType.VarChar, 30).Value = this.Person_Fax;
        cmd.Parameters.Add("@Description", SqlDbType.VarChar, 2000).Value = this.Description;
        cmd.Parameters.Add("@HaveAffiliates", SqlDbType.VarChar, 100).Value = this.HaveAffiliates;
        cmd.Parameters.Add("@NoofEmployees", SqlDbType.Int).Value = this.NoofEmployees;
        cmd.Parameters.Add("@NoofH1BEmployees", SqlDbType.Int).Value = this.NoofH1BEmployees;
        cmd.Parameters.Add("@FileToDate", SqlDbType.Int).Value = this.FileToDate;
        cmd.Parameters.Add("@WithdrawanyH1Bs", SqlDbType.VarChar, 50).Value = this.WithdrawanyH1Bs;
        cmd.Parameters.Add("@H1bPetitionsDenied", SqlDbType.VarChar, 50).Value = this.H1bPetitionsDenied;
        cmd.Parameters.Add("@AnnualIncome", SqlDbType.VarChar, 100).Value = this.AnnualIncome;
        cmd.Parameters.Add("@LastYearIncome", SqlDbType.VarChar, 100).Value = this.LastYearIncome;
        cmd.Parameters.Add("@NetAnnualIncome", SqlDbType.VarChar, 100).Value = this.NetAnnualIncome;
        cmd.Parameters.Add("@LastYearNetIncome", SqlDbType.VarChar, 100).Value = this.LastYearNetIncome;
        cmd.Parameters.Add("@Comments", SqlDbType.Text).Value = this.Comments;
        cmd.Parameters.Add("@SocialSecurity", SqlDbType.Text).Value = this.SocialSecurity;
        cmd.Parameters.Add("@IndividualTax", SqlDbType.Text).Value = this.IndividualTax;
        cmd.Parameters.Add("@ATTYStateLicense", SqlDbType.Text).Value = this.ATTYStateLicense;
        cmd.Parameters.Add("@Naics_Code", SqlDbType.VarChar, 50).Value = this.Naics_Code;

        cmd.Parameters.Add("@Contact_Info", SqlDbType.VarChar, 50).Value = this.Contact_Info;
        cmd.Parameters.Add("@NIV_Contact_Info", SqlDbType.VarChar, 50).Value = this.NIV_Contact_Info;
        cmd.Parameters.Add("@IV_Contact_Info", SqlDbType.VarChar, 50).Value = this.IV_Contact_Info;
        cmd.Parameters.Add("@Acc_Contact_Info", SqlDbType.VarChar, 50).Value = this.Acc_Contact_Info;
        cmd.Parameters.Add("@Temp_Contact_Info", SqlDbType.VarChar, 50).Value = this.Temp_Contact_Info;
        cmd.Parameters.Add("@H1B_Dependent", SqlDbType.VarChar, 50).Value = this.H1B_Dependent;
        cmd.Parameters.Add("@Public_Law", SqlDbType.VarChar, 50).Value = this.Public_Law;
        cmd.Parameters.Add("@Preferences", SqlDbType.Text).Value = this.Preferences;
        dbConnection.Open();
        cmd.ExecuteNonQuery();
        dbConnection.Close();
        return 1;
        }

        public int CreateCompany()
        {
            int CompanyId = 0;
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Company_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@AttorneyId", SqlDbType.VarChar, 200).Value = this._AttorneyId;
            cmd.Parameters.Add("@CompanyName", SqlDbType.VarChar, 200).Value = this.Legal_Name;
            cmd.Parameters.Add("@ShortName", SqlDbType.VarChar, 20).Value = this.Short_Name;
            cmd.Parameters.Add("@ContactPersonName", SqlDbType.VarChar, 200).Value = this.Person_FullName  ;
            cmd.Parameters.Add("ContactPersonEmail", SqlDbType.VarChar, 200).Value =this.Person_Email;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = this.Password;
           
            cmd.Parameters.Add("@CompanyId", SqlDbType.VarChar, 200).Direction = ParameterDirection.Output; 
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            CompanyId = Convert.ToInt32(cmd.Parameters["@CompanyId"].Value);
            dbConnection.Close();
            return CompanyId;
        }


        public DataSet GetEmployerEmployeesList(int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Employer_Employee_Select_All", "@CompanyId", intCompanyId.ToString());
        }

        public DataSet GetEmployerEmployeesList(int intCompanyId, string strTrackingNo)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Employer_Employee_Search_TrackNoNameReceiptNo", "@CompanyId", intCompanyId.ToString(), "@TrackingNo", strTrackingNo);
        }

        public DataSet GetAttorneyEmployeesList(int intCompanyId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_Search1", "@CompanyId", intCompanyId.ToString());
        }


        public DataSet GetAttorneyEmployeesList(int intCompanyId, string strTrackingNo)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Attorney_Employee_Search2", "@CompanyId", intCompanyId.ToString(),"@TrackingNo",strTrackingNo);
        }

        public bool SendEmployerInvitation()
        {
            string strBaseUrl = System.Configuration.ConfigurationSettings.AppSettings.Get("BaseUrl"); 
            string strLink = strBaseUrl  + "/employer/index.aspx";
            string strBody = "<br>Dear " + this.Person_FullName; 
            //strBody += "<br><p>To process " + this.VisaType + " Visa, Please submit your information by click on below link";
            strBody += "<p><a href='" + strLink.ToString() + "'>" + strLink.ToString() + "</a>";
            strBody += "<br><br>User Name: " + this.Person_Email;
            strBody += "<br><br>Password: " + this.Password; 
            clsSendEmail objMail = new clsSendEmail();
            objMail.SendTo = this.Person_Email;
            objMail.FromName = "ramineni@raminenilaw.com";
            objMail.Body = strBody;
            objMail.BCc = "ramineni@raminenilaw.com";
            objMail.Subject = "Your Login Information";
            objMail.Send();
            return true;
        }

        public int CheckAuthontication(string strEmail, String strPassword)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            int intEid = 0;
            Ds = DB.getSPResults("Company_Login_Email", "@EmailAddress", strEmail,"@Password",strPassword);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0]["password"].ToString() == strPassword)
                {
                    flag = true;
                    intEid = Convert.ToInt32(Ds.Tables[0].Rows[0]["Companyid"].ToString());
                    _Person_FullName = Ds.Tables[0].Rows[0]["Person_FullName"].ToString();
                    _Legal_Name = Ds.Tables[0].Rows[0]["Legal_Name"].ToString();
                }
            }

            return intEid;


        }

        public bool isExistCompanyEmail(string strEmail)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            Ds = DB.getSPResults("Company_Select_Email", "@EmailAddress", strEmail);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }

            return flag;


        }

        public bool ChangePassword(int Comapnyid, string strOldPass, string strNewPass)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            int intFlag = 0;
            Ds = DB.getSPResults("Company_Change_Password","@CompanyId",Comapnyid.ToString(), "@OldPassword", strOldPass,"@NewPassword",strNewPass);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                intFlag =Convert.ToInt32(Ds.Tables[0].Rows[0]["Result"].ToString());

                if(intFlag==1)
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
    }

     


    
}


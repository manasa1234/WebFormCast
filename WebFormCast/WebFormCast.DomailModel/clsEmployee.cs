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
using System.Text;
using System.Data.SqlClient;
using ACLGDataAaccess;
using System.IO;
using System.Security.Cryptography;

namespace WebFormCast.ACLG
{

    public class AcglEmployee : AcglGeneral
    {


        int _EmployeeId = 0;
        int _Company_id = 0;
        string _FirstName = "";
        string _LastName = "";
        string _Email = "";
        string _TrackingNo = "";
        int _intJobTitelId = 0;
        string _JobTitel = "";
        string _JobDescription = "";
        string _NT_Job_Description = "";
        string _EmployeeCode = "";
        string _AccessKey = "";
        string _VisaType = "";
        int _Visa_Type_id = 0;
        string _MiddleName = "";
        string _OtherName1 = "";
        string _OtherName2 = "";
        string _OtherName3 = "";
        string _TelNo = "";
        string _DateofBirth = "";
        string _MaritalStatus = "";
        string _SocialSecurity = "";
        string _ANumber = "";
        string _CountryofBirth = "";
        string _StateofBirth = "";
        string _CountryofCitixenship = "";
        string _I94 = "";
        string _DateofFirstEntry = "";
        string _DateofLastArrival = "";
        string _PassportNumber = "";
        string _Passportissuedate = "";
        string _PassportExpiresDate = "";
        string _CNIStatus = "";
        string _CNIDateStatusExpires = "";
        string _ConsulateCityCountry = "";
        string _ConsulateCityCountry1 = "";
        string _ForeignAddress = "";

        string _ForeignAddress_Street = "";
        string _ForeignAddress_AppNo = "";
        string _ForeignAddress_City = "";
        string _ForeignAddress_State = "";
        string _ForeignAddress_Country = "";
        string _ForeignAddress_Zip = "";

        string _USAddress_Street = "";
        string _USAddress_AppNo = "";
        string _USAddress_City = "";
        string _USAddress_State = "";
        string _USAddress_Zip = "";
        bool _H1Bwithnpast7yrs = false;
        bool _Denied = false;
        string _PrevReceiptNo = "";
        public string ReceiptNo = "";
        string _DateIn1 = "";
        string _DateIn2 = "";
        string _DateIn3 = "";
        string _DateIn4 = "";
        string _DateOut1 = "";
        string _DateOut2 = "";
        string _DateOut3 = "";
        string _DateOut4 = "";
        string _Skills = "";
        string _Reference2 = "";
        string _Reference1 = "";
        bool _Dependents = false;
        int _DependentsCount = 0;
        int _status = 0;

        public string Date_Filed = "";
        public string Silvergate_Inv_No = "";
        public string Due_Date = "";
        //Nullable<DateTime> Due_Date;
        public int Updated_By_User_ID = 0;
        public int Assign_to = 0;
        public string Updated_On = "";
        public string Status_Note = "";
        public string Type_Note = "";

        public int HighestLeve = 0;
        public string PrimaryFieldofStudy = "";
        public bool MasterDegreeFromUS = false;
        public string USInstitutionName = "";
        public string USDateDegreeAwarded = "";
        public string USDegreeType = "";
        public string USInstitutionAddress = "";

        public int Rate_of_Pay_Per_Year = 0;

        public string DateIntendedFrom = "";
        public string DateIntendedTo = "";
        public bool isFulltime = false;
        public string Hours_per_week = "";
        public string WagsperYear = "";
        public string WorkLocation = "";

        public string LCA_Case_Code = "";
        public string NAICS_Code = "";
        public string Other_Compensation = "";
        public string work_experience = "";

        public string Title = "";
        public int CurrentAddress = 0;
        public int CaseOwner = 0;
        public int Employee_Access = 1;
        public int Employer_Access = 1;

        string _Q_isUSResident = null;
        string _Q_isThirdParty = null;
        string _Q_isPremiumFee = null;
        string _Q_isEmpRelated = null;
        string _Q_isFileDependents = null;
        string _Q_isPrevEmployed = null;
        string _SevisNo = "";
        string _StdEADNo = "";
        string _PassportIssueCountry = "";
        string _EC_JobTitle = "";
        string _EC_Name = "";
        string _EC_Address = "";
        string _EC_MgrName = "";
        string _EC_Email = "";
        string _EC_Phone = "";

        string _PERM_DateFiled = "";
        string _PERM_CaseNo = "";
        string _I140_ReceiptNo = "";
        string _Pend_App_Type = "";
        string _Pend_App_ReceiptNo = "";
        string _Comments = "";

        public int Status
        {
            get
            {
                return _status;
            }
        }

        public string StatusString(int statusStr)
        {

            if (statusStr == 1 || statusStr == 0)
                return "Open";
            else if (statusStr == 2)
                return "Open";
            else if (statusStr == 3)
                return "Finalized";
            else if (statusStr == 4)
                return "In Review";
            else if (statusStr == 5)
                return "In Review";
            else if (statusStr == 6)
                return "InProcess";
            else if (statusStr == 7)
                return "Completed";
            else
                return "n/a";
        }

        public string StatusText
        {
            get
            {
                if (_status == 1 || _status == 0)
                    return "Open";
                else if (_status == 2)
                    return "Open";
                else if (_status == 3)
                    return "Finalized";
                else if (_status == 4)
                    return "In Review";
                else if (_status == 5)
                    return "In Review";
                else if (_status == 6)
                    return "InProcess";
                else if (_status == 7)
                    return "Completed";
                else
                    return "n/a";

                //if (oE.Status == 6)
                //    lbStatus.Text = "New";
                //else if (oE.Status == 10)
                //    lbStatus.Text = "In Review";
                //else if (oE.Status == 11)
                //    lbStatus.Text = "Accepted";
                //else if (oE.Status == 12)
                //    lbStatus.Text = "In Progress";
                //else if (oE.Status == 15)
                //    lbStatus.Text = "Filed";

            }
        }




        public int EmployeeId
        {
            get
            {
                return _EmployeeId;
            }
        }
        public int Company_id
        {
            get
            {
                return _Company_id;
            }
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
        }
        public string Email
        {
            get
            {
                return _Email;
            }
        }
        public string TrackingNo
        {
            get
            {
                return _TrackingNo;
            }
        }
        public string EmployeeCode
        {
            get
            {
                return _EmployeeCode;
            }
        }

        public int JobTitleId
        {
            get
            {
                return _intJobTitelId;
            }
        }
        public string JobTitel
        {
            get
            {
                return _JobTitel;
            }
        }

        public string JobDescription
        {
            get
            {
                return _JobDescription;
            }
        }
        public string NT_Job_Description
        {
            get
            {
                return _NT_Job_Description;
            }
        }
        public string AccessKey
        {
            get
            {
                if (_Email != "")
                    return _AccessKey;
                else
                    return "";
            }
        }

        public int Visa_Type_id
        {
            get
            {

                return _Visa_Type_id;
            }
        }
        public string VisaType
        {
            get
            {
                return _VisaType;
            }
        }


        public string MiddleName
        {
            get
            {
                return _MiddleName;
            }
        }
        public string OtherName1
        {
            get
            {
                return _OtherName1;
            }
        }
        public string OtherName2
        {
            get
            {
                return _OtherName2;
            }
        }
        public string OtherName3
        {
            get
            {
                return _OtherName3;
            }
        }
        public string TelNo
        {
            get
            {
                return _TelNo;
            }
        }
        public string DateofBirth
        {
            get
            {
                return _DateofBirth;

            }
        }
        public string MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
        }
        public string SocialSecurity
        {
            get
            {
                return _SocialSecurity;
            }
        }
        public string ANumber
        {
            get
            {
                return _ANumber;
            }
        }
        public string CountryofBirth
        {
            get
            {
                return _CountryofBirth;
            }
        }
        public string StateofBirth
        {
            get
            {
                return _StateofBirth;
            }
        }
        public string CountryofCitixenship
        {
            get
            {
                return _CountryofCitixenship;
            }
        }
        public string I94
        {
            get
            {
                return _I94;
            }
        }
        public string DateofFirstEntry
        {
            get
            {
                return _DateofFirstEntry;
            }
        }
        public string DateofLastArrival
        {
            get
            {
                return _DateofLastArrival;
            }
        }
        public string PassportNumber
        {
            get
            {
                return _PassportNumber;
            }
        }
        public string Passportissuedate
        {
            get
            {
                return _Passportissuedate;
            }
        }
        public string PassportExpiresDate
        {
            get
            {
                return _PassportExpiresDate;
            }
        }
        public string CNIStatus
        {
            get
            {
                return _CNIStatus;
            }
        }
        public string CNIDateStatusExpires
        {
            get
            {
                return _CNIDateStatusExpires;
            }
        }
        public string ConsulateCityCountry
        {
            get
            {
                return _ConsulateCityCountry;
            }
        }
        public string ConsulateCityCountry1
        {
            get
            {
                return _ConsulateCityCountry1;
            }
        }

        public string ForeignAddress
        {
            get
            {
                return _ForeignAddress;
            }
        }
        public string ForeignAddress_Street
        {
            get
            {
                return _ForeignAddress_Street;
            }
        }
        public string ForeignAddress_AppNo
        {
            get
            {
                return _ForeignAddress_AppNo;
            }
        }
        public string ForeignAddress_City
        {
            get
            {
                return _ForeignAddress_City;
            }
        }
        public string ForeignAddress_State
        {
            get
            {
                return _ForeignAddress_State;
            }
        }
        public string ForeignAddress_Country
        {
            get
            {
                return _ForeignAddress_Country;
            }
        }
        public string ForeignAddress_Zip
        {
            get
            {
                return _ForeignAddress_Zip;
            }
        }

        public string USAddress_Street
        {
            get
            {
                return _USAddress_Street;
            }
        }
        public string USAddress_AppNo
        {
            get
            {
                return _USAddress_AppNo;
            }
        }
        public string USAddress_City
        {
            get
            {
                return _USAddress_City;
            }
        }
        public string USAddress_State
        {
            get
            {
                return _USAddress_State;
            }
        }
        public string USAddress_Zip
        {
            get
            {
                return _USAddress_Zip;
            }
        }



        public bool H1Bwithnpast7yrs
        {
            get
            {
                return _H1Bwithnpast7yrs;
            }
        }
        public bool Denied
        {
            get
            {
                return _Denied;
            }
        }
        public string PrevReceiptNo
        {
            get
            {
                return _PrevReceiptNo;
            }
        }
        public string DateIn1
        {
            get
            {
                return _DateIn1;
            }
        }
        public string DateIn2
        {
            get
            {
                return _DateIn2;
            }
        }

        public string DateIn3
        {
            get
            {
                return _DateIn3;
            }
        }


        public string DateIn4
        {
            get
            {
                return _DateIn4;
            }
        }
        public string DateOut1
        {
            get
            {
                return _DateOut1;
            }
        }
        public string DateOut2
        {
            get
            {
                return _DateOut2;
            }
        }
        public string DateOut3
        {
            get
            {
                return _DateOut3;
            }
        }
        public string DateOut4
        {
            get
            {
                return _DateOut4;
            }
        }
        public string Skills
        {
            get
            {
                return _Skills;
            }
        }
        public string Reference2
        {
            get
            {
                return _Reference2;
            }
        }
        public string Reference1
        {
            get
            {
                return _Reference1;
            }
        }
        public bool Dependents
        {
            get
            {
                return _Dependents;
            }
        }
        public int DependentsCount
        {
            get
            {
                return _DependentsCount;
            }
        }

        public string Q_isUSResident
        {
            get
            {
                return _Q_isUSResident;
            }
        }

        public string Q_isThirdParty
        {
            get
            {
                return _Q_isThirdParty;
            }
        }

        public string Q_isPremiumFee
        {
            get
            {
                return _Q_isPremiumFee;
            }
        }

        public string Q_isEmpRelated
        {
            get
            {
                return _Q_isEmpRelated;
            }
        }

        public string Q_isFileDependents
        {
            get
            {
                return _Q_isFileDependents;
            }
        }

        public string Q_isPrevEmployed
        {
            get
            {
                return _Q_isPrevEmployed;
            }
        }

        public string SevisNo
        {
            get
            {
                return _SevisNo;
            }
        }

        public string StdEADNo
        {
            get
            {
                return _StdEADNo;
            }
        }

        public string PassportIssueCountry
        {
            get
            {
                return _PassportIssueCountry;
            }
        }
        public string EC_JobTitle
        {
            get
            {
                return _EC_JobTitle;
            }
        }

        public string EC_Name
        {
            get
            {
                return _EC_Name;
            }
        }

        public string EC_Address
        {
            get
            {
                return _EC_Address;
            }
        }

        public string EC_MgrName
        {
            get
            {
                return _EC_MgrName;
            }
        }

        public string EC_Email
        {
            get
            {
                return _EC_Email;
            }
        }

        public string EC_Phone
        {
            get
            {
                return _EC_Phone;
            }
        }

        public string PERM_DateFiled
        {
            get
            {
                return _PERM_DateFiled;
            }
        }

        public string PERM_CaseNo
        {
            get
            {
                return _PERM_CaseNo;
            }
        }

        public string I140_ReceiptNo
        {
            get
            {
                return _I140_ReceiptNo;
            }
        }

        public string Pend_App_Type
        {
            get
            {
                return _Pend_App_Type;
            }
        }

        public string Pend_App_ReceiptNo
        {
            get
            {
                return _Pend_App_ReceiptNo;
            }
        }

        public string Comments
        {
            get
            {
                return _Comments;
            }
        }

        public AcglEmployee()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        public AcglEmployee(int EmployeeId)
        {
            Initialize(EmployeeId);
        }

        public bool SendEmployeeAccessMail()
        {
            string strBaseUrl = System.Configuration.ConfigurationSettings.AppSettings.Get("BaseUrl");
            string strLink = strBaseUrl + "/employee/index.aspx";
            string strBody = "<br>Dear " + this.FirstName + " " + this.LastName;
            strBody += "<br><p>To process " + this.VisaType + "Visa, Please submit your information by click on below link";
            strBody += "<p><a href='" + strLink.ToString() + "'>" + strLink.ToString() + "</a>";
            strBody += "<br><br>UserName: " + this.Email;
            strBody += "<br><br>Password: " + this.AccessKey;
            strBody += "<br><br>";
            clsSendEmail objMail = new clsSendEmail();
            objMail.SendTo = this.Email;
            objMail.FromName = "ramineni@raminenilaw.com";
            objMail.Body = strBody;
            objMail.BCc = "ramineni@raminenilaw.com";
            objMail.Subject = "Visa Process";
            objMail.Send();
            return true;
        }


        protected string GetAccessLink()
        {

            string strLink = "";
            string strurl = System.Configuration.ConfigurationSettings.AppSettings.Get("BaseUrl");
            strLink += "employee_id=" + this._EmployeeId.ToString() + "&employee_signature=" + this._EmployeeCode;
            strLink = strurl + "/?" + Encryption.Encrypt(strLink);
            return strLink;
        }

        public void Initialize(int intEmployeeid)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            Ds = DB.getSPResults("Employee_Select", "@EmployeeId", intEmployeeid.ToString());


            if (Ds.Tables[0].Rows.Count > 0)
            {
                _FirstName = Ds.Tables[0].Rows[0]["First_Name"].ToString();
                _LastName = Ds.Tables[0].Rows[0]["Last_Name"].ToString();
                _Email = Ds.Tables[0].Rows[0]["Email_Address"].ToString();
                _AccessKey = Ds.Tables[0].Rows[0]["Access_Key"].ToString();
                _EmployeeCode = Ds.Tables[0].Rows[0]["Employee_code"].ToString();
                _TrackingNo = Ds.Tables[0].Rows[0]["Tracking_No"].ToString();
                _EmployeeId = Convert.ToInt32(Ds.Tables[0].Rows[0]["Employee_id"].ToString());
                _Company_id = Convert.ToInt32(Ds.Tables[0].Rows[0]["Company_id"].ToString());
                _VisaType = Ds.Tables[0].Rows[0]["Visa_Type_Name"].ToString();
                //String s = Ds.Tables[0].Rows[0]["Visa_Type_id"].ToString();
                string i = (Ds.Tables[0].Rows[0]["Visa_Type_id"].ToString());
                if (i == "")
                {
                    _Visa_Type_id = 0;
                }
                else
                {
                    _Visa_Type_id = Convert.ToInt32(i);

                }

                _MiddleName = Ds.Tables[0].Rows[0]["MiddleName"].ToString();
                _OtherName1 = Ds.Tables[0].Rows[0]["OtherName1"].ToString();
                _OtherName2 = Ds.Tables[0].Rows[0]["OtherName2"].ToString();
                _OtherName3 = Ds.Tables[0].Rows[0]["OtherName3"].ToString();
                _TelNo = Ds.Tables[0].Rows[0]["TelNo"].ToString();
                _DateofBirth = Ds.Tables[0].Rows[0]["DateofBirth"].ToString();
                _MaritalStatus = Ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
                _SocialSecurity = Ds.Tables[0].Rows[0]["SocialSecurity"].ToString();
                _ANumber = Ds.Tables[0].Rows[0]["ANumber"].ToString();
                _CountryofBirth = Ds.Tables[0].Rows[0]["CountryofBirth"].ToString();
                _StateofBirth = Ds.Tables[0].Rows[0]["StateofBirth"].ToString();
                _CountryofCitixenship = Ds.Tables[0].Rows[0]["CountryofCitixenship"].ToString();
                _I94 = Ds.Tables[0].Rows[0]["I94"].ToString();
                _DateofFirstEntry = Ds.Tables[0].Rows[0]["DateofFirstEntry"].ToString();
                _DateofLastArrival = Ds.Tables[0].Rows[0]["DateofLastArrival"].ToString();
                _PassportNumber = Ds.Tables[0].Rows[0]["PassportNumber"].ToString();
                _Passportissuedate = Ds.Tables[0].Rows[0]["Passportissuedate"].ToString();
                _PassportIssueCountry = Ds.Tables[0].Rows[0]["PassportIssueCountry"].ToString();
                _PassportExpiresDate = Ds.Tables[0].Rows[0]["PassportExpiresDate"].ToString();
                _CNIStatus = Ds.Tables[0].Rows[0]["CNIStatus"].ToString();
                _CNIDateStatusExpires = Ds.Tables[0].Rows[0]["CNIDateStatusExpires"].ToString();
                _ConsulateCityCountry = Ds.Tables[0].Rows[0]["ConsulateCityCountry"].ToString();
                _ConsulateCityCountry1 = Ds.Tables[0].Rows[0]["ConsulateCityCountry1"].ToString();
                _ForeignAddress = Ds.Tables[0].Rows[0]["ForeignAddress"].ToString();

                _USAddress_Street = Ds.Tables[0].Rows[0]["USAddress_Street"].ToString();
                _USAddress_AppNo = Ds.Tables[0].Rows[0]["USAddress_ApptNo"].ToString();
                _USAddress_City = Ds.Tables[0].Rows[0]["USAddress_City"].ToString();
                _USAddress_State = Ds.Tables[0].Rows[0]["USAddress_State"].ToString();
                _USAddress_Zip = Ds.Tables[0].Rows[0]["USAddress_Zip"].ToString();

                _ForeignAddress_Street = Ds.Tables[0].Rows[0]["ForeignAddress_Street"].ToString();
                _ForeignAddress_AppNo = Ds.Tables[0].Rows[0]["ForeignAddress_ApptNo"].ToString();
                _ForeignAddress_City = Ds.Tables[0].Rows[0]["ForeignAddress_City"].ToString();
                _ForeignAddress_State = Ds.Tables[0].Rows[0]["ForeignAddress_State"].ToString();
                _ForeignAddress_Country = Ds.Tables[0].Rows[0]["ForeignAddress_Country"].ToString();
                _ForeignAddress_Zip = Ds.Tables[0].Rows[0]["ForeignAddress_Zip"].ToString();


                _H1Bwithnpast7yrs = Convert.ToBoolean(Ds.Tables[0].Rows[0]["H1Bwithnpast7yrs"].ToString());
                _Denied = Convert.ToBoolean(Ds.Tables[0].Rows[0]["Denied"].ToString());
                _PrevReceiptNo = Ds.Tables[0].Rows[0]["PrevReceiptNo"].ToString();
                ReceiptNo = Ds.Tables[0].Rows[0]["ReceiptNo"].ToString();
                _DateIn1 = Ds.Tables[0].Rows[0]["DateIn1"].ToString();
                _DateIn2 = Ds.Tables[0].Rows[0]["DateIn2"].ToString();
                _DateIn3 = Ds.Tables[0].Rows[0]["DateIn3"].ToString();
                _DateIn4 = Ds.Tables[0].Rows[0]["DateIn4"].ToString();
                _DateOut1 = Ds.Tables[0].Rows[0]["DateOut1"].ToString();
                _DateOut2 = Ds.Tables[0].Rows[0]["DateOut2"].ToString();
                _DateOut3 = Ds.Tables[0].Rows[0]["DateOut3"].ToString();
                _DateOut4 = Ds.Tables[0].Rows[0]["DateOut4"].ToString();
                _Skills = Ds.Tables[0].Rows[0]["Skills"].ToString();
                _Reference2 = Ds.Tables[0].Rows[0]["Reference2"].ToString();
                _Reference1 = Ds.Tables[0].Rows[0]["Reference1"].ToString();
                _Dependents = Convert.ToBoolean(Ds.Tables[0].Rows[0]["Dependents"].ToString());
                _DependentsCount = Convert.ToInt32(Ds.Tables[0].Rows[0]["DependentsCount"].ToString());
                _status = Convert.ToInt32(Ds.Tables[0].Rows[0]["STATUS"].ToString());
                _JobTitel = Ds.Tables[0].Rows[0]["Job_Title"].ToString();
                string s = Ds.Tables[0].Rows[0]["JobTitle_id"].ToString();
                if (s == "")
                {
                    _intJobTitelId = 0;
                }
                else
                {
                    _intJobTitelId = Convert.ToInt32(s);
                }
                _JobDescription = Ds.Tables[0].Rows[0]["Job_Description"].ToString();
                _NT_Job_Description = Ds.Tables[0].Rows[0]["NT_Job_Description"].ToString();
                HighestLeve = Convert.ToInt32(Ds.Tables[0].Rows[0]["HighestLeve"].ToString());
                PrimaryFieldofStudy = Ds.Tables[0].Rows[0]["PrimaryFieldofStudy"].ToString();
                MasterDegreeFromUS = Convert.ToBoolean(Ds.Tables[0].Rows[0]["MasterDegreeFromUS"].ToString());
                USInstitutionName = Ds.Tables[0].Rows[0]["USInstitutionName"].ToString();
                USDateDegreeAwarded = Ds.Tables[0].Rows[0]["USDateDegreeAwarded"].ToString();
                USDegreeType = Ds.Tables[0].Rows[0]["USDegreeType"].ToString();
                USInstitutionAddress = Ds.Tables[0].Rows[0]["USInstitutionAddress"].ToString();
                Rate_of_Pay_Per_Year = Convert.ToInt32(Ds.Tables[0].Rows[0]["Rate_of_Pay_Per_Year"].ToString());
                CaseOwner = Convert.ToInt32(Ds.Tables[0].Rows[0]["Case_Owner"].ToString());
                Employee_Access = Convert.ToInt32(Ds.Tables[0].Rows[0]["Employee_Access"].ToString());
                Employer_Access = Convert.ToInt32(Ds.Tables[0].Rows[0]["Employer_Access"].ToString());

                _Q_isUSResident = Ds.Tables[0].Rows[0]["Q_isUSResident"].ToString();
                _Q_isThirdParty = Ds.Tables[0].Rows[0]["Q_isThirdParty"].ToString();
                _Q_isPremiumFee = Ds.Tables[0].Rows[0]["Q_isPremiumFee"].ToString();
                _Q_isEmpRelated = Ds.Tables[0].Rows[0]["Q_isEmpRelated"].ToString();
                _Q_isFileDependents = Ds.Tables[0].Rows[0]["Q_isFileDependents"].ToString();
                _Q_isPrevEmployed = Ds.Tables[0].Rows[0]["Q_isPrevEmployed"].ToString();
                _SevisNo = Ds.Tables[0].Rows[0]["SEVIS_Number"].ToString();
                _StdEADNo = Ds.Tables[0].Rows[0]["Std_EAD_RNumber"].ToString();

                _EC_JobTitle = Ds.Tables[0].Rows[0]["EC_JobTitle"].ToString();
                _EC_Name = Ds.Tables[0].Rows[0]["EC_Name"].ToString();
                _EC_Address = Ds.Tables[0].Rows[0]["EC_Address"].ToString();
                _EC_MgrName = Ds.Tables[0].Rows[0]["EC_MgrName"].ToString();
                _EC_Email = Ds.Tables[0].Rows[0]["EC_Email"].ToString();
                _EC_Phone = Ds.Tables[0].Rows[0]["EC_Phone"].ToString();
                _PERM_DateFiled = Ds.Tables[0].Rows[0]["PERM_DateFiled"].ToString();
                _PERM_CaseNo = Ds.Tables[0].Rows[0]["PERM_CaseNo"].ToString();
                _I140_ReceiptNo = Ds.Tables[0].Rows[0]["I140_ReceiptNo"].ToString();
                _Pend_App_Type = Ds.Tables[0].Rows[0]["Pend_App_Type"].ToString();
                _Pend_App_ReceiptNo = Ds.Tables[0].Rows[0]["Pend_App_ReceiptNo"].ToString();

                Date_Filed = Ds.Tables[0].Rows[0]["Date_Filed"].ToString();
                Silvergate_Inv_No = Ds.Tables[0].Rows[0]["Silvergate_Inv_No"].ToString();
                Due_Date = Ds.Tables[0].Rows[0]["Due_Date"].ToString();
                try
                {
                    Updated_By_User_ID = Convert.ToInt32(Ds.Tables[0].Rows[0]["Updated_By_User_ID"].ToString());
                }
                catch { }
                try
                {

                    Assign_to = Convert.ToInt32(Ds.Tables[0].Rows[0]["Assign_to"].ToString());
                }
                catch
                { }
                Status_Note = Ds.Tables[0].Rows[0]["Status_Note"].ToString();
                Type_Note = Ds.Tables[0].Rows[0]["Type_Note"].ToString();
                Updated_On = Ds.Tables[0].Rows[0]["Updated_On"].ToString();


                DateIntendedFrom = Ds.Tables[0].Rows[0]["DateIntendedFrom"].ToString();
                DateIntendedTo = Ds.Tables[0].Rows[0]["DateIntendedTo"].ToString();
                try
                {
                    isFulltime = Convert.ToBoolean(Ds.Tables[0].Rows[0]["isFulltime"].ToString());
                }
                catch { }
                Hours_per_week = Ds.Tables[0].Rows[0]["Hours_per_week"].ToString();
                WagsperYear = Ds.Tables[0].Rows[0]["WagsperYear"].ToString();
                WorkLocation = Ds.Tables[0].Rows[0]["WorkLocation"].ToString();

                LCA_Case_Code = Ds.Tables[0].Rows[0]["LCA_Case_Code"].ToString();
                NAICS_Code = Ds.Tables[0].Rows[0]["NAICS_Code"].ToString();
                Other_Compensation = Ds.Tables[0].Rows[0]["Other_Compensation"].ToString();
                work_experience = Ds.Tables[0].Rows[0]["work_experience"].ToString();
                Title = Ds.Tables[0].Rows[0]["Title"].ToString();
                CurrentAddress = Convert.ToInt32(Ds.Tables[0].Rows[0]["CurrentAddress"].ToString());
            }

        }

        public int CheckAuthontication(string strEmail, String strPassword)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            int intEid = 0;
            int intAccess = 1;
            Ds = DB.getSPResults("Employee_Select_Email", "@EmailAddress", strEmail);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                if (Ds.Tables[0].Rows[0]["Access_Key"].ToString() == strPassword)
                {
                    flag = true;
                    if (Ds.Tables[0].Rows[0]["Employee_Access"].ToString() != "")
                        intAccess = Convert.ToInt32(Ds.Tables[0].Rows[0]["Employee_Access"].ToString());

                    if (intAccess == Convert.ToInt32(EMPLOYEE.READ_YES_EDIT_YES) || intAccess == Convert.ToInt32(EMPLOYEE.READ_YES_EDIT_NO))
                        intEid = Convert.ToInt32(Ds.Tables[0].Rows[0]["Employee_id"].ToString());
                }
            }

            return intEid;


        }


        public bool EmailisExists(string strEmail)
        {
            ACLGDB DB = new ACLGDB();
            DataSet Ds = new DataSet();
            bool flag = false;
            int intEid = 0;
            Ds = DB.getSPResults("Employee_Select_Email", "@EmailAddress", strEmail);

            if (Ds.Tables[0].Rows.Count > 0)
            {
                flag = true;
            }

            return flag;


        }

        public int CreateNewEmployee(int CompanyId, string strFirst_Name, string strLast_Name, string strEmail_Address, int CaseType, int JobTitleid, string strTracking_Code, string strMessage)
        {
            string strAccessKey = GetAccessKey();
            string strEmployeeCode = getenKey(strEmail_Address);
            int intEmployee_id = 0;
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_Insert";
            cmd.Connection = dbConnection;

            SqlParameter dbParam = new SqlParameter();
            dbParam = new SqlParameter();
            dbParam.ParameterName = "@First_Name";
            dbParam.Value = strFirst_Name;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);
            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Last_Name";
            dbParam.Value = strLast_Name;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Email";
            dbParam.Value = strEmail_Address;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Access_Key";
            dbParam.Value = strAccessKey;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);
            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Tracking_No";
            dbParam.Value = strTracking_Code;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Employee_Code";
            dbParam.Value = strEmployeeCode;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Creation_Message";
            dbParam.Value = strMessage;
            dbParam.DbType = System.Data.DbType.String;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Company_id";
            dbParam.Value = CompanyId;
            dbParam.DbType = System.Data.DbType.Int16;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@VisaType";
            dbParam.Value = CaseType;
            dbParam.DbType = System.Data.DbType.Int16;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@JobTitleId";
            dbParam.Value = JobTitleid;
            dbParam.DbType = System.Data.DbType.Int16;
            cmd.Parameters.Add(dbParam);

            dbParam = new SqlParameter();
            dbParam.ParameterName = "@Employee_id";
            dbParam.DbType = System.Data.DbType.Int16;
            dbParam.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(dbParam);

            dbConnection.Open();
            cmd.ExecuteNonQuery();

            intEmployee_id = Convert.ToInt32(cmd.Parameters["@Employee_id"].Value);
            dbConnection.Close();
            return intEmployee_id;
        }

        public int UpdateEmployeeEducation(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_UpdateEducation";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeId;
            cmd.Parameters.Add("@HighestLeve", SqlDbType.Int).Value = this.HighestLeve;
            cmd.Parameters.Add("@PrimaryFieldofStudy", SqlDbType.VarChar, 200).Value = this.PrimaryFieldofStudy;
            cmd.Parameters.Add("@MasterDegreeFromUS", SqlDbType.Bit).Value = this.MasterDegreeFromUS;
            cmd.Parameters.Add("@USInstitutionName", SqlDbType.VarChar, 200).Value = this.USInstitutionName;
            cmd.Parameters.Add("@USDateDegreeAwarded", SqlDbType.VarChar, 200).Value = this.USDateDegreeAwarded;
            cmd.Parameters.Add("@USDegreeType", SqlDbType.VarChar, 200).Value = this.USDegreeType;
            cmd.Parameters.Add("@USInstitutionAddress", SqlDbType.VarChar, 500).Value = this.USInstitutionAddress;


            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return 1;

        }

        public int Update1Employee(int intEmployeeId,
        string FirstName,
        string LastName,
        string MiddleName,
        string OtherName1,
        string OtherName2,
        string OtherName3,
        string TelNo,
        string DateofBirth,
        string SocialSecurity,
        string ANumber,
        string CountryofBirth,
        string StateofBirth,
        string CountryofCitixenship,
        string I94,
        string DateofFirstEntry,
        string DateofLastArrival,
        string PassportNumber,
        string Passportissuedate,
        string PassportExpiresDate,
        string CNIStatus,
        string CNIDateStatusExpires,
        string ConsulateCityCountry,
        string ConsulateCityCountry1,
        string ForeignAddress,
        string ForeignAddress_Street,
        string ForeignAddress_AppNo,
        string ForeignAddress_City,
        string ForeignAddress_State,
        string ForeignAddress_Country,
        string ForeignAddress_Zip,
        string USAddress_Street,
        string USAddress_AppNo,
        string USAddress_City,
        string USAddress_State,
        string USAddress_Zip,
        bool H1Bwithnpast7yrs,
        bool Denied,
        string Skills,
        string Title,
        int CurrentAddress,
        string SevisNo,
        string StdEADNo,
        string PassportIssueCountry,
        string EC_JobTitle,
        string EC_Name,
        string EC_Address,
        string EC_MgrName,
        string EC_Email,
        string EC_Phone,
        string PERM_DateFiled, string PERM_CaseNo, string I140_ReceiptNo, string Pend_App_Type, string Pend_App_ReceiptNo
            )
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_Update1";
            cmd.Connection = dbConnection;

            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeId;
            cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 100).Value = FirstName;
            cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 100).Value = LastName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar, 100).Value = MiddleName;
            cmd.Parameters.Add("@OtherName1", SqlDbType.VarChar, 100).Value = OtherName1;
            cmd.Parameters.Add("@OtherName2", SqlDbType.VarChar, 100).Value = OtherName2;
            cmd.Parameters.Add("@OtherName3", SqlDbType.VarChar, 100).Value = OtherName3;
            cmd.Parameters.Add("@TelNo", SqlDbType.VarChar, 50).Value = TelNo;
            try
            {
                cmd.Parameters.Add("@DateofBirth", SqlDbType.DateTime).Value = Convert.ToDateTime(DateofBirth).ToString();
            }
            catch { }
            cmd.Parameters.Add("@SocialSecurity", SqlDbType.VarChar, 50).Value = SocialSecurity;
            cmd.Parameters.Add("@ANumber", SqlDbType.VarChar, 50).Value = ANumber;
            cmd.Parameters.Add("@CountryofBirth", SqlDbType.VarChar, 50).Value = CountryofBirth;
            cmd.Parameters.Add("@StateofBirth", SqlDbType.VarChar, 50).Value = StateofBirth;
            cmd.Parameters.Add("@CountryofCitixenship", SqlDbType.VarChar, 50).Value = CountryofCitixenship;
            cmd.Parameters.Add("@I94", SqlDbType.VarChar, 50).Value = I94;
            try
            {
                cmd.Parameters.Add("@DateofFirstEntry", SqlDbType.DateTime).Value = Convert.ToDateTime(DateofFirstEntry).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateofLastArrival", SqlDbType.DateTime).Value = Convert.ToDateTime(DateofLastArrival).ToString();
            }
            catch { }
            cmd.Parameters.Add("@PassportNumber", SqlDbType.VarChar, 50).Value = PassportNumber;
            try
            {
                cmd.Parameters.Add("@Passportissuedate", SqlDbType.DateTime).Value = Convert.ToDateTime(Passportissuedate).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@PassportExpiresDate", SqlDbType.DateTime).Value = Convert.ToDateTime(PassportExpiresDate);
            }
            catch { }
            cmd.Parameters.Add("@CNIStatus", SqlDbType.VarChar, 100).Value = CNIStatus;
            try
            {
                cmd.Parameters.Add("@CNIDateStatusExpires", SqlDbType.DateTime).Value = Convert.ToDateTime(CNIDateStatusExpires).ToString();
            }
            catch { }
            cmd.Parameters.Add("@ConsulateCityCountry", SqlDbType.VarChar, 50).Value = ConsulateCityCountry;
            cmd.Parameters.Add("@ConsulateCityCountry1", SqlDbType.VarChar, 50).Value = ConsulateCityCountry1;
            cmd.Parameters.Add("@ForeignAddress", SqlDbType.VarChar, 400).Value = ForeignAddress;

            cmd.Parameters.Add("@ForeignAddress_Street", SqlDbType.VarChar, 100).Value = ForeignAddress_Street;
            cmd.Parameters.Add("@ForeignAddress_AppNo", SqlDbType.VarChar, 100).Value = ForeignAddress_AppNo;
            cmd.Parameters.Add("@ForeignAddress_City", SqlDbType.VarChar, 100).Value = ForeignAddress_City;
            cmd.Parameters.Add("@ForeignAddress_State", SqlDbType.VarChar, 100).Value = ForeignAddress_State;
            cmd.Parameters.Add("@ForeignAddress_Country", SqlDbType.VarChar, 100).Value = ForeignAddress_Country;
            cmd.Parameters.Add("@ForeignAddress_Zip", SqlDbType.VarChar, 50).Value = ForeignAddress_Zip;

            cmd.Parameters.Add("@USAddress_Street", SqlDbType.VarChar, 100).Value = USAddress_Street;
            cmd.Parameters.Add("@USAddress_AppNo", SqlDbType.VarChar, 100).Value = USAddress_AppNo;
            cmd.Parameters.Add("@USAddress_City", SqlDbType.VarChar, 100).Value = USAddress_City;
            cmd.Parameters.Add("@USAddress_State", SqlDbType.VarChar, 100).Value = USAddress_State;
            cmd.Parameters.Add("@USAddress_Zip", SqlDbType.VarChar, 50).Value = USAddress_Zip;


            cmd.Parameters.Add("@H1Bwithnpast7yrs", SqlDbType.Bit).Value = H1Bwithnpast7yrs;
            cmd.Parameters.Add("@Denied", SqlDbType.Bit).Value = Denied;
            cmd.Parameters.Add("@PrevReceiptNo", SqlDbType.VarChar, 50).Value = PrevReceiptNo;
            cmd.Parameters.Add("@Skills", SqlDbType.Text).Value = Skills;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 10).Value = Title;
            cmd.Parameters.Add("@CurrentAddress", SqlDbType.Int).Value = CurrentAddress;
            cmd.Parameters.Add("@SevisNo", SqlDbType.VarChar).Value = SevisNo;
            cmd.Parameters.Add("@StdEADNo", SqlDbType.VarChar).Value = StdEADNo;
            cmd.Parameters.Add("@PassportIssueCountry", SqlDbType.VarChar).Value = PassportIssueCountry;
            cmd.Parameters.Add("@EC_JobTitle", SqlDbType.VarChar).Value = EC_JobTitle;
            cmd.Parameters.Add("@EC_Name", SqlDbType.VarChar).Value = EC_Name;
            cmd.Parameters.Add("@EC_Address", SqlDbType.VarChar).Value = EC_Address;
            cmd.Parameters.Add("@EC_MgrName", SqlDbType.VarChar).Value = EC_MgrName;
            cmd.Parameters.Add("@EC_Email", SqlDbType.VarChar).Value = EC_Email;
            cmd.Parameters.Add("@EC_Phone", SqlDbType.VarChar).Value = EC_Phone;
            try
            {
                cmd.Parameters.Add("@PERM_DateFiled", SqlDbType.DateTime).Value = string.IsNullOrEmpty(PERM_DateFiled) ? (Object)DBNull.Value : Convert.ToDateTime(PERM_DateFiled).ToString();
            }
            catch { }
            cmd.Parameters.Add("@PERM_CaseNo", SqlDbType.VarChar).Value = PERM_CaseNo;
            cmd.Parameters.Add("@I140_ReceiptNo", SqlDbType.VarChar).Value = I140_ReceiptNo;
            cmd.Parameters.Add("@Pend_App_Type", SqlDbType.VarChar).Value = Pend_App_Type;
            cmd.Parameters.Add("@Pend_App_ReceiptNo", SqlDbType.VarChar).Value = Pend_App_ReceiptNo;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return 1;
        }
        public int Update1Employee_Attorney(int intEmployeeId,
        string FirstName,
        string LastName,
        string MiddleName,
        string OtherName1,
        string OtherName2,
        string OtherName3,
        string Email,
        string TelNo,
        string DateofBirth,
        string SocialSecurity,
        string ANumber,
        string CountryofBirth,
        string StateofBirth,
        string CountryofCitixenship,
        string I94,
        string DateofFirstEntry,
        string DateofLastArrival,
        string PassportNumber,
        string Passportissuedate,
        string PassportExpiresDate,
        string CNIStatus,
        string CNIDateStatusExpires,
        string ConsulateCityCountry,
        string ConsulateCityCountry1,
        string ForeignAddress,
        string ForeignAddress_Street,
        string ForeignAddress_AppNo,
        string ForeignAddress_City,
        string ForeignAddress_State,
        string ForeignAddress_Country,
        string ForeignAddress_Zip,
        string USAddress_Street,
        string USAddress_AppNo,
        string USAddress_City,
        string USAddress_State,
        string USAddress_Zip,
        bool H1Bwithnpast7yrs,
        bool Denied,
        string PrevReceiptNo,
        string DateIn1,
        string DateIn2,
        string DateIn3,
        string DateIn4,
        string DateOut1,
        string DateOut2,
        string DateOut3,
        string DateOut4,
        string Skills,
        string Reference2,
        string Reference1,
        bool Dependents,
        int DependentsCount,
        string Title,
        int CurrentAddress
            )
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_Update3";
            cmd.Connection = dbConnection;


            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeId;
            cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 100).Value = FirstName;
            cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 100).Value = LastName;
            cmd.Parameters.Add("@MiddleName", SqlDbType.VarChar, 100).Value = MiddleName;
            cmd.Parameters.Add("@OtherName1", SqlDbType.VarChar, 100).Value = OtherName1;
            cmd.Parameters.Add("@OtherName2", SqlDbType.VarChar, 100).Value = OtherName2;
            cmd.Parameters.Add("@OtherName3", SqlDbType.VarChar, 100).Value = OtherName3;
            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 100).Value = Email;
            cmd.Parameters.Add("@TelNo", SqlDbType.VarChar, 50).Value = TelNo;
            try
            {
                cmd.Parameters.Add("@DateofBirth", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateofBirth) ? (Object)DBNull.Value : Convert.ToDateTime(DateofBirth).ToString();
            }
            catch { }
            cmd.Parameters.Add("@SocialSecurity", SqlDbType.VarChar, 50).Value = SocialSecurity;
            cmd.Parameters.Add("@ANumber", SqlDbType.VarChar, 50).Value = ANumber;
            cmd.Parameters.Add("@CountryofBirth", SqlDbType.VarChar, 50).Value = CountryofBirth;
            cmd.Parameters.Add("@StateofBirth", SqlDbType.VarChar, 50).Value = StateofBirth;
            cmd.Parameters.Add("@CountryofCitixenship", SqlDbType.VarChar, 50).Value = CountryofCitixenship;
            cmd.Parameters.Add("@I94", SqlDbType.VarChar, 50).Value = I94;
            try
            {
                cmd.Parameters.Add("@DateofFirstEntry", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateofFirstEntry) ? (Object)DBNull.Value : Convert.ToDateTime(DateofFirstEntry).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateofLastArrival", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateofLastArrival) ? (Object)DBNull.Value : Convert.ToDateTime(DateofLastArrival).ToString();
            }
            catch { }
            cmd.Parameters.Add("@PassportNumber", SqlDbType.VarChar, 50).Value = PassportNumber;
            try
            {
                cmd.Parameters.Add("@Passportissuedate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(Passportissuedate) ? (Object)DBNull.Value : Convert.ToDateTime(Passportissuedate).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@PassportExpiresDate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(PassportExpiresDate) ? (Object)DBNull.Value : Convert.ToDateTime(PassportExpiresDate).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CNIStatus", SqlDbType.VarChar, 100).Value = CNIStatus;
            try
            {
                cmd.Parameters.Add("@CNIDateStatusExpires", SqlDbType.DateTime).Value = string.IsNullOrEmpty(CNIDateStatusExpires) ? (Object)DBNull.Value : Convert.ToDateTime(CNIDateStatusExpires).ToString();
            }
            catch { }
            cmd.Parameters.Add("@ConsulateCityCountry", SqlDbType.VarChar, 50).Value = ConsulateCityCountry;
            cmd.Parameters.Add("@ConsulateCityCountry1", SqlDbType.VarChar, 50).Value = ConsulateCityCountry1;
            cmd.Parameters.Add("@ForeignAddress", SqlDbType.VarChar, 400).Value = ForeignAddress;

            cmd.Parameters.Add("@ForeignAddress_Street", SqlDbType.VarChar, 100).Value = ForeignAddress_Street;
            cmd.Parameters.Add("@ForeignAddress_AppNo", SqlDbType.VarChar, 100).Value = ForeignAddress_AppNo;
            cmd.Parameters.Add("@ForeignAddress_City", SqlDbType.VarChar, 100).Value = ForeignAddress_City;
            cmd.Parameters.Add("@ForeignAddress_State", SqlDbType.VarChar, 100).Value = ForeignAddress_State;
            cmd.Parameters.Add("@ForeignAddress_Country", SqlDbType.VarChar, 100).Value = ForeignAddress_Country;
            cmd.Parameters.Add("@ForeignAddress_Zip", SqlDbType.VarChar, 50).Value = ForeignAddress_Zip;

            cmd.Parameters.Add("@USAddress_Street", SqlDbType.VarChar, 100).Value = USAddress_Street;
            cmd.Parameters.Add("@USAddress_AppNo", SqlDbType.VarChar, 100).Value = USAddress_AppNo;
            cmd.Parameters.Add("@USAddress_City", SqlDbType.VarChar, 100).Value = USAddress_City;
            cmd.Parameters.Add("@USAddress_State", SqlDbType.VarChar, 100).Value = USAddress_State;
            cmd.Parameters.Add("@USAddress_Zip", SqlDbType.VarChar, 50).Value = USAddress_Zip;

            cmd.Parameters.Add("@H1Bwithnpast7yrs", SqlDbType.Bit).Value = H1Bwithnpast7yrs;
            cmd.Parameters.Add("@Denied", SqlDbType.Bit).Value = Denied;
            cmd.Parameters.Add("@PrevReceiptNo", SqlDbType.VarChar, 50).Value = PrevReceiptNo;
            try
            {
                cmd.Parameters.Add("@DateIn1", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateIn1) ? (Object)DBNull.Value : Convert.ToDateTime(DateIn1).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateIn2", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateIn2) ? (Object)DBNull.Value : Convert.ToDateTime(DateIn2).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateIn3", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateIn3) ? (Object)DBNull.Value : Convert.ToDateTime(DateIn3).ToString();
            }
            catch { }

            try
            {
                cmd.Parameters.Add("@DateIn4", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateIn4) ? (Object)DBNull.Value : Convert.ToDateTime(DateIn4).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateOut1", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateOut1) ? (Object)DBNull.Value : Convert.ToDateTime(DateOut1).ToString();
            }
            catch { }

            try
            {
                cmd.Parameters.Add("@DateOut2", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateOut2) ? (Object)DBNull.Value : Convert.ToDateTime(DateOut2).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateOut3", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateOut3) ? (Object)DBNull.Value : Convert.ToDateTime(DateOut3).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateOut4", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateOut4) ? (Object)DBNull.Value : Convert.ToDateTime(DateOut4).ToString();
            }
            catch { }
            cmd.Parameters.Add("@Skills", SqlDbType.Text).Value = Skills;
            cmd.Parameters.Add("@Reference1", SqlDbType.VarChar, 50).Value = Reference1;
            cmd.Parameters.Add("@Reference2", SqlDbType.VarChar, 50).Value = Reference2;
            cmd.Parameters.Add("@Dependents", SqlDbType.Bit).Value = Dependents;
            cmd.Parameters.Add("@DependentsCount", SqlDbType.Int).Value = DependentsCount;
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 10).Value = Title;
            cmd.Parameters.Add("@CurrentAddress", SqlDbType.Int).Value = CurrentAddress;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return 1;
        }

        public string GetAccessKey()
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Substring(1, 6);
            return guidResult;

        }


        public string getenKey(string strname)
        {
            string internalKey = strname.Trim();
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            UTF8Encoding ENC = new UTF8Encoding();
            byte[] internalHashBytes = MD5.ComputeHash(ENC.GetBytes(internalKey.ToString().Trim()));
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (i = 0; i <= internalHashBytes.Length - 1; i++)
            {
                sb.Append(internalHashBytes[i].ToString("X2"));
            }
            string internalHash = sb.ToString();
            return internalHash;

        }
        public bool AddEducation(int intEmployeeID, string strUniversity, int intFromMonth, int intFromYear, int intToMonth, int intToYear, int intGradYear, string strDegree)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Education_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@University", SqlDbType.VarChar, 500).Value = strUniversity;
            cmd.Parameters.Add("@FromMonth", SqlDbType.Int).Value = intFromMonth;
            cmd.Parameters.Add("@FromYear", SqlDbType.Int).Value = intFromYear;
            cmd.Parameters.Add("@ToYear", SqlDbType.Int).Value = intToYear;
            cmd.Parameters.Add("@ToMonth", SqlDbType.Int).Value = intToMonth;
            cmd.Parameters.Add("@GradYear", SqlDbType.Int).Value = intGradYear;
            cmd.Parameters.Add("@Degree_Name", SqlDbType.VarChar, 500).Value = strDegree;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool AddProfession(int intEmployeeID, string strEmployer, string strSkills, string strDeignation, int intFromMonth, int intFromYear, int intToMonth, int intToYear)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Profession_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Employer", SqlDbType.VarChar, 2000).Value = strEmployer;
            cmd.Parameters.Add("@FromMonth", SqlDbType.Int).Value = intFromMonth;
            cmd.Parameters.Add("@FromYear", SqlDbType.Int).Value = intFromYear;
            cmd.Parameters.Add("@ToYear", SqlDbType.Int).Value = intToYear;
            cmd.Parameters.Add("@ToMonth", SqlDbType.Int).Value = intToMonth;
            cmd.Parameters.Add("@Skills", SqlDbType.VarChar, 5000).Value = strSkills;
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 2000).Value = strDeignation;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool AddDependent(int pintEmployeeID, string pLast_Name, string pFirst_Name, string pMiddle_Namem, string pOther_Name, string pDateofBirht, string pCountryofBirth, string pCountryofCitizenship,
            string pUSSocialSecurityNo,
            string pANumber,
            string pI94,
            string pDateofFirstEntry,
            string pDateofLastArrival,
            string pPassportNo,
            string pPassportIssueDate,
            string pPassportExpireDate,
            string pCurrentNonimigrationStatus,
            string pDateStatusExpire,
            string pCountryPassportIssuance,
            string pForeignaddress,
            string pDaytimeTelephonenumber,
            string pEmailaddress,
            string pRelation,
            string pUSAddress
            )
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Dependents_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = pintEmployeeID;
            cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 100).Value = pLast_Name;
            cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 100).Value = pFirst_Name;
            cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 100).Value = pMiddle_Namem;
            cmd.Parameters.Add("@Other_Name", SqlDbType.VarChar, 100).Value = pOther_Name;
            try
            {
                cmd.Parameters.Add("@DateofBirht", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateofBirht) ? (Object)DBNull.Value : Convert.ToDateTime(pDateofBirht).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CountryofBirth", SqlDbType.VarChar, 100).Value = pCountryofBirth;
            cmd.Parameters.Add("@CountryofCitizenship", SqlDbType.VarChar, 100).Value = pCountryofCitizenship;
            cmd.Parameters.Add("@USSocialSecurityNo", SqlDbType.VarChar, 50).Value = pUSSocialSecurityNo;
            cmd.Parameters.Add("@ANumber", SqlDbType.VarChar, 100).Value = pANumber;
            cmd.Parameters.Add("@I94", SqlDbType.VarChar, 100).Value = pI94;

            try
            { cmd.Parameters.Add("@DateofFirstEntry", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateofFirstEntry) ? (Object)DBNull.Value : Convert.ToDateTime(pDateofFirstEntry).ToString(); }
            catch { }

            try
            {
                cmd.Parameters.Add("@DateofLastArrival", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateofLastArrival) ? (Object)DBNull.Value : Convert.ToDateTime(pDateofLastArrival).ToString();
            }
            catch { }
            cmd.Parameters.Add("@PassportNo", SqlDbType.VarChar, 100).Value = pPassportNo;
            try
            {
                cmd.Parameters.Add("@PassportIssueDate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pPassportIssueDate) ? (Object)DBNull.Value : Convert.ToDateTime(pPassportIssueDate).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@PassportExpireDate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pPassportExpireDate) ? (Object)DBNull.Value : Convert.ToDateTime(pPassportExpireDate).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CurrentNonimigrationStatus", SqlDbType.VarChar, 100).Value = pCurrentNonimigrationStatus;
            try
            {
                cmd.Parameters.Add("@DateStatusExpire", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateStatusExpire) ? (Object)DBNull.Value : Convert.ToDateTime(pDateStatusExpire).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CountryPassportIssuance", SqlDbType.VarChar, 100).Value = pCountryPassportIssuance;
            cmd.Parameters.Add("@Foreignaddress", SqlDbType.Text).Value = pForeignaddress;
            cmd.Parameters.Add("@DaytimeTelephonenumber", SqlDbType.VarChar, 100).Value = pDaytimeTelephonenumber;
            cmd.Parameters.Add("@Emailaddress", SqlDbType.VarChar, 100).Value = pEmailaddress;
            cmd.Parameters.Add("@Relation", SqlDbType.Text).Value = pRelation;
            cmd.Parameters.Add("@USAddress", SqlDbType.Text).Value = pUSAddress;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool UpdateDependent(int pintEmployeeID, string pLast_Name, string pFirst_Name, string pMiddle_Namem, string pOther_Name, string pDateofBirht, string pCountryofBirth, string pCountryofCitizenship,
           string pUSSocialSecurityNo,
           string pANumber,
           string pI94,
           string pDateofFirstEntry,
           string pDateofLastArrival,
           string pPassportNo,
           string pPassportIssueDate,
           string pPassportExpireDate,
           string pCurrentNonimigrationStatus,
           string pDateStatusExpire,
           string pCountryPassportIssuance,
           string pForeignaddress,
           string pDaytimeTelephonenumber,
           string pEmailaddress,
           string pRelation,
           string pUSAddress,
           string pSignature
           )
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Dependents_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = pintEmployeeID;
            cmd.Parameters.Add("@Last_Name", SqlDbType.VarChar, 100).Value = pLast_Name;
            cmd.Parameters.Add("@First_Name", SqlDbType.VarChar, 100).Value = pFirst_Name;
            cmd.Parameters.Add("@Middle_Name", SqlDbType.VarChar, 100).Value = pMiddle_Namem;
            cmd.Parameters.Add("@Other_Name", SqlDbType.VarChar, 100).Value = pOther_Name;
            try
            {
                cmd.Parameters.Add("@DateofBirht", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateofBirht) ? (Object)DBNull.Value : Convert.ToDateTime(pDateofBirht).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CountryofBirth", SqlDbType.VarChar, 100).Value = pCountryofBirth;
            cmd.Parameters.Add("@CountryofCitizenship", SqlDbType.VarChar, 100).Value = pCountryofCitizenship;
            cmd.Parameters.Add("@USSocialSecurityNo", SqlDbType.VarChar, 50).Value = pUSSocialSecurityNo;
            cmd.Parameters.Add("@ANumber", SqlDbType.VarChar, 100).Value = pANumber;
            cmd.Parameters.Add("@I94", SqlDbType.VarChar, 100).Value = pI94;

            try
            { cmd.Parameters.Add("@DateofFirstEntry", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateofFirstEntry) ? (Object)DBNull.Value : Convert.ToDateTime(pDateofFirstEntry).ToString(); }
            catch { }

            try
            {
                cmd.Parameters.Add("@DateofLastArrival", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateofLastArrival) ? (Object)DBNull.Value : Convert.ToDateTime(pDateofLastArrival).ToString();
            }
            catch { }
            cmd.Parameters.Add("@PassportNo", SqlDbType.VarChar, 100).Value = pPassportNo;
            try
            {
                cmd.Parameters.Add("@PassportIssueDate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pPassportIssueDate) ? (Object)DBNull.Value : Convert.ToDateTime(pPassportIssueDate).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@PassportExpireDate", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pPassportExpireDate) ? (Object)DBNull.Value : Convert.ToDateTime(pPassportExpireDate).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CurrentNonimigrationStatus", SqlDbType.VarChar, 100).Value = pCurrentNonimigrationStatus;
            try
            {
                cmd.Parameters.Add("@DateStatusExpire", SqlDbType.DateTime).Value = string.IsNullOrEmpty(pDateStatusExpire) ? (Object)DBNull.Value : Convert.ToDateTime(pDateStatusExpire).ToString();
            }
            catch { }
            cmd.Parameters.Add("@CountryPassportIssuance", SqlDbType.VarChar, 100).Value = pCountryPassportIssuance;
            cmd.Parameters.Add("@Foreignaddress", SqlDbType.Text).Value = pForeignaddress;
            cmd.Parameters.Add("@DaytimeTelephonenumber", SqlDbType.VarChar, 100).Value = pDaytimeTelephonenumber;
            cmd.Parameters.Add("@Emailaddress", SqlDbType.VarChar, 100).Value = pEmailaddress;
            cmd.Parameters.Add("@Relation", SqlDbType.Text).Value = pRelation;
            cmd.Parameters.Add("@USAddress", SqlDbType.Text).Value = pUSAddress;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = pSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool UpdateProfession(int intEmployeeID, string strEmployer, string strSkills, string strDeignation, int intFromMonth, int intFromYear, int intToMonth, int intToYear, string strSignature)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Profession_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Employer", SqlDbType.VarChar, 2000).Value = strEmployer;
            cmd.Parameters.Add("@FromMonth", SqlDbType.Int).Value = intFromMonth;
            cmd.Parameters.Add("@FromYear", SqlDbType.Int).Value = intFromYear;
            cmd.Parameters.Add("@ToYear", SqlDbType.Int).Value = intToYear;
            cmd.Parameters.Add("@ToMonth", SqlDbType.Int).Value = intToMonth;
            cmd.Parameters.Add("@Skills", SqlDbType.VarChar, 5000).Value = strSkills;
            cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 2000).Value = strDeignation;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool UpdateEducation(int intEmployeeID, string strUniversity, int intFromMonth, int intFromYear, int intToMonth, int intToYear, int intGradYear, string strDegree, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Education_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@University", SqlDbType.VarChar, 500).Value = strUniversity;
            cmd.Parameters.Add("@FromMonth", SqlDbType.Int).Value = intFromMonth;
            cmd.Parameters.Add("@FromYear", SqlDbType.Int).Value = intFromYear;
            cmd.Parameters.Add("@ToYear", SqlDbType.Int).Value = intToYear;
            cmd.Parameters.Add("@ToMonth", SqlDbType.Int).Value = intToMonth;
            cmd.Parameters.Add("@GradYear", SqlDbType.Int).Value = intGradYear;
            cmd.Parameters.Add("@Degree_Name", SqlDbType.VarChar, 500).Value = strDegree;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool DeleteEducation(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Education_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool DeleteProfession(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Profession_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool DeleteDependant(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Dependents_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public DataSet GetEducationList(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Education_Select", "@Employeeid", intEmployeeId.ToString());
        }

        public DataSet GetProfession(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Profession_Select", "@Employeeid", intEmployeeId.ToString());
        }

        public DataSet GetDepentents(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Dependents_Select", "@Employee_id", intEmployeeId.ToString());
        }

        public DataSet GetVendorList(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("Vendor_Select", "@Employee_id", intEmployeeId.ToString());
        }

        public bool UpdateVendor(int intEmployeeID, string name, string contactName, string email, string phone, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Vendor_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
            cmd.Parameters.Add("@Contact_Name", SqlDbType.VarChar, 100).Value = contactName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
            cmd.Parameters.Add("@Phone_number", SqlDbType.VarChar, 100).Value = phone;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool DeleteVendor(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Vendor_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool AddVendor(int intEmployeeID, string name, string contactName, string email, string phone)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Vendor_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
            cmd.Parameters.Add("@Contact_Name", SqlDbType.VarChar, 100).Value = contactName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = email;
            cmd.Parameters.Add("@Phone_number", SqlDbType.VarChar, 100).Value = phone;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public DataSet GetPrevReceiptList(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("PrevReceiptNo_Select", "@Employee_id", intEmployeeId.ToString());
        }

        public bool UpdatePrevReceipt(int intEmployeeID, string receiptNo, string empName, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PrevReceiptNo_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Receipt_No", SqlDbType.VarChar, 100).Value = receiptNo;
            cmd.Parameters.Add("@Employer_Name", SqlDbType.VarChar, 100).Value = empName;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool DeletePrevReceipt(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PrevReceiptNo_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool AddPrevReceipt(int intEmployeeID, string receiptNo, string empName)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PrevReceiptNo_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Receipt_No", SqlDbType.VarChar, 100).Value = receiptNo;
            cmd.Parameters.Add("@Employer_Name", SqlDbType.VarChar, 100).Value = empName;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public DataSet GetPrevStayList(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("PrevStay_Select", "@Employee_id", intEmployeeId.ToString());
        }

        public bool UpdatePrevStay(int intEmployeeID, string Status, string DateIn, string DateOut, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PrevStay_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 25).Value = Status;
            try
            {
                cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateIn) ? (Object)DBNull.Value : Convert.ToDateTime(DateIn).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateOut", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateOut) ? (Object)DBNull.Value : Convert.ToDateTime(DateOut).ToString();
            }
            catch { }
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool DeletePrevStay(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PrevStay_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool AddPrevStay(int intEmployeeID, string Status, string DateIn, string DateOut)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PrevStay_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 25).Value = Status;
            try
            {
                cmd.Parameters.Add("@DateIn", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateIn) ? (Object)DBNull.Value : Convert.ToDateTime(DateIn).ToString();
            }
            catch { }
            try
            {
                cmd.Parameters.Add("@DateOut", SqlDbType.DateTime).Value = string.IsNullOrEmpty(DateOut) ? (Object)DBNull.Value : Convert.ToDateTime(DateOut).ToString();
            }
            catch { }
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = guidResult;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool ApproveCaseAndSubmite(int intEmployeeID, int intEmployerId)
        {
            try
            {
                string strSql = "Update Employee set isEmployer_Approved=1,Employer_Approved_Date=getdate() Where Employee_id=" + intEmployeeID.ToString() + " And Company_id=" + intEmployerId.ToString();
                ACLGDB DB = new ACLGDB();
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStatus(int intEmployeeID, int intStatus)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Employee_Status_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@status", SqlDbType.Int).Value = intStatus;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }

        public bool UpdateComments(int intEmployeeID, string comments)
        {
            ACLGDB DB = new ACLGDB();
            string strSql = "Update Employee set Comments='" + comments + "' where employee_id=" + intEmployeeID;
            DB.ExeQuery(strSql);
            return true;
        }

        //public bool EnableDisable(int intEmployeeID,bool act)
        //{
        //    ACLGDB DB = new ACLGDB();
        //    string strSql = "Update Employee set  where employee_id=" + intEmployeeID;
        //    DB.ExeQuery(strSql);
        //    return true;
        //}

        public bool UpdateEmployment(int intEmployeeID, int intJobTitle_id, string strDateIntendedFrom, string strDateIntendedTo, bool bisFulltime, string strHours_per_week, string strWagsperYear, string strWorkLocation)
        {
            //try
            //{
            ACLGDB DB = new ACLGDB();
            int intisFullTime = 0;
            if (bisFulltime)
                intisFullTime = 1;
            string strSql = "Update Employee set JobTitle_id=" + intJobTitle_id + ",DateIntendedFrom='" + strDateIntendedFrom + "',DateIntendedTo='" + strDateIntendedTo + "',isFulltime=" + intisFullTime + ",Hours_per_week='" + strHours_per_week + "',WagsperYear='" + strWagsperYear + "',WorkLocation='" + strWorkLocation + "' where employee_id=" + intEmployeeID;
            DB.ExeQuery(strSql);
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }


        public bool SetEmployeeAccess(int intEmployeeID, int intAccess)
        {
            try
            {
                ACLGDB DB = new ACLGDB();
                string strSql = "Update Employee set Employee_Access=" + intAccess + " where employee_id=" + intEmployeeID;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SetEmployerAccess(int intEmployeeID, int intAccess)
        {
            try
            {
                ACLGDB DB = new ACLGDB();
                string strSql = "Update Employee set Employer_Access=" + intAccess + " where employee_id=" + intEmployeeID;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateAttorneyValues(int intEmployeeID, int intJobTitle_id, string strLCA_Case_Code, string strNAICS_Code, string strOther_Compensation, string strwork_experience, string strDateIntendedFrom, string strDateIntendedTo, bool bisFulltime, string strHours_per_week, string strWagsperYear, string strWorkLocation)
        {
            //try
            //{
            ACLGDB DB = new ACLGDB();
            int intisFullTime = 0;
            if (bisFulltime)
                intisFullTime = 1;
            string strSql = "Update Employee set JobTitle_id=" + intJobTitle_id + ",LCA_Case_Code='" + strLCA_Case_Code + "',NAICS_Code='" + strNAICS_Code + "',Other_Compensation='" + strOther_Compensation + "',work_experience='" + strwork_experience + "',DateIntendedFrom='" + strDateIntendedFrom + "',DateIntendedTo='" + strDateIntendedTo + "',isFulltime=" + intisFullTime + ",Hours_per_week='" + strHours_per_week + "',WagsperYear='" + strWagsperYear + "',WorkLocation='" + strWorkLocation + "' where employee_id=" + intEmployeeID;
            DB.ExeQuery(strSql);
            return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public bool UpdateInitialQuestions(int intEmployeeID, string qisUSResident, string qisThirdParty, string qisPremiumFee
            , string qisEmpRelated, string qisFileDependents, string qisPrevEmployed)
        {
            ACLGDB DB = new ACLGDB();
            string strSql = "Update Employee set Q_isUSResident ='" + qisUSResident + "', Q_isThirdParty ='" + qisThirdParty;
            strSql += "', Q_isPremiumFee='" + qisPremiumFee + "', Q_isEmpRelated ='" + qisEmpRelated;
            strSql += "', Q_isFileDependents='" + qisFileDependents + "', Q_isPrevEmployed ='" + qisPrevEmployed;
            strSql += "' where employee_id=" + intEmployeeID;
            DB.ExeQuery(strSql);
            return true;
        }
        public bool UpdateCaseType(int intEmployeeID, int Category_Id, int Visa_Type_id, string Inv_No, DateTime? Due_Date, int Status, DateTime? Date_Filed, int AssignTo, int userid, String ReceiptNo, string strSignature, string Other_Type)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CaseType_Update";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Category_Id", SqlDbType.Int).Value = Category_Id;
            cmd.Parameters.Add("@Visa_Type_Id", SqlDbType.Int).Value = Visa_Type_id;
            cmd.Parameters.Add("@Inv_No", SqlDbType.VarChar, 50).Value = Inv_No;
            cmd.Parameters.Add("@Due_Date", SqlDbType.DateTime).Value = Due_Date;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            cmd.Parameters.Add("@Date_Filed", SqlDbType.DateTime).Value = Date_Filed;
            cmd.Parameters.Add("@Assign_to", SqlDbType.Int).Value = AssignTo;
            cmd.Parameters.Add("@User_ID", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar, 50).Value = ReceiptNo;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            if (Other_Type == "")
            {
                cmd.Parameters.Add("@Other_Type", SqlDbType.NVarChar, 100).Value = string.Empty;
            }
            else
            {
                cmd.Parameters.Add("@Other_Type", SqlDbType.NVarChar, 100).Value = Other_Type;
            }
            dbConnection.Open();
            int rowseffected = 0;
            rowseffected=cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;
        }
        public bool InsertCaseType(int intEmployeeID, int Category_Id, int Visa_Type_id, string Inv_No, DateTime? Due_Date, int Status, DateTime? Date_Filed, int AssignTo, int userid, string ReceiptNo, string strSignature, string Other_Type)
        {
            string guidResult = System.Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", "");
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CaseType_Insert";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Category_Id", SqlDbType.Int).Value = Category_Id;
            cmd.Parameters.Add("@Visa_Type_Id", SqlDbType.Int).Value = Visa_Type_id;
            cmd.Parameters.Add("@Inv_No", SqlDbType.VarChar, 50).Value = Inv_No;
            cmd.Parameters.Add("@Due_Date ", SqlDbType.DateTime).Value = Due_Date;
            cmd.Parameters.Add("@Status", SqlDbType.Int).Value = Status;
            cmd.Parameters.Add("@Date_Filed ", SqlDbType.DateTime).Value = Date_Filed;
            cmd.Parameters.Add("@Assign_to", SqlDbType.Int).Value = AssignTo;
            cmd.Parameters.Add("@user_ID", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar, 50).Value = ReceiptNo;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
            cmd.Parameters.Add("@Other_Type", SqlDbType.NVarChar, 100).Value = Other_Type;
            //cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
            dbConnection.Open();
            Console.WriteLine("sql query:" + cmd);
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;

        }
        public DataSet GetCaseType(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();
            return DB.getSPResults("NewCaseType_Select", "@Employee_id", intEmployeeId.ToString());
        }
        public bool DeleteCaseType(int intEmployeeID, string strSignature)
        {
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CaseType_Delete";
            cmd.Connection = dbConnection;
            cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeID;
            cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = strSignature;
            dbConnection.Open();
            cmd.ExecuteNonQuery();
            dbConnection.Close();
            return true;

        }

    }
}
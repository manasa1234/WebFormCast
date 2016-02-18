using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ACLGDataAaccess;
namespace WebFormCast.ACLG
{
    public class Form_G28
    {
        string strSql = "";
        public bool isApproved = false;
        int Employee_id = 0;
        public string InRe="";
        public string Date1="";
        public string FileNo="";
        public string Name1="";
        public string NameType1="";
        public string AptNo1="";
        public string Street1="";
        public string City1="";
        public string State1="";
        public string Zip1="";
        public string Name2="";
        public string NameType2="";
        public string AptNo2="";
        public string Street2="";
        public string City2="";
        public string State2="";
        public string Zip2="";
        public string AttorneyFirmNameAddress="";
        public string AttorneyName="";
        public string AttorneyPhone="";
        public string AttorneyName2="";
        public string Form129Name="";
        public string CompanyPersonName="";
        public string Date2="";
        public string Note = "";




        public Form_G28()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public Form_G28(int EId)
        {
            Employee_id = EId;
            Initialize(Employee_id);
        }

        protected void Initialize(int intEmployeeId)
        {
            ACLGDB DB = new ACLGDB();

            DataSet Ds = new DataSet();

            Ds = DB.getSPResults("Form_G28_SELECT", "@Employee_id", intEmployeeId.ToString());

            if (Ds.Tables[0].Rows.Count > 0)
            {
                isApproved = true;
                InRe = Ds.Tables[0].Rows[0]["InRe"].ToString();
                Date1 = Ds.Tables[0].Rows[0]["Date1"].ToString();
                FileNo = Ds.Tables[0].Rows[0]["FileNo"].ToString();
                Name1 = Ds.Tables[0].Rows[0]["Name1"].ToString();
                NameType1 = Ds.Tables[0].Rows[0]["NameType1"].ToString();
                AptNo1 = Ds.Tables[0].Rows[0]["AptNo1"].ToString();
                Street1 = Ds.Tables[0].Rows[0]["Street1"].ToString();
                City1 = Ds.Tables[0].Rows[0]["City1"].ToString();
                State1 = Ds.Tables[0].Rows[0]["State1"].ToString();
                Zip1 = Ds.Tables[0].Rows[0]["Zip1"].ToString();
                Name2 = Ds.Tables[0].Rows[0]["Name2"].ToString();
                NameType2 = Ds.Tables[0].Rows[0]["NameType2"].ToString();
                AptNo2 = Ds.Tables[0].Rows[0]["AptNo2"].ToString();
                Street2 = Ds.Tables[0].Rows[0]["Street2"].ToString();
                City2 = Ds.Tables[0].Rows[0]["City2"].ToString();
                State2 = Ds.Tables[0].Rows[0]["State2"].ToString();
                Zip2 = Ds.Tables[0].Rows[0]["Zip2"].ToString();
                AttorneyFirmNameAddress = Ds.Tables[0].Rows[0]["AttorneyFirmNameAddress"].ToString();
                AttorneyName = Ds.Tables[0].Rows[0]["AttorneyName"].ToString();
                AttorneyPhone = Ds.Tables[0].Rows[0]["AttorneyPhone"].ToString();
                AttorneyName2 = Ds.Tables[0].Rows[0]["AttorneyName2"].ToString();
                Form129Name = Ds.Tables[0].Rows[0]["Form129Name"].ToString();
                CompanyPersonName = Ds.Tables[0].Rows[0]["CompanyPersonName"].ToString();
                Date2 = Ds.Tables[0].Rows[0]["Date2"].ToString();
                Note = Ds.Tables[0].Rows[0]["Note"].ToString();
            }
        }

        public bool Form_G28_Update(int intEmployeeId)
        {

            try
            {
                ACLGDataAaccess.ACLGDB DB = new ACLGDataAaccess.ACLGDB();
                strSql += "Update Form_G28 set ";
                strSql += "InRe='" + InRe + "'";
                strSql += ",Date1='" + Date1 + "'";
                strSql += ",FileNo='" + FileNo + "'";
                strSql += ",Name1='" + Name1 + "'";
                strSql += ",NameType1='" + NameType1 + "'";
                strSql += ",AptNo1='" + AptNo1 + "'";
                strSql += ",Street1='" + Street1 + "'";
                strSql += ",City1='" + City1 + "'";
                strSql += ",State1='" + State1 + "'";
                strSql += ",Zip1='" + Zip1 + "'";
                strSql += ",Name2='" + Name2 + "'";
                strSql += ",NameType2='" + NameType2 + "'";
                strSql += ",AptNo2='" + AptNo2 + "'";
                strSql += ",Street2='" + Street2 + "'";
                strSql += ",City2='" + City2 + "'";
                strSql += ",State2='" + State2 + "'";
                strSql += ",Zip2='" + Zip2 + "'";
                strSql += ",AttorneyFirmNameAddress='" + AttorneyFirmNameAddress + "'";
                strSql += ",AttorneyName='" + AttorneyName + "'";
                strSql += ",AttorneyPhone='" + AttorneyPhone + "'";
                strSql += ",AttorneyName2='" + AttorneyName2 + "'";
                strSql += ",Form129Name='" + Form129Name + "'";
                strSql += ",CompanyPersonName='" + CompanyPersonName + "'";
                strSql += ",Date2='" + Date2 + "'";
                strSql += ",Note='" + Note + "'";
                strSql += " where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
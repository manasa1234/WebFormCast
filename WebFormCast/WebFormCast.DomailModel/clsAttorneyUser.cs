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
/// Summary description for clsAttorneyUser
/// </summary>
namespace WebFormCast.ACLG
{



    public class AttorneyUser
    {
        public string User_Name = "";
        public string Password = "";
        public string User_Display_Name = "";
        public string Last_Access_Date = "";
        public string User_Type = "";
        public int Attorney_id = 0;
        public int User_ID = 0;
        public AttorneyUser()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public AttorneyUser(int intUserId)
        {
            
            string strSql = "Select * from Users where User_ID=" + intUserId + "";
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            bool Flag = false;

            dr = DB.getReader(strSql);

            if (dr.Read())
            {
                User_Name = dr["User_Name"].ToString();
                Password = dr["Password"].ToString();
                User_Display_Name = dr["User_Display_Name"].ToString();
                Last_Access_Date = dr["Last_Access_Date"].ToString();
                User_Type = dr["User_Type"].ToString();
                Attorney_id = Convert.ToInt32(dr["Attorney_id"].ToString());
                User_ID = Convert.ToInt32(dr["User_ID"].ToString());
                Flag = true;
            }
            dr.Close();
        }



        public bool UpdateLoginDate()
        {
            ACLGDB DB = new ACLGDB();
            string strSql = "Update Users set Last_Access_Date=getdate() Where User_ID=" + User_ID;
            DB.ExeQuery(strSql);
            return true;
        }
        public bool CheckAuthentication(string strUserName)
        {
            strUserName = strUserName.Replace("'","''");
            string strSql = "Select * from Users where User_Name='" + strUserName + "'";
            ACLGDB DB = new ACLGDB();
            SqlDataReader dr;
            bool Flag = false;

            dr = DB.getReader(strSql);

            if (dr.Read())
            {
                User_Name = dr["User_Name"].ToString();
                Password = dr["Password"].ToString();
                User_Display_Name = dr["User_Display_Name"].ToString();
                Last_Access_Date = dr["Last_Access_Date"].ToString();
                User_Type = dr["User_Type"].ToString();
                Attorney_id = Convert.ToInt32(dr["Attorney_id"].ToString());
                User_ID = Convert.ToInt32(dr["User_ID"].ToString());
                Flag = true;
            }
            dr.Close();
            return Flag;
        }
    }
}
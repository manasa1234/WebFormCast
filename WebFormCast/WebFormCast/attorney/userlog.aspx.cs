using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ACLGDataAaccess;
using WebFormCast.ACLG;
namespace WebFormCast.attorney
{
    public partial class userlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Attorney_User_Type"] == null)
            {
                Response.Redirect("index.aspx");
                //Else
                //If Session["Attorney_User_Type"] <> "Admin" Then
                //Response.Redirect("index.aspx")
                //End If
            }

            //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            lbUserDisp.Text = Session["Attorney_User_DisplayName"].ToString();

            if (!IsPostBack)
            {
                AcglGeneral OG = new AcglGeneral();
                lbNavigation.Text = OG.GetNavLinks("REPORTS");

                fillUsers(0);
            }
        }
        public void FillGrid()
        {
            ACLGDB Db = new ACLGDB();
            int intUserId = 0;
            intUserId =  Convert.ToInt16(ddUsers.SelectedValue);
            mydata.ConnectionString = Db.ConnectionString;
            mydata.SelectCommand = "SELECT User_log.User_id, User_log.Record_id, User_log.Action, Users.User_Name,Action_Desc,Action_Date,Employee.Tracking_No,User_Display_Name FROM (User_log INNER JOIN Users ON User_log.User_id = Users.User_ID) INNER JOIN Employee ON User_log.Record_id = Employee.employee_id  Where user_log.User_id=" + intUserId + " order by Action_Date desc";
        }
        public void fillUsers(int IntUid)
        {
            SqlDataReader Dr = default(SqlDataReader);
            ACLGDB Db = new ACLGDB();
            System.Text.StringBuilder  sbBody = new System.Text.StringBuilder();

            Dr = Db.getReader("Select * from Users order by User_Display_Name");
            ddUsers.DataSource = Dr;
            ddUsers.DataTextField = "User_Display_Name";
            ddUsers.DataValueField = "User_ID";
            ddUsers.DataBind();
            ddUsers.Items.Insert(0, new ListItem("Recent Actions", "0"));
            ddUsers.SelectedValue = IntUid.ToString();
            Dr.Close();
        }


        protected void ddUsers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if ((ddUsers.SelectedIndex >= 0))
            {
                lbUserName.Text = ddUsers.SelectedItem.Text + " Actions";
            }


            FillGrid();
        }

        protected void myGrid_PageIndexChanged(object sender, System.EventArgs e)
        {
            FillGrid();
        }

        protected void myGrid_Sorted(object sender, System.EventArgs e)
        {
            FillGrid();
        }

        protected void myGrid_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string item = myGrid.DataKeys[index].Value.ToString();
            Session["Attorney_Employee_Id"] = item.ToString();
            if (e.CommandName.Equals("select"))
            {
                Response.Redirect("case.aspx?return=log");
            }
        }
    }
}
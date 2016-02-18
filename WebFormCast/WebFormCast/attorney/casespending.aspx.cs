using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using ACLGDataAaccess;
using System.Text;
using WebFormCast.ACLG;
namespace WebFormCast.attorney
{
partial class casespending : System.Web.UI.Page
{
    public string strBody;
    public string strBody1;
    bool blnEdit = false;
    int intCid = 0;
    int intRecID = 0;
	public bool GetTable()
	{
		SqlDataReader Dr = default(SqlDataReader);
		ACLGDB Db = new ACLGDB();
		StringBuilder sbBody = new StringBuilder();
		StringBuilder sbBody1 = new StringBuilder();
		int sno = 0;
		string strName = "";
		int intClient_id = 0;
		bool blnIsFound = false;
		string strSql = "";
		strSql = "Select *,(select top 1 Comments from notes  where notes.Record_Id=Employee.Employee_id order by Case_Note_id desc) as Comments  from Employee left join Users On Employee.Updated_By_User_ID=users.User_ID Where Due_date between '" + getTodayDate() + "' and '" + cale.SelectedDate + "' order by Due_Date";
		
        Dr = Db.getReader(strSql);

		while (Dr.Read()) {
			sno = sno + 1;

			if (blnIsFound == false) {
				sbBody.AppendLine("<tr>");
				sbBody.AppendLine("<td class='td_row1'>" + sno + "</td>");
				sbBody.AppendLine("<td class='td_row1'><a href='cases.aspx?id=" + Dr["Employee_id"].ToString() + "&signature=&tracking=" + Dr["Tracking_No"].ToString() + "&select=true'>" + Dr["Tracking_No"].ToString() + "</a>&nbsp;</td>");
				sbBody.AppendLine("<td class='td_row1'>" + Dr["Last_Name"].ToString() + " " + Dr["First_Name"].ToString() + " " + Dr["MiddleName"].ToString() + "&nbsp;</td>");

				if (IsDate(Dr["Date_filed"].ToString())) {
					sbBody.AppendLine("<td class='td_row1'>" + Convert.ToDateTime(Dr["Date_filed"].ToString()) + "&nbsp;</td>");
				} else {
					sbBody.AppendLine("<td class='td_row1'>&nbsp;</td>");
				}
				sbBody.AppendLine("<td class='td_row1'>" + Dr["ReceiptNo"].ToString() + "&nbsp;</td>");
				//sbBody.AppendLine("<td class='td_row1'>" & Dr["comments"].ToString() & "</td>")
				sbBody.AppendLine("<td class='td_row1'>" + Dr["comments"].ToString() + "&nbsp;</td>");
				if (IsDate(Dr["Due_Date"].ToString())) {
					sbBody.AppendLine("<td class='td_row1'>" + Convert.ToDateTime(Dr["Due_Date"].ToString()) + "&nbsp;</td>");
				} else {
					sbBody.AppendLine("<td class='td_row1'>&nbsp;</td>");
				}
				sbBody.AppendLine("<td class='td_row1'>" + Dr["Silvergate_Inv_no"].ToString() + "&nbsp;</td>");
				sbBody.AppendLine("<td class='td_row1'>" + Dr["Type_Note"].ToString() + "&nbsp;</td>");
				//sbBody.AppendLine("<td class='td_row1'>" & Dr["Status_Note"].ToString() & "&nbsp;</td>")
				sbBody.AppendLine("<td class='td_row1'>" + Dr["User_Display_Name"].ToString() + " " + Dr["Updated_On"].ToString() + "&nbsp;</td>");
				strName = Dr["Tracking_No"].ToString();
				sbBody.AppendLine("</tr>");
			}
		}
		Dr.Close();
		strBody = sbBody.ToString();
		strBody1 = sbBody1.ToString();
        return true;
	}
    private bool IsDate(string inputDate)
    {
    bool isDate = true;
    try
    {
	    DateTime dt = DateTime.Parse(inputDate);
    }
    catch
    {
    	isDate=false;
    }
    return isDate;
    }
	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (Session["Attorney_Id"] == null) {
			Response.Redirect("index.aspx");
		}
		//lbCompanyLogoText.Text = Session["Company_Name"].ToString();
		lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();

		AcglGeneral OG = new AcglGeneral();
		lbNavigation.Text = OG.GetNavLinks("HOME");
		//cale.SelectedDate =  Month(DateAdd(DateInterval.Day, 15, Convert.ToDateTime(System.DateTime.Now))) + "/" +  Day(DateAdd(DateInterval.Day, 15, Convert.ToDateTime(System.DateTime.Now()))) + "/" + Year(DateAdd(DateInterval.Day, 15, Convert.ToDateTime(System.DateTime.Now())));
        //cale.SelectedDate =  Convert.ToDateTime(System.DateTime.Now).AddDays(15).Month.ToString() + "/" + Convert.ToDateTime(System.DateTime.Now).AddDays(15).Day.ToString() + "/" + Convert.ToDateTime(System.DateTime.Now).AddDays(15).Year.ToString();
        cale.SelectedDate = System.DateTime.Now.AddDays(15);
		GetTable();
	}

	protected void cale_SelectionChanged(object sender, System.EventArgs e)
	{
		GetTable();
	}


	public string getTodayDate()
	{
		string strdate = "";

		//strdate = Month(System.DateTime.Now()) + "/" + Day(System.DateTime.Now()) + "/" + Year(System.DateTime.Now());
        strdate = System.DateTime.Now.Month + "/" + System.DateTime.Now.Day + "/" + System.DateTime.Now.Year;
		return strdate;
	}
	public void attorney_casespending()
	{
		Load += Page_Load;
	}
}
}


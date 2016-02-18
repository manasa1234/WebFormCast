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
using WebFormCast.ACLG;


public partial class attorney_LCA : System.Web.UI.Page
{
    int intAttorney_id = 0;
    int intCompany_id = 0;
    int count = 0;
        string comp;
    string ssql;
    string track;
    string status;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            intAttorney_id = Convert.ToInt16(Session["Attorney_Id"]);
        }
        catch { }
        if (intAttorney_id <= 0)
        {
            Response.Redirect("index.aspx");
        }
        try
        {
            //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
            Session["CaseRequestPage"] = "LCA";
            count = Convert.ToInt32(Session["check"]);
            comp=Convert.ToString( Session["company"]);
            //if(comp=="All")
            //{
                track = Convert.ToString(Session["trackno"]);
                //this.Request.QueryString[2];
                status = Convert.ToString(Session["status"]);
            //}
            //else{
            //intCompany_id = Convert.ToInt32( comp );
            //}
           
                //this.Request.QueryString[1];
            lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
          //  string url = HttpContext.Current.Request.Url.AbsoluteUri;
          //  //int countqs= CountQueryStringKey(url);
          //count = Request.QueryString.AllKeys.Length;


          if (count>0)
            {
                
                getlca(comp);
             
            }
            else if (Request["txtTrackingNo"] != null)
            {
                string strTrckingno = "";
                strTrckingno = Request["txtTrackingNo"].ToString().Trim();
                txtTrackingNo.Text = strTrckingno;
                searchLCA();
            }
            else if (Request["MySearch$txtTrackingNo"] != null)
            {
                string strTrckingno = "";
                strTrckingno = Request["MySearch$txtTrackingNo"].ToString().Trim();
                txtTrackingNo.Text = strTrckingno;
                searchLCA();
            }
            else
            {
                try
                {
                    intCompany_id = getCompanyId();
                }
                catch
                { }
                if (intCompany_id > 0)
                {
                    ddCompany.SelectedValue = intCompany_id.ToString();
                    Company oC = new Company(intCompany_id);
                    Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
                    this.lbCompanyName.Text = oC.Legal_Name;
                    this.lbStatus.Text = this.ddStatus.Text;
                    this.lbTrackId.Text = "";
                    this.lbCount.Text = "";
                }
            }
        }
        catch { }

    }
    protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddCompany.SelectedValue.Equals("All"))
        {
            txtTrackingNo.Text = "";
        }
       
        
    }

    protected void ddStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!ddStatus.SelectedValue.Equals("All"))
        {
            txtTrackingNo.Text = "";
        }
    }

    protected void lcaSearch_Click(object sender, System.EventArgs e)
    {
        searchLCA();            
    }

    protected void searchLCA()
    {
        int intCompanyId = 0;
        if (txtTrackingNo.Text.Trim() != "")
        {
            ddCompany.SelectedValue = "All";
            ddStatus.SelectedValue = "All";
            setCompanyId(intCompanyId);
        }
        if (!ddCompany.SelectedValue.Equals("All"))
        {
            intCompanyId = Convert.ToInt16(ddCompany.SelectedValue);
            setCompanyId(intCompanyId);
            Company oC = new Company(intCompanyId);
            Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
        }
        getsql();
        gvLCA.Visible = true;
        gvLCA.DataBind();
        this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
        this.lbStatus.Text = this.ddStatus.Text;
        this.lbTrackId.Text = this.txtTrackingNo.Text;
        this.lbCount.Text = "Total No.of Records - " + gvLCA.Rows.Count;
    }


    public void getsql()
    {
        ssql = "SELECT ID, [RLTrackingNumber], [LCATrackNumber], [Legal_Name], [Beneficiary], [CurrentStatus],EmpStartEnd, Employee_ID FROM [LCtracking], Company, [Employee] where CompanyID = Company and LCtracking.RLTrackingNumber = Employee.Tracking_No";
        string strTrackingNo = "";
        strTrackingNo = txtTrackingNo.Text.Replace("'", "''").Trim();
        if (strTrackingNo != "")
        {
            ssql = ssql + " and RLTrackingNumber = '" + strTrackingNo + "'";
        }
        else
        {
            if (!(this.ddStatus.Text == "All"))
            {
                ssql = ssql + " and CurrentStatus like '" + this.ddStatus.Text + "%'";
            }
            if (!(this.ddCompany.Text == "All"))
            {
                ssql = ssql + " and company = '" + this.ddCompany.SelectedItem.Value + "'";
            }
        }
        //Session("ssql") = ssql
        //Response.Write(ssql)
        //Response.End()
        this.SqlDataSource2.SelectCommand = ssql + " ORDER BY RLTrackingNumber";
        
    }

    protected int getCompanyId()
    {
        int intCompany_id = 0;
        try
        {
            intCompany_id = Convert.ToInt16(Session["ACompany_Id"]);
        }
        catch { }
        if (intCompany_id <= 0)
        {
            try
            {
                intCompany_id = Convert.ToInt16(Request.Cookies["Attorney"]["ACompany_Id"]);
            }
            catch { }
        }
        return intCompany_id;
    }

    protected void setCompanyId(int intCompanyId)
    {
        Session["ACompany_Id"] = intCompanyId;
        HttpCookie myCookie = new HttpCookie("Attorney");
        myCookie["ACompany_Id"] = intCompanyId.ToString();
        myCookie.Expires = DateTime.Now.AddDays(30);
        Response.Cookies.Add(myCookie);
    }

    //protected void txtTrackingNo_TextChanged(object sender, EventArgs e)
    //{

    //}
    protected void getlca(string company)
    {
         int companyid=0;
        if(company== "All")
        {
            companyid=0;
        }
        else
        {
            companyid = Convert.ToInt32(company);
        }
        txtTrackingNo.Text = track;
        ddCompany.DataBind(); 
        ddStatus.SelectedValue = status;
        ddCompany.SelectedValue = "";
       
        //ddCompany.DataSourceID = "SqlDataSource1";
      
      
      ddCompany.SelectedValue = company;
        if (txtTrackingNo.Text.Trim() != "")
        {
            ddCompany.SelectedValue = "All";
            ddStatus.SelectedValue = "All";
            setCompanyId(companyid);
        }
        if (ddCompany.SelectedValue!="All")
        {
            companyid = Convert.ToInt16(ddCompany.SelectedValue);
            setCompanyId(companyid);
            Company oC = new Company(companyid);
            Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
        }
        getsql();
        gvLCA.Visible = true;
        gvLCA.DataBind();
        this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
        this.lbStatus.Text = this.ddStatus.Text;
        this.lbTrackId.Text = this.txtTrackingNo.Text;
        this.lbCount.Text = "Total No.of Records - " + gvLCA.Rows.Count;
        Session["check"] =0;
        Session["trackno"] ="";
        Session["status"] = "All";
        Session["company"] = "All";
        txtTrackingNo.Text = "";
     
    }
}

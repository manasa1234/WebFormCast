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


public partial class attorney_PERM : System.Web.UI.Page
{
    int intAttorney_id = 0;
    int intCompany_id = 0;
    string ssql;
    int count = 0;
    string comp;
    string track;
    string status;
    string reprts;
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
            lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
            Session["CaseRequestPage"] = "perm";
       
            count = Convert.ToInt32(Session["check"]);
            comp = Convert.ToString(Session["scompany"]);
            track = Convert.ToString(Session["strack"]);
            status = Convert.ToString(Session["sstatus"]);
            reprts = Convert.ToString(Session["sreports"]);

            if (count > 0)
            {
                Search(comp);

            }
        }
        catch
        { }
        //Response.Write(IsPostBack.ToString());
        checkReport();
        if (!IsPostBack)
        {
            AcglGeneral objG = new AcglGeneral();
            lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
            if (Request["txtTrackingNo"] != null)
            {
                string strTrckingno = "";
                strTrckingno = Request["txtTrackingNo"].ToString().Trim();
                txtTrackingNo.Text = strTrckingno;
                searchPERM();
            }
            else if (Request["MySearch$txtTrackingNo"] != null)
            {
                string strTrckingno = "";
                strTrckingno = Request["MySearch$txtTrackingNo"].ToString().Trim();
                txtTrackingNo.Text = strTrckingno;
                searchPERM();
            }
            else
            {
                try
                {
                    intCompany_id = getCompanyId();
                }
                catch { }
                if (intCompany_id > 0)
                {
                    ddCompany.SelectedValue = intCompany_id.ToString();
                    Company oC = new Company(intCompany_id);
                    Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
                    this.lbCompanyName.Text = oC.Legal_Name;
                    this.lbStatus.Text = this.ddStatus.Text;
                    this.lbTrackId.Text = "";
                    this.lbReport.Text = "";
                    this.lbCount.Text = "";
                }
            }
        }
    }

    private void Search(string comp)
    {

        int intCompanyId = 0;

        if (comp == "All")
        {
            intCompanyId = 0;
        }
        else
        {
            intCompanyId = Convert.ToInt32(comp);
        }
        ddCompany.DataBind();
        ddStatus.DataBind();
        ddReport.DataBind();
        ddStatus.SelectedValue = status;
        ddReport.SelectedValue = reprts;
        checkReport();
        ddCompany.SelectedValue = comp;
        txtTrackingNo.Text = track;
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
        gvPERM.Visible = true;
        gvPERM.DataBind();
        this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
        this.lbStatus.Text = this.ddStatus.Text;
        this.lbTrackId.Text = this.txtTrackingNo.Text;
        this.lbReport.Text = this.ddReport.SelectedItem.Value;
        this.lbCount.Text = "Total No.of Records - " + gvPERM.Rows.Count;
        count = 0;
        Session["check"] = 0;
        Session["strack"] = "";
        Session["sstatus"] = "All";
        Session["sreports"] = "0";
        Session["scompany"] = "All";
        ddCompany.SelectedValue = "All";
        ddReport.SelectedValue = "";
        ddStatus.SelectedValue = "All";
        txtTrackingNo.Text = "";
        ddStatus.Enabled = true;
        txtTrackingNo.Enabled = true;
        lblInfo.Visible = false;

        //Handle report selection related non-visible fields
        this.lstUsers.SelectedValue = "0";
        this.txtDateFrom.Text = "";
        this.txtDateTo.Text = "";
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

    protected void reset_Click(object sender, System.EventArgs e)
    {
        //Handle visible fields
        ddCompany.SelectedValue = "All";
        ddReport.SelectedValue = "";
        ddStatus.SelectedValue = "All";
        txtTrackingNo.Text = "";
        ddStatus.Enabled = true;
        txtTrackingNo.Enabled = true;
        lblInfo.Visible = false;

        //Handle report selection related non-visible fields
        this.lstUsers.SelectedValue = "0";
        this.txtPWDTrackNo.Text = "";
        this.txtDateFrom.Text = "";
        this.txtDateTo.Text = "";
        checkReport();

        gvPERM.Visible = false;
        this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
        this.lbStatus.Text = this.ddStatus.Text;
        this.lbTrackId.Text = "";
        this.lbReport.Text = "";
        this.lbCount.Text = "";
    }

    protected void permSearch_Click(object sender, System.EventArgs e)
    {
        searchPERM();
    }

    protected void searchPERM()
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
        gvPERM.Visible = true;
        gvPERM.DataBind();
        this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
        this.lbStatus.Text = this.ddStatus.Text;
        this.lbTrackId.Text = this.txtTrackingNo.Text;
        this.lbReport.Text = this.ddReport.SelectedItem.Value;
        this.lbCount.Text = "Total No.of Records - " + gvPERM.Rows.Count;
    }

    public void getsql()
    {
        ssql = "SELECT PERMTracking.ID, PERMTracking.TrackingNo, PERMTracking.PERMTrackingNo, Company.Legal_Name, PERMTracking.Beneficiary, PERMTracking.PERMStatus, CONVERT(VARCHAR(10),PERMTracking.DateLastUpdated,101) DateLastUpdated_NoTime, Employee.Employee_Id FROM [PERMTracking], Company, Employee where CompanyID = Company and PERMTracking.TrackingNo = Employee.Tracking_No";
        string strTrackingNo = "";
        strTrackingNo = txtTrackingNo.Text.Replace("'", "''").Trim();
        if (strTrackingNo != "")
        {
            ssql = ssql + " and (lower(TrackingNo) = '" + strTrackingNo.ToLower() + "'" + " or lower(Beneficiary) like '%" + strTrackingNo.ToLower() + "%')";
        }
        else
        {            
            if (!(this.ddCompany.Text == "All"))
            {
                ssql = ssql + " and company = '" + this.ddCompany.SelectedItem.Value + "'";
            }
            if (!String.IsNullOrEmpty(this.ddReport.Text))
            {
                ssql = ssql + " and PERMStatus != 'Inactivated'";
                if (this.ddReport.Text == "I-140 - All")
                {
                    ssql = ssql + " and PERMStatus = 'Certified'";
                }
                if (this.ddReport.Text == "PERM - Assigned To")
                {
                    ssql = ssql + " and PERMFilingDate IS NULL ";
                    if (this.lstUsers.SelectedItem.Value != null && Convert.ToInt32(this.lstUsers.SelectedItem.Value) > 0)
                    {
                        ssql = ssql + " and PERMAssignedTo = " + this.lstUsers.SelectedItem.Value;
                    }
                }
                if (this.ddReport.Text == "PERM - Audit")
                {
                    ssql = ssql + " and PERMStatus = 'Audit' and PERMCertDate IS NULL";
                }
                if (this.ddReport.Text == "PERM - Certified")
                {
                    ssql = ssql + " and PERMCertDate IS NOT NULL";
                }
                if (this.ddReport.Text == "PERM - Last Updated")
                {
                    ssql = ssql + " and PERMStatus in ('Pending', 'Audit') and DATEDIFF(day, PERMTracking.DateLastUpdated, GETDATE()) > 14";
                }
                if (this.ddReport.Text == "PERM - Not Filed")
                {
                    ssql = ssql + " and PERMFilingDate IS NULL";
                }
                if (this.ddReport.Text == "PERM - Pending")
                {
                    ssql = ssql + " and PERMStatus = 'Pending'";
                }
                if (this.ddReport.Text == "PERM - Due Date Range")
                {
                    if (!String.IsNullOrEmpty(txtDateFrom.Text) || !String.IsNullOrEmpty(txtDateTo.Text))
                    {
                        ssql = ssql + " and PERMDueDate IS NOT NULL";
                        if (!String.IsNullOrEmpty(txtDateFrom.Text))
                        {
                            ssql = ssql + " and PERMDueDate >= '" +  txtDateFrom.Text + "'";
                        }
                        if (!String.IsNullOrEmpty(txtDateTo.Text))
                        {
                            ssql = ssql + " and PERMDueDate <= '" + txtDateTo.Text + "'";
                        }
                    }
                }
                if (this.ddReport.Text == "PERM - Audit Due Date Range")
                {
                    if (!String.IsNullOrEmpty(txtDateFrom.Text) || !String.IsNullOrEmpty(txtDateTo.Text))
                    {
                        ssql = ssql + " and AuditDueDate IS NOT NULL";
                        if (!String.IsNullOrEmpty(txtDateFrom.Text))
                        {
                            ssql = ssql + " and AuditDueDate >= '" + txtDateFrom.Text + "'";
                        }
                        if (!String.IsNullOrEmpty(txtDateTo.Text))
                        {
                            ssql = ssql + " and AuditDueDate <= '" + txtDateTo.Text + "'";
                        }
                    }
                }
                
                if (this.ddReport.Text == "PWD - Pending")
                {
                    ssql = ssql + " and PWDStatus = 'Pending'";
                }
                if (this.ddReport.Text == "PWD - Issued")
                {
                    ssql = ssql + " and DatePWDIssued IS NOT NULL";
                }
                if (this.ddReport.Text == "PWD Track Number")
                {
                    if (!String.IsNullOrEmpty(txtPWDTrackNo.Text))
                    {
                        ssql = ssql + " and PWDTrackingNo like '" + txtPWDTrackNo.Text + "'";
                    }
                }
                if (this.ddReport.Text == "PERM Track Number")
                {
                    if (!String.IsNullOrEmpty(txtPWDTrackNo.Text))
                    {
                        ssql = ssql + " and PERMTrackingNo like '" + txtPWDTrackNo.Text + "'";
                    }
                }
                if (this.ddReport.Text == "Recruitment - Expired")
                {
                    ssql = ssql + " and DateRecruitmentStart IS NOT NULL and DateRecruitmentEnd <= GETDATE()";
                }
                if (this.ddReport.Text == "Recruitment - Not Initiated")
                {
                    ssql = ssql + " and DateRecruitmentStart IS NULL";
                }
                if (this.ddReport.Text == "Recruitment - Unexpired")
                {
                    ssql = ssql + " and DateRecruitmentStart IS NOT NULL and DateRecruitmentEnd > GETDATE()";
                }
                if (this.ddReport.Text == "Recruitment -Initiated")
                {
                    ssql = ssql + " and DateRecruitmentStart IS NOT NULL";
                }
            }
            else
            {
                if (!(this.ddStatus.Text == "All"))
                {
                    ssql = ssql + " and PERMStatus like '" + this.ddStatus.Text + "%'";
                }
            }
        }
        this.SqlDataSource2.SelectCommand = ssql + " ORDER BY TrackingNo";
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

    protected void gvPERM_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (!(e.Row.Cells[4].Text != null && e.Row.Cells[4].Text.ToLower().Equals("inactivated")))
            {
                if (e.Row.Cells[5].Text != null)
                {
                    DateTime now = DateTime.Today;
                    DateTime ludv = Convert.ToDateTime(e.Row.Cells[5].Text);
                    TimeSpan diff = now - ludv;
                    if (diff.Days > 7)
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Yellow;
                    }
                    if (diff.Days <= 7)
                    {
                        e.Row.Cells[5].BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
        }
    }

    protected void ddReport_Changed(object sender, EventArgs e)
    {
        checkReport();
        Page.SetFocus("ddReport");
    }

    protected void checkReport()
    {
        if (ddReport.SelectedValue != null && ddReport.SelectedValue.Equals(""))
        {
            ddStatus.Enabled = true;
            txtTrackingNo.Enabled = true;
            lblInfo.Visible = false;
        }
        else
        {
            ddStatus.SelectedValue = "All";
            txtTrackingNo.Text = "";
            ddStatus.Enabled = false;
            txtTrackingNo.Enabled = false;
            lblInfo.Visible = true;
        }
        //AssignedTo
        if (ddReport.SelectedValue != null && ddReport.SelectedValue.Contains("Assigned To"))
        {
            this.lbAssignedTo.Visible = true;
            this.lstUsers.Visible = true;
        }
        else
        {
            this.lbAssignedTo.Visible = false;
            this.lstUsers.Visible = false;
        }
        //lblPWDTrackNo
        if (ddReport.SelectedValue != null && (ddReport.SelectedValue.Equals("PWD Track Number") || ddReport.SelectedValue.Equals("PERM Track Number")))
        {
            if (ddReport.SelectedValue.Equals("PERM Track Number"))
            {
                this.lblPWDTrackNo.Text = "PERM Track Number";
            }
            else
            {
                this.lblPWDTrackNo.Text = "PWD Track Number";
            }
            this.lblPWDTrackNo.Visible = true;
            this.txtPWDTrackNo.Visible = true;
            this.lblPWDTrackNoInfo.Visible = true;
        }
        else
        {
            this.lblPWDTrackNo.Visible = false;
            this.txtPWDTrackNo.Visible = false;
            this.lblPWDTrackNoInfo.Visible = false;
        }
        //lblDateFrom and lblDateTo
        if (ddReport.SelectedValue != null && (ddReport.SelectedValue.Equals("PERM - Due Date Range") || ddReport.SelectedValue.Equals("PERM - Audit Due Date Range")))
        {
            this.lblDateFrom.Visible = true;
            this.txtDateFrom.Visible = true;

            this.lblDateTo.Visible = true;
            this.txtDateTo.Visible = true;
        }
        else
        {
            this.lblDateFrom.Visible = false;
            this.txtDateFrom.Visible = false;

            this.lblDateTo.Visible = false;
            this.txtDateTo.Visible = false;
        }
    }

}

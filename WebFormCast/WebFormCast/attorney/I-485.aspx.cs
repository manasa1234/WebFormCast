using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormCast.ACLG;

namespace WebFormCast.attorney
{
    public partial class I_485 : System.Web.UI.Page
    {
        int intAttorney_id = 0;
        int intCompany_id = 0;
        string scomp;
        string sdraftstatus;
        string scasestatus;
        string strack;
        int count = 0;

        string status;

        string petetion;
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
                string paramIl = HttpUtility.ParseQueryString(this.ClientQueryString).Get("cid");
                if (paramIl != null)
                {
                    intCompany_id = Convert.ToInt32(Request.QueryString[0]);
                    if (intCompany_id > 0)
                    {
                        scomp = Convert.ToString(intCompany_id);
                        searchI485(scomp);
                    }
                }
                //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
                lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
                Session["CaseRequestPage"] = "I485";
                count = Convert.ToInt32(Session["check"]);
                strack = Convert.ToString(Session["strackno"]);
                scasestatus = Convert.ToString(Session["scasestatus"]);
                sdraftstatus = Convert.ToString(Session["sdraftstatus"]);
                scomp = Convert.ToString(Session["scompany"]);

                if (count > 0)
                {
                   searchI485(scomp);
                }

            }
            catch
            { }
            //Response.Write(IsPostBack.ToString());
            //checkReport();
            if (!IsPostBack)
            {
                AcglGeneral objG = new AcglGeneral();
                lbNavigation.Text = objG.GetNavLinks("TRACK. SYS.");
                //if(txtfedexshipped.Text!=null)
                //{
                //    fedex = Convert.ToDateTime(txtfedexshipped.Text);
                //}
                //if(txtuscisdt.Text!=null)
                //{
                //    uscisdt = Convert.ToDateTime(txtuscisdt.Text);
                //}
                //if(txtstatusexpires.Text!=null)
                //{
                //    statusexp = Convert.ToDateTime(txtstatusexpires.Text);
                //}
                if (Request["txtTrackingNo"] != null)
                {
                    string strTrckingno = "";
                    strTrckingno = Request["txtTrackingNo"].ToString().Trim();
                    txtTrackingNo.Text = strTrckingno;
                    //searchH1B();
                }
                else if (Request["MySearch$txtTrackingNo"] != null)
                {
                    string strTrckingno = "";
                    strTrckingno = Request["MySearch$txtTrackingNo"].ToString().Trim();
                    txtTrackingNo.Text = strTrckingno;
                    //searchH1B();
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
                        this.lbStatus.Text = this.dddraftStatus.Text;
                        this.lbTrackId.Text = "";
                        //this.lbReport.Text = "";
                        this.lbCount.Text = "";
                    }
                }
            }
        }

        private void searchI485(string scomp)
        {
            int intCompanyId = 0;
            if (scomp == "All")
            {
                intCompanyId = 0;
            }
            else
            {
                intCompanyId = Convert.ToInt32(scomp);
            }
            ddCompany.DataBind();
            dddraftStatus.DataBind();
            ddcasestatus.DataBind();

            ddCompany.SelectedValue = scomp;
            ddcasestatus.SelectedValue = scasestatus;

            dddraftStatus.SelectedValue = sdraftstatus;
            txtTrackingNo.Text = strack;
            if (txtTrackingNo.Text.Trim() != "")
            {
                ddCompany.SelectedValue = "All";
                dddraftStatus.SelectedValue = " ";
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
            gvH1B.Visible = true;
            gvH1B.DataBind();
            this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
            this.lbStatus.Text = this.dddraftStatus.Text;
            this.lbTrackId.Text = this.txtTrackingNo.Text;
            //this.lbReport.Text = this.ddReport.SelectedItem.Value;
            this.lbCount.Text = "Total No.of Records - " + gvH1B.Rows.Count;
            Session["check"] = 0;
            Session["strackno"] = "";
            Session["scasestatus"] = "";
            Session["sdraftstatus"] = "";
            Session["scompany"] = "All";

        }

     
        protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddCompany.SelectedValue.Equals("All"))
            {
                txtTrackingNo.Text = "";
            }
        }

        protected void dddraftStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dddraftStatus.SelectedValue.Equals("All"))
            {
                txtTrackingNo.Text = "";
            }
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



     


        protected void  searchI485()
        {
            int intCompanyId = 0;
            if (txtTrackingNo.Text.Trim() != "")
            {
                ddCompany.SelectedValue = "All";
                dddraftStatus.SelectedValue = " ";
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
            gvH1B.Visible = true;
            gvH1B.DataBind();
            this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
            this.lbStatus.Text = this.dddraftStatus.Text;
            this.lbTrackId.Text = this.txtTrackingNo.Text;
            //this.lbReport.Text = this.ddReport.SelectedItem.Value;
            this.lbCount.Text = "Total No.of Records - " + gvH1B.Rows.Count;
        }

        private void getsql()
        {
            string sql;
            status = dddraftStatus.SelectedValue;
            petetion = ddcasestatus.SelectedValue;
            string strTrackingNo = txtTrackingNo.Text;

            sql = "SELECT I485tracking.ID,I485tracking.RLTrackingNumber, Company.Legal_Name, I485tracking.DraftStatus,I485tracking.CaseStatus, CONVERT(VARCHAR(10),I485tracking.Last_Updated,101) Last_Updated,  Employee.Employee_Id FROM [I485tracking], Company, Employee where CompanyID = Company and I485tracking.RLTrackingNumber = Employee.Tracking_No";
            strTrackingNo = txtTrackingNo.Text.Replace("'", "''").Trim();
            //if (strTrackingNo != "")
            //{
            //    sql = sql + " and (lower(TrackingNo) = '" + strTrackingNo.ToLower() + "'" + strTrackingNo.ToLower() + "%')";
            //}
            //else
            //{


            if (!ddCompany.SelectedValue.Equals("All"))
            {
                sql = sql + " and [Company] = " + this.ddCompany.SelectedItem.Value;

            }

            if (txtTrackingNo.Text.Length != 0)
            {

                sql = sql + "  and (lower(TrackingNo) = '" + strTrackingNo.ToLower() + "'" + strTrackingNo.ToLower() + "%')";

            }
            if (!petetion.Equals(""))
            {

                sql = sql + "  and [CaseStatus] = '" + petetion + "'";

            }
            if (!status.Equals(""))
            {


                sql = sql + "  and [DraftStatus] ='" + status + "'";


            }


            this.SqlDataSource2.SelectCommand = sql + "  ORDER BY RLTrackingNumber";
        }

        protected void I485Search_Click(object sender, EventArgs e)
        {
            searchI485();
        }

        protected void reset_Click1(object sender, EventArgs e)
        {
            ddCompany.SelectedValue = "All";
            //ddReport.SelectedValue = "";
            //dddraftStatus.SelectedValue = "All";
            ddcasestatus.SelectedValue = "";

            dddraftStatus.SelectedValue = "";
            txtTrackingNo.Text = "";
            dddraftStatus.Enabled = true;
            txtTrackingNo.Enabled = true;
            //lblInfo.Visible = false;

            //Handle report selection related non-visible fields
            //this.lstUsers.SelectedValue = "0";
            //this.txtDateFrom.Text = "";
            //this.txtDateTo.Text = "";
            //checkReport();

            gvH1B.Visible = false;
            this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
            this.lbStatus.Text = this.dddraftStatus.Text;
            this.lbTrackId.Text = "";
            //this.lbReport.Text = "";
            this.lbCount.Text = "";
        }

       






    }


}


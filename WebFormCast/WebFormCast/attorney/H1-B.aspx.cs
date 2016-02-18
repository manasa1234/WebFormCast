using ACLGDataAaccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormCast.ACLG;
namespace WebFormCast.attorney
{
    public partial class H1_B : System.Web.UI.Page
    {
        int intAttorney_id = 0;
        int intCompany_id = 0;
        string scomp;
        string sstatus;
        string sstatuspet;
        string strack;
        int count = 0;
        Nullable<DateTime> sfedex;
        Nullable<DateTime> suscis;
        Nullable<DateTime> sstatusexp;
        Nullable<DateTime> fedex;
        Nullable<DateTime> uscisdt;
        Nullable<DateTime> statusexp;
        string steam;
        string status;
        string t;
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
                if (paramIl !=null)
                {
                    intCompany_id = Convert.ToInt32(Request.QueryString[0]);
                    if (intCompany_id > 0)
                    {
                        scomp = Convert.ToString(intCompany_id);
                        searchH1B(scomp);
                    }
                }
                //lbCompanyLogoText.Text = Session["Company_Name"].ToString();
                lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
                Session["CaseRequestPage"] = "H1B";
                count = Convert.ToInt32(Session["check"]);
                strack = Convert.ToString(Session["strackno"]);
                sstatus=Convert.ToString(Session["sstatus"]);
                sstatuspet = Convert.ToString(Session["sstatuspetetion"]);
                scomp=Convert.ToString(Session["scompany"]);
                if (Convert.ToString(Session["sfedexdt"]) == "")
                {
                    sfedex = null;
                }
                else
                {
                    sfedex = Convert.ToDateTime(Session["sfedexdt"]);
                }
                if (Convert.ToString(Session["suscisdt"]) == "")
                {
                    suscis = null;
                }
                else
                {
                    suscis = Convert.ToDateTime(Session["suscisdt"]);
                }
                if (Convert.ToString(Session["sstausexpdt"]) == "")
                {
                    sstatusexp = null;
                }
                else
                {
                    sstatusexp = Convert.ToDateTime(Session["sstausexpdt"]);
                }
                steam = Convert.ToString(Session["sTeams"]);
                if(count>0)
                {
                    searchH1B(scomp);
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
                        this.lbStatus.Text = this.ddStatus.Text;
                        this.lbTrackId.Text = "";
                        //this.lbReport.Text = "";
                        this.lbCount.Text = "";
                    }
                }
            }
        }

        private void searchH1B(string scomp)
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
            ddStatus.DataBind();
            ddstatuespetetion.DataBind();
            ddteams.DataBind();
            ddCompany.SelectedValue = scomp;
            ddstatuespetetion.SelectedValue = sstatuspet;
            ddteams.SelectedValue = steam;
            ddStatus.SelectedValue = sstatus;
            txtTrackingNo.Text = strack;
            if (sfedex == null)
            {
                txtfedexshipped.Text = "";
            }
            else
            {
                txtfedexshipped.Text = Convert.ToString(sfedex);
            } if (sstatusexp == null)
            {
                txtstatusexpires.Text = "";
            }
            else
            {
                txtstatusexpires.Text = Convert.ToString(sstatusexp);
            }
            if (suscis == null)
            {
                txtuscisdt.Text = "";
            }
            else
            {
                txtuscisdt.Text = Convert.ToString(suscis);
            }
            if (txtTrackingNo.Text.Trim() != "")
            {
                ddCompany.SelectedValue = "All";
                ddStatus.SelectedValue = " ";
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
            this.lbStatus.Text = this.ddStatus.Text;
            this.lbTrackId.Text = this.txtTrackingNo.Text;
            //this.lbReport.Text = this.ddReport.SelectedItem.Value;
            this.lbCount.Text = "Total No.of Records - " + gvH1B.Rows.Count;
            count = 0;
            Session["check"] = 0;
            Session["strackno"] = "";
            Session["sstatus"] = "";
            Session["sstatuspetetion"] ="";
            Session["scompany"] = "All";
            Session["sfedexdt"] = "";
            Session["suscisdt"] = "";
            Session["sstausexpdt"] = "";
            Session["sTeams"] = "";
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
            //ddReport.SelectedValue = "";
            //ddStatus.SelectedValue = "All";
            ddstatuespetetion.SelectedValue="";
            ddteams.SelectedValue = "";
            ddStatus.SelectedValue = "";
            txtTrackingNo.Text = "";
            ddStatus.Enabled = true;
            txtTrackingNo.Enabled = true;
            //lblInfo.Visible = false;

            //Handle report selection related non-visible fields
            //this.lstUsers.SelectedValue = "0";
            //this.txtDateFrom.Text = "";
            //this.txtDateTo.Text = "";
            //checkReport();

            gvH1B.Visible = false;
            this.lbCompanyName.Text = this.ddCompany.SelectedItem.Text;
            this.lbStatus.Text = this.ddStatus.Text;
            this.lbTrackId.Text = "";
            //this.lbReport.Text = "";
            this.lbCount.Text = "";
        }

        //protected void H1B()
        //{

        //}

        

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

      

        protected void H1BSearch_Click(object sender, EventArgs e)
        {
            searchH1B();
            //teamreports();
            //petetionstatusreports();
            //queryreports();
            
        }



        protected void searchH1B()
        {
            int intCompanyId = 0;
            if (txtTrackingNo.Text.Trim() != "")
            {
                ddCompany.SelectedValue = "All";
                ddStatus.SelectedValue = " ";
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
            this.lbStatus.Text = this.ddStatus.Text;
            this.lbTrackId.Text = this.txtTrackingNo.Text;
            //this.lbReport.Text = this.ddReport.SelectedItem.Value;
            this.lbCount.Text = "Total No.of Records - " + gvH1B.Rows.Count;
        }

        private void getsql()
        {
            string sql;
            status = ddStatus.SelectedValue;
            petetion = ddstatuespetetion.SelectedValue;
            string strTrackingNo = txtTrackingNo.Text;
            if (txtuscisdt.Text == "")
            {
                uscisdt = null;
            }
            else
            {
                uscisdt = Convert.ToDateTime(txtuscisdt.Text);
            }
            if (txtfedexshipped.Text == "")
            {
                fedex = null;
            }
            else
            {
                fedex = Convert.ToDateTime(txtfedexshipped.Text);
            }
            if (txtstatusexpires.Text == "")
            {
                statusexp = null;
            }
            else
            {
                statusexp = Convert.ToDateTime(txtstatusexpires.Text);
            }
            t = ddteams.SelectedValue;
            sql = "SELECT NIVtracking.ID,NIVtracking.RLTrackingNumber, Company.Legal_Name, NIVtracking.DraftStatus, CONVERT(VARCHAR(10),NIVtracking.Last_Updated,101) Last_Updated, NIVtracking.Premium_Processing, Employee.Employee_Id FROM [NIVtracking], Company, Employee where CompanyID = Company and NIVtracking.RLTrackingNumber = Employee.Tracking_No";
            strTrackingNo = txtTrackingNo.Text.Replace("'", "''").Trim();
            //if (strTrackingNo != "")
            //{
            //    sql = sql + " and (lower(TrackingNo) = '" + strTrackingNo.ToLower() + "'" + strTrackingNo.ToLower() + "%')";
            //}
            //else
            //{


            if (!ddCompany.SelectedValue.Equals("All"))
            {
                sql = sql + " and [Company] = " + this.ddCompany.SelectedItem.Value ;

            }

            if (txtTrackingNo.Text.Length != 0)
            {

                sql = sql + "  and (lower(TrackingNo) = '" + strTrackingNo.ToLower() + "'" + strTrackingNo.ToLower() + "%')";

            }
            if (!petetion.Equals(""))
            {

                sql = sql + "  and [PetetionStatus] = '" + petetion + "'";

            }
            if (!status.Equals(""))
            {


                sql = sql + "  and [DraftStatus] ='" + status + "'";


            }
            if (!t.Equals(""))
            {

                sql = sql + "  and [Team] ='" + t + "'";


            }
            if (uscisdt != null)
            {
               txtuscisdt.Text = String.Format("{0:MM/dd/yyyy}", uscisdt);
               sql = sql + "  and [RFE_Uscis_DueDate] = '" + txtuscisdt.Text+"'";


            }
            if (fedex != null)
            {
                txtfedexshipped.Text = String.Format("{0:MM/dd/yyyy}", fedex);
                sql = sql + "  and [Fedex_DateShipped] = '" + txtfedexshipped.Text+"'";


            }
            if (statusexp != null)
            {
                txtstatusexpires.Text = String.Format("{0:MM/dd/yyyy}", statusexp);
                sql = sql + "  and [Status_Expires] = '" + txtstatusexpires.Text+"'";

            }
            this.SqlDataSource2.SelectCommand = sql + "  ORDER BY RLTrackingNumber";
        }

   
       


      
        
       

    }

}


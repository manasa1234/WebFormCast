using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using WebFormCast.ACLG;
using System.Configuration;
using System.Data;
namespace WebFormCast.attorney
{
    public partial class templateheader : System.Web.UI.Page
    {
        int intAttorney_id = 0;
        int intCompany_id = 0;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbmsg.Text = "&nbsp;";
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
            }
            catch
            { }
            if (!IsPostBack)
            {
                clsAttorney OA = new clsAttorney(intAttorney_id);
                OA.bindCompanyCombo(ddCompany, 0);

                AcglGeneral OG = new AcglGeneral();
                //OG.bindTypeCombo(ddVisaType, 0);
                AcglGeneral objG = new AcglGeneral();
                lbNavigation.Text = objG.GetNavLinks("TEMPLATE");

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddCompany.SelectedIndex > 0)
                intCompany_id = Convert.ToInt16(ddCompany.SelectedValue);



            string strBody = "";
            string strHeader = "";
            string strFooter = "";
            int strHH = 0;
            int strFH = 0;

            //strBody = strBody.Replace("'", "''");

            strHeader = txtTemplateHeader.Text;
            strFooter = txtTemplateFooter.Text;
            if (txtHHeight.Text == "")
            {
                strHH = 0;

            }
            else
            {
                strHH = Convert.ToInt32(txtHHeight.Text);
            }
            if (txtFHeight.Text == "")
            {
                strFH = 0;
            }
            else
            {
                strFH = Convert.ToInt32(txtFHeight.Text);
            }
            clsTemplate OT = new clsTemplate();

            if (intCompany_id > 0)
            {
                OT.Update_TemplateHeader(intAttorney_id, intCompany_id, strHeader, strFooter, strHH, strFH);
                lbmsg.Text = "Template has been saved!";
            }


        }

        protected void getTemplateBody()
        {

            if (ddCompany.SelectedIndex > 0)
            {
                intCompany_id = Convert.ToInt16(ddCompany.SelectedValue);
                clsTemplate OT = new clsTemplate();
                OT.Get_TemplateHeader(intAttorney_id, intCompany_id);
                txtTemplateHeader.Text = OT.Header;
                //txtTemplateHeader.Height = 20;
                txtTemplateFooter.Text = OT.Footer;
                txtHHeight.Text = OT.HHeight.ToString();
                txtFHeight.Text = OT.FHeight.ToString();
                count = OT.TemplateHeadercount(intAttorney_id, intCompany_id);
            }

        }

        protected void ddCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            getTemplateBody();
            if (count > 0)
            {
                btnSave.Text = "Update";
                btnDelete.Visible = true;
                btnDelete.Enabled = true;

            }
            else
            {
                btnSave.Text = "Save";
                btnDelete.Visible = false;
                btnDelete.Enabled = false;
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (ddCompany.SelectedIndex > 0)
            {
                intCompany_id = Convert.ToInt16(ddCompany.SelectedValue);

                clsTemplate OT = new clsTemplate();
                bool p = OT.DeleteTemplateHeader(intAttorney_id, intCompany_id);

                if (p)
                {
                    txtTemplateHeader.Text = "";
                    txtTemplateFooter.Text = "";
                    lbmsg.Text = "Template was deleted";
                }
                else
                {
                    lbmsg.Text = "Template was not deleted";
                }

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtTemplateHeader.Text = "";
            txtTemplateFooter.Text = "";
            txtHHeight.Text = "";
            txtFHeight.Text = "";
        }

    }

}
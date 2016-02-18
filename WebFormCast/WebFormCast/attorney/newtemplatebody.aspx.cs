using System;
using System.Collections.Generic;
using System.Linq;
using ACLGDataAaccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using WebFormCast.ACLG;

namespace WebFormCast.attorney
{
    public partial class newtemplatebody : System.Web.UI.Page
    {
        int intAttorney_id = 0;
        //int intCompany_id = 0;
        int intTemplate_id = 0;
        int intVisaType_id = 0;
        string s = "";
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
                //OA.bindCompanyCombo(ddCompany, 0);

                //AcglGeneral OG = new AcglGeneral();
                //OG.bindTypeCombo(ddVisaType, 0);
                AcglGeneral objG = new AcglGeneral();
                lbNavigation.Text = objG.GetNavLinks("TEMPLATE");
                gettemplatename();
                Getvisatype_values();

            }
            //gettemplatename();
            //Getvisatype_values();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            //  s = txtother.Text;
            //if (s=="")
            //{}
            //else
            //{
            //    txtother__Leave(this, e); 
            //}
            string strBody = "";
            //string strHeader = "";
            //string strFooter = "";
            //int strHH = 0;
            //int strFH = 0;
            strBody = txtTemplateBody.Text;
            if (ddTemplates.SelectedIndex > 0 && ddVisaType.SelectedIndex > 0)
            {

                if (ddTemplates.SelectedItem.Text == "Other")
                {
                    gettemplateid();
                }
                else
                {
                    intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
                }

                //intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
                intVisaType_id = Convert.ToInt16(ddVisaType.SelectedValue);
                strBody = txtTemplateBody.Text;
                clsTemplate OT = new clsTemplate();
                OT.insert_TemplateBody(intTemplate_id, intVisaType_id, strBody);
                lbmsg.Text = "Template has been saved!";
            }

            //strBody = strBody.Replace("'", "''");

            //strHeader = txtTemplateHeader.Text;
            //strFooter = txtTemplateFooter.Text;
            //strHH =  Convert.ToInt32(txtHHeight.Text);
            //strFH  =Convert.ToInt32(txtFHeight.Text);

            //clsTemplate OT = new clsTemplate();

            //if (intCompany_id > 0 && intTemplate_id > 0 && intVisaType_id>0)
            //{
            //    OT.Update_Template(intAttorney_id, intCompany_id,intTemplate_id,intVisaType_id,strBody,strHeader,strFooter,strHH,strFH);
            //    lbmsg.Text = "Template has been saved!";
            //}


        }

        private void gettemplateid()
        {
            //s=txtother.Text;

            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            string query = "select Templateid from AttorneyTemplate_Name where Template_Name='" + txtother.Text + "'";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = con;
            SqlDataReader usernameRdr = null;


            try
            {
                con.Open();
                usernameRdr = cmd.ExecuteReader();
                while (usernameRdr.Read())
                {

                    intTemplate_id = Convert.ToInt32(usernameRdr["Templateid"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
                con.Dispose();

            }

        }


        private int InsertTemplateBody(int intTemplate_id, string strBody, int intVisaType_id)
        {
            strBody = HttpContext.Current.Server.HtmlEncode(strBody);
            //strHeader = HttpContext.Current.Server.HtmlEncode(strHeader);
            //strFooter = HttpContext.Current.Server.HtmlEncode(strFooter); 
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            string queryString = "INSERT INTO [dbo].[AttorneyTemplate_Body] ([Templateid] ,[Template_Body],[VisaTypeid],[CreatedDate]) VALUES (@Templateid,@Templatebody,@visatypeid)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = queryString;
            cmd.Connection = con;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = intTemplate_id;
            cmd.Parameters.Add("@Templatebody", SqlDbType.Text).Value = strBody;
            cmd.Parameters.Add("@visatypeid", SqlDbType.Int).Value = intVisaType_id;
            int rowsAffected = 0;
            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                // error here
            }
            finally
            {
                con.Close();
            }
            return rowsAffected;
        }

        protected void ddVisaType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Getvisatype_values();
        }

        private void Getvisatype_values()
        {
            ddVisaType.Items.Add(new ListItem("--Select Visa Type--", ""));
            ddVisaType.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            String strQuery = "select Visa_Type_Id,Visa_Type_Name from Visa_Type ";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddVisaType.DataSource = cmd.ExecuteReader();
                ddVisaType.DataTextField = "Visa_Type_Name";
                ddVisaType.DataValueField = "Visa_Type_Id";
                ddVisaType.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
                con.Dispose();

            }

        }

        protected void ddTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gettemplatename();

            if (ddTemplates.SelectedItem.Text == "Other")
            {
                txtother.Visible = true;
                s = txtother.Text;
                //if (s == "")
                //{ }
                //else
                //{ }
                //if(txtother.TextChanged==true)
                //     { }
                //     else
                //getothervalues();
            }
            //int tval = Convert.ToInt32(ddTemplates.SelectedItem.Value);
            //if (tval == 1)
            //{
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

        private int inserttemplatename(string tname, int tvalue)
        {

            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            string queryString = "insert into [dbo].[AttorneyTemplate_Name]([Templateid],[Template_Name]) VALUES (@Templateid,@Templatename)";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = queryString;
            cmd.Connection = con;
            cmd.Parameters.Add("@Templateid", SqlDbType.Int).Value = tvalue;
            cmd.Parameters.Add("@Templatename", SqlDbType.NVarChar, 100).Value = tname;
            int rowsAffected = 0;
            try
            {
                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                //ddTemplates.SelectedValue = Convert.ToString(tvalue);
            }
            catch (SqlException)
            {
                // error here
            }
            finally
            {
                con.Close();
            }
            return rowsAffected;

        }

        private void gettemplatename()
        {


            ddTemplates.Items.Add(new ListItem("--Select Template Type--", ""));
            ddTemplates.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            String strQuery = "select Templateid,Template_Name from AttorneyTemplate_Name ";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddTemplates.DataSource = cmd.ExecuteReader();
                ddTemplates.DataTextField = "Template_Name";
                ddTemplates.DataValueField = "Templateid";
                ddTemplates.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                con.Close();
                con.Dispose();

            }

        }
        protected void getTemplateBody()
        {
            txtTemplateBody.Text = "";
            if (ddTemplates.SelectedIndex > 0 && ddVisaType.SelectedIndex > 0)
            {
                intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
                intVisaType_id = Convert.ToInt16(ddVisaType.SelectedValue);
                clsTemplate OT = new clsTemplate();
                txtTemplateBody.Text = OT.TemplateBody(intVisaType_id, intTemplate_id);
                count = OT.TemplateBodycount(intVisaType_id, intTemplate_id);
            }

        }




        private void getothervalues()
        {

            int c = 0;
            s = txtother.Text;
            if (s == "")
            { }
            else
            {
                ACLGDB DB = new ACLGDB();
                string connectionString = DB.ConnectionString;
                string query = "select count (Templateid) from AttorneyTemplate_Name";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    c = (Int32)cmd.ExecuteScalar();
                    if (c > 0)
                    {
                        inserttemplatename(s, c + 1);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                    con.Close();
                    con.Dispose();

                }
            }

        }



        protected void btnCancel_Click(object sender, EventArgs e)
        {

            ddTemplates.SelectedValue = "";
            ddVisaType.SelectedValue = "";

        }

        protected void txtother__Leave(object sender, EventArgs e)
        {

            getothervalues();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (ddTemplates.SelectedIndex > 0 && ddVisaType.SelectedIndex > 0)
            {
                intTemplate_id = Convert.ToInt16(ddTemplates.SelectedValue);
                intVisaType_id = Convert.ToInt16(ddVisaType.SelectedValue);
                clsTemplate OT = new clsTemplate();
                bool p = OT.DeleteTemplateBody(intVisaType_id, intTemplate_id);

                if (p)
                {
                    txtTemplateBody.Text = "";
                    lbmsg.Text = "Template was deleted";
                }
                else
                {
                    lbmsg.Text = "Template was not deleted";
                }

            }

        }
    }
}


  
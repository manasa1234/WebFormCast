using ACLGDataAaccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormCast.ACLG;
namespace WebFormCast.attorney
{
    public partial class case1 : System.Web.UI.Page
    {
        public string strRow1 = "";
        public string strRow2 = "";
        public string HiddenClassName { get; private set; }
        int userid = 0;
        string other = "";
        string strActioncs = "";
        int intRecId = 0;
        int intEmployeeId = 0;
        string strcasetype = "";
        string strcasevalues = "";
        string strinvno = "";

        string strreceiptno = "";
        string strSignature = "";
        int category = 0;
        int visaid = 0;
        int intstat = 0;
        Nullable<DateTime> dtduedate;
        //DateTime dtduedate=DateTime.Now;
        Nullable<DateTime> dtdatefiled;
        //DateTime dtdatefiled=DateTime.Now;
        int strstatus = 0;
        int intClient_id = 0;
        int intAssign_id = 0;
        bool blnEdit = true;
        public string strComments = "";
        public string strNewTrackingNo = "";
        int intUserId;
        int intAttorney_id = 0;
        int intTypeId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Attorney_Id"] == null)
            {
                Response.Redirect("index.aspx");
            }
            lbUserName.Text = Session["Attorney_User_DisplayName"].ToString();
            intAttorney_id = Convert.ToInt32(Session["Attorney_Id"]);
            intUserId = Convert.ToInt32(Session["Attorney_User_Id"]);
            panComments.Visible = true;
            if (Session["Attorney_User_Type"] == "Admin")
            {
                ddUsers.Visible = true;
                //rowAssign.Visible = True
            }
            else
            {
                ddUsers.Visible = true;
                //rowAssign.Visible = False
            }

            if (Request["Attorney_Employee_Id"] == null)
            {
                if (Session["Attorney_Employee_Id"] != null)
                {
                    intEmployeeId = Convert.ToInt32(Session["Attorney_Employee_Id"]);
                }
            }
            else if (Session["CaseRequestPage"].ToString() != "cases")
            {
                intEmployeeId = Convert.ToInt32(Request["Attorney_Employee_Id"]);
            }
            else
            {
                if (Session["Attorney_Employee_Id"] != null)
                {
                    intEmployeeId = Convert.ToInt32(Session["Attorney_Employee_Id"]);
                }
            }
            Session["CaseRequestPage"] = "cases";
            /**new code added for generic classes **/
            try
            {
                strSignature = Request["signature"] == null ? "" : Request["signature"].ToString();
            }
            catch { }
            try
            {

                strActioncs = Request["action"] == null ? "" : Request["action"].ToString();
                //strSignature = Request["signature"] == null ? "" : Request["signature"].ToString();
            }
            catch { }

            try
            {
                intRecId = Request["order"] == null ? 0 : Convert.ToInt16(Request["order"]);
            }
            catch { }

            if (!IsPostBack)
            {


                commenttext();
                if (strActioncs == "delete")
                {
                    AcglEmployee OE = new AcglEmployee();
                    OE.DeleteCaseType(intEmployeeId, strSignature);
                    Response.Redirect("case.aspx#Type");

                }

                Initialize();
                populate();
                assignvalues();
                //displayCaseList();

            }
        }
        public void Initialize()
        {

            AcglGeneral objG = new AcglGeneral();
            //int visaid = Convert.ToInt32(ddCasevalues.SelectedValue);
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strSignature);
           
            lbNavigation.Text = objG.GetNavLinks("CASE");

            if (Request["action"] != "new")
            {

                blnEdit = true;
                FillFrom();
                dlClient.Enabled = false;
            }

            fillCombo(intClient_id);
            FillTypes(intTypeId);
            if (ddUsers.Visible)
            {
                fillUsers(intAssign_id);
            }

            if (intUserId == intAssign_id)
            {
                UpdateAssign_Accessed(intUserId, intEmployeeId);
            }
            if (Request["action"] != null)
            {
                if (Request["action"].ToString() == "new")
                {
                    if (Convert.ToInt32(dlClient.SelectedValue) > 0)
                    {

                        intClient_id = Convert.ToInt32(dlClient.SelectedValue);
                        Company OC = new Company(intClient_id);
                        txtTrackingId.Text = OC.NextTrackingNo;
                        txtTrackingNo.Text = txtTrackingId.Text;
                    }
                }
            }
            clsAttorney OA = new clsAttorney(intAttorney_id);
            OA.bindCompanyCombo(ddEmployer, 0);
            if (intClient_id > 0)
            {
                ddEmployer.SelectedValue = intClient_id.ToString();
                Company oC = new Company(intClient_id);
                Session["Attorney_CompanyName"] = oC.Legal_Name.ToString();
                lbCompanyName1.Text = oC.Legal_Name.ToString();
                lbClientName.Text = oC.Legal_Name.ToString();
            }

            if (Request["action"] != null && Request["action"].ToString() == "new")
            {
                hide.Visible = false;
                HiddenClassName = "display:none";
                btncaseButton.Visible = false;
                blnEdit = false;
                panComments.Visible = false;
            }
            else
            {
                hide.Visible = true;
                panComments.Visible = true;
                strComments = getComments(intEmployeeId);
                blnEdit = true;
                if (Request["action"] != null && Request["action"].ToString() == "editScroll")
                {
                    panComments.Focus();
                    //}
                }
                displayCaseList();

            }
        }

        private void UpdateAssign_Accessed(int intAID, int intR)
        {
            string strSql = "";
            ACLGDB DB = new ACLGDB();
            strSql = "Update Employee set Assigned_User_Accessed='YES' where Employee_id=" + intEmployeeId + " and Assign_to=" + intAID;
            DB.ExeQuery(strSql);
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
                isDate = false;
            }
            return isDate;
        }
        public void FillFrom()
        {
            AcglEmployee oE = new AcglEmployee(intEmployeeId);
            string strSql = "";
            string strsql1 = "";
            int intUid = 0;
            txtTrackingId.Text = oE.TrackingNo;
            Session["Attorney_Employee_TrackingNo"] = oE.TrackingNo;
            txtLastName.Text = oE.LastName;
            hfLname.Value = oE.LastName;
            txtFirstName.Text = oE.FirstName;
            hfFName.Value = oE.FirstName;
            txtMiddleName.Text = oE.MiddleName;
            hfMname.Value = oE.MiddleName;
            txtEmail.Text = oE.Email;
            if ((!string.IsNullOrEmpty(oE.Email.Trim())))
            {
                txtEmail.Enabled = false;
            }
            hfEmail.Value = oE.Email;
            ddCasetype.SelectedValue = oE.Visa_Type_id.ToString();
            ddCasevalues.SelectedValue = oE.Visa_Type_id.ToString();
            txtDueDate.Text = oE.Date_Filed;
            txtDateFiled.Text = oE.Date_Filed;
            ddStatus.SelectedValue = oE.Status.ToString();
            txtReceiptno.Text = oE.ReceiptNo.ToString();


            //if (oE.ReceiptNo.ToString() != "-")
            //{
            //    if (oE.ReceiptNo.ToString().Replace("-","") != "")
            //    {
            //        txtReceiptchar.Text = oE.ReceiptNo.ToString().Substring(0, 3);
            //        txtReceiptnum.Text = oE.ReceiptNo.Substring(4, 10);
            //    }
            //}
            //hfReceip.Value = oE.ReceiptNo;
            //txtType.Text = oE.Type_Note;
            //hfType.Value = oE.Visa_Type_id.ToString();
            //TxtInvno.Text = oE.Silvergate_Inv_No;
            //hfInvno.Value = oE.Silvergate_Inv_No;

            //if (IsDate(oE.Due_Date))
            //{
            //    txtDueDate.Text = Convert.ToDateTime(oE.Due_Date).ToString();
            //}

            //hDueDate.Value = oE.Due_Date;

            intClient_id = oE.Company_id;

            if (oE.Assign_to <= 0)
            {
                intAssign_id = 0;

            }
            else
            {
                intAssign_id = oE.Assign_to;

            }

            //ddStatus.SelectedValue = oE.Status.ToString();
            //hfStatus.Value = oE.Status.ToString();

            if ((oE.Updated_By_User_ID > 0))
            {
                AttorneyUser OU = new AttorneyUser(oE.Updated_By_User_ID);
                lbUpdatdBy.Text = OU.User_Display_Name + " on " + oE.Updated_On;
            }


        }
        private string getComments(int intRID)
        {
            string strC = "";

            SqlDataReader Dr = default(SqlDataReader);
            ACLGDB DB = new ACLGDB();
            string strSql = "";

            strSql = "Select *,Convert(varchar(12),Commented_Date,101) as Commented_Date1 from Notes left Join Users On Notes.Updated_By_User_ID=Users.User_id  where Record_Id=" + intRID + " order by Commented_Date desc";
            Dr = DB.getReader(strSql);

            while (Dr.Read())
            {
                if (IsDate(Dr["Commented_Date1"].ToString()))
                {
                    strC = strC + "<tr><td align='left'>" + String.Format("{0:MM/dd/yyy}", Convert.ToDateTime(Dr["Commented_Date1"])) + "-" + Dr["User_Display_Name"].ToString() + "</td><td align='left'>" + Dr["Comments"].ToString() + "</td></tr>";
                }
                else
                {
                    strC = strC + "<tr><td align='left'>--" + Dr["User_Display_Name"].ToString() + "</td><td align='left'>" + Dr["Comments"].ToString() + "</td></tr>";
                }
            }
            Dr.Close();
            return strC;



        }
        public void FillTypes(int intT)
        {
            //clsAttorney objCompany = new clsAttorney();
            //objCompany.bindTypeCombo(ddType, intT);
        }
        public void fillCombo(int IntCid)
        {
            clsAttorney OA = new clsAttorney(intAttorney_id);
            OA.bindCompanyCombo(dlClient, IntCid);
        }
        public void fillUsers(int IntUid)
        {
            SqlDataReader Dr;
            ACLGDB DB = new ACLGDB();
            StringBuilder sbBody = new StringBuilder();
            Dr = DB.getReader("Select * from Users order by User_Display_Name");
            ddUsers.DataSource = Dr;
            ddUsers.DataTextField = "User_Display_Name";
            ddUsers.DataValueField = "User_ID";
            ddUsers.DataBind();
            ddUsers.Items.Insert(0, new ListItem("Select User", "0"));
            ddUsers.SelectedValue = IntUid.ToString();
            Dr.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Request["Attorney_Employee_Id"] == null)
            {
                if (Session["Attorney_Employee_Id"] != null)
                {
                    intEmployeeId = Convert.ToInt32(Session["Attorney_Employee_Id"]);
                }
            }
            else if (Session["CaseRequestPage"].ToString() != "cases")
            {
                intEmployeeId = Convert.ToInt32(Request["Attorney_Employee_Id"]);
            }
            else
            {
                if (Session["Attorney_Employee_Id"] != null)
                {
                    intEmployeeId = Convert.ToInt32(Session["Attorney_Employee_Id"]);
                }
            }
            //fillvalues();
            strcasetype = ddCasetype.SelectedValue.ToString();
            strcasevalues = ddCasevalues.SelectedValue.ToString();
            if (strcasetype == "")
            {
                category = 0;
            }
            else
            {
                category = Convert.ToInt32(strcasetype);
            }
            if (category == 0)
            {
                visaid = 0;
            }
            else
            {
                visaid = Convert.ToInt32(strcasevalues);
            }
            strinvno = txtInvno.Text;
            if (txtDueDate.Text == "")
            {
                dtduedate = null;
            }
            else
            {
                dtduedate = Convert.ToDateTime(txtDueDate.Text);
            }

            strstatus = Convert.ToInt32(ddStatus.SelectedValue);
            if (txtDateFiled.Text == "")
            {
                dtdatefiled = null;
            }
            else
            {
                dtdatefiled = Convert.ToDateTime(txtDateFiled.Text);
            }
            strreceiptno = txtReceiptno.Text.ToString();
            string users = ddUsers.SelectedValue.ToString();


            if (ddUsers.SelectedValue == "")
            {
                userid = 0;
            }
            else
            {
                userid = Convert.ToInt32(users);
            }
            other = txtCaseother.Text;
            string strActionDesc = "";
            string strSql = "";
            ACLGDB DB = new ACLGDB();
            bool blnChanged = false;
            string strAction = "";
            AcglEmployee OE = new AcglEmployee();


            //if (IsDate(CleanText(txtDateFiled.Text)))
            //{
            //    strDateFiled = "'" + CleanText(txtDateFiled.Text) + "'";
            //}
            //else
            //{
            //    strDateFiled = "null";
            //}

            //if (IsDate(CleanText(txtDueDate.Text)))
            //{
            //    strDueDate = "'" + CleanText(txtDueDate.Text) + "'";
            //}
            //else
            //{
            //    strDueDate = "null";
            //}
            strActionDesc = "<table>";

            if (hfLname.Value != txtLastName.Text | hfFName.Value != txtFirstName.Text | hfMname.Value != txtMiddleName.Text)
            {
                blnChanged = true;
                strAction = "Name";
            }



            if (hfEmail.Value != txtEmail.Text)
            {
                blnChanged = true;
                strAction += ", Email Id";
            }

            if (hfPhone.Value != txtPhone.Text)
            {
                blnChanged = true;
                strAction += ", Phone No";
            }



            //if (hfDateFiled.Value != txtDateFiled.Text)
            //{
            //    blnChanged = true;
            //    strAction += ", DateFiled";
            //}
            //if (hfReceip.Value != CleanText(txtReceipt.Text + "-" + txtReceipt1.Text))
            //{
            //    blnChanged = true;
            //    strAction += ", ReceiptNo";
            //}
            //if (hfType.Value != txtType.Text)
            //{
            //    blnChanged = true;
            //    strAction += ", Type";
            //}
            //if (hfInvno.Value != TxtInvno.Text)
            //{
            //    blnChanged = true;
            //    strAction += ", InvNo";
            //}
            //if (hDueDate.Value != txtDueDate.Text)
            //{
            //    blnChanged = true;
            //    strAction += ", DueDate";
            //}
            //if (hfStatus.Value != ddStatus.SelectedValue)
            //{
            //    blnChanged = true;
            //    strAction += ", Status ";
            //}
            strActionDesc += "<tr><td>Old values:</td><td>" + hfEmail.Value + " " + hfLname.Value + " " + hfFName.Value + " " + hfMname.Value + "" + hfPhone.Value + "</td>";//<td>" + hfDateFiled.Value + "</td><td>" + hfReceip.Value + "</td><td>" + hfType.Value + "</td><td>" + hfInvno.Value + "</td><td>" + hDueDate.Value + "</td><td>" + hfStatus.Value + "</td></tr>";
            strActionDesc += "<tr><td>New values:</td><td>" + txtEmail.Text + " " + txtLastName.Text + " " + txtFirstName.Text + " " + txtMiddleName.Text + "" + txtPhone.Text + "</td>" + "<td>" + txtDateFiled.Text + "</td><td>" + txtReceiptno.Text + "</td><td>" + ddCasetype.SelectedValue.ToString() + "</td><td>" + ddCasevalues.SelectedValue.ToString() + "</td><td>" + txtInvno.Text + "</td><td>" + txtDueDate.Text + "</td><td>" + ddStatus.SelectedValue + "</td></tr>";
            strActionDesc += "</table>";
            bool flag = false;
            if (Request["action"] == "new")
            {
                string strAccessKey = OE.GetAccessKey();
                //strSql = "Insert into Employee(Tracking_No,Email_Address,Access_Key,Company_id,Last_Name,First_Name,MiddleName,Date_Filed,ReceiptNo,Type_Note,Visa_Type_id,Silvergate_Inv_No,Due_Date,Updated_By_User_ID,Updated_On,status,JobTitle_id) values('" + CleanText(txtTrackingId.Text) + "','" + CleanText(txtEmail.Text) + "','" + strAccessKey + "'," + dlClient.SelectedValue + ",'" + CleanText(txtLastName.Text) + "','" + CleanText(txtFirstName.Text) + "','" + CleanText(txtMiddleName.Text) + "'," + strDateFiled + ",'" + CleanText(txtReceipt.Text + "-" + txtReceipt1.Text) + "','" + CleanText(txtType.Text) + "'," + ddType.SelectedValue + ",'" + CleanText(TxtInvno.Text) + "'," + strDueDate + "," + Session["Attorney_User_Id"].ToString() + ",getDate()," + ddStatus.SelectedValue + ",0)";
                strSql = "Insert into Employee(Tracking_No,Email_Address,Access_Key,Company_id,Last_Name,First_Name,MiddleName,Signature) values('" + CleanText(txtTrackingId.Text) + "','" + CleanText(txtEmail.Text) + "','" + strAccessKey + "'," + dlClient.SelectedValue + ",'" + CleanText(txtLastName.Text) + "','" + CleanText(txtFirstName.Text) + "','" + CleanText(txtMiddleName.Text) + "','" + strSignature + "')";
                DB.ExeQuery(strSql);
               intEmployeeId= getemplid();
               if (ddCasetype.SelectedValue != "")
               {
                   flag = OE.InsertCaseType(intEmployeeId, category, visaid, strinvno, dtduedate, strstatus, dtdatefiled, intAssign_id, userid, strreceiptno, strSignature, other);

               }
               else
               { }

                //fillvalues();
                strAction = "New Case Created";
                AddLog("Case Updated (" + strAction + ")", strActionDesc);
                strSql = "UPDATE COMPANY SET Next_Sequence_No=isnull(Next_Sequence_No,1) + 1 WHERE COMPANYID=" + dlClient.SelectedValue;
                DB.ExeQuery(strSql);

            }
            else
            {
                ////strSql = "Update Employee set Email_Address='" + CleanText(txtEmail.Text) + "',Last_Name='" + CleanText(txtLastName.Text) + "',First_Name='" + CleanText(txtFirstName.Text) + "',MiddleName='" + CleanText(txtMiddleName.Text) + "', Date_Filed=" + strDateFiled + ",ReceiptNo='" + CleanText(txtReceipt.Text + "-" + txtReceipt1.Text) + "',Type_note='" + CleanText(txtType.Text) + "',Visa_Type_id=" + ddType.SelectedValue + ",Silvergate_Inv_No='" + CleanText(TxtInvno.Text) + "',Due_Date=" + strDueDate + ",Status=" + ddStatus.SelectedValue + ",Updated_By_User_ID=" + Session["Attorney_User_Id"].ToString() + ",Updated_On=getDate() Where Employee_id=" + intEmployeeId;
                //strSql1 = "UPDATE Employee_CaseType SET Category_Id = '" + category + "',Visa_Type_Id ='" + visaid + "',Inv_No='" + strinvno + "',Due_Date ='" + dtduedate + "',Status = '" + strstatus + "',Date_Filed ='" + dtduedate +
                //    "',Assign_to='" + intAssign_id + "',ReceiptNo ='" + strreceiptno + "WHERE  Employee_id=" + intEmployeeId;
                strSql = "Update Employee set  Email_Address='" + CleanText(txtEmail.Text) + "',Last_Name='" + CleanText(txtLastName.Text) + "',First_Name='" + CleanText(txtFirstName.Text) + "',MiddleName='" + CleanText(txtMiddleName.Text) + "',TelNo='" + CleanText(txtPhone.Text) + "', Updated_By_User_ID=" + Session["Attorney_User_Id"].ToString() + ",Updated_On=getDate() Where Employee_id=" + intEmployeeId;
                DB.ExeQuery(strSql);
                if (ddCasetype.SelectedValue != "")
                {
                    flag = OE.UpdateCaseType(intEmployeeId, category, visaid, strinvno, dtduedate, strstatus, dtdatefiled, intAssign_id, userid, strreceiptno, strSignature, other);
                }
                else
                {

                }

                if (blnChanged == true)
                {
                    AddLog("Case Updated (" + strAction + ")", strActionDesc);
                }
                    

            }

            //if (ddUsers.Visible)
            //{
            //    if (ddUsers.SelectedValue != hfAssign_ID.Value)
            //    {
            //        strSql = "Update Employee set Assigned_User_Accessed='NO',Assign_to=" + ddUsers.SelectedValue + "   Where Tracking_No='" + CleanText(txtTrackingId.Text) + "'";
            //        DB.ExeQuery(strSql);
            //    }
            //}
            //displayCaseList();
            Response.Redirect("case.aspx?cid=" + dlClient.SelectedValue.ToString());
           
        }

        private int getemplid()
        {
            int empid=0;
            ACLGDB DB = new ACLGDB();
            SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
            String strQuery = "SELECT [Employee_id] FROM [dbo].[Employee] where  Tracking_No='" + txtTrackingId.Text + "'";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = dbConnection;
            dbConnection.Open();
            empid = Convert.ToInt32(cmd.ExecuteScalar());
              dbConnection.Close();
              return empid;
        }

        //private void Insertvalues(int intEmployeeId, int category, int visaid, string strinvno, DateTime? dtduedate, int strstatus, DateTime? dtdatefiled, int intAssign_id, int userid, string strreceiptno, string strSignature, string other)
        //{
        //    string guidResult = System.Guid.NewGuid().ToString();
        //    guidResult = guidResult.Replace("-", "");
        //    ACLGDB DB = new ACLGDB();
        //    SqlConnection dbConnection = new SqlConnection(DB.ConnectionString);
           
          
        //    String strQuery = "INSERT INTO Employee_CaseType(Employee_id, Category_Id,Visa_Type_Id, Inv_No, Due_Date, Status, Date_Filed,Assign_to,User_ID,ReceiptNo, Signature,Other_Type,Created_Date)VALUES(@Employee_id, @Category_Id, @Visa_Type_Id, @Inv_No, @Due_Date, @Status, @Date_Filed,@Assign_to,@User_ID, @ReceiptNo, @Signature,@Other_Type, getdate())";
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = strQuery;
        //    cmd.Connection = dbConnection;
        //    cmd.Parameters.Add("@Employee_id", SqlDbType.Int).Value = intEmployeeId;
        //    cmd.Parameters.Add("@Category_Id", SqlDbType.Int).Value = category;
        //    cmd.Parameters.Add("@Visa_Type_Id", SqlDbType.Int).Value = visaid;
        //    cmd.Parameters.Add("@Inv_No", SqlDbType.VarChar, 50).Value = strinvno;
        //    cmd.Parameters.Add("@Due_Date ", SqlDbType.DateTime).Value = dtduedate;
        //    cmd.Parameters.Add("@Status", SqlDbType.Int).Value = strstatus;
        //    cmd.Parameters.Add("@Date_Filed ", SqlDbType.DateTime).Value = dtdatefiled;
        //    cmd.Parameters.Add("@Assign_to", SqlDbType.Int).Value = intAssign_id;
        //    cmd.Parameters.Add("@user_ID", SqlDbType.Int).Value = userid;
        //    cmd.Parameters.Add("@ReceiptNo", SqlDbType.VarChar, 50).Value = strreceiptno;
        //    cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 500).Value = guidResult;
        //    cmd.Parameters.Add("@Other_Type", SqlDbType.NVarChar, 100).Value = other;
        //    //cmd.Parameters.Add("@Signature", SqlDbType.VarChar, 100).Value = strSignature;
        //    dbConnection.Open();
        //    Console.WriteLine("sql query:" + cmd);
        //    cmd.ExecuteNonQuery();
        //    dbConnection.Close();
        //}
      
        public string CleanText(string strVal1)
        {
            strVal1 = strVal1.ToString().Trim().Replace("'", "''");
            return strVal1;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("case.aspx?cid=" + dlClient.SelectedValue.ToString());
        }

        protected void btnAddComment_Click(object sender, EventArgs e)
        {
            if (intEmployeeId > 0 & !string.IsNullOrEmpty(CleanText(txtComment.Text)))
            {
                string strSql = "";
                ACLGDB DB = new ACLGDB();

                txtComment.Text = txtComment.Text + strComments;
                strSql = "Insert into Notes(Record_Id,Commented_Date,Comments,Updated_By_User_ID) values(" + intEmployeeId + ",getdate(),'" + CleanText(txtComment.Text) + "'," + Session["Attorney_User_Id"].ToString() + ")";
                DB.ExeQuery(strSql);
                AddLog("Comment Added", CleanText(txtComment.Text));
                txtComment.Text = "";
                //strComments = getComments(intEmployeeId)
                Response.Redirect("case.aspx");
            }
        }

        protected void dlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dlClient.SelectedValue) > 0)
            {
                if (Request["action"] != null && Request["action"].ToString() == "new")
                {
                    hide.Visible = false;
                    HiddenClassName = "display:none";
                    btncaseButton.Visible = false;
                    blnEdit = false;
                    panComments.Visible = false;
                }
                intClient_id = Convert.ToInt32(dlClient.SelectedValue);
                Company OC = new Company(intClient_id);
                txtTrackingId.Text = OC.NextTrackingNo;
                setCompanyId(intClient_id);
                //txtTrackingNo.Text = txtTrackingId.Text
            }
        }
        public void GenerateNewCaseId()
        {
            SqlDataReader Dr = default(SqlDataReader);
            ACLGDB DB = new ACLGDB();
            StringBuilder sbBody = new StringBuilder();
            string strClient_Short_form = "";
            string strLastVal = "";
            string strYear = "";
            strYear = DateTime.Today.Year.ToString();
            if (strYear.Length >= 4)
            {
                strYear = strYear.Substring(2, 2);
            }
            Dr = DB.getReader("Select * from clients Where Client_id=" + dlClient.SelectedValue);

            if (Dr.Read())
            {
                strClient_Short_form = Dr["Client_Short_Form"].ToString();
                strLastVal = Dr["Last_Case_No"].ToString();
            }
            Dr.Close();

            if (strLastVal.Trim() == string.Empty)
            {
                strLastVal = "01";
            }
            else
            {
                strLastVal = (Convert.ToInt32(strLastVal) + 1).ToString();
                if (Convert.ToInt32(strLastVal) <= 9)
                {
                    strLastVal = "0" + strLastVal;
                }
            }

            strNewTrackingNo = strYear + strClient_Short_form + strLastVal;
            txtTrackingId.Text = strNewTrackingNo;
        }
        private bool AddLog(string strAction, string strDesc)
        {

            string strSql = "";
            ACLGDB DB = new ACLGDB();
            strSql = "Insert into User_log([User_id],[Record_id],[Action],[Action_Date],[Action_Desc]) values(" + intUserId + "," + intEmployeeId + ",'" + strAction + "',getdate(),'" + strDesc + "')";
            DB.ExeQuery(strSql);
            return true;
        }

        //protected void ddUsers_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    assignvalues();
        //}

        protected void ddType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddEmployer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intCompanyId = 0;
            intCompanyId = Convert.ToInt32(ddEmployer.SelectedValue);
            setCompanyId(intCompanyId);
            Response.Redirect("cases.aspx");
        }

        protected void txtTrackingNo_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {
            Session["CaseRequestPage"] = "cases";
        }
        protected void setCompanyId(int intCompanyId)
        {
            Session["ACompany_Id"] = intCompanyId;
            HttpCookie myCookie = new HttpCookie("Attorney");
            myCookie["ACompany_Id"] = intCompanyId.ToString();
            myCookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(myCookie);
        }
        protected void ddCasetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            casevalues();
            panComments.Visible = false;
            if (Request["action"] != null && Request["action"].ToString() == "new")
            {
                hide.Visible = false;
                HiddenClassName = "display:none";
                btncaseButton.Visible = false;
                blnEdit = false;
                panComments.Visible = true;
            }
        }
        protected void ddCasevalues_SelectedIndexChanged(object sender, EventArgs e)
        {

            casevaluesother();
            panComments.Visible = false;
            if (Request["action"] != null && Request["action"].ToString() == "new")
            {
                hide.Visible = false;
                HiddenClassName = "display:none";
                btncaseButton.Visible = false;
                blnEdit = false;
                panComments.Visible = true;
               
            }
        }

        protected void btncaseButton_Click(object sender, EventArgs e)
        {

            fillvalues();
        }
        protected void fillvalues()
        {
            strcasetype = ddCasetype.SelectedValue.ToString();
            strcasevalues = ddCasevalues.SelectedValue.ToString();
            category = Convert.ToInt32(strcasetype);
            visaid = Convert.ToInt32(strcasevalues);
            int aid = 0;
            strinvno = txtInvno.Text;

            if (txtDueDate.Text == "")
            {
                dtduedate = null;
            }
            else
            {
                dtduedate = Convert.ToDateTime(txtDueDate.Text);
            }

            strstatus = Convert.ToInt32(ddStatus.SelectedValue);
            if (txtDateFiled.Text == "")
            {
                dtdatefiled = null;
            }
            else
            {
                dtdatefiled = Convert.ToDateTime(txtDateFiled.Text);
            }
            string users = ddUsers.SelectedValue.ToString();

            if (ddUsers.SelectedValue == "")
            {
                userid = 0;
            }
            else
            {
                userid = Convert.ToInt32(users);
            }
            strreceiptno = txtReceiptno.Text.ToString();
            other = txtCaseother.Text;
            bool flag = false;
            AcglEmployee oE = new AcglEmployee();


            if (strActioncs == "edit")
            {
                if (ddCasetype.SelectedValue != "--Select CaseType--")
                {

                    flag = oE.UpdateCaseType(intEmployeeId, category, visaid, strinvno, dtduedate, strstatus, dtdatefiled, intAssign_id, userid, strreceiptno, strSignature, other);
                }
            }
            //else if( (Request["action"].ToString() == "delete"))
            //{
            //    if (ddCasetype.SelectedValue != "--Select CaseType--")
            //    {
            //        flag = oE.DeleteCaseType(intEmployeeId, strEmployeeSignature);
            //    }
            //}
            else
            {
                if (ddCasetype.SelectedValue != "--Select CaseType--")
                {
                    if (category != 0)
                    {
                        visaid = Convert.ToInt32(strcasevalues);
                    }
                    else
                    {
                        visaid = 0;
                        string script = "<script>alert('please selct the case type');</script>";

                    }
                    flag = oE.InsertCaseType(intEmployeeId, category, visaid, strinvno, dtduedate, strstatus, dtdatefiled, intAssign_id, userid, strreceiptno, strSignature, other);

                }
            }

            if (flag)
            {
                ddCasetype.SelectedValue = "";
                ddCasevalues.SelectedValue = "";
                txtDueDate.Text = "";
                ddStatus.SelectedValue = "";
                txtDateFiled.Text = "";
                ddUsers.SelectedValue = "";
                txtReceiptno.Text = "";



            }
            Response.Redirect("case.aspx#Type");
            //displayCaseList();

        }
        // public void fillblnedit()
        //{
        //    strSql = "Update Employee set Email_Address='" + CleanText(txtEmail.Text) + "',Last_Name='" + CleanText(txtLastName.Text) + "',First_Name='" + CleanText(txtFirstName.Text) + "',MiddleName='" + CleanText(txtMiddleName.Text) + ", Updated_By_User_ID=" + Session["Attorney_User_Id"].ToString() + ",Updated_On=getDate() Where Employee_id=" + intEmployeeId + ",Visa_Type_id=" + category + ",Date_Filed=" + dtdatefiled + ",Silvergate_Inv_No=" + strinvno + ",Due_Date=" + dtduedate + ",Assign_to=" + intAssign_id + ",Status=" + strstatus + ",ReceiptNo=" + strreceiptno;

        //}
        public void populate()
        {


            ddCasetype.AppendDataBoundItems = true;
            //ddCasevalues.Visible = false;
            ACLGDB DB = new ACLGDB();
            ddCasetype.Items.Clear();
            //ddCasetype.SelectedValue = "0";
            //ddCasetype.SelectedItem.Text = "--Select CaseType--";
            ListItem li = new ListItem("--Select Category--", "");
            ddCasetype.Items.Insert(0, li);
            string connectionString = DB.ConnectionString;
            String strQuery = "select Category_Id,Category_Name from Category";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddCasetype.DataSource = cmd.ExecuteReader();

                ddCasetype.DataTextField = "Category_Name";
                ddCasetype.DataValueField = "Category_Id";

                ddCasetype.DataBind();
                //   ListItem li = new ListItem("--Select CaseType--", "0");
                //ddCasetype.Items.Insert(0, li);

            }
            catch (Exception ex)
            {
                ddCasetype.SelectedValue = "";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }


        public void commenttext()
        {

            ddtext.Visible = false;
            ddtxtheading.Items.Add(new ListItem("---Select the comment type---", ""));
            ddtxtheading.Items.Add(new ListItem("Administrative Case Initiation", "1"));
            ddtxtheading.Items.Add(new ListItem("Document Review", "2"));
            ddtxtheading.Items.Add(new ListItem("Draft & Review Comments", "3"));
            ddtxtheading.Items.Add(new ListItem("Finalizing & Shipment", "4"));
            ddtxtheading.Items.Add(new ListItem("RFE Specific Comments", "5"));
            ddtxtheading.Items.Add(new ListItem("Administration Closing of File", "6"));
        }
        protected void ddtxtheading_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddtext.Visible = true;

            ddtext.Items.Clear();

            ddtext.AppendDataBoundItems = true;
            ddtext.Items.Add("---Select Text to add in Comment---");
            if (ddtxtheading.SelectedValue == "1")
            {

                ddtext.Items.Add("Folder with available documents (if any) to Accounts for invoicing");
                ddtext.Items.Add("Folder invoiced and transferred to Managing Paralegal for Document Review");
            }
            if (ddtxtheading.SelectedValue == "2")
            {

                ddtext.Items.Add("Folder Assigned to Paralegal for Document Review");
                ddtext.Items.Add("Review Documents,Missing:");
                ddtext.Items.Add("Followed-up with Client for Missing Documents,E-mail to client:");
                ddtext.Items.Add("Received Documents,and Assigned for Document Review.Follow-up to be completed by:");
                ddtext.Items.Add("Received Checks & Signature Pages");
            }
            if (ddtxtheading.SelectedValue == "3")
            {

                ddtext.Items.Add("Documenst Review & Draft Complete, Transferred to Sr./Managing Paralegal for Review");
                ddtext.Items.Add("Review Complete,Transferred to Paralegal for Edit");
                ddtext.Items.Add("Edits Complete,Transferred to Associate Attorney for Review");
                ddtext.Items.Add("1st Review Complete,Transfered to Paralegal for Edits");
                ddtext.Items.Add("Edits Complete,Transferred to Managing Attorney for Review");
                ddtext.Items.Add("Final Review Complete,Transferred to Paralegal to Finalize");
            }
            if (ddtxtheading.SelectedValue == "4")
            {

                ddtext.Items.Add("Petetion Scanned and Sent to Client for Review");
                ddtext.Items.Add("Receive Confirmation, Petetion Shipped FedEx:");
            }
            if (ddtxtheading.SelectedValue == "5")
            {

                ddtext.Items.Add("RFE Notice Received,Scanned and E-mailed to Client");
                ddtext.Items.Add("Request for Documents Drafted,and Submitetd for Review");
                ddtext.Items.Add("Request for Documenst reviewed, and Sent to Clinet");
                ddtext.Items.Add("Denial Received,Scanned and E-mailed to client");
                ddtext.Items.Add("RFE Scanned, and Sent to Client for Review");
                ddtext.Items.Add("Received Confirmation,RFE Shipped FedEx:");
            }
            if (ddtxtheading.SelectedValue == "6")
            {

                ddtext.Items.Add("I-129 Receipt Notice Received and E-mailed to Client");
                ddtext.Items.Add("I-129 PP Receipt Notice Receive and E-mailed to Client");
                ddtext.Items.Add("Approval Received and E-mailed to Client");
                ddtext.Items.Add("Approval Notice Mailed:");
                ddtext.Items.Add("Final Copy Folder Scanned & Inactivated ");
                ddtext.Items.Add("Invoice Ammends & Inactivated,Client Not Proceding");
            }
        }

        protected void ddtext_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtComment.Text = txtComment.Text + " " + ddtext.SelectedItem.Text;
        }

        //protected void btnaddcmt_Click(object sender, EventArgs e)
        //{
        //    txtComment.Text= txtComment.Text+" "+ddtext.SelectedValue.ToString();
        //}

        protected void displayCaseList()
        {
            //ddCasetype.SelectedValue = "";
            DataSet ds = new DataSet();

            AcglEmployee OE = new AcglEmployee();
            intstat = OE.Employee_Access;
            ds = OE.GetCaseType(intEmployeeId);
            //ddCasetype.SelectedValue = "0";
            assignvalues();
            int eRecId = 2;
            int cRecId = 0;
            populate();
           
            strRow1 = "";
            strRow2 = "";
            if (strActioncs != "edit")
                intRecId = 0;
            eRecId = intRecId;
            //if (ds.Tables.Count > 0)
            //{
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cRecId = i + 1;
                if (eRecId == cRecId)
                {
                    casevalues();

                    String status = OE.StatusString(Convert.ToInt32(ds.Tables[0].Rows[i]["Status"]));
                    string str = ds.Tables[0].Rows[i]["signature"].ToString();
                    string casetype = ds.Tables[0].Rows[i]["Category_ID"].ToString();
                    string casevalue = ds.Tables[0].Rows[i]["Visa_Type_ID"].ToString();
                    other = txtCaseother.Text;
                    ddCasevalues.Visible = true;
                    ddCasevalues.Enabled = true;

                    //string ctype = Convert.ToString(ddCasetype.Items.FindByValue(casetype));
                    ddCasetype.SelectedValue = casetype;
                    if (ddCasetype.SelectedValue == "")
                    {
                        ddCasevalues.Visible = false;
                        ddCasevalues.SelectedValue = "";
                    }
                    else
                    {

                        ddCasevalues.Visible = true;
                        ddCasevalues.Enabled = true;
                        //string cvalue = Convert.ToString(ddCasevalues.Items.FindByText(casevalue));
                        ddCasevalues.SelectedValue = casevalue;
                    }
                    if (casevalue == "Other")
                    {
                        txtCaseother.Visible = true;
                        txtCaseother.Text = ds.Tables[0].Rows[i]["Other_Type"].ToString();
                    }
                    else
                    {
                        txtCaseother.Visible = false;
                    }
                    string users = ds.Tables[0].Rows[i]["User_ID"].ToString();
                    txtInvno.Text = ds.Tables[0].Rows[i]["Inv_No"].ToString();
                    txtDueDate.Text = ds.Tables[0].Rows[i]["Due_Date"].ToString();
                    ddStatus.SelectedValue = status;
                    //ds.Tables[0].Rows[i]["Status"].ToString();
                    //ddUsers.SelectedValue = ds.Tables[0].Rows[i]["User_ID"].ToString();
                    ddUsers.SelectedValue = users;
                    txtDateFiled.Text = ds.Tables[0].Rows[i]["Date_Filed"].ToString();
                    txtReceiptno.Text = ds.Tables[0].Rows[i]["ReceiptNo"].ToString();

                }
                else if (cRecId < eRecId || intRecId <= 0)
                {
                    String status = OE.StatusString(Convert.ToInt32(ds.Tables[0].Rows[i]["Status"]));
                    string str = ds.Tables[0].Rows[i]["signature"].ToString();
                    string dtfiled = ds.Tables[0].Rows[i]["Date_Filed"].ToString();
                    string duedt = ds.Tables[0].Rows[i]["Due_Date"].ToString();
                    DateTime dt;
                    DateTime dtdue;
                    if (dtfiled == "")
                    {
                        dtfiled = "";
                    }
                    else
                    {
                        dt = Convert.ToDateTime(dtfiled);

                        dtfiled = dt.ToString("dd/M/yyyy");
                    }
                    if (duedt == "")
                    {
                        duedt = "";
                    }
                    else
                    {
                        dtdue = Convert.ToDateTime(duedt);
                        duedt = dtdue.ToString("dd/M/yyyy");
                    }
                    string users = ds.Tables[0].Rows[i]["User_ID"].ToString();
                    if (ds.Tables[0].Rows[i]["User_ID"].ToString() == "")
                    {
                        userid = 0;

                    }
                    else
                    {
                        userid = Convert.ToInt32(users);
                    }
                    strRow1 += "<tr>";
                    strRow1 += "<td> " + ds.Tables[0].Rows[i]["Category_Name"].ToString() + "<br/> " + ds.Tables[0].Rows[i]["Visa_Type_Name"];
                    if (ds.Tables[0].Rows[i]["Visa_Type_Name"] == "Other")
                    {
                        strRow1 += "<br/> " + ds.Tables[0].Rows[i]["Other_Type"] + "</td>";
                    }
                    else
                    {
                        strRow1 += "</td>";
                    }
                    strRow1 += "<td>" + ds.Tables[0].Rows[i]["Inv_No"].ToString() + "</td>";
                    strRow1 += "<td>" + duedt + "</td>";
                    strRow1 += "<td>" + status + "</td>";
                    strRow1 += "<td>" + ddUsers.Items.FindByValue(users) + "</td>";
                    strRow1 += "<td>" + dtfiled + "</td>";
                    strRow1 += "<td>" + ds.Tables[0].Rows[i]["ReceiptNo"].ToString() + "</td>";
                    if (intstat == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                        strRow1 += "<td><a href='case.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Type'>Edit</a>&nbsp;&nbsp;<a onclick='javascript:return confirm(\"Are you sure want to delete?\");'href='case.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Type'>Delete</a></td>";
                    else
                        strRow1 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                    strRow1 += "</tr>";
                }
                else
                {
                    string str = ds.Tables[0].Rows[i]["signature"].ToString();
                    String status = OE.StatusString(Convert.ToInt32(ds.Tables[0].Rows[i]["Status"]));
                    string dtfiled = ds.Tables[0].Rows[i]["Date_Filed"].ToString();
                    string duedt = ds.Tables[0].Rows[i]["Due_Date"].ToString();
                    DateTime dt;
                    string users = ds.Tables[0].Rows[i]["User_ID"].ToString();
                    if (ds.Tables[0].Rows[i]["User_ID"].ToString() == "")
                    {
                        userid = 0;

                    }
                    else
                    {
                        userid = Convert.ToInt32(users);
                    }
                    DateTime dtdue;
                    if (dtfiled == "")
                    {
                        dtfiled = "";
                    }
                    else
                    {
                        dt = Convert.ToDateTime(dtfiled);

                        dtfiled = dt.ToString("dd/M/yyyy");
                    }
                    if (duedt == "")
                    {
                        duedt = "";
                    }
                    else
                    {
                        dtdue = Convert.ToDateTime(duedt);

                        duedt = dtdue.ToString("dd/M/yyyy");
                    }
                    strRow2 += "<tr>";
                    strRow2 += "<td> " + ds.Tables[0].Rows[i]["Category_Name"].ToString() + "<br/> " + ds.Tables[0].Rows[i]["Visa_Type_Name"];
                    if (ds.Tables[0].Rows[i]["Visa_Type_Name"] == "Other")
                    {
                        strRow2 += "<br/> " + ds.Tables[0].Rows[i]["Other_Type"] + "</td>";
                    }
                    else
                    {
                        strRow2 += "</td>";
                    }
                    strRow2 += "<td>" + ds.Tables[0].Rows[i]["Inv_No"].ToString() + "</td>";
                    strRow2 += "<td>" + duedt + "</td>";
                    strRow2 += "<td>" + status + "</td>";
                    strRow2 += "<td>" + ddUsers.Items.FindByValue(users) + "</td>";
                    strRow2 += "<td>" + dtfiled + "</td>";

                    strRow2 += "<td>" + ds.Tables[0].Rows[i]["ReceiptNo"].ToString() + "</td>";
                    if (intstat == Convert.ToInt16(AcglGeneral.EMPLOYEE.READ_YES_EDIT_YES))
                        strRow2 += "<td><a href='case.aspx?action=edit&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Type'>Edit</a>&nbsp;&nbsp;<a href='case.aspx?action=delete&order=" + cRecId.ToString() + "&signature=" + ds.Tables[0].Rows[i]["signature"].ToString() + "#Type'>Delete</a></td>";
                    else
                        strRow2 += "<td><a href='#'>Edit</a>&nbsp;&nbsp;<a href='#'>Delete</a></td>";
                    strRow2 += "</tr>";
                }


            }

            //}
            //else
            //    fillvalues();

        }
        public void casevalues()
        {
            ddCasevalues.Items.Clear();
            ddCasevalues.Visible = true;
            //txtCaseother.Visible = false;
            ddCasevalues.Items.Add(new ListItem("--Select CaseType--", ""));
            ddCasevalues.AppendDataBoundItems = true;
            ACLGDB DB = new ACLGDB();
            string connectionString = DB.ConnectionString;
            if (ddCasetype.SelectedValue != "")
            {
                int categoryid = Convert.ToInt32(ddCasetype.SelectedValue);

                String strQuery = "select Visa_Type_Id,Visa_Type_Name from Visa_Type where Category_Id=@Category_Id";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Category_Id",
                    ddCasetype.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddCasevalues.DataSource = cmd.ExecuteReader();
                    ddCasevalues.DataTextField = "Visa_Type_Name";
                    ddCasevalues.DataValueField = "Visa_Type_Id";
                    ddCasevalues.DataBind();
                    if (ddCasevalues.Items.Count > 1)
                    {
                        ddCasevalues.Enabled = true;
                    }
                    else
                    {
                        ddCasevalues.Enabled = false;

                    }
                }
                catch (Exception ex)
                {
                    ddCasevalues.SelectedValue = "";
                }
                finally
                {

                    con.Close();
                    con.Dispose();

                }
            }
            else
            {

            }
        }
        public void casevaluesother()
        {
            if (ddCasevalues.SelectedItem.Text == "Other")
            {
                txtCaseother.Visible = true;
            }
            else
                txtCaseother.Visible = false;
        }
        public void assignvalues()
        {

            ddUsers.AppendDataBoundItems = true;

            ACLGDB DB = new ACLGDB();
            ddUsers.Items.Clear();
            //ddCasetype.SelectedValue = "0";
            //ddCasetype.SelectedItem.Text = "--Select CaseType--";
            ListItem li = new ListItem("--Select User--", "");
            ddUsers.Items.Insert(0, li);
            string connectionString = DB.ConnectionString;
            String strQuery = "select User_ID,User_Display_Name from dbo.Users";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddUsers.DataSource = cmd.ExecuteReader();

                ddUsers.DataTextField = "User_Display_Name";
                ddUsers.DataValueField = "User_ID";

                ddUsers.DataBind();
                //   ListItem li = new ListItem("--Select CaseType--", "0");
                //ddCasetype.Items.Insert(0, li);

            }
            catch (Exception ex)
            {
                ddUsers.SelectedValue = "";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void ddUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Request["action"] != null && Request["action"].ToString() == "new")
            {
                hide.Visible = false;
                HiddenClassName = "display:none";
                btncaseButton.Visible = false;
                blnEdit = false;
                panComments.Visible = false;
            }
            else
            {
                hide.Visible = true;
                panComments.Visible = true;
            }
        }

    }
}
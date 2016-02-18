Imports System.Data.SqlClient
Imports ACLGDataAaccess
Imports ACLG

Partial Class case1
    Inherits System.Web.UI.Page
    Dim intEmployeeId As Integer = 0
    Dim intClient_id As Integer = 0
    Dim intAssign_id As Integer = 0
    Dim blnEdit As Boolean = True
    Public strComments As String = ""
    Public strNewTrackingNo As String = ""
    Dim intUserId As Integer
    Dim intAttorney_id As Integer = 0
    Dim intTypeId As Integer = 0
    Dim strEmployeeSignature As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Attorney_Id") Is Nothing Then
            Response.Redirect("index.aspx")
        End If
        lbUserName.Text = Session("Attorney_User_DisplayName").ToString()
        intAttorney_id = Convert.ToInt16(Session("Attorney_Id"))
        intUserId = Convert.ToInt16(Session("Attorney_User_Id"))

        If Session("Attorney_User_Type") = "Admin" Then
            ddUsers.Visible = True
            'rowAssign.Visible = True
        Else
            ddUsers.Visible = False
            'rowAssign.Visible = False
        End If

        If Request("Attorney_Employee_Id") Is Nothing Then
            If Session("Attorney_Employee_Id") Then
                intEmployeeId = Session("Attorney_Employee_Id")
            End If
        ElseIf Session("CaseRequestPage") <> "cases" Then
            intEmployeeId = Request("Attorney_Employee_Id")
        Else
            If Session("Attorney_Employee_Id") Then
                intEmployeeId = Session("Attorney_Employee_Id")
            End If
        End If
        Session("CaseRequestPage") = "cases"

        If Not IsPostBack Then
            Dim objG As AcglGeneral = New AcglGeneral()
            lbFormLinks.Text = objG.GetFormLinks(intEmployeeId, strEmployeeSignature)
            lbNavigation.Text = objG.GetNavLinks("CASE")

            If Request("action") <> "new" Then
                blnEdit = True
                FillFrom()
                dlClient.Enabled = False
            End If
            fillCombo(intClient_id)
            FillTypes(intTypeId)
            If ddUsers.Visible Then
                fillUsers(intAssign_id)
            End If

            If intUserId = intAssign_id Then
                UpdateAssign_Accessed(intUserId, intEmployeeId)
            End If
            If Request("action") = "new" Then
                If Convert.ToInt16(dlClient.SelectedValue) > 0 Then
                    intClient_id = Convert.ToInt16(dlClient.SelectedValue)
                    Dim OC As Company = New Company(intClient_id)
                    txtTrackingId.Text = OC.NextTrackingNo
                    txtTrackingNo.Text = txtTrackingId.Text
                End If
            End If

            Dim OA As clsAttorney = New clsAttorney(intAttorney_id)
            OA.bindCompanyCombo(ddEmployer, 0)
            If intClient_id > 0 Then
                ddEmployer.SelectedValue = intClient_id.ToString()
                Dim oC As New Company(intClient_id)
                Session("Attorney_CompanyName") = oC.Legal_Name.ToString()
                lbCompanyName1.Text = oC.Legal_Name.ToString()
                lbClientName.Text = oC.Legal_Name.ToString()
            End If

        End If

        If Request("action") = "new" Then
            blnEdit = False
            panComments.Visible = False
        Else
            panComments.Visible = True
            strComments = getComments(intEmployeeId)
            blnEdit = True
            If Request("action") = "editScroll" Then
                panComments.Focus()
            End If
        End If

    End Sub
    Private Sub UpdateAssign_Accessed(ByVal intAID As Integer, ByVal intR As Integer)
        Dim strSql As String = ""
        Dim DB As New ACLGDB()
        strSql = "Update Employee set Assigned_User_Accessed='YES' where Employee_id=" & intEmployeeId & " and Assign_to=" & intAID
        DB.ExeQuery(strSql)
    End Sub
    Public Sub FillFrom()

        Dim oE As AcglEmployee = New AcglEmployee(intEmployeeId)
        Dim strSql As String = ""
        Dim intUid As Integer = 0
        txtTrackingId.Text = oE.TrackingNo
        Session("Attorney_Employee_TrackingNo") = oE.TrackingNo
        txtLastName.Text = oE.LastName
        hfLname.Value = oE.LastName
        txtFirstName.Text = oE.FirstName
        hfFName.Value = oE.FirstName
        txtMiddleName.Text = oE.MiddleName
        hfMname.Value = oE.MiddleName
        txtEmail.Text = oE.Email
        If (oE.Email.Trim() <> "") Then
            txtEmail.Enabled = False
        End If
        hfEmail.Value = oE.Email
        intTypeId = oE.Visa_Type_id

        If IsDate(oE.Date_Filed) Then
            txtDateFiled.Text = CDate(oE.Date_Filed)
        End If
        hfDateFiled.Value = oE.Date_Filed
        txtReceipt.Text = Left(oE.ReceiptNo, 3)
        txtReceipt1.Text = Mid(oE.ReceiptNo, 5, 10)
        hfReceip.Value = oE.ReceiptNo
        txtType.Text = oE.Type_Note
        hfType.Value = oE.Visa_Type_id
        TxtInvno.Text = oE.Silvergate_Inv_No
        hfInvno.Value = oE.Silvergate_Inv_No

        If IsDate(oE.Due_Date) Then
            txtDueDate.Text = CDate(oE.Due_Date)
        End If

        hDueDate.Value = oE.Due_Date

        intClient_id = oE.Company_id

        If oE.Assign_to <= 0 Then
            intAssign_id = 0
            hfAssign_ID.Value = "0"
        Else
            intAssign_id = oE.Assign_to
            hfAssign_ID.Value = oE.Assign_to
        End If

        ddStatus.SelectedValue = oE.Status
        hfStatus.Value = oE.Status

        If (oE.Updated_By_User_ID > 0) Then
            Dim OU As AttorneyUser = New AttorneyUser(oE.Updated_By_User_ID)
            lbUpdatdBy.Text = OU.User_Display_Name & " on " & oE.Updated_On
        End If


    End Sub

    Private Function getComments(ByVal intRID As Integer) As String
        Dim strC As String = ""

        Dim Dr As SqlDataReader
        Dim DB As New ACLGDB()
        Dim strSql As String = ""

        strSql = "Select *,Convert(varchar(12),Commented_Date,101) as Commented_Date1 from Notes left Join Users On Notes.Updated_By_User_ID=Users.User_id  where Record_Id=" & intRID & " order by Commented_Date desc"
        Dr = Db.GetReader(strSql)

        While Dr.Read()
            If IsDate(Dr("Commented_Date1").ToString()) Then
                strC = strC & "<tr><td align='left'>" & CDate(Dr("Commented_Date1").ToString()) & "-" & Dr("User_Display_Name").ToString() & "</td><td align='left'>" & Dr("Comments").ToString() & "</td></tr>"
            Else
                strC = strC & "<tr><td align='left'>--" & Dr("User_Display_Name").ToString() & "</td><td align='left'>" & Dr("Comments").ToString() & "</td></tr>"
            End If
        End While
        Dr.Close()
        Return strC



    End Function
    Public Sub FillTypes(ByVal intT As Integer)
        Dim objCompany As clsAttorney = New clsAttorney()
        objCompany.bindTypeCombo(ddType, intT)
    End Sub


    Public Sub fillCombo(ByVal IntCid As Integer)
        Dim OA As clsAttorney = New clsAttorney(intAttorney_id)
        OA.bindCompanyCombo(dlClient, IntCid)
    End Sub
    Public Sub fillUsers(ByVal IntUid As Integer)
        Dim Dr As SqlDataReader
        Dim DB As New ACLGDB()
        Dim sbBody As New StringBuilder()
        Dr = DB.getReader("Select * from Users order by User_Display_Name")
        ddUsers.DataSource = Dr
        ddUsers.DataTextField = "User_Display_Name"
        ddUsers.DataValueField = "User_ID"
        ddUsers.DataBind()
        ddUsers.Items.Insert(0, New ListItem("Select User", "0"))
        ddUsers.SelectedValue = IntUid
        Dr.Close()
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim strActionDesc As String = ""
        Dim strSql As String = ""
        Dim DB As New ACLGDB()
        Dim strDateFiled As String = ""
        Dim strDueDate As String = ""
        Dim blnChanged As Boolean = False
        Dim strAction As String = ""
        Dim strRow1 As String = ""
        Dim strRow2 As String = ""
        Dim OE As New AcglEmployee()


        If IsDate(CleanText(txtDateFiled.Text)) Then
            strDateFiled = "'" & CleanText(txtDateFiled.Text) & "'"
        Else
            strDateFiled = "null"
        End If

        If IsDate(CleanText(txtDueDate.Text)) Then
            strDueDate = "'" & CleanText(txtDueDate.Text) & "'"
        Else
            strDueDate = "null"
        End If
        strActionDesc = "<table>"

        If hfLname.Value <> txtLastName.Text Or hfFName.Value <> txtFirstName.Text Or hfMname.Value <> txtMiddleName.Text Then
            blnChanged = True
            strAction = "Name"
        End If



        If hfEmail.Value <> txtEmail.Text Then
            blnChanged = True
            strAction += ", Email Id"
        End If


        If hfDateFiled.Value <> txtDateFiled.Text Then
            blnChanged = True
            strAction += ", DateFiled"
        End If
        If hfReceip.Value <> CleanText(txtReceipt.Text & "-" & txtReceipt1.Text) Then
            blnChanged = True
            strAction += ", ReceiptNo"
        End If
        If hfType.Value <> txtType.Text Then
            blnChanged = True
            strAction += ", Type"
        End If
        If hfInvno.Value <> TxtInvno.Text Then
            blnChanged = True
            strAction += ", InvNo"
        End If
        If hDueDate.Value <> txtDueDate.Text Then
            blnChanged = True
            strAction += ", DueDate"
        End If
        If hfStatus.Value <> ddStatus.SelectedValue Then
            blnChanged = True
            strAction += ", Status "
        End If
        strActionDesc += "<tr><td>Old values:</td><td>" & hfEmail.Value & " " & hfLname.Value & " " & hfFName.Value & " " & hfMname.Value & "</td><td>" & hfDateFiled.Value & "</td><td>" & hfReceip.Value & "</td><td>" & hfType.Value & "</td><td>" & hfInvno.Value & "</td><td>" & hDueDate.Value & "</td><td>" & hfStatus.Value & "</td></tr>"
        strActionDesc += "<tr><td>New values:</td><td>" & txtEmail.Text & " " & txtLastName.Text & " " & txtFirstName.Text & " " & txtMiddleName.Text & "</td><td>" & txtDateFiled.Text & "</td><td>" & txtReceipt.Text & "</td><td>" & txtType.Text & "</td><td>" & TxtInvno.Text & "</td><td>" & txtDueDate.Text & "</td><td>" & ddStatus.SelectedValue & "</td></tr>"
        strActionDesc += "</table>"


        If blnEdit Then
            strSql = "Update Employee set Email_Address='" & CleanText(txtEmail.Text) & "',Last_Name='" & CleanText(txtLastName.Text) & "',First_Name='" & CleanText(txtFirstName.Text) & "',MiddleName='" & CleanText(txtMiddleName.Text) & "', Date_Filed=" & strDateFiled & ",ReceiptNo='" & CleanText(txtReceipt.Text & "-" & txtReceipt1.Text) & "',Type_note='" & CleanText(txtType.Text) & "',Visa_Type_id=" & ddType.SelectedValue & ",Silvergate_Inv_No='" & CleanText(TxtInvno.Text) & "',Due_Date=" & strDueDate & ",Status=" & ddStatus.SelectedValue & ",Updated_By_User_ID=" & Session("Attorney_User_Id") & ",Updated_On=getDate() Where Employee_id=" & intEmployeeId
            DB.ExeQuery(strSql)
            If blnChanged = True Then
                AddLog("Case Updated (" & strAction & ")", strActionDesc)
            End If
        Else
            Dim strAccessKey As String = OE.GetAccessKey()
            strSql = "Insert into Employee(Tracking_No,Email_Address,Access_Key,Company_id,Last_Name,First_Name,MiddleName,Date_Filed,ReceiptNo,Type_Note,Visa_Type_id,Silvergate_Inv_No,Due_Date,Updated_By_User_ID,Updated_On,status,JobTitle_id) values('" & CleanText(txtTrackingId.Text) & "','" & CleanText(txtEmail.Text) & "','" & strAccessKey & "'," & dlClient.SelectedValue & ",'" & CleanText(txtLastName.Text) & "','" & CleanText(txtFirstName.Text) & "','" & CleanText(txtMiddleName.Text) & "'," & strDateFiled & ",'" & CleanText(txtReceipt.Text & "-" & txtReceipt1.Text) & "','" & CleanText(txtType.Text) & "'," & ddType.SelectedValue & ",'" & CleanText(TxtInvno.Text) & "'," & strDueDate & "," & Session("Attorney_User_Id") & ",getDate()," & ddStatus.SelectedValue & ",0)"
            DB.ExeQuery(strSql)
            strAction = "New Case Created"
            AddLog("Case Updated (" & strAction & ")", strActionDesc)
            strSql = "UPDATE COMPANY SET Next_Sequence_No=isnull(Next_Sequence_No,1) + 1 WHERE COMPANYID=" & dlClient.SelectedValue
            DB.ExeQuery(strSql)
        End If
        If ddUsers.Visible Then
            If ddUsers.SelectedValue <> hfAssign_ID.Value Then
                strSql = "Update Employee set Assigned_User_Accessed='NO',Assign_to=" & ddUsers.SelectedValue & "   Where Tracking_No='" & CleanText(txtTrackingId.Text) & "'"
                DB.ExeQuery(strSql)
            End If
        End If
        Response.Redirect("cases.aspx?cid=" & dlClient.SelectedValue)
    End Sub
    Function CleanText(ByVal strVal1 As String) As String
        strVal1 = strVal1.ToString().Trim().Replace("'", "''")
        Return strVal1
    End Function

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("cases.aspx?cid=" & dlClient.SelectedValue)
    End Sub

    Protected Sub btnAddComment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddComment.Click

        If intEmployeeId > 0 And CleanText(txtComment.Text) <> "" Then
            Dim strSql As String = ""
            Dim DB As New ACLGDB()
            strSql = "Insert into Notes(Record_Id,Commented_Date,Comments,Updated_By_User_ID) values(" & intEmployeeId & ",getdate(),'" & CleanText(txtComment.Text) & "'," & Session("Attorney_User_Id") & ")"
            DB.ExeQuery(strSql)
            AddLog("Comment Added", CleanText(txtComment.Text))
            txtComment.Text = ""
            'strComments = getComments(intEmployeeId)
            Response.Redirect("case.aspx")
        End If

    End Sub
    Protected Sub dlClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dlClient.SelectedIndexChanged
        ' GenerateNewCaseId()
        If Convert.ToInt16(dlClient.SelectedValue) > 0 Then
            intClient_id = Convert.ToInt16(dlClient.SelectedValue)
            Dim OC As Company = New Company(intClient_id)
            txtTrackingId.Text = OC.NextTrackingNo
            setCompanyId(intClient_id)
            'txtTrackingNo.Text = txtTrackingId.Text
        End If
    End Sub

    Sub GenerateNewCaseId()
        Dim Dr As SqlDataReader
        Dim DB As New ACLGDB()
        Dim sbBody As New StringBuilder()
        Dim strClient_Short_form As String = ""
        Dim strLastVal As String = ""
        Dim strYear As String = ""
        strYear = Right(Year(DateAndTime.Today()), 2)
        Dr = DB.getReader("Select * from clients Where Client_id=" & dlClient.SelectedValue)

        If Dr.Read() Then
            strClient_Short_form = Dr("Client_Short_Form").ToString()
            strLastVal = Dr("Last_Case_No").ToString()
        End If
        Dr.Close()

        If Trim(strLastVal) = "" Then
            strLastVal = "01"
        Else
            strLastVal = Val(strLastVal) + 1
            If Val(strLastVal) <= 9 Then
                strLastVal = "0" & strLastVal
            End If
        End If

        strNewTrackingNo = strYear & strClient_Short_form & strLastVal
        txtTrackingId.Text = strNewTrackingNo
    End Sub

    'Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    '    Dim strTNo As String = ""
    '    Dim intRid As Integer = 0

    '    strTNo = txtSearch.Text.Trim().Replace("'", "''")

    '    If strTNo <> "" Then

    '        Dim Dr As SqlDataReader
    '        Dim DB As New ACLGDB()
    '        Dim strSql As String = ""

    '        strSql = "Select * from Records where Tracking_No='" & strTNo & "'"
    '        Dr = Db.GetReader(strSql)
    '        While Dr.Read()
    '            intRid = Dr("Record_id")
    '        End While
    '        Dr.Close()

    '        If intRid > 0 Then
    '            Response.Redirect("case.aspx?id=" & intRid & "&action=edit")
    '        End If

    '    End If
    'End Sub

    Private Function AddLog(ByVal strAction As String, ByVal strDesc As String) As Boolean

        Dim strSql As String = ""
        Dim DB As New ACLGDB()
        strSql = "Insert into User_log([User_id],[Record_id],[Action],[Action_Date],[Action_Desc]) values(" & intUserId & "," & intEmployeeId & ",'" & strAction & "',getdate(),'" & strDesc & "')"
        DB.ExeQuery(strSql)
        Return True
    End Function

    Protected Sub ddStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddStatus.SelectedIndexChanged

    End Sub

    Protected Sub ddEmployer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddEmployer.SelectedIndexChanged


        Dim intCompanyId As Integer = 0
        intCompanyId = Convert.ToInt16(ddEmployer.SelectedValue)
        setCompanyId(intCompanyId)
        Response.Redirect("cases.aspx")
        


    End Sub

    Protected Sub txtSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Click
        Session("CaseRequestPage") = "cases"
    End Sub

    Protected Sub setCompanyId(ByVal intCompanyId As Integer)
        Session("ACompany_Id") = intCompanyId
        Dim myCookie As New HttpCookie("Attorney")
        myCookie("ACompany_Id") = intCompanyId.ToString()
        myCookie.Expires = DateTime.Now.AddDays(30)
        Response.Cookies.Add(myCookie)
    End Sub
End Class

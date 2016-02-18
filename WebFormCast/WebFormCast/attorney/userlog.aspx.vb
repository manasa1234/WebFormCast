Imports System.Data.SqlClient
Imports ACLGDataAaccess
Partial Class userlog
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Attorney_User_Type") Is Nothing Then
            Response.Redirect("index.aspx")
            'Else
            'If Session("Attorney_User_Type") <> "Admin" Then
            'Response.Redirect("index.aspx")
            'End If
        End If

        'lbCompanyLogoText.Text = Session["Company_Name"].ToString();
        lbUserDisp.Text = Session("Attorney_User_DisplayName").ToString()

        If Not IsPostBack Then
            Dim OG As AcglGeneral = New AcglGeneral()
            lbNavigation.Text = OG.GetNavLinks("REPORTS")

            fillUsers(0)
        End If
    End Sub

    Public Sub FillGrid()
        Dim Db As New ACLGDB()
        Dim intUserId As Integer = 0
        intUserId = ddUsers.SelectedValue
        mydata.ConnectionString = Db.ConnectionString
        mydata.SelectCommand = "SELECT User_log.User_id, User_log.Record_id, User_log.Action, Users.User_Name,Action_Desc,Action_Date,Employee.Tracking_No,User_Display_Name FROM (User_log INNER JOIN Users ON User_log.User_id = Users.User_ID) INNER JOIN Employee ON User_log.Record_id = Employee.employee_id  Where user_log.User_id=" & intUserId & " order by Action_Date desc"
    End Sub
    Public Sub fillUsers(ByVal IntUid As Integer)
        Dim Dr As SqlDataReader
        Dim Db As New ACLGDB()
        Dim sbBody As New StringBuilder()

        Dr = Db.GetReader("Select * from Users order by User_Display_Name")
        ddUsers.DataSource = Dr
        ddUsers.DataTextField = "User_Display_Name"
        ddUsers.DataValueField = "User_ID"
        ddUsers.DataBind()
        ddUsers.Items.Insert(0, New ListItem("Recent Actions", "0"))
        ddUsers.SelectedValue = IntUid
        Dr.Close()
    End Sub

    Protected Sub ddUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddUsers.SelectedIndexChanged

        If (ddUsers.SelectedIndex >= 0) Then
            lbUserName.Text = ddUsers.SelectedItem.Text & " Actions"
        End If


        FillGrid()
    End Sub

    Protected Sub myGrid_PageIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles myGrid.PageIndexChanged
        FillGrid()
    End Sub

    Protected Sub myGrid_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles myGrid.Sorted
        FillGrid()
    End Sub

    Protected Sub myGrid_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles myGrid.RowCommand
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)
        Dim item As String = myGrid.DataKeys(index).Value.ToString()
        Session("Attorney_Employee_Id") = item.ToString()
        If e.CommandName.Equals("select") Then
            Response.Redirect("case.aspx?return=log")
        End If
    End Sub
End Class

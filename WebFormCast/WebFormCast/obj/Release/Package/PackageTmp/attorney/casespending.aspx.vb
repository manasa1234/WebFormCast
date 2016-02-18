Imports System.Data.SqlClient
Imports ACLGDataAaccess
Imports System.String
Imports System.Text
Partial Class attorney_casespending
    Inherits System.Web.UI.Page
    Public strBody As String
    Public strBody1 As String
    Dim blnEdit As Boolean = False
    Dim intCid As Integer = 0
    Dim intRecID As Integer = 0
    Public Function GetTable() As Boolean
        Dim Dr As SqlDataReader
        Dim Db As New ACLGDB()
        Dim sbBody As New StringBuilder()
        Dim sbBody1 As New StringBuilder()
        Dim sno As Integer = 0
        Dim strName As String = ""
        Dim intClient_id As Integer = 0
        Dim blnIsFound As Boolean = False
        Dim strSql As String = ""
        strSql = "Select *,(select top 1 Comments from notes  where notes.Record_Id=Employee.Employee_id order by Case_Note_id desc) as Comments  from Employee left join Users On Employee.Updated_By_User_ID=users.User_ID Where Due_date between '" & getTodayDate() & "' and '" & cale.SelectedDate & "' order by Due_Date"
        Dr = Db.GetReader(strSql)

        While Dr.Read()
            sno = sno + 1

            If blnIsFound = False Then
                sbBody.AppendLine("<tr>")
                sbBody.AppendLine("<td class='td_row1'>" & sno & "</td>")
                sbBody.AppendLine("<td class='td_row1'><a href='cases.aspx?id=" & Dr("Employee_id") & "&signature=&tracking=" & Dr("Tracking_No").ToString() & "&select=true'>" & Dr("Tracking_No").ToString() & "</a>&nbsp;</td>")
                sbBody.AppendLine("<td class='td_row1'>" & Dr("Last_Name").ToString() & " " & Dr("First_Name").ToString() & " " & Dr("MiddleName").ToString() & "&nbsp;</td>")

                If IsDate(Dr("Date_filed").ToString()) Then
                    sbBody.AppendLine("<td class='td_row1'>" & CDate(Dr("Date_filed").ToString()) & "&nbsp;</td>")
                Else
                    sbBody.AppendLine("<td class='td_row1'>&nbsp;</td>")
                End If
                sbBody.AppendLine("<td class='td_row1'>" & Dr("ReceiptNo").ToString() & "&nbsp;</td>")
                'sbBody.AppendLine("<td class='td_row1'>" & Dr("comments").ToString() & "</td>")
                sbBody.AppendLine("<td class='td_row1'>" & Dr("comments").ToString() & "&nbsp;</td>")
                If IsDate(Dr("Due_Date").ToString()) Then
                    sbBody.AppendLine("<td class='td_row1'>" & CDate(Dr("Due_Date").ToString()) & "&nbsp;</td>")
                Else
                    sbBody.AppendLine("<td class='td_row1'>&nbsp;</td>")
                End If
                sbBody.AppendLine("<td class='td_row1'>" & Dr("Silvergate_Inv_no").ToString() & "&nbsp;</td>")
                sbBody.AppendLine("<td class='td_row1'>" & Dr("Type_Note").ToString() & "&nbsp;</td>")
                'sbBody.AppendLine("<td class='td_row1'>" & Dr("Status_Note").ToString() & "&nbsp;</td>")
                sbBody.AppendLine("<td class='td_row1'>" & Dr("User_Display_Name").ToString() & " " & Dr("Updated_On").ToString() & "&nbsp;</td>")
                strName = Dr("Tracking_No").ToString()
                sbBody.AppendLine("</tr>")
            End If
        End While
        Dr.Close()
        strBody = sbBody.ToString()
        strBody1 = sbBody1.ToString()
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("Attorney_Id") Is Nothing Then
            Response.Redirect("index.aspx")
        End If
        'lbCompanyLogoText.Text = Session["Company_Name"].ToString();
        lbUserName.Text = Session("Attorney_User_DisplayName").ToString()

        Dim OG As AcglGeneral = New AcglGeneral()
        lbNavigation.Text = OG.GetNavLinks("HOME")
        cale.SelectedDate = Month(DateAdd(DateInterval.Day, 15, CDate(Date.Now()))) & "/" & Day(DateAdd(DateInterval.Day, 15, CDate(Date.Now()))) & "/" & Year(DateAdd(DateInterval.Day, 15, CDate(Date.Now())))
        GetTable()
    End Sub

    Protected Sub cale_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cale.SelectionChanged
        GetTable()
    End Sub


    Function getTodayDate() As String
        Dim strdate As String = ""

        strdate = Month(Date.Now()) & "/" & Day(Date.Now()) & "/" & Year(Date.Now())
        Return strdate
    End Function
End Class

Imports System
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports Microsoft.VisualBasic
Imports System.Web.SessionState
Imports System.Web.Mail
Imports System.Web.UI.Page
Imports System.Diagnostics
Imports WebSupergoo.ABCpdf4
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        Dim theDoc As New WebSupergoo.ABCpdf4.Doc
        Dim pdftext As String
        pdftext = GetWebSource("http://www.google.com")
        'pdftext = "<HTML><body><h1>Shivaji</h1></body></HTML>"
        'theDoc.SetInfo(0, "License", "322-594-815-276-4005-092 ABCpdf .NET Pro 5")
        Dim w As Integer = 530  '540
        Dim h As Integer = 800 ' 750
        Dim x1 As Integer = 30
        Dim y1 As Integer = 0
        Dim theID As Integer

        theDoc.Rect.SetRect(x1, y1, w, h)
        theID = theDoc.AddImageHtml(pdftext, True, 0, False)

        While theDoc.GetInfo(theID, "Truncated") = "1"
            theDoc.Page = theDoc.AddPage()
            theID = theDoc.AddImageToChain(theID)
            'theDoc.FrameRect()
        End While

        Dim I As Integer

        For I = 1 To theDoc.PageCount
            theDoc.PageNumber = I
            theDoc.Flatten()
        Next

        Dim strPdfName As String
        Dim theData As Byte() = theDoc.GetData()
        Response.Clear()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", theData.Length.ToString())
        strPdfName = "sample.pdf"   'stremployeeLastname & "_" & Month(d) & "_" & Day(d) & "_" & Year(d) & ".pdf"
        'strPdfName = stremployeeLastname & "_Doc.pdf"
        'Response.AddHeader("content-disposition", "attachment; filename=" & strPdfName)
        'Response.AddHeader("content-disposition", "attachment; filename=shivaji.pdf")
        'theDoc.Save("C:\Inetpub\wwwroot\ampac_crc\Test.pdf")
        'Response.Write("SSSSSSSSSSSSSSSS")
        Response.AddHeader("content-disposition", "inline; filename=" & strPdfName)
        Response.BinaryWrite(theData)
        'response.write(pdftext)
        'lbDisp.Text = strHtml
        'lbdisp.Text = "The PDF is being generated......."

    End Sub
    Public Shared Function GetWebSource(ByVal strURL As String) As String
        Try
            Dim HttpWReq As HttpWebRequest
            HttpWReq = WebRequest.Create(strURL)
            Dim HttpWResp As HttpWebResponse
            HttpWResp = HttpWReq.GetResponse()
            'HttpContext.Current.Trace.Warn("**" & HttpWResp.ResponseUri.ToString)
            'HttpContext.Current.Trace.Warn("**" & HttpWResp.ResponseUri.Host)
            'HttpContext.Current.Trace.Warn("**" & HttpWResp.ResponseUri.IsFile)
            Dim s As Stream = HttpWResp.GetResponseStream()
            Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim readStream As New StreamReader(s, encode)
            Return readStream.ReadToEnd()
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("ERR " & ex.Message)
            Return ""
        End Try
    End Function




End Class

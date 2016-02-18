<%@ Page Language="VB" EnableViewState="false"  %>
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("time") = Now.ToString()
		Session("Attorney_Id")=Session("Attorney_Id")
		Dim k as integer
		k = Session.Timeout    
		Response.write(k)
		Response.Write("<BR>")
        Response.Write(Session("Attorney_Id"))
    End Sub
</script>



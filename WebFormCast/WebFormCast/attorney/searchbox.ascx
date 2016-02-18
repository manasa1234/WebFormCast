<%@ Control Language="C#" AutoEventWireup="true" Inherits="attorney_searchbox" Codebehind="searchbox.ascx.cs" %>
<table border="0" align="left" cellpadding="0" cellspacing="0">
<tr>
<td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
<td align="right" class="topbar_sub_bg">Clients <asp:DropDownList 
        AutoPostBack="true" ID="ddEmployer" style="width:200px" runat="server" 
         EnableViewState="true" 
        onselectedindexchanged="ddEmployer_SelectedIndexChanged" ></asp:DropDownList><br /><br />
  Search. <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px" 
        ontextchanged="txtTrackingNo_TextChanged"></asp:TextBox>&nbsp;<asp:Button 
        ID="txtSearch" runat="server" PostBackUrl="~/attorney/cases.aspx" CausesValidation="false" Text="&nbsp;GO&nbsp;" onclick="txtSearch_Click" />
  <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
</tr>
</table>
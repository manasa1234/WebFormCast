<%@ Page Language="VB" AutoEventWireup="false" Inherits="userlog" Codebehind="userlog.aspx.vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="container">
<form id="form1" name="form1"  runat="server">
<div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserDisp" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
  <asp:Label ID="lbNavigation" runat="server">
    <ul class="topNav">
    <li><a href="home.aspx"><b>Home</b></a></li>
      <li><a href="cases.aspx"><b>Cases</b></a></li>
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li class="current"><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    </asp:Label>
    <div id="contentArea3">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="right" class="topbar_sub_bg">User :<asp:DropDownList ID="ddUsers" runat="server" AutoPostBack=true></asp:DropDownList></td>
                  <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title"><asp:Label ID="lbUserName" runat="server"></asp:Label></div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="useraccounts.aspx">User Accounts</a> &raquo; Case List</div>
      <div id="whiteArea">
     <div>
       <asp:GridView AllowPaging="true" ID="myGrid"  DataKeyNames="record_id" AllowSorting="true" PageSize="20" Width="99%" CellPadding="5" CellSpacing="1" GridLines="None" AutoGenerateColumns="false" DataSourceID="mydata"  runat="server">
    <Columns>
        <asp:TemplateField ItemStyle-Width="30px"  HeaderText="S.No">  <ItemTemplate>    <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
        <asp:ButtonField DataTextField="Tracking_no"  HeaderText="Tracking No" ButtonType="Link" CommandName="select"/> 
        <asp:BoundField ItemStyle-Width="150px" DataField="Action" HeaderText="Action"  />  
        <asp:BoundField DataField="Action_Desc" HtmlEncode=false  HeaderText="Action Desc"/>  
        <asp:BoundField ItemStyle-Width="70px" DataFormatString="{0:d}" DataField="Action_Date" HeaderText="Action Date"/>  
    </Columns>
    <PagerSettings   Mode="NumericFirstLast"  FirstPageText="<<" LastPageText=">>" /> 
    </asp:GridView>   
    <asp:SqlDataSource ID="mydata" ConnectionString="" runat="server" ></asp:SqlDataSource> 
    </div>
    </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
     </form>
</div>
<script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorneyclientmanager" Codebehind="clientmanager.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="container">
<form runat="server">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
    <li><a href="home.aspx"><b>Home</b></a></li>
      <li><a href="cases.aspx"><b>Cases</b></a></li>
      <li class="current"><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Account's</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul></asp:Label>
    <div id="contentArea2">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="right" class="topbar_sub_bg">Search. <asp:TextBox ID="txtCompanyName" runat="server" Width="160px"></asp:TextBox>&nbsp;<asp:Button 
                        ID="txtSearch" runat="server" UseSubmitBehavior="true" Text="&nbsp;GO&nbsp;" /></td>
                  <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Client Manager</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="newclient.aspx">Client Manager</a> &raquo; Client(s) List</div>
      <div id="whiteArea">
        <h2></h2>
        <div align="right"><a href="newclient.aspx"><em><strong>Create New Client</strong></em></a></div>
        <asp:GridView ID="gvEmployees" Width="100%"  AutoGenerateColumns="false" AllowPaging="true"  AllowSorting="true" onsorting="gvEmployees_Sorting"  
              PageSize="20"  runat="server" DataKeyNames="Companyid" onpageindexchanged="gvEmployees_PageIndexChanged" 
              onpageindexchanging="gvEmployees_PageIndexChanging" 
                        onrowcommand="gvEmployees_RowCommand">
        <Columns>
            <asp:TemplateField ItemStyle-Width="30px"  HeaderText="S.No" >  <ItemTemplate>    <%# Container.DataItemIndex + 1 %>  </ItemTemplate></asp:TemplateField>
            <asp:ButtonField ButtonType="Link" DataTextField="Legal_Name" SortExpression="Legal_Name"  Text="" HeaderText="Company Name" CommandName="Show" />
            <asp:BoundField DataField="Person_FullName" HeaderText="Contact Name" SortExpression="Person_FullName" />
            <asp:BoundField DataField="Person_Email" HeaderText="Person Email" SortExpression="Person_Email" />
            <asp:BoundField DataField="LastLogged_On" NullDisplayText="--"  HeaderText="Last Logged On" SortExpression="LastLogged_On" />
            <asp:TemplateField >
                <ItemTemplate>
                    <a href="mailto:<%#DataBinder.Eval(Container.DataItem, "Person_Email")%>?Subject=Welcome%20to%20ACLG%20Client%20Management%20System&Bcc=support@webformcast.com&Body=Dear%20<%#DataBinder.Eval(Container.DataItem, "Person_FullName")%>%0D%0A%0D%0AThank%20you%20very%20much%20for%20choosing%20to%20do%20business%20with%20our%20law%20firm.%20Please%20be%20assured%20that%20I%20am%20available%20to%20you%2024/7%20and%20365.%20My%20direct%20contact%20numbers%20are%20as%20follows%3A%0D%0A%0D%0A617%20830%204545%0D%0A%0D%0A781%20267%203234%28Cell%20phone%29.%0D%0A%0D%0APlease%20click%20on%20the%20link%20below%20and%20use%20the%20login%20and%20password%20to%20use%20our%20state%20of%20the%20art%20client%20management%20system.%20Please%20complete/update%20your%20information%20in%20the%20My%20Account%20page.%20After%20you%20complete%20the%20information%2C%20please%20save%20and%20submit%20the%20form.%20An%20attorney%20will%20get%20in%20touch%20with%20you%20within%2048%20hours%20if%20we%20should%20have%20any%20questions.%0D%0A%0D%0Ahttp://webformcast.azurewebsites.net/employer/index.aspx%0D%0A%0D%0AUsername%20%3A%20<%#DataBinder.Eval(Container.DataItem, "Person_Email")%>%0D%0APassword%20%3A%20<%#DataBinder.Eval(Container.DataItem, "password")%>%0D%0A%0D%0AThank%20you%2C%0D%0A%20%0D%0ASrinivas%20Ramineni%2C%20Esq.%0D%0AAmerican%20Consumer%20Law%20Group%2C%20LLC%0D%0A2%20Winter%20Street%2C%20Suite%20203%0D%0AWaltham%20%2C%20MA%2002451%0D%0A617%20580%203030%20%28Ph%29%0D%0A781%20517%200152%20%28Fax%29">Mail User Info</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField ButtonType="Link" Text="Edit" HeaderText="Action" CommandName="Edit" />
            <asp:ButtonField ButtonType="Link" Text="Login" HeaderText="Action" CommandName="Login" />
        </Columns>
        <PagerSettings   Mode="NumericFirstLast"   FirstPageText="<<" LastPageText=">>" />
        </asp:GridView>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
<script src="../scripts/content.js" type="text/javascript"></script>
<%=strScript%>
</body>
</html>

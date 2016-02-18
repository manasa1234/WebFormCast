<%@ Page Language="C#" AutoEventWireup="true" Inherits="cases" Codebehind="cases.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form runat="server" defaultbutton="txtSearch">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
      <li><a href="home.aspx"><b>Home</b></a></li>  
      <li class="current"><a href="cases.aspx"><b>Cases</b></a></li>
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul></asp:Label>
    <div id="contentArea1">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="right" class="topbar_sub_bg">Clients <asp:DropDownList 
                        AutoPostBack="true" ID="ddEmployer" style="width:200px" runat="server" 
                        onselectedindexchanged="ddEmployer_SelectedIndexChanged" EnableViewState="true" ></asp:DropDownList><br /><br />
                  Search. <asp:TextBox ID="txtTrackingNo" runat="server" Width="160px"></asp:TextBox>&nbsp;<asp:Button 
                        ID="txtSearch" runat="server" UseSubmitBehavior="true" Text="&nbsp;GO&nbsp;" onclick="txtSearch_Click" />
                  <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title"><asp:Label ID="lbClientName" runat="server"></asp:Label></div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="#"><asp:Label ID="lbCompanyName1" runat="server"></asp:Label></a> &raquo; List of Employees</div>
      <div id="whiteArea">
      <div align="right"><a href="case.aspx?action=new"><b>Create New Case</b></a></div>
      <asp:GridView ID="gvEmployees" Width="100%"  AutoGenerateColumns="False" AllowPaging="True" 
              PageSize="20"  runat="server" DataKeyNames="Employee_id" onpageindexchanged="gvEmployees_PageIndexChanged" 
              onpageindexchanging="gvEmployees_PageIndexChanging" 
                        onrowcommand="gvEmployees_RowCommand">
        <Columns>
            <asp:TemplateField ItemStyle-Width="20px"  HeaderText="S.No" >  <ItemTemplate>    <%# Container.DataItemIndex + 1 %>  </ItemTemplate>

<ItemStyle Width="20px"></ItemStyle>
            </asp:TemplateField>
            <asp:BoundField  ItemStyle-Width="65px" DataField="Tracking_No" HeaderText="Tracking ID" >
<ItemStyle Width="65px"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ItemStyle-Width="100px" DataTextField="FullName"  HeaderText="Employee Name" ButtonType="Link" CommandName="select" > 
<ItemStyle Width="100px"></ItemStyle>
            </asp:ButtonField>
            <asp:BoundField ItemStyle-Width="60px" DataField="Visa_Type_Name" HeaderText="Type" >
<ItemStyle Width="60px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="Comments" HeaderText="Comments" />
            <asp:BoundField ItemStyle-Width="50px" DataField="Status" ItemStyle-Wrap="false" HeaderText="Status" >
<ItemStyle Wrap="False" Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="50px" DataField="DateFiled" HeaderText="Date Filed" >
<ItemStyle Width="50px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField ItemStyle-Width="60px" DataField="ReceiptNo" HeaderText="Reciept Number" >
<ItemStyle Width="60px"></ItemStyle>
            </asp:BoundField>
            <asp:ButtonField ItemStyle-Width="40px" ButtonType="Link" Text="Edit" CommandName="edit" > 
<ItemStyle Width="40px"></ItemStyle>
            </asp:ButtonField>
        </Columns>
         <PagerStyle Font-Bold="true" /> 
         <PagerSettings   Position="Bottom"  Mode="NumericFirstLast"   FirstPageText="<<" LastPageText=">>" />
         
         
        </asp:GridView>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
<script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>



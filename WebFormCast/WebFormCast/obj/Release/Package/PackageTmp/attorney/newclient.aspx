<%@ Page Language="C#" AutoEventWireup="true" Inherits="newclient" Codebehind="newclient.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form runat="server">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
  <asp:Label ID="lbNavigation" runat="server">
    <ul class="topNav">
    <li><a href="home.aspx"><b>Home</b></a></li>
      <li><a href="cases.aspx"><b>Cases</b></a></li>
      <li class="current"><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    </asp:Label>
    <div id="contentArea2">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Creating New Client</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="clientmanager.aspx">Client Manager</a> &raquo; Case List</div>
      <div id="whiteArea"  align="center" >
      <asp:Label ID="txtMessage" runat="server"></asp:Label>
      <asp:Panel ID="panDisp" runat="server">
        <table  border="0" align="center" cellpadding="0" cellspacing="0">
            <tr><th align="left">Company Name</th><td align="left"><asp:TextBox Width="250" ID="txtCompanyName" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ControlToValidate="txtCompanyName" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator></td></tr>
            <tr><th align="left">Short Name</th><td align="left"><asp:TextBox Width="50" MaxLength="5" ID="txtShortName" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtShortName" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator><asp:Label ID="lbShortName" runat="server" ForeColor="Red"></asp:Label></td></tr>
            <tr><th align="left">Contact Person Name</th><td align="left"><asp:TextBox Width="200" ID="txtPerson_Name" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="rf1" ControlToValidate="txtPerson_Name" ErrorMessage="*" runat="server"/> </td></tr>
            <tr><th align="left">Contact Person Email</th><td align="left"><asp:TextBox Width="200" ID="txtPerson_Email" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="rf2" ControlToValidate="txtPerson_Email" ErrorMessage="*" runat="server"/><asp:Label ID="lbEmail" runat="server" ForeColor="Red"></asp:Label> </td></tr>
            <tr><th align="left">Password</th><td align="left"><asp:TextBox Width="200" ID="TextBox1" Text="********" ReadOnly="true" runat="server"></asp:TextBox>&nbsp;<asp:Label Text="(Auto generated)" Font-Size="Smaller" ForeColor="GrayText" runat="server"></asp:Label></td></tr>
            <tr><td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Create New Client" 
                    onclick="btnSave_Click"/><br />
                <!--Note:When you submit this form an auto-generated mail will send to employeer with login information. -->
            </td></tr>
        </table>
        </asp:Panel>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
</html>

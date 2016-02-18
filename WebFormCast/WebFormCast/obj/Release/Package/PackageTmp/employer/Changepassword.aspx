<%@ Page Language="C#" AutoEventWireup="true" Inherits="employer_Changepassword" Codebehind="Changepassword.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
<link href="../css/calendar-tas.css" rel="stylesheet" type="text/css" />
<script src="../calendar.js" type="text/javascript"></script>
<script src="../lang/calendar-en.js" type="text/javascript"></script>
<script src="../calendar-setup.js" type="text/javascript"></script>
<script src="../scripts/mootools.js" type="text/javascript"></script>
<script src="../scripts/fadescript.js" type="text/javascript"></script>
</head>
<body>
<form id="Form1" runat="server">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <ul class="topNav">
      <li><a href="employer.aspx"><b>Home</b></a></li>
      <li><a href="employer_manage.aspx"><b>Add New Employee</b></a></li>
      <li class="current"><a href="employer_myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    <div id="contentArea3">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">My Account</div>
      <div class="bcru"><a href="employer.aspx">Home</a> &raquo; <a href="employer_myaccount.aspx">My Account</a>&raquo; Change Password</div>
      <div id="whiteArea">
      <center>
        <table border="0" cellpadding="0" cellspacing="0">
          <tr>
            <th colspan="4">Change Password</th>
          </tr>
          <tr>
            <td>Old Password</td>
            <td><asp:TextBox ID="txtPassword"  runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtPassword" runat="server" ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator> </td>
          </tr>
          <tr>
            <td>New Password</td>
            <td><asp:TextBox ID="txtPassword1"  runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPassword1" runat="server" ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator></td>
          </tr>
                    <tr>
            <td>Confirm Password</td>
            <td><asp:TextBox ID="txtPassword2"  runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword2" runat="server" ErrorMessage="*" Display="Static"></asp:RequiredFieldValidator><br /> <asp:CompareValidator runat="server" ControlToValidate="txtPassword2" ControlToCompare="txtPassword1" ErrorMessage="Confirm password not match"></asp:CompareValidator>  </td>
          </tr>
          <tr>
            <td colspan="2" align="center"><asp:Button ID="btnSubmit" runat="server" 
                    Text="Submit" onclick="btnSubmit_Click" /></td>
          </tr>
        </table>
        <asp:Label ID="lbMsg" runat="server" Font-Bold="true"></asp:Label>
        </center>
      </div>
    </div>
  </div>
<div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
<input id="flag" value="1" type="hidden"/>
<div id="loading"  runat="server"></div>
</form>
</body>
</html>




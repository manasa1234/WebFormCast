﻿<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_usersaccounts" Codebehind="useraccounts.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="container">
<form id="form1" name="form1" method="post" action="<%=strAction%>">
<div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
  <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
      <li class="current"><a href="home.aspx"><b>Home</b></a></li>
      <li><a href="cases.aspx"><b>Cases</b></a></li>
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul></asp:Label>
    <div id="contentArea3">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">User Accounts</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="useraccounts.aspx">User Accounts</a> &raquo; Case List</div>
      <div id="whiteArea">
      
        <div align="right"><a href="useraccounts.aspx?action=new"><em><strong>Create New User</strong></em></a></div>
        <table width="100%" align="center" cellpadding="4" cellspacing="0" border="0">
        <tr>
            <th ></th>
            <th >S.No</th>
            <th >User Name</th>
            <th >Password</th>
            <th >Display Name</th>
            <th >Type</th>
            <th >Last Accessed On</th>
        </tr>
        <%=strBody%>
        </table>
       
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
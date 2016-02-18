<%@ Page Language="VB" AutoEventWireup="false" Inherits="attorney_casespending" Codebehind="vtest.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="Form1" runat="server">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
      <li class="current"><a href="home.aspx"><b>Home</b></a></li>  
      <li ><a href="cases.aspx"><b>Cases</b></a></li>
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
                <td align="right" class="topbar_sub_bg">
                <table border="0" cellspacing="0" cellpadding="5">
                    <tr>
                      <td>&raquo; <a href="home.aspx">New Cases</a></td>
                      <td>&raquo; <a href="casespending.aspx">Pending Cases</a></td>
                      <td>&raquo; <a href="unsubmitedcases.aspx">Client Un-Approved Cases</a></td>
                    </tr>
            </table>
                </td>
                  <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title"><asp:Label ID="lbClientName" runat="server"></asp:Label></div>
      <div class="bcru"><a href="home.aspx">Home</a> &raquo; Panding Cases</div>
      
      <div id="whiteArea">
      <strong>Select days:</strong><asp:Calendar ID="cale" runat="server" CellPadding="0" ></asp:Calendar>
          <table width="100%" cellpadding="0" cellspacing="0" border="0">
        <tr>
            <th>S.No</th>
            <th width="75">Tracking ID</th>
            <th>Name</th>
            <th>Date Filed</th>
            <th>Receipt No</th>
            <th>Comments</th>
            <th>Due Date</th>
            <th>Inv No</th>
            <th>Type</th>
            <!--<th width="80" >Status</th>-->
            <th>Log</th>
        </tr>
        <%=strBody%>
    </table>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
<script src="../scripts/content.js" type="text/javascript"></script>
</html>
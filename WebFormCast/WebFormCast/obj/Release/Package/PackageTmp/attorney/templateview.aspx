<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorneytemplateview" Codebehind="templateview.aspx.cs" %>
<%@ Register Src="~/attorney/searchbox.ascx" TagName="SearchBox" TagPrefix="SB"%>
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
</head>
<body>
<form id="Form1" runat="server">
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
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li class="current"><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    </asp:Label>
    <div id="contentArea1">
<table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg"><SB:SearchBox id="MySearch" Runat="Server"></SB:SearchBox>
            <table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="left" class="topbar_sub_bg">
                <asp:Label ID="lbFormLinks" runat="server"></asp:Label></td>
                <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Employee</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="home.aspx"><asp:Label ID="lbCompanyName" runat="server"></asp:Label></a> &raquo; <a href="employeeview.aspx"><asp:Label ID="lbtrackingno" runat="server"></asp:Label></a> &raquo; Form - G28</div>
       <div id="whiteArea">
      <table width="100%"   style="border:0px" cellspacing="0" cellpadding="0">
        <tr><td width="50%" style="border:0px"><h2><asp:Label ID="lbTemplate" runat="server"></asp:Label></h2></td>
            <td style="border:0px" align="right" valign="top" width="50%">
                                <asp:HyperLink id="hlDelete" Text="Delete" Font-Bold="true" NavigateUrl="templatedit.aspx" runat="server"></asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:HyperLink id="hlEdit" Text="Edit" Font-Bold="true" NavigateUrl="templatedit.aspx" runat="server"></asp:HyperLink>
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink Target="_blank" ID="hlDownloadPdf" runat="server" 
                                    Font-Bold="True" Text="Download PDF"></asp:HyperLink> </td></tr>
      </table>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr><td><asp:Label ID="lbTemplatebody" runat="server"></asp:Label></td></tr>
        </table>
        <div align="center" class="divBlock">
          <asp:Button ID="btnCancel" runat="server" Text="Back" />
        </div>
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

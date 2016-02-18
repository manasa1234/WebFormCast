<%@ Page Language="C#" AutoEventWireup="true" Inherits="employer_manage" Codebehind="employer_manage.aspx.cs" %>

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
    <ul class="topNav">
      <li><a href="employer.aspx"><b>Home</b></a></li>
      <li class="current"><a href="employer_manage.aspx"><b>Add New Employee</b></a></li>
      <li><a href="employer_myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    <div id="contentArea2">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Manage Employees</div>
      <div class="bcru"><a href="employer.aspx">Home</a> &raquo; Manage Employees</div>
      <div id="whiteArea">
      <asp:Panel ID="panForm" runat="server" HorizontalAlign="Center" >
        <table width="90%"  border="0" cellpadding="0" cellspacing="0">
          <tr>
            <th colspan="4" align="center"><asp:Label ID="lbMeg"  ForeColor="Green"   Font-Bold="true" runat="server"></asp:Label><asp:RegularExpressionValidator  ID="regexpusername" runat="server" ValidationExpression ="^(['_a-zA-Z0-9-]+)(\.['_a-zA-Z0-9-]+)*@([a-zA-Z0-9-]+)(\.[a-zA-Z0-9-]+)*(\.[a-zA-Z]{2,3})$" ControlToValidate ="txtEmail_Address" ErrorMessage ="must enter a working email address." Display="Dynamic"></asp:RegularExpressionValidator></th>
          </tr>
          <tr>
            <td align="right">First Name</td>
            <td><asp:TextBox ID="txtFirst_Name" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ControlToValidate="txtFirst_Name" Display="Dynamic" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
            <td align="right">Last Name</td>
            <td><asp:TextBox ID="txtLast_Name" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ControlToValidate="txtLast_Name" Display="Dynamic"  runat="server" ErrorMessage="*"/></td>
          </tr>
          <tr>  
            <td align="right">Email</td>
            <td><asp:TextBox ID="txtEmail_Address" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmail_Address" Display="Dynamic"  runat="server" ErrorMessage="*"/></td>
            <td align="right">Job Title</td>
            <td><asp:DropDownList ID="ddJobTitle" runat="server"></asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" ControlToValidate="ddJobTitle" Display="Dynamic"  runat="server" ErrorMessage="*"/> </td>
          </tr>
          <tr>
            <td align="right">Type</td>
            <td><asp:DropDownList ID="ddType" runat="server"></asp:DropDownList><asp:RequiredFieldValidator ControlToValidate="ddType" runat="server" ErrorMessage="*" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">&nbsp;</td>
          </tr>
          <tr>
            <th colspan="10"><asp:Button ID="btnSave" runat="server" Text="&nbsp;&nbsp;Save&nbsp;&nbsp;" 
                    onclick="btnSave_Click" />
                    <asp:Button Visible="false" ID="btnSaveEmail" runat="server" Text="Save &amp; Send Email" 
                    onclick="btnSaveEmail_Click" /></th>
          </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="panDisplay" runat="server" HorizontalAlign="Center" Height="300px">
        <br /><br /><br/>
        <p>New employee <asp:Label ID="lbFirstName" ForeColor="#006699" Font-Bold="true" runat="server"></asp:Label>&nbsp;<asp:Label ForeColor="#006699"  id="lbLastName"  Font-Bold="true"  runat="server"></asp:Label> has been created with tracking no <asp:Label ForeColor="#006699"  ID="lbTrackingNo"  Font-Bold="true"  runat="server"></asp:Label>. Please click on the this <asp:HyperLink ID="hlEmail" Text="Email" Font-Underline =true  runat="server"></asp:HyperLink> link to send the Login details.</p>
        <p>Note: Email can also be sent later to the employee by clicking on the Email link for the employee from the HOME page</p>
        <asp:Label id="lbCreated" runat="server">
        </asp:Label>
        </asp:Panel>
        <br />
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" Inherits="attoreymyaccount" Codebehind="myaccount.aspx.cs" %>
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
      <li><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accoun t's</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li class="current"><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    </asp:Label>
    <div id="contentArea1">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">My Account</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; My Account</div>
      <div id="whiteArea">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="50%" valign="top" >
            <center> <asp:Label ID="lbmsg" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label></center>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td align="right">Name</td>
                <td><asp:TextBox ID="txtName" Width="250" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ControlToValidate="txtName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
              </tr>
              <tr>
                <td align="right">Firm Name</td>
                <td><asp:TextBox ID="txtFirmName" Width="250" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RFFirmName" ControlToValidate="txtFirmName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator></td>
              </tr>
              <tr>
                <td align="right">Address</td>
                <td>
                    <asp:TextBox ID="txtSuite" runat="server"></asp:TextBox><asp:Label Font-Size="Small" Text="(Suite #)" ForeColor="GrayText" runat="server"></asp:Label><br />
                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox><asp:Label ID="Label2" Font-Size="Small"   Text="(Number & Street)" ForeColor="GrayText" runat="server"></asp:Label><br />
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox><asp:Label ID="Label3" Font-Size="Small" Text="(City)" ForeColor="GrayText" runat="server"></asp:Label><br />
                    <asp:TextBox ID="txtState" runat="server"></asp:TextBox><asp:Label ID="Label5" Font-Size="Small" Text="(State)" ForeColor="GrayText" runat="server"></asp:Label><br />
                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox><asp:Label ID="Label6" Font-Size="Small" Text="(Zip Code)" ForeColor="GrayText" runat="server"></asp:Label><br />
                </td>
              </tr>
              <tr>
                <td align="right">Tel</td>
                <td>
                    <asp:TextBox ID="txtTel_Code"  Width="50" runat="server"/>-<asp:TextBox ID="txtTel"  Width="150" runat="server"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTel" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br /><asp:Label ID="Label1" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Code)"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Phone No)"></asp:Label>
                 </td>
              </tr>
              
              <tr>
                <td align="right">Fax</td>
                <td><asp:TextBox ID="txtFax" runat="server" Width="150" ></asp:TextBox></td>
              </tr>
              <tr>
                <td align="right">Email</td>
                <td><asp:TextBox ID="txtEmail" runat="server" Width="150" ></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> </td>
              </tr>
              <tr>
                <td align="right">ATTY State License #</td>
                <td><asp:TextBox ID="txtAttyStateLicense" runat="server" Width="150" ></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAttyStateLicense" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator> </td>
              </tr>
            <tr>
                <td colspan="2" align="center"><asp:Button ID="btnSave" Text="  Save  " 
                        runat="server" onclick="btnSave_Click" /> </td>
              </tr>
            </table></td>
            <td valign="top"><h3>Package  Details</h3>
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><p>&nbsp;</p>
                  <p>&nbsp;</p>
                  <p>&nbsp;</p>
                  <p>&nbsp;</p></td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td><p>&nbsp;</p>
                  <p>&nbsp;</p>
                  <p>&nbsp;</p>
                  <p>&nbsp;</p></td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr>
                  <td><p>&nbsp;</p>
                  <p>&nbsp;</p>
                  <p>&nbsp;</p>
                  <p>&nbsp;</p>
                  </td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
              </table>              <p>&nbsp;</p></td>
          </tr>
        </table>
        </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" Inherits="employer_index" Codebehind="index.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title> American Consumer Law Group</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" Text="Welcome to Client Management System"  runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">&nbsp;</div>
  </div>
  <div id="contentShadows">
    <ul class="topNav"></ul>
    <div id="contentArea1">
      <div class="bcru">Login</div>
      <div align="center" id="whiteArea"><br />
        <br />
        <form id="Form1" runat="server">
        <asp:Label ID="lbmsg" runat="server" ForeColor="Red"></asp:Label>
        <table width="210" border="0" cellspacing="0" cellpadding="0" style="border:0">
          <tr>
            <td style="border:0; padding:10px; background-image:url(../images/login_bg.gif)"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="border:0">
              <tr>
                <td style="border:0; font-weight:bold; font-size:12px; color:#43576c" align="center">Username</td>
              </tr>
              <tr>
                <td style="border:0" align="center"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
              </tr>
              <tr>
                <td style="border:0; font-weight:bold; font-size:12px; color:#43576c" align="center">Password</td>
              </tr>
              <tr>
                <td style="border:0" align="center"><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox></td>
              </tr>
              <!--
              <tr>
                <td style="border:0"><input type="checkbox" name="checkbox2" id="checkbox2" />
                  Remember Me</td>
              </tr>
              <tr>
                <td style="border:0"><a href="#">Forgot Password?</a></td>
              </tr>
              -->
            </table></td>
          </tr>
          <tr>
            <td style="border:0; padding:0">
                    <asp:ImageButton ID="btnLogin" runat="server" Text="Login" 
                    onclick="btnLogin_Click" ImageUrl="../images/login_btn.gif" Width="210" Height="41"  />
                    </td>
          </tr>
        </table>
        </form>
        <br />
        <br />
      </div>
    </div>
  </div>
 <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" EnableViewStateMac="false" Inherits="attorney_index" Codebehind="Index.aspx.cs" %>

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
  <div id="header"><img src="../images/logo.gif" width="160" height="45" /></div>
  <div id="contentShadows">
    <ul class="topNav"></ul>
    <div id="contentArea1">
      <div class="bcru">Login</div>
      <div id="whiteArea">
      <center><asp:Label ID="lbmsg" runat="server" ForeColor="Red"></asp:Label> </center>
        <table border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td>Username</td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td>Password</td>
            <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <td colspan="2"><input type="checkbox" name="checkbox" id="checkbox" />
            Remember Me</td>
          </tr>
          <tr>
            <th colspan="2"><asp:Button  ID="btnLogin" runat="server" Text="Login" 
                    onclick="btnLogin_Click" /> </th>
          </tr>
        </table>
        </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
    </form>
</div>
</body>
</html>


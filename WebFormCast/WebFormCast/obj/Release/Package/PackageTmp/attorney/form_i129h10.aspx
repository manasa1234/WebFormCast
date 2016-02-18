<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h10" Codebehind="form_i129h10.aspx.cs" %>
<%@ Register Src="~/attorney/searchbox.ascx" TagName="SearchBox" TagPrefix="SB"%>
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
    <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
    <li><a href="home.aspx"><b>Home</b></a></li>
      <li  class="current"><a href="cases.aspx"><b>Cases</b></a></li>
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
          <td class="topbar_bg"><SB:SearchBox id="MySearch" Runat="Server"></SB:SearchBox>
            <table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="left" class="topbar_sub_bg"><asp:Label ID="lbFormLinks" runat="server"></asp:Label></td>
                <td width="2"><img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
              </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">Client Name</div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="home.aspx"><asp:Label ID="lbCompanyName" runat="server"></asp:Label></a> &raquo; <a href="employeeview.aspx"><asp:Label ID="lbtrackingno" runat="server"></asp:Label></a> &raquo; Form - I-129H</div>
      <div id="whiteArea">
                <table width="100%"   style="border:0px" cellspacing="0" cellpadding="0">
        <tr><td width="50%" style="border:0px"><h2>Form I-129H</h2></td><td style="border:0px" align="right" valign="top" width="50%"><asp:HyperLink Target="_blank" ID="hlDownloadPdf" runat="server" Font-Bold="true" Text="Download PDF"></asp:HyperLink> </td></tr>
      </table>
       <div class="pageNum" runat="server" id="divSublinks"></div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="50%" valign="top"><strong>Department of Homeland Security</strong><br />
              U.S. Citizenship and Immigration Services</td>
            <td align="right" valign="top">OMB No.1615-0009; Expires 05/31/08
              <h4>H Classification Supplement 
                to Form I-129</h4></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="left">Section 4. Complete this section if filing for H-3 classification.</th>
          </tr>
          <tr>
            <td><p><strong>1.</strong> If you answer &quot;yes&quot; to any of the following questions, attach a full explanation.</p>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td><strong>a.</strong> Is the training you intend to provide, or similar training, available in the alien's country?</td>
                    <td><input type="radio" name="radio61" id="radio61" value="radio61" />
                      No</td>
                    <td><input type="radio" name="radio61" id="radio62" value="radio61" />
                      Yes</td>
                  </tr>
                  <tr>
                    <td><strong>b.</strong> Will the training benefit the alien in pursuing a career abroad?</td>
                    <td><input type="radio" name="radio63" id="radio63" value="radio63" />
                      No</td>
                    <td><input type="radio" name="radio63" id="radio68" value="radio63" />
                      Yes</td>
                  </tr>
                  <tr>
                    <td><strong>c. </strong>Does the training involve productive employment incidental to training?</td>
                    <td><input type="radio" name="radio64" id="radio64" value="radio64" />
                      No</td>
                    <td><input type="radio" name="radio64" id="radio69" value="radio64" />
                      Yes</td>
                  </tr>
                  <tr>
                    <td><strong>d. </strong>Does the alien already have skills related to the training?</td>
                    <td><input type="radio" name="radio65" id="radio65" value="radio65" />
                      No</td>
                    <td><input type="radio" name="radio65" id="radio70" value="radio65" />
                      Yes</td>
                  </tr>
                  <tr>
                    <td><strong>e. </strong>Is this training an effort to overcome a labor shortage?</td>
                    <td><input type="radio" name="radio66" id="radio66" value="radio66" />
                      No</td>
                    <td><input type="radio" name="radio66" id="radio71" value="radio66" />
                      Yes</td>
                  </tr>
                  <tr>
                    <td><strong>f. </strong>Do you intend to employ the alien abroad at the end of this training?</td>
                    <td><input type="radio" name="radio67" id="radio67" value="radio67" />
                      No</td>
                    <td><input type="radio" name="radio67" id="radio72" value="radio67" />
                      Yes</td>
                  </tr>
              </table></td>
          </tr>
          <tr>
            <td><strong>2.</strong> If you do not intend to employ this person abroad at the end of this training, explain why you wish to incur the cost of providing 
              this training and your expected return from this training.</td>
          </tr>
          <tr>
            <td><textarea name="textfield101" rows="12" id="textfield141" style="width:600px"></textarea></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="right">Form I-129 Supplement H (Rev. 07/30/07)Y</td>
          </tr>
        </table>
        <br />
        <div align="center" class="divBlock">
          <asp:Button ID="btnSubmit" runat="server" Text="Submit &amp; Continue" 
                onclick="btnSubmit_Click"/>
          <input type="submit" name="Cancel" id="Cancel" value="Cancel" />
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

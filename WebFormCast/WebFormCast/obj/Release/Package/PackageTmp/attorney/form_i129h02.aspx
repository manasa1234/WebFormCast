<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h02" Codebehind="form_i129h02.aspx.cs" %>
<%@ Register Src="~/attorney/searchbox.ascx" TagName="SearchBox" TagPrefix="SB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form  runat="server">
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
            <td align="right" valign="top">OMB No. 1615-0009; Expires 10/31/2013
              <h4> I-129, Petition for a 
                Nonimmigrant Worker</h4></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th colspan="3" align="left">Part 2. Information about this petition.<br />
                <span style="font-weight:normal">(See instructions for fee information.)</span></th>
          </tr>
          <tr>
            <td colspan="3">&nbsp;</td>
          </tr>
          <tr>
            <th>1.</th>
            <th colspan="2" align="left">Requested Nonimmigrant Classification. (Write classification symbol):
              <asp:TextBox ID="txtf2_RequestedNonimmigrantClassification" CssClass="input_edit" runat="server"></asp:TextBox>  </th>
          </tr>
          <tr>
            <th width="20">2.</th>
            <th colspan="2" align="left">Basis for Classification <span style="font-weight:normal">(Check one):</span></th>
          </tr>
          <tr>
            <td rowspan="6">&nbsp;</td>
            <td width="35">a.
              <asp:RadioButton CssClass="input_normal_wb" ID="rbf2_BasisforClassification_a" GroupName="BasisforClassification" runat="server" /></td>
            <td>New employment (including new employer filing H-1B extension).</td>
          </tr>
          <tr>
            <td>b.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_BasisforClassification_b" GroupName="BasisforClassification" runat="server" /></td>
            <td>Continuation of previously approved employment without change with the 
              same employer.</td>
          </tr>
          <tr>
            <td>c.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_BasisforClassification_c" GroupName="BasisforClassification" runat="server" /></td>
            <td>Change in previously approved employment.</td>
          </tr>
          <tr>
            <td>d.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_BasisforClassification_d" GroupName="BasisforClassification" runat="server" /></td>
            <td>New concurrent employment.</td>
          </tr>
          <tr>
            <td>e.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_BasisforClassification_e" GroupName="BasisforClassification" runat="server" /></td>
            <td>Change of employer.</td>
          </tr>
          <tr>
            <td>f.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_BasisforClassification_f" GroupName="BasisforClassification" runat="server" /></td>
            <td>Amended petition.</td>
          </tr>
          <tr>
            <th width="20">3.</th>
            <th colspan="2" align="left"><span style="font-weight:normal">Provide the most recent petition/application receipt number for the beneficiary. If none exists, indicate "N/A."</span></th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="2"><asp:TextBox ID="txtPreReceiptNo"  CssClass="input_edit" runat="server"/></td>
          </tr>
          <tr>
            <th>4.</th>
            <th colspan="2" align="left">Requested Action.<span style="font-weight:normal"> (Check one):</span></th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td width="35" valign="top">a.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_RequestedAction_a" GroupName="RequestedAction" runat="server" /> </td>
            <td>Notify the office in<strong> Part 4 </strong>so the person(s) can obtain a visa or be admitted.<br />
              (<strong>NOTE:</strong> a petition is not required for an E-1, E-2 or R visa).</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td valign="top">b.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_RequestedAction_b" GroupName="RequestedAction" runat="server" /></td>
            <td>Change the person(s)' status and extend their stay since the person(s) are all 
              now in the U.S. in another status (see instructions for limitations). This is 
              available only where you check &quot;New Employment&quot; in <strong>Item 2</strong>, above.</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td valign="top">c.
             <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_RequestedAction_c" GroupName="RequestedAction" runat="server" /></td>
            <td>Extend the stay of the person(s) since they now hold this status.</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td valign="top">d.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_RequestedAction_d" GroupName="RequestedAction" runat="server" /></td>
            <td>Amend the stay of the person(s) since they now hold this status.</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td valign="top">e.
              <asp:RadioButton CssClass="input_normal_wb"  ID="rbf2_RequestedAction_e" GroupName="RequestedAction" runat="server" /></td>
            <td>Extend the status of a nonimmigrant classification based on a Free Trade 
              Agreement. (See Free Trade Supplement for TN and H1B1 to Form I-129).</td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td valign="top">f.
             <asp:RadioButton  CssClass="input_normal_wb"  ID="rbf2_RequestedAction_f" GroupName="RequestedAction" runat="server" /></td>
            <td>Change status to a nonimmigrant classification based on a Free Trade 
              Agreement. (See Free Trade Supplement for TN and H1B1 to Form I-129).</td>
          </tr>
          <tr>
            <th valign="top">5.</th>
            <th colspan="2" align="left">Total number of workers in petition<span style="font-weight:normal"> (See instructions
              relating to when more than one worker can be included):
              <asp:TextBox  ID="txtf2_Totalnumberofworkersinpetition"  CssClass="input_edit"  runat="server"></asp:TextBox>
            </span></th>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="right">Form I-129 (Rev. 11/23/10)N</td>
          </tr>
        </table>
        <br />
        <div align="center" class="divBlock">
          <asp:Button ID="btnSave" runat="server" Text="Submit &amp; Continue" 
                onclick="btnSave_Click" />&nbsp;<asp:Button ID="btnCancel" Text="Cancel" runat="server" />
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

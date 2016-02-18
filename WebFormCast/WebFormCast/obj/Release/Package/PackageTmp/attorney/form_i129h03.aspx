<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h03" Codebehind="form_i129h03.aspx.cs" %>
<%@ Register Src="~/attorney/searchbox.ascx" TagName="SearchBox" TagPrefix="SB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 234px;
        }
    </style>
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
          <td class="topbar_bg"><<SB:SearchBox id="MySearch" Runat="Server"></SB:SearchBox>
            <table border="0" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td width="2"><img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                <td align="left" class="topbar_sub_bg"><asp:Label  ID="lbFormLinks" runat="server"></asp:Label></td>
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
            <th colspan="5" align="left">Part 3. Information about the person(s) you are filing for.<br />
                <span style="font-weight:normal">Complete the blocks below. Use the continuation sheet to name each person included in this petition.</span></th>
          </tr>
          <tr>
            <td colspan="5">&nbsp;</td>
          </tr>
          <tr>
            <th width="20">1.</th>
            <th colspan="4" align="left">If an Entertainment Group, Give the Group Name</th>
          </tr>
          <tr>
            <td rowspan="9">&nbsp;</td>
            <td colspan="4"><asp:TextBox  CssClass="input_edit" Text="&nbsp;" 
                    ID="f3_Entertainment_Group_Name" runat="server" Width="410px"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="2" align="left">Family Name (Last Name)</th>
            <th align="left">Given Name (First Name)</th>
            <th align="left">Full Middle Name</th>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox CssClass="input_edit"  ID="f3_Last_Name" runat="server" 
                    Width="250px"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="f3_First_Name" runat="server" 
                    Width="250px"></asp:TextBox></td>
            <td><asp:TextBox ID="f3_Middle_Name" Width="200"  CssClass="input_edit"  runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4" align="left">All Other Names Used (include maiden name and names from all previous marriages)</th>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox CssClass="input_edit" ID="f3_Other_Name1" 
                    runat="server" Width="250px"></asp:TextBox></td>
            <td><asp:TextBox Width="250px" CssClass="input_edit"  ID="f3_Other_Name2" 
                    runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="f3_Other_Name3" runat="server" 
                    Width="200px"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="2" align="left">Date of Birth (mm/dd/yyyy)</th>
            <th align="left">U.S. Social Security # (if any)</th>
            <th align="left">A # (if any)</th>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox CssClass="input_edit"  ID="f3_Date_of_Birth" 
                    runat="server" Width="100px"></asp:TextBox></td>
            <td><asp:TextBox Width="200px" CssClass="input_edit"  ID="f3_US_Social_Security" 
                    runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="200px" CssClass="input_edit"  ID="f3_Anumber" 
                    runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="2" align="left">Country of Birth</th>
            <th align="left">Province of Birth</th>
            <th align="left">Country of Citizenship</th>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox Width="250px" CssClass="input_edit"  ID="f3_Country_of_Birth" runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="193px" CssClass="input_edit"  ID="f3_Province_of_Birth" 
                    runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="191px" CssClass="input_edit"  
                    ID="f3_Country_of_Citizenship" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th>2.</th>
            <th colspan="4" align="left">If in the United States, Complete the Following:</th>
          </tr>
          <tr>
            <td rowspan="6">&nbsp;</td>
            <th colspan="2" align="left">Date of Last Arrival (mm/dd/yyyy)</th>
            <th align="left">I-94 # (Arrival/Departure Document)</th>
            <th align="left">Current Nonimmigrant Status</th>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox Width="250px" CssClass="input_edit"  ID="f3_Date_of_Last_Arrival" runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="172px" CssClass="input_edit"  ID="f3_I94" runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="196px" CssClass="input_edit"  
                    ID="f3_Current_Nonimmigrant_Status" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th align="left">Date Status Expires (mm/dd/yyyy)</th>
            <th align="left" class="style1">Passport Number</th>
            <th align="left">Date Passport Issued (mm/dd/yyyy)</th>
            <th align="left">Date Passport Expires (mm/dd/yyyy)</th>
          </tr>
          <tr>
            <td><asp:TextBox Width="107px" CssClass="input_edit"  ID="f3_Date_Status_Expires" 
                    runat="server"></asp:TextBox></td>
            <td class="style1"><asp:TextBox Width="110px" CssClass="input_edit"  
                    ID="f3_Passport_Number" runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="98px" CssClass="input_edit"  ID="f3_Date_Passport_Issued" 
                    runat="server"></asp:TextBox></td>
            <td><asp:TextBox Width="122px" CssClass="input_edit"  ID="f3_Date_Passport_Expires" 
                    runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4" align="left">Current U.S. Address</th>
          </tr>
          <tr>
            <td colspan="4"><asp:TextBox CssClass="input_edit"  TextMode="MultiLine" Rows="6" Columns="100" ID="f3_Current_US_Address" runat="server"></asp:TextBox></td>
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
          <asp:Button ID="btnSubmit" runat="server" Text="Submit &amp; Continue" onclick="btnSubmit_Click"/>
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

<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h01" Codebehind="form_i129h01.aspx.cs" %>
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
            <td align="right" valign="top">OMB No. 1615-0009; Expires 10/31/2013
              <h4> I-129, Petition for a 
                Nonimmigrant Worker</h4></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="top">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <th colspan="3" align="left">START HERE</th>
                </tr>
              </table>
              <br />
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <th colspan="3" align="left">Part 1. Petitioner Information<br />
                    <span style="font-weight:normal">(If the employer is an individual, complete Number 1. Organizations complete <strong>Number 2</strong>). Use the mailing address of the petitioner.</span></th>
                </tr>
                <tr>
                  <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                  <th width="20">1.</th>
                  <th align="left" colspan="2">Legal Name of Employer:</th>
                </tr>
                <tr>
                  <td rowspan="4">&nbsp;</td>
                  <th align="left" colspan="3">a. Last Name (Family Name)</th>
                </tr>
                <tr>
                  <td colspan="2"><asp:TextBox   ID="txtLastName" Text="&nbsp;" CssClass="input_edit" 
                          runat="server" Width="520px"></asp:TextBox> </td>
                </tr>
                <tr>
                  <th align="left">b. First Name (Given Name)</th>
                  <th align="left">c. Full Middle Name</th>
                </tr>
                <tr>
                  <td valign="top"><asp:TextBox ID="txtFirstName" Text="&nbsp;" CssClass="input_edit"  
                          runat="server" Width="250px"></asp:TextBox> </td>                
                  <td valign="top"><asp:TextBox ID="txtMiddleName" Text="&nbsp;" CssClass="input_edit"  
                          runat="server" Width="250px"></asp:TextBox> </td>
                </tr>
                <tr>
                  <th width="20">2.</th>
                  <th align="left" colspan="2">Company or Organization:</th>
                </tr>
                <tr>
                  <td rowspan="2">&nbsp;</td>
                  <th align="left" colspan="2">Name of Company or Organization</th>
                </tr>
                <tr>
                  <td valign="top" colspan="2"><asp:TextBox ID="txtCompanyName"  CssClass="input_edit"  runat="server" 
                          Width="510px"></asp:TextBox> </td>
                </tr>

                <tr>
                  <th width="20">3.</th>
                  <th align="left" colspan="2">Mailing Address:</th>
                </tr>
                <tr>
                  <td rowspan="14">&nbsp;</td>
                  <th align="left" colspan="2">a. C/O:(In Care Of, if any)</th>
                </tr>
                <tr>
                  <td colspan="2"><asp:TextBox Width="510px"  ID="txtCareOf" Text="&nbsp;" CssClass="input_edit"  runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                  <th align="left">b. Street Number and Name</th>
                  <th align="left">c. Suite/Apt. #</th>
                </tr>
                <tr>
                  <td><asp:TextBox Width="250px"   ID="txtMailingAddress"  CssClass="input_edit"  runat="server"></asp:TextBox> </td>
                  <td><asp:TextBox Width="250px"  ID="txtSuiteNo"  CssClass="input_edit"  runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                  <th align="left">d. City</th>
                  <th align="left">e. State/Province</th>
                </tr>
                <tr>
                  <td><asp:TextBox Width="250px"  ID="txtCity"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                  <td><asp:TextBox Width="250px"  ID="txtState"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                  <th align="left">f. Country</th>
                  <th align="left">g. Zip/Postal Code</th>
                </tr>
                <tr>
                  <td><asp:TextBox Width="250px"  ID="txtCountry" Text="USA"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                  <td><asp:TextBox Width="250px"  ID="txtZip"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                  <th align="left" colspan="2">h. Telephone # (include area code) (Do not leave spaces or type any special characters)</th>
                </tr>
                <tr>
                  <td colspan="2"><asp:TextBox ID="txtCompanyPhoneNo_Code"  CssClass="input_edit"  runat="server" Width="40px"></asp:TextBox>-<asp:TextBox ID="txtCompanyPhoneNo"  CssClass="input_edit"  runat="server" 
                          Width="150px"></asp:TextBox><br />
                          <asp:Label ID="Label1" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Code)"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Phone No)"></asp:Label>
                          </td>
                </tr>
                <tr>
                  <th align="left">i. E-Mail Address (If Any)</th>
                  <th align="left">j. Federal Employer Identification #</th>
                </tr>
                <tr>
                  <td><asp:TextBox  Width="250px" ID="txtEmailAddress"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                  <td><asp:TextBox  Width="250px" ID="txtFederalNo"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                </tr>
                <tr>
                  <th align="left">k. Individual Tax #</th>
                  <th align="left">l. Social Security #</th>
                </tr>
                <tr>
                  <td><asp:TextBox  Width="250px" ID="txtIndividualTax"  CssClass="input_edit" runat="server"></asp:TextBox> </td>
                  <td><asp:TextBox  Width="250px" ID="txtSocialSecurity" CssClass="input_edit"  runat="server"></asp:TextBox> </td>
                </tr>
              </table>
              <br /></td>
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
</body>
</html>

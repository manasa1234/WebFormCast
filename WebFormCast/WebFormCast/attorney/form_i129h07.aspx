<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h07" Codebehind="form_i129h07.aspx.cs" %>
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
            <td align="right" valign="top">OMB No.1615-0009; Expires 10/31/2013
              <h4>H Classification Supplement 
                to Form I-129</h4></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="left">1. Name of the petitioner:</th>
            <th align="left">2. Name of the beneficiary or if this petition includes multiple beneficiaries, the total number of beneficiaries:</th>
          </tr>
          <tr>
            <td><asp:TextBox CssClass="input_edit" Width="250px" ID="f8_Name_of_organization_filing_petition" runat="server"></asp:TextBox> </td>
            <td><asp:TextBox CssClass="input_edit" Width="250px" ID="f8_Name_of_person" runat="server"/></td>
          </tr>
          <tr>
            <th colspan="2" align="left">3. <span style="font-weight:normal">List each beneficiary's prior periods of stay in H or L classification in the United States for the last 6 years (beneficiaries requesting H-2A or H-2B classification need only list the last 3 years). Be sure to only list those periods in which each beneficiary was actually in the United States in an H or L classification. Do not include periods in which the beneficiary was in a dependent status, for example, H-4 or L-2 status.<br />
                  <strong> NOTE:</strong> Submit photocopies of Forms I-94, I-797, and/or other USCIS issued documents noting these periods of stay in the H or L classification. If more space is needed, attach an additional sheet.</span></th>
          </tr>
          <tr>
            <td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <th>Subject's Name</th>
                  <th colspan="2">Period of Stay <em style="font-weight:normal">(mm/dd/yyyy)</em></th>
                  <th>Subject's Name</th>
                  <th colspan="2">Period of Stay <em style="font-weight:normal">(mm/dd/yyyy)</em></th>
                </tr>
                <tr>
                  <td>&nbsp;<asp:TextBox ID="f8_SubjectsName1" runat="server" CssClass="input_edit"/></td>
                  <td>From:
                    <asp:TextBox ID="f8_Period_From1" runat="server" CssClass="input_edit"/></td>
                  <td>To:
                    <asp:TextBox ID="f8_Period_To1" runat="server" CssClass="input_edit"/></td>
                  <td>&nbsp;
                    <asp:TextBox ID="f8_SubjectsName2" runat="server" CssClass="input_edit"/></td>
                  <td>From:
                    <asp:TextBox ID="f8_Period_From2" runat="server" CssClass="input_edit"/></td>
                  <td>To:
                    <asp:TextBox ID="f8_Period_To2" runat="server" CssClass="input_edit"/></td>
                </tr>
                <tr>
                  <td>&nbsp;<asp:TextBox ID="f8_SubjectsName3" runat="server" CssClass="input_edit"/></td>
                  <td>From:
                    <asp:TextBox ID="f8_Period_From3" runat="server" CssClass="input_edit"/></td>
                  <td>To:
                    <asp:TextBox ID="f8_Period_To3" runat="server" CssClass="input_edit"/></td>
                  <td>&nbsp;
                    <asp:TextBox ID="f8_SubjectsName4" runat="server" CssClass="input_edit"/></td>
                  <td>From:
                    <asp:TextBox ID="f8_Period_From4" runat="server" CssClass="input_edit"/></td>
                  <td>To:
                    <asp:TextBox ID="f8_Period_To4" runat="server" CssClass="input_edit"/></td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th colspan="2" align="left">4. Classification sought <em style="font-weight:normal">(Check one)</em>:</th>
          </tr>
          <tr>
            <td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td valign="top"><asp:RadioButton CssClass="input_normal_wb"  ID="f8_Classification_sought1" Checked="true" runat="server" />
                    H-1B1</td>
                  <td width="40%" valign="top">Specialty occupation</td>
                  <td valign="top"><asp:RadioButton   CssClass="input_normal_wb"  id="f8_Classification_sought2"  runat="server" />
                    H-2A</td>
                  <td width="40%" valign="top">Agricultural worker</td>
                </tr>
                <tr>
                  <td valign="top"><asp:RadioButton  CssClass="input_normal_wb"  id="f8_Classification_sought3" runat="server" />
                    H-1B2</td>
                  <td valign="top">Exceptional services relating to a cooperative 
                    research and development project administered by 
                    the U.S. Department of Defense (DOD)</td>
                  <td valign="top"><asp:RadioButton  CssClass="input_normal_wb"   id="f8_Classification_sought4" runat="server" />
                    H-2B</td>
                  <td valign="top">Non-agricultural worker</td>
                </tr>
                <tr>
                  <td valign="top"><asp:RadioButton  CssClass="input_normal_wb"  ID="f8_Classification_sought5" runat="server" />
                    H-1B3</td>
                  <td valign="top">Fashion model of national or international acclaim</td>
                  <td valign="top"><asp:RadioButton  CssClass="input_normal_wb"  ID="f8_Classification_sought6"  runat="server" />
                    H-3</td>
                  <td valign="top">Trainee</td>
                </tr>
                <tr>
                  <td valign="top">&nbsp;</td>
                  <td valign="top">&nbsp;</td>
                  <td valign="top"><asp:RadioButton  ID="f8_Classification_sought7" CssClass="input_normal_wb" runat="server" />
                    H-3</td>
                  <td valign="top">Special education exchange visitor program</td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th colspan="2" align="left">5. Are you filing this petition on behalf of an alien subject to the Guam-CNMI cap exemption under Public Law 110-229?</th>
          </tr>
          <tr>
            <td colspan="2" align="left">TBD No/Yes</td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="left">Section 1. Complete this section if filing for H-1B classification.</th>
          </tr>
          <tr>
            <td><strong>1. </strong>Describe the proposed duties</td>
          </tr>
          <tr>
            <td><asp:TextBox  ID="f8_Describe_the_proposed_duties" CssClass="input_edit" TextMode="MultiLine" Rows="2" Columns="160" runat="server" ></asp:TextBox> </td>
          </tr>
          <tr>
            <td><strong>2. </strong>Beneficiary's present occupation and summary of prior work experience</td>
          </tr>
          <tr>
            <td><asp:TextBox TextMode=MultiLine Rows="6" Columns="160" ID="f8_Aliens_present_occupation" runat="server" CssClass="input_edit" ></asp:TextBox> </td>
          </tr>
          <tr>
            <th align="left"><em>Statement for H-1B specialty occupations only:</em></th>
          </tr>
          <tr>
            <td>By filing this petition, I agree to the terms of the labor condition application for the duration of the alien's authorized period of stay 
              for H-1B employment.</td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><strong>Petitioner's Signature</strong></td>
                  <td><strong>Print or Type Name</strong></td>
                  <td><strong>Date </strong><em>(mm/dd/yyyy)</em></td>
                </tr>
                <tr>
                  <td><input name="textfield90" type="text" id="textfield113" size="40" /></td>
                  <td><asp:TextBox Width="200px" ID="f8_Print_or_Type_Name1" CssClass="input_edit" runat="server"></asp:TextBox> </td>
                  <td><asp:TextBox Width="100px" ID="f8_DATE1" runat="server" CssClass="input_edit"></asp:TextBox> </td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th align="left"><em>Statement for H-1B specialty occupations and U.S. Department of Defense projects:</em></th>
          </tr>
          <tr>
            <td>As an authorized official of the employer, I certify that the employer will be liable for the reasonable costs of return transportation 
              of the alien abroad if the alien is dismissed from employment by the employer before the end of the period of authorized stay.</td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><strong>Signature of Authorized Official of Employer</strong></td>
                  <td><strong>Print or Type Name</strong></td>
                  <td><strong>Date </strong><em>(mm/dd/yyyy)</em></td>
                </tr>
                <tr>
                  <td><input name="textfield93"  type="text" id="textfield116" size="40" /></td>
                  <td><asp:TextBox Width="200px" ID="f8_Print_or_Type_Name2" CssClass="input_edit" runat="server"></asp:TextBox></td>
                  <td><asp:TextBox Width="100px" ID="f8_DATE2" runat="server" CssClass="input_edit"></asp:TextBox> </td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th align="left"><em>Statement for H-1B specialty occupations only:</em></th>
          </tr>
          <tr>
            <td>I certify that the alien will be working on a cooperative research and development project or a co-production project under a 
              reciprocal government-to-government agreement administered by the U.S. Department of Defense.</td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><strong>DOD Project Manager's Signature</strong></td>
                  <td><strong>Print or Type Name</strong></td>
                  <td><strong>Date </strong><em>(mm/dd/yyyy)</em></td>
                </tr>
                <tr>
                  <td><input name="textfield94" type="text" id="textfield119" size="40" /></td>
                  <td><input name="textfield94" type="text" id="textfield120" size="40" /></td>
                  <td><input name="textfield94" type="text" id="textfield121" size="40" /></td>
                </tr>
            </table></td>
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

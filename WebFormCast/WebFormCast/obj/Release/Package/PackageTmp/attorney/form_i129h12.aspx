<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h12" Codebehind="form_i129h12.aspx.cs" %>
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
              <h4>H-1B Data Collection and 
                Filing Fee Exemption Supplement</h4></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="left">Part B. Fee Exemption and/or Determination</th>
          </tr>
          <tr>
            <td>In order for USCIS to determine if you must pay the additional $1,500 or $750 fee, please answer all of the following questions:</td>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td>1.</td>
                  <td width="6%"><asp:RadioButton ID="f12_Fee_Exemption_1_Yes" GroupName="g1" CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td width="6%"><asp:RadioButton ID="f12_Fee_Exemption_1_No" GroupName="g1" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td>Are you an institution of higher education as defined in the Higher Education Act of 1965, section 101 
                    (a), 20 U.S.C. section 1001(a)?</td>
                </tr>
                <tr>
                  <td>2.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_2_Yes" CssClass="input_normal_wb" GroupName="g2" runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_2_No" CssClass="input_normal_wb" GroupName="g2" runat="server" />
                    No</td>
                  <td>Are you a nonprofit organization or entity related to or affiliated with an institution of higher education, 
                    as such institutions of higher education are defined in the Higher Education Act of 1965, section 101 
                    (a), 20 U.S.C. section 1001(a)?</td>
                </tr>
                <tr>
                  <td>3.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_3_Yes" CssClass="input_normal_wb" GroupName="g3"  runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_3_No" CssClass="input_normal_wb"  GroupName="g3" runat="server" />
                    No</td>
                  <td>Are you a nonprofit research organization or a governmental research organization, as defined in 
                    8 CFR 214.2(h)(19)(iii)(C)?</td>
                </tr>
                <tr>
                  <td>4.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_4_Yes" CssClass="input_normal_wb"  GroupName="g4" runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_4_No" CssClass="input_normal_wb"  GroupName="g4" runat="server" />
                    No</td>
                  <td>Is this the second or subsequent request for an extension of stay that you have filed for this alien?</td>
                </tr>
                <tr>
                  <td>5.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_5_Yes" CssClass="input_normal_wb"  GroupName="g5" runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_5_No" CssClass="input_normal_wb"  GroupName="g5" runat="server" />
                    No</td>
                  <td>Is this an amended petition that does not contain any request for extensions of stay?</td>
                </tr>
                <tr>
                  <td>6.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_6_Yes" CssClass="input_normal_wb"  GroupName="g6" runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_6_No" CssClass="input_normal_wb"  GroupName="g6" runat="server" />
                    No</td>
                  <td>Are you filing this petition in order to correct a USCIS error?</td>
                </tr>
                <tr>
                  <td>7.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_7_Yes" CssClass="input_normal_wb"  GroupName="g7" runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_7_No" CssClass="input_normal_wb"  GroupName="g7" runat="server" />
                    No</td>
                  <td>Is the petitioner a primary or secondary education institution?</td>
                </tr>
                <tr>
                  <td>8.</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_8_Yes" CssClass="input_normal_wb"  GroupName="g8" runat="server" />
                    Yes</td>
                  <td><asp:RadioButton ID="f12_Fee_Exemption_8_No" CssClass="input_normal_wb"  GroupName="g8" runat="server" />
                    No</td>
                  <td><p>Is the petitioner a non-profit entity that engages in an established curriculum-related clinical training of 
                    students registered at such an institution?</p></td>
                </tr>
              </table>
                <br />
              If you answered &quot;Yes&quot; to any of the questions above, then you are required to submit the fee for your H-1B Form I-129 petition, 
              which is $320. If you answered &quot;No&quot; to all questions, please answer Question 9.<br />
                  <br />
                  <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                      <td>9.</td>
                      <td width="6%"><asp:RadioButton ID="f12_Fee_Exemption_9_Yes" CssClass="input_normal_wb"  GroupName="g9"  runat="server" />
                        Yes</td>
                      <td width="6%"><asp:RadioButton ID="f12_Fee_Exemption_9_No" CssClass="input_normal_wb"  GroupName="g9" runat="server" />
                        No</td>
                      <td>Do you currently employ a total of no more than 25 full-time equivalent employees in the United 
                        States, including any affiliate or subsidiary of your company?</td>
                    </tr>
                  </table>
              <br />
              If you answered &quot;Yes&quot; to Question 9 above, then you are required to pay an additional fee of $750. If you answered &quot;No&quot;, then 
              you are required to pay an additional fee of $1,500.</td>
          </tr>
          <tr>
            <td><strong>NOTE:</strong> On or after March 8, 2005, a U.S. employer seeking initial approval of H-1B or L nonimmigrant status for a beneficiary, or 
              seeking approval to employ an H-1B or L nonimmigrant currently working for another U.S. employer, must submit an additional $500 
              fee. This additional $500 Fraud Prevention and Detection fee was mandated by the provisions of the H-1B Visa Reform Act of 2004. 
              There is no exemption from this fee.</td>
          </tr>
          <tr>
            <th align="left">Part C. Numerical Limitation Exemption Information.</th>
          </tr>
          <tr>
            <td><table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td valign="top">1.</td>
                  <td width="6%" valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_1_Yes" GroupName="f12_Numerical_Limitation_1" CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td width="6%" valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_1_No"  GroupName="f12_Numerical_Limitation_1" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">Are you an institution of higher education as defined in the Higher Education Act of 1965, section 101 
                    (a), 20 U.S.C. section 1001(a)?</td>
                </tr>
                <tr>
                  <td valign="top">2.</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_2_Yes" GroupName="f12_Numerical_Limitation_2"  CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_2_No" GroupName="f12_Numerical_Limitation_2"  CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">Are you a nonprofit organization or entity related to or affiliated with an institution of higher education, 
                    as such institutions of higher education as defined in the Higher Education Act of 1965, section 101(a), 
                    20 U.S.C. section 1001(a)?</td>
                </tr>
                <tr>
                  <td valign="top">3.</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_3_Yes"  GroupName="f12_Numerical_Limitation_3" CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_3_No"  GroupName="f12_Numerical_Limitation_3" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">Are you a nonprofit research organization or a governmental research organization, as defined in 8 
                    CFR 214.2(h)(19)(iii)(C)?</td>
                </tr>
                <tr>
                  <td valign="top">4.</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_4_Yes"  GroupName="f12_Numerical_Limitation_4" CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_4_No"  GroupName="f12_Numerical_Limitation_4" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">Is the beneficiary of this petition a J-1 nonimmigrant alien who received a waiver of the two-year 
                    foreign residency requirement described in section 214 (l)(1)(B) or (C) of the Act?</td>
                </tr>
                <tr>
                  <td valign="top">5.</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_5_Yes" GroupName="f12_Numerical_Limitation_5"  CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_5_No"  GroupName="f12_Numerical_Limitation_5" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">Has the beneficiary of this petition been previously granted status as an H-1B nonimmigrant in the past 
                    6 years and not left the United States for more than one year after attaining such status?</td>
                </tr>
                <tr>
                  <td valign="top">6.</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_6_Yes" GroupName="f12_Numerical_Limitation_6"  CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_6_No"  GroupName="f12_Numerical_Limitation_6" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">If the petition is to request a change of employer, did the beneficiary previously work as an H-1B for an 
                    institution of higher education, an entity related to or affiliated with an institution of higher education, 
                    or a nonprofit research organization or governmental research institution defined in questions 1, 2 and 3 
                    of Part C of this form?</td>
                </tr>
                <tr>
                  <td valign="top">7.</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_7_Yes"  GroupName="f12_Numerical_Limitation_7" CssClass="input_normal_wb" runat="server" />
                    Yes</td>
                  <td valign="top"><asp:RadioButton ID="f12_Numerical_Limitation_7_No"  GroupName="f12_Numerical_Limitation_7" CssClass="input_normal_wb" runat="server" />
                    No</td>
                  <td valign="top">Has the beneficiary of this petition earned a master's or higher degree from a U.S. institution of higher 
                    education, as defined in the Higher Education Act of 1965, section 101(a), 20 U.S.C. section 1001(a)?</td>
                </tr>
            </table></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="right">Form I-129 H-1B Data Collection Supplement (Rev. 07/30/07)Y</td>
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

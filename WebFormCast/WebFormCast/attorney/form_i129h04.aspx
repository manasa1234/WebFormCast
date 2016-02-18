<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h04" Codebehind="form_i129h04.aspx.cs" %>
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
      <li><a href="_forms.aspx"><b>Forms</b></a></li>
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
            <th colspan="5" align="left">Part 4. Processing Information.</th>
          </tr>
          <tr>
            <td colspan="5">&nbsp;</td>
          </tr>
          <tr>
            <th width="21" valign="top">1.</th>
            <th colspan="4" align="left">If the person named in Part 3 is outside the United States or a requested extension of stay or change of status cannot be granted, 
              give the U.S. consulate or inspection facility you want notified if this petition is approved.</th>
          </tr>
          <tr>
            <td rowspan="5">&nbsp;</td>
            <td colspan="4">Type of Office<em> (Check one)</em>:
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Type_of_Office1" GroupName="Type_of_Office" runat="server" />
              Consulate
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Type_of_Office2" GroupName="Type_of_Office"  runat="server" />
              Pre-flight inspection
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Type_of_Office3"  GroupName="Type_of_Office" runat="server" />
              Port of Entry</td>
          </tr>
          <tr>
            <th colspan="3" align="left">Office Address (City): </th>
            <th align="left">U.S. State or Foreign Country:</th>
          </tr>
          <tr>
            <td colspan="3"><asp:TextBox CssClass="input_edit" TextMode="MultiLine" Rows="6" Columns="60" ID="f4_Office_Address" runat="server"></asp:TextBox> </td>
            <td><asp:TextBox  CssClass="input_edit" id="f4_US_State_or_Foreign_Country" TextMode="MultiLine" Rows="6" Columns="60" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <th colspan="4" align="left">Person's Foreign Address:</th>
          </tr>
          <tr>
            <td colspan="4"><asp:TextBox CssClass="input_edit" TextMode="MultiLine" Rows="6" Columns="60"  ID="f4_Persons_Foreign_Address" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <th>2.</th>
            <th colspan="4" align="left">Does each person in this petition have a valid passport?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton    CssClass="input_normal_wb"  GroupName="f4_Have_a_valid_passpor" ID="f4_Have_a_valid_passpor1" runat="server" />
              Not required to have passport
              <asp:RadioButton   CssClass="input_normal_wb"  ID="f4_Have_a_valid_passpor2" GroupName="f4_Have_a_valid_passpor" runat="server" />
              No - Go to <strong>Page7,&nbsp;&nbsp;Part9</strong> and write your explanation
              <asp:RadioButton   CssClass="input_normal_wb"  ID="f4_Have_a_valid_passpor3" GroupName="f4_Have_a_valid_passpor" runat="server" />
              Yes</td>
          </tr>
          <tr>
            <th>3.</th>
            <th colspan="4" align="left">Are you filing any other petitions with this one?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton   CssClass="input_normal_wb"  ID="f4_Anyother_petitionsNo" GroupName="anyother_petitions" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Anyother_petitionsYes"  GroupName="anyother_petitions" runat="server" />
              Yes - How many?
              <asp:TextBox CssClass="input_edit"  ID="f4_Anyother_petitions_HowMany" runat="server" /></td>
          </tr>
          <tr>
            <th>4.</th>
            <th colspan="4" align="left">Are applications for replacement/initial I-94s being filed with this petition?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Are_applications_for_replacementNo" GroupName="Are_applications_for_replacement" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  id="f4_Are_applications_for_replacementYes" runat="server"  GroupName="Are_applications_for_replacement"  />
              Yes - How many?
              <asp:TextBox CssClass="input_edit"  ID="f4_Are_applications_for_replacement_howmany" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <th>5.</th>
            <th colspan="4" align="left">Are applications by dependents being filed with this petition?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left">
            <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_dependents_being_filedNo" GroupName="dependents_being_filed" runat="server" /> No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_dependents_being_filedYes"  GroupName="dependents_being_filed"  runat="server" /> Yes - How many?
              <asp:TextBox  CssClass="input_edit"  ID="f4_dependents_being_filed_HowMany" runat="server"></asp:TextBox>
               </td>
          </tr>
          <tr>
            <th>6.</th>
            <th colspan="4" align="left">Is any person in this petition in removal proceedings?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton    CssClass="input_normal_wb"  GroupName="f4_Removal_proceedings" ID="f4_Removal_proceedingsNo" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Removal_proceedingsYes"  GroupName="f4_Removal_proceedings" runat="server" />
              Yes - explain on <strong>Page7,&nbsp;&nbsp;Part9</strong></td>
          </tr>
          <tr>
            <th>7.</th>
            <th colspan="4" align="left">Have you ever filed an immigrant petition for any person in this petition?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Have_you_ever_filed_an_immigrant_petitionNo" GroupName="Have_you_ever_filed_an_immigrant_petition" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Have_you_ever_filed_an_immigrant_petitionYes" runat="server"  GroupName="Have_you_ever_filed_an_immigrant_petition"  />
              Yes - explain on <strong>Page7,&nbsp;&nbsp;Part9</strong></td>
          </tr>
          <tr>
            <th>8.</th>
            <th colspan="4" align="left">If you indicated you were filing a new petition in Part 2, within the past seven years has any person in this petition:</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3" align="left"><strong>a.</strong> Ever been given the classification you are now requesting?</td>
            <td align="left"><asp:RadioButton    CssClass="input_normal_wb"  GroupName="g1" ID="f4_Thepast_seven_years1No" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Thepast_seven_years1Yes" GroupName="g1" runat="server" />
              Yes - explain on <strong>Page7,&nbsp;&nbsp;Part9</strong></td>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="3" align="left"><strong>b.</strong> Ever been denied the classification you are now requesting?</td>
            <td align="left"><asp:RadioButton    CssClass="input_normal_wb"  GroupName="g2" ID="f4_Thepast_seven_years2No" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Thepast_seven_years2Yes" GroupName="g2" runat="server" />
              Yes - explain on <strong>Page7,&nbsp;&nbsp;Part9</strong></td>
          </tr>
          <tr>
            <th>9.</th>
            <th colspan="4" align="left">Have you ever previously filed a petition for this person?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton    CssClass="input_normal_wb"  GroupName="g3" ID="f4_Ever_previously_filed_a_petition_for_this_persoNo" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_Ever_previously_filed_a_petition_for_this_persoYes" GroupName="g3" runat="server" />
              Yes - explain on <strong>Page7,&nbsp;&nbsp;Part9</strong></td>
          </tr>
          <tr>
            <th>10.</th>
            <th colspan="4" align="left">If you are filing for an entertainment group, has any person in this petition not 
              been with the group for at least one year?</th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td colspan="4" align="left"><asp:RadioButton    CssClass="input_normal_wb"  ID="f4_If_you_are_filing_for_an_entertainment_groupNo" GroupName="g4" runat="server" />
              No
              <asp:RadioButton    CssClass="input_normal_wb"  ID="f4_If_you_are_filing_for_an_entertainment_groupYes" runat="server" GroupName="g4" />
              Yes - explain on <strong>Page7,&nbsp;&nbsp;Part9</strong></td>
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
          <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
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


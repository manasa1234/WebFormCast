<%@ Page Language="C#" AutoEventWireup="true" Inherits="formg28" Codebehind="formg28.aspx.cs" %>
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
      <li><a href="useraccounts.aspx"><b>User Account's</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul></asp:Label>
    <div id="contentArea1">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">
          <SB:SearchBox id="MySearch" Runat="Server"></SB:SearchBox>
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
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="home.aspx"><asp:Label ID="lbCompanyName" runat="server"></asp:Label></a> &raquo; <a href="employeeview.aspx"><asp:Label ID="lbtrackingno" runat="server"></asp:Label></a> &raquo; Form - G28</div>
      <div id="whiteArea">
      <table width="100%"   style="border:0px" cellspacing="0" cellpadding="0">
        <tr><td width="50%" style="border:0px"><h2>Form G-28</h2></td><td style="border:0px" align="right" valign="top" width="50%"><asp:HyperLink Target="_blank" ID="hlDownloadPdf" runat="server" Font-Bold="true" Text="Download PDF"></asp:HyperLink> </td></tr>
      </table>
        
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="50%" valign="top">U.S. Department of Justice<br />
            Immigration and Naturalization Service</td>
            <td align="right" valign="top"><h4>Notice of Entry of Appearance<br />
            as Attorney or Representative</h4></td>
          </tr>
          <tr>
            <td colspan="2"><p><strong>Appearances -</strong> An appearance shall be filed on this form by the attorney or representative appearing in each case. Thereafter, substitution may be 
              permitted upon the written withdrawal of the attorney or representative of record or upon notification of the new attorney or representative. When 
              an appearance is made by a person acting in a representative capacity, his personal appearance or signature shall constitute a representation that 
              under the provisions of this chapter he is authorized and qualified to represent. Further proof of authority to act in a representative capacity may be 
              required.</p>
              <p><strong>Availability of Records - </strong>During the time a case is pending, and except as otherwise provided in 8 CFR 103.2(b), a party to a proceeding 
                or his attorney or representative shall be permitted to examine the record of proceeding in a Service office. He may, in conformity with 8 CFR 
                103.10, obtain copies of Service records or information therefrom and copies of documents or transcripts of evidence furnished by him. Upon 
                request, he/she may, in addition, be loaned a copy of the testimony and exhibits contained in the record of proceeding upon giving his/her receipt for 
                such copies and pledging that it will be surrendered upon final disposition of the case or upon demand. If extra copies of exhibits do not exist, they 
            shall not be furnished free on loan; however, they shall be made available for copying or purchase of copies as provided in 8 CFR 103.10.</p></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="right">In re:</th>
            <th align="left"><asp:TextBox CssClass="input_edit" ID="InRe" runat="server" Width="650"></asp:TextBox></th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td>Date:
            <asp:TextBox CssClass="input_edit"  id="Date1" runat="server"></asp:TextBox>
            File No.
            <asp:TextBox CssClass="input_edit"  ID="FileNo" runat="server"></asp:TextBox> </td>
          </tr>
        </table>
        <br />
        I hereby enter my appearance as attorney for (or representative of), and at the request of the following named person(s):<br />
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="right">Name</th>
            <th align="left"><asp:TextBox CssClass="input_edit"  ID="Name1" runat="server" Width="450"></asp:TextBox></th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td><asp:CheckBox runat="server" ID="NameType1_1"/>
Petitioner
  <asp:CheckBox runat="server" ID="NameType1_2" />
Applicant
<asp:CheckBox runat="server" ID="NameType1_3"  />
Beneficiary</td>
          </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th>Address: (Apt. No.)</th>
            <th>(Number &amp; Street)</th>
            <th>(City)</th>
            <th>(State)</th>
            <th>(Zip Code)</th>
          </tr>
          <tr>
            <td><asp:TextBox CssClass="input_edit"  ID="AptNo1" runat="server"></asp:TextBox> </td>
            <td><asp:TextBox CssClass="input_edit"  id="Street1" runat="server"></asp:TextBox> </td>
            <td><asp:TextBox CssClass="input_edit"  ID="City1" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="State1" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="Zip1" runat="server"></asp:TextBox></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th align="right">Name</th>
            <th align="left"><asp:TextBox CssClass="input_edit"  ID="Name2"  Width="450" runat="server"></asp:TextBox></th>
          </tr>
          <tr>
            <td>&nbsp;</td>
            <td><asp:CheckBox runat="server" ID="NameType2_1"  />
              Petitioner
              <asp:CheckBox runat="server" ID="NameType2_2"/>
              Applicant
              <asp:CheckBox runat="server" ID="NameType2_3" />
              Beneficiary</td>
          </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th>Address: (Apt. No.)</th>
            <th>(Number &amp; Street)</th>
            <th>(City)</th>
            <th>(State)</th>
            <th>(Zip Code)</th>
          </tr>
          <tr>
            <td><asp:TextBox CssClass="input_edit"  ID="AptNo2" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="Street2" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="City2" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="State2" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="Zip2" runat="server"></asp:TextBox></td>
          </tr>
        </table>
        <br />
        Check Applicable Item(s) below:<br />
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="top"><asp:CheckBox runat="server" ID="CheckBox6" Checked=true /></td>
            <td valign="top">1. I am an attorney and a member in good standing of the bar of the Supreme Court of the United States or of the highest court of the following 
            State, territory, insular possession, or District of Columbia<br />
            <input type="text" name="textfield17" id="textfield17" />
            <input name="textfield18" type="text" id="textfield18" value="Name of Court" />
            and am not under a court or administrative agency 
            order suspending, enjoining, restraining, disbarring, or otherwise restricting me in practicing law.</td>
          </tr>
          <tr>
            <td valign="top"><asp:CheckBox runat="server" ID="CheckBox7" Enabled="false" /></td>
            <td valign="top">2. I am an accredited representative of the following named religious, charitable, social service, or similar organization established in the
            United States and which is so recognized by the Board:</td>
          </tr>
          <tr>
            <td valign="top"><asp:CheckBox runat="server" ID="CheckBox8" Enabled="false" /></td>
            <td valign="top">3. I am associated with
              <input name="textfield19" type="text" id="textfield19" size="90" />
              the attorney of record previously filed a notice of appearance in this case and my appearance is at his request. <em>(If you check this item, also
            check item 1 or 2 whichever is appropriate.)</em></td>
          </tr>
          <tr>
            <td valign="top"><asp:CheckBox runat="server" ID="CheckBox9" Enabled="false" /></td>
            <td valign="top">4. Others (Explain Fully.)<br />
              <textarea name="textfield20" rows="4" id="textfield20" style="width:500px"></textarea></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th width="50%">SIGNATURE</th>
            <th>COMPLETE ADDRESS</th>
          </tr>
          <tr>
            <td valign="top">&nbsp;</td>
            <td align="center"><asp:TextBox CssClass="input_edit" Rows="6" Width="350"  ID="AttorneyFirmNameAddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
          </tr>
          <tr>
            <th>NAME (Type or Print)</th>
            <th>TELEPHONE NUMBER</th>
          </tr>
          <tr>
            <td align="center"><asp:TextBox CssClass="input_edit"  ID="AttorneyName" runat="server" Width="411px"></asp:TextBox></td>
            <td align="center"><asp:TextBox CssClass="input_edit"  ID="AttorneyPhone" runat="server" Width="200"></asp:TextBox>
              (fax)</td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td>PURSUANT TO THE PRIVACY ACT OF 1974, I HEREBY CONSENT TO THE DISCLOSURE TO THE FOLLOWING NAMED
              ATTORNEY OR REPRESENTATIVE OF ANY RECORD PERTAINING TO ME WHICH APPEARS IN ANY IMMIGRATION AND 
            NATURALIZATION SERVICE SYSTEM OF RECORDS:</td>
          </tr>
          <tr>
            <td align="center"><asp:TextBox CssClass="input_edit"  ID="AttorneyName2" runat="server" Width="411px"></asp:TextBox>
            <br />
            (Name of Attorney or Representative)</td>
          </tr>
          <tr>
            <td>THE ABOVE CONSENT TO DISCLOSURE IS IN CONNECTION WITH THE FOLLOWING MATTER:</td>
          </tr>
          <tr>
            <td align="center"><asp:TextBox CssClass="input_edit"  id="Form129Name" runat="server" Width="350px"></asp:TextBox> </td>
          </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th>Name of Person Consenting</th>
            <th>Signature of Person Consenting</th>
            <th>Date</th>
          </tr>
          <tr>
            <td align="center"><asp:TextBox CssClass="input_edit" Width="300"  ID="CompanyPersonName" runat="server"></asp:TextBox></td>
            <td><input type="text" name="textfield24" id="textfield28" /></td>
            <td><asp:TextBox CssClass="input_edit"  ID="Date2" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td colspan="3">(NOTE: Execution of this box is required under the Privacy Act of 1974 where the person being represented is a citizen of the United States or an alien 
            lawfully admitted for permanent residence.)</td>
          </tr>
          <tr>
            <td colspan="3"><asp:TextBox CssClass="input_edit"  Rows="10" ID="Note" runat="server" TextMode="MultiLine" style="width:700px"/></td>
          </tr>
        </table>
        <br />
        This form may not be used to request records under the Freedom of Information Act or the Privacy Act. The manner of requesting such records is contained in 8CFR 103.10 and 103.20 Et.SEQ.<br />
        <br />
        <div align="center" class="divBlock"><asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Save" /></div>
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

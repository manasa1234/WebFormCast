<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h06" Codebehind="form_i129h06.aspx.cs" %>
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
            <th colspan="2" align="left">Part 6. Certification Regarding the Release of Controlled Technology or Technical Data to Foreign 
                                         Persons in the United States</th>
          </tr>
          <tr>
            <td colspan="2">(For H-1B, H-1B1 Chile/Singapore, L-1, and O-1A petitions only. This section of the form is not required for all other classifications. See <strong>Page 3</strong> of the Instructions before completing this section.)</td>
          </tr>
          <tr>
            <td colspan="2"><strong>Check Box 1 or Box 2 as appropriate:</strong></td>
          </tr>
          <tr>
            <td colspan="2">With respect to the technology or technical data the petitioner will release or otherwise provide access to the beneficiary, the petitioner certifies that it has reviewed the Export Administration Regulations (EAR) and the International Traffic in Arms Regulations (ITAR) and has determined that:</td>
          </tr>
          <tr>
            <td>TBD <strong>1.</strong>
            A license is not required from either U.S. Department of Commerce or the U.S. Department of State to release such technology or technical data to the foreign person; or
            </td>
          </tr>
          <tr>
            <td>TBD <strong>2.</strong>
            A license is required from the U.S. Department of Commerce and/or the U.S. Department of State to release such technology or technical data to the beneficiary and the petitioner will prevent access to the controlled technology or technical data by the beneficiary until and unless the petitioner has received the required license or other authorization to release it to the beneficiary.
            </td>
          </tr>
        </table>
        <br />



        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th colspan="2" align="left">Part 7. Signature. <em style="font-weight:normal">Read the information on penalties in the instructions before completing this section.</em></th>
          </tr>
          <tr>
            <td colspan="2">I certify, under penalty of perjury that this petition and the evidence submitted with it are true and correct to the best of my 
            knowledge. I authorize the release of any information from my records, or from the petitioning organization's records that U.S. 
            Citizenship and Immigration Services needs to determine eligibility for the benefit being sought. I recognize the authority of USCIS to 
            conduct audits of this petition using publicly available open source information. I also recognize that supporting evidence submitted 
            may be verified by USCIS through any means determined appropriate by USCIS, including but not limited to, on-site compliance 
            reviews.</td>
          </tr>
          <tr>
            <td><strong>Signature</strong></td>
            <td><strong>Daytime Phone Number</strong> (Area/Country Code)</td>
          </tr>
          <tr>
            <td><input name="textfield63" type="text" id="textfield76" size="60" /></td>
            <td><asp:TextBox Width="50px" CssClass="input_edit" id="f6_Daytime_Phone_Number1_Code" runat="server"></asp:TextBox>-<asp:TextBox Width="150px" CssClass="input_edit" id="f6_Daytime_Phone_Number1" runat="server"></asp:TextBox>
            <br /><asp:Label ID="Label1" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Code)"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Phone No)"></asp:Label>
            </td>
          </tr>
          <tr>
            <td><strong>Print Name</strong></td>
            <td><strong>Date</strong> (mm/dd/yyyy)</td>
          </tr>
          <tr>
            <td><asp:TextBox  Width="200px" CssClass="input_edit" ID="f6_Print_Name1" runat="server"></asp:TextBox></td>
            <td><asp:TextBox  Width="100px" CssClass="input_edit" ID="f6_Date1" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td colspan="2"><strong>NOTE:</strong> If you do not completely fill out this form and the required supplement, or fail to submit required documents listed in the 
              instructions, the person(s) filed for may not be found eligible for the requested benefit and this petition may be denied.</td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th colspan="2" align="left">Part 8. Signature of person preparing form, if other than above.</th>
          </tr>
          <tr>
            <td colspan="2">I declare that I prepared this petition at the request of the above person and it is based on all information of which I have any 
              knowledge.</td>
          </tr>
          <tr>
            <td><strong>Signature</strong></td>
            <td><strong>Daytime Phone Number</strong> (Area/Country Code)</td>
          </tr>
          <tr>
            <td><input name="textfield67" type="text" id="textfield80" size="60" /></td>
            <td><asp:TextBox Width="50px" CssClass="input_edit" id="f6_Daytime_Phone_Number2_Code" runat="server"></asp:TextBox>-<asp:TextBox  Width="150px" CssClass="input_edit" id="f6_Daytime_Phone_Number2" runat="server"></asp:TextBox>
            <br /><asp:Label ID="Label2" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Code)"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" ForeColor=GrayText runat="server"  Font-Size=Smaller   Text="(Phone No)"></asp:Label>
            </td>
          </tr>
          <tr>
            <td><strong>Print Name</strong></td>
            <td><strong>Date</strong> (mm/dd/yyyy)</td>
          </tr>
          <tr>
            <td><asp:TextBox  Width="200px" CssClass="input_edit" ID="f6_Print_Name2" runat="server"></asp:TextBox> </td>
            <td><asp:TextBox  Width="100px" CssClass="input_edit" ID="f6_Date2" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <td colspan="2"><strong>Firm Name and Address</strong></td>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox  Width="200px" CssClass="input_edit" ID="f6_Firm_Name_and_Address" runat="server" TextMode="MultiLine" Rows="6" style="width:600px"/></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th colspan="2" align="left">Part 9. Explanation Page.</th>
          </tr>
          <tr>
            <td colspan="2">TBD<asp:TextBox  Width="200px" CssClass="input_edit" ID="TextBox9" runat="server" TextMode="MultiLine" Rows="10" style="width:600px"/></td>
          </tr>
          <tr>
            <td><strong>Signature</strong></td>
            <td><strong>Date</strong> (mm/dd/yyyy)</td>
          </tr>
          <tr>
            <td>TBD<input name="tbd1" type="text" id="text2" size="60" /></td>
            <td>TBD<asp:TextBox  Width="100px" CssClass="input_edit" ID="TextBox8" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <td colspan="2"><strong>Print Name</strong></td>
          </tr>
          <tr>
            <td colspan="2"><asp:TextBox  Width="200px" CssClass="input_edit" ID="f6_Print_Name3" runat="server"></asp:TextBox> </td>
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
<script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>

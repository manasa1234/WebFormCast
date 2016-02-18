<%@ Page Language="C#" AutoEventWireup="true" Inherits="employer_account" Codebehind="employer_account.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
<link href="../css/calendar-tas.css" rel="stylesheet" type="text/css" />
<script src="../calendar.js" type="text/javascript"></script>
<script src="../lang/calendar-en.js" type="text/javascript"></script>
<script src="../calendar-setup.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            width: 17%;
        }
        .auto-style2 {
            width: 32%;
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
      <li><a href="cases.aspx"><b>Cases</b></a></li>
      <li class="current"><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Accounts</b></a></li>
      <li><a href="templates.aspx"><b>Templates</b></a></li>
      <li><a href="forms.aspx"><b>Forms</b></a></li>
      <li><a href="myaccount.aspx"><b>My Account</b></a></li>
    </ul></asp:Label>
    <div id="contentArea3">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">&nbsp;</td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title"><asp:Label ID="lbCompanyName" runat="server"></asp:Label></div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="clientmanager.aspx">Client Manager</a></div>
      <div id="whiteArea">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <th colspan="4">Part I - Company Contact Information</th>
          </tr>
          <tr>
            <td class="auto-style1">1. Legal    Name of Company</td>
            <td><asp:TextBox ID="txtLegal_Name"  runat="server" Width="303px"></asp:TextBox></td>
            <td class="auto-style2">2.  Type    of Company - LLC/Inc/Sole Proprietor</td>
            <td width="20%"><asp:TextBox ID="txtCompany_Type" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="auto-style1">3. Mailing Address</td>
            <td><asp:TextBox ID="txtAptNo" Width="200px" runat="server"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(Suite #)"></asp:Label>
            <br /><asp:TextBox ID="txtStreet" Width="200px" runat="server"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(Number & Street)"></asp:Label>
            <br /><asp:TextBox id="txtCity" runat="server" Width="200px"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(City)"></asp:Label>
            <br /><asp:TextBox ID="txtState" runat="server" Width="200px"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(State)"></asp:Label>
            <br /><asp:TextBox ID="txtZipCode" runat="server" Width="200px"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(Zip Code)"></asp:Label>
            </td>
            <td class="auto-style2">4. Address where all documents should be sent</td>
            <td><asp:TextBox ID="txtDocuments_Address" TextMode="MultiLine" Rows="4" 
                    Columns="40" runat="server" Height="90px"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="auto-style1">5. Phone Number</td>
            <td align="left">
                <asp:TextBox ID="txtPhone_No_Code" Width="50" runat="server"></asp:TextBox>-<asp:TextBox ID="txtPhone_No" runat="server"></asp:TextBox>
                <br /><asp:Label runat="server" Font-Size="Small" ForeColor="GrayText" Text="(Code)"></asp:Label>
            </td>
            <td class="auto-style2">6. Fax    No.</td>
            <td><asp:TextBox ID="txtFax_No" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="auto-style1">7. Alternate Phone Number</td>
            <td><asp:TextBox ID="txtAlternate_Phone_No_Code" Width="50" runat="server"></asp:TextBox>-<asp:TextBox ID="txtAlternate_Phone_No"  runat="server"></asp:TextBox>
            <br /><asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="GrayText" Text="(Code)"></asp:Label>
            </td>
            <td class="auto-style2">8. Web address</td>
            <td><asp:TextBox ID="txtWeb_Address" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4">Part II -    Registration Information</th>
          </tr>
          <tr>
            <td class="auto-style1">1. EIN    Number/FEIN/Federal ID No.</td>
            <td><asp:TextBox ID="txtEIN_Number" Width="200" runat="server"></asp:TextBox></td>
            <td class="auto-style2">2. Date Registered</td>
            <td><input type="text" runat="server" id="txtRegistered_Date" readonly />&nbsp;<a href="#" id="f_Registered_Date"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>
          </tr>
          <tr>
            <td class="auto-style1">3. State    of Registration</td>
            <td><asp:TextBox ID="txtRegistration_State" Width="200" runat="server"/></td>
            <td class="auto-style2">4. NACIS_Code</td>
            <td><asp:TextBox id="txtNaics_Code" runat="server"/></td>
          </tr>
          <tr>
            <th colspan="4">Part III    - Signatory Information</th>
          </tr>
          <tr>
            <td class="auto-style1">1. Full    name of the person who will sign all forms</td>
            <td><asp:TextBox ID="txtPerson_FullName" Width="200" MaxLength="100" runat="server"></asp:TextBox></td>
            <td class="auto-style2">2. Designation</td>
            <td><asp:TextBox ID="txtPerson_Designation" Width="150" MaxLength="100" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="auto-style1">3.    Contact No.</td>
            <td><asp:TextBox ID="txtPerson_ContactNo" Width="150" runat="server" runat="server" MaxLength="50"></asp:TextBox></td>
            <td class="auto-style2">4. Cell No.</td>
            <td><asp:TextBox ID="txtPerson_CellNo" Width="150" runat="server" runat="server" MaxLength="50"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="auto-style1">5. Login E Mail Address</td>
            <td><asp:TextBox ID="txtPerson_Email"  Width="200" runat="server" MaxLength="100"></asp:TextBox></td>
            <td class="auto-style2">6. Fax No.</td>
            <td><asp:TextBox ID="txtPerson_Fax"  Width="150" MaxLength="30" runat="server"></asp:TextBox></td>
          </tr>
          <tr>  
            <td class="auto-style1">7. Password</td>
            <td><asp:TextBox ID="txtPassword"  Width="200" runat="server" MaxLength="50"></asp:TextBox></td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>

          <tr>
            <td class="auto-style1">8. Contact Information</td>
            <td><asp:TextBox ID="txtContact_Info"  Width="200" runat="server" MaxLength="100"></asp:TextBox></td>
            <td class="auto-style2">9. Temporary Contact (if applicable)</td>
            <td><asp:TextBox ID="txtTemp_Contact_Info" Width="200" runat="server" MaxLength="100"></asp:TextBox></td>
          </tr>

          <tr>
            <td class="auto-style1">10. NIV Contact Information</td>
            <td><asp:TextBox ID="txtNIV_Contact_Info"  Width="200" runat="server" MaxLength="100"></asp:TextBox></td>
            <td class="auto-style2">11. Accounting Contact Information.</td>
            <td><asp:TextBox ID="txtAcc_Contact_Info"  Width="200" MaxLength="30" runat="server"></asp:TextBox></td>
          </tr>

          <tr>
            <td class="auto-style1">12. IV Contact Information</td>
            <td><asp:TextBox ID="txtIV_Contact_Info"  Width="200" runat="server" MaxLength="100"></asp:TextBox></td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
            


          <tr>
            <th colspan="4">Part IV. Nature of Business</th>
          </tr>
          <tr>
            <td class="auto-style1">1. Describe company activities briefly</td>
            <td><asp:TextBox TextMode="MultiLine" Rows="4" Columns="40" ID="txtDescription" runat="server"></asp:TextBox> </td>
            <td class="auto-style2">2. Does the Company have any affiliates</td>
            <td><asp:TextBox ID="txtHaveAffiliates" TextMode="MultiLine" Rows="4" Columns="40" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4">Part V.    Information about Employees</th>
          </tr>
          <tr>
            <td class="auto-style1">1. Current    number of employees</td>
            <td><asp:TextBox ID="txtNoofEmployees" runat="server" MaxLength="5"></asp:TextBox></td>
            <td class="auto-style2">2. Current number of H1B employees</td>
            <td><asp:TextBox ID="txtNoofH1BEmployees" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td class="auto-style1">3. H-1B Dependent</td>
            <td><asp:TextBox ID="txtH1B_Dependent" runat="server" MaxLength="5"></asp:TextBox> </td>
            <td class="auto-style2">4. Subject to Public Law (50/50)</td>
            <td><asp:TextBox ID="txtPublic_Law" runat="server" MaxLength="5"></asp:TextBox> </td>
          </tr>
          <tr>
            <th colspan="4">Part VI.    Financials</th>
          </tr>
          <tr>
            <td class="auto-style1">1. Gross    annual income for the present year</td>
            <td><asp:TextBox ID="txtAnnualIncome" MaxLength="90" Width="200" runat="server"></asp:TextBox></td>
            <td class="auto-style2">2. Gross income last year</td>
            <td><asp:TextBox ID="txtLastYearIncome" MaxLength="90"  Width="200"  runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <td class="auto-style1">3. Net    annual income for the present year</td>
            <td><asp:TextBox ID="txtNetAnnualIncome" MaxLength="90"  Width="200"  runat="server"></asp:TextBox> </td>
            <td class="auto-style2">4. Net annual income for last year</td>
            <td><asp:TextBox ID="txtLastYearNetIncome" MaxLength="90"  Width="200"  runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <th colspan="2">Required    documents</th>
            <th colspan="2">Company Preferences</th>
          </tr>
          <tr>
            <td colspan="2">1. Soft    copy of letterhead (Please email it)<br />
              2. Tax    Returns for last year, if unavailable<br />
              3.    Quarterly tax returns for the last four quarters</td>
            <td colspan="2"><asp:TextBox TextMode="MultiLine" Rows="6" ID="txtPreferences" runat="server" Columns="80" ></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th colspan="4">Comments</th>
          </tr>
          <tr>
            <td colspan="4"><asp:TextBox TextMode="MultiLine" Rows="6" ID="txtComments" runat="server" Columns="180"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td colspan="4" align="center"><asp:Button ID="btnSave" Text="Save and Submit" runat="server" 
                    onclick="btnSave_Click" /> </td>
          </tr>
        </table>
      </div>
    </div>
  </div>
  <div id="footer"><a href="http://www.raminenilaw.com/?page_id=258"> </a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a><br />
&copy; 2009 Ramineni Law Associated, LLC. All rights reserved.</div>
</div>
</form>
<script type="text/javascript">
    Calendar.setup({
        inputField     :    "txtRegistered_Date",     // id of the input field
        ifFormat       :    "%m/%d/%Y",      // format of the input field
        button         :    "f_Registered_Date",  // trigger for the calendar (button ID)
        align          :    "Br",           // alignment (defaults to "Bl")
        singleClick    :    true
    });

    
</script>
<script src="../scripts/content.js" type="text/javascript"></script>
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" Inherits="employer_myaccount" Codebehind="employer_myaccount.aspx.cs" %>
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
<script src="../scripts/mootools.js" type="text/javascript"></script>
<script src="../scripts/fadescript.js" type="text/javascript"></script>
</head>
<body>
<form runat="server">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <ul class="topNav">
      <li><a href="employer.aspx"><b>Home</b></a></li>
      <li><a href="employer_manage.aspx"><b>Add New Employee</b></a></li>
      <li class="current"><a href="employer_myaccount.aspx"><b>My Account</b></a></li>
    </ul>
    <div id="contentArea3">
      <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
          <td width="2"><img src="../images/topbar_lft.gif" width="2" height="87" /></td>
          <td class="topbar_bg">
          <table border="0" cellspacing="0" cellpadding="5">
            <tr>
                <td>&raquo; <a href="changepassword.aspx">Change Password</a></td>
             </tr>
            </table></td>
          <td width="2"><img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
        </tr>
      </table>
      <div class="shadow"></div>
      <div class="title">My Account</div>
      <div class="bcru"><a href="employer.aspx">Home</a> &raquo; My Account</div>
      <div id="whiteArea">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <th colspan="4">Part I - Company Contact Information</th>
          </tr>
          <tr>
            <td width="30%">1. Legal    Name of Company</td>
            <td width="20%"><asp:TextBox ID="txtLegal_Name"  runat="server" Width="303px"></asp:TextBox></td>
            <td width="30%">2.  Type    of Company - LLC/Inc/Sole Proprietor</td>
            <td width="20%"><asp:TextBox ID="txtCompany_Type" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td>3. Mailing Address</td>
            <td><asp:TextBox ID="txtAptNo" Width="200px" runat="server"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(Suite #)"></asp:Label>
            <br /><asp:TextBox ID="txtStreet" Width="200px" runat="server"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(Number & Street)"></asp:Label>
            <br /><asp:TextBox id="txtCity" runat="server" Width="200px"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(City)"></asp:Label>
            <br /><asp:TextBox ID="txtState" runat="server" Width="200px"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(State)"></asp:Label>
            <br /><asp:TextBox ID="txtZipCode" runat="server" Width="200px"></asp:TextBox><asp:Label Font-Size="Smaller" runat="server"  Text="(Zip Code)"></asp:Label>
            </td>
            <td>4. Address where all documents should be sent</td>
            <td><asp:TextBox ID="txtDocuments_Address" TextMode="MultiLine" Rows="4" 
                    Columns="40" runat="server" Height="90px"></asp:TextBox></td>
          </tr>
          <tr>
            <td>5. Phone Number</td>
            <td align="left">
                <asp:TextBox ID="txtPhone_No_Code" Width="50" runat="server"></asp:TextBox>-<asp:TextBox ID="txtPhone_No" runat="server"></asp:TextBox>
                <br /><asp:Label runat="server" Font-Size="Small" ForeColor="GrayText" Text="(Code)"></asp:Label>
            </td>
            <td>6. Fax    No.</td>
            <td><asp:TextBox ID="txtFax_No" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td>7. Alternate Phone Number</td>
            <td><asp:TextBox ID="txtAlternate_Phone_No_Code" Width="50" runat="server"></asp:TextBox>-<asp:TextBox ID="txtAlternate_Phone_No"  runat="server"></asp:TextBox>
            <br /><asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="GrayText" Text="(Code)"></asp:Label>
            </td>
            <td>8. Web address</td>
            <td><asp:TextBox ID="txtWeb_Address" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4">Part II -    Registration Information</th>
          </tr>
          <tr>
            <td>1. EIN    Number/FEIN/Federal ID No.</td>
            <td><asp:TextBox ID="txtEIN_Number" Width="200" runat="server"></asp:TextBox></td>
            <td>2. Date Registered</td>
            <td><input type="text" runat="server" id="txtRegistered_Date" readonly />&nbsp;<a href="#" id="f_Registered_Date"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>
          </tr>
          <tr>
            <td>3. State    of Registration</td>
            <td><asp:TextBox ID="txtRegistration_State" Width="200" runat="server"/></td>
            <td>4. NAICS_Code</td>
            <td><asp:TextBox  id="txtNaics_Code"  runat="server"/></td>
          </tr>
          <tr>
            <th colspan="4">Part III    - Signatory Information</th>
          </tr>
          <tr>
            <td>1. Full    name of the person who will sign all forms</td>
            <td><asp:TextBox ID="txtPerson_FullName" Width="200" MaxLength="100" runat="server"></asp:TextBox></td>
            <td>2. Designation</td>
            <td><asp:TextBox ID="txtPerson_Designation" Width="150" MaxLength="100" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td>3.    Contact No.</td>
            <td><asp:TextBox ID="txtPerson_ContactNo" Width="150" runat="server" runat="server" MaxLength="50"></asp:TextBox></td>
            <td>4. Cell No.</td>
            <td><asp:TextBox ID="txtPerson_CellNo" Width="150" runat="server" runat="server" MaxLength="50"></asp:TextBox></td>
          </tr>
          <tr>
            <td>5. E Mail    Address</td>
            <td><asp:TextBox ID="txtPerson_Email"  Width="200" runat="server" MaxLength="100"></asp:TextBox></td>
            <td>6. Fax No.</td>
            <td><asp:TextBox ID="txtPerson_Fax"  Width="150" MaxLength="30" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4">Part IV. Nature of Business</th>
          </tr>
          <tr>
            <td>1. Describe company activities briefly</td>
            <td><asp:TextBox TextMode="MultiLine" Rows="4" Columns="40" ID="txtDescription" runat="server"></asp:TextBox> </td>
            <td>2. Does the Company have any affiliates</td>
            <td><asp:TextBox ID="txtHaveAffiliates" TextMode="MultiLine" Rows="4" Columns="40" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <th colspan="4">Part V.    Information about Employees</th>
          </tr>
          <tr>
            <td>1. Curent    number of employees</td>
            <td><asp:TextBox ID="txtNoofEmployees" runat="server" MaxLength="5"></asp:TextBox></td>
            <td>2. Current number of H1B employees</td>
            <td><asp:TextBox ID="txtNoofH1BEmployees" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td>3. How    many H-1Bs did you file todate</td>
            <td><asp:TextBox ID="txtFileToDate" runat="server" MaxLength="5"></asp:TextBox> </td>
            <td>4. Did you withdraw any H-1Bs</td>
            <td><asp:TextBox ID="txtWithdrawanyH1Bs" runat="server" ></asp:TextBox> </td>
          </tr>
          <tr>
            <td>5. Were    any H-1B Petitions denied</td>
            <td><asp:TextBox ID="txtH1bPetitionsDenied" runat="server" MaxLength="20"></asp:TextBox></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <th colspan="4">Part VI.    Financials</th>
          </tr>
          <tr>
            <td>1. Gross    annual income for the present year</td>
            <td><asp:TextBox ID="txtAnnualIncome" MaxLength="90" Width="200" runat="server"></asp:TextBox></td>
            <td>2. Gross income last year</td>
            <td><asp:TextBox ID="txtLastYearIncome" MaxLength="90"  Width="200"  runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <td>3. Net    annual income for the present year</td>
            <td><asp:TextBox ID="txtNetAnnualIncome" MaxLength="90"  Width="200"  runat="server"></asp:TextBox> </td>
            <td>4. Net annual income for last year</td>
            <td><asp:TextBox ID="txtLastYearNetIncome" MaxLength="90"  Width="200"  runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <th colspan="2">Required    documents</th>
            <th colspan="2">Comments</th>
          </tr>
          <tr>
            <td colspan="2">1. Soft    copy of letterhead (Please email it)<br />
              2. Tax    Returns for last year, if unavailable<br />
              3.    Quarterly tax returns for the last four quarters</td>
            <td colspan="2"><asp:TextBox TextMode="MultiLine" Rows="6" ID="txtComments" runat="server" Columns="80" ></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td colspan="4" align="center"><asp:Button ID="btnSave" Text="&nbsp;Update&nbsp;" runat="server" 
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
<input id="flag" value="1" type="hidden"/>
<div id="loading"  runat="server"></div>
</body>
</html>


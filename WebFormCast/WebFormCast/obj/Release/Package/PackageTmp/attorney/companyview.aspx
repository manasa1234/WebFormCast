<%@ Page Language="C#" AutoEventWireup="true" Inherits="attorney_companyview" Codebehind="companyview.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>USIT</title>
<link href="../css/styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="Form1" runat="server">
<div id="container">
  <div id="header">
  <div id="headerlogo"><asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>  
  <div id="login_info">Welcome! <strong><asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
  </div>
  <div id="contentShadows">
    <asp:Label ID="lbNavigation" runat="server"><ul class="topNav">
      <li ><a href="home.aspx"><b>Home</b></a></li>
      <li class="current"><a href="clientmanager.aspx"><b>Client Manager</b></a></li>
      <li><a href="useraccounts.aspx"><b>User Account's</b></a></li>
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
      <div class="title"><asp:Label ID="lbCompnayName" runat="server"></asp:Label></div>
      <div class="bcru"><a href="cases.aspx">Cases</a> &raquo; <a href="clientmanager.aspx">Client Manager</a></div>
      <div id="whiteArea">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
          <tr>
            <th colspan="4">Part I - Company Contact Information</th>
          </tr>
          <tr>
            <td width="30%">1. Legal    Name of Company</td>
            <td width="20%"><asp:Label ID="txtLegal_Name"  runat="server" Width="303px"></asp:Label></td>
            <td width="30%">2.  Type    of Company - LLC/Inc/Sole Proprietor</td>
            <td width="20%"><asp:Label ID="txtCompany_Type" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td>3. Mailing Address</td>
            <td><asp:Label ID="txtAptNo" Width="200px" runat="server"></asp:Label><asp:Label ID="Label1" Font-Size="Smaller" runat="server"  Text="(Suite #)"></asp:Label>
            <br /><asp:Label ID="txtStreet" Width="200px" runat="server"></asp:Label><asp:Label ID="Label2" Font-Size="Smaller" runat="server"  Text="(Number & Street)"></asp:Label>
            <br /><asp:Label id="txtCity" runat="server" Width="200px"></asp:Label><asp:Label ID="Label3" Font-Size="Smaller" runat="server"  Text="(City)"></asp:Label>
            <br /><asp:Label ID="txtState" runat="server" Width="200px"></asp:Label><asp:Label ID="Label4" Font-Size="Smaller" runat="server"  Text="(State)"></asp:Label>
            <br /><asp:Label ID="txtZipCode" runat="server" Width="200px"></asp:Label><asp:Label ID="Label5" Font-Size="Smaller" runat="server"  Text="(Zip Code)"></asp:Label>
            </td>
            <td>4. Address where all documents should be sent</td>
            <td><asp:Label ID="txtDocuments_Address" TextMode="MultiLine" Rows="4" 
                    Columns="40" runat="server" Height="90px"></asp:Label></td>
          </tr>
          <tr>
            <td>5. Phone Number</td>
            <td align="left">
                <asp:Label ID="txtPhone_No_Code" Width="50" runat="server"></asp:Label>-<asp:Label ID="txtPhone_No" runat="server"></asp:Label>
                <br /><asp:Label ID="Label6" runat="server" Font-Size="Small" ForeColor="GrayText" Text="(Code)"></asp:Label>
            </td>
            <td>6. Fax    No.</td>
            <td><asp:Label ID="txtFax_No" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td>7. Alternate Phone Number</td>
            <td><asp:Label ID="txtAlternate_Phone_No_Code" Width="50" runat="server"></asp:Label>-<asp:Label ID="txtAlternate_Phone_No"  runat="server"></asp:Label>
            <br /><asp:Label ID="Label7" runat="server" Font-Size="Small" ForeColor="GrayText" Text="(Code)"></asp:Label>
            </td>
            <td>8. Web address</td>
            <td><asp:Label ID="txtWeb_Address" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <th colspan="4">Part II -    Registration Information</th>
          </tr>
          <tr>
            <td>1. EIN    Number/FEIN/Federal ID No.</td>
            <td><asp:Label ID="txtEIN_Number" Width="200" runat="server"></asp:Label></td>
            <td>2. Date Registered</td>
            <td><input type="text" runat="server" id="txtRegistered_Date" readonly /></td>
          </tr>
          <tr>
            <td>3. State    of Registration</td>
            <td><asp:Label ID="txtRegistration_State" Width="200" runat="server"/></td>
            <td>4. NAICS Code:</td>
            <td><asp:Label id="txtNaics_Code"  runat="server"/></td>
          </tr>
          <tr>
            <th colspan="4">Part III    - Signatory Information</th>
          </tr>
          <tr>
            <td>1. Full    name of the person who will sign all forms</td>
            <td><asp:Label ID="txtPerson_FullName" Width="200" MaxLength="100" runat="server"></asp:Label></td>
            <td>2. Designation</td>
            <td><asp:Label ID="txtPerson_Designation" Width="150" MaxLength="100" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td>3.    Contact No.</td>
            <td><asp:Label ID="txtPerson_ContactNo" Width="150" runat="server" runat="server" MaxLength="50"></asp:Label></td>
            <td>4. Cell No.</td>
            <td><asp:Label ID="txtPerson_CellNo" Width="150" runat="server" runat="server" MaxLength="50"></asp:Label></td>
          </tr>
          <tr>
            <td>5. Login E Mail Address</td>
            <td><asp:Label ID="txtPerson_Email"  Width="200" runat="server" MaxLength="50"></asp:Label></td>
            <td>6. Fax No.</td>
            <td><asp:Label ID="txtPerson_Fax"  Width="150" MaxLength="30" runat="server"></asp:Label></td>
          </tr>

          <tr>
            <td>7. Contact Information</td>
            <td><asp:Label ID="txtContact_Info" TextMode="MultiLine" Rows="4" Columns="40" runat="server" Height="90px"></asp:Label></td>
            <td>8. Temporary Contact (if applicable)</td>
            <td><asp:Label ID="txtTemp_Contact_Info" TextMode="MultiLine" Rows="4" Columns="40" runat="server" Height="90px"></asp:Label></td>
          </tr>

          <tr>
            <td>9. NIV Contact Information</td>
            <td><asp:Label ID="txtNIV_Contact_Info"  Width="200" runat="server" MaxLength="50"></asp:Label></td>
            <td>10. Accounting Contact Information</td>
            <td><asp:Label ID="txtAcc_Contact_Info"  Width="150" MaxLength="30" runat="server"></asp:Label></td>
          </tr>

          <tr>
            <td>11. IV Contact Information</td>
            <td><asp:Label ID="txtIV_Contact_Info"  Width="200" runat="server" MaxLength="50"></asp:Label></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
          </tr>

          <tr>
            <th colspan="4">Part IV. Nature of Business</th>
          </tr>
          <tr>
            <td>1. Describe company activities briefly</td>
            <td><asp:Label TextMode="MultiLine" Rows="4" Columns="40" ID="txtDescription" runat="server"></asp:Label> </td>
            <td>2. Does the Company have any affiliates</td>
            <td><asp:Label ID="txtHaveAffiliates" TextMode="MultiLine" Rows="4" Columns="40" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <th colspan="4">Part V.    Information about Employees</th>
          </tr>
          <tr>
            <td>1. Current    number of employees</td>
            <td><asp:Label ID="txtNoofEmployees" runat="server" MaxLength="5"></asp:Label></td>
            <td>2. Current number of H1B employees</td>
            <td><asp:Label ID="txtNoofH1BEmployees" runat="server"></asp:Label></td>
          </tr>
          <tr>
            <td>3. H-1B Dependent</td>
            <td><asp:Label ID="txtH1B_Dependent" runat="server" MaxLength="5"></asp:Label> </td>
            <td>4. Subject to Public Law (50/50)</td>
            <td><asp:Label ID="txtPublic_Law" runat="server" MaxLength="5"></asp:Label> </td>
          </tr>
          <tr>
            <th colspan="4">Part VI.    Financials</th>
          </tr>
          <tr>
            <td>1. Gross    annual income for the present year</td>
            <td><asp:Label ID="txtAnnualIncome" MaxLength="90" Width="200" runat="server"></asp:Label></td>
            <td>2. Gross income last year</td>
            <td><asp:Label ID="txtLastYearIncome" MaxLength="90"  Width="200"  runat="server"></asp:Label> </td>
          </tr>
          <tr>
            <td>3. Net    annual income for the present year</td>
            <td><asp:Label ID="txtNetAnnualIncome" MaxLength="90"  Width="200"  runat="server"></asp:Label> </td>
            <td>4. Net annual income for last year</td>
            <td><asp:Label ID="txtLastYearNetIncome" MaxLength="90"  Width="200"  runat="server"></asp:Label> </td>
          </tr>
          <tr>
            <th colspan="2">Required    documents</th>
            <th colspan="2">Company Preferences</th>
          </tr>
          <tr>
            <td colspan="2">1. Soft    copy of letterhead (Please email it)<br />
              2. Tax    Returns for last year, if unavailable<br />
              3.    Quarterly tax returns for the last four quarters</td>
            <td colspan="2"><asp:Label TextMode="MultiLine" Rows="6" ID="txtPreferences" runat="server" Columns="80" ></asp:Label>
            </td>
          </tr>
          <tr>
            <th colspan="4">Comments</th>
          </tr>
          <tr>
            <td colspan="4"><asp:Label TextMode="MultiLine" Rows="6" ID="txtComments" runat="server" Columns="80" ></asp:Label>
            </td>
          </tr>


          <tr>
            <td colspan="4" align="center"></td>
          </tr>
        </table>
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

<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h05" Codebehind="form_i129h05.aspx.cs" %>
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
            <th colspan="4" align="left">Part 5. Basic information about the proposed employment and employer. <em style="font-weight:normal">Attach the supplement relating to the classification you are requesting.</em></th>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>1.</strong></td>
            <td valign="top">Job Title</td>
            <td rowspan="2" align="right" valign="top"><strong>2.</strong></td>
            <td valign="top">LCA or ETA Case Number</td>
          </tr>
          <tr>
            <td valign="top"><asp:TextBox Width="250px" CssClass="input_edit" ID="f5_Job_Title" runat="server"></asp:TextBox> </td>
            <td valign="top"><asp:TextBox ID="f5_LCA_Case_Number" CssClass="input_edit" Width="200px" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>3.</strong></td>
            <td colspan="3" valign="top">Address where the person(s) will work if different from address in Part 1. (Street number and name, city/town, state, zip code)</td>
          </tr>
          <tr>
            <td colspan="3" valign="top"><asp:TextBox ID="f5_different_from_address" Rows="5" Columns="100" CssClass="input_edit" TextMode="MultiLine" runat="server"></asp:TextBox> </td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>4.</strong></td>
            <td valign="top">Is an itinerary included with the petition?</td>
            <td rowspan="2" align="right" valign="top"><strong>5.</strong></td>
            <td valign="top">Will the beneficiary work off-site?</td>
          </tr>
          <tr>
            <td valign="top">NO/YES TBD</td>
            <td valign="top">NO/YES TBD</td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>6.</strong></td>
            <td colspan="3" valign="top">Will the beneficiary(ies) work exclusively in the CNMI?</td>
          </tr>
          <tr>
            <td colspan="3" valign="top">NO/YES TBD</td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>7.</strong></td>
            <td valign="top">Is this a full-time position?</td>
            <td rowspan="2" align="right" valign="top"><strong>8.</strong></td>
            <td valign="top">Wages per week or per year:</td>
          </tr>
          <tr>
            <td valign="top">
              <asp:RadioButton ID="f5_Is_this_a_fulltime_positionNo" CssClass="input_normal_wb" runat="server" GroupName="g1" /> No
              <asp:RadioButton ID="f5_Is_this_a_fulltime_positionYes" CssClass="input_normal_wb" runat="server" GroupName="g1" /> Yes              
              &nbsp;&nbsp;If "No," Hours per week:
              <asp:TextBox ID="f5_Hours_per_week" runat="server" CssClass="input_edit" Width="100px" ></asp:TextBox>
            </td>
            <td colspan="2" valign="top">
              <asp:TextBox ID="f5_Wages_per_week_Year" CssClass="input_edit" Width="100px" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>9.</strong></td>
            <td valign="top">Other Compensation <em>(Explain):</em></td>
            <td rowspan="2" align="right" valign="top"><strong>10.</strong></td>
            <td valign="top">Dates of intended employment <em>(mm/dd/yyyy)</em>:</td>
          </tr>
          <tr>
            <td valign="top"><asp:TextBox ID="f5_Other_Compensation"  CssClass="input_edit" Width="250px"  runat="server"></asp:TextBox>  </td>
            <td valign="top">From:
              <input id="f5_Dates_of_intended_employment1"  Class="input_edit" Width="100px"  runat="server" />
              To:
              <input id="f5_Dates_of_intended_employment2"  Class="input_edit" Width="100px"  runat="server" /></td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>11.</strong></td>
            <td colspan="3" valign="top"><em>Type of Business</em></td>
          </tr>
          <tr>
            <td colspan="3" valign="top"><asp:TextBox ID="f5_Type_of_Business" CssClass="input_edit" Width="250px" runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>12.</strong></td>
            <td valign="top">Year Established</td>
            <td rowspan="2" align="right" valign="top"><strong>13.</strong></td>
            <td valign="top">Current Number of Employees in the U.S.</td>
          </tr>
          <tr>
            <td valign="top"><asp:TextBox ID="f5_Year_Established"  CssClass="input_edit" Width="250px" runat="server"></asp:TextBox></td>
            <td valign="top"><asp:TextBox ID="f5_Current_Number_of_Employees" CssClass="input_edit" Width="250px"  runat="server"></asp:TextBox></td>
          </tr>
          <tr>
            <td rowspan="2" align="right" valign="top"><strong>14.</strong></td>
            <td valign="top">Gross Annual Income</td>
            <td rowspan="2" align="right" valign="top"><strong>15.</strong></td>
            <td valign="top">Net Annual Income</td>
          </tr>
          <tr>
            <td valign="top"><asp:TextBox  CssClass="input_edit" Width="150px" ID="f5_Gross_Annual_Income" runat="server"></asp:TextBox> </td>
            <td valign="top"><asp:TextBox ID="f5_Net_Annual_Income"  CssClass="input_edit" Width="150px"  runat="server"></asp:TextBox> </td>
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


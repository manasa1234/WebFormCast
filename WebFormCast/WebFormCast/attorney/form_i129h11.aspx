<%@ Page Language="C#" AutoEventWireup="true" Inherits="form_i129h11" Codebehind="form_i129h11.aspx.cs" %>
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
            <td width="120" align="right"><strong>Petitioner's Name</strong></td>
            <td><asp:TextBox ID="f11_Petitioners_Name" CssClass="input_edit" runat="server" 
                    Width="327px"></asp:TextBox></td>
          </tr>
        </table>
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <th colspan="3" align="left">Part A. General Information.</th>
          </tr>
          <tr>
            <td colspan="3">&nbsp;</td>
          </tr>
          <tr>
            <th colspan="3" align="left">1. Employer Information - <em>(check all items that apply)</em></th>
          </tr>
          <tr>
            <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><strong>a.</strong> Is the petitioner a dependent employer?</td>
                  <td><asp:RadioButton ID="f11_Is_the_petitioner_a_dependent_employerNo" CssClass="input_normal_wb" runat="server" GroupName="g1" />
                    No</td>
                  <td><asp:RadioButton ID="f11_Is_the_petitioner_a_dependent_employerYes"  CssClass="input_normal_wb"  runat="server" GroupName="g1" />
                    Yes</td>
                </tr>
                <tr>
                  <td><strong>b.</strong> Has the petitioner ever been found to be a willful violator?</td>
                  <td><asp:RadioButton ID="f11_found_to_be_a_willful_violatorNo" runat="server"  CssClass="input_normal_wb" GroupName="g2" />
                    No</td>
                  <td><asp:RadioButton ID="f11_found_to_be_a_willful_violatorYes" runat="server"  CssClass="input_normal_wb" GroupName="g2" />
                    Yes</td>
                </tr>
                <tr>
                  <td><strong>c. </strong>Is the beneficiary an exempt H-1B nonimmigrant?</td>
                  <td><asp:RadioButton id="f11_exempt_H1B_nonimmigrant1No" runat="server"  CssClass="input_normal_wb" GroupName="g3" />
                    No</td>
                  <td><asp:RadioButton ID="f11_exempt_H1B_nonimmigrant1Yes" runat="server"  CssClass="input_normal_wb" GroupName="g3" />
                    Yes</td>
                </tr>
                <tr>
                  <td><blockquote>
                      <p><strong>1.</strong> If yes, is it because the beneficiary's annual rate of pay is equal to at least $60,000?</p>
                  </blockquote></td>
                  <td><asp:RadioButton ID="f11_exempt_H1B_nonimmigrant2No"  CssClass="input_normal_wb"  runat="server" GroupName="g4" />
                    No</td>
                  <td><asp:RadioButton ID="f11_exempt_H1B_nonimmigrant2Yes"  CssClass="input_normal_wb"  runat="server" GroupName="g4" />
                    Yes</td>
                </tr>
                <tr>
                  <td><blockquote>
                      <p><strong>2. </strong>Or is it because the beneficiary has a master's or higher degree in a speciality related to the employment?</p>
                  </blockquote></td>
                  <td><asp:RadioButton ID="f11_BeneficiaryAnnualMaster1"  CssClass="input_normal_wb"  runat="server" GroupName="g5" />
                    No</td>
                  <td><asp:RadioButton ID="f11_BeneficiaryAnnualMaster2"  CssClass="input_normal_wb"  runat="server" GroupName="g5" />
                    Yes</td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th colspan="3" align="left">2.</th>
          </tr>
          <tr>
            <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td>Beneficiary' s Last Name</td>
                  <td>First Name</td>
                  <td><strong></strong>MiddleName Name</td>
                </tr>
                <tr>
                  <td><asp:TextBox  ID="f11_Beneficiarys_Last_Name"  CssClass="input_edit" 
                          runat="server" Width="167px"></asp:TextBox></td>
                  <td><asp:TextBox ID="f11_First_Name" CssClass="input_edit"  runat="server" 
                          Width="279px"></asp:TextBox> </td>
                  <td><asp:TextBox ID="f11_Middle_Name" CssClass="input_edit"  runat="server" 
                          Width="153px"></asp:TextBox>  </td>
                </tr>
                <tr>
                  <td>Attention To or In Care Of</td>
                  <td>Current Residential Address - Street Number and Name</td>
                  <td>Apt. #</td>
                </tr>
                <tr>
                  <td><asp:TextBox ID="f11_In_Care_Of" runat="server" CssClass="input_edit" 
                          Width="161px"></asp:TextBox> </td>
                  <td><asp:TextBox ID="f11_Current_Street_Number_and_Name" runat="server" 
                          CssClass="input_edit" Width="269px"/> </td>
                  <td><asp:TextBox ID="f11_AptNo" runat="server" CssClass="input_edit"/> </td>
                </tr>
                <tr>
                  <td>City</td>
                  <td>State</td>
                  <td>Zip/Postal Code</td>
                </tr>
                <tr>
                  <td><asp:TextBox ID="f11_City" runat="server" CssClass="input_edit" 
                          Width="161px"></asp:TextBox> </td>
                  <td><asp:TextBox ID="f11_State" runat="server" 
                          CssClass="input_edit" Width="269px"/> </td>
                  <td><asp:TextBox ID="f11_Zip" runat="server" CssClass="input_edit"/> </td>
                </tr>
                
                <tr>
                  <td>U.S. Social Security #<em> (If Any)</em></td>
                  <td>I-94 #<em> (Arrival/Departure Document)</em></td>
                  <td>Previous Receipt #<em> (If Any)</em></td>
                </tr>
                <tr>
                  <td><asp:TextBox ID="f11_Social_Security" runat="server" CssClass="input_edit" 
                          Width="157px"/>  </td>
                  <td><asp:TextBox ID="f11_I94" runat="server" CssClass="input_edit"/> </td>
                  <td><asp:TextBox ID="f11_Previous_Receipt" runat="server" CssClass="input_edit"/> </td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th colspan="3" align="left">3. Beneficiary's Highest Level of Education. Please check one box below.</th>
          </tr>
          <tr>
            <td colspan="3"><table widht="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education1" runat="server" GroupName="g11" /> </td>
                  <td>NO DIPLOMA</td>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education2" runat="server" GroupName="g11" /></td>
                  <td>Associate's degree <em>(for example: AA, AS)</em></td>
                </tr>
                <tr>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education3" runat="server" GroupName="g11" /></td>
                  <td>HIGH SCHOOL GRADUATE - high school 
                    DIPLOMA or the equivalent (example: GED)</td>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education4" runat="server" GroupName="g11" /></td>
                  <td>Bachelor's degree<em> (for example: BA, AB, BS)</em></td>
                </tr>
                <tr>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education5" runat="server" GroupName="g11" /></td>
                  <td>Some college credit, but less than one year</td>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education6" runat="server" GroupName="g11" /></td>
                  <td>Master's degree<em> (for example: MA, MS, MEng, MEd, MSW, MBA)</em></td>
                </tr>
                <tr>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education7" runat="server" GroupName="g11" /></td>
                  <td>One or more years of college, no degree</td>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education8" runat="server" GroupName="g11" /></td>
                  <td>Professional degree <em>(for example: MD, DDS, DVM, LLB, JD)</em></td>
                </tr>
                <tr>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td><asp:RadioButton ID="f11_Highest_Level_of_Education9" runat="server" GroupName="g11" /></td>
                  <td>Doctorate degree<em> (for example: PhD, EdD)</em></td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th colspan="3" align="left">4. Major/Primary Field of Study.</th>
          </tr>
          <tr>
            <td colspan="3"><asp:TextBox CssClass="input_edit" ID="f11_Primary_Field_of_Study" 
                    runat="server" Width="313px" MaxLength="50"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <th colspan="3" align="left">5. Has the beneficiary of this petition earned a master's or higher degree from a U.S. institution of higher education as defined in 20 U.S.C. section 1001(a)?</th>
          </tr>
          <tr>
            <td colspan="3"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td rowspan="5" valign="top"><asp:RadioButton  GroupName="higher"  id="f11_higher_degree_from_a_USNo" runat="server" />
                    No</td>
                  <td colspan="3"><asp:RadioButton id="f11_higher_degree_from_a_USYes"  GroupName="higher"  runat="server" />
                    Yes (If &quot;Yes&quot; provide the following information):</td>
                </tr>
                <tr>
                  <td>Name of the U.S. institution of higher education</td>
                  <td>Date Degree Awarded</td>
                  <td>Type of U.S. Degree</td>
                </tr>
                <tr>
                  <td><asp:TextBox CssClass="input_edit"  ID="f11_Name_of_the_US_institution" 
                          runat="server" Width="250px"></asp:TextBox></td>
                  <td><asp:TextBox CssClass="input_edit"  ID="f11_Date_Degree_Awarded" runat="server" 
                          Width="157px"></asp:TextBox></td>
                  <td><asp:TextBox CssClass="input_edit"  ID="f11_Type_of_US_Degree" runat="server" 
                          Width="133px"></asp:TextBox></td>
                </tr>
                <tr>
                  <td colspan="3">Address of the U.S. institution of higher education</td>
                </tr>
                <tr>
                  <td colspan="3"><asp:TextBox CssClass="input_edit"  ID="f11_Address_of_the_US_institution" runat="server" TextMode="MultiLine" Rows="6" Columns="50"></asp:TextBox></td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <th align="left">6. Rate of Pay Per Year.</th>
            <th align="left">7. LCA Code.</th>
            <th align="left">8. NAICS Code.</th>
          </tr>
          <tr>
            <td><asp:TextBox CssClass="input_edit"  ID="f11_Rate_of_Pay_Per_Year" runat="server"></asp:TextBox> </td>
            <td><asp:TextBox CssClass="input_edit"  ID="f11_LCA_Code" runat="server"></asp:TextBox></td>
            <td><asp:TextBox CssClass="input_edit"  ID="f11_NAICS_Code" runat="server"></asp:TextBox></td>
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

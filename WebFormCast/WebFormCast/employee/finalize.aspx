<%@ Page Language="C#" AutoEventWireup="true" Inherits="employee_finalize" CodeBehind="finalize.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USIT</title>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/mootools.js" type="text/javascript"></script>
    <script src="../scripts/fadescript.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>
                <div id="login_info">Welcome, <strong>
                    <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
            </div>
            <div id="contentShadows">
                <ul class="topNav">
                    <li class="current"><a href="employee.aspx"><b>Employee</b></a></li>
                </ul>
                <div id="contentArea1">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tr>
                            <td width="2">
                                <img src="../images/topbar_lft.gif" width="2" height="87" /></td>
                            <td class="topbar_bg">
                                <table border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee.aspx">
                                            <img src="../images/ep_icon01_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Personal Information</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee2.aspx">
                                            <img src="../images/ep_icon02_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Education Details</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" runat="server" id="tbEmployment" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee3.aspx">
                                            <img src="../images/ep_icon03_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Experience Details</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" runat="server" id="tbDependent" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg_gry"><a href="employee4.aspx">
                                            <img src="../images/ep_icon04_dis.png" width="42" height="42" align="absmiddle" />
                                            <strong>Dependant's Details</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                                <table border="0" runat="server" id="Table1" align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg"><a href="finalize.aspx">
                                            <strong>Review and Submit</strong></a></td>
                                        <td width="2">
                                            <img src="../images/topbar_sub_rgt.gif" width="2" height="78" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="2">
                                <img src="../images/topbar_rgt.gif" width="2" height="87" /></td>
                        </tr>
                    </table>
                    <div class="shadow"></div>
                    <div class="title">Employee:
                        <asp:Label ID="lbName" Text="&nbsp;" runat="server"></asp:Label></div>
                    <div id="whiteArea">
                        <div class="EmployeeStatus">Status:
                            <asp:Label ID="lbStatus" Text="Approved" runat="server"></asp:Label></div>
                        <h2>Review and Submit</h2>

                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th>COMMENTS<br />
                                    Would you like to give us additional information?</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" Columns="150" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                        </table>

                        <div>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="alert"><b>Note:</b>  After completing all your information, please cllick on the "finalize" button. After you click the "finalize" button you can't change the information. Therefore, before you finalize, please check all information and confirm that you entered all the information correctly!</td>
                                    <td>
                                        <asp:Button ID="btnFinalize" Font-Bold="true" ForeColor="Green" Text="Finalize" runat="server"
                                            OnClick="btnFinalize_Click" /></td>
                                </tr>
                            </table>
                        </div>
                        <p>Your Tracking Number is :
                            <asp:Label ID="lbTracking" Font-Bold="true" runat="server"></asp:Label></p>
                        <p>(Please note the tracking number) send the following Check List documents as attachments in the email:
                            <asp:Label Font-Bold="true" ID="lbEmployerEmail" runat="server"></asp:Label></p>

                        <p>DOCUMENTS (COPIES) TO BE FURNISHED (A-4 SIZE ONLY, REDUCE IF REQUIRED, DO NOT STAPLE)</p>
                        <ol>
                            <li>Academic  certificates - latest onwards with transcripts (marks sheets)</li>
                            <li>Training  certificates </li>
                            <li>Resume  – Latest employment mentioned first </li>
                            <li>Passport  – (Bio-data page, last page, only US Visa Pages – Do not send blank pages)</li>
                            <li>Experience  letters with skills from previous employers</li>
                        </ol>
                        <p>Additional  if in the US</p>
                        <ol>
                            <li>Latest  pay stubs of 2 months</li>
                            <li>I-94  Form</li>
                            <li>H1  Approval Notice</li>
                            <li>Education evaluation if available</li>
                        </ol>
                        <p>Additional  for GC</p>
                        <ol>
                            <li>Birth  Certificate for self &amp; dependants</li>
                            <li>Marriage  Certificate</li>
                        </ol>
                        <div align="center" class="divBlock">Please use the above Tracking Number in the subject field of your email while sending the documents.    </div>
                    </div>
                </div>
            </div>
            <div id="footer">
                <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a>
                <br />
                &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.
            </div>
        </div>
    </form>
    <input id="flag" value="1" type="hidden" />
    <div id="loading" runat="server"></div>
</body>
</html>

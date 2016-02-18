<%@ Page Language="C#" AutoEventWireup="true" Inherits="employee_employee3" CodeBehind="employee3.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USIT</title>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/mootools.js" type="text/javascript"></script>
    <script src="../scripts/fadescript.js" type="text/javascript"></script>
    <!--[if lt IE 7.]>
<script defer type="text/javascript" src="pngfix.js"></script>
<![endif]-->
</head>
<body>
    <form runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />--></div>
                <div id="login_info">Welcome, <strong>
                    <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a></div>
            </div>
            <div id="contentShadows">
                <ul class="topNav">
                    <li class="current"><a href="employee.html"><b>Employee</b></a></li>
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
                                        <td align="right" class="topbar_sub_bg"><a href="employee3.aspx">
                                            <img src="../images/ep_icon03.png" width="42" height="42" align="absmiddle" />
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
                                        <td align="right" class="topbar_sub_bg_gry"><a href="finalize.aspx">
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
                        <h2>Experience Information</h2>
                        <p><strong>TOTAL YEARS OF EXPERIENCE:</strong></p>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="5"><strong>EMPLOYMENT HISTORY:</strong></td>
                            </tr>
                            <tr>
                                <th>EMPLOYER &amp; ADDRESS</th>
                                <th>FROM MM/YY</th>
                                <th>TO MM/YY</th>
                                <th>SKILLS USED</th>
                                <th>DESIGNATION </th>
                                <th>ACTION</th>
                            </tr>
                            <%=strRow1%>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtEmployer" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmployer" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddMonth1" runat="server"></asp:DropDownList><asp:DropDownList ID="ddYear1" runat="server"></asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddMonth2" runat="server"></asp:DropDownList><asp:DropDownList ID="ddYear2" runat="server"></asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="txtSkills" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSkills" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtDesignation" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnButton" runat="server" Text="Save" OnClick="btnButton_Click" /></td>
                            </tr>
                            <%=strRow2%>
                        </table>
                        <br />
                        <div align="center" class="divBlock">
                            <asp:Button ID="btnContinue" runat="server" Text="Continue" CausesValidation="false"
                                OnClick="btnContinue_Click" />&nbsp;&nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
                                OnClick="btnCancel_Click" />
                        </div>
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


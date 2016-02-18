<%@ Page Language="C#" AutoEventWireup="true" Inherits="employee_employee2" CodeBehind="employee2.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>USIT</title>
    <link href="../css/styles.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7.]>
<script defer type="text/javascript" src="pngfix.js"></script>
<![endif]-->
    <script src="../scripts/mootools.js" type="text/javascript"></script>
    <script src="../scripts/fadescript.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 79px;
        }

        .auto-style2 {
            background-image: url('../images/topbar_sub_bg_gry.gif');
            background-repeat: repeat-x;
            padding: 0 8px 0 8px;
            color: #666666;
            height: 79px;
        }
    </style>
</head>
<body>
    <form runat="server">
        <div id="container">
            <div id="header">
                <div id="headerlogo">
                    <asp:Label ID="lbCompanyLogoText" runat="server"></asp:Label><!--<img src="../images/logo.gif" width="160" height="45" />-->
                </div>
                <div id="login_info">
                    Welcome, <strong>
                        <asp:Label ID="lbUserName" runat="server"></asp:Label></strong> | <a href="index.aspx?action=1">Logout</a>
                </div>
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
                                        <td align="right" class="topbar_sub_bg"><a href="employee2.aspx">
                                            <img src="../images/ep_icon02.png" width="42" height="42" align="absmiddle" />
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
                    <div class="title">
                        Employee:
                        <asp:Label ID="lbName" Text="&nbsp;" runat="server"></asp:Label>
                    </div>
                    <div id="whiteArea">
                        <div class="EmployeeStatus">
                            Status:
                            <asp:Label ID="lbStatus" Text="Approved" runat="server"></asp:Label>
                        </div>
                        <h2>Education Information</h2>
                        <a name="Education"></a>
                        <table widht="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <th colspan="3" align="left">Beneficiary's Highest Level of Education. Please check one box below.</th>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table widht="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve1" runat="server" GroupName="g1" />
                                            </td>
                                            <td>NO DIPLOMA</td>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve2" runat="server" GroupName="g1" /></td>
                                            <td>Associate's degree <em>(for example: AA, AS)</em></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve3" runat="server" GroupName="g1" /></td>
                                            <td>HIGH SCHOOL GRADUATE - high school 
                    DIPLOMA or the equivalent (example: GED)</td>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve4" runat="server" GroupName="g1" /></td>
                                            <td>Bachelor's degree<em> (for example: BA, AB, BS)</em></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve5" runat="server" GroupName="g1" /></td>
                                            <td>Some college credit, but less than one year</td>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve6" runat="server" GroupName="g1" /></td>
                                            <td>Master's degree<em> (for example: MA, MS, MEng, MEd, MSW, MBA)</em></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve7" runat="server" GroupName="g1" /></td>
                                            <td>One or more years of college, no degree</td>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve8" runat="server" GroupName="g1" /></td>
                                            <td>Professional degree <em>(for example: MD, DDS, DVM, LLB, JD)</em></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:RadioButton ID="rbHighestLeve9" runat="server" GroupName="g1" /></td>
                                            <td>Doctorate degree<em> (for example: PhD, EdD)</em></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <th colspan="3" align="left">Major/Primary Field of Study.</th>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox ID="txtPrimaryFieldofStudy" runat="server" Width="200" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th colspan="3" align="left">Did you earned a master's or higher degree from a U.S. institution of higher education as defined in 20 U.S.C. section 1001(a)?</th>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td rowspan="5" valign="top">
                                                <asp:RadioButton GroupName="G2" ID="chMasterDegreeFromUS1" runat="server" />
                                                No</td>
                                            <td colspan="3">
                                                <asp:RadioButton ID="chMasterDegreeFromUS2" GroupName="G2" runat="server" />
                                                Yes (If &quot;Yes&quot; provide the following information):</td>
                                        </tr>
                                        <tr>
                                            <td>Name of the U.S. institution of higher education</td>
                                            <td>Date Degree Awarded</td>
                                            <td>Type of U.S. Degree</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtUSInstitutionName" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSDateDegreeAwarded" runat="server"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUSDegreeType" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">Address of the U.S. institution of higher education</td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:TextBox ID="txtUSInstitutionAddress" runat="server" TextMode="MultiLine" Rows="6" Columns="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <br />
                        <br />
                        <h4>EDUCATIONAL  QUALIFICATIONS:</h4>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <th>UNIVERSITY / BOARD</th>
                                <th>FROM MM/YY</th>
                                <th>TO MM/YY</th>
                                <th>GRAD YR</th>
                                <th>DEGREE / DIPLOMA</th>
                                <th>Action</th>
                            </tr>
                            <%=strRow1%>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtUniversity" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtUniversity" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddMonth1" runat="server"></asp:DropDownList><asp:DropDownList ID="ddYear1" runat="server"></asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddMonth2" runat="server"></asp:DropDownList><asp:DropDownList ID="ddYear2" runat="server"></asp:DropDownList></td>
                                <td>
                                    <asp:DropDownList ID="ddYear3" runat="server"></asp:DropDownList></td>
                                <td>
                                    <asp:TextBox ID="txtDegree" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtDegree" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnButton" runat="server" Text="Save" OnClick="btnButton_Click" /></td>
                            </tr>
                            <%=strRow2%>
                        </table>
                        <br />
                        <div align="center" class="divBlock">
                            <asp:Button ID="btnSave1" runat="server" CausesValidation="false"
                                Text="Save & Continue"
                                OnClick="btnSave1_Click" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false"
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

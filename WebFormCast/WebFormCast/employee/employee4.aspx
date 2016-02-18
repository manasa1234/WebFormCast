<%@ Page Language="C#" AutoEventWireup="true" Inherits="employee_employee4" CodeBehind="employee4.aspx.cs" %>

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
                                <table border="0" runat="server" id="tbDependent" align="left" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td width="2">
                                            <img src="../images/topbar_sub_lft.gif" width="2" height="78" /></td>
                                        <td align="right" class="topbar_sub_bg"><a href="employee4.aspx">
                                            <img src="../images/ep_icon04.png" width="42" height="42" align="absmiddle" />
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
                        <h2>Dependents Information</h2>
                        <!--
        <h3 align="center">IF  APPLYING FOR H4 FOR DEPENDANT IN THE USA ONLY</h3>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td align="right">Applicant's dependents filing</td>
            <td><input type="text" name="textfield48" id="textfield75" /></td>
            <td align="right">How many?</td>
            <td><input type="text" name="textfield49" id="textfield76" /></td>
          </tr>
        </table>
        -->
                        <p>If  applying for Dependents, please give the following information:</p>
                        <p>Accompanying  documents for H4 needed:</p>
                        <ol start="1" type="1">
                            <li>Copy of Passport       with visa stamping and I-94</li>
                            <li>Prior H4       Approval Notice, if any</li>
                            <li>Marriage Certificate</li>
                        </ol>
                        <div align="right">
                            <asp:Button ID="btnNew" Text="Add New Dependant" runat="server"
                                OnClick="btnNew_Click" />
                        </div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="5"><strong>DEPENDANTS DETAILS:</strong></td>
                            </tr>
                            <tr>
                                <th>NAME</th>
                                <th>DATE OF BIRTH</th>
                                <th>PASSPORT NUMBER</th>
                                <th>EMAIL ADDRESS</th>
                                <th>ACTION</th>
                            </tr>
                            <%=strRow1%>
                        </table>
                        <br />
                        <br />
                        <asp:Panel ID="panDisplay" runat="server">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right">Relationship</td>
                                    <td>
                                        <asp:TextBox ID="txtRelation" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtRelation" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator></td>
                                    <td align="right">Last Name</td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtLastName" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator></td>
                                    <td align="right">First Name</td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtFirstName" ErrorMessage="*" runat="server"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">Middle Name</td>
                                    <td>
                                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox></td>
                                    <td align="right">Other Names</td>
                                    <td>
                                        <asp:TextBox ID="txtOtherName" runat="server"></asp:TextBox></td>
                                    <td align="right">Country of Birth</td>
                                    <td>
                                        <asp:DropDownList ID="ddCountryofBirht" runat="server"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td align="right">Country of Citizenship</td>
                                    <td>
                                        <asp:DropDownList ID="ddCountryofCitizensip" runat="server"></asp:DropDownList></td>
                                    <td align="right">Date of Birth</td>
                                    <td>
                                        <input type="text" id="txtDateofBirth" runat="server" />&nbsp;<a href="#" id="f_DateofBirth"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a></td>
                                    <td align="right">U.S. Social Security #</td>
                                    <td>
                                        <asp:TextBox ID="txtUSSocialSecurityNo" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">'A' Number</td>
                                    <td>
                                        <asp:TextBox ID="txtANumber" runat="server"></asp:TextBox></td>
                                    <td align="right">Date of First Entry in USA</td>
                                    <td>
                                        <input type="text" runat="server" id="txtDateofFirstEntry" />&nbsp;<a href="#" id="f_DateofFirstEntry"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>
                                    <td align="right">Date of Last Arrival in USA</td>
                                    <td>
                                        <input id="txtDateofLastArrival" runat="server" type="text" />&nbsp;<a href="#" id="f_DateofLastArrival"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>
                                </tr>
                                <tr>
                                    <td align="right">I-94 #</td>
                                    <td>
                                        <asp:TextBox ID="txtI94" runat="server"></asp:TextBox></td>
                                    <td align="right">Current Nonimmigrant Status</td>
                                    <td>
                                        <asp:TextBox ID="txtCurrentNonimigrationStatus" runat="server"></asp:TextBox></td>
                                    <td align="right">Status Expiry Date</td>
                                    <td>
                                        <asp:TextBox ID="txtDateStatusExpire" runat="server"></asp:TextBox>&nbsp;<a href="#" id="f_DateStatusExpire"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>
                                </tr>
                                <tr>
                                    <td align="right">Passport Number</td>
                                    <td>
                                        <asp:TextBox ID="txtPassportNo" runat="server"></asp:TextBox><asp:RequiredFieldValidator ControlToValidate="txtPassportNo" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right">Passport Country of Issuance</td>
                                    <td>
                                        <asp:DropDownList ID="txtCountryPassportIssuance" runat="server"></asp:DropDownList>
                                    </td>
                                    <td align="right">Passport Issue Date</td>
                                    <td>
                                        <input type="text" id="txtPassportIssueDate" runat="server" />&nbsp;<a href="#" id="f_PassportIssueDate"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>
                                </tr>
                                <tr>
                                    <td align="right">Passport Expiry Date</td>
                                    <td colspan="5">
                                        <input type="text" runat="server" id="txtPassportExpireDate" />&nbsp;<a href="#" id="f_PassportExpireDate"><img src="../images/icon_calender.jpg" alt="" width="14" height="14" border="0" align="absmiddle" /></a> </td>

                                </tr>
                                <tr>
                                    <td align="right">Foreign address (as in passport)</td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtForeignaddress" runat="server" Columns="150"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">Phone number</td>
                                    <td>
                                        <asp:TextBox ID="txtDaytimeTelephonenumber" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="right">Email address</td>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtEmailaddress" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">U.S. Address</td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txtUSAddress" runat="server" Columns="150"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Button ID="btnAdd" runat="server"
                                            Text="Submit" OnClick="btnAdd_Click" />&nbsp;&nbsp;<asp:Button ID="Button1"
                                                runat="server" Text="Cancel" OnClick="Button1_Click" CausesValidation="false" /></td>
                                </tr>
                            </table>

                        </asp:Panel>
                        <br />
                        <div align="center" class="divBlock">
                            <asp:Button ID="btnButton" runat="server" Text="Continue" OnClick="btnButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
            <div id="footer">
                <a href="http://www.raminenilaw.com/?page_id=258"></a><a href="http://www.raminenilaw.com/?page_id=258">Contact Us</a> | <a href="legal_notices.html">Legal Notice </a>
                <br />
                &copy; 2009 Ramineni Law Associated, LLC. All rights reserved.
            </div>
    </form>
    </div>
    <script type="text/javascript">

        if (document.getElementById("txtDateofBirth")) {
            Calendar.setup({
                inputField: "txtDateofBirth",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_DateofBirth",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });

            Calendar.setup({
                inputField: "txtDateofFirstEntry",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_DateofFirstEntry",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });

            Calendar.setup({
                inputField: "txtDateofLastArrival",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_DateofLastArrival",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });

            Calendar.setup({
                inputField: "txtPassportIssueDate",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_PassportIssueDate",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });

            Calendar.setup({
                inputField: "txtPassportExpireDate",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_PassportExpireDate",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });

            Calendar.setup({
                inputField: "txtDateStatusExpire",     // id of the input field
                ifFormat: "%m/%d/%Y",      // format of the input field
                button: "f_DateStatusExpire",  // trigger for the calendar (button ID)
                align: "Br",           // alignment (defaults to "Bl")
                singleClick: true
            });




        }
    </script>
    <input id="flag" value="1" type="hidden" />
    <div id="loading" runat="server"></div>
</body>
</html>

